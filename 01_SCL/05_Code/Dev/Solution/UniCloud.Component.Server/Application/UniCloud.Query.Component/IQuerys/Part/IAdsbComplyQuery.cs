#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/18 11:52:26

// 文件名：IAdsbComplyQuery
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
    /// 表示用于AdsbComply的查询接口。
    /// </summary>
    [ServiceContract(Namespace = "http://www.UniCloud.com")]
    public interface IAdsbComplyQuery
    {
        #region Query AdsbComply

        /// <summary>
        /// 获取所有AdsbComply
        /// </summary>
        /// <returns>所有的AdsbComply。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetAdsbComplys", ReplyAction = "http://www.UniCloud.com/IPartService/GetAdsbComplysResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/GetAdsbComplysDataFault")]
        AdsbComplyDataObjectList GetAdsbComplys(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        /// <summary>
        /// 获取所有AdsbComply分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的AdsbComply分页信息。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetAdsbComplyWithPagination", ReplyAction = "http://www.UniCloud.com/IPartService/GetAdsbComplyWithPaginationResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetAdsbComplyWithPaginationDataFault")]
        AdsbComplyWithPagination GetAdsbComplyWithPagination(bool? isAD,Pagination pagination);

        /// <summary>
        /// 通过AdsbComplyId获取相应的AdsbComply
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetAdsbComplyByID", ReplyAction = "http://www.UniCloud.com/IPartService/GetAdsbComplyByIDResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetAdsbComplyByIDDataFault")]
        AdsbComplyDataObject GetAdsbComplyByID(int id);
        #endregion
    }
}
