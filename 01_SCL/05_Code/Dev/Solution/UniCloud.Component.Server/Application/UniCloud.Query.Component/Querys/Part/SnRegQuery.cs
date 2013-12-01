#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/17 23:23:10

// 文件名：SnRegQuery
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UniCloud.DataObjects;
using UniCloud.Domain.Model;
using UniCloud.Domain.Repositories.EntityFramework;

namespace UniCloud.Query
{
   /// <summary>
   /// 表示用于SnReg的查询接口。
   /// </summary>
   public class SnRegQuery: ISnRegQuery
   {
      private readonly ComponentDbContext _context;
      
      public SnRegQuery(IUniCloudDbContext context)
      {
         _context = context as ComponentDbContext;
      }
      
      #region Query SnReg
      
      /// <summary>
      /// 获取所有SnReg
      /// </summary>
      /// <returns>所有的SnReg。</returns>
      public SnRegDataObjectList GetSnRegs(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter)
      {
         Expression<Func<SnReg, bool>> source = p => true;
         return GetSnRegList(source);
      }
      
      /// <summary>
      /// 获取所有SnReg分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的SnReg分页信息。</returns>
      public SnRegWithPagination GetSnRegWithPagination(Pagination pagination)
      {
         Expression<Func<SnReg, bool>> wherePredicate = p => true;
         Expression<Func<SnReg, dynamic>> sortPredicate = t =>t.ID;
         return GetSnRegPage(wherePredicate,sortPredicate,pagination);
      }
      
      /// <summary>
      /// 通过SnRegId获取相应的SnReg
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
       public SnRegDataObject GetSnRegByID(int id)
      {
         Expression<Func<SnReg, bool>> source = p => p.ID == id;
         var result = GetSnRegList(source);
         return result == null ? null : result.FirstOrDefault();
      }
      
      #endregion
      
      #region Common Query
      
       private SnRegDataObjectList GetSnRegList(Expression<Func<SnReg, bool>> source)
      {
         var queryResult = (_context.SnRegs.Where(source).Select(t => new SnRegDataObject()
            {
               PnRegID = t.PnRegID,
               Sn = t.Sn,
               Ac = t.Ac,
               Ata = t.Ata,
               Position = t.Position,
               InstallDate = t.InstallDate,
               Note = t.Note,
               Avail = t.Avail,
               NhSnRegID = t.NhSnRegID,
               RootSnRegID = t.RootSnRegID,
               Zone = t.Zone,
               SyncAMASIS = t.SyncAMASIS,
               EngineTli = t.EngineTli,
               ID = t.ID,
               Pn = t.PnReg.Pn,
               NhPnSn = (_context.SnRegs.Where(c => c.ID == t.NhSnRegID && c.ID != t.ID)
                            .Select(c => c.PnReg.Pn+"/"+c.Sn)).FirstOrDefault(),
               ItemNo = (_context.CcpMains.Where(c => c.CcpPns.Where(d=> t.PnReg.Pn.Equals(d.Pn)).Count()>0).FirstOrDefault().ItemNo)
                            ,
            })).ToList();
         if (!queryResult.Any()) return new SnRegDataObjectList();
         var transferResult = new SnRegDataObjectList();
         queryResult.ForEach(transferResult.Add);
         return transferResult;
      }

       public List<SnReg> GetSnRegsByCalculate(String[] cpns)
       {
           //.Select(t => new SnReg()
           //{
           //    ID = t.ID,
           //    PnRegID = t.PnRegID,
           //    Sn = t.Sn,
           //    Ac = t.Ac,
           //    InstallDate = t.InstallDate,
           //    Avail = t.Avail,
           //    NhSnRegID = t.NhSnRegID,
           //    RootSnRegID = t.RootSnRegID,
           //    EngineTli = t.EngineTli,               
           //}))
           //件号
           Expression<Func<SnReg, bool>> source = p => cpns.Contains(p.PnReg.Pn);
           var queryResult = (_context.SnRegs.Where(source).ToList());
           if (!queryResult.Any()) return new List<SnReg>();
           var transferResult = new List<SnReg>();
           queryResult.ForEach(t=>{     
          
               t.PnClass = t.PnReg.PnClass;
               t.TrainRate = t.PnReg.TrainRate;
               t.RootPnClass = (_context.SnRegs.Where(c => c.ID == t.RootSnRegID && c.ID != t.ID).Select(c => c.PnReg.PnClass)).FirstOrDefault();
               t.snHistory = (_context.SnHistorys.Where(c=>c.SnRegID == t.ID).OrderByDescending(o=>o.ID).FirstOrDefault());
               t.ccHistory = (_context.SnHistorys.Where(c => c.SnRegID == t.ID && ("Install".Equals(c.Active) || "Remove".Equals(c.Active))).OrderByDescending(o => o.ID)).FirstOrDefault();
                transferResult.Add(t);
           });
           return transferResult;
       }

