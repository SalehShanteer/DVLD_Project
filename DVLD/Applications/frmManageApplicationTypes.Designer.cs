namespace DVLD
{
    partial class frmManageApplicationTypes
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
            this.lblApplicationTypesCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvApplicationTypesList = new System.Windows.Forms.DataGridView();
            this.cmsManageApplicationTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblAddUpdatePerson = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationTypesList)).BeginInit();
            this.cmsManageApplicationTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblApplicationTypesCount
            // 
            this.lblApplicationTypesCount.AutoSize = true;
            this.lblApplicationTypesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationTypesCount.Location = new System.Drawing.Point(114, 427);
            this.lblApplicationTypesCount.Name = "lblApplicationTypesCount";
            this.lblApplicationTypesCount.Size = new System.Drawing.Size(19, 20);
            this.lblApplicationTypesCount.TabIndex = 14;
            this.lblApplicationTypesCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 426);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "# Records:";
            // 
            // dgvApplicationTypesList
            // 
            this.dgvApplicationTypesList.AllowUserToAddRows = false;
            this.dgvApplicationTypesList.AllowUserToDeleteRows = false;
            this.dgvApplicationTypesList.AllowUserToOrderColumns = true;
            this.dgvApplicationTypesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplicationTypesList.ContextMenuStrip = this.cmsManageApplicationTypes;
            this.dgvApplicationTypesList.Location = new System.Drawing.Point(20, 251);
            this.dgvApplicationTypesList.Name = "dgvApplicationTypesList";
            this.dgvApplicationTypesList.ReadOnly = true;
            this.dgvApplicationTypesList.Size = new System.Drawing.Size(498, 164);
            this.dgvApplicationTypesList.TabIndex = 11;
            // 
            // cmsManageApplicationTypes
            // 
            this.cmsManageApplicationTypes.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.cmsManageApplicationTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.editToolStripMenuItem});
            this.cmsManageApplicationTypes.Name = "cmsManagePeople";
            this.cmsManageApplicationTypes.Size = new System.Drawing.Size(129, 46);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(125, 6);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD.Properties.Resources.EditPerson;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(128, 36);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // lblAddUpdatePerson
            // 
            this.lblAddUpdatePerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddUpdatePerson.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAddUpdatePerson.Location = new System.Drawing.Point(27, 194);
            this.lblAddUpdatePerson.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddUpdatePerson.Name = "lblAddUpdatePerson";
            this.lblAddUpdatePerson.Size = new System.Drawing.Size(487, 43);
            this.lblAddUpdatePerson.TabIndex = 10;
            this.lblAddUpdatePerson.Text = "Manage Application Types";
            this.lblAddUpdatePerson.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(408, 421);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 30);
            this.btnClose.TabIndex = 100;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.ManageApplicationTypes;
            this.pictureBox1.Location = new System.Drawing.Point(191, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(177, 170);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // frmManageApplicationTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(539, 456);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblApplicationTypesCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvApplicationTypesList);
            this.Controls.Add(this.lblAddUpdatePerson);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmManageApplicationTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Application Types";
            this.Load += new System.EventHandler(this.frmManageApplicationTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationTypesList)).EndInit();
            this.cmsManageApplicationTypes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblApplicationTypesCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvApplicationTypesList;
        private System.Windows.Forms.Label lblAddUpdatePerson;
        private System.Windows.Forms.ContextMenuStrip cmsManageApplicationTypes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.Button btnClose;
    }
}