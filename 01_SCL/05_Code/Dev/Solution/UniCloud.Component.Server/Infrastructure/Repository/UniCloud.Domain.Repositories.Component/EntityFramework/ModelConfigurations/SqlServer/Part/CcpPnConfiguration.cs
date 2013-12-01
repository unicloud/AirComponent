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
    public class CcpPnConfiguration : EntityTypeConfiguration<CcpPn>
    {
        public CcpPnConfiguration()
        {
            HasKey(c => c.ID);
            Property(c => c.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Acmodel).HasColumnName("AC_MODEL").HasMaxLength(10);
            Property(c => c.Acconfig).HasColumnName("AC_CONFIG").HasMaxLength(10);
            Property(c => c.AcRegs).HasColumnName("AC_REGS").HasMaxLength(50);
            Property(c => c.Ieam).HasColumnName("IEAM").HasMaxLength(2);
            Property(c => c.Notes).HasColumnName("NOTES").HasMaxLength(20);
            Property(c => c.Pn).HasColumnName("PN").HasMaxLength(30);
            Property(c => c.Qty).HasColumnName("QTY");
            Property(c => c.Sns).HasColumnName("SNS").HasMaxLength(50);
            Property(c => c.SpecPn).HasColumnName("SPECPN").HasMaxLength(30);
            Property(c => c.PnRegID).HasColumnName("PN_REGID");
            Property(c => c.CcpMainID).HasColumnName("CCPMAIN_ID");

            ToTable("CCPPN", Schema.Name);
        }
    }
}
