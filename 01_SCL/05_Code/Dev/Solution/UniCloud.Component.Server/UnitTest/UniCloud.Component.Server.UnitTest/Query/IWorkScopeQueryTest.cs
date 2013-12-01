using UniCloud.Query;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Component.Server.UnitTest
{
    
    
    /// <summary>
    ///这是 IWorkScopeQueryTest 的测试类，旨在
    ///包含所有 IWorkScopeQueryTest 单元测试
    ///</summary>
    [TestClass()]
    public class IWorkScopeQueryTest
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


        internal virtual IWorkScopeQuery CreateIWorkScopeQuery()
        {
            // TODO: 实例化相应的具体类。
            IWorkScopeQuery target = ServiceLocator.Instance.GetService<IWorkScopeQuery>();
            return target;
        }

        /// <summary>
        ///GetWorkScopeByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetWorkScopeByIDTest()
        {
            IWorkScopeQuery target = CreateIWorkScopeQuery(); // TODO: 初始化为适当的值
            int id = 0; // TODO: 初始化为适当的值
            WorkScopeDataObject expected = null; // TODO: 初始化为适当的值
            WorkScopeDataObject actual;
            actual = target.GetWorkScopeByID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetWorkScopeWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GetWorkScopeWithPaginationTest()
        {
            IWorkScopeQuery target = CreateIWorkScopeQuery(); // TODO: 初始化为适当的值
            Pagination pagination = null; // TODO: 初始化为适当的值
            WorkScopeWithPagination expected = null; // TODO: 初始化为适当的值
            WorkScopeWithPagination actual;
            actual = target.GetWorkScopeWithPagination(pagination);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetWorkScopes 的测试
        ///</summary>
        [TestMethod()]
        public void GetWorkScopesTest()
        {
            IWorkScopeQuery target = CreateIWorkScopeQuery(); // TODO: 初始化为适当的值
            ColumnFilterDescriptorCollection colFilter = null; // TODO: 初始化为适当的值
            ColumnSortDescriptorCollection sortFilter = null; // TODO: 初始化为适当的值
            WorkScopeDataObjectList expected = null; // TODO: 初始化为适当的值
            WorkScopeDataObjectList actual;
            actual = target.GetWorkScopes(colFilter, sortFilter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
