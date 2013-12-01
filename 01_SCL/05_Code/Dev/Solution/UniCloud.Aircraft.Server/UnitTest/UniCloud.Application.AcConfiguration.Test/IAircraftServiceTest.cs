using UniCloud.Infrastructure;
using UniCloud.Infrastructure.Communication;
using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using System.Collections.Generic;
using System.Linq;
using UniCloud.Domain.Model;

namespace UniCloud.Application.AcConfiguration.Test
{
    
    
    /// <summary>
    ///这是 IAircraftServiceTest 的测试类，旨在
    ///包含所有 IAircraftServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class IAircraftServiceTest
    {

        private readonly ServiceProxy<IAircraftService> aircraftService = new ServiceProxy<IAircraftService>();
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


        internal virtual IAircraftService CreateIAircraftService()
        {
            // TODO: 实例化相应的具体类。
            IAircraftService target = ServiceLocator.Instance.GetService<IAircraftService>(); 
            return target;
        }

        /// <summary>
        ///AddAcCategory 的测试
        ///</summary>
        [TestMethod()]
        public void AddAcCategoryTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            AcCategoryDataObjectList acCategorys = new AcCategoryDataObjectList()
                                                   {
                                                       new AcCategoryDataObject(){Guid=Guid.NewGuid(),Level="150",Regional=""},
                                                       new AcCategoryDataObject(){Guid=Guid.NewGuid(),Level="200",Regional=""},
                                                       new AcCategoryDataObject(){Guid=Guid.NewGuid(),Level="250",Regional=""},
                                                       new AcCategoryDataObject(){Guid=Guid.NewGuid(),Level="300",Regional=""}
                                                   }; // TODO: 初始化为适当的值
            //for (int i = 1; i < 11; i++)
            //{
            //    AcCategoryDataObject acCategory = new AcCategoryDataObject();
            //    acCategory.Guid = Guid.NewGuid();
            //    acCategory.Level = i.ToString();
            //    acCategory.Regional = "test";
            //    acCategorys.Add(acCategory);
            //}
            AcCategoryDataObjectList expected = null; // TODO: 初始化为适当的值
            AcCategoryDataObjectList actual;
            actual = target.AddAcCategory(acCategorys);
            Assert.AreNotEqual(actual.Count, 0);
        }

        /// <summary>
        ///AddAcReg 的测试
        ///</summary>
        [TestMethod()]
        public void AddAcRegTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            AcRegDataObjectList acRegs = new AcRegDataObjectList(); // TODO: 初始化为适当的值

            Random rand = new Random();

            var actypes = target.GetAllAcType();
            foreach (var actype in actypes)
            {
                foreach (var model in actype.Acmodels)
                {
                    foreach (var config in model.AcConfigs)
                    {
                        var acreg = new AcRegDataObject()
                                    {
                                        AcConfigGuid = config.Guid,
                                        AcConfigID = config.ID.Value,
                                        AcModelGuid = model.Guid,
                                        AcModelID = model.ID.Value,
                                        AcTypeGuid = actype.Guid,
                                        AcTypeID = actype.ID.Value,
                                        EngineTr = "2" + rand.Next(1, 5).ToString() + "K",
                                        CreateDate = DateTime.Now.AddYears(-rand.Next(1, 10)),
                                        Guid = Guid.NewGuid(),
                                        DecodeConfigGuid = Guid.NewGuid(),
                                        ExportCategory = "",
                                        Owner = "** airline",
                                        IsOperation = true,
                                        SubframeLenght = 256,
                                        Msn = "XF098776" + rand.Next(1, 100).ToString(),
                                        RegNumber = "B-" + rand.Next(1, 10).ToString() + rand.Next(1, 10).ToString() + rand.Next(1, 10).ToString() + rand.Next(1, 10).ToString(),
                                        OffsetUTC = 8,
                                        SeatingCapacity = 180 + rand.Next(1, 20),
                                        CarryingCapacity = 200,
                                        ImportCategory = "购买",
                                        AcregLicenses = new AcregLicenseDataObjectList()
                                                        {
                                                            new AcregLicenseDataObject(){Guid=Guid.NewGuid(),CopyFile="",IssuedFrom="中国民航局",ValidMonths=20,ExpireDate=DateTime.Now.AddYears(-rand.Next(1, 10)),
                                                            State="可用",Notes="",LicenseTypeID =target.GetAllLicenseType()[0].ID.Value,LicenseTypeGuid=target.GetAllLicenseType()[0].Guid},
                                                             new AcregLicenseDataObject(){Guid=Guid.NewGuid(),CopyFile="",IssuedFrom="中国民航局",ValidMonths=20,ExpireDate=DateTime.Now.AddYears(-rand.Next(1, 10)),
                                                            State="可用",Notes="",LicenseTypeID =target.GetAllLicenseType()[1].ID.Value,LicenseTypeGuid=target.GetAllLicenseType()[1].Guid}
                                                        }

                                    };
                        acRegs.Add(acreg);
                    }
                }
            }

            //var acreg = new AcRegDataObject();
            //acreg.Guid = Guid.NewGuid();
            //acreg.Owner = "";
            //acreg.AcConfigGuid = target.GetAllAcType()[0].Acmodels[0].AcConfigs[0].Guid;
            //acreg.AcConfigID = target.GetAllAcType()[0].Acmodels[0].AcConfigs[0].ID.Value;
            //acreg.AcModelGuid = target.GetAllAcType()[0].Acmodels[0].Guid;
            //acreg.AcModelID = target.GetAllAcType()[0].Acmodels[0].ID.Value;
            //acreg.AcTypeGuid = target.GetAllAcType()[0].Guid;
            //acreg.AcTypeID = target.GetAllAcType()[0].ID.Value;
            //acreg.OffsetUTC = 2;
            //acreg.Operators = "厦航";
            //acreg.IsOperation = false;
            //acreg.ImportCategory = "购买";
            //acreg.ImportDate = new DateTime(2011, 1, 1);
            //acreg.RegNumber = "11111";//此值不能相同，不然添加不成功
            //acreg.Msn = "11111111111111111";
            //acreg.CreateDate = new DateTime(2010, 1, 1);
            //acreg.CarryingCapacity = 1000;
            //acreg.DecodeConfigGuid = new Guid();
            //acreg.ExportDate = new DateTime(2015, 3, 3);
            //acreg.FactoryDate = new DateTime(2010, 3, 3);
            //acreg.EngineTr = "200K";
            //acreg.SeatingCapacity = 300;
            //acreg.SubframeLenght = 200;
            //var acregli = new AcregLicenseDataObject();
            //acregli.Guid = Guid.NewGuid();
            //acregli.AcRegGuid = acreg.Guid;
            //acregli.CopyFile = "none";
            //acregli.ExpireDate = new DateTime(2012, 1, 1);
            //acregli.IssuedDate = new DateTime(2012, 1, 1);
            //acregli.IssuedFrom = "厦航";
            //acregli.LicenseTypeGuid = target.GetAllLicenseType()[0].Guid;
            //acregli.LicenseTypeID = target.GetAllLicenseType()[0].ID.Value;
            //acregli.Notes = "note";
            //acregli.State = "可用";
            //acregli.ValidMonths = 22;
            //acreg.AcregLicenses.Add(acregli);
            //acRegs.Add(acreg);
            AcRegDataObjectList expected = null; // TODO: 初始化为适当的值
            AcRegDataObjectList actual;
            actual = target.AddAcReg(acRegs);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///AddAcType 的测试
        ///</summary>
        [TestMethod()]
        public void AddAcTypeTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            AcTypeDataObjectList actypes = new AcTypeDataObjectList()
                                           {
                                             
                                           }; // TODO: 初始化为适当的值

