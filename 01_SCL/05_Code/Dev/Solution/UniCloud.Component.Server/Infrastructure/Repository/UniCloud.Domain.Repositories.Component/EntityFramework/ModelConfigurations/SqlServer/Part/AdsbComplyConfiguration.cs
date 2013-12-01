#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/18 10:33:25

// 文件名：AdsbComplyConfiguration
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

namespace UniCloud.Domain.Repositories.EntityFramework.ModelConfigurations.SqlServer
{
    public class AdsbComplyConfiguration : EntityTypeConfiguration<AdsbComply>
    {
        public AdsbComplyConfiguration()
        {
            HasKey(k => k.ID);
            Property(p => p.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Actype).HasColumnName("ACTYPE").HasMaxLength(10);
            Property(p => p.FileType).HasColumnName("FILE_TYPE").HasMaxLength(6);
            Property(p => p.FileNo).HasColumnName("FILE_NO").HasMaxLength(20);
            Property(p => p.FileVersion).HasColumnName("FILE_VERSION").HasMaxLength(4);
            Property(p => p.ComplyAc).HasColumnName("COMPLY_AC").HasMaxLength(20);
            Property(p => p.ComplyStatus).HasColumnName("COMPLY_STATUS").HasMaxLength(10);
            Property(p => p.ComplyNotes).HasColumnName("COMPLY_NOTES").HasMaxLength(100);
            Property(p => p.ComplyClose).HasColumnName("COMPLY_CLOSE").HasMaxLength(6);
            Property(p => p.ComFeeNotes).HasColumnName("COM_FEE_NOTES").HasMaxLength(200);
            Property(p => p.ComFee).HasColumnName("COM_FEE").HasPrecision(10,2);
            Property(p => p.ComFeeCurrency).HasColumnName("COM_FEE_CURRENCY").HasMaxLength(8);
            Property(p => p.ComplyDate).HasColumnName("COM_DATE").HasColumnType("datetime2");
            Property(p => p.AdsbID).HasColumnName("ADSB_ID");

            //配置一对多关系
            HasRequired(a => a.Adsb).WithMany().HasForeignKey(a => a.AdsbID);

            ToTable("ADSB_COMPLY", Schema.Name);
        }
    }
}
