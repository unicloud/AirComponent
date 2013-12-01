using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Model;

namespace UniCloud.Domain.Repositories.EntityFramework.ModelConfigurations.SqlServer
{
    public class AcIntUnitUtilizaConfiguration : EntityTypeConfiguration<AcIntUnitUtiliza>
    {
        public AcIntUnitUtilizaConfiguration()
        {
            HasKey(i => i.ID);
            Property(i => i.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(i => i.AcReg).HasColumnName("AC_REG").HasMaxLength(6);
            Property(i => i.Msn).HasColumnName("MSN").HasMaxLength(20);
            Property(i => i.Unit).HasColumnName("UNIT").HasMaxLength(4);
            Property(i => i.Utiliza).HasColumnName("UTILIZA").HasPrecision(3, 1) ;
            Property(i => i.UtilizaRate).HasColumnName("UTILIZA_RATE").HasPrecision(3, 2);
            ToTable("AC_UTILIZA", Schema.Name);
        }
    }
}
