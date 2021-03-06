﻿using UniCloud.Query;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Component.Server.UnitTest
{
    
    
    /// <summary>
    ///这是 ISnHistoryQueryTest 的测试类，旨在
    ///包含所有 ISnHistoryQueryTest 单元测试
    ///</summary>
    [TestClass()]
    public class ISnHistoryQueryTest
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


        internal virtual ISnHistoryQuery CreateISnHistoryQuery()
        {
            // TODO: 实例化相应的具体类。
            ISnHistoryQuery target = ServiceLocator.Instance.GetService<ISnHistoryQuery>();
            return target;
        }

        /// <summary>
        ///GetLastSnHistoryBySnregID 的测试
        ///</summary>
        [TestMethod()]
        public void GetLastSnHistoryBySnregIDTest()
        {
            ISnHistoryQuery target = CreateISnHistoryQuery(); // TODO: 初始化为适当的值
            int id = 0; // TODO: 初始化为适当的值
            SnHistoryDataObject expected = null; // TODO: 初始化为适当的值
            SnHistoryDataObject actual;
            actual = target.GetLastSnHistoryBySnregID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetSnHistoryByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetSnHistoryByIDTest()
        {
            ISnHistoryQuery target = CreateISnHistoryQuery(); // TODO: 初始化为适当的值
            int id = 0; // TODO: 初始化为适当的值
            SnHistoryDataObject expected = null; // TODO: 初始化为适当的值
            SnHistoryDataObject actual;
            actual = target.GetSnHistoryByID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetSnHistoryWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GetSnHistoryWithPaginationTest()
        {
            ISnHistoryQuery target = CreateISnHistoryQuery(); // TODO: 初始化为适当的值
            Pagination pagination = null; // TODO: 初始化为适当的值
            SnHistoryWithPagination expected = null; // TODO: 初始化为适当的值
            SnHistoryWithPagination actual;
            actual = target.GetSnHistoryWithPagination(pagination);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetSnHistorys 的测试
        ///</summary>
        [TestMethod()]
        public void GetSnHistorysTest()
        {
            ISnHistoryQuery target = CreateISnHistoryQuery(); // TODO: 初始化为适当的值
            ColumnFilterDescriptorCollection colFilter = null; // TODO: 初始化为适当的值
            ColumnSortDescriptorCollection sortFilter = null; // TODO: 初始化为适当的值
            SnHistoryDataObjectList expected = null; // TODO: 初始化为适当的值
            SnHistoryDataObjectList actual;
            actual = target.GetSnHistorys(colFilter, sortFilter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///QuerySnHistorys 的测试
        ///</summary>
        [TestMethod()]
        public void QuerySnHistorysTest()
        {
            ISnHistoryQuery target = CreateISnHistoryQuery(); // TODO: 初始化为适当的值
            string ac = string.Empty; // TODO: 初始化为适当的值
            string itemNo = string.Empty; // TODO: 初始化为适当的值
            string pn = string.Empty; // TODO: 初始化为适当的值
            DateTime fromDate = new DateTime(); // TODO: 初始化为适当的值
            DateTime toDate = new DateTime(); // TODO: 初始化为适当的值
            SnHistoryDataObjectList expected = null; // TODO: 初始化为适当的值
            SnHistoryDataObjectList actual;
            actual = target.QuerySnHistorys(ac, itemNo, pn, fromDate, toDate);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
