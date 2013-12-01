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
    public class WfHistoryConfiguration : EntityTypeConfiguration<WfHistory>
    {
        public WfHistoryConfiguration()
        {
            HasKey(w => w.ID);
            Property(w => w.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(w => w.AuditNotes).HasColumnName("AUDIT_NOTES").HasMaxLength(1000);
            Property(w => w.AuditTime).HasColumnName("AUDIT_TIME").HasColumnType("datetime2");
            Property(w => w.Auditor).HasColumnName("AUDITOR").HasMaxLength(30);
            Property(w => w.Business).HasColumnName("BUSINESS").HasMaxLength(20);
            Property(w => w.BusinessID).HasColumnName("BUSINESSID");
            Property(w => w.Result).HasColumnName("RESULT").HasMaxLength(6);
            Property(w => w.Seq).HasColumnName("SEQ").HasMaxLength(6);
            Property(w => w.Department).HasColumnName("DEPARTMENT").HasMaxLength(10);
            Property(w => w.Description).HasColumnName("DESCRIPTION").HasMaxLength(1000);
            //Property(w => w.ScnMainID).HasColumnName("SCN_MAINID");

            ToTable("WF_HISTORY", Schema.Name);
        }
    }
}
