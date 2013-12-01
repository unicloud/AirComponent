using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Component.Server.UnitTest
{
    
    
    /// <summary>
    ///这是 IEgtMarginServiceTest 的测试类，旨在
    ///包含所有 IEgtMarginServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class IEgtMarginServiceTest
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


        internal virtual IEgtMarginService CreateIEgtMarginService()
        {
            // TODO: 实例化相应的具体类。
            IEgtMarginService target = ServiceLocator.Instance.GetService<IEgtMarginService>();
            return target;
        }

        /// <summary>
        ///CommitEgtMargins 的测试
        ///</summary>
        [TestMethod()]
        public void CommitEgtMarginsTest()
        {
            IEgtMarginService target = CreateIEgtMarginService(); // TODO: 初始化为适当的值
            EgtMarginResultData egtMarginData = new EgtMarginResultData()
                                                {
                                                    AddedCollection = new EgtMarginDataObjectList()
                                                                      {
                                                                          new EgtMarginDataObject()
                                                                          {
                                                                              
                                                                          }
                                                                      }
                                                }; // TODO: 初始化为适当的值
            EgtMarginResultData expected = null; // TODO: 初始化为适当的值
            EgtMarginResultData actual;
            actual = target.CommitEgtMargins(egtMarginData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreateEgtMargins 的测试
        ///</summary>
        [TestMethod()]
        public void CreateEgtMarginsTest()
        {
            IEgtMarginService target = CreateIEgtMarginService(); // TODO: 初始化为适当的值
            EgtMarginDataObjectList egtMargins = null; // TODO: 初始化为适当的值
            EgtMarginDataObjectList expected = null; // TODO: 初始化为适当的值
            EgtMarginDataObjectList actual;
            actual = target.CreateEgtMargins(egtMargins);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteEgtMargins 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteEgtMarginsTest()
        {
            IEgtMarginService target = CreateIEgtMarginService(); // TODO: 初始化为适当的值
            IDList egtMarginIDs = null; // TODO: 初始化为适当的值
            IDList expected = null; // TODO: 初始化为适当的值
            IDList actual;
            actual = target.DeleteEgtMargins(egtMarginIDs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateEgtMargins 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateEgtMarginsTest()
        {
            IEgtMarginService target = CreateIEgtMarginService(); // TODO: 初始化为适当的值
            EgtMarginDataObjectList egtMargins = null; // TODO: 初始化为适当的值
            EgtMarginDataObjectList expected = null; // TODO: 初始化为适当的值
            EgtMarginDataObjectList actual;
            actual = target.UpdateEgtMargins(egtMargins);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
