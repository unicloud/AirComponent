#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/30 10:17:20

// 文件名：ILicenseTypeQuery
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
   /// 表示用于LicenseType的查询接口。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface ILicenseTypeQuery
   {
      #region Get LicenseType
      
      /// <summary>
      /// 获取所有LicenseType
      /// </summary>
      /// <returns>所有的LicenseType。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetLicenseTypes", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetLicenseTypesResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IAircraftService/GetLicenseTypesDataFault")]
      LicenseTypeDataObjectList GetLicenseTypes(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter);
      
      /// <summary>
      /// 获取所有LicenseType分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的LicenseType分页信息。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetLicenseTypeWithPagination", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetLicenseTypeWithPaginationResponse")]
      [FaultContract(typeof(FaultData), Name ="FaultData", Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action="http://www.UniCloud.com/IAircraftService/GetLicenseTypeWithPaginationDataFault")]
      LicenseTypeWithPagination GetLicenseTypeWithPagination(Pagination pagination);
      
      /// <summary>
      /// 通过LicenseTypeId获取相应的LicenseType
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetLicenseTypeByID", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetLicenseTypeByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IAircraftService/GetLicenseTypeByIDDataFault")]
      LicenseTypeDataObject GetLicenseTypeByID(int id);
      #endregion

      #region LicenseTypeDorpDownSource
      
      /// <summary>
      /// 获取LicenseType下拉数据集合
      /// </summary>
      /// <param name="colFilter"></param>
      /// <param name="sortFilter"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetLicenseTypeCol", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetLicenseTypeColResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IAircraftService/GetLicenseTypeColDataFault")]
      KeyValueDataObjectList GetLicenseTypeCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);
      #endregion

   }
}
