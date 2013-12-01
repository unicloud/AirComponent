using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Model;

namespace UniCloud.Domain.Repositories
{
   /// <summary>
   /// 表示用于ScnMain聚合根的仓储接口。
   /// </summary>
   public interface IScnMainRepository: IRepository<ScnMain>
   {
      /// <summary>
      /// 实现对ScnMain的增删改。
      /// 需要添加的ScnMain对象集合
      /// 需要删除的ScnMain的ID集合
      /// 需要更新的ScnMain对象集合
      /// <returns>执行后的更改结果</returns>
      /// </summary>
      void CommitScnMain(List<ScnMain> addScnMains, IEnumerable<string> deleteIds, List<ScnMain> updateScnMains);
   }
}
