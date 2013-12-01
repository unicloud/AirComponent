#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/21 12:27:06

// 文件名：IOilHistoryQuery
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
   /// 表示用于OilHistory的查询接口。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IOilHistoryQuery
   {
      #region Query OilHistory
      
      /// <summary>
      /// 获取所有OilHistory
      /// </summary>
      /// <returns>所有的OilHistory。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetOilHistorys", ReplyAction ="http://www.UniCloud.com/IPartService/GetOilHistorysResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/GetOilHistorysDataFault")]
      OilHistoryDataObjectList GetOilHistorys(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter);
      
      /// <summary>
      /// 获取所有OilHistory分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的OilHistory分页信息。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetOilHistoryWithPagination", ReplyAction ="http://www.UniCloud.com/IPartService/GetOilHistoryWithPaginationResponse")]
      [FaultContract(typeof(FaultData), Name ="FaultData", Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action="http://www.UniCloud.com/IPartService/GetOilHistoryWithPaginationDataFault")]
      OilHistoryWithPagination GetOilHistoryWithPagination(Pagination pagination);
      
      /// <summary>
      /// 通过OilHistoryId获取相应的OilHistory
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetOilHistoryByID", ReplyAction ="http://www.UniCloud.com/IPartService/GetOilHistoryByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IPartService/GetOilHistoryByIDDataFault")]
      OilHistoryDataObject GetOilHistoryByID(int id);

      #endregion
   }
}
