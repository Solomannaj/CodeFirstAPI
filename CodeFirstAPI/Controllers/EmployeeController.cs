using CodeFirstEntity;
using CodeFirstEntity.Interfaces;
using CodeFirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CodeFirstAPI.Controllers
{
   
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        // GET api/Employee/GetEmployees
      
        [HttpGet]
        public List<Employee> GetEmployees()
        {

            IEmployeeBL cls = new EmployeeBL();
            
            return cls.GetEmployees();
        }

        [HttpGet]
        public List<Job> GetJobs()
        {

            IEmployeeBL cls = new EmployeeBL();

            return cls.GetJobs();
        }


        // POST api/Employee/SaveEmployee
        [HttpPost]
        public void SaveEmployee(Employee empDet)
        {
            IEmployeeBL cls = new EmployeeBL();
            cls.SaveEmployee(empDet);
        }

        [HttpPut]
        public void EditEmployee(Employee empDet)
        {
            IEmployeeBL cls = new EmployeeBL();
            cls.EditEmployee(empDet);
        }


        // DELETE api/Employee/5
        [HttpDelete]
        public void DeleteEmployee(int empID)
        {
            IEmployeeBL cls = new EmployeeBL();
            cls.DeleteEmployee(empID);
        }
    }
}
