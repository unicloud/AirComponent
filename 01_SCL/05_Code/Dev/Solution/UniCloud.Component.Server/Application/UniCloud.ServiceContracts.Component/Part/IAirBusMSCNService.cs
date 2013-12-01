#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/13 10:03:06

// 文件名：IAirBusMSCNService
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
   /// 表示与AirBusMSCN相关的应用层服务契约。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IAirBusMSCNService
   {
      /// <summary>
      /// 创建AirBusMSCN。
      /// </summary>
      /// <param name="airBusMSCNs">需要创建的AirBusMSCN。</param>
      /// <returns>创建的AirBusMSCN。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CreateAirBusMSCNs", ReplyAction ="http://www.UniCloud.com/IPartService/CreateAirBusMSCNsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CreateAirBusMSCNsDataFault")]
      [Caching(CachingMethod.Remove, "GetAirBusMSCNs")]
      AirBusMSCNDataObjectList CreateAirBusMSCNs(AirBusMSCNDataObjectList airBusMSCNs);
      
      /// <summary>
      /// 删除AirBusMSCN信息。
      /// </summary>
      /// <param name="airBusMSCNIDs">需要更新的AirBusMSCN信息的ID值。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/DeleteAirBusMSCNs", ReplyAction ="http://www.UniCloud.com/IPartService/DeleteAirBusMSCNsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/DeleteAirBusMSCNsDataFault")]
      [Caching(CachingMethod.Remove, "GetAirBusMSCNs")]
      IDList DeleteAirBusMSCNs(IDList airBusMSCNIDs);
      
      /// <summary>
      /// 更新AirBusMSCN信息。
      /// </summary>
      /// <param name="airBusMSCNs">需要更新的AirBusMSCN信息。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/UpdateAirBusMSCNs", ReplyAction ="http://www.UniCloud.com/IPartService/UpdateAirBusMSCNsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/UpdateAirBusMSCNsDataFault")]
      [Caching(CachingMethod.Remove, "GetAirBusMSCNs")]
      AirBusMSCNDataObjectList UpdateAirBusMSCNs(AirBusMSCNDataObjectList airBusMSCNs);
      
      /// <summary>
      /// 提交AirBusMSCN的增删改数据
      /// </summary>
      /// <param name="airBusMSCNData"></param>
      /// <returns>提交成功的数据</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CommitAirBusMSCNs", ReplyAction ="http://www.UniCloud.com/IPartService/CommitAirBusMSCNsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CommitAirBusMSCNsDataFault")]
      [Caching(CachingMethod.Remove, "GetAirBusMSCNs")]
      AirBusMSCNResultData CommitAirBusMSCNs(AirBusMSCNResultData airBusMSCNData);

   }
}
