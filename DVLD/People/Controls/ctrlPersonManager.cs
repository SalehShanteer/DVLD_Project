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
    public partial class ctrlPersonManager : UserControl
    {

        private enum enMode { AddNew = 0, Update = 1 }

        private enMode _Mode = enMode.AddNew;

        private int _PersonID;

        private clsPerson _Person;

        //Define the event
        public event Action<int> OnSavePersonComplete;

        public event Action OnClose;

        //Create a method to raise the event
        protected virtual void SavePersonComplete(int PersonID)
        {
            Action<int> handler = OnSavePersonComplete;

            if (handler != null)
            {
                handler(PersonID);
            }
        }

        protected virtual void Close()
        {
            Action handler = OnClose;
            if (handler != null)
            {
                handler();
            }
        }


        public ctrlPersonManager() : this(-1) { }

        public ctrlPersonManager(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;

            if (_PersonID != -1)
            {
                _Mode = enMode.Update;
            }
            else
            {
                _Mode = enMode.AddNew;
            }
        }




        //Save the person
        private void _SetPersonNationalityCountry()
        {
            _Person.Country = clsCountry.Find(cbxCountry.SelectedItem.ToString());
        }

        private void _SetPersonGender()
        {
            if (rbMale.Checked)
            {
                _Person.Gender = true;// Male : true
            }
            else
            {
                _Person.Gender = false;// Female : false
            }
        }

        private void _SetPersonDetails()
        {
            _Person.NationalNumber = txtNationalNo.Text;
            _Person.FirstName = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = txtThirdName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.Address = rtxtAddress.Text;
            _Person.Phone = txtPhone.Text;
            _Person.Email = txtEmail.Text;

            _SetPersonNationalityCountry();

            _SetPersonGender();
        }

        private void _SavePerson()
        {
            _SetPersonDetails();

            if (_Person.Save())
            {
                

                _Mode = enMode.Update;

                MessageBox.Show(clsUtility.saveMessage("person"), clsUtility.saveTitle("Person"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (OnSavePersonComplete != null)
                {
                    SavePersonComplete(_Person.ID);
                }
            }
            else
            {
                MessageBox.Show(clsUtility.errorSaveMessage, clsUtility.errorSaveTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _DisplayPersonGender()
        {
            if (_Person.Gender)
            {
                //When gender is true then 'Male'
                rbMale.Checked = true;
            }
            else
            {
                //When gender is false then 'Female'
                rbFemale.Checked = true;
            }
        }

        private void _DisplayPersonNationalityCountry()
        {
            cbxCountry.SelectedIndex = cbxCountry.FindString(_Person.Country.Name);
        }

        private void _DisplayPersonInfo()
        {
            txtNationalNo.Text = _Person.NationalNumber;
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            rtxtAddress.Text = _Person.Address;
            txtPhone.Text = _Person.Phone;
            txtEmail.Text = _Person.Email;

            _DisplayPersonGender();
            _DisplayPersonNationalityCountry();
        }

        private void _LoadCountriesControlBox()
        {
            DataTable dtCountries = clsCountry.GetCountriesList();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbxCountry.Items.Add(row["Name"]);
            }
        }

        private void _LoadPersonInfo()
        {
            _LoadCountriesControlBox();

            if (_Mode == enMode.AddNew)
            {
                _Person = new clsPerson();

                // Set default country 'Jordan' in countries comboBox
                cbxCountry.SelectedIndex = cbxCountry.FindString("Jordan");
            }
            else
            {
                //Retrieve the person data
                _Person = clsPerson.Find(_PersonID);

                _DisplayPersonInfo();
            }
        }
       

        private void btnSave_Click(object sender, EventArgs e)
        {
            _SavePerson();
        }

        private void ctrlPersonManager_Load(object sender, EventArgs e)
        {
            _LoadPersonInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
