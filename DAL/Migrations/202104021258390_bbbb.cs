namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bbbb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductReviews",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        productID = c.Int(nullable: false),
                        userID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.productID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.userID)
                .Index(t => t.productID)
                .Index(t => t.userID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductReviews", "userID", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductReviews", "productID", "dbo.Products");
            DropIndex("dbo.ProductReviews", new[] { "userID" });
            DropIndex("dbo.ProductReviews", new[] { "productID" });
            DropTable("dbo.ProductReviews");
        }
    }
}
