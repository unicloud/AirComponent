#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/16 16:16:39

// 文件名：IMajorEventRepository
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
   /// 表示用于MajorEvent聚合根的仓储接口。
   /// </summary>
   public interface IMajorEventRepository: IRepository<MajorEvent>
   {
      /// <summary>
      /// 实现对MajorEvent的增删改。
      /// 需要添加的MajorEvent对象集合
      /// 需要删除的MajorEvent的ID集合
      /// 需要更新的MajorEvent对象集合
      /// <returns>执行后的更改结果</returns>
      /// </summary>
      void CommitMajorEvent(List<MajorEvent> addMajorEvents, IEnumerable<string> deleteIds, List<MajorEvent> updateMajorEvents);
   }
}
