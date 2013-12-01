#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/21 12:27:06

// 文件名：IScnMainQuery
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.ServiceModel;
using UniCloud.DataObjects;

namespace UniCloud.Query
{
    /// <summary>
    /// 表示用于ScnMain的查询接口。
    /// </summary>
    [ServiceContract(Namespace = "http://www.UniCloud.com")]
    public interface IScnMainQuery
    {
        #region Query ScnMain

        /// <summary>
        /// 获取所有ScnMain
        /// </summary>
        /// <returns>所有的ScnMain。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetScnMains", ReplyAction = "http://www.UniCloud.com/IPartService/GetScnMainsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/GetScnMainsDataFault")]
        ScnMainDataObjectList GetScnMains(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        /// <summary>
        /// 获取所有ScnMain分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的ScnMain分页信息。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetScnMainWithPagination", ReplyAction = "http://www.UniCloud.com/IPartService/GetScnMainWithPaginationResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetScnMainWithPaginationDataFault")]
        ScnMainWithPagination GetScnMainWithPagination(Pagination pagination, string organization);

        /// <summary>
        /// 通过ScnMainId获取相应的ScnMain
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetScnMainByID", ReplyAction = "http://www.UniCloud.com/IPartService/GetScnMainByIDResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetScnMainByIDDataFault")]
        ScnMainDataObject GetScnMainByID(int id);


        /// <summary>
        /// 比较两架飞机之间SCN的异同
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/CompareAcOrders", ReplyAction = "http://www.UniCloud.com/IPartService/CompareAcOrdersResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/CompareAcOrdersDataFault")]
        CompareAcOrderDtoWithPagination CompareAcOrders(string msn1, string msn2, Pagination pagination);

        /// <summary>
        /// 查询合同飞机MSN
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetAcOrderMsns", ReplyAction = "http://www.UniCloud.com/IPartService/GetAcOrderMsnsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetAcOrderMsnsDataFault")]
        KeyValueDataObjectList GetAcOrderMsns();

        #endregion
    }
}
