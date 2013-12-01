#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/21 22:36:56

// 文件名：AcCategoryQuery
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

namespace UniCloud.Query.AcConfiguration
{
   /// <summary>
   /// 表示用于AcCategory的查询接口。
   /// </summary>
   public class AcCategoryQuery: IAcCategoryQuery
   {
      private readonly AcConfigurationDbContext _context;
      
      public AcCategoryQuery(IUniCloudDbContext context)
      {
         _context = context as AcConfigurationDbContext;
      }
      
      #region Get AcCategory
      
      /// <summary>
      /// 获取所有AcCategory
      /// </summary>
      /// <returns>所有的AcCategory。</returns>
      public AcCategoryDataObjectList GetAcCategorys(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter)
      {
         Expression<Func<AcCategory, bool>> source = p => true;
         return GetAcCategoryList(source);
      }
      
      /// <summary>
      /// 获取所有AcCategory分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的AcCategory分页信息。</returns>
      public AcCategoryWithPagination GetAcCategoryWithPagination(Pagination pagination)
      {
         Expression<Func<AcCategory, bool>> wherePredicate = p => true;
         Expression<Func<AcCategory, dynamic>> sortPredicate = t =>t.ID;
         return GetAcCategoryPage(wherePredicate,sortPredicate,pagination);
      }
      
      /// <summary>
      /// 通过AcCategoryId获取相应的AcCategory
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
       public AcCategoryDataObject GetAcCategoryByID(int id)
      {
         Expression<Func<AcCategory, bool>> source = p => p.ID == id;
         var result = GetAcCategoryList(source);
         return result == null ? null : result.FirstOrDefault();
      }
      
      #endregion
      
      #region Common Get
      
       private AcCategoryDataObjectList GetAcCategoryList(Expression<Func<AcCategory, bool>> source)
      {
         var queryResult = (_context.AcCategorys.Where(source).Select(t => new AcCategoryDataObject()
            {
               Guid = t.Guid,
               Level = t.Level,
               Regional = t.Regional,
               ID = t.ID,
            })).ToList();
         if (!queryResult.Any()) return new AcCategoryDataObjectList();
         var transferResult = new AcCategoryDataObjectList();
         queryResult.ForEach(transferResult.Add);
         return transferResult;
      }
      
       private AcCategoryWithPagination GetAcCategoryPage(Expression<Func<AcCategory, bool>> wherePredicate,
                  Expression<Func<AcCategory, dynamic>> sortPredicate,
                  Pagination pagination)
      {
         Expression<Func<AcCategory,AcCategoryDataObject>> mapper=t=> new AcCategoryDataObject
            {
               Guid = t.Guid,
               Level = t.Level,
               Regional = t.Regional,
               ID = t.ID,
            };
         var AcCategoryResult = _context.LoadPageDataObjects<AcCategory,AcCategoryDataObject>(wherePredicate, sortPredicate, pagination, mapper);
         if(AcCategoryResult==null) return null;
         pagination.TotalPages=AcCategoryResult.TotalPages;
         var AcCategoryWithPagination= new AcCategoryWithPagination
            {
               Pagination=pagination,
               BaseDataObjectList = new BaseDataObjectList<AcCategoryDataObject>()
            };
         foreach (var value in AcCategoryResult.Data)
            {
               AcCategoryWithPagination.BaseDataObjectList.Add(value);
            }
            return AcCategoryWithPagination;
      }
      
      #endregion
      
      #region AcCategoryDorpDownSource
      
      /// <summary>
      /// 通过AcCategory下拉数据集合
      /// </summary>
      /// <param name="colFilter"></param>
      /// <param name="sortFilter"></param>
      /// <returns></returns>
      public KeyValueDataObjectList GetAcCategoryCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
      {
         var results=new KeyValueDataObjectList();
         var queryResult = (_context.AcCategorys.Select(t => new KeyValueDataObject()
            {
                IntKey =t.ID,
                Name=t.Regional
            })).ToList();
         queryResult.ForEach(results.Add);
         return results;
      }
      #endregion

   }
}
