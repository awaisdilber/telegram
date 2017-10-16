using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeDirectoryAPI.Models
{
    public class Employee
    {
        public string EmployeeId
        {
            get;
            set;
        }
        public string EmployeeName
        {
            get;
            set;
        }
        public string Department
        {
            get;
            set;
        }
        public string Ext
        {
            get;
            set;
        }
        public string ContactNumber
        {
            get;
            set;
        }
        public string EmergencyContactNumber
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
    }
}