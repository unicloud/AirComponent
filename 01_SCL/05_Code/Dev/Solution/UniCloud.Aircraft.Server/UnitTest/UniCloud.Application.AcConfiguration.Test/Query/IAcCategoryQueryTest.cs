using UniCloud.Query.AcConfiguration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Application.AcConfiguration.Test
{
    
    
    /// <summary>
    ///这是 IAcCategoryQueryTest 的测试类，旨在
    ///包含所有 IAcCategoryQueryTest 单元测试
    ///</summary>
    [TestClass()]
    public class IAcCategoryQueryTest
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
        internal virtual IAcCategoryQuery CreateIAcCategoryQuery()
        {
            // TODO: 实例化相应的具体类。
            IAcCategoryQuery target = ServiceLocator.Instance.GetService<IAcCategoryQuery>();
            return target;
        }

        /// <summary>
        ///GetAcCategoryByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcCategoryByIDTest()
        {
            IAcCategoryQuery target = CreateIAcCategoryQuery(); // TODO: 初始化为适当的值
            int id = 0; // TODO: 初始化为适当的值
            AcCategoryDataObject expected = null; // TODO: 初始化为适当的值
            AcCategoryDataObject actual;
            actual = target.GetAcCategoryByID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAcCategoryCol 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcCategoryColTest()
        {
            IAcCategoryQuery target = CreateIAcCategoryQuery(); // TODO: 初始化为适当的值
            ColumnFilterDescriptorCollection colFilter = null; // TODO: 初始化为适当的值
            ColumnSortDescriptorCollection sortFilter = null; // TODO: 初始化为适当的值
            KeyValueDataObjectList expected = null; // TODO: 初始化为适当的值
            KeyValueDataObjectList actual;
            actual = target.GetAcCategoryCol(colFilter, sortFilter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAcCategoryWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcCategoryWithPaginationTest()
        {
            IAcCategoryQuery target = CreateIAcCategoryQuery(); // TODO: 初始化为适当的值
            Pagination pagination = null; // TODO: 初始化为适当的值
            AcCategoryWithPagination expected = null; // TODO: 初始化为适当的值
            AcCategoryWithPagination actual;
            actual = target.GetAcCategoryWithPagination(pagination);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAcCategorys 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcCategorysTest()
        {
            IAcCategoryQuery target = CreateIAcCategoryQuery(); // TODO: 初始化为适当的值
            ColumnFilterDescriptorCollection colFilter = null; // TODO: 初始化为适当的值
            ColumnSortDescriptorCollection sortFilter = null; // TODO: 初始化为适当的值
            AcCategoryDataObjectList expected = null; // TODO: 初始化为适当的值
            AcCategoryDataObjectList actual;
            actual = target.GetAcCategorys(colFilter, sortFilter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
