#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/30 10:17:20

// 文件名：IAcTypeService
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
    /// 表示与AcType相关的应用层服务契约。
    /// </summary>
    [ServiceContract(Namespace = "http://www.UniCloud.com")]
    public interface IAcTypeService
    {
        /// <summary>
        /// 创建AcType。
        /// </summary>
        /// <param name="acTypes">需要创建的AcType。</param>
        /// <returns>创建的AcType。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/CreateAcTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/CreateAcTypesResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IAircraftService/CreateAcTypesDataFault")]
        [Caching(CachingMethod.Remove, "GetAcTypes")]
        AcTypeDataObjectList CreateAcTypes(AcTypeDataObjectList acTypes);

        /// <summary>
        /// 删除AcType信息。
        /// </summary>
        /// <param name="acTypeIDs">需要更新的AcType信息的ID值。</param>
        [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/DeleteAcTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/DeleteAcTypesResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IAircraftService/DeleteAcTypesDataFault")]
        [Caching(CachingMethod.Remove, "GetAcTypes")]
        bool DeleteAcTypes(IDList acTypeIDs);

        /// <summary>
        /// 更新AcType信息。
        /// </summary>
        /// <param name="acTypes">需要更新的AcType信息。</param>
        [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/UpdateAcTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/UpdateAcTypesResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IAircraftService/UpdateAcTypesDataFault")]
        [Caching(CachingMethod.Remove, "GetAcTypes")]
        AcTypeDataObjectList UpdateAcTypes(AcTypeDataObjectList acTypes);

        /// <summary>
        /// 提交AcType的增删改数据
        /// </summary>
        /// <param name="acTypeData"></param>
        /// <returns>提交成功的数据</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/CommitAcTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/CommitAcTypesResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IAircraftService/CommitAcTypesDataFault")]
        [Caching(CachingMethod.Remove, "GetAcTypes")]
        AcTypeResultData CommitAcTypes(AcTypeResultData acTypeData);

        /// <summary>
        /// 通过AcTypeId获取相应的AcType 带导航属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/GetFullAcTypeByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAcTypeByIDResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IAircraftService/GetFullAcTypeByIDDataFault")]
        AcTypeDataObject GetFullAcTypeByID(int id);

        /// <summary>
        /// 通过AcTypeId获取相应的AcType 带导航属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/GetFullAcTypeByGuid", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAcTypeByGuidResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IAircraftService/GetFullAcTypeByGuidDataFault")]
        AcTypeDataObject GetFullAcTypeByGuid(string id);

        /// <summary>
        /// 获取所有AcType 带导航属性
        /// </summary>
        /// <returns>所有的AcType。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/GetFullAcTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAcTypesResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IAircraftService/GetFullAcTypesDataFault")]
        AcTypeDataObjectList GetFullAcTypes();

        /// <summary>
        /// 维护ATA与Actype之间的关系
        /// </summary>
        /// <param name="actypes"></param>
        /// <returns></returns>
        [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/ManageAcTypeAta", ReplyAction = "http://www.UniCloud.com/IAircraftService/ManageAcTypeAtaResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IAircraftService/ManageAcTypeAtaDataFault")]
        AcTypeDataObjectList ManageAcTypeAta(AcTypeDataObjectList actypes);

        /// <summary>
        /// 创建acModels。
        /// </summary>
        /// <param name="acTypes">需要创建的acModels。</param>
        /// <returns>创建的acModels。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/CreateAcModels", ReplyAction = "http://www.UniCloud.com/IAircraftService/CreateAcModelsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IAircraftService/CreateAcModelsDataFault")]
        [Caching(CachingMethod.Remove, "GetAcTypes")]
        AcModelDataObjectList CreateAcModels(int acTypeId, AcModelDataObjectList acModels);

        /// <summary>
        /// 更新acModels。
        /// </summary>
        /// <param name="acTypes">需要更新的acModels。</param>
        /// <returns>更新的acModels。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/UpdateAcModels", ReplyAction = "http://www.UniCloud.com/IAircraftService/UpdateAcModelsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IAircraftService/UpdateAcModelsDataFault")]
        [Caching(CachingMethod.Remove, "GetAcTypes")]
        AcModelDataObjectList UpdateAcModels(int acTypeId, AcModelDataObjectList acModels);

        /// <summary>
        /// 创建acConfigs。
        /// </summary>
        /// <param name="acTypes">需要创建的acConfigs。</param>
        /// <returns>创建的acConfigs。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/CreateAcConfigs", ReplyAction = "http://www.UniCloud.com/IAircraftService/CreateAcConfigsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IAircraftService/CreateAcConfigsDataFault")]
        [Caching(CachingMethod.Remove, "GetAcTypes")]
        AcConfigDataObjectList CreateAcConfigs(int acTypeId, int acModelId, AcConfigDataObjectList acConfigs);

        /// <summary>
        /// 更新acConfigs。
        /// </summary>
        /// <param name="acTypes">需要更新的acConfigs。</param>
        /// <returns>更新的acConfigs。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/UpdateAcConfigs", ReplyAction = "http://www.UniCloud.com/IAircraftService/UpdateAcConfigsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IAircraftService/UpdateAcConfigsDataFault")]
        [Caching(CachingMethod.Remove, "GetAcTypes")]
        AcConfigDataObjectList UpdateAcConfigs(int acTypeId, int acModelId, AcConfigDataObjectList acConfigs);


        /// <summary>
        /// 删除AcModel信息。
        /// </summary>
        /// <param name="acModels">需要更新的AcModel信息的ID值。</param>
        [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/DeleteAcModels", ReplyAction = "http://www.UniCloud.com/IAircraftService/DeleteAcModelsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IAircraftService/DeleteAcModelsDataFault")]
        [Caching(CachingMethod.Remove, "GetAcTypes")]
        bool DeleteAcModels(int acTypeId, AcModelDataObjectList acModels);

        /// <summary>
        /// 删除AcConfig信息。
        /// </summary>
        /// <param name="acConfigs">需要更新的AcConfig信息的ID值。</param>
        [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/DeleteAcConfigs", ReplyAction = "http://www.UniCloud.com/IAircraftService/DeleteAcConfigsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IAircraftService/DeleteAcConfigsDataFault")]
        [Caching(CachingMethod.Remove, "GetAcTypes")]
        bool DeleteAcConfigs(int acTypeId,int acModelId, AcConfigDataObjectList acConfigs);
    }
}
