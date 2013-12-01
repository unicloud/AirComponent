using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Component.Server.UnitTest
{
    
    
    /// <summary>
    ///这是 IAcStructureServiceTest 的测试类，旨在
    ///包含所有 IAcStructureServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class IAcStructureServiceTest
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

        internal virtual IAcStructureService CreateIAcStructureService()
        {
            // TODO: 实例化相应的具体类。
            IAcStructureService target = ServiceLocator.Instance.GetService<IAcStructureService>();
            return target;
        }

        /// <summary>
        ///CommitAcStructures 的测试
        ///</summary>
        [TestMethod()]
        public void CommitAcStructuresTest()
        {
            IAcStructureService target = CreateIAcStructureService(); // TODO: 初始化为适当的值
            AcStructureResultData acStructureData = null; // TODO: 初始化为适当的值
            AcStructureResultData expected = null; // TODO: 初始化为适当的值
            AcStructureResultData actual;
            actual = target.CommitAcStructures(acStructureData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreateAcStructures 的测试
        ///</summary>
        [TestMethod()]
        public void CreateAcStructuresTest()
        {
            IAcStructureService target = CreateIAcStructureService(); // TODO: 初始化为适当的值
            AcStructureDataObjectList acStructures = new AcStructureDataObjectList()
                                                     {
                                                         new AcStructureDataObject()
                                                         {
                                                             Acmodel="B-234",Acreg="B-2123",CloseDate=DateTime.Now
                                                         }
                                                     }; // TODO: 初始化为适当的值
            AcStructureDataObjectList expected = null; // TODO: 初始化为适当的值
            AcStructureDataObjectList actual;
            actual = target.CreateAcStructures(acStructures);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteAcStructures 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteAcStructuresTest()
        {
            IAcStructureService target = CreateIAcStructureService(); // TODO: 初始化为适当的值
            IDList acStructureIDs = null; // TODO: 初始化为适当的值
            IDList expected = null; // TODO: 初始化为适当的值
            IDList actual;
            actual = target.DeleteAcStructures(acStructureIDs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateAcStructures 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateAcStructuresTest()
        {
            IAcStructureService target = CreateIAcStructureService(); // TODO: 初始化为适当的值
            AcStructureDataObjectList acStructures = null; // TODO: 初始化为适当的值
            AcStructureDataObjectList expected = null; // TODO: 初始化为适当的值
            AcStructureDataObjectList actual;
            actual = target.UpdateAcStructures(acStructures);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
