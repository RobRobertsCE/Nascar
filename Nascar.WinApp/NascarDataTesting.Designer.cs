namespace Nascar.WinApp
{
    partial class NascarDataTesting
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
            this.btnStartLiveFeed = new System.Windows.Forms.Button();
            this.btnStopLiveFeed = new System.Windows.Forms.Button();
            this.pnlConfig = new System.Windows.Forms.Panel();
            this.btnTrackViewMapper = new System.Windows.Forms.Button();
            this.btnSelectReplay = new System.Windows.Forms.Button();
            this.txtStopwatchCarNumber = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pauseReplay = new System.Windows.Forms.Button();
            this.stopReplay = new System.Windows.Forms.Button();
            this.startReplay = new System.Windows.Forms.Button();
            this.picRawFeedState = new System.Windows.Forms.PictureBox();
            this.picFeedState = new System.Windows.Forms.PictureBox();
            this.grpSeries = new System.Windows.Forms.GroupBox();
            this.cmbRace = new System.Windows.Forms.ComboBox();
            this.chkDisplay = new System.Windows.Forms.CheckBox();
            this.chkProcess = new System.Windows.Forms.CheckBox();
            this.rbTruck = new System.Windows.Forms.RadioButton();
            this.chkHarvest = new System.Windows.Forms.CheckBox();
            this.rbXfinity = new System.Windows.Forms.RadioButton();
            this.rbCup = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.txtRaceId = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblFeedStart = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFeedCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRaceId = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnLights = new System.Windows.Forms.Button();
            this.liveFeedDisplay1 = new Nascar.WinApp.LiveFeedDisplay();
            this.cautionLightView1 = new Nascar.WinApp.Views.CautionLightView();
            this.pnlConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRawFeedState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFeedState)).BeginInit();
            this.grpSeries.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartLiveFeed
            // 
            this.btnStartLiveFeed.Enabled = false;
            this.btnStartLiveFeed.Location = new System.Drawing.Point(8, 8);
            this.btnStartLiveFeed.Name = "btnStartLiveFeed";
            this.btnStartLiveFeed.Size = new System.Drawing.Size(96, 23);
            this.btnStartLiveFeed.TabIndex = 2;
            this.btnStartLiveFeed.Text = "Start Live Feed";
            this.btnStartLiveFeed.UseVisualStyleBackColor = true;
            this.btnStartLiveFeed.Click += new System.EventHandler(this.btnStartLiveFeed_Click);
            // 
            // btnStopLiveFeed
            // 
            this.btnStopLiveFeed.Enabled = false;
            this.btnStopLiveFeed.Location = new System.Drawing.Point(136, 8);
            this.btnStopLiveFeed.Name = "btnStopLiveFeed";
            this.btnStopLiveFeed.Size = new System.Drawing.Size(96, 23);
            this.btnStopLiveFeed.TabIndex = 3;
            this.btnStopLiveFeed.Text = "Stop Live Feed";
            this.btnStopLiveFeed.UseVisualStyleBackColor = true;
            this.btnStopLiveFeed.Click += new System.EventHandler(this.btnStopLiveFeed_Click);
            // 
            // pnlConfig
            // 
            this.pnlConfig.Controls.Add(this.cautionLightView1);
            this.pnlConfig.Controls.Add(this.btnLights);
            this.pnlConfig.Controls.Add(this.btnTrackViewMapper);
            this.pnlConfig.Controls.Add(this.btnSelectReplay);
            this.pnlConfig.Controls.Add(this.txtStopwatchCarNumber);
            this.pnlConfig.Controls.Add(this.button4);
            this.pnlConfig.Controls.Add(this.button3);
            this.pnlConfig.Controls.Add(this.pauseReplay);
            this.pnlConfig.Controls.Add(this.stopReplay);
            this.pnlConfig.Controls.Add(this.startReplay);
            this.pnlConfig.Controls.Add(this.picRawFeedState);
            this.pnlConfig.Controls.Add(this.picFeedState);
            this.pnlConfig.Controls.Add(this.grpSeries);
            this.pnlConfig.Controls.Add(this.btnStopLiveFeed);
            this.pnlConfig.Controls.Add(this.btnStartLiveFeed);
            this.pnlConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlConfig.Location = new System.Drawing.Point(0, 0);
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Padding = new System.Windows.Forms.Padding(5);
            this.pnlConfig.Size = new System.Drawing.Size(1255, 96);
            this.pnlConfig.TabIndex = 7;
            // 
            // btnTrackViewMapper
            // 
            this.btnTrackViewMapper.Location = new System.Drawing.Point(744, 8);
            this.btnTrackViewMapper.Name = "btnTrackViewMapper";
            this.btnTrackViewMapper.Size = new System.Drawing.Size(112, 23);
            this.btnTrackViewMapper.TabIndex = 21;
            this.btnTrackViewMapper.Text = "Track View Mapper";
            this.btnTrackViewMapper.UseVisualStyleBackColor = true;
            this.btnTrackViewMapper.Click += new System.EventHandler(this.btnTrackViewMapper_Click);
            // 
            // btnSelectReplay
            // 
            this.btnSelectReplay.Location = new System.Drawing.Point(280, 8);
            this.btnSelectReplay.Name = "btnSelectReplay";
            this.btnSelectReplay.Size = new System.Drawing.Size(99, 23);
            this.btnSelectReplay.TabIndex = 20;
            this.btnSelectReplay.Text = "Select Replay";
            this.btnSelectReplay.UseVisualStyleBackColor = true;
            this.btnSelectReplay.Click += new System.EventHandler(this.btnSelectReplay_Click);
            // 
            // txtStopwatchCarNumber
            // 
            this.txtStopwatchCarNumber.Location = new System.Drawing.Point(1104, 64);
            this.txtStopwatchCarNumber.Name = "txtStopwatchCarNumber";
            this.txtStopwatchCarNumber.Size = new System.Drawing.Size(48, 20);
            this.txtStopwatchCarNumber.TabIndex = 19;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(992, 64);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 23);
            this.button4.TabIndex = 18;
            this.button4.Text = "Add Stopwatch";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(624, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "next feed";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pauseReplay
            // 
            this.pauseReplay.Location = new System.Drawing.Point(544, 8);
            this.pauseReplay.Name = "pauseReplay";
            this.pauseReplay.Size = new System.Drawing.Size(75, 23);
            this.pauseReplay.TabIndex = 16;
            this.pauseReplay.Text = "pause replay";
            this.pauseReplay.UseVisualStyleBackColor = true;
            this.pauseReplay.Click += new System.EventHandler(this.pauseReplay_Click);
            // 
            // stopReplay
            // 
            this.stopReplay.Location = new System.Drawing.Point(464, 8);
            this.stopReplay.Name = "stopReplay";
            this.stopReplay.Size = new System.Drawing.Size(75, 23);
            this.stopReplay.TabIndex = 15;
            this.stopReplay.Text = "stop replay";
            this.stopReplay.UseVisualStyleBackColor = true;
            this.stopReplay.Click += new System.EventHandler(this.stopReplay_Click);
            // 
            // startReplay
            // 
            this.startReplay.Location = new System.Drawing.Point(384, 8);
            this.startReplay.Name = "startReplay";
            this.startReplay.Size = new System.Drawing.Size(75, 23);
            this.startReplay.TabIndex = 14;
            this.startReplay.Text = "start replay";
            this.startReplay.UseVisualStyleBackColor = true;
            this.startReplay.Click += new System.EventHandler(this.startReplay_Click);
            // 
            // picRawFeedState
            // 
            this.picRawFeedState.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picRawFeedState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picRawFeedState.Location = new System.Drawing.Point(120, 8);
            this.picRawFeedState.Name = "picRawFeedState";
            this.picRawFeedState.Size = new System.Drawing.Size(16, 24);
            this.picRawFeedState.TabIndex = 10;
            this.picRawFeedState.TabStop = false;
            // 
            // picFeedState
            // 
            this.picFeedState.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picFeedState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFeedState.Location = new System.Drawing.Point(104, 8);
            this.picFeedState.Name = "picFeedState";
            this.picFeedState.Size = new System.Drawing.Size(16, 24);
            this.picFeedState.TabIndex = 9;
            this.picFeedState.TabStop = false;
            // 
            // grpSeries
            // 
            this.grpSeries.Controls.Add(this.cmbRace);
            this.grpSeries.Controls.Add(this.chkDisplay);
            this.grpSeries.Controls.Add(this.chkProcess);
            this.grpSeries.Controls.Add(this.rbTruck);
            this.grpSeries.Controls.Add(this.chkHarvest);
            this.grpSeries.Controls.Add(this.rbXfinity);
            this.grpSeries.Controls.Add(this.rbCup);
            this.grpSeries.Controls.Add(this.button2);
            this.grpSeries.Controls.Add(this.txtRaceId);
            this.grpSeries.Controls.Add(this.button1);
            this.grpSeries.Location = new System.Drawing.Point(8, 40);
            this.grpSeries.Name = "grpSeries";
            this.grpSeries.Size = new System.Drawing.Size(976, 56);
            this.grpSeries.TabIndex = 8;
            this.grpSeries.TabStop = false;
            this.grpSeries.Text = "Settings";
            // 
            // cmbRace
            // 
            this.cmbRace.FormattingEnabled = true;
            this.cmbRace.Location = new System.Drawing.Point(184, 24);
            this.cmbRace.Name = "cmbRace";
            this.cmbRace.Size = new System.Drawing.Size(208, 21);
            this.cmbRace.TabIndex = 12;
            this.cmbRace.SelectedIndexChanged += new System.EventHandler(this.cmbRace_SelectedIndexChanged);
            // 
            // chkDisplay
            // 
            this.chkDisplay.AutoSize = true;
            this.chkDisplay.Checked = true;
            this.chkDisplay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisplay.Location = new System.Drawing.Point(680, 24);
            this.chkDisplay.Name = "chkDisplay";
            this.chkDisplay.Size = new System.Drawing.Size(113, 17);
            this.chkDisplay.TabIndex = 11;
            this.chkDisplay.Text = "Display Feed Data";
            this.chkDisplay.UseVisualStyleBackColor = true;
            // 
            // chkProcess
            // 
            this.chkProcess.AutoSize = true;
            this.chkProcess.Checked = true;
            this.chkProcess.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProcess.Location = new System.Drawing.Point(560, 24);
            this.chkProcess.Name = "chkProcess";
            this.chkProcess.Size = new System.Drawing.Size(117, 17);
            this.chkProcess.TabIndex = 10;
            this.chkProcess.Text = "Process Feed Data";
            this.chkProcess.UseVisualStyleBackColor = true;
            // 
            // rbTruck
            // 
            this.rbTruck.AutoSize = true;
            this.rbTruck.Location = new System.Drawing.Point(128, 24);
            this.rbTruck.Name = "rbTruck";
            this.rbTruck.Size = new System.Drawing.Size(53, 17);
            this.rbTruck.TabIndex = 2;
            this.rbTruck.Text = "Truck";
            this.rbTruck.UseVisualStyleBackColor = true;
            this.rbTruck.CheckedChanged += new System.EventHandler(this.rbSeries_CheckedChanged);
            // 
            // chkHarvest
            // 
            this.chkHarvest.AutoSize = true;
            this.chkHarvest.Checked = true;
            this.chkHarvest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHarvest.Location = new System.Drawing.Point(408, 24);
            this.chkHarvest.Name = "chkHarvest";
            this.chkHarvest.Size = new System.Drawing.Size(141, 17);
            this.chkHarvest.TabIndex = 9;
            this.chkHarvest.Text = "Harvest Raw Feed Data";
            this.chkHarvest.UseVisualStyleBackColor = true;
            // 
            // rbXfinity
            // 
            this.rbXfinity.AutoSize = true;
            this.rbXfinity.Location = new System.Drawing.Point(64, 24);
            this.rbXfinity.Name = "rbXfinity";
            this.rbXfinity.Size = new System.Drawing.Size(56, 17);
            this.rbXfinity.TabIndex = 1;
            this.rbXfinity.Text = "XFinity";
            this.rbXfinity.UseVisualStyleBackColor = true;
            this.rbXfinity.CheckedChanged += new System.EventHandler(this.rbSeries_CheckedChanged);
            // 
            // rbCup
            // 
            this.rbCup.AutoSize = true;
            this.rbCup.Checked = true;
            this.rbCup.Location = new System.Drawing.Point(8, 24);
            this.rbCup.Name = "rbCup";
            this.rbCup.Size = new System.Drawing.Size(44, 17);
            this.rbCup.TabIndex = 0;
            this.rbCup.TabStop = true;
            this.rbCup.Text = "Cup";
            this.rbCup.UseVisualStyleBackColor = true;
            this.rbCup.CheckedChanged += new System.EventHandler(this.rbSeries_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(944, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtRaceId
            // 
            this.txtRaceId.Location = new System.Drawing.Point(840, 24);
            this.txtRaceId.Name = "txtRaceId";
            this.txtRaceId.Size = new System.Drawing.Size(100, 20);
            this.txtRaceId.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(808, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFeedStart,
            this.lblFeedCount,
            this.lblRaceId});
            this.statusStrip1.Location = new System.Drawing.Point(0, 515);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1255, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblFeedStart
            // 
            this.lblFeedStart.AutoSize = false;
            this.lblFeedStart.AutoToolTip = true;
            this.lblFeedStart.Name = "lblFeedStart";
            this.lblFeedStart.Size = new System.Drawing.Size(200, 17);
            this.lblFeedStart.Text = "Feed Start: -";
            this.lblFeedStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFeedCount
            // 
            this.lblFeedCount.AutoSize = false;
            this.lblFeedCount.AutoToolTip = true;
            this.lblFeedCount.Name = "lblFeedCount";
            this.lblFeedCount.Size = new System.Drawing.Size(125, 17);
            this.lblFeedCount.Text = "Feed Count: 0";
            this.lblFeedCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRaceId
            // 
            this.lblRaceId.Name = "lblRaceId";
            this.lblRaceId.Size = new System.Drawing.Size(118, 17);
            this.lblRaceId.Text = "toolStripStatusLabel1";
            // 
            // btnLights
            // 
            this.btnLights.Location = new System.Drawing.Point(864, 8);
            this.btnLights.Name = "btnLights";
            this.btnLights.Size = new System.Drawing.Size(112, 23);
            this.btnLights.TabIndex = 22;
            this.btnLights.Text = "CautionLights";
            this.btnLights.UseVisualStyleBackColor = true;
            this.btnLights.Click += new System.EventHandler(this.btnLights_Click);
            // 
            // liveFeedDisplay1
            // 
            this.liveFeedDisplay1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.liveFeedDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.liveFeedDisplay1.Location = new System.Drawing.Point(0, 96);
            this.liveFeedDisplay1.Model = null;
            this.liveFeedDisplay1.Name = "liveFeedDisplay1";
            this.liveFeedDisplay1.Padding = new System.Windows.Forms.Padding(2);
            this.liveFeedDisplay1.Size = new System.Drawing.Size(1255, 419);
            this.liveFeedDisplay1.TabIndex = 6;
            // 
            // cautionLightView1
            // 
            this.cautionLightView1.BackColor = System.Drawing.Color.Black;
            this.cautionLightView1.LightState = Nascar.WinApp.Views.CautionLightState.Off;
            this.cautionLightView1.Location = new System.Drawing.Point(1064, 8);
            this.cautionLightView1.Name = "cautionLightView1";
            this.cautionLightView1.Padding = new System.Windows.Forms.Padding(2);
            this.cautionLightView1.Size = new System.Drawing.Size(185, 48);
            this.cautionLightView1.TabIndex = 23;
            // 
            // NascarDataTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 537);
            this.Controls.Add(this.liveFeedDisplay1);
            this.Controls.Add(this.pnlConfig);
            this.Controls.Add(this.statusStrip1);
            this.Name = "NascarDataTesting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nascar Data Testing";
            this.pnlConfig.ResumeLayout(false);
            this.pnlConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRawFeedState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFeedState)).EndInit();
            this.grpSeries.ResumeLayout(false);
            this.grpSeries.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartLiveFeed;
        private System.Windows.Forms.Button btnStopLiveFeed;
        private LiveFeedDisplay liveFeedDisplay1;
        private System.Windows.Forms.Panel pnlConfig;
        private System.Windows.Forms.GroupBox grpSeries;
        private System.Windows.Forms.RadioButton rbTruck;
        private System.Windows.Forms.RadioButton rbXfinity;
        private System.Windows.Forms.RadioButton rbCup;
        private System.Windows.Forms.CheckBox chkProcess;
        private System.Windows.Forms.CheckBox chkHarvest;
        private System.Windows.Forms.CheckBox chkDisplay;
        private System.Windows.Forms.PictureBox picFeedState;
        private System.Windows.Forms.PictureBox picRawFeedState;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblFeedStart;
        private System.Windows.Forms.ToolStripStatusLabel lblFeedCount;
        private System.Windows.Forms.ComboBox cmbRace;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtRaceId;
        private System.Windows.Forms.ToolStripStatusLabel lblRaceId;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button startReplay;
        private System.Windows.Forms.Button stopReplay;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button pauseReplay;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtStopwatchCarNumber;
        private System.Windows.Forms.Button btnSelectReplay;
        private System.Windows.Forms.Button btnTrackViewMapper;
        private System.Windows.Forms.Button btnLights;
        private Views.CautionLightView cautionLightView1;
    }
}

