using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniCloud.ServiceContracts;
using UniCloud.Infrastructure;
using UniCloud.DataObjects;

namespace UniCloud.Component.Server.UnitTest
{
    [TestClass]
    public class InitData
    {
        internal virtual IPartService CreateIPartService()
        {
            // TODO: 实例化相应的具体类。
            IPartService target = ServiceLocator.Instance.GetService<IPartService>(); ;
            return target;
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            Initializer.Init();
        }

        [TestMethod]
        public void InitSnReg()
        {
            IPartService target = CreateIPartService();
            SnRegDataObjectList snRegs = new SnRegDataObjectList()
                                         {
                                             new SnRegDataObject(){Ac="B-2343",Ata="03",Avail="在役",EngineTli="22k",
                                       InstallDate=DateTime.Now.AddYears(-1),NhSnRegID=null,
                                       Sn="BN0987",PnRegID=1,RootSnRegID=null,Position="机舱",Zone="A1"},
                                       new SnRegDataObject(){Ac="B-2343",Ata="03",Avail="在役",EngineTli="22k",
                                       InstallDate=DateTime.Now.AddYears(-1),NhSnRegID=1,
                                       Sn="BN0987-01",PnRegID=1,RootSnRegID=1,Position="机舱",Zone="A1"},
                                       new SnRegDataObject(){Ac="B-2343",Ata="03",Avail="在役",EngineTli="22k",
                                       InstallDate=DateTime.Now.AddYears(-1),NhSnRegID=2,
                                       Sn="BN0987-02",PnRegID=1,RootSnRegID=1,Position="机舱",Zone="A1"},
                                       new SnRegDataObject(){Ac="B-2343",Ata="03",Avail="在役",EngineTli="22k",
                                       InstallDate=DateTime.Now.AddYears(-1),NhSnRegID=2,
                                       Sn="BN0987-03",PnRegID=1,RootSnRegID=1,Position="机舱",Zone="A1"},
                                       new SnRegDataObject(){Ac="B-2343",Ata="03",Avail="在役",EngineTli="22k",
                                       InstallDate=DateTime.Now.AddYears(-1),NhSnRegID=3,
                                       Sn="BN0987-04",PnRegID=1,RootSnRegID=1,Position="机舱",Zone="A1"},
                                       new SnRegDataObject(){Ac="B-2343",Ata="03",Avail="在役",EngineTli="22k",
                                       InstallDate=DateTime.Now.AddYears(-1),NhSnRegID=3,
                                       Sn="BN0987-05",PnRegID=1,RootSnRegID=1,Position="机舱",Zone="A1"}
                                         };
            target.AddSnReg(snRegs);
        }
    }
}
