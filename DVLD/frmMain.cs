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
    public partial class frmMain : Form
    {
             
        public frmMain()
        {
            InitializeComponent();
        }


        private void _ShowManagePeopleScreen()
        {
            frmManagePeople frm = new frmManagePeople();
            frm.ShowDialog();
        }

        private void _ShowManageDriversScreen()
        {
            frmManageDrivers frm = new frmManageDrivers();
            frm.ShowDialog();
        }

        private void _ShowManageUsersScreen()
        {
            frmManageUsers frm = new frmManageUsers();
            frm.ShowDialog();
        }

        private void _ShowManageTestTypesScreen()
        {
            frmManageTestTypes frm = new frmManageTestTypes();
            frm.ShowDialog();
        }

        private void _ShowManageApplicationTypesScreen()
        {
            frmManageApplicationTypes frm = new frmManageApplicationTypes();
            frm.ShowDialog();
        }

        private void _ShowAddNewLocalLicenseApplication()
        {
            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication(-1);
            frm.ShowDialog();
        }

        private void _Logout()
        {
            this.Close();
        }

        private void peopleStripDropDownButton_Click(object sender, EventArgs e)
        {
            _ShowManagePeopleScreen();
        }

        private void driversStripDropDownButton_Click(object sender, EventArgs e)
        {
            _ShowManageDriversScreen();
        }

        private void usersStripDropDownButton_Click(object sender, EventArgs e)
        {
            _ShowManageUsersScreen();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _Logout();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowManageTestTypesScreen();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowManageApplicationTypesScreen();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowAddNewLocalLicenseApplication();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            clsUserSetting CurrentUser = clsUserSetting.Find("Current User");

            // Clear the current user
            CurrentUser.User = null;
            CurrentUser.Permissions = 0;
            CurrentUser.Save();
        }
    }
}
