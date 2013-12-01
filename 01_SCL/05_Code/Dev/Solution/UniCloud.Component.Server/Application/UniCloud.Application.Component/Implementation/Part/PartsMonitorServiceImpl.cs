#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/6 21:54:49

// 文件名：PartsMonitorServiceImpl
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
   /// 表示与PartsMonitor相关的应用层服务的一种实现。
   /// </summary>
    public class PartsMonitorServiceImpl : ApplicationService, IPartsMonitorService
    {
        #region Private Fields
        private readonly IPartsMonitorRepository _partsMonitorRepository;
        private readonly IPartsMonitorQuery _partsMonitorQuery;
        private readonly IDomainService _domainService;
        private readonly IPnRegRepository _pnRegQuery;
        private readonly ISnHistoryRepository _snHistoryQuery;
        private readonly ISnRegRepository _snRegRepository;
        private readonly ISnHistoryRepository _snHistoryRepository;
        private readonly ICcpMainRepository _ccpMainRepository;
        private readonly ICcpMainService _ccpMainService;
        private readonly ISnRegQuery _snRegQuery;
        private readonly IAcIntUnitUtilizaRepository _acUtilizaRpt;
        private readonly IIntUnitRepository _intUnitRpt;
        private readonly IWorkScopeRepository _workScopeRpt;
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个<c>PartsMonitorServiceImpl</c>类型的实例。
        /// </summary>
        /// <param name="context">用来初始化<c>PartsMonitorServiceImpl</c>类型的仓储上下文实例。</param>
        /// <param name="partsMonitorRepository">“PartsMonitor”仓储实例。</param>
        /// <param name="partsMonitorQuery">“partsMonitorQuery”查询实例。</param>
        /// <param name="domainService">“领域服务”实例。</param>
        public PartsMonitorServiceImpl(IRepositoryContext context,
        IPartsMonitorRepository partsMonitorRepository,
        IPartsMonitorQuery partsMonitorQuery,
        IDomainService domainService,
        IPnRegRepository pnRegQuery,
        ISnHistoryRepository snHistoryQuery,
        ISnRegRepository snRegRepository,
        ISnHistoryRepository snHistoryRepository,
        ICcpMainService ccpMainService,
        ICcpMainRepository ccpMainRepository,
        ISnRegQuery snRegQuery,
        IAcIntUnitUtilizaRepository acUtilizaRpt,
        IIntUnitRepository intUnitRpt,
        IWorkScopeRepository workScopeRpt)
            : base(context)
        {
            this._partsMonitorRepository = partsMonitorRepository;
            this._partsMonitorQuery = partsMonitorQuery;
            this._domainService = domainService;
            this._pnRegQuery = pnRegQuery;
            this._snHistoryQuery = snHistoryQuery;
            this._snRegRepository = snRegRepository;
            this._snHistoryRepository = snHistoryRepository;
            this._ccpMainService = ccpMainService;
            this._ccpMainRepository = ccpMainRepository;
            this._snRegQuery = snRegQuery;
            this._acUtilizaRpt = acUtilizaRpt;
            this._intUnitRpt = intUnitRpt;
            this._workScopeRpt = workScopeRpt;

        }
        #endregion

        #region IPartsMonitorService

        /// <summary>
        /// 创建PartsMonitor。
        /// </summary>
        /// <param name="partsMonitors">需要创建的PartsMonitor。</param>
        /// <returns>创建的PartsMonitor。</returns>
        public PartsMonitorDataObjectList CreatePartsMonitors(PartsMonitorDataObjectList partsMonitors)
        {
            return PerformCreateObjects<PartsMonitorDataObjectList, PartsMonitorDataObject, PartsMonitor>(partsMonitors, _partsMonitorRepository);
        }

        /// <summary>
        /// 删除PartsMonitor信息。
        /// </summary>
        /// <param name="partsMonitorIDs">需要更新的PartsMonitor信息的ID值。</param>
        public IDList DeletePartsMonitors(IDList partsMonitorIDs)
        {
            PerformDeleteObjects(partsMonitorIDs, _partsMonitorRepository);
            return partsMonitorIDs;
        }

        /// <summary>
        /// 更新PartsMonitor信息。
        /// </summary>
        /// <param name="partsMonitors">需要更新的PartsMonitor信息。</param>
        public PartsMonitorDataObjectList UpdatePartsMonitors(PartsMonitorDataObjectList partsMonitors)
        {
            return PerformUpdateObjects<PartsMonitorDataObjectList, PartsMonitorDataObject, PartsMonitor>(partsMonitors,
               _partsMonitorRepository,
               pdo => pdo.ID,
               (p, pdo) =>
               {
               });
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

            _partsMonitorRepository.CommitPartsMonitor(addList, deleteList, updateList);

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
        #endregion

        #region IPartsMonitorQuery

        /// <summary>
        /// 通过PartsMonitorId获取相应的PartsMonitorDataObject 有导航属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PartsMonitorDataObject GetFullPartsMonitorByID(int id)
        {
            var result = _partsMonitorRepository.GetByKey(id);
            return result != null ? Mapper.Map<PartsMonitor, PartsMonitorDataObject>(result) : null;
        }

        /// <summary>
        ///  获取所有的PartsMonitor信息 有导航属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PartsMonitorDataObjectList GetFullPartsMonitors()
        {
            var results = _partsMonitorRepository.GetAll();
            return results != null ? Mapper.Map<IEnumerable<PartsMonitor>, PartsMonitorDataObjectList>(results) : null;
        }


        //提取所有/特定有效性附件项
        private PartsMonitor FindPartsMonitors(int snregid, string itemno, string workscope)
        {
            //状态为 C
            Expression<Func<PartsMonitor, bool>> exp = c => true;
            if (!string.IsNullOrEmpty(itemno))
            {
                exp = exp.And(p => itemno.Equals(p.ItemNo));
                //同时把历史版本查上来.
            }
            if (!string.IsNullOrEmpty(workscope))
            {
                exp = exp.And(p => workscope.Equals(p.Workscope));
                //同时把历史版本查上来.
            }
            if (snregid != null && snregid!=0)
            {
                exp = exp.And(p => p.SnRegID ==snregid);
            }
            var result = _partsMonitorRepository.GetAll(Specification<PartsMonitor>.Eval(exp)).FirstOrDefault();
            return result;
        }

        #endregion

        #region 附件监控 算法设计

        //计算所有附件项相关的到期日期
        public PartsMonitorDataObjectList CalculateAllCcpMain(){

            List<CcpMain> mains = GetReleaseTasks("");
            PartsMonitorDataObjectList results = new PartsMonitorDataObjectList();
            var re = CalculateCcpMains(mains);
            re.ForEach(
                p =>
                {                   
                    results.Add(Mapper.Map<PartsMonitor, PartsMonitorDataObject>(p));
                });
            return results;
        }
        
        //计算特定附件项相关的到期日期
        public PartsMonitorDataObjectList CalculateSpecificCcpMain(string itemno)
        {
            List<CcpMain> mains = GetReleaseTasks(itemno);
            // TODO 查找上一版本的附件项，针对不在新版内的适用部件，进行监控记录清理.

            PartsMonitorDataObjectList results = new PartsMonitorDataObjectList();
            var re = CalculateCcpMains(mains);
            re.ForEach(
                p =>
                {
                    results.Add(Mapper.Map<PartsMonitor, PartsMonitorDataObject>(p));
                });
            return results;
        }

        //计算特定的SN序号件
        public PartsMonitorDataObjectList CalculateSpecificSnregs(List<SnReg> sns)
        {
            PartsMonitorDataObjectList results = new PartsMonitorDataObjectList();
                       
            //var re = CalculateCcpSn(CcpMain main,SnReg sn, List<CcpLimit> limits, List<AcReg> acUtilization, ref List<PartsMonitor> result);
            //List<PartsMonitor> re = new List<PartsMonitor>();
            //String[] pns = new String[] { cpn.Pn};
            //List<SnReg> sns = GetSnRegs(pns);
            //if (sns != null && sns.Count > 0) 
            //{
            //    foreach (var sn in sns) { 
                
            //        //进入部件到期分析                    
            //        CalculateCcpSn(main, sn, limits, acUtilization, ref re);
            //    }                           
            //} 
            //re.ForEach(
            //    p =>
            //    {
            //        results.Add(Mapper.Map<PartsMonitor, PartsMonitorDataObject>(p));
            //    });
            return results;
        }

        //分析多项附件项
        private List<PartsMonitor> CalculateCcpMains(List<CcpMain> mains)
        {
            //飞机利用率
            List<AcIntUnitUtiliza> acUtilization = _acUtilizaRpt.GetAcIntUnitUtilizas();
            //控制单位
            List<IntUnit> units = _intUnitRpt.GetAll().ToList();
            //到期工作
            List<WorkScope> workScopes = _workScopeRpt.GetAll().ToList();
           
            List<PartsMonitor> result = new List<PartsMonitor>();
            foreach (var main in mains) {

                CalculateCcpMain(main, acUtilization, units, workScopes, ref result);
            }
            var updateList = new List<PartsMonitor>();
            var addList = new List<PartsMonitor>();

            foreach (var pm in result) {
                PartsMonitor db = FindPartsMonitors(pm.SnRegID, pm.ItemNo, pm.Workscope);
                if (db != null)
                {
                    pm.ID = db.ID;
                    updateList.Add(pm);
                }
                else {
                    addList.Add(pm);
                }
            }
            _partsMonitorRepository.CommitPartsMonitor(addList, null, updateList);

            result = updateList.Concat(addList).ToList();
            return result;
        }
        //分析附件项
        private void CalculateCcpMain(CcpMain main, List<AcIntUnitUtiliza> acUtilization,List<IntUnit> units, List<WorkScope> workScopes, ref List<PartsMonitor> result)
        {
            //当适用性以及间隔都存在的时候，才可以计算到期时间.
            if (main != null && main.CcpPns != null && main.CcpPns.Count > 0 && main.CcpLimits != null && main.CcpLimits.Count > 0) {

                string Ieam = "0";
                //每个附件项均有一个组号为“0”默认的间隔组                
                foreach (var cpn in main.CcpPns) {
                    if (!String.IsNullOrEmpty(cpn.Ieam))
                    {
                        Ieam = cpn.Ieam;//适用性有特定间隔
                        
                    }
                    var limits = main.CcpLimits.Where(o => Ieam.Equals(o.Ieam)).ToList();
                    if(limits!=null&& limits.Count>0){
                        //进入有效的适用性分析
                        CalculateCcpPn(main, cpn, limits, acUtilization, units, workScopes, ref result);   
                    }else{
                        // TODO 在系统日志中记录某项适用性找不到间隔                                
                    }
                }                      
            }
        }
        //分析有效适用性
        private void CalculateCcpPn(CcpMain main, CcpPn cpn, List<CcpLimit> limits, List<AcIntUnitUtiliza> acUtilization, List<IntUnit> units, List<WorkScope> workScopes, ref List<PartsMonitor> result)
        {
            
            String[] pns = new String[] { cpn.Pn};
            List<SnReg> sns = GetSnRegs(pns);
            if (sns != null && sns.Count > 0) 
            {
                foreach (var sn in sns) { 
                
                    //进入部件到期分析                    
                    CalculateCcpSn(main, sn, limits, acUtilization, units, workScopes, ref result);
                }                           
            }           
        }
        //分析部件到期
        private void CalculateCcpSn(CcpMain main, SnReg sn, List<CcpLimit> limits, List<AcIntUnitUtiliza> acUtilization, List<IntUnit> units, List<WorkScope> workScopes, ref List<PartsMonitor> result)
        {
            List<PartsMonitorDetail> detail = new List<PartsMonitorDetail>();
            Decimal[] ftimes = new Decimal[]{};//部件最近履历至今的飞行时间
            //GetSnRegTime(units,ref sn, ref ftimes);//初始化部件TSN...以及使用时间
            SnHistory sh = sn.snHistory;
            decimal[] times = GetFlightTime(sn.Ac,sn.InstallDate,DateTime.Now);
            GetSnRegTsn(sn.PnReg.PnClass, sn.PnReg.TrainRate, ref sh, times,units);
            sn.snHistory = sh;
            ApplCcpLimit(sn, ref limits);//排除不在适用范围内的间隔列表
            //计算适用间隔的剩余时间/到期日期
            CalculateLimitSn(main, sn, limits, acUtilization, units, workScopes, ref detail);

            var q =
                from p in detail
                group p by p.Workscope into g               
                select new
                {
                    g.Key,
                    ProductCount = g
                };

            foreach (var l in q.ToList())
            {
                string workscope = l.Key;
                var lm = limits.Where(o => workscope.Equals(o.WorkScope)).FirstOrDefault();
                List<PartsMonitorDetail> gd = l.ProductCount.ToList();
                PartsMonitorDetail de;
                if ("Y".Equals(lm.PolicyExec))
                {
                    de = gd.OrderBy(o => o.ExpireDate).FirstOrDefault();               
                }
                else {
                    de = gd.OrderByDescending(o => o.ExpireDate).FirstOrDefault();
                }                   
                PartsMonitor pm = new PartsMonitor();
                pm.ExpireDate = de.ExpireDate;
                pm.ItemNo = main.ItemNo;
                pm.NhItemNo = main.NhItemNo;
                pm.PartsMonitorDetails = gd;
                pm.PnRegID = de.PnRegID;
                pm.PolicyExec = lm.PolicyExec;
                pm.RemainTime = de.Remain.ToString();
                pm.SnRegID = de.SnRegID;
                pm.UsedTime = de.Used.ToString();
                pm.Workscope = de.Workscope;
                //pm.Snreg = sn;
                result.Add(pm);
            }
        }
        //分析间隔到期
        private void CalculateLimitSn(CcpMain main, SnReg sn, List<CcpLimit> limits, List<AcIntUnitUtiliza> acUtilization, List<IntUnit> units, List<WorkScope> workScopes, ref List<PartsMonitorDetail> result)
        {
            //Calendar calendar = Calendar.getInstance();
            foreach (var lm in limits) 
            {
                IntUnit unit = units.Where(a => a.Unit == lm.Unit).FirstOrDefault();
                var utiliza = acUtilization.Where(o=>o.AcReg == sn.Ac && o.Unit == lm.Unit).FirstOrDefault();
                decimal rate =1;
                if(utiliza != null)
                    rate = utiliza.Utiliza * utiliza.UtilizaRate;
                decimal used = 0;//已经使用的时间
                decimal next = lm.Interval;//到期的时间
                decimal remd = 99999999;//剩余的时间 
                int remd_ca = 0;//剩余日期
                var unitHis = sn.ccHistory.SnHistoryUnits.Where(o => o.Unit == lm.Unit).FirstOrDefault();
                var lastHis = sn.snHistory.SnHistoryUnits.Where(o => o.Unit == lm.Unit).FirstOrDefault();
                if (lm.Unit != "CA" && lm.Unit != "MM" && lm.Unit != "YE")
                {

                    if (lastHis != null)
                    {
                        if ("R".Equals(lm.WorkScopeItem.Type))
                        {
                            used = unitHis.USR - lastHis.USR;
                        }
                        else if ("O".Equals(lm.WorkScopeItem.Type))
                        {
                            used = unitHis.USO - lastHis.USO;
                        }
                        else
                        {
                            used = unitHis.USN - lastHis.USN;
                        }
                    }
                    else
                    {
                        //首次检查
                        if ("R".Equals(lm.WorkScopeItem.Type))
                        {
                            used = unitHis.USR;
                        }
                        else if ("O".Equals(lm.WorkScopeItem.Type))
                        {
                            used = unitHis.USO;
                        }
                        else
                        {
                            used = unitHis.USN;
                        }
                    }
                }
                else {
                    if ("N".Equals(lm.WorkScopeItem.Type))
                    {
                        used = (DateTime.Now - sn.snHistory.ActiveDate).Days;
                    }
                    else
                    {
                        if (sn.RepairDate == null)
                        {
                            used = (DateTime.Now - sn.InstallDate).Days;
                        }
                        else
                        {
                            used = (DateTime.Now - sn.RepairDate.Value).Days;
                        }
                    }
                }
                
                if ("CA".Equals(lm.Unit))
                {
                    remd = next - used;
                    remd_ca = (int)remd;
                }
                else if ("MM".Equals(lm.Unit))
                {
                    remd = next - used/30;
                    remd_ca = (int)(remd * 30);
                }
                else if ("YE".Equals(lm.Unit))
                {
                    remd = next - used /365;
                    remd_ca = (int)(remd * 365);
                }else{
                    remd = next - used;
                    remd_ca = (int)(remd / rate);                    
                }
                DateTime expireDate = DateTime.Now;
                expireDate = expireDate.AddDays(remd_ca);
                PartsMonitorDetail detail = new PartsMonitorDetail();
                detail.ExpireDate = expireDate;
                detail.Ieam = lm.Ieam;
                detail.Interval = lm.Interval;
                detail.ItemNo = main.ItemNo;
                detail.PnRegID = sn.PnRegID;
                detail.Remain = remd;
                detail.SnRegID = sn.ID;
                detail.Unit = lm.Unit;
                detail.Used = used;
                detail.Utiliza = rate;
                detail.Workscope = lm.WorkScope;
                
                result.Add(detail);
            }
        }
        //查找适用的间隔列表
        private void ApplCcpLimit(SnReg sn,ref List<CcpLimit> limits)
        {
            for (int i = limits.Count-1; i >= 0;i-- )
            {
                CcpLimit lm = limits[i];
                if (!String.IsNullOrEmpty(lm.RangeType))
                {
                    SnHistoryUnit unit = sn.snHistory.SnHistoryUnits.Where(p => p.Unit == lm.RangeType).FirstOrDefault();
                    if (unit != null)
                    {
                        if (lm.RangeMin == null)
                        {
                            lm.RangeMin = 0;
                        }
                        if (lm.RangeMax == null || lm.RangeMax == 0)
                        {
                            lm.RangeMax = 9999999;
                        }
                        if (lm.RangeMin.Value > unit.USN || unit.USN > lm.RangeMax.Value)
                        {
                            limits.RemoveAt(i);
                            // TODO ("附件项:" + ItemNo + "间隔组:" + Ieam + " "+"工作代码"+Work+"间隔"+"未激活！");
                        }
                    }
                }
            }    
        }

        private void GetSnRegTsn(string pnClass, int? trainRate, ref SnHistory sh, Decimal[] times, List<IntUnit>  units)
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
                    var unit = units.Where(p => unitHis.Unit.Equals(p.Unit)).FirstOrDefault();
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
            #endregion
        }

        /// <summary>
        /// 约定 
        /// times[0]飞行时间,
        /// times[1]飞行循环,
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

        //提取所有/特定有效性附件项
        private List<CcpMain> GetReleaseTasks(string itemno)
        {
            //状态为 C
            Expression<Func<CcpMain, bool>> exp = c => true;
            if (!string.IsNullOrEmpty(itemno))
            {
                exp = exp.And(p => itemno.Equals(p.ItemNo));                
                //同时把历史版本查上来.
            }
            else {
                exp = exp.And(p => "C".Equals(p.State));
            }            
            var result = _ccpMainRepository.GetAll(Specification<CcpMain>.Eval(exp)).ToList();
            return result;
        }
        //提取所有/特定有效性附件项
        private List<SnReg> GetSnRegs(String[] cpns)
        {
            return _snRegQuery.GetSnRegsByCalculate(cpns);            
        }

        #endregion

        #region 基础方法

        private bool isNotNull(int? value)
        {

            return value != null && value > 0;
        }


        #endregion
    }
}
