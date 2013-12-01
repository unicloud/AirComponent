using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;
using UniCloud.Query;
//using UniCloud.Infrastructure.Common.Input;

namespace UniCloud.Component.Server.UnitTest
{
    
    
    /// <summary>
    ///这是 ISnRegServiceTest 的测试类，旨在
    ///包含所有 ISnRegServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class ISnRegServiceTest
    {


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

        [TestInitialize()]
        public void MyTestInitialize()
        {
            Initializer.Init();
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
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        internal virtual ISnRegService CreateISnRegService()
        {
            // TODO: 实例化相应的具体类。
            ISnRegService target = ServiceLocator.Instance.GetService<ISnRegService>();
            return target;
        }
        internal virtual ISnRegQuery CreateISnRegQuery()
        {
            // TODO: 实例化相应的具体类。
            ISnRegQuery target = ServiceLocator.Instance.GetService<ISnRegQuery>();
            return target;
        }

        /// <summary>
        ///CommitSnRegs 的测试
        ///</summary>
        [TestMethod()]
        public void CommitSnRegsTest()
        {
            ISnRegService target = CreateISnRegService(); // TODO: 初始化为适当的值
            SnRegResultData snRegData = null; // TODO: 初始化为适当的值
            SnRegResultData expected = null; // TODO: 初始化为适当的值
            SnRegResultData actual;
            actual = target.CommitSnRegs(snRegData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreateSnRegs 的测试
        ///</summary>
        [TestMethod()]
        public void CreateSnRegsTest()
        {
            ISnRegService target = CreateISnRegService(); // TODO: 初始化为适当的值
            SnRegDataObjectList snRegs = null; // TODO: 初始化为适当的值
            int expected = 1; // TODO: 初始化为适当的值
            SnRegDataObjectList actual;
            snRegs = new SnRegDataObjectList();
            SnRegDataObject sn = new SnRegDataObject();
            sn.Ac = "B-6321";
            sn.Ata = "72";
            sn.Avail = "IN";
            sn.EngineTli = "26K";
            sn.InstallDate = DateTime.Now;
            sn.ItemNo = "";
            sn.PnReg = new PnRegDataObject();
            sn.PnReg.Pn = "V2500-A5";
            sn.NhSnReg = new SnRegDataObject();
            //sn.NhSnReg.Sn = "00000";
            //sn.NhSnReg.PnReg = new PnRegDataObject();
            //sn.NhSnReg.PnReg.Pn = "V2500-A5";
            sn.Position = "R";
            sn.Sn = "0021";
            sn.Zone = "420";
            sn.SnCsn = new SnHistoryUnitDataObject();
            sn.SnCsn.Unit = "CY";
            sn.SnCsn.USI = 100;
            sn.SnCsn.USN = 400;
            sn.SnCsn.USO = 320;
            sn.SnCsn.USR = 300;
            sn.SnTsn = new SnHistoryUnitDataObject();
            sn.SnTsn.Unit = "FH";
            sn.SnTsn.USI = 300;
            sn.SnTsn.USN = 250;
            sn.SnTsn.USO = 220;
            sn.SnTsn.USR = 200;
            snRegs.Add(sn);
            actual = target.CreateSnRegs(snRegs);
            Assert.AreEqual(expected, actual.Count);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteSnRegs 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteSnRegsTest()
        {
            ISnRegService target = CreateISnRegService(); // TODO: 初始化为适当的值
            IDList snRegIDs = null; // TODO: 初始化为适当的值
            IDList expected = null; // TODO: 初始化为适当的值
            IDList actual;
            actual = target.DeleteSnRegs(snRegIDs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullSnRegByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullSnRegByIDTest()
        {
            ISnRegService target = CreateISnRegService(); // TODO: 初始化为适当的值
            int id = 0; // TODO: 初始化为适当的值
            SnRegDataObject expected = null; // TODO: 初始化为适当的值
            SnRegDataObject actual;
            actual = target.GetFullSnRegByID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullSnRegs 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullSnRegsTest()
        {
            ISnRegService target = CreateISnRegService(); // TODO: 初始化为适当的值
            SnRegDataObjectList expected = null; // TODO: 初始化为适当的值
            SnRegDataObjectList actual;
            actual = target.GetFullSnRegs();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
        /// <summary>
        ///GetSnRegPageTest 的测试
        ///</summary>
        [TestMethod()]
        public void GetSnRegPageTest()
        {
            ISnRegQuery target = CreateISnRegQuery(); // TODO: 初始化为适当的值
            Pagination pagination = null; // TODO: 初始化为适当的值
            int pageNumber = 0;
            //分页信息
            pagination = new Pagination { PageNumber = pageNumber + 1, PageSize = 20 };
            //DataPage.PageIndex = pageNumber;
            //DataPage.PageSize = pagination.PageSize;
            pagination.FilterDescriptors = new ColumnFilterDescriptorCollection();
            //pagination.SortOrder = new SortOrder();
            //pagination.SortPredicate = "";

            SnRegWithPagination actual;
            actual = target.GetSnRegWithPagination(pagination);
            Assert.AreEqual(pagination, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
        /// <summary>
        ///QuerySnRegDtos 的测试
        ///</summary>
        [TestMethod()]
        public void QuerySnRegDtosTest()
        {
            ISnRegService target = CreateISnRegService(); // TODO: 初始化为适当的值
            string itemNo = string.Empty; // TODO: 初始化为适当的值
            int pnId = 0; // TODO: 初始化为适当的值
            int snId = 0; // TODO: 初始化为适当的值
            string ac = string.Empty; // TODO: 初始化为适当的值
            string avail = string.Empty; // TODO: 初始化为适当的值
            SnRegDataObjectList expected = null; // TODO: 初始化为适当的值
            SnRegDataObjectList actual;
            actual = target.QuerySnRegDtos(itemNo, pnId, snId, ac, avail);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///QuerySnRegs 的测试
        ///</summary>
        [TestMethod()]
        public void QuerySnRegsTest()
        {
            ISnRegService target = CreateISnRegService(); // TODO: 初始化为适当的值
            string ac = string.Empty; // TODO: 初始化为适当的值
            int pnRegId = 0; // TODO: 初始化为适当的值
            string sn = string.Empty; // TODO: 初始化为适当的值
            SnRegDataObjectList expected = null; // TODO: 初始化为适当的值
            SnRegDataObjectList actual;
            actual = target.QuerySnRegs(ac, pnRegId, sn);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateSnRegs 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateSnRegsTest()
        {
            ISnRegService target = CreateISnRegService(); // TODO: 初始化为适当的值
            SnRegDataObjectList snRegs = null; // TODO: 初始化为适当的值
            SnRegDataObjectList expected = null; // TODO: 初始化为适当的值
            SnRegDataObjectList actual;
            actual = target.UpdateSnRegs(snRegs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
