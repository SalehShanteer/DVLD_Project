namespace DVLD
{
    partial class frmAddUpdateLocalDrivingLicenseApplication
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
            this.tcDrivingLicenseApplicationInfo = new System.Windows.Forms.TabControl();
            this.tabPersonInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrlPersonInfoWithFilter1 = new DVLD.ctrlPersonInfoWithFilter();
            this.tabApplicationInfo = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.cbxLicenseClass = new System.Windows.Forms.ComboBox();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDrivingLicenseApplicationID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblAddUpdateLocalDrivingLicenseApplication = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tcDrivingLicenseApplicationInfo.SuspendLayout();
            this.tabPersonInfo.SuspendLayout();
            this.tabApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcDrivingLicenseApplicationInfo
            // 
            this.tcDrivingLicenseApplicationInfo.Controls.Add(this.tabPersonInfo);
            this.tcDrivingLicenseApplicationInfo.Controls.Add(this.tabApplicationInfo);
            this.tcDrivingLicenseApplicationInfo.Location = new System.Drawing.Point(15, 91);
            this.tcDrivingLicenseApplicationInfo.Name = "tcDrivingLicenseApplicationInfo";
            this.tcDrivingLicenseApplicationInfo.SelectedIndex = 0;
            this.tcDrivingLicenseApplicationInfo.Size = new System.Drawing.Size(844, 461);
            this.tcDrivingLicenseApplicationInfo.TabIndex = 0;
            this.tcDrivingLicenseApplicationInfo.SelectedIndexChanged += new System.EventHandler(this.tcDrivingLicenseApplicationInfo_SelectedIndexChanged);
            // 
            // tabPersonInfo
            // 
            this.tabPersonInfo.Controls.Add(this.btnNext);
            this.tabPersonInfo.Controls.Add(this.ctrlPersonInfoWithFilter1);
            this.tabPersonInfo.Location = new System.Drawing.Point(4, 29);
            this.tabPersonInfo.Name = "tabPersonInfo";
            this.tabPersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPersonInfo.Size = new System.Drawing.Size(836, 428);
            this.tabPersonInfo.TabIndex = 0;
            this.tabPersonInfo.Text = "Person Info";
            this.tabPersonInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(714, 383);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(110, 40);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrlPersonInfoWithFilter1
            // 
            this.ctrlPersonInfoWithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlPersonInfoWithFilter1.Location = new System.Drawing.Point(7, 22);
            this.ctrlPersonInfoWithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlPersonInfoWithFilter1.Name = "ctrlPersonInfoWithFilter1";
            this.ctrlPersonInfoWithFilter1.Size = new System.Drawing.Size(831, 364);
            this.ctrlPersonInfoWithFilter1.TabIndex = 0;
            this.ctrlPersonInfoWithFilter1.OnFindPersonComplete += new System.Action<int>(this.ctrlPersonInfoWithFilter1_OnFindPersonComplete);
            // 
            // tabApplicationInfo
            // 
            this.tabApplicationInfo.Controls.Add(this.label8);
            this.tabApplicationInfo.Controls.Add(this.label7);
            this.tabApplicationInfo.Controls.Add(this.label6);
            this.tabApplicationInfo.Controls.Add(this.lblCreatedBy);
            this.tabApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.tabApplicationInfo.Controls.Add(this.cbxLicenseClass);
            this.tabApplicationInfo.Controls.Add(this.lblApplicationDate);
            this.tabApplicationInfo.Controls.Add(this.label2);
            this.tabApplicationInfo.Controls.Add(this.lblDrivingLicenseApplicationID);
            this.tabApplicationInfo.Controls.Add(this.label1);
            this.tabApplicationInfo.Controls.Add(this.btnBack);
            this.tabApplicationInfo.Location = new System.Drawing.Point(4, 29);
            this.tabApplicationInfo.Name = "tabApplicationInfo";
            this.tabApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabApplicationInfo.Size = new System.Drawing.Size(836, 428);
            this.tabApplicationInfo.TabIndex = 1;
            this.tabApplicationInfo.Text = "Application Info";
            this.tabApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(48, 284);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 20);
            this.label8.TabIndex = 110;
            this.label8.Text = "Created By:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(48, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 20);
            this.label7.TabIndex = 109;
            this.label7.Text = "Application Fees:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(48, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 20);
            this.label6.TabIndex = 108;
            this.label6.Text = "License Class:";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(236, 284);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(49, 20);
            this.lblCreatedBy.TabIndex = 107;
            this.lblCreatedBy.Text = "????";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(236, 225);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(49, 20);
            this.lblApplicationFees.TabIndex = 106;
            this.lblApplicationFees.Text = "????";
            // 
            // cbxLicenseClass
            // 
            this.cbxLicenseClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLicenseClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxLicenseClass.FormattingEnabled = true;
            this.cbxLicenseClass.Location = new System.Drawing.Point(240, 168);
            this.cbxLicenseClass.Name = "cbxLicenseClass";
            this.cbxLicenseClass.Size = new System.Drawing.Size(239, 26);
            this.cbxLicenseClass.TabIndex = 105;
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Location = new System.Drawing.Point(236, 110);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(49, 20);
            this.lblApplicationDate.TabIndex = 104;
            this.lblApplicationDate.Text = "????";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 20);
            this.label2.TabIndex = 103;
            this.label2.Text = "Application Date:";
            // 
            // lblDrivingLicenseApplicationID
            // 
            this.lblDrivingLicenseApplicationID.AutoSize = true;
            this.lblDrivingLicenseApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrivingLicenseApplicationID.Location = new System.Drawing.Point(236, 54);
            this.lblDrivingLicenseApplicationID.Name = "lblDrivingLicenseApplicationID";
            this.lblDrivingLicenseApplicationID.Size = new System.Drawing.Size(49, 20);
            this.lblDrivingLicenseApplicationID.TabIndex = 102;
            this.lblDrivingLicenseApplicationID.Text = "????";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 20);
            this.label1.TabIndex = 100;
            this.label1.Text = "D.L.Application ID:";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(595, 370);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(110, 40);
            this.btnBack.TabIndex = 99;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblAddUpdateLocalDrivingLicenseApplication
            // 
            this.lblAddUpdateLocalDrivingLicenseApplication.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddUpdateLocalDrivingLicenseApplication.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAddUpdateLocalDrivingLicenseApplication.Location = new System.Drawing.Point(91, 22);
            this.lblAddUpdateLocalDrivingLicenseApplication.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddUpdateLocalDrivingLicenseApplication.Name = "lblAddUpdateLocalDrivingLicenseApplication";
            this.lblAddUpdateLocalDrivingLicenseApplication.Size = new System.Drawing.Size(710, 42);
            this.lblAddUpdateLocalDrivingLicenseApplication.TabIndex = 6;
            this.lblAddUpdateLocalDrivingLicenseApplication.Text = "New Local Driving License Application";
            this.lblAddUpdateLocalDrivingLicenseApplication.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(733, 554);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 40);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(605, 555);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 40);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAddUpdateLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 600);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblAddUpdateLocalDrivingLicenseApplication);
            this.Controls.Add(this.tcDrivingLicenseApplicationInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAddUpdateLocalDrivingLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Local Driving License Application";
            this.Load += new System.EventHandler(this.frmAddUpdateLocalDrivingLicenseApplication_Load);
            this.tcDrivingLicenseApplicationInfo.ResumeLayout(false);
            this.tabPersonInfo.ResumeLayout(false);
            this.tabApplicationInfo.ResumeLayout(false);
            this.tabApplicationInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcDrivingLicenseApplicationInfo;
        private System.Windows.Forms.TabPage tabPersonInfo;
        private ctrlPersonInfoWithFilter ctrlPersonInfoWithFilter1;
        private System.Windows.Forms.TabPage tabApplicationInfo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblAddUpdateLocalDrivingLicenseApplication;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDrivingLicenseApplicationID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.ComboBox cbxLicenseClass;
        private System.Windows.Forms.Label lblApplicationDate;
    }
}