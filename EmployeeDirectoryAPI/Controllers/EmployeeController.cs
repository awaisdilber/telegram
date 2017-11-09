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
            new Employee()  
                {  
                    EmployeeID = 1, 
                    FullName = "Amin Ansari", 
                    DepartmentID = 1,
                    Ext = "101",
                    Mobile = "0312-842-9631",
                    ContactPhone = "0312-842-9631",
                    Address = "Model Town" 
                },  
                new Employee()  
                {  
                    EmployeeID = 2, 
                    FullName = "Nadeem Ahmed", 
                    DepartmentID = 1,
                    Ext = "104",
                    Mobile = "0300-842-9631",
                    ContactPhone = "0300-842-9631",
                    Address = "Bahria Town" 
                },  
                new Employee()  
                {  
                    EmployeeID = 4, 
                    FullName = "Shahid Ashraf", 
                    DepartmentID = 1,
                    Ext = "129",
                    Mobile = "0321-842-9631",
                    ContactPhone = "0321-842-9631",
                    Address = "Bahria Town" 
                },  
                new Employee()  
                {  
                    EmployeeID = 3, 
                    FullName = "Fawad Zia Qureshi", 
                    DepartmentID = 1,
                    Ext = "103",
                    Mobile = "0345-842-9631",
                    ContactPhone = "0345-842-9631",
                    Address = "BR Society" 
                },  
                new Employee()  
                {  
                    EmployeeID = 5, 
                    FullName = "Muhammad Reza", 
                    DepartmentID = 1,
                    Ext = "129",
                    Mobile = "0333-842-9631",
                    ContactPhone = "0333-842-9631",
                    Address = "Model Town Extension" 
                },
                new Employee()  
                {  
                    EmployeeID = 87, 
                    FullName = "Awais Dilber", 
                    DepartmentID = 1,
                    Ext = "101",
                    Mobile = "0312-842-9631",
                    ContactPhone = "0312-842-9631",
                    Address = "Model Town" 
                },  
                new Employee()  
                {  
                    EmployeeID = 101, 
                    FullName = "Muhammad Yasin", 
                    DepartmentID = 1,
                    Ext = "104",
                    Mobile = "0300-842-9631",
                    ContactPhone = "0300-842-9631",
                    Address = "Bahria Town" 
                },  
                new Employee()  
                {  
                    EmployeeID = 44, 
                    FullName = "Nayyar Raza Malhi Longest Name In App", 
                    DepartmentID = 1,
                    Ext = "129",
                    Mobile = "0321-842-9631",
                    ContactPhone = "0321-842-9631",
                    Address = "Bahria Town" 
                },  
                new Employee()  
                {  
                    EmployeeID = 33, 
                    FullName = "Raheel Abbas", 
                    DepartmentID = 1,
                    Ext = "103",
                    Mobile = "0345-842-9631",
                    ContactPhone = "0345-842-9631",
                    Address = "BR Society" 
                },  
                new Employee()  
                {  
                    EmployeeID = 55, 
                    FullName = "Muhammad Zain Sheikh", 
                    DepartmentID = 1,
                    Ext = "129",
                    Mobile = "0333-842-9631",
                    ContactPhone = "0333-842-9631",
                    Address = "Model Town Extension" 
                }  
        };
        public IList<Employee> GetAllEmployees()
        {
            //Return list of all employees  
            return employees;

            //List<EmployeeInfo> employees = new List<EmployeeInfo>();

            //using (var context = new EmployeeDirectoryEntities())
            //{
            //    var dbEmployees = context.Employees.Where(x => x.IsActive == true).ToList();

            //    foreach (var employee in dbEmployees)
            //    {
            //        employees.Add(new EmployeeInfo() {
            //            EmployeeNo = employee.EmployeeNo,
            //            FullName = employee.FullName,
            //            CommonName = employee.CommonName,
            //            FatherName = employee.FatherName,
            //            ContactPhone = employee.ContactPhone,
            //            Email = employee.Email,
            //            PersonalEmail = employee.PersonalEmail,
            //            OfficialEamil = employee.OfficialEmail,
            //            Mobile = employee.Mobile,
            //            Extension = employee.Ext,
            //            Gender = employee.Gender,
            //            DateOfBirth = employee.DateofBirth.HasValue ? employee.DateofBirth.Value.ToShortDateString() : string.Empty,
            //            DateOfJoining = employee.JoiningDate.HasValue ? employee.JoiningDate.Value.ToShortDateString() : string.Empty,
            //            IsActive = employee.IsActive.HasValue ? employee.IsActive.Value : false,
            //        });
            //    }
            //}

            //return employees;
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
