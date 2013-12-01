#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/18 11:52:26

// 文件名：AdsbQuery
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
   /// 表示用于Adsb的查询接口。
   /// </summary>
   public class AdsbQuery: IAdsbQuery
   {
       private readonly ComponentDbContext _context;
      
      public AdsbQuery(IUniCloudDbContext context)
      {
          _context = context as ComponentDbContext;
      }
      
      #region Query Adsb
      
      /// <summary>
      /// 获取所有Adsb
      /// </summary>
      /// <returns>所有的Adsb。</returns>
      public AdsbDataObjectList GetAdsbs(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter)
      {
         Expression<Func<Adsb, bool>> source = p => true;
         return GetAdsbList(source);
      }
      
      /// <summary>
      /// 获取所有Adsb分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的Adsb分页信息。</returns>
      public AdsbWithPagination GetAdsbWithPagination(Pagination pagination)
      {
         Expression<Func<Adsb, bool>> wherePredicate = p => true;
         Expression<Func<Adsb, dynamic>> sortPredicate = t =>t.ID;
         return GetAdsbPage(wherePredicate,sortPredicate,pagination);
      }
      
      /// <summary>
      /// 通过AdsbId获取相应的Adsb
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
       public AdsbDataObject GetAdsbByID(int id)
      {
         Expression<Func<Adsb, bool>> source = p => p.ID == id;
         var result = GetAdsbList(source);
         return result == null ? null : result.FirstOrDefault();
      }
      
      #endregion
      
      #region Common Query
      
       private AdsbDataObjectList GetAdsbList(Expression<Func<Adsb, bool>> source)
      {
         var queryResult = (_context.Adsbs.Where(source).Select(t => new AdsbDataObject()
            {
               Actype = t.Actype,
               FileType = t.FileType,
               FileNo = t.FileNo,
               FileVersion = t.FileVersion,
               FileTitle = t.FileTitle,
               FromFile = t.FromFile,
               Content = t.Content,
               ReceiveDate = t.ReceiveDate,
               ID = t.ID,
            })).ToList();
         if (!queryResult.Any()) return new AdsbDataObjectList();
         var transferResult = new AdsbDataObjectList();
         queryResult.ForEach(transferResult.Add);
         return transferResult;
      }
      
       private AdsbWithPagination GetAdsbPage(Expression<Func<Adsb, bool>> wherePredicate,
                  Expression<Func<Adsb, dynamic>> sortPredicate,
                  Pagination pagination)
      {
         Expression<Func<Adsb,AdsbDataObject>> mapper=t=> new AdsbDataObject
            {
               Actype = t.Actype,
               FileType = t.FileType,
               FileNo = t.FileNo,
               FileVersion = t.FileVersion,
               FileTitle = t.FileTitle,
               FromFile = t.FromFile,
               Content = t.Content,
               ReceiveDate = t.ReceiveDate,
               ID = t.ID,
            };
         var AdsbResult = _context.LoadPageDataObjects<Adsb,AdsbDataObject>(wherePredicate, sortPredicate, pagination, mapper);
         if(AdsbResult==null) return null;
         pagination.TotalPages=AdsbResult.TotalPages;
         var AdsbWithPagination= new AdsbWithPagination
            {
               Pagination=pagination,
               BaseDataObjectList = new BaseDataObjectList<AdsbDataObject>()
            };
         foreach (var value in AdsbResult.Data)
            {
               AdsbWithPagination.BaseDataObjectList.Add(value);
            }
            return AdsbWithPagination;
      }
      
      #endregion
      
   }
}
