using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

namespace UniCloud.Component.Server.UnitTest
{
    /// <summary>
    ///这是 IPnRegServiceTest 的测试类，旨在
    ///包含所有 IPnRegServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class IPnRegServiceTest
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


        internal virtual IPnRegService CreateIPnRegService()
        {
            // TODO: 实例化相应的具体类。
            IPnRegService target = ServiceLocator.Instance.GetService<IPnRegService>();
            return target;
        }

        /// <summary>
        ///CommitPnRegs 的测试
        ///</summary>
        [TestMethod()]
        public void CommitPnRegsTest()
        {

            IPnRegService target = CreateIPnRegService(); // TODO: 初始化为适当的值
            PnRegResultData pnRegData = null; // TODO: 初始化为适当的值
            PnRegResultData expected = null; // TODO: 初始化为适当的值
            PnRegResultData actual;
            actual = target.CommitPnRegs(pnRegData);
            Assert.AreEqual(expected, actual);
           
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreatePnRegs 的测试
        ///</summary>
        [TestMethod()]
        public void CreatePnRegsTest()
        {
            IPnRegService target = CreateIPnRegService(); // TODO: 初始化为适当的值
            PnRegDataObjectList pnRegs = new PnRegDataObjectList()
                                         {
                                             new PnRegDataObject(){Ata="01",Pn="SX22342",TrainRate=12,IsLife=true,Description="AA"}
                                         }; // TODO: 初始化为适当的值
            PnRegDataObjectList expected = null; // TODO: 初始化为适当的值
            PnRegDataObjectList actual;
            actual = target.CreatePnRegs(pnRegs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeletePnRegs 的测试
        ///</summary>
        [TestMethod()]
        public void DeletePnRegsTest()
        {
            string ac = "2373,CSC23G7300836M1F,Communications - Cabin                 Intercommunication Data System (CIDS)  - Introduce 66A software standard.,AC,54866,X,X";
            string strs=@"3420,CSC34G2020209M1F,""Navigation - Integrated Standby        Indication System (ISIS) - THALES      AVIONICS, PN C16221VA01"",AC,55952,X,X";
            //解析标题有逗号(,)的情况
            var temp = strs.Split('"').ToList();
            List<string> list = new List<string>();
            if (temp.Count == 3)
            {
                list.AddRange(temp[0].Split(',').Where(a=>a.Length>0));
                list.Add(temp[1]);
                list.AddRange(temp[2].Split(',').Where(a=>a.Length>0));
            }
            var list2 = strs.Split(',').ToList();
            var asb1 = ac.Split('"').ToList();
            var list1 = ac.Split(',').ToList();


            IPnRegService target = CreateIPnRegService(); // TODO: 初始化为适当的值
            IDList pnRegIDs = null; // TODO: 初始化为适当的值
            IDList expected = null; // TODO: 初始化为适当的值
            IDList actual;
            actual = target.DeletePnRegs(pnRegIDs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullPnRegByID 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullPnRegByIDTest()
        {
            IPnRegService target = CreateIPnRegService(); // TODO: 初始化为适当的值
            int id = 0; // TODO: 初始化为适当的值
            PnRegDataObject expected = null; // TODO: 初始化为适当的值
            PnRegDataObject actual;
            actual = target.GetFullPnRegByID(id);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///GetFullPnRegs 的测试
        ///</summary>
        [TestMethod()]
        public void GetFullPnRegsTest()
        {
            IPnRegService target = CreateIPnRegService(); // TODO: 初始化为适当的值
            PnRegDataObjectList expected = null; // TODO: 初始化为适当的值
            PnRegDataObjectList actual;
            actual = target.GetFullPnRegs();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///UpdatePnRegs 的测试
        ///</summary>
        [TestMethod()]
        public void UpdatePnRegsTest()
        {
            IPnRegService target = CreateIPnRegService(); // TODO: 初始化为适当的值
            PnRegDataObjectList pnRegs = null; // TODO: 初始化为适当的值
            PnRegDataObjectList expected = null; // TODO: 初始化为适当的值
            PnRegDataObjectList actual;
            actual = target.UpdatePnRegs(pnRegs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
