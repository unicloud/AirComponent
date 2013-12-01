using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Component.Server.UnitTest
{
    
    
    /// <summary>
    ///这是 IAirBusMSCNServiceTest 的测试类，旨在
    ///包含所有 IAirBusMSCNServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class IAirBusMSCNServiceTest
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


        internal virtual IAirBusMSCNService CreateIAirBusMSCNService()
        {
            // TODO: 实例化相应的具体类。
            IAirBusMSCNService target = ServiceLocator.Instance.GetService<IAirBusMSCNService>(); 
            return target;
        }

        /// <summary>
        ///CommitAirBusMSCNs 的测试
        ///</summary>
        [TestMethod()]
        public void CommitAirBusMSCNsTest()
        {
            IAirBusMSCNService target = CreateIAirBusMSCNService(); // TODO: 初始化为适当的值
            AirBusMSCNResultData airBusMSCNData = new AirBusMSCNResultData()
                                                  {
                                                      AddedCollection = new AirBusMSCNDataObjectList()
                                                                        {
                                                                            new AirBusMSCNDataObject()
                                                                            {
                                                                                Ata="223",Mod="23",Fleet="CSC*I",Msn="2102",
                                                                                MscnTitle="222",MscnNo="DFSSDES09"
                                                                            }
                                                                        }
                                                  }; // TODO: 初始化为适当的值
            AirBusMSCNResultData expected = null; // TODO: 初始化为适当的值
            AirBusMSCNResultData actual;
            actual = target.CommitAirBusMSCNs(airBusMSCNData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreateAirBusMSCNs 的测试
        ///</summary>
        [TestMethod()]
        public void CreateAirBusMSCNsTest()
        {
            IAirBusMSCNService target = CreateIAirBusMSCNService(); // TODO: 初始化为适当的值
            AirBusMSCNDataObjectList airBusMSCNs = null; // TODO: 初始化为适当的值
            AirBusMSCNDataObjectList expected = null; // TODO: 初始化为适当的值
            AirBusMSCNDataObjectList actual;
            actual = target.CreateAirBusMSCNs(airBusMSCNs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteAirBusMSCNs 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteAirBusMSCNsTest()
        {
            IAirBusMSCNService target = CreateIAirBusMSCNService(); // TODO: 初始化为适当的值
            IDList airBusMSCNIDs = null; // TODO: 初始化为适当的值
            IDList expected = null; // TODO: 初始化为适当的值
            IDList actual;
            actual = target.DeleteAirBusMSCNs(airBusMSCNIDs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateAirBusMSCNs 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateAirBusMSCNsTest()
        {
            IAirBusMSCNService target = CreateIAirBusMSCNService(); // TODO: 初始化为适当的值
            AirBusMSCNDataObjectList airBusMSCNs = null; // TODO: 初始化为适当的值
            AirBusMSCNDataObjectList expected = null; // TODO: 初始化为适当的值
            AirBusMSCNDataObjectList actual;
            actual = target.UpdateAirBusMSCNs(airBusMSCNs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
