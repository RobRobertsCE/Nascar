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
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpSeries = new System.Windows.Forms.GroupBox();
            this.chkDisplay = new System.Windows.Forms.CheckBox();
            this.chkProcess = new System.Windows.Forms.CheckBox();
            this.rbTruck = new System.Windows.Forms.RadioButton();
            this.chkHarvest = new System.Windows.Forms.CheckBox();
            this.rbXfinity = new System.Windows.Forms.RadioButton();
            this.rbCup = new System.Windows.Forms.RadioButton();
            this.picFeedState = new System.Windows.Forms.PictureBox();
            this.picRawFeedState = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblFeedStart = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFeedCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.liveFeedDisplay1 = new Nascar.WinApp.LiveFeedDisplay();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.grpSeries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFeedState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRawFeedState)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartLiveFeed
            // 
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
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.picRawFeedState);
            this.panel1.Controls.Add(this.picFeedState);
            this.panel1.Controls.Add(this.grpSeries);
            this.panel1.Controls.Add(this.btnStopLiveFeed);
            this.panel1.Controls.Add(this.btnStartLiveFeed);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 160);
            this.panel1.TabIndex = 7;
            // 
            // grpSeries
            // 
            this.grpSeries.Controls.Add(this.chkDisplay);
            this.grpSeries.Controls.Add(this.chkProcess);
            this.grpSeries.Controls.Add(this.rbTruck);
            this.grpSeries.Controls.Add(this.chkHarvest);
            this.grpSeries.Controls.Add(this.rbXfinity);
            this.grpSeries.Controls.Add(this.rbCup);
            this.grpSeries.Location = new System.Drawing.Point(8, 40);
            this.grpSeries.Name = "grpSeries";
            this.grpSeries.Size = new System.Drawing.Size(224, 112);
            this.grpSeries.TabIndex = 8;
            this.grpSeries.TabStop = false;
            this.grpSeries.Text = "Settings";
            // 
            // chkDisplay
            // 
            this.chkDisplay.AutoSize = true;
            this.chkDisplay.Checked = true;
            this.chkDisplay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDisplay.Location = new System.Drawing.Point(72, 72);
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
            this.chkProcess.Location = new System.Drawing.Point(72, 48);
            this.chkProcess.Name = "chkProcess";
            this.chkProcess.Size = new System.Drawing.Size(117, 17);
            this.chkProcess.TabIndex = 10;
            this.chkProcess.Text = "Process Feed Data";
            this.chkProcess.UseVisualStyleBackColor = true;
            // 
            // rbTruck
            // 
            this.rbTruck.AutoSize = true;
            this.rbTruck.Location = new System.Drawing.Point(8, 72);
            this.rbTruck.Name = "rbTruck";
            this.rbTruck.Size = new System.Drawing.Size(53, 17);
            this.rbTruck.TabIndex = 2;
            this.rbTruck.Text = "Truck";
            this.rbTruck.UseVisualStyleBackColor = true;
            // 
            // chkHarvest
            // 
            this.chkHarvest.AutoSize = true;
            this.chkHarvest.Checked = true;
            this.chkHarvest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHarvest.Location = new System.Drawing.Point(72, 24);
            this.chkHarvest.Name = "chkHarvest";
            this.chkHarvest.Size = new System.Drawing.Size(141, 17);
            this.chkHarvest.TabIndex = 9;
            this.chkHarvest.Text = "Harvest Raw Feed Data";
            this.chkHarvest.UseVisualStyleBackColor = true;
            // 
            // rbXfinity
            // 
            this.rbXfinity.AutoSize = true;
            this.rbXfinity.Location = new System.Drawing.Point(8, 48);
            this.rbXfinity.Name = "rbXfinity";
            this.rbXfinity.Size = new System.Drawing.Size(56, 17);
            this.rbXfinity.TabIndex = 1;
            this.rbXfinity.Text = "XFinity";
            this.rbXfinity.UseVisualStyleBackColor = true;
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFeedStart,
            this.lblFeedCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 515);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1032, 22);
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
            // liveFeedDisplay1
            // 
            this.liveFeedDisplay1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.liveFeedDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.liveFeedDisplay1.Location = new System.Drawing.Point(0, 160);
            this.liveFeedDisplay1.Name = "liveFeedDisplay1";
            this.liveFeedDisplay1.Size = new System.Drawing.Size(1032, 355);
            this.liveFeedDisplay1.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(272, 88);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "4373";
            // 
            // NascarDataTesting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 537);
            this.Controls.Add(this.liveFeedDisplay1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "NascarDataTesting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nascar Data Testing";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpSeries.ResumeLayout(false);
            this.grpSeries.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFeedState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRawFeedState)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartLiveFeed;
        private System.Windows.Forms.Button btnStopLiveFeed;
        private LiveFeedDisplay liveFeedDisplay1;
        private System.Windows.Forms.Panel panel1;
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
        private System.Windows.Forms.TextBox textBox1;
    }
}

