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
    public partial class ctrlDriverLicenseInfoWithFilter : UserControl
    {

        // Define Event
        public event Action<int> OnFindLicenseComplete;

        // Create method to raise event
        protected virtual void FindLicenseComplete(int LicenseID)
        {
            Action<int> handler = OnFindLicenseComplete;

            if (handler != null)
            {
                handler(LicenseID);
            }
        }
        
        public ctrlDriverLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        public void DisableFilterFromOutside()
        {
            gbFilter.Enabled = false;
        }

        public void DisplayLicenseInfoFromOutside(int LicenseID)
        {
            txtLicenseID.Text = LicenseID.ToString();
            _SearchForLicense();
        }

        private void _SearchForLicense()
        {
            int LicenseID = Convert.ToInt32(txtLicenseID.Text);
            if (clsLicense.IsExist(LicenseID))
            {
                ctrlDriverLicenseInfo1.DisplayLicenseInfoFromOutside(LicenseID);

                OnFindLicenseComplete?.Invoke(LicenseID);
            }
            else
            {
                MessageBox.Show($"License with ID = {LicenseID} not found!", "Wrong!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLicenseSearch_Click(object sender, EventArgs e)
        {
            _SearchForLicense();
        }

        private void txtLicenseID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Press Enter ==> Search
                e.SuppressKeyPress = true;
                _SearchForLicense();
            }
        }

        private void txtLicenseID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ensure only allowed digits
            }
        }

    }
}
