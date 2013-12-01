#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/13 10:03:05

// 文件名：AirBusMSCNConfiguration
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using UniCloud.Domain.Model;

namespace UniCloud.Domain.Repositories.EntityFramework.ModelConfigurations.Oracle
{
    public class AirBusMSCNConfiguration : EntityTypeConfiguration<AirBusMSCN>
    {
        public AirBusMSCNConfiguration()
        {
            HasKey(k => k.ID);
            Property(p => p.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.MscnNo).HasColumnName("MSCN_NO").HasMaxLength(30);
            Property(p => p.MscnTitle).HasColumnName("MSCN_TITLE").HasMaxLength(200);
            Property(p => p.Ata).HasColumnName("ATA").HasMaxLength(10);
            Property(p => p.Mod).HasColumnName("MOD").HasMaxLength(20);
            Property(p => p.Status).HasColumnName("STATUS").HasMaxLength(20);
            Property(p => p.Msn).HasColumnName("MSN").HasMaxLength(20);
            Property(p => p.Fleet).HasColumnName("FLEET").HasMaxLength(20);

            ToTable("AIRBUS_MSCN", Schema.Name);
        }
    }
}
