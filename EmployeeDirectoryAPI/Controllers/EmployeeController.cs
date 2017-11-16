using EmployeeDirectoryAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web.Http;

namespace EmployeeDirectoryAPI.Controllers
{
    public class EmployeeController : ApiController
    {        
        public IList<Employee> GetAllEmployees()
        {
            //Return list of all employees  
            IList<Employee> employees = new List<Employee>();

            employees = GetAllEmployeesThroughJSON();

            return employees;
        }

        private IList<Employee> GetAllEmployeesThroughJSON()
        {
            IList<Employee> employeeList = new List<Employee>();
            try
            {
                using (StreamReader r = new StreamReader(VirtualPathUtility.ToAppRelative("//EmployeeJSONData.json")))
                {
                    string json = r.ReadToEnd();
                    employeeList = JsonConvert.DeserializeObject<List<Employee>>(json);
                }
                
            }
            catch (Exception ex)
            {
                Employee emp = new Employee();
                emp.FullName = ex.Message;
                employeeList.Add(emp);
                //return new JsonException(ex.Message);
                //throw;
            }

            return employeeList;
            
        }
    }
}
