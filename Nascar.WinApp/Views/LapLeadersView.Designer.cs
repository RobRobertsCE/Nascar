namespace Nascar.WinApp.Views
{
    partial class LapLeadersView
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
            this.lstLapLeaders = new System.Windows.Forms.ListView();
            this.chCarNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTimesLed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLapsLed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblCaption = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstLapLeaders
            // 
            this.lstLapLeaders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCarNumber,
            this.chTimesLed,
            this.chLapsLed});
            this.lstLapLeaders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLapLeaders.FullRowSelect = true;
            this.lstLapLeaders.GridLines = true;
            this.lstLapLeaders.Location = new System.Drawing.Point(2, 18);
            this.lstLapLeaders.MultiSelect = false;
            this.lstLapLeaders.Name = "lstLapLeaders";
            this.lstLapLeaders.Size = new System.Drawing.Size(312, 137);
            this.lstLapLeaders.TabIndex = 0;
            this.lstLapLeaders.UseCompatibleStateImageBehavior = false;
            this.lstLapLeaders.View = System.Windows.Forms.View.Details;
            // 
            // chCarNumber
            // 
            this.chCarNumber.Text = "#";
            // 
            // chTimesLed
            // 
            this.chTimesLed.Text = "Times Led";
            this.chTimesLed.Width = 100;
            // 
            // chLapsLed
            // 
            this.chLapsLed.Text = "LapsLed";
            // 
            // lblCaption
            // 
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCaption.Location = new System.Drawing.Point(2, 2);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(312, 16);
            this.lblCaption.TabIndex = 1;
            this.lblCaption.Text = "Lap Leaders";
            // 
            // LapLeadersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstLapLeaders);
            this.Controls.Add(this.lblCaption);
            this.Name = "LapLeadersView";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(316, 157);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstLapLeaders;
        private System.Windows.Forms.ColumnHeader chCarNumber;
        private System.Windows.Forms.ColumnHeader chTimesLed;
        private System.Windows.Forms.ColumnHeader chLapsLed;
        private System.Windows.Forms.Label lblCaption;
    }
}
