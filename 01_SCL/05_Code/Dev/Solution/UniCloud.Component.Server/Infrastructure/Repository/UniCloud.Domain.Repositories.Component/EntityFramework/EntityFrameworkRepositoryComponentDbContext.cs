using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Events.Bus;

namespace UniCloud.Domain.Repositories.EntityFramework
{
    public class EntityFrameworkRepositoryComponentDbContext : EntityFrameworkRepositoryContext
    {
        public EntityFrameworkRepositoryComponentDbContext(IBus bus)
            : base(bus)
        {
        }

        public override UniCloudDbContext CreateDbContext()
        {
            return new ComponentDbContext();
        }
    }
}
