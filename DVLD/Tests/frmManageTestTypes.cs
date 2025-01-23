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
                    lblTestTypesCount.Text = clsTestType.GetTestTypesCount().ToString();
                }));
            });

            RefreshTestTypesThread.Start();
        }

        private void _UpdateTestType()
        {
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
