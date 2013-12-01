#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/21 12:27:06

// 文件名：ISnRegQuery
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.ServiceModel;
using UniCloud.DataObjects;
using UniCloud.Domain.Model;

namespace UniCloud.Query
{
    /// <summary>
    /// 表示用于SnReg的查询接口。
    /// </summary>
    [ServiceContract(Namespace = "http://www.UniCloud.com")]
    public interface ISnRegQuery
    {
        #region Query SnReg 模板生成接口

        /// <summary>
        /// 获取所有SnReg
        /// </summary>
        /// <returns>所有的SnReg。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetSnRegs", ReplyAction = "http://www.UniCloud.com/IPartService/GetSnRegsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/GetSnRegsDataFault")]
        SnRegDataObjectList GetSnRegs(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        /// <summary>
        /// 获取所有SnReg分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的SnReg分页信息。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetSnRegWithPagination", ReplyAction = "http://www.UniCloud.com/IPartService/GetSnRegWithPaginationResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetSnRegWithPaginationDataFault")]
        SnRegWithPagination GetSnRegWithPagination(Pagination pagination);

        /// <summary>
        /// 通过SnRegId获取相应的SnReg
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetSnRegByID", ReplyAction = "http://www.UniCloud.com/IPartService/GetSnRegByIDResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetSnRegByIDDataFault")]
        SnRegDataObject GetSnRegByID(int id);

        #endregion

        #region Query SnReg 自定义

        //返回值 用公共类、命名规则 前缀+模型名称+"s"
        /// <summary>
        /// 通过SnRegId获取相应的EgtMargin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetSnEgtMarginByID", ReplyAction = "http://www.UniCloud.com/IPartService/GetSnEgtMarginByIDResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetSnEgtMarginByIDDataFault")]
        EgtMarginDataObjectList GetSnEgtMarginByID(int id);

        /// <summary>
        /// 获取符合条件的SnReg
        /// </summary>
        /// <returns>获取符合条件的SnReg</returns>
        List<SnReg> GetSnRegsByCalculate(String[] cpns);
        /// <summary>
        /// 获取符合条件的SnReg
        /// </summary>
        /// <returns>获取符合条件的SnReg</returns>
        List<SnReg> GetSnRegsByOilAnalysis(string[] pnclass);

        /// <summary>
        /// 获取所有SnReg EGT分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的SnReg EGT分页信息。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetSnRegEgtWithPagination", ReplyAction = "http://www.UniCloud.com/IPartService/GetSnRegEgtWithPaginationResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetSnRegEgtWithPaginationDataFault")]
        SnRegWithPagination GetSnRegEgtWithPagination(Pagination pagination);

        /// <summary>
        /// 查询发动机详情
        /// <returns></returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/QueryEngineReportDetail", ReplyAction = "http://www.UniCloud.com/IPartService/QueryEngineReportDetailResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/QueryEngineReportDetailDataFault")]
        EngineReportDto QueryEngineReportDetail(int id);

        /// <summary>
        /// 查询发动机清单
        /// <returns></returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/QueryEngineReports", ReplyAction = "http://www.UniCloud.com/IPartService/QueryEngineReportsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/QueryEngineReportsDataFault")]
        EngineReportDtoWithPagination QueryEngineReports(Pagination pagination);

        #endregion
    }
}
