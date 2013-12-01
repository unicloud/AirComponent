#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/18 11:52:26

// 文件名：IAdsbQuery
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
    /// 表示用于Adsb的查询接口。
    /// </summary>
    [ServiceContract(Namespace = "http://www.UniCloud.com")]
    public interface IAdsbQuery
    {
        #region Query Adsb

        /// <summary>
        /// 获取所有Adsb
        /// </summary>
        /// <returns>所有的Adsb。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetAdsbs", ReplyAction = "http://www.UniCloud.com/IPartService/GetAdsbsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/GetAdsbsDataFault")]
        AdsbDataObjectList GetAdsbs(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        /// <summary>
        /// 获取所有Adsb分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的Adsb分页信息。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetAdsbWithPagination", ReplyAction = "http://www.UniCloud.com/IPartService/GetAdsbWithPaginationResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetAdsbWithPaginationDataFault")]
        AdsbWithPagination GetAdsbWithPagination(Pagination pagination);

        /// <summary>
        /// 通过AdsbId获取相应的Adsb
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetAdsbByID", ReplyAction = "http://www.UniCloud.com/IPartService/GetAdsbByIDResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetAdsbByIDDataFault")]
        AdsbDataObject GetAdsbByID(int id);
        #endregion
    }
}
