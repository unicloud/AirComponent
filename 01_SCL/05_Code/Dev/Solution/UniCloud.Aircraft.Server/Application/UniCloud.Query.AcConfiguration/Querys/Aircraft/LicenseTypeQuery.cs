#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/21 22:36:56

// 文件名：LicenseTypeQuery
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
   /// 表示用于LicenseType的查询接口。
   /// </summary>
   public class LicenseTypeQuery: ILicenseTypeQuery
   {
      private readonly AcConfigurationDbContext _context;
      
      public LicenseTypeQuery(IUniCloudDbContext context)
      {
         _context = context as AcConfigurationDbContext;
      }
      
      #region Get LicenseType
      
      /// <summary>
      /// 获取所有LicenseType
      /// </summary>
      /// <returns>所有的LicenseType。</returns>
      public LicenseTypeDataObjectList GetLicenseTypes(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter)
      {
         Expression<Func<LicenseType, bool>> source = p => true;
         return GetLicenseTypeList(source);
      }
      
      /// <summary>
      /// 获取所有LicenseType分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的LicenseType分页信息。</returns>
      public LicenseTypeWithPagination GetLicenseTypeWithPagination(Pagination pagination)
      {
         Expression<Func<LicenseType, bool>> wherePredicate = p => true;
         Expression<Func<LicenseType, dynamic>> sortPredicate = t =>t.ID;
         return GetLicenseTypePage(wherePredicate,sortPredicate,pagination);
      }
      
      /// <summary>
      /// 通过LicenseTypeId获取相应的LicenseType
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
       public LicenseTypeDataObject GetLicenseTypeByID(int id)
      {
         Expression<Func<LicenseType, bool>> source = p => p.ID == id;
         var result = GetLicenseTypeList(source);
         return result == null ? null : result.FirstOrDefault();
      }
      
      #endregion
      
      #region Common Get
      
       private LicenseTypeDataObjectList GetLicenseTypeList(Expression<Func<LicenseType, bool>> source)
      {
         var queryResult = (_context.LicenseTypes.Where(source).Select(t => new LicenseTypeDataObject()
            {
               Guid = t.Guid,
               Type = t.Type,
               Description = t.Description,
               HasFile = t.HasFile,
               ID = t.ID,
            })).ToList();
         if (!queryResult.Any()) return new LicenseTypeDataObjectList();
         var transferResult = new LicenseTypeDataObjectList();
         queryResult.ForEach(transferResult.Add);
         return transferResult;
      }
      
       private LicenseTypeWithPagination GetLicenseTypePage(Expression<Func<LicenseType, bool>> wherePredicate,
                  Expression<Func<LicenseType, dynamic>> sortPredicate,
                  Pagination pagination)
      {
         Expression<Func<LicenseType,LicenseTypeDataObject>> mapper=t=> new LicenseTypeDataObject
            {
               Guid = t.Guid,
               Type = t.Type,
               Description = t.Description,
               HasFile = t.HasFile,
               ID = t.ID,
            };
         var LicenseTypeResult = _context.LoadPageDataObjects<LicenseType,LicenseTypeDataObject>(wherePredicate, sortPredicate, pagination, mapper);
         if(LicenseTypeResult==null) return null;
         pagination.TotalPages=LicenseTypeResult.TotalPages;
         var LicenseTypeWithPagination= new LicenseTypeWithPagination
            {
               Pagination=pagination,
               BaseDataObjectList = new BaseDataObjectList<LicenseTypeDataObject>()
            };
         foreach (var value in LicenseTypeResult.Data)
            {
               LicenseTypeWithPagination.BaseDataObjectList.Add(value);
            }
            return LicenseTypeWithPagination;
      }
      
      #endregion
      
      #region LicenseTypeDorpDownSource
      
      /// <summary>
      /// 通过LicenseType下拉数据集合
      /// </summary>
      /// <param name="colFilter"></param>
      /// <param name="sortFilter"></param>
      /// <returns></returns>
      public KeyValueDataObjectList GetLicenseTypeCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
      {
         var results=new KeyValueDataObjectList();
         var queryResult = (_context.LicenseTypes.Select(t => new KeyValueDataObject()
            {
                IntKey=t.ID,
                Name=t.Type
            })).ToList();
         queryResult.ForEach(results.Add);
         return results;
      }
      #endregion

   }
}
