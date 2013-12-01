using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;
using UniCloud.Query;
using System.IO;

namespace UniCloud.Component.Server.UnitTest
{


    /// <summary>
    ///这是 ICcOrderServiceTest 的测试类，旨在
    ///包含所有 ICcOrderServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class ICcOrderServiceTest
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


        internal virtual ICcOrderService CreateICcOrderService()
        {
            // TODO: 实例化相应的具体类。
            ICcOrderService target = ServiceLocator.Instance.GetService<ICcOrderService>();
            return target;
        }

        internal virtual ICcOrderQuery CreateICcOrderQuery()
        {
            // TODO: 实例化相应的具体类。
            ICcOrderQuery target = ServiceLocator.Instance.GetService<ICcOrderQuery>();
            return target;
        }

        /// <summary>
        ///CommitCcOrders 的测试
        ///</summary>
        [TestMethod()]
        public void CommitCcOrdersTest()
        {
            var ins = typeof (UniCloud.ServiceContracts.IPartService).GetInterfaces();
            
            var d= ins[0].GetMethods();
            ICcOrderService target = CreateICcOrderService(); // TODO: 初始化为适当的值
            ICcOrderQuery ccOrderQuery = CreateICcOrderQuery();
            //var ccorder = ccOrderQuery.GetEngCcOrderByID(55);
            ////var ccorder = ccOrderQuery.GetCcOrderByID(52);
            //ccorder.Ccins.Add(new CcinDataObject()
            //                  {
            //                      Sn = "BN0987-01",
            //                      Pn = "A2101039620600",EngineTli="22k",Zone="A"
            //                  });
            //ccorder.Ccouts.Add(new CcoutDataObject()
            //{
            //    Sn = "BN0987-01",
            //    Pn = "A2101039620600",
            //    Zone = "A"
            //});

            FileStream stream = new FileStream("D:\\机队资源规划_会议纪要_20131010PM.doc", FileMode.Open);
            StandardDocumentDataObject sdoc = new StandardDocumentDataObject();
            sdoc.DocumentFileStream = new byte[stream.Length];
            stream.Read(sdoc.DocumentFileStream, 0, (int)stream.Length);

            AttactDocumentDataObject doc = new AttactDocumentDataObject()
            {
                FileName = "AA",
                Document = sdoc
            };

            CcOrderResultData ccOrderData = new CcOrderResultData()
                                            {
                                                AddedCollection = new CcOrderDataObjectList()
                                                                  {
                                                                      new CcOrderDataObject(){AcReg="B-2688",Cctype="Remove",OrderNo="CC20131008",State="Edit",
                                                                          RemReason="zhyy",WoItem="1",WoNo="NRC1",WoType="NRC",Sn = "BN0987-01",Pn = "A2101039620600",
                                                                          Ccins=new CcinDataObjectList()
                                                                          {new CcinDataObject(){EngineTli="22K",Zone="09",
                                                                          Ata="03",
                                                                           Sn = "BN037-01",Pn = "A2101039620600",
                                                                           IsNew=true,
                                                                          SnReg=new SnRegDataObject()
                                                                                {
                                                                                    AttactDocuments=new AttactDocumentDataObjectList()
                                                                                                    {
                                                                                                        doc
                                                                                                    }
                                                                                }}
                                                                          },
                                                                          Ccouts=new CcoutDataObjectList()
                                                                          {
                                                                          new CcoutDataObject(){
                                                                          UnScheduled=true,Seq=2, Sn = "BN0987-01",Pn = "A2101039620600",}
                                                                          }
                                                                      }
                                                                  },
                                                //ModefiedCollection = new CcOrderDataObjectList()
                                                //                     {
                                                //                         ccorder
                                                //                     }
                                            }; // TODO: 初始化为适当的值

            CcOrderResultData expected = null; // TODO: 初始化为适当的值
            CcOrderResultData actual;
            actual = target.CommitCcOrders(ccOrderData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreateCcOrders 的测试
        ///</summary>
        [TestMethod()]
        public void CreateCcOrdersTest()
        {
            ICcOrderService target = CreateICcOrderService(); // TODO: 初始化为适当的值
            CcOrderDataObjectList ccOrders = null; // TODO: 初始化为适当的值
            CcOrderDataObjectList expected = null; // TODO: 初始化为适当的值
            CcOrderDataObjectList actual;
            actual = target.CreateCcOrders(ccOrders);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteCcOrders 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteCcOrdersTest()
        {
            ICcOrderService target = CreateICcOrderService(); // TODO: 初始化为适当的值
            IDList ccOrderIDs = null; // TODO: 初始化为适当的值
            IDList expected = null; // TODO: 初始化为适当的值
            IDList actual;
            actual = target.DeleteCcOrders(ccOrderIDs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullCcOrderByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullCcOrderByIDTest()
        {
            ICcOrderService target = CreateICcOrderService(); // TODO: 初始化为适当的值
            int id = 0; // TODO: 初始化为适当的值
            CcOrderDataObject expected = null; // TODO: 初始化为适当的值
            CcOrderDataObject actual;
            actual = target.GetFullCcOrderByID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullCcOrders 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullCcOrdersTest()
        {
            ICcOrderService target = CreateICcOrderService(); // TODO: 初始化为适当的值
            CcOrderDataObjectList expected = null; // TODO: 初始化为适当的值
            CcOrderDataObjectList actual;
            actual = target.GetFullCcOrders();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateCcOrders 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateCcOrdersTest()
        {
            ICcOrderService target = CreateICcOrderService(); // TODO: 初始化为适当的值
            CcOrderDataObjectList ccOrders = null; // TODO: 初始化为适当的值
            CcOrderDataObjectList expected = null; // TODO: 初始化为适当的值
            CcOrderDataObjectList actual;
            actual = target.UpdateCcOrders(ccOrders);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///VerifyCcOrder 的测试
        ///</summary>
        [TestMethod()]
        public void VerifyCcOrderTest()
        {
            ICcOrderService target = CreateICcOrderService(); // TODO: 初始化为适当的值
            int ccOrderId = 0; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.VerifyCcOrder(ccOrderId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///VerifyCcOrder 的测试
        ///</summary>
        [TestMethod()]
        public void VerifyEngCcOrderTest()
        {
            ICcOrderService target = CreateICcOrderService(); // TODO: 初始化为适当的值
            int ccOrderId = 62; // TODO: 初始化为适当的值
            bool expected = false; // TODO: 初始化为适当的值
            bool actual;
            actual = target.VerifyEngCcOrder(ccOrderId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
