namespace UniCloud.Domain.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOwner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AC_REG", "OWNER", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AC_REG", "OWNER");
        }
    }
}
