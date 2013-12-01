#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/19 15:38:43

// 文件名：AcStructureConfiguration
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

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
    public class AcStructureConfiguration : EntityTypeConfiguration<AcStructure>
    {
        public AcStructureConfiguration()
        {
            HasKey(k => k.ID);
            Property(p => p.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            Property(p => p.Actype).HasColumnName("ACTYPE").HasMaxLength(10);
            Property(p => p.Acmodel).HasColumnName("ACMODEL").HasMaxLength(10);
            Property(p => p.ReportNo).HasColumnName("REPORT_NO").HasMaxLength(20);
            Property(p => p.ReportType).HasColumnName("REPORT_TYPE").HasMaxLength(10);
            Property(p => p.Description).HasColumnName("DESCRIPTION").HasMaxLength(1000);
            Property(p => p.IsDefer).HasColumnName("IS_DEFER").HasMaxLength(4);
            Property(p => p.Acreg).HasColumnName("ACREG").HasMaxLength(10);
            Property(p => p.TecAss).HasColumnName("TEC_ASS").HasMaxLength(1000);
            Property(p => p.TreatResult).HasColumnName("TREAT_RESULT").HasMaxLength(1000);
            Property(p => p.Status).HasColumnName("STATUS").HasMaxLength(6);
            Property(p => p.Source).HasColumnName("SOURCE").HasMaxLength(100);
            Property(p => p.Level).HasColumnName("LEVEL").HasMaxLength(10);
            Property(p => p.RepairDeadline).HasColumnName("REPAIR_DEADLINE").HasMaxLength(10);
            Property(p => p.CloseDate).HasColumnName("CLOSE_DATE");
            Property(p => p.ReportDate).HasColumnName("REPORT_DATE");

            ToTable("AC_STRUCTURE", Schema.Name);
        }
    }
}
