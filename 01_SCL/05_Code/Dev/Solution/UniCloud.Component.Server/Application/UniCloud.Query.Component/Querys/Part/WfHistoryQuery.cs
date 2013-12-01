#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/17 23:23:10

// 文件名：WfHistoryQuery
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
   /// 表示用于WfHistory的查询接口。
   /// </summary>
   public class WfHistoryQuery: IWfHistoryQuery
   {
      private readonly ComponentDbContext _context;
      
      public WfHistoryQuery(IUniCloudDbContext context)
      {
         _context = context as ComponentDbContext;
      }
      
      #region Query WfHistory
      
      /// <summary>
      /// 获取所有WfHistory
      /// </summary>
      /// <returns>所有的WfHistory。</returns>
      public WfHistoryDataObjectList GetWfHistorys(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter)
      {
         Expression<Func<WfHistory, bool>> source = p => true;
         return GetWfHistoryList(source);
      }
      
      /// <summary>
      /// 获取所有WfHistory分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的WfHistory分页信息。</returns>
      public WfHistoryWithPagination GetWfHistoryWithPagination(Pagination pagination)
      {
         Expression<Func<WfHistory, bool>> wherePredicate = p => true;
         Expression<Func<WfHistory, dynamic>> sortPredicate = t =>t.ID;
         return GetWfHistoryPage(wherePredicate,sortPredicate,pagination);
      }
      
      /// <summary>
      /// 通过WfHistoryId获取相应的WfHistory
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
       public WfHistoryDataObject GetWfHistoryByID(int id)
      {
         Expression<Func<WfHistory, bool>> source = p => p.ID == id;
         var result = GetWfHistoryList(source);
         return result == null ? null : result.FirstOrDefault();
      }
      
      #endregion
      
      #region Common Query
      
       private WfHistoryDataObjectList GetWfHistoryList(Expression<Func<WfHistory, bool>> source)
      {
         var queryResult = (_context.WfHistorys.Where(source).OrderByDescending(o=>o.AuditTime).Select(t => new WfHistoryDataObject()
            {
               Seq = t.Seq,
               Auditor = t.Auditor,
               AuditTime = t.AuditTime,
               AuditNotes = t.AuditNotes,
               Result = t.Result,
               Business = t.Business,
               BusinessID = t.BusinessID,
               Department = t.Department,
               Description = t.Description,
               ID = t.ID,
            })).ToList();
         if (!queryResult.Any()) return new WfHistoryDataObjectList();
         var transferResult = new WfHistoryDataObjectList();
         queryResult.ForEach(transferResult.Add);
         return transferResult;
      }
      
       private WfHistoryWithPagination GetWfHistoryPage(Expression<Func<WfHistory, bool>> wherePredicate,
                  Expression<Func<WfHistory, dynamic>> sortPredicate,
                  Pagination pagination)
      {
         Expression<Func<WfHistory,WfHistoryDataObject>> mapper=t=> new WfHistoryDataObject
            {
               Seq = t.Seq,
               Auditor = t.Auditor,
               AuditTime = t.AuditTime,
               AuditNotes = t.AuditNotes,
               Result = t.Result,
               Business = t.Business,
               BusinessID = t.BusinessID,
               Department = t.Department,
               Description = t.Description,
               ID = t.ID,
            };
         var WfHistoryResult = _context.LoadPageDataObjects<WfHistory,WfHistoryDataObject>(wherePredicate, sortPredicate, pagination, mapper);
         if(WfHistoryResult==null) return null;
         pagination.TotalPages=WfHistoryResult.TotalPages;
         var WfHistoryWithPagination= new WfHistoryWithPagination
            {
               Pagination=pagination,
               BaseDataObjectList = new BaseDataObjectList<WfHistoryDataObject>()
            };
         foreach (var value in WfHistoryResult.Data)
            {
               WfHistoryWithPagination.BaseDataObjectList.Add(value);
            }
            return WfHistoryWithPagination;
      }
      
      #endregion

       #region pri
      /// <summary>
      /// 获取某业务记录的所有WfHistory
      /// </summary>
      /// <returns>所有的WfHistory。</returns>
      public WfHistoryDataObjectList GetWfHistorysByBusiness(string business,int businessID)
      {
          Expression<Func<WfHistory, bool>> source = p => business.Equals(p.Business) && p.BusinessID == businessID;
          return GetWfHistoryList(source);
      }

       #endregion
   }
}
