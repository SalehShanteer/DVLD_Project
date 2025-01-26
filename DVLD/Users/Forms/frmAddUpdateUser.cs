using DVLD_Business;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmAddUpdateUser : Form
    {

        // define delegate for save event
        public delegate void SavePersonEventHandler(object sender, bool IsSaved);

        // define event for save
        public event SavePersonEventHandler SavePerson;

        private enum enMode { AddNew = 0, Update = 1}

        private enMode _Mode = enMode.AddNew;

        private int _UserID;

        private int _PersonID = -1;

        private clsUser _User;

        private Dictionary <int, string> RolesDescription = new Dictionary<int, string>();

        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;   

            if (_UserID != -1)
            {
                _Mode = enMode.Update;
            }
            else
            {
                _Mode = enMode.AddNew;
            }
        }     

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _LoadUserInfo();
        }

        // Save user info
        private void _SetUserRole()
        {
            _User.Role = clsRole.Find(cbxRoles.Text);
        }

        private void _SetAccountInfo()
        {
            _User.Username = txtUsername.Text;
            _User.Password = txtPassword.Text;
            _User.IsActive = ckbIsActive.Checked;

            _SetUserRole();
        }

        private void _SetPersonInfo()
        {
            _User.Person = clsPerson.Find(_PersonID);
        }

        private void _SetUserInfo()
        {
            _SetPersonInfo();
            _SetAccountInfo();
        }

        private void _SaveUser()
        {
            _SetUserInfo();

            if (_User.Save())
            {
                MessageBox.Show(clsUtility.saveMessage("User"), clsUtility.saveTitle("User"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Change the form title
                this.Text = "Update User";
                lblAddUpdateUser.Text = "Update User";

                // Display user ID
                lblUserID.Text = _User.ID.ToString();

                _Mode = enMode.Update;

                // Raise save event
                SavePerson?.Invoke(this, IsSaved : true);

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

        private bool _IsValidData()
        {
            bool isValid = true;

            if (!_ValidateRequiredField(txtUsername, "Username"))
            {
                isValid = false;
            }
            else if (clsUser.IsUsernameExist(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Username already exists");
                isValid = false;
            }
            if (!_ValidateRequiredField(txtPassword, "Password"))
            {
                isValid = false;
            }
            else if (!clsUtility.ValidatePassword(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Password must be at least 8 characters, digit, upper case, lower case and special character");
                isValid = false;
            }

            if (!_ValidateRequiredField(txtConfirmPassword, "Confirm Password"))
            {
                isValid = false;
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "Password does not match");
                isValid = false;
            }

            return isValid;
        }

        // Load user info 
        private void _DisplayPersonInfo()
        {
            ctrlPersonInfoWithFilter1.FindPersonFromOutside(_User.Person.ID);
        }

        private void _DisplayUserRole()
        {
            cbxRoles.SelectedIndex = cbxRoles.FindString(_User.Role.Title);
        }

        private void _DisplayUserInfo()
        {
            // Display account info
            lblUserID.Text = _User.ID.ToString();
            txtUsername.Text = _User.Username;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            ckbIsActive.Checked = _User.IsActive;

            _DisplayUserRole();
            _DisplayPersonInfo();
        }

        private void _LoadUserInfo()
        {
            _LoadRolesComboBox();

            if (_Mode == enMode.AddNew)
            {
                // Change the form title
                this.Text = "Add New User";
                lblAddUpdateUser.Text = "Add New User";

                _User = new clsUser();

            }
            else
            {
                // Change the form title
                this.Text = "Update User";
                lblAddUpdateUser.Text = "Update User";

                //Disable filter groubBox
                ctrlPersonInfoWithFilter1.DisableFilterFromOutside();

                // Retrieve user data
                _User = clsUser.Find(_UserID);

                _DisplayUserInfo();
            }
        }

        private void _LoadRolesComboBox()
        {
            DataTable dtRoles = clsRole.GetRolesList();

            foreach (DataRow row in dtRoles.Rows)
            {
                cbxRoles.Items.Add(row["Title"]);

                // Load roles description
                RolesDescription.Add((int)row["RoleID"], (string)row["Description"]);
            }
            // Set roles default index 'Data Entry' 
            cbxRoles.SelectedIndex = 0;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Change label description to match role
            lblRoleDescription.Text = RolesDescription[cbxRoles.SelectedIndex + 1].ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (_PersonID == -1)
            {
                MessageBox.Show("Please select a person", "Person not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_IsValidData())
            {
                _SaveUser();
            }
            else
            {
                MessageBox.Show(clsUtility.errorProviderMessage, clsUtility.errorSaveTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctrlPersonInfoWithFilter1_OnFindPersonComplete(int obj)
        {
            _PersonID = obj; 
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tcUserInfo.SelectedIndex = 1;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tcUserInfo.SelectedIndex = 0;
        }

        private void _ShowHidePassword(TextBox textBox, PictureBox pictureBoxShowHide)
        {
            if (textBox.UseSystemPasswordChar == true)
            {
                // Show password in plain text
                pictureBoxShowHide.Image = Properties.Resources.show;
                textBox.UseSystemPasswordChar = false;
            }
            else
            {
                // Hide password in plain text
                pictureBoxShowHide.Image = Properties.Resources.hide;
                textBox.UseSystemPasswordChar = true;
            }
        }

        private void pbShowHidePassword_Click(object sender, EventArgs e)
        {
            _ShowHidePassword(txtPassword, pbShowHidePassword);
        }

        private void pbShowHideConfirmPassword_Click(object sender, EventArgs e)
        {
            _ShowHidePassword(txtConfirmPassword, pbShowHideConfirmPassword);
        }
    }
}
