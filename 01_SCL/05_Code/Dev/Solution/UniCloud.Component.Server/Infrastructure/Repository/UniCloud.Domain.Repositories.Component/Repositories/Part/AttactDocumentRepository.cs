#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/21 9:41:58

// 文件名：AttactDocumentRepository
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UniCloud.Domain.Model;
using UniCloud.Domain.Repositories.EntityFramework;

namespace UniCloud.Domain.Repositories.Repositories
{
   public class AttactDocumentRepository: EntityFrameworkIntRepository<AttactDocument>, IAttactDocumentRepository
   {
       private readonly ComponentDbContext _efContext;
      
      public AttactDocumentRepository(IRepositoryContext context) : base(context)
      {
          _efContext = EFContext.Context as ComponentDbContext;
      }
      /// <summary>
      /// 实现对AttactDocument的增删改。
      /// 需要添加的AttactDocument对象集合
      /// 需要删除的AttactDocument的ID集合
      /// 需要更新的AttactDocument对象集合
      /// <returns>执行后的更改结果</returns>
      /// </summary>
      public void CommitAttactDocument(List<AttactDocument> addAttactDocuments,  IEnumerable<string> deleteIds,  List<AttactDocument> updateAttactDocuments)
      {
         AddAttactDocuments(addAttactDocuments);
         DeleteAttactDocuments(deleteIds);
         UpdateAttactDocuments(updateAttactDocuments);
         _efContext.SaveChanges();
      }
      
      /// <summary>
      /// 增加AttactDocument
      /// </summary>
      /// <param name="addAttactDocuments">AttactDocument</param>
      private void AddAttactDocuments(List<AttactDocument> addAttactDocuments)
      {
        if (addAttactDocuments != null && addAttactDocuments.Any())
        {
            addAttactDocuments.ForEach(p =>
            {
                _efContext.Entry(p).State = EntityState.Added;
            });
        }
      }
      
      /// <summary>
      /// 删除AttactDocument
      /// </summary>
      /// <param name="deleteIds">删除AttactDocument</param>
      private void DeleteAttactDocuments(IEnumerable<string> deleteIds)
      {
        if (deleteIds != null)
        {
            foreach (var id in deleteIds)
            {
                var result = GetAttactDocumentById(id.ToString());
                if (result != null)
                {
                   _efContext.Entry(result).State = EntityState.Deleted;
                }
            }
        }
      }
      
      /// <summary>
      ///     更新AttactDocument
      /// </summary>
      /// <param name="updateAttactDocuments">更新的AttactDocument</param>
      private void UpdateAttactDocuments(List<AttactDocument> updateAttactDocuments)
      {
        if (updateAttactDocuments != null && updateAttactDocuments.Any())
        {
            foreach (var updateObj in updateAttactDocuments)
            {
                var obj = GetAttactDocumentById(updateObj.ID.ToString());
                if (obj != null)
                {
                    _efContext.AttactDocuments.Attach(obj);
                    
                }
                else
                {
                    //当作子表来更新，传入集合有，数据库没有，则新增
                    _efContext.Entry(updateObj).State = EntityState.Added;
                }
            }
            //找中数据库中记录
            var doc = updateAttactDocuments.FirstOrDefault();
            var attDocs =
                _efContext.AttactDocuments.Where(a => a.BusinessID == doc.BusinessID && a.Business == doc.Business).ToList();
            //传入集合没有，数据库中有，则删除
            for (int i = attDocs.Count - 1; i >= 0; i--)
            {
                var d = attDocs.ElementAt(i);
                if (updateAttactDocuments.FirstOrDefault(p => p.ID == d.ID) == null)
                    _efContext.Entry(d).State = EntityState.Deleted;
            }
        }
      }
      
      /// <summary>
      ///     根据AttactDocumentID获取AttactDocument
      /// </summary>
      /// <param name="id">AttactDocument主键</param>
      /// <returns>AttactDocument</returns>
      private AttactDocument GetAttactDocumentById(string id)
      {
          var value = Convert.ToInt32(id);
          return _efContext == null ? null : _efContext.AttactDocuments.FirstOrDefault(p => p.ID == value);
      }
   }
}
