namespace UniCloud.Domain.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WFSCNID : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.WF_HISTORY", name: "ScnMainID", newName: "SCN_MAINID");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.WF_HISTORY", name: "SCN_MAINID", newName: "ScnMainID");
        }
    }
}
