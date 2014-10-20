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
            Nascar.Models.DriverModel driverModel1 = new Nascar.Models.DriverModel();
            this.BestLapSpeedTextBox = new System.Windows.Forms.TextBox();
            this.BestLapOnTextBox = new System.Windows.Forms.TextBox();
            this.BestLapTimeTextBox = new System.Windows.Forms.TextBox();
            this.CarNumberLabel = new System.Windows.Forms.Label();
            this.PositionLabel = new System.Windows.Forms.Label();
            this.driverView1 = new Nascar.WinApp.Views.DriverView();
            this.SuspendLayout();
            // 
            // BestLapSpeedTextBox
            // 
            this.BestLapSpeedTextBox.Location = new System.Drawing.Point(368, 0);
            this.BestLapSpeedTextBox.Name = "BestLapSpeedTextBox";
            this.BestLapSpeedTextBox.Size = new System.Drawing.Size(100, 20);
            this.BestLapSpeedTextBox.TabIndex = 10;
            // 
            // BestLapOnTextBox
            // 
            this.BestLapOnTextBox.Location = new System.Drawing.Point(472, 0);
            this.BestLapOnTextBox.Name = "BestLapOnTextBox";
            this.BestLapOnTextBox.Size = new System.Drawing.Size(32, 20);
            this.BestLapOnTextBox.TabIndex = 9;
            // 
            // BestLapTimeTextBox
            // 
            this.BestLapTimeTextBox.Location = new System.Drawing.Point(264, 0);
            this.BestLapTimeTextBox.Name = "BestLapTimeTextBox";
            this.BestLapTimeTextBox.Size = new System.Drawing.Size(100, 20);
            this.BestLapTimeTextBox.TabIndex = 8;
            // 
            // CarNumberLabel
            // 
            this.CarNumberLabel.Location = new System.Drawing.Point(208, 0);
            this.CarNumberLabel.Name = "CarNumberLabel";
            this.CarNumberLabel.Size = new System.Drawing.Size(40, 16);
            this.CarNumberLabel.TabIndex = 11;
            this.CarNumberLabel.Text = "label1";
            this.CarNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PositionLabel
            // 
            this.PositionLabel.Location = new System.Drawing.Point(512, 0);
            this.PositionLabel.Name = "PositionLabel";
            this.PositionLabel.Size = new System.Drawing.Size(40, 16);
            this.PositionLabel.TabIndex = 12;
            this.PositionLabel.Text = "label1";
            this.PositionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // driverView1
            // 
            driverModel1.driver_id = 0;
            driverModel1.first_name = null;
            driverModel1.full_name = null;
            driverModel1.is_in_chase = false;
            driverModel1.last_name = null;
            this.driverView1.Driver = driverModel1;
            this.driverView1.Location = new System.Drawing.Point(0, 0);
            this.driverView1.Name = "driverView1";
            this.driverView1.Size = new System.Drawing.Size(208, 24);
            this.driverView1.TabIndex = 7;
            // 
            // VehicleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.PositionLabel);
            this.Controls.Add(this.CarNumberLabel);
            this.Controls.Add(this.BestLapSpeedTextBox);
            this.Controls.Add(this.BestLapOnTextBox);
            this.Controls.Add(this.BestLapTimeTextBox);
            this.Controls.Add(this.driverView1);
            this.Name = "VehicleView";
            this.Size = new System.Drawing.Size(1089, 22);
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

    }
}
