﻿#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/11/14 11:29:10
* 文件名：IFlightLogService
* 版本：V1.0.0
*
* 修改者： 时间： 
* 修改说明：
* ========================================================================
*/
#endregion

namespace UniCloud.Service.Refernce.ServicesRefernce
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://www.UniCloud.com", ConfigurationName = "FlightLogSvc.IFlightLogService")]
    public interface IFlightLogService
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IFlightLogService/GetFlightLogs", ReplyAction = "http://www.UniCloud.com/IFlightLogService/GetFlightLogsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IFlightLogService/GetFlightLogsDataFault", Name = "FaultData")]
        UniCloud.DataObjects.FlightLogDataObjectList GetFlightLogs();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IFlightLogService/GetFlightLogs", ReplyAction = "http://www.UniCloud.com/IFlightLogService/GetFlightLogsResponse")]
        System.Threading.Tasks.Task<UniCloud.DataObjects.FlightLogDataObjectList> GetFlightLogsAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IFlightLogService/GetFlightLogWithPagination", ReplyAction = "http://www.UniCloud.com/IFlightLogService/GetFlightLogWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IFlightLogService/GetFlightLogWithPaginationDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        UniCloud.DataObjects.FlightLogWithPagination GetFlightLogWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IFlightLogService/GetFlightLogWithPagination", ReplyAction = "http://www.UniCloud.com/IFlightLogService/GetFlightLogWithPaginationResponse")]
        System.Threading.Tasks.Task<UniCloud.DataObjects.FlightLogWithPagination> GetFlightLogWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IFlightLogService/GetFlightLogByID", ReplyAction = "http://www.UniCloud.com/IFlightLogService/GetFlightLogByIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IFlightLogService/GetFlightLogByIDDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        UniCloud.DataObjects.FlightLogDataObject GetFlightLogByID(string id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IFlightLogService/GetFlightLogByID", ReplyAction = "http://www.UniCloud.com/IFlightLogService/GetFlightLogByIDResponse")]
        System.Threading.Tasks.Task<UniCloud.DataObjects.FlightLogDataObject> GetFlightLogByIDAsync(string id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IFlightLogService/GetFlightTime", ReplyAction = "http://www.UniCloud.com/IFlightLogService/GetFlightTimeResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IFlightLogService/GetFlightTimeDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        decimal[] GetFlightTime(string acreg, System.DateTime fromDate, System.DateTime toDate);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IFlightLogService/GetFlightTime", ReplyAction = "http://www.UniCloud.com/IFlightLogService/GetFlightTimeResponse")]
        System.Threading.Tasks.Task<decimal[]> GetFlightTimeAsync(string acreg, System.DateTime fromDate, System.DateTime toDate);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IFlightLogService/ExistFlightWithAcReg", ReplyAction = "http://www.UniCloud.com/IFlightLogService/ExistFlightWithAcRegResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IFlightLogService/ExistFlightWithAcRegDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        bool ExistFlightWithAcReg(string acReg);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IFlightLogService/ExistFlightWithAcReg", ReplyAction = "http://www.UniCloud.com/IFlightLogService/ExistFlightWithAcRegResponse")]
        System.Threading.Tasks.Task<bool> ExistFlightWithAcRegAsync(string acReg);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IFlightLogService/CreateFlightLogs", ReplyAction = "http://www.UniCloud.com/IFlightLogService/CreateFlightLogsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IFlightLogService/CreateFlightLogsDataFault", Name = "FaultData")]
        UniCloud.DataObjects.FlightLogDataObjectList CreateFlightLogs(UniCloud.DataObjects.FlightLogDataObjectList flightLogs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IFlightLogService/CreateFlightLogs", ReplyAction = "http://www.UniCloud.com/IFlightLogService/CreateFlightLogsResponse")]
        System.Threading.Tasks.Task<UniCloud.DataObjects.FlightLogDataObjectList> CreateFlightLogsAsync(UniCloud.DataObjects.FlightLogDataObjectList flightLogs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IFlightLogService/DeleteFlightLogs", ReplyAction = "http://www.UniCloud.com/IFlightLogService/DeleteFlightLogsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IFlightLogService/DeleteFlightLogsDataFault", Name = "FaultData")]
        UniCloud.DataObjects.IDList DeleteFlightLogs(UniCloud.DataObjects.IDList flightLogIDs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IFlightLogService/DeleteFlightLogs", ReplyAction = "http://www.UniCloud.com/IFlightLogService/DeleteFlightLogsResponse")]
        System.Threading.Tasks.Task<UniCloud.DataObjects.IDList> DeleteFlightLogsAsync(UniCloud.DataObjects.IDList flightLogIDs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IFlightLogService/UpdateFlightLogs", ReplyAction = "http://www.UniCloud.com/IFlightLogService/UpdateFlightLogsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IFlightLogService/UpdateFlightLogsDataFault", Name = "FaultData")]
        UniCloud.DataObjects.FlightLogDataObjectList UpdateFlightLogs(UniCloud.DataObjects.FlightLogDataObjectList flightLogs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IFlightLogService/UpdateFlightLogs", ReplyAction = "http://www.UniCloud.com/IFlightLogService/UpdateFlightLogsResponse")]
        System.Threading.Tasks.Task<UniCloud.DataObjects.FlightLogDataObjectList> UpdateFlightLogsAsync(UniCloud.DataObjects.FlightLogDataObjectList flightLogs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IFlightLogService/CommitFlightLogs", ReplyAction = "http://www.UniCloud.com/IFlightLogService/CommitFlightLogsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IFlightLogService/CommitFlightLogsDataFault", Name = "FaultData")]
        UniCloud.DataObjects.FlightLogResultData CommitFlightLogs(UniCloud.DataObjects.FlightLogResultData flightLogData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IFlightLogService/CommitFlightLogs", ReplyAction = "http://www.UniCloud.com/IFlightLogService/CommitFlightLogsResponse")]
        System.Threading.Tasks.Task<UniCloud.DataObjects.FlightLogResultData> CommitFlightLogsAsync(UniCloud.DataObjects.FlightLogResultData flightLogData);
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFlightLogServiceChannel : IFlightLogService, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FlightLogServiceClient : System.ServiceModel.ClientBase<IFlightLogService>, IFlightLogService
    {

        public FlightLogServiceClient()
        {
        }

        public FlightLogServiceClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public FlightLogServiceClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public FlightLogServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public FlightLogServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        public UniCloud.DataObjects.FlightLogDataObjectList GetFlightLogs()
        {
            return base.Channel.GetFlightLogs();
        }

        public System.Threading.Tasks.Task<UniCloud.DataObjects.FlightLogDataObjectList> GetFlightLogsAsync()
        {
            return base.Channel.GetFlightLogsAsync();
        }

        public UniCloud.DataObjects.FlightLogWithPagination GetFlightLogWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetFlightLogWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<UniCloud.DataObjects.FlightLogWithPagination> GetFlightLogWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetFlightLogWithPaginationAsync(pagination);
        }

        public UniCloud.DataObjects.FlightLogDataObject GetFlightLogByID(string id)
        {
            return base.Channel.GetFlightLogByID(id);
        }

        public System.Threading.Tasks.Task<UniCloud.DataObjects.FlightLogDataObject> GetFlightLogByIDAsync(string id)
        {
            return base.Channel.GetFlightLogByIDAsync(id);
        }

        public decimal[] GetFlightTime(string acreg, System.DateTime fromDate, System.DateTime toDate)
        {
            return base.Channel.GetFlightTime(acreg, fromDate, toDate);
        }

        public System.Threading.Tasks.Task<decimal[]> GetFlightTimeAsync(string acreg, System.DateTime fromDate, System.DateTime toDate)
        {
            return base.Channel.GetFlightTimeAsync(acreg, fromDate, toDate);
        }

        public bool ExistFlightWithAcReg(string acReg)
        {
            return base.Channel.ExistFlightWithAcReg(acReg);
        }

        public System.Threading.Tasks.Task<bool> ExistFlightWithAcRegAsync(string acReg)
        {
            return base.Channel.ExistFlightWithAcRegAsync(acReg);
        }

        public UniCloud.DataObjects.FlightLogDataObjectList CreateFlightLogs(UniCloud.DataObjects.FlightLogDataObjectList flightLogs)
        {
            return base.Channel.CreateFlightLogs(flightLogs);
        }

        public System.Threading.Tasks.Task<UniCloud.DataObjects.FlightLogDataObjectList> CreateFlightLogsAsync(UniCloud.DataObjects.FlightLogDataObjectList flightLogs)
        {
            return base.Channel.CreateFlightLogsAsync(flightLogs);
        }

        public UniCloud.DataObjects.IDList DeleteFlightLogs(UniCloud.DataObjects.IDList flightLogIDs)
        {
            return base.Channel.DeleteFlightLogs(flightLogIDs);
        }

        public System.Threading.Tasks.Task<UniCloud.DataObjects.IDList> DeleteFlightLogsAsync(UniCloud.DataObjects.IDList flightLogIDs)
        {
            return base.Channel.DeleteFlightLogsAsync(flightLogIDs);
        }

        public UniCloud.DataObjects.FlightLogDataObjectList UpdateFlightLogs(UniCloud.DataObjects.FlightLogDataObjectList flightLogs)
        {
            return base.Channel.UpdateFlightLogs(flightLogs);
        }

        public System.Threading.Tasks.Task<UniCloud.DataObjects.FlightLogDataObjectList> UpdateFlightLogsAsync(UniCloud.DataObjects.FlightLogDataObjectList flightLogs)
        {
            return base.Channel.UpdateFlightLogsAsync(flightLogs);
        }

        public UniCloud.DataObjects.FlightLogResultData CommitFlightLogs(UniCloud.DataObjects.FlightLogResultData flightLogData)
        {
            return base.Channel.CommitFlightLogs(flightLogData);
        }

        public System.Threading.Tasks.Task<UniCloud.DataObjects.FlightLogResultData> CommitFlightLogsAsync(UniCloud.DataObjects.FlightLogResultData flightLogData)
        {
            return base.Channel.CommitFlightLogsAsync(flightLogData);
        }
    }
}
