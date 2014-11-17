namespace Nascar.WinApp.Views
{
    partial class CautionsView
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
            this.lstCautions = new System.Windows.Forms.ListView();
            this.chLapNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLaps = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLuckyDog = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cnNote = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblCaption = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstCautions
            // 
            this.lstCautions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chLapNumber,
            this.chLaps,
            this.chLuckyDog,
            this.cnNote});
            this.lstCautions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCautions.FullRowSelect = true;
            this.lstCautions.GridLines = true;
            this.lstCautions.Location = new System.Drawing.Point(2, 18);
            this.lstCautions.MultiSelect = false;
            this.lstCautions.Name = "lstCautions";
            this.lstCautions.Size = new System.Drawing.Size(410, 171);
            this.lstCautions.TabIndex = 2;
            this.lstCautions.UseCompatibleStateImageBehavior = false;
            this.lstCautions.View = System.Windows.Forms.View.Details;
            // 
            // chLapNumber
            // 
            this.chLapNumber.Text = "Lap #";
            // 
            // chLaps
            // 
            this.chLaps.Text = "Laps";
            // 
            // chLuckyDog
            // 
            this.chLuckyDog.Text = "Lucky Dog";
            this.chLuckyDog.Width = 75;
            // 
            // cnNote
            // 
            this.cnNote.Text = "Reason";
            this.cnNote.Width = 200;
            // 
            // lblCaption
            // 
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCaption.Location = new System.Drawing.Point(2, 2);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(410, 16);
            this.lblCaption.TabIndex = 3;
            this.lblCaption.Text = "Cautions - 0 for 0 Laps";
            // 
            // CautionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lstCautions);
            this.Controls.Add(this.lblCaption);
            this.Name = "CautionsView";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(414, 191);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstCautions;
        private System.Windows.Forms.ColumnHeader chLapNumber;
        private System.Windows.Forms.ColumnHeader chLaps;
        private System.Windows.Forms.ColumnHeader chLuckyDog;
        private System.Windows.Forms.ColumnHeader cnNote;
        private System.Windows.Forms.Label lblCaption;
    }
}
