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
    public partial class ctrlUserInfo : UserControl
    {

        private int _UserID;

        private clsUser _User;

        public ctrlUserInfo()
        {
            InitializeComponent();
        }

        public void DisplayUserInfoOutside(int UserID)
        {
            _UserID = UserID;

            _LoadUserInfo();
        }

        private void _DisplayPersonInfo()
        {
            ctrlPersonInfo1.DisplayPersonInfoOutside(_User.Person.ID);
        }

        private void _DisplayUserAccountInfo()
        {
            lblUserID.Text = _User.ID.ToString();
            lblUsername.Text = _User.Username;
            lblRole.Text = _User.Role.Title;
            lblIsActive.Text = _User.IsActive ? "Yes" : "No";
        }

        private void _LoadUserInfo()
        {
            _User = clsUser.Find(_UserID);

            if (_User != null)
            {
                _DisplayPersonInfo();
                _DisplayUserAccountInfo();
            }
            else
            {
                MessageBox.Show("Error: User details not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
