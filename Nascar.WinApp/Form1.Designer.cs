﻿namespace Nascar.WinApp
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.liveFeedDisplay1 = new Nascar.WinApp.LiveFeedDisplay();
            this.grpSeries = new System.Windows.Forms.GroupBox();
            this.rbCup = new System.Windows.Forms.RadioButton();
            this.rbXfinity = new System.Windows.Forms.RadioButton();
            this.rbTruck = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.grpSeries.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get Live Feed Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Display Live Feed Data";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(680, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(136, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Start Live Feed";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(680, 48);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(136, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Stop Live Feed";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(144, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(240, 20);
            this.textBox1.TabIndex = 4;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(144, 32);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(240, 95);
            this.listBox1.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.grpSeries);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1032, 136);
            this.panel1.TabIndex = 7;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(408, 48);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(136, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "truck final tally";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(408, 16);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(136, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "cup final tally";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // liveFeedDisplay1
            // 
            this.liveFeedDisplay1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.liveFeedDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.liveFeedDisplay1.Location = new System.Drawing.Point(0, 136);
            this.liveFeedDisplay1.Name = "liveFeedDisplay1";
            this.liveFeedDisplay1.Size = new System.Drawing.Size(1032, 401);
            this.liveFeedDisplay1.TabIndex = 6;
            // 
            // grpSeries
            // 
            this.grpSeries.Controls.Add(this.rbTruck);
            this.grpSeries.Controls.Add(this.rbXfinity);
            this.grpSeries.Controls.Add(this.rbCup);
            this.grpSeries.Location = new System.Drawing.Point(600, 8);
            this.grpSeries.Name = "grpSeries";
            this.grpSeries.Size = new System.Drawing.Size(72, 72);
            this.grpSeries.TabIndex = 8;
            this.grpSeries.TabStop = false;
            this.grpSeries.Text = "Series";
            // 
            // rbCup
            // 
            this.rbCup.AutoSize = true;
            this.rbCup.Checked = true;
            this.rbCup.Location = new System.Drawing.Point(8, 16);
            this.rbCup.Name = "rbCup";
            this.rbCup.Size = new System.Drawing.Size(44, 17);
            this.rbCup.TabIndex = 0;
            this.rbCup.TabStop = true;
            this.rbCup.Text = "Cup";
            this.rbCup.UseVisualStyleBackColor = true;
            // 
            // rbXfinity
            // 
            this.rbXfinity.AutoSize = true;
            this.rbXfinity.Location = new System.Drawing.Point(8, 32);
            this.rbXfinity.Name = "rbXfinity";
            this.rbXfinity.Size = new System.Drawing.Size(56, 17);
            this.rbXfinity.TabIndex = 1;
            this.rbXfinity.Text = "XFinity";
            this.rbXfinity.UseVisualStyleBackColor = true;
            // 
            // rbTruck
            // 
            this.rbTruck.AutoSize = true;
            this.rbTruck.Location = new System.Drawing.Point(8, 48);
            this.rbTruck.Name = "rbTruck";
            this.rbTruck.Size = new System.Drawing.Size(53, 17);
            this.rbTruck.TabIndex = 2;
            this.rbTruck.Text = "Truck";
            this.rbTruck.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 537);
            this.Controls.Add(this.liveFeedDisplay1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpSeries.ResumeLayout(false);
            this.grpSeries.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private LiveFeedDisplay liveFeedDisplay1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox grpSeries;
        private System.Windows.Forms.RadioButton rbTruck;
        private System.Windows.Forms.RadioButton rbXfinity;
        private System.Windows.Forms.RadioButton rbCup;
    }
}

