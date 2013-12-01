#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/6 11:27:30

// 文件名：IAcIntUnitUtilizaQuery
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
   /// 表示用于AcIntUnitUtiliza的查询接口。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IAcIntUnitUtilizaQuery
   {
      #region Query AcIntUnitUtiliza
      
      /// <summary>
      /// 获取所有AcIntUnitUtiliza
      /// </summary>
      /// <returns>所有的AcIntUnitUtiliza。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetAcIntUnitUtilizas", ReplyAction ="http://www.UniCloud.com/IPartService/GetAcIntUnitUtilizasResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/GetAcIntUnitUtilizasDataFault")]
      AcIntUnitUtilizaDataObjectList GetAcIntUnitUtilizas(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter);
      
      /// <summary>
      /// 获取所有AcIntUnitUtiliza分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的AcIntUnitUtiliza分页信息。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetAcIntUnitUtilizaWithPagination", ReplyAction ="http://www.UniCloud.com/IPartService/GetAcIntUnitUtilizaWithPaginationResponse")]
      [FaultContract(typeof(FaultData), Name ="FaultData", Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action="http://www.UniCloud.com/IPartService/GetAcIntUnitUtilizaWithPaginationDataFault")]
      AcIntUnitUtilizaWithPagination GetAcIntUnitUtilizaWithPagination(Pagination pagination);
      
      /// <summary>
      /// 通过AcIntUnitUtilizaId获取相应的AcIntUnitUtiliza
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetAcIntUnitUtilizaByID", ReplyAction ="http://www.UniCloud.com/IPartService/GetAcIntUnitUtilizaByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IPartService/GetAcIntUnitUtilizaByIDDataFault")]
      AcIntUnitUtilizaDataObject GetAcIntUnitUtilizaByID(int id);
      #endregion
   }
}
