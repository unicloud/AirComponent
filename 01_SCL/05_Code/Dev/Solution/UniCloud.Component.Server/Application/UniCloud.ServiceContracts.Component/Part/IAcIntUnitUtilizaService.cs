#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/6 11:27:30

// 文件名：IAcIntUnitUtilizaService
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
using UniCloud.Query;

namespace UniCloud.ServiceContracts
{
   /// <summary>
   /// 表示与AcIntUnitUtiliza相关的应用层服务契约。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IAcIntUnitUtilizaService
   {
      /// <summary>
      /// 创建AcIntUnitUtiliza。
      /// </summary>
      /// <param name="acIntUnitUtilizas">需要创建的AcIntUnitUtiliza。</param>
      /// <returns>创建的AcIntUnitUtiliza。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CreateAcIntUnitUtilizas", ReplyAction ="http://www.UniCloud.com/IPartService/CreateAcIntUnitUtilizasResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CreateAcIntUnitUtilizasDataFault")]
      [Caching(CachingMethod.Remove, "GetAcIntUnitUtilizas")]
      AcIntUnitUtilizaDataObjectList CreateAcIntUnitUtilizas(AcIntUnitUtilizaDataObjectList acIntUnitUtilizas);
      
      /// <summary>
      /// 删除AcIntUnitUtiliza信息。
      /// </summary>
      /// <param name="acIntUnitUtilizaIDs">需要更新的AcIntUnitUtiliza信息的ID值。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/DeleteAcIntUnitUtilizas", ReplyAction ="http://www.UniCloud.com/IPartService/DeleteAcIntUnitUtilizasResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/DeleteAcIntUnitUtilizasDataFault")]
      [Caching(CachingMethod.Remove, "GetAcIntUnitUtilizas")]
      IDList DeleteAcIntUnitUtilizas(IDList acIntUnitUtilizaIDs);
      
      /// <summary>
      /// 更新AcIntUnitUtiliza信息。
      /// </summary>
      /// <param name="acIntUnitUtilizas">需要更新的AcIntUnitUtiliza信息。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/UpdateAcIntUnitUtilizas", ReplyAction ="http://www.UniCloud.com/IPartService/UpdateAcIntUnitUtilizasResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/UpdateAcIntUnitUtilizasDataFault")]
      [Caching(CachingMethod.Remove, "GetAcIntUnitUtilizas")]
      AcIntUnitUtilizaDataObjectList UpdateAcIntUnitUtilizas(AcIntUnitUtilizaDataObjectList acIntUnitUtilizas);
      
      /// <summary>
      /// 提交AcIntUnitUtiliza的增删改数据
      /// </summary>
      /// <param name="acIntUnitUtilizaData"></param>
      /// <returns>提交成功的数据</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CommitAcIntUnitUtilizas", ReplyAction ="http://www.UniCloud.com/IPartService/CommitAcIntUnitUtilizasResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CommitAcIntUnitUtilizasDataFault")]
      [Caching(CachingMethod.Remove, "GetAcIntUnitUtilizas")]
      AcIntUnitUtilizaResultData CommitAcIntUnitUtilizas(AcIntUnitUtilizaResultData acIntUnitUtilizaData);
   }
}
