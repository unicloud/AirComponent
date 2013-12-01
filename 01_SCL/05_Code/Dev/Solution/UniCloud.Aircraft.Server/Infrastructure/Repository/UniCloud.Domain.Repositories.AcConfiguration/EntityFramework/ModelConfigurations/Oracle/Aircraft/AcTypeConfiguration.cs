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
    public class AcTypeConfiguration : EntityTypeConfiguration<AcType>
    {
        public AcTypeConfiguration()
        {
            HasKey(a => a.ID);
            Property(a => a.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Guid).HasColumnName("GUID").HasColumnType("GUID");
            Property(a => a.Name).HasColumnName("NAME").HasMaxLength(6);
            Property(a => a.Description).HasColumnName("DESCRIPTION");
            Property(a => a.Manufacturer).HasColumnName("MANUFACTURER");
            Property(a => a.AcCategory).HasColumnName("ACCATEGORY").HasMaxLength(20);

            //HasOptional(a => a.AcCategory).WithMany().HasForeignKey(a => a.AcCategory);
            //HasMany(a => a.AcRegs).WithRequired().HasForeignKey(a => a.AcTypeID);
            HasMany(a => a.Acmodels).WithRequired().HasForeignKey(a => a.AcTypeID);
            HasMany(a => a.Atas).WithMany().Map(m =>
            {
                m.ToTable("AC_ATA", Schema.Name);
                m.MapLeftKey("AC_TYPEID");
                m.MapRightKey("ATAID");
            });

            ToTable("AC_TYPE", Schema.Name);
        }
    }
}
