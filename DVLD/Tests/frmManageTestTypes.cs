using DVLD_Business;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmManageTestTypes : Form
    {

        private DataView _dvTestTypesList;
        
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void _Refresh()
        {
            _RefreshTestTypes();
        }

        private void _RefreshTestTypes()
        {
            Thread RefreshTestTypesThread = new Thread(() =>
            {
                _dvTestTypesList = clsTestType.GetTestTypesList().DefaultView;

                // To ensure that the data grid view is updated from the main thread
                this.Invoke(new Action(() =>
                {
                    dgvTestTypesList.DataSource = _dvTestTypesList;
                    //Display number of records
                    int TestTypesCount = clsTestType.GetTestTypesCount();
                    lblTestTypesCount.Text = TestTypesCount.ToString();

                    // If there are records
                    if (TestTypesCount > 0)
                    {
                        _PrepareApplicationList();
                    }

                }));
            });

            RefreshTestTypesThread.Start();
        }

        private void _PrepareApplicationList()
        {
            //Adjust columns widths
            dgvTestTypesList.Columns["ID"].Width = 40;
            dgvTestTypesList.Columns["Title"].Width = 170;
            dgvTestTypesList.Columns["Description"].Width = 405;
            dgvTestTypesList.Columns["Fees"].Width = 45;
        }

        private void _UpdateTestType()
        {
            if (!clsSettings.CheckPermission((int)clsSettings.enTestPermissions.UpdateTestInfo))
            {
                MessageBox.Show(clsUtility.errorPermissionMessage, clsUtility.errorPermissionTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dgvTestTypesList.SelectedCells.Count > 0)
            {
                int SelectedTestTypeID = (int)dgvTestTypesList.CurrentRow.Cells["ID"].Value;

                frmUpdateTestType frm = new frmUpdateTestType(SelectedTestTypeID);

                frm.UpdateTestType += (sender, IsUpdated) =>
                {
                    if (IsUpdated)
                    {
                        _RefreshTestTypes();
                    }
                };

                frm.ShowDialog();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _UpdateTestType();
        }
    }
}
