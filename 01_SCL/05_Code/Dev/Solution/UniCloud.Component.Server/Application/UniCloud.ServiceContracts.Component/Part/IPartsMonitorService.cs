#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/6 21:54:49

// 文件名：IPartsMonitorService
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.ServiceModel;
using UniCloud.DataObjects;
using UniCloud.Domain.Model;
using UniCloud.Infrastructure;
using UniCloud.Infrastructure.Caching;


namespace UniCloud.ServiceContracts
{
   /// <summary>
   /// 表示与PartsMonitor相关的应用层服务契约。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IPartsMonitorService
   {
      /// <summary>
      /// 创建PartsMonitor。
      /// </summary>
      /// <param name="partsMonitors">需要创建的PartsMonitor。</param>
      /// <returns>创建的PartsMonitor。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CreatePartsMonitors", ReplyAction ="http://www.UniCloud.com/IPartService/CreatePartsMonitorsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CreatePartsMonitorsDataFault")]
      [Caching(CachingMethod.Remove, "GetPartsMonitors")]
      PartsMonitorDataObjectList CreatePartsMonitors(PartsMonitorDataObjectList partsMonitors);
      
      /// <summary>
      /// 删除PartsMonitor信息。
      /// </summary>
      /// <param name="partsMonitorIDs">需要更新的PartsMonitor信息的ID值。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/DeletePartsMonitors", ReplyAction ="http://www.UniCloud.com/IPartService/DeletePartsMonitorsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/DeletePartsMonitorsDataFault")]
      [Caching(CachingMethod.Remove, "GetPartsMonitors")]
      IDList DeletePartsMonitors(IDList partsMonitorIDs);
      
      /// <summary>
      /// 更新PartsMonitor信息。
      /// </summary>
      /// <param name="partsMonitors">需要更新的PartsMonitor信息。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/UpdatePartsMonitors", ReplyAction ="http://www.UniCloud.com/IPartService/UpdatePartsMonitorsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/UpdatePartsMonitorsDataFault")]
      [Caching(CachingMethod.Remove, "GetPartsMonitors")]
      PartsMonitorDataObjectList UpdatePartsMonitors(PartsMonitorDataObjectList partsMonitors);
      
      /// <summary>
      /// 提交PartsMonitor的增删改数据
      /// </summary>
      /// <param name="partsMonitorData"></param>
      /// <returns>提交成功的数据</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/CommitPartsMonitors", ReplyAction ="http://www.UniCloud.com/IPartService/CommitPartsMonitorsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/CommitPartsMonitorsDataFault")]
      [Caching(CachingMethod.Remove, "GetPartsMonitors")]
      PartsMonitorResultData CommitPartsMonitors(PartsMonitorResultData partsMonitorData);
      
      /// <summary>
      /// 通过PartsMonitorId获取相应的PartsMonitor 带导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetFullPartsMonitorByID", ReplyAction ="http://www.UniCloud.com/IPartService/GetFullPartsMonitorByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IPartService/GetFullPartsMonitorByIDDataFault")]
      PartsMonitorDataObject GetFullPartsMonitorByID(int id);
      
      /// <summary>
      /// 获取所有PartsMonitor 带导航属性
      /// </summary>
      /// <returns>所有的PartsMonitor。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetFullPartsMonitors", ReplyAction ="http://www.UniCloud.com/IPartService/GetFullPartsMonitorsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/GetFullPartsMonitorsDataFault")]
      PartsMonitorDataObjectList GetFullPartsMonitors();

      /// <summary>
      /// 计算所有附件项相关的到期日期
      /// </summary>
      /// <returns>生成的监控记录</returns>
      [OperationContract(Action = "http://www.UniCloud.com/IPartService/CalculateAllCcpMain", ReplyAction = "http://www.UniCloud.com/IPartService/CalculateAllCcpMainResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/CalculateAllCcpMainDataFault")]
      PartsMonitorDataObjectList CalculateAllCcpMain();

      
      /// <summary>
      ///计算特定附件项相关的到期日期
      /// </summary>
      /// <returns>生成的监控记录</returns>
      [OperationContract(Action = "http://www.UniCloud.com/IPartService/CalculateSpecificCcpMain", ReplyAction = "http://www.UniCloud.com/IPartService/CalculateSpecificCcpMainResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/CalculateSpecificCcpMainDataFault")]
      PartsMonitorDataObjectList CalculateSpecificCcpMain(string itemno);

      
      /// <summary>
      ///计算特定的SN序号件
      /// </summary>
      /// <returns>生成的监控记录</returns>
      //[OperationContract(Action = "http://www.UniCloud.com/IPartService/CalculateSpecificSnregs", ReplyAction = "http://www.UniCloud.com/IPartService/CalculateSpecificSnregsResponse")]
      //[FaultContract(typeof(FaultData), Name = "FaultData", Action = "http://www.UniCloud.com/IPartService/CalculateSpecificSnregsDataFault")]
      PartsMonitorDataObjectList CalculateSpecificSnregs(List<SnReg> sns);
   }
}
