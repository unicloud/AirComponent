#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/6 21:54:49

// 文件名：CcOrderServiceImpl
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoMapper;
using Microsoft.Practices.ObjectBuilder2;
using UniCloud.DataObjects;
using UniCloud.Domain;
using UniCloud.Domain.Model;
using UniCloud.Domain.Repositories;
using UniCloud.Domain.Services;
using UniCloud.Query;
using UniCloud.ServiceContracts;
using System.Linq;
using UniCloud.Domain.Specifications;
using UniCloud.Service.Refernce;
using System.Linq.Expressions;


namespace UniCloud.Application.Implementation
{
    /// <summary>
    /// 表示与CcOrder相关的应用层服务的一种实现。
    /// </summary>
    public class CcOrderServiceImpl : ApplicationService, ICcOrderService
    {
        #region Private Fields
        private readonly ICcOrderRepository _ccOrderRepository;
        private readonly ICcOrderQuery _ccOrderQuery;
        private readonly ISnRegRepository _snRegRepository;
        private readonly IPnRegRepository _pnRegRepository;
        private readonly ISnHistoryRepository _snHistoryRepository;
        private readonly IDomainService _domainService;
        private readonly IAttactDocumentService _attactDocumentService;
        private readonly ISnRegService _snRegService;
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个<c>CcOrderServiceImpl</c>类型的实例。
        /// </summary>
        /// <param name="context">用来初始化<c>CcOrderServiceImpl</c>类型的仓储上下文实例。</param>
        /// <param name="ccOrderRepository">“CcOrder”仓储实例。</param>
        /// <param name="ccOrderQuery">“ccOrderQuery”查询实例。</param>
        /// <param name="domainService">“领域服务”实例。</param>
        public CcOrderServiceImpl(IRepositoryContext context,
        ICcOrderRepository ccOrderRepository,
        ICcOrderQuery ccOrderQuery,
        ISnHistoryRepository snHistoryRepository,
        IPnRegRepository pnRegRepository,
        ISnRegRepository snRegRepository,
        IAttactDocumentService attactDocumentService,
        IDomainService domainService,
        ISnRegService snRegService)
            : base(context)
        {
            this._ccOrderRepository = ccOrderRepository;
            this._ccOrderQuery = ccOrderQuery;
            this._domainService = domainService;
            this._snRegRepository = snRegRepository;
            this._pnRegRepository = pnRegRepository;
            this._snHistoryRepository = snHistoryRepository;
            this._attactDocumentService = attactDocumentService;
            this._snRegService = snRegService;
        }
        #endregion

        #region ICcOrderService

        /// <summary>
        /// 创建CcOrder。
        /// </summary>
        /// <param name="ccOrders">需要创建的CcOrder。</param>
        /// <returns>创建的CcOrder。</returns>
        public CcOrderDataObjectList CreateCcOrders(CcOrderDataObjectList ccOrders)
        {
            return PerformCreateObjects<CcOrderDataObjectList, CcOrderDataObject, CcOrder>(ccOrders, _ccOrderRepository);
        }

        /// <summary>
        /// 删除CcOrder信息。
        /// </summary>
        /// <param name="ccOrderIDs">需要更新的CcOrder信息的ID值。</param>
        public IDList DeleteCcOrders(IDList ccOrderIDs)
        {
            PerformDeleteObjects(ccOrderIDs, _ccOrderRepository);
            return ccOrderIDs;
        }

