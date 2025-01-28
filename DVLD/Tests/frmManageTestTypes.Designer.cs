namespace DVLD
{
    partial class frmManageTestTypes
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
            this.lblAddUpdatePerson = new System.Windows.Forms.Label();
            this.dgvTestTypesList = new System.Windows.Forms.DataGridView();
            this.cmsManageTestTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTestTypesCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestTypesList)).BeginInit();
            this.cmsManageTestTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAddUpdatePerson
            // 
            this.lblAddUpdatePerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddUpdatePerson.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAddUpdatePerson.Location = new System.Drawing.Point(183, 198);
            this.lblAddUpdatePerson.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddUpdatePerson.Name = "lblAddUpdatePerson";
            this.lblAddUpdatePerson.Size = new System.Drawing.Size(370, 43);
            this.lblAddUpdatePerson.TabIndex = 5;
            this.lblAddUpdatePerson.Text = "Manage Test Types";
            this.lblAddUpdatePerson.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvTestTypesList
            // 
            this.dgvTestTypesList.AllowUserToAddRows = false;
            this.dgvTestTypesList.AllowUserToDeleteRows = false;
            this.dgvTestTypesList.AllowUserToOrderColumns = true;
            this.dgvTestTypesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestTypesList.ContextMenuStrip = this.cmsManageTestTypes;
            this.dgvTestTypesList.Location = new System.Drawing.Point(13, 251);
            this.dgvTestTypesList.Name = "dgvTestTypesList";
            this.dgvTestTypesList.ReadOnly = true;
            this.dgvTestTypesList.Size = new System.Drawing.Size(703, 98);
            this.dgvTestTypesList.TabIndex = 6;
            // 
            // cmsManageTestTypes
            // 
            this.cmsManageTestTypes.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.cmsManageTestTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.editToolStripMenuItem});
            this.cmsManageTestTypes.Name = "cmsManagePeople";
            this.cmsManageTestTypes.Size = new System.Drawing.Size(129, 46);
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.ManageTestTypes;
            this.pictureBox1.Location = new System.Drawing.Point(273, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(188, 176);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // lblTestTypesCount
            // 
            this.lblTestTypesCount.AutoSize = true;
            this.lblTestTypesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestTypesCount.Location = new System.Drawing.Point(104, 361);
            this.lblTestTypesCount.Name = "lblTestTypesCount";
            this.lblTestTypesCount.Size = new System.Drawing.Size(19, 20);
            this.lblTestTypesCount.TabIndex = 9;
            this.lblTestTypesCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 360);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "# Records:";
            // 
            // frmManageTestTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(728, 387);
            this.Controls.Add(this.lblTestTypesCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvTestTypesList);
            this.Controls.Add(this.lblAddUpdatePerson);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmManageTestTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Test Types";
            this.Load += new System.EventHandler(this.frmManageTestTypes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestTypesList)).EndInit();
            this.cmsManageTestTypes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddUpdatePerson;
        private System.Windows.Forms.DataGridView dgvTestTypesList;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTestTypesCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip cmsManageTestTypes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    }
}