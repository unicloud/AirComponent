#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/6 21:54:49

// 文件名：IPnRegService
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
   /// 表示与PnReg相关的应用层服务契约。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IPnRegService
   {
      /// <summary>
      /// 创建PnReg。
      /// </summary>
      /// <param name="pnRegs">需要创建的PnReg。</param>
      /// <returns>创建的PnReg。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CreatePnRegs", ReplyAction ="http://www.UniCloud.com/IPartService/CreatePnRegsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CreatePnRegsDataFault")]
      [Caching(CachingMethod.Remove, "GetPnRegs")]
      PnRegDataObjectList CreatePnRegs(PnRegDataObjectList pnRegs);
      
      /// <summary>
      /// 删除PnReg信息。
      /// </summary>
      /// <param name="pnRegIDs">需要更新的PnReg信息的ID值。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/DeletePnRegs", ReplyAction ="http://www.UniCloud.com/IPartService/DeletePnRegsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/DeletePnRegsDataFault")]
      [Caching(CachingMethod.Remove, "GetPnRegs")]
      IDList DeletePnRegs(IDList pnRegIDs);
      
      /// <summary>
      /// 更新PnReg信息。
      /// </summary>
      /// <param name="pnRegs">需要更新的PnReg信息。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/UpdatePnRegs", ReplyAction ="http://www.UniCloud.com/IPartService/UpdatePnRegsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/UpdatePnRegsDataFault")]
      [Caching(CachingMethod.Remove, "GetPnRegs")]
      PnRegDataObjectList UpdatePnRegs(PnRegDataObjectList pnRegs);
      
      /// <summary>
      /// 提交PnReg的增删改数据
      /// </summary>
      /// <param name="pnRegData"></param>
      /// <returns>提交成功的数据</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CommitPnRegs", ReplyAction ="http://www.UniCloud.com/IPartService/CommitPnRegsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CommitPnRegsDataFault")]
      [Caching(CachingMethod.Remove, "GetPnRegs")]
      PnRegResultData CommitPnRegs(PnRegResultData pnRegData);
      
      /// <summary>
      /// 通过PnRegId获取相应的PnReg 带导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetFullPnRegByID", ReplyAction ="http://www.UniCloud.com/IPartService/GetFullPnRegByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IPartService/GetFullPnRegByIDDataFault")]
      PnRegDataObject GetFullPnRegByID(int id);
      
      /// <summary>
      /// 获取所有PnReg 带导航属性
      /// </summary>
      /// <returns>所有的PnReg。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetFullPnRegs", ReplyAction ="http://www.UniCloud.com/IPartService/GetFullPnRegsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/GetFullPnRegsDataFault")]
      PnRegDataObjectList GetFullPnRegs();
   }
}