        /// <summary>
        /// 更新CcOrder信息。
        /// </summary>
        /// <param name="ccOrders">需要更新的CcOrder信息。</param>
        public CcOrderDataObjectList UpdateCcOrders(CcOrderDataObjectList ccOrders)
        {
            return PerformUpdateObjects<CcOrderDataObjectList, CcOrderDataObject, CcOrder>(ccOrders,
               _ccOrderRepository,
               pdo => pdo.ID,
               (p, pdo) =>
               {
               });
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
                AddedCollection = new CcOrderDataObjectList(),
                DeletedCollection = new List<string>(),
                ModefiedCollection = new CcOrderDataObjectList()
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
                    ValidateCcOrder(p);
                    AddAttactDocument(p,true);
                    var ccOrder = Mapper.Map<CcOrderDataObject, CcOrder>(p);
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
                       ValidateCcOrder(p);
                       AddAttactDocument(p,false);
                       var ccOrder = Mapper.Map<CcOrderDataObject, CcOrder>(p);
                       updateList.Add(ccOrder);
                   });
            }

            #endregion

            _ccOrderRepository.CommitCcOrder(addList, deleteList, updateList);

            #region Output

            var addResults = new ObservableCollection<CcOrderDataObject>();
            if (addList.Any())
            {
                addList.ForEach(
                   p =>
                   {
                       var ccOrderDto = Mapper.Map<CcOrder, CcOrderDataObject>(p);
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

        /// <summary>
        /// 判断CcOrder中Pn/Sn的正确性
        /// </summary>
        /// <param name="ccOrders"></param>
        public void ValidateCcOrder(CcOrderDataObject ccOrder)
        {
            
            //Cn判断
            if (!string.IsNullOrWhiteSpace(ccOrder.Pn))
            {
                ccOrder.PnRegID = ValidatePn(ccOrder.Pn);
            }
            //Sn判断
            if (!string.IsNullOrWhiteSpace(ccOrder.Sn))
            {
                int? rootSnreg, nhSnreg;
                ccOrder.SnRegID = ValidateSn(ccOrder.Sn, out rootSnreg, out nhSnreg);
                ccOrder.RootSnRegID = rootSnreg;
            }

            foreach (var ccout in ccOrder.Ccouts)
            {
                //Cn判断
                if (!string.IsNullOrWhiteSpace(ccout.Pn))
                {
                    ccout.PnRegID = ValidatePn(ccout.Pn);
                }
                //Sn判断
                if (!string.IsNullOrWhiteSpace(ccout.Sn))
                {
                    int? rootSnreg, nhSnreg;
                    ccout.SnRegID = ValidateSn(ccout.Sn, out rootSnreg, out nhSnreg);
                    ccout.RootSnRegID = rootSnreg;
                    ccout.NhSnRegID = nhSnreg;
                }
            }

            foreach (var ccin in ccOrder.Ccins)
            {
                //如果不是新增的，则要做存在性校验
                if (ccin.IsNew)
                {
                    
                }
                else
                {
                    //Cn判断
                    if (!string.IsNullOrWhiteSpace(ccin.Pn))
                    {
                        ccin.PnRegID = ValidatePn(ccin.Pn);
                    }
                    //Sn判断
                    if (!string.IsNullOrWhiteSpace(ccin.Sn))
                    {
                        int? rootSnreg, nhSnreg;
                        ccin.SnRegID = ValidateSn(ccin.Sn, out rootSnreg, out nhSnreg);
                        ccin.RootSnRegID = rootSnreg;
                        ccin.NhSnRegID = nhSnreg;
                    }
                }
            }
        }

        /// <summary>
        /// 保存Document 
        /// 1 新增Document
        /// 2 如果有，还要新增SnReg
        /// 3 保存表AttactDocument
        /// </summary>
        /// <param name="ccOrder"></param>
        public void AddAttactDocument(CcOrderDataObject ccOrder,bool isAdd)
        {
            foreach (var ccin in ccOrder.Ccins)
            {
                List<AttactDocumentDataObject> addDocs = new List<AttactDocumentDataObject>();
                List<AttactDocumentDataObject> updateDocs = new List<AttactDocumentDataObject>();
                IDList deleteDocs = new IDList();
                //附件增加 DocumentID, BusinessID,Business
                if (ccin.SnReg!=null&&ccin.SnReg.AttactDocuments.Count > 0)
                {
                    int snRegId = 0;
                    if (ccin.IsNew)
                    {
                        SnReg snreg = new SnReg()
                                      {
                                          InstallDate=DateTime.Now,
                                          //EngineTli Ac 
                                          RootSnRegID=ccOrder.RootSnRegID,
                                          NhSnRegID=ccOrder.SnRegID,
                                          Sn=ccin.Sn,
                                          Ata=ccin.Ata,
                                          Ac=ccOrder.AcReg,
                                          //NhSnRegID=ccOrder
                                      };
                        _snRegRepository.Add(snreg);
                        _snRegRepository.Context.Commit();
                        //ccin赋值
                        snRegId = snreg.ID;
                        ccin.RootSnRegID = snreg.RootSnRegID;
                        ccin.NhSnRegID = snreg.NhSnRegID;
                        ccin.SnRegID = snRegId;
                        ccin.PnRegID = ValidatePn(ccin.Pn);
                        ccin.IsNew = false;
                    }
                    else
                    {
                        snRegId = ccin.SnRegID;
                    }

                    foreach (var document in ccin.SnReg.AttactDocuments)
                    {
                        document.Business = "snreg";
                        document.BusinessID = snRegId;
                        if (isAdd)
                        {
                            addDocs.Add(document);
                        }
                        else
                        {
                            updateDocs.Add(document);
                        }
                    }  
                }
                //保存文档 存在一个BUG，只能保存单个MajorEvent,不然无法获取businessID
                AttactDocumentResultData docResultData = new AttactDocumentResultData()
                {
                    AddedCollection = addDocs,
                    ModefiedCollection = updateDocs,
                    DeletedCollection = deleteDocs
                };
                _attactDocumentService.CommitAttactDocuments(docResultData);
                
            }
           
        }

        public int ValidatePn(string pn)
        {
            var pnreg = _pnRegRepository.Get(Specification<PnReg>.Eval(a => a.Pn == pn));
            if (pnreg != null)
            {
                return pnreg.ID;
            }
            else
                throw new DomainException("保存失败!数据库中不存在件号为" + pn + "的记录.");
        }

        public int ValidateSn(string sn,out int? rootSnreg,out int? nhSnreg)
        {
            var snreg = _snRegRepository.Get(Specification<SnReg>.Eval(a => a.Sn == sn));
            if (snreg != null)
            {
                rootSnreg = snreg.RootSnRegID;
                nhSnreg = snreg.NhSnRegID;
                return snreg.ID;
            }
            else
                throw new DomainException("保存失败!数据库中不存在序号为" + sn + "的记录.");
        }

        /// <summary>
        /// 通过CcOrderId获取相应的CcOrderDataObject 有导航属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CcOrderDataObject GetFullCcOrderByID(int id)
        {
            var result = _ccOrderRepository.GetByKey(id);
            return result != null ? Mapper.Map<CcOrder, CcOrderDataObject>(result) : null;
        }

        /// <summary>
        ///  获取所有的CcOrder信息 有导航属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CcOrderDataObjectList GetFullCcOrders()
        {
            var results = _ccOrderRepository.GetAll();
            return results != null ? Mapper.Map<IEnumerable<CcOrder>, CcOrderDataObjectList>(results) : null;
        }

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
            List<CcOrder> orders = new List<CcOrder>();                
            var ccOrder = _ccOrderRepository.GetByKey(ccOrderId);
            List<SnHistory> snHistorys = new List<SnHistory>();
            
            
            
            if (ccOrder != null)
            {
                ccOrder.State = "生效";  //将状态置为生效
                orders.Add(ccOrder);
                CcOrder cyCcOrder =null;
                #region 处理交换、拆配业务
                //如果状态为交换或拆配，生成第二条CcOrder记录，与第一条记录Ccin.Ccout互换
                if (ccOrder.Cctype == "Swap" || ccOrder.Cctype == "RemMat")
                {
                    cyCcOrder = new CcOrder()
                    {
                        AcReg = ccOrder.SwapAcreg,
                        SwapAcreg = ccOrder.AcReg,
                        Cctype = ccOrder.Cctype,
                        OperatDate = ccOrder.OperatDate,
                        Operator = ccOrder.Operator,
                        OrderNo = ccOrder.OrderNo,
                        RemReason = ccOrder.RemReason,
                        State = "生效",
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
                            Position = ccout.Position,
                            NhSnRegID = ccin.NhSnRegID,
                            PnRegID = ccin.PnRegID,
                            RootSnRegID = ccin.RootSnRegID,
                            Seq = ccin.Seq,
                            SnRegID = ccin.SnRegID,
                            UnScheduled = ccout != null ? ccout.UnScheduled : true,
                            Zone = ccin.Zone
                        };
                        cyCcOrder.Ccouts.Add(cyCcout);
                    }

                    if (ccout != null)
                    {
                        var cyCcin = new Ccin()
                        {
                            Ata = ccout.Ata,
                            Position = ccout.Position,
                            EngineTli = ccin != null ? ccin.EngineTli : "",
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
                    orders.Add(cyCcOrder);
                }
                #endregion
                //修改部件状态、生成历史记录
                AutoCreateSnHistory(orders,ref snHistorys);
                //发布拆装确认事件
                ccOrder.PublishCcOrderEvent(ccOrder.AcReg, ccOrder.OperatDate, snHistorys);
            }

            //提交到数据库
            _ccOrderRepository.Context.Commit();
            _snRegRepository.Context.Commit();
            _snHistoryRepository.CommitSnHistory(snHistorys, null, null);
            return true;
        }
        //根据拆换指令，修改部件状态以及补充履历
        private void AutoCreateSnHistory(List<CcOrder> orders, ref List<SnHistory> snHistorys)
        {

            #region 部件更新，履历生成
            foreach (var ccOrder in orders)
            {
                if (ccOrder.Ccins != null && ccOrder.Ccins.Count > 0)
                {
                    foreach (var ccin in ccOrder.Ccins)
                    {
                        #region 修改安装涉及的所有部件的状态 以及生成维修记录
                        List<int> sns = findSnRegIDsByRootID(ccin.SnRegID);
                        foreach (var snid in sns)
                        {
                            SnRegDataObject sn = _snRegService.GetFullSnRegByID(snid);
                            sn.Ac = ccOrder.AcReg;
                            sn.Avail = "IN";
                            if (ccin.SnRegID == snid)
                            {   //拆换主件
                                sn.Ata = ccin.Ata;
                                sn.EngineTli = ccin.EngineTli;
                                sn.Propertys = ccin.Propertys;
                                sn.Position = ccin.Position;
                                sn.Zone = ccin.Zone;
                                if (ccin.CyInterval != 0 && ccin.CyInterval != null)
                                    sn.Interval = "CY:" + ccin.CyInterval;
                                if (ccin.FhInterval != 0 && ccin.FhInterval != null)
                                    sn.Interval = "FH:" + ccin.CyInterval;
                            }
                            sn.InstallDate = ccOrder.OperatDate;
                            var snHistory = new SnHistory()
                            {
                                Active = "Install",
                                ActiveDate = ccOrder.OperatDate,
                                Source = ccOrder.AcReg,
                                Ata = ccin.Ata,
                                Orderno = ccOrder.OrderNo,
                                NhSnRegID = sn.NhSnRegID,
                                RootSnRegID = sn.RootSnRegID,
                                SnRegID = sn.ID,
                                Position = sn.Position,
                                Note = ccin.EngineTli,
                                SnHistoryUnits = new List<SnHistoryUnit>(),
                            };
                            if (sn.snHistory != null && sn.snHistory.SnHistoryUnits != null)
                            {
                                sn.snHistory.SnHistoryUnits.ForEach(p =>
                                {
                                    p.ID = 0;
                                    p.SnHistoryID = 0;
                                    snHistory.SnHistoryUnits.Add(Mapper.Map<SnHistoryUnitDataObject, SnHistoryUnit>(p));
                                });
                            }
                            else {
                                var fhUnit = new SnHistoryUnit();
                                var cyUnit = new SnHistoryUnit();
                                fhUnit.Unit = "FH";
                                cyUnit.Unit = "CY";
                                fhUnit.USN = ccin.Tsn==null?0:ccin.Tsn.Value;
                                fhUnit.USO = ccin.Tso == null ? 0 : ccin.Tso.Value;
                                fhUnit.USR = ccin.Tsr == null ? 0 : ccin.Tsr.Value;
                                cyUnit.USN = ccin.Tsn == null ? 0 : ccin.Csn.Value;
                                cyUnit.USO = ccin.Tso == null ? 0 : ccin.Cso.Value;
                                cyUnit.USR = ccin.Tsr == null ? 0 : ccin.Csr.Value;
                                snHistory.SnHistoryUnits.Add(fhUnit);
                                snHistory.SnHistoryUnits.Add(cyUnit);
                            }
                            snHistorys.Add(snHistory);
                        }
                        #endregion
                    }
                    foreach (var ccout in ccOrder.Ccouts)
                    {
                        #region 修改安装涉及的所有部件的状态 以及生成维修记录
                        List<int> sns = findSnRegIDsByRootID(ccout.SnRegID);
                        foreach (var snid in sns)
                        {
                            SnRegDataObject sn = _snRegService.GetFullSnRegByID(snid);
                            sn.Ac = "";
                            sn.Avail = "UI";
                            if (ccout.SnRegID == snid)
                            {   //拆换主件
                                sn.Ata = ccout.Ata;
                                sn.EngineTli = "";
                                sn.Position = "";
                                sn.Zone = "";
                            }
                            sn.RemoveDate = ccOrder.OperatDate;
                            var snHistory = new SnHistory()
                            {
                                Active = "Remove",
                                ActiveDate = ccOrder.OperatDate,
                                Source = ccOrder.AcReg,
                                Ata = ccout.Ata,
                                Orderno = ccOrder.OrderNo,
                                NhSnRegID = sn.NhSnRegID,
                                RootSnRegID = sn.RootSnRegID,
                                SnRegID = sn.ID,
                                Position = sn.Position,
                                Note = ccout.IsClaim ? "涉及索赔" : "",
                                SnHistoryUnits = new List<SnHistoryUnit>(),
                            };
                            if (sn.snHistory != null && sn.snHistory.SnHistoryUnits != null)
                            {
                                sn.snHistory.SnHistoryUnits.ForEach(p =>
                                {
                                    p.ID = 0;
                                    p.SnHistoryID = 0;
                                    snHistory.SnHistoryUnits.Add(Mapper.Map<SnHistoryUnitDataObject, SnHistoryUnit>(p));
                                });
                            }
                            snHistorys.Add(snHistory);
                        }
                        #endregion
                    }
                }
            }
            #endregion

        }
        /// <summary>
        /// 查找本部件以及所有下级件
        /// </summary>
        /// <param name="rootSnid"></param>
        /// <returns></returns>
        public List<int> findSnRegIDsByRootID(int rootSnid) {

            List<int> snids = null;

            Expression<Func<SnReg, bool>> express = c => true;
            
            express = express.And(main => main.RootSnRegID==rootSnid);

            snids = _snRegRepository.GetAll(Specification<SnReg>.Eval(express)).Select(o => o.ID).ToList();
            return snids;       
        }
        
        /// <summary>
        /// 审核发动机拆装
        /// 1 将状态改成生效
        /// 2 根据NhSnregID,递归查询生成历史记录
        /// </summary>
        /// <param name="ccOrderId"></param>
        /// <returns></returns>
        public bool VerifyEngCcOrder(int ccOrderId)
        {
            var ccOrder = _ccOrderRepository.GetByKey(ccOrderId);
            List<SnHistory> snHistorys = new List<SnHistory>();
            //将状态置为生效
            ccOrder.State = "生效";
            if (ccOrder != null)
            {
                //生成主部件历史记录
                if (ccOrder.Ccouts.Count > 0)
                {
                    if (ccOrder.Ccouts.ElementAt(0).SnRegID > 0)
                    {
                        var snreg = _snRegRepository.GetByKey(ccOrder.Ccouts.ElementAt(0).SnRegID);
                        if (snreg != null)
                        {
                            GenerateSnHistory(ccOrder, snreg, "Remove", snHistorys);
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
                            GenerateSnHistory(ccOrder, snreg, "Install", snHistorys);
                        }
                    }
                }
            }
            //提交到数据库
            _ccOrderRepository.Context.Commit();
            return true;
        }

        /// <summary>
        /// 递归生成部件历史记录
        /// </summary>
        /// <param name="ccOrder"></param>
        /// <param name="snreg"></param>
        /// <param name="active"></param>
        /// <param name="snHistorys"></param>
        private void GenerateSnHistory(CcOrder ccOrder, SnReg snreg, string active, List<SnHistory> snHistorys)
        {
            var lowSnregs = _snRegRepository.GetAll(Specification<SnReg>.Eval(p => p.NhSnRegID == snreg.ID));
            if (lowSnregs.Any())
            {
                foreach (var lowSnreg in lowSnregs)
                {
                    GenerateSnHistory(ccOrder,lowSnreg,active, snHistorys);
                }
            }
            else
            {
                AddSnHistorys(ccOrder,snreg,active, snHistorys);
            }
        }

        /// <summary>
        /// 增加部件历史记录
        /// </summary>
        /// <param name="ccOrder"></param>
        /// <param name="snreg"></param>
        private void AddSnHistorys(CcOrder ccOrder, SnReg snreg, string active, List<SnHistory> snHistorys)
        {
            var snHistory = new SnHistory()
            {
                Source = ccOrder.AcReg,
                Active = active,
                ActiveDate = ccOrder.OperatDate,
                Ata = snreg.Ata,
                Orderno = ccOrder.OrderNo,               
                NhSnRegID = snreg.NhSnRegID,
                RootSnRegID = snreg.RootSnRegID,
                SnRegID = snreg.ID,
                Position = snreg.Position,
                //Note = ccOrder.Ccouts;
            };
            snHistorys.Add(snHistory);
            _snHistoryRepository.Add(snHistory);
        }

        #endregion
    }
}
