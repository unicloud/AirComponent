using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Component.Server.UnitTest
{
    
    
    /// <summary>
    ///这是 IAdsbServiceTest 的测试类，旨在
    ///包含所有 IAdsbServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class IAdsbServiceTest
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


        internal virtual IAdsbService CreateIAdsbService()
        {
            // TODO: 实例化相应的具体类。
            IAdsbService target = ServiceLocator.Instance.GetService<IAdsbService>();
            return target;
        }

        /// <summary>
        ///CommitAdsbs 的测试
        ///</summary>
        [TestMethod()]
        public void CommitAdsbsTest()
        {
            IAdsbService target = CreateIAdsbService(); // TODO: 初始化为适当的值
            AdsbResultData adsbData = null; // TODO: 初始化为适当的值
            AdsbResultData expected = null; // TODO: 初始化为适当的值
            AdsbResultData actual;
            actual = target.CommitAdsbs(adsbData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreateAdsbs 的测试
        ///</summary>
        [TestMethod()]
        public void CreateAdsbsTest()
        {
            IAdsbService target = CreateIAdsbService(); // TODO: 初始化为适当的值
            AdsbDataObjectList adsbs = new AdsbDataObjectList()
                                       {
                                           new AdsbDataObject(){ReceiveDate=DateTime.Now,Actype="a",Content="b"}
                                       }; // TODO: 初始化为适当的值
            AdsbDataObjectList expected = null; // TODO: 初始化为适当的值
            AdsbDataObjectList actual;
            actual = target.CreateAdsbs(adsbs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteAdsbs 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteAdsbsTest()
        {
            IAdsbService target = CreateIAdsbService(); // TODO: 初始化为适当的值
            IDList adsbIDs = null; // TODO: 初始化为适当的值
            IDList expected = null; // TODO: 初始化为适当的值
            IDList actual;
            actual = target.DeleteAdsbs(adsbIDs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateAdsbs 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateAdsbsTest()
        {
            IAdsbService target = CreateIAdsbService(); // TODO: 初始化为适当的值
            AdsbDataObjectList adsbs = null; // TODO: 初始化为适当的值
            AdsbDataObjectList expected = null; // TODO: 初始化为适当的值
            AdsbDataObjectList actual;
            actual = target.UpdateAdsbs(adsbs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
