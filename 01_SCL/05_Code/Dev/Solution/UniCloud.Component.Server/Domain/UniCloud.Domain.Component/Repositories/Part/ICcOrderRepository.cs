using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Model;

namespace UniCloud.Domain.Repositories
{
   /// <summary>
   /// 表示用于CcOrder聚合根的仓储接口。
   /// </summary>
   public interface ICcOrderRepository: IRepository<CcOrder>
   {
      /// <summary>
      /// 实现对CcOrder的增删改。
      /// 需要添加的CcOrder对象集合
      /// 需要删除的CcOrder的ID集合
      /// 需要更新的CcOrder对象集合
      /// <returns>执行后的更改结果</returns>
      /// </summary>
      void CommitCcOrder(List<CcOrder> addCcOrders, IEnumerable<string> deleteIds, List<CcOrder> updateCcOrders);
   }
}
