using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Model;
using UniCloud.Domain.Repositories.EntityFramework;

namespace UniCloud.Domain.Repositories.Repositories
{
    public class PartsMonitorRepository : EntityFrameworkIntRepository<PartsMonitor>, IPartsMonitorRepository
    {
        private readonly ComponentDbContext _efContext;

        public PartsMonitorRepository(IRepositoryContext context)
            : base(context)
        {
            _efContext = EFContext.Context as ComponentDbContext;
        }
        /// <summary>
        /// 实现对PartsMonitor的增删改。
        /// 需要添加的PartsMonitor对象集合
        /// 需要删除的PartsMonitor的ID集合
        /// 需要更新的PartsMonitor对象集合
        /// <returns>执行后的更改结果</returns>
        /// </summary>
      public void CommitPartsMonitor(List<PartsMonitor> addPartsMonitors,  IEnumerable<string> deleteIds,  List<PartsMonitor> updatePartsMonitors)
        {
            AddPartsMonitors(addPartsMonitors);
            DeletePartsMonitors(deleteIds);
            UpdatePartsMonitors(updatePartsMonitors);
            _efContext.SaveChanges();
        }

        /// <summary>
        /// 增加PartsMonitor
        /// </summary>
        /// <param name="addPartsMonitors">PartsMonitor</param>
        private void AddPartsMonitors(List<PartsMonitor> addPartsMonitors)
        {
            if (addPartsMonitors != null && addPartsMonitors.Any())
            {
                addPartsMonitors.ForEach(p =>
                {
                    for (int i = p.PartsMonitorDetails.Count - 1; i >= 0; i--)
                    {
                        var partsDetail = p.PartsMonitorDetails.ElementAt(i);
                        _efContext.Entry(partsDetail).State = EntityState.Added;
                    }
                    _efContext.Entry(p).State = EntityState.Added;
                });
            }
        }

        /// <summary>
        /// 删除PartsMonitor
        /// </summary>
        /// <param name="deleteIds">删除PartsMonitor</param>
        private void DeletePartsMonitors(IEnumerable<string> deleteIds)
        {
            if (deleteIds != null)
            {
                foreach (string id in deleteIds)
                {
                    var result = GetPartsMonitorById(id);
                    if (result != null)
                    {
                        for (int i = result.PartsMonitorDetails.Count - 1; i >= 0; i--)
                        {
                            var partsDetail = result.PartsMonitorDetails.ElementAt(i);
                            _efContext.Entry(partsDetail).State = EntityState.Deleted;
                        }
                        _efContext.Entry(result).State = EntityState.Deleted;
                    }
                }
            }
        }

        /// <summary>
        ///     更新PartsMonitor
        /// </summary>
        /// <param name="updatePartsMonitors">更新的PartsMonitor</param>
        private void UpdatePartsMonitors(List<PartsMonitor> updatePartsMonitors)
        {
            if (updatePartsMonitors != null && updatePartsMonitors.Any())
            {
                foreach (var updateObj in updatePartsMonitors)
                {
                    var obj = GetPartsMonitorById(updateObj.ID.ToString());
                    if (obj != null)
                    {
                        _efContext.PartsMonitors.Attach(obj);
                        #region 更新PartsMonitor内容
                        obj.ExpireDate = updateObj.ExpireDate;                   
                        obj.ItemNo = updateObj.ItemNo;                        
                        obj.NhItemNo = updateObj.ItemNo;
                        obj.PnRegID = updateObj.PnRegID;                        
                        obj.PolicyExec = updateObj.PolicyExec;
                        obj.RemainTime = updateObj.RemainTime;
                        obj.Snreg = null;
                        obj.SnRegID = updateObj.SnRegID;
                        obj.UsedTime = updateObj.UsedTime;
                        obj.Workscope = updateObj.Workscope;
                        
                        #endregion

                        #region 更新PartsMonitorDetail内容
                        for (int i = obj.PartsMonitorDetails.Count - 1; i >= 0; i--)
                        {
                            var partDetail = obj.PartsMonitorDetails.ElementAt(i);
                            if (updateObj.PartsMonitorDetails.FirstOrDefault(p => p.ID == partDetail.ID || (p.SnRegID == partDetail.SnRegID && p.Ieam == partDetail.Ieam && p.Workscope == partDetail.Workscope && p.Unit == partDetail.Unit)) == null)
                            {
                                _efContext.Entry(partDetail).State = EntityState.Deleted;
                            }
                               
                        }
                        foreach (var pmDetail in updateObj.PartsMonitorDetails)
                        {
                            var pmd = obj.PartsMonitorDetails.FirstOrDefault(p => p.ID == pmDetail.ID || (p.SnRegID == pmDetail.SnRegID && p.Ieam == pmDetail.Ieam && p.Workscope == pmDetail.Workscope && p.Unit == pmDetail.Unit));
                            if (pmd != null)
                            {
                                pmd.ExpireDate = pmDetail.ExpireDate;
                                pmd.Ieam = pmDetail.Ieam;
                                pmd.Interval = pmDetail.Interval;
                                pmd.ItemNo = pmDetail.ItemNo;
                                //pmd.PartsMonitorID = pmDetail.PartsMonitorID;
                                pmd.PnRegID = pmDetail.PnRegID;
                                pmd.Remain = pmDetail.Remain;
                                pmd.SnRegID = pmDetail.SnRegID;                                
                                pmd.Unit = pmDetail.Unit;
                                pmd.Used = pmDetail.Used;
                                pmd.Utiliza = pmDetail.Utiliza;
                                pmd.Workscope = pmDetail.Workscope;
                            }
                            else
                            {
                                pmDetail.PartsMonitorID = updateObj.ID;
                                _efContext.Entry(pmDetail).State = EntityState.Added;
                            }
                        } 
                        #endregion
                    }
                }
            }
        }

        /// <summary>
        ///     根据PartsMonitorID获取PartsMonitor
        /// </summary>
        /// <param name="id">PartsMonitor主键</param>
        /// <returns>PartsMonitor</returns>
        private PartsMonitor GetPartsMonitorById(string id)
        {
            var value = Convert.ToInt32(id);
            return _efContext == null ? null : _efContext.PartsMonitors.Include("PartsMonitorDetails").FirstOrDefault(p => p.ID == value);
        }
    }
}
