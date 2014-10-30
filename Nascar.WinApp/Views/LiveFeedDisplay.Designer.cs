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
            Nascar.Models.VehicleModel vehicleModel1 = new Nascar.Models.VehicleModel();
            this.vehiclePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.vehicleView1 = new Nascar.WinApp.Views.VehicleView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.eventDisplay = new Nascar.WinApp.EventDisplay();
            this.eventDisplay1 = new Nascar.WinApp.EventDisplay();
            this.vehiclePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // vehiclePanel
            // 
            this.vehiclePanel.AutoScroll = true;
            this.vehiclePanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.vehiclePanel.Controls.Add(this.vehicleView1);
            this.vehiclePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vehiclePanel.Location = new System.Drawing.Point(0, 88);
            this.vehiclePanel.Name = "vehiclePanel";
            this.vehiclePanel.Size = new System.Drawing.Size(1070, 371);
            this.vehiclePanel.TabIndex = 1;
            // 
            // vehicleView1
            // 
            this.vehicleView1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.vehicleView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vehicleView1.Location = new System.Drawing.Point(3, 3);
            this.vehicleView1.Name = "vehicleView1";
            this.vehicleView1.Size = new System.Drawing.Size(1089, 22);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.eventDisplay);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1070, 88);
            this.panel1.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(216, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Car #";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(512, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Position";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Driver";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(472, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Lap #";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Best Lap (Time)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Best Lap (MPH)";
            // 
            // eventDisplay
            // 
            this.eventDisplay.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.eventDisplay.EventDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.eventDisplay.Location = new System.Drawing.Point(8, 8);
            this.eventDisplay.Name = "eventDisplay";
            this.eventDisplay.Run = "<run>";
            this.eventDisplay.Series = Nascar.Models.SeriesName.Cup;
            this.eventDisplay.Size = new System.Drawing.Size(904, 55);
            this.eventDisplay.TabIndex = 0;
            this.eventDisplay.TrackName = "<event>";
            // 
            // eventDisplay1
            // 
            this.eventDisplay1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.eventDisplay1.EventDate = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.eventDisplay1.Location = new System.Drawing.Point(8, 8);
            this.eventDisplay1.Name = "eventDisplay1";
            this.eventDisplay1.Run = "<run>";
            this.eventDisplay1.Series = Nascar.Models.SeriesName.Cup;
            this.eventDisplay1.Size = new System.Drawing.Size(447, 55);
            this.eventDisplay1.TabIndex = 0;
            this.eventDisplay1.TrackName = "<event>";
            // 
            // LiveFeedDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vehiclePanel);
            this.Controls.Add(this.panel1);
            this.Name = "LiveFeedDisplay";
            this.Size = new System.Drawing.Size(1070, 459);
            this.vehiclePanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private EventDisplay eventDisplay;
        private EventDisplay eventDisplay1;
        private System.Windows.Forms.FlowLayoutPanel vehiclePanel;
        private System.Windows.Forms.Panel panel1;
        private Views.VehicleView vehicleView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;

    }
}
