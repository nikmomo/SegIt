using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SensorDataSegmentation
{
    /// <summary>
    /// Represents a form for label selection from a predefined list.
    /// </summary>
    public partial class labelSelection : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="labelSelection"/> class.
        /// </summary>
        public labelSelection()
        {
            InitializeComponent();
            confirmButton.Click += confirmButton_Click;
            cancelButton.Click += cancelButton_Click;
            labelBox.DoubleClick += LabelBox_DoubleClick;
            labelBox.Items.AddRange(LabelList.ins.Labels.ToArray());
            labelBox.KeyDown += (s, e) => { if (e.KeyCode == Keys.Return) confirmButton.PerformClick(); };
        }

        /// <summary>
        /// Handles the double-click event on a LabelBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains no event data.</param>
        private void LabelBox_DoubleClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Gets the index of the selected item in the labels list box.
        /// </summary> 
        /// <value>The zero-based index of the currently selected item. A value of -1 indicates no selection.</value>
        public int SelectedIndex => labelBox.SelectedIndex;

        /// <summary>
        /// Handles click events on the confirm button. Validates if an item is selected and closes the form with an OK dialog result.
        ///</summary>
        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (labelBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item.");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        ///<summary>
        // Handles click events on the cancel button. Closes the form with a Cancel dialog result.
        ///</summary> 
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
