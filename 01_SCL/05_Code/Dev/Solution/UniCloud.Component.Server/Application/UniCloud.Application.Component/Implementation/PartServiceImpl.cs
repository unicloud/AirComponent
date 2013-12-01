using System.Collections.ObjectModel;
using System.Data.Entity.Validation;
using System.Linq.Expressions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ObjectBuilder2;
using UniCloud.DataObjects;
using UniCloud.Domain.Model;
using UniCloud.Domain.Repositories;
using UniCloud.Domain.Specifications;
using UniCloud.ServiceContracts;
using SortOrder = UniCloud.Domain.Repositories.SortOrder;
using UniCloud.Query;
using UniCloud.Domain.Repositories.EntityFramework;

namespace UniCloud.Application.Implementation
{
    public class PartServiceImpl : ApplicationService, IPartService
    {
        #region Private Fields
        private readonly ICcOrderRepository _ccOrderRepository;
        private readonly ICcpMainRepository _ccpMainRepository;
        private readonly IIntUnitRepository _intUnitRepository;
        private readonly IOilHistoryRepository _oilHistoryRepository;
        private readonly IPartsMonitorRepository _partsMonitorRepository;
        private readonly IPnRegRepository _pnRegRepository;
        private readonly IScnMainRepository _scnMainRepository;
        private readonly ISnRegRepository _snRegRepository;
        private readonly ISnHistoryRepository _snHistoryRepository;
        private readonly IWfHistoryRepository _wfHistoryRepository;
        private readonly IWorkScopeRepository _workScopeRepository;
        //查询接口
        private readonly IComponentQuery _componentQuery;

        private readonly UniCloud.Domain.Repositories.EntityFramework.AircraftDbContext _aricraftContext =
            new Domain.Repositories.EntityFramework.AircraftDbContext();
        #endregion

        #region Ctor

        public PartServiceImpl(IRepositoryContext context,
                               IUniCloudDbContext uniCloudDbContext,
                               ICcOrderRepository ccOrderRepository,
                               ICcpMainRepository ccpMainRepository,
                               IIntUnitRepository intUnitRepository,
                               IOilHistoryRepository oilHistoryRepository,
                               IPartsMonitorRepository partsMonitorRepository,
                               IPnRegRepository pnRegRepository,
                               IScnMainRepository scnMainRepository,
                               ISnRegRepository snRegRepository,
                               ISnHistoryRepository snHistoryRepository,
                               IWfHistoryRepository wfHistoryRepository,
                               IWorkScopeRepository workScopeRepository)
            : base(context)
        {
            this._ccOrderRepository = ccOrderRepository;
            this._ccpMainRepository = ccpMainRepository;
            this._intUnitRepository = intUnitRepository;
            this._oilHistoryRepository = oilHistoryRepository;
            this._partsMonitorRepository = partsMonitorRepository;
            this._pnRegRepository = pnRegRepository;
            this._scnMainRepository = scnMainRepository;
            this._snRegRepository = snRegRepository;
            this._snHistoryRepository = snHistoryRepository;
            this._wfHistoryRepository = wfHistoryRepository;
            this._workScopeRepository = workScopeRepository;
            this._componentQuery = new ComponentQuery(uniCloudDbContext);
        }

        #endregion

        #region Ccin
        /// <summary>
        /// 添加Ccin
        /// </summary>
        /// <param name="ccins"></param>
        /// <returns></returns>
        public CcinDataObjectList AddCcin(int ccOrderId, CcinDataObjectList ccins)
        {
            CcinDataObjectList list = new CcinDataObjectList();
            var ccOrder = _ccOrderRepository.GetByKey(ccOrderId);
            List<Ccin> results = new List<Ccin>();
            if (ccOrder != null)
            {
                foreach (var ccin in ccins)
                {
                    var cc = Mapper.Map<CcinDataObject, Ccin>(ccin);
                    results.Add(cc);
                    ccOrder.Ccins.Add(cc);
                }
                _ccOrderRepository.Update(ccOrder);
                _ccOrderRepository.Context.Commit();
                list = Mapper.Map<List<Ccin>, CcinDataObjectList>(results);
            }
            return list;
        }

        /// <summary>
        /// 删除Ccin
        /// </summary>
        /// <param name="ccinIds"></param>
        public bool DeleteCcin(int ccOrderId, IDList ccinIds)
        {
            bool isSuccess = false;
            var ccOrder = _ccOrderRepository.GetByKey(ccOrderId);
            if (ccOrder != null)
            {
                foreach (var ccinId in ccinIds)
                {
                    var cId = Convert.ToInt32(ccinId);
                    var ccin = ccOrder.Ccins.FirstOrDefault(c => c.ID == cId);
                    if (ccin != null)
                    {
                        //不为空则标识为删除
                        _ccOrderRepository.EntityRegisterDeleted(ccin);
                    }
                }
                _ccOrderRepository.Context.Commit();
                isSuccess = true;
            }
            return isSuccess;
        }

        /// <summary>
        /// 更新Ccin
        /// </summary>
        /// <param name="ccins"></param>
        /// <returns></returns>
        public CcinDataObjectList UpdateCcin(int ccOrderId, CcinDataObjectList ccins)
        {
            CcinDataObjectList list = new CcinDataObjectList();
            var ccOrder = _ccOrderRepository.GetByKey(ccOrderId);
            if (ccOrder != null)
            {
                foreach (var ccDto in ccins)
                {
                    var cc = ccOrder.Ccins.FirstOrDefault(c => c.ID == ccDto.ID);
                    if (cc != null)
                    {
                        if (ccDto.AtaGuid != null)
                        {
                            cc.AtaGuid = ccDto.AtaGuid;
                        }
                        if (!string.IsNullOrEmpty(ccDto.Ata))
                        {
                            cc.Ata = ccDto.Ata;
                        }
                        if (ccDto.NhSnRegID > 0)
                        {
                            cc.NhSnRegID = ccDto.NhSnRegID;
                        }
                        if (ccDto.PnRegID > 0)
                        {
                            cc.PnRegID = ccDto.PnRegID;
                        }
                        if (ccDto.RootSnRegID > 0)
                        {
                            cc.RootSnRegID = ccDto.RootSnRegID;
                        }
                        if (ccDto.Seq > 0)
                        {
                            cc.Seq = ccDto.Seq;
                        }
                        if (ccDto.SnRegID > 0)
                        {
                            cc.SnRegID = ccDto.SnRegID;
                        }
                        if (!string.IsNullOrEmpty(ccDto.Zone))
                        {
                            cc.Zone = ccDto.Zone;
                        }
                        if (!string.IsNullOrEmpty(ccDto.EngineTli))
                            cc.EngineTli = ccDto.EngineTli;
                    }
                    list.Add(Mapper.Map<Ccin, CcinDataObject>(cc));
                }
                _ccOrderRepository.Update(ccOrder);
                _ccOrderRepository.Context.Commit();
            }
            return list;
        }

        /// <summary>
        /// 获取所有Ccin
        /// </summary>
        /// <returns></returns>
        public CcinDataObjectList GetAllCcins(int ccOrderId)
        {
            CcinDataObjectList list = new CcinDataObjectList();
            var ccOrder = _ccOrderRepository.GetByKey(ccOrderId);
            if (ccOrder != null)
            {
                list = Mapper.Map<ICollection<Ccin>, CcinDataObjectList>(ccOrder.Ccins);
            }
            return list;
        }

        /// <summary>
        /// 通过ID获取Ccin
        /// </summary>
        /// <param name="ccinId"></param>
        /// <returns></returns>
        public CcinDataObject GetCcin(int ccOrderId, int ccinId)
        {
            var ccOrder = _ccOrderRepository.GetByKey(ccOrderId);
            if (ccOrder != null)
            {
                var cc = ccOrder.Ccins.FirstOrDefault(c => c.ID == ccinId);
                return Mapper.Map<Ccin, CcinDataObject>(cc);
            }
            else
                return null;

        }
        #endregion

        #region CcOrder
        /// <summary>
        /// 添加CcOrder
        /// </summary>
        /// <param name="ccOrders"></param>
        /// <returns></returns>
        public CcOrderDataObjectList AddCcOrder(CcOrderDataObjectList ccOrders)
        {
            return
                PerformCreateObjects<CcOrderDataObjectList, CcOrderDataObject, CcOrder>(ccOrders, _ccOrderRepository);
        }

        /// <summary>
        /// 删除CcOrder
        /// </summary>
        /// <param name="ccOrderIds"></param>
        public bool DeleteCcOrder(IDList ccOrderIds)
        {
            bool isSuccess = false;
            foreach (var ccOrderId in ccOrderIds)
            {
                var ccOrder = _ccOrderRepository.GetByKey(ccOrderId);
                //移除子项
                for (int i = ccOrder.Ccouts.Count; i > 0; i--)
                {
                    _ccOrderRepository.EntityRegisterDeleted(ccOrder.Ccouts.ElementAt(i - 1));
                }
                for (int i = ccOrder.Ccins.Count; i > 0; i--)
                {
                    _ccOrderRepository.EntityRegisterDeleted(ccOrder.Ccins.ElementAt(i - 1));
                }
                _ccOrderRepository.Remove(ccOrder);
            }
            _ccOrderRepository.Context.Commit();
            isSuccess = true;
            return isSuccess;
        }

        /// <summary>
        /// 更新CcOrder
        /// </summary>
        /// <param name="ccOrders"></param>
        /// <returns></returns>
        public CcOrderDataObjectList UpdateCcOrder(CcOrderDataObjectList ccOrders)
        {
            return
                PerformUpdateObjects<CcOrderDataObjectList, CcOrderDataObject, CcOrder>(ccOrders, _ccOrderRepository,
                c => c.ID, (c, cDto) =>
                {
                    bool isModify = false; //是否有修改
                    if (!"".Equals(cDto.AcReg))
                    {
                        c.AcReg = cDto.AcReg;
                        isModify = true;
                    }
                    if (!string.IsNullOrEmpty(cDto.Cctype))
                    {
                        c.Cctype = cDto.Cctype;
                        isModify = true;
                    }
                    if (!string.IsNullOrEmpty(cDto.OrderNo))
                    {
                        c.OrderNo = cDto.OrderNo;
                        isModify = true;
                    }
                    if (!string.IsNullOrEmpty(cDto.RemReason))
                    {
                        c.RemReason = cDto.RemReason;
                        isModify = true;
                    }
                    if (!string.IsNullOrEmpty(cDto.State))
                    {
                        c.State = cDto.State;
                        isModify = true;
                    }
                    if (!"".Equals(cDto.SwapAcreg))
                    {
                        c.SwapAcreg = cDto.SwapAcreg;
                        isModify = true;
                    }
                    if (!string.IsNullOrEmpty(cDto.UpdateBy))
                    {
                        c.UpdateBy = cDto.UpdateBy;
                        isModify = true;
                    }
                    if (!string.IsNullOrEmpty(cDto.WoItem))
                    {
                        c.WoItem = cDto.WoItem;
                        isModify = true;
                    }
                    if (!string.IsNullOrEmpty(cDto.WoNo))
                    {
                        c.WoNo = cDto.WoNo;
                        isModify = true;
                    }
                    if (!string.IsNullOrEmpty(cDto.WoType))
                    {
                        c.WoType = cDto.WoType;
                        isModify = true;
                    }
                    if (!string.IsNullOrEmpty(cDto.Operator))
                    {
                        c.Operator = cDto.Operator;
                        isModify = true;
                    }
                    if (c.OperatDate != cDto.OperatDate)
                    {
                        c.OperatDate = cDto.OperatDate;
                        isModify = true;
                    }
                    //如果有修改，则更新修改时间
                    if (isModify)
                    {
                        c.UpdateDate = DateTime.Now;
                    }
                });
        }

        /// <summary>
        /// 获取所有CcOrder
        /// </summary>
        /// <returns></returns>
        public CcOrderDataObjectList GetAllCcOrders()
        {
            CcOrderDataObjectList list = new CcOrderDataObjectList();
            var results = _ccOrderRepository.GetAll();
            foreach (var ccOrder in results)
            {
                list.Add(Mapper.Map<CcOrder, CcOrderDataObject>(ccOrder));
            }
            return list;
        }

        /// <summary>
        /// 通过ID获取CcOrder
        /// </summary>
        /// <param name="ccOrderId"></param>
        /// <returns></returns>
        public CcOrderDataObject GetCcOrder(int ccOrderId)
        {
            var result = _ccOrderRepository.GetByKey(ccOrderId);
            if (result != null)
            {
                return Mapper.Map<CcOrder, CcOrderDataObject>(result);
            }
            else
                return null;
        }

        //public CcOrderDtoList GetAllCcOrderInfo()
        //{
        //    var ccOrderDtos = new CcOrderDtoList();
        //    var ccOrders = _ccOrderRepository.GetAll();
        //    foreach (var ccOrder in ccOrders)
        //    {
        //        var ccOrderDto = new CcOrderDto();
        //        ccOrderDto.ID = ccOrder.ID;
        //        ccOrderDto.Cctype = ccOrder.Cctype;
        //        ccOrderDto.From = ccOrder.WoType + ":" + ccOrder.WoNo + "-" + ccOrder.WoItem;
        //        ccOrderDto.OperatDate = ccOrder.OperatDate;
        //        ccOrderDto.Operator = ccOrder.Operator;
        //        ccOrderDto.OrderNo = ccOrder.OrderNo;
        //        ccOrderDto.RemReason = ccOrder.RemReason;
        //        ccOrderDto.State = ccOrder.State;
        //        ccOrderDto.SwapAcreg = ccOrder.SwapAcreg;
        //        ccOrderDto.UpdateBy = ccOrder.UpdateBy;
        //        ccOrderDto.UpdateDate = ccOrder.UpdateDate;
        //        ccOrderDto.WoItem = ccOrder.WoItem;
        //        ccOrderDto.WoNo = ccOrder.WoNo;
        //        ccOrderDto.WoType = ccOrder.WoType;
        //        if (ccOrder.Ccouts.Any())
        //        {
        //            var ccout = ccOrder.Ccouts.First();
        //            ccOrderDto.CcNature = ccout.UnScheduled ? "非计划性拆下" : "计划性拆下";
        //            ccOrderDto.OutPnReg = ccout.PnRegID > 0 ? _pnRegRepository.GetByKey(ccout.PnRegID).Pn : "";
        //            ccOrderDto.Zone = ccOrder.Ccouts.ElementAt(0).Zone;
        //            ccOrderDto.SnReg = ccout.SnRegID > 0 ? _snRegRepository.GetByKey(ccout.SnRegID).Sn : "";
        //        }
        //        if (ccOrder.Ccins.Any())
        //        {
        //            var ccin = ccOrder.Ccins.First();
        //            ccOrderDto.EngineTli = ccin.EngineTli;
        //            ccOrderDto.InPnReg = _pnRegRepository.GetByKey(ccin.PnRegID).Pn;
        //            ccOrderDto.SnReg = ccin.SnRegID > 0 ? _snRegRepository.GetByKey(ccin.SnRegID).Sn : "";
        //        }
        //        ccOrderDtos.Add(ccOrderDto);
        //    }
        //    return ccOrderDtos;
        //}

        /// <summary>
        /// 审核拆装记录
        /// </summary>
        /// <param name="ccOrder"></param>
        //public void VerifyCcOrder(CcOrderDataObject ccOrder)
        //{
        //    //TODO:要去查找SnHistory中的相关记录，根据snid及飞机查找，将上一次的使用时间重新计算那个后的飞行时间产生新的历史记录
        //    //现只加入时间为0的记录
        //    var snHistory = new SnHistory();
        //    var ccorder = _ccOrderRepository.GetByKey(ccOrder.ID);
        //    if (ccorder != null)
        //    {

        //        ccorder.State = "A";
        //        _ccOrderRepository.Update(ccorder);
        //        _ccOrderRepository.Context.Commit();
        //        SnReg sn = null;
        //        if (ccorder.Ccouts.Any())
        //            sn = _snRegRepository.GetByKey(ccorder.Ccouts.ElementAt(0).SnRegID);
        //        if (sn != null)
        //        {
        //            snHistory.SnRegID = sn.ID;
        //            snHistory.SnReg = sn;
        //            snHistory.Ac = ccorder.AcReg;
        //            snHistory.Active = ccorder.Cctype;
        //            snHistory.ActiveDate = ccorder.OperatDate;
        //            snHistory.Ata = sn.Ata;
        //            snHistory.Position = sn.Position;
        //            snHistory.Note = ccorder.RemReason;
        //            var intUintFH = _intUnitRepository.Get(Specification<IntUnit>.Eval(i => i.Unit.ToUpper() == "FH"));
        //            if (intUintFH != null)
        //            {
        //                var snHistoryUnit = new SnHistoryUnit();
        //                snHistoryUnit.IntUnit = intUintFH;
        //                snHistoryUnit.IntUnitID = intUintFH.ID;
        //                //snHistoryUnit.SnHistory = snHistory;
        //                snHistoryUnit.SnHistoryID = snHistory.ID;
        //                snHistoryUnit.USN = 0;
        //                snHistoryUnit.USO = 0;
        //                snHistoryUnit.USR = 0;
        //                snHistory.SnHistoryUnits.Add(snHistoryUnit);
        //            }
        //            var intUnitCY = _intUnitRepository.Get(Specification<IntUnit>.Eval(i => i.Unit.ToUpper() == "CY"));
        //            if (intUnitCY != null)
        //            {
        //                var snHistoryUnit = new SnHistoryUnit();
        //                snHistoryUnit.IntUnit = intUnitCY;
        //                snHistoryUnit.IntUnitID = intUnitCY.ID;
        //                //snHistoryUnit.SnHistory = snHistory;
        //                snHistoryUnit.SnHistoryID = snHistory.ID;
        //                snHistoryUnit.USN = 0;
        //                snHistoryUnit.USO = 0;
        //                snHistoryUnit.USR = 0;
        //                snHistory.SnHistoryUnits.Add(snHistoryUnit);
        //            }
        //            _snHistoryRepository.Add(snHistory);
        //            _snHistoryRepository.Context.Commit();
                    
        //        }
        //    }
        //}

