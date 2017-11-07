using EmployeeDirectoryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeDirectoryAPI.Controllers
{
    public class EmployeeController : ApiController
    {        
        IList<Employee> employees = new List<Employee>()  
        {  
            //new Employee()  
            //    {  
            //        EmployeeId = "1", 
            //        EmployeeName = "Amin Ansari", 
            //        Department = "Management",
            //        Ext = "101",
            //        ContactNumber = "0312-842-9631",
            //        EmergencyContactNumber = "0312-842-9631",
            //        Address = "Model Town" 
            //    },  
            //    new Employee()  
            //    {  
            //        EmployeeId = "2", 
            //        EmployeeName = "Nadeem Ahmed", 
            //        Department = "Application Development",
            //        Ext = "104",
            //        ContactNumber = "0300-842-9631",
            //        EmergencyContactNumber = "0300-842-9631",
            //        Address = "Bahria Town" 
            //    },  
            //    new Employee()  
            //    {  
            //        EmployeeId = "4", 
            //        EmployeeName = "Shahid Ashraf", 
            //        Department = "Application Support",
            //        Ext = "129",
            //        ContactNumber = "0321-842-9631",
            //        EmergencyContactNumber = "0321-842-9631",
            //        Address = "Bahria Town" 
            //    },  
            //    new Employee()  
            //    {  
            //        EmployeeId = "3", 
            //        EmployeeName = "Fawad Zia Qureshi", 
            //        Department = "Quality Assurance",
            //        Ext = "103",
            //        ContactNumber = "0345-842-9631",
            //        EmergencyContactNumber = "0345-842-9631",
            //        Address = "BR Society" 
            //    },  
            //    new Employee()  
            //    {  
            //        EmployeeId = "5", 
            //        EmployeeName = "Muhammad Reza", 
            //        Department = "Software Development",
            //        Ext = "129",
            //        ContactNumber = "0333-842-9631",
            //        EmergencyContactNumber = "0333-842-9631",
            //        Address = "Model Town Extension" 
            //    }  
        };
        public IList<EmployeeInfo> GetAllEmployees()
        {
            //Return list of all employees  
            //return employees;

            List<EmployeeInfo> employees = new List<EmployeeInfo>();

            using (var context = new EmployeeDirectoryEntities())
            {
                var dbEmployees = context.Employees.Where(x => x.IsActive == true).ToList();

                foreach (var employee in dbEmployees)
                {
                    employees.Add(new EmployeeInfo() {
                        EmployeeNo = employee.EmployeeNo,
                        FullName = employee.FullName,
                        CommonName = employee.CommonName,
                        FatherName = employee.FatherName,
                        ContactPhone = employee.ContactPhone,
                        Email = employee.Email,
                        PersonalEmail = employee.PersonalEmail,
                        OfficialEamil = employee.OfficialEmail,
                        Mobile = employee.Mobile,
                        Extension = employee.Ext,
                        Gender = employee.Gender,
                        DateOfBirth = employee.DateofBirth.HasValue ? employee.DateofBirth.Value.ToShortDateString() : string.Empty,
                        DateOfJoining = employee.JoiningDate.HasValue ? employee.JoiningDate.Value.ToShortDateString() : string.Empty,
                        IsActive = employee.IsActive.HasValue ? employee.IsActive.Value : false,
                    });
                }
            }

            return employees;
        }
        public EmployeeInfo GetEmployeeDetails(string id)
        {
            //Return a single employee detail  
            EmployeeInfo result = new EmployeeInfo();
            Employee employee = employees.FirstOrDefault();

            using (var context = new EmployeeDirectoryEntities())
            {
                employee = context.Employees.Where(x => x.EmployeeNo == id).FirstOrDefault();
                if (employee != null)
                {
                    result.EmployeeNo = employee.EmployeeNo;
                    result.FullName = employee.FullName;
                    result.CommonName = employee.CommonName;
                    result.FatherName = employee.FatherName;
                    result.ContactPhone = employee.ContactPhone;
                    result.Email = employee.Email;
                    result.PersonalEmail = employee.PersonalEmail;
                    result.OfficialEamil = employee.OfficialEmail;
                    result.Mobile = employee.Mobile;
                    result.Extension = employee.Ext;
                    result.Gender = employee.Gender;
                    result.DateOfBirth = employee.DateofBirth.HasValue ? employee.DateofBirth.Value.ToShortDateString() : string.Empty;
                    result.DateOfJoining = employee.JoiningDate.HasValue ? employee.JoiningDate.Value.ToShortDateString() : string.Empty;
                    result.IsActive = employee.IsActive.HasValue ? employee.IsActive.Value : false;
                }
            }

            if (employee == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return result;
        }
    }
}