       public List<SnReg> GetSnRegsByOilAnalysis(string[] pnclass)
       {
           
           Expression<Func<SnReg, bool>> exp = c => pnclass.Contains(c.PnReg.PnClass);                  
           var queryResult = (_context.SnRegs.Include("PnReg").Where(exp).ToList());
           if (!queryResult.Any()) return new List<SnReg>();
           var transferResult = new List<SnReg>();
           queryResult.ForEach(t =>
           {
               transferResult.Add(t);
           });
           return transferResult;
       }


       private SnRegWithPagination GetSnRegPage(Expression<Func<SnReg, bool>> wherePredicate,
                  Expression<Func<SnReg, dynamic>> sortPredicate,
                  Pagination pagination)
      {
          Expression<Func<SnReg, SnRegDataObject>> mapper = t => new SnRegDataObject
            {
               PnRegID = t.PnRegID,
               Sn = t.Sn,
               Ac = t.Ac,
               Ata = t.Ata,
               Position = t.Position,
               InstallDate = t.InstallDate,
               Note = t.PnReg.Description,
               Avail = t.Avail,
               NhSnRegID = t.NhSnRegID,
               RootSnRegID = t.RootSnRegID,
               Zone = t.Zone,
               EngineTli = t.EngineTli,
               ID = t.ID,
               SyncAMASIS=t.SyncAMASIS,
               Pn = t.PnReg.Pn,
               NhPnSn = (_context.SnRegs.Where(c => c.ID == t.NhSnRegID && c.ID!=t.ID)
                            .Select(c => c.PnReg.Pn + "/" + c.Sn)).FirstOrDefault(),
               ItemNo = (_context.CcpMains.Where(c => c.CcpPns.Where(d => t.PnReg.Pn.Equals(d.Pn)).Count() > 0).FirstOrDefault().ItemNo),
            };
         var SnRegResult = _context.LoadPageDataObjects<SnReg,SnRegDataObject>(wherePredicate, sortPredicate, pagination, mapper);
         if(SnRegResult==null) return null;
         pagination.TotalPages=SnRegResult.TotalPages;
         var SnRegWithPagination= new SnRegWithPagination
            {
               Pagination=pagination,
               BaseDataObjectList = new BaseDataObjectList<SnRegDataObject>()
            };
         foreach (var value in SnRegResult.Data)
            {
               SnRegWithPagination.BaseDataObjectList.Add(value);
            }
            return SnRegWithPagination;
      }
      
      #endregion

       public EgtMarginDataObjectList GetSnEgtMarginByID(int id)
       {
           var queryResults = _context.EgtMargins.Where(a => a.SnRegID == id)
               .Select(p => new EgtMarginDataObject()
               {
                   Egtm=p.Egtm,
                   ID=p.ID,
                   OperateDate=p.OperateDate,
                   Operator=p.Operator,
                   PnRegID=p.PnRegID,
                   SnRegID=p.SnRegID
               }).OrderByDescending(p=>p.OperateDate).ToList();
           var transferResult = new EgtMarginDataObjectList();
           queryResults.ForEach(transferResult.Add);
           return transferResult;
       }

       public SnRegWithPagination GetSnRegEgtWithPagination(Pagination pagination)
       {
           Expression<Func<SnReg, bool>> wherePredicate = p => p.PnReg.PnClass=="ENG";
           Expression<Func<SnReg, dynamic>> sortPredicate = t => t.ID;

           Expression<Func<SnReg, SnRegDataObject>> mapper = t => new SnRegDataObject
           {
               PnRegID = t.PnRegID,
               Sn = t.Sn,
               ID = t.ID,
               Pn = t.PnReg.Pn,
               Egtm = t.Egtm,
               //OperateDate = t.EgtMargins.OrderByDescending(a => a.OperateDate).FirstOrDefault().OperateDate,
               //Operator = t.EgtMargins.OrderByDescending(a => a.OperateDate).FirstOrDefault().Operator,
               EgtMarginID = t.EgtMargins.OrderByDescending(a => a.OperateDate).FirstOrDefault().ID,
           };
           var SnRegResult = _context.LoadPageDataObjects<SnReg, SnRegDataObject>(wherePredicate, sortPredicate, pagination, mapper);
           if (SnRegResult == null) return null;
           pagination.TotalPages = SnRegResult.TotalPages;
           var SnRegWithPagination = new SnRegWithPagination
           {
               Pagination = pagination,
               BaseDataObjectList = new BaseDataObjectList<SnRegDataObject>()
           };
           foreach (var value in SnRegResult.Data)
           {
               SnRegWithPagination.BaseDataObjectList.Add(value);
           }
           return SnRegWithPagination;
       }

