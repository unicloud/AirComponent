#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/17 23:23:10

// 文件名：OilHistoryQuery
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
   /// 表示用于OilHistory的查询接口。
   /// </summary>
   public class OilHistoryQuery: IOilHistoryQuery
   {
      private readonly ComponentDbContext _context;
      
      public OilHistoryQuery(IUniCloudDbContext context)
      {
         _context = context as ComponentDbContext;
      }
      
      #region Query OilHistory
      
      /// <summary>
      /// 获取所有OilHistory
      /// </summary>
      /// <returns>所有的OilHistory。</returns>
      public OilHistoryDataObjectList GetOilHistorys(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter)
      {
         Expression<Func<OilHistory, bool>> source = p => true;
         return GetOilHistoryList(source);
      }
      
      /// <summary>
      /// 获取所有OilHistory分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的OilHistory分页信息。</returns>
      public OilHistoryWithPagination GetOilHistoryWithPagination(Pagination pagination)
      {
         Expression<Func<OilHistory, bool>> wherePredicate = p => true;
         Expression<Func<OilHistory, dynamic>> sortPredicate = t =>t.ID;         
         return GetOilHistoryPage(wherePredicate,sortPredicate,pagination);
      }
      
      /// <summary>
      /// 通过OilHistoryId获取相应的OilHistory
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
       public OilHistoryDataObject GetOilHistoryByID(int id)
      {
         Expression<Func<OilHistory, bool>> source = p => p.ID == id;
         var result = GetOilHistoryList(source);
         return result == null ? null : result.FirstOrDefault();
      }
      
      #endregion
      
      #region Common Query
      
       private OilHistoryDataObjectList GetOilHistoryList(Expression<Func<OilHistory, bool>> source)
      {
         var queryResult = (_context.OilHistorys.Where(source).Select(t => new OilHistoryDataObject()
            {
                ID = t.ID,
                AcReg = t.AcReg,
                Msn = t.Msn,
                FlightDate = t.FlightDate,
                FlLogno = t.FlLogno,
                FlLegno = t.FlLegno,
                UpliftDer = t.UpliftDer,
                UpliftArr = t.UpliftArr,
                Pn = t.Pn,
                Sn = t.Sn,
                Ata = t.Ata,
                Zone = t.Zone,
                Position = t.Position,
                Tsn = t.Tsn,
                Csn = t.Csn,
                Fh = t.Fh,
                Cy = t.Cy,
                InstalDate = t.InstalDate,
                UpdateDate = t.UpdateDate,
                Notes = t.Notes,
            })).ToList();
         if (!queryResult.Any()) return new OilHistoryDataObjectList();
         var transferResult = new OilHistoryDataObjectList();
         queryResult.ForEach(transferResult.Add);
         return transferResult;
      }
      
       private OilHistoryWithPagination GetOilHistoryPage(Expression<Func<OilHistory, bool>> wherePredicate,
                  Expression<Func<OilHistory, dynamic>> sortPredicate,
                  Pagination pagination)
      {
         Expression<Func<OilHistory,OilHistoryDataObject>> mapper=t=> new OilHistoryDataObject
            {
                ID = t.ID,
                AcReg = t.AcReg,
                Msn = t.Msn,
                FlightDate = t.FlightDate,
                FlLogno = t.FlLogno,
                FlLegno = t.FlLegno,
                UpliftDer = t.UpliftDer,
                UpliftArr = t.UpliftArr,
                Pn = t.Pn,
                Sn = t.Sn,
                Ata = t.Ata,
                Zone = t.Zone,
                Position = t.Position,
                Tsn = t.Tsn,
                Csn = t.Csn,
                Fh = t.Fh,
                Cy = t.Cy,
                InstalDate = t.InstalDate,
                UpdateDate = t.UpdateDate,
                Notes = t.Notes,
            };
         var OilHistoryResult = _context.LoadPageDataObjects<OilHistory,OilHistoryDataObject>(wherePredicate, sortPredicate, pagination, mapper);
         if(OilHistoryResult==null) return null;
         pagination.TotalPages=OilHistoryResult.TotalPages;
         var OilHistoryWithPagination= new OilHistoryWithPagination
            {
               Pagination=pagination,
               BaseDataObjectList = new BaseDataObjectList<OilHistoryDataObject>()
            };
         foreach (var value in OilHistoryResult.Data)
            {
               OilHistoryWithPagination.BaseDataObjectList.Add(value);
            }
            return OilHistoryWithPagination;
      }
      
      #endregion

   }
}
