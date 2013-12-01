#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/30 10:17:20

// 文件名：ILicenseTypeService
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.ServiceModel;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;
using UniCloud.Infrastructure.Caching;
using UniCloud.Query.AcConfiguration;

namespace UniCloud.ServiceContracts
{
   /// <summary>
   /// 表示与LicenseType相关的应用层服务契约。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface ILicenseTypeService
   {
      /// <summary>
      /// 创建LicenseType。
      /// </summary>
      /// <param name="licenseTypes">需要创建的LicenseType。</param>
      /// <returns>创建的LicenseType。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/CreateLicenseTypes", ReplyAction ="http://www.UniCloud.com/IAircraftService/CreateLicenseTypesResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IAircraftService/CreateLicenseTypesDataFault")]
      [Caching(CachingMethod.Remove, "GetLicenseTypes")]
      LicenseTypeDataObjectList CreateLicenseTypes(LicenseTypeDataObjectList licenseTypes);
      
      /// <summary>
      /// 删除LicenseType信息。
      /// </summary>
      /// <param name="licenseTypeIDs">需要更新的LicenseType信息的ID值。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/DeleteLicenseTypes", ReplyAction ="http://www.UniCloud.com/IAircraftService/DeleteLicenseTypesResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IAircraftService/DeleteLicenseTypesDataFault")]
      [Caching(CachingMethod.Remove, "GetLicenseTypes")]
      IDList DeleteLicenseTypes(IDList licenseTypeIDs);
      
      /// <summary>
      /// 更新LicenseType信息。
      /// </summary>
      /// <param name="licenseTypes">需要更新的LicenseType信息。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/UpdateLicenseTypes", ReplyAction ="http://www.UniCloud.com/IAircraftService/UpdateLicenseTypesResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IAircraftService/UpdateLicenseTypesDataFault")]
      [Caching(CachingMethod.Remove, "GetLicenseTypes")]
      LicenseTypeDataObjectList UpdateLicenseTypes(LicenseTypeDataObjectList licenseTypes);
      
      /// <summary>
      /// 提交LicenseType的增删改数据
      /// </summary>
      /// <param name="licenseTypeData"></param>
      /// <returns>提交成功的数据</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/CommitLicenseTypes", ReplyAction ="http://www.UniCloud.com/IAircraftService/CommitLicenseTypesResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IAircraftService/CommitLicenseTypesDataFault")]
      [Caching(CachingMethod.Remove, "GetLicenseTypes")]
      LicenseTypeResultData CommitLicenseTypes(LicenseTypeResultData licenseTypeData);
      
      /// <summary>
      /// 通过LicenseTypeId获取相应的LicenseType 带导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetFullLicenseTypeByID", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetFullLicenseTypeByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IAircraftService/GetFullLicenseTypeByIDDataFault")]
      LicenseTypeDataObject GetFullLicenseTypeByID(int id);
      
      /// <summary>
      /// 获取所有LicenseType 带导航属性
      /// </summary>
      /// <returns>所有的LicenseType。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetFullLicenseTypes", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetFullLicenseTypesResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IAircraftService/GetFullLicenseTypesDataFault")]
      LicenseTypeDataObjectList GetFullLicenseTypes();
   }
}
