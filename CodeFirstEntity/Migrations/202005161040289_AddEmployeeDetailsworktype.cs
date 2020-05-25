namespace CodeFirstEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeDetailsworktype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeDetails", "worktype", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeDetails", "worktype");
        }
    }
}
