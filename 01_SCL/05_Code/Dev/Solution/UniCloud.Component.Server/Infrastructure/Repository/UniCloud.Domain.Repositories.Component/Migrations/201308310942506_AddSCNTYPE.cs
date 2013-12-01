namespace UniCloud.Domain.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSCNTYPE : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SCN_MAIN", "SCNTYPE", c => c.String(maxLength: 4));
            AddColumn("dbo.SCN_MAIN", "CLOSESITUATION", c => c.Int(nullable: false));
            AddColumn("dbo.SCN_MAIN", "CLOSETIME", c => c.DateTime(nullable: false));
            AddColumn("dbo.SCN_MAIN", "CREATEUSER", c => c.String(maxLength: 10));
            AddColumn("dbo.SCN_MAIN", "CREATETIME", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SCN_MAIN", "CREATETIME");
            DropColumn("dbo.SCN_MAIN", "CREATEUSER");
            DropColumn("dbo.SCN_MAIN", "CLOSETIME");
            DropColumn("dbo.SCN_MAIN", "CLOSESITUATION");
            DropColumn("dbo.SCN_MAIN", "SCNTYPE");
        }
    }
}
