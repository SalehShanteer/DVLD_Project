using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD
{
    public partial class frmManagePeople : Form
    {

        private DataView dvPeopleList;
        
        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void _RefreshPeopleList()
        {
            // Get the people list
            dvPeopleList = clsPerson.GetPeopleList().DefaultView;
            dgvPeopleList.DataSource = dvPeopleList;

            //Display number of records
            lblPeopleCount.Text = clsPerson.GetPeopleCount().ToString();
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleList();
        }

        private void _ShowPersonDetails()
        {
            if (dgvPeopleList.SelectedCells.Count > 0)
            {
                int SelectedPersonID = (int)dgvPeopleList.CurrentRow.Cells["Person ID"].Value;

                //Open person details form
                frmPersonDetails frm = new frmPersonDetails(SelectedPersonID);
                frm.ShowDialog();

                _RefreshPeopleList();
            }
        }

        private void _AddNewPerson()
        {
            //Open add/update person form
            frmAddUpdatePerson frm = new frmAddUpdatePerson(-1);
            frm.ShowDialog();

            _RefreshPeopleList();
        }

        private void _UpdatePerson()
        {
            if (dgvPeopleList.SelectedCells.Count > 0)
            {
                int SelectedPersonID = (int)dgvPeopleList.CurrentRow.Cells["Person ID"].Value;

                //Open add/update person form
                frmAddUpdatePerson frm = new frmAddUpdatePerson(SelectedPersonID);
                frm.ShowDialog();

                _RefreshPeopleList();
            }
        }

        private void _DeletePerson()
        {
            if (dgvPeopleList.SelectedCells.Count > 0)
            {
                int SelectedPersonID = (int)dgvPeopleList.CurrentRow.Cells["Person ID"].Value;

                if (MessageBox.Show(clsUtility.askForDeleteMessage("person", SelectedPersonID), "Delete?"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (clsPerson.Delete(SelectedPersonID))
                    {
                        MessageBox.Show(clsUtility.deleteMessage("person", SelectedPersonID), clsUtility.deleteTitle("Person")
                            , MessageBoxButtons.OK, MessageBoxIcon.Information);

                        _RefreshPeopleList();
                    }
                    else
                    {
                        MessageBox.Show(clsUtility.errorDeleteMessage, clsUtility.errorDeleteTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            _AddNewPerson();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowPersonDetails();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _AddNewPerson();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _UpdatePerson();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _DeletePerson();
        }
    }
}
