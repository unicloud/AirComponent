using UniCloud.Query.AcConfiguration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Application.AcConfiguration.Test
{
    
    
    /// <summary>
    ///这是 IAcTypeQueryTest 的测试类，旨在
    ///包含所有 IAcTypeQueryTest 单元测试
    ///</summary>
    [TestClass()]
    public class IAcTypeQueryTest
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

        internal virtual IAcTypeQuery CreateIAcTypeQuery()
        {
            // TODO: 实例化相应的具体类。
            IAcTypeQuery target = ServiceLocator.Instance.GetService<IAcTypeQuery>();
            return target;
        }

        /// <summary>
        ///GetAcConfigByGuid 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcConfigByGuidTest()
        {
            IAcTypeQuery target = CreateIAcTypeQuery(); // TODO: 初始化为适当的值
            string Id = string.Empty; // TODO: 初始化为适当的值
            AcConfigDataObject expected = null; // TODO: 初始化为适当的值
            AcConfigDataObject actual;
            actual = target.GetAcConfigByGuid(Id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAcConfigByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcConfigByIDTest()
        {
            IAcTypeQuery target = CreateIAcTypeQuery(); // TODO: 初始化为适当的值
            int Id = 0; // TODO: 初始化为适当的值
            AcConfigDataObject expected = null; // TODO: 初始化为适当的值
            AcConfigDataObject actual;
            actual = target.GetAcConfigByID(Id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAcConfigCol 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcConfigColTest()
        {
            IAcTypeQuery target = CreateIAcTypeQuery(); // TODO: 初始化为适当的值
            ColumnFilterDescriptorCollection colFilter = null; // TODO: 初始化为适当的值
            ColumnSortDescriptorCollection sortFilter = null; // TODO: 初始化为适当的值
            KeyValueDataObjectList expected = null; // TODO: 初始化为适当的值
            KeyValueDataObjectList actual;
            actual = target.GetAcConfigCol(colFilter, sortFilter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAcConfigs 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcConfigsTest()
        {
            IAcTypeQuery target = CreateIAcTypeQuery(); // TODO: 初始化为适当的值
            ColumnFilterDescriptorCollection colFilter = null; // TODO: 初始化为适当的值
            ColumnSortDescriptorCollection sortFilter = null; // TODO: 初始化为适当的值
            AcConfigDataObjectList expected = null; // TODO: 初始化为适当的值
            AcConfigDataObjectList actual;
            actual = target.GetAcConfigs(colFilter, sortFilter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAcModelByGuid 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcModelByGuidTest()
        {
            IAcTypeQuery target = CreateIAcTypeQuery(); // TODO: 初始化为适当的值
            string Id = string.Empty; // TODO: 初始化为适当的值
            AcModelDataObject expected = null; // TODO: 初始化为适当的值
            AcModelDataObject actual;
            actual = target.GetAcModelByGuid(Id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAcModelByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcModelByIDTest()
        {
            IAcTypeQuery target = CreateIAcTypeQuery(); // TODO: 初始化为适当的值
            int Id = 0; // TODO: 初始化为适当的值
            AcModelDataObject expected = null; // TODO: 初始化为适当的值
            AcModelDataObject actual;
            actual = target.GetAcModelByID(Id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAcModelCol 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcModelColTest()
        {
            IAcTypeQuery target = CreateIAcTypeQuery(); // TODO: 初始化为适当的值
            ColumnFilterDescriptorCollection colFilter = null; // TODO: 初始化为适当的值
            ColumnSortDescriptorCollection sortFilter = null; // TODO: 初始化为适当的值
            KeyValueDataObjectList expected = null; // TODO: 初始化为适当的值
            KeyValueDataObjectList actual;
            actual = target.GetAcModelCol(colFilter, sortFilter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAcModels 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcModelsTest()
        {
            IAcTypeQuery target = CreateIAcTypeQuery(); // TODO: 初始化为适当的值
            ColumnFilterDescriptorCollection colFilter = null; // TODO: 初始化为适当的值
            ColumnSortDescriptorCollection sortFilter = null; // TODO: 初始化为适当的值
            AcModelDataObjectList expected = null; // TODO: 初始化为适当的值
            AcModelDataObjectList actual;
            actual = target.GetAcModels(colFilter, sortFilter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAcTypeByGuid 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcTypeByGuidTest()
        {
            IAcTypeQuery target = CreateIAcTypeQuery(); // TODO: 初始化为适当的值
            string id = string.Empty; // TODO: 初始化为适当的值
            AcTypeDataObject expected = null; // TODO: 初始化为适当的值
            AcTypeDataObject actual;
            actual = target.GetAcTypeByGuid(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAcTypeByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcTypeByIDTest()
        {
            IAcTypeQuery target = CreateIAcTypeQuery(); // TODO: 初始化为适当的值
            int id = 0; // TODO: 初始化为适当的值
            AcTypeDataObject expected = null; // TODO: 初始化为适当的值
            AcTypeDataObject actual;
            actual = target.GetAcTypeByID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAcTypeCol 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcTypeColTest()
        {
            IAcTypeQuery target = CreateIAcTypeQuery(); // TODO: 初始化为适当的值
            ColumnFilterDescriptorCollection colFilter = null; // TODO: 初始化为适当的值
            ColumnSortDescriptorCollection sortFilter = null; // TODO: 初始化为适当的值
            KeyValueDataObjectList expected = null; // TODO: 初始化为适当的值
            KeyValueDataObjectList actual;
            actual = target.GetAcTypeCol(colFilter, sortFilter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAcTypeWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcTypeWithPaginationTest()
        {
            IAcTypeQuery target = CreateIAcTypeQuery(); // TODO: 初始化为适当的值
            Pagination pagination = null; // TODO: 初始化为适当的值
            AcTypeWithPagination expected = null; // TODO: 初始化为适当的值
            AcTypeWithPagination actual;
            actual = target.GetAcTypeWithPagination(pagination);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAcTypes 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcTypesTest()
        {
            IAcTypeQuery target = CreateIAcTypeQuery(); // TODO: 初始化为适当的值
            ColumnFilterDescriptorCollection colFilter = null; // TODO: 初始化为适当的值
            ColumnSortDescriptorCollection sortFilter = null; // TODO: 初始化为适当的值
            AcTypeDataObjectList expected = null; // TODO: 初始化为适当的值
            AcTypeDataObjectList actual;
            actual = target.GetAcTypes(colFilter, sortFilter);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
