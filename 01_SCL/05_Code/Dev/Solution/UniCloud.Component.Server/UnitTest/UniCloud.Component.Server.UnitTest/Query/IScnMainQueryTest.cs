using UniCloud.Query;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Component.Server.UnitTest
{
    
    
    /// <summary>
    ///这是 IScnMainQueryTest 的测试类，旨在
    ///包含所有 IScnMainQueryTest 单元测试
    ///</summary>
    [TestClass()]
    public class IScnMainQueryTest
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


        internal virtual IScnMainQuery CreateIScnMainQuery()
        {
            // TODO: 实例化相应的具体类。
            IScnMainQuery target = ServiceLocator.Instance.GetService<IScnMainQuery>();
            return target;
        }

        /// <summary>
        ///GetScnMainByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetScnMainByIDTest()
        {
            IScnMainQuery target = CreateIScnMainQuery(); // TODO: 初始化为适当的值
            int id = 16; // TODO: 初始化为适当的值
            ScnMainDataObject expected = null; // TODO: 初始化为适当的值
            ScnMainDataObject actual;
            actual = target.GetScnMainByID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetScnMainWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GetScnMainWithPaginationTest()
        {
            IScnMainQuery target = CreateIScnMainQuery(); // TODO: 初始化为适当的值
            Pagination pagination = new Pagination()
                                    {
                                        PageNumber=1,
                                        PageSize=10
                                    }; // TODO: 初始化为适当的值
            ScnMainWithPagination expected = null; // TODO: 初始化为适当的值
            ScnMainWithPagination actual;
            actual = target.GetScnMainWithPagination(pagination, "航材计划室");
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetScnMains 的测试
        ///</summary>
        [TestMethod()]
        public void GetScnMainsTest()
        {
            IScnMainQuery target = CreateIScnMainQuery(); // TODO: 初始化为适当的值
            ColumnFilterDescriptorCollection colFilter = null; // TODO: 初始化为适当的值
            ColumnSortDescriptorCollection sortFilter = null; // TODO: 初始化为适当的值
            ScnMainDataObjectList expected = null; // TODO: 初始化为适当的值
            ScnMainDataObjectList actual;
            actual = target.GetScnMains(colFilter, sortFilter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetScnMains 的测试
        ///</summary>
        [TestMethod()]
        public void CompareQueryTest()
        {
            IScnMainQuery target = CreateIScnMainQuery(); // TODO: 初始化为适当的值
            ColumnFilterDescriptorCollection colFilter = null; // TODO: 初始化为适当的值
            ColumnSortDescriptorCollection sortFilter = null; // TODO: 初始化为适当的值
            ScnMainDataObjectList expected = null; // TODO: 初始化为适当的值
            Pagination p = new Pagination()
                           {
                               PageNumber = 1,
                               PageSize = 10
                           };
            var actual = target.CompareAcOrders("5961", "5962",p);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetScnMains 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcOrderMsnsTest()
        {
            IScnMainQuery target = CreateIScnMainQuery(); // TODO: 初始化为适当的值

            var actual = target.GetAcOrderMsns();
            Assert.AreEqual(0, actual);
        }
    }
}
