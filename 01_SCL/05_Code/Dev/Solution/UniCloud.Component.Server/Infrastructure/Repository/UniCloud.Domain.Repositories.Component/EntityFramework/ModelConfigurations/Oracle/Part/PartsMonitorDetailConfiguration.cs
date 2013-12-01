#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/8/21 10:43:08
* 文件名：PartsMonitorDetailConfiguration
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
    public class PartsMonitorDetailConfiguration : EntityTypeConfiguration<PartsMonitorDetail>
    {
        public PartsMonitorDetailConfiguration()
        {
            HasKey(k => k.ID);
            Property(p => p.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.ExpireDate).HasColumnName("EXPIRE_DATE").HasColumnType("datetime2");
            Property(p => p.Ieam).HasColumnName("IEAM").HasMaxLength(2);
            Property(p => p.Interval).HasColumnName("INTERVAL");
            Property(p => p.ItemNo).HasColumnName("ITEM_NO").HasMaxLength(20);
            Property(p => p.PartsMonitorID).HasColumnName("PART_MONITOR_ID");
            Property(p => p.PnRegID).HasColumnName("PN_REG_ID");
            Property(p => p.Remain).HasColumnName("Remain").HasPrecision(7, 2);
            Property(p => p.SnRegID).HasColumnName("SN_REG_ID");
            Property(p => p.Unit).HasColumnName("UNIT").HasMaxLength(4);
            Property(p => p.Used).HasColumnName("USED").HasPrecision(7, 2);
            Property(p => p.Utiliza).HasColumnName("UTILIZA").HasPrecision(4, 2);
            Property(p => p.Workscope).HasColumnName("WORKSCOPE").HasMaxLength(4);    

            ToTable("PARTS_MONITOR_DETAIL", Schema.Name);
        }
    }
}
