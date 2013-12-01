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
    public class AcCategoryConfiguration : EntityTypeConfiguration<AcCategory>
    {
        public AcCategoryConfiguration()
        {
            HasKey(a => a.ID);
            Property(a => a.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(a => a.Guid).HasColumnName("GUID");
            Property(a => a.Level).HasColumnName("LEVEL");
            Property(a => a.Regional).HasColumnName("REGIONAL");

            ToTable("AC_CATEGORY", Schema.Name);
        }
    }
}
