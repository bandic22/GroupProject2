namespace AuctionWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bids", "Item_Id", "dbo.Items");
            DropIndex("dbo.Bids", new[] { "Item_Id" });
            RenameColumn(table: "dbo.Bids", name: "Item_Id", newName: "ItemId");
            AlterColumn("dbo.Bids", "ItemId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bids", "ItemId");
            AddForeignKey("dbo.Bids", "ItemId", "dbo.Items", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bids", "ItemId", "dbo.Items");
            DropIndex("dbo.Bids", new[] { "ItemId" });
            AlterColumn("dbo.Bids", "ItemId", c => c.Int());
            RenameColumn(table: "dbo.Bids", name: "ItemId", newName: "Item_Id");
            CreateIndex("dbo.Bids", "Item_Id");
            AddForeignKey("dbo.Bids", "Item_Id", "dbo.Items", "Id");
        }
    }
}
