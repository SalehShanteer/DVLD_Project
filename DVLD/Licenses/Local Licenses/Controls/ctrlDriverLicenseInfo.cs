using DVLD.Properties;
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
    public partial class ctrlDriverLicenseInfo : UserControl
    {

        private clsLicense _License;

        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public bool DisplayLicenseInfoFromOutside(int LicenseID)
        {
            // Retrieve license info
            _License = clsLicense.Find(LicenseID);

            if (_License != null)
            {
                _DisplayAllInfo();
                return true;
            }
            return false;
        }

        private void _DisplayDriverInfo()
        {
            lblDriverID.Text = _License.Driver.ID.ToString();
            lblName.Text = _License.Driver.Person.FullName;
            lblNationalNo.Text = _License.Driver.Person.NationalNumber;
            lblGender.Text = _License.Driver.Person.Gender == true ? "Male" : "Female";
            lblDateOfBirth.Text = _License.Driver.Person.DateOfBirth.ToString("M/dd/yyyy");

            _DisplayPersonImage();
        }

        private void _DisplayPersonImage()
        {
            string ImagePath = _License.Driver.Person.ImagePath;
            if (ImagePath != string.Empty)
            {
                pbImage.Load(ImagePath);
            }
            else
            {
                pbImage.Image = _License.Driver.Person.Gender == true ? Resources.Male : Resources.Female;
            }
        }

        private void _DisplayLicenseInfo()
        {
            // License info
            lblLicenseID.Text = _License.ID.ToString();
            lblIssueDate.Text = _License.IssueDate.ToString("M/dd/yyyy");
            lblIssueReason.Text = clsUtility.GetLicenseIssueReason((byte)_License.Application.ApplicationType.ID);
            lblNotes.Text = _License.Notes != string.Empty ? _License.Notes : "No Notes";
            lblClass.Text = _License.LicenseClass.Title;
            lblIsActive.Text = _License.IsActive == true ? "Yes" : "No";
            lblExpirationDate.Text = _License.ExpireDate.ToString("M/dd/yyyy");

            // Display Detained status based on some condition
            lblIsDetained.Text = clsDetainedLicense.IsDetained(_License.ID) == true ? "Yes" : "No";
        }

        private void _DisplayAllInfo()
        {           
            _DisplayDriverInfo();
            _DisplayLicenseInfo();
        }

    }
}
