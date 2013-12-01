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
    public class ScnMainRepository :EntityFrameworkIntRepository<ScnMain> , IScnMainRepository
    {
        private readonly ComponentDbContext _efContext;

        public ScnMainRepository(IRepositoryContext context)
            : base(context)
        {
            _efContext = EFContext.Context as ComponentDbContext;
        }
        /// <summary>
        /// 实现对ScnMain的增删改。
        /// 需要添加的ScnMain对象集合
        /// 需要删除的ScnMain的ID集合
        /// 需要更新的ScnMain对象集合
        /// <returns>执行后的更改结果</returns>
        /// </summary>
      public void CommitScnMain(List<ScnMain> addScnMains,  IEnumerable<string> deleteIds,  List<ScnMain> updateScnMains)
        {
            AddScnMains(addScnMains);
            DeleteScnMains(deleteIds);
            UpdateScnMains(updateScnMains);
            _efContext.SaveChanges();
        }

        /// <summary>
        /// 增加ScnMain
        /// </summary>
        /// <param name="addScnMains">ScnMain</param>
        private void AddScnMains(List<ScnMain> addScnMains)
        {
            if (addScnMains != null && addScnMains.Any())
            {
                addScnMains.ForEach(p =>
                {
                    for (int i = p.ScnAcorders.Count - 1; i >= 0; i--)
                    {
                        var scnacorder = p.ScnAcorders.ElementAt(i);
                        _efContext.Entry(scnacorder).State = EntityState.Added;
                    }
                    for (int i = p.ScnItems.Count - 1; i >= 0; i--)
                    {
                        var scnitem = p.ScnItems.ElementAt(i);
                        _efContext.Entry(scnitem).State = EntityState.Added;
                    }
                    _efContext.Entry(p).State = EntityState.Added;
                });
            }
        }

        /// <summary>
        /// 删除ScnMain
        /// </summary>
        /// <param name="deleteIds">删除ScnMain</param>
        private void DeleteScnMains(IEnumerable<string> deleteIds)
        {
            if (deleteIds != null)
            {
                foreach (string id in deleteIds)
                {
                    var result = GetScnMainById(id);
                    if (result != null)
                    {
                        for (int i = result.ScnAcorders.Count - 1; i >= 0; i--)
                        {
                            var scnacorder = result.ScnAcorders.ElementAt(i);
                            _efContext.Entry(scnacorder).State = EntityState.Deleted;
                        }
                        for (int i = result.ScnItems.Count - 1; i >= 0; i--)
                        {
                            var scnitem = result.ScnItems.ElementAt(i);
                            _efContext.Entry(scnitem).State = EntityState.Deleted;
                        }
                        _efContext.Entry(result).State = EntityState.Deleted;
                    }
                }
            }
        }

        /// <summary>
        ///     更新ScnMain
        /// </summary>
        /// <param name="updateScnMains">更新的ScnMain</param>
        private void UpdateScnMains(List<ScnMain> updateScnMains)
        {
            if (updateScnMains != null && updateScnMains.Any())
            {
                foreach (var updateObj in updateScnMains)
                {
                    var obj = GetScnMainById(updateObj.ID.ToString());
                    if (obj != null)
                    {
                       // _efContext.ScnMains.Attach(obj);
                        #region 更新ScnMain内容
                        obj.AcModelGuid = updateObj.AcModelGuid;
                        obj.AcModelID = updateObj.AcModelID;
                        obj.AcTypeGuid = updateObj.AcTypeGuid;
                        obj.AcTypeID = updateObj.AcTypeID;
                        obj.Description = updateObj.Description == null ? obj.Description : updateObj.Description;
                        obj.ScnNo = updateObj.ScnNo == null ? obj.ScnNo : updateObj.ScnNo;
                        obj.State = updateObj.State == null ? obj.State : updateObj.State;
                        obj.Version = updateObj.Version == null ? obj.Version : updateObj.Version;
                        obj.ScnTitle = updateObj.ScnTitle == null ? obj.ScnTitle : updateObj.ScnTitle;
                        obj.ScnType = updateObj.ScnType == null ? obj.ScnType : updateObj.ScnType;
                        obj.ModName = updateObj.ModName == null ? obj.ModName : updateObj.ModName;
                        obj.CloseSituation = updateObj.CloseSituation > 0 ? updateObj.CloseSituation : obj.CloseSituation;
                        obj.Amount = updateObj.Amount > 0 ? updateObj.Amount : obj.Amount;
                        obj.DocumentID = updateObj.DocumentID.HasValue ? updateObj.DocumentID : obj.DocumentID;
                        obj.Ata = updateObj.Ata == null ? obj.Ata : updateObj.Ata;
                        obj.MoneyOnMsn = updateObj.MoneyOnMsn == null ? obj.MoneyOnMsn : updateObj.MoneyOnMsn;
                        obj.Organization = updateObj.Organization == null ? obj.Organization : updateObj.Organization;
                        obj.VerifyStatus = updateObj.VerifyStatus == null ? obj.VerifyStatus : updateObj.VerifyStatus;
                        #endregion
                        
                        #region 更新ScnAcorder内容
                        for (int i = obj.ScnAcorders.Count - 1; i >= 0; i--)
                        {
                            var scnAcorder = obj.ScnAcorders.ElementAt(i);
                            if (updateObj.ScnAcorders.FirstOrDefault(s => s.ID == scnAcorder.ID) == null)
                                _efContext.Entry(scnAcorder).State = EntityState.Deleted;
                        }
                        foreach (var acorder in updateObj.ScnAcorders)
                        {
                            var aco = obj.ScnAcorders.FirstOrDefault(a => a.ID == acorder.ID);
                            if (aco != null)
                            {
                                aco.AcOrder = acorder.AcOrder;
                                aco.AcOrderItem = acorder.AcOrderItem;
                                aco.Notes = acorder.Notes;
                                aco.Price = acorder.Price;
                                aco.MSN = acorder.MSN;
                                aco.CSCNumber = acorder.CSCNumber;
                            }
                            else
                            {
                                //关联外键
                                acorder.ScnMainID = obj.ID;
                                _efContext.Entry(acorder).State = EntityState.Added;
                            }
                        } 
                        #endregion

                        #region 更新ScnItem内容
                        for (int i = obj.ScnItems.Count - 1; i >= 0; i--)
                        {
                            var scnitem = obj.ScnItems.ElementAt(i);
                            if (updateObj.ScnItems.FirstOrDefault(s => s.ID == scnitem.ID) == null)
                                _efContext.Entry(scnitem).State = EntityState.Deleted;
                        }
                        foreach (var item in updateObj.ScnItems)
                        {
                            var it = obj.ScnItems.FirstOrDefault(i => i.ID == item.ID);
                            if (it != null)
                            {
                                it.AtaGuid = item.AtaGuid;
                                it.AtaID = item.AtaID;
                                it.Currency = item.Currency;
                                it.Description = item.Description;
                                it.ItemNo = item.ItemNo;
                                it.Notes = item.Notes;
                                it.Pn = item.Pn;
                                it.PnRegID = item.PnRegID;
                                it.Price = item.Price;
                                it.PnRegID = item.PnRegID;
                                it.Qty = item.Qty;
                                it.TotalPrice = item.TotalPrice;
                                it.Vendor = item.Vendor;
                            }
                            else
                            {
                                //关联外键
                                item.ScnMainID = obj.ID;
                                _efContext.Entry(item).State = EntityState.Added;
                            }
                        } 
                        #endregion

                        //#region 更新WfHistory
                        //for (int i = obj.WfHistorys.Count - 1; i >= 0; i--)
                        //{
                        //    var wfHistory = obj.WfHistorys.ElementAt(i);
                        //    if (updateObj.WfHistorys.FirstOrDefault(s => s.ID == wfHistory.ID) == null)
                        //        _efContext.Entry(wfHistory).State = EntityState.Deleted;
                        //}
                        //foreach (var item in updateObj.WfHistorys)
                        //{
                        //    var it = obj.WfHistorys.FirstOrDefault(i => i.ID == item.ID);
                        //    if (it != null)
                        //    {
                        //        it.AuditNotes = item.AuditNotes == null ? it.AuditNotes : item.AuditNotes;
                        //        it.Auditor = item.Auditor == null ? it.Auditor : item.Auditor;
                        //        it.AuditTime = item.AuditTime;
                        //        it.Business = item.Business == null ? it.Business : item.Business;
                        //        it.Department = item.Department == null ? it.Department : item.Department;
                        //        it.Description = item.Description == null ? it.Description : item.Description;
                        //        it.BusinessID = item.BusinessID > 0 ? item.BusinessID : it.BusinessID;
                        //        it.Result = item.Result == null ? it.Result : item.Result;
                        //        it.Seq = item.Seq == null ? it.Seq : item.Seq;
                        //    }
                        //    else
                        //    {
                        //        //关联外键
                        //        //item.ScnMainID = obj.ID;
                        //        _efContext.Entry(item).State = EntityState.Added;
                        //    }
                        //} 
                        //#endregion
                    }
                }
            }
        }

        /// <summary>
        ///     根据ScnMainID获取ScnMain
        /// </summary>
        /// <param name="id">ScnMain主键</param>
        /// <returns>ScnMain</returns>
        private ScnMain GetScnMainById(string id)
        {
            int value = Convert.ToInt32(id);
            return _efContext == null ? null : _efContext.ScnMains.FirstOrDefault(p => p.ID== value);
        }
    }
}