       public EngineReportDtoWithPagination QueryEngineReports(Pagination pagination)
       {
           Expression<Func<SnReg, bool>> wherePredicate = p => p.PnReg.PnClass == "ENG";
           Expression<Func<SnReg, dynamic>> sortPredicate = t => t.Sn;
           Expression<Func<SnReg, SnRegDataObject>> mapper = t => new SnRegDataObject
           {
               Sn = t.Sn,
               ID = t.ID,
               Pn = t.PnReg.Pn,
               Ac=t.Ac,
               Position=t.Position,
               Propertys=t.Propertys,
               InstallDate = t.InstallDate,
               PnReg = new PnRegDataObject() { Pn = t.PnReg.Pn, PnClass = t.PnReg.PnClass, TrainRate = t.PnReg.TrainRate, EGTLimit = t.PnReg.EGTLimit },
               Avail = t.Avail,
               EngineTli = t.EngineTli,
           };
           var SnRegResult = _context.LoadPageDataObjects<SnReg, SnRegDataObject>(wherePredicate, sortPredicate, pagination, mapper);
           if (SnRegResult == null) return null;
           pagination.TotalPages = SnRegResult.TotalPages;
           var engineReportWithPagination = new EngineReportDtoWithPagination
           {
               Pagination = pagination,
               BaseDataObjectList = new BaseDataObjectList<EngineReportDto>()
           };
           List<IntUnit> units = _context.IntUnits.ToList();
           for (int i = 0; i < SnRegResult.Data.Count; i++)
           {
               var value = SnRegResult.Data[i];
               var dto = new EngineReportDto();
               dto.Snreg = value;
               dto.ID = value.ID;
               //从FlightLog中获取FC/M FH/M TSO CSO TSR CSR
               FillTimeEngine(ref dto, units);
               engineReportWithPagination.BaseDataObjectList.Add(dto);              

           }
           return engineReportWithPagination;
       }

