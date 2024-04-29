using System.Windows.Forms;

namespace SegIt
{
    partial class mainForm
    {
        /// <summary>
        /// Contains a collection of components used by the form.
        /// </summary>
        /// <remarks>
        /// This field holds the set of components that the form or control uses.
        /// It is primarily used for managing the lifecycle of these components,
        /// ensuring they are properly disposed when the form or control itself is disposed.
        /// This helps prevent memory leaks by releasing managed and unmanaged resources.
        /// </remarks>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Releases the unmanaged resources used by the component and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.topFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.openDataFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cSVFilecsvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMediaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioFilemp3wavToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportLabeledFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoAddNextSeg = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.addCSVButton = new System.Windows.Forms.Label();
            this.mediaButton = new System.Windows.Forms.Label();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.totalX = new System.Windows.Forms.ToolStripStatusLabel();
            this.currentX = new System.Windows.Forms.ToolStripStatusLabel();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.audioControl = new System.Windows.Forms.TrackBar();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.dataColor = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataStartVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataDur = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.labelSettingButton = new SegIt.NoFocusButton();
            this.audioButton = new SegIt.NoFocusButton();
            this.endPointButton = new SegIt.NoFocusButton();
            this.startPointButton = new SegIt.NoFocusButton();
            this.returnButton = new SegIt.NoFocusButton();
            this.skipButton = new SegIt.NoFocusButton();
            this.playButton = new SegIt.NoFocusButton();
            this.speedUpButton = new SegIt.NoFocusButton();
            this.slowDownButton = new SegIt.NoFocusButton();
            this.addButton = new SegIt.NoFocusButton();
            this.editButton = new SegIt.NoFocusButton();
            this.delButton = new SegIt.NoFocusButton();
            this.graphCtrl = new SegIt.DataGraph();
            this.menuStrip1.SuspendLayout();
            this.statusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.audioControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topFile,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1212, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "Navigator";
            // 
            // topFile
            // 
            this.topFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.openDataFileToolStripMenuItem,
            this.openMediaToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.exportLabeledFilesToolStripMenuItem,
            this.batchExportToolStripMenuItem});
            this.topFile.Name = "topFile";
            this.topFile.Size = new System.Drawing.Size(37, 22);
            this.topFile.Text = "File";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(235, 22);
            this.toolStripMenuItem3.Text = "Open.. (Ctrl + O)";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // openDataFileToolStripMenuItem
            // 
            this.openDataFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cSVFilecsvToolStripMenuItem});
            this.openDataFileToolStripMenuItem.Name = "openDataFileToolStripMenuItem";
            this.openDataFileToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.openDataFileToolStripMenuItem.Text = "Load Data";
            // 
            // cSVFilecsvToolStripMenuItem
            // 
            this.cSVFilecsvToolStripMenuItem.Name = "cSVFilecsvToolStripMenuItem";
            this.cSVFilecsvToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cSVFilecsvToolStripMenuItem.Text = "CSV File (*.csv)";
            // 
            // openMediaToolStripMenuItem
            // 
            this.openMediaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoFileToolStripMenuItem,
            this.audioFilemp3wavToolStripMenuItem});
            this.openMediaToolStripMenuItem.Name = "openMediaToolStripMenuItem";
            this.openMediaToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.openMediaToolStripMenuItem.Text = "Load Media";
            // 
            // videoFileToolStripMenuItem
            // 
            this.videoFileToolStripMenuItem.Name = "videoFileToolStripMenuItem";
            this.videoFileToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.videoFileToolStripMenuItem.Text = "Video File (*.mp4, *.mov...)";
            // 
            // audioFilemp3wavToolStripMenuItem
            // 
            this.audioFilemp3wavToolStripMenuItem.Name = "audioFilemp3wavToolStripMenuItem";
            this.audioFilemp3wavToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.audioFilemp3wavToolStripMenuItem.Text = "Audio File (*.mp3, *.wav)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(232, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(235, 22);
            this.toolStripMenuItem1.Text = "Save (Ctrl + S)";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(235, 22);
            this.toolStripMenuItem2.Text = "Save as.. (Ctrl + Shift + S)";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // exportLabeledFilesToolStripMenuItem
            // 
            this.exportLabeledFilesToolStripMenuItem.Name = "exportLabeledFilesToolStripMenuItem";
            this.exportLabeledFilesToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.exportLabeledFilesToolStripMenuItem.Text = "Export.. (Ctrl + E)";
            this.exportLabeledFilesToolStripMenuItem.Click += new System.EventHandler(this.exportLabeledFilesToolStripMenuItem_Click);
            // 
            // batchExportToolStripMenuItem
            // 
            this.batchExportToolStripMenuItem.Name = "batchExportToolStripMenuItem";
            this.batchExportToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.batchExportToolStripMenuItem.Text = "Batch Export..";
            this.batchExportToolStripMenuItem.Click += new System.EventHandler(this.batchExportToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoAddNextSeg});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // autoAddNextSeg
            // 
            this.autoAddNextSeg.Name = "autoAddNextSeg";
            this.autoAddNextSeg.Size = new System.Drawing.Size(222, 22);
            this.autoAddNextSeg.Text = "Auto add next segment: ON";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(982, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Segmentation Manager";
            // 
            // addCSVButton
            // 
            this.addCSVButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.addCSVButton.AutoSize = true;
            this.addCSVButton.BackColor = System.Drawing.Color.Transparent;
            this.addCSVButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addCSVButton.Cursor = System.Windows.Forms.Cursors.Cross;
            this.addCSVButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addCSVButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addCSVButton.Location = new System.Drawing.Point(28, 423);
            this.addCSVButton.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.addCSVButton.Name = "addCSVButton";
            this.addCSVButton.Padding = new System.Windows.Forms.Padding(295, 70, 295, 70);
            this.addCSVButton.Size = new System.Drawing.Size(927, 168);
            this.addCSVButton.TabIndex = 18;
            this.addCSVButton.Text = "Double Click to Load CSV File";
            // 
            // mediaButton
            // 
            this.mediaButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.mediaButton.AutoSize = true;
            this.mediaButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mediaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.mediaButton.Location = new System.Drawing.Point(26, 42);
            this.mediaButton.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mediaButton.Name = "mediaButton";
            this.mediaButton.Padding = new System.Windows.Forms.Padding(290, 150, 290, 150);
            this.mediaButton.Size = new System.Drawing.Size(932, 328);
            this.mediaButton.TabIndex = 19;
            this.mediaButton.Text = "Double Click to Load Media File";
            // 
            // statusBar
            // 
            this.statusBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.totalX,
            this.currentX,
            this.status});
            this.statusBar.Location = new System.Drawing.Point(0, 605);
            this.statusBar.Name = "statusBar";
            this.statusBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusBar.Size = new System.Drawing.Size(1212, 22);
            this.statusBar.TabIndex = 20;
            this.statusBar.Text = "statusBar";
            // 
            // totalX
            // 
            this.totalX.Name = "totalX";
            this.totalX.Size = new System.Drawing.Size(0, 0);
            // 
            // currentX
            // 
            this.currentX.Name = "currentX";
            this.currentX.Size = new System.Drawing.Size(0, 0);
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 17);
            // 
            // audioControl
            // 
            this.audioControl.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.audioControl.LargeChange = 10;
            this.audioControl.Location = new System.Drawing.Point(1154, 478);
            this.audioControl.Maximum = 100;
            this.audioControl.Name = "audioControl";
            this.audioControl.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.audioControl.Size = new System.Drawing.Size(45, 90);
            this.audioControl.TabIndex = 23;
            this.audioControl.TabStop = false;
            this.audioControl.TickFrequency = 5;
            this.audioControl.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.audioControl.Visible = false;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataColor,
            this.dataLabel,
            this.dataStartVal,
            this.dataDur});
            this.dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView.GridColor = System.Drawing.Color.White;
            this.dataGridView.Location = new System.Drawing.Point(964, 68);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView.RowHeadersWidth = 30;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(221, 446);
            this.dataGridView.TabIndex = 26;
            // 
            // dataColor
            // 
            this.dataColor.FillWeight = 25F;
            this.dataColor.HeaderText = "Color";
            this.dataColor.MinimumWidth = 8;
            this.dataColor.Name = "dataColor";
            this.dataColor.ReadOnly = true;
            this.dataColor.Width = 25;
            // 
            // dataLabel
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataLabel.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataLabel.FillWeight = 60F;
            this.dataLabel.HeaderText = "Label";
            this.dataLabel.MinimumWidth = 8;
            this.dataLabel.Name = "dataLabel";
            this.dataLabel.ReadOnly = true;
            this.dataLabel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataLabel.Width = 60;
            // 
            // dataStartVal
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataStartVal.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataStartVal.FillWeight = 55F;
            this.dataStartVal.HeaderText = "Start Point";
            this.dataStartVal.MinimumWidth = 8;
            this.dataStartVal.Name = "dataStartVal";
            this.dataStartVal.ReadOnly = true;
            this.dataStartVal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataStartVal.Width = 55;
            // 
            // dataDur
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataDur.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataDur.FillWeight = 48F;
            this.dataDur.HeaderText = "Duration";
            this.dataDur.MinimumWidth = 8;
            this.dataDur.Name = "dataDur";
            this.dataDur.ReadOnly = true;
            this.dataDur.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataDur.Width = 48;
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.mediaPlayer.Enabled = true;
            this.mediaPlayer.Location = new System.Drawing.Point(37, 42);
            this.mediaPlayer.Margin = new System.Windows.Forms.Padding(2);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mediaPlayer.OcxState")));
            this.mediaPlayer.Size = new System.Drawing.Size(905, 359);
            this.mediaPlayer.TabIndex = 0;
            this.mediaPlayer.TabStop = false;
            this.mediaPlayer.Visible = false;
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 0;
            // 
            // labelSettingButton
            // 
            this.labelSettingButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelSettingButton.BackgroundImage = global::SegIt.Properties.Resources.settings;
            this.labelSettingButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.labelSettingButton.Location = new System.Drawing.Point(1160, 38);
            this.labelSettingButton.Margin = new System.Windows.Forms.Padding(2);
            this.labelSettingButton.Name = "labelSettingButton";
            this.labelSettingButton.Size = new System.Drawing.Size(25, 25);
            this.labelSettingButton.TabIndex = 25;
            this.labelSettingButton.TabStop = false;
            this.labelSettingButton.Tag = "labelCtrl";
            this.toolTip.SetToolTip(this.labelSettingButton, "Configure labels");
            this.labelSettingButton.UseVisualStyleBackColor = true;
            this.labelSettingButton.Click += new System.EventHandler(this.labelSettingButton_Click);
            // 
            // audioButton
            // 
            this.audioButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.audioButton.BackgroundImage = global::SegIt.Properties.Resources.volume_mute;
            this.audioButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.audioButton.Enabled = false;
            this.audioButton.Location = new System.Drawing.Point(1162, 566);
            this.audioButton.Margin = new System.Windows.Forms.Padding(2);
            this.audioButton.Name = "audioButton";
            this.audioButton.Size = new System.Drawing.Size(25, 25);
            this.audioButton.TabIndex = 24;
            this.audioButton.TabStop = false;
            this.audioButton.Tag = "mediaCtrl";
            this.audioButton.UseVisualStyleBackColor = true;
            // 
            // endPointButton
            // 
            this.endPointButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.endPointButton.BackgroundImage = global::SegIt.Properties.Resources.text_select_end;
            this.endPointButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.endPointButton.Enabled = false;
            this.endPointButton.Location = new System.Drawing.Point(1162, 519);
            this.endPointButton.Margin = new System.Windows.Forms.Padding(2);
            this.endPointButton.Name = "endPointButton";
            this.endPointButton.Size = new System.Drawing.Size(25, 25);
            this.endPointButton.TabIndex = 22;
            this.endPointButton.TabStop = false;
            this.endPointButton.Tag = "labelCtrl";
            this.toolTip.SetToolTip(this.endPointButton, "Set the end point of the segment (Ctrl + C)");
            this.endPointButton.UseVisualStyleBackColor = true;
            // 
            // startPointButton
            // 
            this.startPointButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.startPointButton.BackgroundImage = global::SegIt.Properties.Resources.text_select_start;
            this.startPointButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.startPointButton.Enabled = false;
            this.startPointButton.Location = new System.Drawing.Point(1133, 519);
            this.startPointButton.Margin = new System.Windows.Forms.Padding(2);
            this.startPointButton.Name = "startPointButton";
            this.startPointButton.Size = new System.Drawing.Size(25, 25);
            this.startPointButton.TabIndex = 21;
            this.startPointButton.TabStop = false;
            this.startPointButton.Tag = "labelCtrl";
            this.toolTip.SetToolTip(this.startPointButton, "Set the start point of the segment (Ctrl + X)");
            this.startPointButton.UseVisualStyleBackColor = true;
            // 
            // returnButton
            // 
            this.returnButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.returnButton.BackgroundImage = global::SegIt.Properties.Resources.skip_back;
            this.returnButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.returnButton.Enabled = false;
            this.returnButton.Location = new System.Drawing.Point(993, 566);
            this.returnButton.Margin = new System.Windows.Forms.Padding(2);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(25, 25);
            this.returnButton.TabIndex = 16;
            this.returnButton.TabStop = false;
            this.returnButton.Tag = "mediaCtrl";
            this.toolTip.SetToolTip(this.returnButton, "Skip backward 5 seconds (Left arrow)");
            this.returnButton.UseVisualStyleBackColor = true;
            // 
            // skipButton
            // 
            this.skipButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.skipButton.BackgroundImage = global::SegIt.Properties.Resources.skip_forward;
            this.skipButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.skipButton.Enabled = false;
            this.skipButton.Location = new System.Drawing.Point(1070, 566);
            this.skipButton.Margin = new System.Windows.Forms.Padding(2);
            this.skipButton.Name = "skipButton";
            this.skipButton.Size = new System.Drawing.Size(25, 25);
            this.skipButton.TabIndex = 15;
            this.skipButton.TabStop = false;
            this.skipButton.Tag = "mediaCtrl";
            this.toolTip.SetToolTip(this.skipButton, "Skip forward 5 seconds (Right arrow)\r\n");
            this.skipButton.UseVisualStyleBackColor = true;
            // 
            // playButton
            // 
            this.playButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.playButton.BackgroundImage = global::SegIt.Properties.Resources.play;
            this.playButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.playButton.Enabled = false;
            this.playButton.Location = new System.Drawing.Point(1032, 566);
            this.playButton.Margin = new System.Windows.Forms.Padding(2);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(25, 25);
            this.playButton.TabIndex = 14;
            this.playButton.TabStop = false;
            this.playButton.Tag = "mediaCtrl";
            this.toolTip.SetToolTip(this.playButton, "Play/Pause (Spacebar)");
            this.playButton.UseVisualStyleBackColor = true;
            // 
            // speedUpButton
            // 
            this.speedUpButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.speedUpButton.BackgroundImage = global::SegIt.Properties.Resources.fast_forward;
            this.speedUpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.speedUpButton.Enabled = false;
            this.speedUpButton.Location = new System.Drawing.Point(1099, 566);
            this.speedUpButton.Margin = new System.Windows.Forms.Padding(2);
            this.speedUpButton.Name = "speedUpButton";
            this.speedUpButton.Size = new System.Drawing.Size(25, 25);
            this.speedUpButton.TabIndex = 13;
            this.speedUpButton.TabStop = false;
            this.speedUpButton.Tag = "mediaCtrl";
            this.toolTip.SetToolTip(this.speedUpButton, "Speed up x0.25 (\')");
            this.speedUpButton.UseVisualStyleBackColor = true;
            // 
            // slowDownButton
            // 
            this.slowDownButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.slowDownButton.BackgroundImage = global::SegIt.Properties.Resources.fast_backward;
            this.slowDownButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.slowDownButton.Enabled = false;
            this.slowDownButton.Location = new System.Drawing.Point(964, 566);
            this.slowDownButton.Margin = new System.Windows.Forms.Padding(2);
            this.slowDownButton.Name = "slowDownButton";
            this.slowDownButton.Size = new System.Drawing.Size(26, 25);
            this.slowDownButton.TabIndex = 12;
            this.slowDownButton.TabStop = false;
            this.slowDownButton.Tag = "mediaCtrl";
            this.toolTip.SetToolTip(this.slowDownButton, "Speed down x0.25 (;)");
            this.slowDownButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.addButton.BackgroundImage = global::SegIt.Properties.Resources.plus;
            this.addButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addButton.Enabled = false;
            this.addButton.Location = new System.Drawing.Point(964, 519);
            this.addButton.Margin = new System.Windows.Forms.Padding(2);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(25, 25);
            this.addButton.TabIndex = 8;
            this.addButton.TabStop = false;
            this.addButton.Tag = "labelCtrl";
            this.toolTip.SetToolTip(this.addButton, "Add a new segment (Ctrl + Z)");
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            this.editButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.editButton.BackgroundImage = global::SegIt.Properties.Resources.edit;
            this.editButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.editButton.Enabled = false;
            this.editButton.Location = new System.Drawing.Point(993, 519);
            this.editButton.Margin = new System.Windows.Forms.Padding(2);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(25, 25);
            this.editButton.TabIndex = 7;
            this.editButton.TabStop = false;
            this.editButton.Tag = "labelCtrl";
            this.toolTip.SetToolTip(this.editButton, "Edit the label of the segment (Ctrl + Spacebar)");
            this.editButton.UseVisualStyleBackColor = true;
            // 
            // delButton
            // 
            this.delButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.delButton.BackgroundImage = global::SegIt.Properties.Resources.trash;
            this.delButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.delButton.Enabled = false;
            this.delButton.Location = new System.Drawing.Point(1022, 519);
            this.delButton.Margin = new System.Windows.Forms.Padding(2);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(25, 25);
            this.delButton.TabIndex = 6;
            this.delButton.TabStop = false;
            this.delButton.Tag = "labelCtrl";
            this.toolTip.SetToolTip(this.delButton, "Delete the segment (Del)");
            this.delButton.UseVisualStyleBackColor = true;
            // 
            // graphCtrl
            // 
            this.graphCtrl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.graphCtrl.CursorVal = 0D;
            this.graphCtrl.IsShowContextMenu = false;
            this.graphCtrl.Location = new System.Drawing.Point(24, 423);
            this.graphCtrl.Margin = new System.Windows.Forms.Padding(0);
            this.graphCtrl.Name = "graphCtrl";
            this.graphCtrl.NextCursorVal = 0D;
            this.graphCtrl.ScrollGrace = 0D;
            this.graphCtrl.ScrollMaxX = 0D;
            this.graphCtrl.ScrollMaxY = 0D;
            this.graphCtrl.ScrollMaxY2 = 0D;
            this.graphCtrl.ScrollMinX = 0D;
            this.graphCtrl.ScrollMinY = 0D;
            this.graphCtrl.ScrollMinY2 = 0D;
            this.graphCtrl.Size = new System.Drawing.Size(932, 168);
            this.graphCtrl.TabIndex = 3;
            this.graphCtrl.UseExtendedPrintDialog = true;
            this.graphCtrl.Visible = false;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1212, 627);
            this.Controls.Add(this.audioControl);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.labelSettingButton);
            this.Controls.Add(this.audioButton);
            this.Controls.Add(this.addCSVButton);
            this.Controls.Add(this.endPointButton);
            this.Controls.Add(this.startPointButton);
            this.Controls.Add(this.mediaButton);
            this.Controls.Add(this.mediaPlayer);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.skipButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.speedUpButton);
            this.Controls.Add(this.slowDownButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.graphCtrl);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1228, 666);
            this.Name = "mainForm";
            this.Text = "SegIt";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.audioControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataGraph graphCtrl;
        private NoFocusButton delButton;
        private NoFocusButton editButton;
        private NoFocusButton addButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem topFile;
        private System.Windows.Forms.ToolStripMenuItem openDataFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cSVFilecsvToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMediaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem audioFilemp3wavToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Label label1;
        private NoFocusButton slowDownButton;
        private NoFocusButton speedUpButton;
        private NoFocusButton playButton;
        private NoFocusButton returnButton;
        private System.Windows.Forms.Label addCSVButton;
        private System.Windows.Forms.Label mediaButton;
        private NoFocusButton skipButton;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.ToolStripStatusLabel totalX;
        private System.Windows.Forms.ToolStripStatusLabel currentX;
        private NoFocusButton startPointButton;
        private NoFocusButton endPointButton;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoAddNextSeg;
        private TrackBar audioControl;
        private NoFocusButton audioButton;
        private NoFocusButton labelSettingButton;
        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
        private DataGridView dataGridView;
        private DataGridViewImageColumn dataColor;
        private DataGridViewTextBoxColumn dataLabel;
        private DataGridViewTextBoxColumn dataStartVal;
        private DataGridViewTextBoxColumn dataDur;
        private ToolStripMenuItem exportLabeledFilesToolStripMenuItem;
        private ToolStripMenuItem batchExportToolStripMenuItem;
        private ToolTip toolTip;
        //private MetroFramework.Controls.MetroTrackBar metroTrackBar1;
    }
}