        /// <summary>
        /// 确认生效功能。
        /// 1>拆配/交换（串件）类型的拆换，生成两条确认指令。
        /// 2>生成主部件历史记录
        /// 3>生成下级件部件历史记录
        /// 4>抛出部件拆装确认事件，通知相关事务后续处理.  
        /// </summary>
        /// <param name="ccOrderId"></param>
        public bool VerifyCcOrder(int ccOrderId)
        {
            var ccOrder = _ccOrderRepository.GetByKey(ccOrderId);
            List<SnHistory> snHistorys = new List<SnHistory>();
            //将状态置为生效
            ccOrder.State = "Activity";
            if (ccOrder != null)
            {
                //如果状态为交换或拆配，生成第二条CcOrder记录，与第一条记录Ccin.Ccout互换
                if (ccOrder.Cctype == "Swap" || ccOrder.Cctype == "RemMat")
                {
                    var cyCcOrder = new CcOrder()
                                    {
                                        AcReg = ccOrder.SwapAcreg,
                                        SwapAcreg = ccOrder.AcReg,
                                        Cctype = ccOrder.Cctype,
                                        OperatDate = ccOrder.OperatDate,
                                        Operator = ccOrder.Operator,
                                        OrderNo = ccOrder.OrderNo,
                                        RemReason = ccOrder.RemReason,
                                        State = "Activity",
                                        UpdateBy = ccOrder.UpdateBy,
                                        UpdateDate = DateTime.Now,
                                        WoItem = ccOrder.WoItem,
                                        WoNo = ccOrder.WoNo,
                                        WoType = ccOrder.WoType
                                    };
                    var ccin = ccOrder.Ccins.FirstOrDefault();
                    var ccout = ccOrder.Ccouts.FirstOrDefault();
                    if (ccin != null)
                    {
                        var cyCcout = new Ccout()
                        {
                            Ata = ccin.Ata,
                            AtaGuid = ccin.AtaGuid,
                            NhSnRegID = ccin.NhSnRegID,
                            PnRegID = ccin.PnRegID,
                            RootSnRegID = ccin.RootSnRegID,
                            Seq = ccin.Seq,
                            SnRegID = ccin.SnRegID,
                            UnScheduled =ccout!=null? ccout.UnScheduled:true,
                            Zone = ccin.Zone
                        };
                        cyCcOrder.Ccouts.Add(cyCcout);
                    }
                   
                    if (ccout != null)
                    {
                        var cyCcin = new Ccin()
                        {
                            Ata = ccout.Ata,
                            AtaGuid = ccout.AtaGuid,
                            EngineTli =ccin!=null? ccin.EngineTli:"",
                            NhSnRegID = ccout.NhSnRegID,
                            PnRegID = ccout.PnRegID,
                            RootSnRegID = ccout.RootSnRegID,
                            Seq = ccout.Seq,
                            SnRegID = ccout.SnRegID,
                            Zone = ccout.Zone
                        };
                        cyCcOrder.Ccins.Add(ccin);
                    }
                    _ccOrderRepository.Add(cyCcOrder);
                }

                //生成主部件历史记录
                if (ccOrder.Ccouts.Count > 0)
                {
                    if (ccOrder.Ccouts.ElementAt(0).SnRegID > 0)
                    {
                        var snreg = _snRegRepository.GetByKey(ccOrder.Ccouts.ElementAt(0).SnRegID);
                        if (snreg != null)
                        {
                            AddSnHistorys(ccOrder, snreg, "Remove", snHistorys);
                            //生成下级部件历史记录
                            var lowSnregs =
                                _snRegRepository.GetAll(Specification<SnReg>.Eval(p => p.NhSnRegID == snreg.ID));
                            if (lowSnregs.Any())
                            {
                                foreach (var lowSnreg in lowSnregs)
                                {
                                    AddSnHistorys(ccOrder, lowSnreg, "Remove", snHistorys);
                                }
                            }
                        }
                    }
                }
                if (ccOrder.Ccins.Count > 0)
                {
                    if (ccOrder.Ccins.ElementAt(0).SnRegID > 0)
                    {
                        var snreg = _snRegRepository.GetByKey(ccOrder.Ccins.ElementAt(0).SnRegID);
                        if (snreg != null)
                        {
                            AddSnHistorys(ccOrder, snreg, "Instore", snHistorys);
                            //生成下级部件历史记录
                            var lowSnregs =
                                _snRegRepository.GetAll(Specification<SnReg>.Eval(p => p.NhSnRegID == snreg.ID));
                            if (lowSnregs.Any())
                            {
                                foreach (var lowSnreg in lowSnregs)
                                {
                                    AddSnHistorys(ccOrder, lowSnreg, "Instore", snHistorys);
                                }
                            }
                        }
                    }
                }
            }
            //发布拆装确认事件
            ccOrder.PublishCcOrderEvent(ccOrder.AcReg, ccOrder.OperatDate, snHistorys);
            //提交到数据库
             _ccOrderRepository.Context.Commit();
            return true;
        }

        /// <summary>
        /// 增加部件历史记录
        /// </summary>
        /// <param name="ccOrder"></param>
        /// <param name="snreg"></param>
        private void AddSnHistorys(CcOrder ccOrder,SnReg snreg,string active,List<SnHistory> snHistorys)
        {
            var snHistory = new SnHistory()
            {
                Ac = ccOrder.AcReg,
                Active = active,
                ActiveDate = ccOrder.OperatDate,
                Ata = snreg.Ata,
                EngineTli = snreg.EngineTli,
                NhSnRegID = snreg.NhSnRegID,
                RootSnRegID = snreg.RootSnRegID,
                SnRegID = snreg.ID,
                Position = snreg.Position,
                Note = ccOrder.RemReason
            };
            snHistorys.Add(snHistory);
            _snHistoryRepository.Add(snHistory);
        }

        /// <summary>
        /// 根据条件查询拆装记录
        /// </summary>
        /// <param name="pnReg">件号</param>
        /// <param name="snReg">序号（附件）</param>
        /// <param name="ccType">拆装类型</param>
        /// <param name="ccNature">拆装性质</param>
        /// <returns></returns>
        public CcOrderDataObjectList QueryCcOrder(string pnReg, string snReg, string ccType, string ccNature)
        {
            var reCcOrders = new CcOrderDataObjectList();
            //var ccorders = GetAllCcOrderInfo();
            //Expression<Func<CcOrderDto, bool>> express = c => true;
            //if (!string.IsNullOrEmpty(pnReg))
            //    express.And(c => c.InPnReg == pnReg || c.OutPnReg == pnReg);
            //if (!string.IsNullOrEmpty(snReg))
            //    express.And(c => c.SnReg.Equals(snReg));
            //if (!string.IsNullOrEmpty(ccType))
            //    express.And(c => c.Cctype.Equals(ccType));
            //if (!string.IsNullOrEmpty(ccNature))
            //    express.And(c => c.CcNature.Equals(ccNature));
            //var expre = express.Compile();
            //var ccorderlist = ccorders.Where(expre);
            //reCcOrders.AddRange(ccorderlist);
            return reCcOrders;
        }

        /// <summary>
        /// 提交CcOrder的增删改数据
        /// </summary>
        /// <param name="ccOrderData"></param>
        /// <returns>提交成功的数据</returns>
        public CcOrderResultData CommitCcOrders(CcOrderResultData ccOrderData)
        {
            var resultData = new CcOrderResultData
            {
                AddedCollection =
                   new CcOrderDataObjectList(),
                DeletedCollection = new List<string>(),
                ModefiedCollection =
                   new CcOrderDataObjectList()
            };
            var addList = new List<CcOrder>();
            IEnumerable<string> deleteList = new List<string>();
            var updateList = new List<CcOrder>();

            #region Input

            if (ccOrderData.AddedCollection != null && ccOrderData.AddedCollection.Any())
            {
                ccOrderData.AddedCollection.ForEach(
                p =>
                {
                    var ccOrder = Mapper.Map<CcOrderDataObject, CcOrder>(p);
                    if (p.Ccins != null)
                    {
                        ccOrder.Ccins.Add(Mapper.Map<CcinDataObject, Ccin>(p.Ccins));
                    }
                    if (p.Ccouts != null)
                    {
                        ccOrder.Ccouts.Add(Mapper.Map<CcoutDataObject, Ccout>(p.Ccouts));
                    }
                    addList.Add(ccOrder);

                });
            }
            if (ccOrderData.DeletedCollection != null && ccOrderData.DeletedCollection.Any())
            {
                deleteList = ccOrderData.DeletedCollection;
            }
            if (ccOrderData.ModefiedCollection != null && ccOrderData.ModefiedCollection.Any())
            {
                ccOrderData.ModefiedCollection.ForEach(
                   p =>
                   {
                       var ccOrder = Mapper.Map<CcOrderDataObject, CcOrder>(p);
                       if (p.Ccins != null)
                       {
                           ccOrder.Ccins.Add(Mapper.Map<CcinDataObject, Ccin>(p.Ccins));
                       }
                       if (p.Ccouts != null)
                       {
                           ccOrder.Ccouts.Add(Mapper.Map<CcoutDataObject, Ccout>(p.Ccouts));
                       }
                       updateList.Add(ccOrder);
                   });
            }

            #endregion

            _ccOrderRepository.CommitCcOrder(ref addList, ref deleteList, ref updateList);

            #region Output

            var addResults = new ObservableCollection<CcOrderDataObject>();
            if (addList.Any())
            {
                addList.ForEach(
                   p =>
                   {
                       var ccOrderDto = Mapper.Map<CcOrder, CcOrderDataObject>(p);
                       ccOrderDto.Ccins = Mapper.Map<Ccin, CcinDataObject>(p.Ccins.FirstOrDefault());
                       ccOrderDto.Ccouts = Mapper.Map<Ccout, CcoutDataObject>(p.Ccouts.FirstOrDefault());
                       addResults.Add(ccOrderDto);
                   });
                resultData.AddedCollection = addResults;
            }
            var updateResults = new ObservableCollection<CcOrderDataObject>();
            if (updateList.Any())
            {
                updateList.ForEach(
                   p => updateResults.Add(Mapper.Map<CcOrder, CcOrderDataObject>(p)));
                resultData.ModefiedCollection = updateResults;
            }
            if (deleteList != null && deleteList.Any())
            {
                resultData.DeletedCollection = deleteList;
            }

            #endregion

            return resultData;
        }

        #endregion

        #region Ccout
        /// <summary>
        /// 添加Ccout
        /// </summary>
        /// <param name="ccouts"></param>
        /// <returns></returns>
        public CcoutDataObjectList AddCcout(int ccOrderId, CcoutDataObjectList ccouts)
        {
            CcoutDataObjectList list = new CcoutDataObjectList();
            var ccOrder = _ccOrderRepository.GetByKey(ccOrderId);
            List<Ccout> results = new List<Ccout>();
            if (ccOrder != null)
            {
                foreach (var ccout in ccouts)
                {
                    var cc = Mapper.Map<CcoutDataObject, Ccout>(ccout);
                    results.Add(cc);
                    ccOrder.Ccouts.Add(cc);
                }
                _ccOrderRepository.Update(ccOrder);
                _ccOrderRepository.Context.Commit();
                list = Mapper.Map<List<Ccout>, CcoutDataObjectList>(results);
            }
            return list;
        }

        /// <summary>
        /// 删除Ccout
        /// </summary>
        /// <param name="ccoutIds"></param>
        public bool DeleteCcout(int ccOrderId, IDList ccoutIds)
        {
            bool isSuccess = false;
            var ccOrder = _ccOrderRepository.GetByKey(ccOrderId);
            if (ccOrder != null)
            {
                foreach (var ccoutId in ccoutIds)
                {
                    var cId = Convert.ToInt32(ccoutId);
                    var ccin = ccOrder.Ccouts.FirstOrDefault(c => c.ID == cId);
                    if (ccin != null)
                    {
                        //不为空则标识为删除
                        _ccOrderRepository.EntityRegisterDeleted(ccin);
                    }
                }
                _ccOrderRepository.Context.Commit();
                isSuccess = true;
            }
            return isSuccess;
        }

        /// <summary>
        /// 更新Ccout
        /// </summary>
        /// <param name="ccouts"></param>
        /// <returns></returns>
        public CcoutDataObjectList UpdateCcout(int ccOrderId, CcoutDataObjectList ccouts)
        {
            CcoutDataObjectList list = new CcoutDataObjectList();
            var ccOrder = _ccOrderRepository.GetByKey(ccOrderId);
            if (ccOrder != null)
            {
                foreach (var ccDto in ccouts)
                {
                    var cc = ccOrder.Ccouts.FirstOrDefault(c => c.ID == ccDto.ID);
                    if (cc != null)
                    {
                        if (ccDto.AtaGuid != null)
                        {
                            cc.AtaGuid = ccDto.AtaGuid;
                        }
                        if (!string.IsNullOrEmpty(ccDto.Ata))
                        {
                            cc.Ata = ccDto.Ata;
                        }
                        if (ccDto.NhSnRegID > 0)
                        {
                            cc.NhSnRegID = ccDto.NhSnRegID;
                        }
                        if (ccDto.PnRegID > 0)
                        {
                            cc.PnRegID = ccDto.PnRegID;
                        }
                        if (ccDto.RootSnRegID > 0)
                        {
                            cc.RootSnRegID = ccDto.RootSnRegID;
                        }
                        if (ccDto.Seq > 0)
                        {
                            cc.Seq = ccDto.Seq;
                        }
                        if (ccDto.SnRegID > 0)
                        {
                            cc.SnRegID = ccDto.SnRegID;
                        }
                        if (!string.IsNullOrEmpty(ccDto.Zone))
                        {
                            cc.Zone = ccDto.Zone;
                        }
                        cc.UnScheduled = ccDto.UnScheduled;
                    }
                    list.Add(Mapper.Map<Ccout, CcoutDataObject>(cc));
                }
                _ccOrderRepository.Update(ccOrder);
                _ccOrderRepository.Context.Commit();
            }
            return list;
        }

        /// <summary>
        /// 获取所有Ccout
        /// </summary>
        /// <returns></returns>
        public CcoutDataObjectList GetAllCcouts(int ccOrderId)
        {
            CcoutDataObjectList list = new CcoutDataObjectList();
            var ccOrder = _ccOrderRepository.GetByKey(ccOrderId);
            if (ccOrder != null)
            {
                list = Mapper.Map<ICollection<Ccout>, CcoutDataObjectList>(ccOrder.Ccouts);
            }
            return list;
        }

        /// <summary>
        /// 通过ID获取Ccout
        /// </summary>
        /// <param name="ccoutId"></param>
        /// <returns></returns>
        public CcoutDataObject GetCcout(int ccOrderId, int ccoutId)
        {
            var ccOrder = _ccOrderRepository.GetByKey(ccOrderId);
            if (ccOrder != null)
            {
                var cc = ccOrder.Ccouts.FirstOrDefault(c => c.ID == ccoutId);
                return Mapper.Map<Ccout, CcoutDataObject>(cc);
            }
            else
                return null;
        }
        #endregion

        #region CcpLimit
        /// <summary>
        /// 添加CcpLimit
        /// </summary>
        /// <param name="ccpMainId"></param>
        /// <param name="ccpLimits"></param>
        /// <returns></returns>
        public CcpLimitDataObjectList AddCcpLimit(int ccpMainId, CcpLimitDataObjectList ccpLimits)
        {
            var ccpMain = _ccpMainRepository.GetByKey(ccpMainId);
            if (ccpMain != null)
            {
                foreach (var ccpLimit in ccpLimits)
                {
                    ccpMain.CcpLimits.Add(Mapper.Map<CcpLimitDataObject, CcpLimit>(ccpLimit));
                }
                _ccpMainRepository.Update(ccpMain);
                _ccpMainRepository.Context.Commit();
            }
            return ccpLimits;
        }

        /// <summary>
        /// 删除CcpLimit
        /// </summary>
        /// <param name="ccpMainId"></param>
        /// <param name="ccpLimits"></param>
        public void DeleteCcpLimit(int ccpMainId, CcpLimitDataObjectList ccpLimits)
        {
            var ccpMain = _ccpMainRepository.GetByKey(ccpMainId);
            if (ccpMain != null)
            {
                _ccpMainRepository.DeleteCcpLimit(ccpMain, ccpLimits.Select(Mapper.Map<CcpLimitDataObject, CcpLimit>));
            }
        }

        /// <summary>
        /// 更新CcpLimit
        /// </summary>
        /// <param name="ccpMainId"></param>
        /// <param name="ccpLimits"></param>
        /// <returns></returns>
        public CcpLimitDataObjectList UpdateCcpLimit(int ccpMainId, CcpLimitDataObjectList ccpLimits)
        {
            var ccpMain = _ccpMainRepository.GetByKey(ccpMainId);
            if (ccpMain != null)
            {
                foreach (var ccpLimit in ccpLimits)
                {
                    var ccpli = ccpMain.CcpLimits.FirstOrDefault(c => c.ID == ccpLimit.ID);
                    if (ccpli != null)
                    {
                        if (!string.IsNullOrEmpty(ccpLimit.Ieam))
                            ccpli.Ieam = ccpLimit.Ieam;
                        ccpli.RangeMax = ccpLimit.RangeMax;
                        ccpli.RangeMin = ccpLimit.RangeMin;
                        if (!string.IsNullOrEmpty(ccpLimit.ControlType))
                            ccpli.ControlType = ccpLimit.ControlType;
                        if (!string.IsNullOrEmpty(ccpLimit.ControlNo))
                            ccpli.ControlNo = ccpLimit.ControlNo;
                        if (!string.IsNullOrEmpty(ccpLimit.EngineTli))
                            ccpli.EngineTli = ccpLimit.EngineTli;
                        if (!string.IsNullOrEmpty(ccpLimit.Unit))
                            ccpli.Unit = ccpLimit.Unit;                        
                        ccpli.Interval = ccpLimit.Interval;
                        if (!string.IsNullOrEmpty(ccpLimit.ControlGroup))
                            ccpli.ControlGroup = ccpLimit.ControlGroup;
                        if (!string.IsNullOrEmpty(ccpLimit.RangeType))
                            ccpli.RangeType = ccpLimit.RangeType;
                        if (!string.IsNullOrEmpty(ccpLimit.WorkScope))
                            ccpli.WorkScope = ccpLimit.WorkScope;
                        ccpli.WorkScopeID = ccpLimit.WorkScopeID;
                        if (!string.IsNullOrEmpty(ccpLimit.PolicyExec))
                            ccpli.PolicyExec = ccpLimit.PolicyExec;
                        if (!string.IsNullOrEmpty(ccpLimit.Source))
                            ccpli.Source = ccpLimit.Source;
                        if (!string.IsNullOrEmpty(ccpLimit.Notes))
                            ccpli.Notes = ccpLimit.Notes;
                    }
                }
                _ccpMainRepository.Update(ccpMain);
                _ccpMainRepository.Context.Commit();
            }
            return ccpLimits;
        }

        /// <summary>
        /// 通过ID获取CcpLimit
        /// </summary>
        /// <param name="ccpMainId"></param>
        /// <returns></returns>
        public CcpLimitDataObjectList GetCcpLimit(int ccpMainId)
        {
            var ccpLimits = new CcpLimitDataObjectList();
            var ccpMain = _ccpMainRepository.GetByKey(ccpMainId);
            if (ccpMain != null)
            {
                ccpLimits.AddRange(ccpMain.CcpLimits.Select(Mapper.Map<CcpLimit, CcpLimitDataObject>));
            }
            return ccpLimits;
        }
        #endregion

        #region CcpMain
        /// <summary>
        /// 添加CcpMain
        /// </summary>
        /// <param name="ccpMains"></param>
        /// <returns></returns>
        public CcpMainDataObjectList AddCcpMain(CcpMainDataObjectList ccpMains)
        {
            var addList = new List<CcpMain>();

            ccpMains.ForEach(
               p =>
               {
                   var ccpMain = Mapper.Map<CcpMainDataObject, CcpMain>(p);
                   ccpMain.Ata = "72";
                   addList.Add(ccpMain);
               });

            _ccpMainRepository.CommitCcpMain(addList, null, null);

            var result = new CcpMainDataObjectList();
            if (addList.Any())
            {
                addList.ForEach(
                   p => result.Add(Mapper.Map<CcpMain, CcpMainDataObject>(p)));
            }
            return result;
            //return PerformCreateObjects<CcpMainDataObjectList, CcpMainDataObject, CcpMain>(ccpMains, _ccpMainRepository);
        }

        /// <summary>
        /// 删除CcpMain
        /// </summary>
        /// <param name="ccpMainIds"></param>
        public void DeleteCcpMain(IDList ccpMainIds)
        {
            foreach (var ccpMainId in ccpMainIds)
            {
                var ccpMain = _ccpMainRepository.Get(Specification<CcpMain>.Eval(c => c.ID.ToString() == ccpMainId));
                if (ccpMain != null)
                    _ccpMainRepository.DeleteCcpMain(ccpMain);
            }
        }

