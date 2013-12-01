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
    public class AcregLicenseConfiguration : EntityTypeConfiguration<AcregLicense>
    {
        public AcregLicenseConfiguration()
        {
            HasKey(a => a.ID);
            Property(a => a.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Guid).HasColumnName("GUID");
            Property(a => a.CopyFile).HasColumnName("COPY_FILE");
            Property(a => a.ExpireDate).HasColumnName("EXPIRE_DATE").HasColumnType("datetime2");
            Property(a => a.IssuedDate).HasColumnName("ISSUED_DATE").HasColumnType("datetime2");
            Property(a => a.IssuedFrom).HasColumnName("ISSUED_FROM");
            Property(a => a.Notes).HasColumnName("NOTES");
            Property(a => a.LicenseTypeGuid).HasColumnName("LICENSE_TYPE_GUID");
            Property(a => a.LicenseTypeID).HasColumnName("LICENSE_TYPE_ID");
            Property(a => a.State).HasColumnName("STATE");
            Property(a => a.ValidMonths).HasColumnName("VALID_MONTHS");
            Property(a => a.AcRegID).HasColumnName("AC_Reg_ID");
            Property(a => a.AcRegGuid).HasColumnName("AC_Reg_GUID");
            Property(a => a.DocumentGuid).HasColumnName("DOCUMENTGUID");

            ToTable("ACREG_LICENSE",Schema.Name);
        }
    }
}
