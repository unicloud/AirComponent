using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Component.Server.UnitTest
{
    
    
    /// <summary>
    ///这是 ISnHistoryServiceTest 的测试类，旨在
    ///包含所有 ISnHistoryServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class ISnHistoryServiceTest
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


        internal virtual ISnHistoryService CreateISnHistoryService()
        {
            // TODO: 实例化相应的具体类。
            ISnHistoryService target = ServiceLocator.Instance.GetService<ISnHistoryService>();
            return target;
        }

        /// <summary>
        ///CommitSnHistorys 的测试
        ///</summary>
        [TestMethod()]
        public void CommitSnHistorysTest()
        {
            ISnHistoryService target = CreateISnHistoryService(); // TODO: 初始化为适当的值
            SnHistoryResultData snHistoryData = null; // TODO: 初始化为适当的值
            SnHistoryResultData expected = null; // TODO: 初始化为适当的值
            SnHistoryResultData actual;
            actual = target.CommitSnHistorys(snHistoryData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreateSnHistorys 的测试
        ///</summary>
        [TestMethod()]
        public void CreateSnHistorysTest()
        {
            ISnHistoryService target = CreateISnHistoryService(); // TODO: 初始化为适当的值
            SnHistoryDataObjectList snHistorys = null; // TODO: 初始化为适当的值
            SnHistoryDataObjectList expected = null; // TODO: 初始化为适当的值
            SnHistoryDataObjectList actual;
            actual = target.CreateSnHistorys(snHistorys);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteSnHistorys 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteSnHistorysTest()
        {
            ISnHistoryService target = CreateISnHistoryService(); // TODO: 初始化为适当的值
            IDList snHistoryIDs = null; // TODO: 初始化为适当的值
            IDList expected = null; // TODO: 初始化为适当的值
            IDList actual;
            actual = target.DeleteSnHistorys(snHistoryIDs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullSnHistoryByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullSnHistoryByIDTest()
        {
            ISnHistoryService target = CreateISnHistoryService(); // TODO: 初始化为适当的值
            int id = 0; // TODO: 初始化为适当的值
            SnHistoryDataObject expected = null; // TODO: 初始化为适当的值
            SnHistoryDataObject actual;
            actual = target.GetFullSnHistoryByID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullSnHistorys 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullSnHistorysTest()
        {
            ISnHistoryService target = CreateISnHistoryService(); // TODO: 初始化为适当的值
            SnHistoryDataObjectList expected = null; // TODO: 初始化为适当的值
            SnHistoryDataObjectList actual;
            actual = target.GetFullSnHistorys();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateSnHistorys 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateSnHistorysTest()
        {
            ISnHistoryService target = CreateISnHistoryService(); // TODO: 初始化为适当的值
            SnHistoryDataObjectList snHistorys = null; // TODO: 初始化为适当的值
            SnHistoryDataObjectList expected = null; // TODO: 初始化为适当的值
            SnHistoryDataObjectList actual;
            actual = target.UpdateSnHistorys(snHistorys);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
