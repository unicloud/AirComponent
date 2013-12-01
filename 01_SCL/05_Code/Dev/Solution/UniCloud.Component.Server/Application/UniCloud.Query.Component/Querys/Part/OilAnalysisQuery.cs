#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/6 11:27:30

// 文件名：OilAnalysisQuery
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
using UniCloud.Domain.Specifications;

namespace UniCloud.Query
{
   /// <summary>
   /// 表示用于OilAnalysis的查询接口。
   /// </summary>
   public class OilAnalysisQuery: IOilAnalysisQuery
   {
       private readonly ComponentDbContext _context;
       private const string ERROR_STRING_NEWLINE = "\n";

       public OilAnalysisQuery(IUniCloudDbContext context)
      {
          _context = context as ComponentDbContext;
      }
      
      #region Query OilAnalysis
      
      /// <summary>
      /// 获取所有OilAnalysis
      /// </summary>
      /// <returns>所有的OilAnalysis。</returns>
      public OilAnalysisDataObjectList GetOilAnalysiss(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter)
      {
         Expression<Func<OilAnalysis, bool>> source = p => true;
         return GetOilAnalysisList(source);
      }
      
      /// <summary>
      /// 获取所有OilAnalysis分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的OilAnalysis分页信息。</returns>
      public OilAnalysisWithPagination GetOilAnalysisWithPagination(Pagination pagination)
      {
         Expression<Func<OilAnalysis, bool>> wherePredicate = p => true;
         Expression<Func<OilAnalysis, dynamic>> sortPredicate = t =>t.FlightDate;
         return GetOilAnalysisPage(wherePredicate,sortPredicate,pagination);
      }
      
      /// <summary>
      /// 通过OilAnalysisId获取相应的OilAnalysis
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
       public OilAnalysisDataObject GetOilAnalysisByID(int id)
      {

          OilAnalysisDataObject sh = null;
          Expression<Func<OilAnalysis, bool>> source = p => p.ID == id;
          var queryResult = (_context.OilAnalysiss.Where(source).Select(t => new OilAnalysisDataObject()
          {
              FlightDate = t.FlightDate,
              Pn = t.Pn,
              Sn = t.Sn,
              AcReg = t.AcReg,
              Msn = t.Msn,
              Ata = t.Ata,
              Zone = t.Zone,
              Position = t.Position,
              Tqsr = t.Tqsr,
              Tsr = t.Tsr,
              Notes = t.Notes,
              Toc = t.Toc,
              Tocn = t.Tocn,
              Ioc = t.Ioc,
              Ioca = t.Ioca,
              Iocn = t.Iocn,
              Aoc3 = t.Aoc3,
              Aoc7 = t.Aoc7,
              Aocn = t.Aocn,
              WarnTag = t.WarnTag,
              ID = t.ID,
          })).OrderByDescending(o => o.ID).FirstOrDefault();
          
          if (queryResult != null) {
              sh = queryResult;
              //查找当天飞行记录
              var ohs = _context.OilHistorys.Where(p=>p.Sn ==sh.Sn && p.FlightDate == sh.FlightDate).Select(t => new OilHistoryDataObject()
                {
                    ID = t.ID,
                    AcReg = t.AcReg,
                    Msn = t.Msn,
                    FlightDate = t.FlightDate,
                    FlLogno = t.FlLogno,
                    FlLegno = t.FlLegno,
                    UpliftDer = t.UpliftDer,
                    UpliftArr = t.UpliftArr,
                    Pn = t.Pn,
                    Sn = t.Sn,
                    Ata = t.Ata,
                    Zone = t.Zone,
                    Position = t.Position,
                    Tsn = t.Tsn,
                    Csn = t.Csn,
                    Fh = t.Fh,
                    Cy = t.Cy,
                    InstalDate = t.InstalDate,
                    UpdateDate = t.UpdateDate,
                    Notes = t.Notes,
                  }).OrderByDescending(o => o.FlLogno).ToList();
              if (ohs != null)
              {
                  sh.Detail = new OilHistoryDataObjectList();
                  ohs.ForEach(o => sh.Detail.Add(o));
              }
          }             
         return sh;
      }

      #endregion
      
      #region Common Query
      
       private OilAnalysisDataObjectList GetOilAnalysisList(Expression<Func<OilAnalysis, bool>> source)
      {
         var queryResult = (_context.OilAnalysiss.Where(source).Select(t => new OilAnalysisDataObject()
            {
               FlightDate = t.FlightDate,
               Pn = t.Pn,
               Sn = t.Sn,
               AcReg = t.AcReg,
               Msn = t.Msn,
               Ata = t.Ata,
               Zone = t.Zone,
               Position = t.Position,
               Tqsr = t.Tqsr,
               Tsr = t.Tsr,
               Notes = t.Notes,
               Toc = t.Toc,
               Tocn = t.Tocn,
               Ioc = t.Ioc,
               Ioca = t.Ioca,
               Iocn = t.Iocn,
               Aoc3 = t.Aoc3,
               Aoc7 = t.Aoc7,
               Aocn = t.Aocn,
               WarnTag = t.WarnTag,
               ID = t.ID,
            })).ToList();
         if (!queryResult.Any()) return new OilAnalysisDataObjectList();
         var transferResult = new OilAnalysisDataObjectList();
         queryResult.ForEach(transferResult.Add);
         return transferResult;
      }
      
