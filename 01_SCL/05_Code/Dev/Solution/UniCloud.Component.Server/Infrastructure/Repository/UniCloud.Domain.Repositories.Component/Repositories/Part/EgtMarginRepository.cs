#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/16 10:49:57

// 文件名：EgtMarginRepository
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
   public class EgtMarginRepository: EntityFrameworkIntRepository<EgtMargin>, IEgtMarginRepository
   {
       private readonly ComponentDbContext _efContext;
      
      public EgtMarginRepository(IRepositoryContext context) : base(context)
      {
          _efContext = EFContext.Context as ComponentDbContext;
      }
      /// <summary>
      /// 实现对EgtMargin的增删改。
      /// 需要添加的EgtMargin对象集合
      /// 需要删除的EgtMargin的ID集合
      /// 需要更新的EgtMargin对象集合
      /// <returns>执行后的更改结果</returns>
      /// </summary>
      public void CommitEgtMargin(List<EgtMargin> addEgtMargins,  IEnumerable<string> deleteIds,  List<EgtMargin> updateEgtMargins)
      {
         AddEgtMargins(addEgtMargins);
         DeleteEgtMargins(deleteIds);
         UpdateEgtMargins(updateEgtMargins);
         _efContext.SaveChanges();
      }
      
      /// <summary>
      /// 增加EgtMargin
      /// </summary>
      /// <param name="addEgtMargins">EgtMargin</param>
      private void AddEgtMargins(List<EgtMargin> addEgtMargins)
      {
        if (addEgtMargins != null && addEgtMargins.Any())
        {
            addEgtMargins.ForEach(p =>
            {
                p.OperateDate = DateTime.Now;
                _efContext.Entry(p).State = EntityState.Added;
            });
        }
      }
      
      /// <summary>
      /// 删除EgtMargin
      /// </summary>
      /// <param name="deleteIds">删除EgtMargin</param>
      private void DeleteEgtMargins(IEnumerable<string> deleteIds)
      {
        if (deleteIds != null)
        {
            foreach (var id in deleteIds)
            {
                var result = GetEgtMarginById(id.ToString());
                if (result != null)
                {
                   _efContext.Entry(result).State = EntityState.Deleted;
                }
            }
        }
      }
      
      /// <summary>
      ///     更新EgtMargin
      /// </summary>
      /// <param name="updateEgtMargins">更新的EgtMargin</param>
      private void UpdateEgtMargins(List<EgtMargin> updateEgtMargins)
      {
        if (updateEgtMargins != null && updateEgtMargins.Any())
        {
            foreach (var updateObj in updateEgtMargins)
            {
                var obj = GetEgtMarginById(updateObj.ID.ToString());
                if (obj != null)
                {
                    obj.Egtm = updateObj.Egtm;
                    obj.OperateDate = updateObj.OperateDate;
                    obj.Operator = updateObj.Operator;
                    _efContext.EgtMargins.Attach(obj);
                }
            }
        }
      }
      
      /// <summary>
      ///     根据EgtMarginID获取EgtMargin
      /// </summary>
      /// <param name="id">EgtMargin主键</param>
      /// <returns>EgtMargin</returns>
      private EgtMargin GetEgtMarginById(string id)
      {
          var value = Convert.ToInt32(id);
          return _efContext == null ? null : _efContext.EgtMargins.FirstOrDefault(p => p.ID == value);
      }
   }
}