        /// <summary>
        /// 更新CcpMain
        /// </summary>
        /// <param name="ccpMains"></param>
        /// <returns></returns>
        public CcpMainDataObjectList UpdateCcpMain(CcpMainDataObjectList ccpMains)
        {
            return PerformUpdateObjects<CcpMainDataObjectList, CcpMainDataObject, CcpMain>(ccpMains, _ccpMainRepository, c => c.ID, (
                cc, ccp) =>
            {
                if (!string.IsNullOrEmpty(ccp.ItemNo))
                    cc.ItemNo = ccp.ItemNo;
                if (!string.IsNullOrEmpty(ccp.AcType))
                    cc.AcType = ccp.AcType;
                cc.Ata = ccp.Ata;
                if (!string.IsNullOrEmpty(ccp.Description))
                    cc.Description = ccp.Description;
                cc.IsLife = ccp.IsLife;
                cc.Version = ccp.Version;
                if (!string.IsNullOrEmpty(ccp.State))
                    cc.State = ccp.State;
                if (ccp.NhItemNo != null)
                    cc.NhItemNo = ccp.NhItemNo;
                if (!string.IsNullOrEmpty(ccp.Updateby))
                    cc.Updateby = ccp.Updateby;
                cc.UpdateTime = ccp.UpdateTime;

            });
        }

        /// <summary>
        /// 提交CcpMain的增删改数据
        /// </summary>
        /// <param name="ccpMainData"></param>
        /// <returns>提交成功的数据</returns>
        public CcpMainResultData CommitCcpMains(CcpMainResultData ccpMainData)
        {
            var resultData = new CcpMainResultData
            {
                AddedCollection =
                   new CcpMainDataObjectList(),
                DeletedCollection = new List<string>(),
                ModefiedCollection =
                   new CcpMainDataObjectList()
            };
            var addList = new List<CcpMain>();
            IEnumerable<string> deleteList = new List<string>();
            var updateList = new List<CcpMain>();

            #region Input

            if (ccpMainData.AddedCollection != null && ccpMainData.AddedCollection.Any())
            {
                ccpMainData.AddedCollection.ForEach(
                p =>
                {
                    CcpMain cm = Mapper.Map<CcpMainDataObject, CcpMain>(p);
                    CheckCcpMain(cm, "Add");
                    addList.Add(cm);
                });
            }
            if (ccpMainData.DeletedCollection != null && ccpMainData.DeletedCollection.Any())
            {
                ccpMainData.ModefiedCollection.ForEach(
                p =>
                {
                    CcpMain cm = Mapper.Map<CcpMainDataObject, CcpMain>(p);
                    CheckCcpMain(cm, "Delete");
                });
                deleteList = ccpMainData.DeletedCollection;
            }
            if (ccpMainData.ModefiedCollection != null && ccpMainData.ModefiedCollection.Any())
            {
                ccpMainData.ModefiedCollection.ForEach(
                   p =>
                   {
                       CcpMain cm = Mapper.Map<CcpMainDataObject, CcpMain>(p);
                       CheckCcpMain(cm, "Edit");
                       updateList.Add(cm);

                   });
            }

            #endregion

            _ccpMainRepository.CommitCcpMain(addList, deleteList, updateList);

            #region Output

            var addResults = new ObservableCollection<CcpMainDataObject>();
            if (addList.Any())
            {
                addList.ForEach(
                   p => addResults.Add(Mapper.Map<CcpMain, CcpMainDataObject>(p)));
                resultData.AddedCollection = addResults;
            }
            var updateResults = new ObservableCollection<CcpMainDataObject>();
            if (updateList.Any())
            {
                updateList.ForEach(
                   p => updateResults.Add(Mapper.Map<CcpMain, CcpMainDataObject>(p)));
                resultData.ModefiedCollection = updateResults;
            }
            if (deleteList != null && deleteList.Any())
            {
                resultData.DeletedCollection = deleteList;
            }

            //#endregion

            return resultData;
        }
            #endregion

        /// <summary>
        /// 获取所有CcpMain
        /// </summary>
        /// <returns></returns>
        public CcpMainDataObjectList GetAllCcpMains()
        {
            var ccpMains = new CcpMainDataObjectList();
            var ccps = _ccpMainRepository.GetAll();
            if (ccps != null)
                ccpMains.AddRange(ccps.Select(Mapper.Map<CcpMain, CcpMainDataObject>));
            if (ccpMains != null)
            {
                ccpMains[0].CcpLimits = this.GetCcpLimit(ccpMains[0].ID);
                ccpMains[0].CcpPns = this.GetCcpPn(ccpMains[0].ID);
            }
            return ccpMains;
        }

        /// <summary>
        /// 通过ID获取CcpMain
        /// </summary>
        /// <param name="ccpMainId"></param>
        /// <returns></returns>
        public CcpMainDataObject GetCcpMain(int ccpMainId)
        {
            CcpMainDataObject db;
            var ccpMain = _ccpMainRepository.GetByKey(ccpMainId);
            if (ccpMain != null)
            {
                db = Mapper.Map<CcpMain, CcpMainDataObject>(ccpMain);
                db.CcpLimits = this.GetCcpLimit(db.ID);
                db.CcpPns = this.GetCcpPn(db.ID);
                db.WfHistorys = this.GetWfHistoryByBusiness(db.ID, "CcpMain");
                return db;
            }

            return null;
        }

        /// <summary>
        /// 根据条件查询CcpMain（展示用）
        /// </summary>
        /// <param name="acType">机型</param>
        /// <param name="itemNo">附件项号</param>
        /// <param name="ataId">章节ID</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        public CcpMainDataObjectList QueryAllCcpMain(string acType, string itemNo, string ata, string state)
        {
            var ccpMainlist = new CcpMainDataObjectList();
            Expression<Func<CcpMain, bool>> express = c => true;
            if (!string.IsNullOrEmpty(acType))
            {
                express = express.And(main => main.AcType.Equals(acType));
            }
            if (!string.IsNullOrEmpty(itemNo))
            {
                express = express.And(main => main.ItemNo.Equals(itemNo));
            }
            if (!string.IsNullOrEmpty(ata))
            {
                express = express.And(main => main.Ata == ata);
            }
            if (!string.IsNullOrEmpty(state))
            {
                express = express.And(main => main.State == state);
            }
            var ccpMains = _ccpMainRepository.GetAll(Specification<CcpMain>.Eval(express)).Select(c => new CcpMainDataObject
            {
                ID = c.ID,
                AcType = c.AcType,
                Description = c.Description,
                IsLife = c.IsLife,
                ItemNo = c.ItemNo,
                Ata = c.Ata,
                NhItemNo = c.NhItemNo,
                State = c.State,
                UpdateTime = c.UpdateTime,
                Updateby = c.Updateby,
                Version = c.Version
            });

            ccpMainlist.AddRange(ccpMains);
            return ccpMainlist;
        }

        /// <summary>
        /// 获取所有附件项号
        /// </summary>
        /// <returns></returns>
        public string[] GetAllItem()
        {
            var items = _ccpMainRepository.GetAll().Select(c => c.ItemNo).ToArray();
            return items;
        }

        /// <summary>
        /// 审核附件项
        /// </summary>
        /// <param name="ccpMainId"></param>
        public void VerifyCcpMain(int ccpMainId)
        {
            var ccpMain = _ccpMainRepository.Get(Specification<CcpMain>.Eval(c => c.ID == ccpMainId && c.State.ToUpper() == "E"));
            if (ccpMain != null)
            {
                var ccpMainC = _ccpMainRepository.Get(Specification<CcpMain>.Eval(c => ccpMain.AcType.Equals(c.AcType) && c.ItemNo == ccpMain.ItemNo && c.State.ToUpper() == "C"));
                if (ccpMainC != null)
                {
                    ccpMainC.State = "H";
                    _ccpMainRepository.Update(ccpMainC);
                }
                ccpMain.State = "C";
                _ccpMainRepository.Update(ccpMain);
                _ccpMainRepository.Context.Commit();
            }
            //TODO 生成审批历史记录
            //TODO 抛出领域事件，附件项生效，重新计算附件到期预测。

        }

        /// <summary>
        /// 根据PnID查询附件项号
        /// </summary>
        /// <param name="pnId"></param>
        /// <returns></returns>
        public string QueryItemNo(int pnId)
        {
            PnReg pn = _pnRegRepository.GetByKey(pnId);
            var ccpMains = _ccpMainRepository.GetAll();
            foreach (var ccpMain in ccpMains)
            {
                var ccpPn = ccpMain.CcpPns.FirstOrDefault(c => c.PnRegID == pnId || pn.Pn.Equals(c.Pn));
                if (ccpPn != null)
                    return ccpMain.ItemNo;
            }
            return string.Empty;
        }

        /// <summary>
        /// 根据附件项号查询附件
        /// </summary>
        /// <param name="itemNo"></param>
        /// <returns></returns>
        public PnRegDataObjectList QueryPns(string itemNo)
        {
            var pnregs = new PnRegDataObjectList();
            //var ccpMains = _ccpMainRepository.GetAll(Specification<CcpMain>.Eval(c => c.ItemNo.Equals(itemNo)));
            //foreach (var ccpMain in ccpMains)
            //{
            //    var pns = ccpMain.CcpPns.Select(c => c.PnReg);
            //    pnregs.AddRange(pns.Select(Mapper.Map<PnReg,PnRegDataObject>));
            //}
            return pnregs;
        }

        //-----------------------------------校验-----
        private void CheckCcpMain(CcpMain ccpMain, string oper)
        {

            if (("Add".Equals(oper) || "Edit".Equals(oper)) && "E".Equals(ccpMain.State))
            {
                var ccpMainE = _ccpMainRepository.Get(Specification<CcpMain>.Eval(c => ccpMain.AcType.Equals(c.AcType) && ccpMain.ItemNo.Equals(c.ItemNo) && "E".Equals(c.State) && ccpMain.ID != c.ID));
                if (ccpMainE != null)
                {
                    throw new Exception("错误：机型/附件项：【" + ccpMain.AcType + ":" + ccpMain.ItemNo + "】已经存在一个编辑/改版条目.");
                }
                var ccpMainC = _ccpMainRepository.Get(Specification<CcpMain>.Eval(c => ccpMain.AcType.Equals(c.AcType) && ccpMain.ItemNo.Equals(c.ItemNo) && "C".Equals(c.State) && ccpMain.ID != c.ID));
                if (ccpMainC != null && ccpMainC.Version >= ccpMain.Version)
                {
                    throw new Exception("错误：附件项：【" + ccpMain.AcType + ":" + ccpMain.ItemNo + "】已经存在一个当前有效条目，请通过改版进行编订.");
                }
            }
            else if ("Delete".Equals(oper) && !"E".Equals(ccpMain.State))
            {

                throw new Exception("错误：附件项：【" + ccpMain.AcType + ":" + ccpMain.ItemNo + "】当前有效/已经存档，不可删除！");
            }
        }
        #endregion

        #region CcpPn
        /// <summary>
        /// 添加CcpPn
        /// </summary>
        /// <param name="ccpMainId"></param>
        /// <param name="ccpPns"></param>
        /// <returns></returns>
        public CcpPnDataObjectList AddCcpPn(int ccpMainId, CcpPnDataObjectList ccpPns)
        {
            var ccpMain = _ccpMainRepository.GetByKey(ccpMainId);
            if (ccpMain != null)
            {
                foreach (var ccpPn in ccpPns)
                {
                    ccpMain.CcpPns.Add(Mapper.Map<CcpPnDataObject, CcpPn>(ccpPn));
                }
                _ccpMainRepository.Update(ccpMain);
                _ccpMainRepository.Context.Commit();
            }
            return ccpPns;
        }

        /// <summary>
        /// 删除CcpPn
        /// </summary>
        /// <param name="ccpMainId"></param>
        /// <param name="ccpPns"></param>
        public void DeleteCcpPn(int ccpMainId, CcpPnDataObjectList ccpPns)
        {
            var ccpMain = _ccpMainRepository.GetByKey(ccpMainId);
            if (ccpMain != null)
            {
                _ccpMainRepository.DeleteCcpPn(ccpMain, ccpPns.Select(Mapper.Map<CcpPnDataObject, CcpPn>));
            }
        }

        /// <summary>
        /// 更新CcpPn
        /// </summary>
        /// <param name="ccpMainId"></param>
        /// <param name="ccpPns"></param>
        /// <returns></returns>
        public CcpPnDataObjectList UpdateCcpPn(int ccpMainId, CcpPnDataObjectList ccpPns)
        {
            var ccpMain = _ccpMainRepository.GetByKey(ccpMainId);
            if (ccpMain != null)
            {
                foreach (var ccpPn in ccpPns)
                {
                    var cpn = ccpMain.CcpPns.FirstOrDefault(c => c.ID == ccpPn.ID);
                    if (cpn != null)
                    {
                        if (!string.IsNullOrEmpty(ccpPn.Pn))
                            cpn.Pn = ccpPn.Pn;
                        if (!string.IsNullOrEmpty(ccpPn.SpecPn))
                            cpn.SpecPn = ccpPn.SpecPn;
                        if (!string.IsNullOrEmpty(ccpPn.AcModel))
                            cpn.AcModel = ccpPn.AcModel;
                        if (!string.IsNullOrEmpty(ccpPn.AcRegs))
                            cpn.AcRegs = ccpPn.AcRegs;
                        if (!string.IsNullOrEmpty(ccpPn.Notes))
                            cpn.Notes = ccpPn.Notes;
                        if (!string.IsNullOrEmpty(ccpPn.Ieam))
                            cpn.Ieam = ccpPn.Ieam;
                        cpn.Qty = ccpPn.Qty;
                        if (!string.IsNullOrEmpty(ccpPn.Sns))
                            cpn.Sns = ccpPn.Sns;
                        cpn.PnRegID = ccpPn.PnRegID;
                        cpn.CcpMainID = ccpPn.CcpMainID;
                    }
                }
                _ccpMainRepository.Update(ccpMain);
                _ccpMainRepository.Context.Commit();
            }
            return ccpPns;
        }

        /// <summary>
        /// 通过ID获取CcpPn
        /// </summary>
        /// <param name="ccpMainId"></param>
        /// <returns></returns>
        public CcpPnDataObjectList GetCcpPn(int ccpMainId)
        {
            var ccpPns = new CcpPnDataObjectList();
            var ccpMain = _ccpMainRepository.GetByKey(ccpMainId);
            if (ccpMain != null)
            {
                ccpPns.AddRange(ccpMain.CcpPns.Select(Mapper.Map<CcpPn, CcpPnDataObject>));
            }
            return ccpPns;
        }
        #endregion

        #region IntUnit
        /// <summary>
        /// 添加IntUnit
        /// </summary>
        /// <param name="intUnits"></param>
        /// <returns></returns>
        public IntUnitDataObjectList AddIntUnit(IntUnitDataObjectList intUnits)
        {
            return PerformCreateObjects<IntUnitDataObjectList, IntUnitDataObject, IntUnit>(intUnits, _intUnitRepository);
        }

        /// <summary>
        /// 删除IntUnit
        /// </summary>
        /// <param name="intUnitIds"></param>
        public void DeleteIntUnit(IDList intUnitIds)
        {
            PerformDeleteObjects<IntUnit>(intUnitIds, _intUnitRepository);
        }

        /// <summary>
        /// 更新IntUnit
        /// </summary>
        /// <param name="intUnits"></param>
        /// <returns></returns>
        public IntUnitDataObjectList UpdateIntUnit(IntUnitDataObjectList intUnits)
        {
            return PerformUpdateObjects<IntUnitDataObjectList, IntUnitDataObject, IntUnit>(intUnits, _intUnitRepository, i => i.ID, (iu, iun) =>
            {
                if (!string.IsNullOrEmpty(iun.Unit))
                    iu.Unit = iun.Unit;
                if (!string.IsNullOrEmpty(iun.Descritption))
                    iu.Descritption = iun.Descritption;
                if (!string.IsNullOrEmpty(iun.Type))
                    iu.Type = iun.Type;
                if (!string.IsNullOrEmpty(iun.ShortName))
                    iu.ShortName = iun.ShortName;
            });
        }

        /// <summary>
        /// 获取所有IntUnit
        /// </summary>
        /// <returns></returns>
        public IntUnitDataObjectList GetAllIntUnits()
        {
            var intUnits = new IntUnitDataObjectList();
            var units = _intUnitRepository.GetAll();
            if (units != null)
                intUnits.AddRange(units.Select(Mapper.Map<IntUnit, IntUnitDataObject>));
            return intUnits;
        }

        /// <summary>
        /// 通过ID获取IntUnit
        /// </summary>
        /// <param name="intUnitId"></param>
        /// <returns></returns>
        public IntUnitDataObject GetIntUnit(int intUnitId)
        {
            var intUnit = _intUnitRepository.GetByKey(intUnitId);
            if (intUnit != null)
                return Mapper.Map<IntUnit, IntUnitDataObject>(intUnit);
            return null;
        }

        /// <summary>
        /// 提交IntUnit的增删改数据
        /// </summary>
        /// <param name="intUnitData"></param>
        /// <returns>提交成功的数据</returns>
        public IntUnitResultData CommitIntUnits(IntUnitResultData intUnitData)
        {
            var resultData = new IntUnitResultData
            {
                AddedCollection =
                   new IntUnitDataObjectList(),
                DeletedCollection = new List<string>(),
                ModefiedCollection =
                   new IntUnitDataObjectList()
            };
            var addList = new List<IntUnit>();
            IEnumerable<string> deleteList = new List<string>();
            var updateList = new List<IntUnit>();

            #region Input

            if (intUnitData.AddedCollection != null && intUnitData.AddedCollection.Any())
            {
                intUnitData.AddedCollection.ForEach(
                p =>
                {
                    addList.Add(Mapper.Map<IntUnitDataObject, IntUnit>(p));
                });
            }
            if (intUnitData.DeletedCollection != null && intUnitData.DeletedCollection.Any())
            {
                deleteList = intUnitData.DeletedCollection;
            }
            if (intUnitData.ModefiedCollection != null && intUnitData.ModefiedCollection.Any())
            {
                intUnitData.ModefiedCollection.ForEach(
                   p => updateList.Add(Mapper.Map<IntUnitDataObject, IntUnit>(p)));
            }

            #endregion

            _intUnitRepository.CommitIntUnit(ref addList, ref deleteList, ref updateList);

            #region Output

            var addResults = new ObservableCollection<IntUnitDataObject>();
            if (addList.Any())
            {
                addList.ForEach(
                   p => addResults.Add(Mapper.Map<IntUnit, IntUnitDataObject>(p)));
                resultData.AddedCollection = addResults;
            }
            var updateResults = new ObservableCollection<IntUnitDataObject>();
            if (updateList.Any())
            {
                updateList.ForEach(
                   p => updateResults.Add(Mapper.Map<IntUnit, IntUnitDataObject>(p)));
                resultData.ModefiedCollection = updateResults;
            }
            if (deleteList != null && deleteList.Any())
            {
                resultData.DeletedCollection = deleteList;
            }

            #endregion

            return resultData;
        }
        #endregion

        #region OilHistory
        /// <summary>
        /// 添加OilHistory
        /// </summary>
        /// <param name="oilHistorys"></param>
        /// <returns></returns>
        public OilHistoryDataObjectList AddOilHistory(OilHistoryDataObjectList oilHistorys)
        {
            return
               PerformCreateObjects<OilHistoryDataObjectList, OilHistoryDataObject, OilHistory>(oilHistorys, _oilHistoryRepository);
        }

        /// <summary>
        /// 删除OilHistory
        /// </summary>
        /// <param name="oilHistoryIds"></param>
        public bool DeleteOilHistory(IDList oilHistoryIds)
        {
            bool isSuccess = false;
            foreach (var oilId in oilHistoryIds)
            {
                var oil = _oilHistoryRepository.GetByKey(oilId);
                if (oil != null)
                    _oilHistoryRepository.Remove(oil);
            }
            _ccOrderRepository.Context.Commit();
            isSuccess = true;
            return isSuccess;
        }

