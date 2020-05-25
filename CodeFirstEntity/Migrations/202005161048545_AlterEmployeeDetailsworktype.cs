namespace CodeFirstEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterEmployeeDetailsworktype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeDetails", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.EmployeeDetails", "Address", c => c.String(maxLength: 200));
            AlterColumn("dbo.EmployeeDetails", "worktype", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeDetails", "worktype", c => c.String());
            AlterColumn("dbo.EmployeeDetails", "Address", c => c.String());
            AlterColumn("dbo.EmployeeDetails", "Name", c => c.String());
        }
    }
}
