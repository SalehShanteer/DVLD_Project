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
    public partial class frmLicenseInfo : Form
    {

        private int _LicenseID;


        public frmLicenseInfo(int LicenseID)
        {
            InitializeComponent();

            _LicenseID = LicenseID;
        }

        private void frmLicenseInfo_Load(object sender, EventArgs e)
        {
            _LoadLicenseInfo();
        }

        private void _LoadLicenseInfo()
        {
            bool IsDisplayed = ctrlDriverLicenseInfo1.DisplayLicenseInfoFromOutside(_LicenseID);

            if (!IsDisplayed)
            {
                MessageBox.Show(clsUtility.errorOpenFormMessag("license info"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Close form
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
