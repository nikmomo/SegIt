using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SensorDataSegmentation
{
    /// <summary>
    /// Represents a specialized <see cref="ListBox"/> that intercepts and handles
    /// left and right arrow key presses differently from the default <see cref="ListBox"/> behavior.
    /// </summary>
    public class SegmentListBox : ListBox
    {
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;

        /// <summary>
        /// Overrides the standard window procedure to intercept left and right arrow key messages.
        /// </summary>
        /// <param name="m">A Windows <see cref="Message"/> that is associated with the current Windows message.</param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_KEYDOWN || m.Msg == WM_KEYUP)
            {
                Keys keyData = (Keys)m.WParam.ToInt32();
                if (keyData == Keys.Left || keyData == Keys.Right)
                {
                    // Indicate that the message was handled
                    m.Result = IntPtr.Zero;
                    return;
                }
            }

            // Call the base class method to process all other messages
            base.WndProc(ref m);
        }
    }

}
