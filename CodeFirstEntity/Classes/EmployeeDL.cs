using CodeFirstEntity.Entities;
using CodeFirstEntity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CodeFirstEntity.Classes
{
    public class EmployeeDL : IEmployeeDL
    {
        public SqlConnection con;
        public EmployeeDL(SqlConnection _con)
        {
            con = _con;
        }

        public virtual void SaveEmployeeTest(EmployeeDetails empDet)
        {
            // SqlConnection con = new SqlConnection(@"Data Source=B283LCOK\SQLEXPRESS;Initial Catalog=EmployeeDB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SaveEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpName", empDet.Name);
            cmd.Parameters.AddWithValue("@EmpAddress", empDet.Address);
            cmd.Parameters.AddWithValue("@EmpAge", empDet.Age);
            cmd.Parameters.AddWithValue("@EmpJobID", empDet.EmployeeJobID);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void SaveEmployee(EmployeeDetails empDet)
        {
            var empContext = new EmployeeEntity();
            var jobObj = empContext.JobDetails.FirstOrDefault(x => x.JobID == empDet.EmployeeJobID);
            if (jobObj != null)
            {
                //jobObj.Name = empDet.JobDetails.Name;

                var empObj = empContext.EmployeeDetails.SingleOrDefault(x => x.Name == empDet.Name);
                if (empObj != null)
                {
                    empObj.Name = empDet.Name;
                    empObj.Address = empDet.Address;
                    empObj.Age = empDet.Age;
                    empObj.EmployeeJobID = jobObj.JobID;
                    // jobObj.Name = empDet.JobDetails.Name;

                }
                else
                {
                    empDet.EmployeeJobID = jobObj.JobID;
                    //  jobObj.Name = empDet.JobDetails.Name;
                    empDet.JobDetails = null;
                    empContext.EmployeeDetails.Add(empDet);
                }
            }
            else
            {
                var empObj = empContext.EmployeeDetails.SingleOrDefault(x => x.Name == empDet.Name);
                if (empObj != null)
                {
                    empObj.Name = empDet.Name;
                    empObj.Address = empDet.Address;
                    empObj.Age = empDet.Age;
                    empObj.JobDetails = empDet.JobDetails;
                }
                else
                {
                    empContext.EmployeeDetails.Add(empDet);
                }
            }

            empContext.SaveChanges();
        }

        public void EditEmployee(EmployeeDetails empDet)
        {
            EmployeeEntity empContext = new EmployeeEntity();

            var jobObj = empContext.JobDetails.FirstOrDefault(x => x.JobID == empDet.EmployeeJobID);
            if (jobObj != null)
            {
               // jobObj.Name = empDet.JobDetails.Name;

                var empObj = empContext.EmployeeDetails.SingleOrDefault(x => x.EmpID == empDet.EmpID);
                if (empObj != null)
                {
                    empObj.Name = empDet.Name;
                    empObj.Address = empDet.Address;
                    empObj.Age = empDet.Age;
                    empObj.EmployeeJobID = jobObj.JobID;
                  //  jobObj.Name = empDet.JobDetails.Name;

                }              
            }
            else
            {
                var empObj = empContext.EmployeeDetails.SingleOrDefault(x => x.EmpID == empDet.EmpID);
                if (empObj != null)
                {
                    empObj.Name = empDet.Name;
                    empObj.Address = empDet.Address;
                    empObj.Age = empDet.Age;
                    empObj.JobDetails = empDet.JobDetails;
                }               
            }

            empContext.SaveChanges();
        }

        public List<EmployeeDetails> GetEmployees()
        {
            EmployeeEntity empContext = new EmployeeEntity();
            return empContext.EmployeeDetails.ToList(); 
        }

        public List<JobDetails> GetJobs()
        {
            EmployeeEntity empContext = new EmployeeEntity();
            return empContext.JobDetails.ToList();
        }

        public void DeleteEmployee(int empId)
        {
           EmployeeEntity empContext = new EmployeeEntity();
           var emp= empContext.EmployeeDetails.Where(x => x.EmpID == empId).FirstOrDefault();
            empContext.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            empContext.SaveChanges();
        }

        public void SaveJob()
        {
            EmployeeEntity empContext = new EmployeeEntity();

         

            EmployeeDetails ed1 = new EmployeeDetails()
            {
                Name = "Ardhra",
                Address = "Bla bla",
                Age = 29,
                Salary = 20000
                
            };

            EmployeeDetails ed2 = new EmployeeDetails()
            {
                Name = "Jwala",
                Address = "Bla bla",
                Age = 29,
                Salary = 20000               
            };

            List<EmployeeDetails> lstempl = new List<EmployeeDetails>();
            lstempl.Add(ed1); lstempl.Add(ed2);

            JobDetails jb = new JobDetails()
            {
                Name = "Part-Time",
                Employees= lstempl
            };

       

            empContext.JobDetails.Add(jb);
            empContext.SaveChanges();
        }

        //JobDetails jb = new JobDetails()
        //{
        //    Name = "Fultime"
        //};

        //EmployeeDetails ed = new EmployeeDetails()
        //{
        //    Name = "Devan",
        //    Address = "Bla bla",
        //    Age = 29,
        //    Salary = 20000,
        //    JobDetails = jb
        //};
    }
}
