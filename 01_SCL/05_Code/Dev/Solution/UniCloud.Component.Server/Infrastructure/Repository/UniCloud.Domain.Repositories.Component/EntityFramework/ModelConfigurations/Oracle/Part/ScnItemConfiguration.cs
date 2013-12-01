#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/8/21 10:47:56
* 文件名：ScnItemConfiguration
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
    public class ScnItemConfiguration : EntityTypeConfiguration<ScnItem>
    {
        public ScnItemConfiguration()
        {
            HasKey(k => k.ID);
            Property(p => p.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.ScnMainID).HasColumnName("SCN_MAINID");
            Property(p => p.ItemNo).HasColumnName("ITEMNO");
            Property(p => p.PnRegID).HasColumnName("PN_REGID");
            Property(p => p.AtaID).HasColumnName("ATAID");
            Property(p => p.AtaGuid).HasColumnName("ATA_GUID").HasColumnType("GUID");
            Property(p => p.Pn).HasColumnName("PN").HasMaxLength(30);
            Property(p => p.Description).HasColumnName("DESCRIPTION").HasMaxLength(100);
            Property(p => p.Vendor).HasColumnName("VENDOR").HasMaxLength(20);
            Property(p => p.Notes).HasColumnName("NOTES").HasMaxLength(100);
            Property(p => p.Qty).HasColumnName("QTY");
            Property(p => p.Price).HasColumnName("PRICE");
            Property(p => p.TotalPrice).HasColumnName("TOTAL_PRICE");
            Property(p => p.Currency).HasColumnName("CURRENCY").HasMaxLength(6);
            
            ToTable("SCN_ITEM", Schema.Name);
        }
    }
}

