using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Component.Server.UnitTest
{
    
    
    /// <summary>
    ///这是 IWfHistoryServiceTest 的测试类，旨在
    ///包含所有 IWfHistoryServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class IWfHistoryServiceTest
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


        internal virtual IWfHistoryService CreateIWfHistoryService()
        {
            // TODO: 实例化相应的具体类。
            IWfHistoryService target = ServiceLocator.Instance.GetService<IWfHistoryService>();
            return target;
        }

        /// <summary>
        ///CommitWfHistorys 的测试
        ///</summary>
        [TestMethod()]
        public void CommitWfHistorysTest()
        {
            IWfHistoryService target = CreateIWfHistoryService(); // TODO: 初始化为适当的值
            WfHistoryResultData wfHistoryData = null; // TODO: 初始化为适当的值
            WfHistoryResultData expected = null; // TODO: 初始化为适当的值
            WfHistoryResultData actual;
            actual = target.CommitWfHistorys(wfHistoryData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreateWfHistorys 的测试
        ///</summary>
        [TestMethod()]
        public void CreateWfHistorysTest()
        {
            IWfHistoryService target = CreateIWfHistoryService(); // TODO: 初始化为适当的值
            WfHistoryDataObjectList wfHistorys = null; // TODO: 初始化为适当的值
            WfHistoryDataObjectList expected = null; // TODO: 初始化为适当的值
            WfHistoryDataObjectList actual;
            actual = target.CreateWfHistorys(wfHistorys);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteWfHistorys 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteWfHistorysTest()
        {
            IWfHistoryService target = CreateIWfHistoryService(); // TODO: 初始化为适当的值
            IDList wfHistoryIDs = null; // TODO: 初始化为适当的值
            IDList expected = null; // TODO: 初始化为适当的值
            IDList actual;
            actual = target.DeleteWfHistorys(wfHistoryIDs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullWfHistoryByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullWfHistoryByIDTest()
        {
            IWfHistoryService target = CreateIWfHistoryService(); // TODO: 初始化为适当的值
            int id = 0; // TODO: 初始化为适当的值
            WfHistoryDataObject expected = null; // TODO: 初始化为适当的值
            WfHistoryDataObject actual;
            actual = target.GetFullWfHistoryByID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullWfHistorys 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullWfHistorysTest()
        {
            IWfHistoryService target = CreateIWfHistoryService(); // TODO: 初始化为适当的值
            WfHistoryDataObjectList expected = null; // TODO: 初始化为适当的值
            WfHistoryDataObjectList actual;
            actual = target.GetFullWfHistorys();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateWfHistorys 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateWfHistorysTest()
        {
            IWfHistoryService target = CreateIWfHistoryService(); // TODO: 初始化为适当的值
            WfHistoryDataObjectList wfHistorys = null; // TODO: 初始化为适当的值
            WfHistoryDataObjectList expected = null; // TODO: 初始化为适当的值
            WfHistoryDataObjectList actual;
            actual = target.UpdateWfHistorys(wfHistorys);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
