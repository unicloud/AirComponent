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
    public interface IAcIntUnitUtilizaRepository : IRepository<AcIntUnitUtiliza>
   {
      /// <summary>
       /// 实现对AcIntUnitUtiliza的增删改。
       /// 需要添加的AcIntUnitUtiliza对象集合
       /// 需要删除的AcIntUnitUtiliza的ID集合
       /// 需要更新的AcIntUnitUtiliza对象集合
      /// <returns>执行后的更改结果</returns>
      /// </summary>
        void CommitAcIntUnitUtiliza(List<AcIntUnitUtiliza> addIntUnits, IEnumerable<string> deleteIds, List<AcIntUnitUtiliza> updateIntUnits);

        /// <summary>
        /// 获取飞机以及相关的利用率
        /// </summary>
        /// <returns></returns>
        List<AcIntUnitUtiliza> GetAcIntUnitUtilizas();
   }
}