       public EngineReportDto QueryEngineReportDetail(int id)
       {
           EngineReportDto dto = new EngineReportDto();
           var snreg = _context.SnRegs.Where(a => a.ID == id).Select(t=> new SnRegDataObject()
           {
               Sn = t.Sn,
               ID = t.ID,
               Pn = t.PnReg.Pn,
               Ac = t.Ac,
               Position = t.Position,
               Propertys = t.Propertys,
               InstallDate = t.InstallDate,
               PnReg = new PnRegDataObject() { Pn = t.PnReg.Pn, PnClass = t.PnReg.PnClass, TrainRate = t.PnReg.TrainRate, EGTLimit = t.PnReg.EGTLimit },
               Avail = t.Avail,
               EngineTli = t.EngineTli,          
           }).FirstOrDefault();
           if (snreg != null)
           {
               dto.ID = snreg.ID;
               dto.Snreg = snreg;
               List<IntUnit> units = _context.IntUnits.ToList();
               List<AcIntUnitUtiliza> utilizas = null;
               if (dto.Snreg.Ac != null && !"".Equals(dto.Snreg.Ac))
                   utilizas = _context.AcIntUnitUtilizas.Where(p => dto.Snreg.Ac.Equals(p.AcReg)).ToList();
               FillDateEngine(ref dto, units, utilizas);

               #region 获取下级件
               var childSnregs = _context.SnRegs.Where(a => a.RootSnRegID == snreg.ID && a.ID != snreg.ID).Select(t=>new SnRegDataObject()
               {
                   Sn = t.Sn,
                   ID = t.ID,
                   Pn = t.PnReg.Pn,
                   Ac = t.Ac,
                   Ata = t.Ata,
                   Position = t.Position,
                   Propertys = t.Propertys,
                   InstallDate = t.InstallDate,
                   Avail = t.Avail,       
               }).ToList();
               childSnregs.ForEach(p => dto.ChildSnregs.Add(p));
               #endregion

               #region 获取维修记录 Install Remove LeaseOut LeaseIn
               var shHistorys = _context.SnHistorys.Where(a => a.SnRegID == snreg.ID).OrderByDescending(p=>p.ActiveDate).ToList();
               foreach (var s in shHistorys)
               {
                   SnHistoryDataObject sh = new SnHistoryDataObject()
                                            {
                                                Source=s.Source,
                                                Active=s.Active,
                                                ActiveDate=s.ActiveDate,
                                                Ata=s.Ata,
                                                ID = s.ID,
                                                Orderno = s.Orderno,
                                                Position = s.Position,
                                                Note = s.Note,                                                
                                            };
                   sh.SnHistoryUnits = new SnHistoryUnitDataObjectList();
                   if (s.SnHistoryUnits != null && s.SnHistoryUnits.Count > 0) { 
                        
                         foreach(var t in s.SnHistoryUnits){
                             SnHistoryUnitDataObject ub = new SnHistoryUnitDataObject()
                                            {
                                                ID = t.ID,
                                                SnHistoryID=t.SnHistoryID,
                                                Unit = t.Unit,
                                                USN = t.USN,
                                                USI = t.USI,
                                                USO = t.USO,
                                                USR = t.USR
                                            };
                             sh.SnHistoryUnits.Add(ub);
                         }
                   }
                   if ("Install".Equals(sh.Active) || "Remove".Equals(sh.Active))
                   {
                       dto.SnHistorys.Add(sh);
                   }
                   else if ("LeaseOut".Equals(sh.Active) || "LeaseIn".Equals(sh.Active))
                   {
                       dto.EngLeaseHistorys.Add(sh);
                   }
                   else
                   {
                       dto.RepairHistorys.Add(sh);
                   }

               }
               #endregion
           }

           return dto;
       }

