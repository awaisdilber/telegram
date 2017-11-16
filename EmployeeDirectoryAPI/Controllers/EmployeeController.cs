using EmployeeDirectoryAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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

            using (StreamReader r = new StreamReader(System.AppDomain.CurrentDomain.BaseDirectory + "/EmployeeJSONData.json"))
            {
                string json = r.ReadToEnd();
                employeeList = JsonConvert.DeserializeObject<List<Employee>>(json);
            }

            return employeeList;
        }
    }
}
