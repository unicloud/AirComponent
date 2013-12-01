#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/17 23:23:10

// 文件名：IntUnitQuery
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UniCloud.DataObjects;
using UniCloud.Domain.Model;
using UniCloud.Domain.Repositories.EntityFramework;

namespace UniCloud.Query
{
   /// <summary>
   /// 表示用于IntUnit的查询接口。
   /// </summary>
   public class IntUnitQuery: IIntUnitQuery
   {
      private readonly ComponentDbContext _context;

      public IntUnitQuery(IUniCloudDbContext context)
      {
         _context = context as ComponentDbContext;
      }
      
      #region Query IntUnit
      
      /// <summary>
      /// 获取所有IntUnit
      /// </summary>
      /// <returns>所有的IntUnit。</returns>
      public IntUnitDataObjectList GetIntUnits(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter)
      {
         Expression<Func<IntUnit, bool>> source = p => true;
         return GetIntUnitList(source);
      }
      
      /// <summary>
      /// 获取所有IntUnit分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的IntUnit分页信息。</returns>
      public IntUnitWithPagination GetIntUnitWithPagination(Pagination pagination)
      {
         Expression<Func<IntUnit, bool>> wherePredicate = p => true;
         Expression<Func<IntUnit, dynamic>> sortPredicate = t =>t.ID;
         return GetIntUnitPage(wherePredicate,sortPredicate,pagination);
      }
      
      /// <summary>
      /// 通过IntUnitId获取相应的IntUnit
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
       public IntUnitDataObject GetIntUnitByID(int id)
      {
         Expression<Func<IntUnit, bool>> source = p => p.ID == id;
         var result = GetIntUnitList(source);
         return result == null ? null : result.FirstOrDefault();
      }
      
      #endregion
      
      #region Common Query
      
       private IntUnitDataObjectList GetIntUnitList(Expression<Func<IntUnit, bool>> source)
      {
         var queryResult = (_context.IntUnits.Where(source).Select(t => new IntUnitDataObject()
            {
               Unit = t.Unit,
               Descritption = t.Descritption,
               Type = t.Type,
               ShortName = t.ShortName,
               ID = t.ID,
            })).ToList();
         if (!queryResult.Any()) return new IntUnitDataObjectList();
         var transferResult = new IntUnitDataObjectList();
         queryResult.ForEach(transferResult.Add);
         return transferResult;
      }
      
       private IntUnitWithPagination GetIntUnitPage(Expression<Func<IntUnit, bool>> wherePredicate,
                  Expression<Func<IntUnit, dynamic>> sortPredicate,
                  Pagination pagination)
      {
         Expression<Func<IntUnit,IntUnitDataObject>> mapper=t=> new IntUnitDataObject
            {
               Unit = t.Unit,
               Descritption = t.Descritption,
               Type = t.Type,
               ShortName = t.ShortName,
               ID = t.ID,
            };
         var IntUnitResult = _context.LoadPageDataObjects<IntUnit,IntUnitDataObject>(wherePredicate, sortPredicate, pagination, mapper);
         if(IntUnitResult==null) return null;
         pagination.TotalPages=IntUnitResult.TotalPages;
         var IntUnitWithPagination= new IntUnitWithPagination
            {
               Pagination=pagination,
               BaseDataObjectList = new BaseDataObjectList<IntUnitDataObject>()
            };
         foreach (var value in IntUnitResult.Data)
            {
               IntUnitWithPagination.BaseDataObjectList.Add(value);
            }
            return IntUnitWithPagination;
      }



      #endregion


   }
}
