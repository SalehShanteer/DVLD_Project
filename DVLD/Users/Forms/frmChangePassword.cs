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
    public partial class frmChangePassword : Form
    {

        private int _UserID;

        private clsUser _User;

        public frmChangePassword(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _LoadUserInfo();
        }

        private bool _CheckIfCurrentPasswordCorrect()
        {
            return txtCurrentPassword.Text == _User.Password;
        }

        private void _SaveUserNewPassword()
        {
            // Save user new password
            _User.Password = txtNewPassword.Text;

            if (_User.Save())
            {
                MessageBox.Show("User password saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(clsUtility.errorSaveMessage, clsUtility.errorSaveTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool _ValidateRequiredField(TextBox ctrl, string name)
        {
            if (string.IsNullOrWhiteSpace(ctrl.Text))
            {
                errorProvider1.SetError(ctrl, $"Please enter the {name}");
                return false;
            }
            else
            {
                errorProvider1.SetError(ctrl, string.Empty);
                return true;
            }
        }

        private bool _IsValidData()
        {
            bool isValid = true;

            if (!_ValidateRequiredField(txtCurrentPassword, "Current Password"))
            {
                isValid = false;
            }
            else if (!clsUtility.ValidatePassword(txtCurrentPassword.Text))
            {
                errorProvider1.SetError(txtCurrentPassword, "Password must be at least 8 characters, digit, upper case, lower case and special character");
                isValid = false;
            }
            else if (!_CheckIfCurrentPasswordCorrect())
            {
                errorProvider1.SetError(txtCurrentPassword, "Current password is not match with user password");
                isValid = false;
            }

            if (!_ValidateRequiredField(txtNewPassword, "Password"))
            {
                isValid = false;
            }
            else if (!clsUtility.ValidatePassword(txtNewPassword.Text))
            {
                errorProvider1.SetError(txtNewPassword, "Password must be at least 8 characters, digit, upper case, lower case and special character");
                isValid = false;
            }

            if (!_ValidateRequiredField(txtConfirmPassword, "Confirm Password"))
            {
                isValid = false;
            }
            else if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "Password does not match");
                isValid = false;
            }

            return isValid;
        }

        private void _LoadUserInfo()
        {
            _User = clsUser.Find(_UserID);

            if (_User != null)
            {
                ctrlUserInfo1.DisplayUserInfoOutside(_UserID);
            }
            else
            {
                MessageBox.Show(clsUtility.errorOpenFormMessag("user details"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_IsValidData())
            {
                _SaveUserNewPassword();
            }
            else
            {
                MessageBox.Show(clsUtility.errorProviderMessage, clsUtility.errorSaveTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void _ShowHidePassword(TextBox textBox, PictureBox pictureBoxShowHide)
        {
            if (textBox.UseSystemPasswordChar == true)
            {
                // Show password in plain text
                pictureBoxShowHide.Image = Properties.Resources.show;
                textBox.UseSystemPasswordChar = false;
            }
            else
            {
                // Hide password in plain text
                pictureBoxShowHide.Image = Properties.Resources.hide;
                textBox.UseSystemPasswordChar = true;
            }
        }

        private void pbShowHideCurrentPassword_Click(object sender, EventArgs e)
        {
            _ShowHidePassword(txtCurrentPassword, pbShowHideCurrentPassword);
        }

        private void pbShowHideNewPassword_Click(object sender, EventArgs e)
        {
            _ShowHidePassword(txtNewPassword, pbShowHideNewPassword);
        }

        private void pbShowHideConfirmPassword_Click(object sender, EventArgs e)
        {
            _ShowHidePassword(txtConfirmPassword, pbShowHideConfirmPassword);
        }
    }
}
