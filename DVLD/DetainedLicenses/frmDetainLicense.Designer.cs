namespace DVLD
{
    partial class frmDetainLicense
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
            this.lblApplicationTitle = new System.Windows.Forms.Label();
            this.ctrlDriverLicenseInfoWithFilter1 = new DVLD.ctrlDriverLicenseInfoWithFilter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFineFees = new System.Windows.Forms.TextBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblLicenseID = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDetainDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDetainID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.llblShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.btnDetain = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblApplicationTitle
            // 
            this.lblApplicationTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblApplicationTitle.Location = new System.Drawing.Point(224, 23);
            this.lblApplicationTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApplicationTitle.Name = "lblApplicationTitle";
            this.lblApplicationTitle.Size = new System.Drawing.Size(343, 43);
            this.lblApplicationTitle.TabIndex = 12;
            this.lblApplicationTitle.Text = "Detain License";
            this.lblApplicationTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlDriverLicenseInfoWithFilter1
            // 
            this.ctrlDriverLicenseInfoWithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(13, 72);
            this.ctrlDriverLicenseInfoWithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlDriverLicenseInfoWithFilter1.Name = "ctrlDriverLicenseInfoWithFilter1";
            this.ctrlDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(785, 431);
            this.ctrlDriverLicenseInfoWithFilter1.TabIndex = 13;
            this.ctrlDriverLicenseInfoWithFilter1.OnFindLicenseComplete += new System.Action<int>(this.ctrlDriverLicenseInfoWithFilter1_OnFindLicenseComplete);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFineFees);
            this.groupBox1.Controls.Add(this.lblCreatedBy);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lblLicenseID);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblDetainDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblDetainID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 505);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(777, 134);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detain Info";
            // 
            // txtFineFees
            // 
            this.txtFineFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFineFees.Location = new System.Drawing.Point(210, 98);
            this.txtFineFees.Name = "txtFineFees";
            this.txtFineFees.Size = new System.Drawing.Size(86, 24);
            this.txtFineFees.TabIndex = 33;
            this.txtFineFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFineFees_KeyPress);
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(605, 68);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(49, 20);
            this.lblCreatedBy.TabIndex = 32;
            this.lblCreatedBy.Text = "????";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(381, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 20);
            this.label14.TabIndex = 31;
            this.label14.Text = "Created By:";
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.AutoSize = true;
            this.lblLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseID.Location = new System.Drawing.Point(605, 35);
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.Size = new System.Drawing.Size(49, 20);
            this.lblLicenseID.TabIndex = 26;
            this.lblLicenseID.Text = "????";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(381, 35);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 20);
            this.label20.TabIndex = 25;
            this.label20.Text = "License ID:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Fine Fees:";
            // 
            // lblDetainDate
            // 
            this.lblDetainDate.AutoSize = true;
            this.lblDetainDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainDate.Location = new System.Drawing.Point(207, 68);
            this.lblDetainDate.Name = "lblDetainDate";
            this.lblDetainDate.Size = new System.Drawing.Size(49, 20);
            this.lblDetainDate.TabIndex = 18;
            this.lblDetainDate.Text = "????";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Detain Date:";
            // 
            // lblDetainID
            // 
            this.lblDetainID.AutoSize = true;
            this.lblDetainID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainID.Location = new System.Drawing.Point(207, 35);
            this.lblDetainID.Name = "lblDetainID";
            this.lblDetainID.Size = new System.Drawing.Size(49, 20);
            this.lblDetainID.TabIndex = 16;
            this.lblDetainID.Text = "????";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Detain ID:";
            // 
            // llblShowLicensesHistory
            // 
            this.llblShowLicensesHistory.AutoSize = true;
            this.llblShowLicensesHistory.Enabled = false;
            this.llblShowLicensesHistory.Location = new System.Drawing.Point(18, 652);
            this.llblShowLicensesHistory.Name = "llblShowLicensesHistory";
            this.llblShowLicensesHistory.Size = new System.Drawing.Size(169, 20);
            this.llblShowLicensesHistory.TabIndex = 19;
            this.llblShowLicensesHistory.TabStop = true;
            this.llblShowLicensesHistory.Text = "Show Licenses History";
            this.llblShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblShowLicensesHistory_LinkClicked);
            // 
            // btnDetain
            // 
            this.btnDetain.Enabled = false;
            this.btnDetain.Location = new System.Drawing.Point(678, 645);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(103, 34);
            this.btnDetain.TabIndex = 18;
            this.btnDetain.Text = "Detain";
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.btnDetain_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(546, 645);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 34);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmDetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 690);
            this.Controls.Add(this.llblShowLicensesHistory);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlDriverLicenseInfoWithFilter1);
            this.Controls.Add(this.lblApplicationTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmDetainLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detain License";
            this.Load += new System.EventHandler(this.frmDetainLicense_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblApplicationTitle;
        private ctrlDriverLicenseInfoWithFilter ctrlDriverLicenseInfoWithFilter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblLicenseID;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDetainDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDetainID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFineFees;
        private System.Windows.Forms.LinkLabel llblShowLicensesHistory;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}