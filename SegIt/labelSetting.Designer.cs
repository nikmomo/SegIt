namespace SegIt
{
    partial class labelSetting
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(labelSetting));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.dataColor = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cancelButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.export = new SegIt.NoFocusButton();
            this.import = new SegIt.NoFocusButton();
            this.moveBottom = new SegIt.NoFocusButton();
            this.moveDown = new SegIt.NoFocusButton();
            this.moveUp = new SegIt.NoFocusButton();
            this.moveTop = new SegIt.NoFocusButton();
            this.addButton = new SegIt.NoFocusButton();
            this.delButton = new SegIt.NoFocusButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataColor,
            this.dataLabel});
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView.GridColor = System.Drawing.Color.White;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.RowHeadersWidth = 30;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(227, 239);
            this.dataGridView.TabIndex = 27;
            // 
            // dataColor
            // 
            this.dataColor.FillWeight = 40F;
            this.dataColor.HeaderText = "Color";
            this.dataColor.MinimumWidth = 8;
            this.dataColor.Name = "dataColor";
            this.dataColor.ReadOnly = true;
            this.dataColor.Width = 40;
            // 
            // dataLabel
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataLabel.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataLabel.HeaderText = "Label";
            this.dataLabel.MinimumWidth = 8;
            this.dataLabel.Name = "dataLabel";
            this.dataLabel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataLabel.Width = 150;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(181, 257);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(58, 23);
            this.cancelButton.TabIndex = 32;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(119, 257);
            this.confirmButton.Margin = new System.Windows.Forms.Padding(2);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(58, 23);
            this.confirmButton.TabIndex = 31;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 200;
            this.toolTip.AutoPopDelay = 4000;
            this.toolTip.InitialDelay = 200;
            this.toolTip.ReshowDelay = 40;
            // 
            // export
            // 
            this.export.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.export.BackgroundImage = global::SegIt.Properties.Resources.outport;
            this.export.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.export.Location = new System.Drawing.Point(243, 226);
            this.export.Margin = new System.Windows.Forms.Padding(2);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(25, 25);
            this.export.TabIndex = 38;
            this.export.TabStop = false;
            this.export.Tag = "";
            this.toolTip.SetToolTip(this.export, "Export label configurations");
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // import
            // 
            this.import.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.import.BackgroundImage = global::SegIt.Properties.Resources.import;
            this.import.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.import.Location = new System.Drawing.Point(243, 197);
            this.import.Margin = new System.Windows.Forms.Padding(2);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(25, 25);
            this.import.TabIndex = 37;
            this.import.TabStop = false;
            this.import.Tag = "";
            this.toolTip.SetToolTip(this.import, "Import label configurations");
            this.import.UseVisualStyleBackColor = true;
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // moveBottom
            // 
            this.moveBottom.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.moveBottom.BackgroundImage = global::SegIt.Properties.Resources.move_last;
            this.moveBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.moveBottom.Location = new System.Drawing.Point(243, 131);
            this.moveBottom.Margin = new System.Windows.Forms.Padding(2);
            this.moveBottom.Name = "moveBottom";
            this.moveBottom.Size = new System.Drawing.Size(25, 25);
            this.moveBottom.TabIndex = 36;
            this.moveBottom.TabStop = false;
            this.moveBottom.Tag = "move";
            this.moveBottom.UseVisualStyleBackColor = true;
            this.moveBottom.Visible = false;
            // 
            // moveDown
            // 
            this.moveDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.moveDown.BackgroundImage = global::SegIt.Properties.Resources.move_down;
            this.moveDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.moveDown.Location = new System.Drawing.Point(243, 103);
            this.moveDown.Margin = new System.Windows.Forms.Padding(2);
            this.moveDown.Name = "moveDown";
            this.moveDown.Size = new System.Drawing.Size(25, 25);
            this.moveDown.TabIndex = 35;
            this.moveDown.TabStop = false;
            this.moveDown.Tag = "move";
            this.moveDown.UseVisualStyleBackColor = true;
            this.moveDown.Visible = false;
            // 
            // moveUp
            // 
            this.moveUp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.moveUp.BackgroundImage = global::SegIt.Properties.Resources.move_up;
            this.moveUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.moveUp.Location = new System.Drawing.Point(243, 74);
            this.moveUp.Margin = new System.Windows.Forms.Padding(2);
            this.moveUp.Name = "moveUp";
            this.moveUp.Size = new System.Drawing.Size(25, 25);
            this.moveUp.TabIndex = 34;
            this.moveUp.TabStop = false;
            this.moveUp.Tag = "move";
            this.moveUp.UseVisualStyleBackColor = true;
            this.moveUp.Visible = false;
            // 
            // moveTop
            // 
            this.moveTop.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.moveTop.BackgroundImage = global::SegIt.Properties.Resources.move_top;
            this.moveTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.moveTop.Location = new System.Drawing.Point(243, 46);
            this.moveTop.Margin = new System.Windows.Forms.Padding(2);
            this.moveTop.Name = "moveTop";
            this.moveTop.Size = new System.Drawing.Size(25, 25);
            this.moveTop.TabIndex = 33;
            this.moveTop.TabStop = false;
            this.moveTop.Tag = "move";
            this.moveTop.UseVisualStyleBackColor = true;
            this.moveTop.Visible = false;
            // 
            // addButton
            // 
            this.addButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.addButton.BackgroundImage = global::SegIt.Properties.Resources.plus;
            this.addButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addButton.Location = new System.Drawing.Point(11, 256);
            this.addButton.Margin = new System.Windows.Forms.Padding(2);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(25, 25);
            this.addButton.TabIndex = 30;
            this.addButton.TabStop = false;
            this.addButton.Tag = "labelCtrl";
            this.toolTip.SetToolTip(this.addButton, "Add a new label");
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // delButton
            // 
            this.delButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.delButton.BackgroundImage = global::SegIt.Properties.Resources.trash;
            this.delButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.delButton.Location = new System.Drawing.Point(40, 256);
            this.delButton.Margin = new System.Windows.Forms.Padding(2);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(25, 25);
            this.delButton.TabIndex = 28;
            this.delButton.TabStop = false;
            this.delButton.Tag = "labelCtrl";
            this.toolTip.SetToolTip(this.delButton, "Delete the label");
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // labelSetting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(280, 293);
            this.ControlBox = false;
            this.Controls.Add(this.export);
            this.Controls.Add(this.import);
            this.Controls.Add(this.moveBottom);
            this.Controls.Add(this.moveDown);
            this.Controls.Add(this.moveUp);
            this.Controls.Add(this.moveTop);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.dataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "labelSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configure Labels";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private NoFocusButton addButton;
        private NoFocusButton delButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.DataGridViewImageColumn dataColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataLabel;
        private NoFocusButton moveTop;
        private NoFocusButton moveUp;
        private NoFocusButton moveBottom;
        private NoFocusButton moveDown;
        private NoFocusButton import;
        private NoFocusButton export;
        private System.Windows.Forms.ToolTip toolTip;
    }
}