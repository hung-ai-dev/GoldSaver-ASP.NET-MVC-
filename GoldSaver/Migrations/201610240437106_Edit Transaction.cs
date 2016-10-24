namespace GoldSaver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditTransaction : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Transactions", new[] { "Category_Id" });
            RenameColumn(table: "dbo.Transactions", name: "Category_Id", newName: "CategoryId");
            AlterColumn("dbo.Transactions", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "CategoryId");
            AddForeignKey("dbo.Transactions", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Transactions", new[] { "CategoryId" });
            AlterColumn("dbo.Transactions", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Transactions", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.Transactions", "Category_Id");
            AddForeignKey("dbo.Transactions", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
