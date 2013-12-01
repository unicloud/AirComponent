#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/6 10:51:21

// 文件名：OilAnalysisConfiguration
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
   public class OilAnalysisConfiguration: EntityTypeConfiguration<OilAnalysis>
   {
      public OilAnalysisConfiguration()
      {
         HasKey(k => k.ID);
         Property(p => p.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
         Property(p => p.FlightDate).HasColumnName("FL_DATE").HasColumnType("datetime2");
         Property(p => p.Pn).HasColumnName("PN").HasMaxLength(20);
         Property(p => p.Sn).HasColumnName("SN").HasMaxLength(20);
         Property(p => p.AcReg).HasColumnName("AC_REG").HasMaxLength(6);
         Property(p => p.Msn).HasColumnName("MSN").HasMaxLength(6);
         Property(p => p.Ata).HasColumnName("ATA").HasMaxLength(8);
         Property(p => p.Zone).HasColumnName("ZONE").HasMaxLength(4);
         Property(p => p.Position).HasColumnName("POSITION").HasMaxLength(8);
         Property(p => p.Tqsr).HasColumnName("TQSR").HasPrecision(12, 4);
         Property(p => p.Tsr).HasColumnName("TSR").HasPrecision(12, 4);
         Property(p => p.Notes).HasColumnName("NOTES").HasMaxLength(20);
         Property(p => p.Toc).HasColumnName("TOC").HasPrecision(8, 4);
         Property(p => p.Tocn).HasColumnName("TOCN").HasPrecision(8, 4);
         Property(p => p.Ioc).HasColumnName("IOC").HasPrecision(8, 4);
         Property(p => p.Ioca).HasColumnName("IOCA").HasPrecision(8, 4);
         Property(p => p.Iocn).HasColumnName("IOCN").HasPrecision(8, 4);
         Property(p => p.Aoc3).HasColumnName("AOC3").HasPrecision(8, 4);
         Property(p => p.Aoc7).HasColumnName("AOC7").HasPrecision(8, 4);
         Property(p => p.Aocn).HasColumnName("AOCN").HasPrecision(8, 4);
         Property(p => p.WarnTag).HasColumnName("WARN_TAG").HasMaxLength(100);
         ToTable("OIL_ANLYSIS", Schema.Name);
      }
   }
}
