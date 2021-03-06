﻿using CodeFirstAPI.Interfaces;
using CodeFirstAPI.Models;
using CodeFirstEntity.Entities;
using CodeFirstEntity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstAPI.Classes
{
    public class EmployeeBL : IEmployeeBL
    {
        private IEmployeeDL _IEmployeeDL;

        public EmployeeBL(IEmployeeDL iEmployeeDL)
        {
            _IEmployeeDL= iEmployeeDL;
        }
        public void SaveEmployee(Employee emp)
        {
            JobDetails jb = null;
            if (emp.JobDetails != null)
            {
                jb = new JobDetails()
                {
                    JobID = emp.JobDetails.JobID,
                    Name = emp.JobDetails.Name
                };
            }
          

            EmployeeDetails empDet = new EmployeeDetails();

            empDet.EmpID = emp.EmpID;
            empDet.Name = emp.Name;
            empDet.Address = emp.Address;
            empDet.Age = emp.Age;
            empDet.Salary = emp.Salary;
            empDet.worktype = emp.worktype;
            empDet.JobDetails = jb;
            empDet.EmployeeJobID = emp.JobID;

            _IEmployeeDL.SaveEmployee(empDet);

        }

        public void EditEmployee(Employee emp)
        {
            JobDetails jb = null;
            if (emp.JobDetails != null)
            {
                jb = new JobDetails()
                {
                    JobID = emp.JobDetails.JobID,
                    Name = emp.JobDetails.Name
                };
            }


            EmployeeDetails empDet = new EmployeeDetails();

            empDet.EmpID = emp.EmpID;
            empDet.Name = emp.Name;
            empDet.Address = emp.Address;
            empDet.Age = emp.Age;
            empDet.Salary = emp.Salary;
            empDet.worktype = emp.worktype;
            empDet.JobDetails = jb;
            empDet.EmployeeJobID = emp.JobID;

            _IEmployeeDL.EditEmployee(empDet);

        }

        public List<Employee> GetEmployees()
        {

            List<EmployeeDetails> lstEmployees = _IEmployeeDL.GetEmployees();

            List<Employee> lstEmployeesObj = new List<Employee>();

            foreach (EmployeeDetails empl in lstEmployees)
            {
                Job jb = null;
                if (empl.JobDetails != null)
                {
                    jb = new Job()
                    {
                        JobID = empl.JobDetails.JobID,
                        Name = empl.JobDetails.Name
                    };
                }

                Employee emplObj = new Employee()
                {
                    EmpID = empl.EmpID,
                    Name = empl.Name,
                    Address = empl.Address,
                    Age = empl.Age,
                    Salary = empl.Salary,
                    worktype = empl.worktype,
                    JobDetails = jb,
                    JobID = empl.EmployeeJobID
                };

                lstEmployeesObj.Add(emplObj);
            }

            return lstEmployeesObj;
             
        }

        public List<Job> GetJobs()
        {

            List<JobDetails> lstEmployees = _IEmployeeDL.GetJobs();

            List<Job> lstEmployeesObj = new List<Job>();

            foreach (JobDetails empl in lstEmployees)
            {
             
                   var jb = new Job()
                    {
                        JobID = empl.JobID,
                        Name = empl.Name
                    };

                lstEmployeesObj.Add(jb);
            }

            return lstEmployeesObj;

        }

        public void DeleteEmployee(int empId)
        {            
            _IEmployeeDL.DeleteEmployee(empId);
        }

        public void SaveJob()
        {
            _IEmployeeDL.SaveJob();
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
