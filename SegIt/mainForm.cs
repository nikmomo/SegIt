using AxWMPLib;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.Drawing.Printing;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using WMPLib;
using System.Reflection;
using System.Runtime.InteropServices;

namespace SegIt
{
    /// <summary>
    /// MainForm class for the main form of the application.
    /// </summary>
    public partial class mainForm : Form
    {
        // Window size control
        private Size _originalFormSize;
        private Dictionary<Control, Size> _originalControlSizes = new Dictionary<Control, Size>();
        private Dictionary<Control, Point> _originalControlLocations = new Dictionary<Control, Point>();
        private Dictionary<Control, float> _originalFontSizes = new Dictionary<Control, float>();

        // Media playing control
        private const decimal MIN_SPEED = 0.25M;
        private const decimal MAX_SPEED = 8.0M;
        private const decimal SPEED_INCREMENT = 0.25M;

        private const int DEFAULT_VOLUME = 50;
        private const int VOLUME_ICON_CHANGE_VAL = 30;

        private bool autoPlaying = false;  // Track auto play of the video & data
        private readonly Timer timer = new Timer();
        private decimal SPEED = 1.00M; // playing speed
        private const int TIMER_DELAY = 20;
        private bool playForward = true;
        private int lastVolume = DEFAULT_VOLUME;

        // Graph related declaration
        private double originalMinY = -1;
        private double originalMaxY = -1;
        private double originalMinX = -1;
        private double originalMaxX = -1;

        private readonly List<SegmentHandler> handlers = new List<SegmentHandler>();
        private bool toBeSaveFlag = false;
        private bool autoNextSeg = true; // automatically add next segment
        private int currentSegIndex = -1;

        private List<double> xValues; // Data x-values

        // File management
        private readonly JsonManager jsonManager;
        private readonly ShortcutManager shortcutManager;

        // status bar
        readonly Timer messageTimer = new Timer();

        /// <summary>
        /// Constructor for the mainForm class.
        /// Initializes the form and sets up event handlers.
        /// </summary>
        public mainForm()
        {
            InitializeComponent();

            // Retrieve the version information
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            string versionText = $"Version {version.Major}.{version.Minor}.{version.Build}";

            
            this.Text = $"{this.Text} - {versionText}";

            KeyPreview = true; // Catch all keyboard input
            shortcutManager = new ShortcutManager();

            Task.Run(() => // Multi-threading for shortcut declare
            {
                LabelList.ins.InitLists(); // initialize the label lists
                
                RegisterShortcuts();
            });
            jsonManager = JsonManager.ins; // json manager to read / write json

            // Media Player
            mediaPlayer.settings.autoStart = false;
            mediaPlayer.uiMode = "none";
            mediaPlayer.settings.volume = 0;

            timer.Interval = TIMER_DELAY;
            timer.Tick += (s, e) => // Timer for media update
            {
                if (autoPlaying) // If playing
                {
                    MoveMedia(playForward);
                }

                graphCtrl.UpdateGraph();
                currentX.Text = $"{graphCtrl.XVal}";
            };
            timer.Start();

            // Navigation bar
            cSVFilecsvToolStripMenuItem.Click += (s, e) => OpenCSV();
            videoFileToolStripMenuItem.Click += (s, e) => OpenMedia();

            // Event assignments

            // Set up the Windows Media Player control for the click event
            KeyDown += mainForm_KeyDown;

            // Graph
            graphCtrl.MouseClick += graphCtrl_MouseClick;

            // DataGridView
            dataGridView.DoubleClick += (s, e) => ChooseLabel();
            dataGridView.SelectionChanged += dataGridView_SelectionChanged;
            dataGridView.RowPostPaint += dataGridView_RowPostPaint;
            dataGridView.CellPainting += dataGridView_CellPainting;

            // Label list buttons
            editButton.Click += (s, e) => ChooseLabel();
            delButton.Click += delButton_Click;
            addButton.Click += (s, e) => AddNewSegment();

            //// Loading button
            //loadVideoButton.Click += loadVideoButton_Click;
            addCSVButton.DoubleClick += (s, e) => OpenCSV();

            // Player control buttons
            playButton.Click += PlayButton_Click;
            skipButton.Click += (s, e) => { MoveMedia(true); };
            returnButton.Click += (s, e) => { MoveMedia(false); };
            skipButton.Click += (s, e) => { SkipForSeconds(true, 5); };
            returnButton.Click += (s, e) => { SkipForSeconds(false, 5); };
            speedUpButton.Click += (s, e) => { SpeedCtrl(true); };
            slowDownButton.Click += (s, e) => { SpeedCtrl(false); };
            startPointButton.Click += (s, e) => { CreateOrAdjustLabel(true); };
            mediaButton.DoubleClick += (s, e) => { OpenMedia(); };
            endPointButton.Click += (s, e) => { CreateOrAdjustLabel(false); };
            audioButton.MouseEnter += audioButton_MouseEnter;
            audioButton.MouseLeave += audioButton_MouseLeave;
            audioControl.MouseLeave += audioControl_MouseLeave;
            audioButton.Click += audioButton_Click;
            audioControl.ValueChanged += audioControl_VolumeChanged;

            // top navigation
            videoFileToolStripMenuItem.Click += (s, e) => { OpenMedia(); };
            this.autoAddNextSeg.Click += (s, e) =>
            {
                autoNextSeg = !autoNextSeg;
                autoAddNextSeg.Text = "Auto add next segment: " + (autoNextSeg ? "ON" : "OFF");
            };

        }

