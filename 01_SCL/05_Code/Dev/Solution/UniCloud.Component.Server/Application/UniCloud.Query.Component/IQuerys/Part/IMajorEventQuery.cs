#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/16 16:16:39

// 文件名：IMajorEventQuery
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
   /// 表示用于MajorEvent的查询接口。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IMajorEventQuery
   {
      #region Query MajorEvent
      
      /// <summary>
      /// 获取所有MajorEvent
      /// </summary>
      /// <returns>所有的MajorEvent。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetMajorEvents", ReplyAction ="http://www.UniCloud.com/IPartService/GetMajorEventsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/GetMajorEventsDataFault")]
      MajorEventDataObjectList GetMajorEvents(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter);
      
      /// <summary>
      /// 获取所有MajorEvent分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的MajorEvent分页信息。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetMajorEventWithPagination", ReplyAction ="http://www.UniCloud.com/IPartService/GetMajorEventWithPaginationResponse")]
      [FaultContract(typeof(FaultData), Name ="FaultData", Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action="http://www.UniCloud.com/IPartService/GetMajorEventWithPaginationDataFault")]
      MajorEventWithPagination GetMajorEventWithPagination(Pagination pagination);
      
      /// <summary>
      /// 通过MajorEventId获取相应的MajorEvent
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetMajorEventByID", ReplyAction ="http://www.UniCloud.com/IPartService/GetMajorEventByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IPartService/GetMajorEventByIDDataFault")]
      MajorEventDataObject GetMajorEventByID(int id);
      #endregion
   }
}
