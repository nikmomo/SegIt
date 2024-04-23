using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SensorDataSegmentation
{
    /// <summary>
    /// Represents a form used for processing and exporting files with segments data.
    /// </summary>
    public partial class fileProcess : Form
    {
        private Segment[] _segments; // Array holding segment data to be processed.
        private readonly object _jsonManagerLock = new object(); // Lock object for thread-safe JSON management.

        /// <summary>
        /// Initializes a new instance of the <see cref="fileProcess"/> class without specific segments.
        /// </summary>
        public fileProcess() : this(null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="fileProcess"/> class with specified segments.
        /// </summary>
        /// <param name="segments">Array of segments to be processed and exported.</param>
        public fileProcess(Segment[] segments)
        {
            _segments = segments;

            InitializeComponent();

            sourceTextBox.Text = JsonManager.ins.DataAddress; // only leave the folder address
            targetBrowseButton.Click += (sender, e) => { BrowseFolder(targetTextBox); };

            if (segments == null) // null means it's batch exporting, not single file exports
            {
                sourceTextBox.Text = Path.GetDirectoryName(JsonManager.ins.DataAddress); // only leave the folder address
                sourceBrowseButton.Click += (sender, e) => { BrowseFolder(sourceTextBox); };
                sourceBrowseButton.Enabled = true;
                sourceTextBox.Enabled = true;
                sourceLabel.Text = "Source Folder:";
            }

            exportButton.Click += (sender, e) => { ExportFiles(sourceTextBox.Text, targetTextBox.Text, multipleLabelsCheckBox.Checked); };
            cancelButton.Click += cancelButton_Click;

        }

        // Opens folder browser dialog and sets text box with selected path.
        private void BrowseFolder(TextBox textBox)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox.Text = folderBrowserDialog.SelectedPath;
                    if (textBox.Name == "sourceTextBox" && targetTextBox.Text == string.Empty)
                        targetTextBox.Text = folderBrowserDialog.SelectedPath;
                    if(sourceTextBox.Text != string.Empty && targetTextBox.Text != string.Empty)
                        exportButton.Enabled = true;
                    
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Exports files based on specified parameters.
        private void ExportFiles(string sourcePath, string targetPath, bool allowMultipleLabels)
        {
            if (File.Exists(sourcePath)) // if the source path is a file path then that means not batch export
            {
                string labeledFilePath = GenerateLabeledFilePath(sourcePath, targetPath);
                ExportFile(_segments, sourcePath, labeledFilePath, allowMultipleLabels);
                MessageBox.Show($"File Exported", "Export Files");

                DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            var files = Directory.EnumerateFiles(sourcePath, "*.sgit", SearchOption.TopDirectoryOnly);
            //JsonManager currentState = JsonManager.ins;
            JsonManager.ins.StoreCurrentState(); // store everything that currently have

            Parallel.ForEach(files, (filePath) =>
            {
                Console.WriteLine($"Processing file: {filePath}");
                Segment[] segments;
                string dataPath;
                lock (_jsonManagerLock)
                {
                    JsonManager.ins.LoadJSON(filePath);
                    segments = JsonManager.ins.Segments;
                    LabelList.ins.UpdateLabels(JsonManager.ins.Labels, JsonManager.ins.Colors);
                    dataPath = JsonManager.ins.DataAddress;
                }

                string labeledFilePath = GenerateLabeledFilePath(dataPath, targetPath);
                ExportFile(segments, dataPath, labeledFilePath, allowMultipleLabels);

            });

            MessageBox.Show($"Exported files from '{sourcePath}' to '{targetPath}' ", "Export Files");
            JsonManager.ins.LoadCurrentState();

            DialogResult = DialogResult.OK;
            this.Close();
        }

        // Conducts actual file processing and labeling based on provided data.
        private void ExportFile(Segment[] segments, string sourcePath, string targetPath, bool allowMultipleLabels)
        {
            // Check if the source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source folder does not exist.");
                return;
            }

            // Read all lines from the source CSV file
            var lines = File.ReadAllLines(sourcePath);

            // Prepare a list to hold the modified lines with the new "label" column
            var modifiedLines = new List<string>();

            // Assuming the first line contains headers
            if (lines.Length > 0)
            {
                // Append the "label" column to the header row
                modifiedLines.Add(lines[0] + ",label");
            }

            
            // Determine the last index of the dataset, excluding the header
            int lastIndex = lines.Length - 1; 

            // Process each line in the file, excluding the header
            for (int i = 1; i < lines.Length; i++)
            {
                List<string> labels = new List<string>(); // Initialize list to collect labels
                // Check each segment to see if the current line's index falls within a segment's range
                foreach (var seg in segments)
                {
                    // Adjust StartPoint and EndPoint according to the special conditions
                    int adjustedStartPoint = seg.start == -1 ? 0 : seg.start;
                    int adjustedEndPoint = seg.end == -1 ? lastIndex : seg.end;

                    // Convert the 1-based index of lines to 0-based for comparison
                    int currentIndex = i - 1;

                    // If the current index is within the range of the adjusted segment, use this segment's label
                    if (currentIndex >= adjustedStartPoint && currentIndex <= adjustedEndPoint)
                    {
                        labels.Add(LabelList.ins[seg.label_idx].label);
                        if (!allowMultipleLabels)
                        {
                            break; // If not allowing multiple labels, take the first match and exit loop
                        }
                    }
                }

                //Console.WriteLine(i.ToString(), labels.Count());
                // Concatenate labels if multiple are allowed, or just use the single found label
                string label = string.Join(",", labels); // Join labels with a semicolon or your chosen delimiter

                // Append the collected label(s) to each line
                modifiedLines.Add(lines[i] + (string.IsNullOrEmpty(label) ? "" : "," + label));
            }

            // Write the modified lines to the target CSV file
            File.WriteAllLines(targetPath, modifiedLines, Encoding.UTF8); // TODO: make csv add _labeled to avoid conflicts

            Console.WriteLine("Export completed successfully.");
        }

        // Generates a file path with "_labeled" appended before the extension for exported files.
        private string GenerateLabeledFilePath(string sourcePath, string targetPath)
        {
            // Extract the file name without the extension from the source path
            string sourceFileNameWithoutExtension = Path.GetFileNameWithoutExtension(sourcePath);

            // Get the file extension
            string fileExtension = Path.GetExtension(sourcePath);

            // Construct the new file name with '_labeled' appended before the extension
            string newFileName = $"{sourceFileNameWithoutExtension}_labeled{fileExtension}";

            // If targetPath is a directory, combine it with the new file name
            // If targetPath is a full path (directory + file name), replace the file name in targetPath with newFileName
            // This check ensures that the method works whether targetPath is a directory or a full path
            string targetDirectory = Directory.Exists(targetPath) ? targetPath : Path.GetDirectoryName(targetPath);
            string labeledFilePath = Path.Combine(targetDirectory, newFileName);

            return labeledFilePath;
        }
    }
}
