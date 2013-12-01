using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Model;

namespace UniCloud.Domain.Repositories
{
   /// <summary>
   /// 表示用于WorkScope聚合根的仓储接口。
   /// </summary>
   public interface IWorkScopeRepository: IRepository<WorkScope>
   {
      /// <summary>
      /// 实现对WorkScope的增删改。
      /// 需要添加的WorkScope对象集合
      /// 需要删除的WorkScope的ID集合
      /// 需要更新的WorkScope对象集合
      /// <returns>执行后的更改结果</returns>
      /// </summary>
      void CommitWorkScope(List<WorkScope> addWorkScopes, IEnumerable<string> deleteIds, List<WorkScope> updateWorkScopes);
   }
}
