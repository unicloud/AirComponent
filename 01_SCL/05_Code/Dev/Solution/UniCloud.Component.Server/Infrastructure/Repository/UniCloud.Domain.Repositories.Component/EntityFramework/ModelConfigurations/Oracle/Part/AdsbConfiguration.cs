#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/18 10:33:25

// 文件名：AdsbConfiguration
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
    public class AdsbConfiguration : EntityTypeConfiguration<Adsb>
    {
        public AdsbConfiguration()
        {
            HasKey(k => k.ID);
            Property(p => p.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Actype).HasColumnName("ACTYPE").HasMaxLength(10);
            Property(p => p.FileType).HasColumnName("FILE_TYPE").HasMaxLength(6);
            Property(p => p.FileNo).HasColumnName("FILE_NO").HasMaxLength(20);
            Property(p => p.FileVersion).HasColumnName("FILE_VERSION").HasMaxLength(4);
            Property(p => p.FileTitle).HasColumnName("FILE_TITLE").HasMaxLength(500);
            Property(p => p.FromFile).HasColumnName("FROM_FILE").HasMaxLength(20);
            Property(p => p.Content).HasColumnName("CONTENT").HasMaxLength(1000);
            Property(p => p.ReceiveDate).HasColumnName("RECEIVE_DATE");

            ToTable("ADSB", Schema.Name);
        }
    }
}
