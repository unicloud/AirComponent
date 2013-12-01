namespace UniCloud.Domain.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOpratetor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CCIN", "ENGINE_TLI", c => c.String(maxLength: 4));
            AddColumn("dbo.CC_ORDER", "OPERATOR", c => c.String(maxLength: 20));
            AddColumn("dbo.CC_ORDER", "OPERATDATE", c => c.DateTime(nullable: false));
            DropColumn("dbo.CCIN", "ITEMNO");
            DropColumn("dbo.CCOUT", "ITEMNO");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CCOUT", "ITEMNO", c => c.Int(nullable: false));
            AddColumn("dbo.CCIN", "ITEMNO", c => c.Int(nullable: false));
            DropColumn("dbo.CC_ORDER", "OPERATDATE");
            DropColumn("dbo.CC_ORDER", "OPERATOR");
            DropColumn("dbo.CCIN", "ENGINE_TLI");
        }
    }
}
