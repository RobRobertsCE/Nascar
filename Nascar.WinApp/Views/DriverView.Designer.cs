namespace Nascar.WinApp.Views
{
    partial class DriverView
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
            this.DriverTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // DriverTextBox
            // 
            this.DriverTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DriverTextBox.Location = new System.Drawing.Point(0, 0);
            this.DriverTextBox.Name = "DriverTextBox";
            this.DriverTextBox.Size = new System.Drawing.Size(200, 20);
            this.DriverTextBox.TabIndex = 1;
            // 
            // DriverView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DriverTextBox);
            this.Name = "DriverView";
            this.Size = new System.Drawing.Size(205, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DriverTextBox;
    }
}
