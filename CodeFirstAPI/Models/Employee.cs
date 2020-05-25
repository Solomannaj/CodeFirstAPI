using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstAPI.Models
{
    public class Employee
    {
        public int EmpID { get; set; }

        public int JobID { get; set; }

        public string Name { get; set; }
      
        public string Address { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<decimal> Salary { get; set; }
     
        public string worktype { get; set; }

        public Job JobDetails { get; set; }
    }
}