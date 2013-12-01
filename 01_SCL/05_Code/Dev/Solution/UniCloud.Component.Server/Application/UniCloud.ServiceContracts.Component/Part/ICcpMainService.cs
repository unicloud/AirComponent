#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/6 21:54:49

// 文件名：ICcpMainService
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
   /// 表示与CcpMain相关的应用层服务契约。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface ICcpMainService
   {
      /// <summary>
      /// 创建CcpMain。
      /// </summary>
      /// <param name="ccpMains">需要创建的CcpMain。</param>
      /// <returns>创建的CcpMain。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CreateCcpMains", ReplyAction ="http://www.UniCloud.com/IPartService/CreateCcpMainsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CreateCcpMainsDataFault")]
      [Caching(CachingMethod.Remove, "GetCcpMains")]
      CcpMainDataObjectList CreateCcpMains(CcpMainDataObjectList ccpMains);
      
      /// <summary>
      /// 删除CcpMain信息。
      /// </summary>
      /// <param name="ccpMainIDs">需要更新的CcpMain信息的ID值。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/DeleteCcpMains", ReplyAction ="http://www.UniCloud.com/IPartService/DeleteCcpMainsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/DeleteCcpMainsDataFault")]
      [Caching(CachingMethod.Remove, "GetCcpMains")]
      IDList DeleteCcpMains(IDList ccpMainIDs);
      
      /// <summary>
      /// 更新CcpMain信息。
      /// </summary>
      /// <param name="ccpMains">需要更新的CcpMain信息。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/UpdateCcpMains", ReplyAction ="http://www.UniCloud.com/IPartService/UpdateCcpMainsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/UpdateCcpMainsDataFault")]
      [Caching(CachingMethod.Remove, "GetCcpMains")]
      CcpMainDataObjectList UpdateCcpMains(CcpMainDataObjectList ccpMains);
      
      /// <summary>
      /// 提交CcpMain的增删改数据
      /// </summary>
      /// <param name="ccpMainData"></param>
      /// <returns>提交成功的数据</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CommitCcpMains", ReplyAction ="http://www.UniCloud.com/IPartService/CommitCcpMainsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CommitCcpMainsDataFault")]
      [Caching(CachingMethod.Remove, "GetCcpMains")]
      CcpMainResultData CommitCcpMains(CcpMainResultData ccpMainData);
      
      /// <summary>
      /// 通过CcpMainId获取相应的CcpMain 带导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetFullCcpMainByID", ReplyAction ="http://www.UniCloud.com/IPartService/GetFullCcpMainByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IPartService/GetFullCcpMainByIDDataFault")]
      CcpMainDataObject GetFullCcpMainByID(int id);
      
      /// <summary>
      /// 获取所有CcpMain 带导航属性
      /// </summary>
      /// <returns>所有的CcpMain。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetFullCcpMains", ReplyAction ="http://www.UniCloud.com/IPartService/GetFullCcpMainsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/GetFullCcpMainsDataFault")]
      CcpMainDataObjectList GetFullCcpMains();

      /// <summary>
      /// 根据条件查询CcpMain（展示用）
      /// </summary>
      /// <param name="acModel">机型</param>
      /// <param name="itemNo">附件项号</param>
      /// <param name="ata">章节</param>
      /// <param name="stateStation">状态</param>
      /// <returns></returns>
      [OperationContract(Action = "http://www.UniCloud.com/IPartService/QueryAllCcpMain", ReplyAction = "http://www.UniCloud.com/IPartService/QueryAllCcpMainResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/QueryAllCcpMainDataFault")]
      CcpMainDataObjectList QueryAllCcpMain(string actype, string itemNo, string ata, string stateStation);

      /// <summary>
      /// 审核附件项
      /// </summary>
      /// <param name="ccpMainId"></param>
      [OperationContract(Action = "http://www.UniCloud.com/IPartService/VerifyCcpMain", ReplyAction = "http://www.UniCloud.com/IPartService/VerifyCcpMainResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/VerifyCcpMainDataFault")]
      bool VerifyCcpMain(int ccpMainId);
   }
}
