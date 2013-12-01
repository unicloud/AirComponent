#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/21 9:41:58

// 文件名：IAttactDocumentRepository
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Collections.Generic;
using UniCloud.Domain.Model;

namespace UniCloud.Domain.Repositories
{
   /// <summary>
   /// 表示用于AttactDocument聚合根的仓储接口。
   /// </summary>
   public interface IAttactDocumentRepository: IRepository<AttactDocument>
   {
      /// <summary>
      /// 实现对AttactDocument的增删改。
      /// 需要添加的AttactDocument对象集合
      /// 需要删除的AttactDocument的ID集合
      /// 需要更新的AttactDocument对象集合
      /// <returns>执行后的更改结果</returns>
      /// </summary>
      void CommitAttactDocument(List<AttactDocument> addAttactDocuments, IEnumerable<string> deleteIds, List<AttactDocument> updateAttactDocuments);
   }
}
