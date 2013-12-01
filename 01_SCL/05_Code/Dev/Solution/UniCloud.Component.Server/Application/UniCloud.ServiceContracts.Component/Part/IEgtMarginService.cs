#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/16 10:49:57

// 文件名：IEgtMarginService
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

namespace UniCloud.ServiceContracts
{
    /// <summary>
    /// 表示与EgtMargin相关的应用层服务契约。
    /// </summary>
    [ServiceContract(Namespace = "http://www.UniCloud.com")]
    public interface IEgtMarginService
    {
        /// <summary>
        /// 创建EgtMargin。
        /// </summary>
        /// <param name="egtMargins">需要创建的EgtMargin。</param>
        /// <returns>创建的EgtMargin。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/CreateEgtMargins", ReplyAction = "http://www.UniCloud.com/IPartService/CreateEgtMarginsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/CreateEgtMarginsDataFault")]
        [Caching(CachingMethod.Remove, "GetEgtMargins")]
        EgtMarginDataObjectList CreateEgtMargins(EgtMarginDataObjectList egtMargins);

        /// <summary>
        /// 删除EgtMargin信息。
        /// </summary>
        /// <param name="egtMarginIDs">需要更新的EgtMargin信息的ID值。</param>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/DeleteEgtMargins", ReplyAction = "http://www.UniCloud.com/IPartService/DeleteEgtMarginsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/DeleteEgtMarginsDataFault")]
        [Caching(CachingMethod.Remove, "GetEgtMargins")]
        IDList DeleteEgtMargins(IDList egtMarginIDs);

        /// <summary>
        /// 更新EgtMargin信息。
        /// </summary>
        /// <param name="egtMargins">需要更新的EgtMargin信息。</param>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/UpdateEgtMargins", ReplyAction = "http://www.UniCloud.com/IPartService/UpdateEgtMarginsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/UpdateEgtMarginsDataFault")]
        [Caching(CachingMethod.Remove, "GetEgtMargins")]
        EgtMarginDataObjectList UpdateEgtMargins(EgtMarginDataObjectList egtMargins);

        /// <summary>
        /// 提交EgtMargin的增删改数据
        /// </summary>
        /// <param name="egtMarginData"></param>
        /// <returns>提交成功的数据</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/CommitEgtMargins", ReplyAction = "http://www.UniCloud.com/IPartService/CommitEgtMarginsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/CommitEgtMarginsDataFault")]
        [Caching(CachingMethod.Remove, "GetEgtMargins")]
        EgtMarginResultData CommitEgtMargins(EgtMarginResultData egtMarginData);
    }
}
