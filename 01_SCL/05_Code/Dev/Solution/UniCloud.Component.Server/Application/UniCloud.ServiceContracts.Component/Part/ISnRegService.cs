#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/6 21:54:49

// 文件名：ISnRegService
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
   /// 表示与SnReg相关的应用层服务契约。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface ISnRegService
   {
      /// <summary>
      /// 创建SnReg。
      /// </summary>
      /// <param name="snRegs">需要创建的SnReg。</param>
      /// <returns>创建的SnReg。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CreateSnRegs", ReplyAction ="http://www.UniCloud.com/IPartService/CreateSnRegsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CreateSnRegsDataFault")]
      [Caching(CachingMethod.Remove, "GetSnRegs")]
      SnRegDataObjectList CreateSnRegs(SnRegDataObjectList snRegs);
      
      /// <summary>
      /// 删除SnReg信息。
      /// </summary>
      /// <param name="snRegIDs">需要更新的SnReg信息的ID值。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/DeleteSnRegs", ReplyAction ="http://www.UniCloud.com/IPartService/DeleteSnRegsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/DeleteSnRegsDataFault")]
      [Caching(CachingMethod.Remove, "GetSnRegs")]
      IDList DeleteSnRegs(IDList snRegIDs);
      
      /// <summary>
      /// 更新SnReg信息。
      /// </summary>
      /// <param name="snRegs">需要更新的SnReg信息。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/UpdateSnRegs", ReplyAction ="http://www.UniCloud.com/IPartService/UpdateSnRegsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/UpdateSnRegsDataFault")]
      [Caching(CachingMethod.Remove, "GetSnRegs")]
      SnRegDataObjectList UpdateSnRegs(SnRegDataObjectList snRegs);
      
      /// <summary>
      /// 提交SnReg的增删改数据
      /// </summary>
      /// <param name="snRegData"></param>
      /// <returns>提交成功的数据</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CommitSnRegs", ReplyAction ="http://www.UniCloud.com/IPartService/CommitSnRegsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CommitSnRegsDataFault")]
      [Caching(CachingMethod.Remove, "GetSnRegs")]
      SnRegResultData CommitSnRegs(SnRegResultData snRegData);
      
      /// <summary>
      /// 通过SnRegId获取相应的SnReg 带导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetFullSnRegByID", ReplyAction ="http://www.UniCloud.com/IPartService/GetFullSnRegByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IPartService/GetFullSnRegByIDDataFault")]
      SnRegDataObject GetFullSnRegByID(int id);
      
      /// <summary>
      /// 获取所有SnReg 带导航属性
      /// </summary>
      /// <returns>所有的SnReg。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetFullSnRegs", ReplyAction ="http://www.UniCloud.com/IPartService/GetFullSnRegsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/GetFullSnRegsDataFault")]
      SnRegDataObjectList GetFullSnRegs();

      /// <summary>
      /// 条件查询附件
      /// </summary>
      /// <param name="ac">飞机号</param>
      /// <param name="pnRegId">件号ID</param>
      /// <param name="sn">序号</param>
      /// <returns></returns>
      [OperationContract(Action = "http://www.UniCloud.com/IPartService/QuerySnRegs", ReplyAction = "http://www.UniCloud.com/IPartService/QuerySnRegsResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/QuerySnRegsDataFault")]
      SnRegDataObjectList QuerySnRegs(string ac, int pnRegId, string sn);


      /// <summary>
      /// 条件查询附件
      /// </summary>
      /// <param name="itemNo">附件项号</param>
      /// <param name="pnId">件号ID</param>
      /// <param name="snId">序号ID</param>
      /// <param name="ac">飞机ID</param>
      /// <param name="avail">状态</param>
      /// <returns></returns>
      [OperationContract(Action = "http://www.UniCloud.com/IPartService/QuerySnRegDtos", ReplyAction = "http://www.UniCloud.com/IPartService/QuerySnRegDtosResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/QuerySnRegDtosDataFault")]
      SnRegDataObjectList QuerySnRegDtos(string itemNo, int pnId, int snId, string ac, string avail);
   }
}
