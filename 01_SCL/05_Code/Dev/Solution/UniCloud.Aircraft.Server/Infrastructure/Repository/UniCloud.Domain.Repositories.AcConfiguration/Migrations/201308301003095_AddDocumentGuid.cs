namespace UniCloud.Domain.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDocumentGuid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ACREG_LICENSE", "DOCUMENTGUID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ACREG_LICENSE", "DOCUMENTGUID");
        }
    }
}
