namespace UniCloud.Domain.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CCIN",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PN_REGID = c.Int(nullable: false),
                        SN_REGID = c.Int(nullable: false),
                        ENGINE_TLI = c.String(maxLength: 4),
                        ATAID = c.Int(nullable: false),
                        ATA_GUID = c.Guid(nullable: false),
                        ZONE = c.String(maxLength: 4),
                        SEQ = c.Int(nullable: false),
                        ROOT_SN_REGID = c.Int(),
                        NH_SN_REGID = c.Int(),
                        CC_ORDERID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CC_ORDER", t => t.CC_ORDERID, cascadeDelete: true)
                .Index(t => t.CC_ORDERID);
            
            CreateTable(
                "dbo.CC_ORDER",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ORDERNO = c.String(maxLength: 20),
                        CCTYPE = c.String(maxLength: 2),
                        AC_REGID = c.Int(nullable: false),
                        AC_REG_GUID = c.Guid(nullable: false),
                        SWAP_ACREG = c.Int(nullable: false),
                        REM_REASON = c.String(maxLength: 4),
                        WONO = c.String(maxLength: 20),
                        WO_ITEM = c.String(maxLength: 2),
                        WO_TYPE = c.String(maxLength: 4),
                        UPDATE_DATE = c.DateTime(nullable: false),
                        UPDATEBY = c.String(maxLength: 20),
                        STATE = c.String(maxLength: 2),
                        OPERATOR = c.String(maxLength: 20),
                        OPERATDATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CCOUT",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PN_REGID = c.Int(nullable: false),
                        SN_REGID = c.Int(nullable: false),
                        ATAID = c.Int(nullable: false),
                        ATA_GUID = c.Guid(nullable: false),
                        ZONE = c.String(maxLength: 4),
                        SEQ = c.Int(nullable: false),
                        ROOT_SN_REGID = c.Int(),
                        NH_SN_REGID = c.Int(),
                        UN_SCHEDULED = c.Boolean(nullable: false),
                        CC_ORDERID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CC_ORDER", t => t.CC_ORDERID, cascadeDelete: true)
                .Index(t => t.CC_ORDERID);
            
            CreateTable(
                "dbo.CCP_LIMIT",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IEAM = c.String(maxLength: 2),
                        RANGE_MIN = c.Int(nullable: false),
                        CONTROL_TYPE = c.String(maxLength: 1),
                        CONTROLNO = c.String(maxLength: 2),
                        ENGINE_TLI = c.String(maxLength: 4),
                        UNIT = c.String(maxLength: 2),
                        INTUNIT_ID = c.Int(nullable: false),
                        INTERVAL = c.Int(nullable: false),
                        CONTROL_GROUP = c.String(maxLength: 2),
                        RANGE_MAX = c.Int(nullable: false),
                        RANGE_TYPE = c.String(maxLength: 2),
                        WORK_SCOPE = c.String(maxLength: 2),
                        WORKSCOPE_ID = c.Int(nullable: false),
                        POLICY_EXEC = c.String(maxLength: 1),
                        SOURCE = c.String(maxLength: 50),
                        NOTES = c.String(maxLength: 50),
                        CCPMAIN_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.WORK_SCOPE", t => t.WORKSCOPE_ID, cascadeDelete: true)
                .ForeignKey("dbo.INT_UNIT", t => t.INTUNIT_ID, cascadeDelete: true)
                .ForeignKey("dbo.CCP_MAIN", t => t.CCPMAIN_ID, cascadeDelete: true)
                .Index(t => t.WORKSCOPE_ID)
                .Index(t => t.INTUNIT_ID)
                .Index(t => t.CCPMAIN_ID);
            
            CreateTable(
                "dbo.WORK_SCOPE",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SCOPE = c.String(maxLength: 2),
                        DESCRIPTION = c.String(maxLength: 20),
                        SHORT_NAME = c.String(maxLength: 10),
                        TYPE = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.INT_UNIT",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UNIT = c.String(maxLength: 2),
                        DESCRITPTION = c.String(maxLength: 20),
                        TYPE = c.String(maxLength: 1),
                        SHORT_NAME = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CCP_MAIN",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ITEMNO = c.String(maxLength: 20),
                        AC_MODEL = c.String(maxLength: 6),
                        ACMODEL_ID = c.Int(nullable: false),
                        ACMODEL_GUID = c.Guid(nullable: false),
                        ATAID = c.Int(nullable: false),
                        ATA_GUID = c.Guid(nullable: false),
                        DESCRIPTION = c.String(maxLength: 100),
                        IS_LIFE = c.Boolean(nullable: false),
                        STATE = c.String(maxLength: 6),
                        VERSION = c.Int(nullable: false),
                        NH_ITEMNO = c.String(maxLength: 20),
                        UPDATEBY = c.String(maxLength: 30),
                        UPDATE_TIME = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CCPPN",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PN = c.String(maxLength: 30),
                        SPECPN = c.String(maxLength: 30),
                        AC_CONFIG = c.String(maxLength: 6),
                        ACCONFIG_ID = c.Int(nullable: false),
                        ACCONFIG_GUID = c.Guid(nullable: false),
                        AC_REGS = c.String(maxLength: 50),
                        NOTES = c.String(maxLength: 20),
                        QTY = c.Int(nullable: false),
                        IEAM = c.String(maxLength: 2),
                        SNS = c.String(maxLength: 50),
                        PN_REGID = c.Int(nullable: false),
                        CCPMAIN_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PN_REG", t => t.PN_REGID, cascadeDelete: true)
                .ForeignKey("dbo.CCP_MAIN", t => t.CCPMAIN_ID, cascadeDelete: true)
                .Index(t => t.PN_REGID)
                .Index(t => t.CCPMAIN_ID);
            
            CreateTable(
                "dbo.PN_REG",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PN = c.String(maxLength: 30),
                        PN_CLASS = c.String(maxLength: 6),
                        ATAID = c.Int(nullable: false),
                        ATA_GUID = c.Guid(nullable: false),
                        VENDOR = c.String(maxLength: 10),
                        UPDATE_TIME = c.DateTime(nullable: false),
                        UPDATEBY = c.String(maxLength: 30),
                        STATE = c.String(maxLength: 2),
                        SPECPN = c.String(maxLength: 30),
                        ISLIFE = c.Boolean(nullable: false),
                        DESCRIPTION = c.String(maxLength: 100),
                        TRAIN_RATE = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OIL_HISTORY",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SN_REGID = c.Int(nullable: false),
                        PN_REGID = c.Int(nullable: false),
                        U_P_L_IFT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FLIGHTL_LOGID = c.Int(nullable: false),
                        ADD_TIME = c.String(maxLength: 5),
                        FLIGHT_DATE = c.DateTime(nullable: false),
                        AC_REGID = c.Int(nullable: false),
                        AC_REG_GUID = c.Guid(nullable: false),
                        NOTES = c.String(maxLength: 20),
                        ADD_NAME = c.String(maxLength: 20),
                        UPDATE_DATE = c.DateTime(nullable: false),
                        UPDATEBY = c.String(maxLength: 20),
                        ATAID = c.Int(nullable: false),
                        ATA_GUID = c.Guid(nullable: false),
                        ZONE = c.String(maxLength: 4),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PARTS_MONITOR",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PN_REGID = c.Int(nullable: false),
                        SN_REGID = c.Int(nullable: false),
                        AC_REGID = c.Int(nullable: false),
                        AC_REG_GUID = c.Guid(nullable: false),
                        CCP_MAIN = c.Int(nullable: false),
                        USED_TIME = c.String(maxLength: 20),
                        REMAIN_TIME = c.String(maxLength: 20),
                        WORK_SCOPE = c.String(maxLength: 2),
                        POLICY_EXEC = c.String(maxLength: 2),
                        INSTALL_DATE = c.DateTime(nullable: false),
                        ATAID = c.Int(nullable: false),
                        ATA_GUID = c.Guid(nullable: false),
                        ZONE = c.String(maxLength: 4),
                        POSITION = c.String(maxLength: 20),
                        EXPIRE_DATE = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PARTS_MONITOR_DETAIL",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        INT_UNITID = c.Int(nullable: false),
                        USO = c.Int(nullable: false),
                        USR = c.Int(nullable: false),
                        INTERVAL = c.Int(nullable: false),
                        USN = c.Int(nullable: false),
                        Remain = c.Int(nullable: false),
                        EXPIRE_DATE = c.DateTime(nullable: false),
                        PartsMonitorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PARTS_MONITOR", t => t.PartsMonitorID, cascadeDelete: true)
                .Index(t => t.PartsMonitorID);
            
            CreateTable(
                "dbo.SCN_ACORDER",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AC_ORDER = c.String(maxLength: 20),
                        AC_ORDER_ITEM = c.String(maxLength: 2),
                        NOTES = c.String(maxLength: 20),
                        SCN_MAINID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SCN_MAIN", t => t.SCN_MAINID, cascadeDelete: true)
                .Index(t => t.SCN_MAINID);
            
            CreateTable(
                "dbo.SCN_ITEM",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SCN_MAINID = c.Int(nullable: false),
                        ITEMNO = c.Int(nullable: false),
                        PN_REGID = c.Int(),
                        ATAID = c.Int(nullable: false),
                        ATA_GUID = c.Guid(nullable: false),
                        PN = c.String(maxLength: 30),
                        DESCRIPTION = c.String(maxLength: 100),
                        VENDOR = c.String(maxLength: 20),
                        NOTES = c.String(maxLength: 100),
                        QTY = c.Int(nullable: false),
                        PRICE = c.Double(nullable: false),
                        TOTAL_PRICE = c.Double(nullable: false),
                        CURRENCY = c.String(maxLength: 6),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SCN_MAIN", t => t.SCN_MAINID, cascadeDelete: true)
                .Index(t => t.SCN_MAINID);
            
            CreateTable(
                "dbo.SCN_MAIN",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SCNNO = c.String(maxLength: 20),
                        AC_TYPEID = c.Int(nullable: false),
                        AC_TYPE_GUID = c.Guid(nullable: false),
                        AC_MODELID = c.Int(nullable: false),
                        AC_MODEL_GUID = c.Guid(nullable: false),
                        VERSION = c.String(maxLength: 2),
                        STATE = c.String(maxLength: 2),
                        DESCRIPTION = c.String(maxLength: 1000),
                        SCNTYPE = c.String(maxLength: 4),
                        CLOSESITUATION = c.Int(nullable: false),
                        CLOSETIME = c.DateTime(nullable: false),
                        CREATEUSER = c.String(maxLength: 10),
                        CREATETIME = c.DateTime(nullable: false),
                        SCNTITLE = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SN_HISTORY",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SN_REGID = c.Int(nullable: false),
                        AC_REGID = c.Int(nullable: false),
                        AC_REG_GUID = c.Guid(nullable: false),
                        ACTIVE = c.String(maxLength: 2),
                        POSITION = c.String(maxLength: 20),
                        NOTE = c.String(maxLength: 20),
                        ACTIVE_DATE = c.DateTime(nullable: false),
                        ATAID = c.Int(nullable: false),
                        ATA_GUID = c.Guid(nullable: false),
                        NEXT_HIS = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SN_REG", t => t.SN_REGID, cascadeDelete: true)
                .Index(t => t.SN_REGID);
            
            CreateTable(
                "dbo.SN_REG",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PN_REGID = c.Int(nullable: false),
                        SN = c.String(maxLength: 20),
                        AC_REGID = c.Int(nullable: false),
                        AC_REG_GUID = c.Guid(nullable: false),
                        ATAID = c.Int(nullable: false),
                        ATA_GUID = c.Guid(nullable: false),
                        POSITION = c.String(maxLength: 20),
                        INSTALL_DATE = c.DateTime(nullable: false),
                        NOTE = c.String(maxLength: 20),
                        AVAIL = c.String(maxLength: 6),
                        IS_LIFE = c.Boolean(nullable: false),
                        NH_SN_REGID = c.Int(),
                        ROOT_SN_REGID = c.Int(),
                        ZONE = c.String(maxLength: 4),
                        ENGINE_TLI = c.String(maxLength: 4),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PN_REG", t => t.PN_REGID, cascadeDelete: true)
                .Index(t => t.PN_REGID);
            
            CreateTable(
                "dbo.SN_HISTORY_UNIT",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SN_HISTORYID = c.Int(nullable: false),
                        INT_UNITID = c.Int(nullable: false),
                        USO = c.Decimal(nullable: false, precision: 18, scale: 2),
                        USN = c.Decimal(nullable: false, precision: 18, scale: 2),
                        USR = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.INT_UNIT", t => t.INT_UNITID, cascadeDelete: true)
                .ForeignKey("dbo.SN_HISTORY", t => t.SN_HISTORYID, cascadeDelete: true)
                .Index(t => t.INT_UNITID)
                .Index(t => t.SN_HISTORYID);
            
            CreateTable(
                "dbo.WF_HISTORY",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SEQ = c.String(maxLength: 6),
                        AUDITOR = c.String(maxLength: 30),
                        AUDIT_TIME = c.DateTime(nullable: false),
                        AUDIT_NOTES = c.String(maxLength: 100),
                        RESULT = c.String(maxLength: 6),
                        BUSINESS = c.String(maxLength: 20),
                        BUSINESSID = c.Int(nullable: false),
                        DEPARTMENT = c.String(maxLength: 10),
                        DESCRIPTION = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.SN_HISTORY_UNIT", new[] { "SN_HISTORYID" });
            DropIndex("dbo.SN_HISTORY_UNIT", new[] { "INT_UNITID" });
            DropIndex("dbo.SN_REG", new[] { "PN_REGID" });
            DropIndex("dbo.SN_HISTORY", new[] { "SN_REGID" });
            DropIndex("dbo.SCN_ITEM", new[] { "SCN_MAINID" });
            DropIndex("dbo.SCN_ACORDER", new[] { "SCN_MAINID" });
            DropIndex("dbo.PARTS_MONITOR_DETAIL", new[] { "PartsMonitorID" });
            DropIndex("dbo.CCPPN", new[] { "CCPMAIN_ID" });
            DropIndex("dbo.CCPPN", new[] { "PN_REGID" });
            DropIndex("dbo.CCP_LIMIT", new[] { "CCPMAIN_ID" });
            DropIndex("dbo.CCP_LIMIT", new[] { "INTUNIT_ID" });
            DropIndex("dbo.CCP_LIMIT", new[] { "WORKSCOPE_ID" });
            DropIndex("dbo.CCOUT", new[] { "CC_ORDERID" });
            DropIndex("dbo.CCIN", new[] { "CC_ORDERID" });
            DropForeignKey("dbo.SN_HISTORY_UNIT", "SN_HISTORYID", "dbo.SN_HISTORY");
            DropForeignKey("dbo.SN_HISTORY_UNIT", "INT_UNITID", "dbo.INT_UNIT");
            DropForeignKey("dbo.SN_REG", "PN_REGID", "dbo.PN_REG");
            DropForeignKey("dbo.SN_HISTORY", "SN_REGID", "dbo.SN_REG");
            DropForeignKey("dbo.SCN_ITEM", "SCN_MAINID", "dbo.SCN_MAIN");
            DropForeignKey("dbo.SCN_ACORDER", "SCN_MAINID", "dbo.SCN_MAIN");
            DropForeignKey("dbo.PARTS_MONITOR_DETAIL", "PartsMonitorID", "dbo.PARTS_MONITOR");
            DropForeignKey("dbo.CCPPN", "CCPMAIN_ID", "dbo.CCP_MAIN");
            DropForeignKey("dbo.CCPPN", "PN_REGID", "dbo.PN_REG");
            DropForeignKey("dbo.CCP_LIMIT", "CCPMAIN_ID", "dbo.CCP_MAIN");
            DropForeignKey("dbo.CCP_LIMIT", "INTUNIT_ID", "dbo.INT_UNIT");
            DropForeignKey("dbo.CCP_LIMIT", "WORKSCOPE_ID", "dbo.WORK_SCOPE");
            DropForeignKey("dbo.CCOUT", "CC_ORDERID", "dbo.CC_ORDER");
            DropForeignKey("dbo.CCIN", "CC_ORDERID", "dbo.CC_ORDER");
            DropTable("dbo.WF_HISTORY");
            DropTable("dbo.SN_HISTORY_UNIT");
            DropTable("dbo.SN_REG");
            DropTable("dbo.SN_HISTORY");
            DropTable("dbo.SCN_MAIN");
            DropTable("dbo.SCN_ITEM");
            DropTable("dbo.SCN_ACORDER");
            DropTable("dbo.PARTS_MONITOR_DETAIL");
            DropTable("dbo.PARTS_MONITOR");
            DropTable("dbo.OIL_HISTORY");
            DropTable("dbo.PN_REG");
            DropTable("dbo.CCPPN");
            DropTable("dbo.CCP_MAIN");
            DropTable("dbo.INT_UNIT");
            DropTable("dbo.WORK_SCOPE");
            DropTable("dbo.CCP_LIMIT");
            DropTable("dbo.CCOUT");
            DropTable("dbo.CC_ORDER");
            DropTable("dbo.CCIN");
        }
    }
}
