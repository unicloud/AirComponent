using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Model;

namespace UniCloud.Domain.Repositories
{
    public interface ISnHistoryRepository : IRepository<SnHistory>
    {
        void DeleteSnHistory(SnHistory snHistory);

        void DeleteSnHistoryUnit(SnHistory snHistory, IEnumerable<SnHistoryUnit> snHistoryUnits);

        /// <summary>
        /// 实现对SnHistory的增删改。
        /// 需要添加的SnHistory对象集合
        /// 需要删除的SnHistory的ID集合
        /// 需要更新的SnHistory对象集合
        /// <returns>执行后的更改结果</returns>
        /// </summary>
        void CommitSnHistory(List<SnHistory> addSnHistorys, IEnumerable<string> deleteIds, List<SnHistory> updateSnHistorys);

        /// <summary>
        /// 通过SnHistoryId获取相应的SnHistory
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SnHistory GetLastSnHistoryBySnregID(string snregID);

      
    }
}
