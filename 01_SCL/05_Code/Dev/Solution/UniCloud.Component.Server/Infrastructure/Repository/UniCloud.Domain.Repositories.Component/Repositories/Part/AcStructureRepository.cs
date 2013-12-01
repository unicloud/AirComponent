#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/19 15:38:44

// 文件名：AcStructureRepository
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
    public class AcStructureRepository : EntityFrameworkIntRepository<AcStructure>, IAcStructureRepository
    {
        private readonly ComponentDbContext _efContext;

        public AcStructureRepository(IRepositoryContext context)
            : base(context)
        {
            _efContext = EFContext.Context as ComponentDbContext;
        }
        /// <summary>
        /// 实现对AcStructure的增删改。
        /// 需要添加的AcStructure对象集合
        /// 需要删除的AcStructure的ID集合
        /// 需要更新的AcStructure对象集合
        /// <returns>执行后的更改结果</returns>
        /// </summary>
        public void CommitAcStructure(List<AcStructure> addAcStructures, IEnumerable<string> deleteIds, List<AcStructure> updateAcStructures)
        {
            AddAcStructures(addAcStructures);
            DeleteAcStructures(deleteIds);
            UpdateAcStructures(updateAcStructures);
            _efContext.SaveChanges();
        }

        /// <summary>
        /// 增加AcStructure
        /// </summary>
        /// <param name="addAcStructures">AcStructure</param>
        private void AddAcStructures(List<AcStructure> addAcStructures)
        {
            if (addAcStructures != null && addAcStructures.Any())
            {
                addAcStructures.ForEach(p =>
                {
                    _efContext.Entry(p).State = EntityState.Added;
                });
            }
        }

        /// <summary>
        /// 删除AcStructure
        /// </summary>
        /// <param name="deleteIds">删除AcStructure</param>
        private void DeleteAcStructures(IEnumerable<string> deleteIds)
        {
            if (deleteIds != null)
            {
                foreach (var id in deleteIds)
                {
                    var result = GetAcStructureById(id.ToString());
                    if (result != null)
                    {
                        _efContext.Entry(result).State = EntityState.Deleted;
                    }
                }
            }
        }

        /// <summary>
        ///     更新AcStructure
        /// </summary>
        /// <param name="updateAcStructures">更新的AcStructure</param>
        private void UpdateAcStructures(List<AcStructure> updateAcStructures)
        {
            if (updateAcStructures != null && updateAcStructures.Any())
            {
                foreach (var updateObj in updateAcStructures)
                {
                    var obj = GetAcStructureById(updateObj.ID.ToString());
                    if (obj != null)
                    {
                        _efContext.AcStructures.Attach(obj);
                        obj.Actype = string.IsNullOrWhiteSpace(updateObj.Actype) ? obj.Actype : updateObj.Actype;
                        obj.Acmodel = string.IsNullOrWhiteSpace(updateObj.Acmodel) ?
                            obj.Acmodel : updateObj.Acmodel;
                        obj.Acreg = string.IsNullOrWhiteSpace(updateObj.Acreg) ?
                            obj.Acreg : updateObj.Acreg;
                        obj.Description = string.IsNullOrWhiteSpace(updateObj.Description) ?
                            obj.Description : updateObj.Description;
                        obj.CloseDate = updateObj.CloseDate.HasValue ? updateObj.CloseDate : obj.CloseDate;
                        obj.IsDefer = string.IsNullOrWhiteSpace(updateObj.IsDefer) ? obj.IsDefer : updateObj.IsDefer;
                        obj.Level = string.IsNullOrWhiteSpace(updateObj.Level) ? obj.Level : updateObj.Level;
                        obj.RepairDeadline = string.IsNullOrWhiteSpace(updateObj.RepairDeadline) ?
                           obj.RepairDeadline : updateObj.RepairDeadline;
                        obj.ReportDate = updateObj.ReportDate.HasValue ? updateObj.ReportDate : obj.ReportDate;
                        obj.ReportNo = string.IsNullOrWhiteSpace(updateObj.ReportNo) ? obj.ReportNo : updateObj.ReportNo;
                        obj.ReportType = string.IsNullOrWhiteSpace(updateObj.ReportType) ? obj.ReportType : updateObj.ReportType;
                        obj.Source = string.IsNullOrWhiteSpace(updateObj.Source) ?
                           obj.Source : updateObj.Source;
                        obj.Status = string.IsNullOrWhiteSpace(updateObj.Status) ? obj.Status : updateObj.Status;
                        obj.TecAss = string.IsNullOrWhiteSpace(updateObj.TecAss) ? obj.TecAss : updateObj.TecAss;
                        obj.TreatResult = string.IsNullOrWhiteSpace(updateObj.TreatResult) ?
                           obj.TreatResult : updateObj.TreatResult;
                    }
                }
            }
        }

        /// <summary>
        ///     根据AcStructureID获取AcStructure
        /// </summary>
        /// <param name="id">AcStructure主键</param>
        /// <returns>AcStructure</returns>
        private AcStructure GetAcStructureById(string id)
        {
            int key = Convert.ToInt32(id);
            return _efContext == null ? null : _efContext.AcStructures.FirstOrDefault(p => p.ID == key);
        }
    }
}
