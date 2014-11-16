namespace TwitterLibrary
{
    partial class TweetViewList
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
            this.flpTweets = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flpTweets
            // 
            this.flpTweets.AutoScroll = true;
            this.flpTweets.AutoSize = true;
            this.flpTweets.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flpTweets.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpTweets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTweets.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpTweets.Location = new System.Drawing.Point(0, 0);
            this.flpTweets.Name = "flpTweets";
            this.flpTweets.Size = new System.Drawing.Size(587, 284);
            this.flpTweets.TabIndex = 0;
            // 
            // TweetViewList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpTweets);
            this.Name = "TweetViewList";
            this.Size = new System.Drawing.Size(587, 284);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpTweets;
    }
}