        // MainForm hotkeys 
        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            this.Focus();  // Shifts focus to the form
            if (!shortcutManager.ExecuteShortcut(e.KeyData))
            {
                return;
            }
        }

        // Register shortcut using shortcut manager
        private void RegisterShortcuts()
        {
            // Ctrl+Shift TODO
            //shortcutManager.RegisterShortcut(Keys.Control | Keys.Shift | Keys.S, SaveAsFunction); 

            // Ctrl
            shortcutManager.RegisterShortcut(Keys.Control | Keys.X, () => CreateOrAdjustLabel(true));
            shortcutManager.RegisterShortcut(Keys.Control | Keys.C, () => CreateOrAdjustLabel(false));
            shortcutManager.RegisterShortcut(Keys.Control | Keys.S, SaveFunction);
            shortcutManager.RegisterShortcut(Keys.Control | Keys.Shift | Keys.S,() => toolStripMenuItem2_Click(this, null));
            shortcutManager.RegisterShortcut(Keys.Control | Keys.Z, AddNewSegment);
            shortcutManager.RegisterShortcut(Keys.Control | Keys.Space, ChooseLabel);
            shortcutManager.RegisterShortcut(Keys.Control | Keys.E, exportLabeledFilesToolStripMenuItem.PerformClick);
            shortcutManager.RegisterShortcut(Keys.Control | Keys.O, () => toolStripMenuItem3_Click(this, null));
            shortcutManager.RegisterShortcut(Keys.Control | Keys.L, labelSettingButton.PerformClick);

            // Single Click
            shortcutManager.RegisterShortcut(Keys.Space, () => PlayButton_Click(this, null));
            shortcutManager.RegisterShortcut(Keys.Escape, () => graphCtrl.ZoomOutAll(graphCtrl.GraphPane));
            shortcutManager.RegisterShortcut(Keys.Left, () => SkipForSeconds(false, 5));
            shortcutManager.RegisterShortcut(Keys.Right, () => SkipForSeconds(true, 5));
            shortcutManager.RegisterShortcut(Keys.L, () =>
            {
                autoPlaying = true;
                UpdateMediaPlay();
                PlaySpeedAndDirCtrl(true, false);
            });
            shortcutManager.RegisterShortcut(Keys.J, () =>
            {
                autoPlaying = true;
                UpdateMediaPlay();
                PlaySpeedAndDirCtrl(false, false);
            });
            shortcutManager.RegisterShortcut(Keys.K, () =>
            {
                SPEED = 1;
                PlaySpeedAndDirCtrl(true, true);
                PlayButton_Click(this, null);
            });
            shortcutManager.RegisterShortcut(Keys.OemSemicolon, () =>
            {
                autoPlaying = true;
                UpdateMediaPlay();
                SpeedCtrl(false);
            });
            shortcutManager.RegisterShortcut(Keys.OemQuotes, () =>
            {
                autoPlaying = true;
                UpdateMediaPlay();
                SpeedCtrl(true);
            });
            shortcutManager.RegisterShortcut(Keys.OemPeriod, () => SkipForSeconds(true, 1));
            shortcutManager.RegisterShortcut(Keys.Oemcomma, () => SkipForSeconds(false, 1));
            shortcutManager.RegisterShortcut(Keys.Back, () => delButton_Click(this, null));
            shortcutManager.RegisterShortcut(Keys.Delete, () => delButton_Click(this, null));
            shortcutManager.RegisterShortcut(Keys.Up, () => dataGridView_MoveSelection(true));
            shortcutManager.RegisterShortcut(Keys.Down, () => dataGridView_MoveSelection(false));

        }

        // Method to save the data.
        private void SaveFunction()
        {
            if (!toBeSaveFlag)
            {
                DisplayMessage($"{"Can not be saved because of no updates"}", MessageType.Error);
                return;
            }
            jsonManager.Segments = GetSegments();
            bool result = jsonManager.SaveSegments();
            if (result)
            {
                DisplayMessage($"{"File saved to " + jsonManager.fileName}", MessageType.Info);
                RemoveToBeSaveFlag();
            }
            else DisplayMessage($"{"Failed to save to " + jsonManager.fileName}", MessageType.Error);
        }

