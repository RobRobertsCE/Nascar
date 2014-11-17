namespace Nascar.WinApp.Views
{
    partial class CautionLightView
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
            this.components = new System.ComponentModel.Container();
            this.picLights = new System.Windows.Forms.PictureBox();
            this.blinkTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picLights)).BeginInit();
            this.SuspendLayout();
            // 
            // picLights
            // 
            this.picLights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLights.Location = new System.Drawing.Point(2, 2);
            this.picLights.Name = "picLights";
            this.picLights.Size = new System.Drawing.Size(325, 78);
            this.picLights.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLights.TabIndex = 0;
            this.picLights.TabStop = false;
            // 
            // blinkTimer
            // 
            this.blinkTimer.Interval = 500;
            this.blinkTimer.Tick += new System.EventHandler(this.blinkTimer_Tick);
            // 
            // CautionLightView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.picLights);
            this.Name = "CautionLightView";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(329, 82);
            ((System.ComponentModel.ISupportInitialize)(this.picLights)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picLights;
        private System.Windows.Forms.Timer blinkTimer;
    }
}
