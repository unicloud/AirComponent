using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Application;
using UniCloud.Domain.Events;
using UniCloud.Domain.Model;
using UniCloud.Events.Bus;
using UniCloud.Infrastructure;

namespace UniCloud.Component.Server.UnitTest
{
    public class Initializer
    {
        public static void Init()
        {
            ApplicationAutoMap.Initialize();
            IBus bus = ServiceLocator.Instance.GetService<IBus>();
            DomainEventAggregator.Subscribe<CcOrderEvent>(p =>
            {
                CcOrder ccOrder = p.Source as CcOrder;
            });
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
