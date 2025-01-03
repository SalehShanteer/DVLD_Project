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
    public partial class frmManageApplicationTypes : Form
    {
        
        private DataView dvApplicationTypes;
        
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
            dvApplicationTypes = clsApplicationType.GetApplicationTypesList().DefaultView;
            dgvApplicationTypesList.DataSource = dvApplicationTypes;

            //Display number of records
            dgvApplicationTypesList.Text = clsApplicationType.GetApplicationTypesCount().ToString();
        }

        private void _UpdateApplicationType()
        {
            if (dgvApplicationTypesList.SelectedCells.Count > 0)
            {
                int SelectedApplicationTypeID = (int)dgvApplicationTypesList.CurrentRow.Cells["ID"].Value;

                frmUpdateApplicationType frm = new frmUpdateApplicationType(SelectedApplicationTypeID);
                frm.ShowDialog();

                _RefreshApplicationTypes();
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
