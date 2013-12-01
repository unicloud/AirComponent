#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/18 11:52:26

// 文件名：IAdsbComplyService
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
    /// 表示与AdsbComply相关的应用层服务契约。
    /// </summary>
    [ServiceContract(Namespace = "http://www.UniCloud.com")]
    public interface IAdsbComplyService
    {
        /// <summary>
        /// 创建AdsbComply。
        /// </summary>
        /// <param name="adsbComplys">需要创建的AdsbComply。</param>
        /// <returns>创建的AdsbComply。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/CreateAdsbComplys", ReplyAction = "http://www.UniCloud.com/IPartService/CreateAdsbComplysResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/CreateAdsbComplysDataFault")]
        [Caching(CachingMethod.Remove, "GetAdsbComplys")]
        AdsbComplyDataObjectList CreateAdsbComplys(AdsbComplyDataObjectList adsbComplys);

        /// <summary>
        /// 删除AdsbComply信息。
        /// </summary>
        /// <param name="adsbComplyIDs">需要更新的AdsbComply信息的ID值。</param>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/DeleteAdsbComplys", ReplyAction = "http://www.UniCloud.com/IPartService/DeleteAdsbComplysResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/DeleteAdsbComplysDataFault")]
        [Caching(CachingMethod.Remove, "GetAdsbComplys")]
        IDList DeleteAdsbComplys(IDList adsbComplyIDs);

        /// <summary>
        /// 更新AdsbComply信息。
        /// </summary>
        /// <param name="adsbComplys">需要更新的AdsbComply信息。</param>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/UpdateAdsbComplys", ReplyAction = "http://www.UniCloud.com/IPartService/UpdateAdsbComplysResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/UpdateAdsbComplysDataFault")]
        [Caching(CachingMethod.Remove, "GetAdsbComplys")]
        AdsbComplyDataObjectList UpdateAdsbComplys(AdsbComplyDataObjectList adsbComplys);

        /// <summary>
        /// 提交AdsbComply的增删改数据
        /// </summary>
        /// <param name="adsbComplyData"></param>
        /// <returns>提交成功的数据</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/CommitAdsbComplys", ReplyAction = "http://www.UniCloud.com/IPartService/CommitAdsbComplysResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/CommitAdsbComplysDataFault")]
        [Caching(CachingMethod.Remove, "GetAdsbComplys")]
        AdsbComplyResultData CommitAdsbComplys(AdsbComplyResultData adsbComplyData);
    }
}
