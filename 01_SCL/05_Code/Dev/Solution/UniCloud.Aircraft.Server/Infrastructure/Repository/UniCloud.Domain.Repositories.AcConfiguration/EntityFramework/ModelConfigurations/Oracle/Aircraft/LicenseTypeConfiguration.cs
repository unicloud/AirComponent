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
    public class LicenseTypeConfiguration : EntityTypeConfiguration<LicenseType>
    {
        public LicenseTypeConfiguration()
        {
            HasKey(l => l.ID);
            Property(l => l.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(l => l.Guid).HasColumnName("GUID").HasColumnType("GUID");
            Property(l => l.Description).HasColumnName("DESCRIPTION");
            Property(l => l.Type).HasColumnName("TYPE");
            Property(l => l.HasFile).HasColumnName("HAS_FILE").HasColumnType("odp_internal_use_type");

            //HasMany(l => l.AcregLicenses).WithRequired(a => a.LicenseType).HasForeignKey(a => a.LicenseTypeID);

            ToTable("LICENSE_TYPE",Schema.Name);
        }
    }
}
