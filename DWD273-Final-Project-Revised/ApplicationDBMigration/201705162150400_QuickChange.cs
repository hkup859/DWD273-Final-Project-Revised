namespace DWD273_Final_Project_Revised.ApplicationDBMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuickChange : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
        }
    }
}
