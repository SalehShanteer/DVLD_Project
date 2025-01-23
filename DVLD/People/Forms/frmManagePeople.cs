using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using DVLD_Business;

namespace DVLD
{
    public partial class frmManagePeople : Form
    {

        private DataView _dvPeopleList;

        private short _PageNumber = 1;

        private short _NumberOfPages = 1;

        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void _Refresh()
        {
            _RefreshPeopleList();

            cbxFilter.SelectedIndex = 0; // Set default index at (None)
        }

        private void _RefreshPeopleList()
        {
            // Get the people list
            _PageNumber = 1;
            _ShowPage(_PageNumber);

            //Display number of records
            lblPeopleCount.Text = clsPerson.GetPeopleCount().ToString();
            lblPageNumber.Text = "1";

            _DisplayNumberOfPages();
        }

        private void _DisplayNumberOfPages()
        {
            _NumberOfPages = (short)Math.Ceiling((float)clsPerson.GetPeopleCount() / clsSettings.peopleListRowsPerPage);
            lblNumberOfPages.Text = _NumberOfPages.ToString();
        }

        private void _DisplayNumberOfFilteredPages()
        {
            string FilterAttribute = cbxFilter.Text;
            string Filter = txtFilter.Text;

            _NumberOfPages = (short)Math.Ceiling((float)clsPerson.GetFilteredPeopleCount(FilterAttribute, Filter) / clsSettings.peopleListRowsPerPage);
            lblNumberOfPages.Text = _NumberOfPages.ToString();
        }

        private void _ShowPage(short PageNumber)
        {
            Thread GetPeopleListThread = new Thread(() =>
            {
                _dvPeopleList = clsPerson.GetPeopleListPerPage(PageNumber, clsSettings.peopleListRowsPerPage).DefaultView;

                // To ensure that the data grid view is updated from the main thread
                this.Invoke(new Action(() => { dgvPeopleList.DataSource = _dvPeopleList; }));
            });
       
            GetPeopleListThread.Start();
        }

        private void _DisplayPeopleListPageWithFilter(short PageNumber, string FilterAttribute, string Filter)
        {
            Thread GetPeopleListThread = new Thread(() =>
            {
                _dvPeopleList = clsPerson.GetPeopleListPerPageWithFilter(PageNumber
                    , clsSettings.peopleListRowsPerPage, FilterAttribute, Filter).DefaultView;

                this.Invoke(new Action(() => { dgvPeopleList.DataSource = _dvPeopleList; }));
            });
        }

        private void _ShowFilteredPage(short PageNumber)
        {
            string FilterAttribute = cbxFilter.Text;
            string Filter = txtFilter.Text;

            _DisplayPeopleListPageWithFilter(PageNumber, FilterAttribute, Filter);
        }

        private void _Search()
        {
            _ShowFilteredPage(1);

            lblPageNumber.Text = "1";

            _DisplayNumberOfFilteredPages();
        }


        // Managing People
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

            frm.SavePerson += (sender, IsSaved) =>
            {
                _RefreshPeopleList(); // Refresh the people list after saving the new person
            };

            frm.ShowDialog();
        }

        private void _UpdatePerson()
        {
            if (dgvPeopleList.SelectedCells.Count > 0)
            {
                int SelectedPersonID = (int)dgvPeopleList.CurrentRow.Cells["Person ID"].Value;

                //Open add/update person form
                frmAddUpdatePerson frm = new frmAddUpdatePerson(SelectedPersonID);

                frm.SavePerson += (sender, IsSaved) =>
                {
                    _RefreshPeopleList(); // Refresh the people list after saving the new person
                };

                frm.ShowDialog();
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

        private void btnNextPage_Click(object sender, EventArgs e)
        {

            if (_PageNumber < _NumberOfPages)
            {
                _PageNumber++;

                // Change Page number lable
                lblPageNumber.Text = _PageNumber.ToString();
                if (cbxFilter.SelectedIndex == 0 || string.IsNullOrWhiteSpace(txtFilter.Text))
                {
                    _ShowPage(_PageNumber);
                }
                else
                {
                    _ShowFilteredPage(_PageNumber);
                }            
            }
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (_PageNumber > 1)
            {
                _PageNumber--;

                // Change Page number lable
                lblPageNumber.Text = _PageNumber.ToString();

                if (cbxFilter.SelectedIndex == 0 || string.IsNullOrWhiteSpace(txtFilter.Text))
                {
                    _ShowPage(_PageNumber);
                }
                else
                {
                    _ShowFilteredPage(_PageNumber);
                }
            }
        }

        private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Clear(); 

            if (cbxFilter.SelectedIndex != 0)
            {
                // If any thing selected except none is selected
                txtFilter.Visible = true;
                btnSearch.Visible = true;
            }
            else
            {
                // If none is selected
                txtFilter.Visible = false;
                btnSearch.Visible = false;
                _RefreshPeopleList();
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbxFilter.SelectedIndex == 1 && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ensure only digits allowed when person ID selected
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                _Search();
            }
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;// Prevent the annoying beep sound

                btnSearch_Click(sender, e); // Call the search button click event
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                _RefreshPeopleList();
            }
        }
    }
}
