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
    public partial class frmLicenseHistory : Form
    {

        private string _NationalNumber;

        public frmLicenseHistory(string NationalNumber)
        {
            InitializeComponent();

            _NationalNumber = NationalNumber;
        }

        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            _LoadScreen();
        }

        private void _LoadScreen()
        {
            _DisplayPersonInfo();
            _DisplayDriverLicenses();
        }

        private void _DisplayPersonInfo()
        {
            ctrlPersonInfoWithFilter1.FindPersonFromOutside(_NationalNumber);
            ctrlPersonInfoWithFilter1.DisableFilterFromOutside();
        }

        private void _DisplayDriverLicenses()
        {
            int DriverID = clsDriver.GetIDByNationalNumber(_NationalNumber);

            ctrlDriverLicenses1.DisplayDriverLicensesFromOutside(DriverID);
        }

    }
}
