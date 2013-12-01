using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Events.Bus;
using UniCloud.Infrastructure;

namespace UniCloud.Application.AcConfiguration.Test
{
    public class Initializer
    {
        public static void Init()
        {
            //UniCloudDbContextInitailizer.Initialize();
            ApplicationAutoMap.Initialize();
            IBus bus = ServiceLocator.Instance.GetService<IBus>();
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
