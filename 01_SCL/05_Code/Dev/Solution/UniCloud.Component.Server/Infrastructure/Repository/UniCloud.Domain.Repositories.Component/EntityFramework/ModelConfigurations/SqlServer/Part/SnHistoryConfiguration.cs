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
    public class SnHistoryConfiguration : EntityTypeConfiguration<SnHistory>
    {
        public SnHistoryConfiguration()
        {
            HasKey(s => s.ID);
            Property(s => s.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(s => s.Active).HasColumnName("ACTIVE").HasMaxLength(12);
            Property(s => s.ActiveDate).HasColumnName("ACTIVE_DATE").HasColumnType("datetime2");
            Property(s => s.Source).HasColumnName("SOURCES").HasMaxLength(20);
            Property(s => s.Ata).HasColumnName("ATA").HasMaxLength(8);
            Property(s => s.Position).HasColumnName("POSITION").HasMaxLength(20);
            Property(s => s.Note).HasColumnName("NOTES").HasMaxLength(200);
            Property(s => s.Orderno).HasColumnName("ORDERNO").HasMaxLength(20);
            Property(s => s.SnRegID).HasColumnName("SN_REGID");            
            Property(s => s.NhSnRegID).HasColumnName("NH_SN_REGID");
            Property(s => s.RootSnRegID).HasColumnName("ROOT_SN_REGID");           
            HasMany(s => s.SnHistoryUnits).WithRequired().HasForeignKey(s => s.SnHistoryID);            
            Ignore(s => s.SnReg);
            Ignore(s => s.NhSnReg);
            ToTable("SN_HISTORY", Schema.Name);
        }
    }
}
