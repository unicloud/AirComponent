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
    public class AcregLicenseConfiguration : EntityTypeConfiguration<AcregLicense>
    {
        public AcregLicenseConfiguration()
        {
            HasKey(a => a.ID);
            Property(a => a.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Guid).HasColumnName("GUID").HasColumnType("GUID");
            Property(a => a.CopyFile).HasColumnName("COPY_FILE");
            Property(a => a.ExpireDate).HasColumnName("EXPIRE_DATE");
            Property(a => a.IssuedDate).HasColumnName("ISSUED_DATE");
            Property(a => a.IssuedFrom).HasColumnName("ISSUED_FROM");
            Property(a => a.Notes).HasColumnName("NOTES");
            Property(a => a.LicenseTypeGuid).HasColumnName("LICENSE_TYPE_GUID").HasColumnType("GUID");
            Property(a => a.LicenseTypeID).HasColumnName("LICENSE_TYPE_ID");
            Property(a => a.State).HasColumnName("STATE");
            Property(a => a.ValidMonths).HasColumnName("VALID_MONTHS");
            Property(a => a.AcRegID).HasColumnName("AC_REG_ID");
            Property(a => a.AcRegGuid).HasColumnName("AC_REG_GUID").HasColumnType("GUID");
            Property(a => a.DocumentGuid).HasColumnName("DOCUMENTGUID").HasColumnType("GUID");

            HasRequired(a => a.LicenseType).WithMany().HasForeignKey(a => a.LicenseTypeID);

            ToTable("ACREG_LICENSE",Schema.Name);
        }
    }
}