       private void FillTimeEngine(ref EngineReportDto eng, List<IntUnit> units)
       {

           decimal FHM = 0, FCM = 0,TSN = 0, CSN = 0,CSLSV = 0, TSLSV = 0, FCM24K = 0, FCM27K = 0, FCM27M = 0, FCM27E = 0, FCM33K = 0, FCM39K = 0;
           DateTime fromDate = DateTime.Now.Date;
           fromDate = fromDate.AddDays(-DateTime.Now.Day);
           DateTime toDate = DateTime.Now.Date;
           //FHM FCM 计算从月初到现在的飞行时间、飞行循环
           List<SnHistory> snHistorys = GetSnHistoryByDateSnregID(eng.Snreg.ID);
           var lastHistory = snHistorys.FirstOrDefault();//最后一条履历
           Decimal[] times = GetFlightTime(eng.Snreg.Ac, eng.Snreg.InstallDate, toDate);
           GetSnRegTsn(eng.Snreg.PnReg.PnClass,eng.Snreg.PnReg.TrainRate, ref lastHistory, times, units);
           var afterHistorys = snHistorys.Where(p => p.ActiveDate >= fromDate && ("Install".Equals(p.Active) || "Remove".Equals(p.Active))).ToList();//起始时间内是否有拆装
           //在位的飞机，计算月内多次飞行时间；不在位的飞机，只计算上次在位飞行时间
           if ("IN".Equals(eng.Snreg.Avail))
           {
               FHM = FHM + times[0];
               FCM = FCM + times[1];
               PowerLevel(times, eng.FCM27E, ref FCM24K, ref FCM27K, ref FCM27M, ref FCM27E, ref FCM33K, ref FCM39K);
           }

           #region 月内有拆下的情况，计算月初至拆下之间飞行时间
           if (afterHistorys != null && afterHistorys.Count > 0)
           {
               SnHistory lastHis = null;
               for (int i = 0; i < afterHistorys.Count(); i++)
               {
                   Decimal[] times2 = new Decimal[] { 0, 0, 0, 0, 0 };
                   var sh = afterHistorys[i];
                   if ("Remove".Equals(sh.Active))
                   {
                       DateTime _fromDate = fromDate;
                       lastHis = afterHistorys.Where(p => p.ActiveDate > fromDate).FirstOrDefault();
                       if (lastHis != null)
                           _fromDate = lastHis.ActiveDate;
                       times2 = GetFlightTime(eng.Snreg.Ac, _fromDate, sh.ActiveDate);
                   }
                   FHM = FHM + times2[0];
                   FCM = FCM + times2[1];
                   PowerLevel( times2, sh.Note,ref FCM24K, ref FCM27K, ref FCM27M, ref FCM27E, ref FCM33K, ref FCM39K);
               }
           #endregion
           }            
                      
           TSN = lastHistory.SnHistoryUnits.Where(p => "FH".Equals(p.Unit)).Select(a => a.USN).FirstOrDefault();
           TSLSV = lastHistory.SnHistoryUnits.Where(p => "FH".Equals(p.Unit)).Select(a => a.USR).FirstOrDefault();
           CSN = lastHistory.SnHistoryUnits.Where(p => "CY".Equals(p.Unit)).Select(a => a.USN).FirstOrDefault();
           CSLSV = lastHistory.SnHistoryUnits.Where(p => "CY".Equals(p.Unit)).Select(a => a.USR).FirstOrDefault();

           eng.FHM = FHM.ToString();
           eng.FCM = FCM.ToString();
           eng.TSN = TSN.ToString();
           eng.CSN = CSN.ToString();
           eng.CSLSV = CSLSV.ToString();
           eng.TSLSV = TSLSV.ToString();
           eng.FCM24K = FCM24K.ToString();
           eng.FCM27K = FCM27K.ToString();
           eng.FCM27M = FCM27M.ToString();           
           eng.FCM27E = FCM27E.ToString();
           eng.FCM33K = FCM33K.ToString();
           eng.FCM39K = FCM39K.ToString();
       }
       private void FillDateEngine(ref EngineReportDto eng, List<IntUnit> units, List<AcIntUnitUtiliza> utilizas)
       {
           decimal TSN = 0, CSN = 0;
           DateTime egtDeadlineDate = DateTime.Now, planRepairDate = DateTime.Now;
           DateTime fromDate = DateTime.Now.Date;
           fromDate = fromDate.AddDays(-DateTime.Now.Day);
           DateTime toDate = DateTime.Now.Date;
           //FHM FCM 计算从月初到现在的飞行时间、飞行循环
           List<SnHistory> snHistorys = GetSnHistoryByDateSnregID(eng.Snreg.ID);
           var lastHistory = snHistorys.FirstOrDefault();//最后一条履历
           Decimal[] times = GetFlightTime(eng.Snreg.Ac, eng.Snreg.InstallDate, toDate);
           GetSnRegTsn(eng.Snreg.PnReg.PnClass, eng.Snreg.PnReg.TrainRate, ref lastHistory, times, units);
           TSN = lastHistory.SnHistoryUnits.Where(p => "FH".Equals(p.Unit)).Select(a => a.USN).FirstOrDefault();          
           CSN = lastHistory.SnHistoryUnits.Where(p => "CY".Equals(p.Unit)).Select(a => a.USN).FirstOrDefault();
           if ("IN".Equals(eng.Snreg.Avail))
           {
               TSN = TSN + times[0];
               CSN = CSN + times[1];
           }
           if ("IN".Equals(eng.Snreg.Avail))
           {
               AnalysisEgtDeadline(eng.Snreg, utilizas, eng.Snreg.Egtm, eng.Snreg.PnReg.EGTLimit, ref egtDeadlineDate);
               eng.EgtExpireTime = egtDeadlineDate;
           }
           if ("IN".Equals(eng.Snreg.Avail))
           { 
               AnalysisIntervalDeadline(eng.Snreg, utilizas,times, ref planRepairDate);
               eng.PlanRepairDate = planRepairDate;
           }
           eng.TSN = TSN.ToString();
           eng.CSN = CSN.ToString();
       }
       /// <summary>
       /// 根据EGT裕度，进行到期分析.预计EGTM为0日期=当前EGTM÷EGTM衰减+当前日期
       /// </summary>
       private static void AnalysisEgtDeadline(SnRegDataObject snreg, List<AcIntUnitUtiliza> utilizas, decimal? Egtm, decimal? EGTLimit, ref DateTime egtDeadlineDate)
       {
           string error = "";
           if (EGTLimit == null)
           {
               error = error + "请设置发动机件号：" + snreg.Pn + " 的EGT下限值.\n";
           }
           if (utilizas == null || utilizas.Count <= 0)
           {
               error = error + "请设置飞机：" + snreg.Ac + " 的利用率\n";
           }
           if (Egtm == null)
           {
               error = error + "请设置发动机：" + snreg.Sn.Trim() + " 的EGT裕度.\n";
           }

           if ("".Equals(error))
           {
               decimal remDay = Egtm.Value / EGTLimit.Value;
               int day = (Int16)remDay;
               egtDeadlineDate = egtDeadlineDate.AddDays(day);
           }
           else
           {
               //throw new Exception(error);
           }
       }

