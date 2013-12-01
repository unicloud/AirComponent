namespace UniCloud.Domain.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteOwnerID : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AC_REG", "OWNER_ID");
            DropColumn("dbo.AC_REG", "OWNER_GUID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AC_REG", "OWNER_GUID", c => c.Guid(nullable: false));
            AddColumn("dbo.AC_REG", "OWNER_ID", c => c.Int());
        }
    }
}
