using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlDriverLicenses : UserControl
    {

        private DataView _dvLocalLicensesList;

        private DataView _dvInternationalLicensesList;

        private int _DriverID;

        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }

        public void DisplayDriverLicensesFromOutside(int DriverID)
        {
            _DriverID = DriverID;
            _Refresh();
        }

        private void _Refresh()
        {
            _RefreshLocalLicenses();
            _RefreshInternationalLicenses();
        }

        private void _RefreshLocalLicenses()
        {
            Thread RefreshLocalLicensesThread = new Thread(() =>
            {
                _dvLocalLicensesList = clsLicense.GetDriverLocalLicenses(_DriverID).DefaultView;
                this.Invoke(new Action(() =>
                {
                    dgvLocalLicensesList.DataSource = _dvLocalLicensesList;

                    //Display local licenses records count
                    lblLocalLicensesCount.Text = clsLicense.GetLicensesCountByDriverID(_DriverID).ToString();
                }));
            });
            RefreshLocalLicensesThread.Start();
        }

        private void _RefreshInternationalLicenses()
        {
            Thread RefreshInternationalLicensesThread = new Thread(() =>
            {
                _dvInternationalLicensesList = clsInternationalLicense.GetDriverInternationalLicenses(_DriverID).DefaultView;

                this.Invoke(new Action(() =>
                {
                    dgvInternationalLicensesList.DataSource = _dvInternationalLicensesList;

                    //Display international licenses count
                    lblInternationalLicensesCount.Text = clsInternationalLicense.GetInternationalLicensesCountByDriverID(_DriverID).ToString();
                }));
            });
            RefreshInternationalLicensesThread.Start();
        }

        private void _ShowLicenseInfo()
        {
            // For Local licenses if the selected tab is Local Licenses
            if (dgvLocalLicensesList.SelectedCells.Count > 0 && tcLicenses.SelectedIndex == 0)
            {
                int selectedLocalLicenseID = Convert.ToInt32(dgvLocalLicensesList.CurrentRow.Cells["Lic.ID"].Value);
                frmLicenseInfo frmLicenseInfo = new frmLicenseInfo(selectedLocalLicenseID);
                frmLicenseInfo.ShowDialog();
            }
            // For International licenses if the selected tab is International Licenses
            else if (dgvInternationalLicensesList.SelectedCells.Count > 0 && tcLicenses.SelectedIndex == 1)
            {
                int selectedInternationalLicenseID = Convert.ToInt32(dgvInternationalLicensesList.CurrentRow.Cells["Int.License ID"].Value);
                frmInternationalLicenseInfo frmLicenseInfo = new frmInternationalLicenseInfo(selectedInternationalLicenseID);
                frmLicenseInfo.ShowDialog();
            }
            
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowLicenseInfo();
        }
    }
}
