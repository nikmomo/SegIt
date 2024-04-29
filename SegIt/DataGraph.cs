using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace SegIt
{
    /// <summary>
    /// Represents a specialized <see cref="ZedGraphControl"/> for displaying sensor data with dynamic updates.
    /// </summary>
    public class DataGraph : ZedGraphControl
    {
        /// <summary>
        /// Gets or sets the current cursor value.
        /// </summary>
        public double CursorVal { get; set; } = 0;

        /// <summary>
        /// Gets or sets the next cursor value for updating the graph.
        /// </summary>
        public double NextCursorVal { get; set; } = 0;

        /// <summary>
        /// Gets the rounded X-value of the cursor location on the graph.
        /// </summary>
        public double XVal {
            get { return Math.Round(CursorVal, 1); }
        }

        /// <summary>
        /// Indicates whether the graph is currently being dragged.
        /// </summary>
        public bool IsDragging = false;

        private Point mouseDownPoint = Point.Empty;// To store the point where mouse button was pressed down.
        private Bitmap background; // To store the background bitmap
        private Bitmap backBuffer; // To store the next print bitmap;
        private Bitmap axisBuffer; // To store axis

        private readonly object backBufferLock = new object();
        private readonly object axisLock = new object();

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGraph"/> class with default settings.
        /// </summary>
        public DataGraph()
        {
            InitializeGraphSettings();
        }

        // Initializes default settings for this instance of DataGraph.
        private void InitializeGraphSettings()
        {
            // Graph initialization
            this.GraphPane.CurveList.Clear();
            this.GraphPane.XAxis.Title.IsVisible = false;
            this.GraphPane.YAxis.Title.IsVisible = false;
            this.GraphPane.X2Axis.IsVisible = false;
            this.GraphPane.Y2Axis.IsVisible = false;
            this.GraphPane.Title.IsVisible = false;
            this.GraphPane.Border.IsVisible = false;
            this.GraphPane.XAxis.Scale.FontSpec.Size = 24;
            this.GraphPane.YAxis.Scale.FontSpec.Size = 24;
            this.IsShowContextMenu = false; // Disable the menu

            // Graph Color setting
            this.GraphPane.Chart.Fill = new Fill(this.BackColor);
            this.GraphPane.Fill = new Fill(this.BackColor);

            // Set up a handler for mouse click to control zooming behavior
            this.MouseClick += DataGraph_MouseClick;
            this.MouseDownEvent += DataGraph_MouseDown;
            this.MouseMove += DataGraph_MouseMove;
            this.MouseUpEvent += DataGraph_MouseUp;

            // Zoom handler
            this.ZoomEvent += (s, o, n) => { UpdateGraphAndBackground();  };

        }

        // Right click for zooming out
        private void DataGraph_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Zoom out to the last zoom state on a right-click
                this.ZoomOut(this.GraphPane);
            }
        }

        // Handles the MouseMove event for the DataGraph.
        private void DataGraph_MouseMove(object sender, MouseEventArgs e)
        {
            // If the left button is held down, check if the mouse is moving
            if (e.Button == MouseButtons.Left)
            {
                if (Math.Abs(mouseDownPoint.X - e.X) > SystemInformation.DoubleClickSize.Width ||
                    Math.Abs(mouseDownPoint.Y - e.Y) > SystemInformation.DoubleClickSize.Height)
                {
                    // If the mouse has moved significantly, it's a drag
                    IsDragging = true;
                    //Console.WriteLine("MouseMove triggered!");
                }
            }
        }

        // Handle mouseDown, return false to continue process other operations
        private bool DataGraph_MouseDown(ZedGraphControl sender, MouseEventArgs e)
        {
            // If the left button is pressed, record the starting point
            if (e.Button == MouseButtons.Left)
            {
                mouseDownPoint = new Point(e.X, e.Y);
                IsDragging = false;
                //Console.WriteLine("MouseDown triggered!");
            }

            return false;
        }

        // Handle mouseUp, return false to continue process other operations
        private bool DataGraph_MouseUp(ZedGraphControl sender, MouseEventArgs e)
        {
            // When the mouse is released, reset the dragging flag
            IsDragging = false;
            mouseDownPoint = Point.Empty;
            //Console.WriteLine("MouseUp triggered!");

            return false;
        }

        // Return the Xvalue of the cursor location
        public float GetLocation()
        {
            return this.GraphPane.XAxis.Scale.Transform(CursorVal);
        }

        // Return the predicted location for backBuffer
        private float GetNextLocation()
        {
            return this.GraphPane.XAxis.Scale.Transform(NextCursorVal);
        }

        /// <summary>
        /// Clears all curves and graphical objects from the graph.
        /// </summary>
        public void ClearGraph()
        {
            this.GraphPane.CurveList.Clear();
            this.GraphPane.GraphObjList.Clear();
        }

        /// <summary>
        /// Adds a graphical object to the graph.
        /// </summary>
        /// <param name="lhs">The DataGraph instance.</param>
        /// <param name="rhs">The BoxObj to be added to the graph.</param>
        /// <returns>The modified DataGraph instance with the added graphical object.</returns>
        public static DataGraph operator +(DataGraph lhs, BoxObj rhs)
        {
            lhs.GraphPane.GraphObjList.Add(rhs);

            return lhs;
        }

        /// <summary>
        /// Removes a graphical object from the graph.
        /// </summary>
        /// <param name="lhs">The DataGraph instance.</param>
        /// <param name="rhs">The BoxObj to be removed from the graph.</param>
        /// <returns>The modified DataGraph instance with the graphical object removed.</returns>
        public static DataGraph operator -(DataGraph lhs, BoxObj rhs)
        {
            lhs.GraphPane.GraphObjList.Remove(rhs);

            return lhs;
        }

        /// <summary>
        /// Updates both buffers and refreshes the graph display.
        /// </summary>
        public void UpdateGraphAndBackground()
        {
            UpdateBuffers();
            UpdateGraph();
        }

        ///<summary> 
        /// Refreshes the display of the graph using a back buffer to reduce flicker. 
        ///<para>This method updates both cursor location on screen and redraws entire graphic area based on current data in backBuffer bitmap.</para>  
        ///<para>It ensures that if backBuffer is not available (null), no operation occurs, preventing errors.</para>  
        ///<remarks>It's important that after drawing, backBuffer is updated to reflect any changes made during this draw cycle for consistency in future updates.</remarks>  
        ///</summary>  
        public void UpdateGraph()
        {
            if (backBuffer == null) return;

            Bitmap bmp;

            lock (backBufferLock)
            {
                bmp = (Bitmap)backBuffer.Clone();
            }

            using (Graphics g = this.CreateGraphics())
            {
                g.DrawImage(bmp, 0, 0);
                bmp?.Dispose();
            }
            UpdateBackBuffer();

        }

        /// <summary>
        /// Updates both axis and background buffers, then refreshes the graph display.
        /// </summary>
        public void UpdateBuffers()
        {

            UpdateAxisBuffer();

            background?.Dispose();
            background = new Bitmap(this.Width, this.Height);

            this.DrawToBitmap(background, new Rectangle(0, 0, this.Width, this.Height));

            NextCursorVal = CursorVal;
            UpdateBackBuffer();
        }

        /* Updates the back buffer bitmap asynchronously.
         * This process includes drawing the current cursor position and axis onto the background.
         */
        private void UpdateBackBuffer()
        {
            Task.Run(() =>
            {
                Bitmap bmp;
                if (background == null) return;
                bmp = (Bitmap)background.Clone();

                float cursorPixelX = this.GetNextLocation();

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    using (Pen pen = new Pen(Color.DarkRed, 2)) // Color and width of the pen
                    {
                        g.DrawLine(pen, cursorPixelX, 0, cursorPixelX, this.Height);
                    }

                    // Draw the axis bitmap onto the backBuffer
                    lock (axisLock)
                    {
                        if (axisBuffer != null)
                        {
                            // Use the same Graphics object to draw the axisBuffer onto bmp
                            g.DrawImageUnscaled(axisBuffer, 0, 0);
                        }
                    }
                }

                lock (backBufferLock)
                {
                    backBuffer?.Dispose(); // Dispose the old buffer
                    backBuffer = bmp; // Assign the new buffer
                }

            });
        }

        /* Asynchronously updates the axis buffer bitmap. 
         * This involves redrawing axes and clearing their backgrounds for transparency.
         */
        private void UpdateAxisBuffer()
        {
            GraphPane axisPane = GraphPane.Clone();
            Task.Run(() =>
            {
                Bitmap bmp = new Bitmap(this.Width, this.Height);

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    axisPane.GraphObjList.Clear();

                    // Draw the pane to the specified graphics object
                    axisPane.AxisChange(g);
                    axisPane.Draw(g);

                    // Get the rectangle that bounds the chart area
                    RectangleF plotRect = axisPane.Chart.Rect;

                    // Clear the plotting area to make it transparent
                    g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                    g.FillRectangle(new SolidBrush(Color.Transparent), plotRect);
                }

                lock (axisLock)
                {
                    axisBuffer?.Dispose(); // Dispose the old buffer
                    axisBuffer = bmp;
                }
                //bmp.Save("bmp.png", System.Drawing.Imaging.ImageFormat.Png);
            });
        }
    }
}
