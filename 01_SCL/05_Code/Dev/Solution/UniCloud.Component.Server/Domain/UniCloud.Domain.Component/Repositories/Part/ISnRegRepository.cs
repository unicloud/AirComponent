using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Model;

namespace UniCloud.Domain.Repositories
{
   /// <summary>
   /// 表示用于SnReg聚合根的仓储接口。
   /// </summary>
   public interface ISnRegRepository: IRepository<SnReg>
   {
      /// <summary>
      /// 实现对SnReg的增删改。
      /// 需要添加的SnReg对象集合
      /// 需要删除的SnReg的ID集合
      /// 需要更新的SnReg对象集合
      /// <returns>执行后的更改结果</returns>
      /// </summary>
      void CommitSnReg(List<SnReg> addSnRegs, IEnumerable<string> deleteIds, List<SnReg> updateSnRegs);
   }
}
