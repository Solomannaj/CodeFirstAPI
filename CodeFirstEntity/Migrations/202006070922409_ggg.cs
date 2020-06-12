namespace CodeFirstEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ggg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobTypes",
                c => new
                    {
                        JobTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.JobTypeID);
            
            AddColumn("dbo.JobDetails", "JobTypeRefID", c => c.Int(nullable: false));
            CreateIndex("dbo.JobDetails", "JobTypeRefID");
            AddForeignKey("dbo.JobDetails", "JobTypeRefID", "dbo.JobTypes", "JobTypeID", cascadeDelete: true);
            DropColumn("dbo.JobDetails", "JobType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobDetails", "JobType", c => c.String(maxLength: 50));
            DropForeignKey("dbo.JobDetails", "JobTypeRefID", "dbo.JobTypes");
            DropIndex("dbo.JobDetails", new[] { "JobTypeRefID" });
            DropColumn("dbo.JobDetails", "JobTypeRefID");
            DropTable("dbo.JobTypes");
        }
    }
}