            var acCategorys = target.GetAllAcCategory();
            var names = new string[] {"B737", "B757", "B787", "A320"};
            for (int i = 0; i < acCategorys.Count; i++)
            {
                AcTypeDataObject typeDto = new AcTypeDataObject();
                typeDto.AcCategoryID = acCategorys[i].ID;
                typeDto.AcCategoryGuid = acCategorys[i].Guid;
                typeDto.Name = names[i];
                typeDto.Manufacturer = "The Boeing Company";
                typeDto.Guid = Guid.NewGuid();
                typeDto.Acmodels = new AcModelDataObjectList()
                                   {
                                       new AcModelDataObject(){Guid=Guid.NewGuid(),Name=typeDto.Name+"-800",AcTypeGuid=typeDto.Guid,AcConfigs=
                                       new AcConfigDataObjectList()
                                       {
                                           new AcConfigDataObject(){BEW=10000,BW=10000,BWF=9898,BWI=12,Guid=Guid.NewGuid(),MCC=12000,MLW=12890,
                                           MMFW=800,MTOW=11000,MTW=12000,MZFW=11000,Name=typeDto.Name+"-800-02"},
                                           new AcConfigDataObject(){BEW=12000,BW=12000,BWF=10898,BWI=18,Guid=Guid.NewGuid(),MCC=12000,MLW=10890,
                                           MMFW=800,MTOW=11000,MTW=12000,MZFW=11000,Name=typeDto.Name+"-800-03"}
                                       }}
                                   };
                actypes.Add(typeDto);
            }
            