        /// <summary>
        /// 更新OilHistory
        /// </summary>
        /// <param name="oilHistorys"></param>
        /// <returns></returns>
        public OilHistoryDataObjectList UpdateOilHistory(OilHistoryDataObjectList oilHistorys)
        {
            return
               PerformUpdateObjects<OilHistoryDataObjectList, OilHistoryDataObject, OilHistory>(oilHistorys, _oilHistoryRepository,
               c => c.ID, (c, cDto) =>
               {
                   bool isModify = false; //是否有修改
                   if (cDto.AcRegID > 0)
                   {
                       c.AcRegID = cDto.AcRegID;
                       isModify = true;
                   }
                   if (cDto.AcRegGuid != null)
                   {
                       c.AcRegGuid = cDto.AcRegGuid;
                       isModify = true;
                   }
                   if (!string.IsNullOrEmpty(cDto.AddName))
                   {
                       c.AddName = cDto.AddName;
                       isModify = true;
                   }
                   if (!string.IsNullOrEmpty(cDto.AddTime))
                   {
                       c.AddTime = cDto.AddTime;
                       isModify = true;
                   }
                   if (cDto.AtaID > 0)
                   {
                       c.AtaID = cDto.AtaID;
                       isModify = true;
                   }
                   if (cDto.AtaGuid != null)
                   {
                       c.AtaGuid = cDto.AtaGuid;
                       isModify = true;
                   }
                   if (cDto.FlightDate.Hour > 0)
                   {
                       c.FlightDate = cDto.FlightDate;
                       isModify = true;
                   }
                   if (cDto.FlightlLogID > 0)
                   {
                       c.FlightlLogID = cDto.FlightlLogID;
                       isModify = true;
                   }
                   if (!string.IsNullOrEmpty(cDto.Notes))
                   {
                       c.Notes = cDto.Notes;
                       isModify = true;
                   }
                   if (cDto.PnRegID > 0)
                   {
                       c.PnRegID = cDto.PnRegID;
                       isModify = true;
                   }
                   if (cDto.SnRegID > 0)
                   {
                       c.SnRegID = cDto.SnRegID;
                       isModify = true;
                   }
                   if (!string.IsNullOrEmpty(cDto.UpdateBy))
                   {
                       c.UpdateBy = cDto.UpdateBy;
                       isModify = true;
                   }
                   if (cDto.UPLIFT > 0)
                   {
                       c.UPLIFT = cDto.UPLIFT;
                       isModify = true;
                   }
                   if (!string.IsNullOrEmpty(cDto.Zone))
                   {
                       c.Zone = cDto.Zone;
                       isModify = true;
                   }
                   //如果有修改，则更新修改时间
                   if (isModify)
                   {
                       c.UpdateDate = DateTime.Now;
                   }
               });
        }

        /// <summary>
        /// 获取所有OilHistory
        /// </summary>
        /// <returns></returns>
        public OilHistoryDataObjectList GetAllOilHistorys()
        {
            OilHistoryDataObjectList list = new OilHistoryDataObjectList();
            var results = _oilHistoryRepository.GetAll();
            foreach (var oil in results)
            {
                list.Add(Mapper.Map<OilHistory, OilHistoryDataObject>(oil));
            }
            return list;
        }

        /// <summary>
        /// 通过ID获取OilHistory
        /// </summary>
        /// <param name="oilHistoryId"></param>
        /// <returns></returns>
        public OilHistoryDataObject GetOilHistory(int oilHistoryId)
        {
            var result = _oilHistoryRepository.GetByKey(oilHistoryId);
            if (result != null)
            {
                return Mapper.Map<OilHistory, OilHistoryDataObject>(result);
            }
            else
                return null;
        }

        /// <summary>
        /// 分析Apu
        /// </summary>
        /// <param name="pn">件号</param>
        /// <param name="sn">序号</param>
        /// <param name="average">滚动平均周期值</param>
        /// <param name="warnValue">消耗率警戒值</param>
        /// <param name="warnAddValue">滑油消耗率趋势增量警戒值</param>
        /// <param name="startTime">分析起始日期</param>
        /// <param name="endTime">分析起始日期</param>
        /// <returns></returns>
        public APUWarningDtoList AnalyAPUWarn(string pn, string sn, int average, int warnValue, int warnAddValue,
                                              DateTime startTime, DateTime endTime)
        {
            var apuWarns = new APUWarningDtoList();
            //TODO:未实现，为假数据
            for (int i = 0; i < 10; i++)
            {
                var apuWarn = new APUWarningDto();
                apuWarn.Ac = "B-" + (6227 + i).ToString();
                apuWarn.AddTime = startTime;
                apuWarn.FuelConsumptionRate = i + 10;
                apuWarn.Increment = i + 5;
                apuWarn.Pn = "GTCP331-200ER";
                apuWarn.PnClass = "AP";
                apuWarn.Sn = "P-2118";
                apuWarn.UPLIFT = i + 20;
                apuWarn.WarnTime = endTime;
                apuWarns.Add(apuWarn);
            }
            return apuWarns;
        }

        public OilHistoryDtoList GetAllOilHistoryDto()
        {
            var oilHistoryDtos = new OilHistoryDtoList();
            var oilHistorys = _oilHistoryRepository.GetAll();
            if (oilHistorys != null)
            {
                foreach (var oilHistory in oilHistorys)
                {
                    var oilHistoryDto = new OilHistoryDto();
                    oilHistoryDto.AddName = oilHistory.AddName;
                    oilHistoryDto.AddTime = oilHistory.AddTime;
                    oilHistoryDto.FlightDate = oilHistory.FlightDate;
                    oilHistoryDto.ID = oilHistory.ID;
                    oilHistoryDto.Notes = oilHistory.Notes;
                    var pn = _pnRegRepository.GetByKey(oilHistory.PnRegID);
                    if (pn != null)
                    {
                        oilHistoryDto.PnClass = pn.PnClass;
                        oilHistoryDto.PnReg = pn.Pn;
                    }
                    var sn = _snRegRepository.GetByKey(oilHistory.SnRegID);
                    if (sn != null)
                        oilHistoryDto.SnReg = sn.Sn;
                    oilHistoryDto.UPLIFT = oilHistory.UPLIFT;
                    oilHistoryDto.UpdateBy = oilHistory.UpdateBy;
                    oilHistoryDto.UpdateDate = oilHistory.UpdateDate;
                    oilHistoryDto.Zone = oilHistory.Zone;
                    oilHistoryDtos.Add(oilHistoryDto);
                }
            }
            return oilHistoryDtos;
        }

        /// <summary>
        /// 提交OilHistory的增删改数据
        /// </summary>
        /// <param name="oilHistoryData"></param>
        /// <returns>提交成功的数据</returns>
        public OilHistoryResultData CommitOilHistorys(OilHistoryResultData oilHistoryData)
        {
            var resultData = new OilHistoryResultData
            {
                AddedCollection =
                   new OilHistoryDataObjectList(),
                DeletedCollection = new List<string>(),
                ModefiedCollection =
                   new OilHistoryDataObjectList()
            };
            var addList = new List<OilHistory>();
            IEnumerable<string> deleteList = new List<string>();
            var updateList = new List<OilHistory>();

            #region Input

            if (oilHistoryData.AddedCollection != null && oilHistoryData.AddedCollection.Any())
            {
                oilHistoryData.AddedCollection.ForEach(
                p =>
                {
                    addList.Add(Mapper.Map<OilHistoryDataObject, OilHistory>(p));
                });
            }
            if (oilHistoryData.DeletedCollection != null && oilHistoryData.DeletedCollection.Any())
            {
                deleteList = oilHistoryData.DeletedCollection;
            }
            if (oilHistoryData.ModefiedCollection != null && oilHistoryData.ModefiedCollection.Any())
            {
                oilHistoryData.ModefiedCollection.ForEach(
                   p => updateList.Add(Mapper.Map<OilHistoryDataObject, OilHistory>(p)));
            }

            #endregion

            _oilHistoryRepository.CommitOilHistory(ref addList, ref deleteList, ref updateList);

            #region Output

            var addResults = new ObservableCollection<OilHistoryDataObject>();
            if (addList.Any())
            {
                addList.ForEach(
                   p => addResults.Add(Mapper.Map<OilHistory, OilHistoryDataObject>(p)));
                resultData.AddedCollection = addResults;
            }
            var updateResults = new ObservableCollection<OilHistoryDataObject>();
            if (updateList.Any())
            {
                updateList.ForEach(
                   p => updateResults.Add(Mapper.Map<OilHistory, OilHistoryDataObject>(p)));
                resultData.ModefiedCollection = updateResults;
            }
            if (deleteList != null && deleteList.Any())
            {
                resultData.DeletedCollection = deleteList;
            }

            #endregion

            return resultData;
        }
        #endregion

        #region PartsMonitor
        /// <summary>
        /// 添加PartsMonitor
        /// </summary>
        /// <param name="partsMonitors"></param>
        /// <returns></returns>
        public PartsMonitorDataObjectList AddPartsMonitor(PartsMonitorDataObjectList partsMonitors)
        {
            return
               PerformCreateObjects<PartsMonitorDataObjectList, PartsMonitorDataObject, PartsMonitor>(partsMonitors, _partsMonitorRepository);
        }

        /// <summary>
        /// 删除PartsMonitor
        /// </summary>
        /// <param name="partsMonitorIds"></param>
        public bool DeletePartsMonitor(IDList partsMonitorIds)
        {
            bool isSuccess = false;
            foreach (var partsMonitorId in partsMonitorIds)
            {
                var partsMonitor = _partsMonitorRepository.GetByKey(partsMonitorId);
                //移除子项
                for (int i = partsMonitor.PartsMonitorDetails.Count; i > 0; i--)
                {
                    _ccOrderRepository.EntityRegisterDeleted(partsMonitor.PartsMonitorDetails.ElementAt(i - 1));
                }
                _partsMonitorRepository.Remove(partsMonitor);
            }
            _partsMonitorRepository.Context.Commit();
            isSuccess = true;
            return isSuccess;
        }

        /// <summary>
        /// 更新PartsMonitor
        /// </summary>
        /// <param name="partsMonitors"></param>
        /// <returns></returns>
        public PartsMonitorDataObjectList UpdatePartsMonitor(PartsMonitorDataObjectList partsMonitors)
        {
            return
                PerformUpdateObjects<PartsMonitorDataObjectList, PartsMonitorDataObject, PartsMonitor>(partsMonitors, _partsMonitorRepository,
                p => p.ID, (p, pDto) =>
                {
                    if (pDto.AcReg != null)
                    {
                        p.AcReg = pDto.AcReg;
                    }
                    if (!string.IsNullOrEmpty(pDto.Ata))
                    {
                        p.Ata = pDto.Ata;
                    }
                    if (pDto.ExpireDate.Hour > 0)
                    {
                        p.ExpireDate = pDto.ExpireDate;
                    }
                    if (pDto.InstallDate.Hour > 0)
                    {
                        p.InstallDate = pDto.InstallDate;
                    }
                    if (pDto.PnRegID > 0)
                    {
                        p.PnRegID = pDto.PnRegID;
                    }
                    if (!string.IsNullOrEmpty(pDto.PolicyExec))
                    {
                        p.PolicyExec = pDto.PolicyExec;
                    }
                    if (!string.IsNullOrEmpty(pDto.Position))
                    {
                        p.Position = pDto.Position;
                    }
                    if (!string.IsNullOrEmpty(pDto.RemainTime))
                    {
                        p.RemainTime = pDto.RemainTime;
                    }
                    if (pDto.SnRegID > 0)
                    {
                        p.SnRegID = pDto.SnRegID;
                    }
                    if (!string.IsNullOrEmpty(pDto.UsedTime))
                    {
                        p.UsedTime = pDto.UsedTime;
                    }
                    if (!string.IsNullOrEmpty(pDto.WorkScope))
                    {
                        p.WorkScope = pDto.WorkScope;
                    }
                    if (!string.IsNullOrEmpty(pDto.Zone))
                    {
                        p.Zone = pDto.Zone;
                    }
                });
        }

        /// <summary>
        /// 获取所有PartsMonitor
        /// </summary>
        /// <returns></returns>
        public PartsMonitorDataObjectList GetAllPartsMonitors()
        {
            PartsMonitorDataObjectList list = new PartsMonitorDataObjectList();
            var results = _partsMonitorRepository.GetAll();
            foreach (var partsMonitor in results)
            {
                list.Add(Mapper.Map<PartsMonitor, PartsMonitorDataObject>(partsMonitor));
            }
            return list;
        }

        /// <summary>
        /// 通过ID获取PartsMonitor
        /// </summary>
        /// <param name="partsMonitorId"></param>
        /// <returns></returns>
        public PartsMonitorDataObject GetPartsMonitor(int partsMonitorId)
        {
            var result = _partsMonitorRepository.GetByKey(partsMonitorId);
            if (result != null)
            {
                return Mapper.Map<PartsMonitor, PartsMonitorDataObject>(result);
            }
            else
                return null;
        }

        /// <summary>
        /// 通过条件查找PartsMonitor(展示用)
        /// </summary>
        /// <param name="acRegID">飞机ID</param>
        /// <param name="ccpMainID">附件项ID</param>
        /// <param name="pnRegID">件号ID</param>
        /// <param name="snRegID">附件ID（序号ID）</param>
        /// <param name="expireDate">到期日期</param>
        /// <param name="position">安装位置</param>
        /// <returns></returns>
        public PartsMonitorDataObjectList QueryPartsMonitor(string acReg, int ccpMainID, int pnRegID, int snRegID,
                                                     DateTime expireDate, string position)
        {
            var partsMonitors = new PartsMonitorDataObjectList();
            Expression<Func<PartsMonitor, bool>> express = p => true;
            if (!string.IsNullOrEmpty(acReg))
                express = express.And(p => p.AcReg == acReg);
            if (ccpMainID > 0)
                express = express.And(p => p.CcpMainID == ccpMainID);
            if (pnRegID > 0)
                express = express.And(p => p.PnRegID == pnRegID);
            if (snRegID > 0)
                express = express.And(p => p.SnRegID == snRegID);
            if (expireDate > new DateTime())
            {
                expireDate = expireDate.Date.AddDays(1);
                express = express.And(p => p.ExpireDate < expireDate);
            }
            if (!string.IsNullOrEmpty(position))
                express = express.And(p => p.Position.Equals(position));
            var partsMonitorlist = _partsMonitorRepository.GetAll(Specification<PartsMonitor>.Eval(express));
            if (partsMonitorlist != null)
            {
                foreach (var partsMonitor in partsMonitorlist)
                {
                    var partsMonitorDto = new PartsMonitorDataObject();
                    partsMonitorDto.ID = partsMonitor.ID;
                    partsMonitorDto.Pn = _pnRegRepository.GetByKey(partsMonitor.PnRegID).Pn;
                    partsMonitorDto.Sn = _snRegRepository.GetByKey(partsMonitor.SnRegID).Sn;
                    partsMonitorDto.ItemNo = _ccpMainRepository.GetByKey(partsMonitor.CcpMain).ItemNo;
                    partsMonitorDto.UsedTime = partsMonitor.UsedTime;
                    partsMonitorDto.RemainTime = partsMonitor.RemainTime;
                    partsMonitorDto.WorkScope = partsMonitor.WorkScope;
                    partsMonitorDto.PolicyExec = partsMonitor.PolicyExec;
                    partsMonitorDto.InstallDate = partsMonitor.InstallDate;
                    partsMonitorDto.Zone = partsMonitor.Zone;
                    partsMonitorDto.Position = partsMonitor.Position;
                    partsMonitorDto.ExpireDate = partsMonitor.ExpireDate;
                    partsMonitors.Add(partsMonitorDto);
                }
            }
            return partsMonitors;
        }

        /// <summary>
        /// 计算附件利用率
        /// </summary>
        /// <param name="acRegID">飞机ID</param>
        /// <param name="ccpMainID">附件项ID</param>
        /// <param name="pnRegID">件号ID</param>
        /// <param name="snRegID">附件ID（序号ID）</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="calculateType">采用哪种方式进行计算（0：日利用率，1：周利用率，2：月利用率）</param>
        /// <returns></returns>
        public UtilizationData CalculateUtilization(int acRegID, int ccpMainID, int pnRegID, int snRegID, DateTime startTime, DateTime endTime, int calculateType)
        {
            //TODO:此功能未实现，给予假数据
            var utilization = new UtilizationData();
            int time = 0;
            int max = 0;
            int min = 0;
            var r = new Random();
            switch (calculateType)
            {
                case 0:
                    time = (endTime - startTime).Days;
                    min = 3;
                    max = 6;
                    utilization.FlightCycles = (float)(2 + r.Next(1, 1000) * 0.001);
                    break;
                case 1:
                    time = (endTime - startTime).Days / 7;
                    min = 20;
                    max = 40;
                    utilization.FlightCycles = (float)(10 + r.Next(1, 5000) * 0.001);
                    break;
                case 2:
                    time = (endTime - startTime).Days / 30;
                    min = 80;
                    max = 160;
                    utilization.FlightCycles = (float)(40 + r.Next(1, 20000) * 0.001);
                    break;
                default: break;
            }
            for (int i = 0; i < time; i++)
            {
                var useinfo = new UseDetailInfo
                {
                    Time = i + 1,
                    Value = (float)(min + r.Next(1, (max - min) * 1000) * 0.001)
                };
                utilization.UseDetails.Add(useinfo);
            }
            var hours = utilization.UseDetails.Sum(useDetail => useDetail.Value);
            utilization.FlightHours = (float)hours / utilization.UseDetails.Count;
            return utilization;
        }

        /// <summary>
        /// 提交PartsMonitor的增删改数据
        /// </summary>
        /// <param name="partsMonitorData"></param>
        /// <returns>提交成功的数据</returns>
        public PartsMonitorResultData CommitPartsMonitors(PartsMonitorResultData partsMonitorData)
        {
            var resultData = new PartsMonitorResultData
            {
                AddedCollection =
                   new PartsMonitorDataObjectList(),
                DeletedCollection = new List<string>(),
                ModefiedCollection =
                   new PartsMonitorDataObjectList()
            };
            var addList = new List<PartsMonitor>();
            IEnumerable<string> deleteList = new List<string>();
            var updateList = new List<PartsMonitor>();

            #region Input

            if (partsMonitorData.AddedCollection != null && partsMonitorData.AddedCollection.Any())
            {
                partsMonitorData.AddedCollection.ForEach(
                p =>
                {
                    addList.Add(Mapper.Map<PartsMonitorDataObject, PartsMonitor>(p));
                });
            }
            if (partsMonitorData.DeletedCollection != null && partsMonitorData.DeletedCollection.Any())
            {
                deleteList = partsMonitorData.DeletedCollection;
            }
            if (partsMonitorData.ModefiedCollection != null && partsMonitorData.ModefiedCollection.Any())
            {
                partsMonitorData.ModefiedCollection.ForEach(
                   p => updateList.Add(Mapper.Map<PartsMonitorDataObject, PartsMonitor>(p)));
            }

            #endregion

            _partsMonitorRepository.CommitPartsMonitor(ref addList, ref deleteList, ref updateList);

            #region Output

            var addResults = new ObservableCollection<PartsMonitorDataObject>();
            if (addList.Any())
            {
                addList.ForEach(
                   p => addResults.Add(Mapper.Map<PartsMonitor, PartsMonitorDataObject>(p)));
                resultData.AddedCollection = addResults;
            }
            var updateResults = new ObservableCollection<PartsMonitorDataObject>();
            if (updateList.Any())
            {
                updateList.ForEach(
                   p => updateResults.Add(Mapper.Map<PartsMonitor, PartsMonitorDataObject>(p)));
                resultData.ModefiedCollection = updateResults;
            }
            if (deleteList != null && deleteList.Any())
            {
                resultData.DeletedCollection = deleteList;
            }

            #endregion

            return resultData;
        }

