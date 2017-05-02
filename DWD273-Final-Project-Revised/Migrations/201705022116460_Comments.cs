namespace DWD273_Final_Project_Revised.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Comments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        message = c.String(),
                        relatedTopic = c.String(),
                        TicketID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tickets", t => t.TicketID, cascadeDelete: true)
                .Index(t => t.TicketID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "TicketID", "dbo.Tickets");
            DropIndex("dbo.Comments", new[] { "TicketID" });
            DropTable("dbo.Comments");
        }
    }
}
