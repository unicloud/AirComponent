namespace UniCloud.Domain.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExportCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AC_REG", "EXPORTCATEGORY", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AC_REG", "EXPORTCATEGORY");
        }
    }
}
