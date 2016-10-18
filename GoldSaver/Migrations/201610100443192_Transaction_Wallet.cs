namespace GoldSaver.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transaction_Wallet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        WalletId = c.Int(nullable: false),
                        Cost = c.Single(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Note = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Wallets", t => t.WalletId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.WalletId)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Wallets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "WalletId", "dbo.Wallets");
            DropForeignKey("dbo.Wallets", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Transactions", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Transactions", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Wallets", new[] { "UserId" });
            DropIndex("dbo.Transactions", new[] { "Category_Id" });
            DropIndex("dbo.Transactions", new[] { "WalletId" });
            DropIndex("dbo.Transactions", new[] { "UserId" });
            DropTable("dbo.Wallets");
            DropTable("dbo.Categories");
            DropTable("dbo.Transactions");
        }
    }
}
