namespace Nascar.WinApp
{
    partial class EventDisplay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "00",
            "Driver One",
            "-3"}, -1);
            this.SeriesLabel = new System.Windows.Forms.Label();
            this.TrackLabel = new System.Windows.Forms.Label();
            this.RunLabel = new System.Windows.Forms.Label();
            this.CautionsLabel = new System.Windows.Forms.Label();
            this.picRaceStatus = new System.Windows.Forms.PictureBox();
            this.lblLeaders = new System.Windows.Forms.Label();
            this.lblLap = new System.Windows.Forms.Label();
            this.lblGreenLaps = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lvBestRun = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label8 = new System.Windows.Forms.Label();
            this.lvWorstRun = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label9 = new System.Windows.Forms.Label();
            this.lvWorstRace = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label10 = new System.Windows.Forms.Label();
            this.lvBestRace = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label11 = new System.Windows.Forms.Label();
            this.lvBest10LapAvg = new System.Windows.Forms.ListView();
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label12 = new System.Windows.Forms.Label();
            this.lvBestLastLap = new System.Windows.Forms.ListView();
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label13 = new System.Windows.Forms.Label();
            this.lvBest5LapAvg = new System.Windows.Forms.ListView();
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label14 = new System.Windows.Forms.Label();
            this.lvBest20LapAvg = new System.Windows.Forms.ListView();
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader24 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlRunStats = new System.Windows.Forms.Panel();
            this.pnlRaceStats = new System.Windows.Forms.Panel();
            this.pnlLastLap = new System.Windows.Forms.Panel();
            this.pnlAverages = new System.Windows.Forms.Panel();
            this.cautionLightView1 = new Nascar.WinApp.Views.CautionLightView();
            ((System.ComponentModel.ISupportInitialize)(this.picRaceStatus)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pnlRunStats.SuspendLayout();
            this.pnlRaceStats.SuspendLayout();
            this.pnlLastLap.SuspendLayout();
            this.pnlAverages.SuspendLayout();
            this.SuspendLayout();
            // 
            // SeriesLabel
            // 
            this.SeriesLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeriesLabel.ForeColor = System.Drawing.Color.DimGray;
            this.SeriesLabel.Location = new System.Drawing.Point(533, 8);
            this.SeriesLabel.Name = "SeriesLabel";
            this.SeriesLabel.Size = new System.Drawing.Size(144, 16);
            this.SeriesLabel.TabIndex = 3;
            this.SeriesLabel.Text = "<series>";
            this.SeriesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TrackLabel
            // 
            this.TrackLabel.AutoSize = true;
            this.TrackLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackLabel.ForeColor = System.Drawing.Color.DimGray;
            this.TrackLabel.Location = new System.Drawing.Point(816, 8);
            this.TrackLabel.Name = "TrackLabel";
            this.TrackLabel.Size = new System.Drawing.Size(64, 16);
            this.TrackLabel.TabIndex = 5;
            this.TrackLabel.Text = "<track>";
            this.TrackLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RunLabel
            // 
            this.RunLabel.AutoSize = true;
            this.RunLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunLabel.ForeColor = System.Drawing.Color.DimGray;
            this.RunLabel.Location = new System.Drawing.Point(8, 8);
            this.RunLabel.Name = "RunLabel";
            this.RunLabel.Size = new System.Drawing.Size(52, 16);
            this.RunLabel.TabIndex = 7;
            this.RunLabel.Text = "<run>";
            // 
            // CautionsLabel
            // 
            this.CautionsLabel.AutoSize = true;
            this.CautionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CautionsLabel.Location = new System.Drawing.Point(200, 32);
            this.CautionsLabel.Name = "CautionsLabel";
            this.CautionsLabel.Size = new System.Drawing.Size(72, 16);
            this.CautionsLabel.TabIndex = 9;
            this.CautionsLabel.Text = "<cautions>";
            this.CautionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picRaceStatus
            // 
            this.picRaceStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picRaceStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.picRaceStatus.Location = new System.Drawing.Point(5, 0);
            this.picRaceStatus.Name = "picRaceStatus";
            this.picRaceStatus.Size = new System.Drawing.Size(1815, 34);
            this.picRaceStatus.TabIndex = 10;
            this.picRaceStatus.TabStop = false;
            // 
            // lblLeaders
            // 
            this.lblLeaders.AutoSize = true;
            this.lblLeaders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeaders.Location = new System.Drawing.Point(392, 32);
            this.lblLeaders.Name = "lblLeaders";
            this.lblLeaders.Size = new System.Drawing.Size(90, 16);
            this.lblLeaders.TabIndex = 13;
            this.lblLeaders.Text = "<lap leaders>";
            this.lblLeaders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLap
            // 
            this.lblLap.AutoSize = true;
            this.lblLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLap.Location = new System.Drawing.Point(16, 32);
            this.lblLap.Name = "lblLap";
            this.lblLap.Size = new System.Drawing.Size(41, 16);
            this.lblLap.TabIndex = 15;
            this.lblLap.Text = "<lap>";
            this.lblLap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGreenLaps
            // 
            this.lblGreenLaps.AutoSize = true;
            this.lblGreenLaps.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreenLaps.Location = new System.Drawing.Point(560, 32);
            this.lblGreenLaps.Name = "lblGreenLaps";
            this.lblGreenLaps.Size = new System.Drawing.Size(103, 16);
            this.lblGreenLaps.TabIndex = 17;
            this.lblGreenLaps.Text = "<green flag run>";
            this.lblGreenLaps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Biggest Movers - Run";
            // 
            // lvBestRun
            // 
            this.lvBestRun.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvBestRun.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvBestRun.FullRowSelect = true;
            this.lvBestRun.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvBestRun.Location = new System.Drawing.Point(0, 16);
            this.lvBestRun.MultiSelect = false;
            this.lvBestRun.Name = "lvBestRun";
            this.lvBestRun.Scrollable = false;
            this.lvBestRun.Size = new System.Drawing.Size(176, 120);
            this.lvBestRun.TabIndex = 1;
            this.lvBestRun.UseCompatibleStateImageBehavior = false;
            this.lvBestRun.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "#";
            this.columnHeader1.Width = 25;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Driver";
            this.columnHeader2.Width = 118;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "+/-";
            this.columnHeader3.Width = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(189, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Biggest Fallers - Run";
            // 
            // lvWorstRun
            // 
            this.lvWorstRun.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvWorstRun.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvWorstRun.Location = new System.Drawing.Point(184, 16);
            this.lvWorstRun.Name = "lvWorstRun";
            this.lvWorstRun.Scrollable = false;
            this.lvWorstRun.Size = new System.Drawing.Size(176, 120);
            this.lvWorstRun.TabIndex = 21;
            this.lvWorstRun.UseCompatibleStateImageBehavior = false;
            this.lvWorstRun.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "#";
            this.columnHeader4.Width = 23;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Driver";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "+/-";
            this.columnHeader6.Width = 31;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(189, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Biggest Fallers - Race";
            // 
            // lvWorstRace
            // 
            this.lvWorstRace.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lvWorstRace.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvWorstRace.Location = new System.Drawing.Point(184, 16);
            this.lvWorstRace.Name = "lvWorstRace";
            this.lvWorstRace.Scrollable = false;
            this.lvWorstRace.Size = new System.Drawing.Size(168, 120);
            this.lvWorstRace.TabIndex = 25;
            this.lvWorstRace.UseCompatibleStateImageBehavior = false;
            this.lvWorstRace.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "#";
            this.columnHeader7.Width = 20;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Driver";
            this.columnHeader8.Width = 118;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "+/-";
            this.columnHeader9.Width = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Biggest Movers - Race";
            // 
            // lvBestRace
            // 
            this.lvBestRace.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.lvBestRace.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvBestRace.Location = new System.Drawing.Point(0, 16);
            this.lvBestRace.Name = "lvBestRace";
            this.lvBestRace.Scrollable = false;
            this.lvBestRace.Size = new System.Drawing.Size(176, 120);
            this.lvBestRace.TabIndex = 23;
            this.lvBestRace.UseCompatibleStateImageBehavior = false;
            this.lvBestRace.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "#";
            this.columnHeader10.Width = 27;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Driver";
            this.columnHeader11.Width = 117;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "+/-";
            this.columnHeader12.Width = 29;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(224, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Best 10 Lap Average";
            // 
            // lvBest10LapAvg
            // 
            this.lvBest10LapAvg.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15});
            this.lvBest10LapAvg.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvBest10LapAvg.Location = new System.Drawing.Point(219, 16);
            this.lvBest10LapAvg.Name = "lvBest10LapAvg";
            this.lvBest10LapAvg.Scrollable = false;
            this.lvBest10LapAvg.Size = new System.Drawing.Size(216, 120);
            this.lvBest10LapAvg.TabIndex = 27;
            this.lvBest10LapAvg.UseCompatibleStateImageBehavior = false;
            this.lvBest10LapAvg.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "#";
            this.columnHeader13.Width = 27;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Driver";
            this.columnHeader14.Width = 117;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Time";
            this.columnHeader15.Width = 70;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Fastest Last Lap";
            // 
            // lvBestLastLap
            // 
            this.lvBestLastLap.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18});
            this.lvBestLastLap.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvBestLastLap.Location = new System.Drawing.Point(0, 16);
            this.lvBestLastLap.Name = "lvBestLastLap";
            this.lvBestLastLap.Scrollable = false;
            this.lvBestLastLap.Size = new System.Drawing.Size(216, 120);
            this.lvBestLastLap.TabIndex = 29;
            this.lvBestLastLap.UseCompatibleStateImageBehavior = false;
            this.lvBestLastLap.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "#";
            this.columnHeader16.Width = 27;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Driver";
            this.columnHeader17.Width = 117;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Time";
            this.columnHeader18.Width = 70;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "Best 5 Lap Average";
            // 
            // lvBest5LapAvg
            // 
            this.lvBest5LapAvg.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21});
            this.lvBest5LapAvg.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvBest5LapAvg.Location = new System.Drawing.Point(0, 16);
            this.lvBest5LapAvg.Name = "lvBest5LapAvg";
            this.lvBest5LapAvg.Scrollable = false;
            this.lvBest5LapAvg.Size = new System.Drawing.Size(216, 120);
            this.lvBest5LapAvg.TabIndex = 31;
            this.lvBest5LapAvg.UseCompatibleStateImageBehavior = false;
            this.lvBest5LapAvg.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "#";
            this.columnHeader19.Width = 27;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Driver";
            this.columnHeader20.Width = 117;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Time";
            this.columnHeader21.Width = 70;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(445, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 13);
            this.label14.TabIndex = 32;
            this.label14.Text = "Best 20 Lap Average";
            // 
            // lvBest20LapAvg
            // 
            this.lvBest20LapAvg.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader22,
            this.columnHeader23,
            this.columnHeader24});
            this.lvBest20LapAvg.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvBest20LapAvg.Location = new System.Drawing.Point(440, 16);
            this.lvBest20LapAvg.Name = "lvBest20LapAvg";
            this.lvBest20LapAvg.Scrollable = false;
            this.lvBest20LapAvg.Size = new System.Drawing.Size(216, 120);
            this.lvBest20LapAvg.TabIndex = 33;
            this.lvBest20LapAvg.UseCompatibleStateImageBehavior = false;
            this.lvBest20LapAvg.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "#";
            this.columnHeader22.Width = 27;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "Driver";
            this.columnHeader23.Width = 117;
            // 
            // columnHeader24
            // 
            this.columnHeader24.Text = "Time";
            this.columnHeader24.Width = 70;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cautionLightView1);
            this.panel1.Controls.Add(this.RunLabel);
            this.panel1.Controls.Add(this.SeriesLabel);
            this.panel1.Controls.Add(this.TrackLabel);
            this.panel1.Controls.Add(this.lblLap);
            this.panel1.Controls.Add(this.CautionsLabel);
            this.panel1.Controls.Add(this.lblLeaders);
            this.panel1.Controls.Add(this.lblGreenLaps);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1815, 56);
            this.panel1.TabIndex = 34;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.pnlRunStats);
            this.flowLayoutPanel1.Controls.Add(this.pnlRaceStats);
            this.flowLayoutPanel1.Controls.Add(this.pnlLastLap);
            this.flowLayoutPanel1.Controls.Add(this.pnlAverages);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 90);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1815, 144);
            this.flowLayoutPanel1.TabIndex = 35;
            // 
            // pnlRunStats
            // 
            this.pnlRunStats.Controls.Add(this.lvBestRun);
            this.pnlRunStats.Controls.Add(this.label2);
            this.pnlRunStats.Controls.Add(this.lvWorstRun);
            this.pnlRunStats.Controls.Add(this.label8);
            this.pnlRunStats.Location = new System.Drawing.Point(3, 3);
            this.pnlRunStats.Name = "pnlRunStats";
            this.pnlRunStats.Size = new System.Drawing.Size(360, 136);
            this.pnlRunStats.TabIndex = 36;
            // 
            // pnlRaceStats
            // 
            this.pnlRaceStats.Controls.Add(this.lvBestRace);
            this.pnlRaceStats.Controls.Add(this.label10);
            this.pnlRaceStats.Controls.Add(this.lvWorstRace);
            this.pnlRaceStats.Controls.Add(this.label9);
            this.pnlRaceStats.Location = new System.Drawing.Point(369, 3);
            this.pnlRaceStats.Name = "pnlRaceStats";
            this.pnlRaceStats.Size = new System.Drawing.Size(352, 136);
            this.pnlRaceStats.TabIndex = 36;
            // 
            // pnlLastLap
            // 
            this.pnlLastLap.Controls.Add(this.lvBestLastLap);
            this.pnlLastLap.Controls.Add(this.label12);
            this.pnlLastLap.Location = new System.Drawing.Point(727, 3);
            this.pnlLastLap.Name = "pnlLastLap";
            this.pnlLastLap.Size = new System.Drawing.Size(216, 136);
            this.pnlLastLap.TabIndex = 36;
            // 
            // pnlAverages
            // 
            this.pnlAverages.Controls.Add(this.lvBest5LapAvg);
            this.pnlAverages.Controls.Add(this.lvBest10LapAvg);
            this.pnlAverages.Controls.Add(this.label11);
            this.pnlAverages.Controls.Add(this.label14);
            this.pnlAverages.Controls.Add(this.label13);
            this.pnlAverages.Controls.Add(this.lvBest20LapAvg);
            this.pnlAverages.Location = new System.Drawing.Point(949, 3);
            this.pnlAverages.Name = "pnlAverages";
            this.pnlAverages.Size = new System.Drawing.Size(656, 136);
            this.pnlAverages.TabIndex = 36;
            // 
            // cautionLightView1
            // 
            this.cautionLightView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cautionLightView1.BackColor = System.Drawing.Color.Black;
            this.cautionLightView1.LightState = Nascar.WinApp.Views.CautionLightState.Off;
            this.cautionLightView1.Location = new System.Drawing.Point(1720, 8);
            this.cautionLightView1.Name = "cautionLightView1";
            this.cautionLightView1.Padding = new System.Windows.Forms.Padding(2);
            this.cautionLightView1.Size = new System.Drawing.Size(88, 32);
            this.cautionLightView1.TabIndex = 18;
            // 
            // EventDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picRaceStatus);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "EventDisplay";
            this.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.Size = new System.Drawing.Size(1825, 235);
            ((System.ComponentModel.ISupportInitialize)(this.picRaceStatus)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.pnlRunStats.ResumeLayout(false);
            this.pnlRunStats.PerformLayout();
            this.pnlRaceStats.ResumeLayout(false);
            this.pnlRaceStats.PerformLayout();
            this.pnlLastLap.ResumeLayout(false);
            this.pnlLastLap.PerformLayout();
            this.pnlAverages.ResumeLayout(false);
            this.pnlAverages.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label SeriesLabel;
        private System.Windows.Forms.Label TrackLabel;
        private System.Windows.Forms.Label RunLabel;
        private System.Windows.Forms.Label CautionsLabel;
        private System.Windows.Forms.PictureBox picRaceStatus;
        private System.Windows.Forms.Label lblLeaders;
        private System.Windows.Forms.Label lblLap;
        private System.Windows.Forms.Label lblGreenLaps;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.ListView lvBestRun;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.ListView lvWorstRun;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label label9;
        internal System.Windows.Forms.ListView lvWorstRace;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.ListView lvBestRace;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.ListView lvBest10LapAvg;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.Label label12;
        internal System.Windows.Forms.ListView lvBestLastLap;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.ListView lvBest5LapAvg;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.Label label14;
        internal System.Windows.Forms.ListView lvBest20LapAvg;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader24;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel pnlRunStats;
        private System.Windows.Forms.Panel pnlRaceStats;
        private System.Windows.Forms.Panel pnlLastLap;
        private System.Windows.Forms.Panel pnlAverages;
        private Views.CautionLightView cautionLightView1;
    }
}
