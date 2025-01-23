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
    public partial class frmLoginRecordsList : Form
    {

        private DataView _dvLoginRecordsList;

        public frmLoginRecordsList()
        {
            InitializeComponent();
        }

        private void frmLoginRecordsList_Load(object sender, EventArgs e)
        {
            _Refresh();
        }

        private void _Refresh()
        {
            cbxFilter.SelectedIndex = 0; // Filter default index at (None)

            _RefreshLoginRecords();
        }

        private void _RefreshLoginRecords()
        {
            _dvLoginRecordsList = clsLoginRecord.GetAllLoginRecords().DefaultView;
            dgvLoginRecordsList.DataSource = _dvLoginRecordsList;

            // Display login records count
            lblLoginRecordsCount.Text = clsLoginRecord.GetAllLoginCount().ToString();
        }

        private void _Filter()
        {
            string filterAttribute = cbxFilter.Text;
            string filter = txtFilter.Text.Trim();

            if ((filterAttribute == "None" || string.IsNullOrEmpty(filter)))
            {
                _dvLoginRecordsList.RowFilter = string.Empty;
            }
            else
            {
                if (filterAttribute == "User ID")
                {
                    _dvLoginRecordsList.RowFilter = $"[{filterAttribute}] = {filter}";
                }
               
                else
                {
                    _dvLoginRecordsList.RowFilter = $"[{filterAttribute}] LIKE '{filter}%'";
                }
            }
        }

      
        private void cbxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Text = string.Empty;

            if (cbxFilter.SelectedIndex == 0)
            {
                // Selected index at (none)
                txtFilter.Visible = false;
            }
            else
            {
                txtFilter.Visible = true;
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _Filter();
        }

        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            _Filter();
        }

        private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        {
            _Filter();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && cbxFilter.Text == "User ID")
            {
                e.Handled = true;// Ensure only digits allowed when L.D.L.AppID selected
            }
        }
    }
}
