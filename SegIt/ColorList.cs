using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SegIt
{
    /// <summary>
    /// Represents a list of colors with predefined and randomly generated colors.
    /// </summary>
    public class ColorList
    {
        // Defines a private, static, readonly list of colors.
        // This list is initialized with 5 different colors, each defined with a level of transparency (alpha value of 100).
        private static readonly List<Color> colors = new List<Color>
        {
            Color.FromArgb(100, 100, 149, 237), // soft blue
            Color.FromArgb(100, 60, 179, 113), // muted green
            Color.FromArgb(100, 255, 165, 0), // warm orange
            Color.FromArgb(100, 147, 112, 219), // gentle purple
            Color.FromArgb(100, 119, 136, 153), // soft gray
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="ColorList"/> class,
        /// filling it with additional random colors if necessary to reach the requested total number of colors.
        /// </summary>
        /// <param name="num">The total number of required colors including predefined and randomly generated.</param>
        /// <remarks>
        /// If the number specified is less than or equal to the initial count of predefined colors,
        /// no additional random colors will be added.
        /// </remarks>
        public ColorList(int num)
        {
            Random rd = new Random();
            for (int i = 0; i < num - colors.Count; i++)
            {
                colors.Add(Color.FromArgb(100, rd.Next(0,255), rd.Next(0, 255), rd.Next(0, 255)));
            }
        }

        /// <summary>
        /// Gets the <see cref="Color"/> at the specified index from the color list.
        /// Returns a black color with specific opacity if index is out of range.
        /// </summary>
        /// <param name="index">The zero-based index of the color to get.</param>
        /// <returns>The color at the specified index or a default black color if index is out of range.</returns>
        public Color this[int index]  // Indexer declaration
        {
            get
            {
                if (index < 0 || index >= colors.Count)
                {
                    return Color.FromArgb(120, 0, 0, 0);
                }
                // Return a copy of the color
                var originalColor = colors[index];
                return Color.FromArgb(originalColor.A, originalColor.R, originalColor.G, originalColor.B);
            }
        }
    }
}
