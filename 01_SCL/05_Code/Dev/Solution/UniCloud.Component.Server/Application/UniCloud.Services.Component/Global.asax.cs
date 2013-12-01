using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using UniCloud.Application;
using UniCloud.Domain.Events;
using UniCloud.Domain.Events;
using UniCloud.Domain.Repositories.EntityFramework;
using UniCloud.Events.Bus;
using UniCloud.Infrastructure;
using UniCloud.Domain.Model;

namespace UniCloud.Services
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            ApplicationAutoMap.Initialize();
            AcComponentDbContextInitailizer.Initialize();
            IBus bus = ServiceLocator.Instance.GetService<IBus>();
            DomainEventAggregator.Subscribe<CcOrderEvent>(p =>
            {
                CcOrder ccOrder = p.Source as CcOrder;
            });
            log4net.Config.XmlConfigurator.Configure();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}