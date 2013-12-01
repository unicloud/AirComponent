#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/18 11:52:26

// 文件名：IAdsbService
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
    /// 表示与Adsb相关的应用层服务契约。
    /// </summary>
    [ServiceContract(Namespace = "http://www.UniCloud.com")]
    public interface IAdsbService
    {
        /// <summary>
        /// 创建Adsb。
        /// </summary>
        /// <param name="adsbs">需要创建的Adsb。</param>
        /// <returns>创建的Adsb。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/CreateAdsbs", ReplyAction = "http://www.UniCloud.com/IPartService/CreateAdsbsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/CreateAdsbsDataFault")]
        [Caching(CachingMethod.Remove, "GetAdsbs")]
        AdsbDataObjectList CreateAdsbs(AdsbDataObjectList adsbs);

        /// <summary>
        /// 删除Adsb信息。
        /// </summary>
        /// <param name="adsbIDs">需要更新的Adsb信息的ID值。</param>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/DeleteAdsbs", ReplyAction = "http://www.UniCloud.com/IPartService/DeleteAdsbsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/DeleteAdsbsDataFault")]
        [Caching(CachingMethod.Remove, "GetAdsbs")]
        IDList DeleteAdsbs(IDList adsbIDs);

        /// <summary>
        /// 更新Adsb信息。
        /// </summary>
        /// <param name="adsbs">需要更新的Adsb信息。</param>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/UpdateAdsbs", ReplyAction = "http://www.UniCloud.com/IPartService/UpdateAdsbsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/UpdateAdsbsDataFault")]
        [Caching(CachingMethod.Remove, "GetAdsbs")]
        AdsbDataObjectList UpdateAdsbs(AdsbDataObjectList adsbs);

        /// <summary>
        /// 提交Adsb的增删改数据
        /// </summary>
        /// <param name="adsbData"></param>
        /// <returns>提交成功的数据</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/CommitAdsbs", ReplyAction = "http://www.UniCloud.com/IPartService/CommitAdsbsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/CommitAdsbsDataFault")]
        [Caching(CachingMethod.Remove, "GetAdsbs")]
        AdsbResultData CommitAdsbs(AdsbResultData adsbData);
    }
}
