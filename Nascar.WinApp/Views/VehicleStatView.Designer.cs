namespace Nascar.WinApp.Views
{
    partial class VehicleStatView
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
            this.lblDriver = new System.Windows.Forms.Label();
            this.lblVehicleNumber = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.picManufacturer = new System.Windows.Forms.PictureBox();
            this.lblLastLapTime = new System.Windows.Forms.Label();
            this.lblLastLapSpeed = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picManufacturer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDriver
            // 
            this.lblDriver.BackColor = System.Drawing.Color.DarkBlue;
            this.lblDriver.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriver.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblDriver.Location = new System.Drawing.Point(176, 0);
            this.lblDriver.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDriver.Name = "lblDriver";
            this.lblDriver.Size = new System.Drawing.Size(190, 33);
            this.lblDriver.TabIndex = 0;
            this.lblDriver.Text = "Driver Name";
            this.lblDriver.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblVehicleNumber
            // 
            this.lblVehicleNumber.BackColor = System.Drawing.Color.DarkBlue;
            this.lblVehicleNumber.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVehicleNumber.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblVehicleNumber.Location = new System.Drawing.Point(66, 0);
            this.lblVehicleNumber.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblVehicleNumber.Name = "lblVehicleNumber";
            this.lblVehicleNumber.Size = new System.Drawing.Size(54, 33);
            this.lblVehicleNumber.TabIndex = 1;
            this.lblVehicleNumber.Text = "00";
            this.lblVehicleNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPosition
            // 
            this.lblPosition.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblPosition.Location = new System.Drawing.Point(0, 0);
            this.lblPosition.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(54, 33);
            this.lblPosition.TabIndex = 2;
            this.lblPosition.Text = "99";
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picManufacturer
            // 
            this.picManufacturer.Image = global::Nascar.WinApp.Properties.Resources.toyota_logo;
            this.picManufacturer.Location = new System.Drawing.Point(128, 0);
            this.picManufacturer.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.picManufacturer.Name = "picManufacturer";
            this.picManufacturer.Size = new System.Drawing.Size(40, 24);
            this.picManufacturer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picManufacturer.TabIndex = 3;
            this.picManufacturer.TabStop = false;
            // 
            // lblLastLapTime
            // 
            this.lblLastLapTime.BackColor = System.Drawing.Color.MidnightBlue;
            this.lblLastLapTime.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastLapTime.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblLastLapTime.Location = new System.Drawing.Point(376, 0);
            this.lblLastLapTime.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLastLapTime.Name = "lblLastLapTime";
            this.lblLastLapTime.Size = new System.Drawing.Size(106, 33);
            this.lblLastLapTime.TabIndex = 4;
            this.lblLastLapTime.Text = "12.345";
            this.lblLastLapTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLastLapSpeed
            // 
            this.lblLastLapSpeed.BackColor = System.Drawing.Color.DarkBlue;
            this.lblLastLapSpeed.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastLapSpeed.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblLastLapSpeed.Location = new System.Drawing.Point(496, 0);
            this.lblLastLapSpeed.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLastLapSpeed.Name = "lblLastLapSpeed";
            this.lblLastLapSpeed.Size = new System.Drawing.Size(120, 33);
            this.lblLastLapSpeed.TabIndex = 5;
            this.lblLastLapSpeed.Text = "200.123";
            this.lblLastLapSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VehicleStatView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.Controls.Add(this.lblLastLapSpeed);
            this.Controls.Add(this.lblLastLapTime);
            this.Controls.Add(this.picManufacturer);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblVehicleNumber);
            this.Controls.Add(this.lblDriver);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "VehicleStatView";
            this.Size = new System.Drawing.Size(2090, 29);
            ((System.ComponentModel.ISupportInitialize)(this.picManufacturer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDriver;
        private System.Windows.Forms.Label lblVehicleNumber;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.PictureBox picManufacturer;
        private System.Windows.Forms.Label lblLastLapTime;
        private System.Windows.Forms.Label lblLastLapSpeed;
    }
}
