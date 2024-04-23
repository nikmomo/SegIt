namespace SensorDataSegmentation
{
    partial class labelSelection
    {
        // Required designer variable.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(labelSelection));
            this.labelBox = new System.Windows.Forms.ListBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelBox
            // 
            this.labelBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBox.FormattingEnabled = true;
            this.labelBox.ItemHeight = 16;
            this.labelBox.Location = new System.Drawing.Point(21, 20);
            this.labelBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.labelBox.Name = "labelBox";
            this.labelBox.Size = new System.Drawing.Size(121, 116);
            this.labelBox.TabIndex = 0;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(21, 171);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(58, 23);
            this.confirmButton.TabIndex = 1;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(83, 171);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(58, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // labelSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(172, 206);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.labelBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "labelSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select the label";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox labelBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
    }
}