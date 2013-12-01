using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;
using UniCloud.Query;
using System.Collections.Generic;
using System.IO;

namespace UniCloud.Component.Server.UnitTest
{
    
    
    /// <summary>
    ///这是 IMajorEventServiceTest 的测试类，旨在
    ///包含所有 IMajorEventServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class IMajorEventServiceTest
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


        internal virtual IMajorEventService CreateIMajorEventService()
        {
            // TODO: 实例化相应的具体类。
            IMajorEventService target = ServiceLocator.Instance.GetService<IMajorEventService>();
            return target;
        }

        internal virtual IMajorEventQuery CreateIMajorEventQuery()
        {
            // TODO: 实例化相应的具体类。
            IMajorEventQuery target = ServiceLocator.Instance.GetService<IMajorEventQuery>();
            return target;
        }

         [TestMethod()]
        public void CommitMajorEvent()
        {
            DocService.DocumentServiceClient client = new DocService.DocumentServiceClient();
            FileStream stream = new FileStream("D:\\工作会议纪要（第2期）20130221.pdf",FileMode.Open);
            DocService.StandardDocumentDataObject doc = new DocService.StandardDocumentDataObject();
            doc.DocumentFileStream = new byte[stream.Length];
            stream.Read(doc.DocumentFileStream, 0, (int)stream.Length);
            var aa= client.AddContractDTO(doc);
        }

        /// <summary>
        ///CommitMajorEvents 的测试
        ///</summary>
        [TestMethod()]
        public void CommitMajorEventsTest()
        {
            IMajorEventService target = CreateIMajorEventService(); // TODO: 初始化为适当的值

            IMajorEventQuery query = CreateIMajorEventQuery();
            var major = query.GetMajorEventByID(11);
            List<string> idlist = new List<string>();
            major.Ac = "B-2134";

            FileStream stream = new FileStream("D:\\机队资源规划_会议纪要_20131010PM.doc", FileMode.Open);
            StandardDocumentDataObject sdoc = new StandardDocumentDataObject();
            sdoc.DocumentFileStream = new byte[stream.Length];
            stream.Read(sdoc.DocumentFileStream, 0, (int)stream.Length);

            AttactDocumentDataObject doc = new AttactDocumentDataObject()
                                           {
                                               FileName = "AA",
                                               Document = sdoc
                                           };

            major.AttactDocuments.Add(doc);
            MajorEventResultData majorEventData = new MajorEventResultData()
                                                  {
                                                      //AddedCollection = new MajorEventDataObjectList()
                                                      //                  {
                                                      //                      new MajorEventDataObject()
                                                      //                      {
                                                      //                          Ac = "B-2223",
                                                      //                          Description = "aaaaa",
                                                      //                          ID = 1,
                                                      //                          CreateDate = DateTime.Now,
                                                      //                          CloseDate = DateTime.Now,
                                                      //                          CloseReason = "bbbbb",
                                                      //                          Pos = "2",
                                                      //                          Property = "FHA",
                                                      //                          Sn = "2s122232",
                                                      //                          AttactDocuments=new AttactDocumentDataObjectList()
                                                      //                                          {
                                                      //                                             new AttactDocumentDataObject()
                                                      //                                             {
                                                                                                     
                                                      //                                             }
                                                      //                                          }
                                                      //                      }
                                                      //                  },
                                                      ModefiedCollection = new MajorEventDataObjectList()
                                                                           {
                                                                               major
                                                                           }
                                                  }; // TODO: 初始化为适当的值



            MajorEventResultData expected = null; // TODO: 初始化为适当的值
            MajorEventResultData actual;
            actual = target.CommitMajorEvents(majorEventData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreateMajorEvents 的测试
        ///</summary>
        [TestMethod()]
        public void CreateMajorEventsTest()
        {
            IMajorEventService target = CreateIMajorEventService(); // TODO: 初始化为适当的值
            MajorEventDataObjectList majorEvents = null; // TODO: 初始化为适当的值
            MajorEventDataObjectList expected = null; // TODO: 初始化为适当的值
            MajorEventDataObjectList actual;
            actual = target.CreateMajorEvents(majorEvents);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteMajorEvents 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteMajorEventsTest()
        {
            IMajorEventService target = CreateIMajorEventService(); // TODO: 初始化为适当的值
            IDList majorEventIDs = null; // TODO: 初始化为适当的值
            IDList expected = null; // TODO: 初始化为适当的值
            IDList actual;
            actual = target.DeleteMajorEvents(majorEventIDs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateMajorEvents 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateMajorEventsTest()
        {
            IMajorEventService target = CreateIMajorEventService(); // TODO: 初始化为适当的值
            MajorEventDataObjectList majorEvents = null; // TODO: 初始化为适当的值
            MajorEventDataObjectList expected = null; // TODO: 初始化为适当的值
            MajorEventDataObjectList actual;
            actual = target.UpdateMajorEvents(majorEvents);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
