#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/6 21:54:49

// 文件名：IOilHistoryService
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
   /// 表示与OilHistory相关的应用层服务契约。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IOilHistoryService
   {
      /// <summary>
      /// 创建OilHistory。
      /// </summary>
      /// <param name="oilHistorys">需要创建的OilHistory。</param>
      /// <returns>创建的OilHistory。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CreateOilHistorys", ReplyAction ="http://www.UniCloud.com/IPartService/CreateOilHistorysResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CreateOilHistorysDataFault")]
      [Caching(CachingMethod.Remove, "GetOilHistorys")]
      OilHistoryDataObjectList CreateOilHistorys(OilHistoryDataObjectList oilHistorys);
      
      /// <summary>
      /// 删除OilHistory信息。
      /// </summary>
      /// <param name="oilHistoryIDs">需要更新的OilHistory信息的ID值。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/DeleteOilHistorys", ReplyAction ="http://www.UniCloud.com/IPartService/DeleteOilHistorysResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/DeleteOilHistorysDataFault")]
      [Caching(CachingMethod.Remove, "GetOilHistorys")]
      IDList DeleteOilHistorys(IDList oilHistoryIDs);
      
      /// <summary>
      /// 更新OilHistory信息。
      /// </summary>
      /// <param name="oilHistorys">需要更新的OilHistory信息。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/UpdateOilHistorys", ReplyAction ="http://www.UniCloud.com/IPartService/UpdateOilHistorysResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/UpdateOilHistorysDataFault")]
      [Caching(CachingMethod.Remove, "GetOilHistorys")]
      OilHistoryDataObjectList UpdateOilHistorys(OilHistoryDataObjectList oilHistorys);
      
      /// <summary>
      /// 提交OilHistory的增删改数据
      /// </summary>
      /// <param name="oilHistoryData"></param>
      /// <returns>提交成功的数据</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CommitOilHistorys", ReplyAction ="http://www.UniCloud.com/IPartService/CommitOilHistorysResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CommitOilHistorysDataFault")]
      [Caching(CachingMethod.Remove, "GetOilHistorys")]
      OilHistoryResultData CommitOilHistorys(OilHistoryResultData oilHistoryData);
      
      /// <summary>
      /// 通过OilHistoryId获取相应的OilHistory 带导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetFullOilHistoryByID", ReplyAction ="http://www.UniCloud.com/IPartService/GetFullOilHistoryByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IPartService/GetFullOilHistoryByIDDataFault")]
      OilHistoryDataObject GetFullOilHistoryByID(int id);
      
      /// <summary>
      /// 获取所有OilHistory 带导航属性
      /// </summary>
      /// <returns>所有的OilHistory。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetFullOilHistorys", ReplyAction ="http://www.UniCloud.com/IPartService/GetFullOilHistorysResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/GetFullOilHistorysDataFault")]
      OilHistoryDataObjectList GetFullOilHistorys();

   }
}
