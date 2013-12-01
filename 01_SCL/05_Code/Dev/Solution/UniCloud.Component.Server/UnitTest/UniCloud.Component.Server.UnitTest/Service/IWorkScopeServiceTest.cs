using UniCloud.ServiceContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.Component.Server.UnitTest
{
    
    
    /// <summary>
    ///这是 IWorkScopeServiceTest 的测试类，旨在
    ///包含所有 IWorkScopeServiceTest 单元测试
    ///</summary>
    [TestClass()]
    public class IWorkScopeServiceTest
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


        internal virtual IWorkScopeService CreateIWorkScopeService()
        {
            // TODO: 实例化相应的具体类。
            IWorkScopeService target = ServiceLocator.Instance.GetService<IWorkScopeService>();
            return target;
        }

        /// <summary>
        ///CommitWorkScopes 的测试
        ///</summary>
        [TestMethod()]
        public void CommitWorkScopesTest()
        {
            IWorkScopeService target = CreateIWorkScopeService(); // TODO: 初始化为适当的值
            WorkScopeResultData workScopeData = null; // TODO: 初始化为适当的值
            WorkScopeResultData expected = null; // TODO: 初始化为适当的值
            WorkScopeResultData actual;
            actual = target.CommitWorkScopes(workScopeData);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///CreateWorkScopes 的测试
        ///</summary>
        [TestMethod()]
        public void CreateWorkScopesTest()
        {
            IWorkScopeService target = CreateIWorkScopeService(); // TODO: 初始化为适当的值
            WorkScopeDataObjectList workScopes = null; // TODO: 初始化为适当的值
            WorkScopeDataObjectList expected = null; // TODO: 初始化为适当的值
            WorkScopeDataObjectList actual;
            actual = target.CreateWorkScopes(workScopes);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///DeleteWorkScopes 的测试
        ///</summary>
        [TestMethod()]
        public void DeleteWorkScopesTest()
        {
            IWorkScopeService target = CreateIWorkScopeService(); // TODO: 初始化为适当的值
            IDList workScopeIDs = null; // TODO: 初始化为适当的值
            IDList expected = null; // TODO: 初始化为适当的值
            IDList actual;
            actual = target.DeleteWorkScopes(workScopeIDs);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

       

        /// <summary>
        ///UpdateWorkScopes 的测试
        ///</summary>
        [TestMethod()]
        public void UpdateWorkScopesTest()
        {
            IWorkScopeService target = CreateIWorkScopeService(); // TODO: 初始化为适当的值
            WorkScopeDataObjectList workScopes = null; // TODO: 初始化为适当的值
            WorkScopeDataObjectList expected = null; // TODO: 初始化为适当的值
            WorkScopeDataObjectList actual;
            actual = target.UpdateWorkScopes(workScopes);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
