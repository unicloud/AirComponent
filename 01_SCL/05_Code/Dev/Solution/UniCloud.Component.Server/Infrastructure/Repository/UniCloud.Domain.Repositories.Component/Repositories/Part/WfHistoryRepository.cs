using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Model;
using UniCloud.Domain.Repositories.EntityFramework;

namespace UniCloud.Domain.Repositories.Repositories
{
    public class WfHistoryRepository : EntityFrameworkIntRepository<WfHistory>, IWfHistoryRepository
    {
        private readonly ComponentDbContext _efContext;

        public WfHistoryRepository(IRepositoryContext context)
            : base(context)
        {
            _efContext = EFContext.Context as ComponentDbContext;
        }
        /// <summary>
        /// 实现对WfHistory的增删改。
        /// 需要添加的WfHistory对象集合
        /// 需要删除的WfHistory的ID集合
        /// 需要更新的WfHistory对象集合
        /// <returns>执行后的更改结果</returns>
        /// </summary>
      public void CommitWfHistory(List<WfHistory> addWfHistorys,  IEnumerable<string> deleteIds,  List<WfHistory> updateWfHistorys)
        {
            AddWfHistorys(addWfHistorys);
            DeleteWfHistorys(deleteIds);
            UpdateWfHistorys(updateWfHistorys);
            _efContext.SaveChanges();
        }

        /// <summary>
        /// 增加WfHistory
        /// </summary>
        /// <param name="addWfHistorys">WfHistory</param>
        private void AddWfHistorys(List<WfHistory> addWfHistorys)
        {
            if (addWfHistorys != null && addWfHistorys.Any())
            {
                addWfHistorys.ForEach(p =>
                {
                    if (string.IsNullOrWhiteSpace(p.AuditNotes))
                        p.AuditTime = DateTime.Now;
                    _efContext.Entry(p).State = EntityState.Added;
                });
            }
        }

        /// <summary>
        /// 删除WfHistory
        /// </summary>
        /// <param name="deleteIds">删除WfHistory</param>
        private void DeleteWfHistorys(IEnumerable<string> deleteIds)
        {
            if (deleteIds != null)
            {
                foreach (var id in deleteIds)
                {
                    var result = GetWfHistoryById(id);
                    if (result != null)
                    {
                        _efContext.Entry(result).State = EntityState.Deleted;
                    }
                }
            }
        }

        /// <summary>
        ///     更新WfHistory
        /// </summary>
        /// <param name="updateWfHistorys">更新的WfHistory</param>
        private void UpdateWfHistorys(List<WfHistory> updateWfHistorys)
        {
            if (updateWfHistorys != null && updateWfHistorys.Any())
            {
                foreach (var updateObj in updateWfHistorys)
                {
                    var obj = GetWfHistoryById(updateObj.ID.ToString());
                    if (obj != null)
                    {
                        _efContext.WfHistorys.Attach(obj);
                        obj.Seq = updateObj.Seq;
                        obj.Auditor = updateObj.Auditor;
                        obj.AuditNotes = updateObj.AuditNotes;
                        obj.Result = updateObj.Result;
                        obj.Department = updateObj.Department;
                        obj.Description = updateObj.Description;
                        if (string.IsNullOrWhiteSpace(updateObj.AuditNotes))
                            obj.AuditTime = DateTime.Now;
                    }
                }
            }
        }

        /// <summary>
        ///     根据WfHistoryID获取WfHistory
        /// </summary>
        /// <param name="id">WfHistory主键</param>
        /// <returns>WfHistory</returns>
        private WfHistory GetWfHistoryById(string id)
        {
            var value = Convert.ToInt32(id);
            return _efContext == null ? null : _efContext.WfHistorys.FirstOrDefault(p => p.ID== value);
        }
    }
}
