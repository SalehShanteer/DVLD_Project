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
    public partial class ctrlPersonInfo : UserControl
    {

        private int _PersonID;

        private clsPerson _Person;


        public delegate void DataBackEventHandler(object sender, clsPerson Person);

        public event DataBackEventHandler DataBack;


        public ctrlPersonInfo() : this(-1) {}

        public ctrlPersonInfo(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
        }

        private bool _CheckIfPersonExist()
        {
            return clsPerson.IsExist(_PersonID);
        }

        private void _DisplayPersonGender()
        {
            lblGender.Text = _Person.Gender == true ? "Male" : "Female";
        }

        private void _DisplayPersonImage()
        {
            if (_Person.ImagePath != string.Empty)
            {
                pbImage.Load(_Person.ImagePath);
            }
            else
            {
                // Set default person image (true ==> male) (false ==> female)
                pbImage.Image = _Person.Gender == true ? Resources.Male : Resources.Female;
            }
        }

        private bool _DisplayPersonInfo()
        {
            if (_CheckIfPersonExist())
            {
                // Retrieve person info
                _Person = clsPerson.Find(_PersonID);

                lblPersonID.Text = _Person.ID.ToString();
                lblName.Text = _Person.FullName;
                lblNationalNo.Text = _Person.NationalNumber;
                lblEmail.Text = _Person.Email;
                lblAddress.Text = _Person.Address;
                lblDateOfBirth.Text = _Person.DateOfBirth.ToString("M/dd/yyyy");
                lblPhone.Text = _Person.Phone;
                lblCountry.Text = _Person.Country.Name;

                _DisplayPersonGender();
                _DisplayPersonImage();

                return true;
            }
            else
            {
                MessageBox.Show("Person does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                return false;
            }
        }

        public bool DisplayPersonInfoOutside(int personID)
        {
            _PersonID = personID;

            if (_DisplayPersonInfo())
            {
                // If person exist send person ID back
                DataBack?.Invoke(this, _Person);

                // Enable edit person info link label
                llblEditPersonInfo.Enabled = true;

                return true;
            }
            return false;
        }

        private void _UpdatePerson()
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_Person.ID);
            frm.ShowDialog();
        }

        private void llblEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _UpdatePerson();
        }

    }
}
