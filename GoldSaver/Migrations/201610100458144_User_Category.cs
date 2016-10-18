namespace GoldSaver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User_Category : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User_Category",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.CategoryId })
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CategoryId);
            
            AddColumn("dbo.Categories", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Categories", "ApplicationUser_Id");
            AddForeignKey("dbo.Categories", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User_Category", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.User_Category", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.User_Category", new[] { "CategoryId" });
            DropIndex("dbo.User_Category", new[] { "UserId" });
            DropIndex("dbo.Categories", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Categories", "ApplicationUser_Id");
            DropTable("dbo.User_Category");
        }
    }
}
