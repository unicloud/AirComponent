using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Model;
using UniCloud.Domain.Model.AcConfiguration;

namespace UniCloud.Domain.Repositories.EntityFramework.ModelConfigurations.SqlServer
{
    public class AtaConfiguration : EntityTypeConfiguration<Ata>
    {
        public AtaConfiguration()
        {
            HasKey(a => a.ID);
            Property(a => a.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.ATA).HasColumnName("ATA");
            Property(a => a.Description).HasColumnName("DESCRIPTION");
            Property(a => a.Guid).HasColumnName("GUID");
            Property(a => a.ParentID).HasColumnName("PARENTID");

            HasMany(a => a.ChildAtas).WithOptional(a => a.ParentAta).HasForeignKey(a => a.ParentID);

            ToTable("ATA", Schema.Name);
        }
    }
}
