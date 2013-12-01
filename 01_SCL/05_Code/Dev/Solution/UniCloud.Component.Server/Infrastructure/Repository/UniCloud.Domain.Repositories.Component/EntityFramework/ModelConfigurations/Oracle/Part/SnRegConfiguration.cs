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
    public class SnRegConfiguration : EntityTypeConfiguration<SnReg>
    {
        public SnRegConfiguration()
        {
            HasKey(s => s.ID);
            Property(s => s.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(s => s.Ac).HasColumnName("AC").HasMaxLength(6);
            Property(s => s.Ata).HasColumnName("ATA").HasMaxLength(8);
            Property(s => s.Avail).HasColumnName("AVAIL").HasMaxLength(6);
            Property(s => s.InstallDate).HasColumnName("INSTALL_DATE");
            Property(s => s.NhSnRegID).HasColumnName("NH_SN_REGID");
            Property(s => s.RootSnRegID).HasColumnName("ROOT_SN_REGID");
            Property(s => s.Note).HasColumnName("NOTE").HasMaxLength(20);
            Property(s => s.PnRegID).HasColumnName("PN_REGID");
            Property(s => s.Position).HasColumnName("POSITION").HasMaxLength(20);
            Property(s => s.Sn).HasColumnName("SN").HasMaxLength(20);
            Property(s => s.Zone).HasColumnName("ZONE").HasMaxLength(4);
            Property(p => p.EngineTli).HasColumnName("ENGINE_TLI").HasMaxLength(4);

            //2013-10-6 新增
            Property(s => s.RemoveDate).HasColumnName("REMOVE_DATE");
            Property(s => s.RepairDate).HasColumnName("REPAIR_DATE");
            Property(s => s.Owner).HasColumnName("OWNER").HasMaxLength(50);
            Property(s => s.Leaser).HasColumnName("LEASER").HasMaxLength(50);
            Property(s => s.Propertys).HasColumnName("PROPERTYS").HasMaxLength(5);
            Property(s => s.SyncAMASIS).HasColumnName("SYNC_AMASIS").HasMaxLength(2);
            Property(s => s.Egtm).HasColumnName("EGTM").HasPrecision(8,4);

            HasRequired(s => s.PnReg).WithMany().HasForeignKey(s => s.PnRegID);
            HasMany(s => s.EgtMargins).WithRequired().HasForeignKey(e => e.SnRegID);

            ToTable("SN_REG", Schema.Name);
        }
    }
}
