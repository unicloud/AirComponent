#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/16 14:47:48

// 文件名：AttactDocumentConfiguration
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
   public class AttactDocumentConfiguration: EntityTypeConfiguration<AttactDocument>
   {
      public AttactDocumentConfiguration()
      {
         HasKey(k => k.ID);
         Property(p => p.ID).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
         Property(p => p.BusinessID).HasColumnName("BUSINESSID");
         Property(p => p.Business).HasColumnName("BUSINESS").HasMaxLength(20);
         Property(p => p.DocumentID).HasColumnName("DOCUMENTID").HasColumnType("GUID");
         Property(p => p.FileName).HasColumnName("FILE_NAME").HasMaxLength(50);
         Property(p => p.UploadTime).HasColumnName("UPLOAD_TIME");
         Property(p => p.ExtendType).HasColumnName("EXTEND_TYPE").HasMaxLength(10);
         Property(p => p.Uploader).HasColumnName("UPLOADER").HasMaxLength(20);
         Property(p => p.DocumentType).HasColumnName("DOCUMENT_TYPE").HasMaxLength(20);

         ToTable("ATTACT_DOCUMENT", Schema.Name );
      }
   }
}