       private OilAnalysisWithPagination GetOilAnalysisPage(Expression<Func<OilAnalysis, bool>> wherePredicate,
                  Expression<Func<OilAnalysis, dynamic>> sortPredicate,
                  Pagination pagination)
      {
         Expression<Func<OilAnalysis,OilAnalysisDataObject>> mapper=t=> new OilAnalysisDataObject
            {
               FlightDate = t.FlightDate,
               Pn = t.Pn,
               Sn = t.Sn,
               AcReg = t.AcReg,
               Msn = t.Msn,
               Ata = t.Ata,
               Zone = t.Zone,
               Position = t.Position,
               Tqsr = t.Tqsr,
               Tsr = t.Tsr,
               Notes = t.Notes,
               Toc = t.Toc,
               Tocn = t.Tocn,
               Ioc = t.Ioc,
               Ioca = t.Ioca,
               Iocn = t.Iocn,
               Aoc3 = t.Aoc3,
               Aoc7 = t.Aoc7,
               Aocn = t.Aocn,
               WarnTag = t.WarnTag,
               ID = t.ID,
            };
         var OilAnalysisResult = _context.LoadPageDataObjects<OilAnalysis,OilAnalysisDataObject>(wherePredicate, sortPredicate, pagination, mapper,SortOrder.Descending);
         if(OilAnalysisResult==null) return null;
         pagination.TotalPages=OilAnalysisResult.TotalPages;
         var OilAnalysisWithPagination= new OilAnalysisWithPagination
            {
               Pagination=pagination,
               BaseDataObjectList = new BaseDataObjectList<OilAnalysisDataObject>()
            };
         foreach (var value in OilAnalysisResult.Data)
            {
               OilAnalysisWithPagination.BaseDataObjectList.Add(value);
            }
            return OilAnalysisWithPagination;
      }
      
      #endregion

      #region spec query
       public OilAnalysisDataObjectList GetOilAnalysisBySnData(OilAnalysisDataObject searchObj) {

           string error = "";
           string pn = searchObj.Pn;
           string sn = searchObj.Sn; 
           DateTime fromDate = searchObj.FromDate;
           DateTime toDate = searchObj.ToDate;

           //机型必填性校验
           //if (string.IsNullOrEmpty(pn))
           //{
           //    error = error + "分析条件,请输入发动机/APU件号" + ERROR_STRING_NEWLINE;
           //}
           if (string.IsNullOrEmpty(sn))
           {
               error = error + "分析条件,请输入发动机/APU序号" + ERROR_STRING_NEWLINE;
           }
           //if (fromDate == null)
           //{
           //    error = error + "分析条件,请输入起始时间" + ERROR_STRING_NEWLINE;
           //}
           //if (toDate == null)
           //{
           //    error = error + "分析条件,请输入起始时间" + ERROR_STRING_NEWLINE;
           //}
           
           if (!String.IsNullOrEmpty(error))
           {
               throw new Exception(error);
           }
           Expression<Func<OilAnalysis, bool>> source = p => true;
           if(!String.IsNullOrEmpty(pn))
           {
               source = source.And(p => pn.Equals(p.Pn));
           }
           if (!String.IsNullOrEmpty(sn))
           {
               source = source.And(p => sn.Equals(p.Sn));
           }
           if (fromDate!=null)
           {
               var date = fromDate.Date;
               source = source.And(p => p.FlightDate >= date);
           }
           if (toDate != null)
           {
               var date = toDate.Date;
               source = source.And(p => p.FlightDate <= date);
           }

           var queryResult = (_context.OilAnalysiss.Where(source).Select(t => new OilAnalysisDataObject()
           {
               FlightDate = t.FlightDate,
               Pn = t.Pn,
               Sn = t.Sn,
               AcReg = t.AcReg,
               Msn = t.Msn,
               Ata = t.Ata,
               Zone = t.Zone,
               Position = t.Position,
               Tqsr = t.Tqsr,
               Tsr = t.Tsr,
               Notes = t.Notes,
               Toc = t.Toc,
               Tocn = t.Tocn,
               Ioc = t.Ioc,
               Ioca = t.Ioca,
               Iocn = t.Iocn,
               Aoc3 = t.Aoc3,
               Aoc7 = t.Aoc7,
               Aocn = t.Aocn,
               WarnTag = t.WarnTag,
               ID = t.ID,
           })).ToList();
           if (!queryResult.Any()) return new OilAnalysisDataObjectList();
           var transferResult = new OilAnalysisDataObjectList();
           queryResult.ForEach(transferResult.Add);
           var l = transferResult.Where(p => p.Ioc > 0);
           var s = transferResult.Where(p => p.Ioca > 1);
           return transferResult;
       }

      #endregion

   }
}
