﻿using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

        private void frmMain_Load(object sender, EventArgs e)
        {

            Thread LicensesRefreshThread = new Thread(() =>
            {                

                if (clsLicense.RefreshAllLicensesToCheckActivation())
                {
#if DEBUG
                    MessageBox.Show("Some licenses got inactive!", "Attention");
#endif

                }
                
            });

            LicensesRefreshThread.Start();
        }

        private void _ShowManagePeopleScreen()
        {
            if (!clsSettings.CheckPermission((int)clsSettings.enPeoplePermissions.Read))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            frmManagePeople frm = new frmManagePeople();
            frm.ShowDialog();
        }

        private void _ShowManageDriversScreen()
        {
            if (!clsSettings.CheckPermission((int)clsSettings.enDriverPermissions.Read))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            frmManageDrivers frm = new frmManageDrivers();
            frm.ShowDialog();
        }

        private void _ShowManageUsersScreen()
        {
            if (!clsSettings.CheckPermission((int)clsSettings.enUserPermissions.Read))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            frmManageUsers frm = new frmManageUsers();
            frm.ShowDialog();
        }

        private void _ShowManageTestTypesScreen()
        {
            if (!clsSettings.CheckPermission((int)clsSettings.enTestPermissions.Read))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            frmManageTestTypes frm = new frmManageTestTypes();
            frm.ShowDialog();
        }

        private void _ShowManageApplicationTypesScreen()
        {
            if (!clsSettings.CheckPermission((int)clsSettings.enLocalLicenseApplicationPermissions.Read))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            frmManageApplicationTypes frm = new frmManageApplicationTypes();
            frm.ShowDialog();
        }

        private void _ShowAddNewLocalDrivingLicenseApplicationScreen()
        {
            if (!clsSettings.CheckPermission((int)clsSettings.enLocalLicenseApplicationPermissions.AddUpdate))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication(-1);
            frm.ShowDialog();
        }

        private void _ShowManageLocalDrivingLicenseApplicationsScreen()
        {
            if (!clsSettings.CheckPermission((int)clsSettings.enLocalLicenseApplicationPermissions.Read))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            frmManageLocalDrivingLicenseApplications frm = new frmManageLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void _ShowCurrentUserInfo()
        {
            int CurrentUserID = clsUserSetting.GetCurrentUserID();

            frmUserInfo frm = new frmUserInfo(CurrentUserID);
            frm.ShowDialog();
        }
        
        private void _ShowChangePasswordScreen()
        {
            int CurrentUserID = clsUserSetting.GetCurrentUserID();

            frmChangePassword frm = new frmChangePassword(CurrentUserID);
            frm.ShowDialog();
        }

        private void _Logout()
        {
            this.Close();
        }

        private void _ShowLoginRecordsScreen()
        {
            if (!clsSettings.CheckPermission((int)clsSettings.enUserPermissions.Read))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            frmLoginRecordsList frm = new frmLoginRecordsList();
            frm.ShowDialog();
        }

        private void _ShowAddNewInternationalLicenseApplicationScreen()
        {
            if (!clsSettings.CheckPermission((int)clsSettings.enLicensePermissions.IssueInternational))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void _ShowInternationalLicenseApplicationsScreen()
        {
            if (!clsSettings.CheckPermission((int)clsSettings.enLicensePermissions.ReadInternational))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            frmInternationalLicenseApplications frm = new frmInternationalLicenseApplications();
            frm.ShowDialog();
        }

        private void _ShowRenewLocalLicenseApplicationScreen()
        {
            if (!clsSettings.CheckPermission((int)clsSettings.enLicenseOperationPermissions.Renew))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            frmRenewLocalDrivingLicense frm = new frmRenewLocalDrivingLicense();
            frm.ShowDialog();
        }

        private void _ShowReplacementForLostOrDamagedLicenseScreen()
        {
            if (!clsSettings.CheckPermission((int)clsSettings.enLicenseOperationPermissions.Replace))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            frmReplacementForDamagedOfLostLicenseApplication frm = new frmReplacementForDamagedOfLostLicenseApplication();
            frm.ShowDialog();
        }

        private void _ShowDetainLicenseScreen()
        {
            if (!clsSettings.CheckPermission((int)clsSettings.enLicenseOperationPermissions.Detain))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void _ShowReleaseDetainedLicenseScreen()
        {
            if (!clsSettings.CheckPermission((int)clsSettings.enLicenseOperationPermissions.Release))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void _ShowManageDetainedLicensesScreen()
        {
            if (!clsSettings.CheckPermission((int)clsSettings.enLicenseOperationPermissions.Read))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            frmManageDetainedLicenses frm = new frmManageDetainedLicenses();
            frm.ShowDialog();
        }

        private void peopleStripDropDownButton_Click(object sender, EventArgs e)
        {
            _ShowManagePeopleScreen();
        }

        private void driversStripDropDownButton_Click(object sender, EventArgs e)
        {
            _ShowManageDriversScreen();
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
            _ShowAddNewLocalDrivingLicenseApplicationScreen();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowCurrentUserInfo();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Retrieve the current user
            clsUserSetting CurrentUser = clsUserSetting.Find("Current User");

            // Clear the current user
            CurrentUser.User = null;
            CurrentUser.Permissions = 0;
            CurrentUser.Save();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowChangePasswordScreen();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowManageLocalDrivingLicenseApplicationsScreen();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowManageUsersScreen();
        }

        private void loginRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowLoginRecordsScreen();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowAddNewInternationalLicenseApplicationScreen();
        }

        private void internationalDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowInternationalLicenseApplicationsScreen();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowRenewLocalLicenseApplicationScreen();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowReplacementForLostOrDamagedLicenseScreen();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowDetainLicenseScreen();
        }

        private void releaseDetainedLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _ShowReleaseDetainedLicenseScreen();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowReleaseDetainedLicenseScreen();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowManageDetainedLicensesScreen();
        }
    }
}
