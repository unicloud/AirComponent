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
    public class WorkScopeRepository : EntityFrameworkIntRepository<WorkScope>, IWorkScopeRepository
    {
        private readonly ComponentDbContext _efContext;

        public WorkScopeRepository(IRepositoryContext context)
            : base(context)
        {
            _efContext = EFContext.Context as ComponentDbContext;
        }
        /// <summary>
        /// 实现对WorkScope的增删改。
        /// 需要添加的WorkScope对象集合
        /// 需要删除的WorkScope的ID集合
        /// 需要更新的WorkScope对象集合
        /// <returns>执行后的更改结果</returns>
        /// </summary>
      public void CommitWorkScope(List<WorkScope> addWorkScopes,  IEnumerable<string> deleteIds,  List<WorkScope> updateWorkScopes)
        {
            AddWorkScopes(addWorkScopes);
            DeleteWorkScopes(deleteIds);
            UpdateWorkScopes(updateWorkScopes);
            _efContext.SaveChanges();
        }

        /// <summary>
        /// 增加WorkScope
        /// </summary>
        /// <param name="addWorkScopes">WorkScope</param>
        private void AddWorkScopes(List<WorkScope> addWorkScopes)
        {
            if (addWorkScopes != null && addWorkScopes.Any())
            {
                addWorkScopes.ForEach(p =>
                {
                    _efContext.Entry(p).State = EntityState.Added;
                });
            }
        }

        /// <summary>
        /// 删除WorkScope
        /// </summary>
        /// <param name="deleteIds">删除WorkScope</param>
        private void DeleteWorkScopes(IEnumerable<string> deleteIds)
        {
            if (deleteIds != null)
            {
                foreach (var id in deleteIds)
                {
                    var result = GetWorkScopeById(id);
                    if (result != null)
                    {
                        _efContext.Entry(result).State = EntityState.Deleted;
                    }
                }
            }
        }

        /// <summary>
        ///     更新WorkScope
        /// </summary>
        /// <param name="updateWorkScopes">更新的WorkScope</param>
        private void UpdateWorkScopes(List<WorkScope> updateWorkScopes)
        {
            if (updateWorkScopes != null && updateWorkScopes.Any())
            {
                foreach (var updateObj in updateWorkScopes)
                {
                    var obj = GetWorkScopeById(updateObj.ID.ToString());
                    if (obj != null)
                    {
                        _efContext.WorkScopes.Attach(obj);
                        obj.Scope = updateObj.Scope;
                        obj.Description = updateObj.Description;
                        obj.ShortName = updateObj.ShortName;
                        obj.Type = updateObj.Type;
                    }
                }
            }
        }

        /// <summary>
        ///     根据WorkScopeID获取WorkScope
        /// </summary>
        /// <param name="id">WorkScope主键</param>
        /// <returns>WorkScope</returns>
        private WorkScope GetWorkScopeById(string id)
        {
            var value = Convert.ToInt32(id);
            return _efContext == null ? null : _efContext.WorkScopes.FirstOrDefault(p => p.ID == value);
        }
    }
}
