#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/6 21:54:49

// 文件名：SnRegServiceImpl
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
using System.Linq.Expressions;
using UniCloud.Domain.Specifications;

namespace UniCloud.Application.Implementation
{
    /// <summary>
    /// 表示与SnReg相关的应用层服务的一种实现。
    /// </summary>
    public class SnRegServiceImpl : ApplicationService, ISnRegService
    {
        #region Private Fields
        private readonly ISnRegRepository _snRegRepository;
        private readonly ISnRegQuery _snRegQuery;
        private readonly IDomainService _domainService;
        private readonly IPnRegRepository _pnRegRepository;
        private readonly ICcpMainRepository _ccpMainRepository;
        private readonly ISnHistoryRepository _snHistoryRepository;
        private readonly IPnRegQuery _pnRegQuery;
        
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个<c>SnRegServiceImpl</c>类型的实例。
        /// </summary>
        /// <param name="context">用来初始化<c>SnRegServiceImpl</c>类型的仓储上下文实例。</param>
        /// <param name="snRegRepository">“SnReg”仓储实例。</param>
        /// <param name="snRegQuery">“snRegQuery”查询实例。</param>
        /// <param name="domainService">“领域服务”实例。</param>
        public SnRegServiceImpl(IRepositoryContext context,
        ISnRegRepository snRegRepository,
        ISnRegQuery snRegQuery,
            IPnRegRepository pnRegRepository,
            ICcpMainRepository ccpMainRepository,
            ISnHistoryRepository snHistoryRepository,
        IDomainService domainService,
            IPnRegQuery pnRegQuery)
            : base(context)
        {
            this._snRegRepository = snRegRepository;
            this._snRegQuery = snRegQuery;
            this._domainService = domainService;
            this._pnRegRepository = pnRegRepository;
            this._ccpMainRepository = ccpMainRepository;
            this._snHistoryRepository = snHistoryRepository;
            this._pnRegQuery = pnRegQuery;
        }
        #endregion

        #region ISnRegService

        /// <summary>
        /// 添加SnReg
        /// </summary>
        /// <param name="snRegs"></param>
        /// <returns></returns>
        public SnRegDataObjectList ImportSnRegs(SnRegDataObjectList snRegs)
        {
            SnRegDataObjectList dbs = CreateSnRegs(snRegs);
            List<SnReg> updateList = new List<SnReg>();
            List<SnHistory> db = new List<SnHistory>();
            //上下级再处理
            foreach (var snreg in snRegs)
            {
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
                            nhPn = _pnRegQuery.GetPnRegByID(snreg.NhSnReg.PnRegID).Pn;
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
                        else
                        {
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
                        if (sh != null)
                        {
                            sh.NhSnRegID = dbSn.NhSnRegID;
                            sh.RootSnRegID = dbSn.RootSnRegID;
                            db.Add(Mapper.Map<SnHistoryDataObject, SnHistory>(sh));
                        }
                        updateList.Add(Mapper.Map<SnRegDataObject, SnReg>(dbSn));

                    }
                }
            }
            _snRegRepository.CommitSnReg(null, null, updateList);
            
            _snHistoryRepository.CommitSnHistory(null, null, db);
            return dbs;
        }

