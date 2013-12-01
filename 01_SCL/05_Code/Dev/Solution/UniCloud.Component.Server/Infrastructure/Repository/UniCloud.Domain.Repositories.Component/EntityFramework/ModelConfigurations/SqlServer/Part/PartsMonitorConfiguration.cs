#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/8/21 10:42:33
* 文件名：PartsMonitorConfiguration
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

namespace UniCloud.Domain.Repositories.EntityFramework.ModelConfigurations.SqlServer
{
    public class PartsMonitorConfiguration : EntityTypeConfiguration<PartsMonitor>
    {
        public PartsMonitorConfiguration()
        {
            HasKey(k => k.ID);
            Property(p => p.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.ExpireDate).HasColumnName("EXPIRE_DATE").HasColumnType("datetime2");
            Property(p => p.ItemNo).HasColumnName("ITEM_NO").HasMaxLength(20);
            Property(p => p.NhItemNo).HasColumnName("NH_ITEM_NO").HasMaxLength(20);
            Property(p => p.PnRegID).HasColumnName("PN_REGID");
            Property(p => p.PolicyExec).HasColumnName("POLICY_EXEC").HasMaxLength(2);
            Property(p => p.RemainTime).HasColumnName("REMAIN_TIME").HasMaxLength(40);
            Property(p => p.SnRegID).HasColumnName("SN_REGID");                                 
            Property(p => p.UsedTime).HasColumnName("USED_TIME").HasMaxLength(40);
            Property(p => p.Workscope).HasColumnName("WORKSCOPE").HasMaxLength(4);      
                                
            //配置关系
            HasMany(p => p.PartsMonitorDetails).WithRequired().HasForeignKey(c => c.PartsMonitorID);
            HasRequired(p => p.Snreg).WithMany().HasForeignKey(s => s.SnRegID);
            
            ToTable("PARTS_MONITOR", Schema.Name);
        }
    }
}
