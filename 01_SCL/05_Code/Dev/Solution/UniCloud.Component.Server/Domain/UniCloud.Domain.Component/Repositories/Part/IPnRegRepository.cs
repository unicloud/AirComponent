using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Model;

namespace UniCloud.Domain.Repositories
{
   /// <summary>
   /// 表示用于PnReg聚合根的仓储接口。
   /// </summary>
   public interface IPnRegRepository: IRepository<PnReg>
   {
      /// <summary>
      /// 实现对PnReg的增删改。
      /// 需要添加的PnReg对象集合
      /// 需要删除的PnReg的ID集合
      /// 需要更新的PnReg对象集合
      /// <returns>执行后的更改结果</returns>
      /// </summary>
      void CommitPnReg(List<PnReg> addPnRegs, IEnumerable<string> deleteIds, List<PnReg> updatePnRegs);
   }
}
