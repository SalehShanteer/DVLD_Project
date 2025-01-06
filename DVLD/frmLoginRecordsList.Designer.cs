namespace DVLD
{
    partial class frmLoginRecordsList
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
            this.lblLoginRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.cbxFilter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvLoginRecordsList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbLoginDate = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoginRecordsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbLoginDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLoginRecordsCount
            // 
            this.lblLoginRecordsCount.AutoSize = true;
            this.lblLoginRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginRecordsCount.Location = new System.Drawing.Point(110, 669);
            this.lblLoginRecordsCount.Name = "lblLoginRecordsCount";
            this.lblLoginRecordsCount.Size = new System.Drawing.Size(19, 20);
            this.lblLoginRecordsCount.TabIndex = 111;
            this.lblLoginRecordsCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 668);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 110;
            this.label2.Text = "# Records:";
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(342, 297);
            this.txtFilter.MaxLength = 50;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(207, 26);
            this.txtFilter.TabIndex = 109;
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
            "User ID",
            "User Role",
            "Login Time",
            "Login Status",
            "Failure Reason"});
            this.cbxFilter.Location = new System.Drawing.Point(132, 295);
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.Size = new System.Drawing.Size(186, 28);
            this.cbxFilter.TabIndex = 108;
            this.cbxFilter.SelectedIndexChanged += new System.EventHandler(this.cbxFilter_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 301);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 107;
            this.label3.Text = "Filter By:";
            // 
            // dgvLoginRecordsList
            // 
            this.dgvLoginRecordsList.AllowUserToAddRows = false;
            this.dgvLoginRecordsList.AllowUserToDeleteRows = false;
            this.dgvLoginRecordsList.AllowUserToOrderColumns = true;
            this.dgvLoginRecordsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoginRecordsList.Location = new System.Drawing.Point(17, 338);
            this.dgvLoginRecordsList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvLoginRecordsList.Name = "dgvLoginRecordsList";
            this.dgvLoginRecordsList.ReadOnly = true;
            this.dgvLoginRecordsList.Size = new System.Drawing.Size(1117, 318);
            this.dgvLoginRecordsList.TabIndex = 106;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(428, 238);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 39);
            this.label1.TabIndex = 112;
            this.label1.Text = "Login Records";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD.Properties.Resources.Records;
            this.pictureBox1.Location = new System.Drawing.Point(444, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 209);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 113;
            this.pictureBox1.TabStop = false;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(84, 37);
            this.dtpDateFrom.MinDate = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(117, 26);
            this.dtpDateFrom.TabIndex = 114;
            this.dtpDateFrom.Value = new System.DateTime(2024, 12, 1, 19, 53, 0, 0);
            this.dtpDateFrom.ValueChanged += new System.EventHandler(this.dtpDateFrom_ValueChanged);
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(291, 37);
            this.dtpDateTo.MinDate = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(119, 26);
            this.dtpDateTo.TabIndex = 115;
            this.dtpDateTo.ValueChanged += new System.EventHandler(this.dtpDateTo_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 116;
            this.label4.Text = "From";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(231, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 20);
            this.label5.TabIndex = 117;
            this.label5.Text = "To";
            // 
            // gbLoginDate
            // 
            this.gbLoginDate.Controls.Add(this.dtpDateTo);
            this.gbLoginDate.Controls.Add(this.label5);
            this.gbLoginDate.Controls.Add(this.dtpDateFrom);
            this.gbLoginDate.Controls.Add(this.label4);
            this.gbLoginDate.Location = new System.Drawing.Point(688, 244);
            this.gbLoginDate.Name = "gbLoginDate";
            this.gbLoginDate.Size = new System.Drawing.Size(427, 77);
            this.gbLoginDate.TabIndex = 118;
            this.gbLoginDate.TabStop = false;
            this.gbLoginDate.Text = "Login Date";
            // 
            // frmLoginRecordsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 689);
            this.Controls.Add(this.gbLoginDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblLoginRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.cbxFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvLoginRecordsList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmLoginRecordsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login Records";
            this.Load += new System.EventHandler(this.frmLoginRecordsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoginRecordsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbLoginDate.ResumeLayout(false);
            this.gbLoginDate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLoginRecordsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.ComboBox cbxFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvLoginRecordsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbLoginDate;
    }
}