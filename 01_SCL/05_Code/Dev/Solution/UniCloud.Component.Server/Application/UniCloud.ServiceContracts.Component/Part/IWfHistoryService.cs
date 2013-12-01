#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/6 21:54:49

// 文件名：IWfHistoryService
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


namespace UniCloud.ServiceContracts
{
   /// <summary>
   /// 表示与WfHistory相关的应用层服务契约。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IWfHistoryService
   {
      /// <summary>
      /// 创建WfHistory。
      /// </summary>
      /// <param name="wfHistorys">需要创建的WfHistory。</param>
      /// <returns>创建的WfHistory。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CreateWfHistorys", ReplyAction ="http://www.UniCloud.com/IPartService/CreateWfHistorysResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CreateWfHistorysDataFault")]
      [Caching(CachingMethod.Remove, "GetWfHistorys")]
      WfHistoryDataObjectList CreateWfHistorys(WfHistoryDataObjectList wfHistorys);
      
      /// <summary>
      /// 删除WfHistory信息。
      /// </summary>
      /// <param name="wfHistoryIDs">需要更新的WfHistory信息的ID值。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/DeleteWfHistorys", ReplyAction ="http://www.UniCloud.com/IPartService/DeleteWfHistorysResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/DeleteWfHistorysDataFault")]
      [Caching(CachingMethod.Remove, "GetWfHistorys")]
      IDList DeleteWfHistorys(IDList wfHistoryIDs);
      
      /// <summary>
      /// 更新WfHistory信息。
      /// </summary>
      /// <param name="wfHistorys">需要更新的WfHistory信息。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/UpdateWfHistorys", ReplyAction ="http://www.UniCloud.com/IPartService/UpdateWfHistorysResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/UpdateWfHistorysDataFault")]
      [Caching(CachingMethod.Remove, "GetWfHistorys")]
      WfHistoryDataObjectList UpdateWfHistorys(WfHistoryDataObjectList wfHistorys);
      
      /// <summary>
      /// 提交WfHistory的增删改数据
      /// </summary>
      /// <param name="wfHistoryData"></param>
      /// <returns>提交成功的数据</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CommitWfHistorys", ReplyAction ="http://www.UniCloud.com/IPartService/CommitWfHistorysResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CommitWfHistorysDataFault")]
      [Caching(CachingMethod.Remove, "GetWfHistorys")]
      WfHistoryResultData CommitWfHistorys(WfHistoryResultData wfHistoryData);
      
      /// <summary>
      /// 通过WfHistoryId获取相应的WfHistory 带导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetFullWfHistoryByID", ReplyAction ="http://www.UniCloud.com/IPartService/GetFullWfHistoryByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IPartService/GetFullWfHistoryByIDDataFault")]
      WfHistoryDataObject GetFullWfHistoryByID(int id);
      
      /// <summary>
      /// 获取所有WfHistory 带导航属性
      /// </summary>
      /// <returns>所有的WfHistory。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetFullWfHistorys", ReplyAction ="http://www.UniCloud.com/IPartService/GetFullWfHistorysResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/GetFullWfHistorysDataFault")]
      WfHistoryDataObjectList GetFullWfHistorys();
   }
}
