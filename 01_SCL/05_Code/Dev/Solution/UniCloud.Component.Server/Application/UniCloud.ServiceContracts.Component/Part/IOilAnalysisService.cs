#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/6 10:51:21

// 文件名：IOilAnalysisService
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.ServiceModel;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;
using UniCloud.Infrastructure.Caching;
using UniCloud.Query;

namespace UniCloud.ServiceContracts
{
   /// <summary>
   /// 表示与OilAnalysis相关的应用层服务契约。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IOilAnalysisService
   {
      /// <summary>
      /// 创建OilAnalysis。
      /// </summary>
      /// <param name="oilAnalysiss">需要创建的OilAnalysis。</param>
      /// <returns>创建的OilAnalysis。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CreateOilAnalysiss", ReplyAction ="http://www.UniCloud.com/IPartService/CreateOilAnalysissResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CreateOilAnalysissDataFault")]
      [Caching(CachingMethod.Remove, "GetOilAnalysiss")]
      OilAnalysisDataObjectList CreateOilAnalysiss(OilAnalysisDataObjectList oilAnalysiss);
      
      /// <summary>
      /// 删除OilAnalysis信息。
      /// </summary>
      /// <param name="oilAnalysisIDs">需要更新的OilAnalysis信息的ID值。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/DeleteOilAnalysiss", ReplyAction ="http://www.UniCloud.com/IPartService/DeleteOilAnalysissResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/DeleteOilAnalysissDataFault")]
      [Caching(CachingMethod.Remove, "GetOilAnalysiss")]
      IDList DeleteOilAnalysiss(IDList oilAnalysisIDs);
      
      /// <summary>
      /// 更新OilAnalysis信息。
      /// </summary>
      /// <param name="oilAnalysiss">需要更新的OilAnalysis信息。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/UpdateOilAnalysiss", ReplyAction ="http://www.UniCloud.com/IPartService/UpdateOilAnalysissResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/UpdateOilAnalysissDataFault")]
      [Caching(CachingMethod.Remove, "GetOilAnalysiss")]
      OilAnalysisDataObjectList UpdateOilAnalysiss(OilAnalysisDataObjectList oilAnalysiss);
      
      /// <summary>
      /// 提交OilAnalysis的增删改数据
      /// </summary>
      /// <param name="oilAnalysisData"></param>
      /// <returns>提交成功的数据</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CommitOilAnalysiss", ReplyAction ="http://www.UniCloud.com/IPartService/CommitOilAnalysissResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CommitOilAnalysissDataFault")]
      [Caching(CachingMethod.Remove, "GetOilAnalysiss")]
      OilAnalysisResultData CommitOilAnalysiss(OilAnalysisResultData oilAnalysisData);
      
      /// <summary>
      /// 通过OilAnalysisId获取相应的OilAnalysis 带导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetFullOilAnalysisByID", ReplyAction ="http://www.UniCloud.com/IPartService/GetFullOilAnalysisByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IPartService/GetFullOilAnalysisByIDDataFault")]
      OilAnalysisDataObject GetFullOilAnalysisByID(int id);
      
      /// <summary>
      /// 获取所有OilAnalysis 带导航属性
      /// </summary>
      /// <returns>所有的OilAnalysis。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetFullOilAnalysiss", ReplyAction ="http://www.UniCloud.com/IPartService/GetFullOilAnalysissResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/GetFullOilAnalysissDataFault")]
      OilAnalysisDataObjectList GetFullOilAnalysiss();

      /// <summary>
      /// 分析发动机相关的滑油添加记录
      /// </summary>
      /// <param name="condition"> 分析条件</param>
      /// <returns></returns>
      [OperationContract(Action = "http://www.UniCloud.com/IPartService/OilAnalysisOntime", ReplyAction = "http://www.UniCloud.com/IPartService/OilAnalysisOntimeResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/OilAnalysisOntimeDataFault")]
      void OilAnalysisOntime();
   }
}
