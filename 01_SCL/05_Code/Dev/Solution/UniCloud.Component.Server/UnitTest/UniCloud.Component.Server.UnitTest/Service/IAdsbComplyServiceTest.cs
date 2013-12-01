using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Component.Server.UnitTest
{
    
    
    /// <summary>
    ///这是 IAdsbComplyServiceTest 的测试类，旨在
    ///包含所有 IAdsbComplyServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class IAdsbComplyServiceTest
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


        internal virtual IAdsbComplyService CreateIAdsbComplyService()
        {
            // TODO: 实例化相应的具体类。
            IAdsbComplyService target = ServiceLocator.Instance.GetService<IAdsbComplyService>();
            return target;
        }

        /// <summary>
        ///CommitAdsbComplys 的测试
        ///</summary>
        [TestMethod()]
        public void CommitAdsbComplysTest()
        {
            IAdsbComplyService target = CreateIAdsbComplyService(); // TODO: 初始化为适当的值
            AdsbComplyResultData adsbComplyData = null; // TODO: 初始化为适当的值
            AdsbComplyResultData expected = null; // TODO: 初始化为适当的值
            AdsbComplyResultData actual;
            actual = target.CommitAdsbComplys(adsbComplyData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreateAdsbComplys 的测试
        ///</summary>
        [TestMethod()]
        public void CreateAdsbComplysTest()
        {
            IAdsbComplyService target = CreateIAdsbComplyService(); // TODO: 初始化为适当的值
            AdsbComplyDataObjectList adsbComplys = new AdsbComplyDataObjectList()
                                                   {
                                                       new AdsbComplyDataObject(){Actype="A300-200",AdsbID=1,ComFee=12,
                                                       ComFeeCurrency="$",ComFeeNotes="AAA",ComplyAc="B-2123",ComplyClose="BBB",
                                                       ComplyDate=DateTime.Now,ComplyNotes="CCC",ComplyStatus="关闭",
                                                       FileNo="NH001",FileType="AD",FileVersion="1"},
                                                       new AdsbComplyDataObject(){Actype="A300-200",AdsbID=1,ComFee=12,
                                                       ComFeeCurrency="$",ComFeeNotes="AAA",ComplyAc="B-2143",ComplyClose="BBB",
                                                       ComplyDate=DateTime.Now,ComplyNotes="CCC",ComplyStatus="关闭",
                                                       FileNo="NH002",FileType="CAD",FileVersion="1"},
                                                       new AdsbComplyDataObject(){Actype="A300-200",AdsbID=1,ComFee=12,
                                                       ComFeeCurrency="$",ComFeeNotes="AAA",ComplyAc="B-2113",ComplyClose="BBB",
                                                       ComplyDate=DateTime.Now,ComplyNotes="CCC",ComplyStatus="关闭",
                                                       FileNo="NH003",FileType="SB",FileVersion="1"},
                                                       new AdsbComplyDataObject(){Actype="A300-200",AdsbID=1,ComFee=12,
                                                       ComFeeCurrency="￥",ComFeeNotes="AAA",ComplyAc="B-2156",ComplyClose="BBB",
                                                       ComplyDate=DateTime.Now,ComplyNotes="CCC",ComplyStatus="关闭",
                                                       FileNo="NH004",FileType="ABD",FileVersion="1"}
                                                   }; // TODO: 初始化为适当的值
            AdsbComplyDataObjectList expected = null; // TODO: 初始化为适当的值
            AdsbComplyDataObjectList actual;
            actual = target.CreateAdsbComplys(adsbComplys);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteAdsbComplys 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteAdsbComplysTest()
        {
            IAdsbComplyService target = CreateIAdsbComplyService(); // TODO: 初始化为适当的值
            IDList adsbComplyIDs = null; // TODO: 初始化为适当的值
            IDList expected = null; // TODO: 初始化为适当的值
            IDList actual;
            actual = target.DeleteAdsbComplys(adsbComplyIDs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdateAdsbComplys 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateAdsbComplysTest()
        {
            IAdsbComplyService target = CreateIAdsbComplyService(); // TODO: 初始化为适当的值
            AdsbComplyDataObjectList adsbComplys = null; // TODO: 初始化为适当的值
            AdsbComplyDataObjectList expected = null; // TODO: 初始化为适当的值
            AdsbComplyDataObjectList actual;
            actual = target.UpdateAdsbComplys(adsbComplys);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
