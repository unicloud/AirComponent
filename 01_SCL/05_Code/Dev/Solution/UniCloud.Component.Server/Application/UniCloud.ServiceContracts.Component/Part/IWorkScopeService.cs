#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/6 21:54:49

// 文件名：IWorkScopeService
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
   /// 表示与WorkScope相关的应用层服务契约。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IWorkScopeService
   {
      /// <summary>
      /// 创建WorkScope。
      /// </summary>
      /// <param name="workScopes">需要创建的WorkScope。</param>
      /// <returns>创建的WorkScope。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CreateWorkScopes", ReplyAction ="http://www.UniCloud.com/IPartService/CreateWorkScopesResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CreateWorkScopesDataFault")]
      [Caching(CachingMethod.Remove, "GetWorkScopes")]
      WorkScopeDataObjectList CreateWorkScopes(WorkScopeDataObjectList workScopes);
      
      /// <summary>
      /// 删除WorkScope信息。
      /// </summary>
      /// <param name="workScopeIDs">需要更新的WorkScope信息的ID值。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/DeleteWorkScopes", ReplyAction ="http://www.UniCloud.com/IPartService/DeleteWorkScopesResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/DeleteWorkScopesDataFault")]
      [Caching(CachingMethod.Remove, "GetWorkScopes")]
      IDList DeleteWorkScopes(IDList workScopeIDs);
      
      /// <summary>
      /// 更新WorkScope信息。
      /// </summary>
      /// <param name="workScopes">需要更新的WorkScope信息。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/UpdateWorkScopes", ReplyAction ="http://www.UniCloud.com/IPartService/UpdateWorkScopesResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/UpdateWorkScopesDataFault")]
      [Caching(CachingMethod.Remove, "GetWorkScopes")]
      WorkScopeDataObjectList UpdateWorkScopes(WorkScopeDataObjectList workScopes);
      
      /// <summary>
      /// 提交WorkScope的增删改数据
      /// </summary>
      /// <param name="workScopeData"></param>
      /// <returns>提交成功的数据</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CommitWorkScopes", ReplyAction ="http://www.UniCloud.com/IPartService/CommitWorkScopesResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CommitWorkScopesDataFault")]
      [Caching(CachingMethod.Remove, "GetWorkScopes")]
      WorkScopeResultData CommitWorkScopes(WorkScopeResultData workScopeData);
      
   }
}
