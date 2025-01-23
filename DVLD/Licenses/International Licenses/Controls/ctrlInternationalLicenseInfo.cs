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
    public partial class ctrlInternationalLicenseInfo : UserControl
    {

        private clsInternationalLicense _InternationalLicense;

        public ctrlInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        public void DisplayInternationalLicenseInfoFromOutside(int InternationalLicenseID)
        {
            _InternationalLicense = clsInternationalLicense.Find(InternationalLicenseID);

            if (_InternationalLicense != null)
            {
                _DisplayAllLicenseInfo();
            }
            else
            {
                MessageBox.Show("Error: International license not found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _DisplayDriverInfo()
        {
            lblName.Text = _InternationalLicense.Application.ApplicantPerson.FullName;
            lblNationalNo.Text = _InternationalLicense.Application.ApplicantPerson.NationalNumber;
            lblGender.Text = _InternationalLicense.Application.ApplicantPerson.Gender == true ? "Male" : "Female";
            lblDateOfBirth.Text = _InternationalLicense.Application.ApplicantPerson.DateOfBirth.ToString("M/dd/yyyy");

            _DisplayPersonImage();
        }

        private void _DisplayPersonImage()
        {
            string ImagePath = _InternationalLicense.IssuedUsingLocalLicense.Driver.Person.ImagePath;
            if (ImagePath != string.Empty)
            {
                pbImage.Load(ImagePath);
            }
            else
            {
                pbImage.Image = _InternationalLicense.Application.ApplicantPerson.Gender == true ? Resources.Male : Resources.Female;
            }
        }

        private void _DisplayLicenseInfo()
        {
            lblInternationalLicenseID.Text = _InternationalLicense.ID.ToString();
            lblLicenseID.Text = _InternationalLicense.IssuedUsingLocalLicense.ID.ToString();
            lblApplicationID.Text = _InternationalLicense.Application.ID.ToString();
            lblDriverID.Text = _InternationalLicense.IssuedUsingLocalLicense.Driver.ID.ToString();
            lblIsActive.Text = _InternationalLicense.IsActive == true ? "Yes" : "No";
            lblIssueDate.Text = _InternationalLicense.IssueDate.ToString("M/dd/yyyy");
            lblExpirationDate.Text = _InternationalLicense.ExpireDate.ToString("M/dd/yyyy");
        }

        private void _DisplayAllLicenseInfo()
        {
            _DisplayDriverInfo();
            _DisplayLicenseInfo();
        }

    }
}
