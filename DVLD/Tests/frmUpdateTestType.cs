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
    public partial class frmUpdateTestType : Form
    {
       
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
                MessageBox.Show(clsUtility.saveMessage("test type"), clsUtility.saveTitle("Test Type"), MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(clsUtility.askForSaveMessage("test type"), "Save?"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                _SaveTestType();
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
