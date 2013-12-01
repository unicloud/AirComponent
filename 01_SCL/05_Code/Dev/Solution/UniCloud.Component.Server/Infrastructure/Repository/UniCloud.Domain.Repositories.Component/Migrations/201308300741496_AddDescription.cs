namespace UniCloud.Domain.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WF_HISTORY", "DEPARTMENT", c => c.String(maxLength: 10));
            AddColumn("dbo.WF_HISTORY", "DESCRIPTION", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WF_HISTORY", "DESCRIPTION");
            DropColumn("dbo.WF_HISTORY", "DEPARTMENT");
        }
    }
}
