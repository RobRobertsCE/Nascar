namespace Nascar.WinApp
{
    partial class TrackViewDialog
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtXY = new System.Windows.Forms.TextBox();
            this.lstXY = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.trackView1 = new Nascar.WinApp.Views.TrackView();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.txtXY);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 48);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtXY
            // 
            this.txtXY.Location = new System.Drawing.Point(376, 24);
            this.txtXY.Name = "txtXY";
            this.txtXY.Size = new System.Drawing.Size(136, 20);
            this.txtXY.TabIndex = 1;
            // 
            // lstXY
            // 
            this.lstXY.Dock = System.Windows.Forms.DockStyle.Right;
            this.lstXY.FormattingEnabled = true;
            this.lstXY.Location = new System.Drawing.Point(756, 48);
            this.lstXY.Name = "lstXY";
            this.lstXY.Size = new System.Drawing.Size(120, 452);
            this.lstXY.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(88, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Save Points";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // trackView1
            // 
            this.trackView1.BackColor = System.Drawing.Color.White;
            this.trackView1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.trackView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.trackView1.Location = new System.Drawing.Point(8, 56);
            this.trackView1.Name = "trackView1";
            this.trackView1.Size = new System.Drawing.Size(729, 388);
            this.trackView1.TabIndex = 1;
            this.trackView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.trackView1_MouseMove);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(168, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Load Points";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(248, 8);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Calc Dist";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // TrackViewDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(876, 500);
            this.Controls.Add(this.lstXY);
            this.Controls.Add(this.trackView1);
            this.Controls.Add(this.panel1);
            this.Name = "TrackViewDialog";
            this.Text = "TrackViewDialog";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TrackViewDialog_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private Views.TrackView trackView1;
        private System.Windows.Forms.TextBox txtXY;
        private System.Windows.Forms.ListBox lstXY;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
    }
}