        /// <summary>
        /// 根据输入条件，对不同范围内的部件进行重新计算
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public bool CalculatePartsDue(PartsMonitorDataObject filter)
        {
            List<CcpMain> ccpMains = new List<CcpMain>();

            #region 根据条件进行附件项筛选.有以下几种情况：            
            if (filter == null)
            {
                // TODO 查找所有附件项
                ccpMains = _ccpMainRepository.GetAll().Where(o=>"Curr".Equals(o.State)).ToList();
            }
            else if (filter.CcpMainID != null && filter.CcpMainID > 0)
            {
                // TODO 重新计算某附件项覆盖的部件
                CcpMain ccp = _ccpMainRepository.GetByKey(filter.CcpMainID);
                if (ccp!=null)
                    ccpMains.Add(ccp);
            }
            else {
            }
            #endregion


            #region 迭代附件项，进行适用范围和适用间隔配对.
            foreach (var ccp in ccpMains) {

                var ccpns = ccp.CcpPns;
                var limits = ccp.CcpLimits;
                if (ccpns != null && limits != null && ccpns.Count > 0 && limits.Count > 0)
                {
                    List<CcpLimit> pnlimits =  limits.Where(o => "0".Equals(o.Ieam)).ToList();
                    foreach (var cpn in ccpns)
                    {
                        if (String.IsNullOrEmpty(cpn.Ieam))
                        {
                            pnlimits = limits.Where(o => cpn.Ieam.Equals(o.Ieam)).ToList();
                        }
                        CalculatePartDue(cpn, pnlimits);
                    }
                         
                }            
            }
            #endregion
            return true;
        }

        private bool CalculatePartDue(CcpPn cpn, List<CcpLimit> lms) 
        {
            List<SnReg> sns = GetSnRegObjs(0, cpn.Pn, "");
                          
                
            foreach(var sn in sns){
                SnRegDataObject sndb = Mapper.Map<SnReg, SnRegDataObject>(sn);
                GetSnRegTime(ref sndb);
                //对使用范围内的部件进行分析
                foreach (var lm in lms) {
                    CalculateSnDue(sndb, lm);                
                }                           
            }
            return true;
        }

        private List<PartsMonitorDetail> CalculateSnDue(SnRegDataObject sn, CcpLimit lm)
        {

            //查找上一次执行的历史                
            SnHistoryDataObject sh = sn.snHistory;

            //查找部件从上一次执行到现在的使用时间
            DateTime lastDate = sh.ActiveDate;// TODO 请使用最近一次维修记录日期代替
            SnHistoryUnitDataObjectList lastTimes = sh.SnHistoryUnits;
            if ("FH".Equals(lm.Unit)) {
                SnHistoryUnitDataObject su = lastTimes.Where(o => "FH".Equals(o.Unit)).FirstOrDefault();                
            }
            else if ("CY".Equals(lm.Unit))
            {
            } if ("DA".Equals(lm.Unit))
            {
            } if ("MM".Equals(lm.Unit))
            {
            }
            return null;
        }
        #endregion

        #region PartsMonitorDetail
        /// <summary>
        /// 添加PartsMonitorDetail
        /// </summary>
        /// <param name="partsMonitorDetails"></param>
        /// <returns></returns>
        public PartsMonitorDetailDataObjectList AddPartsMonitorDetail(int partsMonitorId, PartsMonitorDetailDataObjectList partsMonitorDetails)
        {
            PartsMonitorDetailDataObjectList list = new PartsMonitorDetailDataObjectList();
            var partsMonitor = _partsMonitorRepository.GetByKey(partsMonitorId);
            List<PartsMonitorDetail> results = new List<PartsMonitorDetail>();
            if (partsMonitor != null)
            {
                foreach (var pm in partsMonitorDetails)
                {
                    var p = Mapper.Map<PartsMonitorDetailDataObject, PartsMonitorDetail>(pm);
                    results.Add(p);
                    partsMonitor.PartsMonitorDetails.Add(p);
                }
                _partsMonitorRepository.Update(partsMonitor);
                _partsMonitorRepository.Context.Commit();
                list = Mapper.Map<List<PartsMonitorDetail>, PartsMonitorDetailDataObjectList>(results);
            }
            return list;
        }

        /// <summary>
        /// 删除PartsMonitorDetail
        /// </summary>
        /// <param name="partsMonitorDetailIds"></param>
        public bool DeletePartsMonitorDetail(int partsMonitorId, IDList partsMonitorDetailIds)
        {
            bool isSuccess = false;
            var partsMonitor = _partsMonitorRepository.GetByKey(partsMonitorId);
            if (partsMonitor != null)
            {
                foreach (var pmId in partsMonitorDetailIds)
                {
                    var pId = Convert.ToInt32(pmId);
                    var pm = partsMonitor.PartsMonitorDetails.FirstOrDefault(c => c.ID == pId);
                    if (pm != null)
                    {
                        //不为空则标识为删除
                        _partsMonitorRepository.EntityRegisterDeleted(pm);
                    }
                }
                _ccOrderRepository.Context.Commit();
                isSuccess = true;
            }
            return isSuccess;
        }

        /// <summary>
        /// 更新PartsMonitorDetail
        /// </summary>
        /// <param name="partsMonitorDetails"></param>
        /// <returns></returns>
        public PartsMonitorDetailDataObjectList UpdatePartsMonitorDetail(int partsMonitorId, PartsMonitorDetailDataObjectList partsMonitorDetails)
        {
            PartsMonitorDetailDataObjectList list = new PartsMonitorDetailDataObjectList();
            var partsMonitor = _partsMonitorRepository.GetByKey(partsMonitorId);
            if (partsMonitor != null)
            {
                foreach (var pmDetail in partsMonitorDetails)
                {
                    var pmd = partsMonitor.PartsMonitorDetails.FirstOrDefault(c => c.ID == pmDetail.ID);
                    if (pmd != null)
                    {
                        if (pmDetail.ExpireDate.Hour > 0)
                        {
                            pmd.ExpireDate = pmDetail.ExpireDate;
                        }
                        if (pmDetail.Interval > 0)
                        {
                            pmd.Interval = pmDetail.Interval;
                        }
                        if (pmDetail.Remain > 0)
                        {
                            pmd.Remain = pmDetail.Remain;
                        }
                        if (pmDetail.USN > 0)
                        {
                            pmd.USN = pmDetail.USN;
                        }
                        if (pmDetail.USO > 0)
                        {
                            pmd.USO = pmDetail.USO;
                        }
                        if (pmDetail.USR > 0)
                        {
                            pmd.USR = pmDetail.USR;
                        }

                    }
                    list.Add(Mapper.Map<PartsMonitorDetail, PartsMonitorDetailDataObject>(pmd));
                }
                _partsMonitorRepository.Update(partsMonitor);
                _partsMonitorRepository.Context.Commit();
            }
            return list;
        }

        /// <summary>
        /// 获取所有PartsMonitorDetail
        /// </summary>
        /// <returns></returns>
        public PartsMonitorDetailDataObjectList GetAllPartsMonitorDetails(int partsMonitorId)
        {
            PartsMonitorDetailDataObjectList list = new PartsMonitorDetailDataObjectList();
            var partsMonitor = _partsMonitorRepository.GetByKey(partsMonitorId);
            if (partsMonitor != null)
            {
                list = Mapper.Map<ICollection<PartsMonitorDetail>, PartsMonitorDetailDataObjectList>(partsMonitor.PartsMonitorDetails);
            }
            return list;
        }
        /// <summary>
        /// 获取监控相关的PartsMonitorDetail
        /// </summary>
        /// <returns></returns>
        public PartsMonitorDetailDataObjectList GetPartsMonitorDetailByMonitor(string[] keys)
        {
            return null;
        }

        /// <summary>
        /// 通过ID获取PartsMonitorDetail
        /// </summary>
        /// <param name="partsMonitorDetailId"></param>
        /// <returns></returns>
        public PartsMonitorDetailDataObject GetPartsMonitorDetail(int partsMonitorId, int partsMonitorDetailId)
        {
            var partsMonitor = _partsMonitorRepository.GetByKey(partsMonitorId);
            if (partsMonitor != null)
            {
                var pmd = partsMonitor.PartsMonitorDetails.FirstOrDefault(c => c.ID == partsMonitorDetailId);
                return Mapper.Map<PartsMonitorDetail, PartsMonitorDetailDataObject>(pmd);
            }
            else
                return null;
        }
        #endregion


        #region PnReg
        /// <summary>
        /// 添加PnReg
        /// </summary>
        /// <param name="pnRegs"></param>
        /// <returns></returns>
        public PnRegDataObjectList AddPnReg(PnRegDataObjectList pnRegs)
        {
            return PerformCreateObjects<PnRegDataObjectList, PnRegDataObject, PnReg>(pnRegs, _pnRegRepository);
        }

        /// <summary>
        /// 删除PnReg
        /// </summary>
        /// <param name="pnRegIds"></param>
        public void DeletePnReg(IDList pnRegIds)
        {
            PerformDeleteObjects<PnReg>(pnRegIds, _pnRegRepository);
        }

        /// <summary>
        /// 更新PnReg
        /// </summary>
        /// <param name="pnRegs"></param>
        /// <returns></returns>
        public PnRegDataObjectList UpdatePnReg(PnRegDataObjectList pnRegs)
        {
            return PerformUpdateObjects<PnRegDataObjectList, PnRegDataObject, PnReg>(pnRegs, _pnRegRepository, p => p.ID,
                (pn, pnr) =>
                {
                    pn.Ata = pnr.Ata;
                    if (!string.IsNullOrEmpty(pnr.Pn))
                        pn.Pn = pnr.Pn;
                    if (!string.IsNullOrEmpty(pnr.PnClass))
                        pn.PnClass = pnr.PnClass;
                    if (!string.IsNullOrEmpty(pnr.Vendor))
                        pn.Vendor = pnr.Vendor;
                    pn.UpdateTime = pnr.UpdateTime;
                    if (!string.IsNullOrEmpty(pnr.Updateby))
                        pn.Updateby = pnr.Updateby;
                    if (!string.IsNullOrEmpty(pnr.SpecPn))
                        pn.SpecPn = pnr.SpecPn;
                    if (!string.IsNullOrEmpty(pnr.State))
                        pn.State = pnr.State;
                    pn.IsLife = pnr.IsLife;
                    if (!string.IsNullOrEmpty(pnr.Description))
                        pn.Description = pnr.Description;
                });
        }

        /// <summary>
        /// 获取所有PnReg
        /// </summary>
        /// <returns></returns>
        public PnRegDataObjectList GetAllPnRegs()
        {
            return _componentQuery.GetPnRegs();
        }

        /// <summary>
        /// 通过ID获取PnReg
        /// </summary>
        /// <param name="pnRegId"></param>
        /// <returns></returns>
        public PnRegDataObject GetPnReg(int pnRegId)
        {
            var pnReg = _pnRegRepository.GetByKey(pnRegId);
            if (pnReg != null)
                return Mapper.Map<PnReg, PnRegDataObject>(pnReg);
            return null;
        }
        /// <summary>
        /// 通过ID获取PnReg
        /// </summary>
        /// <param name="pnRegId"></param>
        /// <returns></returns>
        public PnRegDataObject GetPnRegByPn(string pn)
        {
            PnRegDataObject pnr = null;
            Expression<Func<PnReg, bool>> express = c => true;
            if (!string.IsNullOrEmpty(pn))
            {
                express = express.And(main => main.Pn.Equals(pn));
            }
            var sns = _pnRegRepository.GetAll(Specification<PnReg>.Eval(express));
            if (sns != null && sns.Count()>0)
            {
                pnr = Mapper.Map<PnReg, PnRegDataObject>(sns.FirstOrDefault());
            }
            
            return pnr;
        }
        /// <summary>
        /// 提交PnReg的增删改数据
        /// </summary>
        /// <param name="pnRegData"></param>
        /// <returns>提交成功的数据</returns>
        public PnRegResultData CommitPnRegs(PnRegResultData pnRegData)
        {
            var resultData = new PnRegResultData
            {
                AddedCollection =
                   new PnRegDataObjectList(),
                DeletedCollection = new List<string>(),
                ModefiedCollection =
                   new PnRegDataObjectList()
            };
            var addList = new List<PnReg>();
            IEnumerable<string> deleteList = new List<string>();
            var updateList = new List<PnReg>();

            #region Input

            if (pnRegData.AddedCollection != null && pnRegData.AddedCollection.Any())
            {
                pnRegData.AddedCollection.ForEach(
                p =>
                {
                    addList.Add(Mapper.Map<PnRegDataObject, PnReg>(p));
                });
            }
            if (pnRegData.DeletedCollection != null && pnRegData.DeletedCollection.Any())
            {
                deleteList = pnRegData.DeletedCollection;
            }
            if (pnRegData.ModefiedCollection != null && pnRegData.ModefiedCollection.Any())
            {
                pnRegData.ModefiedCollection.ForEach(
                   p => updateList.Add(Mapper.Map<PnRegDataObject, PnReg>(p)));
            }

            #endregion

            _pnRegRepository.CommitPnReg(ref addList, ref deleteList, ref updateList);

            #region Output

            var addResults = new ObservableCollection<PnRegDataObject>();
            if (addList.Any())
            {
                addList.ForEach(
                   p => addResults.Add(Mapper.Map<PnReg, PnRegDataObject>(p)));
                resultData.AddedCollection = addResults;
            }
            var updateResults = new ObservableCollection<PnRegDataObject>();
            if (updateList.Any())
            {
                updateList.ForEach(
                   p => updateResults.Add(Mapper.Map<PnReg, PnRegDataObject>(p)));
                resultData.ModefiedCollection = updateResults;
            }
            if (deleteList != null && deleteList.Any())
            {
                resultData.DeletedCollection = deleteList;
            }

            #endregion

            return resultData;
        }
        #endregion

        #region ScnAcorder
        /// <summary>
        /// 添加ScnAcorder
        /// </summary>
        /// <param name="scnAcorders"></param>
        /// <returns></returns>
        public ScnAcorderDataObjectList AddScnAcorder(int scnMainId, ScnAcorderDataObjectList scnAcorders)
        {
            ScnAcorderDataObjectList list = new ScnAcorderDataObjectList();
            var scnMain = _scnMainRepository.GetByKey(scnMainId);
            List<ScnAcorder> results = new List<ScnAcorder>();
            if (scnMain != null)
            {
                foreach (var acord in scnAcorders)
                {
                    var p = Mapper.Map<ScnAcorderDataObject, ScnAcorder>(acord);
                    results.Add(p);
                    scnMain.ScnAcorders.Add(p);
                }
                _scnMainRepository.Update(scnMain);
                _scnMainRepository.Context.Commit();
                list = Mapper.Map<List<ScnAcorder>, ScnAcorderDataObjectList>(results);
            }
            return list;
        }

        /// <summary>
        /// 删除ScnAcorder
        /// </summary>
        /// <param name="scnAcorderIds"></param>
        public bool DeleteScnAcorder(int scnMainId, IDList scnAcorderIds)
        {
            bool isSuccess = false;
            var scnMain = _scnMainRepository.GetByKey(scnMainId);
            if (scnMain != null)
            {
                foreach (var acordId in scnAcorderIds)
                {
                    var aId = Convert.ToInt32(acordId);
                    var acorder = scnMain.ScnAcorders.FirstOrDefault(c => c.ID == aId);
                    if (acorder != null)
                    {
                        //不为空则标识为删除
                        _scnMainRepository.EntityRegisterDeleted(acorder);
                    }
                }
                _scnMainRepository.Context.Commit();
                isSuccess = true;
            }
            return isSuccess;
        }

        /// <summary>
        /// 更新ScnAcorder
        /// </summary>
        /// <param name="scnAcorders"></param>
        /// <returns></returns>
        public ScnAcorderDataObjectList UpdateScnAcorder(int scnMainId, ScnAcorderDataObjectList scnAcorders)
        {
            ScnAcorderDataObjectList list = new ScnAcorderDataObjectList();
            var scnMain = _scnMainRepository.GetByKey(scnMainId);
            if (scnMain != null)
            {
                foreach (var acorder in scnAcorders)
                {
                    var aco = scnMain.ScnAcorders.FirstOrDefault(c => c.ID == acorder.ID);
                    if (aco != null)
                    {
                        if (!string.IsNullOrEmpty(acorder.AcOrder))
                        {
                            aco.AcOrder = acorder.AcOrder;
                        }
                        if (!string.IsNullOrEmpty(acorder.AcOrderItem))
                        {
                            aco.AcOrderItem = acorder.AcOrderItem;
                        }
                        if (!string.IsNullOrEmpty(acorder.Notes))
                        {
                            aco.Notes = acorder.Notes;
                        }
                    }
                    list.Add(Mapper.Map<ScnAcorder, ScnAcorderDataObject>(aco));
                }
                _scnMainRepository.Update(scnMain);
                _scnMainRepository.Context.Commit();
            }
            return list;
        }

        /// <summary>
        /// 获取所有ScnAcorder
        /// </summary>
        /// <returns></returns>
        public ScnAcorderDataObjectList GetAllScnAcorders(int scnMainId)
        {
            ScnAcorderDataObjectList list = new ScnAcorderDataObjectList();
            var scnMain = _scnMainRepository.GetByKey(scnMainId);
            if (scnMain != null)
            {
                list = Mapper.Map<ICollection<ScnAcorder>, ScnAcorderDataObjectList>(scnMain.ScnAcorders);
            }
            return list;
        }

        /// <summary>
        /// 通过ID获取ScnAcorder
        /// </summary>
        /// <param name="scnAcorderId"></param>
        /// <returns></returns>
        public ScnAcorderDataObject GetScnAcorder(int scnMainId, int scnAcorderId)
        {
            var scnMain = _scnMainRepository.GetByKey(scnMainId);
            if (scnMain != null)
            {
                var pmd = scnMain.ScnAcorders.FirstOrDefault(c => c.ID == scnAcorderId);
                return Mapper.Map<ScnAcorder, ScnAcorderDataObject>(pmd);
            }
            else
                return null;
        }
        #endregion

        #region ScnItem
        /// <summary>
        /// 添加ScnItem
        /// </summary>
        /// <param name="scnItems"></param>
        /// <returns></returns>
        public ScnItemDataObjectList AddScnItem(int scnMainId, ScnItemDataObjectList scnItems)
        {
            ScnItemDataObjectList list = new ScnItemDataObjectList();
            var scnMain = _scnMainRepository.GetByKey(scnMainId);
            List<ScnItem> results = new List<ScnItem>();
            if (scnMain != null)
            {
                foreach (var item in scnItems)
                {
                    var p = Mapper.Map<ScnItemDataObject, ScnItem>(item);
                    results.Add(p);
                    scnMain.ScnItems.Add(p);
                }
                _scnMainRepository.Update(scnMain);
                _scnMainRepository.Context.Commit();
                list = Mapper.Map<List<ScnItem>, ScnItemDataObjectList>(results);
            }
            return list;
        }

        /// <summary>
        /// 删除ScnItem
        /// </summary>
        /// <param name="scnItemIds"></param>
        public bool DeleteScnItem(int scnMainId, IDList scnItemIds)
        {
            bool isSuccess = false;
            var scnMain = _scnMainRepository.GetByKey(scnMainId);
            if (scnMain != null)
            {
                foreach (var itemId in scnItemIds)
                {
                    var aId = Convert.ToInt32(itemId);
                    var item = scnMain.ScnItems.FirstOrDefault(c => c.ID == aId);
                    if (item != null)
                    {
                        //不为空则标识为删除
                        _scnMainRepository.EntityRegisterDeleted(item);
                    }
                }
                _scnMainRepository.Context.Commit();
                isSuccess = true;
            }
            return isSuccess;
        }

