using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Component.Server.UnitTest
{
    
    
    /// <summary>
    ///这是 IOilAnalysisServiceTest 的测试类，旨在
    ///包含所有 IOilAnalysisServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class IOilAnalysisServiceTest
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


        internal virtual IOilAnalysisService CreateIOilAnalysisService()
        {
            // TODO: 实例化相应的具体类。
            IOilAnalysisService target = ServiceLocator.Instance.GetService<IOilAnalysisService>();
            return target;
        }

        /// <summary>
        ///CommitOilAnalysiss 的测试
        ///</summary>
        [TestMethod()]
        public void CommitOilAnalysissTest()
        {
            IOilAnalysisService target = CreateIOilAnalysisService(); // TODO: 初始化为适当的值
            OilAnalysisResultData oilAnalysisData = null; // TODO: 初始化为适当的值
            OilAnalysisResultData expected = null; // TODO: 初始化为适当的值
            OilAnalysisResultData actual;
            actual = target.CommitOilAnalysiss(oilAnalysisData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreateOilAnalysiss 的测试
        ///</summary>
        [TestMethod()]
        public void CreateOilAnalysissTest()
        {
            IOilAnalysisService target = CreateIOilAnalysisService(); // TODO: 初始化为适当的值
            OilAnalysisDataObjectList oilAnalysiss = null; // TODO: 初始化为适当的值
            OilAnalysisDataObjectList expected = null; // TODO: 初始化为适当的值
            OilAnalysisDataObjectList actual;
            actual = target.CreateOilAnalysiss(oilAnalysiss);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteOilAnalysiss 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteOilAnalysissTest()
        {
            IOilAnalysisService target = CreateIOilAnalysisService(); // TODO: 初始化为适当的值
            IDList oilAnalysisIDs = null; // TODO: 初始化为适当的值
            IDList expected = null; // TODO: 初始化为适当的值
            IDList actual;
            actual = target.DeleteOilAnalysiss(oilAnalysisIDs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullOilAnalysisByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullOilAnalysisByIDTest()
        {
            IOilAnalysisService target = CreateIOilAnalysisService(); // TODO: 初始化为适当的值
            int id = 0; // TODO: 初始化为适当的值
            OilAnalysisDataObject expected = null; // TODO: 初始化为适当的值
            OilAnalysisDataObject actual;
            actual = target.GetFullOilAnalysisByID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullOilAnalysiss 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullOilAnalysissTest()
        {
            IOilAnalysisService target = CreateIOilAnalysisService(); // TODO: 初始化为适当的值
            OilAnalysisDataObjectList expected = null; // TODO: 初始化为适当的值
            OilAnalysisDataObjectList actual;
            actual = target.GetFullOilAnalysiss();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateOilAnalysiss 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateOilAnalysissTest()
        {
            IOilAnalysisService target = CreateIOilAnalysisService(); // TODO: 初始化为适当的值
            OilAnalysisDataObjectList oilAnalysiss = null; // TODO: 初始化为适当的值
            OilAnalysisDataObjectList expected = null; // TODO: 初始化为适当的值
            OilAnalysisDataObjectList actual;
            actual = target.UpdateOilAnalysiss(oilAnalysiss);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
        [TestMethod()]
        public void AnalyseOilTest()
        {
            IOilAnalysisService target = CreateIOilAnalysisService(); // TODO: 初始化为适当的值

            target.OilAnalysisOntime();
           
            //Assert.Inconclusive("验证此测试方法的正确性。");
        }


    }
}
