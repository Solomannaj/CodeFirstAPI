namespace CodeFirstEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeDetailsEmployeeJobID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeDetails", "EmployeeJobID", c => c.Int(nullable: false));
            CreateIndex("dbo.EmployeeDetails", "EmployeeJobID");
            AddForeignKey("dbo.EmployeeDetails", "EmployeeJobID", "dbo.JobDetails", "JobID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeDetails", "EmployeeJobID", "dbo.JobDetails");
            DropIndex("dbo.EmployeeDetails", new[] { "EmployeeJobID" });
            DropColumn("dbo.EmployeeDetails", "EmployeeJobID");
        }
    }
}