        /// <summary>
        /// 更新ScnItem
        /// </summary>
        /// <param name="scnItems"></param>
        /// <returns></returns>
        public ScnItemDataObjectList UpdateScnItem(int scnMainId, ScnItemDataObjectList scnItems)
        {
            ScnItemDataObjectList list = new ScnItemDataObjectList();
            var scnMain = _scnMainRepository.GetByKey(scnMainId);
            if (scnMain != null)
            {
                foreach (var item in scnItems)
                {
                    var it = scnMain.ScnItems.FirstOrDefault(c => c.ID == item.ID);
                    if (it != null)
                    {
                        if (item.AtaGuid != null)
                        {
                            it.AtaGuid = item.AtaGuid;
                        }
                        if (item.AtaID > 0)
                        {
                            it.AtaID = item.AtaID;
                        }
                        if (!string.IsNullOrEmpty(item.Currency))
                        {
                            it.Currency = item.Currency;
                        }
                        if (!string.IsNullOrEmpty(item.Description))
                        {
                            it.Description = item.Description;
                        }
                        if (item.ItemNo > 0)
                        {
                            it.ItemNo = item.ItemNo;
                        }
                        if (!string.IsNullOrEmpty(item.Notes))
                        {
                            it.Notes = item.Notes;
                        }
                        if (!string.IsNullOrEmpty(item.Pn))
                        {
                            it.Pn = item.Pn;
                        }
                        if (item.PnRegID.HasValue)
                        {
                            it.PnRegID = item.PnRegID;
                        }
                        if (item.Price > 0)
                        {
                            it.Price = item.Price;
                        }
                        if (item.PnRegID.HasValue)
                        {
                            it.PnRegID = item.PnRegID;
                        }
                        if (item.Qty > 0)
                        {
                            it.Qty = item.Qty;
                        }
                        if (item.TotalPrice > 0)
                        {
                            it.TotalPrice = item.TotalPrice;
                        }
                        if (!string.IsNullOrEmpty(item.Vendor))
                        {
                            it.Vendor = item.Vendor;
                        }

                    }
                    list.Add(Mapper.Map<ScnItem, ScnItemDataObject>(it));
                }
                _scnMainRepository.Update(scnMain);
                _scnMainRepository.Context.Commit();
            }
            return list;
        }

        /// <summary>
        /// 获取所有ScnItem
        /// </summary>
        /// <returns></returns>
        public ScnItemDataObjectList GetAllScnItems(int scnMainId)
        {
            ScnItemDataObjectList list = new ScnItemDataObjectList();
            var scnMain = _scnMainRepository.GetByKey(scnMainId);
            if (scnMain != null)
            {
                list = Mapper.Map<ICollection<ScnItem>, ScnItemDataObjectList>(scnMain.ScnItems);
            }
            return list;
        }

        /// <summary>
        /// 通过ID获取ScnItem
        /// </summary>
        /// <param name="scnItemId"></param>
        /// <returns></returns>
        public ScnItemDataObject GetScnItem(int scnMainId, int scnItemId)
        {
            var scnMain = _scnMainRepository.GetByKey(scnMainId);
            if (scnMain != null)
            {
                var pmd = scnMain.ScnItems.FirstOrDefault(c => c.ID == scnItemId);
                return Mapper.Map<ScnItem, ScnItemDataObject>(pmd);
            }
            else
                return null;
        }

        /// <summary>
        /// 根据ScnMainID查询所属明细
        /// </summary>
        /// <param name="scnMainId"></param>
        /// <returns></returns>
        public ScnItemDtoList QueryAllScnItems(int scnMainId)
        {
            var scnItemDtos = new ScnItemDtoList();
            var scnMain = _scnMainRepository.GetByKey(scnMainId);
            foreach (var scnItem in scnMain.ScnItems)
            {
                var scnItemDto = new ScnItemDto();
                scnItemDto.ID = scnItem.ID;
                scnItemDto.Currency = scnItem.Currency;
                scnItemDto.Description = scnItem.Description;
                scnItemDto.ItemNo = scnItem.ItemNo;
                scnItemDto.Notes = scnItem.Notes;
                scnItemDto.Pn = scnItem.Pn;
                var pn = _pnRegRepository.GetByKey(scnItem.PnRegID);
                if (pn != null)
                    scnItemDto.PnClass = pn.PnClass;
                scnItemDto.Price = scnItem.Price;
                scnItemDto.Qty = scnItem.Qty;
                scnItemDto.ScnNo = scnMain.ScnNo;
                scnItemDto.TotalPrice = scnItem.TotalPrice;
                scnItemDto.Vendor = scnItem.Vendor;
                scnItemDtos.Add(scnItemDto);
            }
            return scnItemDtos;
        }
        #endregion

        #region ScnMain
        /// <summary>
        /// 添加ScnMain
        /// </summary>
        /// <param name="scnMains"></param>
        /// <returns></returns>
        public ScnMainDataObjectList AddScnMain(ScnMainDataObjectList scnMains)
        {
            return
              PerformCreateObjects<ScnMainDataObjectList, ScnMainDataObject, ScnMain>(scnMains, _scnMainRepository);
        }

        /// <summary>
        /// 删除ScnMain
        /// </summary>
        /// <param name="scnMainIds"></param>
        public bool DeleteScnMain(IDList scnMainIds)
        {
            bool isSuccess = false;
            foreach (var scnMainId in scnMainIds)
            {
                var scnMain = _scnMainRepository.GetByKey(scnMainId);
                //移除子项
                for (int i = scnMain.ScnAcorders.Count; i > 0; i--)
                {
                    _scnMainRepository.EntityRegisterDeleted(scnMain.ScnAcorders.ElementAt(i - 1));
                }
                for (int i = scnMain.ScnItems.Count; i > 0; i--)
                {
                    _scnMainRepository.EntityRegisterDeleted(scnMain.ScnItems.ElementAt(i - 1));
                }
                _scnMainRepository.Remove(scnMain);
            }
            _scnMainRepository.Context.Commit();
            isSuccess = true;
            return isSuccess;
        }

        /// <summary>
        /// 更新ScnMain
        /// </summary>
        /// <param name="scnMains"></param>
        /// <returns></returns>
        public ScnMainDataObjectList UpdateScnMain(ScnMainDataObjectList scnMains)
        {
            return
                PerformUpdateObjects<ScnMainDataObjectList, ScnMainDataObject, ScnMain>(scnMains, _scnMainRepository,
                s => s.ID, (scn, scnDto) =>
                {
                    if (scnDto.AcModelGuid != null)
                    {
                        scn.AcModelGuid = scnDto.AcModelGuid;
                    }
                    if (scnDto.AcModelID > 0)
                    {
                        scn.AcModelID = scnDto.AcModelID;
                    }
                    if (scnDto.AcTypeGuid != null)
                    {
                        scn.AcTypeGuid = scnDto.AcTypeGuid;
                    }
                    if (scnDto.AcTypeID > 0)
                    {
                        scn.AcTypeID = scnDto.AcTypeID;
                    }
                    if (!string.IsNullOrEmpty(scnDto.Description))
                    {
                        scn.Description = scnDto.Description;
                    }
                    if (!string.IsNullOrEmpty(scnDto.ScnNo))
                    {
                        scn.ScnNo = scnDto.ScnNo;
                    }
                    if (!string.IsNullOrEmpty(scnDto.State))
                    {
                        scn.State = scnDto.State;
                    }
                    if (!string.IsNullOrEmpty(scnDto.Version))
                    {
                        scn.Version = scnDto.Version;
                    }
                });
        }

        /// <summary>
        /// 获取所有ScnMain
        /// </summary>
        /// <returns></returns>
        public ScnMainDataObjectList GetAllScnMains()
        {
            ScnMainDataObjectList list = new ScnMainDataObjectList();
            var results = _scnMainRepository.GetAll();
            foreach (var scnMain in results)
            {
                var dto = Mapper.Map<ScnMain, ScnMainDataObject>(scnMain);
                //取机号
                if (dto.ScnAcorders.Count > 0)
                {
                    foreach (var acorder in dto.ScnAcorders)
                    {
                        AFRP.AFRPServiceClient _client = new AFRP.AFRPServiceClient();
                        acorder.Acreg = _client.GetAcRegByContractRank(acorder.AcOrder, int.Parse(acorder.AcOrderItem));
                    }
                }
                list.Add(dto);
            }
            return list;
        }

        /// <summary>
        /// 通过ID获取ScnMain
        /// </summary>
        /// <param name="scnMainId"></param>
        /// <returns></returns>
        public ScnMainDataObject GetScnMain(int scnMainId)
        {
            var result = _scnMainRepository.GetByKey(scnMainId);
            if (result != null)
            {
                var scnMainDto = Mapper.Map<ScnMain, ScnMainDataObject>(result);
                var wfHistorys =
                    _wfHistoryRepository.GetAll(
                        Specification<WfHistory>.Eval(
                            w => w.BusinessID == scnMainDto.ID && w.Business.ToLower() == "scnmain"));
                if (wfHistorys.Count() > 0)
                {
                    var wfHistoryDtos = Mapper.Map<IEnumerable<WfHistory>, WfHistoryDataObjectList>(wfHistorys);
                    scnMainDto.WfHistorys = wfHistoryDtos;
                }
                return scnMainDto;
            }
            else
                return null;
        }

        /// <summary>
        /// 提交ScnMain的增删改数据
        /// </summary>
        /// <param name="scnMainData"></param>
        /// <returns>提交成功的数据</returns>
        public ScnMainResultData CommitScnMains(ScnMainResultData scnMainData)
        {
            //判断合同号，机号是否正确
            foreach (var scnMainDataObject in scnMainData.AddedCollection)
            {
                if (scnMainDataObject.ScnAcorders.Count > 0)
                {
                    foreach (var scnAcorder in scnMainDataObject.ScnAcorders)
                    {
                        AFRP.AFRPServiceClient _client = new AFRP.AFRPServiceClient();
                        //如果不存在这个合同项次，则抛出异常
                        if (!_client.ValidationByContractRank(scnAcorder.AcOrder, int.Parse(scnAcorder.AcOrderItem)))
                        {
                            throw new Exception("不存在合同号:"+scnAcorder.AcOrder+" 合同项次号:"+scnAcorder.AcOrderItem
                                +" 的记录，请重新输入");
                        }
                    }
                }
            }

            var resultData = new ScnMainResultData
            {
                AddedCollection =
                   new ScnMainDataObjectList(),
                DeletedCollection = new List<string>(),
                ModefiedCollection =
                   new ScnMainDataObjectList()
            };
            var addList = new List<ScnMain>();
            IEnumerable<string> deleteList = new List<string>();
            var updateList = new List<ScnMain>();

            var addWfList = new List<WfHistory>();
            var updateWfList = new List<WfHistory>();


            #region Input

            if (scnMainData.AddedCollection != null && scnMainData.AddedCollection.Any())
            {
                scnMainData.AddedCollection.ForEach(
                p =>
                {
                    addList.Add(Mapper.Map<ScnMainDataObject, ScnMain>(p));
                    p.WfHistorys.ForEach(e =>
                    {
                        var wf = Mapper.Map<WfHistoryDataObject, WfHistory>(e);

                        wf.BusinessID = p.ID;
                        wf.Business = "scnmain";
                        addWfList.Add(wf);
                    });
                });
            }
            if (scnMainData.DeletedCollection != null && scnMainData.DeletedCollection.Any())
            {
                deleteList = scnMainData.DeletedCollection;
            }
            if (scnMainData.ModefiedCollection != null && scnMainData.ModefiedCollection.Any())
            {
                scnMainData.ModefiedCollection.ForEach(
                    p =>
                    {
                        updateList.Add(Mapper.Map<ScnMainDataObject, ScnMain>(p));
                        updateWfList.AddRange(Mapper.Map<WfHistoryDataObjectList, List<WfHistory>>(p.WfHistorys));
                    });

            }

            #endregion

            _scnMainRepository.CommitScnMain(ref addList, ref deleteList, ref updateList);
            //处理wfhistory

            //只增加一条记录的有效
            if (addList.Count > 0)
            {
                addWfList.ForEach(a =>
                {
                    a.BusinessID = addList.First().ID;
                });
            }


            IEnumerable<string> list = new List<string>();
            _wfHistoryRepository.CommitWfHistory(ref addWfList, ref list, ref updateWfList);
            this.Context.Commit();

            #region Output

            var addResults = new ObservableCollection<ScnMainDataObject>();
            if (addList.Any())
            {
                addList.ForEach(
                    p =>
                    {
                        var dto = Mapper.Map<ScnMain, ScnMainDataObject>(p);
                        var wfDtos = Mapper.Map<List<WfHistory>, WfHistoryDataObjectList>(addWfList);
                        dto.WfHistorys = wfDtos;
                        //取机号
                        if (dto.ScnAcorders.Count > 0)
                        {
                            foreach (var acorder in dto.ScnAcorders)
                            {
                                AFRP.AFRPServiceClient _client = new AFRP.AFRPServiceClient();
                                acorder.Acreg = _client.GetAcRegByContractRank(acorder.AcOrder, int.Parse(acorder.AcOrderItem));
                            }
                        }
                        addResults.Add(dto);
                    });
                resultData.AddedCollection = addResults;
            }
            var updateResults = new ObservableCollection<ScnMainDataObject>();
            if (updateList.Any())
            {
                updateList.ForEach(
                    p =>
                    {
                        var dto = Mapper.Map<ScnMain, ScnMainDataObject>(p);
                        var wfDtos = Mapper.Map<List<WfHistory>, WfHistoryDataObjectList>(addWfList);
                        dto.WfHistorys = wfDtos;
                        //取机号
                        if (dto.ScnAcorders.Count > 0)
                        {
                            foreach (var acorder in dto.ScnAcorders)
                            {
                                AFRP.AFRPServiceClient _client = new AFRP.AFRPServiceClient();
                                acorder.Acreg = _client.GetAcRegByContractRank(acorder.AcOrder, int.Parse(acorder.AcOrderItem));
                            }
                        }
                        addResults.Add(dto);
                    });
                resultData.ModefiedCollection = updateResults;
            }
            if (deleteList != null && deleteList.Any())
            {
                resultData.DeletedCollection = deleteList;
            }

            #endregion

            return resultData;
        }
        #endregion

        #region SnHistory
        /// <summary>
        /// 添加SnHistory
        /// </summary>
        /// <param name="snHistorys"></param>
        /// <returns></returns>
        public SnHistoryDataObjectList AddSnHistory(SnHistoryDataObjectList snHistorys)
        {
            return PerformCreateObjects<SnHistoryDataObjectList, SnHistoryDataObject, SnHistory>(snHistorys,
                                                                                                 _snHistoryRepository);
        }

        /// <summary>
        /// 删除SnHistory
        /// </summary>
        /// <param name="snHistoryIds"></param>
        public void DeleteSnHistory(IDList snHistoryIds)
        {
            foreach (var snHistoryId in snHistoryIds)
            {
                var snHistory = _snHistoryRepository.Get(Specification<SnHistory>.Eval(s => s.ID.ToString() == snHistoryId));
                if (snHistory != null)
                {
                    _snHistoryRepository.DeleteSnHistory(snHistory);
                }
            }
        }

        /// <summary>
        /// 更新SnHistory
        /// </summary>
        /// <param name="snHistorys"></param>
        /// <returns></returns>
        public SnHistoryDataObjectList UpdateSnHistory(SnHistoryDataObjectList snHistorys)
        {
            return PerformUpdateObjects<SnHistoryDataObjectList, SnHistoryDataObject, SnHistory>(snHistorys, _snHistoryRepository, s => s.ID,
                (sn, snh) =>
                {
                    sn.SnRegID = snh.SnRegID;
                    sn.NhSnRegID = snh.NhSnRegID;
                    sn.RootSnRegID = snh.RootSnRegID;                    
                    sn.Ac = snh.Ac;
                    sn.Ata = snh.Ata;
                    sn.NextHis = snh.NextHis;
                    if (!string.IsNullOrEmpty(snh.Active))
                        sn.Active = snh.Active;
                    sn.ActiveDate = snh.ActiveDate;
                    if (!string.IsNullOrEmpty(snh.Position))
                        sn.Position = snh.Position;
                    if (!string.IsNullOrEmpty(snh.Note))
                        sn.Note = snh.Note;
                    if (!string.IsNullOrEmpty(snh.EngineTli))
                        sn.EngineTli = snh.EngineTli;
                    
                });
        }

        /// <summary>
        /// 获取所有SnHistory
        /// </summary>
        /// <returns></returns>
        public SnHistoryDataObjectList GetAllSnHistorys()
        {
            var snHistorys = new SnHistoryDataObjectList();
            var sns = _snHistoryRepository.GetAll();
            if (sns != null)
                snHistorys.AddRange(sns.Select(Mapper.Map<SnHistory, SnHistoryDataObject>));
            return snHistorys;
        }

        /// <summary>
        /// 通过ID获取SnHistory
        /// </summary>
        /// <param name="snHistoryId"></param>
        /// <returns></returns>
        public SnHistoryDataObject GetSnHistory(int snHistoryId)
        {
            SnHistoryDataObject sh = null;
            var snHistory = _snHistoryRepository.GetByKey(snHistoryId);
            if (snHistory != null) { 
                sh = Mapper.Map<SnHistory, SnHistoryDataObject>(snHistory);
                if (sh != null && sh.SnHistoryUnits != null && sh.SnHistoryUnits.Count > 0) {

                    sh.SnHistoryFh = sh.SnHistoryUnits.Where(o => "FH".Equals(o.Unit)).FirstOrDefault();
                    sh.SnHistoryCy = sh.SnHistoryUnits.Where(o => "CY".Equals(o.Unit)).FirstOrDefault();
                }
            }              
            return sh;
        }

        
        /// <summary>
        /// 通过ID获取SnHistory
        /// </summary>
        /// <param name="snHistoryId"></param>
        /// <returns></returns>
        public SnHistoryDataObject GetLastSnHistoryBySnregID(int snRegId)
        {
            SnHistoryDataObject sh = null;
            var snHistory = _snHistoryRepository.GetLastSnHistoryBySnregID(snRegId.ToString());
            if (snHistory != null) {

                sh = Mapper.Map<SnHistory, SnHistoryDataObject>(snHistory);
                if (sh != null && sh.SnHistoryUnits != null && sh.SnHistoryUnits.Count > 0) {

                    sh.SnHistoryFh = sh.SnHistoryUnits.Where(o => "FH".Equals(o.Unit)).FirstOrDefault();
                    sh.SnHistoryCy = sh.SnHistoryUnits.Where(o => "CY".Equals(o.Unit)).FirstOrDefault();
                }
            }               
            return sh;
        }
        
