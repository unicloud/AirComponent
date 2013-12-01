#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/21 22:36:56

// 文件名：AtaQuery
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
using System.Collections.Generic;

namespace UniCloud.Query.AcConfiguration
{
   /// <summary>
   /// 表示用于Ata的查询接口。
   /// </summary>
   public class AtaQuery: IAtaQuery
   {
      private readonly AcConfigurationDbContext _context;
      
      public AtaQuery(IUniCloudDbContext context)
      {
         _context = context as AcConfigurationDbContext;
      }
      
      #region Get Ata
      
      /// <summary>
      /// 获取所有Ata
      /// </summary>
      /// <returns>所有的Ata。</returns>
      public AtaDataObjectList GetAtas(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter)
      {
         Expression<Func<Ata, bool>> source = p => true;
         return GetAtaList(source);
      }
      
      /// <summary>
      /// 获取所有Ata分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的Ata分页信息。</returns>
      public AtaWithPagination GetAtaWithPagination(Pagination pagination)
      {
         Expression<Func<Ata, bool>> wherePredicate = p => true;
         Expression<Func<Ata, dynamic>> sortPredicate = t =>t.ID;
         return GetAtaPage(wherePredicate,sortPredicate,pagination);
      }
      
      /// <summary>
      /// 通过AtaId获取相应的Ata
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
       public AtaDataObject GetAtaByID(int id)
      {
         Expression<Func<Ata, bool>> source = p => p.ID == id;
         var result = GetAtaList(source);
         return result == null ? null : result.FirstOrDefault();
      }

       public AtaDataObject GetAtaByGuid(string id)
       {
           Guid guid = new Guid(id);
           Expression<Func<Ata, bool>> source = p => p.Guid == guid;
           var result = GetAtaList(source);
           return result == null ? null : result.FirstOrDefault();
       }
      
      #endregion
      
      #region Common Get
      
       private AtaDataObjectList GetAtaList(Expression<Func<Ata, bool>> source)
      {
         var queryResult = (_context.Atas.Where(source).Select(t => new AtaDataObject()
            {
               Guid = t.Guid,
               ATA = t.ATA,
               Description = t.Description,
               ParentID = t.ParentID,
               ID = t.ID,
            })).ToList();
         if (!queryResult.Any()) return new AtaDataObjectList();
         var sortResults = queryResult.OrderBy(a => a.ATA, new AtaCompare()).ToList();
         var transferResult = new AtaDataObjectList();
         sortResults.ForEach(transferResult.Add);
         return transferResult;
      }
      
       private AtaWithPagination GetAtaPage(Expression<Func<Ata, bool>> wherePredicate,
                  Expression<Func<Ata, dynamic>> sortPredicate,
                  Pagination pagination)
      {
         Expression<Func<Ata,AtaDataObject>> mapper=t=> new AtaDataObject
            {
               Guid = t.Guid,
               ATA = t.ATA,
               Description = t.Description,
               ParentID = t.ParentID,
               ID = t.ID,
            };
         var AtaResult = _context.LoadPageDataObjects<Ata,AtaDataObject>(wherePredicate, sortPredicate, pagination, mapper);
         if(AtaResult==null) return null;
         pagination.TotalPages=AtaResult.TotalPages;
         var AtaWithPagination= new AtaWithPagination
            {
               Pagination=pagination,
               BaseDataObjectList = new BaseDataObjectList<AtaDataObject>()
            };
         foreach (var value in AtaResult.Data)
            {
               AtaWithPagination.BaseDataObjectList.Add(value);
            }
            return AtaWithPagination;
      }
      
      #endregion
      
      #region AtaDorpDownSource
      
      /// <summary>
      /// 通过Ata下拉数据集合
      /// </summary>
      /// <param name="colFilter"></param>
      /// <param name="sortFilter"></param>
      /// <returns></returns>
      public KeyValueDataObjectList GetAtaCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
      {
         var results=new KeyValueDataObjectList();
         var queryResult = (_context.Atas.Select(t => new KeyValueDataObject()
            {
                IntKey=t.ID,
                Name=t.ATA
            })).ToList();
         queryResult.ForEach(results.Add);
         return results;
      }
      #endregion
   }


    public class AtaCompare:IComparer<string>
    {
        public int Compare(string x, string y)
        {
            int a, b;
            int.TryParse(x, out a);
            int.TryParse(y, out b);
            if (a == b)
                return 0;
            else if (a > b)
                return 1;
            else
            {
                return -1;
            }
        }
    }
}
