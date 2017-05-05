namespace DWD273_Final_Project_Revised.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timeCorrected : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "time", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "time", c => c.String());
        }
    }
}
