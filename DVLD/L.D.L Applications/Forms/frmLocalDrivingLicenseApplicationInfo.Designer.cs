﻿namespace DVLD
{
    partial class frmLocalDrivingLicenseApplicationInfo
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
            this.ctrlLocalDrivingLicenseApplicationInfo1 = new DVLD.ctrlLocalDrivingLicenseApplicationInfo();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlLocalDrivingLicenseApplicationInfo1
            // 
            this.ctrlLocalDrivingLicenseApplicationInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlLocalDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(2, 4);
            this.ctrlLocalDrivingLicenseApplicationInfo1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlLocalDrivingLicenseApplicationInfo1.Name = "ctrlLocalDrivingLicenseApplicationInfo1";
            this.ctrlLocalDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(738, 364);
            this.ctrlLocalDrivingLicenseApplicationInfo1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(622, 368);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 31);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmLocalDrivingLicenseApplicationInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(744, 406);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctrlLocalDrivingLicenseApplicationInfo1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmLocalDrivingLicenseApplicationInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Local Driving License Application Info";
            this.Load += new System.EventHandler(this.frmLocalDrivingLicenseApplicationInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlLocalDrivingLicenseApplicationInfo ctrlLocalDrivingLicenseApplicationInfo1;
        private System.Windows.Forms.Button btnClose;
    }
}