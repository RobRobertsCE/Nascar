namespace NascarApi.TestApp
{
    partial class Form1
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
            this.btnStart = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRawFeed = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFeedCount = new System.Windows.Forms.TextBox();
            this.btnAllFeeds = new System.Windows.Forms.Button();
            this.btnAllRaces = new System.Windows.Forms.Button();
            this.btnAllTracks = new System.Windows.Forms.Button();
            this.btnRefactorTest = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(24, 128);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(139, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(64, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "3";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(64, 32);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "4320";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "series id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "race id";
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Location = new System.Drawing.Point(0, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(447, 37);
            this.label3.TabIndex = 5;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "run id";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(64, 56);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "18";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "rawfeed";
            // 
            // txtRawFeed
            // 
            this.txtRawFeed.Location = new System.Drawing.Point(64, 80);
            this.txtRawFeed.Name = "txtRawFeed";
            this.txtRawFeed.Size = new System.Drawing.Size(100, 20);
            this.txtRawFeed.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "feed cnt";
            // 
            // txtFeedCount
            // 
            this.txtFeedCount.Location = new System.Drawing.Point(64, 104);
            this.txtFeedCount.Name = "txtFeedCount";
            this.txtFeedCount.Size = new System.Drawing.Size(100, 20);
            this.txtFeedCount.TabIndex = 10;
            this.txtFeedCount.Text = "10";
            // 
            // btnAllFeeds
            // 
            this.btnAllFeeds.Location = new System.Drawing.Point(24, 232);
            this.btnAllFeeds.Name = "btnAllFeeds";
            this.btnAllFeeds.Size = new System.Drawing.Size(139, 23);
            this.btnAllFeeds.TabIndex = 12;
            this.btnAllFeeds.Text = "All Feeds";
            this.btnAllFeeds.UseVisualStyleBackColor = true;
            this.btnAllFeeds.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnAllRaces
            // 
            this.btnAllRaces.Location = new System.Drawing.Point(24, 200);
            this.btnAllRaces.Name = "btnAllRaces";
            this.btnAllRaces.Size = new System.Drawing.Size(139, 23);
            this.btnAllRaces.TabIndex = 13;
            this.btnAllRaces.Text = "All Races";
            this.btnAllRaces.UseVisualStyleBackColor = true;
            this.btnAllRaces.Click += new System.EventHandler(this.btnAllRaces_Click);
            // 
            // btnAllTracks
            // 
            this.btnAllTracks.Location = new System.Drawing.Point(24, 168);
            this.btnAllTracks.Name = "btnAllTracks";
            this.btnAllTracks.Size = new System.Drawing.Size(139, 23);
            this.btnAllTracks.TabIndex = 14;
            this.btnAllTracks.Text = "All Tracks";
            this.btnAllTracks.UseVisualStyleBackColor = true;
            this.btnAllTracks.Click += new System.EventHandler(this.btnAllTracks_Click);
            // 
            // btnRefactorTest
            // 
            this.btnRefactorTest.Location = new System.Drawing.Point(176, 8);
            this.btnRefactorTest.Name = "btnRefactorTest";
            this.btnRefactorTest.Size = new System.Drawing.Size(139, 23);
            this.btnRefactorTest.TabIndex = 15;
            this.btnRefactorTest.Text = "Start";
            this.btnRefactorTest.UseVisualStyleBackColor = true;
            this.btnRefactorTest.Click += new System.EventHandler(this.btnRefactorTest_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Stop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 306);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRefactorTest);
            this.Controls.Add(this.btnAllTracks);
            this.Controls.Add(this.btnAllRaces);
            this.Controls.Add(this.btnAllFeeds);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFeedCount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRawFeed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRawFeed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFeedCount;
        private System.Windows.Forms.Button btnAllFeeds;
        private System.Windows.Forms.Button btnAllRaces;
        private System.Windows.Forms.Button btnAllTracks;
        private System.Windows.Forms.Button btnRefactorTest;
        private System.Windows.Forms.Button button1;
    }
}

