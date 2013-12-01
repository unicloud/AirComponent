#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/17 23:23:10

// 文件名：SnHistoryQuery
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
   /// 表示用于SnHistory的查询接口。
   /// </summary>
   public class SnHistoryQuery: ISnHistoryQuery
   {
      private readonly ComponentDbContext _context;
      
      public SnHistoryQuery(IUniCloudDbContext context)
      {
         _context = context as ComponentDbContext;
      }
      
      #region Query SnHistory
      
      /// <summary>
      /// 获取所有SnHistory
      /// </summary>
      /// <returns>所有的SnHistory。</returns>
      public SnHistoryDataObjectList GetSnHistorys(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter)
      {
         Expression<Func<SnHistory, bool>> source = p => true;
         return GetSnHistoryList(source);
      }
      
      /// <summary>
      /// 获取所有SnHistory分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的SnHistory分页信息。</returns>
      public SnHistoryWithPagination GetSnHistoryWithPagination(Pagination pagination)
      {
         Expression<Func<SnHistory, bool>> wherePredicate = p => true;
         Expression<Func<SnHistory, dynamic>> sortPredicate = t =>t.ID;
         return GetSnHistoryPage(wherePredicate,sortPredicate,pagination);
      }
      
      /// <summary>
      /// 通过SnHistoryId获取相应的SnHistory
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
       public SnHistoryDataObject GetSnHistoryByID(int id)
      {
         Expression<Func<SnHistory, bool>> source = p => p.ID == id;
         var result = GetSnHistoryList(source);
         return result == null ? null : result.FirstOrDefault();
      }

       /// <summary>
       /// 通过SnHistoryId获取相应的SnHistory
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public SnHistoryDataObject GetLastSnHistoryBySnregID(int snregID)
       {
           SnHistoryDataObject sh = null;
           Expression<Func<SnHistory, bool>> source = p => p.SnRegID == snregID;
           var queryResult = (_context.SnHistorys.Where(source).Select(t => new SnHistoryDataObject()
           {
               SnRegID = t.SnRegID,
               Source = t.Source,
               Active = t.Active,
               Position = t.Position,
               NhSnRegID = t.NhSnRegID,
               RootSnRegID = t.RootSnRegID,
               Note = t.Note,
               ActiveDate = t.ActiveDate,
               Ata = t.Ata,
               Orderno = t.Orderno,
               ID = t.ID
           })).OrderByDescending(o => o.ID).FirstOrDefault();
           if (queryResult != null)
               sh = queryResult;
           return sh;
       }

      #endregion
      
      #region Common Query
      
       private SnHistoryDataObjectList GetSnHistoryList(Expression<Func<SnHistory, bool>> source)
      {
         var queryResult = (_context.SnHistorys.Where(source).Select(t => new SnHistoryDataObject()
            {
                SnRegID = t.SnRegID,
                Source = t.Source,
                Active = t.Active,
                Position = t.Position,
                NhSnRegID = t.NhSnRegID,
                RootSnRegID = t.RootSnRegID,
                Note = t.Note,
                ActiveDate = t.ActiveDate,
                Ata = t.Ata,
                Orderno = t.Orderno,
                ID = t.ID
            })).ToList();
         if (!queryResult.Any()) return new SnHistoryDataObjectList();
         var transferResult = new SnHistoryDataObjectList();
         queryResult.ForEach(transferResult.Add);
         return transferResult;
      }
      
       private SnHistoryWithPagination GetSnHistoryPage(Expression<Func<SnHistory, bool>> wherePredicate,
                  Expression<Func<SnHistory, dynamic>> sortPredicate,
                  Pagination pagination)
      {
         Expression<Func<SnHistory,SnHistoryDataObject>> mapper=t=> new SnHistoryDataObject
            {
               SnRegID = t.SnRegID,
               Source = t.Source,
               Active = t.Active,
               Position = t.Position,
               NhSnRegID = t.NhSnRegID,
               RootSnRegID = t.RootSnRegID,
               Note = t.Note,
               ActiveDate = t.ActiveDate,
               Ata = t.Ata,
               Orderno = t.Orderno,
               ID = t.ID,
               PnSn = (_context.SnRegs.Where(c => c.ID == t.SnRegID && c.ID != t.ID).Select(c => c.PnReg.Pn + "/" + c.Sn)).FirstOrDefault(),
               NhPnSn = (_context.SnRegs.Where(c => c.ID == t.NhSnRegID && c.ID != t.ID).Select(c => c.PnReg.Pn + "/" + c.Sn)).FirstOrDefault(),
               RootPnSn = (_context.SnRegs.Where(c => c.ID == t.RootSnRegID && c.ID != t.ID).Select(c => c.PnReg.Pn + "/" + c.Sn)).FirstOrDefault(), 
            };
         var SnHistoryResult = _context.LoadPageDataObjects<SnHistory,SnHistoryDataObject>(wherePredicate, sortPredicate, pagination, mapper);
         if(SnHistoryResult==null) return null;
         pagination.TotalPages=SnHistoryResult.TotalPages;
         var SnHistoryWithPagination= new SnHistoryWithPagination
            {
               Pagination=pagination,
               BaseDataObjectList = new BaseDataObjectList<SnHistoryDataObject>()
            };
         foreach (var value in SnHistoryResult.Data)
            {
               SnHistoryWithPagination.BaseDataObjectList.Add(value);
            }
            return SnHistoryWithPagination;
      }
      
      #endregion



       public SnHistoryDataObjectList QuerySnHistorys(string ac, string itemNo, string pn, DateTime fromDate, DateTime toDate)
       {
           throw new NotImplementedException();
       }
   }
}
