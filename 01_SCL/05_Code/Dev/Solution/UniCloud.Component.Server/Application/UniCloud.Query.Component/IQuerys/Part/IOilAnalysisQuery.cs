#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/6 10:51:21

// 文件名：IOilAnalysisQuery
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.ServiceModel;
using UniCloud.DataObjects;

namespace UniCloud.Query
{
   /// <summary>
   /// 表示用于OilAnalysis的查询接口。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IOilAnalysisQuery
   {
      #region Query OilAnalysis
      
      /// <summary>
      /// 获取所有OilAnalysis
      /// </summary>
      /// <returns>所有的OilAnalysis。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetOilAnalysiss", ReplyAction ="http://www.UniCloud.com/IPartService/GetOilAnalysissResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/GetOilAnalysissDataFault")]
      OilAnalysisDataObjectList GetOilAnalysiss(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter);
      
      /// <summary>
      /// 获取所有OilAnalysis分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的OilAnalysis分页信息。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetOilAnalysisWithPagination", ReplyAction ="http://www.UniCloud.com/IPartService/GetOilAnalysisWithPaginationResponse")]
      [FaultContract(typeof(FaultData), Name ="FaultData", Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action="http://www.UniCloud.com/IPartService/GetOilAnalysisWithPaginationDataFault")]
      OilAnalysisWithPagination GetOilAnalysisWithPagination(Pagination pagination);
      
      /// <summary>
      /// 通过OilAnalysisId获取相应的OilAnalysis
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetOilAnalysisByID", ReplyAction ="http://www.UniCloud.com/IPartService/GetOilAnalysisByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IPartService/GetOilAnalysisByIDDataFault")]
      OilAnalysisDataObject GetOilAnalysisByID(int id);

      /// <summary>
      /// 通过OilAnalysisId获取相应的OilAnalysis
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetOilAnalysisBySnData", ReplyAction = "http://www.UniCloud.com/IPartService/GetOilAnalysisBySnDataResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetOilAnalysisBySnDataDataFault")]
      OilAnalysisDataObjectList GetOilAnalysisBySnData(OilAnalysisDataObject searchObj);
      #endregion      
      
   }
}
