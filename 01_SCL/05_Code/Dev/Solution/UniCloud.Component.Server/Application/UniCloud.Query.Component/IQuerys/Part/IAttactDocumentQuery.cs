#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/21 9:41:58

// 文件名：IAttactDocumentQuery
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
    /// 表示用于AttactDocument的查询接口。
    /// </summary>
    [ServiceContract(Namespace = "http://www.UniCloud.com")]
    public interface IAttactDocumentQuery
    {
        #region Query AttactDocument

        /// <summary>
        /// 获取所有AttactDocument
        /// </summary>
        /// <returns>所有的AttactDocument。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetAttactDocuments", ReplyAction = "http://www.UniCloud.com/IPartService/GetAttactDocumentsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/GetAttactDocumentsDataFault")]
        AttactDocumentDataObjectList GetAttactDocuments(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        /// <summary>
        /// 获取所有AttactDocument分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的AttactDocument分页信息。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetAttactDocumentWithPagination", ReplyAction = "http://www.UniCloud.com/IPartService/GetAttactDocumentWithPaginationResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetAttactDocumentWithPaginationDataFault")]
        AttactDocumentWithPagination GetAttactDocumentWithPagination(Pagination pagination);

        /// <summary>
        /// 通过AttactDocumentId获取相应的AttactDocument
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetAttactDocumentByID", ReplyAction = "http://www.UniCloud.com/IPartService/GetAttactDocumentByIDResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IPartService/GetAttactDocumentByIDDataFault")]
        AttactDocumentDataObject GetAttactDocumentByID(int id);

        /// <summary>
        /// 获取与某业务相当的AttactDocument
        /// </summary>
        /// <returns>所有的AttactDocument。</returns>
        [OperationContract(Action = "http://www.UniCloud.com/IPartService/GetBusinessAttactDocuments", ReplyAction = "http://www.UniCloud.com/IPartService/GetBusinessAttactDocumentsResponse")]
        [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/GetBusinessAttactDocumentsDataFault")]
        AttactDocumentDataObjectList GetBusinessAttactDocuments(int businessId, string business);
        #endregion
    }
}
