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
                    EmployeeId = "1", 
                    EmployeeName = "Amin Ansari", 
                    Department = "Management",
                    Ext = "101",
                    ContactNumber = "0312-842-9631",
                    EmergencyContactNumber = "0312-842-9631",
                    Address = "Model Town" 
                },  
                new Employee()  
                {  
                    EmployeeId = "2", 
                    EmployeeName = "Nadeem Ahmed", 
                    Department = "Application Development",
                    Ext = "104",
                    ContactNumber = "0300-842-9631",
                    EmergencyContactNumber = "0300-842-9631",
                    Address = "Bahria Town" 
                },  
                new Employee()  
                {  
                    EmployeeId = "4", 
                    EmployeeName = "Shahid Ashraf", 
                    Department = "Application Support",
                    Ext = "129",
                    ContactNumber = "0321-842-9631",
                    EmergencyContactNumber = "0321-842-9631",
                    Address = "Bahria Town" 
                },  
                new Employee()  
                {  
                    EmployeeId = "3", 
                    EmployeeName = "Fawad Zia Qureshi", 
                    Department = "Quality Assurance",
                    Ext = "103",
                    ContactNumber = "0345-842-9631",
                    EmergencyContactNumber = "0345-842-9631",
                    Address = "BR Society" 
                },  
                new Employee()  
                {  
                    EmployeeId = "5", 
                    EmployeeName = "Muhammad Reza", 
                    Department = "Software Development",
                    Ext = "129",
                    ContactNumber = "0333-842-9631",
                    EmergencyContactNumber = "0333-842-9631",
                    Address = "Model Town Extension" 
                }  
        };
        public IList<Employee> GetAllEmployees()
        {
            //Return list of all employees  
            return employees;
        }
        public Employee GetEmployeeDetails(string id)
        {
            //Return a single employee detail  
            var employee = employees.FirstOrDefault(e => e.EmployeeId.Equals(id));
            if (employee == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return employee;
        }
    }
}
