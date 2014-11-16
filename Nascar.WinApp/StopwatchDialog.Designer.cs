namespace Nascar.WinApp
{
    partial class StopwatchDialog
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
            this.stopwatchView1 = new Nascar.WinApp.Views.StopwatchView();
            this.SuspendLayout();
            // 
            // stopwatchView1
            // 
            this.stopwatchView1.BackColor = System.Drawing.Color.Black;
            this.stopwatchView1.Data = null;
            this.stopwatchView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stopwatchView1.Location = new System.Drawing.Point(0, 0);
            this.stopwatchView1.Name = "stopwatchView1";
            this.stopwatchView1.Size = new System.Drawing.Size(275, 180);
            this.stopwatchView1.TabIndex = 0;
            // 
            // StopwatchDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 180);
            this.Controls.Add(this.stopwatchView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StopwatchDialog";
            this.Text = "Stopwatch";
            this.ResumeLayout(false);

        }

        #endregion

        private Views.StopwatchView stopwatchView1;
    }
}