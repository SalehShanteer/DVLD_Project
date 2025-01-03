﻿using DVLD.Properties;
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

        private void _SetPersonImagePath()
        {
            // Set Imagepath if does not have default image
            _Person.ImagePath = pbImage.ImageLocation != null ? pbImage.ImageLocation : string.Empty;
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
            _SetPersonImagePath();
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


        // Load Person Info
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

        private void _DisplayPersonImage()
        {
            if (_Person.ImagePath != string.Empty)
            {
                pbImage.Load(_Person.ImagePath);
            }
            else
            {
                pbImage.Image = rbMale.Checked ? Resources.Male : Resources.Female;
            }
        }

        public void DisplayPersonInfo(int PersonID)
        {
            //Retrieve the person data
            _Person = clsPerson.Find(PersonID);

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
            _DisplayPersonImage();
        }

        private void _LoadCountriesControlBox()
        {
            DataTable dtCountries = clsCountry.GetCountriesList();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbxCountry.Items.Add(row["Name"]);
            }

            // Set default country 'Jordan' in countries comboBox
            cbxCountry.SelectedIndex = cbxCountry.FindString("Jordan");
        }

        private void _LoadPersonInfo()
        {
            _LoadCountriesControlBox();

            if (_Mode == enMode.AddNew)
            {
                _Person = new clsPerson();               
            }
            else
            {              
                DisplayPersonInfo(_PersonID);
            }
        }


        private void _ChooseImageFromFile()
        {
            // Prepare openFileDialog
            openFileDialogForImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
            openFileDialogForImage.FilterIndex = 1;
            openFileDialogForImage.RestoreDirectory = true;// Save last directorty

            if (openFileDialogForImage.ShowDialog() == DialogResult.OK)
            {
                //Display person image
                string SelectedPath = openFileDialogForImage.FileName;
                pbImage.Load(SelectedPath);

                // Show remove link label
                llblRemove.Visible = true;
            }
        }
       
        private void _RemovePersonImage()
        {
            // Set default image for male or female
            pbImage.Image = rbMale.Checked ? Resources.Male : Resources.Female;

            // Hide remove link label
            llblRemove.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(clsUtility.askForSaveMessage("person"), "Save?"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _SavePerson();
            }
        }

        private void ctrlPersonManager_Load(object sender, EventArgs e)
        {
            _LoadPersonInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void llblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _ChooseImageFromFile();
        }

        private void llblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _RemovePersonImage();
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (llblRemove.Visible == false)
            {
                if (rbMale.Checked)
                {
                    pbImage.Image = Resources.Male;
                }
                else if (!rbMale.Checked)
                {
                    pbImage.Image = Resources.Female;
                }
            }
        }

    }
}
