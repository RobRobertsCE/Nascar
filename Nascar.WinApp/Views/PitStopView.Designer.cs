namespace Nascar.WinApp.Views
{
    partial class PitStopView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LapTextBox = new System.Windows.Forms.TextBox();
            this.PositionChangeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.InTextBox = new System.Windows.Forms.TextBox();
            this.OutTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TotalTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Positions +/-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lap";
            // 
            // LapTextBox
            // 
            this.LapTextBox.Location = new System.Drawing.Point(37, 4);
            this.LapTextBox.Name = "LapTextBox";
            this.LapTextBox.Size = new System.Drawing.Size(48, 20);
            this.LapTextBox.TabIndex = 2;
            // 
            // PositionChangeTextBox
            // 
            this.PositionChangeTextBox.Location = new System.Drawing.Point(159, 4);
            this.PositionChangeTextBox.Name = "PositionChangeTextBox";
            this.PositionChangeTextBox.Size = new System.Drawing.Size(48, 20);
            this.PositionChangeTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "In Time";
            // 
            // InTextBox
            // 
            this.InTextBox.Location = new System.Drawing.Point(257, 4);
            this.InTextBox.Name = "InTextBox";
            this.InTextBox.Size = new System.Drawing.Size(48, 20);
            this.InTextBox.TabIndex = 5;
            // 
            // OutTextBox
            // 
            this.OutTextBox.Location = new System.Drawing.Point(363, 4);
            this.OutTextBox.Name = "OutTextBox";
            this.OutTextBox.Size = new System.Drawing.Size(48, 20);
            this.OutTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(309, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Out Time";
            // 
            // TotalTextBox
            // 
            this.TotalTextBox.Location = new System.Drawing.Point(476, 4);
            this.TotalTextBox.Name = "TotalTextBox";
            this.TotalTextBox.Size = new System.Drawing.Size(48, 20);
            this.TotalTextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(415, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Total Time";
            // 
            // PitStopView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TotalTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.OutTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.InTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PositionChangeTextBox);
            this.Controls.Add(this.LapTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PitStopView";
            this.Size = new System.Drawing.Size(533, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox LapTextBox;
        private System.Windows.Forms.TextBox PositionChangeTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox InTextBox;
        private System.Windows.Forms.TextBox OutTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TotalTextBox;
        private System.Windows.Forms.Label label5;
    }
}
