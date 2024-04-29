using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegIt
{
    /// <summary>
    /// Represents a singleton class that provides functionalities related to color square generation.
    /// </summary>
    public class glb
    {
        private static readonly glb instance = new glb();

        // Prevents a default instance of the <see cref="glb"/> class from being created.
        private glb() 
        {
            alpha = 180;
        }

        /// <summary>
        /// Gets the single instance of the glb class.
        /// </summary>
        public static glb ins
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Gets the alpha component of a color, indicating its level of transparency.
        /// </summary>
        /// <value>
        /// An integer representing the alpha component, where 0 is fully transparent and 255 is fully opaque.
        /// The alpha value can only be set within the class constructor or through internal class methods, ensuring controlled modification.
        /// </value>
        public int alpha { get; private set; }

        /// <summary>
        /// Creates a bitmap image of a square filled with the specified color.
        /// </summary>
        /// <param name="color">The color to fill the square.</param>
        /// <returns>A 15x15 <see cref="Bitmap"/> filled with the specified color.</returns>
        public Bitmap getColorSquare(Color color)
        {
            Bitmap bmp = new Bitmap(15, 15);

            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.FillRectangle(new SolidBrush(color), 0, 0, 15, 15);
            }

            return bmp;
        }
    }
}
