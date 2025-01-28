namespace DVLD
{
    partial class ctrlDriverLicenses
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tcLicenses = new System.Windows.Forms.TabControl();
            this.tabLocal = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLocalLicensesList = new System.Windows.Forms.DataGridView();
            this.cmsLicenses = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLocalLicensesCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabInternational = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvInternationalLicensesList = new System.Windows.Forms.DataGridView();
            this.lblInternationalLicensesCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tcLicenses.SuspendLayout();
            this.tabLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesList)).BeginInit();
            this.cmsLicenses.SuspendLayout();
            this.tabInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicensesList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.tcLicenses);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(893, 311);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            // 
            // tcLicenses
            // 
            this.tcLicenses.Controls.Add(this.tabLocal);
            this.tcLicenses.Controls.Add(this.tabInternational);
            this.tcLicenses.Location = new System.Drawing.Point(9, 30);
            this.tcLicenses.Name = "tcLicenses";
            this.tcLicenses.SelectedIndex = 0;
            this.tcLicenses.Size = new System.Drawing.Size(884, 278);
            this.tcLicenses.TabIndex = 0;
            // 
            // tabLocal
            // 
            this.tabLocal.Controls.Add(this.label1);
            this.tabLocal.Controls.Add(this.dgvLocalLicensesList);
            this.tabLocal.Controls.Add(this.lblLocalLicensesCount);
            this.tabLocal.Controls.Add(this.label2);
            this.tabLocal.Location = new System.Drawing.Point(4, 29);
            this.tabLocal.Name = "tabLocal";
            this.tabLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tabLocal.Size = new System.Drawing.Size(876, 245);
            this.tabLocal.TabIndex = 0;
            this.tabLocal.Text = "Local";
            this.tabLocal.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 20);
            this.label1.TabIndex = 111;
            this.label1.Text = "Local Licenses History:";
            // 
            // dgvLocalLicensesList
            // 
            this.dgvLocalLicensesList.AllowUserToAddRows = false;
            this.dgvLocalLicensesList.AllowUserToDeleteRows = false;
            this.dgvLocalLicensesList.AllowUserToOrderColumns = true;
            this.dgvLocalLicensesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicensesList.ContextMenuStrip = this.cmsLicenses;
            this.dgvLocalLicensesList.Location = new System.Drawing.Point(11, 38);
            this.dgvLocalLicensesList.Name = "dgvLocalLicensesList";
            this.dgvLocalLicensesList.ReadOnly = true;
            this.dgvLocalLicensesList.Size = new System.Drawing.Size(848, 171);
            this.dgvLocalLicensesList.TabIndex = 110;
            // 
            // cmsLicenses
            // 
            this.cmsLicenses.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.cmsLicenses.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.cmsLicenses.Name = "cmsLicenses";
            this.cmsLicenses.Size = new System.Drawing.Size(241, 40);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Image = global::DVLD.Properties.Resources.Details;
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(240, 36);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // lblLocalLicensesCount
            // 
            this.lblLocalLicensesCount.AutoSize = true;
            this.lblLocalLicensesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalLicensesCount.Location = new System.Drawing.Point(112, 216);
            this.lblLocalLicensesCount.Name = "lblLocalLicensesCount";
            this.lblLocalLicensesCount.Size = new System.Drawing.Size(19, 20);
            this.lblLocalLicensesCount.TabIndex = 109;
            this.lblLocalLicensesCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 108;
            this.label2.Text = "# Records:";
            // 
            // tabInternational
            // 
            this.tabInternational.Controls.Add(this.label3);
            this.tabInternational.Controls.Add(this.dgvInternationalLicensesList);
            this.tabInternational.Controls.Add(this.lblInternationalLicensesCount);
            this.tabInternational.Controls.Add(this.label5);
            this.tabInternational.Location = new System.Drawing.Point(4, 29);
            this.tabInternational.Name = "tabInternational";
            this.tabInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tabInternational.Size = new System.Drawing.Size(876, 242);
            this.tabInternational.TabIndex = 1;
            this.tabInternational.Text = "International";
            this.tabInternational.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 20);
            this.label3.TabIndex = 115;
            this.label3.Text = "International Licenses History:";
            // 
            // dgvInternationalLicensesList
            // 
            this.dgvInternationalLicensesList.AllowUserToAddRows = false;
            this.dgvInternationalLicensesList.AllowUserToDeleteRows = false;
            this.dgvInternationalLicensesList.AllowUserToOrderColumns = true;
            this.dgvInternationalLicensesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicensesList.ContextMenuStrip = this.cmsLicenses;
            this.dgvInternationalLicensesList.Location = new System.Drawing.Point(11, 38);
            this.dgvInternationalLicensesList.Name = "dgvInternationalLicensesList";
            this.dgvInternationalLicensesList.ReadOnly = true;
            this.dgvInternationalLicensesList.Size = new System.Drawing.Size(847, 171);
            this.dgvInternationalLicensesList.TabIndex = 114;
            // 
            // lblInternationalLicensesCount
            // 
            this.lblInternationalLicensesCount.AutoSize = true;
            this.lblInternationalLicensesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternationalLicensesCount.Location = new System.Drawing.Point(112, 215);
            this.lblInternationalLicensesCount.Name = "lblInternationalLicensesCount";
            this.lblInternationalLicensesCount.Size = new System.Drawing.Size(19, 20);
            this.lblInternationalLicensesCount.TabIndex = 113;
            this.lblInternationalLicensesCount.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 112;
            this.label5.Text = "# Records:";
            // 
            // ctrlDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ctrlDriverLicenses";
            this.Size = new System.Drawing.Size(898, 316);
            this.groupBox1.ResumeLayout(false);
            this.tcLicenses.ResumeLayout(false);
            this.tabLocal.ResumeLayout(false);
            this.tabLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesList)).EndInit();
            this.cmsLicenses.ResumeLayout(false);
            this.tabInternational.ResumeLayout(false);
            this.tabInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicensesList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tcLicenses;
        private System.Windows.Forms.TabPage tabLocal;
        private System.Windows.Forms.TabPage tabInternational;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLocalLicensesList;
        private System.Windows.Forms.Label lblLocalLicensesCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvInternationalLicensesList;
        private System.Windows.Forms.Label lblInternationalLicensesCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip cmsLicenses;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
    }
}
