using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure.Communication;
using UniCloud.Infrastructure.Common;
using System.Linq;
using UniCloud.Infrastructure.Common.Input;
using UniCloud.Infrastructure;


namespace UniCloud.Component.Server.UnitTest
{
    
    
    /// <summary>
    ///这是 IPartServiceTest 的测试类，旨在
    ///包含所有 IPartServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class IPartServiceTest
    {

        private readonly ServiceProxy<IPartService> aircraftService = new ServiceProxy<IPartService>();
        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        [TestInitialize()]
        public void MyTestInitialize()
        {
            Initializer.Init();
        }
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        internal virtual IPartService CreateIPartService()
        {
            // TODO: 实例化相应的具体类。
            IPartService target = ServiceLocator.Instance.GetService<IPartService>(); ;
            return target;
        }

        /// <summary>
        ///AddCcOrder 的测试
        ///</summary>
        [TestMethod()]
        public void AddCcOrderTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            CcOrderDataObjectList ccOrders = new CcOrderDataObjectList();
            for (int i = 1; i < 2; i++)
            {
                var ccorder = new CcOrderDataObject();
                ccorder.AcReg = "";
               
                ccorder.SwapAcreg = "";
                ccorder.OrderNo = "00001";
                ccorder.RemReason = "故障";
                ccorder.State = "P";
                ccorder.OperatDate = DateTime.Now;
                ccorder.Operator = "wuying";
                ccorder.UpdateDate = DateTime.Now;
                ccorder.WoType = "aaa";
                ccorder.WoNo = "000" + i.ToString();
                ccorder.WoItem = "拆装";
                ccorder.Cctype = "拆装";

                var ccin = new CcinDataObject();
                ccin.AtaGuid = new Guid();
                ccin.Ata = "1";
                ccin.EngineTli = "22k";
                ccin.PnRegID = target.GetAllPnRegs()[0].ID;
                ccin.Seq = i;
                ccin.SnRegID = target.GetAllSnRegs()[0].ID;
                ccin.Zone = "飞机尾部";
                ccorder.Ccins=(ccin);
                var ccout = new CcoutDataObject();
                ccout.AtaGuid = new Guid();
                ccout.Ata = "1";
                ccout.UnScheduled = true;
                ccout.PnRegID = target.GetAllPnRegs()[0].ID;
                ccout.Seq = i;
                ccout.SnRegID = target.GetAllSnRegs()[0].ID;
                ccout.Zone = "飞机尾部";
                ccorder.Ccouts=(ccout);
                ccOrders.Add(ccorder);
            }
            CcOrderDataObjectList actual;
            actual = target.AddCcOrder(ccOrders);
            Assert.AreEqual(1, actual.Count);
        }

