#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/21 9:41:58

// 文件名：AttactDocumentQuery
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
   /// 表示用于AttactDocument的查询接口。
   /// </summary>
   public class AttactDocumentQuery: IAttactDocumentQuery
   {
       private readonly ComponentDbContext _context;
      
      public AttactDocumentQuery(IUniCloudDbContext context)
      {
          _context = context as ComponentDbContext;
      }
      
      #region Query AttactDocument
      
      /// <summary>
      /// 获取所有AttactDocument
      /// </summary>
      /// <returns>所有的AttactDocument。</returns>
      public AttactDocumentDataObjectList GetAttactDocuments(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter)
      {
          Expression<Func<AttactDocument, bool>> source =colFilter==null? p => true:
          colFilter.GetLambdaExpression<AttactDocument>();
         return GetAttactDocumentList(source);
      }
      
      /// <summary>
      /// 获取所有AttactDocument分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的AttactDocument分页信息。</returns>
      public AttactDocumentWithPagination GetAttactDocumentWithPagination(Pagination pagination)
      {
         Expression<Func<AttactDocument, bool>> wherePredicate = p => true;
         Expression<Func<AttactDocument, dynamic>> sortPredicate = t =>t.ID;
         return GetAttactDocumentPage(wherePredicate,sortPredicate,pagination);
      }
      
      /// <summary>
      /// 通过AttactDocumentId获取相应的AttactDocument
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
       public AttactDocumentDataObject GetAttactDocumentByID(int id)
      {
         Expression<Func<AttactDocument, bool>> source = p => p.ID == id;
         var result = GetAttactDocumentList(source);
         return result == null ? null : result.FirstOrDefault();
      }
      
      #endregion
      
      #region Common Query
      
       private AttactDocumentDataObjectList GetAttactDocumentList(Expression<Func<AttactDocument, bool>> source)
      {
         var queryResult = (_context.AttactDocuments.Where(source).Select(t => new AttactDocumentDataObject()
            {
               BusinessID = t.BusinessID,
               Business = t.Business,
               DocumentID = t.DocumentID,
               FileName = t.FileName,
               UploadTime = t.UploadTime,
               ExtendType = t.ExtendType,
               Uploader = t.Uploader,
               DocumentType = t.DocumentType,
               ID = t.ID,
            })).ToList();
         if (!queryResult.Any()) return new AttactDocumentDataObjectList();
         var transferResult = new AttactDocumentDataObjectList();
         queryResult.ForEach(transferResult.Add);
         return transferResult;
      }
      
       private AttactDocumentWithPagination GetAttactDocumentPage(Expression<Func<AttactDocument, bool>> wherePredicate,
                  Expression<Func<AttactDocument, dynamic>> sortPredicate,
                  Pagination pagination)
      {
         Expression<Func<AttactDocument,AttactDocumentDataObject>> mapper=t=> new AttactDocumentDataObject
            {
               BusinessID = t.BusinessID,
               Business = t.Business,
               DocumentID = t.DocumentID,
               FileName = t.FileName,
               UploadTime = t.UploadTime,
               ExtendType = t.ExtendType,
               Uploader = t.Uploader,
               DocumentType = t.DocumentType,
               ID = t.ID,
            };
         var AttactDocumentResult = _context.LoadPageDataObjects<AttactDocument,AttactDocumentDataObject>(wherePredicate, sortPredicate, pagination, mapper);
         if(AttactDocumentResult==null) return null;
         pagination.TotalPages=AttactDocumentResult.TotalPages;
         var AttactDocumentWithPagination= new AttactDocumentWithPagination
            {
               Pagination=pagination,
               BaseDataObjectList = new BaseDataObjectList<AttactDocumentDataObject>()
            };
         foreach (var value in AttactDocumentResult.Data)
            {
               AttactDocumentWithPagination.BaseDataObjectList.Add(value);
            }
            return AttactDocumentWithPagination;
      }


       /// <summary>
       /// 获取与某业务相当的AttactDocument
       /// </summary>
       /// <returns>所有的AttactDocument。</returns>
       public AttactDocumentDataObjectList GetBusinessAttactDocuments(int businessId, string business)
       {
           Expression<Func<AttactDocument, bool>> source = p => p.BusinessID == businessId
                                                                && p.Business == business;
           return GetAttactDocumentList(source);
       }

      #endregion
      
   }
}
