#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/16 10:49:57

// 文件名：IEgtMarginQuery
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.ServiceModel;
using UniCloud.DataObjects;
using UniCloud.Domain.Model;

namespace UniCloud.Query
{
    /// <summary>
    /// 表示用于EgtMargin的查询接口。
    /// </summary>
    [ServiceContract(Namespace = "http://www.UniCloud.com")]
    public interface IEgtMarginQuery
    {
        #region Query EgtMargin

        /// <summary>
        /// 获取所有EgtMargin
        /// </summary>
        /// <returns>所有的EgtMargin。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetEgtMargins", ReplyAction = "http://www.UniCloud.com/IPartService/GetEgtMarginsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/GetEgtMarginsDataFault")]
        EgtMarginDataObjectList GetEgtMargins(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        /// <summary>
        /// 获取所有EgtMargin分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的EgtMargin分页信息。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetEgtMarginWithPagination", ReplyAction = "http://www.UniCloud.com/IPartService/GetEgtMarginWithPaginationResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetEgtMarginWithPaginationDataFault")]
        EgtMarginWithPagination GetEgtMarginWithPagination(Pagination pagination);

        /// <summary>
        /// 通过EgtMarginId获取相应的EgtMargin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetEgtMarginByID", ReplyAction = "http://www.UniCloud.com/IPartService/GetEgtMarginByIDResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetEgtMarginByIDDataFault")]
        EgtMarginDataObject GetEgtMarginByID(int id);

        SnReg GetSnRegBySn(string sn);

        /// <summary>
        /// 提交EgtMargin的增删改数据
        /// </summary>
        /// <param name="snregs"></param>
        /// <returns>提交成功的数据</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/SaveSnregEgts", ReplyAction = "http://www.UniCloud.com/IPartService/SaveSnregEgtsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/SaveSnregEgtsDataFault")]
        bool SaveSnregEgts(SnRegDataObjectList snregs);

        /// <summary>
        /// 保存导入的EGT文件
        /// </summary>
        /// <param name="snregs"></param>
        /// <returns></returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/SaveImportEgts", ReplyAction = "http://www.UniCloud.com/IPartService/SaveImportEgtsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/SaveImportEgtsDataFault")]
        bool SaveImportEgts(SnRegDataObjectList snregs);

        #endregion
    }
}
