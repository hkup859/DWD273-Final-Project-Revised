namespace DWD273_Final_Project_Revised.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Time : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "time", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "time");
        }
    }
}
