using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Component.Server.UnitTest
{
    
    
    /// <summary>
    ///这是 IAcIntUnitUtilizaServiceTest 的测试类，旨在
    ///包含所有 IAcIntUnitUtilizaServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class IAcIntUnitUtilizaServiceTest
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


        internal virtual IAcIntUnitUtilizaService CreateIAcIntUnitUtilizaService()
        {
            // TODO: 实例化相应的具体类。
            IAcIntUnitUtilizaService target = ServiceLocator.Instance.GetService<IAcIntUnitUtilizaService>(); 
            return target;
        }

        /// <summary>
        ///CommitAcIntUnitUtilizas 的测试
        ///</summary>
        [TestMethod()]
        public void CommitAcIntUnitUtilizasTest()
        {
            IAcIntUnitUtilizaService target = CreateIAcIntUnitUtilizaService(); // TODO: 初始化为适当的值
            AcIntUnitUtilizaResultData acIntUnitUtilizaData = new AcIntUnitUtilizaResultData()
                                                              {
                                                                  AddedCollection = new AcIntUnitUtilizaDataObjectList()
                                                                                    {
                                                                                        new AcIntUnitUtilizaDataObject()
                                                                                        {
                                                                                            AcReg="B-3422",Msn="",
                                                                                            Unit=null,Utiliza=1,UtilizaRate=2,
                                                                                        }
                                                                                    }
                                                              }; // TODO: 初始化为适当的值
            AcIntUnitUtilizaResultData expected = null; // TODO: 初始化为适当的值
            AcIntUnitUtilizaResultData actual;
            actual = target.CommitAcIntUnitUtilizas(acIntUnitUtilizaData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreateAcIntUnitUtilizas 的测试
        ///</summary>
        [TestMethod()]
        public void CreateAcIntUnitUtilizasTest()
        {
            IAcIntUnitUtilizaService target = CreateIAcIntUnitUtilizaService(); // TODO: 初始化为适当的值
            AcIntUnitUtilizaDataObjectList acIntUnitUtilizas = null; // TODO: 初始化为适当的值
            AcIntUnitUtilizaDataObjectList expected = null; // TODO: 初始化为适当的值
            AcIntUnitUtilizaDataObjectList actual;
            actual = target.CreateAcIntUnitUtilizas(acIntUnitUtilizas);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteAcIntUnitUtilizas 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteAcIntUnitUtilizasTest()
        {
            IAcIntUnitUtilizaService target = CreateIAcIntUnitUtilizaService(); // TODO: 初始化为适当的值
            IDList acIntUnitUtilizaIDs = null; // TODO: 初始化为适当的值
            IDList expected = null; // TODO: 初始化为适当的值
            IDList actual;
            actual = target.DeleteAcIntUnitUtilizas(acIntUnitUtilizaIDs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateAcIntUnitUtilizas 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateAcIntUnitUtilizasTest()
        {
            IAcIntUnitUtilizaService target = CreateIAcIntUnitUtilizaService(); // TODO: 初始化为适当的值
            AcIntUnitUtilizaDataObjectList acIntUnitUtilizas = null; // TODO: 初始化为适当的值
            AcIntUnitUtilizaDataObjectList expected = null; // TODO: 初始化为适当的值
            AcIntUnitUtilizaDataObjectList actual;
            actual = target.UpdateAcIntUnitUtilizas(acIntUnitUtilizas);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
