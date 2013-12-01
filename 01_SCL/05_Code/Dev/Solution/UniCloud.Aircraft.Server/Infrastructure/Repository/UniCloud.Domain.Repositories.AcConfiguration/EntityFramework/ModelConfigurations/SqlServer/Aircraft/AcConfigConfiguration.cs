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
    public class AcConfigConfiguration : EntityTypeConfiguration<AcConfig>
    {
        public AcConfigConfiguration()
        {
            HasKey(a => a.ID);
            Property(a => a.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Guid).HasColumnName("GUID");
            Property(a => a.Name).HasColumnName("NAME").HasMaxLength(10);
            Property(a => a.Description).HasColumnName("DESCRIPTION");
            Property(a => a.AcModelGuid).HasColumnName("AC_MODEL_GUID");
            Property(a => a.AcModelID).HasColumnName("AC_MODEL_ID");
            Property(a => a.BEW).HasColumnName("BEW");
            Property(a => a.BW).HasColumnName("BW");
            Property(a => a.BWF).HasColumnName("BWF");
            Property(a => a.BWI).HasColumnName("BWI");
            Property(a => a.MCC).HasColumnName("MCC");
            Property(a => a.MLW).HasColumnName("MLW");
            Property(a => a.MMFW).HasColumnName("MMFW");
            Property(a => a.MTOW).HasColumnName("MTOW");
            Property(a => a.MTW).HasColumnName("MTW");
            Property(a => a.MZFW).HasColumnName("MZFW");

            //HasMany(a => a.AcRegs).WithRequired().HasForeignKey(a => a.AcConfigID);

            ToTable("AC_CONFIG", Schema.Name);
        }
    }
}
