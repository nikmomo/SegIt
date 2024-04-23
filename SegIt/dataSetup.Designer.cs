namespace SensorDataSegmentation
{
    partial class dataSetup
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
            this.components = new System.ComponentModel.Container();
            this.listBoxX = new System.Windows.Forms.ListBox();
            this.listBoxY = new System.Windows.Forms.ListBox();
            this.listBoxEx = new System.Windows.Forms.ListBox();
            this.headerX = new System.Windows.Forms.Label();
            this.headerY = new System.Windows.Forms.Label();
            this.headerEx = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.moveRight2 = new SensorDataSegmentation.NoFocusButton();
            this.moveLeft2 = new SensorDataSegmentation.NoFocusButton();
            this.moveRight1 = new SensorDataSegmentation.NoFocusButton();
            this.moveLeft1 = new SensorDataSegmentation.NoFocusButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // listBoxX
            // 
            this.listBoxX.FormattingEnabled = true;
            this.listBoxX.Location = new System.Drawing.Point(27, 31);
            this.listBoxX.Name = "listBoxX";
            this.listBoxX.Size = new System.Drawing.Size(120, 186);
            this.listBoxX.TabIndex = 0;
            this.toolTip1.SetToolTip(this.listBoxX, "Double-click an item to set its Y coordinate");
            // 
            // listBoxY
            // 
            this.listBoxY.FormattingEnabled = true;
            this.listBoxY.Location = new System.Drawing.Point(218, 31);
            this.listBoxY.Name = "listBoxY";
            this.listBoxY.Size = new System.Drawing.Size(120, 186);
            this.listBoxY.TabIndex = 1;
            this.toolTip1.SetToolTip(this.listBoxY, "Double-click an item to exclude it");
            // 
            // listBoxEx
            // 
            this.listBoxEx.FormattingEnabled = true;
            this.listBoxEx.Location = new System.Drawing.Point(409, 31);
            this.listBoxEx.Name = "listBoxEx";
            this.listBoxEx.Size = new System.Drawing.Size(120, 186);
            this.listBoxEx.TabIndex = 2;
            this.toolTip1.SetToolTip(this.listBoxEx, "Double-click an item to include it");
            // 
            // headerX
            // 
            this.headerX.AutoSize = true;
            this.headerX.Location = new System.Drawing.Point(52, 15);
            this.headerX.Name = "headerX";
            this.headerX.Size = new System.Drawing.Size(67, 13);
            this.headerX.TabIndex = 3;
            this.headerX.Text = "X coordinate";
            // 
            // headerY
            // 
            this.headerY.AutoSize = true;
            this.headerY.Location = new System.Drawing.Point(242, 15);
            this.headerY.Name = "headerY";
            this.headerY.Size = new System.Drawing.Size(68, 13);
            this.headerY.TabIndex = 4;
            this.headerY.Text = "Y Coordinate";
            // 
            // headerEx
            // 
            this.headerEx.AutoSize = true;
            this.headerEx.Location = new System.Drawing.Point(445, 15);
            this.headerEx.Name = "headerEx";
            this.headerEx.Size = new System.Drawing.Size(51, 13);
            this.headerEx.TabIndex = 5;
            this.headerEx.Text = "Excluded";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(471, 236);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(58, 23);
            this.cancelButton.TabIndex = 34;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(409, 236);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(2);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(58, 23);
            this.confirmButton.TabIndex = 33;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            // 
            // moveRight2
            // 
            this.moveRight2.BackgroundImage = global::SensorDataSegmentation.Properties.Resources.move_right;
            this.moveRight2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.moveRight2.Location = new System.Drawing.Point(361, 94);
            this.moveRight2.Name = "moveRight2";
            this.moveRight2.Size = new System.Drawing.Size(25, 25);
            this.moveRight2.TabIndex = 9;
            this.moveRight2.UseVisualStyleBackColor = true;
            // 
            // moveLeft2
            // 
            this.moveLeft2.BackgroundImage = global::SensorDataSegmentation.Properties.Resources.move_left;
            this.moveLeft2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.moveLeft2.Location = new System.Drawing.Point(361, 125);
            this.moveLeft2.Name = "moveLeft2";
            this.moveLeft2.Size = new System.Drawing.Size(25, 25);
            this.moveLeft2.TabIndex = 8;
            this.moveLeft2.UseVisualStyleBackColor = true;
            // 
            // moveRight1
            // 
            this.moveRight1.BackgroundImage = global::SensorDataSegmentation.Properties.Resources.move_right;
            this.moveRight1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.moveRight1.Location = new System.Drawing.Point(170, 94);
            this.moveRight1.Name = "moveRight1";
            this.moveRight1.Size = new System.Drawing.Size(25, 25);
            this.moveRight1.TabIndex = 7;
            this.moveRight1.UseVisualStyleBackColor = true;
            // 
            // moveLeft1
            // 
            this.moveLeft1.BackgroundImage = global::SensorDataSegmentation.Properties.Resources.move_left;
            this.moveLeft1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.moveLeft1.Location = new System.Drawing.Point(170, 125);
            this.moveLeft1.Name = "moveLeft1";
            this.moveLeft1.Size = new System.Drawing.Size(25, 25);
            this.moveLeft1.TabIndex = 6;
            this.moveLeft1.UseVisualStyleBackColor = true;
            // 
            // dataSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 277);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.moveRight2);
            this.Controls.Add(this.moveLeft2);
            this.Controls.Add(this.moveRight1);
            this.Controls.Add(this.moveLeft1);
            this.Controls.Add(this.headerEx);
            this.Controls.Add(this.headerY);
            this.Controls.Add(this.headerX);
            this.Controls.Add(this.listBoxEx);
            this.Controls.Add(this.listBoxY);
            this.Controls.Add(this.listBoxX);
            this.Name = "dataSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Data Setup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxX;
        private System.Windows.Forms.ListBox listBoxY;
        private System.Windows.Forms.ListBox listBoxEx;
        private System.Windows.Forms.Label headerX;
        private System.Windows.Forms.Label headerY;
        private System.Windows.Forms.Label headerEx;
        private NoFocusButton moveLeft1;
        private NoFocusButton moveRight1;
        private NoFocusButton moveRight2;
        private NoFocusButton moveLeft2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}