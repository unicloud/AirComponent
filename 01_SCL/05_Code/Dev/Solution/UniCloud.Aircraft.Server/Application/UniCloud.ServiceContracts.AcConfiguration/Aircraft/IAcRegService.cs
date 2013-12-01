#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/30 10:17:20

// 文件名：IAcRegService
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
using UniCloud.Query.AcConfiguration;

namespace UniCloud.ServiceContracts
{
   /// <summary>
   /// 表示与AcReg相关的应用层服务契约。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IAcRegService:IApplicationServiceContract
   {
      /// <summary>
      /// 创建AcReg。
      /// </summary>
      /// <param name="acRegs">需要创建的AcReg。</param>
      /// <returns>创建的AcReg。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/CreateAcRegs", ReplyAction ="http://www.UniCloud.com/IAircraftService/CreateAcRegsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IAircraftService/CreateAcRegsDataFault")]
      [Caching(CachingMethod.Remove, "GetAcRegs")]
      AcRegDataObjectList CreateAcRegs(AcRegDataObjectList acRegs);
      
      /// <summary>
      /// 删除AcReg信息。
      /// </summary>
      /// <param name="acRegs">需要更新的AcReg信息的ID值。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/DeleteAcRegs", ReplyAction ="http://www.UniCloud.com/IAircraftService/DeleteAcRegsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IAircraftService/DeleteAcRegsDataFault")]
      [Caching(CachingMethod.Remove, "GetAcRegs")]
      IDList DeleteAcRegs(AcRegDataObjectList acRegs);
      
      /// <summary>
      /// 更新AcReg信息。
      /// </summary>
      /// <param name="acRegs">需要更新的AcReg信息。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/UpdateAcRegs", ReplyAction ="http://www.UniCloud.com/IAircraftService/UpdateAcRegsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IAircraftService/UpdateAcRegsDataFault")]
      [Caching(CachingMethod.Remove, "GetAcRegs")]
      AcRegDataObjectList UpdateAcRegs(AcRegDataObjectList acRegs);
      
      /// <summary>
      /// 提交AcReg的增删改数据
      /// </summary>
      /// <param name="acRegData"></param>
      /// <returns>提交成功的数据</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/CommitAcRegs", ReplyAction ="http://www.UniCloud.com/IAircraftService/CommitAcRegsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IAircraftService/CommitAcRegsDataFault")]
      [Caching(CachingMethod.Remove, "GetAcRegs")]
      AcRegResultData CommitAcRegs(AcRegResultData acRegData);
      
      /// <summary>
      /// 通过AcRegId获取相应的AcReg 带导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetFullAcRegByID", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetFullAcRegByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IAircraftService/GetFullAcRegByIDDataFault")]
      AcRegDataObject GetFullAcRegByID(int id);

      /// <summary>
      /// 通过AcReg GUID获取相应的AcReg 带导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/GetFullAcRegByGuid", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAcRegByGuidResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IAircraftService/GetFullAcRegByGuidDataFault")]
      AcRegDataObject GetFullAcRegByGuid(string id);

      /// <summary>
      /// 通过AcReg GUID获取相应的AcReg 带导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/GetFullAcRegByReg", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAcRegByRegResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IAircraftService/GetFullAcRegByRegDataFault")]
      AcRegDataObject GetFullAcRegByReg (string reg);
      

      /// <summary>
      /// 获取所有AcReg 带导航属性
      /// </summary>
      /// <returns>所有的AcReg。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetFullAcRegs", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetFullAcRegsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IAircraftService/GetFullAcRegsDataFault")]
      AcRegDataObjectList GetFullAcRegs();
   }
}
