﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Model;

namespace UniCloud.Domain.Repositories
{
   /// <summary>
   /// 表示用于WfHistory聚合根的仓储接口。
   /// </summary>
   public interface IWfHistoryRepository: IRepository<WfHistory>
   {
      /// <summary>
      /// 实现对WfHistory的增删改。
      /// 需要添加的WfHistory对象集合
      /// 需要删除的WfHistory的ID集合
      /// 需要更新的WfHistory对象集合
      /// <returns>执行后的更改结果</returns>
      /// </summary>
      void CommitWfHistory(List<WfHistory> addWfHistorys, IEnumerable<string> deleteIds, List<WfHistory> updateWfHistorys);
   }
}