        /// <summary>
        ///AddCcin 的测试
        ///</summary>
        [TestMethod()]
        public void AddCcinTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            CcinDataObjectList ccins = new CcinDataObjectList()
                                       {
                                           new CcinDataObject()
                                           {
                                               AtaGuid=Guid.NewGuid(),
                                               Ata="10",
                                               NhSnRegID=1,
                                               PnRegID=1,
                                               Zone="1A",
                                               Seq=12,
                                               SnRegID=10
                                           },
                                           new CcinDataObject()
                                           {
                                               AtaGuid=Guid.NewGuid(),
                                               Ata="1",
                                               NhSnRegID=2,
                                               PnRegID=2,
                                               Zone="1A",
                                               Seq=2,
                                               SnRegID=2
                                           }
                                       }; // TODO: 初始化为适当的值
            CcinDataObjectList expected = null; // TODO: 初始化为适当的值
            CcinDataObjectList actual;
            int ccOrderId=1;
            actual = target.AddCcin(ccOrderId,ccins);
            Assert.AreEqual(2, actual.Count);
        }

        /// <summary>
        ///AddCcout 的测试
        ///</summary>
        [TestMethod()]
        public void AddCcoutTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            CcoutDataObjectList ccouts = new CcoutDataObjectList()
                                         {
                                             new CcoutDataObject()
                                             {
                                               AtaGuid=Guid.NewGuid(),
                                               Ata="1",
                                               NhSnRegID=2,
                                               PnRegID=3,
                                               Seq=4,
                                               RootSnRegID=5,
                                               SnRegID=6,
                                               UnScheduled=true,
                                               Zone="中部"
                                             },
                                             new CcoutDataObject()
                                             {
                                               AtaGuid=Guid.NewGuid(),
                                               Ata="1",
                                               NhSnRegID=1,
                                               PnRegID=1,
                                               Seq=1,
                                               RootSnRegID=1,
                                               SnRegID=1,
                                               UnScheduled=true,
                                               Zone="头部"
                                             },

                                         }; // TODO: 初始化为适当的值
            CcoutDataObjectList expected = null; // TODO: 初始化为适当的值
            CcoutDataObjectList actual;
            int ccOrderId = 1;
            actual = target.AddCcout(ccOrderId,ccouts);
            Assert.AreEqual(2, actual.Count);
        }

        /// <summary>
        ///AddCcpLimit 的测试
        ///</summary>
        [TestMethod()]
        public void AddCcpLimitTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            CcpLimitDataObjectList ccpLimits = new CcpLimitDataObjectList(); // TODO: 初始化为适当的值
            var ccpLimit = new CcpLimitDataObject();
            ccpLimit.ControlGroup = "99";
            ccpLimit.ControlNo = "1";
            ccpLimit.ControlType = "c";
            ccpLimit.EngineTli = "1000";
            ccpLimit.Ieam = "98";
            //ccpLimit.IntUnitID = target.GetAllIntUnits()[5].ID;//与Unit一致
            ccpLimit.Unit = target.GetAllIntUnits()[5].Unit;
            ccpLimit.Interval = 200;
            ccpLimit.Notes = "test";
            ccpLimit.PolicyExec = "e";
            ccpLimit.RangeMax = 2000;
            ccpLimit.RangeMin = 200;
            ccpLimit.RangeType = "小时";
            ccpLimit.Source = "网上资料";
            ccpLimit.WorkScopeID = target.GetAllWorkScopes()[4].ID;//与WorkScope一致
            ccpLimit.WorkScope = target.GetAllWorkScopes()[4].Scope;
            ccpLimits.Add(ccpLimit);
            int ccpMainId = target.GetAllCcpMains()[0].ID;// TODO: 初始化为适当的值
            CcpLimitDataObjectList expected = null; // TODO: 初始化为适当的值
            CcpLimitDataObjectList actual;
            actual = target.AddCcpLimit(ccpMainId,ccpLimits);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///AddCcpMain 的测试
        ///</summary>
        [TestMethod()]
        public void AddCcpMainTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            CcpMainDataObjectList ccpMains = new CcpMainDataObjectList(); // TODO: 初始化为适当的值
            for (int i = 1; i < 2; i++)
            {
                var ccpMain = new CcpMainDataObject();
                ccpMain.IsLife = true;
                ccpMain.ItemNo = "72-000" + i.ToString();
                ccpMain.AcType = "A320";
                ccpMain.Ata = "72";
                ccpMain.Description = "";
                ccpMain.State = "Edit";
                ccpMain.UpdateTime = DateTime.Now;
                ccpMain.Updateby = "ZSM";
                ccpMain.Version = 1;
                //for (int j = 1; j < 11; j++)
                //{
                    var ccpLimit = new CcpLimitDataObject();
                    ccpLimit.ControlGroup = (0).ToString();
                    ccpLimit.ControlNo = (1).ToString();
                    ccpLimit.ControlType = "A";
                    ccpLimit.EngineTli = "22K";
                    ccpLimit.Ieam = (0).ToString();
                    //ccpLimit.IntUnitID = 1;//与Unit一致
                    ccpLimit.Unit = "FH";
                    ccpLimit.Interval = 600;
                    ccpLimit.Notes = "";
                    ccpLimit.PolicyExec = "Y";
                    ccpLimit.RangeMax = 0;
                    ccpLimit.RangeMin = 600;
                    ccpLimit.RangeType = "FH";
                    ccpLimit.Source = "MPD";
                    ccpLimit.WorkScopeID = 4;//与WorkScope一致
                    ccpLimit.WorkScope = "CL";
                    ccpMain.CcpLimits.Add(ccpLimit);
                    var ccpPn = new CcpPnDataObject();
                    ccpPn.AcModel = string.Empty;
                    ccpPn.AcRegs = "";
                    ccpPn.Ieam = "";
                    ccpPn.Notes = "";
                    ccpPn.PnRegID = 0;//与Pn一致
                    ccpPn.Pn = "CFM56-3C";
                    ccpPn.Qty = 2;
                    ccpPn.Sns = "";
                    ccpPn.SpecPn = "CFM56-3C";
                    ccpMain.CcpPns.Add(ccpPn);
                //}
                ccpMains.Add(ccpMain);
            }
            CcpMainDataObjectList expected = null; // TODO: 初始化为适当的值
            CcpMainDataObjectList actual;
            actual = target.AddCcpMain(ccpMains);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///AddCcpPn 的测试
        ///</summary>
        [TestMethod()]
        public void AddCcpPnTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            CcpPnDataObjectList ccpPns = new CcpPnDataObjectList(); // TODO: 初始化为适当的值
            var ccpPn = new CcpPnDataObject();
            ccpPn.AcModel = string.Empty;
            ccpPn.AcRegs = "98300,89999";
            ccpPn.Ieam = "89";
            ccpPn.Notes = "test";
            ccpPn.PnRegID = target.GetAllPnRegs()[0].ID;//与Pn一致
            ccpPn.Pn = target.GetAllPnRegs()[0].Pn;
            ccpPn.Qty = 55;
            ccpPn.Sns = "测试";
            ccpPn.SpecPn = "000004556";
            ccpPns.Add(ccpPn);
            int ccpMainId = target.GetAllCcpMains()[0].ID;// TODO: 初始化为适当的值
            CcpPnDataObjectList expected = null; // TODO: 初始化为适当的值
            CcpPnDataObjectList actual;
            actual = target.AddCcpPn(ccpMainId,ccpPns);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///AddIntUnit 的测试
        ///</summary>
        [TestMethod()]
        public void AddIntUnitTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            IntUnitDataObjectList intUnits = new IntUnitDataObjectList(); // TODO: 初始化为适当的值
            //for (int i = 0; i < 10; i++)
            //{
            //    var intUnit = new IntUnitDataObject();
            //    intUnit.Descritption = "testUnit";
            //    intUnit.ShortName = "testUnit";
            //    intUnit.Type = i.ToString();
            //    intUnit.Unit = "t" + i.ToString();
            //    intUnits.Add(intUnit);
            //}
            var intunitfh = new IntUnitDataObject();
            intunitfh.Unit = "FH";
            intunitfh.Type = "H";
            intunitfh.ShortName = "FH";
            intunitfh.Descritption = "飞行小时";
            intUnits.Add(intunitfh);
            var intunitcy = new IntUnitDataObject();
            intunitcy.Unit = "CY";
            intunitcy.Type = "Y";
            intunitcy.ShortName = "CY";
            intunitcy.Descritption = "";
            intUnits.Add(intunitcy);
            IntUnitDataObjectList expected = null; // TODO: 初始化为适当的值
            IntUnitDataObjectList actual;
            actual = target.AddIntUnit(intUnits);
            Assert.AreEqual(10, actual.Count);
        }

        /// <summary>
        ///AddOilHistory 的测试
        ///</summary>
        [TestMethod()]
        public void AddOilHistoryTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            OilHistoryDataObjectList oilHistorys = new OilHistoryDataObjectList()
                                                   {
                                                       new OilHistoryDataObject()
                                                       {
                                                           AcRegID=1,
                                                           AcRegGuid=Guid.NewGuid(),
                                                           AddName="CC",
                                                           AddTime="10DAY",
                                                           AtaGuid=Guid.NewGuid(),
                                                           AtaID=1,
                                                           FlightDate=DateTime.Now.AddDays(-10),
                                                           FlightlLogID=1,
                                                           Notes="备注",
                                                           PnRegID=1,
                                                           SnRegID=1,
                                                           UpdateBy="BB",
                                                           UpdateDate=DateTime.Now,
                                                           UPLIFT=10,
                                                           Zone="C2"
                                                       }
                                                   }; // TODO: 初始化为适当的值
            OilHistoryDataObjectList expected = null; // TODO: 初始化为适当的值
            OilHistoryDataObjectList actual;
            actual = target.AddOilHistory(oilHistorys);
            Assert.IsTrue(actual.First().ID>0);
        }

        /// <summary>
        ///AddPartsMonitor 的测试
        ///</summary>
        [TestMethod()]
        public void AddPartsMonitorTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            PartsMonitorDataObjectList partsMonitors = new PartsMonitorDataObjectList
                                                       {
                                                           new PartsMonitorDataObject()
                                                           {
                                                               ExpireDate=DateTime.Now.AddDays(200),
                                                               InstallDate=DateTime.Now,
                                                               CcpMainID=2,
                                                               PnRegID=2,
                                                               PolicyExec="AB",
                                                               Position="1B",
                                                               RemainTime="1000days",
                                                               SnRegID=2,
                                                               UsedTime="100days",
                                                               WorkScope="CB",
                                                               Zone="2C",
                                                               PartsMonitorDetails=new PartsMonitorDetailDataObjectList()
                                                                                   {
                                                                                       new PartsMonitorDetailDataObject()
                                                                                       {
                                                                                           ExpireDate=DateTime.Now.AddDays(1000),
                                                                                           Interval=1000,
                                                                                           Unit="FH",
                                                                                           Remain=200,
                                                                                           USN=200,
                                                                                           USO=150,
                                                                                           USR=100
                                                                                       }
                                                                                   }
                                                           }
                                                       }; // TODO: 初始化为适当的值
            PartsMonitorDataObjectList expected = null; // TODO: 初始化为适当的值
            PartsMonitorDataObjectList actual;
            actual = target.AddPartsMonitor(partsMonitors);
            Assert.AreEqual(1, actual.Count);
        }

        /// <summary>
        ///AddPartsMonitorDetail 的测试
        ///</summary>
        [TestMethod()]
        public void AddPartsMonitorDetailTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            PartsMonitorDetailDataObjectList partsMonitorDetails = new PartsMonitorDetailDataObjectList()
                                                                                   {
                                                                                       new PartsMonitorDetailDataObject()
                                                                                       {
                                                                                           ExpireDate=DateTime.Now.AddDays(1000),
                                                                                           Interval=500,
                                                                                           Unit="FH",
                                                                                           Remain=200,
                                                                                           USN=300,
                                                                                           USO=200,
                                                                                           USR=100
                                                                                       }
                                                                                   }; // TODO: 初始化为适当的值
            PartsMonitorDetailDataObjectList expected = null; // TODO: 初始化为适当的值
            PartsMonitorDetailDataObjectList actual;
            int partsMonitorId = 1;
            actual = target.AddPartsMonitorDetail(partsMonitorId,partsMonitorDetails);
            Assert.IsTrue(actual.First().ID>0);
        }

        /// <summary>
        ///AddPnReg 的测试
        ///</summary>
        [TestMethod()]
        public void AddPnRegTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            PnRegDataObjectList pnRegs = new PnRegDataObjectList(); // TODO: 初始化为适当的值
            for (int i = 1; i < 11; i++)
            {
                var pnReg = new PnRegDataObject();
                
                pnReg.Ata = "72";
                pnReg.Pn = "test" + i.ToString();
                pnReg.PnClass = "test";
                pnReg.SpecPn = "20";
                pnReg.State = "启用";
                pnReg.Updateby = "test";
                pnReg.UpdateTime = DateTime.Now;
                pnReg.Vendor = "至正";
                pnRegs.Add(pnReg);
            }
            PnRegDataObjectList expected = null; // TODO: 初始化为适当的值
            PnRegDataObjectList actual;
            actual = target.AddPnReg(pnRegs);
            Assert.AreEqual(10, actual.Count);
        }

        /// <summary>
        ///AddScnAcorder 的测试
        ///</summary>
        [TestMethod()]
        public void AddScnAcorderTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            ScnAcorderDataObjectList scnAcorders = new ScnAcorderDataObjectList
                                                   {
                                                         new ScnAcorderDataObject()
                                                                     {
                                                                         AcOrderItem="CC",
                                                                         Notes="测试",
                                                                         AcOrder="BB"
                                                                     }
                                                   }; // TODO: 初始化为适当的值
 
            ScnAcorderDataObjectList actual;
            int scnMainId = 1;
            actual = target.AddScnAcorder(scnMainId,scnAcorders);
            Assert.IsTrue(actual.First().ID > 0);
        }

        /// <summary>
        ///AddScnItem 的测试
        ///</summary>
        [TestMethod()]
        public void AddScnItemTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            ScnItemDataObjectList scnItems = new ScnItemDataObjectList()
                                             {
                                                  new ScnItemDataObject()
                                                                  {
                                                                      AtaGuid=Guid.NewGuid(),
                                                                      AtaID=1,
                                                                      Currency="&",
                                                                      Description="测试",
                                                                      ItemNo=3,
                                                                      Notes="BBB",
                                                                      Pn="002",
                                                                      PnRegID=1,
                                                                      Price=10,
                                                                      Qty=12,
                                                                      TotalPrice=12,
                                                                      Vendor="CHINA"
                                                                  }
                                             }; // TODO: 初始化为适当的值
            ScnItemDataObjectList expected = null; // TODO: 初始化为适当的值
            ScnItemDataObjectList actual;
            int scnMainId = 1;
            actual = target.AddScnItem(scnMainId,scnItems);
            Assert.IsTrue(actual.First().ID > 0);
        }

        /// <summary>
        ///AddScnMain 的测试
        ///</summary>
        [TestMethod()]
        public void AddScnMainTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            ScnMainDataObjectList scnMains = new ScnMainDataObjectList()
                                             {
                                                 new ScnMainDataObject()
                                                 {
                                                     AcModelGuid=Guid.NewGuid(),
                                                     AcModelID=1,
                                                     AcTypeGuid=Guid.NewGuid(),
                                                     AcTypeID=1,
                                                     Description="测试",
                                                     ScnNo="001",
                                                     State="A",
                                                     Version="01",
                                                     ScnAcorders=new ScnAcorderDataObjectList()
                                                                 {
                                                                     new ScnAcorderDataObject()
                                                                     {
                                                                         AcOrderItem="BB",
                                                                         Notes="测试",
                                                                         AcOrder="AA"
                                                                     }
                                                                 },
                                                     ScnItems=new ScnItemDataObjectList()
                                                              {
                                                                  new ScnItemDataObject()
                                                                  {
                                                                      AtaGuid=Guid.NewGuid(),
                                                                      AtaID=1,
                                                                      Currency="$",
                                                                      Description="测试",
                                                                      ItemNo=3,
                                                                      Notes="AAA",
                                                                      Pn="001",
                                                                      PnRegID=1,
                                                                      Price=10,
                                                                      Qty=12,
                                                                      TotalPrice=12,
                                                                      Vendor="CHINA"
                                                                  }
                                                              }
                                                 }
                                             }; // TODO: 初始化为适当的值
            var TechWf = new WfHistoryDataObject() { Department = "技术标准室", Seq = "1", AuditTime = DateTime.Now };
            var AirframeWf = new WfHistoryDataObject() { Department = "机身系统室", Seq = "2", AuditTime = DateTime.Now };
            var AirmaterielWf = new WfHistoryDataObject() { Department = "航材计划室", Seq = "3", AuditTime = DateTime.Now };
            var MaintenanceWf = new WfHistoryDataObject() { Department = "机务工程部", Seq = "4", AuditTime = DateTime.Now };
            //scnMains.FirstOrDefault().WfHistorys.Add(TechWf);
            //scnMains.FirstOrDefault().WfHistorys.Add(AirframeWf);
            //scnMains.FirstOrDefault().WfHistorys.Add(AirmaterielWf);
            //scnMains.FirstOrDefault().WfHistorys.Add(MaintenanceWf);
            ScnMainDataObjectList expected = null; // TODO: 初始化为适当的值
            ScnMainDataObjectList actual;
            actual = target.AddScnMain(scnMains);
            Assert.IsTrue(actual.First().ID>0);
        }

        /// <summary>
        ///AddSnHistory 的测试
        ///</summary>
        [TestMethod()]
        public void AddSnHistoryTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            SnHistoryDataObjectList snHistorys = new SnHistoryDataObjectList(); // TODO: 初始化为适当的值
            for (int i = 0; i < 10; i++)
            {
                var snHistory = new SnHistoryDataObject();
                
                snHistory.Ac = "B-2522";
                
                snHistory.Ata = "72";
                snHistory.Active = "拆除";
                snHistory.ActiveDate = DateTime.Now;
                snHistory.Note = "test";
                snHistory.Position = "右上";
                snHistory.SnRegID = target.GetAllSnRegs()[0].ID;
                for (int j = 0; j < 10; j++)
                {
                    var snHistoryUnit = new SnHistoryUnitDataObject();
                    snHistoryUnit.Unit = "FH";
                    snHistoryUnit.USN = j;
                    snHistoryUnit.USO = j;
                    snHistoryUnit.USR = j;
                    snHistory.SnHistoryUnits.Add(snHistoryUnit);
                }
                snHistorys.Add(snHistory);
            }
            SnHistoryDataObjectList expected = null; // TODO: 初始化为适当的值
            SnHistoryDataObjectList actual;
            actual = target.AddSnHistory(snHistorys);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///AddSnHistoryUnit 的测试
        ///</summary>
        [TestMethod()]
        public void AddSnHistoryUnitTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            SnHistoryUnitDataObjectList snHistoryUnits = new SnHistoryUnitDataObjectList(); // TODO: 初始化为适当的值
            snHistoryUnits.Add(new SnHistoryUnitDataObject{Unit = "FH",USN = 11,USO = 12,USR = 13});
            int snHistoryId = target.GetAllSnHistorys()[0].ID;
            SnHistoryUnitDataObjectList expected = null; // TODO: 初始化为适当的值
            SnHistoryUnitDataObjectList actual;
            actual = target.AddSnHistoryUnit(snHistoryId,snHistoryUnits);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///AddSnReg 的测试
        ///</summary>
        [TestMethod()]
        public void AddSnRegTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            SnRegDataObjectList snRegs = new SnRegDataObjectList(); // TODO: 初始化为适当的值
            for (int i = 0; i < 10; i++)
            {
                var snReg = new SnRegDataObject();
                snReg.Ac = "B-6321";                                
                snReg.Ata = "72";
                snReg.Avail = "IN";
                snReg.EngineTli ="26K";
                snReg.NhSnReg = new SnRegDataObject();
                if (i > 0)
                {
                    snReg.NhSnReg.Sn = "00000";
                    snReg.NhSnReg.PnReg = new PnRegDataObject();
                    snReg.NhSnReg.PnReg.Pn = target.GetAllPnRegs()[0].Pn;
                }
                snReg.InstallDate = DateTime.Now;
                snReg.Note = "测试部件";
                snReg.PnReg = new PnRegDataObject();
                snReg.PnReg.Pn = target.GetAllPnRegs()[0].Pn;
                if (i > 0)
                    snReg.PnReg.Pn = target.GetAllPnRegs()[1].Pn;
                snReg.Position = "L";
                snReg.Sn = "0000" + i.ToString();
                snReg.Zone = "410";
                snRegs.Add(snReg);
                snReg.SnCsn = new SnHistoryUnitDataObject();
                snReg.SnCsn.Unit = "CY";
                snReg.SnCsn.USI = 100;
                snReg.SnCsn.USN = 200;
                snReg.SnCsn.USO = 150;
                snReg.SnCsn.USR = 100;
                snReg.SnTsn = new SnHistoryUnitDataObject();
                snReg.SnTsn.Unit = "FH";
                snReg.SnTsn.USI = 100;
                snReg.SnTsn.USN = 200;
                snReg.SnTsn.USO = 150;
                snReg.SnTsn.USR = 100;

            }
            SnRegDataObjectList expected = null; // TODO: 初始化为适当的值
            SnRegDataObjectList actual;
            actual = target.ImportSnRegs(snRegs);
            Assert.AreEqual(10, actual.Count);
        }

        /// <summary>
        ///AddWfHistory 的测试
        ///</summary>
        [TestMethod()]
        public void AddWfHistoryTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            WfHistoryDataObjectList wfHistorys = new WfHistoryDataObjectList(); // TODO: 初始化为适当的值
            for (int i = 0; i < 10; i++)
            {
                var wfHistory = new WfHistoryDataObject();
                wfHistory.AuditNotes = "test";
                wfHistory.AuditTime = DateTime.Now;
                wfHistory.Auditor = "至正";
                wfHistory.Business = "CcpMain";
                wfHistory.BusinessID = (i + 1);
                wfHistory.Result = "通过";
                wfHistory.Seq = "000" + (i + 1).ToString();
                wfHistorys.Add(wfHistory);
            }
            WfHistoryDataObjectList expected = null; // TODO: 初始化为适当的值
            WfHistoryDataObjectList actual;
            actual = target.AddWfHistory(wfHistorys);
            Assert.AreEqual(10, actual.Count);
        }

        /// <summary>
        ///AddWorkScope 的测试
        ///</summary>
        [TestMethod()]
        public void AddWorkScopeTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            WorkScopeDataObjectList workScopes = new WorkScopeDataObjectList(); // TODO: 初始化为适当的值
            for (int i = 1; i < 10; i++)
            {
                var workScope = new WorkScopeDataObject();
                workScope.Description = "test";
                workScope.Scope = "t" + i.ToString();
                workScope.ShortName = "test";
                workScope.Type = "1";
                workScopes.Add(workScope);
            }
            WorkScopeDataObjectList expected = null; // TODO: 初始化为适当的值
            WorkScopeDataObjectList actual;
            actual = target.AddWorkScope(workScopes);
            Assert.AreEqual(9, actual.Count);
        }

        /// <summary>
        ///DeleteCcOrder 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteCcOrderTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            IDList ccOrderIds = new IDList() ; // TODO: 初始化为适当的值
            var ccorders = target.GetAllCcOrders();
            foreach (var ccorder in ccorders)
            {
                ccOrderIds.Add(ccorder.ID.ToString());
            }
            var actual = target.DeleteCcOrder(ccOrderIds);
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///DeleteCcin 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteCcinTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            IDList ccinIds = new IDList(){"3"}; // TODO: 初始化为适当的值
            int ccOrderId = 1;
            var actual= target.DeleteCcin(ccOrderId,ccinIds);
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///DeleteCcout 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteCcoutTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            IDList ccoutIds = new IDList(){"2"}; // TODO: 初始化为适当的值
            int ccOrderId = 1;
            var actual = target.DeleteCcout(ccOrderId, ccoutIds);
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///DeleteCcpLimit 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteCcpLimitTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            CcpLimitDataObjectList ccpLimits = new CcpLimitDataObjectList(); // TODO: 初始化为适当的值
            var ccpLimit = target.GetAllCcpMains()[1].CcpLimits[2];
            ccpLimits.Add(ccpLimit);
            int ccpMainId = target.GetAllCcpMains()[1].ID;// TODO: 初始化为适当的值
            target.DeleteCcpLimit(ccpMainId,ccpLimits);
        }

        /// <summary>
        ///DeleteCcpMain 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteCcpMainTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            IDList ccpMainIds = new IDList(); // TODO: 初始化为适当的值
            ccpMainIds.Add(target.GetAllCcpMains()[4].ID.ToString());
            target.DeleteCcpMain(ccpMainIds);
        }

        /// <summary>
        ///DeleteCcpPn 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteCcpPnTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            CcpPnDataObjectList ccpPns = new CcpPnDataObjectList(); // TODO: 初始化为适当的值
            var ccpPn = target.GetAllCcpMains()[2].CcpPns[3];
            ccpPns.Add(ccpPn);
            int ccpMainId = target.GetAllCcpMains()[2].ID;// TODO: 初始化为适当的值
            target.DeleteCcpPn(ccpMainId,ccpPns);
        }

        /// <summary>
        ///DeleteIntUnit 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteIntUnitTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            IDList intUnitIds = new IDList(); // TODO: 初始化为适当的值
            intUnitIds.Add(target.GetAllIntUnits()[4].ID.ToString());
            target.DeleteIntUnit(intUnitIds);
        }

        /// <summary>
        ///DeleteOilHistory 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteOilHistoryTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            IDList oilHistoryIds = new IDList(){"1"}; // TODO: 初始化为适当的值
            var actual= target.DeleteOilHistory(oilHistoryIds);
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///DeletePartsMonitor 的测试
        ///</summary>
        [TestMethod()]
        public void DeletePartsMonitorTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            IDList partsMonitorIds = new IDList(){"1"}; // TODO: 初始化为适当的值
            var actual= target.DeletePartsMonitor(partsMonitorIds);
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///DeletePartsMonitorDetail 的测试
        ///</summary>
        [TestMethod()]
        public void DeletePartsMonitorDetailTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            IDList partsMonitorDetailIds = new IDList(){"1"}; // TODO: 初始化为适当的值
            int partsMonitorId = 1;
            var acutal= target.DeletePartsMonitorDetail(partsMonitorId,partsMonitorDetailIds);
            Assert.IsTrue(acutal);
        }

        /// <summary>
        ///DeletePnReg 的测试
        ///</summary>
        [TestMethod()]
        public void DeletePnRegTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            IDList pnRegIds = new IDList(); // TODO: 初始化为适当的值
            pnRegIds.Add("14");
            target.DeletePnReg(pnRegIds);
        }

        /// <summary>
        ///DeleteScnAcorder 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteScnAcorderTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            IDList scnAcorderIds = new IDList(){"1"}; // TODO: 初始化为适当的值
            int scnMainId = 1;
            var actual= target.DeleteScnAcorder(scnMainId,scnAcorderIds);
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///DeleteScnItem 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteScnItemTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            IDList scnItemIds = new IDList(){"1"}; // TODO: 初始化为适当的值
            int scnMainId = 1;
            var actual= target.DeleteScnItem(scnMainId,scnItemIds);
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///DeleteScnMain 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteScnMainTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            IDList scnMainIds = new IDList(){"1"}; // TODO: 初始化为适当的值
            var actual = target.DeleteScnMain(scnMainIds);
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///DeleteSnHistory 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteSnHistoryTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            IDList snHistoryIds = new IDList(); // TODO: 初始化为适当的值
            snHistoryIds.Add(target.GetAllSnHistorys()[7].ID.ToString());
            target.DeleteSnHistory(snHistoryIds);
        }

        /// <summary>
        ///DeleteSnHistoryUnit 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteSnHistoryUnitTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            SnHistoryUnitDataObjectList snHistoryUnits = new SnHistoryUnitDataObjectList(); // TODO: 初始化为适当的值
            var snHistoryUnit = target.GetAllSnHistorys()[7].SnHistoryUnits[5];
            snHistoryUnits.Add(snHistoryUnit);
            int snHistoryId = target.GetAllSnHistorys()[7].ID;// TODO: 初始化为适当的值
            target.DeleteSnHistoryUnit(snHistoryId,snHistoryUnits);
        }

        /// <summary>
        ///DeleteSnReg 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteSnRegTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            IDList snRegIds = new IDList(); // TODO: 初始化为适当的值
            snRegIds.Add(target.GetAllSnRegs()[7].ID.ToString());
            target.DeleteSnReg(snRegIds);
        }

        /// <summary>
        ///DeleteWfHistory 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteWfHistoryTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            IDList wfHistoryIds = new IDList(); // TODO: 初始化为适当的值
            wfHistoryIds.Add(target.GetAllWfHistorys()[8].ID.ToString());
            target.DeleteWfHistory(wfHistoryIds);
        }

        /// <summary>
        ///DeleteWorkScope 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteWorkScopeTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            IDList workScopeIds = new IDList(); // TODO: 初始化为适当的值
            workScopeIds.Add(target.GetAllWorkScopes()[7].ID.ToString());
            target.DeleteWorkScope(workScopeIds);
        }

        /// <summary>
        ///GetAllCcOrders 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllCcOrdersTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            CcOrderDataObjectList expected = null; // TODO: 初始化为适当的值
            CcOrderDataObjectList actual;
            actual = target.GetAllCcOrders();
            Assert.IsTrue(actual.Count > 0);
        }

        /// <summary>
        ///GetAllCcins 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllCcinsTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            CcinDataObjectList expected = null; // TODO: 初始化为适当的值
            CcinDataObjectList actual;
            int ccOrderId = 1;
            actual = target.GetAllCcins(ccOrderId);
            Assert.IsTrue(actual.Count>0);
        }

        /// <summary>
        ///GetAllCcouts 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllCcoutsTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            CcoutDataObjectList expected = null; // TODO: 初始化为适当的值
            CcoutDataObjectList actual;
            int ccOrderId = 1;
            actual = target.GetAllCcouts(ccOrderId);
            Assert.IsTrue(actual.Count > 0);
        }

        /// <summary>
        ///GetAllCcpMains 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllCcpMainsTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            CcpMainDataObjectList expected = null; // TODO: 初始化为适当的值
            CcpMainDataObjectList actual;
            actual = target.GetAllCcpMains();
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetAllIntUnits 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllIntUnitsTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            IntUnitDataObjectList expected = null; // TODO: 初始化为适当的值
            IntUnitDataObjectList actual;
            actual = target.GetAllIntUnits();
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetAllOilHistorys 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllOilHistorysTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            OilHistoryDataObjectList expected = null; // TODO: 初始化为适当的值
            OilHistoryDataObjectList actual;
            actual = target.GetAllOilHistorys();
            Assert.IsTrue(actual.Count > 0);
        }

        /// <summary>
        ///GetAllPartsMonitorDetails 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllPartsMonitorDetailsTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            PartsMonitorDetailDataObjectList expected = null; // TODO: 初始化为适当的值
            PartsMonitorDetailDataObjectList actual;
            int partsMonitorId = 1;
            actual = target.GetAllPartsMonitorDetails(partsMonitorId);
            Assert.IsTrue(actual.Count > 0);
        }

        /// <summary>
        ///GetAllPartsMonitors 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllPartsMonitorsTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            PartsMonitorDataObjectList expected = null; // TODO: 初始化为适当的值
            PartsMonitorDataObjectList actual;
            actual = target.GetAllPartsMonitors();
            Assert.IsTrue(actual.Count > 0);
        }

        /// <summary>
        ///GetAllPnRegs 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllPnRegsTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            PnRegDataObjectList expected = null; // TODO: 初始化为适当的值
            PnRegWithPagination actual;
            Pagination p = new Pagination();
            var result = target.GetAllPnRegs();
        }

        /// <summary>
        ///GetAllScnAcorders 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllScnAcordersTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            ScnAcorderDataObjectList expected = null; // TODO: 初始化为适当的值
            ScnAcorderDataObjectList actual;
            int scnMainId = 1;
            actual = target.GetAllScnAcorders(scnMainId);
            Assert.IsTrue(actual.Count > 0);
        }

        /// <summary>
        ///GetAllScnItems 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllScnItemsTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            ScnItemDataObjectList expected = null; // TODO: 初始化为适当的值
            ScnItemDataObjectList actual;
            int scnMainId = 1;
            actual = target.GetAllScnItems(scnMainId);
            Assert.IsTrue(actual.Count > 0);
        }

        /// <summary>
        ///GetAllScnMains 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllScnMainsTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            ScnMainDataObjectList expected = null; // TODO: 初始化为适当的值
            ScnMainDataObjectList actual;
            actual = target.GetAllScnMains();
            Assert.IsTrue(actual.Count > 0);
        }

        /// <summary>
        ///GetAllSnHistorys 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllSnHistorysTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            SnHistoryDataObjectList expected = null; // TODO: 初始化为适当的值
            SnHistoryDataObjectList actual;
            actual = target.GetAllSnHistorys();
            Assert.AreNotEqual(expected, actual);
        }
                /// <summary>
        ///GetAllSnHistorys 的测试
        ///</summary>
        [TestMethod()]
        public void GetSnHistoryPageTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            SnHistoryWithPagination expected = null; // TODO: 初始化为适当的值
            SnHistoryWithPagination actual;
            int pageNumber = 0;
            //分页信息
            var pagination = new Pagination { PageNumber = pageNumber + 1, PageSize = 20 };
            DataPage.PageIndex = pageNumber;
            DataPage.PageSize = pagination.PageSize;
            pagination.FilterDescriptors = new ColumnFilterDescriptorCollection();                   
            pagination.SortOrder = new SortOrder();
            pagination.SortPredicate = "";

            actual = target.GetSnHistoryWithPagination(pagination);
            Assert.AreNotEqual(expected, actual);
        }
        
        /// <summary>
        ///GetAllSnRegs 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllSnRegsTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            SnRegDataObjectList expected = null; // TODO: 初始化为适当的值
            SnRegDataObjectList actual;
            actual = target.GetAllSnRegs();
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetAllWfHistorys 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllWfHistorysTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            WfHistoryDataObjectList expected = null; // TODO: 初始化为适当的值
            WfHistoryDataObjectList actual;
            actual = target.GetAllWfHistorys();
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetAllWorkScopes 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllWorkScopesTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            WorkScopeDataObjectList expected = null; // TODO: 初始化为适当的值
            WorkScopeDataObjectList actual;
            actual = target.GetAllWorkScopes();
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetCcOrder 的测试
        ///</summary>
        [TestMethod()]
        public void GetCcOrderTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            int ccOrderId = 3; // TODO: 初始化为适当的值
            CcOrderDataObject expected = null; // TODO: 初始化为适当的值
            CcOrderDataObject actual;
            actual = target.GetCcOrder(ccOrderId);
            Assert.IsTrue(actual.ID==1);
        }

        /// <summary>
        ///GetCcin 的测试
        ///</summary>
        [TestMethod()]
        public void GetCcinTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            int ccinId = 1; // TODO: 初始化为适当的值
            CcinDataObject expected = null; // TODO: 初始化为适当的值
            CcinDataObject actual;
            int ccOrderId = 1;
            actual = target.GetCcin(ccOrderId,ccinId);
            Assert.IsTrue(actual.ID==1);
        }

        /// <summary>
        ///GetCcout 的测试
        ///</summary>
        [TestMethod()]
        public void GetCcoutTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            int ccoutId = 1; // TODO: 初始化为适当的值
            CcoutDataObject expected = null; // TODO: 初始化为适当的值
            CcoutDataObject actual;
            int ccOrderId = 1;
            actual = target.GetCcout(ccOrderId,ccoutId);
            Assert.IsTrue(actual.ID==1);
        }

        /// <summary>
        ///GetCcpLimit 的测试
        ///</summary>
        [TestMethod()]
        public void GetCcpLimitTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            int ccpMainId = target.GetAllCcpMains()[2].ID; // TODO: 初始化为适当的值
            CcpLimitDataObjectList expected = null; // TODO: 初始化为适当的值
            CcpLimitDataObjectList actual;
            actual = target.GetCcpLimit(ccpMainId);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetCcpMain 的测试
        ///</summary>
        [TestMethod()]
        public void GetCcpMainTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            //int ccpMainId = target.GetAllCcpMains()[7].ID; // TODO: 初始化为适当的值
            CcpMainDataObject expected = null; // TODO: 初始化为适当的值
            CcpMainDataObject actual;
            actual = target.GetCcpMain(7);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetCcpPn 的测试
        ///</summary>
        [TestMethod()]
        public void GetCcpPnTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            int ccpMainId = target.GetAllCcpMains()[2].ID; // TODO: 初始化为适当的值
            CcpPnDataObjectList expected = null; // TODO: 初始化为适当的值
            CcpPnDataObjectList actual;
            actual = target.GetCcpPn(ccpMainId);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetIntUnit 的测试
        ///</summary>
        [TestMethod()]
        public void GetIntUnitTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            int intUnitId = target.GetAllIntUnits()[3].ID; // TODO: 初始化为适当的值
            IntUnitDataObject expected = null; // TODO: 初始化为适当的值
            IntUnitDataObject actual;
            actual = target.GetIntUnit(intUnitId);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetOilHistory 的测试
        ///</summary>
        [TestMethod()]
        public void GetOilHistoryTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            int oilHistoryId = 1; // TODO: 初始化为适当的值
            OilHistoryDataObject expected = null; // TODO: 初始化为适当的值
            OilHistoryDataObject actual;
            actual = target.GetOilHistory(oilHistoryId);
            Assert.IsTrue(actual.ID==oilHistoryId);
        }

        /// <summary>
        ///GetPartsMonitor 的测试
        ///</summary>
        [TestMethod()]
        public void GetPartsMonitorTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            int partsMonitorId = 3; // TODO: 初始化为适当的值
            PartsMonitorDataObject expected = null; // TODO: 初始化为适当的值
            PartsMonitorDataObject actual;
            actual = target.GetPartsMonitor(partsMonitorId);
            Assert.IsTrue(actual.ID == partsMonitorId);
        }

        /// <summary>
        ///GetPartsMonitorDetail 的测试
        ///</summary>
        [TestMethod()]
        public void GetPartsMonitorDetailTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            int partsMonitorDetailId = 2; // TODO: 初始化为适当的值
            PartsMonitorDetailDataObject expected = null; // TODO: 初始化为适当的值
            PartsMonitorDetailDataObject actual;
            int partsMonitorId = 1;
            actual = target.GetPartsMonitorDetail(partsMonitorId,partsMonitorDetailId);
            Assert.IsTrue(actual.ID == partsMonitorDetailId);
        }
                /// <summary>
        ///GetPartsMonitorDetail 的测试
        ///</summary>
        [TestMethod()]
        public void CalculatePartsDueTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            PartsMonitorDataObject expected = null; // TODO: 初始化为适当的值
            
            bool actual;
            actual = target.CalculatePartsDue(expected);
            Assert.IsTrue(actual);
        }
        

        /// <summary>
        ///GetPnReg 的测试
        ///</summary>
        [TestMethod()]
        public void GetPnRegTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            int pnRegId = target.GetAllPnRegs()[6].ID; // TODO: 初始化为适当的值
            PnRegDataObject expected = null; // TODO: 初始化为适当的值
            PnRegDataObject actual;
            actual = target.GetPnReg(pnRegId);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetScnAcorder 的测试
        ///</summary>
        [TestMethod()]
        public void GetScnAcorderTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            int scnAcorderId = 0; // TODO: 初始化为适当的值
            ScnAcorderDataObject expected = null; // TODO: 初始化为适当的值
            ScnAcorderDataObject actual;
            int scnMainId = 0;
            actual = target.GetScnAcorder(scnMainId,scnAcorderId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetScnItem 的测试
        ///</summary>
        [TestMethod()]
        public void GetScnItemTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            int scnItemId = 0; // TODO: 初始化为适当的值
            ScnItemDataObject expected = null; // TODO: 初始化为适当的值
            ScnItemDataObject actual;
            int scnMainId = 0;
            actual = target.GetScnItem(scnMainId,scnItemId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetScnMain 的测试
        ///</summary>
        [TestMethod()]
        public void GetScnMainTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            int scnMainId = 30; // TODO: 初始化为适当的值
            ScnMainDataObject expected = null; // TODO: 初始化为适当的值
            ScnMainDataObject actual;
            actual = target.GetScnMain(scnMainId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetSnHistory 的测试
        ///</summary>
        [TestMethod()]
        public void GetSnHistoryTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            int snHistoryId = target.GetAllSnHistorys()[3].ID; // TODO: 初始化为适当的值
            SnHistoryDataObject expected = null; // TODO: 初始化为适当的值
            SnHistoryDataObject actual;
            actual = target.GetSnHistory(snHistoryId);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetSnHistoryUnit 的测试
        ///</summary>
        [TestMethod()]
        public void GetSnHistoryUnitTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            int snHistoryId = target.GetAllSnHistorys()[1].ID; // TODO: 初始化为适当的值
            SnHistoryUnitDataObjectList expected = null; // TODO: 初始化为适当的值
            SnHistoryUnitDataObjectList actual;
            actual = target.GetSnHistoryUnit(snHistoryId);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetSnReg 的测试
        ///</summary>
        [TestMethod()]
        public void GetSnRegTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            int snRegId = 1; // TODO: 初始化为适当的值
            SnRegDataObject expected = null; // TODO: 初始化为适当的值
            SnRegDataObject actual;
            actual = target.GetSnReg(snRegId);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetWfHistory 的测试
        ///</summary>
        [TestMethod()]
        public void GetWfHistoryTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            int wfHistoryId = target.GetAllWfHistorys()[2].ID; // TODO: 初始化为适当的值
            WfHistoryDataObject expected = null; // TODO: 初始化为适当的值
            WfHistoryDataObject actual;
            actual = target.GetWfHistory(wfHistoryId);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetWorkScope 的测试
        ///</summary>
        [TestMethod()]
        public void GetWorkScopeTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            int workScopeId = target.GetAllWorkScopes()[3].ID; // TODO: 初始化为适当的值
            WorkScopeDataObject expected = null; // TODO: 初始化为适当的值
            WorkScopeDataObject actual;
            actual = target.GetWorkScope(workScopeId);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///UpdateCcOrder 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateCcOrderTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            CcOrderDataObject ccOrders = target.GetCcOrder(1);
            ccOrders.Cctype = "11";
            ccOrders.WoNo = "22";
            CcOrderDataObjectList expected = new CcOrderDataObjectList()
                                             {
                                                 ccOrders
                                             }; // TODO: 初始化为适当的值
            CcOrderDataObjectList actual;
            actual = target.UpdateCcOrder(expected);
            Assert.IsTrue(actual.Count>0);
        }

        /// <summary>
        ///UpdateCcin 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateCcinTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            int ccOrderId = 1;
            CcinDataObjectList ccins = target.GetAllCcins(ccOrderId); // TODO: 初始化为适当的值
            CcinDataObjectList expected = null; // TODO: 初始化为适当的值
            CcinDataObjectList actual;
            foreach (var cc in ccins)
            {
                cc.NhSnRegID = 2;
                cc.PnRegID = 3;
                cc.Zone = "AA";
            }
            actual = target.UpdateCcin(ccOrderId,ccins);
            Assert.IsTrue(actual.Count>0);
        }

        /// <summary>
        ///UpdateCcout 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateCcoutTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            int ccOrderId = 1;
            CcoutDataObjectList ccouts = target.GetAllCcouts(ccOrderId); // TODO: 初始化为适当的值
            foreach (var ccout in ccouts)
            {
                ccout.Ata = "1";
                ccout.NhSnRegID = ccOrderId;
                ccout.PnRegID = ccOrderId;
                ccout.RootSnRegID = ccOrderId;
                ccout.Seq = ccOrderId;
                ccout.SnRegID = ccOrderId;
                ccout.UnScheduled = true;
                ccout.Zone = "2";
            }
            CcoutDataObjectList expected = null; // TODO: 初始化为适当的值
            CcoutDataObjectList actual;
           
            actual = target.UpdateCcout(ccOrderId,ccouts);
            Assert.IsTrue(actual.Count > 0);
        }

        /// <summary>
        ///UpdateCcpLimit 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateCcpLimitTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            CcpLimitDataObjectList ccpLimits = new CcpLimitDataObjectList(); // TODO: 初始化为适当的值
            var ccpLimit = target.GetAllCcpMains()[2].CcpLimits[2];
            ccpLimit.RangeMax = 8999;
            ccpLimits.Add(ccpLimit);
            int ccpMainId = target.GetAllCcpMains()[2].ID;// TODO: 初始化为适当的值
            CcpLimitDataObjectList expected = null; // TODO: 初始化为适当的值
            CcpLimitDataObjectList actual;
            actual = target.UpdateCcpLimit(ccpMainId,ccpLimits);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///UpdateCcpMain 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateCcpMainTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            CcpMainDataObjectList ccpMains = new CcpMainDataObjectList(); // TODO: 初始化为适当的值
            var ccpMain = target.GetAllCcpMains()[2];
            ccpMain.State = "停用";
            ccpMains.Add(ccpMain);
            CcpMainDataObjectList expected = null; // TODO: 初始化为适当的值
            CcpMainDataObjectList actual;
            actual = target.UpdateCcpMain(ccpMains);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///UpdateCcpPn 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateCcpPnTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            CcpPnDataObjectList ccpPns = new CcpPnDataObjectList(); // TODO: 初始化为适当的值
            var ccpPn = target.GetAllCcpMains()[2].CcpPns[3];
            ccpPn.Notes = "testupdate";
            ccpPns.Add(ccpPn);
            int ccpMainId = target.GetAllCcpMains()[2].ID;// TODO: 初始化为适当的值
            CcpPnDataObjectList expected = null; // TODO: 初始化为适当的值
            CcpPnDataObjectList actual;
            actual = target.UpdateCcpPn(ccpMainId,ccpPns);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///UpdateIntUnit 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateIntUnitTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            IntUnitDataObjectList intUnits = new IntUnitDataObjectList(); // TODO: 初始化为适当的值
            var intUnit = target.GetAllIntUnits()[2];
            intUnit.Unit = "cc";
            intUnits.Add(intUnit);
            IntUnitDataObjectList expected = null; // TODO: 初始化为适当的值
            IntUnitDataObjectList actual;
            actual = target.UpdateIntUnit(intUnits);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///UpdateOilHistory 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateOilHistoryTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            OilHistoryDataObjectList oilHistorys = target.GetAllOilHistorys(); // TODO: 初始化为适当的值
            foreach (var oilHistory in oilHistorys)
            {
                oilHistory.AcRegID = 1;
                oilHistory.AddName = "g";
                oilHistory.AddTime = "B";
                oilHistory.AtaID = 1;
                oilHistory.FlightlLogID = 1;
                oilHistory.Notes = "g";
                oilHistory.UpdateBy = "B";
                oilHistory.SnRegID = 1;
            }
            OilHistoryDataObjectList expected = null; // TODO: 初始化为适当的值
            OilHistoryDataObjectList actual;
            actual = target.UpdateOilHistory(oilHistorys);
            Assert.IsTrue(actual.Count>0);
        }

        /// <summary>
        ///UpdatePartsMonitor 的测试
        ///</summary>
        [TestMethod()]
        public void UpdatePartsMonitorTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            PartsMonitorDataObjectList partsMonitors = target.GetAllPartsMonitors(); // TODO: 初始化为适当的值
            foreach (var partsMonitor in partsMonitors)
            {
                partsMonitor.CcpMainID = 1;
                partsMonitor.ExpireDate = DateTime.Now;
                partsMonitor.InstallDate =DateTime.Now;
                partsMonitor.PnRegID = 1;
                partsMonitor.PolicyExec = "1";
                partsMonitor.Position = "BB";
                partsMonitor.RemainTime = "10";
                partsMonitor.SnRegID = 1;
                partsMonitor.UsedTime = "10";
                partsMonitor.WorkScope = "A1";
                partsMonitor.Zone = "B2";

            }
            PartsMonitorDataObjectList expected = null; // TODO: 初始化为适当的值
            PartsMonitorDataObjectList actual;
            actual = target.UpdatePartsMonitor(partsMonitors);
            Assert.IsTrue(actual.Count > 0);
        }

        /// <summary>
        ///UpdatePartsMonitorDetail 的测试
        ///</summary>
        [TestMethod()]
        public void UpdatePartsMonitorDetailTest()
        {
            int partsMonitorId =1;
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            PartsMonitorDetailDataObjectList partsMonitorDetails =target.GetAllPartsMonitorDetails(partsMonitorId); // TODO: 初始化为适当的值
            foreach (var pmd in partsMonitorDetails)
            {
                pmd.Interval = 10;
                pmd.ExpireDate = DateTime.Now;
                pmd.Unit = "FH";
                pmd.Remain = 10;
                pmd.USN = 100;
                pmd.USO = 100;
                pmd.USR = 100;
            }
            PartsMonitorDetailDataObjectList expected = null; // TODO: 初始化为适当的值
            PartsMonitorDetailDataObjectList actual;
            
            actual = target.UpdatePartsMonitorDetail(partsMonitorId,partsMonitorDetails);
            Assert.IsTrue(actual.Count > 0);
        }

        /// <summary>
        ///UpdatePnReg 的测试
        ///</summary>
        [TestMethod()]
        public void UpdatePnRegTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            PnRegDataObjectList pnRegs = new PnRegDataObjectList(); // TODO: 初始化为适当的值
            var pnReg = target.GetAllPnRegs()[3];
            pnReg.State = "停用";
            pnRegs.Add(pnReg);
            PnRegDataObjectList expected = null; // TODO: 初始化为适当的值
            PnRegDataObjectList actual;
            actual = target.UpdatePnReg(pnRegs);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///UpdateScnAcorder 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateScnAcorderTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            ScnAcorderDataObjectList scnAcorders = null; // TODO: 初始化为适当的值
            ScnAcorderDataObjectList expected = null; // TODO: 初始化为适当的值
            ScnAcorderDataObjectList actual;
            int scnMainId = 0;
            actual = target.UpdateScnAcorder(scnMainId,scnAcorders);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateScnItem 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateScnItemTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            ScnItemDataObjectList scnItems = null; // TODO: 初始化为适当的值
            ScnItemDataObjectList expected = null; // TODO: 初始化为适当的值
            ScnItemDataObjectList actual;
            int scnMainId = 0;
            actual = target.UpdateScnItem(scnMainId,scnItems);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateScnMain 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateScnMainTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            ScnMainDataObjectList scnMains = null; // TODO: 初始化为适当的值
            ScnMainDataObjectList expected = null; // TODO: 初始化为适当的值
            ScnMainDataObjectList actual;
            actual = target.UpdateScnMain(scnMains);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateSnHistory 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateSnHistoryTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            SnHistoryDataObjectList snHistorys = new SnHistoryDataObjectList(); // TODO: 初始化为适当的值
            var snHistory = target.GetAllSnHistorys()[1];
            snHistory.Active = "装载";
            snHistorys.Add(snHistory);
            SnHistoryDataObjectList expected = null; // TODO: 初始化为适当的值
            SnHistoryDataObjectList actual;
            actual = target.UpdateSnHistory(snHistorys);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///UpdateSnHistoryUnit 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateSnHistoryUnitTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            SnHistoryUnitDataObjectList snHistoryUnits = new SnHistoryUnitDataObjectList(); // TODO: 初始化为适当的值
            var snHistoryUnit = target.GetAllSnHistorys()[1].SnHistoryUnits[3];
            snHistoryUnit.USN = 9000;
            snHistoryUnits.Add(snHistoryUnit);
            int snHistoryId = target.GetAllSnHistorys()[1].ID;
            SnHistoryUnitDataObjectList expected = null; // TODO: 初始化为适当的值
            SnHistoryUnitDataObjectList actual;
            actual = target.UpdateSnHistoryUnit(snHistoryId,snHistoryUnits);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///UpdateSnReg 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateSnRegTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            SnRegDataObjectList snRegs = new SnRegDataObjectList(); // TODO: 初始化为适当的值
            var snReg = target.GetAllSnRegs()[2];
            snReg.Note = "testSn";
            snRegs.Add(snReg);
            SnRegDataObjectList expected = null; // TODO: 初始化为适当的值
            SnRegDataObjectList actual;
            actual = target.UpdateSnReg(snRegs);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///UpdateWfHistory 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateWfHistoryTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            WfHistoryDataObjectList wfHistorys = target.GetAllWfHistorys(); // TODO: 初始化为适当的值
            foreach (var wfHistory in wfHistorys)
            {
                wfHistory.Auditor = "至正科技";
            }
            WfHistoryDataObjectList expected = null; // TODO: 初始化为适当的值
            WfHistoryDataObjectList actual;
            actual = target.UpdateWfHistory(wfHistorys);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///UpdateWorkScope 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateWorkScopeTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            WorkScopeDataObjectList workScopes = new WorkScopeDataObjectList(); // TODO: 初始化为适当的值
            var workScope = target.GetAllWorkScopes()[3];
            workScope.Description = "testWorkScope";
            workScopes.Add(workScope);
            WorkScopeDataObjectList expected = null; // TODO: 初始化为适当的值
            WorkScopeDataObjectList actual;
            actual = target.UpdateWorkScope(workScopes);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///QueryAllCcpMain 的测试
        ///</summary>
        [TestMethod()]
        public void QueryAllCcpMainTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            string acModel = "A330"; // TODO: 初始化为适当的值
            string itemNo = ""; // TODO: 初始化为适当的值
            string ata = "72"; // TODO: 初始化为适当的值
            string state = ""; // TODO: 初始化为适当的值
            CcpMainDataObjectList expected = null; // TODO: 初始化为适当的值
            CcpMainDataObjectList actual;
            actual = target.QueryAllCcpMain(acModel, itemNo, ata, state);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetAllItem 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllItemTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            string[] expected = null; // TODO: 初始化为适当的值
            string[] actual;
            actual = target.GetAllItem();
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///QueryPartsMonitor 的测试
        ///</summary>
        [TestMethod()]
        public void QueryPartsMonitorTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            string acRegID = ""; // TODO: 初始化为适当的值
            int ccpMainID = 0; // TODO: 初始化为适当的值
            int pnRegID = 0; // TODO: 初始化为适当的值
            int snRegID = 0; // TODO: 初始化为适当的值
            DateTime expireDate = new DateTime(); // TODO: 初始化为适当的值
            string position = string.Empty; // TODO: 初始化为适当的值
            PartsMonitorDataObjectList expected = null; // TODO: 初始化为适当的值
            PartsMonitorDataObjectList actual;
            actual = target.QueryPartsMonitor(acRegID, ccpMainID, pnRegID, snRegID, expireDate, position);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetSnHistoryBySnRegID 的测试
        ///</summary>
        [TestMethod()]
        public void GetSnHistoryBySnRegIDTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            int snRegID = 1; // TODO: 初始化为适当的值
            SnHistoryDataObjectList expected = null; // TODO: 初始化为适当的值
            SnHistoryDataObjectList actual;
            actual = target.GetSnHistoryBySnRegID(snRegID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///QuerySnRegs 的测试
        ///</summary>
        [TestMethod()]
        public void QuerySnRegsTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            int acRegId = 0; // TODO: 初始化为适当的值
            int pnRegId = 1; // TODO: 初始化为适当的值
            string sn = "test5"; // TODO: 初始化为适当的值
            SnRegDataObjectList expected = null; // TODO: 初始化为适当的值
            SnRegDataObjectList actual;
            actual = target.QuerySnRegDtos("",0,0,"","");
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAllCcOrderInfo 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllCcOrderInfoTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
      
        }

        /// <summary>
        ///VerifyCcOrder 的测试
        ///</summary>
        [TestMethod()]
        public void VerifyCcOrderTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            Assert.Inconclusive("无法验证不返回值的方法。");
        }

        /// <summary>
        ///QueryCcOrder 的测试
        ///</summary>
        [TestMethod()]
        public void QueryCcOrderTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            string pnReg = ""; // TODO: 初始化为适当的值
            string snReg = ""; // TODO: 初始化为适当的值
            string ccType = "拆装"; // TODO: 初始化为适当的值
            string ccNature = "非计划性拆下"; // TODO: 初始化为适当的值
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CommitWorkScopes 的测试
        ///</summary>
        [TestMethod()]
        public void CommitWorkScopesTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            WorkScopeResultData workScopeData = new WorkScopeResultData(); // TODO: 初始化为适当的值

            WorkScopeResultData expected = workScopeData; // TODO: 初始化为适当的值
            WorkScopeResultData actual;
            actual = target.CommitWorkScopes(workScopeData);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///CommitCcOrders 的测试
        ///</summary>
        [TestMethod()]
        public void CommitCcOrdersTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            CcOrderResultData ccOrderData = new CcOrderResultData()
                                            {
                                                AddedCollection = new CcOrderDataObjectList()
                                                                  {
                                                                      new CcOrderDataObject(){AcReg="B-2688",Cctype="Remove",OrderNo="AD009",State="Edit",
                                                                          RemReason="zhyy",WoItem="",WoNo="",WoType="",
                                                                          Ccins=new CcinDataObject(){EngineTli="22K",NhSnRegID=12,Zone="09",
                                                                          RootSnRegID=23,PnRegID=12,Ata="03",AtaGuid=Guid.NewGuid()},
                                                                          Ccouts=new CcoutDataObject(){AtaGuid=Guid.NewGuid(),NhSnRegID=12,RootSnRegID=21,
                                                                          PnRegID=12,SnRegID=3,UnScheduled=true,Seq=2,}
                                                                      }
                                                                  },
                                                //ModefiedCollection = new CcOrderDataObjectList()
                                                //                     {
                                                //                         new CcOrderDataObject(){ID=4,OperatDate=DateTime.Now}
                                                //                     }
                                            }; // TODO: 初始化为适当的值
            CcOrderResultData expected = null; // TODO: 初始化为适当的值
            CcOrderResultData actual;
            actual = target.CommitCcOrders(ccOrderData);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///CommitCcpMains 的测试
        ///</summary>
        [TestMethod()]
        public void CommitCcpMainsTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            CcpMainResultData ccpMainData = null; // TODO: 初始化为适当的值
            CcpMainResultData expected = null; // TODO: 初始化为适当的值
            CcpMainResultData actual;
            CcpMainDataObject db = target.GetCcpMain(51);
            db.CcpLimits[0].Interval = 5000;
            ccpMainData = new CcpMainResultData();
            ccpMainData.ModefiedCollection = new CcpMainDataObjectList{ db };
            actual = target.CommitCcpMains(ccpMainData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CommitIntUnits 的测试
        ///</summary>
        [TestMethod()]
        public void CommitIntUnitsTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            IntUnitResultData intUnitData = null; // TODO: 初始化为适当的值
            IntUnitResultData expected = null; // TODO: 初始化为适当的值
            IntUnitResultData actual;
            actual = target.CommitIntUnits(intUnitData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CommitOilHistorys 的测试
        ///</summary>
        [TestMethod()]
        public void CommitOilHistorysTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            OilHistoryResultData oilHistoryData = null; // TODO: 初始化为适当的值
            OilHistoryResultData expected = null; // TODO: 初始化为适当的值
            OilHistoryResultData actual;
            actual = target.CommitOilHistorys(oilHistoryData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CommitPartsMonitors 的测试
        ///</summary>
        [TestMethod()]
        public void CommitPartsMonitorsTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            PartsMonitorResultData partsMonitorData = null; // TODO: 初始化为适当的值
            PartsMonitorResultData expected = null; // TODO: 初始化为适当的值
            PartsMonitorResultData actual;
            actual = target.CommitPartsMonitors(partsMonitorData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CommitPnRegs 的测试
        ///</summary>
        [TestMethod()]
        public void CommitPnRegsTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            PnRegResultData pnRegData = null; // TODO: 初始化为适当的值
            PnRegResultData expected = null; // TODO: 初始化为适当的值
            PnRegResultData actual;
            actual = target.CommitPnRegs(pnRegData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CommitScnMains 的测试
        ///</summary>
        [TestMethod()]
        public void CommitScnMainsTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            ScnMainResultData scnMainData = new ScnMainResultData()
                                            {
                                                AddedCollection = new ScnMainDataObjectList()
                                                                     {
                                                                         
                                                                         new ScnMainDataObject(){Description="A",AcModelGuid=Guid.NewGuid(),
                                                                             ModName="123",ColseTime=DateTime.Now,ScnTitle="KKKK",
                                                                             ScnAcorders=new ScnAcorderDataObjectList()
                                                                                         {
                                                                                             new ScnAcorderDataObject(){AcOrder="0022",AcOrderItem="2"} 
                                                                                         },
                                                                         WfHistorys=new WfHistoryDataObjectList()
                                                                                    {
                                                                                        new WfHistoryDataObject() { Department = "技术标准室", Seq = "1", AuditTime = DateTime.Now,Business="scnmain" },
                                                                                        new WfHistoryDataObject() { Department = "机身系统室", Seq = "2", AuditTime = DateTime.Now, Business = "scnmain" },
                                                                                        new WfHistoryDataObject() { Department = "航材计划室", Seq = "3", AuditTime = DateTime.Now, Business = "scnmain" },
                                                                                        new WfHistoryDataObject() { Department = "机务工程部", Seq = "4", AuditTime = DateTime.Now, Business = "scnmain" }
                                                                                    }}

                                                                     }
                                            }; // TODO: 初始化为适当的值
            ScnMainResultData expected = null; // TODO: 初始化为适当的值
            ScnMainResultData actual;
            actual = target.CommitScnMains(scnMainData);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///CommitSnHistorys 的测试
        ///</summary>
        [TestMethod()]
        public void CommitSnHistorysTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            SnHistoryResultData snHistoryData = null; // TODO: 初始化为适当的值
            SnHistoryResultData expected = null; // TODO: 初始化为适当的值
            SnHistoryResultData actual;
            actual = target.CommitSnHistorys(snHistoryData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CommitSnRegs 的测试
        ///</summary>
        [TestMethod()]
        public void CommitSnRegsTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            SnRegResultData snRegData = null; // TODO: 初始化为适当的值
            SnRegResultData expected = null; // TODO: 初始化为适当的值
            SnRegResultData actual;
            actual = target.CommitSnRegs(snRegData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CommitWfHistorys 的测试
        ///</summary>
        [TestMethod()]
        public void CommitWfHistorysTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            WfHistoryResultData wfHistoryData = null; // TODO: 初始化为适当的值
            WfHistoryResultData expected = null; // TODO: 初始化为适当的值
            WfHistoryResultData actual;
            actual = target.CommitWfHistorys(wfHistoryData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetCcOrderWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GetCcOrderWithPaginationTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            Pagination pagination = new Pagination()
                                    {
                                        PageNumber=1,PageSize=3,SortOrder=SortOrder.Ascending,
                                        SortPredicate="Id"
                                    }; // TODO: 初始化为适当的值
            CcOrderWithPagination expected = null; // TODO: 初始化为适当的值
            CcOrderWithPagination actual;
            actual = target.GetCcOrderWithPagination(pagination);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetWorkScopeWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GetWorkScopeWithPaginationTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            Pagination pagination = new Pagination()
            {
                PageNumber = 1,
                PageSize = 3,
                SortOrder = SortOrder.Ascending,
                SortPredicate = "Id"
            }; // TODO: 初始化为适当的值
            WorkScopeWithPagination expected = null; // TODO: 初始化为适当的值
            WorkScopeWithPagination actual;
            actual = target.GetWorkScopeWithPagination(pagination);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetWfHistoryWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GetWfHistoryWithPaginationTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            Pagination pagination = new Pagination()
            {
                PageNumber = 1,
                PageSize = 3,
                SortOrder = SortOrder.Ascending,
                SortPredicate = "Id"
            }; // TODO: 初始化为适当的值
            WfHistoryWithPagination expected = null; // TODO: 初始化为适当的值
            WfHistoryWithPagination actual;
            actual = target.GetWfHistoryWithPagination(pagination);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetSnRegWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GetSnRegWithPaginationTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            Pagination pagination = new Pagination()
            {
                PageNumber = 1,
                PageSize = 3,
                SortOrder = SortOrder.Ascending,
                SortPredicate = "Id"
            }; // TODO: 初始化为适当的值
            SnRegWithPagination expected = null; // TODO: 初始化为适当的值
            SnRegWithPagination actual;
            actual = target.GetSnRegWithPagination(pagination);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetSnHistoryWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GetSnHistoryWithPaginationTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            Pagination pagination = new Pagination()
            {
                PageNumber = 1,
                PageSize = 3,
                SortOrder = SortOrder.Ascending,
                SortPredicate = "Id"
            }; // TODO: 初始化为适当的值
            SnHistoryWithPagination expected = null; // TODO: 初始化为适当的值
            SnHistoryWithPagination actual;
            actual = target.GetSnHistoryWithPagination(pagination);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetPnRegWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GetPnRegWithPaginationTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            Pagination pagination = new Pagination()
            {
                PageNumber = 1,
                PageSize = 3,
                SortOrder = SortOrder.Ascending,
                SortPredicate = "Id"
            }; // TODO: 初始化为适当的值
            PnRegWithPagination expected = null; // TODO: 初始化为适当的值
            PnRegWithPagination actual;
            actual = target.GetPnRegWithPagination(pagination);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetScnMainWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GetScnMainWithPaginationTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            Pagination pagination = new Pagination()
            {
                PageNumber = 1,
                PageSize = 3,
                SortOrder = SortOrder.Ascending,
                SortPredicate = "Id"
            }; // TODO: 初始化为适当的值
            ScnMainWithPagination expected = null; // TODO: 初始化为适当的值
            ScnMainWithPagination actual;
            actual = target.GetScnMainWithPagination(pagination);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetPartsMonitorWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GetPartsMonitorWithPaginationTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            Pagination pagination = new Pagination()
            {
                PageNumber = 1,
                PageSize = 3,
                SortOrder = SortOrder.Ascending,
                SortPredicate = "Id"
            }; // TODO: 初始化为适当的值
            PartsMonitorWithPagination expected = null; // TODO: 初始化为适当的值
            PartsMonitorWithPagination actual;
            actual = target.GetPartsMonitorWithPagination(pagination);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetOilHistoryWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GetOilHistoryWithPaginationTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            Pagination pagination = new Pagination()
            {
                PageNumber = 1,
                PageSize = 3,
                SortOrder = SortOrder.Ascending,
                SortPredicate = "Id"
            }; // TODO: 初始化为适当的值
            OilHistoryWithPagination expected = null; // TODO: 初始化为适当的值
            OilHistoryWithPagination actual;
            actual = target.GetOilHistoryWithPagination(pagination);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetIntUnitWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GetIntUnitWithPaginationTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            Pagination pagination = new Pagination()
            {
                PageNumber = 1,
                PageSize = 3,
                SortOrder = SortOrder.Ascending,
                SortPredicate = "Id"
            }; // TODO: 初始化为适当的值
            IntUnitWithPagination expected = null; // TODO: 初始化为适当的值
            IntUnitWithPagination actual;
            actual = target.GetIntUnitWithPagination(pagination);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetCcpMainWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GetCcpMainWithPaginationTest()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            Pagination pagination = new Pagination()
            {
                PageNumber = 1,
                PageSize = 3,
                SortOrder = SortOrder.Ascending,
                SortPredicate = "Id"
            }; // TODO: 初始化为适当的值
            CcpMainWithPagination expected = null; // TODO: 初始化为适当的值
            CcpMainWithPagination actual;
            actual = target.GetCcpMainWithPagination(pagination);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///VerifyCcOrder 的测试
        ///</summary>
        [TestMethod()]
        public void VerifyCcOrderTest1()
        {
            IPartService target = CreateIPartService(); // TODO: 初始化为适当的值
            int ccOrderId = 39; // TODO: 初始化为适当的值
            target.VerifyCcOrder(ccOrderId);
            System.Threading.Thread.Sleep(TimeSpan.FromMinutes(5));
            Assert.Inconclusive("无法验证不返回值的方法。");
        }
    }
}
