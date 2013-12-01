#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/6 21:54:49

// 文件名：ISnHistoryService
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
   /// 表示与SnHistory相关的应用层服务契约。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface ISnHistoryService
   {
      /// <summary>
      /// 创建SnHistory。
      /// </summary>
      /// <param name="snHistorys">需要创建的SnHistory。</param>
      /// <returns>创建的SnHistory。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CreateSnHistorys", ReplyAction ="http://www.UniCloud.com/IPartService/CreateSnHistorysResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CreateSnHistorysDataFault")]
      [Caching(CachingMethod.Remove, "GetSnHistorys")]
      SnHistoryDataObjectList CreateSnHistorys(SnHistoryDataObjectList snHistorys);
      
      /// <summary>
      /// 删除SnHistory信息。
      /// </summary>
      /// <param name="snHistoryIDs">需要更新的SnHistory信息的ID值。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/DeleteSnHistorys", ReplyAction ="http://www.UniCloud.com/IPartService/DeleteSnHistorysResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/DeleteSnHistorysDataFault")]
      [Caching(CachingMethod.Remove, "GetSnHistorys")]
      IDList DeleteSnHistorys(IDList snHistoryIDs);
      
      /// <summary>
      /// 更新SnHistory信息。
      /// </summary>
      /// <param name="snHistorys">需要更新的SnHistory信息。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/UpdateSnHistorys", ReplyAction ="http://www.UniCloud.com/IPartService/UpdateSnHistorysResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/UpdateSnHistorysDataFault")]
      [Caching(CachingMethod.Remove, "GetSnHistorys")]
      SnHistoryDataObjectList UpdateSnHistorys(SnHistoryDataObjectList snHistorys);
      
      /// <summary>
      /// 提交SnHistory的增删改数据
      /// </summary>
      /// <param name="snHistoryData"></param>
      /// <returns>提交成功的数据</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CommitSnHistorys", ReplyAction ="http://www.UniCloud.com/IPartService/CommitSnHistorysResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CommitSnHistorysDataFault")]
      [Caching(CachingMethod.Remove, "GetSnHistorys")]
      SnHistoryResultData CommitSnHistorys(SnHistoryResultData snHistoryData);
      
      /// <summary>
      /// 通过SnHistoryId获取相应的SnHistory 带导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetFullSnHistoryByID", ReplyAction ="http://www.UniCloud.com/IPartService/GetFullSnHistoryByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IPartService/GetFullSnHistoryByIDDataFault")]
      SnHistoryDataObject GetFullSnHistoryByID(int id);
      
      /// <summary>
      /// 获取所有SnHistory 带导航属性
      /// </summary>
      /// <returns>所有的SnHistory。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetFullSnHistorys", ReplyAction ="http://www.UniCloud.com/IPartService/GetFullSnHistorysResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/GetFullSnHistorysDataFault")]
      SnHistoryDataObjectList GetFullSnHistorys();
   }
}
