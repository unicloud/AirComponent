namespace UniCloud.Domain.Repositories.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using UniCloud.Domain.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<UniCloud.Domain.Repositories.EntityFramework.ComponentDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(UniCloud.Domain.Repositories.EntityFramework.ComponentDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            
            //增加Snreg测试数据
            context.SnRegs.AddOrUpdate(p => p.ID,
                                       new SnReg(){Ac="B-2343",Ata="03",Avail="在役",EngineTli="22k",
                                       InstallDate=DateTime.Now.AddYears(-1),NhSnRegID=null,
                                       Sn="BN0987",PnRegID=1,RootSnRegID=null,Position="机舱",Zone="A1"},
                                       new SnReg(){Ac="B-2343",Ata="03",Avail="在役",EngineTli="22k",
                                       InstallDate=DateTime.Now.AddYears(-1),NhSnRegID=1,
                                       Sn="BN0987-01",PnRegID=1,RootSnRegID=1,Position="机舱",Zone="A1"},
                                       new SnReg(){Ac="B-2343",Ata="03",Avail="在役",EngineTli="22k",
                                       InstallDate=DateTime.Now.AddYears(-1),NhSnRegID=2,
                                       Sn="BN0987-02",PnRegID=1,RootSnRegID=1,Position="机舱",Zone="A1"},
                                       new SnReg(){Ac="B-2343",Ata="03",Avail="在役",EngineTli="22k",
                                       InstallDate=DateTime.Now.AddYears(-1),NhSnRegID=2,
                                       Sn="BN0987-03",PnRegID=1,RootSnRegID=1,Position="机舱",Zone="A1"},
                                       new SnReg(){Ac="B-2343",Ata="03",Avail="在役",EngineTli="22k",
                                       InstallDate=DateTime.Now.AddYears(-1),NhSnRegID=3,
                                       Sn="BN0987-04",PnRegID=1,RootSnRegID=1,Position="机舱",Zone="A1"},
                                       new SnReg(){Ac="B-2343",Ata="03",Avail="在役",EngineTli="22k",
                                       InstallDate=DateTime.Now.AddYears(-1),NhSnRegID=3,
                                       Sn="BN0987-05",PnRegID=1,RootSnRegID=1,Position="机舱",Zone="A1"});
        }
    }
}
