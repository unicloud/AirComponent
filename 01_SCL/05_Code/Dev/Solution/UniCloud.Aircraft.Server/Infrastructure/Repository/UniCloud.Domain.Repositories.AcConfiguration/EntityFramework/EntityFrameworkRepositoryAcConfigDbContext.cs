using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Events.Bus;

namespace UniCloud.Domain.Repositories.EntityFramework
{
    public class EntityFrameworkRepositoryAcConfigDbContext : EntityFrameworkRepositoryContext
    {
        public EntityFrameworkRepositoryAcConfigDbContext(IBus bus)
            : base(bus)
        {
        }

        public override UniCloudDbContext CreateDbContext()
        {
            return new AcConfigurationDbContext();
        }
    }
}
