namespace UniCloud.Domain.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddScnTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SCN_MAIN", "SCNTITLE", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SCN_MAIN", "SCNTITLE");
        }
    }
}
