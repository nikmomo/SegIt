using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace SegIt
{
    /// <summary>
    /// Represents a segment with start and end points along with an associated label.
    /// This class is structured to facilitate easy JSON export of its properties.
    /// </summary>
    public class Segment
    {
        /// <summary>
        /// Gets or sets the index of the label associated with this segment.
        /// </summary>
        public int label_idx { get; set; }

        /// <summary>
        /// Gets or sets the start point of this segment.
        /// </summary>
        public int start { get; set; }

        /// <summary>
        /// Gets or sets the end point of this segment.
        /// </summary>
        public int end { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Segment"/> class,
        /// setting both start and end points to the given startPoint value and label index to -1 (undefined).
        /// </summary>
        /// <param name="startPoint">The initial value for both start and end points of this segment.</param>
        public Segment(int startPoint)
        {
            start = startPoint;
            end = startPoint;
            label_idx = -1;
        }

    }

    /// <summary>
    /// Manages creation, configuration, and representation of segments in graphical form,
    /// handling their properties such as position, color, and labeling.
    /// </summary>
    public class SegmentHandler
    {
        /// <summary>
        /// Gets the current box object.
        /// </summary>
        public BoxObj box { get; private set; }

        /// <summary>
        /// Gets a new box object and updates the current box reference.
        /// </summary>
        /// <returns>A new <see cref="BoxObj"/> instance.</returns>
        public BoxObj newBox { get
            {
                box = CreateBox();
                return box;
            }
        }

        /// <summary>
        /// Gets the current segment object.
        /// </summary>
        public Segment segment { get; private set; }

        private double startValue;
        private double endValue;
        private int alpha;
        private Color color;

        private double minY;
        private double maxY;
        private readonly LabelList list = LabelList.ins;

        /// <summary>
        /// Initializes a new instance of the <see cref="SegmentHandler"/> class with the specified parameters.
        /// </summary>
        public SegmentHandler(int startPoint, double currentXValue, double minY, double maxY)
        {
            startValue = currentXValue;
            endValue = currentXValue + 1;
            segment = new Segment(startPoint);
            alpha = 100;

            // keep min and max Y value
            this.minY = minY;
            this.maxY = maxY;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SegmentHandler"/> class with the specified parameters.
        /// </summary>
        public SegmentHandler(Segment seg, double startX, double endX, double minY, double maxY)
        {
            startValue = startX;
            endValue = endX;
            segment = seg;
            alpha = 100;

            // keep min and max Y value
            this.minY = minY;
            this.maxY = maxY;
        }

        /// <summary>
        /// Gets or sets the starting index of the segment.
        /// </summary>
        public int StartPoint
        {
            get => segment.start;
            set
            {
                segment.start = value;
            }
        }

        /// <summary>
        /// Gets or sets the ending index of the segment.
        /// </summary>
        public int EndPoint
        {
            get => segment.end;
            set
            {
                segment.end = value;
            }
        }

        /// <summary>
        /// Gets the label of the current segment.
        /// </summary>
        public string Label => list[segment.label_idx].label;

        /// <summary>
        /// Gets the color associated with this segment's label.
        /// </summary>
        public Color Color => color;

        /// <summary>
        /// Sets the label of this segment using a specified label index and updates the color accordingly.
        /// </summary>
        /// <param name="labelValue">The index value of the label in a predefined list.</param>
        public void setLabel(int labelValue)
        {
            segment.label_idx = labelValue;
            color = list[labelValue].color;
        }

        /// <summary>
        /// Gets or sets the start value (often representing time or position on an axis) for this segment.
        /// </summary>
        public double StartValue
        {
            get => Math.Round(startValue, 2);
            set
            {
                startValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the end value (often representing time or position on an axis) for this segment.
        /// This should be greater than or equal to StartValue.
        /// </summary>
        public double EndValue
        {
            get => endValue;
            set
            {
                endValue = value;
            }
        }

        /// <summary>
        /// Calculates and gets the duration of this segment by subtracting StartValue from EndValue.
        /// The result is rounded to two decimal places.
        /// </summary>
        public double Duration => Math.Round(endValue - startValue, 2);

        // Private method to generate visual representation (BoxObj) for this segment.
        private BoxObj CreateBox()
        {

            // Convert the start and end indices of the Label to X values
            double startX = startValue;
            double endX = endValue;

            // Create a BoxObj to represent the label's range
            BoxObj newBox = new BoxObj(startX, maxY, endX - startX, maxY - minY, Color.Empty, Color.FromArgb(alpha, color));

            Console.WriteLine(newBox.Location.X1 + " " + newBox.Location.X2);

            // Customize the box
            newBox.Border.IsVisible = false;
            newBox.Fill = new Fill(Color.FromArgb(alpha, color)); // 100 is alpha for transparency

            return newBox;
        }

        /// <summary>
        /// Updates the color property of this segment to match the color associated with its current label index.
        /// </summary>
        public void UpdateColor()
        {
            color = list[segment.label_idx].color;
        }

        /// <summary>
        /// Provides a string representation of this segment, including its label, start value, and duration.
        /// </summary>
        /// <returns>A formatted string containing the label, rounded start value to two decimal places,
        /// and rounded duration (difference between end and start values) to two decimal places.</returns>
        public override string ToString()
        {
            return $"{list[segment.label_idx]} | {Math.Round(startValue, 2)} | {Math.Round(endValue - startValue, 2)}";
        }

    }
}
