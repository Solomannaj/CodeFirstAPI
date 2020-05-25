namespace CodeFirstEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobDetails",
                c => new
                    {
                        JobID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.JobID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.JobDetails");
        }
    }
}
