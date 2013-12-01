#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/13 10:03:06

// 文件名：AirBusMSCNRepository
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
   public class AirBusMSCNRepository: EntityFrameworkIntRepository<AirBusMSCN>, IAirBusMSCNRepository
   {
       private readonly ComponentDbContext _efContext;
      
      public AirBusMSCNRepository(IRepositoryContext context) : base(context)
      {
          _efContext = EFContext.Context as ComponentDbContext;
      }
      /// <summary>
      /// 实现对AirBusMSCN的增删改。
      /// 需要添加的AirBusMSCN对象集合
      /// 需要删除的AirBusMSCN的ID集合
      /// 需要更新的AirBusMSCN对象集合
      /// <returns>执行后的更改结果</returns>
      /// </summary>
      public void CommitAirBusMSCN(List<AirBusMSCN> addAirBusMSCNs,  IEnumerable<string> deleteIds,  List<AirBusMSCN> updateAirBusMSCNs)
      {
         AddAirBusMSCNs(addAirBusMSCNs);
         DeleteAirBusMSCNs(deleteIds);
         UpdateAirBusMSCNs(updateAirBusMSCNs);
         _efContext.SaveChanges();
      }
      
      /// <summary>
      /// 增加AirBusMSCN
      /// </summary>
      /// <param name="addAirBusMSCNs">AirBusMSCN</param>
      private void AddAirBusMSCNs(List<AirBusMSCN> addAirBusMSCNs)
      {
        if (addAirBusMSCNs != null && addAirBusMSCNs.Any())
        {
            addAirBusMSCNs.ForEach(p =>
            {
                _efContext.Entry(p).State = EntityState.Added;
            });
        }
      }
      
      /// <summary>
      /// 删除AirBusMSCN
      /// </summary>
      /// <param name="deleteIds">删除AirBusMSCN</param>
      private void DeleteAirBusMSCNs(IEnumerable<string> deleteIds)
      {
        if (deleteIds != null)
        {
            foreach (var id in deleteIds)
            {
                var result = GetAirBusMSCNById(id.ToString());
                if (result != null)
                {
                   _efContext.Entry(result).State = EntityState.Deleted;
                }
            }
        }
      }
      
      /// <summary>
      ///     更新AirBusMSCN
      /// </summary>
      /// <param name="updateAirBusMSCNs">更新的AirBusMSCN</param>
      private void UpdateAirBusMSCNs(List<AirBusMSCN> updateAirBusMSCNs)
      {
        if (updateAirBusMSCNs != null && updateAirBusMSCNs.Any())
        {
            foreach (var updateObj in updateAirBusMSCNs)
            {
                var obj = GetAirBusMSCNById(updateObj.ID.ToString());
                if (obj != null)
                {
                    _efContext.AirBusMSCNs.Attach(obj);
                    obj.Mod = updateObj.Mod;
                    obj.MscnNo = updateObj.MscnNo;
                    obj.MscnTitle = updateObj.MscnTitle;
                    obj.Msn = updateObj.Msn;
                    obj.Status = updateObj.Status;
                    obj.Ata = updateObj.Ata;
                }
            }
        }
      }
      
      /// <summary>
      ///     根据AirBusMSCNID获取AirBusMSCN
      /// </summary>
      /// <param name="id">AirBusMSCN主键</param>
      /// <returns>AirBusMSCN</returns>
      private AirBusMSCN GetAirBusMSCNById(string id)
      {
          int key = Convert.ToInt32(id);
          return _efContext == null ? null : _efContext.AirBusMSCNs.FirstOrDefault(p => p.ID == key);
      }
   }
}
