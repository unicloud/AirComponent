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
    public class CcpMainConfiguration : EntityTypeConfiguration<CcpMain>
    {
        public CcpMainConfiguration()
        {
            HasKey(c => c.ID);
            Property(c => c.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.AcType).HasColumnName("AC_TYPE").HasMaxLength(6);           
            Property(c => c.Ata).HasColumnName("ATA").HasMaxLength(8);
            Property(c => c.Description).HasColumnName("DESCRIPTION").HasMaxLength(100);
            Property(c => c.IsLife).HasColumnName("IS_LIFE");
            Property(c => c.ItemNo).HasColumnName("ITEMNO").HasMaxLength(20);
            Property(c => c.NhItemNo).HasColumnName("NH_ITEMNO").HasMaxLength(20);
            Property(c => c.State).HasColumnName("STATE").HasMaxLength(6);
            Property(c => c.Updateby).HasColumnName("UPDATEBY").HasMaxLength(30);
            Property(c => c.UpdateTime).HasColumnName("UPDATE_TIME").HasColumnType("datetime2");
            Property(c => c.Version).HasColumnName("VERSION");

            HasMany(c => c.CcpPns).WithRequired().HasForeignKey(c => c.CcpMainID);
            HasMany(c => c.CcpLimits).WithRequired().HasForeignKey(c => c.CcpMainID);

            ToTable("CCP_MAIN", Schema.Name);
        }
    }
}
