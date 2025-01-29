using DVLD.Properties;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
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

        public ctrlPersonManager()
        {
            InitializeComponent();
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
            string SourceFilePath = pbImage.ImageLocation;

            if (SourceFilePath != null)
            {
                string Extension = Path.GetExtension(SourceFilePath);
                string DestinationFilePath = $"C:\\Users\\saleh\\Desktop\\Programming\\Projects\\DVLD Project\\DVLD People Images\\{Guid.NewGuid()}.{Extension}";

                File.Copy(SourceFilePath, DestinationFilePath, true);
                _Person.ImagePath = DestinationFilePath;
            }
            else
            {
                _Person.ImagePath = string.Empty;
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


        private bool _ValidateRequiredField(TextBox ctrl, string name)
        {
            if (string.IsNullOrWhiteSpace(ctrl.Text))
            {
                errorProvider1.SetError(ctrl, $"Please enter the {name}");
                return false;
            }
            else
            {
                errorProvider1.SetError(ctrl, string.Empty);
                return true;
            }
        }

        private bool _ValidateRequiredField(RichTextBox ctrl, string name)
        {
            if (string.IsNullOrWhiteSpace(ctrl.Text))
            {
                errorProvider1.SetError(ctrl, $"Please enter the {name}");
                return false;
            }
            else
            {
                errorProvider1.SetError(ctrl, string.Empty);
                return true;
            }
        }

        private bool _ValidatePersonName()
        {
            bool isValid = true;

            if (!_ValidateRequiredField(txtFirstName, "first name"))
            {
                isValid = false;
            }

            if (!_ValidateRequiredField(txtSecondName, "second name"))
            {
                isValid = false;
            }
            if (!_ValidateRequiredField(txtThirdName, "third name"))
            {
                isValid = false;
            }

            if (!_ValidateRequiredField(txtLastName, "last name"))
            {
                isValid = false;
            }

            return isValid;
        }

        private bool _ValidateEmailSyntax()
        {
            if (!clsUtility.ValidateEmail(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Please enter a valid email address");
                return false;
            }
            else
            {
                errorProvider1.SetError(txtEmail, string.Empty);
                return true;
            }
        }

        private bool _ValidateEmail()
        {
            bool isValid = true;

            if (!_ValidateRequiredField(txtEmail, "email"))
            {
                isValid = false;
            }
            else if (!_ValidateEmailSyntax())
            {
                isValid = false;
            }
            else if ((_Mode == enMode.AddNew && clsPerson.IsEmailExist(txtEmail.Text))
               || (_Mode == enMode.Update && _Person.IsSameEmail(txtEmail.Text)))

            {
                errorProvider1.SetError(txtEmail, "Email already exists!");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtEmail, string.Empty);
            }

            return isValid;
        }

        private bool ValidatePersonContact()
        {
            bool isValid = true;

            if (!_ValidateRequiredField(txtPhone, "phone number"))
            {
                isValid = false;
            }
            if (!_ValidateEmail())
            {
                isValid = false;
            }

            if (!_ValidateRequiredField(rtxtAddress, "address"))
            {
                isValid = false;
            }

            return isValid;
        }

        private bool ValidatePersonNationalNumber()
        {
            bool isValid = true;

            if (!_ValidateRequiredField(txtNationalNo, "national number"))
            {
                isValid = false;
            }
            else if ((_Mode == enMode.AddNew && clsPerson.IsNationalNumberExist(txtNationalNo.Text))
                || (_Mode == enMode.Update && _Person.IsSameNationalNumber(txtNationalNo.Text)))
            {
                errorProvider1.SetError(txtNationalNo, "National number already exists!");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, string.Empty);
            }

            return isValid;
        }

        private bool _IsValidData()
        {
            bool isValid = true;

            if (!_ValidatePersonName())
            {
                isValid = false;
            }
            if (!ValidatePersonContact())
            {
                isValid = false;
            }
            if (!ValidatePersonNationalNumber())
            {
                isValid = false;
            }

            return isValid;
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
                if (File.Exists(_Person.ImagePath))
                {
                    pbImage.Load(_Person.ImagePath);

                    // Show remove link label
                    llblRemove.Visible = true;
                }
                else
                {
                    MessageBox.Show($"Image with path '{_Person.ImagePath}' not found!", "Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);

                    pbImage.Image = rbMale.Checked ? Resources.Male : Resources.Female;
                }
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
            _Mode = enMode.Update;

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

        private void _SetMaxBirthDate()
        {
            // Set max date to ensure only people with 18 years old or older are allowed
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
        }

        private void _LoadPersonInfo()
        {
            _LoadCountriesControlBox();
            _SetMaxBirthDate();

            if (_Mode == enMode.AddNew)
            {
                _Person = new clsPerson();               
            }
            else
            {              
                DisplayPersonInfo(_Person.ID);
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

                if (_Person.ImagePath != string.Empty)
                {
                    _RemovePersonImage();
                    
                }
                //Display person image
                string SelectedPath = openFileDialogForImage.FileName;
                pbImage.Load(SelectedPath);

                _SetPersonImagePath();

                // Show remove link label
                llblRemove.Visible = true;
            }
        }

        private bool _DeleteImage()
        {
            string filePath = _Person.ImagePath;

            try
            {
                
                if (pbImage.Image != null)
                {
                    // Load default image to prevent file in use error
                    pbImage.Load("C:\\Users\\saleh\\Desktop\\Programming\\Projects\\DVLD Project\\DVLD People Images\\Male.png");
                    pbImage.Image = null;
                }

                // Move the file to a temporary location to release the lock
                if (File.Exists(filePath))
                {
                    // Delete the file from the temporary location
                    File.Delete(filePath);
                    return true;
                }
                else
                {
                    MessageBox.Show("File does not exist!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Image delete operation failed! " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void _RemovePersonImage()
        {

            if (_DeleteImage())
            {
                // Set default image for male or female
                pbImage.Image = rbMale.Checked ? Properties.Resources.Male : Properties.Resources.Female;

                _Person.ImagePath = string.Empty;

                // Hide remove link label
                llblRemove.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(clsUtility.askForSaveMessage("person"), "Save?"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_IsValidData())
                {
                    _SavePerson();
                }
                else
                {
                    MessageBox.Show("Please enter the required data", "Error!"
                                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
