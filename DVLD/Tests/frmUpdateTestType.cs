using DVLD_Business;
using System;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmUpdateTestType : Form
    {

        // Define a delegate
        public delegate void UpdateTestTypeEventHandler(object sender, bool IsUpdated);

        // Define an event based on that delegate
        public event UpdateTestTypeEventHandler UpdateTestType;

        private int _TestTypeID;

        private clsTestType _TestType;
        
        public frmUpdateTestType(int TestTypeID)
        {
            InitializeComponent();

            _TestTypeID = TestTypeID;
        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _LoadTestTypeInfo();
        }

        private void _SetTestTypeInfo()
        {
            _TestType.Title = txtTitle.Text;
            _TestType.Description = rtxtDescription.Text;
            _TestType.Fees = Convert.ToInt16(txtFees.Text);
        }

        private void _SaveTestType()
        {
            _SetTestTypeInfo();

            if (_TestType.Save())
            {
                MessageBox.Show(clsUtility.saveMessage("test type"), clsUtility.saveTitle("Test Type")
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Raise the event
                UpdateTestType?.Invoke(this, IsUpdated : true);
            }
            else
            {
                MessageBox.Show(clsUtility.errorSaveMessage, clsUtility.errorSaveTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _DisplayTestTypeInfo()
        {
            lblID.Text = _TestType.ID.ToString();
            txtTitle.Text = _TestType.Title.ToString();
            rtxtDescription.Text = _TestType.Description.ToString();
            txtFees.Text = _TestType.Fees.ToString();
        }

        private void _LoadTestTypeInfo()
        {
            _TestType = clsTestType.Find(_TestTypeID);

            if (_TestType != null)
            {
                _DisplayTestTypeInfo();
            }
            else
            {
                MessageBox.Show(clsUtility.errorOpenFormMessag("update test type"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
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

        public bool _IsValidData()
        {
            bool IsValid = true;

            if (!_ValidateRequiredField(txtTitle, "title"))
            {
                IsValid = false;
            }
            if (!_ValidateRequiredField(txtFees, "fees"))
            {
                IsValid = false;
            }
            if (!_ValidateRequiredField(rtxtDescription, "description"))
            {
                IsValid = false;
            }

            return IsValid;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(clsUtility.askForSaveMessage("test type"), "Save?"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (_IsValidData())
                {
                    _SaveTestType();
                }
                else
                {
                    MessageBox.Show("Please enter the required data", "Error!"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
