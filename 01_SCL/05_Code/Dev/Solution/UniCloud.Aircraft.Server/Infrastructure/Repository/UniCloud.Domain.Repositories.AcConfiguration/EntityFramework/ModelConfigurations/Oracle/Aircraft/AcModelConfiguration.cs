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
    public class AcModelConfiguration : EntityTypeConfiguration<AcModel>
    {
        public AcModelConfiguration()
        {
            HasKey(a => a.ID);
            Property(a => a.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Guid).HasColumnName("GUID").HasColumnType("GUID");
            Property(a => a.Name).HasColumnName("NAME").HasMaxLength(10);
            Property(a => a.AcTypeGuid).HasColumnName("AC_TYPE_GUID").HasColumnType("GUID");
            Property(a => a.AcTypeID).HasColumnName("AC_TYPE_ID");
            Property(a => a.Description).HasColumnName("DESCRIPTION");

            //HasMany(a => a.AcRegs).WithRequired().HasForeignKey(a => a.AcModelID);
            HasMany(a => a.AcConfigs).WithRequired().HasForeignKey(a => a.AcModelID);

            ToTable("AC_MODEL", Schema.Name);
        }
    }
}
