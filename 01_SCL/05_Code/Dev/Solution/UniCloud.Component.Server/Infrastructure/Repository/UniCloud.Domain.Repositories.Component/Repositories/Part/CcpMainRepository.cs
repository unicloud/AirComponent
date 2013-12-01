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
    public class CcpMainRepository : EntityFrameworkIntRepository<CcpMain>, ICcpMainRepository
    {
        private readonly ComponentDbContext _efContext;

        public CcpMainRepository(IRepositoryContext context)
            : base(context)
        {
            _efContext = EFContext.Context as ComponentDbContext;
        }
        /// <summary>
        /// 实现对CcpMain的增删改。
        /// 需要添加的CcpMain对象集合
        /// 需要删除的CcpMain的ID集合
        /// 需要更新的CcpMain对象集合
        /// <returns>执行后的更改结果</returns>
        /// </summary>
        public void CommitCcpMain(List<CcpMain> addCcpMains, IEnumerable<string> deleteIds, List<CcpMain> updateCcpMains)
        {
            AddCcpMains(addCcpMains);
            DeleteCcpMains(deleteIds);
            UpdateCcpMains(updateCcpMains);
            _efContext.SaveChanges();
        }

        /// <summary>
        /// 增加CcpMain
        /// </summary>
        /// <param name="addCcpMains">CcpMain</param>
        private void AddCcpMains(List<CcpMain> addCcpMains)
        {
            if (addCcpMains != null && addCcpMains.Any())
            {
                addCcpMains.ForEach(p =>
                {
                    for (int i = p.CcpLimits.Count - 1; i >= 0; i--)
                    {
                        _efContext.Entry(p.CcpLimits.ElementAt(i)).State = EntityState.Added;
                    }
                    for (int i = p.CcpPns.Count - 1; i >= 0; i--)
                    {
                        _efContext.Entry(p.CcpPns.ElementAt(i)).State = EntityState.Added;
                    }
                    _efContext.Entry(p).State = EntityState.Added;
                });
            }
        }

        /// <summary>
        /// 删除CcpMain
        /// </summary>
        /// <param name="deleteIds">删除CcpMain</param>
        private void DeleteCcpMains(IEnumerable<string> deleteIds)
        {
            if (deleteIds != null)
            {
                foreach (string id in deleteIds)
                {
                    var result = GetCcpMainById(id);
                    if (result != null)
                    {
                        for (int i = result.CcpLimits.Count - 1; i >= 0; i--)
                        {
                            _efContext.Entry(result.CcpLimits.ElementAt(i)).State = EntityState.Deleted;
                        }
                        for (int i = result.CcpPns.Count - 1; i >= 0; i--)
                        {
                            _efContext.Entry(result.CcpPns.ElementAt(i)).State = EntityState.Deleted;
                        }
                        _efContext.Entry(result).State = EntityState.Deleted;
                    }
                }
            }
        }

        /// <summary>
        ///     更新CcpMain
        /// </summary>
        /// <param name="updateCcpMains">更新的CcpMain</param>
        private void UpdateCcpMains(List<CcpMain> updateCcpMains)
        {
            if (updateCcpMains != null && updateCcpMains.Any())
            {
                foreach (var updateObj in updateCcpMains)
                {
                    var obj = GetCcpMainById(updateObj.ID.ToString());
                    if (obj != null)
                    {
                        _efContext.CcpMains.Attach(obj);
                        #region 更新CcpMain内容
                        obj.ItemNo = updateObj.ItemNo;
                        obj.AcType = updateObj.AcType;
                        obj.Ata = updateObj.Ata;
                        obj.Description = updateObj.Description;
                        obj.IsLife = updateObj.IsLife;
                        obj.Version = updateObj.Version;
                        obj.State = updateObj.State;
                        obj.NhItemNo = updateObj.NhItemNo;
                        obj.Updateby = updateObj.Updateby;
                        obj.UpdateTime = updateObj.UpdateTime; 
                        #endregion

                        #region 更新CcpLimit内容
                        for (int i = obj.CcpLimits.Count - 1; i >= 0; i--)
                        {
                            var ccpLimit = obj.CcpLimits.ElementAt(i);
                            if (updateObj.CcpLimits.FirstOrDefault(c => c.ID == ccpLimit.ID) == null)
                                _efContext.Entry(ccpLimit).State = EntityState.Deleted;
                        }
                        var addList = new List<CcpLimit>();
                        foreach (var ccpLimit in updateObj.CcpLimits)
                        {
                            var ccplimit = obj.CcpLimits.FirstOrDefault(c => c.ID == ccpLimit.ID);
                            if (ccplimit != null)
                            {
                                ccplimit.Ieam = ccpLimit.Ieam;
                                ccplimit.RangeMax = ccpLimit.RangeMax;
                                ccplimit.RangeMin = ccpLimit.RangeMin;
                                ccplimit.ControlType = ccpLimit.ControlType;
                                ccplimit.ControlNo = ccpLimit.ControlNo;
                                ccplimit.EngineTli = ccpLimit.EngineTli;
                                ccplimit.Unit = ccpLimit.Unit;
                                ccplimit.Interval = ccpLimit.Interval;
                                ccplimit.ControlGroup = ccpLimit.ControlGroup;
                                ccplimit.RangeType = ccpLimit.RangeType;
                                ccplimit.WorkScope = ccpLimit.WorkScope;
                                ccplimit.WorkScopeID = ccpLimit.WorkScopeID;
                                ccplimit.PolicyExec = ccpLimit.PolicyExec;
                                ccplimit.Source = ccpLimit.Source;
                                ccplimit.Notes = ccpLimit.Notes;
                            }
                            else
                            {
                                ccpLimit.CcpMainID = obj.ID;
                                addList.Add(ccpLimit);
                            }
                            addList.ForEach(p => _efContext.Entry(p).State = EntityState.Added);
                        } 
                        #endregion

                        #region 更新CcpPn内容
                        for (int i = obj.CcpPns.Count - 1; i >= 0; i--)
                        {
                            var ccpPn = obj.CcpPns.ElementAt(i);
                            if (updateObj.CcpPns.FirstOrDefault(c => c.ID == ccpPn.ID) == null)
                                _efContext.Entry(ccpPn).State = EntityState.Deleted;
                        }
                        var addPnList = new List<CcpPn>();
                        foreach (var ccpPn in updateObj.CcpPns)
                        {
                            var ccppn = obj.CcpPns.FirstOrDefault(c => c.ID == ccpPn.ID);
                            if (ccppn != null)
                            {
                                ccppn.Pn = ccpPn.Pn;
                                ccppn.SpecPn = ccpPn.SpecPn;
                                ccppn.Acmodel = ccpPn.Acmodel;
                                ccppn.Acconfig = ccpPn.Acconfig;
                                ccppn.AcRegs = ccpPn.AcRegs;
                                ccppn.Notes = ccpPn.Notes;
                                ccppn.Ieam = ccpPn.Ieam;
                                ccppn.Qty = ccpPn.Qty;
                                ccppn.Sns = ccpPn.Sns;
                                ccppn.PnRegID = ccpPn.PnRegID;
                                // ccppn.CcpMainID = ccpPn.CcpMainID;
                            }
                            else
                            {
                                ccppn.CcpMainID = obj.ID;
                                addPnList.Add(ccpPn);                                
                            }
                            addPnList.ForEach(p => _efContext.Entry(p).State = EntityState.Added);
                        } 
                        #endregion
                    }
                }
            }
        }

        /// <summary>
        ///     根据CcpMainID获取CcpMain
        /// </summary>
        /// <param name="id">CcpMain主键</param>
        /// <returns>CcpMain</returns>
        private CcpMain GetCcpMainById(string id)
        {
            var value = Convert.ToInt32(id);
            return _efContext == null ? null : _efContext.CcpMains.FirstOrDefault(p => p.ID == value);
        }

        public void DeleteCcpMain(CcpMain ccpMain)
        {
            if (ccpMain == null)
                return;
            for (int i = ccpMain.CcpLimits.Count - 1; i >= 0; i--)
            {
                this.DoEntityRegisterDeleted(ccpMain.CcpLimits.ElementAt(i));
            }
            for (int i = ccpMain.CcpPns.Count - 1; i >= 0; i--)
            {
                this.DoEntityRegisterDeleted(ccpMain.CcpPns.ElementAt(i));
            }
            this.Remove(ccpMain);
            this.Context.Commit();
        }

        public void DeleteCcpLimit(CcpMain ccpMain, IEnumerable<CcpLimit> ccpLimits)
        {
            if (ccpMain == null || ccpMain.CcpLimits == null || ccpLimits == null)
                return;
            for (int i = ccpMain.CcpLimits.Count-1; i >= 0; i--)
            {
                if (ccpLimits.FirstOrDefault(c => c.ID == ccpMain.CcpLimits.ElementAt(i).ID) != null)
                {
                    this.DoEntityRegisterDeleted(ccpMain.CcpLimits.ElementAt(i));
                }
            }
            this.Update(ccpMain);
            this.Context.Commit();
        }

        public void DeleteCcpPn(CcpMain ccpMain, IEnumerable<CcpPn> ccpPns)
        {
            if (ccpMain == null || ccpMain.CcpPns == null || ccpPns == null)
                return;
            for (int i = ccpMain.CcpPns.Count - 1; i >= 0; i--)
            {
                if (ccpPns.FirstOrDefault(c => c.ID == ccpMain.CcpPns.ElementAt(i).ID) != null)
                {
                    this.DoEntityRegisterDeleted(ccpMain.CcpPns.ElementAt(i));
                }
            }
            this.Update(ccpMain);
            this.Context.Commit();
        }
    }
}
