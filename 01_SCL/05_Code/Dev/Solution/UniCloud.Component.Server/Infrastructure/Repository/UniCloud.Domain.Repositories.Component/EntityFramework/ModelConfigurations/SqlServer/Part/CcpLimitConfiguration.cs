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
    public class CcpLimitConfiguration : EntityTypeConfiguration<CcpLimit>
    {
        public CcpLimitConfiguration()
        {
            HasKey(c => c.ID);
            Property(c => c.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.CcpMainID).HasColumnName("CCPMAIN_ID");
            Property(c => c.ControlGroup).HasColumnName("CONTROL_GROUP").HasMaxLength(2);
            Property(c => c.ControlNo).HasColumnName("CONTROLNO").HasMaxLength(2);
            Property(c => c.ControlType).HasColumnName("CONTROL_TYPE").HasMaxLength(1);
            Property(c => c.EngineTli).HasColumnName("ENGINE_TLI").HasMaxLength(4);
            Property(c => c.Ieam).HasColumnName("IEAM").HasMaxLength(2);
            Property(c => c.Interval).HasColumnName("INTERVAL");
            Property(c => c.Notes).HasColumnName("NOTES").HasMaxLength(50);
            Property(c => c.PolicyExec).HasColumnName("POLICY_EXEC").HasMaxLength(1);
            Property(c => c.RangeMax).HasColumnName("RANGE_MAX");
            Property(c => c.RangeMin).HasColumnName("RANGE_MIN");
            Property(c => c.RangeType).HasColumnName("RANGE_TYPE").HasMaxLength(2);
            Property(c => c.Source).HasColumnName("SOURCE").HasMaxLength(50);
            Property(c => c.Unit).HasColumnName("UNIT").HasMaxLength(2);
            Property(c => c.WorkScope).HasColumnName("WORK_SCOPE").HasMaxLength(2);
            Property(c => c.WorkScopeID).HasColumnName("WORKSCOPE_ID");            
            HasRequired(c => c.WorkScopeItem).WithMany().HasForeignKey(c=>c.WorkScopeID);
            

            ToTable("CCP_LIMIT", Schema.Name);
        }
    }
}
