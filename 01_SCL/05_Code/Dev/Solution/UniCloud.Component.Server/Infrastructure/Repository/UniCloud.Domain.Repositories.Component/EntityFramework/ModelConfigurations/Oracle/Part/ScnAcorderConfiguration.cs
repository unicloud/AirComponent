#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/8/21 10:44:06
* 文件名：ScnAcorderConfiguration
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
    public class ScnAcorderConfiguration : EntityTypeConfiguration<ScnAcorder>
    {
        public ScnAcorderConfiguration()
        {
            HasKey(k => k.ID);
            Property(p => p.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.AcOrder).HasColumnName("AC_ORDER").HasMaxLength(20);
            Property(p => p.AcOrderItem).HasColumnName("AC_ORDER_ITEM").HasMaxLength(2);
            Property(p => p.Notes).HasColumnName("NOTES").HasMaxLength(20);
            Property(p => p.ScnMainID).HasColumnName("SCN_MAINID");
            Property(p => p.MSN).HasColumnName("MSN").HasMaxLength(10);
            Property(p => p.Price).HasColumnName("PRICE");
            Property(p => p.CSCNumber).HasColumnName("CSC_NUMBER").HasMaxLength(15);
            
            ToTable("SCN_ACORDER", Schema.Name);
        }
    }
}
