﻿using System;
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

        private enum enMode { AddNew = 0, Update = 1 }

        private enMode _Mode = enMode.AddNew;

        private int _PersonID;
        
        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;

            if (_PersonID != -1)
            {
                _Mode = enMode.Update;
            }
            else
            {
                _Mode = enMode.AddNew;
            }
        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _LoadPersonInfo();
        }

        private void _LoadPersonInfo()
        {
            if (_Mode == enMode.AddNew)
            {
                //Change the form title
                this.Text = "Add New Person";
                lblAddUpdatePerson.Text = "Add New Person";
            }
            else
            {             
                ctrlPersonManager1.DisplayPersonInfo(_PersonID);
               
                //Display the person ID
                lblPersonID.Text = _PersonID.ToString();

                //Change the form title
                this.Text = "Update Person";
                lblAddUpdatePerson.Text = "Update Person";

            }

        }

        private void ctrlPersonManager1_OnSavePersonComplete(int obj)
        {
            //Display the person ID
            lblPersonID.Text = obj.ToString();

            //Change the form title
            this.Text = "Update Person";
            lblAddUpdatePerson.Text = "Update Person";

            _Mode = enMode.Update;
        }

        private void ctrlPersonManager1_OnClose()
        {
            this.Close();
        }

      
    }
}
