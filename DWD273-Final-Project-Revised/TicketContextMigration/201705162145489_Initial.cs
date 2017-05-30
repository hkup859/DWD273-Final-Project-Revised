namespace DWD273_Final_Project_Revised.TicketContextMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                        time = c.String(),
                        relatedTopic = c.String(),
                        TicketID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Tickets", t => t.TicketID, cascadeDelete: true)
                .Index(t => t.TicketID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        message = c.String(),
                        submitTime = c.DateTime(nullable: false),
                        resolved = c.Boolean(nullable: false),
                        TopicID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Topics", t => t.TopicID, cascadeDelete: true)
                .Index(t => t.TopicID);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TopicDesc = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "TopicID", "dbo.Topics");
            DropForeignKey("dbo.Comments", "TicketID", "dbo.Tickets");
            DropIndex("dbo.Tickets", new[] { "TopicID" });
            DropIndex("dbo.Comments", new[] { "TicketID" });
            DropTable("dbo.Topics");
            DropTable("dbo.Tickets");
            DropTable("dbo.Comments");
        }
    }
}
