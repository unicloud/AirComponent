#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/21 12:27:06

// 文件名：IWorkScopeQuery
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
   /// 表示用于WorkScope的查询接口。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IWorkScopeQuery
   {
      #region Query WorkScope
      
      /// <summary>
      /// 获取所有WorkScope
      /// </summary>
      /// <returns>所有的WorkScope。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetWorkScopes", ReplyAction ="http://www.UniCloud.com/IPartService/GetWorkScopesResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/GetWorkScopesDataFault")]
      WorkScopeDataObjectList GetWorkScopes(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter);
      
      /// <summary>
      /// 获取所有WorkScope分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的WorkScope分页信息。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetWorkScopeWithPagination", ReplyAction ="http://www.UniCloud.com/IPartService/GetWorkScopeWithPaginationResponse")]
      [FaultContract(typeof(FaultData), Name ="FaultData", Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action="http://www.UniCloud.com/IPartService/GetWorkScopeWithPaginationDataFault")]
      WorkScopeWithPagination GetWorkScopeWithPagination(Pagination pagination);
      
      /// <summary>
      /// 通过WorkScopeId获取相应的WorkScope
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetWorkScopeByID", ReplyAction ="http://www.UniCloud.com/IPartService/GetWorkScopeByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IPartService/GetWorkScopeByIDDataFault")]
      WorkScopeDataObject GetWorkScopeByID(int id);
      #endregion
   }
}
