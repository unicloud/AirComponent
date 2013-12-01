using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Component.Server.UnitTest
{
    
    
    /// <summary>
    ///这是 IPartsMonitorServiceTest 的测试类，旨在
    ///包含所有 IPartsMonitorServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class IPartsMonitorServiceTest
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


        internal virtual IPartsMonitorService CreateIPartsMonitorService()
        {
            // TODO: 实例化相应的具体类。
            IPartsMonitorService target = ServiceLocator.Instance.GetService<IPartsMonitorService>();
            return target;
        }

        /// <summary>
        ///CommitPartsMonitors 的测试
        ///</summary>
        [TestMethod()]
        public void CommitPartsMonitorsTest()
        {
            IPartsMonitorService target = CreateIPartsMonitorService(); // TODO: 初始化为适当的值
            PartsMonitorResultData partsMonitorData = null; // TODO: 初始化为适当的值
            PartsMonitorResultData expected = null; // TODO: 初始化为适当的值
            PartsMonitorResultData actual;
            actual = target.CommitPartsMonitors(partsMonitorData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreatePartsMonitors 的测试
        ///</summary>
        [TestMethod()]
        public void CreatePartsMonitorsTest()
        {
            IPartsMonitorService target = CreateIPartsMonitorService(); // TODO: 初始化为适当的值
            PartsMonitorDataObjectList partsMonitors = null; // TODO: 初始化为适当的值
            PartsMonitorDataObjectList expected = null; // TODO: 初始化为适当的值
            PartsMonitorDataObjectList actual;
            actual = target.CreatePartsMonitors(partsMonitors);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeletePartsMonitors 的测试
        ///</summary>
        [TestMethod()]
        public void DeletePartsMonitorsTest()
        {
            IPartsMonitorService target = CreateIPartsMonitorService(); // TODO: 初始化为适当的值
            IDList partsMonitorIDs = null; // TODO: 初始化为适当的值
            IDList expected = null; // TODO: 初始化为适当的值
            IDList actual;
            actual = target.DeletePartsMonitors(partsMonitorIDs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullPartsMonitorByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullPartsMonitorByIDTest()
        {
            IPartsMonitorService target = CreateIPartsMonitorService(); // TODO: 初始化为适当的值
            int id = 0; // TODO: 初始化为适当的值
            PartsMonitorDataObject expected = null; // TODO: 初始化为适当的值
            PartsMonitorDataObject actual;
            actual = target.GetFullPartsMonitorByID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullPartsMonitors 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullPartsMonitorsTest()
        {
            IPartsMonitorService target = CreateIPartsMonitorService(); // TODO: 初始化为适当的值
            PartsMonitorDataObjectList expected = null; // TODO: 初始化为适当的值
            PartsMonitorDataObjectList actual;
            actual = target.GetFullPartsMonitors();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdatePartsMonitors 的测试
        ///</summary>
        [TestMethod()]
        public void UpdatePartsMonitorsTest()
        {
            IPartsMonitorService target = CreateIPartsMonitorService(); // TODO: 初始化为适当的值
            PartsMonitorDataObjectList partsMonitors = null; // TODO: 初始化为适当的值
            PartsMonitorDataObjectList expected = null; // TODO: 初始化为适当的值
            PartsMonitorDataObjectList actual;
            actual = target.UpdatePartsMonitors(partsMonitors);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CalculateAllCcpMain 的测试
        ///</summary>
        [TestMethod()]
        public void CalculateAllCcpMainTest()
        {
            IPartsMonitorService target = CreateIPartsMonitorService(); // TODO: 初始化为适当的值            
           
            PartsMonitorDataObjectList actual;

            actual = target.CalculateAllCcpMain();

            Assert.IsNotNull(actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CalculateAllCcpMain 的测试
        ///</summary>
        [TestMethod()]
        public void CalculateSpecificCcpMainTest()
        {
            IPartsMonitorService target = CreateIPartsMonitorService(); // TODO: 初始化为适当的值            

            PartsMonitorDataObjectList actual;
            string itemno = "90-0001";
            actual = target.CalculateSpecificCcpMain(itemno);

            Assert.IsNotNull(actual);
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
