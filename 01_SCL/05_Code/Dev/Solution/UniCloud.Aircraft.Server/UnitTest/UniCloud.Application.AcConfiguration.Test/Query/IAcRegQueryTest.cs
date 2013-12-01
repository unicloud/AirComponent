using UniCloud.Query.AcConfiguration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Application.AcConfiguration.Test
{
    
    
    /// <summary>
    ///这是 IAcRegQueryTest 的测试类，旨在
    ///包含所有 IAcRegQueryTest 单元测试
    ///</summary>
    [TestClass()]
    public class IAcRegQueryTest
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
        internal virtual IAcRegQuery CreateIAcRegQuery()
        {
            // TODO: 实例化相应的具体类。
            IAcRegQuery target = ServiceLocator.Instance.GetService<IAcRegQuery>();
            return target;
        }

        /// <summary>
        ///GetAcRegByGuid 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcRegByGuidTest()
        {
            IAcRegQuery target = CreateIAcRegQuery(); // TODO: 初始化为适当的值
            string id = string.Empty; // TODO: 初始化为适当的值
            AcRegDataObject expected = null; // TODO: 初始化为适当的值
            AcRegDataObject actual;
            actual = target.GetAcRegByGuid(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAcRegByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcRegByIDTest()
        {
            IAcRegQuery target = CreateIAcRegQuery(); // TODO: 初始化为适当的值
            int id = 0; // TODO: 初始化为适当的值
            AcRegDataObject expected = null; // TODO: 初始化为适当的值
            AcRegDataObject actual;
            actual = target.GetAcRegByID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAcRegCol 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcRegColTest()
        {
            IAcRegQuery target = CreateIAcRegQuery(); // TODO: 初始化为适当的值
            ColumnFilterDescriptorCollection colFilter = null; // TODO: 初始化为适当的值
            ColumnSortDescriptorCollection sortFilter = null; // TODO: 初始化为适当的值
            KeyValueDataObjectList expected = null; // TODO: 初始化为适当的值
            KeyValueDataObjectList actual;
            actual = target.GetAcRegCol(colFilter, sortFilter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAcRegWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcRegWithPaginationTest()
        {
            IAcRegQuery target = CreateIAcRegQuery(); // TODO: 初始化为适当的值
            Pagination pagination = null; // TODO: 初始化为适当的值
            AcRegWithPagination expected = null; // TODO: 初始化为适当的值
            AcRegWithPagination actual;
            actual = target.GetAcRegWithPagination(pagination);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAcRegs 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcRegsTest()
        {
            IAcRegQuery target = CreateIAcRegQuery(); // TODO: 初始化为适当的值
            ColumnFilterDescriptorCollection colFilter = null; // TODO: 初始化为适当的值
            ColumnSortDescriptorCollection sortFilter = null; // TODO: 初始化为适当的值
            AcRegDataObjectList expected = null; // TODO: 初始化为适当的值
            AcRegDataObjectList actual;
            actual = target.GetAcRegs(colFilter, sortFilter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAcregLicenseByAcregID 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcregLicenseByAcregIDTest()
        {
            IAcRegQuery target = CreateIAcRegQuery(); // TODO: 初始化为适当的值
            int id = 0; // TODO: 初始化为适当的值
            AcregLicenseDataObjectList expected = null; // TODO: 初始化为适当的值
            AcregLicenseDataObjectList actual;
            actual = target.GetAcregLicenseByAcregID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
