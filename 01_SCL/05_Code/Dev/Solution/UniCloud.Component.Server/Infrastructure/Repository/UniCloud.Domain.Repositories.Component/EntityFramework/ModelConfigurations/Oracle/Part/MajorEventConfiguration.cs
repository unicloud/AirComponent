#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/16 16:16:39

// 文件名：MajorEventConfiguration
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
    public class MajorEventConfiguration : EntityTypeConfiguration<MajorEvent>
    {
        public MajorEventConfiguration()
        {
            HasKey(k => k.ID);
            Property(p => p.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Ac).HasColumnName("AC").HasMaxLength(6);
            Property(p => p.Pos).HasColumnName("POS").HasMaxLength(3);
            Property(p => p.Sn).HasColumnName("SN").HasMaxLength(20);
            Property(p => p.Description).HasColumnName("DESCRIPTION").HasMaxLength(2000);
            Property(p => p.Property).HasColumnName("PROPERTY").HasMaxLength(10);
            Property(p => p.CloseReason).HasColumnName("CLOSE_REASON").HasMaxLength(1000);
            Property(p => p.CreateDate).HasColumnName("CREATE_DATE");
            Property(p => p.CloseDate).HasColumnName("CLOSE_DATE");

            ToTable("MAJOR_EVENT", Schema.Name);
        }
    }
}
