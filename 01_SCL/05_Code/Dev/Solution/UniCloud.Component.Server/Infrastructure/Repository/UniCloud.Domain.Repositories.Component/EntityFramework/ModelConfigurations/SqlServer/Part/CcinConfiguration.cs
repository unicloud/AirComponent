#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/8/21 10:39:03
* 文件名：CcinConfiguration
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
    public class CcinConfiguration : EntityTypeConfiguration<Ccin>
    {
        public CcinConfiguration()
        {
            HasKey(k => k.ID);
            Property(p => p.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.PnRegID).HasColumnName("PN_REGID");
            Property(p => p.SnRegID).HasColumnName("SN_REGID");
            Property(p => p.Ata).HasColumnName("ATA").HasMaxLength(8);
            Property(p => p.Propertys).HasColumnName("PROPERTYS").HasMaxLength(8);
            Property(p => p.Position).HasColumnName("POSITION").HasMaxLength(10);
            Property(p => p.Zone).HasColumnName("ZONE").HasMaxLength(4);
            Property(p => p.Seq).HasColumnName("SEQ");
            Property(p => p.RootSnRegID).HasColumnName("ROOT_SN_REGID");
            Property(p => p.NhSnRegID).HasColumnName("NH_SN_REGID");
            Property(p => p.CcOrderID).HasColumnName("CC_ORDERID");
            Property(c => c.EngineTli).HasColumnName("ENGINE_TLI").HasMaxLength(4);
            Property(p => p.FhInterval).HasColumnName("FH_INTERVAL");
            Property(p => p.CyInterval).HasColumnName("CY_INTERVAL");
            Property(p => p.Tsn).HasColumnName("TSN").HasPrecision(10, 2);
            Property(p => p.Tso).HasColumnName("TSO").HasPrecision(10, 2);
            Property(p => p.Tsr).HasColumnName("TSR").HasPrecision(10, 2);
            Property(p => p.Csn).HasColumnName("CSN").HasPrecision(10, 2);
            Property(p => p.Cso).HasColumnName("CSO").HasPrecision(10, 2);
            Property(p => p.Csr).HasColumnName("CSR").HasPrecision(10, 2);

            ToTable("CCIN", Schema.Name);
        }
    }
}