        /// <summary>
        /// 提交SnHistory的增删改数据
        /// </summary>
        /// <param name="snHistoryData"></param>
        /// <returns>提交成功的数据</returns>
        public SnHistoryResultData CommitSnHistorys(SnHistoryResultData snHistoryData)
        {
            var resultData = new SnHistoryResultData
            {
                AddedCollection =
                   new SnHistoryDataObjectList(),
                DeletedCollection = new List<string>(),
                ModefiedCollection =
                   new SnHistoryDataObjectList()
            };
            var addList = new List<SnHistory>();
            IEnumerable<string> deleteList = new List<string>();
            var updateList = new List<SnHistory>();

            #region Input

            if (snHistoryData.AddedCollection != null && snHistoryData.AddedCollection.Any())
            {
                snHistoryData.AddedCollection.ForEach(
                p =>
                {
                    addList.Add(Mapper.Map<SnHistoryDataObject, SnHistory>(p));
                });
            }
            if (snHistoryData.DeletedCollection != null && snHistoryData.DeletedCollection.Any())
            {
                deleteList = snHistoryData.DeletedCollection;
            }
            if (snHistoryData.ModefiedCollection != null && snHistoryData.ModefiedCollection.Any())
            {
                snHistoryData.ModefiedCollection.ForEach(
                   p => updateList.Add(Mapper.Map<SnHistoryDataObject, SnHistory>(p)));
            }

            #endregion

            _snHistoryRepository.CommitSnHistory(ref addList, ref deleteList, ref updateList);

            #region Output

            var addResults = new ObservableCollection<SnHistoryDataObject>();
            if (addList.Any())
            {
                addList.ForEach(
                   p => addResults.Add(Mapper.Map<SnHistory, SnHistoryDataObject>(p)));
                resultData.AddedCollection = addResults;
            }
            var updateResults = new ObservableCollection<SnHistoryDataObject>();
            if (updateList.Any())
            {
                updateList.ForEach(
                   p => updateResults.Add(Mapper.Map<SnHistory, SnHistoryDataObject>(p)));
                resultData.ModefiedCollection = updateResults;
            }
            if (deleteList != null && deleteList.Any())
            {
                resultData.DeletedCollection = deleteList;
            }

            #endregion

            return resultData;
        }

