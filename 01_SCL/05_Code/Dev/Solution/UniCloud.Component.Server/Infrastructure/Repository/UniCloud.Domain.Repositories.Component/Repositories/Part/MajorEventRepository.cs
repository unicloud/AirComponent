#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/16 16:16:39

// 文件名：MajorEventRepository
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
    public class MajorEventRepository : EntityFrameworkIntRepository<MajorEvent>, IMajorEventRepository
    {
        private readonly ComponentDbContext _efContext;

        public MajorEventRepository(IRepositoryContext context)
            : base(context)
        {
            _efContext = EFContext.Context as ComponentDbContext;
        }
        /// <summary>
        /// 实现对MajorEvent的增删改。
        /// 需要添加的MajorEvent对象集合
        /// 需要删除的MajorEvent的ID集合
        /// 需要更新的MajorEvent对象集合
        /// <returns>执行后的更改结果</returns>
        /// </summary>
        public void CommitMajorEvent(List<MajorEvent> addMajorEvents, IEnumerable<string> deleteIds, List<MajorEvent> updateMajorEvents)
        {
            AddMajorEvents(addMajorEvents);
            DeleteMajorEvents(deleteIds);
            UpdateMajorEvents(updateMajorEvents);
            _efContext.SaveChanges();
        }

        /// <summary>
        /// 增加MajorEvent
        /// </summary>
        /// <param name="addMajorEvents">MajorEvent</param>
        private void AddMajorEvents(List<MajorEvent> addMajorEvents)
        {
            if (addMajorEvents != null && addMajorEvents.Any())
            {
                addMajorEvents.ForEach(p =>
                {
                    _efContext.Entry(p).State = EntityState.Added;
                });
            }
        }

        /// <summary>
        /// 删除MajorEvent
        /// </summary>
        /// <param name="deleteIds">删除MajorEvent</param>
        private void DeleteMajorEvents(IEnumerable<string> deleteIds)
        {
            if (deleteIds != null)
            {
                foreach (var id in deleteIds)
                {
                    var result = GetMajorEventById(id.ToString());
                    if (result != null)
                    {
                        _efContext.Entry(result).State = EntityState.Deleted;
                    }
                }
            }
        }

        /// <summary>
        ///     更新MajorEvent
        /// </summary>
        /// <param name="updateMajorEvents">更新的MajorEvent</param>
        private void UpdateMajorEvents(List<MajorEvent> updateMajorEvents)
        {
            if (updateMajorEvents != null && updateMajorEvents.Any())
            {
                foreach (var updateObj in updateMajorEvents)
                {
                    var obj = GetMajorEventById(updateObj.ID.ToString());
                    if (obj != null)
                    {
                        _efContext.MajorEvents.Attach(obj);
                        obj.Ac = updateObj.Ac;
                        obj.CloseDate = updateObj.CloseDate;
                        obj.CloseReason = updateObj.CloseReason;
                        obj.CreateDate = updateObj.CreateDate;
                        obj.Description = updateObj.Description;
                        obj.Pos = updateObj.Pos;
                        obj.Property = updateObj.Property;
                        obj.Sn = updateObj.Sn;
                    }
                }
            }
        }

        /// <summary>
        ///     根据MajorEventID获取MajorEvent
        /// </summary>
        /// <param name="id">MajorEvent主键</param>
        /// <returns>MajorEvent</returns>
        private MajorEvent GetMajorEventById(string id)
        {
            int value = Convert.ToInt32(id);
            return _efContext == null ? null : _efContext.MajorEvents.FirstOrDefault(p => p.ID == value);
        }
    }
}
