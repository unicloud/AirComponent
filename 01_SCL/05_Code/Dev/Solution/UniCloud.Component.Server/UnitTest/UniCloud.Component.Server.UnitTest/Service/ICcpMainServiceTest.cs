using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Component.Server.UnitTest
{
    
    
    /// <summary>
    ///这是 ICcpMainServiceTest 的测试类，旨在
    ///包含所有 ICcpMainServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class ICcpMainServiceTest
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


        internal virtual ICcpMainService CreateICcpMainService()
        {
            // TODO: 实例化相应的具体类。
            ICcpMainService target = ServiceLocator.Instance.GetService<ICcpMainService>();
            return target;
        }

        /// <summary>
        ///CommitCcpMains 的测试
        ///</summary>
        [TestMethod()]
        public void CommitCcpMainsTest()
        {
            ICcpMainService target = CreateICcpMainService(); // TODO: 初始化为适当的值
            CcpMainResultData ccpMainData = null; // TODO: 初始化为适当的值
            CcpMainResultData expected = null; // TODO: 初始化为适当的值
            CcpMainResultData actual;
            actual = target.CommitCcpMains(ccpMainData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreateCcpMains 的测试
        ///</summary>
        [TestMethod()]
        public void CreateCcpMainsTest()
        {
            ICcpMainService target = CreateICcpMainService(); // TODO: 初始化为适当的值
            CcpMainDataObjectList ccpMains = null; // TODO: 初始化为适当的值
            CcpMainDataObjectList expected = null; // TODO: 初始化为适当的值
            CcpMainDataObjectList actual;
            actual = target.CreateCcpMains(ccpMains);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteCcpMains 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteCcpMainsTest()
        {
            ICcpMainService target = CreateICcpMainService(); // TODO: 初始化为适当的值
            IDList ccpMainIDs = null; // TODO: 初始化为适当的值
            IDList expected = null; // TODO: 初始化为适当的值
            IDList actual;
            actual = target.DeleteCcpMains(ccpMainIDs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullCcpMainByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullCcpMainByIDTest()
        {
            ICcpMainService target = CreateICcpMainService(); // TODO: 初始化为适当的值
            int id = 0; // TODO: 初始化为适当的值
            CcpMainDataObject expected = null; // TODO: 初始化为适当的值
            CcpMainDataObject actual;
            actual = target.GetFullCcpMainByID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullCcpMains 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullCcpMainsTest()
        {
            ICcpMainService target = CreateICcpMainService(); // TODO: 初始化为适当的值
            CcpMainDataObjectList expected = null; // TODO: 初始化为适当的值
            CcpMainDataObjectList actual;
            actual = target.GetFullCcpMains();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///QueryAllCcpMain 的测试
        ///</summary>
        [TestMethod()]
        public void QueryAllCcpMainTest()
        {
            ICcpMainService target = CreateICcpMainService(); // TODO: 初始化为适当的值
            string actype = string.Empty; // TODO: 初始化为适当的值
            string itemNo = string.Empty; // TODO: 初始化为适当的值
            string ata = string.Empty; // TODO: 初始化为适当的值
            string stateStation = string.Empty; // TODO: 初始化为适当的值
            CcpMainDataObjectList expected = null; // TODO: 初始化为适当的值
            CcpMainDataObjectList actual;
            actual = target.QueryAllCcpMain(actype, itemNo, ata, stateStation);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateCcpMains 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateCcpMainsTest()
        {
            ICcpMainService target = CreateICcpMainService(); // TODO: 初始化为适当的值
            CcpMainDataObjectList ccpMains = null; // TODO: 初始化为适当的值
            CcpMainDataObjectList expected = null; // TODO: 初始化为适当的值
            CcpMainDataObjectList actual;
            actual = target.UpdateCcpMains(ccpMains);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///VerifyCcpMain 的测试
        ///</summary>
        [TestMethod()]
        public void VerifyCcpMainTest()
        {
            ICcpMainService target = CreateICcpMainService(); // TODO: 初始化为适当的值
            int ccpMainId = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.VerifyCcpMain(ccpMainId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
