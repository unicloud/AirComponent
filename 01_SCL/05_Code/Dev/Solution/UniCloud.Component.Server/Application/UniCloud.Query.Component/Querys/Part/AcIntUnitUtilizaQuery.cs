#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/6 11:27:30

// 文件名：AcIntUnitUtilizaQuery
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
   /// 表示用于AcIntUnitUtiliza的查询接口。
   /// </summary>
   public class AcIntUnitUtilizaQuery: IAcIntUnitUtilizaQuery
   {
       private readonly ComponentDbContext _context;
      
      public AcIntUnitUtilizaQuery(IUniCloudDbContext context)
      {
          _context = context as ComponentDbContext;
      }
      
      #region Query AcIntUnitUtiliza
      
      /// <summary>
      /// 获取所有AcIntUnitUtiliza
      /// </summary>
      /// <returns>所有的AcIntUnitUtiliza。</returns>
      public AcIntUnitUtilizaDataObjectList GetAcIntUnitUtilizas(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter)
      {
         Expression<Func<AcIntUnitUtiliza, bool>> source = p => true;
         return GetAcIntUnitUtilizaList(source);
      }
      
      /// <summary>
      /// 获取所有AcIntUnitUtiliza分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的AcIntUnitUtiliza分页信息。</returns>
      public AcIntUnitUtilizaWithPagination GetAcIntUnitUtilizaWithPagination(Pagination pagination)
      {
         Expression<Func<AcIntUnitUtiliza, bool>> wherePredicate = p => true;
         Expression<Func<AcIntUnitUtiliza, dynamic>> sortPredicate = t =>t.ID;
         return GetAcIntUnitUtilizaPage(wherePredicate,sortPredicate,pagination);
      }
      
      /// <summary>
      /// 通过AcIntUnitUtilizaId获取相应的AcIntUnitUtiliza
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
       public AcIntUnitUtilizaDataObject GetAcIntUnitUtilizaByID(int id)
      {
         Expression<Func<AcIntUnitUtiliza, bool>> source = p => p.ID == id;
         var result = GetAcIntUnitUtilizaList(source);
         return result == null ? null : result.FirstOrDefault();
      }
      
      #endregion
      
      #region Common Query
      
       private AcIntUnitUtilizaDataObjectList GetAcIntUnitUtilizaList(Expression<Func<AcIntUnitUtiliza, bool>> source)
      {
         var queryResult = (_context.AcIntUnitUtilizas.Where(source).Select(t => new AcIntUnitUtilizaDataObject()
            {
               AcReg = t.AcReg,
               Msn = t.Msn,
               Unit = t.Unit,
               Utiliza = t.Utiliza,
               UtilizaRate = t.UtilizaRate,
               ID = t.ID,
            })).ToList();
         if (!queryResult.Any()) return new AcIntUnitUtilizaDataObjectList();
         var transferResult = new AcIntUnitUtilizaDataObjectList();
         queryResult.ForEach(transferResult.Add);
         return transferResult;
      }
      
       private AcIntUnitUtilizaWithPagination GetAcIntUnitUtilizaPage(Expression<Func<AcIntUnitUtiliza, bool>> wherePredicate,
                  Expression<Func<AcIntUnitUtiliza, dynamic>> sortPredicate,
                  Pagination pagination)
      {
         Expression<Func<AcIntUnitUtiliza,AcIntUnitUtilizaDataObject>> mapper=t=> new AcIntUnitUtilizaDataObject
            {
               AcReg = t.AcReg,
               Msn = t.Msn,
               Unit = t.Unit,
               Utiliza = t.Utiliza,
               UtilizaRate = t.UtilizaRate,
               ID = t.ID,
            };
         var AcIntUnitUtilizaResult = _context.LoadPageDataObjects<AcIntUnitUtiliza,AcIntUnitUtilizaDataObject>(wherePredicate, sortPredicate, pagination, mapper);
         if(AcIntUnitUtilizaResult==null) return null;
         pagination.TotalPages=AcIntUnitUtilizaResult.TotalPages;
         var AcIntUnitUtilizaWithPagination= new AcIntUnitUtilizaWithPagination
            {
               Pagination=pagination,
               BaseDataObjectList = new BaseDataObjectList<AcIntUnitUtilizaDataObject>()
            };
         foreach (var value in AcIntUnitUtilizaResult.Data)
            {
               AcIntUnitUtilizaWithPagination.BaseDataObjectList.Add(value);
            }
            return AcIntUnitUtilizaWithPagination;
      }
      
      #endregion
      
   }
}
