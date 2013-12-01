using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using UniCloud.Application;
using UniCloud.Domain.Repositories.EntityFramework;
using UniCloud.Events.Bus;
using UniCloud.Infrastructure;

namespace UniCloud.Services
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
            ApplicationAutoMap.Initialize();
            AcConfigurationDbContextInitailizer.Initialize();
            IBus bus = ServiceLocator.Instance.GetService<IBus>();
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