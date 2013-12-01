#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/8/21 10:40:47
* 文件名：CcOrderConfiguration
* 版本：V1.0.0
*
* 修改者： 时间： 
* 修改说明：
* ========================================================================
*/
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
    public class CcOrderConfiguration : EntityTypeConfiguration<CcOrder>
    {
        public CcOrderConfiguration()
        {
            HasKey(k => k.ID);
            Property(p => p.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.OrderNo).HasColumnName("ORDERNO").HasMaxLength(20);
            Property(p => p.Cctype).HasColumnName("CCTYPE").HasMaxLength(12);
            Property(p => p.AcReg).HasColumnName("AC_REG").HasMaxLength(6);
            Property(p => p.SwapAcreg).HasColumnName("SWAP_ACREG").HasMaxLength(6);
            Property(p => p.RemReason).HasColumnName("REM_REASON").HasMaxLength(100);
            Property(p => p.WoNo).HasColumnName("WONO").HasMaxLength(20);
            Property(p => p.WoItem).HasColumnName("WO_ITEM").HasMaxLength(2);
            Property(p => p.WoType).HasColumnName("WO_TYPE").HasMaxLength(4);
            Property(p => p.UpdateDate).HasColumnName("UPDATE_DATE");
            Property(p => p.UpdateBy).HasColumnName("UPDATEBY").HasMaxLength(20);
            Property(p => p.State).HasColumnName("STATE").HasMaxLength(10);
            Property(p => p.OperatDate).HasColumnName("OPERATDATE");
            Property(p => p.Operator).HasColumnName("OPERATOR").HasMaxLength(20);
            Property(p => p.PnRegID).HasColumnName("PN_REGID");
            Property(p => p.SnRegID).HasColumnName("SN_REGID");
            
            //配置关系
            HasMany(p => p.Ccins).WithRequired().HasForeignKey(c => c.CcOrderID);
            HasMany(p => p.Ccouts).WithRequired().HasForeignKey(c => c.CcOrderID);

            ToTable("CC_ORDER", Schema.Name);
        }
    }
}

