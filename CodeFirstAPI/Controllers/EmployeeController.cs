using CodeFirstAPI.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using CodeFirstAPI.Interfaces;


namespace CodeFirstAPI.Controllers
{
   
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        // GET api/Employee/GetEmployees
        private IEmployeeBL _IEmployeeBL;

        public EmployeeController(IEmployeeBL iEmployeeBL)
        {
            _IEmployeeBL = iEmployeeBL;
        }

        [HttpGet]
        public List<Employee> GetEmployees()
        {
            
            return _IEmployeeBL.GetEmployees();
        }

        [HttpGet]
        public List<Job> GetJobs()
        {

            return _IEmployeeBL.GetJobs();
        }


        // POST api/Employee/SaveEmployee
        [HttpPost]
        public void SaveEmployee(Employee empDet)
        {            
            _IEmployeeBL.SaveEmployee(empDet);
        }

        [HttpPut]
        public void EditEmployee(Employee empDet)
        {
            _IEmployeeBL.EditEmployee(empDet);
        }


        // DELETE api/Employee/5
        [HttpDelete]
        public void DeleteEmployee(int empID)
        {           
            _IEmployeeBL.DeleteEmployee(empID);
        }
    }
}
