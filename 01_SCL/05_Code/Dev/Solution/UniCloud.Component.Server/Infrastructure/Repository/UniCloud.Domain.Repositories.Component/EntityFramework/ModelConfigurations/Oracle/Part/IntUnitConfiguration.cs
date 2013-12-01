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
    public class IntUnitConfiguration : EntityTypeConfiguration<IntUnit>
    {
        public IntUnitConfiguration()
        {
            HasKey(i => i.ID);
            Property(i => i.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(i => i.Descritption).HasColumnName("DESCRITPTION").HasMaxLength(20);
            Property(i => i.ShortName).HasColumnName("SHORT_NAME").HasMaxLength(20);
            Property(i => i.Type).HasColumnName("TYPE").HasMaxLength(1);
            Property(i => i.Unit).HasColumnName("UNIT").HasMaxLength(2);

            ToTable("INT_UNIT", Schema.Name);
        }
    }
}
