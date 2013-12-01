#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/6 12:46:36

// 文件名：OilAnalysisRepository
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
   public class OilAnalysisRepository: EntityFrameworkIntRepository<OilAnalysis>, IOilAnalysisRepository
   {
        private readonly ComponentDbContext _efContext;

        public OilAnalysisRepository(IRepositoryContext context)
            : base(context)
        {
            _efContext = EFContext.Context as ComponentDbContext;
        }
      /// <summary>
      /// 实现对OilAnalysis的增删改。
      /// 需要添加的OilAnalysis对象集合
      /// 需要删除的OilAnalysis的ID集合
      /// 需要更新的OilAnalysis对象集合
      /// <returns>执行后的更改结果</returns>
      /// </summary>
      public void CommitOilAnalysis(List<OilAnalysis> addOilAnalysiss,  IEnumerable<string> deleteIds,  List<OilAnalysis> updateOilAnalysiss)
      {
         AddOilAnalysiss(addOilAnalysiss);
         DeleteOilAnalysiss(deleteIds);
         UpdateOilAnalysiss(updateOilAnalysiss);
         _efContext.SaveChanges();
      }
      /// <summary>
      /// 增加OilAnalysis
      /// </summary>
      /// <param name="addOilAnalysiss">OilAnalysis</param>
      private void AddOilAnalysiss(List<OilAnalysis> addOilAnalysiss)
      {
          if (addOilAnalysiss != null && addOilAnalysiss.Any())
          {
              addOilAnalysiss.ForEach(p =>
              {
                  _efContext.Entry(p).State = EntityState.Added;
              });
          }
      }
      
      /// <summary>
      /// 删除OilAnalysis
      /// </summary>
      /// <param name="deleteIds">删除OilAnalysis</param>
      private void DeleteOilAnalysiss(IEnumerable<string> deleteIds)
      {
        if (deleteIds != null)
        {
            foreach (var id in deleteIds)
            {
                var result = GetOilAnalysisById(id.ToString());
                if (result != null)
                {
                   _efContext.Entry(result).State = EntityState.Deleted;
                }
            }
        }
      }
      
      /// <summary>
      ///     更新OilAnalysis
      /// </summary>
      /// <param name="updateOilAnalysiss">更新的OilAnalysis</param>
      private void UpdateOilAnalysiss(List<OilAnalysis> updateOilAnalysiss)
      {
        if (updateOilAnalysiss != null && updateOilAnalysiss.Any())
        {
            foreach (var updateObj in updateOilAnalysiss)
            {
                var obj = GetOilAnalysisById(updateObj.ID.ToString());
                if (obj != null)
                {
                    _efContext.OilAnalysiss.Attach(obj);
                    obj.AcReg = updateObj.AcReg;
                    obj.Msn = updateObj.Msn;
                    obj.FlightDate = updateObj.FlightDate;
                    obj.Pn = updateObj.Pn;
                    obj.Sn = updateObj.Sn;
                    obj.Ata = updateObj.Ata;
                    obj.Zone = updateObj.Zone;
                    obj.Position = updateObj.Position;
                    obj.Aoc3 = updateObj.Aoc3;
                    obj.Aoc7 = updateObj.Aoc7;
                    obj.Aocn = updateObj.Aocn;
                    obj.Ioc = updateObj.Ioc;
                    obj.Ioca = updateObj.Ioca;
                    obj.Iocn = updateObj.Iocn;
                    obj.Toc = updateObj.Toc;
                    obj.Tocn = updateObj.Tocn;
                    obj.Tqsr = updateObj.Tqsr;
                    obj.Tsr = updateObj.Tsr;
                    obj.WarnTag = updateObj.WarnTag;                  
                    obj.Notes = updateObj.Notes;
                }
            }
        }
      }
      
      /// <summary>
      ///     根据OilAnalysisID获取OilAnalysis
      /// </summary>
      /// <param name="id">OilAnalysis主键</param>
      /// <returns>OilAnalysis</returns>
      private OilAnalysis GetOilAnalysisById(string id)
      {
          int key = Int16.Parse(id);
          return _efContext == null ? null : _efContext.OilAnalysiss.FirstOrDefault(p => p.ID == key);
      }
   }
}
