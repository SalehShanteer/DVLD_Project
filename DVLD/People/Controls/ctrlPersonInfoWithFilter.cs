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
    public partial class ctrlPersonInfoWithFilter : UserControl
    {

        private clsPerson _Person;


        public delegate void DataBackEventHandler(object sender, clsPerson Person);

        public event DataBackEventHandler DataBack;

        // Define the event
        public event Action<int> OnFindPersonComplete;

        //Create method to raise event
        protected virtual void FindPersonComplete(int PersonID)
        {
            Action<int> handler = OnFindPersonComplete;

            if (OnFindPersonComplete != null)
            {
                handler(PersonID);
            }
        }

        public ctrlPersonInfoWithFilter()
        {
            InitializeComponent();
        }

        private void ctrlPersonInfoWithFilter_Load(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void _FindPerson()
        {
            int PersonID = -1;

            if (cbxFilters.SelectedIndex == 0)
            {
                // If national number selected
                string NationaNumber = txtFilter.Text;
                PersonID = clsPerson.GetPersonID(NationaNumber);
            }
            else
            {
                // If person ID selected
                if (int.TryParse(txtFilter.Text, out int ID))
                {
                    PersonID = ID;
                }
                else
                    return;
            }

            if (ctrlPersonInfo1.DisplayPersonInfoOutside(PersonID))
            {
                ctrlPersonInfo1.DataBack += ctrlPersonInfo_DataBack;// Subscribe the event

                DataBack?.Invoke(this, _Person);

                if (OnFindPersonComplete != null)
                {
                    OnFindPersonComplete(PersonID);
                }
            }
        }

        public void FindPersonFromOutside(int PersonID)
        {
            cbxFilters.SelectedIndex = 1; //Set comboBox at person ID

            txtFilter.Text = PersonID.ToString();

            _FindPerson();
        }

        public void DisableFilterFromOutside()
        {
            gbxFilter.Enabled = false;
        }

        private void _Refresh()
        {
            cbxFilters.SelectedIndex = 0;// Set default index for filter comboBox (National No.)
        }

        private void _AddNewPerson()
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(-1);
            frm.ShowDialog();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbxFilters.SelectedIndex == 1)
            {
                // Filter in person ID. 
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true; // Ensure only allowed digits
                }
            }
        }

        private void ctrlPersonInfo_DataBack(object sender, clsPerson Person)
        {
            _Person = Person;
        }

        private void cbxFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Clear();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            _FindPerson();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _AddNewPerson();
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Press Enter ==> Search
                e.SuppressKeyPress = true;
                _FindPerson();
            }
        }

    }
}
