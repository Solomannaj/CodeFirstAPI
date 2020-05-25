namespace CodeFirstEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeDetails",
                c => new
                    {
                        EmpID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Age = c.Int(),
                        Salary = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.EmpID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeeDetails");
        }
    }
}
