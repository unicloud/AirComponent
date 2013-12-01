#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/16 16:16:39

// 文件名：IMajorEventService
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
   /// 表示与MajorEvent相关的应用层服务契约。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IMajorEventService
   {
      /// <summary>
      /// 创建MajorEvent。
      /// </summary>
      /// <param name="majorEvents">需要创建的MajorEvent。</param>
      /// <returns>创建的MajorEvent。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CreateMajorEvents", ReplyAction ="http://www.UniCloud.com/IPartService/CreateMajorEventsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CreateMajorEventsDataFault")]
      [Caching(CachingMethod.Remove, "GetMajorEvents")]
      MajorEventDataObjectList CreateMajorEvents(MajorEventDataObjectList majorEvents);
      
      /// <summary>
      /// 删除MajorEvent信息。
      /// </summary>
      /// <param name="majorEventIDs">需要更新的MajorEvent信息的ID值。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/DeleteMajorEvents", ReplyAction ="http://www.UniCloud.com/IPartService/DeleteMajorEventsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/DeleteMajorEventsDataFault")]
      [Caching(CachingMethod.Remove, "GetMajorEvents")]
      IDList DeleteMajorEvents(IDList majorEventIDs);
      
      /// <summary>
      /// 更新MajorEvent信息。
      /// </summary>
      /// <param name="majorEvents">需要更新的MajorEvent信息。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/UpdateMajorEvents", ReplyAction ="http://www.UniCloud.com/IPartService/UpdateMajorEventsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/UpdateMajorEventsDataFault")]
      [Caching(CachingMethod.Remove, "GetMajorEvents")]
      MajorEventDataObjectList UpdateMajorEvents(MajorEventDataObjectList majorEvents);
      
      /// <summary>
      /// 提交MajorEvent的增删改数据
      /// </summary>
      /// <param name="majorEventData"></param>
      /// <returns>提交成功的数据</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CommitMajorEvents", ReplyAction ="http://www.UniCloud.com/IPartService/CommitMajorEventsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CommitMajorEventsDataFault")]
      [Caching(CachingMethod.Remove, "GetMajorEvents")]
      MajorEventResultData CommitMajorEvents(MajorEventResultData majorEventData);
      
   }
}
