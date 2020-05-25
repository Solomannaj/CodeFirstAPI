
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEntity.Interfaces
{
   public interface IEmployeeDL
    {
        void SaveEmployee(EmployeeDetails empDet);

        void EditEmployee(EmployeeDetails empDet);

        void SaveJob();
        List<EmployeeDetails> GetEmployees();

        List<JobDetails> GetJobs();

        void DeleteEmployee(int empId);
    }
}
