namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseNew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Category", "Link", c => c.String());
            AddColumn("dbo.tb_Order", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.tb_Product", "OriginalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Product", "OriginalPrice");
            DropColumn("dbo.tb_Order", "Status");
            DropColumn("dbo.tb_Category", "Link");
        }
    }
}
