#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/19 15:38:44

// 文件名：IAcStructureRepository
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
   /// 表示用于AcStructure聚合根的仓储接口。
   /// </summary>
   public interface IAcStructureRepository: IRepository<AcStructure>
   {
      /// <summary>
      /// 实现对AcStructure的增删改。
      /// 需要添加的AcStructure对象集合
      /// 需要删除的AcStructure的ID集合
      /// 需要更新的AcStructure对象集合
      /// <returns>执行后的更改结果</returns>
      /// </summary>
      void CommitAcStructure(List<AcStructure> addAcStructures, IEnumerable<string> deleteIds, List<AcStructure> updateAcStructures);
   }
}
