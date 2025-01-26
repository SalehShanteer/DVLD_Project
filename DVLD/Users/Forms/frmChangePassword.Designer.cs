namespace DVLD
{
    partial class frmChangePassword
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
            this.txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.ctrlUserInfo1 = new DVLD.ctrlUserInfo();
            this.pbShowHideConfirmPassword = new System.Windows.Forms.PictureBox();
            this.pbShowHideNewPassword = new System.Windows.Forms.PictureBox();
            this.pbShowHideCurrentPassword = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowHideConfirmPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowHideNewPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowHideCurrentPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCurrentPassword
            // 
            this.txtCurrentPassword.Location = new System.Drawing.Point(236, 411);
            this.txtCurrentPassword.MaxLength = 320;
            this.txtCurrentPassword.Name = "txtCurrentPassword";
            this.txtCurrentPassword.Size = new System.Drawing.Size(163, 26);
            this.txtCurrentPassword.TabIndex = 97;
            this.txtCurrentPassword.UseSystemPasswordChar = true;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(236, 454);
            this.txtNewPassword.MaxLength = 320;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(163, 26);
            this.txtNewPassword.TabIndex = 96;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(48, 457);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 20);
            this.label4.TabIndex = 95;
            this.label4.Text = "New Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(48, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 20);
            this.label3.TabIndex = 94;
            this.label3.Text = "Current Password:";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(236, 496);
            this.txtConfirmPassword.MaxLength = 320;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(163, 26);
            this.txtConfirmPassword.TabIndex = 99;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 499);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 20);
            this.label1.TabIndex = 98;
            this.label1.Text = "Confirm Password:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(566, 541);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(109, 38);
            this.btnClose.TabIndex = 101;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(713, 541);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(109, 38);
            this.btnSave.TabIndex = 100;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ctrlUserInfo1
            // 
            this.ctrlUserInfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlUserInfo1.Location = new System.Drawing.Point(13, 9);
            this.ctrlUserInfo1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ctrlUserInfo1.Name = "ctrlUserInfo1";
            this.ctrlUserInfo1.Size = new System.Drawing.Size(824, 392);
            this.ctrlUserInfo1.TabIndex = 0;
            // 
            // pbShowHideConfirmPassword
            // 
            this.pbShowHideConfirmPassword.Image = global::DVLD.Properties.Resources.hide;
            this.pbShowHideConfirmPassword.Location = new System.Drawing.Point(435, 500);
            this.pbShowHideConfirmPassword.Name = "pbShowHideConfirmPassword";
            this.pbShowHideConfirmPassword.Size = new System.Drawing.Size(29, 21);
            this.pbShowHideConfirmPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbShowHideConfirmPassword.TabIndex = 107;
            this.pbShowHideConfirmPassword.TabStop = false;
            this.pbShowHideConfirmPassword.Click += new System.EventHandler(this.pbShowHideConfirmPassword_Click);
            // 
            // pbShowHideNewPassword
            // 
            this.pbShowHideNewPassword.Image = global::DVLD.Properties.Resources.hide;
            this.pbShowHideNewPassword.Location = new System.Drawing.Point(435, 459);
            this.pbShowHideNewPassword.Name = "pbShowHideNewPassword";
            this.pbShowHideNewPassword.Size = new System.Drawing.Size(29, 21);
            this.pbShowHideNewPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbShowHideNewPassword.TabIndex = 108;
            this.pbShowHideNewPassword.TabStop = false;
            this.pbShowHideNewPassword.Click += new System.EventHandler(this.pbShowHideNewPassword_Click);
            // 
            // pbShowHideCurrentPassword
            // 
            this.pbShowHideCurrentPassword.Image = global::DVLD.Properties.Resources.hide;
            this.pbShowHideCurrentPassword.Location = new System.Drawing.Point(435, 414);
            this.pbShowHideCurrentPassword.Name = "pbShowHideCurrentPassword";
            this.pbShowHideCurrentPassword.Size = new System.Drawing.Size(29, 21);
            this.pbShowHideCurrentPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbShowHideCurrentPassword.TabIndex = 109;
            this.pbShowHideCurrentPassword.TabStop = false;
            this.pbShowHideCurrentPassword.Click += new System.EventHandler(this.pbShowHideCurrentPassword_Click);
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 602);
            this.Controls.Add(this.pbShowHideCurrentPassword);
            this.Controls.Add(this.pbShowHideNewPassword);
            this.Controls.Add(this.pbShowHideConfirmPassword);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCurrentPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ctrlUserInfo1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowHideConfirmPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowHideNewPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowHideCurrentPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlUserInfo ctrlUserInfo1;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox pbShowHideCurrentPassword;
        private System.Windows.Forms.PictureBox pbShowHideNewPassword;
        private System.Windows.Forms.PictureBox pbShowHideConfirmPassword;
    }
}