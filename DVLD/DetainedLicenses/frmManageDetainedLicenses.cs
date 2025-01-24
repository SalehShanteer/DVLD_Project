﻿using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmManageDetainedLicenses : Form
    {

        private DataView _dvDetainedLicensesList;

        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }

        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            _Refresh();
        }

        // using async/await instead of Thread
        private async void _Refresh()
        {
            await _RefreshDetainedLicenses();

            cbxFilter.SelectedIndex = 0; // Filter default index at (none)
        }

        private async Task _RefreshDetainedLicenses()
        {
            try
            {
                _dvDetainedLicensesList = await Task.Run(() => clsDetainedLicense.GetDetainedLicensesList().DefaultView);

                dgvDetainedLicensesList.DataSource = _dvDetainedLicensesList;

                // Display detained licenses records count
                lblLicenseDetainsCount.Text = clsDetainedLicense.GetDetainedLicensesCount().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string _GetFilterAttributes(int filterIndex)
        {
            string[] filterAttributes = new string[]
            {
                "None",
                "D.ID",
                "Is Released",
                "N.No.",
                "Full Name",
                "Release App.ID"
            };
            
            return filterAttributes[filterIndex];
        }

        private void _Filter()
        {
            string filterAttribute = _GetFilterAttributes(cbxFilter.SelectedIndex);
            string filter = txtFilter.Text.Trim();

            if (filterAttribute == "None" || string.IsNullOrEmpty(filter))
            {
                _dvDetainedLicensesList.RowFilter = string.Empty;
            }
            else
            {
                if (filterAttribute == "D.ID" || filterAttribute == "Release App.ID")
                {
                    _dvDetainedLicensesList.RowFilter = $"[{filterAttribute}] = {filter}";
                }
                else if (filterAttribute == "N.No.")
                {
                    _dvDetainedLicensesList.RowFilter = $"[{filterAttribute}] = '{filter}'";
                }
                else
                {
                    _dvDetainedLicensesList.RowFilter = $"[{filterAttribute}] LIKE '{filter}%'";
                }
            }
        }

        private void _IsReleasedFilter()
        {
            switch (cbxIsReleased.SelectedIndex)
            {
                case 0:
                    {
                        // All
                        _dvDetainedLicensesList.RowFilter = string.Empty;
                        break;
                    }

                case 1:
                    {
                        // Yes
                        _dvDetainedLicensesList.RowFilter = "[Is Released] = 1";
                        break;
                    }
                case 2:
                    {
                        // No
                        _dvDetainedLicensesList.RowFilter = "[Is Released] = 0";
                        break;
                    }
            }
        }

        private void _ShowReleaseDetainedLicenseScreen()
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void _ShowDetainedLicenseScreen()
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void _ShowPersonDetailsScreen()
        {
            if (dgvDetainedLicensesList.SelectedCells.Count > 0)
            {
                string NationalNumber = (string)dgvDetainedLicensesList.CurrentRow.Cells["N.No."].Value;

                int PersonID = clsPerson.Find(NationalNumber).ID;
                frmPersonDetails frm = new frmPersonDetails(PersonID);
                frm.ShowDialog();
            }
        }

        private void _ShowLicenseDetailsScreen()
        {
            if (dgvDetainedLicensesList.SelectedCells.Count > 0)
            {
                int SelectedLocalLicenseID = (int)dgvDetainedLicensesList.CurrentRow.Cells["L.ID"].Value;

                frmLicenseInfo frm = new frmLicenseInfo(SelectedLocalLicenseID);
                frm.ShowDialog();
            }
        }

        private void _ShowPersonLicenseHistoryScreen()
        {
            if (dgvDetainedLicensesList.SelectedCells.Count > 0)
            {
                string NationalNumber = (string)dgvDetainedLicensesList.CurrentRow.Cells["N.No."].Value;

                frmLicenseHistory frm = new frmLicenseHistory(NationalNumber);
                frm.ShowDialog();
            }
        }

        private void _ShowReleaseDetainedLicenseForSpecificDetainScreen()
        {
            if (dgvDetainedLicensesList.SelectedCells.Count > 0)
            {
                int SelectedLicenseID = (int)dgvDetainedLicensesList.CurrentRow.Cells["L.ID"].Value;
                frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense(SelectedLicenseID);
                frm.ShowDialog();
            }
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            _ShowDetainedLicenseScreen();
        }

        private void btnReleaseDetainedLicense_Click(object sender, EventArgs e)
        {
            _ShowReleaseDetainedLicenseScreen();
        }

        private void cbxIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            _IsReleasedFilter();
        }

        private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Clear filter textBox
            txtFilter.Text = string.Empty;
            cbxIsReleased.SelectedIndex = 0;// Is Released filter default index at (All)

            switch (cbxFilter.Text)
            {
                case "None":
                    {
                        txtFilter.Visible = false;
                        cbxIsReleased.Visible = false;
                        break;
                    }

                case "Is Released":
                    {

                        txtFilter.Visible = false;
                        cbxIsReleased.Visible = true;
                        break;
                    }

                default:
                    {
                        txtFilter.Visible = true;
                        cbxIsReleased.Visible = false;
                        break;
                    }
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) 
                && (cbxFilter.SelectedIndex == 1 || cbxFilter.SelectedIndex == 5))
            {
                e.Handled = true; // Ensure only digits are allowed if the filter is by detain ID or release application ID
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _Filter();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowPersonDetailsScreen();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowLicenseDetailsScreen();
        }

        private void showPersonLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowPersonLicenseHistoryScreen();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowReleaseDetainedLicenseForSpecificDetainScreen();
        }

        private void cmsDetainedLicenses_Opening(object sender, CancelEventArgs e)
        {
            if (dgvDetainedLicensesList.SelectedCells.Count > 0)
            {
                int SelectedLocalLicenseID = (int)dgvDetainedLicensesList.CurrentRow.Cells["L.ID"].Value;
                
                if (clsDetainedLicense.IsDetained(SelectedLocalLicenseID))
                {
                    releaseDetainedLicenseToolStripMenuItem.Enabled = true;
                }
                else
                {
                    releaseDetainedLicenseToolStripMenuItem.Enabled = false;
                }
            }
        }
    }
}
