using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegIt
{
    /// <summary>
    /// Represents a singleton class that manages label and color lists for segments.
    /// </summary>
    public class LabelList
    {
        // Holds the Singleton instance of the LabelList class.
        private static readonly LabelList _instance = new LabelList();

        /// <summary>
        /// Gets the singleton instance of the LabelList class.
        /// </summary>
        public static LabelList ins => _instance;

        /// <summary>
        /// Gets the list of labels.
        /// </summary>
        public List<string> Labels { get; private set; }

        /// <summary>
        /// Gets the list of colors associated with labels.
        /// </summary>
        public List<Color> Colors { get; private set; }

        /// <summary>
        /// The order of the labels, each number in the corresponded location represent the order number
        /// </summary>
        public List<int> Order { get; set; }

        // Private constructor to prevent instance creation outside of the class and initialize list properties.
        private LabelList()
        {
            Labels = new List<string>();
            Colors = new List<Color>();
        }

        /// <summary>
        /// Initializes the label and color lists with default values.
        /// </summary>
        public void InitLists()
        {
            Labels = new List<string>
            {
                "Label1",
                "Label2",
                "Label3",
            };

            Colors = new List<Color>
            {
                Color.FromArgb(glb.ins.alpha, Color.DarkRed),
                Color.FromArgb(glb.ins.alpha, Color.Blue),
                Color.FromArgb(glb.ins.alpha, Color.DarkGreen),
            };

            //Order = new List<int> {0, 1, 2};
        }

        /// <summary>
        /// Updates the labels and their corresponding colors.
        /// </summary>
        /// <param name="labels">A list of new labels to be updated.</param>
        /// <param name="colors">A list of colors corresponding to each label. The order of colors should match the order of labels.</param>
        /// <remarks>
        /// This method assigns new lists of labels and colors to the class properties. It's important that both lists have the same length
        /// as each label is associated with a color at the same index. If there's a mismatch in length between labels and colors,
        /// unexpected behavior or runtime errors could occur when accessing these properties later.
        /// </remarks>
        public void UpdateLabels(List<string> labels, List<Color> colors)
        {
            Labels = labels;
            Colors = colors;
        }

        // Optionally, you can keep the indexer for direct access to labels
        /// <summary>
        // Provides direct access to label and color pairs by index. 
        // Returns "NONE" and Black color if index is -1, throws exception if index is out of range.
        ///</summary>
        public (string label, Color color) this[int idx]
        {
            get
            {
                if (idx == -1) return ("NONE", Color.Black);
                if (idx < 0 || idx >= Labels.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(idx), "Index is out of range.");
                }

                return (Labels[idx], Colors[idx]);
            }
        }
    };
}