            //for (int i = 2; i < 5; i++)
            //{
            //    var actype = new AcTypeDataObject();
            //    actype.Guid = Guid.NewGuid();
            //    actype.AcCategoryGuid = target.GetAllAcCategory()[i-1].Guid;
            //    actype.AcCategoryID = target.GetAllAcCategory()[i-1].ID.Value;
            //    actype.Description = "test";
            //    actype.Manufacturer = "test";
            //    actype.Name = "AcType"+i.ToString(); //此值不能相同，不然添加不成功
            //    for (int j = 2; j < 5; j++)
            //    {
            //        var acmodel = new AcModelDataObject();
            //        var actypeata = new AtaDataObject();
            //        acmodel.Guid = Guid.NewGuid();
            //        acmodel.AcTypeGuid = actype.Guid;
            //        acmodel.Description = "test";
            //        acmodel.Name = "testModel" + i.ToString() + j.ToString(); //此值不能相同，不然添加不成功
            //        for (int k = 1; k < 5; k++)
            //        {
            //            var acconfig = new AcConfigDataObject();
            //            acconfig.Guid = Guid.NewGuid();
            //            acconfig.AcModelGuid = acmodel.Guid;
            //            acconfig.BEW = 10000;
            //            acconfig.BW = 100000;
            //            acconfig.BWF = 10000;
            //            acconfig.BWI = 10000;
            //            acconfig.Description = "test";
            //            acconfig.MCC = 10000;
            //            acconfig.MLW = 10000;
            //            acconfig.MMFW = 10000;
            //            acconfig.MTOW = 10000;
            //            acconfig.MTW = 10000;
            //            acconfig.MZFW = 10000;
            //            acconfig.Name = "acconfig" + i.ToString() + j.ToString() + k.ToString(); //此值不能相同，不然添加不成功
            //            acmodel.AcConfigs.Add(acconfig);
            //        }
            //        //actypeata.Guid = Guid.NewGuid();
            //        //actypeata.Ata = "1256"; //同一个AcType中此值不能相同，不然添加不成功
            //        //actypeata.Description = "test";
            //        actype.AcCategory = target.GetAllAcCategory()[i-1];
            //        actype.Atas.Add(target.GetAllAta()[i-1]);
            //        actype.Acmodels.Add(acmodel);
            //    }
            //    //actype.Atas.Add(actypeata);
            //    actypes.Add(actype);
            //}
            //AcTypeDataObjectList expected = null; // TODO: 初始化为适当的值
            AcTypeDataObjectList actual;
            actual = target.AddAcType(actypes);
            Assert.AreNotEqual(0, actual.Count);
        }

        /// <summary>
        ///AddLicenseType 的测试
        ///</summary>
        [TestMethod()]
        public void AddLicenseTypeTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            LicenseTypeDataObjectList licenseTypes = new LicenseTypeDataObjectList()
                                                     {
                                                         new LicenseTypeDataObject(){Guid=Guid.NewGuid(),Type="BA",HasFile=true,Description=""},
                                                         new LicenseTypeDataObject(){Guid=Guid.NewGuid(),Type="BK",HasFile=true,Description=""}
                                                     }; // TODO: 初始化为适当的值
            //for (int i = 1; i < 2; i++)
            //{
            //    var licenseType = new LicenseTypeDataObject();
            //    licenseType.Guid = Guid.NewGuid();
            //    licenseType.Description = "testlicensetype";
            //    licenseType.HasFile = false;
            //    licenseType.Type = "test"+i.ToString();//此值不能相同，不然添加不成功
            //    licenseTypes.Add(licenseType);
            //}
            
            LicenseTypeDataObjectList expected = null; // TODO: 初始化为适当的值
            LicenseTypeDataObjectList actual;
            actual = target.AddLicenseType(licenseTypes);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///DeleteAcCategory 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteAcCategoryTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            IDList acCategoryIds = new IDList(); // TODO: 初始化为适当的值
            acCategoryIds.Add("21");
            target.DeleteAcCategory(acCategoryIds);
        }

        ///// <summary>
        /////DeleteAcReg 的测试
        /////</summary>
        //[TestMethod()]
        //public void DeleteAcRegTest()
        //{
        //    IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
        //    IDList acRegIds = new IDList(); // TODO: 初始化为适当的值
        //    for (int i = 21; i < 31; i++)
        //    {
        //        acRegIds.Add(i.ToString());
        //    }
        //    target.DeleteAcReg(acRegIds);
        //    Assert.Inconclusive("无法验证不返回值的方法。");
        //}

        /// <summary>
        ///DeleteAcType 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteAcTypeTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            IDList actypeIds = new IDList(); // TODO: 初始化为适当的值
            actypeIds.Add("29");
            target.DeleteAcType(actypeIds);//有被AcReg引用的无法删除
        }

        /// <summary>
        ///DeleteLicenseType 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteLicenseTypeTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            IDList licenseTypeIds = new IDList(); // TODO: 初始化为适当的值
            licenseTypeIds.Add("41");
            target.DeleteLicenseType(licenseTypeIds);//有被AcReg引用的无法删除
        }

        /// <summary>
        ///GetAcCategory 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcCategoryTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            int id = target.GetAllAcCategory()[0].ID.Value; // TODO: 初始化为适当的值
            AcCategoryDataObject expected = null; // TODO: 初始化为适当的值
            AcCategoryDataObject actual;
            actual = target.GetAcCategory(id);
            Assert.AreNotEqual(actual,null);
        }

        /// <summary>
        ///GetAcCategoryByGuid 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcCategoryByGuidTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            Guid guid = target.GetAllAcCategory()[0].Guid;// TODO: 初始化为适当的值
            AcCategoryDataObject expected = null; // TODO: 初始化为适当的值
            AcCategoryDataObject actual;
            actual = target.GetAcCategoryByGuid(guid);
            Assert.AreNotEqual(actual, null);
        }

        /// <summary>
        ///GetAcConfig 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcConfigTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            int acTypeId = target.GetAllAcType()[0].ID.Value; // TODO: 初始化为适当的值
            int acModelId = target.GetAllAcType()[0].Acmodels[0].ID.Value; // TODO: 初始化为适当的值
            AcConfigDataObjectList expected = null; // TODO: 初始化为适当的值
            AcConfigDataObjectList actual;
            actual = target.GetAcConfig(acTypeId, acModelId);
            Assert.AreNotEqual(actual.Count, 0);
        }

        /// <summary>
        ///GetAcConfigByGuid 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcConfigByGuidTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            Guid acTypeGuid = target.GetAllAcType()[0].Guid; // TODO: 初始化为适当的值
            Guid acModelGuid = target.GetAllAcType()[0].Acmodels[0].Guid; // TODO: 初始化为适当的值
            AcConfigDataObjectList expected = null; // TODO: 初始化为适当的值
            AcConfigDataObjectList actual;
            actual = target.GetAcConfigByGuid(acTypeGuid, acModelGuid);
            Assert.AreNotEqual(actual.Count, 0);
        }

        /// <summary>
        ///GetAcModel 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcModelTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            int acTypeId = target.GetAllAcType()[0].ID.Value; // TODO: 初始化为适当的值
            AcModelDataObjectList expected = null; // TODO: 初始化为适当的值
            AcModelDataObjectList actual;
            actual = target.GetAcModel(acTypeId);
            Assert.AreNotEqual(actual.Count, 0);
        }

        /// <summary>
        ///GetAcModelByGuid 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcModelByGuidTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            Guid acTypeGuid = target.GetAllAcType()[0].Guid; // TODO: 初始化为适当的值
            AcModelDataObjectList expected = null; // TODO: 初始化为适当的值
            AcModelDataObjectList actual;
            actual = target.GetAcModelByGuid(acTypeGuid);
            Assert.AreNotEqual(actual.Count, 0);
        }

        /// <summary>
        ///GetAcReg 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcRegTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            int id = target.GetAllAcReg()[0].ID.Value; // TODO: 初始化为适当的值
            AcRegDataObject expected = null; // TODO: 初始化为适当的值
            AcRegDataObject actual;
            actual = target.GetAcReg(id);
            Assert.AreNotEqual(actual, null);
        }

        /// <summary>
        ///GetAcRegByGuid 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcRegByGuidTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            Guid guid = target.GetAllAcReg()[0].Guid; // TODO: 初始化为适当的值
            AcRegDataObject expected = null; // TODO: 初始化为适当的值
            AcRegDataObject actual;
            actual = target.GetAcRegByGuid(guid);
            Assert.AreNotEqual(actual, null);
        }

        /// <summary>
        ///GetAcRegByGuidWithoutNavigationAttr 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcRegByGuidWithoutNavigationAttrTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            Guid guid = target.GetAllAcReg()[0].Guid; // TODO: 初始化为适当的值
            AcRegDataObject expected = null; // TODO: 初始化为适当的值
            AcRegDataObject actual;
            actual = target.GetAcRegByGuidWithoutNavigationAttr(guid);
            Assert.AreNotEqual(actual, null);
        }

        /// <summary>
        ///GetAcRegWithoutNavigationAttr 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcRegWithoutNavigationAttrTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            int id = target.GetAllAcReg()[0].ID.Value; // TODO: 初始化为适当的值
            AcRegDataObject expected = null; // TODO: 初始化为适当的值
            AcRegDataObject actual;
            actual = target.GetAcRegWithoutNavigationAttr(id);
            Assert.AreNotEqual(actual, null);
        }

        /// <summary>
        ///GetAcTypeAta 的测试
        ///</summary>
        [TestMethod()]
        public void GetAtaTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            int ataId = target.GetAllAta()[0].ID.Value; // TODO: 初始化为适当的值
            AtaDataObject expected = null; // TODO: 初始化为适当的值
            AtaDataObject actual;
            actual = target.GetAta(ataId);
            Assert.AreNotEqual(actual, expected);
        }

        /// <summary>
        ///GetAcTypeAtaByGuid 的测试
        ///</summary>
        [TestMethod()]
        public void GetAtaByGuidTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            Guid ataGuid = target.GetAllAta()[0].Guid; // TODO: 初始化为适当的值
            AtaDataObject expected = null; // TODO: 初始化为适当的值
            AtaDataObject actual;
            actual = target.GetAtaByGuid(ataGuid);
            Assert.AreNotEqual(actual, expected);
        }

        /// <summary>
        ///GetAcregLicense 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcregLicenseTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            int acRegId = target.GetAllAcReg()[0].ID.Value; // TODO: 初始化为适当的值
            AcregLicenseDataObjectList expected = null; // TODO: 初始化为适当的值
            AcregLicenseDataObjectList actual;
            actual = target.GetAcregLicense(acRegId);
            Assert.AreNotEqual(actual.Count, 0);
        }

        /// <summary>
        ///GetAcregLicenseByGuid 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcregLicenseByGuidTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            Guid acRegGuid = target.GetAllAcReg()[0].Guid; // TODO: 初始化为适当的值
            AcregLicenseDataObjectList expected = null; // TODO: 初始化为适当的值
            AcregLicenseDataObjectList actual;
            actual = target.GetAcregLicenseByGuid(acRegGuid);
            Assert.AreNotEqual(actual.Count, 0);
        }

        /// <summary>
        ///GetActype 的测试
        ///</summary>
        [TestMethod()]
        public void GetActypeTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            int id = target.GetAllAcType()[0].ID.Value; // TODO: 初始化为适当的值
            AcTypeDataObject expected = null; // TODO: 初始化为适当的值
            AcTypeDataObject actual;
            actual = target.GetActype(id);
            Assert.AreNotEqual(actual, null);
        }

        /// <summary>
        ///GetActypeByGuid 的测试
        ///</summary>
        [TestMethod()]
        public void GetActypeByGuidTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            Guid guid = new Guid("da3fcae8-e303-4afb-88e1-92686c773086");//target.GetAllAcType()[0].Guid; // TODO: 初始化为适当的值
            AcTypeDataObject expected = null; // TODO: 初始化为适当的值
            AcTypeDataObject actual;
            actual = target.GetActypeByGuid(guid);
            Assert.AreNotEqual(actual, null);
        }

        /// <summary>
        ///GetActypeByGuidWithoutNavigationAttr 的测试
        ///</summary>
        [TestMethod()]
        public void GetActypeByGuidWithoutNavigationAttrTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            Guid guid = target.GetAllAcType()[0].Guid; // TODO: 初始化为适当的值
            AcTypeDataObject expected = null; // TODO: 初始化为适当的值
            AcTypeDataObject actual;
            actual = target.GetActypeByGuidWithoutNavigationAttr(guid);
            Assert.AreNotEqual(actual, null);
        }

        /// <summary>
        ///GetActypeWithoutNavigationAttr 的测试
        ///</summary>
        [TestMethod()]
        public void GetActypeWithoutNavigationAttrTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            int id = target.GetAllAcType()[0].ID.Value; // TODO: 初始化为适当的值
            AcTypeDataObject expected = null; // TODO: 初始化为适当的值
            AcTypeDataObject actual;
            actual = target.GetActypeWithoutNavigationAttr(id);
            Assert.AreNotEqual(actual, null);
        }

        /// <summary>
        ///GetAllAcCategory 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllAcCategoryTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            AcCategoryDataObjectList expected = null; // TODO: 初始化为适当的值
            AcCategoryDataObjectList actual;
            actual = target.GetAllAcCategory();
            Assert.AreNotEqual(actual, null);
        }

        /// <summary>
        ///GetAllAcReg 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllAcRegTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            AcRegDataObjectList expected = null; // TODO: 初始化为适当的值
            AcRegDataObjectList actual;
            actual = target.GetAllAcReg();
            Assert.AreNotEqual(actual, null);
        }

        /// <summary>
        ///GetAllAcRegWithoutNavigationAttr 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllAcRegWithoutNavigationAttrTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            AcRegDataObjectList expected = null; // TODO: 初始化为适当的值
            AcRegDataObjectList actual;
            actual = target.GetAllAcRegWithoutNavigationAttr();
            Assert.AreNotEqual(actual.Count, 0);
        }

        /// <summary>
        ///GetAllAcType 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllAcTypeTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            AcTypeDataObjectList expected = null; // TODO: 初始化为适当的值
            AcTypeDataObjectList actual;
            actual = target.GetAllAcType();
            Assert.AreNotEqual(actual, null);
        }

        /// <summary>
        ///GetAllAta 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllAtaTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            AtaDataObjectList expected = null; // TODO: 初始化为适当的值
            AtaDataObjectList actual;
            actual = target.GetAllAta();
            Assert.AreNotEqual(actual, null);
        }

        /// <summary>
        ///GetAllAcTypeWithoutNavigationAttr 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllAcTypeWithoutNavigationAttrTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            AcTypeDataObjectList expected = null; // TODO: 初始化为适当的值
            AcTypeDataObjectList actual;
            actual = target.GetAllAcTypeWithoutNavigationAttr();
            Assert.AreNotEqual(actual, null);
        }

        /// <summary>
        ///GetAllLicenseType 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllLicenseTypeTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            LicenseTypeDataObjectList expected = null; // TODO: 初始化为适当的值
            LicenseTypeDataObjectList actual;
            actual = target.GetAllLicenseType();
            Assert.AreNotEqual(actual.Count, 0);
        }

        ///// <summary>
        /////GetAllLicenseTypeWithoutNavigationAttr 的测试
        /////</summary>
        //[TestMethod()]
        //public void GetAllLicenseTypeWithoutNavigationAttrTest()
        //{
        //    IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
        //    LicenseTypeDataObjectList expected = null; // TODO: 初始化为适当的值
        //    LicenseTypeDataObjectList actual;
        //    actual = target.GetAllLicenseTypeWithoutNavigationAttr();
        //    Assert.AreNotEqual(actual, null);
        //    Assert.Inconclusive("验证此测试方法的正确性。");
        //}

        /// <summary>
        ///GetLicenseType 的测试
        ///</summary>
        [TestMethod()]
        public void GetLicenseTypeTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            int id = target.GetAllLicenseType()[0].ID.Value; // TODO: 初始化为适当的值
            LicenseTypeDataObject expected = null; // TODO: 初始化为适当的值
            LicenseTypeDataObject actual;
            actual = target.GetLicenseType(id);
            Assert.AreNotEqual(actual, null);
        }

        /// <summary>
        ///GetLicenseTypeByGuid 的测试
        ///</summary>
        [TestMethod()]
        public void GetLicenseTypeByGuidTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            Guid guid = target.GetAllLicenseType()[0].Guid; // TODO: 初始化为适当的值
            LicenseTypeDataObject expected = null; // TODO: 初始化为适当的值
            LicenseTypeDataObject actual;
            actual = target.GetLicenseTypeByGuid(guid);
            Assert.AreNotEqual(actual, null);
        }

        ///// <summary>
        /////GetLicenseTypeByGuidWithoutNavigationAttr 的测试
        /////</summary>
        //[TestMethod()]
        //public void GetLicenseTypeByGuidWithoutNavigationAttrTest()
        //{
        //    IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
        //    Guid guid = target.GetAllLicenseType()[0].Guid; // TODO: 初始化为适当的值
        //    LicenseTypeDataObject expected = null; // TODO: 初始化为适当的值
        //    LicenseTypeDataObject actual;
        //    actual = target.GetLicenseTypeByGuidWithoutNavigationAttr(guid);
        //    Assert.AreNotEqual(actual, null);
        //    Assert.Inconclusive("验证此测试方法的正确性。");
        //}

        ///// <summary>
        /////GetLicenseTypeWithoutNavigationAttr 的测试
        /////</summary>
        //[TestMethod()]
        //public void GetLicenseTypeWithoutNavigationAttrTest()
        //{
        //    IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
        //    int id = target.GetAllLicenseType()[0].ID.Value; // TODO: 初始化为适当的值
        //    LicenseTypeDataObject expected = null; // TODO: 初始化为适当的值
        //    LicenseTypeDataObject actual;
        //    actual = target.GetLicenseTypeWithoutNavigationAttr(id);
        //    Assert.AreNotEqual(actual, null);
        //    Assert.Inconclusive("验证此测试方法的正确性。");
        //}

        /// <summary>
        ///UpdateAcCategory 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateAcCategoryTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            AcCategoryDataObjectList acCategorys = target.GetAllAcCategory(); // TODO: 初始化为适当的值
            AcCategoryDataObjectList expected = null; // TODO: 初始化为适当的值
            foreach (var acCategory in acCategorys)
            {
                acCategory.Regional = "newtest";
            }
            AcCategoryDataObjectList actual;
            actual = target.UpdateAcCategory(acCategorys);
            Assert.AreNotEqual(0, actual.Count);
        }

        /// <summary>
        ///UpdateAcReg 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateAcRegTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            AcRegDataObjectList acRegs = target.GetAllAcReg(); // TODO: 初始化为适当的值
            AcRegDataObjectList expected = null; // TODO: 初始化为适当的值
            foreach (var acReg in acRegs)
            {
                acReg.ImportCategory = "引进";
            }
            AcRegDataObjectList actual;
            actual = target.UpdateAcReg(acRegs);
            Assert.AreNotEqual(0, actual.Count);
        }

        /// <summary>
        ///UpdateAcType 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateAcTypeTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            AcTypeDataObjectList actypes = target.GetAllAcType(); // TODO: 初始化为适当的值
            AcTypeDataObjectList expected = null; // TODO: 初始化为适当的值
            var actype = target.GetAllAcType()[5];
                actype.Manufacturer = "至正科技";
                actype.Atas.Add(target.GetAllAta()[0]);
            AcTypeDataObjectList actual;
            actual = target.UpdateAcType(actypes);
            Assert.AreNotEqual(0, actual.Count);
        }

        /// <summary>
        ///UpdateLicenseType 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateLicenseTypeTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            LicenseTypeDataObjectList licenseTypes = target.GetAllLicenseType(); // TODO: 初始化为适当的值
            for (int i = 0; i < licenseTypes.Count; i++)
            {
                licenseTypes[i].Description = licenseTypes[i].Type + i.ToString();//Type为业务组件无法更新
            }
            LicenseTypeDataObjectList expected = null; // TODO: 初始化为适当的值
            LicenseTypeDataObjectList actual;
            actual = target.UpdateLicenseType(licenseTypes);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///UpdateAcregLicenseByGuid 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateAcregLicenseByGuidTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            Guid acRegGuid = target.GetAllAcReg()[0].Guid; // TODO: 初始化为适当的值
            AcregLicenseDataObjectList acregLicenses = target.GetAcregLicenseByGuid(target.GetAllAcReg()[0].Guid); // TODO: 初始化为适当的值
            AcregLicenseDataObjectList expected = null; // TODO: 初始化为适当的值
            foreach (var acregLicense in acregLicenses)
            {
                acregLicense.CopyFile = "未使用";
            }
            AcregLicenseDataObjectList actual;
            actual = target.UpdateAcregLicenseByGuid(acRegGuid, acregLicenses);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///UpdateAcregLicense 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateAcregLicenseTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            int acRegId = target.GetAllAcReg()[0].ID.Value; // TODO: 初始化为适当的值
            AcregLicenseDataObjectList acregLicenses = target.GetAcregLicenseByGuid(target.GetAllAcReg()[0].Guid); // TODO: 初始化为适当的值
            AcregLicenseDataObjectList expected = null; // TODO: 初始化为适当的值
            foreach (var acregLicense in acregLicenses)
            {
                acregLicense.CopyFile = "使用";
            }
            AcregLicenseDataObjectList actual;
            actual = target.UpdateAcregLicense(acRegId, acregLicenses);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///UpdateAcModelByGuid 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateAcModelByGuidTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            Guid acTypeGuid = target.GetAllAcType()[0].Guid; // TODO: 初始化为适当的值
            AcModelDataObjectList acModels = target.GetAcModel(target.GetAllAcType()[0].ID.Value); // TODO: 初始化为适当的值
            AcModelDataObjectList expected = null; // TODO: 初始化为适当的值
            foreach (var acModel in acModels)
            {
                acModel.Description = "testtwo";//Name为业务组件，无法更新
            }
            AcModelDataObjectList actual;
            actual = target.UpdateAcModelByGuid(acTypeGuid, acModels);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///UpdateAcModel 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateAcModelTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            int acTypeId = target.GetAllAcType()[0].ID.Value; // TODO: 初始化为适当的值
            AcModelDataObjectList acModels = target.GetAcModel(target.GetAllAcType()[0].ID.Value); // TODO: 初始化为适当的值
            AcModelDataObjectList expected = null; // TODO: 初始化为适当的值
            foreach (var acModel in acModels)
            {
                acModel.Description = "testone";//Name为业务组件，无法更新
            }
            AcModelDataObjectList actual;
            actual = target.UpdateAcModel(acTypeId, acModels);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///UpdateAcConfigByGuid 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateAcConfigByGuidTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            Guid acTypeGuid = target.GetAllAcType()[0].Guid; // TODO: 初始化为适当的值
            Guid acModelGuid = target.GetAllAcType()[0].Acmodels[0].Guid; // TODO: 初始化为适当的值
            AcConfigDataObjectList acConfigs = target.GetAcConfigByGuid(acTypeGuid, acModelGuid); // TODO: 初始化为适当的值
            foreach (var acConfig in acConfigs)
            {
                acConfig.Description = "testGuid";//Name为业务组件，无法更新
            }
            AcConfigDataObjectList expected = null; // TODO: 初始化为适当的值
            AcConfigDataObjectList actual;
            actual = target.UpdateAcConfigByGuid(acTypeGuid, acModelGuid, acConfigs);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///UpdateAcConfig 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateAcConfigTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            int acTypeId = target.GetAllAcType()[0].ID.Value; // TODO: 初始化为适当的值
            int acModelId = target.GetAllAcType()[0].Acmodels[0].ID.Value; // TODO: 初始化为适当的值
            AcConfigDataObjectList acConfigs = target.GetAcConfig(acTypeId, acModelId); // TODO: 初始化为适当的值
            foreach (var acConfig in acConfigs)
            {
                acConfig.Description = "testID";//Name为业务组件，无法更新
            }
            AcConfigDataObjectList expected = null; // TODO: 初始化为适当的值
            AcConfigDataObjectList actual;
            actual = target.UpdateAcConfig(acTypeId, acModelId, acConfigs);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///DeleteAcregLicenseByGuid 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteAcregLicenseByGuidTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            Guid acRegGuid = target.GetAllAcReg()[0].Guid; // TODO: 初始化为适当的值
            AcregLicenseDataObjectList acregLicenses = target.GetAcregLicenseByGuid(acRegGuid); // TODO: 初始化为适当的值
            target.DeleteAcregLicenseByGuid(acRegGuid, acregLicenses);
        }

        /// <summary>
        ///DeleteAcregLicense 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteAcregLicenseTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            int acRegId = target.GetAllAcReg()[0].ID.Value; // TODO: 初始化为适当的值
            AcregLicenseDataObjectList acregLicenses = target.GetAcregLicense(acRegId); // TODO: 初始化为适当的值
            target.DeleteAcregLicense(acRegId, acregLicenses);
        }

        /// <summary>
        ///DeleteAcModelByGuid 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteAcModelByGuidTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            Guid acTypeGuid = target.GetAllAcType()[0].Guid; // TODO: 初始化为适当的值
            AcModelDataObjectList acModels = new AcModelDataObjectList(); // TODO: 初始化为适当的值
            acModels.Add(target.GetAllAcType()[0].Acmodels[0]);
            target.DeleteAcModelByGuid(acTypeGuid, acModels);//有被AcReg引用的无法删除
        }

        /// <summary>
        ///DeleteAcModel 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteAcModelTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            int acTypeId = target.GetAllAcType()[0].ID.Value; // TODO: 初始化为适当的值
            AcModelDataObjectList acModels = new AcModelDataObjectList(); // TODO: 初始化为适当的值
            acModels.Add(target.GetAllAcType()[0].Acmodels[0]);
            target.DeleteAcModel(acTypeId, acModels);//有被AcReg引用的无法删除
        }

        /// <summary>
        ///DeleteAcConfigByGuid 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteAcConfigByGuidTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            Guid acTypeGuid = target.GetAllAcType()[0].Guid; // TODO: 初始化为适当的值
            Guid acModelGuid = target.GetAllAcType()[0].Acmodels[0].Guid; // TODO: 初始化为适当的值
            AcConfigDataObjectList acConfigs = new AcConfigDataObjectList(); // TODO: 初始化为适当的值
            acConfigs.Add(target.GetAllAcType()[0].Acmodels[0].AcConfigs[1]);
            target.DeleteAcConfigByGuid(acTypeGuid, acModelGuid, acConfigs);//有被AcReg引用的无法删除
        }

        /// <summary>
        ///DeleteAcConfig 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteAcConfigTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            int acTypeId = target.GetAllAcType()[0].ID.Value; // TODO: 初始化为适当的值
            int acModelId = target.GetAllAcType()[0].Acmodels[0].ID.Value; // TODO: 初始化为适当的值
            AcConfigDataObjectList acConfigs = new AcConfigDataObjectList(); // TODO: 初始化为适当的值
            acConfigs.Add(target.GetAllAcType()[0].Acmodels[0].AcConfigs[0]);
            target.DeleteAcConfig(acTypeId, acModelId, acConfigs);//有被AcReg引用的无法删除
        }

        ///// <summary>
        /////DeleteAcTypeAta 的测试
        /////</summary>
        //[TestMethod()]
        //public void DeleteAcTypeAtaTest()
        //{
        //    IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
        //    int acTypeId = target.GetAllAcType()[0].ID.Value; // TODO: 初始化为适当的值
        //    AtaDataObjectList acTypeAtas = new AtaDataObjectList() ; // TODO: 初始化为适当的值
        //    acTypeAtas.Add(target.GetAllAcType()[0].ActypeAtas[0]);
        //    target.DeleteAcTypeAta(acTypeId, acTypeAtas);
        //}

        ///// <summary>
        /////DeleteAcTypeAtaByGuid 的测试
        /////</summary>
        //[TestMethod()]
        //public void DeleteAcTypeAtaByGuidTest()
        //{
        //    IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
        //    Guid acTypeGuid = target.GetAllAcType()[0].Guid; // TODO: 初始化为适当的值
        //    AtaDataObjectList acTypeAtas = new AtaDataObjectList(); // TODO: 初始化为适当的值
        //    acTypeAtas.Add(target.GetAllAcType()[0].ActypeAtas[0]);
        //    target.DeleteAcTypeAtaByGuid(acTypeGuid, acTypeAtas);
        //}

        /// <summary>
        ///AddAcregLicenseByGuid 的测试
        ///</summary>
        [TestMethod()]
        public void AddAcregLicenseByGuidTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            Guid acRegGuid = target.GetAllAcReg()[0].Guid; // TODO: 初始化为适当的值
            AcregLicenseDataObjectList acregLicenses = new AcregLicenseDataObjectList(); // TODO: 初始化为适当的值
            var acregli = new AcregLicenseDataObject();
            acregli.Guid = Guid.NewGuid();
            acregli.AcRegGuid = acRegGuid;
            acregli.CopyFile = "none";
            acregli.ExpireDate = new DateTime(2012, 1, 1);
            acregli.IssuedDate = new DateTime(2012, 1, 1);
            acregli.IssuedFrom = "厦航";
            acregli.LicenseTypeGuid = target.GetAllLicenseType()[0].Guid;
            acregli.LicenseTypeID = target.GetAllLicenseType()[0].ID.Value;
            acregli.Notes = "note";
            acregli.State = "可用";
            acregli.ValidMonths = 22;
            acregLicenses.Add(acregli);
            AcregLicenseDataObjectList expected = null; // TODO: 初始化为适当的值
            AcregLicenseDataObjectList actual;
            actual = target.AddAcregLicenseByGuid(acRegGuid, acregLicenses);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///AddAcregLicense 的测试
        ///</summary>
        [TestMethod()]
        public void AddAcregLicenseTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            int acRegId = target.GetAllAcReg()[0].ID.Value; // TODO: 初始化为适当的值
            AcregLicenseDataObjectList acregLicenses = new AcregLicenseDataObjectList(); // TODO: 初始化为适当的值
            var acregli = new AcregLicenseDataObject();
            acregli.Guid = Guid.NewGuid();
            acregli.AcRegGuid = target.GetAllAcReg()[0].Guid;
            acregli.CopyFile = "none";
            acregli.ExpireDate = new DateTime(2012, 1, 1);
            acregli.IssuedDate = new DateTime(2012, 1, 1);
            acregli.IssuedFrom = "厦航";
            acregli.LicenseTypeGuid = target.GetAllLicenseType()[0].Guid;
            acregli.LicenseTypeID = target.GetAllLicenseType()[0].ID.Value;
            acregli.Notes = "note";
            acregli.State = "可用";
            acregli.ValidMonths = 22;
            acregLicenses.Add(acregli);
            AcregLicenseDataObjectList expected = null; // TODO: 初始化为适当的值
            AcregLicenseDataObjectList actual;
            actual = target.AddAcregLicense(acRegId, acregLicenses);
            Assert.AreNotEqual(0, actual.Count);
        }

        ///// <summary>
        /////AddAcTypeAtaByGuid 的测试
        /////</summary>
        //[TestMethod()]
        //public void AddAcTypeAtaByGuidTest()
        //{
        //    IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
        //    Guid acTypeGuid = target.GetAllAcType()[0].Guid; // TODO: 初始化为适当的值
        //    AtaDataObjectList acTypeAtas = new AtaDataObjectList(); // TODO: 初始化为适当的值
        //    var actypeata = new AtaDataObject();
        //    actypeata.Guid = Guid.NewGuid();
        //    actypeata.Ata = "12356";//同一个Ata中此值不能相同，不然添加不成功
        //    actypeata.Description = "test";
        //    acTypeAtas.Add(actypeata);
        //    AtaDataObjectList expected = null; // TODO: 初始化为适当的值
        //    AtaDataObjectList actual;
        //    actual = target.AddAta(acTypeAtas);
        //    Assert.AreNotEqual(0, actual.Count);
        //}

        /// <summary>
        ///AddAcTypeAta 的测试
        ///</summary>
        [TestMethod()]
        public void AddAtaTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            //int acTypeId = target.GetAllAcType()[0].ID.Value; // TODO: 初始化为适当的值
            AtaDataObjectList acTypeAtas = new AtaDataObjectList()
                                           {
                                               new AtaDataObject(){ATA="21",Description="空调"},
                                               new AtaDataObject(){ATA="72",Description="发动机"},
                                               new AtaDataObject(){ATA="28",Description="燃油"},
                                               new AtaDataObject(){ATA="29",Description="液压"},
                                               new AtaDataObject(){ATA="71",Description="动力装置"},
                                               new AtaDataObject(){ATA="49",Description="APU"},
                                               new AtaDataObject(){ATA="32",Description="起落架"},
                                               new AtaDataObject(){ATA="21",Description="空调"}
                                           }; // TODO: 初始化为适当的值

            //for (int i = 1; i < 11; i++)
            //{
            //    var actypeata = new AtaDataObject();
            //    actypeata.Guid = Guid.NewGuid();
            //    actypeata.Ata = "12"+i.ToString();//同一个AcType中此值不能相同，不然添加不成功
            //    actypeata.Description = "test";
            //    var childata = new AtaDataObject();
            //    childata.Guid = Guid.NewGuid();
            //    childata.Ata = "123"+i.ToString();
            //    actypeata.ChildAtas.Add(childata);
            //    acTypeAtas.Add(actypeata);
            //}
            //childata.ParentAta = actypeata;
            
            AtaDataObjectList expected = null; // TODO: 初始化为适当的值
            AtaDataObjectList actual;
            actual = target.AddAta(acTypeAtas);
            Assert.AreNotEqual(0, actual.Count);
        }

        /// <summary>
        ///AddAcModelByGuid 的测试
        ///</summary>
        [TestMethod()]
        public void AddAcModelByGuidTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            Guid acTypeGuid = target.GetAllAcType()[0].Guid; // TODO: 初始化为适当的值
            AcModelDataObjectList acModels = new AcModelDataObjectList(); // TODO: 初始化为适当的值
            var acmodel = new AcModelDataObject();
            acmodel.Guid = Guid.NewGuid();
            acmodel.Description = "test";
            acmodel.Name = "testmodelGuid";//此值不能相同，不然添加不成功
            acModels.Add(acmodel);
            AcModelDataObjectList expected = null; // TODO: 初始化为适当的值
            AcModelDataObjectList actual;
            actual = target.AddAcModelByGuid(acTypeGuid, acModels);
            Assert.AreNotEqual(0, actual.Count);
        }

        /// <summary>
        ///AddAcModel 的测试
        ///</summary>
        [TestMethod()]
        public void AddAcModelTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            int acTypeId = target.GetAllAcType()[0].ID.Value; // TODO: 初始化为适当的值
            AcModelDataObjectList acModels = new AcModelDataObjectList(); // TODO: 初始化为适当的值
            var acmodel = new AcModelDataObject();
            acmodel.Guid = Guid.NewGuid();
            acmodel.Description = "test";
            acmodel.Name = "testmodelID";//此值不能相同，不然添加不成功
            acModels.Add(acmodel);
            AcModelDataObjectList expected = null; // TODO: 初始化为适当的值
            AcModelDataObjectList actual;
            actual = target.AddAcModel(acTypeId, acModels);
            Assert.AreNotEqual(0, actual.Count);
        }

        /// <summary>
        ///AddAcConfigByGuid 的测试
        ///</summary>
        [TestMethod()]
        public void AddAcConfigByGuidTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            Guid acTypeGuid = target.GetAllAcType()[0].Guid; // TODO: 初始化为适当的值
            Guid acModelGuid = target.GetAllAcType()[0].Acmodels[0].Guid; // TODO: 初始化为适当的值
            AcConfigDataObjectList acConfigs = new AcConfigDataObjectList(); // TODO: 初始化为适当的值
            var acconfig = new AcConfigDataObject();
            acconfig.Guid = Guid.NewGuid();
            acconfig.BEW = 10000;
            acconfig.BW = 100000;
            acconfig.BWF = 10000;
            acconfig.BWI = 10000;
            acconfig.Description = "test";
            acconfig.MCC = 10000;
            acconfig.MLW = 10000;
            acconfig.MMFW = 10000;
            acconfig.MTOW = 10000;
            acconfig.MTW = 10000;
            acconfig.MZFW = 10000;
            acconfig.Name = "testacconfigGuid";//此值不能相同，不然添加不成功
            acConfigs.Add(acconfig);
            AcConfigDataObjectList expected = null; // TODO: 初始化为适当的值
            AcConfigDataObjectList actual;
            actual = target.AddAcConfigByGuid(acTypeGuid, acModelGuid, acConfigs);
            Assert.AreNotEqual(0, actual.Count);
        }

        /// <summary>
        ///AddAcConfig 的测试
        ///</summary>
        [TestMethod()]
        public void AddAcConfigTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            int acTypeId = target.GetAllAcType()[0].ID.Value; // TODO: 初始化为适当的值
            int acmodelId = target.GetAllAcType()[0].Acmodels[0].ID.Value; // TODO: 初始化为适当的值
            AcConfigDataObjectList acConfigs = new AcConfigDataObjectList(); // TODO: 初始化为适当的值
            var acconfig = new AcConfigDataObject();
            acconfig.Guid = Guid.NewGuid();
            acconfig.BEW = 10000;
            acconfig.BW = 100000;
            acconfig.BWF = 10000;
            acconfig.BWI = 10000;
            acconfig.Description = "test";
            acconfig.MCC = 10000;
            acconfig.MLW = 10000;
            acconfig.MMFW = 10000;
            acconfig.MTOW = 10000;
            acconfig.MTW = 10000;
            acconfig.MZFW = 10000;
            acconfig.Name = "testacconfigID";//此值不能相同，不然添加不成功
            acConfigs.Add(acconfig);
            AcConfigDataObjectList expected = null; // TODO: 初始化为适当的值
            AcConfigDataObjectList actual;
            actual = target.AddAcConfig(acTypeId, acmodelId, acConfigs);
            Assert.AreNotEqual(0, actual.Count);
        }

        /// <summary>
        ///GetAcModelByName 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcModelByNameTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            string acTypeName = "testNames7"; // TODO: 初始化为适当的值
            string acModelName = "testmodel71"; // TODO: 初始化为适当的值
            AcModelDataObject expected = null; // TODO: 初始化为适当的值
            AcModelDataObject actual;
            actual = target.GetAcModelByName(acTypeName, acModelName);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetAcRegByAc 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcRegByAcTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            string regNumber = "11111"; // TODO: 初始化为适当的值
            AcRegDataObject expected = null; // TODO: 初始化为适当的值
            AcRegDataObject actual;
            actual = target.GetAcRegByRegNumber(regNumber);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetActypeByAcType 的测试
        ///</summary>
        [TestMethod()]
        public void GetActypeByAcTypeTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            string acTypeName = "testNames7"; // TODO: 初始化为适当的值
            AcTypeDataObject expected = null; // TODO: 初始化为适当的值
            AcTypeDataObject actual;
            actual = target.GetActypeByName(acTypeName);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetAcConfigByName 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcConfigByNameTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            string acTypeName = "testNames7"; // TODO: 初始化为适当的值
            string acModelName = "testmodel71"; // TODO: 初始化为适当的值
            string acConfigName = "acconfig715"; // TODO: 初始化为适当的值
            AcConfigDataObject expected = null; // TODO: 初始化为适当的值
            AcConfigDataObject actual;
            actual = target.GetAcConfigByName(acTypeName, acModelName, acConfigName);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetAcConfigByRegNumber 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcConfigByRegNumberTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            string regNumber = "11111"; // TODO: 初始化为适当的值
            AcConfigDataObject expected = null; // TODO: 初始化为适当的值
            AcConfigDataObject actual;
            actual = target.GetAcConfigByRegNumber(regNumber);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetAcTypeByRegNumber 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcTypeByRegNumberTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            string regNumber = "11111"; // TODO: 初始化为适当的值
            AcTypeDataObject expected = null; // TODO: 初始化为适当的值
            AcTypeDataObject actual;
            actual = target.GetAcTypeByRegNumber(regNumber);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetAcModelByRegNumber 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcModelByRegNumberTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            string regNumber = "11111"; // TODO: 初始化为适当的值
            AcModelDataObject expected = null; // TODO: 初始化为适当的值
            AcModelDataObject actual;
            actual = target.GetAcModelByRegNumber(regNumber);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetAllAcConfig 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllAcConfigTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            AcConfigDataObjectList expected = null; // TODO: 初始化为适当的值
            AcConfigDataObjectList actual;
            actual = target.GetAllAcConfig();
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetAllAcModel 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllAcModelTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            AcModelDataObjectList expected = null; // TODO: 初始化为适当的值
            AcModelDataObjectList actual;
            actual = target.GetAllAcModel();
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetAllAcRegInfo 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllAcRegInfoTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            AcRegDtoList expected = null; // TODO: 初始化为适当的值
            AcRegDtoList actual;
            actual = target.GetAllAcRegInfo();
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetAllAcTypeInfo 的测试
        ///</summary>
        [TestMethod()]
        public void GetAllAcTypeInfoTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            AcTypeDtoList expected = null; // TODO: 初始化为适当的值
            AcTypeDtoList actual;
            actual = target.GetAllAcTypeInfo();
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///GetAcregLicensesByRegNumber 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcregLicensesByRegNumberTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            string regNumber = "11111"; // TODO: 初始化为适当的值
            AcregLicenseDataObjectList expected = null; // TODO: 初始化为适当的值
            AcregLicenseDataObjectList actual;
            actual = target.GetAcregLicensesByRegNumber(regNumber);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///DeleteAcConfigByDto 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteAcConfigByDtoTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            AcConfigDtoList acConfigDtos = new AcConfigDtoList(); // TODO: 初始化为适当的值
            target.DeleteAcConfigByDto(acConfigDtos);
        }

        /// <summary>
        ///DeleteAcModelByDto 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteAcModelByDtoTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            AcModelDtoList acModelDtos = new AcModelDtoList(); // TODO: 初始化为适当的值
            target.DeleteAcModelByDto(acModelDtos);
        }

        /// <summary>
        ///GetAcConfigDtoByRegNumber 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcConfigDtoByRegNumberTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            string regNumber = "11111"; // TODO: 初始化为适当的值
            AcConfigDto expected = null; // TODO: 初始化为适当的值
            AcConfigDto actual;
            actual = target.GetAcConfigDtoByRegNumber(regNumber);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CommitAcTypes 的测试
        ///</summary>
        [TestMethod()]
        public void CommitAcTypesTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            AcTypeResultData acTypeData = new AcTypeResultData()
                                          {
                                              DeletedCollection = new List<string>() { "6" },
                                              AddedCollection = new AcTypeDataObjectList()
                                                                {
                                                                    new AcTypeDataObject(){Guid=Guid.NewGuid(),Manufacturer="BY",Name="a1",Description="DCBA",
                                                                    Acmodels=new AcModelDataObjectList()
                                                                             {
                                                                                 new AcModelDataObject(){Guid=Guid.NewGuid(),Name="a11",Description="BB",AcTypeGuid=Guid.NewGuid(),
                                                                                 AcConfigs=new AcConfigDataObjectList()
                                                                                           {
                                                                                               new AcConfigDataObject(){Guid=Guid.NewGuid(),Name="TT"}
                                                                                           }}
                                                                             }}
                                                                },
                                              ModefiedCollection = new AcTypeDataObjectList()
                                                                   {
                                                                       new AcTypeDataObject(){ID=3,Name="b1",Acmodels=new AcModelDataObjectList()
                                                                                                                      {
                                                                                                                          new AcModelDataObject(){ID=3,Name="c1",Description="AAAA",AcConfigs=
                                                                                                                          new AcConfigDataObjectList()
                                                                                                                          {
                                                                                                                              new AcConfigDataObject(){ID=5,Description="c11",Name="BBB"}
                                                                                                                          }}
                                                                                                                      }}
                                                                   } 
                                          }; // TODO: 初始化为适当的值
            AcTypeResultData expected = null; // TODO: 初始化为适当的值
            AcTypeResultData actual;
            actual = target.CommitAcTypes(acTypeData);
            Assert.AreEqual(false, actual.IsSaved);
        }

        /// <summary>
        ///CommitAcCategorys 的测试
        ///</summary>
        [TestMethod()]
        public void CommitAcCategorysTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            AcCategoryResultData acCategoryData = new AcCategoryResultData()
                                                  {
                                                      //AddedCollection = new AcCategoryDataObjectList()
                                                      //                  {
                                                      //                      new AcCategoryDataObject()
                                                      //                      {
                                                      //                          Guid=Guid.NewGuid(),Level="20",Regional="高级"
                                                      //                      }
                                                      //                  },
                                                      DeletedCollection = new List<string>() { "5", "4" },
                                                      ModefiedCollection = new AcCategoryDataObjectList()
                                                                           {
                                                                               new AcCategoryDataObject()
                                                                               {
                                                                                   Guid=new Guid("4D65CFED-0DFF-4C05-AA3E-73EA974D6815"),
                                                                                   Level="30",
                                                                                   ID=3,
                                                                                   Regional="bbaa"
                                                                               }
                                                                           }
                                                  }; // TODO: 初始化为适当的值
            AcCategoryResultData expected = null; // TODO: 初始化为适当的值
            AcCategoryResultData actual;
            actual = target.CommitAcCategorys(acCategoryData);
            Assert.AreEqual(true, actual.IsSaved);
        }

        /// <summary>
        ///CommitAcRegs 的测试
        ///</summary>
        [TestMethod()]
        public void CommitAcRegsTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            AcRegResultData acRegData = new AcRegResultData()
                                        {
                                            AddedCollection=new AcRegDataObjectList(),
                                            DeletedCollection = new List<string>() { "1" },
                                            IsSaved=true,
                                            ModefiedCollection=new AcRegDataObjectList()
                                        }; // TODO: 初始化为适当的值
            AcRegResultData expected = null; // TODO: 初始化为适当的值
            AcRegResultData actual;
            actual = target.CommitAcRegs(acRegData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CommitAtas 的测试
        ///</summary>
        [TestMethod()]
        public void CommitAtasTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            AtaResultData ataData = new AtaResultData()
                                   {
                                       AddedCollection = new AtaDataObjectList()
                                                         {
                                                             new AtaDataObject(){ID=320362,ParentID=4,Description="2222",ATA="3432"},
                                                             new AtaDataObject(){ID=390785,ParentID=44,Description="44",ATA="3244"},
                                                             new AtaDataObject(){ID=450781,ParentID=44,Description="44",ATA="2134"},
                                                         }
                                   }; // TODO: 初始化为适当的值
            AtaResultData expected = null; // TODO: 初始化为适当的值
            AtaResultData actual;
            actual = target.CommitAtas(ataData);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///CommitLicenseTypes 的测试
        ///</summary>
        [TestMethod()]
        public void CommitLicenseTypesTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            LicenseTypeResultData licenseTypeData = null; // TODO: 初始化为适当的值
            LicenseTypeResultData expected = null; // TODO: 初始化为适当的值
            LicenseTypeResultData actual;
            actual = target.CommitLicenseTypes(licenseTypeData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }



        /// <summary>
        ///CommitLicenseTypes 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateItemsTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值


            var actype = target.GetAllAcType().First();
            var acmodel = actype.Acmodels.First();
            
            var srcConfig = new AcConfig();
            List<AcConfig> list = new List<AcConfig>()
                                  {
                                      new AcConfig() {}
                                  };
           


            LicenseTypeResultData licenseTypeData = null; // TODO: 初始化为适当的值
            LicenseTypeResultData expected = null; // TODO: 初始化为适当的值
            LicenseTypeResultData actual;
            actual = target.CommitLicenseTypes(licenseTypeData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAcCategoryWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcCategoryWithPaginationTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            Pagination pagination = new Pagination()
                                    {
                                        PageNumber=1,PageSize=3,SortOrder=SortOrder.Ascending
                                    }; // TODO: 初始化为适当的值
            AcCategoryWithPagination expected = null; // TODO: 初始化为适当的值
            AcCategoryWithPagination actual;
            actual = target.GetAcCategoryWithPagination(pagination);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAcRegWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcRegWithPaginationTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            Pagination pagination = new Pagination()
            {
                PageNumber = 1,
                PageSize = 3,
                SortOrder = SortOrder.Ascending
            }; // TODO: 初始化为适当的值
            AcRegWithPagination expected = null; // TODO: 初始化为适当的值
            AcRegWithPagination actual;
            actual = target.GetAcRegWithPagination(pagination);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAcTypeWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GetAcTypeWithPaginationTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            Pagination pagination = new Pagination()
            {
                PageNumber = 1,
                PageSize = 3,
                SortOrder = SortOrder.Ascending
            }; // TODO: 初始化为适当的值
            AcTypeWithPagination expected = null; // TODO: 初始化为适当的值
            AcTypeWithPagination actual;
            actual = target.GetAcTypeWithPagination(pagination);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetAtaWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GetAtaWithPaginationTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            Pagination pagination = new Pagination()
            {
                PageNumber = 1,
                PageSize = 3,
                SortOrder = SortOrder.Ascending
            }; // TODO: 初始化为适当的值
            AtaWithPagination expected = null; // TODO: 初始化为适当的值
            AtaWithPagination actual;
            actual = target.GetAtaWithPagination(pagination);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetLicenseTypeWithPagination 的测试
        ///</summary>
        [TestMethod()]
        public void GetLicenseTypeWithPaginationTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            Pagination pagination = new Pagination()
            {
                PageNumber = 1,
                PageSize = 3,
                SortOrder = SortOrder.Ascending
            }; // TODO: 初始化为适当的值
            LicenseTypeWithPagination expected = null; // TODO: 初始化为适当的值
            LicenseTypeWithPagination actual;
            actual = target.GetLicenseTypeWithPagination(pagination);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///ManageAcTypeAta 的测试
        ///</summary>
        [TestMethod()]
        public void ManageAcTypeAtaTest()
        {
            IAircraftService target = CreateIAircraftService(); // TODO: 初始化为适当的值
            var acTypeDtos = target.GetAllAcType();
            var atas = target.GetAllAta().Skip(10).Take(2);
            acTypeDtos.First().Atas.AddRange(atas);
            //foreach (var acTypeDto in acTypeDtos)
            //{
            //    acTypeDto.Atas.Clear();
            //    acTypeDto.Atas.AddRange(atas);
            //}
            AcTypeDataObjectList expected = null; // TODO: 初始化为适当的值
            AcTypeDataObjectList actual;
            actual = target.ManageAcTypeAta(acTypeDtos);
            Assert.AreNotEqual(expected, actual);
        }
    }
}
