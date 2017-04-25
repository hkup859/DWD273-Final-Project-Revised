namespace DWD273_Final_Project_Revised.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Topics : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TopicDesc = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Tickets", "TopicID", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "TopicID");
            AddForeignKey("dbo.Tickets", "TopicID", "dbo.Topics", "ID", cascadeDelete: true);
            DropColumn("dbo.Tickets", "topic");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "topic", c => c.String());
            DropForeignKey("dbo.Tickets", "TopicID", "dbo.Topics");
            DropIndex("dbo.Tickets", new[] { "TopicID" });
            DropColumn("dbo.Tickets", "TopicID");
            DropTable("dbo.Topics");
        }
    }
}
