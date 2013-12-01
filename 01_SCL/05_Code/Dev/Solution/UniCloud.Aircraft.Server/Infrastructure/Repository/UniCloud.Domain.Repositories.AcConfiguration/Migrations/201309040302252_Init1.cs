namespace UniCloud.Domain.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AC_REG", "CREATE_DATE", c => c.DateTime(nullable: false, storeType: "datetime2"));
            AlterColumn("dbo.AC_REG", "FACTORY_DATE", c => c.DateTime(nullable: false, storeType: "datetime2"));
            AlterColumn("dbo.AC_REG", "IMPORT_DATE", c => c.DateTime(nullable: false, storeType: "datetime2"));
            AlterColumn("dbo.AC_REG", "EXPORT_DATE", c => c.DateTime(nullable: false, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AC_REG", "EXPORT_DATE", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AC_REG", "IMPORT_DATE", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AC_REG", "FACTORY_DATE", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AC_REG", "CREATE_DATE", c => c.DateTime(nullable: false));
        }
    }
}
