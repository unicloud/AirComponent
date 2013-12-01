namespace UniCloud.Domain.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class da : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SCN_MAIN", "CLOSETIME", c => c.DateTime(nullable: false, storeType: "datetime2"));
            AlterColumn("dbo.SCN_MAIN", "CREATETIME", c => c.DateTime(nullable: false, storeType: "datetime2"));
            AlterColumn("dbo.WF_HISTORY", "AUDIT_TIME", c => c.DateTime(nullable: false, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WF_HISTORY", "AUDIT_TIME", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SCN_MAIN", "CREATETIME", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SCN_MAIN", "CLOSETIME", c => c.DateTime(nullable: false));
        }
    }
}
