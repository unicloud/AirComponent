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
    public class SnHistoryUnitConfiguration : EntityTypeConfiguration<SnHistoryUnit>
    {
        public SnHistoryUnitConfiguration()
        {
            HasKey(s => s.ID);
            Property(s => s.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(s => s.Unit).HasColumnName("UNIT");
            Property(s => s.SnHistoryID).HasColumnName("SN_HISTORYID");
            Property(s => s.USN).HasColumnName("USN");
            Property(s => s.USO).HasColumnName("USO");
            Property(s => s.USR).HasColumnName("USR");
            Property(s => s.USI).HasColumnName("USI");

            ToTable("SN_HISTORY_UNIT", Schema.Name);
        }
    }
}
