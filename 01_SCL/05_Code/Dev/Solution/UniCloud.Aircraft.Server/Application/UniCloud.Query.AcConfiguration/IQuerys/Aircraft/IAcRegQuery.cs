#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/30 10:17:20

// 文件名：IAcRegQuery
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.ServiceModel;
using UniCloud.DataObjects;

namespace UniCloud.Query.AcConfiguration
{
   /// <summary>
   /// 表示用于AcReg的查询接口。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IAcRegQuery
   {
      #region Get AcReg
      
      /// <summary>
      /// 获取所有AcReg
      /// </summary>
      /// <returns>所有的AcReg。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetAcRegs", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetAcRegsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IAircraftService/GetAcRegsDataFault")]
      AcRegDataObjectList GetAcRegs(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter);
      
      /// <summary>
      /// 获取所有AcReg分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的AcReg分页信息。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetAcRegWithPagination", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetAcRegWithPaginationResponse")]
      [FaultContract(typeof(FaultData), Name ="FaultData", Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action="http://www.UniCloud.com/IAircraftService/GetAcRegWithPaginationDataFault")]
      AcRegWithPagination GetAcRegWithPagination(Pagination pagination);
      
      /// <summary>
      /// 通过AcRegId获取相应的AcReg
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetAcRegByID", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetAcRegByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IAircraftService/GetAcRegByIDDataFault")]
      AcRegDataObject GetAcRegByID(int id);

      /// <summary>
      /// 通过Guid获取相应的AcReg
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/GetAcRegByGuid", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcRegByGuidResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IAircraftService/GetAcRegByGuidDataFault")]
      AcRegDataObject GetAcRegByGuid(string id);

      /// <summary>
      /// 通过AcRegId获取相应的AcregLicenses
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/GetAcregLicenseByAcregID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcregLicenseByAcregIDResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IAircraftService/GetAcregLicenseByAcregIDDataFault")]
      AcregLicenseDataObjectList GetAcregLicenseByAcregID(int id);
      #endregion

       #region DropDownSource Collection

      /// <summary>
      /// 获取AcReg下拉数据集合
      /// </summary>
      /// <param name="colFilter"></param>
      /// <param name="sortFilter"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetAcRegCol", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetAcRegColResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IAircraftService/GetAcRegColDataFault")]
      KeyValueDataObjectList GetAcRegCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);
      #endregion

   }
}
