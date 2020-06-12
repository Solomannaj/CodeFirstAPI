namespace CodeFirstEntity.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class EmployeeEntity : DbContext
    {       
        public EmployeeEntity()
            : base("DefaultConnection")
        {
        }
        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }

        public DbSet<JobDetails> JobDetails { get; set; }      
    }

    public class EmployeeDetails
    {
        [Key]
        public int EmpID { get; set; }

        [ForeignKey("JobDetails")]
        public int EmployeeJobID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Address { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<decimal> Salary { get; set; }

        [StringLength(50)]
        public string worktype { get; set; }

        public virtual JobDetails JobDetails { get; set; }
    }

    public class JobDetails
    {   
        [Key]   
        public int JobID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [ForeignKey("JobType")]
        public int JobTypeRefID { get; set; }

        public virtual JobType JobType { get; set; }

        public virtual ICollection<EmployeeDetails> Employees { get; set; }

    }

    public class JobType
    {
        [Key]
        public int JobTypeID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<JobDetails> Jobs { get; set; }
    }

}