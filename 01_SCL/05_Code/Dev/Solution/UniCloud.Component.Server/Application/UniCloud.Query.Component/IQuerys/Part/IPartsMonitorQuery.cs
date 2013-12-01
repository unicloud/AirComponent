#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/21 12:27:06

// 文件名：IPartsMonitorQuery
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
   /// 表示用于PartsMonitor的查询接口。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IPartsMonitorQuery
   {
      #region Query PartsMonitor
      
      /// <summary>
      /// 获取所有PartsMonitor
      /// </summary>
      /// <returns>所有的PartsMonitor。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetPartsMonitors", ReplyAction ="http://www.UniCloud.com/IPartService/GetPartsMonitorsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/GetPartsMonitorsDataFault")]
      PartsMonitorDataObjectList GetPartsMonitors(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter);
      
      /// <summary>
      /// 获取所有PartsMonitor分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的PartsMonitor分页信息。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetPartsMonitorWithPagination", ReplyAction ="http://www.UniCloud.com/IPartService/GetPartsMonitorWithPaginationResponse")]
      [FaultContract(typeof(FaultData), Name ="FaultData", Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action="http://www.UniCloud.com/IPartService/GetPartsMonitorWithPaginationDataFault")]
      PartsMonitorWithPagination GetPartsMonitorWithPagination(Pagination pagination);
      
      /// <summary>
      /// 通过PartsMonitorId获取相应的PartsMonitor
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetPartsMonitorByID", ReplyAction ="http://www.UniCloud.com/IPartService/GetPartsMonitorByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IPartService/GetPartsMonitorByIDDataFault")]
      PartsMonitorDataObject GetPartsMonitorByID(int id);
      #endregion
   }
}