        /// <summary>
        /// 添加SnReg
        /// </summary>
        /// <param name="snRegs"></param>
        /// <returns></returns>
        public SnRegDataObjectList CreateSnRegs(SnRegDataObjectList snRegs)
        {
            var addList = new List<SnReg>();
            var updList = new List<SnReg>();
            foreach (var snreg in snRegs)
            {
                CheckAndFillSnreg(snreg);

                SnReg sn = Mapper.Map<SnRegDataObject, SnReg>(snreg);
                if (snreg != null && snreg.ID > 0)
                {
                    updList.Add(sn);
                }
                else
                {
                    addList.Add(sn);
                }
                
            }
            _snRegRepository.CommitSnReg(addList, null, updList);
            updList = updList.Concat(addList).ToList();
            if (updList.Any())
            {
                updList.ForEach(p =>
                {
                    //生成历史记录
                    var snob = snRegs.Where(o => p.Sn.Equals(o.Sn)).FirstOrDefault();
                    creatSnHistory(snob, p.ID);
                    snob.ID = p.ID;
                    if(p.NhSnRegID==null ||p.NhSnRegID==0){
                        p.NhSnRegID = p.ID;
                        p.RootSnRegID = p.ID;                    
                    }
                    snob.NhSnRegID = p.NhSnRegID;
                    snob.RootSnRegID = p.RootSnRegID;
                });
            }            
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

        public bool ApprSnRegs(IDList snRegIds)
        {
            foreach (var id in snRegIds)
            {
                SnReg so = _snRegRepository.GetByKey(id);
                so.Avail = "IN";
                _snRegRepository.Update(so);
            }

            return true;
        }

        private bool CheckAndFillSnreg(SnRegDataObject snreg) 
        {
            //判断飞机号是否存在
            CheckAcregByReg(snreg.Ac);
            //判断件号是否存在
            PnRegDataObject part = _pnRegQuery.GetPnRegByPn(snreg.PnReg.Pn);
            if (part != null)
            {
                snreg.PnRegID = part.ID;
            }
            else {
                throw new Exception(snreg.PnReg.Pn + "：件号不存在");
            }
            //判断序号是否存在
            SnRegDataObject db = GetSnRegByPnSn(snreg.PnReg.Pn, snreg.Sn);
            if (db != null)
            {
                snreg.ID = db.ID;
            }
            //判断上级件号是否存在
            if (snreg.NhSnReg != null && snreg.NhSnReg.PnReg != null && !"".Equals(snreg.NhSnReg.Sn) && !"".Equals(snreg.NhSnReg.PnReg.Pn))
            {
                PnRegDataObject nhpart = _pnRegQuery.GetPnRegByPn(snreg.NhSnReg.PnReg.Pn);
                if (nhpart == null)
                {
                    throw new Exception(snreg.PnReg.Pn + "：上级件号不存在");
                }
                //判断上级件序号是否存在,存在进行补充，否则跳过.
                SnRegDataObject nhsn = GetSnRegByPnSn(snreg.NhSnReg.PnReg.Pn, snreg.NhSnReg.Sn);
                if (nhsn != null)
                {
                    snreg.NhSnRegID = nhsn.ID;
                    snreg.RootSnRegID = nhsn.RootSnRegID;
                }
            }
            return true;
        }
        //生成历史记录
        private void creatSnHistory(SnRegDataObject sn, int snid)
        {
            List<SnHistory> ls = new List<SnHistory>();
            #region 生成历史记录.
            SnHistory shobj = new SnHistory();
            shobj.SnRegID = snid;
            shobj.Source = sn.Ac;
            if ("".Equals(shobj.Active) || shobj.Active == null)
                shobj.Active = "Install";
            shobj.ActiveDate = sn.InstallDate;
            shobj.Ata = sn.Ata;
            shobj.Orderno = sn.Ac;
            shobj.NhSnRegID = sn.NhSnRegID;
            //shobj.Note = sn.Ac;
            shobj.Position = sn.Position;
            shobj.RootSnRegID = sn.RootSnRegID;
            shobj.SnHistoryUnits = new List<SnHistoryUnit>();
            SnHistoryUnit fh = Mapper.Map<SnHistoryUnitDataObject, SnHistoryUnit>(sn.SnTsn);
            fh.Unit = "FH";
            shobj.SnHistoryUnits.Add(fh);
            SnHistoryUnit cy = Mapper.Map<SnHistoryUnitDataObject, SnHistoryUnit>(sn.SnCsn);
            cy.Unit = "CY";
            shobj.SnHistoryUnits.Add(cy);
            ls.Add(shobj);
            _snHistoryRepository.CommitSnHistory(ls, null, null);
            #endregion
        }

        private void CheckAcregByReg(string acreg) { 
            
            UniCloud.Application.AircraftService.AircraftServiceClient client = new AircraftService.AircraftServiceClient();
            var ac = client.GetFullAcRegByReg(acreg);
            if (ac == null)
                throw new Exception("输入的机号："+acreg+"请先在系统中注册.");
        }
        /// <summary>
        /// 删除SnReg信息。
        /// </summary>
        /// <param name="snRegIDs">需要更新的SnReg信息的ID值。</param>
        public IDList DeleteSnRegs(IDList snRegIDs)
        {
            PerformDeleteObjects(snRegIDs, _snRegRepository);
            return snRegIDs;
        }

        /// <summary>
        /// 更新SnReg信息。
        /// </summary>
        /// <param name="snRegs">需要更新的SnReg信息。</param>
        public SnRegDataObjectList UpdateSnRegs(SnRegDataObjectList snRegs)
        {
            return PerformUpdateObjects<SnRegDataObjectList, SnRegDataObject, SnReg>(snRegs,
               _snRegRepository,
               pdo => pdo.ID,
               (p, pdo) =>
               {
               });
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
                AddedCollection =
                   new SnRegDataObjectList(),
                DeletedCollection = new List<string>(),
                ModefiedCollection =
                   new SnRegDataObjectList()
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
                    SnReg sn = Mapper.Map<SnRegDataObject, SnReg>(p);
                    addList.Add(sn);
                });
            }
            if (snRegData.DeletedCollection != null && snRegData.DeletedCollection.Any())
            {
                deleteList = snRegData.DeletedCollection;
            }
            if (snRegData.ModefiedCollection != null && snRegData.ModefiedCollection.Any())
            {
                snRegData.ModefiedCollection.ForEach(

                   p => {
                   
                       SnReg sn = Mapper.Map<SnRegDataObject, SnReg>(p);
                       updateList.Add(sn);
                   });
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
        /// 通过SnRegId获取相应的SnRegDataObject 有导航属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SnRegDataObject GetFullSnRegByID(int id)
        {
            SnRegDataObject snob = null;
            var result = _snRegRepository.GetByKey(id);
            if(result!=null){
                 snob =  Mapper.Map<SnReg, SnRegDataObject>(result);
                 SnHistoryDataObject sh = GetLastSnHistoryBySnregID(snob.ID);
                 decimal[] times = GetFlightTime(snob.Ac,snob.InstallDate,DateTime.Now);
                 GetSnRegTsn(snob.PnReg.PnClass, snob.PnReg.TrainRate, ref sh, times);
                 snob.snHistory = sh;
                 snob.SnCsn = sh.SnHistoryCy;
                 snob.SnTsn = sh.SnHistoryFh;
            }
            return snob;
        }

        /// <summary>
        ///  获取所有的SnReg信息 有导航属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SnRegDataObjectList GetFullSnRegs()
        {
            var results = _snRegRepository.GetAll();
            return results != null ? Mapper.Map<IEnumerable<SnReg>, SnRegDataObjectList>(results) : null;
        }

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
                    if (sn.NhSnRegID > 0 && sn.NhSnRegID != sn.ID)
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
                    if (sn.RootSnRegID>0 && sn.RootSnRegID != sn.ID)
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

            ////第一条数据进行查询子集
            //if (snRegDtos != null && snRegDtos.Count > 0)
            //    snRegDtos[0] = GetSnReg(snRegDtos[0].ID);

            return snRegDtos;
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
        /// 通过ID获取SnReg
        /// </summary>
        /// <param name="snRegId"></param>
        /// <returns></returns>
        public SnRegDataObject GetSnReg(int snRegId)
        {
            SnRegDataObject snob = null;
            var snReg = _snRegRepository.GetByKey(snRegId);
            if (snReg != null)
            {
                snob = Mapper.Map<SnReg, SnRegDataObject>(snReg);
                #region 获取部件时间

                SnHistoryDataObject sh = GetLastSnHistoryBySnregID(snob.ID);
                decimal[] times = GetFlightTime(snob.Ac, snob.InstallDate, DateTime.Now);
                GetSnRegTsn(snob.PnReg.PnClass, snob.PnReg.TrainRate, ref sh, times);
                snob.snHistory = sh;
                snob.SnCsn = sh.SnHistoryCy;
                snob.SnTsn = sh.SnHistoryFh;

                #endregion
            }
            return snob;
        }

        public SnRegDataObject GetSnRegByPnSn(string pn, string sn)
        {
            SnRegDataObject snReg = null;
            List<SnReg> snRegs = this.GetSnRegObjs(0, pn, sn);
            if (snRegs != null && snRegs.Count > 0)
            {
                snReg = Mapper.Map<SnReg, SnRegDataObject>(snRegs[0]);
            }
            return snReg;
        }

        private List<SnReg> GetSnRegObjs(int id, string pn, string sn)
        {
            List<SnReg> snregs = null;
            if (id > 0)
            {
                var snreg = _snRegRepository.GetByKey(id);
                snregs.Add(snreg);
            }
            else
            {
                Expression<Func<SnReg, bool>> express = c => true;
                if (!string.IsNullOrEmpty(pn))
                {
                    express = express.And(main => main.PnReg.Pn.Equals(pn));
                }
                if (!string.IsNullOrEmpty(sn))
                {
                    express = express.And(main => main.Sn.Equals(sn));
                }
                snregs = _snRegRepository.GetAll(Specification<SnReg>.Eval(express)).ToList();
            }
            return snregs;
        }

        private void GetSnRegTsn(string pnClass, int? trainRate, ref SnHistoryDataObject sh, Decimal[] times)
        {
            #region 获取飞机最新的飞行时间
            decimal fh = 0, cy = 0, ty = 0, da = 0;//飞行时间，正常循环，连续循环（训练循环）                  
            if (times != null && times.Count() > 0)
            {
                fh = times[0];
                cy = times[1];
                if ("APU".Equals(pnClass))
                {
                    fh = times[2];
                    cy = times[3];
                }
                ty = times[4];

                //对连续循环进行换算
                int rate = 1;
                if (trainRate != null && trainRate > 0)
                    rate = trainRate.Value;
                cy = cy + ty / rate;
                da = (DateTime.Now - sh.ActiveDate).Days;
            }
            #endregion

            #region 查询部件最新时间

            if (sh != null)
            {
                foreach (var unitHis in sh.SnHistoryUnits)
                {
                    decimal increase = 0;
                    var unit = unitHis.IntUnit;
                    if ("H".Equals(unit.Type) && "Install".Equals(sh.Active))
                    {
                        increase = fh;
                    }
                    else if ("C".Equals(unit.Type) && "Install".Equals(sh.Active))
                    {
                        increase = cy;
                    }
                    else if ("DA".Equals(unit.Unit))
                    {
                        increase = da;

                    }
                    else if ("MM".Equals(unit.Unit))
                    {
                        increase = Math.Round(da / 30, 2);
                    }
                    unitHis.USI = increase;
                    unitHis.USN = unitHis.USN + increase;
                    unitHis.USO = unitHis.USO + increase;
                    unitHis.USR = unitHis.USR + increase;
                }
            }
            sh.SnHistoryCy = sh.SnHistoryUnits.Where(p => "CY".Equals(p.Unit)).FirstOrDefault();
            sh.SnHistoryCy = sh.SnHistoryUnits.Where(p => "FH".Equals(p.Unit)).FirstOrDefault();
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
            Decimal[] times = new Decimal[] { 100, 60, 30, 60, 60 };
            // 从FLIGHT_LOG 获取数据           
            return times;
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

        /// <summary>
        /// 通过ID获取SnHistory
        /// </summary>
        /// <param name="snHistoryId"></param>
        /// <returns></returns>
        public SnHistoryDataObject GetLastSnHistoryBySnregID(int snRegId)
        {
            SnHistoryDataObject sh = null;
            var snHistory = _snHistoryRepository.GetLastSnHistoryBySnregID(snRegId.ToString());
            if (snHistory != null)
            {

                sh = Mapper.Map<SnHistory, SnHistoryDataObject>(snHistory);
                if (sh != null && sh.SnHistoryUnits != null && sh.SnHistoryUnits.Count > 0)
                {

                    sh.SnHistoryFh = sh.SnHistoryUnits.Where(o => "FH".Equals(o.Unit)).FirstOrDefault();
                    sh.SnHistoryCy = sh.SnHistoryUnits.Where(o => "CY".Equals(o.Unit)).FirstOrDefault();
                }
            }
            return sh;
        }

       

        #endregion
    }
}
