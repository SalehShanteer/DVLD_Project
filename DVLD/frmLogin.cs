using DVLD_Business;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
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
            _RetrieveSavedUser();
        }

        private void _RetrieveSavedUser()
        {
        
            if (clsUtility.ReadFromRegistry("SavedUsername") != string.Empty)
            {
                // Making task to retrieve username and password from registry 
                var SavedUsernameTask = Task.Run (() => clsUtility.ReadFromRegistry("SavedUsername"));
                var SavedPasswordTask = Task.Run (() => clsUtility.ReadFromRegistry("SavedPassword"));

                Task.WaitAll(SavedPasswordTask, SavedPasswordTask);

                string SavedUsername = SavedUsernameTask.Result.ToString();
                string SavedPassword = SavedPasswordTask.Result.ToString();

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

        private async Task _SaveUserToRegistryAsync(clsUser user)
        {
            string SavedUsernameName = "SavedUsername";
            string SavedUsernameData = user.Username;

            string SavedPasswordName = "SavedPassword";
            string SavedPasswordData = clsUtility.Encrypt(user.Password);

            // Save the user to the registry
            Task SaveUsernameTask = Task.Run (() => clsUtility.WriteToRegistry(SavedUsernameName, SavedUsernameData));
            Task SavePasswordTask = Task.Run (() => clsUtility.WriteToRegistry(SavedPasswordName, SavedPasswordData));

            await Task.WhenAll(SaveUsernameTask, SavePasswordTask);
        }

        private async Task _SetSavedUserAsync(clsUser user)
        {
            if (ckbRememberMe.Checked)
            {
                await _SaveUserToRegistryAsync(user);
            }          
        }

        private async Task _LoginAsync()
        {

            clsUser CurrentUser = null;
            clsLoginRecord LoginRecord = null;

            // Retrieve current user and prepare login record concurrently
            Task GetCurrentUserTask = Task.Run(() => CurrentUser = clsUser.Find(txtUsername.Text));
            Task PrepareLoginRecord = Task.Run(() => LoginRecord = new clsLoginRecord());

            Task.WaitAll(GetCurrentUserTask, PrepareLoginRecord);

            string errorMessage = string.Empty;

            // Check the login process
            if (_CheckLoginProccess(CurrentUser, LoginRecord, ref errorMessage))
            {
                // Register the current user
                if (_RegisterCurrentUser(CurrentUser, ref errorMessage))
                {
                    await _SetSavedUserAsync(CurrentUser);
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

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            await _LoginAsync();
        }

        private void pbShowHidePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == true)
            {
                // Show password in plain text
                pbShowHidePassword.Image = Properties.Resources.show;
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                // Hide password in plain text
                pbShowHidePassword.Image = Properties.Resources.hide;
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
