namespace LibraryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookIssue_modelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookIssues",
                c => new
                    {
                        BookIssueId = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookIssueId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookIssues", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.BookIssues", "BookId", "dbo.Books");
            DropIndex("dbo.BookIssues", new[] { "CustomerId" });
            DropIndex("dbo.BookIssues", new[] { "BookId" });
            DropTable("dbo.BookIssues");
        }
    }
}