        public SnHistoryDataObjectList QuerySnHistorys(string ac, string itemNo, string pn, DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region SnHistoryUnit
        /// <summary>
        /// 添加SnHistoryUnit
        /// </summary>
        /// <param name="snHistoryId"></param>
        /// <param name="snHistoryUnits"></param>
        /// <returns></returns>
        public SnHistoryUnitDataObjectList AddSnHistoryUnit(int snHistoryId, SnHistoryUnitDataObjectList snHistoryUnits)
        {
            var snHistory = _snHistoryRepository.GetByKey(snHistoryId);
            if (snHistory != null)
            {
                foreach (var snHistoryUnit in snHistoryUnits)
                {
                    snHistory.SnHistoryUnits.Add(Mapper.Map<SnHistoryUnitDataObject, SnHistoryUnit>(snHistoryUnit));
                }
                _snHistoryRepository.Update(snHistory);
                _snHistoryRepository.Context.Commit();
            }
            return snHistoryUnits;
        }

        /// <summary>
        /// 删除SnHistoryUnit
        /// </summary>
        /// <param name="snHistoryId"></param>
        /// <param name="snHistoryUnits"></param>
        public void DeleteSnHistoryUnit(int snHistoryId, SnHistoryUnitDataObjectList snHistoryUnits)
        {
            var snHistory = _snHistoryRepository.GetByKey(snHistoryId);
            if (snHistory != null)
            {
                _snHistoryRepository.DeleteSnHistoryUnit(snHistory, snHistoryUnits.Select(Mapper.Map<SnHistoryUnitDataObject, SnHistoryUnit>));
                _snHistoryRepository.Context.Commit();
            }
        }

        /// <summary>
        /// 更新SnHistoryUnit
        /// </summary>
        /// <param name="snHistoryId"></param>
        /// <param name="snHistoryUnits"></param>
        /// <returns></returns>
        public SnHistoryUnitDataObjectList UpdateSnHistoryUnit(int snHistoryId, SnHistoryUnitDataObjectList snHistoryUnits)
        {
            var snHistory = _snHistoryRepository.GetByKey(snHistoryId);
            if (snHistory != null)
            {
                foreach (var snHistoryUnit in snHistoryUnits)
                {
                    var unit = snHistory.SnHistoryUnits.FirstOrDefault(s => s.ID == snHistoryUnit.ID);
                    if (unit != null)
                    {
                        unit.Unit = snHistoryUnit.Unit;
                        unit.USN = snHistoryUnit.USN;
                        unit.USO = snHistoryUnit.USO;
                        unit.USR = snHistoryUnit.USR;
                    }
                }
                _snHistoryRepository.Update(snHistory);
                _snHistoryRepository.Context.Commit();
            }
            return snHistoryUnits;
        }

        /// <summary>
        /// 通过SnHistotyID获取SnHistoryUnit
        /// </summary>
        /// <param name="snHistoryId"></param>
        /// <returns></returns>
        public SnHistoryUnitDataObjectList GetSnHistoryUnit(int snHistoryId)
        {
            var snHistoryUnits = new SnHistoryUnitDataObjectList();
            var snHistory = _snHistoryRepository.GetByKey(snHistoryId);
            if (snHistory != null)
                snHistoryUnits.AddRange(snHistory.SnHistoryUnits.Select(Mapper.Map<SnHistoryUnit, SnHistoryUnitDataObject>));
            return snHistoryUnits;
        }

        /// <summary>
        /// 根据SnRegID获取SnHistory
        /// </summary>
        /// <param name="snRegID"></param>
        /// <returns></returns>
        public SnHistoryDataObjectList GetSnHistoryBySnRegID(int snRegID)
        {
            var snHistorylist = new SnHistoryDataObjectList();
            var snHistorys = _snHistoryRepository.GetAll(Specification<SnHistory>.Eval(s => s.SnRegID == snRegID));
            if (snHistorys != null)
                snHistorylist.AddRange(snHistorys.Select(Mapper.Map<SnHistory, SnHistoryDataObject>));
            return snHistorylist;
        }
        #endregion

        #region SnReg

        /// <summary>
        /// 添加SnReg
        /// </summary>
        /// <param name="snRegs"></param>
        /// <returns></returns>
        public SnRegDataObjectList ImportSnRegs(SnRegDataObjectList snRegs)
        {
            SnRegDataObjectList dbs = AddSnReg(snRegs);
            List<SnReg> updateList = new List<SnReg>();
            SnHistoryDataObjectList db = new SnHistoryDataObjectList();
            //上下级再处理
            foreach(var snreg in snRegs){
                if (snreg.NhSnReg != null && (snreg.NhSnReg.PnReg != null || snreg.NhSnReg.PnRegID > 0))
                {
                    SnRegDataObject dbSn = dbs.Where(o => snreg.Sn.Equals(o.Sn) && snreg.PnReg.Pn.Equals(o.PnReg.Pn)).FirstOrDefault();
                    if (dbSn.NhSnRegID <= 0 || dbSn.NhSnRegID == dbSn.ID)
                    {
                        SnRegDataObject nhSnreg;
                        string nhPn = "";
                        string nhSn = snreg.NhSnReg.Sn;
                        if (snreg.NhSnReg.PnRegID > 0)
                        {
                            nhPn = GetPnReg(snreg.NhSnReg.PnRegID).Pn;
                        }
                        else
                        {
                            nhPn = snreg.NhSnReg.PnReg.Pn;
                        }
                        var nhSnregs = dbs.Where(o => nhSn.Equals(o.Sn) && nhPn.Equals(o.PnReg.Pn));
                        if (nhSnregs != null && nhSnregs.Count() > 0)
                        {
                            nhSnreg = nhSnregs.FirstOrDefault();
                        }
                        else {
                            nhSnreg = GetSnRegByPnSn(nhPn, nhSn);
                        }
                        

                        if (nhSnreg != null)
                        {
                            dbSn.RootSnRegID = nhSnreg.RootSnRegID;
                            dbSn.NhSnRegID = nhSnreg.ID;
                        }
                        else
                        {
                            dbSn.RootSnRegID = dbSn.ID;
                        }
                        SnHistoryDataObject sh = GetLastSnHistoryBySnregID(dbSn.ID);
                        if (sh != null) {
                            sh.NhSnRegID = dbSn.NhSnRegID;
                            sh.RootSnRegID = dbSn.RootSnRegID;                            
                            db.Add(sh);
                            
                        }                                               
                        updateList.Add(Mapper.Map<SnRegDataObject, SnReg>(dbSn));
                        
                    }
                }
            }
            _snRegRepository.CommitSnReg(null, null, updateList);
            UpdateSnHistory(db);
            return dbs;
        }

        /// <summary>
        /// 添加SnReg
        /// </summary>
        /// <param name="snRegs"></param>
        /// <returns></returns>
        public SnRegDataObjectList AddSnReg(SnRegDataObjectList snRegs)
        {            
            var addList = new List<SnReg>();
            var updList = new List<SnReg>();
            foreach (var snreg in snRegs)
            {
                PnRegDataObject part = this.GetPnRegByPn(snreg.PnReg.Pn);
                //件号有效性校验
                if (part == null)
                {
                    throw new Exception(snreg.PnReg.Pn + "：件号不存在");
                }
                //重复性校验
                var sn = Mapper.Map<SnRegDataObject, SnReg>(snreg);
                sn.PnRegID = part.ID;
                SnRegDataObject db = GetSnRegByPnSn(snreg.PnReg.Pn, snreg.Sn);
                if (db != null && db.ID>0)
                {
                    sn.ID = db.ID;
                    updList.Add(sn);
                }
                else {
                    addList.Add(sn);
                }                
                #region 上下级关联
                if (snreg.NhSnReg != null && (snreg.NhSnReg.PnReg != null || snreg.NhSnReg.PnRegID > 0))
                {
                    SnReg nhSnreg;
                    string nhPn = "";
                    string nhSn = snreg.NhSnReg.Sn;
                    if (snreg.NhSnReg.PnRegID > 0)
                    {
                        nhPn = GetPnReg(snreg.NhSnReg.PnRegID).Pn;
                    }
                    else
                    {
                        nhPn = snreg.NhSnReg.PnReg.Pn;
                    }
                    
                    var nhSnregs = GetSnRegObjs(0, nhPn, nhSn);

                    if (nhSnregs != null && nhSnregs.Count>0)
                    {
                        nhSnreg = nhSnregs.FirstOrDefault();
                        sn.RootSnRegID = nhSnreg.RootSnRegID;
                        sn.NhSnRegID = nhSnreg.ID;
                    }
                    else
                    {
                        sn.RootSnRegID = sn.ID;
                    }
                }
                else
                {
                    sn.RootSnRegID = sn.ID;
                }
                #endregion
            }
            
            _snRegRepository.CommitSnReg(addList, null, updList);
            
            if (addList.Any())
            {
                addList.ForEach(p =>
                {
                    //生成历史记录
                    var snob = snRegs.Where(o => p.Sn.Equals(o.Sn)).FirstOrDefault();
                    creatSnHistory(snob, p.ID);
                    snob.ID = p.ID;
                    snob.NhSnRegID = p.ID;
                    snob.RootSnRegID = p.ID;                    
                    p.NhSnRegID = p.ID;
                    p.RootSnRegID = p.ID;
                });
            }
            if (updList.Any())
            {
                updList.ForEach(p =>
                {
                    //生成历史记录
                    var snob = snRegs.Where(o => p.Sn.Equals(o.Sn)).FirstOrDefault();
                    creatSnHistory(snob, p.ID);
                    snob.ID = p.ID;
                    snob.NhSnRegID = p.ID;
                    snob.RootSnRegID = p.ID;                    
                    p.NhSnRegID = p.ID;
                    p.RootSnRegID = p.ID;
                });
            }
            updList = updList.Concat(addList).ToList();
            _snRegRepository.CommitSnReg(null, null, updList);
            SnRegDataObjectList result = new SnRegDataObjectList();
            if (updList.Any())
            {
                updList.ForEach(p =>
                {
                    result.Add(Mapper.Map<SnReg, SnRegDataObject>(p));
                });
            }
            return result;            
        }

        public bool ApprSnRegs(IDList snRegIds) {

            foreach (var id in snRegIds) {

                SnRegDataObject so = this.GetSnReg(Int16.Parse(id));
                so.Avail = "IN";
                SnRegDataObjectList sos = new SnRegDataObjectList();
                sos.Add(so);
                this.UpdateSnReg(sos);
            }

            return true;
        }

        //生成历史记录
        private void creatSnHistory(SnRegDataObject sn,int snid)
        {
            SnHistoryDataObjectList db = new SnHistoryDataObjectList();
            #region 生成历史记录.
            SnHistoryDataObject shobj = new SnHistoryDataObject();
            shobj.SnRegID = snid;
            shobj.Ac = sn.Ac;
            if ("".Equals(shobj.Active) || shobj.Active == null)
                shobj.Active = "Instore";
            shobj.ActiveDate = sn.InstallDate;
            shobj.Ata = sn.Ata;
            shobj.EngineTli = sn.EngineTli;
            shobj.NhSnRegID = sn.NhSnRegID;
            shobj.Note = sn.Note;
            shobj.Position = sn.Position;
            shobj.RootSnRegID = sn.RootSnRegID;
            shobj.SnHistoryUnits = new SnHistoryUnitDataObjectList();
            SnHistoryUnitDataObject fh = sn.SnTsn;
            shobj.SnHistoryUnits.Add(fh);
            SnHistoryUnitDataObject cy = sn.SnCsn;
            shobj.SnHistoryUnits.Add(cy);
            db.Add(shobj);
            AddSnHistory(db);          
            #endregion    
        }
        /// <summary>
        /// 删除SnReg
        /// </summary>
        /// <param name="snRegIds"></param>
        public void DeleteSnReg(IDList snRegIds)
        {
            PerformDeleteObjects<SnReg>(snRegIds, _snRegRepository);
        }
        /// <summary>
        /// 提交SnReg的增删改数据
        /// </summary>
        /// <param name="snRegData"></param>
        /// <returns>提交成功的数据</returns>
        public SnRegResultData CommitSnRegs(SnRegResultData snRegData)
        {
            var resultData = new SnRegResultData
            {
                AddedCollection = new SnRegDataObjectList(),
                DeletedCollection = new List<string>(),
                ModefiedCollection = new SnRegDataObjectList()
            };
            var addList = new List<SnReg>();
            IEnumerable<string> deleteList = new List<string>();
            var updateList = new List<SnReg>();

            #region Input

            if (snRegData.AddedCollection != null && snRegData.AddedCollection.Any())
            {
                snRegData.AddedCollection.ForEach(
                p =>
                {
                    addList.Add(Mapper.Map<SnRegDataObject, SnReg>(p));
                });
            }
            if (snRegData.DeletedCollection != null && snRegData.DeletedCollection.Any())
            {
                deleteList = snRegData.DeletedCollection;
            }
            if (snRegData.ModefiedCollection != null && snRegData.ModefiedCollection.Any())
            {
                snRegData.ModefiedCollection.ForEach(
                   p => updateList.Add(Mapper.Map<SnRegDataObject, SnReg>(p)));
            }

            #endregion

            _snRegRepository.CommitSnReg(addList, deleteList, updateList);

            #region Output

            var addResults = new ObservableCollection<SnRegDataObject>();
            if (addList.Any())
            {
                addList.ForEach(
                   p => addResults.Add(Mapper.Map<SnReg, SnRegDataObject>(p)));
                resultData.AddedCollection = addResults;
            }
            var updateResults = new ObservableCollection<SnRegDataObject>();
            if (updateList.Any())
            {
                updateList.ForEach(
                   p => updateResults.Add(Mapper.Map<SnReg, SnRegDataObject>(p)));
                resultData.ModefiedCollection = updateResults;
            }
            if (deleteList != null && deleteList.Any())
            {
                resultData.DeletedCollection = deleteList;
            }

            #endregion

            return resultData;
        }

        /// <summary>
        /// 更新SnReg
        /// </summary>
        /// <param name="snRegs"></param>
        /// <returns></returns>
        public SnRegDataObjectList UpdateSnReg(SnRegDataObjectList snRegs)
        {

            return PerformUpdateObjects<SnRegDataObjectList, SnRegDataObject, SnReg>(snRegs, _snRegRepository, s => s.ID,
                (sn, snr) =>
                {

                    sn.PnRegID = snr.PnRegID;
                    if (!string.IsNullOrEmpty(snr.Sn))
                        sn.Sn = snr.Sn;
                    sn.Ac = snr.Ac;
                    sn.InstallDate = snr.InstallDate;
                    sn.Ata = snr.Ata;

                    if (!string.IsNullOrEmpty(snr.Position))
                        sn.Position = snr.Position;
                    if (!string.IsNullOrEmpty(snr.EngineTli))
                        sn.EngineTli = snr.EngineTli;
                    if (!string.IsNullOrEmpty(snr.Note))
                        sn.Note = snr.Note;
                    if (!string.IsNullOrEmpty(snr.Avail))
                        sn.Avail = snr.Avail;
                    sn.NhSnRegID = snr.NhSnRegID;
                    sn.RootSnRegID = snr.RootSnRegID;
                    if (!string.IsNullOrEmpty(snr.Zone))
                        sn.Zone = snr.Zone;
                });
        }

        /// <summary>
        /// 获取所有SnReg
        /// </summary>
        /// <returns></returns>
        public SnRegDataObjectList GetAllSnRegs()
        {
            return _componentQuery.GetSnRegs();
        }

        /// <summary>
        /// 通过ID获取SnReg
        /// </summary>
        /// <param name="snRegId"></param>
        /// <returns></returns>
        public SnRegDataObject GetSnReg(int snRegId)
        {
            SnRegDataObject snob = null;
            var snReg = _snRegRepository.GetByKey(snRegId);
            if (snReg != null) {
               snob = Mapper.Map<SnReg, SnRegDataObject>(snReg);
               #region 获取部件时间               

               GetSnRegTime(ref snob); 

               #endregion
            }
            return snob;
        }


        public SnRegDataObject GetSnRegByPnSn(string pn,string sn) 
        {
            SnRegDataObject snReg = null;
            List<SnReg> snRegs = this.GetSnRegObjs(0, pn, sn);
            if (snRegs != null && snRegs.Count>0)
            {
                snReg = Mapper.Map<SnReg, SnRegDataObject>(snRegs[0]);
            }              
            return snReg;
        }

        private List<SnReg> GetSnRegObjs(int id,string pn,string sn) 
        {
            List<SnReg> snregs = null;
            if (id != null && id>0)
            {
                var snreg = _snRegRepository.GetByKey(id);
                snregs.Add(snreg);
            }
            else {                                
                Expression<Func<SnReg, bool>> express = c => true;
                if (!string.IsNullOrEmpty(pn))
                {
                    express = express.And(main => main.PnReg.Pn.Equals(pn));
                }
                if (!string.IsNullOrEmpty(sn))
                {
                    express = express.And(main => main.Sn.Equals(pn));                    
                }
                snregs = _snRegRepository.GetAll(Specification<SnReg>.Eval(express)).ToList();                
            }
            return snregs;
        }

        private void GetSnRegTime(ref SnRegDataObject snob)
        {
            #region 获取该部件最新的时间信息

            #region 获取部件最新的飞行时间
            decimal fh=0, cy = 0,ty = 0;//飞行时间，正常循环，连续循环（训练循环）
            string pnClass = snob.PnReg.PnClass;
            //从飞行日志中查找飞行时间信息
            Decimal[] times = GetFlightTime(snob.Ac, snob.InstallDate, DateTime.Now);
            if (times != null && times.Count() > 0)
            {
                foreach (var item in times)
                {
                    if (!"APU".Equals(pnClass))
                    {
                        fh = times[0];
                    }
                    else if (!"APU".Equals(pnClass))
                    {
                        cy = times[1];
                    }
                    else if ("APU".Equals(pnClass))
                    {
                        fh = times[2];
                    }
                    else if ("APU".Equals(pnClass))
                    {
                        cy = times[3];
                    }
                    else
                    {
                        ty = times[4];
                    }
                    //对连续循环进行换算
                    int rate = 1;
                    if (snob.PnReg!=null && snob.PnReg.TrainRate != null && snob.PnReg.TrainRate > 0)
                        rate = snob.PnReg.TrainRate.Value;

                    cy = cy + ty / rate;
                }
            }
            #endregion

            #region 查询部件最近一次装机时间         
            
            decimal tsn = fh, tso = fh, tsr = fh, csn = cy, cso = cy, csr = cy;
            SnHistoryDataObject sh = GetLastSnHistoryBySnregID(snob.ID);
            if (sh!=null)
            {
                tsn = sh.SnHistoryFh.USN;
                tso = sh.SnHistoryFh.USO;
                tsr = sh.SnHistoryFh.USR;
                csn = sh.SnHistoryCy.USN;
                cso = sh.SnHistoryCy.USO;
                csr = sh.SnHistoryCy.USR;
            }


            if (sh != null && ("Instore".Equals(sh.Active) || "Repair".Equals(sh.Active)))
            {
                tsn = sh.SnHistoryFh.USN + fh;
                tso = sh.SnHistoryFh.USO + fh;
                tsr = sh.SnHistoryFh.USR + fh;
                csn = sh.SnHistoryCy.USN + cy;
                cso = sh.SnHistoryCy.USO + cy;
                csr = sh.SnHistoryCy.USR + cy;
                snob.snHistory = sh;
            }
            else {
                snob.snHistory = new SnHistoryDataObject();
            }

            #endregion

            snob.SnTsn = new SnHistoryUnitDataObject();
            snob.SnTsn.Unit = "FH";
            snob.SnTsn.USI = fh;
            snob.SnTsn.USN = tsn;
            snob.SnTsn.USR = tsr;
            snob.SnTsn.USO = tso;
            snob.SnCsn = new SnHistoryUnitDataObject();
            snob.SnCsn.Unit = "CY";
            snob.SnCsn.USI = cy;
            snob.SnCsn.USN = csn;
            snob.SnCsn.USO = cso;
            snob.SnCsn.USR = csr;
            
            #endregion
        }

        /// <summary>
        /// 约定 
        /// times[0] 飞行时间,
        /// times[1] 飞行循环,
        /// times[2]APU使用小时,
        /// times[3]APU使用循环,
        /// times[4]连续循环
        /// </summary>
        /// <param name="acreg"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        private Decimal[] GetFlightTime(string acreg, DateTime fromDate, DateTime toDate)
        {
            Decimal[] times = new Decimal[] {100,60,30,60,60};
            // 从FLIGHT_LOG 获取数据           
            return times;
        }

        ///// <summary>
        ///// 条件查询附件
        ///// </summary>
        ///// <param name="ac">飞机号</param>
        ///// <param name="itemNo">附件项</param>
        ///// <param name="pn">件号</param>
        ///// <returns></returns>
        //public SnRegDataObjectList QuerySnRegs(string ac, string itemNo, string pn)
        //{
        //    return QuerySnRegsDb("", pnRegId, 0, ac, "", sn);
        //}
        /// <summary>
        /// 条件查询附件
        /// </summary>
        /// <param name="acRegId">飞机ID</param>
        /// <param name="pnRegId">件号ID</param>
        /// <param name="sn">序号</param>
        /// <returns></returns>
        public SnRegDataObjectList QuerySnRegs(string ac, int pnRegId, string sn)
        {
            return QuerySnRegsDb("", pnRegId, 0, ac, "", sn);
        }

        /// <summary>
        /// 条件查询附件
        /// </summary>
        /// <param name="itemNo">附件项号</param>
        /// <param name="pnId">件号ID</param>
        /// <param name="snId">序号ID</param>
        /// <param name="acId">飞机ID</param>
        /// <param name="avail">状态</param>
        /// <returns></returns>
        public SnRegDataObjectList QuerySnRegDtos(string itemNo, int pnId, int snId, string ac, string avail)
        {
            return QuerySnRegsDb(itemNo, pnId, snId, ac, avail, "");
        }

        public SnRegDataObjectList QuerySnRegsDb(string itemNo, int pnId, int snId, string ac, string avail, string snr)
        {
            var snRegDtos = new SnRegDataObjectList();
            Expression<Func<SnReg, bool>> expression = s => true;
            if (!string.IsNullOrEmpty(itemNo))
            {
                var pns = QueryPns(itemNo);
                expression = pns.Aggregate(expression, (current, pn) => current.Or(s => s.PnRegID == pn.ID));
            }
            if (pnId > 0)
                expression = expression.And(s => s.PnRegID == pnId);
            if (snId > 0)
                expression = expression.And(s => s.ID == snId);
            if (!string.IsNullOrEmpty(ac))
                expression = expression.And(s => s.Ac == ac);
            if (!string.IsNullOrEmpty(snr))
                expression = expression.And(s => s.Sn == snr);
            if (!string.IsNullOrEmpty(avail))
                expression = expression.And(s => s.Avail.Equals(avail));

            var sns = _snRegRepository.GetAll(Specification<SnReg>.Eval(expression));

            #region DB 转换
            if (sns != null)
            {
                foreach (var sn in sns)
                {
                    var snDto = new SnRegDataObject();

                    snDto.ID = sn.ID;
                    snDto.InstallDate = sn.InstallDate;
                    snDto.Ac = sn.Ac;
                    snDto.Ata = sn.Ata;
                    snDto.Avail = sn.Avail;
                    snDto.EngineTli = sn.EngineTli;
                    snDto.Note = sn.Note;
                    snDto.Position = sn.Position;
                    snDto.Sn = sn.Sn;
                    snDto.Zone = sn.Zone;
                    snDto.ItemNo = QueryItemNo(sn.PnRegID);
                    if (sn.NhSnRegID.HasValue)
                    {
                        var snreg = _snRegRepository.GetByKey(sn.NhSnRegID);
                        if (snreg != null)
                        {
                            SnRegDataObject snob = new SnRegDataObject();
                            snob.Sn = snreg.Sn;
                            snob.PnReg = new PnRegDataObject();
                            snob.PnReg.Pn = snreg.PnReg.Pn;
                            snDto.NhSnReg = snob;
                        }

                    }
                    if (sn.RootSnRegID.HasValue)
                    {
                        var snreg = _snRegRepository.GetByKey(sn.RootSnRegID);
                        if (snreg != null)
                        {
                            SnRegDataObject snob = new SnRegDataObject();
                            snob.Sn = snreg.Sn;
                            snob.PnReg = new PnRegDataObject();
                            snob.PnReg.Pn = snreg.PnReg.Pn;
                            snDto.RootSnReg = snob;
                        }

                    }
                    snDto.Note = sn.Note;
                    if (sn.PnReg != null)
                    {
                        PnRegDataObject pnob = new PnRegDataObject();
                        pnob.Pn = sn.PnReg.Pn;
                        pnob.IsLife = sn.PnReg.IsLife;
                        pnob.Description = sn.PnReg.Description;
                        pnob.SpecPn = sn.PnReg.SpecPn;
                        pnob.PnClass = sn.PnReg.PnClass;
                        snDto.PnReg = pnob;
                    }
                    snRegDtos.Add(snDto);
                }
            }
            #endregion

            //第一条数据进行查询子集
            if (snRegDtos != null && snRegDtos.Count > 0)
                snRegDtos[0] = GetSnReg(snRegDtos[0].ID);

            return snRegDtos;
        }

        #endregion

        #region WfHistory
        /// <summary>
        /// 添加WfHistory
        /// </summary>
        /// <param name="wfHistorys"></param>
        /// <returns></returns>
        public WfHistoryDataObjectList AddWfHistory(WfHistoryDataObjectList wfHistorys)
        {
            return PerformCreateObjects<WfHistoryDataObjectList, WfHistoryDataObject, WfHistory>(wfHistorys,
                                                                                                 _wfHistoryRepository);
        }

        /// <summary>
        /// 删除WfHistory
        /// </summary>
        /// <param name="wfHistoryIds"></param>
        public void DeleteWfHistory(IDList wfHistoryIds)
        {
            PerformDeleteObjects<WfHistory>(wfHistoryIds, _wfHistoryRepository);
        }

        /// <summary>
        /// 更新WfHistory
        /// </summary>
        /// <param name="wfHistorys"></param>
        /// <returns></returns>
        public WfHistoryDataObjectList UpdateWfHistory(WfHistoryDataObjectList wfHistorys)
        {
            return PerformUpdateObjects<WfHistoryDataObjectList, WfHistoryDataObject, WfHistory>(wfHistorys,
                   _wfHistoryRepository, w => w.ID, (wf, wfh) =>
                   {
                       if (!string.IsNullOrEmpty(wfh.Seq))
                           wf.Seq = wfh.Seq;
                       if (!string.IsNullOrEmpty(wfh.Auditor))
                           wf.Auditor = wfh.Auditor;
                       wf.AuditTime = wfh.AuditTime;
                       if (!string.IsNullOrEmpty(wfh.AuditNotes))
                           wf.AuditNotes = wfh.AuditNotes;
                       if (!string.IsNullOrEmpty(wfh.Result))
                           wf.Result = wfh.Result;
                       if (!string.IsNullOrEmpty(wfh.Department))
                           wf.Department = wfh.Department;
                       if (!string.IsNullOrEmpty(wfh.Description))
                           wf.Description = wfh.Description;
                   });
        }

        /// <summary>
        /// 获取所有WfHistory
        /// </summary>
        /// <returns></returns>
        public WfHistoryDataObjectList GetAllWfHistorys()
        {
            var wfHistorys = new WfHistoryDataObjectList();
            var wfs = _wfHistoryRepository.GetAll();
            if (wfs != null)
                wfHistorys.AddRange(wfs.Select(Mapper.Map<WfHistory, WfHistoryDataObject>));
            return wfHistorys;
        }

        /// <summary>
        /// 通过ID获取WfHistory
        /// </summary>
        /// <param name="wfHistoryId"></param>
        /// <returns></returns>
        public WfHistoryDataObject GetWfHistory(int wfHistoryId)
        {
            var wf = _wfHistoryRepository.GetByKey(wfHistoryId);
            if (wf != null)
                return Mapper.Map<WfHistory, WfHistoryDataObject>(wf);
            return null;
        }

        /// <summary>
        /// 通过业务代码与Id获取WfHistroy
        /// </summary>
        /// <param name="businessId"></param>
        /// <param name="business"></param>
        /// <returns></returns>
        public WfHistoryDataObjectList GetWfHistoryByBusiness(int businessId, string business)
        {
            var wfhistorys = new WfHistoryDataObjectList();
            var wfs = _wfHistoryRepository.GetAll(
                    Specification<WfHistory>.Eval(w => w.Business.ToUpper() == business.ToUpper() && w.BusinessID == businessId));
            if (wfs != null)
                wfhistorys.AddRange(wfs.Select(Mapper.Map<WfHistory, WfHistoryDataObject>));
            return wfhistorys;
        }

        public WfHistoryDataObject QueryWfHistory(int businessId, string business, string department)
        {
            var wf = _wfHistoryRepository.Get(
                    Specification<WfHistory>.Eval(w => w.Business.ToUpper() == business.ToUpper()
                        && w.BusinessID == businessId && w.Department.Equals(department)));
            return wf != null ? Mapper.Map<WfHistory, WfHistoryDataObject>(wf) : null;
        }

        /// <summary>
        /// 提交WfHistory的增删改数据
        /// </summary>
        /// <param name="wfHistoryData"></param>
        /// <returns>提交成功的数据</returns>
        public WfHistoryResultData CommitWfHistorys(WfHistoryResultData wfHistoryData)
        {
            var resultData = new WfHistoryResultData
            {
                AddedCollection =
                   new WfHistoryDataObjectList(),
                DeletedCollection = new List<string>(),
                ModefiedCollection =
                   new WfHistoryDataObjectList()
            };
            var addList = new List<WfHistory>();
            IEnumerable<string> deleteList = new List<string>();
            var updateList = new List<WfHistory>();

            #region Input

            if (wfHistoryData.AddedCollection != null && wfHistoryData.AddedCollection.Any())
            {
                wfHistoryData.AddedCollection.ForEach(
                p =>
                {
                    addList.Add(Mapper.Map<WfHistoryDataObject, WfHistory>(p));
                });
            }
            if (wfHistoryData.DeletedCollection != null && wfHistoryData.DeletedCollection.Any())
            {
                deleteList = wfHistoryData.DeletedCollection;
            }
            if (wfHistoryData.ModefiedCollection != null && wfHistoryData.ModefiedCollection.Any())
            {
                wfHistoryData.ModefiedCollection.ForEach(
                   p => updateList.Add(Mapper.Map<WfHistoryDataObject, WfHistory>(p)));
            }

            #endregion

            _wfHistoryRepository.CommitWfHistory(ref addList, ref deleteList, ref updateList);

            #region Output

            var addResults = new ObservableCollection<WfHistoryDataObject>();
            if (addList.Any())
            {
                addList.ForEach(
                   p => addResults.Add(Mapper.Map<WfHistory, WfHistoryDataObject>(p)));
                resultData.AddedCollection = addResults;
            }
            var updateResults = new ObservableCollection<WfHistoryDataObject>();
            if (updateList.Any())
            {
                updateList.ForEach(
                   p => updateResults.Add(Mapper.Map<WfHistory, WfHistoryDataObject>(p)));
                resultData.ModefiedCollection = updateResults;
            }
            if (deleteList != null && deleteList.Any())
            {
                resultData.DeletedCollection = deleteList;
            }

            #endregion

            return resultData;
        }
        #endregion

        #region WorkScope
        /// <summary>
        /// 添加WorkScope
        /// </summary>
        /// <param name="workScopes"></param>
        /// <returns></returns>
        public WorkScopeDataObjectList AddWorkScope(WorkScopeDataObjectList workScopes)
        {
            return PerformCreateObjects<WorkScopeDataObjectList, WorkScopeDataObject, WorkScope>(workScopes,
                                                                                                 _workScopeRepository);
        }

        /// <summary>
        /// 删除WorkScope
        /// </summary>
        /// <param name="workScopeIds"></param>
        public void DeleteWorkScope(IDList workScopeIds)
        {
            PerformDeleteObjects<WorkScope>(workScopeIds, _workScopeRepository);
        }

        /// <summary>
        /// 更新WorkScope
        /// </summary>
        /// <param name="workScopes"></param>
        /// <returns></returns>
        public WorkScopeDataObjectList UpdateWorkScope(WorkScopeDataObjectList workScopes)
        {
            return PerformUpdateObjects<WorkScopeDataObjectList, WorkScopeDataObject, WorkScope>(workScopes, _workScopeRepository, w => w.ID, (
                wo, ws) =>
            {
                if (!string.IsNullOrEmpty(ws.Scope))
                    wo.Scope = ws.Scope;
                if (!string.IsNullOrEmpty(ws.Description))
                    wo.Description = ws.Description;
                if (!string.IsNullOrEmpty(ws.ShortName))
                    wo.ShortName = ws.ShortName;
                if (!string.IsNullOrEmpty(ws.Type))
                    wo.Type = ws.Type;
            });
        }

        /// <summary>
        /// 获取所有WorkScope
        /// </summary>
        /// <returns></returns>
        public WorkScopeDataObjectList GetAllWorkScopes()
        {
            var workScopes = new WorkScopeDataObjectList();
            var works = _workScopeRepository.GetAll();
            if (works != null)
                workScopes.AddRange(works.Select(Mapper.Map<WorkScope, WorkScopeDataObject>));
            return workScopes;
        }

        /// <summary>
        /// 通过ID获取WorkScope
        /// </summary>
        /// <param name="workScopeId"></param>
        /// <returns></returns>
        public WorkScopeDataObject GetWorkScope(int workScopeId)
        {
            var workScope = _workScopeRepository.GetByKey(workScopeId);
            if (workScope != null)
                return Mapper.Map<WorkScope, WorkScopeDataObject>(workScope);
            return null;
        }

        /// <summary>
        /// 提交WorkScope的增删改数据
        /// </summary>
        /// <param name="workScopeData"></param>
        /// <returns>提交成功的数据</returns>
        public WorkScopeResultData CommitWorkScopes(WorkScopeResultData workScopeData)
        {
            var resultData = new WorkScopeResultData
            {
                AddedCollection =
                   new WorkScopeDataObjectList(),
                DeletedCollection = new List<string>(),
                ModefiedCollection =
                   new WorkScopeDataObjectList()
            };
            var addList = new List<WorkScope>();
            IEnumerable<string> deleteList = new List<string>();
            var updateList = new List<WorkScope>();

            #region Input

            if (workScopeData.AddedCollection != null && workScopeData.AddedCollection.Any())
            {
                workScopeData.AddedCollection.ForEach(
                p =>
                {
                    addList.Add(Mapper.Map<WorkScopeDataObject, WorkScope>(p));
                });
            }
            if (workScopeData.DeletedCollection != null && workScopeData.DeletedCollection.Any())
            {
                deleteList = workScopeData.DeletedCollection;
            }
            if (workScopeData.ModefiedCollection != null && workScopeData.ModefiedCollection.Any())
            {
                workScopeData.ModefiedCollection.ForEach(
                   p => updateList.Add(Mapper.Map<WorkScopeDataObject, WorkScope>(p)));
            }

            #endregion

            _workScopeRepository.CommitWorkScope(ref addList, ref deleteList, ref updateList);

            #region Output

            var addResults = new ObservableCollection<WorkScopeDataObject>();
            if (addList.Any())
            {
                addList.ForEach(
                   p => addResults.Add(Mapper.Map<WorkScope, WorkScopeDataObject>(p)));
                resultData.AddedCollection = addResults;
            }
            var updateResults = new ObservableCollection<WorkScopeDataObject>();
            if (updateList.Any())
            {
                updateList.ForEach(
                   p => updateResults.Add(Mapper.Map<WorkScope, WorkScopeDataObject>(p)));
                resultData.ModefiedCollection = updateResults;
            }
            if (deleteList != null && deleteList.Any())
            {
                resultData.DeletedCollection = deleteList;
            }

            #endregion

            return resultData;
        }
        #endregion

        #region 分页查询

        public CcOrderWithPagination GetCcOrderWithPagination(Pagination pagination)
        {
            return _componentQuery.GetCcOrderWithPagination(pagination);
        }

        public CcpMainWithPagination GetCcpMainWithPagination(Pagination pagination)
        {
            return _componentQuery.GetCcpMainWithPagination(pagination);
        }

        public IntUnitWithPagination GetIntUnitWithPagination(Pagination pagination)
        {
            return _componentQuery.GetIntUnitWithPagination(pagination);
        }

        public OilHistoryWithPagination GetOilHistoryWithPagination(Pagination pagination)
        {
            return _componentQuery.GetOilHistoryWithPagination(pagination);
        }

        public PartsMonitorWithPagination GetPartsMonitorWithPagination(Pagination pagination)
        {
            return _componentQuery.GetPartsMonitorWithPagination(pagination);
        }

        public PnRegWithPagination GetPnRegWithPagination(Pagination pagination)
        {
            return _componentQuery.GetPnRegWithPagination(pagination);
        }

        public ScnMainWithPagination GetScnMainWithPagination(Pagination pagination)
        {
            return _componentQuery.GetScnMainWithPagination(pagination);
        }

        public SnHistoryWithPagination GetSnHistoryWithPagination(Pagination pagination)
        {
            return _componentQuery.GetSnHistoryWithPagination(pagination);
        }

        public SnRegWithPagination GetSnRegWithPagination(Pagination pagination)
        {
            return _componentQuery.GetSnRegWithPagination(pagination);
        }

        public WfHistoryWithPagination GetWfHistoryWithPagination(Pagination pagination)
        {
            return _componentQuery.GetWfHistoryWithPagination(pagination);
        }

        public WorkScopeWithPagination GetWorkScopeWithPagination(Pagination pagination)
        {
            return _componentQuery.GetWorkScopeWithPagination(pagination);
        }

        #endregion
    }

}
