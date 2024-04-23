using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SensorDataSegmentation
{
    /// <summary>
    /// Represents a custom button control that does not receive focus when clicked.
    /// </summary>
    public class NoFocusButton : Button
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoFocusButton"/> class.
        /// </summary>
        public NoFocusButton()
        {
            // Set the control styles on the constructor
            SetButtonControlStyles();
        }

        /// <summary>
        /// Sets the control styles to prevent the button from receiving focus.
        /// </summary>
        private void SetButtonControlStyles()
        {
            // Set the control styles to prevent the button from receiving focus
            this.SetStyle(ControlStyles.Selectable, false);
            this.SetStyle(ControlStyles.UserMouse, true);
            this.UpdateStyles();
        }

        /// <summary>
        /// Gets a value indicating whether the control should display focus rectangles.
        /// </summary>
        protected override bool ShowFocusCues
        {
            // Hide focus cues even if the control somehow receives focus.
            get { return false; }
        }

        /// <summary>
        /// Raises the MouseDown event.
        /// </summary>
        /// <param name="mevent">A MouseEventArgs that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            // Call the base method without allowing focus.
            base.OnMouseDown(mevent);
        }

        /// <summary>
        /// Raises the MouseUp event.
        /// </summary>
        /// <param name="mevent">A MouseEventArgs that contains the event data.</param>
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            // Call the base method without allowing focus.
            base.OnMouseUp(mevent);
        }

        /// <summary>
        /// Raises the GotFocus event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            // Redirect focus to the parent form if available.
            if (this.Parent != null)
            {
                this.Parent.Focus();
            }
        }

        /// <summary>
        /// Raises the Enter event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnEnter(EventArgs e)
        {
            // Do nothing upon entering to minimize visual cues/effects.
        }

        /// <summary>
        /// Raises the Leave event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnLeave(EventArgs e)
        {
            // Do nothing upon leaving to minimize visual cues/effects.
        }

        /// <summary>
        /// Raises the KeyDown event.
        /// </summary> 
        /// <param name="kevent">A KeyEventArgs that contains the event data.</param> 
        protected override void OnKeyDown(KeyEventArgs kevent)
        {
            // Ignore key events and mark as handled. 
            kevent.Handled = true;
        }

        /// <Summary> 
        /// Raises The KeyPress Event. 
        /// </Summary> 
        /// <Param Name="kpevent">A KeyPressEventArgs That Contains The Event Data.</Param> 
        protected override void OnKeyPress(KeyPressEventArgs kpevent)
        {
            // Ignore key press events
            kpevent.Handled = true;
        }
    }
}
