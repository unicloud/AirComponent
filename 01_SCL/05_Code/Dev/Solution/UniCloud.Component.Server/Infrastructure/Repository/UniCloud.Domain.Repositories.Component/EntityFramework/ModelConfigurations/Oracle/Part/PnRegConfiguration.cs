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
    public class PnRegConfiguration : EntityTypeConfiguration<PnReg>
    {
        public PnRegConfiguration()
        {
            HasKey(p => p.ID);
            Property(p => p.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Ata).HasColumnName("ATA").HasMaxLength(8);
            Property(p => p.Pn).HasColumnName("PN").HasMaxLength(30);
            Property(p => p.PnClass).HasColumnName("PN_CLASS").HasMaxLength(6);
            Property(p => p.SpecPn).HasColumnName("SPECPN").HasMaxLength(30);
            Property(p => p.State).HasColumnName("STATE").HasMaxLength(2);
            Property(p => p.UpdateTime).HasColumnName("UPDATE_TIME");
            Property(p => p.Updateby).HasColumnName("UPDATEBY").HasMaxLength(30);
            Property(p => p.Vendor).HasColumnName("VENDOR").HasMaxLength(10);
            Property(p => p.IsLife).HasColumnName("ISLIFE").HasColumnType("odp_internal_use_type");
            Property(p => p.Description).HasColumnName("DESCRIPTION").HasMaxLength(100);
            Property(p => p.TrainRate).HasColumnName("TRAIN_RATE");
            Property(p => p.EGTLimit).HasColumnName("EGT_LIMIT");
            Property(p => p.AOC3).HasColumnName("AOC3").HasPrecision(8, 4);
            Property(p => p.AOC7).HasColumnName("AOC7").HasPrecision(8, 4);
            Property(p => p.IOC).HasColumnName("IOC").HasPrecision(8, 4);
            Property(p => p.IOCA).HasColumnName("IOCA").HasPrecision(8, 4);
            
            ToTable("PN_REG", Schema.Name);
        }
    }
}
