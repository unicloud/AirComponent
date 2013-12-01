namespace UniCloud.Domain.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsLife : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PN_REG", "ISLIFE", c => c.Boolean(nullable: false));
            AddColumn("dbo.PN_REG", "DESCRIPTION", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PN_REG", "DESCRIPTION");
            DropColumn("dbo.PN_REG", "ISLIFE");
        }
    }
}
