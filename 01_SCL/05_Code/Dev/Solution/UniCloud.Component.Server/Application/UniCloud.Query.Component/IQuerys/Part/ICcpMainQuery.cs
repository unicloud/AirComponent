#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/17 23:23:10

// 文件名：ICcpMainQuery
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
   /// 表示用于CcpMain的查询接口。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface ICcpMainQuery
   {
      #region Query CcpMain
      
      /// <summary>
      /// 获取所有CcpMain
      /// </summary>
      /// <returns>所有的CcpMain。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetCcpMains", ReplyAction ="http://www.UniCloud.com/IPartService/GetCcpMainsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/GetCcpMainsDataFault")]
      CcpMainDataObjectList GetCcpMains(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter);
      
      /// <summary>
      /// 获取所有CcpMain分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的CcpMain分页信息。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetCcpMainWithPagination", ReplyAction ="http://www.UniCloud.com/IPartService/GetCcpMainWithPaginationResponse")]
      [FaultContract(typeof(FaultData), Name ="FaultData", Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action="http://www.UniCloud.com/IPartService/GetCcpMainWithPaginationDataFault")]
      CcpMainWithPagination GetCcpMainWithPagination(Pagination pagination);
      
      /// <summary>
      /// 通过CcpMainId获取相应的CcpMain
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetCcpMainByID", ReplyAction ="http://www.UniCloud.com/IPartService/GetCcpMainByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IPartService/GetCcpMainByIDDataFault")]
      CcpMainDataObject GetCcpMainByID(int id);
      #endregion
   }
}
