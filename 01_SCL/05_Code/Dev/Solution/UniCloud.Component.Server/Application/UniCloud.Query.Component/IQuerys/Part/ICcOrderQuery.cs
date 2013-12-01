#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/17 23:23:10

// 文件名：ICcOrderQuery
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
   /// 表示用于CcOrder的查询接口。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface ICcOrderQuery
   {
      #region Query CcOrder
      
      /// <summary>
      /// 获取所有CcOrder
      /// </summary>
      /// <returns>所有的CcOrder。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetCcOrders", ReplyAction ="http://www.UniCloud.com/IPartService/GetCcOrdersResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/GetCcOrdersDataFault")]
      CcOrderDataObjectList GetCcOrders(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter);
      
      /// <summary>
      /// 获取所有CcOrder分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的CcOrder分页信息。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetCcOrderWithPagination", ReplyAction ="http://www.UniCloud.com/IPartService/GetCcOrderWithPaginationResponse")]
      [FaultContract(typeof(FaultData), Name ="FaultData", Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action="http://www.UniCloud.com/IPartService/GetCcOrderWithPaginationDataFault")]
      CcOrderWithPagination GetCcOrderWithPagination(Pagination pagination);
      
      /// <summary>
      /// 通过CcOrderId获取相应的CcOrder
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetCcOrderByID", ReplyAction ="http://www.UniCloud.com/IPartService/GetCcOrderByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IPartService/GetCcOrderByIDDataFault")]
      CcOrderDataObject GetCcOrderByID(int id);

      /// <summary>
      ///发动机CcOrder分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>发动机CcOrder分页信息。</returns>
      [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetEngCcOrderWithPagination", ReplyAction = "http://www.UniCloud.com/IPartService/GetEngCcOrderWithPaginationResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetEngCcOrderWithPaginationDataFault")]
      CcOrderWithPagination GetEngCcOrderWithPagination(Pagination pagination);

      /// <summary>
      /// 通过CcOrderId获取相应发动机的CcOrder
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetEngCcOrderByID", ReplyAction = "http://www.UniCloud.com/IPartService/GetEngCcOrderByIDResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetEngCcOrderByIDDataFault")]
      CcOrderDataObject GetEngCcOrderByID(int id);
      #endregion
   }
}
