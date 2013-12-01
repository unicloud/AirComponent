#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/21 12:27:06

// 文件名：IWfHistoryQuery
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
   /// 表示用于WfHistory的查询接口。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IWfHistoryQuery
   {
      #region Query WfHistory
      
      /// <summary>
      /// 获取所有WfHistory
      /// </summary>
      /// <returns>所有的WfHistory。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetWfHistorys", ReplyAction ="http://www.UniCloud.com/IPartService/GetWfHistorysResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/GetWfHistorysDataFault")]
      WfHistoryDataObjectList GetWfHistorys(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter);
      
      /// <summary>
      /// 获取所有WfHistory分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的WfHistory分页信息。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetWfHistoryWithPagination", ReplyAction ="http://www.UniCloud.com/IPartService/GetWfHistoryWithPaginationResponse")]
      [FaultContract(typeof(FaultData), Name ="FaultData", Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action="http://www.UniCloud.com/IPartService/GetWfHistoryWithPaginationDataFault")]
      WfHistoryWithPagination GetWfHistoryWithPagination(Pagination pagination);
      
      /// <summary>
      /// 通过WfHistoryId获取相应的WfHistory
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetWfHistoryByID", ReplyAction ="http://www.UniCloud.com/IPartService/GetWfHistoryByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IPartService/GetWfHistoryByIDDataFault")]
      WfHistoryDataObject GetWfHistoryByID(int id);

      /// <summary>
      /// 通过WfHistoryId获取相应的WfHistory
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetWfHistorysByBusiness", ReplyAction = "http://www.UniCloud.com/IPartService/GetWfHistorysByBusinessResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetWfHistorysByBusinessDataFault")]
      WfHistoryDataObjectList GetWfHistorysByBusiness(string business, int businessID);

      #endregion
   }
}
