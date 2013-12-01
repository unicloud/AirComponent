using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Model;

namespace UniCloud.Domain.Repositories
{
    public interface ICcpMainRepository :IRepository<CcpMain>
    {
        void DeleteCcpMain(CcpMain ccpMain);

        void DeleteCcpLimit(CcpMain ccpMain, IEnumerable<CcpLimit> ccpLimits);

        void DeleteCcpPn(CcpMain ccpMain, IEnumerable<CcpPn> ccpPns);

        /// <summary>
        /// 实现对CcpMain的增删改。
        /// 需要添加的CcpMain对象集合
        /// 需要删除的CcpMain的ID集合
        /// 需要更新的CcpMain对象集合
        /// <returns>执行后的更改结果</returns>
        /// </summary>
        void CommitCcpMain(List<CcpMain> addCcpMains, IEnumerable<string> deleteIds, List<CcpMain> updateCcpMains);
    }
}
