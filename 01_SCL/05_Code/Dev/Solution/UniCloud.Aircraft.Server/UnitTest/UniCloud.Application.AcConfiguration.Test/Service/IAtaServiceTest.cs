using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Application.AcConfiguration.Test
{
    
    
    /// <summary>
    ///这是 IAtaServiceTest 的测试类，旨在
    ///包含所有 IAtaServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class IAtaServiceTest
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

        [TestInitialize()]
        public void MyTestInitialize()
        {
            Initializer.Init();
        }

        internal virtual IAtaService CreateIAtaService()
        {
            // TODO: 实例化相应的具体类。
            IAtaService target = ServiceLocator.Instance.GetService<IAtaService>(); ;
            return target;
        }

        /// <summary>
        ///CommitAtas 的测试
        ///</summary>
        [TestMethod()]
        public void CommitAtasTest()
        {
            IAtaService target = CreateIAtaService(); // TODO: 初始化为适当的值
            AtaResultData ataData = null; // TODO: 初始化为适当的值
            AtaResultData expected = null; // TODO: 初始化为适当的值
            AtaResultData actual;
            actual = target.CommitAtas(ataData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreateAtas 的测试
        ///</summary>
        [TestMethod()]
        public void CreateAtasTest()
        {
            IAtaService target = CreateIAtaService(); // TODO: 初始化为适当的值
            AtaDataObjectList atas = null; // TODO: 初始化为适当的值
            AtaDataObjectList expected = null; // TODO: 初始化为适当的值
            AtaDataObjectList actual;
            actual = target.CreateAtas(atas);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteAtas 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteAtasTest()
        {
            IAtaService target = CreateIAtaService(); // TODO: 初始化为适当的值
            IDList ataIDs = null; // TODO: 初始化为适当的值
            IDList expected = null; // TODO: 初始化为适当的值
            IDList actual;
            actual = target.DeleteAtas(ataIDs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullAtaByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullAtaByIDTest()
        {
            IAtaService target = CreateIAtaService(); // TODO: 初始化为适当的值
            int id = 0; // TODO: 初始化为适当的值
            AtaDataObject expected = null; // TODO: 初始化为适当的值
            AtaDataObject actual;
            actual = target.GetFullAtaByID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullAtas 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullAtasTest()
        {
            IAtaService target = CreateIAtaService(); // TODO: 初始化为适当的值
            AtaDataObjectList expected = null; // TODO: 初始化为适当的值
            AtaDataObjectList actual;
            actual = target.GetFullAtas();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateAtas 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateAtasTest()
        {
            IAtaService target = CreateIAtaService(); // TODO: 初始化为适当的值
            AtaDataObjectList atas = null; // TODO: 初始化为适当的值
            AtaDataObjectList expected = null; // TODO: 初始化为适当的值
            AtaDataObjectList actual;
            actual = target.UpdateAtas(atas);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