       /// <summary>
       /// 根据预设间隔进行到期时间分析，预计修理日期=预计修理间隔（人工输入）÷日利用小时+当前日期
       /// </summary>
       private static void AnalysisIntervalDeadline(SnRegDataObject snreg, List<AcIntUnitUtiliza> utilizas, decimal[] times, ref DateTime planRepairDate)
       {
           string error = "";
           if (snreg.Interval == null || "".Equals(snreg.Interval))
           {
               error = error + "请设置发动机：" + snreg.Sn.Trim() + " 的预计维修间隔.\n";
           }
           if (utilizas == null || utilizas.Count <= 0)
           {
               error = error + "请设置飞机：" + snreg.Ac + " 的利用率.\n";
           }
           if ("".Equals(error))
           {
               string[] intervals = snreg.Interval.Split(';');
               decimal[] remDays = new decimal[] {0,0};
               foreach (var val in intervals)
               {
                   decimal utiliza = 0, interval = 0, use = 0, rem = 0, remDay = 0;
                   var unit = val.Split(' ');
                   utiliza = utilizas.Where(p => unit.Equals(p.Unit)).Select(a => a.Utiliza * a.UtilizaRate).FirstOrDefault();                                     
                   if ("FH".Equals(unit[0]))
                   {                       
                       interval = Decimal.Parse(unit[1]);
                       use = times[0];                    
                   }
                   else
                   {
                       decimal intervalCy = Decimal.Parse(unit[1]);
                       decimal useCy = times[1];
                   }
                   rem = interval - use;
                   remDay = rem / utiliza;
                   remDays[0] = remDay;
               }
               int day = (Int16)remDays.Min();
               planRepairDate = planRepairDate.AddDays(day);
           }
           else {
               //throw new Exception(error);
           }
       }

       /// <summary>
       /// 判断飞行时间是在什么推力下
       /// </summary>
       private static void PowerLevel(Decimal[] times2, string engineTli, ref decimal FCM24K, ref decimal FCM27K, ref decimal FCM27M, ref decimal FCM27E, ref decimal FCM33K, ref decimal FCM39K)
       {
           if ("24K".Equals(engineTli))
           {
               FCM24K = FCM24K + times2[1];
           }
           else if ("27K".Equals(engineTli))
           {
               FCM27K = FCM27K + times2[1];
           }
           else if ("27M".Equals(engineTli))
           {
               FCM27M = FCM27M + times2[1];
           }
           else if ("27E".Equals(engineTli))
           {
               FCM27E = FCM27E + times2[1];
           }
           else if ("33K".Equals(engineTli))
           {
               FCM33K = FCM33K + times2[1];
           }
           else if ("39K".Equals(engineTli))
           {
               FCM39K = FCM39K + times2[1];
           }
           else
           {
               // 警告，出现预期范围外的发动机推力等级。
           }
       }

       private void GetSnRegTsn(string pnClass, int? trainRate, ref SnHistory sh, Decimal[] times, List<IntUnit> units)
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
               if (trainRate!=null && trainRate > 0)
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
                   var unit = units.Where(p=>unitHis.Unit.Equals(p.Unit)).FirstOrDefault();
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
           Decimal[] times = new Decimal[] { 0, 0, 0, 0, 0 };
           if (acreg != null && !"".Equals(acreg)) {

               times = new Decimal[] { 100, 60, 30, 60, 60 };
           }
           
           // 从FLIGHT_LOG 获取数据           
           return times;
       }
       /// <summary>
       /// 通过ID获取SnHistory
       /// </summary>
       /// <param name="snHistoryId"></param>
       /// <returns></returns>
       public List<SnHistory> GetSnHistoryByDateSnregID(int snRegId)
       {          
           var snHistory = _context.SnHistorys.Where(p=>p.SnRegID == snRegId).OrderByDescending(a=>a.ActiveDate).ToList();

           return snHistory;
       }
   }
}
