using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;
using System.Linq;
using UniCloud.Query.AcConfiguration;
using System.IO;
using UniCloud.Infrastructure.Communication;

namespace UniCloud.Application.AcConfiguration.Test
{
    
    
    /// <summary>
    ///这是 IAcRegServiceTest 的测试类，旨在
    ///包含所有 IAcRegServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class IAcRegServiceTest
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
        [TestInitialize()]
        public void MyTestInitialize()
        {
            Initializer.Init();
        }
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        private readonly ServiceProxy<IAircraftService> aircraftService = new ServiceProxy<IAircraftService>();

        internal virtual IAcRegService CreateIAcRegService()
        {
            // TODO: 实例化相应的具体类。
            IAcRegService target = ServiceLocator.Instance.GetService<IAcRegService>(); 
            return target;
        }


        internal virtual IAcRegQuery CreateIAcRegQuery()
        {
            // TODO: 实例化相应的具体类。
            IAcRegQuery target = ServiceLocator.Instance.GetService<IAcRegQuery>();
            return target;
        }

        [TestMethod()]
        public void GetAcregWithPanitagion()
        {
            IAcRegQuery target = CreateIAcRegQuery();
            Pagination pagination = new Pagination();
            pagination.PageNumber = 1;
            pagination.PageSize = 10;
            var results= target.GetAcRegWithPagination(pagination);
            Assert.IsTrue(results.BaseDataObjectList.Count > 0);
        }

        /// <summary>
        ///CommitAcRegs 的测试
        ///</summary>
        [TestMethod()]
        public void CommitAcRegsTest()
        {
            IAcRegService target = CreateIAcRegService(); // TODO: 初始化为适当的值
            AcRegDataObject acreg = target.GetFullAcRegs().First(a=>a.ID==20);
            acreg.AcregLicenses.Add(new AcregLicenseDataObject()
                                    {
                                        LicenseTypeID=2,IssuedFrom="ds",State="有效",IssuedDate=DateTime.Now,
                                        DocumentGuid=Guid.NewGuid(),Guid=Guid.NewGuid(),ValidMonths=12
                                    });
            //FileStream stream = new FileStream("D:\\工作会议纪要（第2期）20130221.pdf", FileMode.Open);
            //var sBytes = new byte[stream.Length];
            //stream.Read(sBytes, 0, (int)stream.Length);
            //acreg.AcregLicenses.FirstOrDefault().Document = new StandardDocumentDataObject()
            //                                                {
            //                                                    FileName="aaaaaa",CreateDate=DateTime.Now,
            //                                                    DocumentFileStream = sBytes,
            //                                                    DocumentTypeID = new Guid("87C89539-293D-46D8-9186-3D2B6D92F12B"),
            //                                                    Abstract="AA",ExtendType=".pdf",Uploader="BB",
            //                                                    DocumentTypeName="合同",FileContent="bb",UnitName="aa",
            //                                                    IsDeleted=false,Note="aa",Tag="aa",IsIndex=1,ID=Guid.NewGuid()
            //                                                };
            //acreg.AcregLicenses.Add(new AcregLicenseDataObject() {State = "A", CopyFile = "dd"});
            AcRegResultData acRegData = new AcRegResultData()
                                        {
                                            //AddedCollection = new AcRegDataObjectList()
                                            //                  {
                                            //                      new AcRegDataObject()
                                            //                      {
                                            //                          EngineTr="22K",CreateDate=DateTime.Now,
                                            //                          AcTypeID=1,AcModelID=1,AcConfigID=1,
                                            //                          RegNumber="B-2212",
                                            //                          AcregLicenses=new AcregLicenseDataObjectList()
                                            //                                        {
                                            //                                            new AcregLicenseDataObject()
                                            //                                            {
                                            //                                                ExpireDate=DateTime.Now,
                                            //                                                IssuedFrom="BB"
                                            //                                            }
                                            //                                        }
                                            //                      }
                                            //                  }
                                            ModefiedCollection = new AcRegDataObjectList()
                                                                 {
                                                                     acreg
                                                                 }
                                        }; // TODO: 初始化为适当的值
            AcRegResultData expected = null; // TODO: 初始化为适当的值
            AcRegResultData actual;
            actual = target.CommitAcRegs(acRegData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreateAcRegs 的测试
        ///</summary>
        [TestMethod()]
        public void CreateAcRegsTest()
        {
            IAcRegService target = CreateIAcRegService(); // TODO: 初始化为适当的值
            AcRegDataObjectList acRegs = null; // TODO: 初始化为适当的值
            AcRegDataObjectList expected = null; // TODO: 初始化为适当的值
            AcRegDataObjectList actual;
            actual = target.CreateAcRegs(acRegs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteAcRegs 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteAcRegsTest()
        {
            IAcRegService target = CreateIAcRegService(); // TODO: 初始化为适当的值
            AcRegDataObjectList acRegIDs = new AcRegDataObjectList()
                                           {
                                               new AcRegDataObject(){ID=16,RegNumber="B-2123"}
                                           }; // TODO: 初始化为适当的值
            IDList expected = null; // TODO: 初始化为适当的值
            IDList actual;
            actual = target.DeleteAcRegs(acRegIDs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullAcRegByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullAcRegByIDTest()
        {
            IAcRegService target = CreateIAcRegService(); // TODO: 初始化为适当的值
            int id = 0; // TODO: 初始化为适当的值
            AcRegDataObject expected = null; // TODO: 初始化为适当的值
            AcRegDataObject actual;
            actual = target.GetFullAcRegByID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullAcRegs 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullAcRegsTest()
        {
            IAcRegService target = CreateIAcRegService(); // TODO: 初始化为适当的值
            AcRegDataObjectList expected = null; // TODO: 初始化为适当的值
            AcRegDataObjectList actual;
            actual = target.GetFullAcRegs();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateAcRegs 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateAcRegsTest()
        {
            IAcRegService target = CreateIAcRegService(); // TODO: 初始化为适当的值
            AcRegDataObjectList acRegs = null; // TODO: 初始化为适当的值
            AcRegDataObjectList expected = null; // TODO: 初始化为适当的值
            AcRegDataObjectList actual;
            actual = target.UpdateAcRegs(acRegs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
