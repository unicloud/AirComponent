#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/6 10:51:21

// 文件名：OilAnalysisServiceImpl
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoMapper;
using Microsoft.Practices.ObjectBuilder2;
using UniCloud.DataObjects;
using UniCloud.Domain.Model;
using UniCloud.Domain.Repositories;
using UniCloud.Domain.Services;
using UniCloud.Query;
using UniCloud.ServiceContracts;
using System.Linq;
using System;
using System.Linq.Expressions;
using UniCloud.Domain.Specifications;

namespace UniCloud.Application.Implementation
{
   /// <summary>
   /// 表示与OilAnalysis相关的应用层服务的一种实现。
   /// </summary>
    public class OilAnalysisServiceImpl : ApplicationService, IOilAnalysisService
    {
        #region Private Fields
        private readonly IOilAnalysisRepository _oilAnalysisRepository;
        private readonly IOilAnalysisQuery _oilAnalysisQuery;
        private readonly IDomainService _domainService;
        private readonly IOilHistoryRepository _oilHistoryRepository;
        private readonly IOilHistoryQuery _oilHistoryQuery;
        private readonly ISnRegRepository _snRegRepository;
        private readonly ISnRegQuery _snRegQuery;
        private readonly IPnRegRepository _pnRegRepository;
        private const int LAST_DAY_ANALYSIS = -2;//往前推几天进行滑油分析（滑油数据要隔天才会稳定.）       
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个<c>OilAnalysisServiceImpl</c>类型的实例。
        /// </summary>
        /// <param name="context">用来初始化<c>OilAnalysisServiceImpl</c>类型的仓储上下文实例。</param>
        /// <param name="oilAnalysisRepository">“OilAnalysis”仓储实例。</param>
        /// <param name="oilAnalysisQuery">“oilAnalysisQuery”查询实例。</param>
        /// <param name="domainService">“领域服务”实例。</param>
        public OilAnalysisServiceImpl(IRepositoryContext context,
        IOilAnalysisRepository oilAnalysisRepository,
        IOilAnalysisQuery oilAnalysisQuery,
        IDomainService domainService,
        IOilHistoryRepository oilHistoryRepository,
        IOilHistoryQuery oilHistoryQuery,
        ISnRegRepository snRegRepository,
        IPnRegRepository pnRegRepository,
        ISnRegQuery snRegQuery)
            : base(context)
        {
            this._oilAnalysisRepository = oilAnalysisRepository;
            this._oilAnalysisQuery = oilAnalysisQuery;
            this._domainService = domainService;
            this._oilHistoryRepository = oilHistoryRepository;
            this._oilHistoryQuery = oilHistoryQuery;
            this._snRegRepository = snRegRepository;
            this._pnRegRepository = pnRegRepository;
            this._snRegQuery = snRegQuery;
        }
        #endregion

        #region IOilAnalysisService

        /// <summary>
        /// 创建OilAnalysis。
        /// </summary>
        /// <param name="oilAnalysiss">需要创建的OilAnalysis。</param>
        /// <returns>创建的OilAnalysis。</returns>
        public OilAnalysisDataObjectList CreateOilAnalysiss(OilAnalysisDataObjectList oilAnalysiss)
        {
            return PerformCreateObjects<OilAnalysisDataObjectList, OilAnalysisDataObject, OilAnalysis>(oilAnalysiss, _oilAnalysisRepository);
        }

        /// <summary>
        /// 删除OilAnalysis信息。
        /// </summary>
        /// <param name="oilAnalysisIDs">需要更新的OilAnalysis信息的ID值。</param>
        public IDList DeleteOilAnalysiss(IDList oilAnalysisIDs)
        {
            PerformDeleteObjects(oilAnalysisIDs, _oilAnalysisRepository);
            return oilAnalysisIDs;
        }

        /// <summary>
        /// 更新OilAnalysis信息。
        /// </summary>
        /// <param name="oilAnalysiss">需要更新的OilAnalysis信息。</param>
        public OilAnalysisDataObjectList UpdateOilAnalysiss(OilAnalysisDataObjectList oilAnalysiss)
        {
            return PerformUpdateObjects<OilAnalysisDataObjectList, OilAnalysisDataObject, OilAnalysis>(oilAnalysiss,
               _oilAnalysisRepository,
               pdo => pdo.ID,
               (p, pdo) =>
               {
               });
        }

