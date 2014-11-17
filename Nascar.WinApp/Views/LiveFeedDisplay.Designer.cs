namespace Nascar.WinApp
{
    partial class LiveFeedDisplay
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
            Nascar.Api.Models.VehicleModel vehicleModel1 = new Nascar.Api.Models.VehicleModel();
            this.vehiclePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.vehicleView1 = new Nascar.WinApp.Views.VehicleView();
            this.eventViewPanel = new System.Windows.Forms.Panel();
            this.pnlVehicleViewHeader = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.eventDisplay = new Nascar.WinApp.EventDisplay();
            this.eventDisplay1 = new Nascar.WinApp.EventDisplay();
            this.vehiclePanel.SuspendLayout();
            this.eventViewPanel.SuspendLayout();
            this.pnlVehicleViewHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // vehiclePanel
            // 
            this.vehiclePanel.AutoScroll = true;
            this.vehiclePanel.BackColor = System.Drawing.Color.Black;
            this.vehiclePanel.Controls.Add(this.vehicleView1);
            this.vehiclePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vehiclePanel.Location = new System.Drawing.Point(0, 256);
            this.vehiclePanel.Name = "vehiclePanel";
            this.vehiclePanel.Size = new System.Drawing.Size(1481, 203);
            this.vehiclePanel.TabIndex = 1;
            // 
            // vehicleView1
            // 
            this.vehicleView1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.vehicleView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vehicleView1.DistanceBehind = 0D;
            this.vehicleView1.Location = new System.Drawing.Point(3, 3);
            this.vehicleView1.Name = "vehicleView1";
            this.vehicleView1.Size = new System.Drawing.Size(1445, 22);
            this.vehicleView1.TabIndex = 0;
            vehicleModel1.average_restart_speed = 0D;
            vehicleModel1.average_running_position = 0D;
            vehicleModel1.average_speed = 0D;
            vehicleModel1.best_lap = 0;
            vehicleModel1.best_lap_speed = 0D;
            vehicleModel1.best_lap_time = 0D;
            vehicleModel1.delta = 0D;
            vehicleModel1.driver = null;
            vehicleModel1.fastest_laps_run = 0;
            vehicleModel1.is_on_track = false;
            vehicleModel1.laps_completed = 0;
            vehicleModel1.laps_led = null;
            vehicleModel1.last_lap_speed = 0D;
            vehicleModel1.last_lap_time = 0D;
            vehicleModel1.passes_made = 0;
            vehicleModel1.passing_differential = 0;
            vehicleModel1.pit_stops = null;
            vehicleModel1.qualifying_status = 0;
            vehicleModel1.quality_passes = 0;
            vehicleModel1.running_position = 0;
            vehicleModel1.sponsor_name = null;
            vehicleModel1.starting_position = 0;
            vehicleModel1.status = 0;
            vehicleModel1.times_passed = 0;
            vehicleModel1.vehicle_elapsed_time = 0D;
            vehicleModel1.vehicle_manufacturer = null;
            vehicleModel1.vehicle_number = null;
            this.vehicleView1.Vehicle = vehicleModel1;
            // 
            // eventViewPanel
            // 
            this.eventViewPanel.Controls.Add(this.eventDisplay);
            this.eventViewPanel.Controls.Add(this.pnlVehicleViewHeader);
            this.eventViewPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.eventViewPanel.Location = new System.Drawing.Point(0, 0);
            this.eventViewPanel.Name = "eventViewPanel";
            this.eventViewPanel.Size = new System.Drawing.Size(1481, 256);
            this.eventViewPanel.TabIndex = 2;
            // 
            // pnlVehicleViewHeader
            // 
            this.pnlVehicleViewHeader.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlVehicleViewHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlVehicleViewHeader.Controls.Add(this.label12);
            this.pnlVehicleViewHeader.Controls.Add(this.label11);
            this.pnlVehicleViewHeader.Controls.Add(this.label18);
            this.pnlVehicleViewHeader.Controls.Add(this.label17);
            this.pnlVehicleViewHeader.Controls.Add(this.label6);
            this.pnlVehicleViewHeader.Controls.Add(this.label2);
            this.pnlVehicleViewHeader.Controls.Add(this.label3);
            this.pnlVehicleViewHeader.Controls.Add(this.label4);
            this.pnlVehicleViewHeader.Controls.Add(this.label13);
            this.pnlVehicleViewHeader.Controls.Add(this.label1);
            this.pnlVehicleViewHeader.Controls.Add(this.label5);
            this.pnlVehicleViewHeader.Controls.Add(this.label7);
            this.pnlVehicleViewHeader.Controls.Add(this.label10);
            this.pnlVehicleViewHeader.Controls.Add(this.label8);
            this.pnlVehicleViewHeader.Controls.Add(this.label9);
            this.pnlVehicleViewHeader.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlVehicleViewHeader.Location = new System.Drawing.Point(0, 240);
            this.pnlVehicleViewHeader.Name = "pnlVehicleViewHeader";
            this.pnlVehicleViewHeader.Size = new System.Drawing.Size(1481, 16);
            this.pnlVehicleViewHeader.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(568, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(88, 16);
            this.label12.TabIndex = 22;
            this.label12.Text = "Trend (Diff \\ +-)";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(480, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Position (Diff \\ +-)";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(1344, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(104, 13);
            this.label18.TabIndex = 20;
            this.label18.Text = "Restart   +/-";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(344, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 13);
            this.label17.TabIndex = 19;
            this.label17.Text = "Run";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Car #";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(976, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Best Lap (MPH \\ Time \\ Lap)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Lap #";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Driver";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(1256, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Started   +/-";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(880, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Avg Pos";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(928, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fastest";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(776, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Laps Led";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(1128, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(128, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Passes  (# \\ Quality \\ +-)";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(392, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Leader (Diff \\ +-)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(656, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Last Lap (MPH\\Time)";
            // 
            // eventDisplay
            // 
            this.eventDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.eventDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eventDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventDisplay.Location = new System.Drawing.Point(0, 0);
            this.eventDisplay.Model = null;
            this.eventDisplay.Name = "eventDisplay";
            this.eventDisplay.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.eventDisplay.ShowAverages = false;
            this.eventDisplay.ShowLastLap = false;
            this.eventDisplay.ShowRaceStats = false;
            this.eventDisplay.ShowRunStats = true;
            this.eventDisplay.Size = new System.Drawing.Size(1481, 240);
            this.eventDisplay.TabIndex = 0;
            // 
            // eventDisplay1
            // 
            this.eventDisplay1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.eventDisplay1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventDisplay1.Location = new System.Drawing.Point(8, 8);
            this.eventDisplay1.Model = null;
            this.eventDisplay1.Name = "eventDisplay1";
            this.eventDisplay1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.eventDisplay1.ShowAverages = false;
            this.eventDisplay1.ShowLastLap = false;
            this.eventDisplay1.ShowRaceStats = false;
            this.eventDisplay1.ShowRunStats = true;
            this.eventDisplay1.Size = new System.Drawing.Size(447, 55);
            this.eventDisplay1.TabIndex = 0;
            // 
            // LiveFeedDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vehiclePanel);
            this.Controls.Add(this.eventViewPanel);
            this.Name = "LiveFeedDisplay";
            this.Size = new System.Drawing.Size(1481, 459);
            this.vehiclePanel.ResumeLayout(false);
            this.eventViewPanel.ResumeLayout(false);
            this.pnlVehicleViewHeader.ResumeLayout(false);
            this.pnlVehicleViewHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private EventDisplay eventDisplay;
        private EventDisplay eventDisplay1;
        private System.Windows.Forms.FlowLayoutPanel vehiclePanel;
        private System.Windows.Forms.Panel eventViewPanel;
        private Views.VehicleView vehicleView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pnlVehicleViewHeader;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;

    }
}
