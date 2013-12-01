#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/6 21:54:49

// 文件名：ICcOrderService
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
    /// 表示与CcOrder相关的应用层服务契约。
    /// </summary>
    [ServiceContract(Namespace = "http://www.UniCloud.com")]
    public interface ICcOrderService
    {
        /// <summary>
        /// 创建CcOrder。
        /// </summary>
        /// <param name="ccOrders">需要创建的CcOrder。</param>
        /// <returns>创建的CcOrder。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/CreateCcOrders", ReplyAction = "http://www.UniCloud.com/IPartService/CreateCcOrdersResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/CreateCcOrdersDataFault")]
        [Caching(CachingMethod.Remove, "GetCcOrders")]
        CcOrderDataObjectList CreateCcOrders(CcOrderDataObjectList ccOrders);

        /// <summary>
        /// 删除CcOrder信息。
        /// </summary>
        /// <param name="ccOrderIDs">需要更新的CcOrder信息的ID值。</param>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/DeleteCcOrders", ReplyAction = "http://www.UniCloud.com/IPartService/DeleteCcOrdersResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/DeleteCcOrdersDataFault")]
        [Caching(CachingMethod.Remove, "GetCcOrders")]
        IDList DeleteCcOrders(IDList ccOrderIDs);

        /// <summary>
        /// 更新CcOrder信息。
        /// </summary>
        /// <param name="ccOrders">需要更新的CcOrder信息。</param>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/UpdateCcOrders", ReplyAction = "http://www.UniCloud.com/IPartService/UpdateCcOrdersResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/UpdateCcOrdersDataFault")]
        [Caching(CachingMethod.Remove, "GetCcOrders")]
        CcOrderDataObjectList UpdateCcOrders(CcOrderDataObjectList ccOrders);

        /// <summary>
        /// 提交CcOrder的增删改数据
        /// </summary>
        /// <param name="ccOrderData"></param>
        /// <returns>提交成功的数据</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/CommitCcOrders", ReplyAction = "http://www.UniCloud.com/IPartService/CommitCcOrdersResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/CommitCcOrdersDataFault")]
        [Caching(CachingMethod.Remove, "GetCcOrders")]
        CcOrderResultData CommitCcOrders(CcOrderResultData ccOrderData);

        /// <summary>
        /// 通过CcOrderId获取相应的CcOrder 带导航属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetFullCcOrderByID", ReplyAction = "http://www.UniCloud.com/IPartService/GetFullCcOrderByIDResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetFullCcOrderByIDDataFault")]
        CcOrderDataObject GetFullCcOrderByID(int id);

        /// <summary>
        /// 获取所有CcOrder 带导航属性
        /// </summary>
        /// <returns>所有的CcOrder。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetFullCcOrders", ReplyAction = "http://www.UniCloud.com/IPartService/GetFullCcOrdersResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/GetFullCcOrdersDataFault")]
        CcOrderDataObjectList GetFullCcOrders();

        /// <summary>
        /// 审核拆装记录
        /// </summary>
        /// <param name="ccOrderId"></param>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/VerifyCcOrder", ReplyAction = "http://www.UniCloud.com/IPartService/VerifyCcOrderResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/VerifyCcOrderDataFault")]
        bool VerifyCcOrder(int ccOrderId);

        /// <summary>
        /// 审核发动机拆装记录
        /// </summary>
        /// <param name="ccOrderId"></param>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/VerifyEngCcOrder", ReplyAction = "http://www.UniCloud.com/IPartService/VerifyEngCcOrderResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/VerifyEngCcOrderDataFault")]
        bool VerifyEngCcOrder(int ccOrderId);
    }
}
