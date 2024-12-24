﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsLoginRecord
    {
        public int ID { get; set; }
        public clsUser User { get; set; }
        public DateTime LoginTime { get; set; }
        public bool LoginStatus { get; set; }
        public string FailureReason { get; set; }

        public clsLoginRecord() 
        {
            this.ID = -1;
            this.User = null;
            this.LoginTime = DateTime.MinValue;
            this.LoginStatus = false;
            this.FailureReason = string.Empty;
        }

        private bool _AddNewLoginRecord()
        {
            this.ID = clsLoginRecordData.AddNewLoginRecord(this.User.ID, this.LoginTime, this.LoginStatus, this.FailureReason);
            return this.ID != -1;
        }

        public bool Save()
        {
            return _AddNewLoginRecord();    
        }

        public static DataTable GetAllLoginRecords()
        {
            return clsLoginRecordData.GetAllLoginRecords();
        }

    }
}