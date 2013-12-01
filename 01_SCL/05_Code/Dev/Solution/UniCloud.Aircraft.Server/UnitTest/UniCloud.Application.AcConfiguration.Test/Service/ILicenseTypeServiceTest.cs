using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Application.AcConfiguration.Test
{
    
    
    /// <summary>
    ///这是 ILicenseTypeServiceTest 的测试类，旨在
    ///包含所有 ILicenseTypeServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class ILicenseTypeServiceTest
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


        internal virtual ILicenseTypeService CreateILicenseTypeService()
        {
            // TODO: 实例化相应的具体类。
            ILicenseTypeService target = ServiceLocator.Instance.GetService<ILicenseTypeService>(); ;
            return target;
        }

        /// <summary>
        ///CommitLicenseTypes 的测试
        ///</summary>
        [TestMethod()]
        public void CommitLicenseTypesTest()
        {
            ILicenseTypeService target = CreateILicenseTypeService(); // TODO: 初始化为适当的值
            LicenseTypeResultData licenseTypeData =null; // TODO: 初始化为适当的值
            LicenseTypeResultData expected = null; // TODO: 初始化为适当的值
            LicenseTypeResultData actual;
            actual = target.CommitLicenseTypes(licenseTypeData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreateLicenseTypes 的测试
        ///</summary>
        [TestMethod()]
        public void CreateLicenseTypesTest()
        {
            ILicenseTypeService target = CreateILicenseTypeService(); // TODO: 初始化为适当的值
            LicenseTypeDataObjectList licenseTypes = new LicenseTypeDataObjectList()
                                                     {
                                                         new LicenseTypeDataObject(){Description="BB",Type="A",Guid=Guid.NewGuid(),HasFile=true}
                                                     }; // TODO: 初始化为适当的值
            LicenseTypeDataObjectList expected = null; // TODO: 初始化为适当的值
            LicenseTypeDataObjectList actual;
            actual = target.CreateLicenseTypes(licenseTypes);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteLicenseTypes 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteLicenseTypesTest()
        {
            ILicenseTypeService target = CreateILicenseTypeService(); // TODO: 初始化为适当的值
            IDList licenseTypeIDs = null; // TODO: 初始化为适当的值
            IDList expected = null; // TODO: 初始化为适当的值
            IDList actual;
            actual = target.DeleteLicenseTypes(licenseTypeIDs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullLicenseTypeByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullLicenseTypeByIDTest()
        {
            ILicenseTypeService target = CreateILicenseTypeService(); // TODO: 初始化为适当的值
            int id = 0; // TODO: 初始化为适当的值
            LicenseTypeDataObject expected = null; // TODO: 初始化为适当的值
            LicenseTypeDataObject actual;
            actual = target.GetFullLicenseTypeByID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullLicenseTypes 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullLicenseTypesTest()
        {
            ILicenseTypeService target = CreateILicenseTypeService(); // TODO: 初始化为适当的值
            LicenseTypeDataObjectList expected = null; // TODO: 初始化为适当的值
            LicenseTypeDataObjectList actual;
            actual = target.GetFullLicenseTypes();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateLicenseTypes 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateLicenseTypesTest()
        {
            ILicenseTypeService target = CreateILicenseTypeService(); // TODO: 初始化为适当的值
            LicenseTypeDataObjectList licenseTypes = null; // TODO: 初始化为适当的值
            LicenseTypeDataObjectList expected = null; // TODO: 初始化为适当的值
            LicenseTypeDataObjectList actual;
            actual = target.UpdateLicenseTypes(licenseTypes);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
