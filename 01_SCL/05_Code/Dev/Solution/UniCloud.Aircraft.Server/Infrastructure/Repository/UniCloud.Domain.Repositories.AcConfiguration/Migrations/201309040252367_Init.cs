namespace UniCloud.Domain.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AC_CATEGORY",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GUID = c.Guid(nullable: false),
                        LEVEL = c.String(),
                        REGIONAL = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AC_CONFIG",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GUID = c.Guid(nullable: false),
                        NAME = c.String(),
                        AC_MODEL_ID = c.Int(nullable: false),
                        AC_MODEL_GUID = c.Guid(nullable: false),
                        DESCRIPTION = c.String(),
                        MTW = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BW = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BWF = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BWI = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BEW = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MTOW = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MLW = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MZFW = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MMFW = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MCC = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AC_MODEL", t => t.AC_MODEL_ID, cascadeDelete: true)
                .Index(t => t.AC_MODEL_ID);
            
            CreateTable(
                "dbo.AC_MODEL",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GUID = c.Guid(nullable: false),
                        NAME = c.String(),
                        AC_TYPE_ID = c.Int(nullable: false),
                        AC_TYPE_GUID = c.Guid(nullable: false),
                        DESCRIPTION = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AC_TYPE", t => t.AC_TYPE_ID, cascadeDelete: true)
                .Index(t => t.AC_TYPE_ID);
            
            CreateTable(
                "dbo.AC_REG",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GUID = c.Guid(nullable: false),
                        AC_TYPE_ID = c.Int(nullable: false),
                        AC_TYPE_GUID = c.Guid(nullable: false),
                        OWNER = c.String(maxLength: 200),
                        OPERATORS = c.String(),
                        IMPORT_CATEGORY = c.String(),
                        EXPORTCATEGORY = c.String(),
                        REG_NUMBER = c.String(),
                        MSN = c.String(),
                        IS_OPERATION = c.Boolean(nullable: false),
                        CREATE_DATE = c.DateTime(nullable: false),
                        FACTORY_DATE = c.DateTime(nullable: false),
                        IMPORT_DATE = c.DateTime(nullable: false),
                        EXPORT_DATE = c.DateTime(nullable: false),
                        SEATING_CAPACITY = c.Int(nullable: false),
                        CARRYING_CAPACITY = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AC_MODEL_ID = c.Int(nullable: false),
                        AC_MODEL_GUID = c.Guid(nullable: false),
                        AC_CONFIG_ID = c.Int(nullable: false),
                        AC_CONFIG_GUID = c.Guid(nullable: false),
                        DECODE_CONFIG_ID = c.Int(),
                        DECODE_CONFIG_GUID = c.Guid(nullable: false),
                        ENGINE_TR = c.String(),
                        OFFSET_UTC = c.Int(nullable: false),
                        SUBFRAME_LENGHT = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ACREG_LICENSE",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GUID = c.Guid(nullable: false),
                        LICENSE_TYPE_ID = c.Int(nullable: false),
                        LICENSE_TYPE_GUID = c.Guid(nullable: false),
                        AC_Reg_ID = c.Int(nullable: false),
                        AC_Reg_GUID = c.Guid(nullable: false),
                        DOCUMENTGUID = c.Guid(nullable: false),
                        NOTES = c.String(),
                        ISSUED_FROM = c.String(),
                        ISSUED_DATE = c.DateTime(nullable: false),
                        VALID_MONTHS = c.Int(nullable: false),
                        EXPIRE_DATE = c.DateTime(nullable: false),
                        STATE = c.String(),
                        COPY_FILE = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.LICENSE_TYPE", t => t.LICENSE_TYPE_ID, cascadeDelete: true)
                .ForeignKey("dbo.AC_REG", t => t.AC_Reg_ID, cascadeDelete: true)
                .Index(t => t.LICENSE_TYPE_ID)
                .Index(t => t.AC_Reg_ID);
            
            CreateTable(
                "dbo.LICENSE_TYPE",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GUID = c.Guid(nullable: false),
                        TYPE = c.String(),
                        DESCRIPTION = c.String(),
                        HAS_FILE = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AC_TYPE",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GUID = c.Guid(nullable: false),
                        NAME = c.String(),
                        DESCRIPTION = c.String(),
                        MANUFACTURER = c.String(),
                        ACCATEGORY_ID = c.Int(),
                        ACCATEGORY_GUID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AC_CATEGORY", t => t.ACCATEGORY_ID)
                .Index(t => t.ACCATEGORY_ID);
            
            CreateTable(
                "dbo.ATA",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GUID = c.Guid(nullable: false),
                        ATA = c.String(),
                        DESCRIPTION = c.String(),
                        PARENTID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ATA", t => t.PARENTID)
                .Index(t => t.PARENTID);
            
            CreateTable(
                "dbo.AC_ATA",
                c => new
                    {
                        AC_TYPEID = c.Int(nullable: false),
                        ATAID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AC_TYPEID, t.ATAID })
                .ForeignKey("dbo.AC_TYPE", t => t.AC_TYPEID, cascadeDelete: true)
                .ForeignKey("dbo.ATA", t => t.ATAID, cascadeDelete: true)
                .Index(t => t.AC_TYPEID)
                .Index(t => t.ATAID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.AC_ATA", new[] { "ATAID" });
            DropIndex("dbo.AC_ATA", new[] { "AC_TYPEID" });
            DropIndex("dbo.ATA", new[] { "PARENTID" });
            DropIndex("dbo.AC_TYPE", new[] { "ACCATEGORY_ID" });
            DropIndex("dbo.ACREG_LICENSE", new[] { "AC_Reg_ID" });
            DropIndex("dbo.ACREG_LICENSE", new[] { "LICENSE_TYPE_ID" });
            DropIndex("dbo.AC_MODEL", new[] { "AC_TYPE_ID" });
            DropIndex("dbo.AC_CONFIG", new[] { "AC_MODEL_ID" });
            DropForeignKey("dbo.AC_ATA", "ATAID", "dbo.ATA");
            DropForeignKey("dbo.AC_ATA", "AC_TYPEID", "dbo.AC_TYPE");
            DropForeignKey("dbo.ATA", "PARENTID", "dbo.ATA");
            DropForeignKey("dbo.AC_TYPE", "ACCATEGORY_ID", "dbo.AC_CATEGORY");
            DropForeignKey("dbo.ACREG_LICENSE", "AC_Reg_ID", "dbo.AC_REG");
            DropForeignKey("dbo.ACREG_LICENSE", "LICENSE_TYPE_ID", "dbo.LICENSE_TYPE");
            DropForeignKey("dbo.AC_MODEL", "AC_TYPE_ID", "dbo.AC_TYPE");
            DropForeignKey("dbo.AC_CONFIG", "AC_MODEL_ID", "dbo.AC_MODEL");
            DropTable("dbo.AC_ATA");
            DropTable("dbo.ATA");
            DropTable("dbo.AC_TYPE");
            DropTable("dbo.LICENSE_TYPE");
            DropTable("dbo.ACREG_LICENSE");
            DropTable("dbo.AC_REG");
            DropTable("dbo.AC_MODEL");
            DropTable("dbo.AC_CONFIG");
            DropTable("dbo.AC_CATEGORY");
        }
    }
}
