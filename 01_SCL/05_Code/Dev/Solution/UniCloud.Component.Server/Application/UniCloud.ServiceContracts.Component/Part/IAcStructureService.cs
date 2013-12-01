#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/19 15:38:44

// 文件名：IAcStructureService
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
using UniCloud.Query;

namespace UniCloud.ServiceContracts
{
    /// <summary>
    /// 表示与AcStructure相关的应用层服务契约。
    /// </summary>
    [ServiceContract(Namespace = "http://www.UniCloud.com")]
    public interface IAcStructureService
    {
        /// <summary>
        /// 创建AcStructure。
        /// </summary>
        /// <param name="acStructures">需要创建的AcStructure。</param>
        /// <returns>创建的AcStructure。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/CreateAcStructures", ReplyAction = "http://www.UniCloud.com/IPartService/CreateAcStructuresResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/CreateAcStructuresDataFault")]
        [Caching(CachingMethod.Remove, "GetAcStructures")]
        AcStructureDataObjectList CreateAcStructures(AcStructureDataObjectList acStructures);

        /// <summary>
        /// 删除AcStructure信息。
        /// </summary>
        /// <param name="acStructureIDs">需要更新的AcStructure信息的ID值。</param>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/DeleteAcStructures", ReplyAction = "http://www.UniCloud.com/IPartService/DeleteAcStructuresResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/DeleteAcStructuresDataFault")]
        [Caching(CachingMethod.Remove, "GetAcStructures")]
        IDList DeleteAcStructures(IDList acStructureIDs);

        /// <summary>
        /// 更新AcStructure信息。
        /// </summary>
        /// <param name="acStructures">需要更新的AcStructure信息。</param>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/UpdateAcStructures", ReplyAction = "http://www.UniCloud.com/IPartService/UpdateAcStructuresResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/UpdateAcStructuresDataFault")]
        [Caching(CachingMethod.Remove, "GetAcStructures")]
        AcStructureDataObjectList UpdateAcStructures(AcStructureDataObjectList acStructures);

        /// <summary>
        /// 提交AcStructure的增删改数据
        /// </summary>
        /// <param name="acStructureData"></param>
        /// <returns>提交成功的数据</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/CommitAcStructures", ReplyAction = "http://www.UniCloud.com/IPartService/CommitAcStructuresResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/CommitAcStructuresDataFault")]
        [Caching(CachingMethod.Remove, "GetAcStructures")]
        AcStructureResultData CommitAcStructures(AcStructureResultData acStructureData);
    }
}
