using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SensorDataSegmentation
{
    /// <summary>
    /// Form for setting labels and colors.
    /// </summary>
    public partial class labelSetting : Form
    {
        readonly LabelList _list = LabelList.ins;
        List<string> labels;
        List<Color> colors;

        private List<int> _order = LabelList.ins.Order;

        /// <summary>
        /// Initializes a new instance of the <see cref="labelSetting"/> class.
        /// </summary>
        public labelSetting()
        {
            InitializeComponent();

            toolTip.SetToolTip(this.moveUp, "Move the selected row up by one position.");
            toolTip.SetToolTip(this.moveDown, "Move the selected row down by one position.");
            toolTip.SetToolTip(this.moveTop, "Move the selected row to the top.");
            toolTip.SetToolTip(this.moveBottom, "Move the selected row to the bottom.");

            dataGridView.RowPostPaint += dataGridView_RowPostPaint;
            dataGridView.CellPainting += dataGridView_CellPainting;
            dataGridView.CellMouseEnter += dataGridView_CellMouseEnter;
            dataGridView.CellMouseLeave += dataGridView_CellMouseLeave;
            dataGridView.CellClick += dataGridView_CellClick;
            dataGridView.CellEndEdit += dataGridView_CellEndEdit;

            confirmButton.Click += confirmButton_Click;
            cancelButton.Click += cancelButton_Click;

            moveUp.Click += moveRow_Click;
            moveDown.Click += moveRow_Click;
            moveTop.Click += moveRow_Click;
            moveBottom.Click += moveRow_Click;

            labels = _list.Labels;
            colors = _list.Colors;

            updateGridFromLabels();
        }

        // Method to handle the RowPostPaint event, rendering row numbers in the DataGridView's row header.
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

        // Method to customize painting of cells - specifically for drawing an icon in a header cell.
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

        // Method triggered on clicking a cell. Specifically for handling color changes via ColorDialog.
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;

            if (e.ColumnIndex == dataGridView.Columns["dataColor"].Index && idx >= 0)
            {
                // Launch the ColorDialog
                using (ColorDialog colorDialog = new ColorDialog())
                {
                    // Get the current color of the cell to set it as the dialog's initial selection
                    Color currentColor = ((Bitmap)dataGridView[e.ColumnIndex, idx].Value).GetPixel(0, 0);
                    colorDialog.Color = currentColor;

                    // Show the dialog and check if the user selected a color
                    if (colorDialog.ShowDialog() == DialogResult.OK)
                    {
                        Color color = Color.FromArgb(glb.ins.alpha, colorDialog.Color);
                        // Set the new color
                        dataGridView[e.ColumnIndex, idx].Value = glb.ins.getColorSquare(color);
                        dataGridView.InvalidateCell(e.ColumnIndex, idx);

                        colors[idx] = color;
                    }
                }
            }
        }

        // Update cursor
        private void dataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            switch (e.ColumnIndex)
            {
                case 0: // "dataColor" column
                    dataGridView.Cursor = Cursors.Hand;
                    break;
                case 1: // "dataLabel" column
                    dataGridView.Cursor = Cursors.IBeam;
                    break;

            }
        }

        // Handles the event when the mouse pointer leaves a cell in the DataGridView.
        private void dataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            dataGridView.Cursor = Cursors.Default;

        }

        // update list value
        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            // Perform a check to ensure that you are working with the correct column if necessary
            if (dataGridView.Columns[e.ColumnIndex].Name == "dataLabel")
            {
                
                // The new value after edit
                string newValue = dataGridView.Rows[idx].Cells[e.ColumnIndex].Value as string;

                labels[idx] = newValue;
            }
        }

        // Handles the Confirm button click event to validate and update labels and colors.
        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (labels.Count != colors.Count)
            {
                Console.WriteLine($"Label count != color count, {labels.Count} != {colors.Count}");
            }
            else
            {
                LabelList.ins.UpdateLabels(labels, colors);
            }
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Handles Cancel button click event to close form without making changes.
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Handles Add button click event to add a new label with a random color to the grid.
        private void addButton_Click(object sender, EventArgs e)
        {
            // Add a new row to the grid
            int rowIndex = dataGridView.Rows.Add();

            Random rd = new Random();
            Color color = Color.FromArgb(glb.ins.alpha, rd.Next(0, 255), rd.Next(0, 255), rd.Next(0, 255));
            colors.Add(color);
            labels.Add("Label");

            Bitmap bmp = glb.ins.getColorSquare(color);
            dataGridView.Rows[rowIndex].Cells["dataColor"].Value = bmp;
            dataGridView.Rows[rowIndex].Cells["dataLabel"].Value = labels[rowIndex];
        }

        // Handles Delete button click event to remove selected rows from grid and associated lists.
        private void delButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView.SelectedRows)
            {
                int idx = item.Index;
                // Make sure it's not attempting to delete a new row
                if (!item.IsNewRow)
                {
                    dataGridView.Rows.RemoveAt(idx);
                    labels.RemoveAt(idx);
                    colors.RemoveAt(idx);
                }
            }
        }

        // Handles Move Row buttons' click events to reorder rows in DataGridView along with their data in lists.
        private void moveRow_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count == 0) return;

            Button btn = sender as Button;
            if (btn == null) return;

            int rowIndex = dataGridView.CurrentCell?.RowIndex ?? -1;
            if (rowIndex < 0) return;

            try
            {
                DataGridViewRow selectedRow = dataGridView.Rows[rowIndex];
                int newIndex = -1;

                switch (btn.Name)
                {
                    case "moveUp":
                        newIndex = rowIndex > 0 ? rowIndex - 1 : -1;
                        break;
                    case "moveDown":
                        newIndex = rowIndex < dataGridView.Rows.Count - 1 ? rowIndex + 1 : -1;
                        break;
                    case "moveTop":
                        newIndex = 0;
                        break;
                    case "moveBottom":
                        newIndex = dataGridView.Rows.Count - 1;
                        break;
                }

                if (newIndex >= 0 && newIndex < dataGridView.Rows.Count)
                {
                    // Suspend layout to avoid unnecessary repaints
                    dataGridView.SuspendLayout();

                    // Move the row in the DataGridView
                    dataGridView.Rows.Remove(selectedRow);
                    dataGridView.Rows.Insert(newIndex, selectedRow);

                    // Move the corresponding label and color in the lists
                    int itemidx = _order[rowIndex];
                    //_order.RemoveAt(rowIndex);
                    //_order.Insert(newIndex, itemidx);
                    //string label = labels[rowIndex];
                    //Color color = colors[rowIndex];
                    //labels.RemoveAt(rowIndex);
                    //colors.RemoveAt(rowIndex);
                    //labels.Insert(newIndex, label);
                    //colors.Insert(newIndex, color);

                    //TODO: Current idea is to use list int as order tracker, access that location can return the corresponded item. Everytime when open this window, give current labels a id to track the changes. when adding new labels, only increase the id number. When removing the label, leave that id blank.

                    // Update DataGridView selection
                    dataGridView.ClearSelection();
                    dataGridView.Rows[newIndex].Selected = true;
                    dataGridView.CurrentCell = dataGridView.Rows[newIndex].Cells[0];

                    // Resume layout and refresh to show changes
                    //dataGridView.ResumeLayout();
                    //dataGridView.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Handle Export button click event for saving current labels into a file using SaveFileDialog prompt dialog box when confirmed by user. 
        private void export_Click(object sender, EventArgs e)
        {
            if (labels.Count != colors.Count)
            {
                Console.WriteLine($"Label count != color count, {labels.Count} != {colors.Count}");
            }
            else
            {
                LabelList.ins.UpdateLabels(labels, colors);
            }
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Labels";
            saveFileDialog.Filter = "SegIt Label It Files (*.lbit)|*.lbit";
            saveFileDialog.DefaultExt = "lbit";
            saveFileDialog.AddExtension = true;
            saveFileDialog.FileName = "MyDataLabels"; // Default file name

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                JsonManager.ins.SaveLabels(saveFileDialog.FileName);
            }
        }

        // Handle Import button by loading labels from user specified file using OpenFileDialog. Updates grid data accordingly after loading.
        private void import_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "SegIt label Files (*.lbit)|*.lbit";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                JsonManager.ins.LoadLabels(openFileDialog.FileName);

                labels = LabelList.ins.Labels;
                colors = LabelList.ins.Colors;

                updateGridFromLabels();
            }
        }

        // Updates the DataGridView from the labels and colors.
        private void updateGridFromLabels()
        {
            dataGridView.Rows.Clear();
            
            for (int n = 0; n < labels.Count; n++)
            {
                // Add a new row to the grid
                int rowIndex = dataGridView.Rows.Add();

                // Set the values for each column
                dataGridView.Rows[rowIndex].Cells["dataLabel"].Value = labels[n];
                dataGridView.Rows[rowIndex].Cells["dataColor"].Value = glb.ins.getColorSquare(colors[n]);

            }
        }
    }
}
