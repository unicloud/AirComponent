using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Model;

namespace UniCloud.Domain.Repositories
{
   /// <summary>
   /// 表示用于OilHistory聚合根的仓储接口。
   /// </summary>
   public interface IOilHistoryRepository: IRepository<OilHistory>
   {
      /// <summary>
      /// 实现对OilHistory的增删改。
      /// 需要添加的OilHistory对象集合
      /// 需要删除的OilHistory的ID集合
      /// 需要更新的OilHistory对象集合
      /// <returns>执行后的更改结果</returns>
      /// </summary>
      void CommitOilHistory(List<OilHistory> addOilHistorys, IEnumerable<string> deleteIds, List<OilHistory> updateOilHistorys);
   }
}
