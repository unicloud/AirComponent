using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Component.Server.UnitTest
{
    
    
    /// <summary>
    ///这是 IIntUnitServiceTest 的测试类，旨在
    ///包含所有 IIntUnitServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class IIntUnitServiceTest
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


        internal virtual IIntUnitService CreateIIntUnitService()
        {
            // TODO: 实例化相应的具体类。
            IIntUnitService target = ServiceLocator.Instance.GetService<IIntUnitService>();
            return target;
        }

        /// <summary>
        ///CommitIntUnits 的测试
        ///</summary>
        [TestMethod()]
        public void CommitIntUnitsTest()
        {
            IIntUnitService target = CreateIIntUnitService(); // TODO: 初始化为适当的值
            IntUnitResultData intUnitData = new IntUnitResultData()
                                            {
                                                AddedCollection = new IntUnitDataObjectList()
                                                                  {
                                                                      new IntUnitDataObject()
                                                                      {
                                                                          Descritption="a",ShortName="b",Type="c",Unit="d"
                                                                      }
                                                                  }
                                            }; // TODO: 初始化为适当的值

            IntUnitResultData expected = null; // TODO: 初始化为适当的值
            IntUnitResultData actual;
            actual = target.CommitIntUnits(intUnitData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreateIntUnits 的测试
        ///</summary>
        [TestMethod()]
        public void CreateIntUnitsTest()
        {
            IIntUnitService target = CreateIIntUnitService(); // TODO: 初始化为适当的值
            IntUnitDataObjectList intUnits = null; // TODO: 初始化为适当的值
            IntUnitDataObjectList expected = null; // TODO: 初始化为适当的值
            IntUnitDataObjectList actual;
            actual = target.CreateIntUnits(intUnits);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteIntUnits 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteIntUnitsTest()
        {
            IIntUnitService target = CreateIIntUnitService(); // TODO: 初始化为适当的值
            IDList intUnitIDs = null; // TODO: 初始化为适当的值
            IDList expected = null; // TODO: 初始化为适当的值
            IDList actual;
            actual = target.DeleteIntUnits(intUnitIDs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

      

        /// <summary>
        ///UpdateIntUnits 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateIntUnitsTest()
        {
            IIntUnitService target = CreateIIntUnitService(); // TODO: 初始化为适当的值
            IntUnitDataObjectList intUnits = null; // TODO: 初始化为适当的值
            IntUnitDataObjectList expected = null; // TODO: 初始化为适当的值
            IntUnitDataObjectList actual;
            actual = target.UpdateIntUnits(intUnits);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
