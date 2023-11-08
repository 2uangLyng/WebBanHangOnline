namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateActive : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_Posts", "Category_Id", "dbo.tb_Category");
            DropIndex("dbo.tb_Posts", new[] { "Category_Id" });
            DropColumn("dbo.tb_Posts", "CategoryID");
            DropColumn("dbo.tb_Posts", "CategoryId");
            RenameColumn(table: "dbo.tb_Posts", name: "Category_Id", newName: "CategoryID");
            AlterColumn("dbo.tb_Posts", "Alias", c => c.String());
            AlterColumn("dbo.tb_Posts", "Image", c => c.String());
            AlterColumn("dbo.tb_Posts", "SeoTitle", c => c.String());
            AlterColumn("dbo.tb_Posts", "SeoDiscription", c => c.String());
            AlterColumn("dbo.tb_Posts", "SeoKeywords", c => c.String());
            AlterColumn("dbo.tb_Posts", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.tb_Product", "Alias", c => c.String());
            AlterColumn("dbo.tb_Product", "ProductCode", c => c.String());
            AlterColumn("dbo.tb_Product", "Image", c => c.String());
            AlterColumn("dbo.tb_Product", "SeoTitle", c => c.String());
            AlterColumn("dbo.tb_Product", "SeoDiscription", c => c.String());
            AlterColumn("dbo.tb_Product", "SeoKeywords", c => c.String());
            CreateIndex("dbo.tb_Posts", "CategoryID");
            AddForeignKey("dbo.tb_Posts", "CategoryID", "dbo.tb_Category", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Posts", "CategoryID", "dbo.tb_Category");
            DropIndex("dbo.tb_Posts", new[] { "CategoryID" });
            AlterColumn("dbo.tb_Product", "SeoKeywords", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Product", "SeoDiscription", c => c.String(maxLength: 50));
            AlterColumn("dbo.tb_Product", "SeoTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Product", "Image", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Product", "ProductCode", c => c.String(maxLength: 50));
            AlterColumn("dbo.tb_Product", "Alias", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Posts", "CategoryID", c => c.Int());
            AlterColumn("dbo.tb_Posts", "SeoKeywords", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Posts", "SeoDiscription", c => c.String(maxLength: 500));
            AlterColumn("dbo.tb_Posts", "SeoTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Posts", "Image", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Posts", "Alias", c => c.String(maxLength: 150));
            RenameColumn(table: "dbo.tb_Posts", name: "CategoryID", newName: "Category_Id");
            AddColumn("dbo.tb_Posts", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.tb_Posts", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.tb_Posts", "Category_Id");
            AddForeignKey("dbo.tb_Posts", "Category_Id", "dbo.tb_Category", "Id");
        }
    }
}