        // Reset the main form and clear all segments and graph.
        private void ResetMain()
        {
            ClearSegments();
            graphCtrl.CursorVal = 0;  // Start X position of the cursor
            autoPlaying = false;  // Track auto play of the video & data
            SPEED = 1; // playing speed
            playForward = true;


            // Label related declaration
            currentSegIndex = -1;

            if (xValues != null)
                xValues.Clear(); // Data x-values
        }

        /// <summary>
        /// Called when the form is loaded. Stores the original size, location,
        /// and font size of the form and its controls for later use.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Store the original form size
            _originalFormSize = this.Size;

            // Store the original size and location of all controls
            foreach (Control c in this.Controls)
            {
                _originalControlSizes[c] = c.Size;
                _originalControlLocations[c] = c.Location;
                _originalFontSizes[c] = c.Font.Size;
            }
        }

        /// <summary>
        /// Handles the form's Resize event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            //// Ensure the form is not minimized and the original size is not zero to avoid division by zero
            //if (this.WindowState == FormWindowState.Minimized || _originalFormSize.Width == 0 || _originalFormSize.Height == 0)
            //{
            //    return;
            //}

            //// Choose a leading dimension
            //float scalingFactor = (float)this.ClientSize.Width / _originalFormSize.Width;

            //// Scale controls based on their original size and location
            //foreach (Control c in this.Controls)
            //{
            //    // Continue if the control is not in the original size dictionary
            //    if (!_originalControlSizes.ContainsKey(c) || !_originalControlLocations.ContainsKey(c)) continue;

            //    // Reset to original size and location before applying scaling
            //    c.Size = _originalControlSizes[c];
            //    c.Location = _originalControlLocations[c];

            //    // Now apply scaling
            //    Size originalSize = _originalControlSizes[c];
            //    int newWidth = (int)(originalSize.Width * scalingFactor);
            //    int newHeight = (int)(originalSize.Height * scalingFactor);
            //    c.Size = new Size(newWidth, newHeight);

            //    Point originalLocation = _originalControlLocations[c];
            //    c.Location = new Point((int)(originalLocation.X * scalingFactor), (int)(originalLocation.Y * scalingFactor));

            //    // Scale font if applicable
            //    if (_originalFontSizes.ContainsKey(c))
            //    {
            //        float originalFontSize = _originalFontSizes[c];
            //        c.Font = new Font(c.Font.FontFamily, originalFontSize * scalingFactor, c.Font.Style);
            //    }
            //}
        }

        /// BUTTON METHODS STARTS ----------------%

        // media control methods

        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (!playButton.Enabled) return;
            playForward = true;
            autoPlaying = !autoPlaying;  // Toggle cursor movement
            UpdateMediaPlay();
        }

        // Label management

        // Perform delete segment task
        private void delButton_Click(object sender, EventArgs e)
        {
            if (currentSegIndex == -1) return;

            graphCtrl -= handlers[currentSegIndex].box; // remove the label box

            handlers.RemoveAt(currentSegIndex);

            dataGridView.Rows.RemoveAt(currentSegIndex);

            currentSegIndex = -1;

            graphCtrl.UpdateGraphAndBackground();
        }

        // Save
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!toBeSaveFlag)
            {
                DisplayMessage($"{"Can not be saved because of no updates"}", MessageType.Error);
                return;
            }
            jsonManager.Segments = GetSegments();
            jsonManager.SaveSegments();
        }

        private readonly object ThreadSafeLock = new object();

        // Handles the click event on a menu item to load a SegIt file.
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "SegIt Files|*.sgit";
            ofd.Title = "Select a SegIt File";

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            jsonManager.LoadJSON(ofd.FileName);
            // if has data address, load it
            if (jsonManager.DataAddress != null)
            {
                if (!OpenCSV(jsonManager.DataAddress))
                    return;
            }
            // if has video address, load it
            if (jsonManager.VideoAddress != null)
                OpenMedia(jsonManager.VideoAddress);

            // if doesn't have any segments, return
            if (jsonManager.Segments == null) return;
            var segments = jsonManager.Segments;

            LabelList.ins.UpdateLabels(jsonManager.Labels, LabelList.ins.Colors);

            // push all segments to the list using multi-threading
            Parallel.ForEach(segments, seg =>
            {
                var startX = (seg.start == -1) ? 0 : xValues[seg.start];
                var endX = (seg.end == -1) ? originalMaxX : xValues[seg.end];
                var label = seg.label_idx;
                Color color = (label == -1) ? Color.FromArgb(glb.ins.alpha, 0, 0, 0) : LabelList.ins.Colors[label];

                SegmentHandler handler = new SegmentHandler(seg, startX, endX, originalMinY, originalMaxY);
                handler.setLabel(label);

                // Synchronize the non-thread-safe operations
                this.Invoke((MethodInvoker)(() =>
                {
                    AddTolabelList(handler); // Assuming this interacts with UI
                    graphCtrl += handler.newBox; // UI update
                }));
            });

            graphCtrl.UpdateGraphAndBackground();

            DisplayMessage($"Sgit file loaded", MessageType.Info);

        }

        // Toggles audio between muted and last set volume when the audio button is clicked
        private void audioButton_Click(object sender, EventArgs e)
        {
            int volume = audioControl.Value;
            Console.WriteLine($"Current value: {volume}");

            if (volume == 0)
            {
                volume = lastVolume;
            }
            else
            {
                lastVolume = volume;
                volume = 0;
            }
            audioControl.Value = volume;
            UpdateVolumeImage();
        }

        // Updates media player's volume based on user interaction with the control element. Also updates UI accordingly
        private void audioControl_VolumeChanged(object sender, EventArgs e)
        {
            mediaPlayer.settings.volume = audioControl.Value;
            UpdateVolumeImage();
        }

        // Update the image of the audioButton if the volume is changed
        private void UpdateVolumeImage()
        {
            int volume = audioControl.Value;
            Bitmap audioImage = (volume == 0) ? Properties.Resources.volume_mute :
                                (volume < VOLUME_ICON_CHANGE_VAL) ? Properties.Resources.volume_half :
                                                                    Properties.Resources.volume_full;

            audioButton.BackgroundImage = audioImage;
        }

        // Shows the audio control when the mouse enters the area of the audio button.
        private void audioButton_MouseEnter(object sender, EventArgs e)
        {
            audioControl.Visible = true;
        }

        // Hides the audio control when the mouse leaves the area of the audio button,
        // but only if it's not currently over the audio control itself.
        private void audioButton_MouseLeave(object sender, EventArgs e)
        {
            // Check if the mouse is still over audioControl
            if (!IsMouseOverControl(audioControl))
            {
                audioControl.Visible = false;
            }
        }

        // Hides the audio control when the mouse leaves its area,
        // but only if it's not currently over the button that triggers its display.
        private void audioControl_MouseLeave(object sender, EventArgs e)
        {
            // Check if the mouse is still over audioButton
            if (!IsMouseOverControl(audioButton))
            {
                audioControl.Visible = false;
            }
        }

        // Utility function to determine if the mouse pointer is currently over a given control.
        // This helps in making decisions about showing or hiding UI elements based on user interaction.
        private bool IsMouseOverControl(Control control)
        {
            // Convert the current mouse screen position to a point relative to the control
            Point clientCursorPosition = control.PointToClient(Cursor.Position);

            // Check if the mouse is within the control bounds
            return control.ClientRectangle.Contains(clientCursorPosition);
        }

        /// BUTTON METHODS ENDS ----------------%

        /// SEGMENTATION METHODS STARTS  ----------------%

        // Choose a label from label window
        private void ChooseLabel()
        {
            if (currentSegIndex == -1) return;
            using (labelSelection prompt = new labelSelection())
            {
                if (prompt.ShowDialog(this) == DialogResult.OK)
                {
                    int index = prompt.SelectedIndex;
                    //removeSegBox(currentSegIndex);
                    graphCtrl -= handlers[currentSegIndex].box;

                    handlers[currentSegIndex].setLabel(index);
                    graphCtrl += handlers[currentSegIndex].newBox;

                    // Use the selectedIndex here
                    UpdateDataAndGraph(currentSegIndex);
                }
            }

            graphCtrl.UpdateGraphAndBackground();
            AutoCheckAndAddSeg();
        }

        // Load listBox values
        private void UpdateDataAndGraph(int idx)
        {
            if (idx == -1) return;

            SegmentHandler s = handlers[idx];
            //removeSegBox(currentSegIndex);
            graphCtrl -= s.box;
            s.UpdateColor();
            graphCtrl += s.newBox;

            dataGridView.Rows[idx].Cells["dataLabel"].Value = s.Label;
            dataGridView.Rows[idx].Cells["dataStartVal"].Value = s.StartValue;
            dataGridView.Rows[idx].Cells["dataDur"].Value = s.Duration;
            dataGridView.Rows[idx].Cells["dataColor"].Value = glb.ins.getColorSquare(s.Color);
            dataGridView.Sort(dataGridView.Columns["dataStartVal"], ListSortDirection.Ascending);

        }

        // handler of when selectedIndex changed
        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count <= 0) return;

            currentSegIndex = dataGridView.SelectedRows[0].Index;

        }

        // Adds a new SegmentHandler object to the list and reflects this addition in the DataGridView.
        private void AddTolabelList(SegmentHandler s)
        {
            //int handlerIndex = handlers.Count; // get the current handler index
            handlers.Add(s); // add new handler to the list

            // Add a new row to the grid
            int rowIndex = dataGridView.Rows.Add();

            // Set the values for each column
            dataGridView.Rows[rowIndex].Cells["dataLabel"].Value = s.Label;
            dataGridView.Rows[rowIndex].Cells["dataStartVal"].Value = s.StartValue; // Instead use startPoint, use start value to represent the starting point
            dataGridView.Rows[rowIndex].Cells["dataDur"].Value = s.Duration;
            dataGridView.Rows[rowIndex].Cells["dataColor"].Value = glb.ins.getColorSquare(s.Color);
            dataGridView.Sort(dataGridView.Columns["dataStartVal"], ListSortDirection.Ascending);

            dataGridView.Rows[rowIndex].Selected = true; // Select the row
            dataGridView.CurrentCell = dataGridView.Rows[rowIndex].Cells[0]; // Set the indicator to the current row

        }

        // Initiates creation of a new segment and updates UI accordingly.
        private void AddNewSegment()
        {
            if (!addButton.Enabled) return;
            RaiseToBeSaveFlag();
            currentSegIndex = -1;
            CreateOrAdjustLabel(true); // get a new label

            if (currentSegIndex != -1) // handle the exception condition
                DisplayMessage($"{"New segment added at " + Math.Round(handlers[currentSegIndex].StartValue, 2)}", MessageType.Info);
        }

        // Clear all segments and graph drawing
        private void ClearSegments()
        {
            handlers.Clear();
            dataGridView.Rows.Clear();

        }

        // Print out row index
        private void dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Use the RowIndex property of the DataGridViewRowPostPaintEventArgs to display the row number
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            // Get the display rectangle of the row header cell area
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);

            // Draw the row number
            TextRenderer.DrawText(e.Graphics, rowIdx, grid.RowHeadersDefaultCellStyle.Font, headerBounds, grid.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        // Print out color icon
        private void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Check if we are in the row header
            if (e.ColumnIndex == 0 && e.RowIndex == -1)
            {
                // Paint the background
                e.PaintBackground(e.CellBounds, true);

                // Draw your icon here
                var icon = Properties.Resources.rgb;

                var iconLocation = new Point(
                    e.CellBounds.X + (e.CellBounds.Width - icon.Width) / 2,
                    e.CellBounds.Y + (e.CellBounds.Height - icon.Height) / 2);

                e.Graphics.DrawImage(icon, iconLocation);

                // Prevent the DataGridView from painting the header cell with its default appearance
                e.Handled = true;
            }
        }

        // Method to move the selection within the DataGridView up or down based on user action.
        private void dataGridView_MoveSelection(bool isUp)
        {
            var grid = dataGridView;

            int maxRowIndex = grid.Rows.Count - 1;
            int currentIndex = grid.CurrentCell.RowIndex;

            if (isUp)
            {
                // Move selection up
                int prevIndex = currentIndex - 1;
                if (prevIndex >= 0) // Check if it's not the first row
                {
                    grid.ClearSelection();
                    //grid.CurrentCell = grid.Rows[prevIndex].Cells[grid.CurrentCell.ColumnIndex];
                    grid.Rows[prevIndex].Selected = true;
                }
            }
            else
            {
                // Move selection down
                int nextIndex = currentIndex + 1;
                if (nextIndex <= maxRowIndex) // Check if it's not the last row
                {
                    grid.ClearSelection();
                    //grid.CurrentCell = grid.Rows[nextIndex].Cells[grid.CurrentCell.ColumnIndex];
                    grid.Rows[nextIndex].Selected = true;
                }
            }
        }

        /// SEGMENTATION METHODS ENDS  ----------------%

        /// GRAPH RELATED METHODS STARTS  ----------------%

        // Method to load CSV data into a graphical representation, such as a graph control.
        private bool LoadCSVIntoGraph(string filePath)
        {
            // clear all graph first
            ClearSegments();
            graphCtrl.ClearGraph();

            xValues = new List<double>();

            List<List<double>> yValues = new List<List<double>>(); // A list to take all yValues

            ColorList colorList;
            string[] headers;

            using (StreamReader sr = new StreamReader(filePath))
            {
                // Read title line
                string line = sr.ReadLine();
                headers = line.Split(',');

                // Assuming the headers are now in the headers array
                // Display your dialog here
                using (dataSetup dataSetupDialog = new dataSetup(headers))
                {
                    var result = dataSetupDialog.ShowDialog(this);
                    if (result == DialogResult.Cancel)
                    {
                        return false;
                    }
                    if (result == DialogResult.OK)
                    {
                        // Get the selected headers for X and Y coordinates
                        var selectedXHeader = dataSetupDialog.SelectedXHeader;
                        var selectedYHeaders = dataSetupDialog.SelectedYHeaders;

                        // Find the indexes of the selected headers
                        int xIndex = Array.IndexOf(headers, selectedXHeader);
                        List<int> yIndices = selectedYHeaders.Select(yHeader => Array.IndexOf(headers, yHeader)).ToList();

                        // Initialize yValues lists based on the number of Y columns
                        foreach (var yIndex in yIndices)
                        {
                            if (yIndex != -1) // Ensure the index is valid
                            {
                                yValues.Add(new List<double>());
                            }
                        }

                        // Read data
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] parts = line.Split(','); // Assuming comma-separated values

                            // Parse and add the X value
                            if (xIndex != -1 && double.TryParse(parts[xIndex], out double xValue))
                            {
                                xValues.Add(xValue);
                            }

                            // Parse and add the Y values
                            for (int i = 0; i < yIndices.Count; i++)
                            {
                                int yIndex = yIndices[i];
                                if (yIndex != -1 && double.TryParse(parts[yIndex], out double yValue))
                                {
                                    yValues[i].Add(yValue);
                                }
                            }
                        }
                    }
                }
            }

            colorList = new ColorList(yValues.Count);

            totalX.Text = $"{Math.Round(xValues[xValues.Count - 1], 1)} /";

            // Add data to the graph
            for (int i = 0; i < yValues.Count; i++)
            {
                graphCtrl.GraphPane.AddCurve(null, xValues.ToArray(), yValues[i].ToArray(), Color.FromArgb(100, colorList[i]), SymbolType.None);
            }

            graphCtrl.AxisChange();

            graphCtrl.UpdateBuffers();

            if (mediaPlayer.URL != null)
            {
                UpdateMediaPosition();
            }

            // Update the overall min max Y value
            originalMinY = graphCtrl.GraphPane.YAxis.Scale.Min;
            originalMaxY = graphCtrl.GraphPane.YAxis.Scale.Max;
            originalMinX = graphCtrl.GraphPane.XAxis.Scale.Min;
            originalMaxX = graphCtrl.GraphPane.XAxis.Scale.Max;

            return true;
        }

        // Move the cursor to the corresponding position
        private void graphCtrl_MouseClick(object sender, MouseEventArgs e)
        {
            if (graphCtrl.IsDragging || e.Button != MouseButtons.Left) return;
            double xVal, yVal;
            graphCtrl.GraphPane.ReverseTransform(e.Location, out xVal, out yVal);
            graphCtrl.CursorVal = xVal < 0 ? 0 : xVal; // If the xVal is out of scope, then set the cursor to 0

            UpdateMediaPosition();
        }

        // Function to find the index of the value in xValues that is closest to the graph cursor's X value.
        private int GetCurrentXIndex()
        {
            int left = 0;
            int right = xValues.Count - 1;
            int closestIndex = -1;
            double closestDistance = double.MaxValue;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                double distance = Math.Abs(xValues[mid] - graphCtrl.CursorVal);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestIndex = mid;
                }

                if (xValues[mid] < graphCtrl.CursorVal)
                {
                    left = mid + 1;
                }
                else if (xValues[mid] > graphCtrl.CursorVal)
                {
                    right = mid - 1;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("current Index: " + closestIndex + "current X:" + xValues[closestIndex]);
            return closestIndex;
        }

        // Open csv file
        private void OpenCSV()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV Files|*.csv";
            ofd.Title = "Select a CSV File";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                OpenCSV(ofd.FileName);
            }
        }

        // Attempts to open and load a CSV file into the graph control, also handling UI updates.
        private bool OpenCSV(string fileName)
        {
            ResetMain();
            if (!LoadCSVIntoGraph(fileName))
                return false;
            jsonManager.DataAddress = fileName;

            graphCtrl.Visible = true;
            addCSVButton.Visible = false;
            foreach (Control ctrl in Controls)
            {
                if (ctrl.Tag == null) continue;
                if (ctrl.Tag.ToString() == "mediaCtrl" || ctrl.Tag.ToString() == "labelCtrl")
                {
                    ctrl.Enabled = true;
                }

            }
            
            DisplayMessage($"CSV loaded", MessageType.Info);

            labelSettingButton_Click(this, null); // Perform a mouse click to set the labels
            return true;
        }

        // adjust label if it's existed, create one if index is -1
        // if it is start of the segement, then isStart = true
        private void CreateOrAdjustLabel(bool isStart)
        {
            if (!addButton.Enabled) return;

            int currentIndex = GetCurrentXIndex();

            if (currentSegIndex == -1)
            {
                var newLabel = new SegmentHandler(currentIndex, graphCtrl.CursorVal, originalMinY, originalMaxY);
                Console.WriteLine(newLabel);
                AddTolabelList(newLabel);
            }
            else
            {
                AdjustExistingLabel(isStart, currentIndex);
                graphCtrl -= handlers[currentSegIndex].box;
            }

            if (currentSegIndex != -1)
            {
                graphCtrl += handlers[currentSegIndex].newBox;
            }

            graphCtrl.UpdateGraphAndBackground();

            UpdateDataAndGraph(currentSegIndex);
        }

        // Adjusts the start or end values of an existing segment based on cursor position.
        private void AdjustExistingLabel(bool isStart, int currentIndex)
        {
            int index = currentSegIndex;

            var currentXValue = graphCtrl.CursorVal;
            var handler = handlers[index];

            if ((isStart && currentXValue > handler.EndValue) ||
                (!isStart && currentXValue < handler.StartValue))
            {
                DisplayMessage("Use ctrl + Z to create new segment", MessageType.Error);
                return;
            }

            if (isStart)
            {
                handler.StartPoint = currentIndex;
                handler.StartValue = currentXValue;
            }
            else
            {
                handler.EndPoint = currentIndex;
                handler.EndValue = currentXValue;
            }

        }

        // Adjusts the start or end values of an existing segment based on cursor position.
        private void AutoCheckAndAddSeg()
        {
            if (GetCurrentXIndex() == -1) return;

            if (autoNextSeg && currentSegIndex == handlers.Count - 1 &&
                handlers[currentSegIndex].segment.label_idx != -1)
            {
                AddNewSegment();
            }
        }

        /// GRAPH RELATED METHODS ENDS  ----------------%

        /// MEDIA METHODS STARTS  ----------------%

        // Updates the media player's position based on the graph control's cursor value.
        private void UpdateMediaPosition()
        {
            var newPos = graphCtrl.CursorVal;

            mediaPlayer.Ctlcontrols.currentPosition = newPos;

            if (mediaPlayer.URL != null && mediaPlayer.playState == WMPLib.WMPPlayState.wmppsPaused) // move 1 tick only work for paused state
            {
                mediaPlayer.Ctlcontrols.play();
                mediaPlayer.Ctlcontrols.pause();

            }

            graphCtrl.UpdateBuffers();

            currentX.Text = $":{graphCtrl.XVal}";
        }

        // Opens a dialog for selecting and opening a video file, updating related controls accordingly.
        private void OpenMedia()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.flv;*.mkv;*.mov;*.wmv";
                openFileDialog.Title = "Select a Video File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    OpenMedia(openFileDialog.FileName);
                    jsonManager.VideoAddress = openFileDialog.FileName;
                    autoPlaying = false;
                }
            }
        }

        // Loads specified video file into the media player, setting UI visibility and displaying a message.
        private void OpenMedia(string fileName)
        {
            mediaPlayer.URL = fileName;
            mediaPlayer.uiMode = "none";

            mediaPlayer.Visible = true;
            mediaButton.Visible = false;
            DisplayMessage($"Video loaded", MessageType.Info);
        }

        // Moves media playback forward or backward by simulating playback speed and direction changes. 
        private void MoveMedia(bool isForward)
        {
            // When the video is not available
            if (mediaButton.Visible)
            {
                graphCtrl.CursorVal += (isForward ? 1 : -1) * TIMER_DELAY * (float)SPEED * 0.002;
                return;
            }

            // When is moving backward
            if (!isForward && autoPlaying)
            {
                mediaPlayer.Ctlcontrols.play();
                mediaPlayer.Ctlcontrols.currentPosition -= TIMER_DELAY * (float)SPEED * 0.002; // Time 2 because counteract the forward play
                mediaPlayer.Ctlcontrols.pause();
            }
            var lastCursor = graphCtrl.CursorVal;
            graphCtrl.CursorVal = mediaPlayer.Ctlcontrols.currentPosition;

            graphCtrl.NextCursorVal = (graphCtrl.CursorVal * 2) - lastCursor;

        }

        // Toggles automatic play/pause state of the media based on user interaction, updating UI accordingly.
        private void UpdateMediaPlay()
        {
            if (autoPlaying)
            {
                mediaPlayer.Ctlcontrols.play();
                DisplayMessage("Playing", MessageType.Info);
            }
            else
            {
                mediaPlayer.Ctlcontrols.pause();
                DisplayMessage("Paused", MessageType.Info);
            }
            playButton.BackgroundImage = autoPlaying ? Properties.Resources.pause : Properties.Resources.play;
        }

        // Skip the play for 5 second
        private void SkipForSeconds(bool isForward, int second)
        {
            var skipFrame = isForward ? second : -second;
            double newPosition = graphCtrl.CursorVal + skipFrame;
            if (newPosition < 0)
            {
                newPosition = 0;
            }
            graphCtrl.CursorVal = newPosition;

            UpdateMediaPosition();
            if (isForward) DisplayMessage("Skipped forward " + $"{second}"
            + " seconds", MessageType.Info);
            else DisplayMessage("Skipped backward " + $"{second}"
            + " seconds", MessageType.Info);
        }

        // Controls the play speed and direction of media playback.
        private void PlaySpeedAndDirCtrl(bool isForward, bool reset)
        {
            // If the direction is not equal reset the speed
            SPEED = reset ? 1.0M : 0.0M;
            playForward = isForward;
            SpeedCtrl(true);
        }

        // Adjusts media playback speed up or down, ensuring it stays within defined limits.
        private void SpeedCtrl(bool isSpeedUp)
        {
            SPEED += isSpeedUp ? SPEED_INCREMENT : -SPEED_INCREMENT;
            if (SPEED < MIN_SPEED) SPEED = MIN_SPEED;
            else if (SPEED > MAX_SPEED) SPEED = MAX_SPEED;

            // The timer interval remains consistent. Only the amount moved (or processed) per tick changes.
            mediaPlayer.settings.rate = (float)SPEED;
            DisplayMessage($"{(isSpeedUp ? "Forward " : "Backward") + "speed: x" + SPEED}", MessageType.Info);
        }

        /// MEDIA METHODS ENDS  ----------------%

        /// JSON S/L METHODS STARTS  ----------------%

        // Retrieves an array of Segment objects currently managed by handlers.
        private Segment[] GetSegments()
        {
            Segment[] segments = new Segment[handlers.Count];

            Parallel.For(0, handlers.Count, i =>
            {
                segments[i] = handlers[i].segment;
            });

            return segments;
        }

        // Flags that there are changes pending save, indicating unsaved work with a visual clue (*).
        private void RaiseToBeSaveFlag()
        {
            if (toBeSaveFlag)
                return;
            toBeSaveFlag = true;
            Text += " *";
        }

        // Clears the save flag indicator when changes have been saved or reverted, removing visual clue (*).
        private void RemoveToBeSaveFlag()
        {
            toBeSaveFlag = false;
            Text = Text.Replace(" *", "");
        }

        /// JSON S/L METHODS ENDS  ----------------%

        /// STATUS BAR STARTS  ----------------%

        /// <summary>
        /// Represents the type of message to display.
        /// </summary>
        public enum MessageType
        {
            Info,
            Warning,
            Error
        }

        /// <summary>
        /// Displays a message with color coding based on the type of message. The message will auto-clear after a set time interval.
        /// </summary>
        /// <param name="message">The text of the message to display.</param>
        /// <param name="type">The type of the message which dictates the color in which it is displayed. Uses the MessageType enumeration.</param>
        public void DisplayMessage(string message, MessageType type)
        {
            switch (type)
            {
                case MessageType.Info:
                    status.ForeColor = Color.Black;
                    break;
                case MessageType.Warning:
                    status.ForeColor = Color.DarkOrange;
                    break;
                case MessageType.Error:
                    status.ForeColor = Color.DarkRed;
                    break;
            }

            status.Text = message;

            messageTimer.Stop();  // Stop any existing timer
            messageTimer.Interval = 5000;
            messageTimer.Tick += (s, e) =>
            {
                status.Text = "";
                messageTimer.Stop();
                status.ForeColor = Color.Black;
            };
            messageTimer.Start();
        }

        /// STATUS BAR ENDS  ----------------%

        // Event handler for when the label setting button is clicked.
        private void labelSettingButton_Click(object sender, EventArgs e)
        {
            using (labelSetting prompt = new labelSetting())
            {
                if (prompt.ShowDialog(this) == DialogResult.OK)
                {
                    RaiseToBeSaveFlag();

                    for (var n = 0; n < handlers.Count; n++)
                    {
                        UpdateDataAndGraph(n);
                    }
                    graphCtrl.UpdateGraphAndBackground();
                }
            }
        }

        // Event handler for exporting labeled files via menu item click. 
        private void exportLabeledFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (fileProcess fileproc = new fileProcess(GetSegments()))
            {
                fileproc.ShowDialog(this);
            }
        }

        // Event handler for initiating batch export via menu item click. 
        private void batchExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (fileProcess fileproc = new fileProcess())
            {
                fileproc.ShowDialog(this);
            }
        }
    }
}
