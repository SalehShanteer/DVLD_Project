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
    public partial class frmLocalDrivingLicenseApplicationInfo : Form
    {

        private int _LocalDrivingLicenseApplicationID;

        public frmLocalDrivingLicenseApplicationInfo(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void frmLocalDrivingLicenseApplicationInfo_Load(object sender, EventArgs e)
        {
            _LoadLocalDrivingLicenseApplication();
        }

        private void _LoadLocalDrivingLicenseApplication()
        {
            ctrlLocalDrivingLicenseApplicationInfo1.DisplayLocalDrivingLicenseApplicationInfoOutside(_LocalDrivingLicenseApplicationID);
        }

      
    }
}