        /// <summary>
        /// 提交OilAnalysis的增删改数据
        /// </summary>
        /// <param name="oilAnalysisData"></param>
        /// <returns>提交成功的数据</returns>
        public OilAnalysisResultData CommitOilAnalysiss(OilAnalysisResultData oilAnalysisData)
        {
            var resultData = new OilAnalysisResultData
            {
                AddedCollection =
                   new OilAnalysisDataObjectList(),
                DeletedCollection = new List<string>(),
                ModefiedCollection =
                   new OilAnalysisDataObjectList()
            };
            var addList = new List<OilAnalysis>();
            IEnumerable<string> deleteList = new List<string>();
            var updateList = new List<OilAnalysis>();

            #region Input

            if (oilAnalysisData.AddedCollection != null && oilAnalysisData.AddedCollection.Any())
            {
                oilAnalysisData.AddedCollection.ForEach(
                p =>
                {
                    addList.Add(Mapper.Map<OilAnalysisDataObject, OilAnalysis>(p));
                });
            }
            if (oilAnalysisData.DeletedCollection != null && oilAnalysisData.DeletedCollection.Any())
            {
                deleteList = oilAnalysisData.DeletedCollection;
            }
            if (oilAnalysisData.ModefiedCollection != null && oilAnalysisData.ModefiedCollection.Any())
            {
                oilAnalysisData.ModefiedCollection.ForEach(
                   p => updateList.Add(Mapper.Map<OilAnalysisDataObject, OilAnalysis>(p)));
            }

            #endregion

            _oilAnalysisRepository.CommitOilAnalysis(addList, deleteList, updateList);

            #region Output

            var addResults = new ObservableCollection<OilAnalysisDataObject>();
            if (addList.Any())
            {
                addList.ForEach(
                   p => addResults.Add(Mapper.Map<OilAnalysis, OilAnalysisDataObject>(p)));
                resultData.AddedCollection = addResults;
            }
            var updateResults = new ObservableCollection<OilAnalysisDataObject>();
            if (updateList.Any())
            {
                updateList.ForEach(
                   p => updateResults.Add(Mapper.Map<OilAnalysis, OilAnalysisDataObject>(p)));
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

        #region IOilAnalysisQuery

        ///// <summary>
        ///// 获取所有的OilAnalysis信息。
        ///// </summary>
        ///// <returns>所有的OilAnalysis信息。</returns>
        //public OilAnalysisDataObjectList GetOilAnalysiss()
        //{
        //   return _oilAnalysisQuery.GetOilAnalysiss();
        //}

        /// <summary>
        /// 获取所有的OilAnalysis分页信息。
        /// </summary>
        /// <returns>所有的OilAnalysis分页信息。</returns>
        public OilAnalysisWithPagination GetOilAnalysisWithPagination(Pagination pagination)
        {
            return _oilAnalysisQuery.GetOilAnalysisWithPagination(pagination);
        }

        /// <summary>
        /// 通过OilAnalysisId获取相应的OilAnalysisDataObject
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OilAnalysisDataObject GetOilAnalysisByID(int id)
        {
            OilAnalysisDataObject oa = null;
            oa = _oilAnalysisQuery.GetOilAnalysisByID(id);

            if(oa!=null){

                var ohs = FindSnOilHistoryByDate(oa.Sn, oa.FlightDate);
                if (ohs!=null)
                {
                    oa.Detail = new OilHistoryDataObjectList();
                    ohs.ForEach(o => oa.Detail.Add(Mapper.Map<OilHistory, OilHistoryDataObject>(o)));
                }
            }                     
            return oa;
        }

        /// <summary>
        /// 通过OilAnalysisId获取相应的OilAnalysisDataObject 有导航属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OilAnalysisDataObject GetFullOilAnalysisByID(int id)
        {
            var result = _oilAnalysisRepository.GetByKey(id);
            return result != null ? Mapper.Map<OilAnalysis, OilAnalysisDataObject>(result) : null;
        }

        /// <summary>
        ///  获取所有的OilAnalysis信息 有导航属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OilAnalysisDataObjectList GetFullOilAnalysiss()
        {
            var results = _oilAnalysisRepository.GetAll();
            return results != null ? Mapper.Map<IEnumerable<OilAnalysis>, OilAnalysisDataObjectList>(results) : null;
        }

        #endregion

        #region 滑油分析算法
        public void OilAnalysisOntime()
        {                      
            var addList = new List<OilAnalysis>();
            var updateList = new List<OilAnalysis>();
            List<SnReg> snregs = GetAllEngApus();
            if(snregs!=null&& snregs.Count>0){
                foreach (var sn in snregs) {
                    DateTime fd = sn.RepairDate == null ? sn.InstallDate : sn.RepairDate.Value;//数据范围起始日期
                    DateTime frd = DateTime.Now;//分析，起始日期
                    DateTime td = DateTime.Now.AddDays(LAST_DAY_ANALYSIS).Date;//分析，结束日期
                    OilAnalysis last = GetLastOilAnalysisBySnDate(sn.Sn,td);
                    if (last.FlightDate.AddDays(1).Date<=td.Date)
                    {
                        frd = last.FlightDate;
                    }
                    //td = DateTime.Parse("2013-10-26");
                    while (frd < td)
                    {
                        //生成监控记录
                        OilAnalysis snoa = new OilAnalysis();
                        List<OilHistory> ohs = new List<OilHistory>();
                        snoa.FlightDate = td;
                        snoa.AcReg = sn.Ac;
                        snoa.Ata = sn.Ata;
                        snoa.Pn = sn.PnReg.Pn;
                        snoa.Position = sn.Position;
                        snoa.Sn = sn.Sn;
                        snoa.Zone = snoa.Zone;
                        SnOilAnalysis(sn,fd,td,ref snoa, ref ohs);
                        var db = GetOilAnalysisBySnDate(sn.Sn, td);
                        if (db != null)
                        {
                            snoa.ID = db.ID;
                            updateList.Add(snoa);
                        }
                        else
                        {
                            addList.Add(snoa);
                        }
                        td = td.AddDays(-1);
                    }
                }
            }            
            _oilAnalysisRepository.CommitOilAnalysis(addList, null, updateList);
        }
        /// <summary>
        /// 计算某发动机/APU特定时间的
        /// </summary>
        /// <param name="sn"></param>
        /// <param name="analysis"></param>
        private void SnOilAnalysis(SnReg sn,DateTime fd, DateTime td,ref OilAnalysis analysis, ref List<OilHistory> td_oils)
        {
            //声明需要计算的TOC、IOC、IOCA、AOC3、AOC7
            decimal toc = 0, ioc = 0, ioc1 = 0, ioca = 0, aoc3 = 0, aoc7 = 0,tqsr = 0, tsr = 0;
            string warnTag = "";

            // 进行当天滑油添加记录提取
            List<OilHistory> oils = FindSnOilHistoryByDate(sn.Sn, fd, td);//修理至今的飞行记录
            if (oils != null && oils.Count > 0)
            {
                td_oils = oils.Where(p => p.FlightDate == td).ToList();//当天飞行记录
                var aoc3_oils = oils.Where(p => p.FlightDate >= td.AddDays(-2) && p.FlightDate <= td);//最近3天飞行记录
                var aoc7_oils = oils.Where(p => p.FlightDate >= td.AddDays(-6) && p.FlightDate <= td);//最近7天飞行记录

                #region 计算 TOC、IOC、IOCA、AOC3、AOC7
                //如果飞行记录不是从送修日期开始，则TQSR = LAST_TQSR + NEXT_Q,TSR = LAST_TSR + NEXT_H                
                if (oils.Where(p => p.FlightDate == fd).ToList().Count > 0)
                {
                    tqsr = oils.Sum(o => o.UpliftArr + o.UpliftDer);
                    tsr = oils.Sum(o => o.Fh);
                }
                else {
                    var last_oa = GetLastOilAnalysisBySnDate(sn.Sn, td);
                    if (last_oa != null)
                    {
                        tqsr = last_oa.Tqsr + oils.Where(p => p.FlightDate > last_oa.FlightDate && p.FlightDate <= td).Sum(o => o.UpliftArr + o.UpliftDer);
                        tsr = last_oa.Tsr + oils.Where(p => p.FlightDate > last_oa.FlightDate && p.FlightDate <= td).Sum(o => o.Fh);
                    }
                    else {
                        tqsr = oils.Sum(o => o.UpliftArr + o.UpliftDer);
                        tsr = oils.Sum(o => o.Fh);
                    }
                }                
                toc = Math.Round(tqsr / tsr, 4);
                decimal q3 = aoc3_oils.Sum(o => o.UpliftArr + o.UpliftDer);
                decimal fh3 = aoc3_oils.Sum(o => o.Fh);
                if (fh3 != 0)
                    aoc3 = Math.Round(q3 / fh3, 4);

                decimal q7 = aoc7_oils.Sum(o => o.UpliftArr + o.UpliftDer);
                decimal fh7 = aoc7_oils.Sum(o => o.Fh);
                if (fh7 != 0)
                    aoc7 = Math.Round(q7 / fh7, 4);

                #endregion

                #region 计算 IOC、IOCA
                //当加油量不等于0时，计算间隔消耗率和间隔消耗率增量
                decimal q = td_oils.Sum(o => o.UpliftArr + o.UpliftDer);//当天加油量
                if (q != 0)
                {
                    var oil = td_oils.Where(p => !(p.UpliftArr == 0 && p.UpliftDer == 0)).FirstOrDefault();//查找本次加油航段
                    //if(oil!=null)
                    var lastoil = GetIOC(oils, oil, ref ioc);
                    if(lastoil!=null)
                        GetIOC(oils, lastoil, ref ioc1);
                    if(ioc1!=0)
                        ioca = ioc - ioc1;
                }
                #endregion

            }
            #region 预警判断
            //toc 预警
            if (toc > 1)
                warnTag = warnTag + "X";
            else
                warnTag = warnTag + "-";
            //aoc3 预警
            if (aoc3 > 1)
                warnTag = warnTag + "X";
            else
                warnTag = warnTag + "-";
            //aoc7 预警
            if (aoc7 > 1)
                warnTag = warnTag + "X";
            else
                warnTag = warnTag + "-";
            //ioc 预警
            if (ioc > 1)
                warnTag = warnTag + "X";
            else
                warnTag = warnTag + "-";
            //ioca 预警
            if (ioca > 1)
                warnTag = warnTag + "X";
            else
                warnTag = warnTag + "-";
            #endregion

            analysis.Toc = toc;
            analysis.Tsr = tsr;
            analysis.Tqsr = tqsr;
            analysis.Ioc = ioc;
            analysis.Ioca = ioca;
            analysis.Aoc3 = aoc3;
            analysis.Aoc7 = aoc7;
            analysis.WarnTag = warnTag;
        }

        /// <summary>
        /// 获取本次加油记录的IOC，同时返回上一次加油记录.
        /// </summary>
        /// <param name="oils"></param>
        /// <param name="oil"></param>
        /// <param name="ioc"></param>
        /// <returns></returns>
        private static OilHistory GetIOC(List<OilHistory> oils, OilHistory oil, ref decimal ioc)
        {
            decimal fh = 0;
            decimal q = oil.UpliftArr + oil.UpliftDer;
            var lastOil = oils.Where(p => p.FlightDate<oil.FlightDate && p.Tsn<oil.Tsn && (p.UpliftArr != 0 || p.UpliftDer != 0)).FirstOrDefault();//查找上次加油航段
            //统计从上次加油航段至今的飞行时间，当是航后加的油，那么本次航段飞行时间不累计.
            if (lastOil != null)
            {
                if (lastOil.UpliftArr != 0)
                {
                    fh = oils.Where(p => p.FlightDate >= lastOil.FlightDate && p.Tsn > lastOil.Tsn && p.FlightDate <= oil.FlightDate && p.Tsn<oil.Tsn).Sum(p => p.Fh);
                }
                else
                {
                    fh = oils.Where(p => p.FlightDate >= lastOil.FlightDate && p.Tsn >= lastOil.Tsn && p.FlightDate <= oil.FlightDate && p.Tsn < oil.Tsn).Sum(p => p.Fh);
                }
            }
            else
            {
                fh = oils.Where(p => p.FlightDate <= oil.FlightDate && p.Tsn < oil.Tsn).Sum(p => p.Fh);
            }
            //如果本次是航后加油，则本次航段飞行时间统计进去，否则不用。
            if (oil.UpliftArr != 0)
            {
                fh = fh + oil.Fh;
            }
            ioc = Math.Round(q / fh, 4);
            return lastOil;
        }
        /// <summary>
        /// 查询某发动机/APU在一定时间内的加油记录.
        /// </summary>
        /// <param name="sn"></param>
        /// <param name="fd"></param>
        /// <param name="td"></param>
        /// <returns></returns>
        private List<OilHistory> FindSnOilHistoryByDate(string sn, DateTime fd, DateTime td)
        {
            List<OilHistory> hiss = null;

            Expression<Func<OilHistory, bool>> express = c => true;
            if (!string.IsNullOrEmpty(sn))
            {
                express = express.And(main => main.Sn.Equals(sn));
            }
            if (fd <= td)
            {
                express = express.And(main => main.FlightDate >= fd && main.FlightDate <= td);
            }
            hiss = _oilHistoryRepository.GetAll(Specification<OilHistory>.Eval(express)).OrderByDescending(o => o.FlLegno).OrderByDescending(o => o.FlLogno).ToList();
            //hiss = _oilHistoryRepository.GetAll(Specification<OilHistory>.Eval(express)).OrderByDescending(o => o.FlLegno).OrderByDescending(o => o.FlightDate).ToList();
            //hiss = _oilHistoryRepository.GetAll(Specification<OilHistory>.Eval(express)).OrderByDescending(o => o.Tsn).OrderByDescending(o => o.FlightDate).ToList();

            return hiss;
        }
        /// <summary>
        /// 查询某发动机/APU在一定时间内的加油记录.
        /// </summary>
        /// <param name="sn"></param>
        /// <param name="fd"></param>
        /// <param name="td"></param>
        /// <returns></returns>
        private List<OilHistory> FindSnOilHistoryByDate(string sn,DateTime td)
        {
            List<OilHistory> hiss = null;

            Expression<Func<OilHistory, bool>> express = c => true;
            if (!string.IsNullOrEmpty(sn))
            {
                express = express.And(main => main.Sn.Equals(sn));
            }           
            express = express.And(main =>  main.FlightDate == td);

            hiss = _oilHistoryRepository.GetAll(Specification<OilHistory>.Eval(express)).OrderByDescending(o => o.FlLegno).OrderByDescending(o => o.FlLogno).ToList();

            return hiss;
        }
        /// <summary>
        /// 查询指定件序号
        /// </summary>
        /// <param name="pn"></param>
        /// <param name="sn"></param>
        /// <param name="pnreg"></param>
        /// <param name="snregs"></param>
        private void GetPnRegSnRegs(string pn, string sn, ref PnReg pnreg, ref List<SnReg> snregs)
        {

            Expression<Func<PnReg, bool>> express1 = c => true;
            if (!string.IsNullOrEmpty(pn))
            {
                express1 = express1.And(main => pn.Equals(main.Pn));
            }
            pnreg = _pnRegRepository.GetAll(Specification<PnReg>.Eval(express1)).FirstOrDefault();

            Expression<Func<SnReg, bool>> express2 = c => true;
            if (!string.IsNullOrEmpty(pn))
            {
                express2 = express2.And(main => main.PnReg.Pn.Equals(pn));
            }
            if (!string.IsNullOrEmpty(sn))
            {
                express2 = express2.And(main => main.Sn.Equals(sn));
            }
            snregs = _snRegRepository.GetAll(Specification<SnReg>.Eval(express2)).ToList();

        }
        /// <summary>
        /// 获取所有的发动机和APU
        /// </summary>
        /// <returns></returns>
        private List<SnReg> GetAllEngApus()
        {
            string[] pnclass = new string[] { "ENG", "APU" };
            return _snRegQuery.GetSnRegsByOilAnalysis(pnclass);
        }

        /// <summary>
        /// 查找某个发动机/APU某日的监控记录
        /// </summary>
        /// <param name="sn"></param>
        /// <param name="fldate"></param>
        /// <returns></returns>
        private OilAnalysis GetOilAnalysisBySnDate(string sn, DateTime fldate)
        {
            Expression<Func<OilAnalysis, bool>> express2 = c => true;
            if (!string.IsNullOrEmpty(sn))
            {
                express2 = express2.And(main => main.Sn.Equals(sn));
            }
            if (fldate != null)
            {
                var date = fldate.Date;
                express2 = express2.And(main => main.FlightDate == date);
            }
            return _oilAnalysisRepository.GetAll(Specification<OilAnalysis>.Eval(express2)).OrderByDescending(o => o.FlightDate).FirstOrDefault();

        }
        /// <summary>
        /// 查找某个发动机/APU某日最新的监控记录
        /// </summary>
        /// <param name="sn"></param>
        /// <param name="fldate"></param>
        /// <returns></returns>
        private OilAnalysis GetLastOilAnalysisBySnDate(string sn, DateTime toDate)
        {
            Expression<Func<OilAnalysis, bool>> express2 = c => true;
            if (!string.IsNullOrEmpty(sn))
            {
                express2 = express2.And(main => main.Sn.Equals(sn));
            }
            if (toDate != null)
            {
                var date = toDate.Date;
                express2 = express2.And(main => main.FlightDate < date);
            }
            return _oilAnalysisRepository.GetAll(Specification<OilAnalysis>.Eval(express2)).OrderByDescending(a=>a.FlightDate).FirstOrDefault();

        }
        #endregion 
    }
}
