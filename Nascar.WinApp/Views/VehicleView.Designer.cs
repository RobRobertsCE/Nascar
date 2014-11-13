namespace Nascar.WinApp.Views
{
    partial class VehicleView
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
            Nascar.Api.Models.DriverModel driverModel1 = new Nascar.Api.Models.DriverModel();
            this.BestLapSpeedTextBox = new System.Windows.Forms.TextBox();
            this.BestLapOnTextBox = new System.Windows.Forms.TextBox();
            this.BestLapTimeTextBox = new System.Windows.Forms.TextBox();
            this.CarNumberLabel = new System.Windows.Forms.Label();
            this.PositionLabel = new System.Windows.Forms.Label();
            this.FastestLapsTextBox = new System.Windows.Forms.TextBox();
            this.AvgRunPosition = new System.Windows.Forms.TextBox();
            this.LapsLedTextBox = new System.Windows.Forms.TextBox();
            this.LapsCompletedTextBox = new System.Windows.Forms.TextBox();
            this.LastLapSpeedTextBox = new System.Windows.Forms.TextBox();
            this.DeltaTextBox = new System.Windows.Forms.TextBox();
            this.PassesMadeTextBox = new System.Windows.Forms.TextBox();
            this.LastLapTimeTextBox = new System.Windows.Forms.TextBox();
            this.PassDifferentialTextBox = new System.Windows.Forms.TextBox();
            this.QualityPassesTextBox = new System.Windows.Forms.TextBox();
            this.StartPosTextBox = new System.Windows.Forms.TextBox();
            this.DeltaStartTextBox = new System.Windows.Forms.TextBox();
            this.lblLapDelta = new System.Windows.Forms.Label();
            this.RestartDeltaTextBox = new System.Windows.Forms.TextBox();
            this.DeltaGainLossTextBox = new System.Windows.Forms.TextBox();
            this.LapsSincePitTextBox = new System.Windows.Forms.TextBox();
            this.RestartPositionTextBox = new System.Windows.Forms.TextBox();
            this.DeltaPositionTextBox = new System.Windows.Forms.TextBox();
            this.DeltaPositionGainLossTextBox = new System.Windows.Forms.TextBox();
            this.DeltaPositionGainLoss5LapsTextBox = new System.Windows.Forms.TextBox();
            this.DeltaPosition5LapsTextBox = new System.Windows.Forms.TextBox();
            this.driverView1 = new Nascar.WinApp.Views.DriverView();
            this.SuspendLayout();
            // 
            // BestLapSpeedTextBox
            // 
            this.BestLapSpeedTextBox.Location = new System.Drawing.Point(976, 0);
            this.BestLapSpeedTextBox.Name = "BestLapSpeedTextBox";
            this.BestLapSpeedTextBox.Size = new System.Drawing.Size(56, 20);
            this.BestLapSpeedTextBox.TabIndex = 10;
            this.BestLapSpeedTextBox.Text = "BstSpd";
            // 
            // BestLapOnTextBox
            // 
            this.BestLapOnTextBox.Location = new System.Drawing.Point(1088, 0);
            this.BestLapOnTextBox.Name = "BestLapOnTextBox";
            this.BestLapOnTextBox.Size = new System.Drawing.Size(32, 20);
            this.BestLapOnTextBox.TabIndex = 9;
            this.BestLapOnTextBox.Text = "Bst#";
            // 
            // BestLapTimeTextBox
            // 
            this.BestLapTimeTextBox.Location = new System.Drawing.Point(1032, 0);
            this.BestLapTimeTextBox.Name = "BestLapTimeTextBox";
            this.BestLapTimeTextBox.Size = new System.Drawing.Size(56, 20);
            this.BestLapTimeTextBox.TabIndex = 8;
            this.BestLapTimeTextBox.Text = "BstTime";
            // 
            // CarNumberLabel
            // 
            this.CarNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CarNumberLabel.ForeColor = System.Drawing.Color.White;
            this.CarNumberLabel.Location = new System.Drawing.Point(64, 0);
            this.CarNumberLabel.Name = "CarNumberLabel";
            this.CarNumberLabel.Size = new System.Drawing.Size(24, 24);
            this.CarNumberLabel.TabIndex = 11;
            this.CarNumberLabel.Text = "00";
            this.CarNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PositionLabel
            // 
            this.PositionLabel.BackColor = System.Drawing.Color.White;
            this.PositionLabel.ForeColor = System.Drawing.Color.Black;
            this.PositionLabel.Location = new System.Drawing.Point(0, 0);
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Size = new System.Drawing.Size(32, 24);
            this.PositionLabel.TabIndex = 12;
            this.PositionLabel.Text = "0";
            this.PositionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FastestLapsTextBox
            // 
            this.FastestLapsTextBox.Location = new System.Drawing.Point(928, 0);
            this.FastestLapsTextBox.Name = "FastestLapsTextBox";
            this.FastestLapsTextBox.Size = new System.Drawing.Size(40, 20);
            this.FastestLapsTextBox.TabIndex = 14;
            this.FastestLapsTextBox.Text = "FstsLps";
            // 
            // AvgRunPosition
            // 
            this.AvgRunPosition.Location = new System.Drawing.Point(880, 0);
            this.AvgRunPosition.Name = "AvgRunPosition";
            this.AvgRunPosition.Size = new System.Drawing.Size(40, 20);
            this.AvgRunPosition.TabIndex = 13;
            this.AvgRunPosition.Text = "AvgPos";
            // 
            // LapsLedTextBox
            // 
            this.LapsLedTextBox.Location = new System.Drawing.Point(776, 0);
            this.LapsLedTextBox.Name = "LapsLedTextBox";
            this.LapsLedTextBox.Size = new System.Drawing.Size(96, 20);
            this.LapsLedTextBox.TabIndex = 16;
            this.LapsLedTextBox.Text = "LpsLed";
            // 
            // LapsCompletedTextBox
            // 
            this.LapsCompletedTextBox.Location = new System.Drawing.Point(304, 0);
            this.LapsCompletedTextBox.Name = "LapsCompletedTextBox";
            this.LapsCompletedTextBox.Size = new System.Drawing.Size(40, 20);
            this.LapsCompletedTextBox.TabIndex = 15;
            this.LapsCompletedTextBox.Text = "LpsRun";
            // 
            // LastLapSpeedTextBox
            // 
            this.LastLapSpeedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LastLapSpeedTextBox.Location = new System.Drawing.Point(656, 0);
            this.LastLapSpeedTextBox.Name = "LastLapSpeedTextBox";
            this.LastLapSpeedTextBox.Size = new System.Drawing.Size(56, 20);
            this.LastLapSpeedTextBox.TabIndex = 18;
            this.LastLapSpeedTextBox.Text = "LastMph";
            // 
            // DeltaTextBox
            // 
            this.DeltaTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DeltaTextBox.Location = new System.Drawing.Point(392, 0);
            this.DeltaTextBox.Name = "DeltaTextBox";
            this.DeltaTextBox.Size = new System.Drawing.Size(40, 20);
            this.DeltaTextBox.TabIndex = 17;
            this.DeltaTextBox.Text = "Delta";
            // 
            // PassesMadeTextBox
            // 
            this.PassesMadeTextBox.Location = new System.Drawing.Point(1128, 0);
            this.PassesMadeTextBox.Name = "PassesMadeTextBox";
            this.PassesMadeTextBox.Size = new System.Drawing.Size(40, 20);
            this.PassesMadeTextBox.TabIndex = 20;
            this.PassesMadeTextBox.Text = "Pss#";
            // 
            // LastLapTimeTextBox
            // 
            this.LastLapTimeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LastLapTimeTextBox.Location = new System.Drawing.Point(712, 0);
            this.LastLapTimeTextBox.Name = "LastLapTimeTextBox";
            this.LastLapTimeTextBox.Size = new System.Drawing.Size(56, 20);
            this.LastLapTimeTextBox.TabIndex = 19;
            this.LastLapTimeTextBox.Text = "LastSecs";
            // 
            // PassDifferentialTextBox
            // 
            this.PassDifferentialTextBox.Location = new System.Drawing.Point(1208, 0);
            this.PassDifferentialTextBox.Name = "PassDifferentialTextBox";
            this.PassDifferentialTextBox.Size = new System.Drawing.Size(40, 20);
            this.PassDifferentialTextBox.TabIndex = 21;
            this.PassDifferentialTextBox.Text = "PssDif";
            // 
            // QualityPassesTextBox
            // 
            this.QualityPassesTextBox.Location = new System.Drawing.Point(1168, 0);
            this.QualityPassesTextBox.Name = "QualityPassesTextBox";
            this.QualityPassesTextBox.Size = new System.Drawing.Size(40, 20);
            this.QualityPassesTextBox.TabIndex = 22;
            this.QualityPassesTextBox.Text = "QtyPss";
            // 
            // StartPosTextBox
            // 
            this.StartPosTextBox.Location = new System.Drawing.Point(1256, 0);
            this.StartPosTextBox.Name = "StartPosTextBox";
            this.StartPosTextBox.Size = new System.Drawing.Size(40, 20);
            this.StartPosTextBox.TabIndex = 23;
            this.StartPosTextBox.Text = "Start";
            // 
            // DeltaStartTextBox
            // 
            this.DeltaStartTextBox.Location = new System.Drawing.Point(1296, 0);
            this.DeltaStartTextBox.Name = "DeltaStartTextBox";
            this.DeltaStartTextBox.Size = new System.Drawing.Size(40, 20);
            this.DeltaStartTextBox.TabIndex = 24;
            this.DeltaStartTextBox.Text = "RaceDelta";
            // 
            // lblLapDelta
            // 
            this.lblLapDelta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLapDelta.ForeColor = System.Drawing.Color.White;
            this.lblLapDelta.Location = new System.Drawing.Point(32, 0);
            this.lblLapDelta.Name = "lblLapDelta";
            this.lblLapDelta.Size = new System.Drawing.Size(24, 24);
            this.lblLapDelta.TabIndex = 25;
            this.lblLapDelta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RestartDeltaTextBox
            // 
            this.RestartDeltaTextBox.Location = new System.Drawing.Point(1384, 0);
            this.RestartDeltaTextBox.Name = "RestartDeltaTextBox";
            this.RestartDeltaTextBox.Size = new System.Drawing.Size(40, 20);
            this.RestartDeltaTextBox.TabIndex = 26;
            this.RestartDeltaTextBox.Text = "RaceDelta";
            // 
            // DeltaGainLossTextBox
            // 
            this.DeltaGainLossTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DeltaGainLossTextBox.Location = new System.Drawing.Point(432, 0);
            this.DeltaGainLossTextBox.Name = "DeltaGainLossTextBox";
            this.DeltaGainLossTextBox.Size = new System.Drawing.Size(40, 20);
            this.DeltaGainLossTextBox.TabIndex = 27;
            this.DeltaGainLossTextBox.Text = "Delta+-";
            // 
            // LapsSincePitTextBox
            // 
            this.LapsSincePitTextBox.Location = new System.Drawing.Point(344, 0);
            this.LapsSincePitTextBox.Name = "LapsSincePitTextBox";
            this.LapsSincePitTextBox.Size = new System.Drawing.Size(40, 20);
            this.LapsSincePitTextBox.TabIndex = 28;
            this.LapsSincePitTextBox.Text = "LpsRun";
            // 
            // RestartPositionTextBox
            // 
            this.RestartPositionTextBox.Location = new System.Drawing.Point(1344, 0);
            this.RestartPositionTextBox.Name = "RestartPositionTextBox";
            this.RestartPositionTextBox.Size = new System.Drawing.Size(40, 20);
            this.RestartPositionTextBox.TabIndex = 29;
            this.RestartPositionTextBox.Text = "RaceDelta";
            // 
            // DeltaPositionTextBox
            // 
            this.DeltaPositionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DeltaPositionTextBox.Location = new System.Drawing.Point(480, 0);
            this.DeltaPositionTextBox.Name = "DeltaPositionTextBox";
            this.DeltaPositionTextBox.Size = new System.Drawing.Size(40, 20);
            this.DeltaPositionTextBox.TabIndex = 30;
            this.DeltaPositionTextBox.Text = "DeltaPos";
            // 
            // DeltaPositionGainLossTextBox
            // 
            this.DeltaPositionGainLossTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DeltaPositionGainLossTextBox.Location = new System.Drawing.Point(520, 0);
            this.DeltaPositionGainLossTextBox.Name = "DeltaPositionGainLossTextBox";
            this.DeltaPositionGainLossTextBox.Size = new System.Drawing.Size(40, 20);
            this.DeltaPositionGainLossTextBox.TabIndex = 31;
            this.DeltaPositionGainLossTextBox.Text = "DeltaPos";
            // 
            // DeltaPositionGainLoss5LapsTextBox
            // 
            this.DeltaPositionGainLoss5LapsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DeltaPositionGainLoss5LapsTextBox.Location = new System.Drawing.Point(608, 0);
            this.DeltaPositionGainLoss5LapsTextBox.Name = "DeltaPositionGainLoss5LapsTextBox";
            this.DeltaPositionGainLoss5LapsTextBox.Size = new System.Drawing.Size(40, 20);
            this.DeltaPositionGainLoss5LapsTextBox.TabIndex = 33;
            this.DeltaPositionGainLoss5LapsTextBox.Text = "DeltaPos";
            // 
            // DeltaPosition5LapsTextBox
            // 
            this.DeltaPosition5LapsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DeltaPosition5LapsTextBox.Location = new System.Drawing.Point(568, 0);
            this.DeltaPosition5LapsTextBox.Name = "DeltaPosition5LapsTextBox";
            this.DeltaPosition5LapsTextBox.Size = new System.Drawing.Size(40, 20);
            this.DeltaPosition5LapsTextBox.TabIndex = 32;
            this.DeltaPosition5LapsTextBox.Text = "DeltaPos";
            // 
            // driverView1
            // 
            driverModel1.driver_id = 0;
            driverModel1.first_name = null;
            driverModel1.full_name = null;
            driverModel1.is_in_chase = false;
            driverModel1.last_name = null;
            this.driverView1.Driver = driverModel1;
            this.driverView1.Location = new System.Drawing.Point(96, 0);
            this.driverView1.Name = "driverView1";
            this.driverView1.Size = new System.Drawing.Size(208, 24);
            this.driverView1.TabIndex = 7;
            // 
            // VehicleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.DeltaPositionGainLoss5LapsTextBox);
            this.Controls.Add(this.DeltaPosition5LapsTextBox);
            this.Controls.Add(this.DeltaPositionGainLossTextBox);
            this.Controls.Add(this.DeltaPositionTextBox);
            this.Controls.Add(this.RestartPositionTextBox);
            this.Controls.Add(this.LapsSincePitTextBox);
            this.Controls.Add(this.DeltaGainLossTextBox);
            this.Controls.Add(this.RestartDeltaTextBox);
            this.Controls.Add(this.lblLapDelta);
            this.Controls.Add(this.DeltaStartTextBox);
            this.Controls.Add(this.StartPosTextBox);
            this.Controls.Add(this.QualityPassesTextBox);
            this.Controls.Add(this.PassDifferentialTextBox);
            this.Controls.Add(this.PassesMadeTextBox);
            this.Controls.Add(this.LastLapTimeTextBox);
            this.Controls.Add(this.LastLapSpeedTextBox);
            this.Controls.Add(this.DeltaTextBox);
            this.Controls.Add(this.LapsLedTextBox);
            this.Controls.Add(this.LapsCompletedTextBox);
            this.Controls.Add(this.FastestLapsTextBox);
            this.Controls.Add(this.AvgRunPosition);
            this.Controls.Add(this.PositionLabel);
            this.Controls.Add(this.CarNumberLabel);
            this.Controls.Add(this.BestLapSpeedTextBox);
            this.Controls.Add(this.BestLapOnTextBox);
            this.Controls.Add(this.BestLapTimeTextBox);
            this.Controls.Add(this.driverView1);
            this.Name = "VehicleView";
            this.Size = new System.Drawing.Size(1552, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox BestLapSpeedTextBox;
        private System.Windows.Forms.TextBox BestLapOnTextBox;
        private System.Windows.Forms.TextBox BestLapTimeTextBox;
        private DriverView driverView1;
        private System.Windows.Forms.Label CarNumberLabel;
        private System.Windows.Forms.Label PositionLabel;
        private System.Windows.Forms.TextBox FastestLapsTextBox;
        private System.Windows.Forms.TextBox AvgRunPosition;
        private System.Windows.Forms.TextBox LapsLedTextBox;
        private System.Windows.Forms.TextBox LapsCompletedTextBox;
        private System.Windows.Forms.TextBox LastLapSpeedTextBox;
        private System.Windows.Forms.TextBox DeltaTextBox;
        private System.Windows.Forms.TextBox PassesMadeTextBox;
        private System.Windows.Forms.TextBox LastLapTimeTextBox;
        private System.Windows.Forms.TextBox PassDifferentialTextBox;
        private System.Windows.Forms.TextBox QualityPassesTextBox;
        private System.Windows.Forms.TextBox StartPosTextBox;
        private System.Windows.Forms.TextBox DeltaStartTextBox;
        private System.Windows.Forms.Label lblLapDelta;
        private System.Windows.Forms.TextBox RestartDeltaTextBox;
        private System.Windows.Forms.TextBox DeltaGainLossTextBox;
        private System.Windows.Forms.TextBox LapsSincePitTextBox;
        private System.Windows.Forms.TextBox RestartPositionTextBox;
        private System.Windows.Forms.TextBox DeltaPositionTextBox;
        private System.Windows.Forms.TextBox DeltaPositionGainLossTextBox;
        private System.Windows.Forms.TextBox DeltaPositionGainLoss5LapsTextBox;
        private System.Windows.Forms.TextBox DeltaPosition5LapsTextBox;

    }
}
