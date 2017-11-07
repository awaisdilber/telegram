using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeDirectoryAPI.Models
{
    public class EmployeeInfo
    {
        public string EmployeeNo { get; set; }

        public string FullName { get; set; }

        public string FatherName { get; set; }

        public string CommonName { get; set; }

        public string Email { get; set; }

        public string OfficialEamil { get; set; }

        public string PersonalEmail { get; set; }

        public string ContactPhone { get; set; }

        public string Mobile { get; set; }

        public string Gender { get; set; }

        public string MaritalStatus { get; set; }

        public string Extension { get; set; }

        public string Department { get; set; }

        public string Designation { get; set; }

        public string DateOfBirth { get; set; }

        public string DateOfJoining { get; set; }

        public Boolean IsActive { get; set; }

        public string ProfilePicture { get; set; }

        public string CurrentStatus { get; set; }

        public string ReportingManager { get; set; }


    }
}