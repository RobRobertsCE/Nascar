namespace ImageHarvester
{
    partial class ImageHarvesterForm
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnFindFromUrl = new System.Windows.Forms.Button();
            this.btnSaveImages = new System.Windows.Forms.Button();
            this.btnLoadImages = new System.Windows.Forms.Button();
            this.btnFindImageUrls = new System.Windows.Forms.Button();
            this.middlePanel = new System.Windows.Forms.Panel();
            this.txtHtml = new System.Windows.Forms.TextBox();
            this.lstPics = new System.Windows.Forms.ListBox();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.flpPics = new System.Windows.Forms.FlowLayoutPanel();
            this.topPanel.SuspendLayout();
            this.middlePanel.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.txtUrl);
            this.topPanel.Controls.Add(this.btnFindFromUrl);
            this.topPanel.Controls.Add(this.btnSaveImages);
            this.topPanel.Controls.Add(this.btnLoadImages);
            this.topPanel.Controls.Add(this.btnFindImageUrls);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1007, 40);
            this.topPanel.TabIndex = 0;
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(360, 8);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(432, 20);
            this.txtUrl.TabIndex = 4;
            this.txtUrl.Text = "http://www.nascar.com/en_us/sprint-cup-series/drivers.html";
            // 
            // btnFindFromUrl
            // 
            this.btnFindFromUrl.Location = new System.Drawing.Point(192, 8);
            this.btnFindFromUrl.Name = "btnFindFromUrl";
            this.btnFindFromUrl.Size = new System.Drawing.Size(160, 23);
            this.btnFindFromUrl.TabIndex = 3;
            this.btnFindFromUrl.Text = "Find Image Url\'s From URL";
            this.btnFindFromUrl.UseVisualStyleBackColor = true;
            this.btnFindFromUrl.Click += new System.EventHandler(this.btnFindFromUrl_Click);
            // 
            // btnSaveImages
            // 
            this.btnSaveImages.Location = new System.Drawing.Point(912, 8);
            this.btnSaveImages.Name = "btnSaveImages";
            this.btnSaveImages.Size = new System.Drawing.Size(88, 23);
            this.btnSaveImages.TabIndex = 2;
            this.btnSaveImages.Text = "Save Images";
            this.btnSaveImages.UseVisualStyleBackColor = true;
            this.btnSaveImages.Click += new System.EventHandler(this.btnSaveImages_Click);
            // 
            // btnLoadImages
            // 
            this.btnLoadImages.Location = new System.Drawing.Point(800, 8);
            this.btnLoadImages.Name = "btnLoadImages";
            this.btnLoadImages.Size = new System.Drawing.Size(104, 23);
            this.btnLoadImages.TabIndex = 1;
            this.btnLoadImages.Text = "Display Images";
            this.btnLoadImages.UseVisualStyleBackColor = true;
            this.btnLoadImages.Click += new System.EventHandler(this.btnDisplayImages_Click);
            // 
            // btnFindImageUrls
            // 
            this.btnFindImageUrls.Location = new System.Drawing.Point(8, 8);
            this.btnFindImageUrls.Name = "btnFindImageUrls";
            this.btnFindImageUrls.Size = new System.Drawing.Size(176, 23);
            this.btnFindImageUrls.TabIndex = 0;
            this.btnFindImageUrls.Text = "Find Image Url\'s From HTML";
            this.btnFindImageUrls.UseVisualStyleBackColor = true;
            this.btnFindImageUrls.Click += new System.EventHandler(this.btnFindImageUrls_Click);
            // 
            // middlePanel
            // 
            this.middlePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.middlePanel.Controls.Add(this.txtHtml);
            this.middlePanel.Controls.Add(this.lstPics);
            this.middlePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.middlePanel.Location = new System.Drawing.Point(0, 40);
            this.middlePanel.Name = "middlePanel";
            this.middlePanel.Size = new System.Drawing.Size(1007, 288);
            this.middlePanel.TabIndex = 1;
            // 
            // txtHtml
            // 
            this.txtHtml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHtml.Location = new System.Drawing.Point(544, 0);
            this.txtHtml.Multiline = true;
            this.txtHtml.Name = "txtHtml";
            this.txtHtml.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtHtml.Size = new System.Drawing.Size(459, 284);
            this.txtHtml.TabIndex = 0;
            // 
            // lstPics
            // 
            this.lstPics.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstPics.FormattingEnabled = true;
            this.lstPics.Location = new System.Drawing.Point(0, 0);
            this.lstPics.Name = "lstPics";
            this.lstPics.ScrollAlwaysVisible = true;
            this.lstPics.Size = new System.Drawing.Size(544, 284);
            this.lstPics.TabIndex = 1;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.flpPics);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 328);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Padding = new System.Windows.Forms.Padding(5);
            this.bottomPanel.Size = new System.Drawing.Size(1007, 262);
            this.bottomPanel.TabIndex = 2;
            // 
            // flpPics
            // 
            this.flpPics.AutoScroll = true;
            this.flpPics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpPics.Location = new System.Drawing.Point(5, 5);
            this.flpPics.Name = "flpPics";
            this.flpPics.Size = new System.Drawing.Size(997, 252);
            this.flpPics.TabIndex = 0;
            // 
            // ImageHarvesterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 590);
            this.Controls.Add(this.middlePanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.topPanel);
            this.Name = "ImageHarvesterForm";
            this.Text = "Image Harvester";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.middlePanel.ResumeLayout(false);
            this.middlePanel.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button btnSaveImages;
        private System.Windows.Forms.Button btnLoadImages;
        private System.Windows.Forms.Button btnFindImageUrls;
        private System.Windows.Forms.Panel middlePanel;
        private System.Windows.Forms.TextBox txtHtml;
        private System.Windows.Forms.ListBox lstPics;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.FlowLayoutPanel flpPics;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnFindFromUrl;
    }
}

