using UniCloud.Query;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Component.Server.UnitTest
{
    
    
    /// <summary>
    ///这是 IAdsbComplyQueryTest 的测试类，旨在
    ///包含所有 IAdsbComplyQueryTest 单元测试
    ///</summary>
    [TestClass()]
    public class IAdsbComplyQueryTest
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


        internal virtual IAdsbComplyQuery CreateIAdsbComplyQuery()
        {
            // TODO: 实例化相应的具体类。
            IAdsbComplyQuery target = ServiceLocator.Instance.GetService<IAdsbComplyQuery>();
            return target;
        }

        /// <summary>
        ///GetAdsbComplyByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetAdsbComplyByIDTest()
        {
            IAdsbComplyQuery target = CreateIAdsbComplyQuery(); // TODO: 初始化为适当的值
            int id = 0; // TODO: 初始化为适当的值
            AdsbComplyDataObject expected = null; // TODO: 初始化为适当的值
            AdsbComplyDataObject actual;
            actual = target.GetAdsbComplyByID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAdsbComplyWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GetAdsbComplyWithPaginationTest()
        {
            IAdsbComplyQuery target = CreateIAdsbComplyQuery(); // TODO: 初始化为适当的值
            Pagination pagination = null; // TODO: 初始化为适当的值
            AdsbComplyWithPagination expected = null; // TODO: 初始化为适当的值
            AdsbComplyWithPagination actual;
            actual = target.GetAdsbComplyWithPagination(true,pagination);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAdsbComplys 的测试
        ///</summary>
        [TestMethod()]
        public void GetAdsbComplysTest()
        {
            IAdsbComplyQuery target = CreateIAdsbComplyQuery(); // TODO: 初始化为适当的值
            ColumnFilterDescriptorCollection colFilter = null; // TODO: 初始化为适当的值
            ColumnSortDescriptorCollection sortFilter = null; // TODO: 初始化为适当的值
            AdsbComplyDataObjectList expected = null; // TODO: 初始化为适当的值
            AdsbComplyDataObjectList actual;
            actual = target.GetAdsbComplys(colFilter, sortFilter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
