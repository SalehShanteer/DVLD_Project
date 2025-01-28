namespace DVLD
{
    partial class frmAddUpdateUser
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
            this.tcUserInfo = new System.Windows.Forms.TabControl();
            this.tabPersonInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrlPersonInfoWithFilter1 = new DVLD.ctrlPersonInfoWithFilter();
            this.tabAccountSettings = new System.Windows.Forms.TabPage();
            this.pbShowHideConfirmPassword = new System.Windows.Forms.PictureBox();
            this.pbShowHidePassword = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.ckbIsActive = new System.Windows.Forms.CheckBox();
            this.lblRoleDescription = new System.Windows.Forms.Label();
            this.cbxRoles = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblAddUpdateUser = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tcUserInfo.SuspendLayout();
            this.tabPersonInfo.SuspendLayout();
            this.tabAccountSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowHideConfirmPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowHidePassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tcUserInfo
            // 
            this.tcUserInfo.Controls.Add(this.tabPersonInfo);
            this.tcUserInfo.Controls.Add(this.tabAccountSettings);
            this.tcUserInfo.Location = new System.Drawing.Point(13, 84);
            this.tcUserInfo.Name = "tcUserInfo";
            this.tcUserInfo.SelectedIndex = 0;
            this.tcUserInfo.Size = new System.Drawing.Size(867, 446);
            this.tcUserInfo.TabIndex = 0;
            // 
            // tabPersonInfo
            // 
            this.tabPersonInfo.Controls.Add(this.btnNext);
            this.tabPersonInfo.Controls.Add(this.ctrlPersonInfoWithFilter1);
            this.tabPersonInfo.Location = new System.Drawing.Point(4, 29);
            this.tabPersonInfo.Name = "tabPersonInfo";
            this.tabPersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPersonInfo.Size = new System.Drawing.Size(859, 413);
            this.tabPersonInfo.TabIndex = 0;
            this.tabPersonInfo.Text = "Person Info";
            this.tabPersonInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(708, 369);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(110, 40);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrlPersonInfoWithFilter1
            // 
            this.ctrlPersonInfoWithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlPersonInfoWithFilter1.Location = new System.Drawing.Point(7, 8);
            this.ctrlPersonInfoWithFilter1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlPersonInfoWithFilter1.Name = "ctrlPersonInfoWithFilter1";
            this.ctrlPersonInfoWithFilter1.Size = new System.Drawing.Size(831, 364);
            this.ctrlPersonInfoWithFilter1.TabIndex = 0;
            this.ctrlPersonInfoWithFilter1.OnFindPersonComplete += new System.Action<int>(this.ctrlPersonInfoWithFilter1_OnFindPersonComplete);
            // 
            // tabAccountSettings
            // 
            this.tabAccountSettings.Controls.Add(this.pbShowHideConfirmPassword);
            this.tabAccountSettings.Controls.Add(this.pbShowHidePassword);
            this.tabAccountSettings.Controls.Add(this.btnBack);
            this.tabAccountSettings.Controls.Add(this.ckbIsActive);
            this.tabAccountSettings.Controls.Add(this.lblRoleDescription);
            this.tabAccountSettings.Controls.Add(this.cbxRoles);
            this.tabAccountSettings.Controls.Add(this.label5);
            this.tabAccountSettings.Controls.Add(this.txtPassword);
            this.tabAccountSettings.Controls.Add(this.txtConfirmPassword);
            this.tabAccountSettings.Controls.Add(this.txtUsername);
            this.tabAccountSettings.Controls.Add(this.lblUserID);
            this.tabAccountSettings.Controls.Add(this.label4);
            this.tabAccountSettings.Controls.Add(this.label3);
            this.tabAccountSettings.Controls.Add(this.label1);
            this.tabAccountSettings.Controls.Add(this.label2);
            this.tabAccountSettings.Location = new System.Drawing.Point(4, 29);
            this.tabAccountSettings.Name = "tabAccountSettings";
            this.tabAccountSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabAccountSettings.Size = new System.Drawing.Size(859, 413);
            this.tabAccountSettings.TabIndex = 1;
            this.tabAccountSettings.Text = "Account Settings";
            this.tabAccountSettings.UseVisualStyleBackColor = true;
            // 
            // pbShowHideConfirmPassword
            // 
            this.pbShowHideConfirmPassword.Image = global::DVLD.Properties.Resources.hide;
            this.pbShowHideConfirmPassword.Location = new System.Drawing.Point(428, 215);
            this.pbShowHideConfirmPassword.Name = "pbShowHideConfirmPassword";
            this.pbShowHideConfirmPassword.Size = new System.Drawing.Size(29, 21);
            this.pbShowHideConfirmPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbShowHideConfirmPassword.TabIndex = 106;
            this.pbShowHideConfirmPassword.TabStop = false;
            this.pbShowHideConfirmPassword.Click += new System.EventHandler(this.pbShowHideConfirmPassword_Click);
            // 
            // pbShowHidePassword
            // 
            this.pbShowHidePassword.Image = global::DVLD.Properties.Resources.hide;
            this.pbShowHidePassword.Location = new System.Drawing.Point(428, 159);
            this.pbShowHidePassword.Name = "pbShowHidePassword";
            this.pbShowHidePassword.Size = new System.Drawing.Size(29, 21);
            this.pbShowHidePassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbShowHidePassword.TabIndex = 105;
            this.pbShowHidePassword.TabStop = false;
            this.pbShowHidePassword.Click += new System.EventHandler(this.pbShowHidePassword_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(578, 369);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(110, 40);
            this.btnBack.TabIndex = 98;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // ckbIsActive
            // 
            this.ckbIsActive.AutoSize = true;
            this.ckbIsActive.Checked = true;
            this.ckbIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbIsActive.Location = new System.Drawing.Point(251, 332);
            this.ckbIsActive.Name = "ckbIsActive";
            this.ckbIsActive.Size = new System.Drawing.Size(88, 24);
            this.ckbIsActive.TabIndex = 97;
            this.ckbIsActive.Text = "Is Active";
            this.ckbIsActive.UseVisualStyleBackColor = true;
            // 
            // lblRoleDescription
            // 
            this.lblRoleDescription.AutoSize = true;
            this.lblRoleDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRoleDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoleDescription.Location = new System.Drawing.Point(428, 274);
            this.lblRoleDescription.MaximumSize = new System.Drawing.Size(400, 100);
            this.lblRoleDescription.Name = "lblRoleDescription";
            this.lblRoleDescription.Size = new System.Drawing.Size(71, 17);
            this.lblRoleDescription.TabIndex = 96;
            this.lblRoleDescription.Text = "Description";
            // 
            // cbxRoles
            // 
            this.cbxRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRoles.FormattingEnabled = true;
            this.cbxRoles.Location = new System.Drawing.Point(249, 271);
            this.cbxRoles.Name = "cbxRoles";
            this.cbxRoles.Size = new System.Drawing.Size(163, 28);
            this.cbxRoles.TabIndex = 95;
            this.cbxRoles.SelectedIndexChanged += new System.EventHandler(this.cbxRoles_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(61, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 94;
            this.label5.Text = "Role:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(249, 154);
            this.txtPassword.MaxLength = 320;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(163, 26);
            this.txtPassword.TabIndex = 93;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(249, 211);
            this.txtConfirmPassword.MaxLength = 320;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(163, 26);
            this.txtConfirmPassword.TabIndex = 92;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(249, 98);
            this.txtUsername.MaxLength = 50;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(163, 26);
            this.txtUsername.TabIndex = 91;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.Location = new System.Drawing.Point(245, 52);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(49, 20);
            this.lblUserID.TabIndex = 90;
            this.lblUserID.Text = "????";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(61, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 20);
            this.label4.TabIndex = 89;
            this.label4.Text = "Confirm Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(61, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 88;
            this.label3.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 87;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 86;
            this.label2.Text = "User ID:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(604, 532);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 39);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(732, 531);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 39);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblAddUpdateUser
            // 
            this.lblAddUpdateUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddUpdateUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAddUpdateUser.Location = new System.Drawing.Point(4, 28);
            this.lblAddUpdateUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddUpdateUser.Name = "lblAddUpdateUser";
            this.lblAddUpdateUser.Size = new System.Drawing.Size(895, 42);
            this.lblAddUpdateUser.TabIndex = 5;
            this.lblAddUpdateUser.Text = "Add New User";
            this.lblAddUpdateUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(891, 574);
            this.Controls.Add(this.lblAddUpdateUser);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tcUserInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAddUpdateUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New User";
            this.Load += new System.EventHandler(this.frmAddUpdateUser_Load);
            this.tcUserInfo.ResumeLayout(false);
            this.tabPersonInfo.ResumeLayout(false);
            this.tabAccountSettings.ResumeLayout(false);
            this.tabAccountSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowHideConfirmPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowHidePassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcUserInfo;
        private System.Windows.Forms.TabPage tabPersonInfo;
        private ctrlPersonInfoWithFilter ctrlPersonInfoWithFilter1;
        private System.Windows.Forms.TabPage tabAccountSettings;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblAddUpdateUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.ComboBox cbxRoles;
        private System.Windows.Forms.Label lblRoleDescription;
        private System.Windows.Forms.CheckBox ckbIsActive;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pbShowHideConfirmPassword;
        private System.Windows.Forms.PictureBox pbShowHidePassword;
    }
}