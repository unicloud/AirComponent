namespace UniCloud.Domain.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WF_HISTORY", "ScnMainID", c => c.Int(nullable: false));
            AddForeignKey("dbo.WF_HISTORY", "ScnMainID", "dbo.SCN_MAIN", "ID", cascadeDelete: true);
            CreateIndex("dbo.WF_HISTORY", "ScnMainID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.WF_HISTORY", new[] { "ScnMainID" });
            DropForeignKey("dbo.WF_HISTORY", "ScnMainID", "dbo.SCN_MAIN");
            DropColumn("dbo.WF_HISTORY", "ScnMainID");
        }
    }
}
