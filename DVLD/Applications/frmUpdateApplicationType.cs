using DVLD_Business;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmUpdateApplicationType : Form
    {
        // Declare delegate
        public delegate void IsUpdatedEventHandler(object sender, bool IsUpdated);

        // Declare event using event
        public event IsUpdatedEventHandler IsUpdated;

        private int _ApplicationTypeID;

        private clsApplicationType _ApplicationType;
        
        public frmUpdateApplicationType(int ApplicationTypeID)
        {
            InitializeComponent();

            _ApplicationTypeID = ApplicationTypeID;
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            _LoadApplicationTypeInfo();
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
            bool IsValid = true;

            if (!_ValidateRequiredField(txtTitle, "title"))
            {
                IsValid = false;
            }

            if (!_ValidateRequiredField(txtFees, "fees"))
            {
                IsValid = false;
            }

            return IsValid;
        }

        private void _SetApplicationTypeInfo()
        {
            _ApplicationType.Title = txtTitle.Text;
            _ApplicationType.Fees = Convert.ToInt16(txtFees.Text);
        }

        private void _SaveApplicationType()
        {
            _SetApplicationTypeInfo();

            if (_ApplicationType.Save())
            {
                MessageBox.Show(clsUtility.saveMessage("application type"), clsUtility.saveTitle("Application type")
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Raise event showing that the application type is updated
                IsUpdated?.Invoke(this, IsUpdated : true);
            }
            else
            {
                MessageBox.Show(clsUtility.errorSaveMessage, clsUtility.errorSaveTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void _DisplayApplicationTypeInfo()
        {
            lblID.Text = _ApplicationType.ID.ToString();
            txtTitle.Text = _ApplicationType.Title;
            txtFees.Text = _ApplicationType.Fees.ToString();
        }

        private void _LoadApplicationTypeInfo()
        {
            _ApplicationType = clsApplicationType.Find(_ApplicationTypeID);

            if (_ApplicationType != null)
            {
                _DisplayApplicationTypeInfo();
            }
            else
            {
                MessageBox.Show(clsUtility.errorOpenFormMessag("update application type"), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(clsUtility.askForSaveMessage("application type"), "Save?"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (_IsValidData())
                {
                    _SaveApplicationType();
                }
                else
                {
                    MessageBox.Show("Please enter the required data", "Error!"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       
    }
}
