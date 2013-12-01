namespace UniCloud.Domain.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ACREG_LICENSE", "ISSUED_DATE", c => c.DateTime(nullable: false, storeType: "datetime2"));
            AlterColumn("dbo.ACREG_LICENSE", "EXPIRE_DATE", c => c.DateTime(nullable: false, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ACREG_LICENSE", "EXPIRE_DATE", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ACREG_LICENSE", "ISSUED_DATE", c => c.DateTime(nullable: false));
        }
    }
}
