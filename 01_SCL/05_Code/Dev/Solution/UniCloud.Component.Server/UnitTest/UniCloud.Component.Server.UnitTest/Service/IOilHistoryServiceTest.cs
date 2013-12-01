using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Component.Server.UnitTest
{
    
    
    /// <summary>
    ///这是 IOilHistoryServiceTest 的测试类，旨在
    ///包含所有 IOilHistoryServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class IOilHistoryServiceTest
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


        internal virtual IOilHistoryService CreateIOilHistoryService()
        {
            // TODO: 实例化相应的具体类。
            IOilHistoryService target = ServiceLocator.Instance.GetService<IOilHistoryService>();
            return target;
        }

        /// <summary>
        ///CommitOilHistorys 的测试
        ///</summary>
        [TestMethod()]
        public void CommitOilHistorysTest()
        {
            IOilHistoryService target = CreateIOilHistoryService(); // TODO: 初始化为适当的值
            OilHistoryResultData oilHistoryData = null; // TODO: 初始化为适当的值
            OilHistoryResultData expected = null; // TODO: 初始化为适当的值
            OilHistoryResultData actual;
            actual = target.CommitOilHistorys(oilHistoryData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreateOilHistorys 的测试
        ///</summary>
        [TestMethod()]
        public void CreateOilHistorysTest()
        {
            IOilHistoryService target = CreateIOilHistoryService(); // TODO: 初始化为适当的值
            OilHistoryDataObjectList oilHistorys = null; // TODO: 初始化为适当的值
            OilHistoryDataObjectList expected = null; // TODO: 初始化为适当的值
            OilHistoryDataObjectList actual;
            actual = target.CreateOilHistorys(oilHistorys);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteOilHistorys 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteOilHistorysTest()
        {
            IOilHistoryService target = CreateIOilHistoryService(); // TODO: 初始化为适当的值
            IDList oilHistoryIDs = null; // TODO: 初始化为适当的值
            IDList expected = null; // TODO: 初始化为适当的值
            IDList actual;
            actual = target.DeleteOilHistorys(oilHistoryIDs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullOilHistoryByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullOilHistoryByIDTest()
        {
            IOilHistoryService target = CreateIOilHistoryService(); // TODO: 初始化为适当的值
            int id = 0; // TODO: 初始化为适当的值
            OilHistoryDataObject expected = null; // TODO: 初始化为适当的值
            OilHistoryDataObject actual;
            actual = target.GetFullOilHistoryByID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullOilHistorys 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullOilHistorysTest()
        {
            IOilHistoryService target = CreateIOilHistoryService(); // TODO: 初始化为适当的值
            OilHistoryDataObjectList expected = null; // TODO: 初始化为适当的值
            OilHistoryDataObjectList actual;
            actual = target.GetFullOilHistorys();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateOilHistorys 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateOilHistorysTest()
        {
            IOilHistoryService target = CreateIOilHistoryService(); // TODO: 初始化为适当的值
            OilHistoryDataObjectList oilHistorys = null; // TODO: 初始化为适当的值
            OilHistoryDataObjectList expected = null; // TODO: 初始化为适当的值
            OilHistoryDataObjectList actual;
            actual = target.UpdateOilHistorys(oilHistorys);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
