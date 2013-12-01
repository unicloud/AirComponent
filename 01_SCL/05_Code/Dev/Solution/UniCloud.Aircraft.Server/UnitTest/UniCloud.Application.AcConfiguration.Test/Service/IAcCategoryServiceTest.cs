using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Application.AcConfiguration.Test
{
    
    
    /// <summary>
    ///这是 IAcCategoryServiceTest 的测试类，旨在
    ///包含所有 IAcCategoryServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class IAcCategoryServiceTest
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
        [TestInitialize()]
        public void MyTestInitialize()
        {
            Initializer.Init();
        }
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        internal virtual IAcCategoryService CreateIAcCategoryService()
        {
            // TODO: 实例化相应的具体类。
            IAcCategoryService target = ServiceLocator.Instance.GetService<IAcCategoryService>(); 
            return target;
        }

        /// <summary>
        ///CommitAcCategorys 的测试
        ///</summary>
        [TestMethod()]
        public void CommitAcCategorysTest()
        {
            IAcCategoryService target = CreateIAcCategoryService(); // TODO: 初始化为适当的值
            AcCategoryResultData acCategoryData = null; // TODO: 初始化为适当的值
            AcCategoryResultData expected = null; // TODO: 初始化为适当的值
            AcCategoryResultData actual;
            actual = target.CommitAcCategorys(acCategoryData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreateAcCategorys 的测试
        ///</summary>
        [TestMethod()]
        public void CreateAcCategorysTest()
        {
            IAcCategoryService target = CreateIAcCategoryService(); // TODO: 初始化为适当的值
            AcCategoryDataObjectList acCategorys = null; // TODO: 初始化为适当的值
            AcCategoryDataObjectList expected = null; // TODO: 初始化为适当的值
            AcCategoryDataObjectList actual;
            actual = target.CreateAcCategorys(acCategorys);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteAcCategorys 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteAcCategorysTest()
        {
            IAcCategoryService target = CreateIAcCategoryService(); // TODO: 初始化为适当的值
            IDList acCategoryIDs = null; // TODO: 初始化为适当的值
            IDList expected = null; // TODO: 初始化为适当的值
            IDList actual;
            actual = target.DeleteAcCategorys(acCategoryIDs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullAcCategoryByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullAcCategoryByIDTest()
        {
            IAcCategoryService target = CreateIAcCategoryService(); // TODO: 初始化为适当的值
            int id = 0; // TODO: 初始化为适当的值
            AcCategoryDataObject expected = null; // TODO: 初始化为适当的值
            AcCategoryDataObject actual;
            actual = target.GetFullAcCategoryByID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullAcCategorys 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullAcCategorysTest()
        {
            IAcCategoryService target = CreateIAcCategoryService(); // TODO: 初始化为适当的值
            AcCategoryDataObjectList expected = null; // TODO: 初始化为适当的值
            AcCategoryDataObjectList actual;
            actual = target.GetFullAcCategorys();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateAcCategorys 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateAcCategorysTest()
        {
            IAcCategoryService target = CreateIAcCategoryService(); // TODO: 初始化为适当的值
            AcCategoryDataObjectList acCategorys = null; // TODO: 初始化为适当的值
            AcCategoryDataObjectList expected = null; // TODO: 初始化为适当的值
            AcCategoryDataObjectList actual;
            actual = target.UpdateAcCategorys(acCategorys);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
