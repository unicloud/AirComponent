#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/13 10:03:06

// 文件名：IAirBusMSCNQuery
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
    /// 表示用于AirBusMSCN的查询接口。
    /// </summary>
    [ServiceContract(Namespace = "http://www.UniCloud.com")]
    public interface IAirBusMSCNQuery
    {
        #region Query AirBusMSCN

        /// <summary>
        /// 获取所有AirBusMSCN
        /// </summary>
        /// <returns>所有的AirBusMSCN。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetAirBusMSCNs", ReplyAction = "http://www.UniCloud.com/IPartService/GetAirBusMSCNsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/GetAirBusMSCNsDataFault")]
        AirBusMSCNDataObjectList GetAirBusMSCNs(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        /// <summary>
        /// 获取所有AirBusMSCN分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的AirBusMSCN分页信息。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetAirBusMSCNWithPagination", ReplyAction = "http://www.UniCloud.com/IPartService/GetAirBusMSCNWithPaginationResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetAirBusMSCNWithPaginationDataFault")]
        AirBusMSCNWithPagination GetAirBusMSCNWithPagination(Pagination pagination);

        /// <summary>
        /// 通过AirBusMSCNId获取相应的AirBusMSCN
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetAirBusMSCNByID", ReplyAction = "http://www.UniCloud.com/IPartService/GetAirBusMSCNByIDResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetAirBusMSCNByIDDataFault")]
        AirBusMSCNDataObject GetAirBusMSCNByID(int id);

        /// <summary>
        /// 对比空客MSCN
        /// </summary>
        /// <param name="fleet">飞机批次</param>
        /// <param name="importType">导入方式</param>
        /// <param name="airBus"></param>
        /// <returns></returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/CompareMscn", ReplyAction = "http://www.UniCloud.com/IPartService/CompareMscnResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/CompareMscnDataFault")]
        CompareMscnDtoList CompareMscn(string fleet, string importType, AirBusMSCNDataObjectList airBus);

        #endregion
    }
}
