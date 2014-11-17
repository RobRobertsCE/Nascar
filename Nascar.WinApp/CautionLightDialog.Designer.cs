namespace Nascar.WinApp
{
    partial class CautionLightDialog
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
            this.rbG = new System.Windows.Forms.RadioButton();
            this.rbY = new System.Windows.Forms.RadioButton();
            this.rbR = new System.Windows.Forms.RadioButton();
            this.rbO = new System.Windows.Forms.RadioButton();
            this.cautionLightView1 = new Nascar.WinApp.Views.CautionLightView();
            this.SuspendLayout();
            // 
            // rbG
            // 
            this.rbG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbG.AutoSize = true;
            this.rbG.Location = new System.Drawing.Point(8, 144);
            this.rbG.Name = "rbG";
            this.rbG.Size = new System.Drawing.Size(54, 17);
            this.rbG.TabIndex = 1;
            this.rbG.TabStop = true;
            this.rbG.Text = "Green";
            this.rbG.UseVisualStyleBackColor = true;
            this.rbG.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbY
            // 
            this.rbY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbY.AutoSize = true;
            this.rbY.Location = new System.Drawing.Point(64, 144);
            this.rbY.Name = "rbY";
            this.rbY.Size = new System.Drawing.Size(56, 17);
            this.rbY.TabIndex = 2;
            this.rbY.TabStop = true;
            this.rbY.Text = "Yellow";
            this.rbY.UseVisualStyleBackColor = true;
            this.rbY.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbR
            // 
            this.rbR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbR.AutoSize = true;
            this.rbR.Location = new System.Drawing.Point(120, 144);
            this.rbR.Name = "rbR";
            this.rbR.Size = new System.Drawing.Size(45, 17);
            this.rbR.TabIndex = 3;
            this.rbR.TabStop = true;
            this.rbR.Text = "Red";
            this.rbR.UseVisualStyleBackColor = true;
            this.rbR.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbO
            // 
            this.rbO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbO.AutoSize = true;
            this.rbO.Checked = true;
            this.rbO.Location = new System.Drawing.Point(184, 144);
            this.rbO.Name = "rbO";
            this.rbO.Size = new System.Drawing.Size(39, 17);
            this.rbO.TabIndex = 4;
            this.rbO.TabStop = true;
            this.rbO.Text = "Off";
            this.rbO.UseVisualStyleBackColor = true;
            this.rbO.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // cautionLightView1
            // 
            this.cautionLightView1.BackColor = System.Drawing.Color.Black;
            this.cautionLightView1.LightState = Nascar.WinApp.Views.CautionLightState.Off;
            this.cautionLightView1.Location = new System.Drawing.Point(8, 8);
            this.cautionLightView1.Name = "cautionLightView1";
            this.cautionLightView1.Padding = new System.Windows.Forms.Padding(2);
            this.cautionLightView1.Size = new System.Drawing.Size(400, 128);
            this.cautionLightView1.TabIndex = 0;
            // 
            // CautionLightDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 169);
            this.Controls.Add(this.rbO);
            this.Controls.Add(this.rbR);
            this.Controls.Add(this.rbY);
            this.Controls.Add(this.rbG);
            this.Controls.Add(this.cautionLightView1);
            this.Name = "CautionLightDialog";
            this.Text = "CautionLightDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Views.CautionLightView cautionLightView1;
        private System.Windows.Forms.RadioButton rbG;
        private System.Windows.Forms.RadioButton rbY;
        private System.Windows.Forms.RadioButton rbR;
        private System.Windows.Forms.RadioButton rbO;
    }
}