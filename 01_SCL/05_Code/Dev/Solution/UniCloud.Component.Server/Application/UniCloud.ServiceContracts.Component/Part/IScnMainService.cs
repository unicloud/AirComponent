#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/6 21:54:49

// 文件名：IScnMainService
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
   /// 表示与ScnMain相关的应用层服务契约。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IScnMainService
   {
      /// <summary>
      /// 创建ScnMain。
      /// </summary>
      /// <param name="scnMains">需要创建的ScnMain。</param>
      /// <returns>创建的ScnMain。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CreateScnMains", ReplyAction ="http://www.UniCloud.com/IPartService/CreateScnMainsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CreateScnMainsDataFault")]
      [Caching(CachingMethod.Remove, "GetScnMains")]
      ScnMainDataObjectList CreateScnMains(ScnMainDataObjectList scnMains);
      
      /// <summary>
      /// 删除ScnMain信息。
      /// </summary>
      /// <param name="scnMainIDs">需要更新的ScnMain信息的ID值。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/DeleteScnMains", ReplyAction ="http://www.UniCloud.com/IPartService/DeleteScnMainsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/DeleteScnMainsDataFault")]
      [Caching(CachingMethod.Remove, "GetScnMains")]
      IDList DeleteScnMains(IDList scnMainIDs);
      
      /// <summary>
      /// 更新ScnMain信息。
      /// </summary>
      /// <param name="scnMains">需要更新的ScnMain信息。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/UpdateScnMains", ReplyAction ="http://www.UniCloud.com/IPartService/UpdateScnMainsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/UpdateScnMainsDataFault")]
      [Caching(CachingMethod.Remove, "GetScnMains")]
      ScnMainDataObjectList UpdateScnMains(ScnMainDataObjectList scnMains);
      
      /// <summary>
      /// 提交ScnMain的增删改数据
      /// </summary>
      /// <param name="scnMainData"></param>
      /// <returns>提交成功的数据</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CommitScnMains", ReplyAction ="http://www.UniCloud.com/IPartService/CommitScnMainsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CommitScnMainsDataFault")]
      [Caching(CachingMethod.Remove, "GetScnMains")]
      ScnMainResultData CommitScnMains(ScnMainResultData scnMainData);
      
      /// <summary>
      /// 通过ScnMainId获取相应的ScnMain 带导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetFullScnMainByID", ReplyAction ="http://www.UniCloud.com/IPartService/GetFullScnMainByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IPartService/GetFullScnMainByIDDataFault")]
      ScnMainDataObject GetFullScnMainByID(int id);
      
      /// <summary>
      /// 获取所有ScnMain 带导航属性
      /// </summary>
      /// <returns>所有的ScnMain。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetFullScnMains", ReplyAction ="http://www.UniCloud.com/IPartService/GetFullScnMainsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/GetFullScnMainsDataFault")]
      ScnMainDataObjectList GetFullScnMains();
   }
}
