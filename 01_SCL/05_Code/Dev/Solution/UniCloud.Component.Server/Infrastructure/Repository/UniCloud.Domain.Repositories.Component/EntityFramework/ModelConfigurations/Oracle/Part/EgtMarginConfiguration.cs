#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/16 11:27:14

// 文件名：EgtMarginConfiguration
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
   public class EgtMarginConfiguration: EntityTypeConfiguration<EgtMargin>
   {
      public EgtMarginConfiguration()
      {
         HasKey(k => k.ID);
         Property(p => p.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
         Property(p => p.PnRegID).HasColumnName("PN_REGID");
         Property(p => p.SnRegID).HasColumnName("SN_REGID");
         Property(p => p.Egtm).HasColumnName("EGTM").HasPrecision(9, 4);
         Property(p => p.Operator).HasColumnName("OPERATOR").HasMaxLength(20);
         Property(p => p.OperateDate).HasColumnName("OPERATE_DATE");
         ToTable("EGT_MARGIN", Schema.Name);
      }
   }
}
