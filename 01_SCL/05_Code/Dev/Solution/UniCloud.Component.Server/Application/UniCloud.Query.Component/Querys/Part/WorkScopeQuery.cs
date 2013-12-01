#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/17 23:23:10

// 文件名：WorkScopeQuery
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Linq;
using System.Linq.Expressions;
using UniCloud.DataObjects;
using UniCloud.Domain.Model;
using UniCloud.Domain.Repositories.EntityFramework;

namespace UniCloud.Query
{
   /// <summary>
   /// 表示用于WorkScope的查询接口。
   /// </summary>
   public class WorkScopeQuery: IWorkScopeQuery
   {
      private readonly ComponentDbContext _context;
      
      public WorkScopeQuery(IUniCloudDbContext context)
      {
         _context = context as ComponentDbContext;
      }
      
      #region Query WorkScope
      
      /// <summary>
      /// 获取所有WorkScope
      /// </summary>
      /// <returns>所有的WorkScope。</returns>
      public WorkScopeDataObjectList GetWorkScopes(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter)
      {
         Expression<Func<WorkScope, bool>> source = p => true;
         return GetWorkScopeList(source);
      }
      
      /// <summary>
      /// 获取所有WorkScope分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的WorkScope分页信息。</returns>
      public WorkScopeWithPagination GetWorkScopeWithPagination(Pagination pagination)
      {
         Expression<Func<WorkScope, bool>> wherePredicate = p => true;
         Expression<Func<WorkScope, dynamic>> sortPredicate = t =>t.ID;
         return GetWorkScopePage(wherePredicate,sortPredicate,pagination);
      }
      
      /// <summary>
      /// 通过WorkScopeId获取相应的WorkScope
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
       public WorkScopeDataObject GetWorkScopeByID(int id)
      {
         Expression<Func<WorkScope, bool>> source = p => p.ID == id;
         var result = GetWorkScopeList(source);
         return result == null ? null : result.FirstOrDefault();
      }
      
      #endregion
      
      #region Common Query
      
       private WorkScopeDataObjectList GetWorkScopeList(Expression<Func<WorkScope, bool>> source)
      {
         var queryResult = (_context.WorkScopes.Where(source).Select(t => new WorkScopeDataObject()
            {
               Scope = t.Scope,
               Description = t.Description,
               ShortName = t.ShortName,
               Type = t.Type,
               ID = t.ID,
            })).ToList();
         if (!queryResult.Any()) return new WorkScopeDataObjectList();
         var transferResult = new WorkScopeDataObjectList();
         queryResult.ForEach(transferResult.Add);
         return transferResult;
      }
      
       private WorkScopeWithPagination GetWorkScopePage(Expression<Func<WorkScope, bool>> wherePredicate,
                  Expression<Func<WorkScope, dynamic>> sortPredicate,
                  Pagination pagination)
      {
         Expression<Func<WorkScope,WorkScopeDataObject>> mapper=t=> new WorkScopeDataObject
            {
               Scope = t.Scope,
               Description = t.Description,
               ShortName = t.ShortName,
               Type = t.Type,
               ID = t.ID,
            };
         var WorkScopeResult = _context.LoadPageDataObjects<WorkScope,WorkScopeDataObject>(wherePredicate, sortPredicate, pagination, mapper);
         if(WorkScopeResult==null) return null;
         pagination.TotalPages=WorkScopeResult.TotalPages;
         var WorkScopeWithPagination= new WorkScopeWithPagination
            {
               Pagination=pagination,
               BaseDataObjectList = new BaseDataObjectList<WorkScopeDataObject>()
            };
         foreach (var value in WorkScopeResult.Data)
            {
               WorkScopeWithPagination.BaseDataObjectList.Add(value);
            }
            return WorkScopeWithPagination;
      }
      
      #endregion
      
   }
}
