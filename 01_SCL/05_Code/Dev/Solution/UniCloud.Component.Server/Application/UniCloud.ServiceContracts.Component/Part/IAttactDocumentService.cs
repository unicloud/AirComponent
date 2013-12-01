#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/21 9:41:58

// 文件名：IAttactDocumentService
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
   /// 表示与AttactDocument相关的应用层服务契约。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IAttactDocumentService
   {
      /// <summary>
      /// 创建AttactDocument。
      /// </summary>
      /// <param name="attactDocuments">需要创建的AttactDocument。</param>
      /// <returns>创建的AttactDocument。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CreateAttactDocuments", ReplyAction ="http://www.UniCloud.com/IPartService/CreateAttactDocumentsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CreateAttactDocumentsDataFault")]
      [Caching(CachingMethod.Remove, "GetAttactDocuments")]
      AttactDocumentDataObjectList CreateAttactDocuments(AttactDocumentDataObjectList attactDocuments);
      
      /// <summary>
      /// 删除AttactDocument信息。
      /// </summary>
      /// <param name="attactDocumentIDs">需要更新的AttactDocument信息的ID值。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/DeleteAttactDocuments", ReplyAction ="http://www.UniCloud.com/IPartService/DeleteAttactDocumentsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/DeleteAttactDocumentsDataFault")]
      [Caching(CachingMethod.Remove, "GetAttactDocuments")]
      IDList DeleteAttactDocuments(IDList attactDocumentIDs);
      
      /// <summary>
      /// 更新AttactDocument信息。
      /// </summary>
      /// <param name="attactDocuments">需要更新的AttactDocument信息。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/UpdateAttactDocuments", ReplyAction ="http://www.UniCloud.com/IPartService/UpdateAttactDocumentsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/UpdateAttactDocumentsDataFault")]
      [Caching(CachingMethod.Remove, "GetAttactDocuments")]
      AttactDocumentDataObjectList UpdateAttactDocuments(AttactDocumentDataObjectList attactDocuments);
      
      /// <summary>
      /// 提交AttactDocument的增删改数据
      /// </summary>
      /// <param name="attactDocumentData"></param>
      /// <returns>提交成功的数据</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CommitAttactDocuments", ReplyAction ="http://www.UniCloud.com/IPartService/CommitAttactDocumentsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CommitAttactDocumentsDataFault")]
      [Caching(CachingMethod.Remove, "GetAttactDocuments")]
      AttactDocumentResultData CommitAttactDocuments(AttactDocumentResultData attactDocumentData);
      
   }
}
