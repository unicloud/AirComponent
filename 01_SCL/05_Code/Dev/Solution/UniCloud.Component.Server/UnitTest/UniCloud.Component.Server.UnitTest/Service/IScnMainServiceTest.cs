using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UniCloud.Component.Server.UnitTest
{
    
    
    /// <summary>
    ///这是 IScnMainServiceTest 的测试类，旨在
    ///包含所有 IScnMainServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class IScnMainServiceTest
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


        internal virtual IScnMainService CreateIScnMainService()
        {
            // TODO: 实例化相应的具体类。
            IScnMainService target = ServiceLocator.Instance.GetService<IScnMainService>();
            return target;
        }

        /// <summary>
        ///CommitScnMains 的测试
        ///</summary>
        [TestMethod()]
        public void CommitScnMainsTest()
        {
            IScnMainService target = CreateIScnMainService(); // TODO: 初始化为适当的值
            ScnMainResultData scnMainData = new ScnMainResultData()
                                            {
                                                AddedCollection = new ObservableCollection<ScnMainDataObject>()
                                                                  {
                                                                        new ScnMainDataObject(){Description="A",AcModelGuid=Guid.NewGuid(),
                                                                             ModName="123",ColseTime=DateTime.Now,ScnTitle="KKKK",
                                                                             //ScnAcorders=new ScnAcorderDataObjectList()
                                                                             //            {
                                                                             //                new ScnAcorderDataObject(){AcOrder="0022",AcOrderItem="2"} 
                                                                             //            },
                                                                         WfHistorys=new WfHistoryDataObjectList()
                                                                                    {
                                                                                        new WfHistoryDataObject() { Department = "技术标准室", Seq = "1", AuditTime = DateTime.Now,Business="scnmain" },
                                                                                        new WfHistoryDataObject() { Department = "机身系统室", Seq = "2", AuditTime = DateTime.Now, Business = "scnmain" },
                                                                                        new WfHistoryDataObject() { Department = "航材计划室", Seq = "3", AuditTime = DateTime.Now, Business = "scnmain" },
                                                                                        new WfHistoryDataObject() { Department = "机务工程部", Seq = "4", AuditTime = DateTime.Now, Business = "scnmain" }
                                                                                    }}
                                                                  }
                                            }; // TODO: 初始化为适当的值
            ScnMainResultData expected = null; // TODO: 初始化为适当的值
            ScnMainResultData actual;
            actual = target.CommitScnMains(scnMainData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreateScnMains 的测试
        ///</summary>
        [TestMethod()]
        public void CreateScnMainsTest()
        {
            IScnMainService target = CreateIScnMainService(); // TODO: 初始化为适当的值
            ScnMainDataObjectList scnMains = null; // TODO: 初始化为适当的值
            ScnMainDataObjectList expected = null; // TODO: 初始化为适当的值
            ScnMainDataObjectList actual;
            actual = target.CreateScnMains(scnMains);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteScnMains 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteScnMainsTest()
        {
            IScnMainService target = CreateIScnMainService(); // TODO: 初始化为适当的值
            IDList scnMainIDs = null; // TODO: 初始化为适当的值
            IDList expected = null; // TODO: 初始化为适当的值
            IDList actual;
            actual = target.DeleteScnMains(scnMainIDs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullScnMainByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullScnMainByIDTest()
        {
            IScnMainService target = CreateIScnMainService(); // TODO: 初始化为适当的值
            int id = 16; // TODO: 初始化为适当的值
            ScnMainDataObject expected = null; // TODO: 初始化为适当的值
            ScnMainDataObject actual;
            actual = target.GetFullScnMainByID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullScnMains 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullScnMainsTest()
        {
            IScnMainService target = CreateIScnMainService(); // TODO: 初始化为适当的值
            ScnMainDataObjectList expected = null; // TODO: 初始化为适当的值
            ScnMainDataObjectList actual;
            actual = target.GetFullScnMains();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateScnMains 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateScnMainsTest()
        {
            IScnMainService target = CreateIScnMainService(); // TODO: 初始化为适当的值
            ScnMainDataObjectList scnMains = null; // TODO: 初始化为适当的值
            ScnMainDataObjectList expected = null; // TODO: 初始化为适当的值
            ScnMainDataObjectList actual;
            actual = target.UpdateScnMains(scnMains);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
