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
            if (_CheckIfCurrentPasswordCorrect())
            {
                _User.Password = txtNewPassword.Text;

                if (_User.Save())
                {
                    MessageBox.Show("User password saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("The inserted Current password is wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            _SaveUserNewPassword();
        }
    }
}
