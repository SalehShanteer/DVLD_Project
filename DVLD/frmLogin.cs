using DVLD_Business;
using System;
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
            _RetrieveSavedUser();
        }

        private void _RetrieveSavedUser()
        {
        
            if (clsUtility.ReadFromRegistry("SavedUsername") != string.Empty)
            {
                string SavedUsername = clsUtility.ReadFromRegistry("SavedUsername");
                string SavedPassword = clsUtility.ReadFromRegistry("SavedPassword");

                txtUsername.Text = SavedUsername;
                txtPassword.Text = clsUtility.Decrypt(SavedPassword);
            }
        }

        private bool _CheckLoginProccess(clsUser CurrentUser, clsLoginRecord LoginRecord, ref string errorMessage)
        {
            bool CanPass = false;

            if (CurrentUser != null)
            {
                LoginRecord.User = CurrentUser;

                // Check if the password is correct
                if (txtPassword.Text == CurrentUser.Password)
                {
                    if (CurrentUser.IsActive == true)
                    {
                        // User is active
                        LoginRecord.LoginStatus = true;

                        CanPass = true;
                    }
                    else
                    {
                        // User is not active
                        LoginRecord.LoginStatus = false;
                        LoginRecord.FailureReason = clsUtility.errorLoginNotActiveUser;
                        
                        errorMessage = clsUtility.errorLoginNotActiveUser;

                        CanPass = false;
                    }
                }
                else
                {
                    // Wrong password
                    LoginRecord.LoginStatus = false;
                    LoginRecord.FailureReason = clsUtility.errorLoginWrongPassword;

                    errorMessage = clsUtility.errorLoginWrongPassword;

                    CanPass = false;
                }
                LoginRecord.Save();
                
            }
            else
            {
                // Username not found
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

        private void _SaveUserToRegistry(clsUser user)
        {
            string ValueName1 = "SavedUsername";
            string ValueData1 = user.Username;

            string ValueName2 = "SavedPassword";
            string ValueData2 = clsUtility.Encrypt(user.Password);

            // Save the user to the registry
            clsUtility.WriteToRegistry(ValueName1, ValueData1);
            clsUtility.WriteToRegistry(ValueName2, ValueData2);
        }

        private void _SetSavedUser(clsUser user)
        {
            if (ckbRememberMe.Checked)
            {
                _SaveUserToRegistry(user);
            }          
        }

        private void _Login()
        {
            clsUser CurrentUser = clsUser.Find(txtUsername.Text);
            clsLoginRecord LoginRecord = new clsLoginRecord();
            string errorMessage = string.Empty;

            // Check the login process
            if (_CheckLoginProccess(CurrentUser, LoginRecord, ref errorMessage))
            {
                // Register the current user
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
                // Show password in plain text
                pbShowHidePassword.Image = Properties.Resources.hide;
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                // Hide password in plain text
                pbShowHidePassword.Image = Properties.Resources.show;
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
