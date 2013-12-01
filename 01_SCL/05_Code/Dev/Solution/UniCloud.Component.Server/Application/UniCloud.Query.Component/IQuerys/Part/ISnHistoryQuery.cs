#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/21 12:27:06

// 文件名：ISnHistoryQuery
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
   /// 表示用于SnHistory的查询接口。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface ISnHistoryQuery
   {
      #region Query SnHistory
      
      /// <summary>
      /// 获取所有SnHistory
      /// </summary>
      /// <returns>所有的SnHistory。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetSnHistorys", ReplyAction ="http://www.UniCloud.com/IPartService/GetSnHistorysResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/GetSnHistorysDataFault")]
      SnHistoryDataObjectList GetSnHistorys(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter);
      
      /// <summary>
      /// 获取所有SnHistory分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的SnHistory分页信息。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetSnHistoryWithPagination", ReplyAction ="http://www.UniCloud.com/IPartService/GetSnHistoryWithPaginationResponse")]
      [FaultContract(typeof(FaultData), Name ="FaultData", Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action="http://www.UniCloud.com/IPartService/GetSnHistoryWithPaginationDataFault")]
      SnHistoryWithPagination GetSnHistoryWithPagination(Pagination pagination);
      
      /// <summary>
      /// 通过SnHistoryId获取相应的SnHistory
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetSnHistoryByID", ReplyAction ="http://www.UniCloud.com/IPartService/GetSnHistoryByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IPartService/GetSnHistoryByIDDataFault")]
      SnHistoryDataObject GetSnHistoryByID(int id);

      /// <summary>
      /// 通过SnHistoryId获取相应的SnHistory
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action = "http://www.UniCloud.com/IPartService/QuerySnHistorys", ReplyAction = "http://www.UniCloud.com/IPartService/GetSnHistoryByIDResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetSnHistoryByIDDataFault")]
      SnHistoryDataObjectList QuerySnHistorys(string ac, string itemNo, string pn, DateTime fromDate, DateTime toDate);


      /// <summary>
      /// 通过部件ID获取最新的SnHistory
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetLastSnHistoryBySnregID", ReplyAction = "http://www.UniCloud.com/IPartService/GetSnHistoryByIDResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetSnHistoryByIDDataFault")]
      SnHistoryDataObject GetLastSnHistoryBySnregID(int id);

      #endregion
   }
}
