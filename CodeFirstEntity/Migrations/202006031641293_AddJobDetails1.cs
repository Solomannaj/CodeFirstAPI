﻿namespace CodeFirstEntity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobDetails1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobDetails", "JobType", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobDetails", "JobType");
        }
    }
}
