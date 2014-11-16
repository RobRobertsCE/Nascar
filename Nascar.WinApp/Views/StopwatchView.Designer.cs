namespace Nascar.WinApp.Views
{
    partial class StopwatchView
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
            this.components = new System.ComponentModel.Container();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lsCurrent = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lsNext = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lsBest = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lsLast = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.rectangleShape3 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.lblLapTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLapCount = new System.Windows.Forms.Label();
            this.lblLapNumber = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCarNumber = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblLapTimeFractions = new System.Windows.Forms.Label();
            this.lblLapMphFractions = new System.Windows.Forms.Label();
            this.lblLapMph = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnBest = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.lblBestLap = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.currentLapTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lsCurrent,
            this.lsNext,
            this.lsBest,
            this.lsLast,
            this.rectangleShape3,
            this.rectangleShape2,
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(274, 181);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // lsCurrent
            // 
            this.lsCurrent.BorderWidth = 3;
            this.lsCurrent.Name = "lsCurrent";
            this.lsCurrent.X1 = 198;
            this.lsCurrent.X2 = 249;
            this.lsCurrent.Y1 = 140;
            this.lsCurrent.Y2 = 140;
            // 
            // lsNext
            // 
            this.lsNext.BorderWidth = 3;
            this.lsNext.Name = "lsNext";
            this.lsNext.X1 = 110;
            this.lsNext.X2 = 130;
            this.lsNext.Y1 = 140;
            this.lsNext.Y2 = 140;
            // 
            // lsBest
            // 
            this.lsBest.BorderWidth = 3;
            this.lsBest.Name = "lsBest";
            this.lsBest.X1 = 66;
            this.lsBest.X2 = 86;
            this.lsBest.Y1 = 140;
            this.lsBest.Y2 = 140;
            // 
            // lsLast
            // 
            this.lsLast.BorderWidth = 3;
            this.lsLast.Name = "lsLast";
            this.lsLast.X1 = 22;
            this.lsLast.X2 = 42;
            this.lsLast.Y1 = 140;
            this.lsLast.Y2 = 140;
            // 
            // rectangleShape3
            // 
            this.rectangleShape3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rectangleShape3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.rectangleShape3.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape3.CornerRadius = 8;
            this.rectangleShape3.Location = new System.Drawing.Point(16, 38);
            this.rectangleShape3.Name = "rectangleShape3";
            this.rectangleShape3.Size = new System.Drawing.Size(241, 105);
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rectangleShape2.BorderColor = System.Drawing.Color.Red;
            this.rectangleShape2.BorderWidth = 2;
            this.rectangleShape2.CornerRadius = 8;
            this.rectangleShape2.Location = new System.Drawing.Point(6, 6);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(262, 169);
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rectangleShape1.BorderColor = System.Drawing.Color.OrangeRed;
            this.rectangleShape1.BorderWidth = 4;
            this.rectangleShape1.CornerRadius = 8;
            this.rectangleShape1.Location = new System.Drawing.Point(8, 8);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(257, 164);
            // 
            // lblLapTime
            // 
            this.lblLapTime.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lblLapTime.Font = new System.Drawing.Font("DS-Digital", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLapTime.Location = new System.Drawing.Point(112, 69);
            this.lblLapTime.Name = "lblLapTime";
            this.lblLapTime.Size = new System.Drawing.Size(72, 32);
            this.lblLapTime.TabIndex = 2;
            this.lblLapTime.Text = "00";
            this.lblLapTime.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(154, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Laps";
            // 
            // lblLapCount
            // 
            this.lblLapCount.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lblLapCount.Font = new System.Drawing.Font("DS-Digital", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLapCount.Location = new System.Drawing.Point(144, 40);
            this.lblLapCount.Name = "lblLapCount";
            this.lblLapCount.Size = new System.Drawing.Size(56, 24);
            this.lblLapCount.TabIndex = 4;
            this.lblLapCount.Text = "000";
            this.lblLapCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLapNumber
            // 
            this.lblLapNumber.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lblLapNumber.Font = new System.Drawing.Font("DS-Digital", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLapNumber.Location = new System.Drawing.Point(80, 40);
            this.lblLapNumber.Name = "lblLapNumber";
            this.lblLapNumber.Size = new System.Drawing.Size(56, 24);
            this.lblLapNumber.TabIndex = 6;
            this.lblLapNumber.Text = "000";
            this.lblLapNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(88, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Lap #";
            // 
            // lblCarNumber
            // 
            this.lblCarNumber.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lblCarNumber.Font = new System.Drawing.Font("DS-Digital", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCarNumber.Location = new System.Drawing.Point(25, 40);
            this.lblCarNumber.Name = "lblCarNumber";
            this.lblCarNumber.Size = new System.Drawing.Size(40, 24);
            this.lblCarNumber.TabIndex = 8;
            this.lblCarNumber.Text = "000";
            this.lblCarNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(26, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Car #";
            // 
            // lblLapTimeFractions
            // 
            this.lblLapTimeFractions.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lblLapTimeFractions.Font = new System.Drawing.Font("DS-Digital", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLapTimeFractions.Location = new System.Drawing.Point(176, 72);
            this.lblLapTimeFractions.Name = "lblLapTimeFractions";
            this.lblLapTimeFractions.Size = new System.Drawing.Size(64, 32);
            this.lblLapTimeFractions.TabIndex = 9;
            this.lblLapTimeFractions.Text = ".000";
            this.lblLapTimeFractions.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblLapMphFractions
            // 
            this.lblLapMphFractions.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lblLapMphFractions.Font = new System.Drawing.Font("DS-Digital", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLapMphFractions.Location = new System.Drawing.Point(176, 107);
            this.lblLapMphFractions.Name = "lblLapMphFractions";
            this.lblLapMphFractions.Size = new System.Drawing.Size(64, 32);
            this.lblLapMphFractions.TabIndex = 11;
            this.lblLapMphFractions.Text = ".000";
            this.lblLapMphFractions.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblLapMph
            // 
            this.lblLapMph.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lblLapMph.Font = new System.Drawing.Font("DS-Digital", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLapMph.Location = new System.Drawing.Point(112, 104);
            this.lblLapMph.Name = "lblLapMph";
            this.lblLapMph.Size = new System.Drawing.Size(72, 32);
            this.lblLapMph.TabIndex = 10;
            this.lblLapMph.Text = "000";
            this.lblLapMph.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "Lap Time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(60, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 22);
            this.label3.TabIndex = 13;
            this.label3.Text = "MPH:";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(16, 144);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(32, 23);
            this.btnPrevious.TabIndex = 14;
            this.btnPrevious.Text = "<-";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnBest
            // 
            this.btnBest.Location = new System.Drawing.Point(56, 144);
            this.btnBest.Name = "btnBest";
            this.btnBest.Size = new System.Drawing.Size(40, 23);
            this.btnBest.TabIndex = 15;
            this.btnBest.Text = "Best";
            this.btnBest.UseVisualStyleBackColor = true;
            this.btnBest.Click += new System.EventHandler(this.btnBest_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(192, 144);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(64, 23);
            this.btnLast.TabIndex = 16;
            this.btnLast.Text = "Last";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnCurrent_Click);
            // 
            // lblBestLap
            // 
            this.lblBestLap.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lblBestLap.Font = new System.Drawing.Font("DS-Digital", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBestLap.Location = new System.Drawing.Point(202, 40);
            this.lblBestLap.Name = "lblBestLap";
            this.lblBestLap.Size = new System.Drawing.Size(56, 24);
            this.lblBestLap.TabIndex = 18;
            this.lblBestLap.Text = "000";
            this.lblBestLap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(200, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Best Lap";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(104, 144);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(32, 23);
            this.btnNext.TabIndex = 19;
            this.btnNext.Text = "->";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // currentLapTimer
            // 
            this.currentLapTimer.Interval = 1000;
            this.currentLapTimer.Tick += new System.EventHandler(this.currentLapTimer_Tick);
            // 
            // StopwatchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblBestLap);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnBest);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLapMphFractions);
            this.Controls.Add(this.lblLapMph);
            this.Controls.Add(this.lblLapTimeFractions);
            this.Controls.Add(this.lblCarNumber);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblLapNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblLapCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLapTime);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "StopwatchView";
            this.Size = new System.Drawing.Size(274, 181);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape3;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.Label lblLapTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLapCount;
        private System.Windows.Forms.Label lblLapNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCarNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblLapTimeFractions;
        private System.Windows.Forms.Label lblLapMphFractions;
        private System.Windows.Forms.Label lblLapMph;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnBest;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Label lblBestLap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnNext;
        private Microsoft.VisualBasic.PowerPacks.LineShape lsCurrent;
        private Microsoft.VisualBasic.PowerPacks.LineShape lsNext;
        private Microsoft.VisualBasic.PowerPacks.LineShape lsBest;
        private Microsoft.VisualBasic.PowerPacks.LineShape lsLast;
        private System.Windows.Forms.Timer currentLapTimer;
    }
}
