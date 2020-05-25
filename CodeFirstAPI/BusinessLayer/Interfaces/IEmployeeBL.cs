using CodeFirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEntity.Interfaces
{
   public interface IEmployeeBL
    {
        void SaveEmployee(Employee emp);

        void EditEmployee(Employee empDet);
        void SaveJob();

        List<Employee> GetEmployees();
        List<Job> GetJobs();

        void DeleteEmployee(int empId);
    }
}
