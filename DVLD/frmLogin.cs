using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmLogin : Form
    {
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            _LoadSavedUser();
        }

        private void _LoadSavedUser()
        {
            clsUserSetting SavedUser = clsUserSetting.Find("Saved User");

            if (SavedUser.User != null)
            {
                txtUsername.Text = SavedUser.User.Username;
                txtPassword.Text = SavedUser.User.Password;
                ckbRememberMe.Checked = true;
            }
        }

        private bool _CheckLoginProccess(clsUser CurrentUser, clsLoginRecord LoginRecord, ref string errorMessage)
        {
            bool CanPass = false;

            if (CurrentUser != null)
            {
                LoginRecord.User = CurrentUser;

                if (txtPassword.Text == CurrentUser.Password)
                {
                    if (CurrentUser.IsActive == true)
                    {
                        LoginRecord.LoginStatus = true;

                        CanPass = true;
                    }
                    else
                    {
                        LoginRecord.LoginStatus = false;
                        LoginRecord.FailureReason = clsUtility.errorLoginNotActiveUser;
                        
                        errorMessage = clsUtility.errorLoginNotActiveUser;

                        CanPass = false;
                    }
                }
                else
                {
                    LoginRecord.LoginStatus = false;
                    LoginRecord.FailureReason = clsUtility.errorLoginWrongPassword;

                    errorMessage = clsUtility.errorLoginWrongPassword;

                    CanPass = false;
                }
                LoginRecord.Save();
                
            }
            else
            {
                errorMessage = clsUtility.errorLoginUsernameNotFound;

                CanPass = false;
            }

            return CanPass;
        }

        private void _EnterMainScreen()
        {
            frmMain frm = new frmMain();
            frm.ShowDialog();
        }

        private bool _RegisterCurrentUser(clsUser User, ref string errorMessage)
        {
            clsUserSetting CurrentUser = clsUserSetting.Find("Current User");
            CurrentUser.User = User;
            CurrentUser.Permissions = User.Role.Permissions;

            if (CurrentUser.Save())
            {
                return true;
            }
            else
            {
                errorMessage = clsUtility.errorLoginRegisterCurrentUser;
                return false;
            }

        }

        private void _SetSavedUser(clsUser user)
        {
            clsUserSetting SavedUser = clsUserSetting.Find("Saved User");

            if (ckbRememberMe.Checked)
            {
                SavedUser.User = user;
            }
            else
            {
                SavedUser.User = null;
            }

            // Update the saved user
            SavedUser.Save();
        }

        private void _Login()
        {
            clsUser CurrentUser = clsUser.Find(txtUsername.Text);
            clsLoginRecord LoginRecord = new clsLoginRecord();
            string errorMessage = string.Empty;

            if (_CheckLoginProccess(CurrentUser, LoginRecord, ref errorMessage))
            {
                if (_RegisterCurrentUser(CurrentUser, ref errorMessage))
                {
                    _SetSavedUser(CurrentUser);
                    _EnterMainScreen();
                }
                else
                {
                    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _Login();
        }

        private void pbShowHidePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == true)
            {
                pbShowHidePassword.Image = Properties.Resources.hide;
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                pbShowHidePassword.Image = Properties.Resources.show;
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
