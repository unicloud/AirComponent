#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/8/21 10:48:46
* 文件名：ScnMainConfiguration
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
    public class ScnMainConfiguration : EntityTypeConfiguration<ScnMain>
    {
        public ScnMainConfiguration()
        {
            HasKey(k => k.ID);
            Property(p => p.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.ScnNo).HasColumnName("SCNNO").HasMaxLength(20);
            Property(p => p.AcTypeID).HasColumnName("AC_TYPEID");
            Property(p => p.AcTypeGuid).HasColumnName("AC_TYPE_GUID");
            Property(p => p.AcModelID).HasColumnName("AC_MODELID");
            Property(p => p.AcModelGuid).HasColumnName("AC_MODEL_GUID");
            Property(p => p.Version).HasColumnName("VERSION").HasMaxLength(2);
            Property(p => p.State).HasColumnName("STATE").HasMaxLength(2);
            Property(p => p.Description).HasColumnName("DESCRIPTION").HasMaxLength(2000);
            Property(p => p.ScnType).HasColumnName("SCNTYPE").HasMaxLength(4);
            Property(p => p.CloseSituation).HasColumnName("CLOSESITUATION");
            Property(p => p.ColseTime).HasColumnName("CLOSETIME").HasColumnType("datetime2");
            Property(p => p.CreateUser).HasColumnName("CREATEUSER").HasMaxLength(10);
            Property(p => p.CreateTime).HasColumnName("CREATETIME").HasColumnType("datetime2");
            Property(p => p.ScnTitle).HasColumnName("SCNTITLE").HasMaxLength(50);
            Property(p => p.ModName).HasColumnName("MOD_NAME").HasMaxLength(20);
            Property(p => p.Amount).HasColumnName("AMOUNT").HasPrecision(18, 4);
            Property(p => p.DocumentID).HasColumnName("DOCUMENTID");
            Property(p => p.Ata).HasColumnName("ATA").HasMaxLength(8);
            Property(p => p.MoneyOnMsn).HasColumnName("MONEY_ON_MSN").HasMaxLength(10);
            Property(p => p.Organization).HasColumnName("ORGANIZAITON").HasMaxLength(50);
            Property(p => p.VerifyStatus).HasColumnName("VERIFY_STATUS").HasMaxLength(100);

            //配置关系
            HasMany(p => p.ScnAcorders).WithRequired().HasForeignKey(c => c.ScnMainID);
            HasMany(p => p.ScnItems).WithRequired().HasForeignKey(c => c.ScnMainID);
            //HasMany(p => p.WfHistorys).WithRequired().HasForeignKey(w => w.ScnMainID);
            
            ToTable("SCN_MAIN", Schema.Name);
        }
    }
}
