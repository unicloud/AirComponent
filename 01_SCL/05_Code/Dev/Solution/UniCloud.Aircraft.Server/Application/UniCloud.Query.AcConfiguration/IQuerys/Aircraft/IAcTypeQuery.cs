#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/30 10:17:20

// 文件名：IAcTypeQuery
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
   /// 表示用于AcType的查询接口。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IAcTypeQuery
   {
      #region Get AcType
      
      /// <summary>
      /// 获取所有AcType
      /// </summary>
      /// <returns>所有的AcType。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetAcTypes", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetAcTypesResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IAircraftService/GetAcTypesDataFault")]
      AcTypeDataObjectList GetAcTypes(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter);
      
      /// <summary>
      /// 获取所有AcType分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的AcType分页信息。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetAcTypeWithPagination", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetAcTypeWithPaginationResponse")]
      [FaultContract(typeof(FaultData), Name ="FaultData", Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action="http://www.UniCloud.com/IAircraftService/GetAcTypeWithPaginationDataFault")]
      AcTypeWithPagination GetAcTypeWithPagination(Pagination pagination);
      
      /// <summary>
      /// 通过AcTypeId获取相应的AcType
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetAcTypeByID", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetAcTypeByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IAircraftService/GetAcTypeByIDDataFault")]
      AcTypeDataObject GetAcTypeByID(int id);

      /// <summary>
      /// 通过GuidID获取相应的AcType
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/GetAcTypeByGuid", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcTypeByGuidResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IAircraftService/GetAcTypeByGuidDataFault")]
      AcTypeDataObject GetAcTypeByGuid(string id);

      /// <summary>
      /// 获取所有AcModel
      /// </summary>
      /// <returns>所有的AcModel。</returns>
      [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/GetAcModels", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcModelsResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IAircraftService/GetAcModelsDataFault")]
      AcModelDataObjectList GetAcModels(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);


      /// <summary>
      /// 通过AcModelId获取相应的AcModel
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/GetAcModelByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcModelByIDResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IAircraftService/GetAcModelByIDDataFault")]
      AcModelDataObject GetAcModelByID(int Id);

      /// <summary>
      /// 通过GUID获取相应的AcModel
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/GetAcModelByGuid", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcModelByGuidResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IAircraftService/GetAcModelByGuidDataFault")]
      AcModelDataObject GetAcModelByGuid(string Id);

      /// <summary>
      /// 获取所有AcConfig
      /// </summary>
      /// <returns>所有的GetAcConfigs。</returns>
      [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/GetAcConfigs", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcConfigsResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IAircraftService/GetAcConfigsDataFault")]
      AcConfigDataObjectList GetAcConfigs(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

      /// <summary>
      /// 通过AcRegId获取相应的AcregLicenses
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/GetAcConfigByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcConfigByIDResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IAircraftService/GetAcConfigByIDDataFault")]
      AcConfigDataObject GetAcConfigByID(int Id);

      /// <summary>
      /// 通过GUID获取相应的AcregLicenses
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/GetAcConfigByGuid", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcConfigByGuidResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IAircraftService/GetAcConfigByGuidDataFault")]
      AcConfigDataObject GetAcConfigByGuid(string Id);
      #endregion

      #region AcTypeDorpDownSource
      
      /// <summary>
      /// 获取AcType下拉数据集合
      /// </summary>
      /// <param name="colFilter"></param>
      /// <param name="sortFilter"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetAcTypeCol", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetAcTypeColResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IAircraftService/GetAcTypeColDataFault")]
      KeyValueDataObjectList GetAcTypeCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

      /// <summary>
      /// 获取AcConfig下拉数据集合
      /// </summary>
      /// <param name="colFilter"></param>
      /// <param name="sortFilter"></param>
      /// <returns></returns>
      [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/GetAcConfigCol", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcConfigColResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IAircraftService/GetAcConfigColDataFault")]
      KeyValueDataObjectList GetAcConfigCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

      /// <summary>
      /// 获取AcModel下拉数据集合
      /// </summary>
      /// <param name="colFilter"></param>
      /// <param name="sortFilter"></param>
      /// <returns></returns>
      [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/GetAcModelCol", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcModelColResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IAircraftService/GetAcModelColDataFault")]
      KeyValueDataObjectList GetAcModelCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);
      #endregion

   }
}
