using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;
using System.Linq;
using System.Collections.Generic;
using UniCloud.Domain.Model;

namespace UniCloud.Application.AcConfiguration.Test
{
    
    
    /// <summary>
    ///这是 IAcTypeServiceTest 的测试类，旨在
    ///包含所有 IAcTypeServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class IAcTypeServiceTest
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


        internal virtual IAcTypeService CreateIAcTypeService()
        {
            // TODO: 实例化相应的具体类。
            IAcTypeService target = ServiceLocator.Instance.GetService<IAcTypeService>();
            return target;
        }

        /// <summary>
        ///CommitAcTypes 的测试
        ///</summary>
        [TestMethod()]
        public void CommitAcTypesTest()
        {
            IAcTypeService target = CreateIAcTypeService(); // TODO: 初始化为适当的值
            AcTypeResultData acTypeData = null; // TODO: 初始化为适当的值
            AcTypeResultData expected = null; // TODO: 初始化为适当的值
            AcTypeResultData actual;
            actual = target.CommitAcTypes(acTypeData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreateAcTypes 的测试
        ///</summary>
        [TestMethod()]
        public void CreateAcTypesTest()
        {
            IAcTypeService target = CreateIAcTypeService(); // TODO: 初始化为适当的值
            AcTypeDataObjectList acTypes = null; // TODO: 初始化为适当的值
            AcTypeDataObjectList expected = null; // TODO: 初始化为适当的值
            AcTypeDataObjectList actual;
            actual = target.CreateAcTypes(acTypes);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullAcTypeByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullAcTypeByIDTest()
        {
            IAcTypeService target = CreateIAcTypeService(); // TODO: 初始化为适当的值
            int id = 0; // TODO: 初始化为适当的值
            AcTypeDataObject expected = null; // TODO: 初始化为适当的值
            AcTypeDataObject actual;
            actual = target.GetFullAcTypeByID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullAcTypes 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullAcTypesTest()
        {
            IAcTypeService target = CreateIAcTypeService(); // TODO: 初始化为适当的值
            AcTypeDataObjectList expected = null; // TODO: 初始化为适当的值
            AcTypeDataObjectList actual;
            actual = target.GetFullAcTypes();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateAcTypes 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateAcTypesTest()
        {
            IAcTypeService target = CreateIAcTypeService(); // TODO: 初始化为适当的值
            AcTypeDataObjectList acTypes = null; // TODO: 初始化为适当的值
            AcTypeDataObjectList expected = null; // TODO: 初始化为适当的值
            AcTypeDataObjectList actual;
            actual = target.UpdateAcTypes(acTypes);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateAcModels 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateAcModelsTest()
        {
            IAcTypeService target = CreateIAcTypeService(); // TODO: 初始化为适当的值
            var acModel = target.GetFullAcTypes()[0].Acmodels[0];
            acModel.Description = "AABB";
            int acTypeId = 2; // TODO: 初始化为适当的值
            AcModelDataObjectList acModels = new AcModelDataObjectList()
                                             {
                                                 acModel
                                             }; // TODO: 初始化为适当的值
            AcModelDataObjectList expected = null; // TODO: 初始化为适当的值
            AcModelDataObjectList actual;
            actual = target.UpdateAcModels(acTypeId, acModels);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateAcConfigs 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateAcConfigsTest()
        {
            IAcTypeService target = CreateIAcTypeService(); // TODO: 初始化为适当的值
            int acTypeId = 0; // TODO: 初始化为适当的值
            int acModelId = 0; // TODO: 初始化为适当的值
            AcConfigDataObjectList acConfigs = null; // TODO: 初始化为适当的值
            AcConfigDataObjectList expected = null; // TODO: 初始化为适当的值
            AcConfigDataObjectList actual;
            actual = target.UpdateAcConfigs(acTypeId, acModelId, acConfigs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreateAcModels 的测试
        ///</summary>
        [TestMethod()]
        public void CreateAcModelsTest()
        {
            IAcTypeService target = CreateIAcTypeService(); // TODO: 初始化为适当的值
            int acTypeId = 0; // TODO: 初始化为适当的值
            AcModelDataObjectList acModels = null; // TODO: 初始化为适当的值
            AcModelDataObjectList expected = null; // TODO: 初始化为适当的值
            AcModelDataObjectList actual;
            actual = target.CreateAcModels(acTypeId, acModels);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreateAcConfigs 的测试
        ///</summary>
        [TestMethod()]
        public void CreateAcConfigsTest()
        {
            IAcTypeService target = CreateIAcTypeService(); // TODO: 初始化为适当的值
            int acTypeId = 0; // TODO: 初始化为适当的值
            int acModelId = 0; // TODO: 初始化为适当的值
            AcConfigDataObjectList acConfigs = null; // TODO: 初始化为适当的值
            AcConfigDataObjectList expected = null; // TODO: 初始化为适当的值
            AcConfigDataObjectList actual;
            actual = target.CreateAcConfigs(acTypeId, acModelId, acConfigs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteAcConfigs 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteAcConfigsTest()
        {
            IAcTypeService target = CreateIAcTypeService(); // TODO: 初始化为适当的值
            var actype = target.GetFullAcTypes();
            int acTypeId = 5; // TODO: 初始化为适当的值
            int acModelId = 8; // TODO: 初始化为适当的值
            var p = actype.FirstOrDefault(a => a.ID == 5).Acmodels.FirstOrDefault(b => b.ID == 8).AcConfigs;
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.DeleteAcConfigs(acTypeId, acModelId, p);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteAcModels 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteAcModelsTest()
        {
            IAcTypeService target = CreateIAcTypeService(); // TODO: 初始化为适当的值
            int acTypeId = 0; // TODO: 初始化为适当的值
            AcModelDataObjectList acModels = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.DeleteAcModels(acTypeId, acModels);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteAcTypes 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteAcTypesTest1()
        {
            IAcTypeService target = CreateIAcTypeService(); // TODO: 初始化为适当的值
            IDList acTypeIDs = null; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.DeleteAcTypes(acTypeIDs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
