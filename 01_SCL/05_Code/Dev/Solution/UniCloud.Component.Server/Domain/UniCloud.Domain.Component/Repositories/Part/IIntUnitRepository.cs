using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Model;

namespace UniCloud.Domain.Repositories
{
   /// <summary>
   /// 表示用于IntUnit聚合根的仓储接口。
   /// </summary>
   public interface IIntUnitRepository: IRepository<IntUnit>
   {
      /// <summary>
      /// 实现对IntUnit的增删改。
      /// 需要添加的IntUnit对象集合
      /// 需要删除的IntUnit的ID集合
      /// 需要更新的IntUnit对象集合
      /// <returns>执行后的更改结果</returns>
      /// </summary>
      void CommitIntUnit(List<IntUnit> addIntUnits, IEnumerable<string> deleteIds, List<IntUnit> updateIntUnits);
   }
}
