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
    public partial class frmPersonDetails : Form
    {

        private int _PersonID;

        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;   
        }     

        private void frmPersonInfo_Load(object sender, EventArgs e)
        {
            _LoadPersonInfo();
        }

        private void _LoadPersonInfo()
        {
            ctrlPersonInfo1.DisplayPersonInfoOutside(_PersonID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
