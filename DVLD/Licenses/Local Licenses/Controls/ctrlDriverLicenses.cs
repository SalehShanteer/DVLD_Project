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
                    int LocalLicensesCount = clsLicense.GetLicensesCountByDriverID(_DriverID);
                    lblLocalLicensesCount.Text = LocalLicensesCount.ToString();

                    // Check if there are local licenses
                    if (LocalLicensesCount != 0)
                    {
                        _PrepareLocalLicensesList();
                    }
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
                    int InternationalLicensesCount = clsInternationalLicense.GetInternationalLicensesCountByDriverID(_DriverID);
                    lblInternationalLicensesCount.Text = InternationalLicensesCount.ToString();

                    // Check if there are international licenses
                    if (InternationalLicensesCount != 0)
                    {
                        _PrepareInternationalLicensesList();
                    }
                }));
            });
            RefreshInternationalLicensesThread.Start();
        }

        private void _PrepareLocalLicensesList()
        {
            //Adjust columns widths
            dgvLocalLicensesList.Columns["Lic.ID"].Width = 85;
            dgvLocalLicensesList.Columns["App.ID"].Width = 85;
            dgvLocalLicensesList.Columns["Class Name"].Width = 270;
            dgvLocalLicensesList.Columns["Issue Date"].Width = 130;
            dgvLocalLicensesList.Columns["Expiration Date"].Width = 150;
            dgvLocalLicensesList.Columns["Is Active"].Width = 85;
        }

        private void _PrepareInternationalLicensesList()
        {
            //Adjust columns widths
            dgvInternationalLicensesList.Columns["int.License ID"].Width = 140;
            dgvInternationalLicensesList.Columns["Application ID"].Width = 140;
            dgvInternationalLicensesList.Columns["L.License ID"].Width = 140;
            dgvInternationalLicensesList.Columns["Issue Date"].Width = 140;
            dgvInternationalLicensesList.Columns["Expiration Date"].Width = 150;
            dgvInternationalLicensesList.Columns["Is Active"].Width = 93;
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
