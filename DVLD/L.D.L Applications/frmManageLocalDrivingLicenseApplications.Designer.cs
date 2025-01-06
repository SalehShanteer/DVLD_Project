namespace DVLD
{
    partial class frmManageLocalDrivingLicenseApplications
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
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.cbxFilter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvLocalDrivingLicenseApplicationsList = new System.Windows.Forms.DataGridView();
            this.cmsLocalDrivingLicenseApplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleTestsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleWrittenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issueDrivingLicenseFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLocalDrivingLicenseApplicationsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddNewLocalDrivingLicenseApplication = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplicationsList)).BeginInit();
            this.cmsLocalDrivingLicenseApplications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(348, 342);
            this.txtFilter.MaxLength = 50;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(207, 26);
            this.txtFilter.TabIndex = 101;
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
            "L.D.L.AppID",
            "National No.",
            "Full Name",
            "Status"});
            this.cbxFilter.Location = new System.Drawing.Point(138, 340);
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.Size = new System.Drawing.Size(186, 28);
            this.cbxFilter.TabIndex = 100;
            this.cbxFilter.SelectedIndexChanged += new System.EventHandler(this.cbxFilter_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(37, 346);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 99;
            this.label3.Text = "Filter By:";
            // 
            // dgvLocalDrivingLicenseApplicationsList
            // 
            this.dgvLocalDrivingLicenseApplicationsList.AllowUserToAddRows = false;
            this.dgvLocalDrivingLicenseApplicationsList.AllowUserToDeleteRows = false;
            this.dgvLocalDrivingLicenseApplicationsList.AllowUserToOrderColumns = true;
            this.dgvLocalDrivingLicenseApplicationsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalDrivingLicenseApplicationsList.ContextMenuStrip = this.cmsLocalDrivingLicenseApplications;
            this.dgvLocalDrivingLicenseApplicationsList.Location = new System.Drawing.Point(23, 383);
            this.dgvLocalDrivingLicenseApplicationsList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvLocalDrivingLicenseApplicationsList.Name = "dgvLocalDrivingLicenseApplicationsList";
            this.dgvLocalDrivingLicenseApplicationsList.ReadOnly = true;
            this.dgvLocalDrivingLicenseApplicationsList.Size = new System.Drawing.Size(1180, 318);
            this.dgvLocalDrivingLicenseApplicationsList.TabIndex = 98;
            // 
            // cmsLocalDrivingLicenseApplications
            // 
            this.cmsLocalDrivingLicenseApplications.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.cmsLocalDrivingLicenseApplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.editApplicationToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.cancelApplicationToolStripMenuItem,
            this.scheduleTestsToolStripMenuItem,
            this.issueDrivingLicenseFirstTimeToolStripMenuItem,
            this.showLicenseToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.cmsLocalDrivingLicenseApplications.Name = "cmsLocalDrivingLicenseApplications";
            this.cmsLocalDrivingLicenseApplications.Size = new System.Drawing.Size(353, 292);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Image = global::DVLD.Properties.Resources.Details;
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(352, 36);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            // 
            // editApplicationToolStripMenuItem
            // 
            this.editApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.Edit;
            this.editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            this.editApplicationToolStripMenuItem.Size = new System.Drawing.Size(352, 36);
            this.editApplicationToolStripMenuItem.Text = "Edit Application";
            this.editApplicationToolStripMenuItem.Click += new System.EventHandler(this.editApplicationToolStripMenuItem_Click);
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.Delete;
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(352, 36);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            this.deleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Image = global::DVLD.Properties.Resources.Cancel;
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(352, 36);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application";
            this.cancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // scheduleTestsToolStripMenuItem
            // 
            this.scheduleTestsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleVisionTestToolStripMenuItem,
            this.scheduleWrittenTestToolStripMenuItem,
            this.scheduleStreetTestToolStripMenuItem});
            this.scheduleTestsToolStripMenuItem.Image = global::DVLD.Properties.Resources.ManageTestTypes;
            this.scheduleTestsToolStripMenuItem.Name = "scheduleTestsToolStripMenuItem";
            this.scheduleTestsToolStripMenuItem.Size = new System.Drawing.Size(352, 36);
            this.scheduleTestsToolStripMenuItem.Text = "Schedule Tests";
            // 
            // scheduleVisionTestToolStripMenuItem
            // 
            this.scheduleVisionTestToolStripMenuItem.Name = "scheduleVisionTestToolStripMenuItem";
            this.scheduleVisionTestToolStripMenuItem.Size = new System.Drawing.Size(253, 30);
            this.scheduleVisionTestToolStripMenuItem.Text = "Schedule Vision Test";
            // 
            // scheduleWrittenTestToolStripMenuItem
            // 
            this.scheduleWrittenTestToolStripMenuItem.Name = "scheduleWrittenTestToolStripMenuItem";
            this.scheduleWrittenTestToolStripMenuItem.Size = new System.Drawing.Size(253, 30);
            this.scheduleWrittenTestToolStripMenuItem.Text = "Schedule Written Test";
            // 
            // scheduleStreetTestToolStripMenuItem
            // 
            this.scheduleStreetTestToolStripMenuItem.Name = "scheduleStreetTestToolStripMenuItem";
            this.scheduleStreetTestToolStripMenuItem.Size = new System.Drawing.Size(253, 30);
            this.scheduleStreetTestToolStripMenuItem.Text = "Schedule Street Test";
            // 
            // issueDrivingLicenseFirstTimeToolStripMenuItem
            // 
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Image = global::DVLD.Properties.Resources.DrivingLicense;
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Name = "issueDrivingLicenseFirstTimeToolStripMenuItem";
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(352, 36);
            this.issueDrivingLicenseFirstTimeToolStripMenuItem.Text = "Issue Driving License (First Time)";
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Image = global::DVLD.Properties.Resources.DrivingLicense;
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(352, 36);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD.Properties.Resources.History;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(352, 36);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(328, 273);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(578, 39);
            this.label1.TabIndex = 102;
            this.label1.Text = "Local Driving License Applications";
            // 
            // lblLocalDrivingLicenseApplicationsCount
            // 
            this.lblLocalDrivingLicenseApplicationsCount.AutoSize = true;
            this.lblLocalDrivingLicenseApplicationsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalDrivingLicenseApplicationsCount.Location = new System.Drawing.Point(116, 714);
            this.lblLocalDrivingLicenseApplicationsCount.Name = "lblLocalDrivingLicenseApplicationsCount";
            this.lblLocalDrivingLicenseApplicationsCount.Size = new System.Drawing.Size(19, 20);
            this.lblLocalDrivingLicenseApplicationsCount.TabIndex = 105;
            this.lblLocalDrivingLicenseApplicationsCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 713);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 104;
            this.label2.Text = "# Records:";
            // 
            // btnAddNewLocalDrivingLicenseApplication
            // 
            this.btnAddNewLocalDrivingLicenseApplication.Location = new System.Drawing.Point(955, 329);
            this.btnAddNewLocalDrivingLicenseApplication.Name = "btnAddNewLocalDrivingLicenseApplication";
            this.btnAddNewLocalDrivingLicenseApplication.Size = new System.Drawing.Size(223, 37);
            this.btnAddNewLocalDrivingLicenseApplication.TabIndex = 106;
            this.btnAddNewLocalDrivingLicenseApplication.Text = "Add New L.D.L Application";
            this.btnAddNewLocalDrivingLicenseApplication.UseVisualStyleBackColor = true;
            this.btnAddNewLocalDrivingLicenseApplication.Click += new System.EventHandler(this.btnAddNewLocalDrivingLicenseApplication_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.ManageApplication;
            this.pictureBox1.Location = new System.Drawing.Point(499, 32);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(228, 224);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 103;
            this.pictureBox1.TabStop = false;
            // 
            // frmManageLocalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 747);
            this.Controls.Add(this.btnAddNewLocalDrivingLicenseApplication);
            this.Controls.Add(this.lblLocalDrivingLicenseApplicationsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.cbxFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvLocalDrivingLicenseApplicationsList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmManageLocalDrivingLicenseApplications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Local Driving License Applications";
            this.Load += new System.EventHandler(this.frmManageLocalDrivingLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalDrivingLicenseApplicationsList)).EndInit();
            this.cmsLocalDrivingLicenseApplications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ComboBox cbxFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvLocalDrivingLicenseApplicationsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblLocalDrivingLicenseApplicationsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddNewLocalDrivingLicenseApplication;
        private System.Windows.Forms.ContextMenuStrip cmsLocalDrivingLicenseApplications;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleTestsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleWrittenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleStreetTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issueDrivingLicenseFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
    }
}