#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/8/21 10:49:27
* 文件名：OilHistoryConfiguration
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
    public class OilHistoryConfiguration : EntityTypeConfiguration<OilHistory>
    {
        public OilHistoryConfiguration()
        {
            HasKey(k => k.ID);
            Property(p => p.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            Property(p => p.AcReg).HasColumnName("AC_REG").HasMaxLength(6);
            Property(p => p.Msn).HasColumnName("MSN").HasMaxLength(6);
            Property(p => p.FlightDate).HasColumnName("FL_DATE").HasColumnType("datetime2");
            Property(p => p.FlLogno).HasColumnName("FL_LOGNO").HasMaxLength(6);
            Property(p => p.FlLegno).HasColumnName("FL_LEGNO").HasMaxLength(6);
            Property(p => p.UpliftDer).HasColumnName("UPLIFT_DER");
            Property(p => p.UpliftArr).HasColumnName("UPLIFT_ARR");
            Property(p => p.Pn).HasColumnName("PN").HasMaxLength(20);
            Property(p => p.Sn).HasColumnName("SN").HasMaxLength(20);
            Property(p => p.InstalDate).HasColumnName("INSTAL_DATE").HasMaxLength(10);
            Property(p => p.Ata).HasColumnName("ATA").HasMaxLength(8);
            Property(p => p.Zone).HasColumnName("ZONE").HasMaxLength(4);
            Property(p => p.Position).HasColumnName("POSITION").HasMaxLength(8);
            Property(p => p.Tsn).HasColumnName("TSN");
            Property(p => p.Csn).HasColumnName("CSN");
            Property(p => p.Fh).HasColumnName("FH");
            Property(p => p.Cy).HasColumnName("CY");
            Property(p => p.UpdateDate).HasColumnName("UPDATE_DATE").HasColumnType("datetime2");
            Property(p => p.Notes).HasColumnName("NOTES").HasMaxLength(20);

            ToTable("OIL_HISTORY", Schema.Name);
        }
    }
}

