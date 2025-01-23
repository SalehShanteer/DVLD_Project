using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlInternationalLicenseApplicationInfo : UserControl
    {
        
        public ctrlInternationalLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        private void ctrlInternationalLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            _LoadInitialLicenseInfo();
        }

        private void _LoadInitialLicenseInfo()
        {
            _DisplayInitialLicenseInfo();
        }

        private void _DisplayInitialLicenseInfo()
        {
            //lblApplicationDate.Text = DateTime.Now.ToString("M/dd/yyyy");
            //lblIssueDate.Text = DateTime.Now.ToString("M/dd/yyyy");
            //lblExpirationDate.Text = DateTime.Now.AddYears(clsSettings.InternationalLicenseDefaultValidityLength).ToString("M/dd/yyyy");
            //lblFees.Text = clsApplicationType.GetFees(6).ToString(); // 6 => New international license
            //lblCreatedBy.Text = clsUserSetting.GetCurrentUserFullName();
        }

       
    }
}
