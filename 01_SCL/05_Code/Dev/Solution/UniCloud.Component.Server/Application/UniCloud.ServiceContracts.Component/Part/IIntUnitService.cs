#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/6 21:54:49

// 文件名：IIntUnitService
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
   /// 表示与IntUnit相关的应用层服务契约。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IIntUnitService
   {
      /// <summary>
      /// 创建IntUnit。
      /// </summary>
      /// <param name="intUnits">需要创建的IntUnit。</param>
      /// <returns>创建的IntUnit。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CreateIntUnits", ReplyAction ="http://www.UniCloud.com/IPartService/CreateIntUnitsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CreateIntUnitsDataFault")]
      [Caching(CachingMethod.Remove, "GetIntUnits")]
      IntUnitDataObjectList CreateIntUnits(IntUnitDataObjectList intUnits);
      
      /// <summary>
      /// 删除IntUnit信息。
      /// </summary>
      /// <param name="intUnitIDs">需要更新的IntUnit信息的ID值。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/DeleteIntUnits", ReplyAction ="http://www.UniCloud.com/IPartService/DeleteIntUnitsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/DeleteIntUnitsDataFault")]
      [Caching(CachingMethod.Remove, "GetIntUnits")]
      IDList DeleteIntUnits(IDList intUnitIDs);
      
      /// <summary>
      /// 更新IntUnit信息。
      /// </summary>
      /// <param name="intUnits">需要更新的IntUnit信息。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/UpdateIntUnits", ReplyAction ="http://www.UniCloud.com/IPartService/UpdateIntUnitsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/UpdateIntUnitsDataFault")]
      [Caching(CachingMethod.Remove, "GetIntUnits")]
      IntUnitDataObjectList UpdateIntUnits(IntUnitDataObjectList intUnits);
      
      /// <summary>
      /// 提交IntUnit的增删改数据
      /// </summary>
      /// <param name="intUnitData"></param>
      /// <returns>提交成功的数据</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CommitIntUnits", ReplyAction ="http://www.UniCloud.com/IPartService/CommitIntUnitsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CommitIntUnitsDataFault")]
      [Caching(CachingMethod.Remove, "GetIntUnits")]
      IntUnitResultData CommitIntUnits(IntUnitResultData intUnitData);
      
   }
}
