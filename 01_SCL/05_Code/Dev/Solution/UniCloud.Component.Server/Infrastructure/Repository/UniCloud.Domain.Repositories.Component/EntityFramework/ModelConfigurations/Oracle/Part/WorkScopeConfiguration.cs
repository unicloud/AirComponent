using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Model;

namespace UniCloud.Domain.Repositories.EntityFramework.ModelConfigurations.Oracle
{
    public class WorkScopeConfiguration : EntityTypeConfiguration<WorkScope>
    {
        public WorkScopeConfiguration()
        {
            HasKey(w => w.ID);
            Property(w => w.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(w => w.Description).HasColumnName("DESCRIPTION").HasMaxLength(20);
            Property(w => w.Scope).HasColumnName("SCOPE").HasMaxLength(2);
            Property(w => w.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(10);
            Property(w => w.Type).HasColumnName("TYPE").HasMaxLength(1);

            ToTable("WORK_SCOPE", Schema.Name);
        }
    }
}
