#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/18 11:52:26

// 文件名：IAdsbComplyRepository
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
   /// 表示用于AdsbComply聚合根的仓储接口。
   /// </summary>
   public interface IAdsbComplyRepository: IRepository<AdsbComply>
   {
      /// <summary>
      /// 实现对AdsbComply的增删改。
      /// 需要添加的AdsbComply对象集合
      /// 需要删除的AdsbComply的ID集合
      /// 需要更新的AdsbComply对象集合
      /// <returns>执行后的更改结果</returns>
      /// </summary>
      void CommitAdsbComply(List<AdsbComply> addAdsbComplys, IEnumerable<string> deleteIds, List<AdsbComply> updateAdsbComplys);
   }
}
