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
    public partial class frmManageTestTypes : Form
    {

        private DataView dvTestTypesList;
        
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
            dvTestTypesList = clsTestType.GetTestTypesList().DefaultView;
            dgvTestTypesList.DataSource = dvTestTypesList;

            //Display number of records
            lblTestTypesCount.Text = clsTestType.GetTestTypesCount().ToString();
        }

        private void _UpdateTestType()
        {
            if (dgvTestTypesList.SelectedCells.Count > 0)
            {
                int SelectedTestTypeID = (int)dgvTestTypesList.CurrentRow.Cells["ID"].Value;

                frmUpdateTestType frm = new frmUpdateTestType(SelectedTestTypeID);
                frm.ShowDialog();

                _RefreshTestTypes();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _UpdateTestType();
        }
    }
}
