namespace Nascar.ServiceScheduler
{
    partial class SeriesScheduleDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeriesScheduleDialog));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.chkCup = new System.Windows.Forms.CheckBox();
            this.chkNationwide = new System.Windows.Forms.CheckBox();
            this.chkTruck = new System.Windows.Forms.CheckBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSessions = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.filterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnClose,
            this.btnDelete,
            this.toolStripSeparator1,
            this.btnSessions,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(609, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(33, 22);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(31, 22);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 22);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(44, 22);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(609, 170);
            this.dataGridView1.TabIndex = 2;
            // 
            // filterPanel
            // 
            this.filterPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.filterPanel.Controls.Add(this.chkTruck);
            this.filterPanel.Controls.Add(this.chkNationwide);
            this.filterPanel.Controls.Add(this.chkCup);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterPanel.Location = new System.Drawing.Point(0, 25);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(609, 31);
            this.filterPanel.TabIndex = 3;
            // 
            // chkCup
            // 
            this.chkCup.AutoSize = true;
            this.chkCup.Checked = true;
            this.chkCup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCup.Location = new System.Drawing.Point(8, 8);
            this.chkCup.Name = "chkCup";
            this.chkCup.Size = new System.Drawing.Size(107, 17);
            this.chkCup.TabIndex = 0;
            this.chkCup.Text = "Sprint Cup Series";
            this.chkCup.UseVisualStyleBackColor = true;
            this.chkCup.CheckedChanged += new System.EventHandler(this.chkCup_CheckedChanged);
            // 
            // chkNationwide
            // 
            this.chkNationwide.AutoSize = true;
            this.chkNationwide.Checked = true;
            this.chkNationwide.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNationwide.Location = new System.Drawing.Point(128, 8);
            this.chkNationwide.Name = "chkNationwide";
            this.chkNationwide.Size = new System.Drawing.Size(111, 17);
            this.chkNationwide.TabIndex = 1;
            this.chkNationwide.Text = "Nationwide Series";
            this.chkNationwide.UseVisualStyleBackColor = true;
            this.chkNationwide.CheckedChanged += new System.EventHandler(this.chkCup_CheckedChanged);
            // 
            // chkTruck
            // 
            this.chkTruck.AutoSize = true;
            this.chkTruck.Checked = true;
            this.chkTruck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTruck.Location = new System.Drawing.Point(256, 8);
            this.chkTruck.Name = "chkTruck";
            this.chkTruck.Size = new System.Drawing.Size(161, 17);
            this.chkTruck.TabIndex = 2;
            this.chkTruck.Text = "Camping World Truck Series";
            this.chkTruck.UseVisualStyleBackColor = true;
            this.chkTruck.CheckedChanged += new System.EventHandler(this.chkCup_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSessions
            // 
            this.btnSessions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSessions.Image = ((System.Drawing.Image)(resources.GetObject("btnSessions.Image")));
            this.btnSessions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSessions.Name = "btnSessions";
            this.btnSessions.Size = new System.Drawing.Size(55, 22);
            this.btnSessions.Text = "Sessions";
            this.btnSessions.Click += new System.EventHandler(this.btnSessions_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // SeriesScheduleDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 226);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SeriesScheduleDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Series Schedule";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.CheckBox chkTruck;
        private System.Windows.Forms.CheckBox chkNationwide;
        private System.Windows.Forms.CheckBox chkCup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSessions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}