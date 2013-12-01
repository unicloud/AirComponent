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
    public class CcOrderRepository : EntityFrameworkIntRepository<CcOrder>, ICcOrderRepository
    {
        private readonly ComponentDbContext _efContext;

        public CcOrderRepository(IRepositoryContext context)
            : base(context)
        {
            _efContext = EFContext.Context as ComponentDbContext;
        }
        /// <summary>
        /// 实现对CcOrder的增删改。
        /// 需要添加的CcOrder对象集合
        /// 需要删除的CcOrder的ID集合
        /// 需要更新的CcOrder对象集合
        /// <returns>执行后的更改结果</returns>
        /// </summary>
      public void CommitCcOrder(List<CcOrder> addCcOrders,  IEnumerable<string> deleteIds,  List<CcOrder> updateCcOrders)
        {
            AddCcOrders(addCcOrders);
            DeleteCcOrders(deleteIds);
            UpdateCcOrders(updateCcOrders);
            _efContext.SaveChanges();
        }

        /// <summary>
        /// 增加CcOrder
        /// </summary>
        /// <param name="addCcOrders">CcOrder</param>
        private void AddCcOrders(List<CcOrder> addCcOrders)
        {
            if (addCcOrders != null && addCcOrders.Any())
            {
                addCcOrders.ForEach(p =>
                {
                    for (int i = p.Ccouts.Count - 1; i >= 0; i--)
                    {
                        var ccout = p.Ccouts.ElementAt(i);
                        _efContext.Entry(ccout).State = EntityState.Added;
                    }
                    for (int i = p.Ccins.Count - 1; i >= 0; i--)
                    {
                        var ccin = p.Ccins.ElementAt(i);
                        _efContext.Entry(ccin).State = EntityState.Added;
                    }
                    _efContext.Entry(p).State = EntityState.Added;
                });
            }
        }

        /// <summary>
        /// 删除CcOrder
        /// </summary>
        /// <param name="deleteIds">删除CcOrder</param>
        private void DeleteCcOrders(IEnumerable<string> deleteIds)
        {
            if (deleteIds != null)
            {
                foreach (string id in deleteIds)
                {
                    var result = GetCcOrderById(id);
                    if (result != null)
                    {
                        for (int i = result.Ccouts.Count - 1; i >= 0; i--)
                        {
                            var ccout = result.Ccouts.ElementAt(i);
                            _efContext.Entry(ccout).State = EntityState.Deleted;
                        }
                        for (int i = result.Ccins.Count - 1; i >= 0; i--)
                        {
                            var ccin = result.Ccins.ElementAt(i);
                            _efContext.Entry(ccin).State = EntityState.Deleted;
                        }
                        _efContext.Entry(result).State = EntityState.Deleted;
                    }
                }
            }
        }

        /// <summary>
        ///     更新CcOrder
        /// </summary>
        /// <param name="updateCcOrders">更新的CcOrder</param>
        private void UpdateCcOrders(List<CcOrder> updateCcOrders)
        {
            if (updateCcOrders != null && updateCcOrders.Any())
            {
                foreach (var updateObj in updateCcOrders)
                {
                    var obj = GetCcOrderById(updateObj.ID.ToString());
                    if (obj != null)
                    {
                        _efContext.CcOrders.Attach(obj);

                        #region 更改CcOrder内容

                        obj.AcReg = updateObj.AcReg;                        
                        obj.Cctype = updateObj.Cctype;
                        obj.OrderNo = updateObj.OrderNo;
                        obj.RemReason = updateObj.RemReason;
                        obj.State = updateObj.State;
                        obj.SwapAcreg = updateObj.SwapAcreg;
                        obj.UpdateBy = updateObj.UpdateBy;
                        obj.WoItem = updateObj.WoItem;
                        obj.WoNo = updateObj.WoNo;
                        obj.WoType = updateObj.WoType;
                        obj.Operator = updateObj.Operator;
                        obj.OperatDate = updateObj.OperatDate;
                        obj.UpdateDate = updateObj.UpdateDate;

                        #endregion

                        #region 更新CcOut内容

                        for (int i = obj.Ccouts.Count - 1; i >= 0; i--)
                        {
                            var ccout = obj.Ccouts.ElementAt(i);
                            if (updateObj.Ccouts.FirstOrDefault(c => c.ID == ccout.ID) == null)
                                _efContext.Entry(ccout).State = EntityState.Deleted;
                        }
                        foreach (var ccout in updateObj.Ccouts)
                        {
                            var cCout = obj.Ccouts.FirstOrDefault(c => c.ID == ccout.ID);
                            if (cCout != null)
                            {
                                cCout.Position = ccout.Position;
                                cCout.Ata = ccout.Ata;
                                cCout.NhSnRegID = ccout.NhSnRegID;
                                cCout.PnRegID = ccout.PnRegID;
                                cCout.RootSnRegID = ccout.RootSnRegID;
                                cCout.Seq = ccout.Seq;
                                cCout.SnRegID = ccout.SnRegID;
                                cCout.Zone = ccout.Zone;
                                cCout.UnScheduled = ccout.UnScheduled;
                            }
                            else
                            {
                                ccout.CcOrderID = obj.ID;
                                _efContext.Entry(ccout).State = EntityState.Added;
                            }
                        }

                        #endregion

                        #region 更新CcIn内容

                        for (int i = obj.Ccins.Count - 1; i >= 0; i--)
                        {
                            var ccin = obj.Ccins.ElementAt(i);
                            if (updateObj.Ccins.FirstOrDefault(c => c.ID == ccin.ID) == null)
                                _efContext.Entry(ccin).State = EntityState.Deleted;
                        }
                        foreach (var ccin in updateObj.Ccins)
                        {
                            var cCin = obj.Ccins.FirstOrDefault(c => c.ID == ccin.ID);
                            if (cCin != null)
                            {
                                cCin.Position = ccin.Position;
                                cCin.Propertys = ccin.Propertys;
                                cCin.Ata = ccin.Ata;
                                cCin.NhSnRegID = ccin.NhSnRegID;
                                cCin.PnRegID = ccin.PnRegID;
                                cCin.RootSnRegID = ccin.RootSnRegID;
                                cCin.Seq = ccin.Seq;
                                cCin.SnRegID = ccin.SnRegID;
                                cCin.Zone = ccin.Zone;
                                cCin.EngineTli = ccin.EngineTli;
                            }
                            else
                            {
                                ccin.CcOrderID = obj.ID;
                                _efContext.Entry(ccin).State = EntityState.Added;
                            }
                        }

                        #endregion
                    }
                }
            }
        }

        /// <summary>
        ///     根据CcOrderID获取CcOrder
        /// </summary>
        /// <param name="id">CcOrder主键</param>
        /// <returns>CcOrder</returns>
        private CcOrder GetCcOrderById(string id)
        {
            var value = Convert.ToInt32(id);
            return _efContext == null ? null : _efContext.CcOrders.FirstOrDefault(p => p.ID == value);
        }
    }
}
