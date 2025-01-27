namespace DVLD
{
    partial class frmManageDrivers
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
            this.components = new System.ComponentModel.Container();
            this.dgvDriversList = new System.Windows.Forms.DataGridView();
            this.cmsDrivers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueInternationalLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicensesHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.cbxFilter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDriversCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDriversList)).BeginInit();
            this.cmsDrivers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDriversList
            // 
            this.dgvDriversList.AllowUserToAddRows = false;
            this.dgvDriversList.AllowUserToDeleteRows = false;
            this.dgvDriversList.AllowUserToOrderColumns = true;
            this.dgvDriversList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDriversList.ContextMenuStrip = this.cmsDrivers;
            this.dgvDriversList.Location = new System.Drawing.Point(12, 336);
            this.dgvDriversList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvDriversList.Name = "dgvDriversList";
            this.dgvDriversList.ReadOnly = true;
            this.dgvDriversList.Size = new System.Drawing.Size(846, 291);
            this.dgvDriversList.TabIndex = 5;
            // 
            // cmsDrivers
            // 
            this.cmsDrivers.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.cmsDrivers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonInfoToolStripMenuItem,
            this.issueInternationalLicenseToolStripMenuItem,
            this.showLicensesHistoryToolStripMenuItem});
            this.cmsDrivers.Name = "cmsDrivers";
            this.cmsDrivers.Size = new System.Drawing.Size(300, 112);
            // 
            // showPersonInfoToolStripMenuItem
            // 
            this.showPersonInfoToolStripMenuItem.Image = global::DVLD.Properties.Resources.Details;
            this.showPersonInfoToolStripMenuItem.Name = "showPersonInfoToolStripMenuItem";
            this.showPersonInfoToolStripMenuItem.Size = new System.Drawing.Size(299, 36);
            this.showPersonInfoToolStripMenuItem.Text = "Show Person Info";
            this.showPersonInfoToolStripMenuItem.Click += new System.EventHandler(this.showPersonInfoToolStripMenuItem_Click);
            // 
            // issueInternationalLicenseToolStripMenuItem
            // 
            this.issueInternationalLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.International;
            this.issueInternationalLicenseToolStripMenuItem.Name = "issueInternationalLicenseToolStripMenuItem";
            this.issueInternationalLicenseToolStripMenuItem.Size = new System.Drawing.Size(299, 36);
            this.issueInternationalLicenseToolStripMenuItem.Text = "Issue International license";
            this.issueInternationalLicenseToolStripMenuItem.Click += new System.EventHandler(this.issueInternationalLicenseToolStripMenuItem_Click);
            // 
            // showLicensesHistoryToolStripMenuItem
            // 
            this.showLicensesHistoryToolStripMenuItem.Image = global::DVLD.Properties.Resources.History;
            this.showLicensesHistoryToolStripMenuItem.Name = "showLicensesHistoryToolStripMenuItem";
            this.showLicensesHistoryToolStripMenuItem.Size = new System.Drawing.Size(299, 36);
            this.showLicensesHistoryToolStripMenuItem.Text = "Show Licenses History";
            this.showLicensesHistoryToolStripMenuItem.Click += new System.EventHandler(this.showLicensesHistoryToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(292, 240);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = "Manage Drivers";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Driver;
            this.pictureBox1.Location = new System.Drawing.Point(335, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 207);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(335, 297);
            this.txtFilter.MaxLength = 50;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(207, 26);
            this.txtFilter.TabIndex = 104;
            this.txtFilter.Visible = false;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // cbxFilter
            // 
            this.cbxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFilter.FormattingEnabled = true;
            this.cbxFilter.Items.AddRange(new object[] {
            "None",
            "Driver ID",
            "Person ID",
            "National No.",
            "Full Name"});
            this.cbxFilter.Location = new System.Drawing.Point(125, 295);
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.Size = new System.Drawing.Size(186, 28);
            this.cbxFilter.TabIndex = 103;
            this.cbxFilter.SelectedIndexChanged += new System.EventHandler(this.cbxFilter_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 301);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 102;
            this.label3.Text = "Filter By:";
            // 
            // lblDriversCount
            // 
            this.lblDriversCount.AutoSize = true;
            this.lblDriversCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriversCount.Location = new System.Drawing.Point(114, 638);
            this.lblDriversCount.Name = "lblDriversCount";
            this.lblDriversCount.Size = new System.Drawing.Size(19, 20);
            this.lblDriversCount.TabIndex = 107;
            this.lblDriversCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 637);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 106;
            this.label2.Text = "# Records:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(746, 630);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(109, 30);
            this.btnClose.TabIndex = 108;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmManageDrivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 663);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblDriversCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.cbxFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvDriversList);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmManageDrivers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Drivers";
            this.Load += new System.EventHandler(this.frmManageDrivers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDriversList)).EndInit();
            this.cmsDrivers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDriversList;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ComboBox cbxFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDriversCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip cmsDrivers;
        private System.Windows.Forms.ToolStripMenuItem showPersonInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueInternationalLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicensesHistoryToolStripMenuItem;
        private System.Windows.Forms.Button btnClose;
    }
}