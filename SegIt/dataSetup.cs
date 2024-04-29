using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegIt
{
    /// <summary>
    /// Represents a form that allows users to setup data configurations.
    /// </summary>
    /// <remarks>
    /// This form is used to select and configure data headers for X and Y axes,
    /// as well as excluding specific headers from consideration. It supports 
    /// dynamic selection and validation of headers to ensure proper configuration.
    /// </remarks>
    public partial class dataSetup : Form
    {
        /// <summary>
        /// Gets or sets the header name for the X-axis selection.
        /// </summary>
        /// <value>
        /// The header name used to identify the selected X-axis data column.
        /// </value>
        public string SelectedXHeader { get; set; }

        /// <summary>
        /// Gets or sets the list of header names for Y-axis selections.
        /// </summary>
        /// <value>
        /// A list of header names used to identify selected Y-axis data columns.
        /// </value>
        public List<string> SelectedYHeaders { get; set; } = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="dataSetup"/> form with header information.
        /// </summary>
        /// <param name="headers">Array of header strings to be displayed and selected from.</param>
        public dataSetup(string[] headers)
        {
            InitializeComponent();

            listBoxX.SelectedIndexChanged += ListBox_SelectedIndexChanged;
            listBoxY.SelectedIndexChanged += ListBox_SelectedIndexChanged;
            listBoxEx.SelectedIndexChanged += ListBox_SelectedIndexChanged;

            moveRight1.Click += btnMoveRight_Click;
            moveRight2.Click += btnMoveRight_Click;
            moveLeft1.Click += btnMoveLeft_Click;
            moveLeft2.Click += btnMoveLeft_Click;

            // double click feature to simplify the actions
            listBoxY.DoubleClick += btnMoveRight_Click;
            listBoxEx.DoubleClick += btnMoveLeft_Click;
            listBoxX.DoubleClick += btnMoveRight_Click;

            confirmButton.Click += confirmButton_Click;
            cancelButton.Click += cancelButton_Click;

            // Add all headers to listBox2
            foreach (var header in headers)
            {
                listBoxY.Items.Add(header);
            }

            // Check for specific words and move them to listBoxX
            foreach (var header in headers)
            {
                if (header.Contains("time") ||
                    header.Contains("stamp") ||
                    header.Contains("index") ||
                    header.Contains("frame"))
                {
                    listBoxX.Items.Add(header);

                    // remove them from listBoxY
                    listBoxY.Items.Remove(header);
                }
                else if (header.Contains("label"))
                {
                    listBoxEx.Items.Add(header);

                    // remove them from listBoxY
                    listBoxY.Items.Remove(header);
                }
            }
        }

        // Clears selection in other ListBoxes when a new selection is made.
        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ListBox current = sender as ListBox;

            // Clear selections in the other ListBoxes
            foreach (Control ctrl in new[] {listBoxX, listBoxY, listBoxEx})
            {
                if (ctrl == sender)
                {
                    Console.WriteLine($"Current control is {ctrl.Name}");
                    continue;
                }
                if (!ctrl.Focused && ctrl is ListBox listBox)
                {
                    listBox.ClearSelected();
                }
            }
        }

        // Moves selected item between ListBoxes based on which button was clicked.
        private void btnMoveRight_Click(object sender, EventArgs e)
        {
            // Check which listbox has the selected item
            if (listBoxX.SelectedItem != null)
            {
                MoveSelectedItem(listBoxX, listBoxY);
            }
            else if (listBoxY.SelectedItem != null)
            {
                MoveSelectedItem(listBoxY, listBoxEx);
            }
        }

        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            // Check which listbox has the selected item
            if (listBoxY.SelectedItem != null)
            {
                MoveSelectedItem(listBoxY, listBoxX);
            }
            else if (listBoxEx.SelectedItem != null)
            {
                MoveSelectedItem(listBoxEx, listBoxY);
            }
        }

        // Transfers the selected item from one ListBox to another.
        private void MoveSelectedItem(ListBox source, ListBox target)
        {
            if (source.SelectedItem != null)
            {
                // Move the selected item to the target ListBox
                object selectedItem = source.SelectedItem;
                source.Items.Remove(selectedItem);  // Remove from source first
                target.Items.Add(selectedItem);     // Add to target
                target.SelectedItem = selectedItem; // Set the moved item as selected in the target ListBox
            }
        }

        // Finalizes the selection process. Validates selections and closes the form with an OK result.
        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (listBoxX.Items.Count != 1)
            {
                MessageBox.Show($"Must have only 1 value in {headerX.Text}.");
                return;
            }

            // Using LINQ to directly convert the ListBox items to a List of strings
            SelectedXHeader = listBoxX.Items[0].ToString();
            SelectedYHeaders = listBoxY.Items.Cast<object>().Select(item => item.ToString()).ToList();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Closes the form without making any changes. Sets dialog result to Cancel.
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
