using UniCloud.Query;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Component.Server.UnitTest
{
    
    
    /// <summary>
    ///这是 ICcOrderQueryTest 的测试类，旨在
    ///包含所有 ICcOrderQueryTest 单元测试
    ///</summary>
    [TestClass()]
    public class ICcOrderQueryTest
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


        internal virtual ICcOrderQuery CreateICcOrderQuery()
        {
            // TODO: 实例化相应的具体类。
            ICcOrderQuery target = ServiceLocator.Instance.GetService<ICcOrderQuery>();
            return target;
        }

        /// <summary>
        ///GetCcOrderByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetCcOrderByIDTest()
        {
            ICcOrderQuery target = CreateICcOrderQuery(); // TODO: 初始化为适当的值
            int id = 64; // TODO: 初始化为适当的值
            CcOrderDataObject expected = null; // TODO: 初始化为适当的值
            CcOrderDataObject actual;
            actual = target.GetCcOrderByID(id);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///GetCcOrderWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GetCcOrderWithPaginationTest()
        {
            ICcOrderQuery target = CreateICcOrderQuery(); // TODO: 初始化为适当的值
            Pagination pagination = new Pagination()
                                    {
                                        PageNumber=1,PageSize=10
                                    }; // TODO: 初始化为适当的值
            CcOrderWithPagination expected = null; // TODO: 初始化为适当的值
            CcOrderWithPagination actual;
            actual = target.GetCcOrderWithPagination(pagination);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }


        /// <summary>
        ///GetCcOrderWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GeteEngCcOrderWithPaginationTest()
        {
            ICcOrderQuery target = CreateICcOrderQuery(); // TODO: 初始化为适当的值
            Pagination pagination = new Pagination()
            {
                PageNumber = 1,
                PageSize = 10
            }; // TODO: 初始化为适当的值
            CcOrderWithPagination expected = null; // TODO: 初始化为适当的值
            CcOrderWithPagination actual;
            actual = target.GetEngCcOrderWithPagination(pagination);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetCcOrders 的测试
        ///</summary>
        [TestMethod()]
        public void GetCcOrdersTest()
        {
            ICcOrderQuery target = CreateICcOrderQuery(); // TODO: 初始化为适当的值
            ColumnFilterDescriptorCollection colFilter = null; // TODO: 初始化为适当的值
            ColumnSortDescriptorCollection sortFilter = null; // TODO: 初始化为适当的值
            CcOrderDataObjectList expected = null; // TODO: 初始化为适当的值
            CcOrderDataObjectList actual;
            actual = target.GetCcOrders(colFilter, sortFilter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
