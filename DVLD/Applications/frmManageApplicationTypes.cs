using DVLD_Business;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmManageApplicationTypes : Form
    {
        
        private DataView _dvApplicationTypes;
        
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void _Refresh()
        {
            _RefreshApplicationTypes();
        }

        private void _RefreshApplicationTypes()
        {
            Thread RefreshApplicationTypesThread = new Thread(() =>
            {
                _dvApplicationTypes = clsApplicationType.GetApplicationTypesList().DefaultView;

                // To ensure that the data grid view is updated from the main thread
                this.Invoke(new Action(() =>
                {
                    dgvApplicationTypesList.DataSource = _dvApplicationTypes;

                    //Display number of records
                    int ApplicationTypesCount = clsApplicationType.GetApplicationTypesCount();
                    lblApplicationTypesCount.Text = ApplicationTypesCount.ToString();

                    // If there are records
                    if (ApplicationTypesCount > 0)
                    {
                        _PrepareApplicationList();
                    }
                }));

            });

            RefreshApplicationTypesThread.Start();
        }

        private void _PrepareApplicationList()
        {
            //Adjust columns widths
            dgvApplicationTypesList.Columns["ID"].Width = 50;
            dgvApplicationTypesList.Columns["Title"].Width = 350;
            dgvApplicationTypesList.Columns["Fees"].Width = 50;
        }

        private void _UpdateApplicationType()
        {
            if (dgvApplicationTypesList.SelectedCells.Count > 0)
            {
                int SelectedApplicationTypeID = (int)dgvApplicationTypesList.CurrentRow.Cells["ID"].Value;

                frmUpdateApplicationType frm = new frmUpdateApplicationType(SelectedApplicationTypeID);

                frm.IsUpdated += (sender, IsUpdated) =>
                {

                    if (IsUpdated)
                    {
                        _RefreshApplicationTypes(); // Refresh if the application updated
                    }
                };

                frm.ShowDialog();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _UpdateApplicationType();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
