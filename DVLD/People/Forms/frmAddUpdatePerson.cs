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
    public partial class frmAddUpdatePerson : Form
    {
        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {

        }

        private void ctrlPersonManager1_OnSavePersonComplete(int obj)
        {
            //Display the person ID
            lblPersonID.Text = obj.ToString();

            //Change the form title
            lblAddUpdatePerson.Text = "Update Person";
        }

        private void ctrlPersonManager1_OnClose()
        {
            this.Close();
        }
    }
}
