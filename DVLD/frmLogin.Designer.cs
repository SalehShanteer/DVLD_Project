namespace DVLD
{
    partial class frmLogin
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
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbShowHidePassword = new System.Windows.Forms.PictureBox();
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.ckbRememberMe = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbShowHidePassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Location = new System.Drawing.Point(210, 178);
            this.txtUsername.MaxLength = 30;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(180, 19);
            this.txtUsername.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Location = new System.Drawing.Point(210, 240);
            this.txtPassword.MaxLength = 320;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(180, 19);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 101;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(79, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 102;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(170, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 42);
            this.label3.TabIndex = 103;
            this.label3.Text = "Login";
            // 
            // pbShowHidePassword
            // 
            this.pbShowHidePassword.Image = global::DVLD.Properties.Resources.hide;
            this.pbShowHidePassword.Location = new System.Drawing.Point(409, 240);
            this.pbShowHidePassword.Name = "pbShowHidePassword";
            this.pbShowHidePassword.Size = new System.Drawing.Size(29, 21);
            this.pbShowHidePassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbShowHidePassword.TabIndex = 104;
            this.pbShowHidePassword.TabStop = false;
            this.pbShowHidePassword.Click += new System.EventHandler(this.pbShowHidePassword_Click);
            // 
            // pbExit
            // 
            this.pbExit.Image = global::DVLD.Properties.Resources.ExitButton;
            this.pbExit.Location = new System.Drawing.Point(424, 25);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(36, 35);
            this.pbExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbExit.TabIndex = 0;
            this.pbExit.TabStop = false;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(222, 334);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(133, 29);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // ckbRememberMe
            // 
            this.ckbRememberMe.AutoSize = true;
            this.ckbRememberMe.Checked = true;
            this.ckbRememberMe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbRememberMe.Location = new System.Drawing.Point(210, 281);
            this.ckbRememberMe.Name = "ckbRememberMe";
            this.ckbRememberMe.Size = new System.Drawing.Size(133, 24);
            this.ckbRememberMe.TabIndex = 106;
            this.ckbRememberMe.Text = "Remember me";
            this.ckbRememberMe.UseVisualStyleBackColor = true;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(496, 386);
            this.Controls.Add(this.ckbRememberMe);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.pbShowHidePassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.pbExit);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbShowHidePassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbShowHidePassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox ckbRememberMe;
    }
}