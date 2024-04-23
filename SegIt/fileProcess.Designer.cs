namespace SensorDataSegmentation
{
    partial class fileProcess
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sourceLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.targetTextBox = new System.Windows.Forms.TextBox();
            this.multipleLabelsCheckBox = new System.Windows.Forms.CheckBox();
            this.sourceBrowseButton = new SensorDataSegmentation.NoFocusButton();
            this.cancelButton = new SensorDataSegmentation.NoFocusButton();
            this.exportButton = new SensorDataSegmentation.NoFocusButton();
            this.targetBrowseButton = new SensorDataSegmentation.NoFocusButton();
            this.SuspendLayout();
            // 
            // sourceLabel
            // 
            this.sourceLabel.AutoSize = true;
            this.sourceLabel.Location = new System.Drawing.Point(15, 13);
            this.sourceLabel.Name = "sourceLabel";
            this.sourceLabel.Size = new System.Drawing.Size(63, 13);
            this.sourceLabel.TabIndex = 0;
            this.sourceLabel.Text = "Source File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Target Folder:";
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Enabled = false;
            this.sourceTextBox.Location = new System.Drawing.Point(97, 10);
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.Size = new System.Drawing.Size(200, 20);
            this.sourceTextBox.TabIndex = 2;
            // 
            // targetTextBox
            // 
            this.targetTextBox.Location = new System.Drawing.Point(97, 38);
            this.targetTextBox.Name = "targetTextBox";
            this.targetTextBox.Size = new System.Drawing.Size(200, 20);
            this.targetTextBox.TabIndex = 3;
            // 
            // multipleLabelsCheckBox
            // 
            this.multipleLabelsCheckBox.AutoSize = true;
            this.multipleLabelsCheckBox.Location = new System.Drawing.Point(18, 74);
            this.multipleLabelsCheckBox.Name = "multipleLabelsCheckBox";
            this.multipleLabelsCheckBox.Size = new System.Drawing.Size(194, 17);
            this.multipleLabelsCheckBox.TabIndex = 6;
            this.multipleLabelsCheckBox.Text = "Allow multiple labels in one segment";
            this.multipleLabelsCheckBox.UseVisualStyleBackColor = true;
            // 
            // sourceBrowseButton
            // 
            this.sourceBrowseButton.Enabled = false;
            this.sourceBrowseButton.Location = new System.Drawing.Point(303, 10);
            this.sourceBrowseButton.Name = "sourceBrowseButton";
            this.sourceBrowseButton.Size = new System.Drawing.Size(75, 20);
            this.sourceBrowseButton.TabIndex = 9;
            this.sourceBrowseButton.Text = "Browse...";
            this.sourceBrowseButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(312, 71);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(66, 20);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // exportButton
            // 
            this.exportButton.Enabled = false;
            this.exportButton.Location = new System.Drawing.Point(231, 71);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 20);
            this.exportButton.TabIndex = 7;
            this.exportButton.Text = "Export Files";
            this.exportButton.UseVisualStyleBackColor = true;
            // 
            // targetBrowseButton
            // 
            this.targetBrowseButton.Location = new System.Drawing.Point(303, 38);
            this.targetBrowseButton.Name = "targetBrowseButton";
            this.targetBrowseButton.Size = new System.Drawing.Size(75, 20);
            this.targetBrowseButton.TabIndex = 5;
            this.targetBrowseButton.Text = "Browse...";
            this.targetBrowseButton.UseVisualStyleBackColor = true;
            // 
            // fileProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 102);
            this.ControlBox = false;
            this.Controls.Add(this.sourceBrowseButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.multipleLabelsCheckBox);
            this.Controls.Add(this.targetBrowseButton);
            this.Controls.Add(this.targetTextBox);
            this.Controls.Add(this.sourceTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sourceLabel);
            this.Name = "fileProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sourceLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.TextBox targetTextBox;
        private NoFocusButton targetBrowseButton;
        private System.Windows.Forms.CheckBox multipleLabelsCheckBox;
        private NoFocusButton exportButton;
        private NoFocusButton cancelButton;
        private NoFocusButton sourceBrowseButton;
    }
}