#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/17 23:23:10

// 文件名：CcpMainQuery
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
   /// 表示用于CcpMain的查询接口。
   /// </summary>
   public class CcpMainQuery: ICcpMainQuery
   {
      private readonly ComponentDbContext _context;
      
      public CcpMainQuery(IUniCloudDbContext context)
      {
         _context = context as ComponentDbContext;
      }
      
      #region Query CcpMain
      
      /// <summary>
      /// 获取所有CcpMain
      /// </summary>
      /// <returns>所有的CcpMain。</returns>
      public CcpMainDataObjectList GetCcpMains(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter)
      {
         Expression<Func<CcpMain, bool>> source = p => true;
         return GetCcpMainList(source);
      }
      
      /// <summary>
      /// 获取所有CcpMain分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的CcpMain分页信息。</returns>
      public CcpMainWithPagination GetCcpMainWithPagination(Pagination pagination)
      {
         Expression<Func<CcpMain, bool>> wherePredicate = p => true;
         Expression<Func<CcpMain, dynamic>> sortPredicate = t =>t.ID;
         return GetCcpMainPage(wherePredicate,sortPredicate,pagination);
      }
      
      /// <summary>
      /// 通过CcpMainId获取相应的CcpMain
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
       public CcpMainDataObject GetCcpMainByID(int id)
      {
         Expression<Func<CcpMain, bool>> source = p => p.ID == id;
         var result = GetCcpMainList(source);
         return result == null ? null : result.FirstOrDefault();
      }
      
      #endregion
      
      #region Common Query
      
       private CcpMainDataObjectList GetCcpMainList(Expression<Func<CcpMain, bool>> source)
      {
         var queryResult = (_context.CcpMains.Where(source).Select(t => new CcpMainDataObject()
            {
               ItemNo = t.ItemNo,
               AcType = t.AcType,
               Ata = t.Ata,
               Description = t.Description,
               IsLife = t.IsLife,
               State = t.State,
               Version = t.Version,
               NhItemNo = t.NhItemNo,
               Updateby = t.Updateby,
               UpdateTime = t.UpdateTime,
               ID = t.ID,
            })).ToList();
         if (!queryResult.Any()) return new CcpMainDataObjectList();
         var transferResult = new CcpMainDataObjectList();
         queryResult.ForEach(transferResult.Add);
         return transferResult;
      }
      
       private CcpMainWithPagination GetCcpMainPage(Expression<Func<CcpMain, bool>> wherePredicate,
                  Expression<Func<CcpMain, dynamic>> sortPredicate,
                  Pagination pagination)
      {
         Expression<Func<CcpMain,CcpMainDataObject>> mapper=t=> new CcpMainDataObject
            {
               ItemNo = t.ItemNo,
               AcType = t.AcType,
               Ata = t.Ata,
               Description = t.Description,
               IsLife = t.IsLife,
               State = t.State,
               Version = t.Version,
               NhItemNo = t.NhItemNo,
               Updateby = t.Updateby,
               UpdateTime = t.UpdateTime,
               ID = t.ID,
            };
         var CcpMainResult = _context.LoadPageDataObjects<CcpMain,CcpMainDataObject>(wherePredicate, sortPredicate, pagination, mapper);
         if(CcpMainResult==null) return null;
         pagination.TotalPages=CcpMainResult.TotalPages;
         var CcpMainWithPagination= new CcpMainWithPagination
            {
               Pagination=pagination,
               BaseDataObjectList = new BaseDataObjectList<CcpMainDataObject>()
            };
         foreach (var value in CcpMainResult.Data)
            {
               CcpMainWithPagination.BaseDataObjectList.Add(value);
            }
            return CcpMainWithPagination;
      }
      
      #endregion
      
   }
}
