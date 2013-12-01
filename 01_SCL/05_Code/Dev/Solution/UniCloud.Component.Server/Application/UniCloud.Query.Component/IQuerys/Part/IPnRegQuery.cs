#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/21 12:27:06

// 文件名：IPnRegQuery
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
    /// 表示用于PnReg的查询接口。
    /// </summary>
    [ServiceContract(Namespace = "http://www.UniCloud.com")]
    public interface IPnRegQuery
    {
        #region Query PnReg

        /// <summary>
        /// 获取所有PnReg
        /// </summary>
        /// <returns>所有的PnReg。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetPnRegs", ReplyAction = "http://www.UniCloud.com/IPartService/GetPnRegsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/GetPnRegsDataFault")]
        PnRegDataObjectList GetPnRegs(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        /// <summary>
        /// 获取所有PnReg分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的PnReg分页信息。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetPnRegWithPagination", ReplyAction = "http://www.UniCloud.com/IPartService/GetPnRegWithPaginationResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetPnRegWithPaginationDataFault")]
        PnRegWithPagination GetPnRegWithPagination(Pagination pagination,bool isEngPart);

        /// <summary>
        /// 通过PnRegId获取相应的PnReg
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetPnRegByID", ReplyAction = "http://www.UniCloud.com/IPartService/GetPnRegByIDResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetPnRegByIDDataFault")]
        PnRegDataObject GetPnRegByID(int id);

        /// <summary>
        /// 通过PnRegId获取相应的PnReg
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetPnRegByPn", ReplyAction = "http://www.UniCloud.com/IPartService/GetPnRegByPnResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetPnRegByPnDataFault")]
        PnRegDataObject GetPnRegByPn(string pn);

        /// <summary>
        /// 查询以某字符开头的10个PN名值对
        /// </summary>
        /// <param name="pn"></param>
        /// <returns></returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/QueryPnregCol", ReplyAction = "http://www.UniCloud.com/IPartService/QueryPnregColResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/QueryPnregColDataFault")]
        KeyValueDataObjectList QueryPnregCol(string pn);


        /// <summary>
        /// 获取发动机与滑油
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的PnReg分页信息。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetEngPnOilWithPagination", ReplyAction = "http://www.UniCloud.com/IPartService/GetEngPnOilWithPaginationResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetEngPnOilWithPaginationDataFault")]
        PnRegWithPagination GetEngPnOilWithPagination(Pagination pagination);
        #endregion
    }
}
