using UniCloud.Query.AcConfiguration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Application.AcConfiguration.Test
{
    
    
    /// <summary>
    ///这是 IAtaQueryTest 的测试类，旨在
    ///包含所有 IAtaQueryTest 单元测试
    ///</summary>
    [TestClass()]
    public class IAtaQueryTest
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
        internal virtual IAtaQuery CreateIAtaQuery()
        {
            // TODO: 实例化相应的具体类。
            IAtaQuery target = ServiceLocator.Instance.GetService<IAtaQuery>();
            return target;
        }

        /// <summary>
        ///GetAtaByGuid 的测试
        ///</summary>
        [TestMethod()]
        public void GetAtaByGuidTest()
        {
            IAtaQuery target = CreateIAtaQuery(); // TODO: 初始化为适当的值
            string id = string.Empty; // TODO: 初始化为适当的值
            AtaDataObject expected = null; // TODO: 初始化为适当的值
            AtaDataObject actual;
            actual = target.GetAtaByGuid(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAtaByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetAtaByIDTest()
        {
            IAtaQuery target = CreateIAtaQuery(); // TODO: 初始化为适当的值
            int id = 0; // TODO: 初始化为适当的值
            AtaDataObject expected = null; // TODO: 初始化为适当的值
            AtaDataObject actual;
            actual = target.GetAtaByID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAtaCol 的测试
        ///</summary>
        [TestMethod()]
        public void GetAtaColTest()
        {
            IAtaQuery target = CreateIAtaQuery(); // TODO: 初始化为适当的值
            ColumnFilterDescriptorCollection colFilter = null; // TODO: 初始化为适当的值
            ColumnSortDescriptorCollection sortFilter = null; // TODO: 初始化为适当的值
            KeyValueDataObjectList expected = null; // TODO: 初始化为适当的值
            KeyValueDataObjectList actual;
            actual = target.GetAtaCol(colFilter, sortFilter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAtaWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GetAtaWithPaginationTest()
        {
            IAtaQuery target = CreateIAtaQuery(); // TODO: 初始化为适当的值
            Pagination pagination = null; // TODO: 初始化为适当的值
            AtaWithPagination expected = null; // TODO: 初始化为适当的值
            AtaWithPagination actual;
            actual = target.GetAtaWithPagination(pagination);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAtas 的测试
        ///</summary>
        [TestMethod()]
        public void GetAtasTest()
        {
            IAtaQuery target = CreateIAtaQuery(); // TODO: 初始化为适当的值
            ColumnFilterDescriptorCollection colFilter = null; // TODO: 初始化为适当的值
            ColumnSortDescriptorCollection sortFilter = null; // TODO: 初始化为适当的值
            AtaDataObjectList expected = null; // TODO: 初始化为适当的值
            AtaDataObjectList actual;
            actual = target.GetAtas(colFilter, sortFilter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
