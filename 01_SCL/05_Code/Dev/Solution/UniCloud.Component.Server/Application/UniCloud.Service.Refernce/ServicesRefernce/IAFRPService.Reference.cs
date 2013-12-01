#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/10/21 17:58:40
* 文件名：IAFRPService
* 版本：V1.0.0
*
* 修改者： 时间： 
* 修改说明：
* ========================================================================
*/
#endregion
using UniCloud.DataObjects;

namespace UniCloud.Service.Refernce.ServicesRefernce
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://www.UniCloud.com", ConfigurationName = "AFRP.IAFRPService")]
    public interface IAFRPService
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetNDRCRequestWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetNDRCRequestWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetNDRCRequestWithPaginationFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        NDRCRequestWithPagination GetNDRCRequestWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetNDRCRequestWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetNDRCRequestWithPaginationResponse")]
        System.Threading.Tasks.Task<NDRCRequestWithPagination> GetNDRCRequestWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPlanAircraftWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPlanAircraftWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetPlanAircraftWithPaginationFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        PlanAircraftWithPagination GetPlanAircraftWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPlanAircraftWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPlanAircraftWithPaginationResponse")]
        System.Threading.Tasks.Task<PlanAircraftWithPagination> GetPlanAircraftWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPlanEngineWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPlanEngineWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetPlanEngineWithPaginationFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        PlanEngineWithPagination GetPlanEngineWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPlanEngineWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPlanEngineWithPaginationResponse")]
        System.Threading.Tasks.Task<PlanEngineWithPagination> GetPlanEngineWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPlanWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPlanWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetPlanWithPaginationFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        PlanWithPagination GetPlanWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPlanWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPlanWithPaginationResponse")]
        System.Threading.Tasks.Task<PlanWithPagination> GetPlanWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetProgrammCategoryWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetProgrammCategoryWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetProgrammCategoryWithPaginationFaultDataFa" +
            "ult", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ProgrammCategoryWithPagination GetProgrammCategoryWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetProgrammCategoryWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetProgrammCategoryWithPaginationResponse")]
        System.Threading.Tasks.Task<ProgrammCategoryWithPagination> GetProgrammCategoryWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetProgrammingWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetProgrammingWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetProgrammingWithPaginationFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ProgrammingWithPagination GetProgrammingWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetProgrammingWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetProgrammingWithPaginationResponse")]
        System.Threading.Tasks.Task<ProgrammingWithPagination> GetProgrammingWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetRAApprovalDocWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetRAApprovalDocWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetRAApprovalDocWithPaginationFaultDataFault" +
            "", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        RAApprovalDocWithPagination GetRAApprovalDocWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetRAApprovalDocWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetRAApprovalDocWithPaginationResponse")]
        System.Threading.Tasks.Task<RAApprovalDocWithPagination> GetRAApprovalDocWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetRARequestWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetRARequestWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetRARequestWithPaginationFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        RARequestWithPagination GetRARequestWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetRARequestWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetRARequestWithPaginationResponse")]
        System.Threading.Tasks.Task<RARequestWithPagination> GetRARequestWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetRequestWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetRequestWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetRequestWithPaginationFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        RequestWithPagination GetRequestWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetRequestWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetRequestWithPaginationResponse")]
        System.Threading.Tasks.Task<RequestWithPagination> GetRequestWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetSAWSApprovalDocWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetSAWSApprovalDocWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetSAWSApprovalDocWithPaginationFaultDataFau" +
            "lt", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        SAWSApprovalDocWithPagination GetSAWSApprovalDocWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetSAWSApprovalDocWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetSAWSApprovalDocWithPaginationResponse")]
        System.Threading.Tasks.Task<SAWSApprovalDocWithPagination> GetSAWSApprovalDocWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetSAWSRequestWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetSAWSRequestWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetSAWSRequestWithPaginationFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        SAWSRequestWithPagination GetSAWSRequestWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetSAWSRequestWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetSAWSRequestWithPaginationResponse")]
        System.Threading.Tasks.Task<SAWSRequestWithPagination> GetSAWSRequestWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetXmlConfigWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetXmlConfigWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetXmlConfigWithPaginationFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        XmlConfigWithPagination GetXmlConfigWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetXmlConfigWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetXmlConfigWithPaginationResponse")]
        System.Threading.Tasks.Task<XmlConfigWithPagination> GetXmlConfigWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAirlinesWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAirlinesWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAirlinesWithPaginationFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AirlinesWithPagination GetAirlinesWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAirlinesWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAirlinesWithPaginationResponse")]
        System.Threading.Tasks.Task<AirlinesWithPagination> GetAirlinesWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllSubsidiarysWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllSubsidiarysWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllSubsidiarysWithPaginationFaultDataFaul" +
            "t", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AirlinesWithPagination GetAllSubsidiarysWithPagination(System.Guid masterID, UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllSubsidiarysWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllSubsidiarysWithPaginationResponse")]
        System.Threading.Tasks.Task<AirlinesWithPagination> GetAllSubsidiarysWithPaginationAsync(System.Guid masterID, UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllFilialesWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllFilialesWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllFilialesWithPaginationFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AirlinesWithPagination GetAllFilialesWithPagination(System.Guid masterID, UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllFilialesWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllFilialesWithPaginationResponse")]
        System.Threading.Tasks.Task<AirlinesWithPagination> GetAllFilialesWithPaginationAsync(System.Guid masterID, UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetMailAddressWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetMailAddressWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetMailAddressWithPaginationFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        MailAddressWithPagination GetMailAddressWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetMailAddressWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetMailAddressWithPaginationResponse")]
        System.Threading.Tasks.Task<MailAddressWithPagination> GetMailAddressWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetManagerWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetManagerWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetManagerWithPaginationFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ManagerWithPagination GetManagerWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetManagerWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetManagerWithPaginationResponse")]
        System.Threading.Tasks.Task<ManagerWithPagination> GetManagerWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetManufacturerWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetManufacturerWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetManufacturerWithPaginationFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ManufacturerWithPagination GetManufacturerWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetManufacturerWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetManufacturerWithPaginationResponse")]
        System.Threading.Tasks.Task<ManufacturerWithPagination> GetManufacturerWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetOperatorWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetOperatorWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetOperatorWithPaginationFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        OperatorWithPagination GetOperatorWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetOperatorWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetOperatorWithPaginationResponse")]
        System.Threading.Tasks.Task<OperatorWithPagination> GetOperatorWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetOwnerWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetOwnerWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetOwnerWithPaginationFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        OwnerWithPagination GetOwnerWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetOwnerWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetOwnerWithPaginationResponse")]
        System.Threading.Tasks.Task<OwnerWithPagination> GetOwnerWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetXmlSettingWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetXmlSettingWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetXmlSettingWithPaginationFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        XmlSettingWithPagination GetXmlSettingWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetXmlSettingWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetXmlSettingWithPaginationResponse")]
        System.Threading.Tasks.Task<XmlSettingWithPagination> GetXmlSettingWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetManufacturerDTOByManufacturerID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetManufacturerDTOByManufacturerIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetManufacturerDTOByManufacturerIDFaultDataF" +
            "ault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ManufacturerDataObject GetManufacturerDTOByManufacturerID(System.Guid manufacturerId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetManufacturerDTOByManufacturerID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetManufacturerDTOByManufacturerIDResponse")]
        System.Threading.Tasks.Task<ManufacturerDataObject> GetManufacturerDTOByManufacturerIDAsync(System.Guid manufacturerId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetManufacturerDTOByOwnerID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetManufacturerDTOByOwnerIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetManufacturerDTOByOwnerIDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ManufacturerDataObject GetManufacturerDTOByOwnerID(System.Guid ownerId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetManufacturerDTOByOwnerID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetManufacturerDTOByOwnerIDResponse")]
        System.Threading.Tasks.Task<ManufacturerDataObject> GetManufacturerDTOByOwnerIDAsync(System.Guid ownerId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAircraftTypeDTOListByManufacturerID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAircraftTypeDTOListByManufacturerIDRespon" +
            "se")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAircraftTypeDTOListByManufacturerIDFaultD" +
            "ataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AircraftTypeDataObjectList GetAircraftTypeDTOListByManufacturerID(System.Guid manufacturerId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAircraftTypeDTOListByManufacturerID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAircraftTypeDTOListByManufacturerIDRespon" +
            "se")]
        System.Threading.Tasks.Task<AircraftTypeDataObjectList> GetAircraftTypeDTOListByManufacturerIDAsync(System.Guid manufacturerId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllNDRCApprovalDocDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllNDRCApprovalDocDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllNDRCApprovalDocDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        NDRCApprovalDocDataObjectList GetAllNDRCApprovalDocDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllNDRCApprovalDocDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllNDRCApprovalDocDTOResponse")]
        System.Threading.Tasks.Task<NDRCApprovalDocDataObjectList> GetAllNDRCApprovalDocDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetNDRCApprovalDocDTOByNDRCApprovalDocID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetNDRCApprovalDocDTOByNDRCApprovalDocIDResp" +
            "onse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetNDRCApprovalDocDTOByNDRCApprovalDocIDFaul" +
            "tDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        NDRCApprovalDocDataObject GetNDRCApprovalDocDTOByNDRCApprovalDocID(System.Guid ndrcRaApprovalDocId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetNDRCApprovalDocDTOByNDRCApprovalDocID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetNDRCApprovalDocDTOByNDRCApprovalDocIDResp" +
            "onse")]
        System.Threading.Tasks.Task<NDRCApprovalDocDataObject> GetNDRCApprovalDocDTOByNDRCApprovalDocIDAsync(System.Guid ndrcRaApprovalDocId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetNDRCRequestDTOListByNDRCApprovalDocID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetNDRCRequestDTOListByNDRCApprovalDocIDResp" +
            "onse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetNDRCRequestDTOListByNDRCApprovalDocIDFaul" +
            "tDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        NDRCRequestDataObjectList GetNDRCRequestDTOListByNDRCApprovalDocID(System.Guid ndrcRaApprovalDocId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetNDRCRequestDTOListByNDRCApprovalDocID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetNDRCRequestDTOListByNDRCApprovalDocIDResp" +
            "onse")]
        System.Threading.Tasks.Task<NDRCRequestDataObjectList> GetNDRCRequestDTOListByNDRCApprovalDocIDAsync(System.Guid ndrcRaApprovalDocId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitNDRCApprovalDocDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitNDRCApprovalDocDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/CommitNDRCApprovalDocDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        NDRCApprovalDocResultData CommitNDRCApprovalDocDTO(NDRCApprovalDocResultData ndrcApprovalDocData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitNDRCApprovalDocDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitNDRCApprovalDocDTOResponse")]
        System.Threading.Tasks.Task<NDRCApprovalDocResultData> CommitNDRCApprovalDocDTOAsync(NDRCApprovalDocResultData ndrcApprovalDocData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllNDRCApprovalHistoryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllNDRCApprovalHistoryDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllNDRCApprovalHistoryDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        NDRCApprovalHistoryDataObjectList GetAllNDRCApprovalHistoryDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllNDRCApprovalHistoryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllNDRCApprovalHistoryDTOResponse")]
        System.Threading.Tasks.Task<NDRCApprovalHistoryDataObjectList> GetAllNDRCApprovalHistoryDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetNDRCApprovalHistoryDTOByNDRCApprovalHisto" +
            "ryID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetNDRCApprovalHistoryDTOByNDRCApprovalHisto" +
            "ryIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetNDRCApprovalHistoryDTOByNDRCApprovalHisto" +
            "ryIDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        NDRCApprovalHistoryDataObject GetNDRCApprovalHistoryDTOByNDRCApprovalHistoryID(System.Guid ndrcApprovalHistoryId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetNDRCApprovalHistoryDTOByNDRCApprovalHisto" +
            "ryID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetNDRCApprovalHistoryDTOByNDRCApprovalHisto" +
            "ryIDResponse")]
        System.Threading.Tasks.Task<NDRCApprovalHistoryDataObject> GetNDRCApprovalHistoryDTOByNDRCApprovalHistoryIDAsync(System.Guid ndrcApprovalHistoryId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetNDRCApprovalHistoryDTOListByPlanAircraftI" +
            "D", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetNDRCApprovalHistoryDTOListByPlanAircraftI" +
            "DResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetNDRCApprovalHistoryDTOListByPlanAircraftI" +
            "DFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        NDRCApprovalHistoryDataObjectList GetNDRCApprovalHistoryDTOListByPlanAircraftID(System.Guid planAircraftId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetNDRCApprovalHistoryDTOListByPlanAircraftI" +
            "D", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetNDRCApprovalHistoryDTOListByPlanAircraftI" +
            "DResponse")]
        System.Threading.Tasks.Task<NDRCApprovalHistoryDataObjectList> GetNDRCApprovalHistoryDTOListByPlanAircraftIDAsync(System.Guid planAircraftId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllNDRCRequestDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllNDRCRequestDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllNDRCRequestDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        NDRCRequestDataObjectList GetAllNDRCRequestDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllNDRCRequestDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllNDRCRequestDTOResponse")]
        System.Threading.Tasks.Task<NDRCRequestDataObjectList> GetAllNDRCRequestDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetNDRCRequestDTOByNDRCRequestID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetNDRCRequestDTOByNDRCRequestIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetNDRCRequestDTOByNDRCRequestIDFaultDataFau" +
            "lt", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        NDRCRequestDataObject GetNDRCRequestDTOByNDRCRequestID(System.Guid ndrcRequestId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetNDRCRequestDTOByNDRCRequestID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetNDRCRequestDTOByNDRCRequestIDResponse")]
        System.Threading.Tasks.Task<NDRCRequestDataObject> GetNDRCRequestDTOByNDRCRequestIDAsync(System.Guid ndrcRequestId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetNDRCApprovalHistoryDTOListByNDRCRequestID" +
            "", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetNDRCApprovalHistoryDTOListByNDRCRequestID" +
            "Response")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetNDRCApprovalHistoryDTOListByNDRCRequestID" +
            "FaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        NDRCApprovalHistoryDataObjectList GetNDRCApprovalHistoryDTOListByNDRCRequestID(System.Guid ndrcRequestId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetNDRCApprovalHistoryDTOListByNDRCRequestID" +
            "", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetNDRCApprovalHistoryDTOListByNDRCRequestID" +
            "Response")]
        System.Threading.Tasks.Task<NDRCApprovalHistoryDataObjectList> GetNDRCApprovalHistoryDTOListByNDRCRequestIDAsync(System.Guid ndrcRequestId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitNDRCRequestDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitNDRCRequestDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/CommitNDRCRequestDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        NDRCRequestResultData CommitNDRCRequestDTO(NDRCRequestResultData ndrcRequestData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitNDRCRequestDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitNDRCRequestDTOResponse")]
        System.Threading.Tasks.Task<NDRCRequestResultData> CommitNDRCRequestDTOAsync(NDRCRequestResultData ndrcRequestData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllOperationHistoryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllOperationHistoryDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllOperationHistoryDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        OperationHistoryDataObjectList GetAllOperationHistoryDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllOperationHistoryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllOperationHistoryDTOResponse")]
        System.Threading.Tasks.Task<OperationHistoryDataObjectList> GetAllOperationHistoryDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetOperationHistoryDTOByOperationHistoryID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetOperationHistoryDTOByOperationHistoryIDRe" +
            "sponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetOperationHistoryDTOByOperationHistoryIDFa" +
            "ultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        OperationHistoryDataObject GetOperationHistoryDTOByOperationHistoryID(System.Guid operationHistoryId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetOperationHistoryDTOByOperationHistoryID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetOperationHistoryDTOByOperationHistoryIDRe" +
            "sponse")]
        System.Threading.Tasks.Task<OperationHistoryDataObject> GetOperationHistoryDTOByOperationHistoryIDAsync(System.Guid operationHistoryId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetSubOperationHistoryDTOListByOperationHist" +
            "oryID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetSubOperationHistoryDTOListByOperationHist" +
            "oryIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetSubOperationHistoryDTOListByOperationHist" +
            "oryIDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        SubOperationHistoryDataObjectList GetSubOperationHistoryDTOListByOperationHistoryID(System.Guid operationHistoryId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetSubOperationHistoryDTOListByOperationHist" +
            "oryID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetSubOperationHistoryDTOListByOperationHist" +
            "oryIDResponse")]
        System.Threading.Tasks.Task<SubOperationHistoryDataObjectList> GetSubOperationHistoryDTOListByOperationHistoryIDAsync(System.Guid operationHistoryId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllOwnerDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllOwnerDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllOwnerDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        OwnerDataObjectList GetAllOwnerDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllOwnerDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllOwnerDTOResponse")]
        System.Threading.Tasks.Task<OwnerDataObjectList> GetAllOwnerDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetOwnerDTOByOwnerID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetOwnerDTOByOwnerIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetOwnerDTOByOwnerIDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        OwnerDataObject GetOwnerDTOByOwnerID(System.Guid ownerId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetOwnerDTOByOwnerID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetOwnerDTOByOwnerIDResponse")]
        System.Threading.Tasks.Task<OwnerDataObject> GetOwnerDTOByOwnerIDAsync(System.Guid ownerId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetOwnershipHistoryDTOListBySupplierID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetOwnershipHistoryDTOListBySupplierIDRespon" +
            "se")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetOwnershipHistoryDTOListBySupplierIDFaultD" +
            "ataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        OwnershipHistoryDataObjectList GetOwnershipHistoryDTOListBySupplierID(System.Guid ownerId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetOwnershipHistoryDTOListBySupplierID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetOwnershipHistoryDTOListBySupplierIDRespon" +
            "se")]
        System.Threading.Tasks.Task<OwnershipHistoryDataObjectList> GetOwnershipHistoryDTOListBySupplierIDAsync(System.Guid ownerId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitOwnerDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitOwnerDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/CommitOwnerDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        OwnerResultData CommitOwnerDTO(OwnerResultData ownerData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitOwnerDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitOwnerDTOResponse")]
        System.Threading.Tasks.Task<OwnerResultData> CommitOwnerDTOAsync(OwnerResultData ownerData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllOwnershipHistoryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllOwnershipHistoryDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllOwnershipHistoryDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        OwnershipHistoryDataObjectList GetAllOwnershipHistoryDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllOwnershipHistoryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllOwnershipHistoryDTOResponse")]
        System.Threading.Tasks.Task<OwnershipHistoryDataObjectList> GetAllOwnershipHistoryDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetOwnershipHistoryDTOByOwnershipHistoryID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetOwnershipHistoryDTOByOwnershipHistoryIDRe" +
            "sponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetOwnershipHistoryDTOByOwnershipHistoryIDFa" +
            "ultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        OwnershipHistoryDataObject GetOwnershipHistoryDTOByOwnershipHistoryID(System.Guid ownershipHistoryId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetOwnershipHistoryDTOByOwnershipHistoryID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetOwnershipHistoryDTOByOwnershipHistoryIDRe" +
            "sponse")]
        System.Threading.Tasks.Task<OwnershipHistoryDataObject> GetOwnershipHistoryDTOByOwnershipHistoryIDAsync(System.Guid ownershipHistoryId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetOwnershipHistoryDTOListByAircraftID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetOwnershipHistoryDTOListByAircraftIDRespon" +
            "se")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetOwnershipHistoryDTOListByAircraftIDFaultD" +
            "ataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        OwnershipHistoryDataObjectList GetOwnershipHistoryDTOListByAircraftID(System.Guid aircraftId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetOwnershipHistoryDTOListByAircraftID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetOwnershipHistoryDTOListByAircraftIDRespon" +
            "se")]
        System.Threading.Tasks.Task<OwnershipHistoryDataObjectList> GetOwnershipHistoryDTOListByAircraftIDAsync(System.Guid aircraftId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllPlanAircraftDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllPlanAircraftDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllPlanAircraftDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        PlanAircraftDataObjectList GetAllPlanAircraftDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllPlanAircraftDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllPlanAircraftDTOResponse")]
        System.Threading.Tasks.Task<PlanAircraftDataObjectList> GetAllPlanAircraftDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPlanAircraftDTOByPlanAircraftID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPlanAircraftDTOByPlanAircraftIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetPlanAircraftDTOByPlanAircraftIDFaultDataF" +
            "ault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        PlanAircraftDataObject GetPlanAircraftDTOByPlanAircraftID(System.Guid planAircraftId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPlanAircraftDTOByPlanAircraftID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPlanAircraftDTOByPlanAircraftIDResponse")]
        System.Threading.Tasks.Task<PlanAircraftDataObject> GetPlanAircraftDTOByPlanAircraftIDAsync(System.Guid planAircraftId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPlanHistoryDTOListByPlanAircraftID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPlanHistoryDTOListByPlanAircraftIDRespons" +
            "e")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetPlanHistoryDTOListByPlanAircraftIDFaultDa" +
            "taFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        PlanHistoryDataObjectList GetPlanHistoryDTOListByPlanAircraftID(System.Guid planAircraftId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPlanHistoryDTOListByPlanAircraftID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPlanHistoryDTOListByPlanAircraftIDRespons" +
            "e")]
        System.Threading.Tasks.Task<PlanHistoryDataObjectList> GetPlanHistoryDTOListByPlanAircraftIDAsync(System.Guid planAircraftId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitPlanAircraftDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitPlanAircraftDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/CommitPlanAircraftDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        PlanAircraftResultData CommitPlanAircraftDTO(PlanAircraftResultData planAircraftData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitPlanAircraftDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitPlanAircraftDTOResponse")]
        System.Threading.Tasks.Task<PlanAircraftResultData> CommitPlanAircraftDTOAsync(PlanAircraftResultData planAircraftData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllPlanDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllPlanDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllPlanDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        PlanDataObjectList GetAllPlanDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllPlanDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllPlanDTOResponse")]
        System.Threading.Tasks.Task<PlanDataObjectList> GetAllPlanDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPlanDTOByPlanID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPlanDTOByPlanIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetPlanDTOByPlanIDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        PlanDataObject GetPlanDTOByPlanID(System.Guid planId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPlanDTOByPlanID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPlanDTOByPlanIDResponse")]
        System.Threading.Tasks.Task<PlanDataObject> GetPlanDTOByPlanIDAsync(System.Guid planId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPlanDTOListByAnnualID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPlanDTOListByAnnualIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetPlanDTOListByAnnualIDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        PlanDataObjectList GetPlanDTOListByAnnualID(System.Guid annualId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPlanDTOListByAnnualID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPlanDTOListByAnnualIDResponse")]
        System.Threading.Tasks.Task<PlanDataObjectList> GetPlanDTOListByAnnualIDAsync(System.Guid annualId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPlanHistoryDTOListByPlanID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPlanHistoryDTOListByPlanIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetPlanHistoryDTOListByPlanIDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        PlanHistoryDataObjectList GetPlanHistoryDTOListByPlanID(System.Guid planId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPlanHistoryDTOListByPlanID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPlanHistoryDTOListByPlanIDResponse")]
        System.Threading.Tasks.Task<PlanHistoryDataObjectList> GetPlanHistoryDTOListByPlanIDAsync(System.Guid planId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetCurrentPlanDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetCurrentPlanDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetCurrentPlanDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        PlanDataObject GetCurrentPlanDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetCurrentPlanDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetCurrentPlanDTOResponse")]
        System.Threading.Tasks.Task<PlanDataObject> GetCurrentPlanDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitPlanDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitPlanDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/CommitPlanDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        PlanResultData CommitPlanDTO(PlanResultData planData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitPlanDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitPlanDTOResponse")]
        System.Threading.Tasks.Task<PlanResultData> CommitPlanDTOAsync(PlanResultData planData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllPlanEngineDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllPlanEngineDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllPlanEngineDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        PlanEngineDataObjectList GetAllPlanEngineDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllPlanEngineDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllPlanEngineDTOResponse")]
        System.Threading.Tasks.Task<PlanEngineDataObjectList> GetAllPlanEngineDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPlanEngineDTOByPlanEngineID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPlanEngineDTOByPlanEngineIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetPlanEngineDTOByPlanEngineIDFaultDataFault" +
            "", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        PlanEngineDataObject GetPlanEngineDTOByPlanEngineID(System.Guid planEngineId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPlanEngineDTOByPlanEngineID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPlanEngineDTOByPlanEngineIDResponse")]
        System.Threading.Tasks.Task<PlanEngineDataObject> GetPlanEngineDTOByPlanEngineIDAsync(System.Guid planEngineId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEnginePlanHistoryDTOListByPlanEngineID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEnginePlanHistoryDTOListByPlanEngineIDRes" +
            "ponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetEnginePlanHistoryDTOListByPlanEngineIDFau" +
            "ltDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        EnginePlanHistoryDataObjectList GetEnginePlanHistoryDTOListByPlanEngineID(System.Guid planEngineId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEnginePlanHistoryDTOListByPlanEngineID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEnginePlanHistoryDTOListByPlanEngineIDRes" +
            "ponse")]
        System.Threading.Tasks.Task<EnginePlanHistoryDataObjectList> GetEnginePlanHistoryDTOListByPlanEngineIDAsync(System.Guid planEngineId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitPlanEngineDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitPlanEngineDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/CommitPlanEngineDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        PlanEngineResultData CommitPlanEngineDTO(PlanEngineResultData planEngineData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitPlanEngineDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitPlanEngineDTOResponse")]
        System.Threading.Tasks.Task<PlanEngineResultData> CommitPlanEngineDTOAsync(PlanEngineResultData planEngineData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllProgrammingDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllProgrammingDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllProgrammingDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ProgrammingDataObjectList GetAllProgrammingDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllProgrammingDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllProgrammingDTOResponse")]
        System.Threading.Tasks.Task<ProgrammingDataObjectList> GetAllProgrammingDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetProgrammingDTOByProgrammingID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetProgrammingDTOByProgrammingIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetProgrammingDTOByProgrammingIDFaultDataFau" +
            "lt", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ProgrammingDataObject GetProgrammingDTOByProgrammingID(System.Guid programmingId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetProgrammingDTOByProgrammingID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetProgrammingDTOByProgrammingIDResponse")]
        System.Threading.Tasks.Task<ProgrammingDataObject> GetProgrammingDTOByProgrammingIDAsync(System.Guid programmingId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllCAACProgrammingDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllCAACProgrammingDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllCAACProgrammingDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        CAACProgrammingDataObjectList GetAllCAACProgrammingDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllCAACProgrammingDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllCAACProgrammingDTOResponse")]
        System.Threading.Tasks.Task<CAACProgrammingDataObjectList> GetAllCAACProgrammingDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetCAACProgrammingDTOByCaacProgrammingID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetCAACProgrammingDTOByCaacProgrammingIDResp" +
            "onse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetCAACProgrammingDTOByCaacProgrammingIDFaul" +
            "tDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        CAACProgrammingDataObject GetCAACProgrammingDTOByCaacProgrammingID(System.Guid caacProgrammingID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetCAACProgrammingDTOByCaacProgrammingID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetCAACProgrammingDTOByCaacProgrammingIDResp" +
            "onse")]
        System.Threading.Tasks.Task<CAACProgrammingDataObject> GetCAACProgrammingDTOByCaacProgrammingIDAsync(System.Guid caacProgrammingID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetCAACProgrammingDetailDTOListByCaacProgram" +
            "mingID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetCAACProgrammingDetailDTOListByCaacProgram" +
            "mingIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetCAACProgrammingDetailDTOListByCaacProgram" +
            "mingIDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        CAACProgrammingDetailDataObjectList GetCAACProgrammingDetailDTOListByCaacProgrammingID(System.Guid caacProgrammingId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetCAACProgrammingDetailDTOListByCaacProgram" +
            "mingID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetCAACProgrammingDetailDTOListByCaacProgram" +
            "mingIDResponse")]
        System.Threading.Tasks.Task<CAACProgrammingDetailDataObjectList> GetCAACProgrammingDetailDTOListByCaacProgrammingIDAsync(System.Guid caacProgrammingId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitCAACProgrammingDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitCAACProgrammingDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/CommitCAACProgrammingDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        CAACProgrammingResultData CommitCAACProgrammingDTO(CAACProgrammingResultData caacProgrammingData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitCAACProgrammingDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitCAACProgrammingDTOResponse")]
        System.Threading.Tasks.Task<CAACProgrammingResultData> CommitCAACProgrammingDTOAsync(CAACProgrammingResultData caacProgrammingData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllRAApprovalDocDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllRAApprovalDocDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllRAApprovalDocDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        RAApprovalDocDataObjectList GetAllRAApprovalDocDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllRAApprovalDocDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllRAApprovalDocDTOResponse")]
        System.Threading.Tasks.Task<RAApprovalDocDataObjectList> GetAllRAApprovalDocDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetRAApprovalDocDTOByRAApprovalDocID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetRAApprovalDocDTOByRAApprovalDocIDResponse" +
            "")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetRAApprovalDocDTOByRAApprovalDocIDFaultDat" +
            "aFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        RAApprovalDocDataObject GetRAApprovalDocDTOByRAApprovalDocID(System.Guid raApprovalDocId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetRAApprovalDocDTOByRAApprovalDocID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetRAApprovalDocDTOByRAApprovalDocIDResponse" +
            "")]
        System.Threading.Tasks.Task<RAApprovalDocDataObject> GetRAApprovalDocDTOByRAApprovalDocIDAsync(System.Guid raApprovalDocId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetRARequestDTOListByRAApprovalDocID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetRARequestDTOListByRAApprovalDocIDResponse" +
            "")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetRARequestDTOListByRAApprovalDocIDFaultDat" +
            "aFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        RARequestDataObjectList GetRARequestDTOListByRAApprovalDocID(System.Guid raApprovalDocId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetRARequestDTOListByRAApprovalDocID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetRARequestDTOListByRAApprovalDocIDResponse" +
            "")]
        System.Threading.Tasks.Task<RARequestDataObjectList> GetRARequestDTOListByRAApprovalDocIDAsync(System.Guid raApprovalDocId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitRAApprovalDocDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitRAApprovalDocDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/CommitRAApprovalDocDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        RAApprovalDocResultData CommitRAApprovalDocDTO(RAApprovalDocResultData raApprovalDocData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitRAApprovalDocDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitRAApprovalDocDTOResponse")]
        System.Threading.Tasks.Task<RAApprovalDocResultData> CommitRAApprovalDocDTOAsync(RAApprovalDocResultData raApprovalDocData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllRAApprovalHistoryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllRAApprovalHistoryDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllRAApprovalHistoryDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        RAApprovalHistoryDataObjectList GetAllRAApprovalHistoryDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllRAApprovalHistoryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllRAApprovalHistoryDTOResponse")]
        System.Threading.Tasks.Task<RAApprovalHistoryDataObjectList> GetAllRAApprovalHistoryDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetRAApprovalHistoryDTOByRAApprovalHistoryID" +
            "", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetRAApprovalHistoryDTOByRAApprovalHistoryID" +
            "Response")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetRAApprovalHistoryDTOByRAApprovalHistoryID" +
            "FaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        RAApprovalHistoryDataObject GetRAApprovalHistoryDTOByRAApprovalHistoryID(System.Guid raApprovalHistoryId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetRAApprovalHistoryDTOByRAApprovalHistoryID" +
            "", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetRAApprovalHistoryDTOByRAApprovalHistoryID" +
            "Response")]
        System.Threading.Tasks.Task<RAApprovalHistoryDataObject> GetRAApprovalHistoryDTOByRAApprovalHistoryIDAsync(System.Guid raApprovalHistoryId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetRAApprovalHistoryDTOListByPlanAircraftID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetRAApprovalHistoryDTOListByPlanAircraftIDR" +
            "esponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetRAApprovalHistoryDTOListByPlanAircraftIDF" +
            "aultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        RAApprovalHistoryDataObjectList GetRAApprovalHistoryDTOListByPlanAircraftID(System.Guid planAircraftId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetRAApprovalHistoryDTOListByPlanAircraftID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetRAApprovalHistoryDTOListByPlanAircraftIDR" +
            "esponse")]
        System.Threading.Tasks.Task<RAApprovalHistoryDataObjectList> GetRAApprovalHistoryDTOListByPlanAircraftIDAsync(System.Guid planAircraftId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllRARequestDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllRARequestDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllRARequestDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        RARequestDataObjectList GetAllRARequestDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllRARequestDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllRARequestDTOResponse")]
        System.Threading.Tasks.Task<RARequestDataObjectList> GetAllRARequestDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetRARequestDTOByRARequestID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetRARequestDTOByRARequestIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetRARequestDTOByRARequestIDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        RARequestDataObject GetRARequestDTOByRARequestID(System.Guid raRequestId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetRARequestDTOByRARequestID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetRARequestDTOByRARequestIDResponse")]
        System.Threading.Tasks.Task<RARequestDataObject> GetRARequestDTOByRARequestIDAsync(System.Guid raRequestId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetRAApprovalHistoryDTOListByRARequestID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetRAApprovalHistoryDTOListByRARequestIDResp" +
            "onse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetRAApprovalHistoryDTOListByRARequestIDFaul" +
            "tDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        RAApprovalHistoryDataObjectList GetRAApprovalHistoryDTOListByRARequestID(System.Guid raRequestId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetRAApprovalHistoryDTOListByRARequestID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetRAApprovalHistoryDTOListByRARequestIDResp" +
            "onse")]
        System.Threading.Tasks.Task<RAApprovalHistoryDataObjectList> GetRAApprovalHistoryDTOListByRARequestIDAsync(System.Guid raRequestId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitRARequestDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitRARequestDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/CommitRARequestDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        RARequestResultData CommitRARequestDTO(RARequestResultData raRequestData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitRARequestDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitRARequestDTOResponse")]
        System.Threading.Tasks.Task<RARequestResultData> CommitRARequestDTOAsync(RARequestResultData raRequestData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllRequestDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllRequestDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllRequestDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        RequestDataObjectList GetAllRequestDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllRequestDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllRequestDTOResponse")]
        System.Threading.Tasks.Task<RequestDataObjectList> GetAllRequestDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetRequestDTOByRequestID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetRequestDTOByRequestIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetRequestDTOByRequestIDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        RequestDataObject GetRequestDTOByRequestID(System.Guid requestId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetRequestDTOByRequestID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetRequestDTOByRequestIDResponse")]
        System.Threading.Tasks.Task<RequestDataObject> GetRequestDTOByRequestIDAsync(System.Guid requestId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetApprovalHistoryDTOListByRequestID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetApprovalHistoryDTOListByRequestIDResponse" +
            "")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetApprovalHistoryDTOListByRequestIDFaultDat" +
            "aFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ApprovalHistoryDataObjectList GetApprovalHistoryDTOListByRequestID(System.Guid requestId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetApprovalHistoryDTOListByRequestID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetApprovalHistoryDTOListByRequestIDResponse" +
            "")]
        System.Threading.Tasks.Task<ApprovalHistoryDataObjectList> GetApprovalHistoryDTOListByRequestIDAsync(System.Guid requestId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitRequestDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitRequestDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/CommitRequestDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        RequestResultData CommitRequestDTO(RequestResultData requestData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitRequestDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitRequestDTOResponse")]
        System.Threading.Tasks.Task<RequestResultData> CommitRequestDTOAsync(RequestResultData requestData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllSAWSApprovalDocDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllSAWSApprovalDocDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllSAWSApprovalDocDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        SAWSApprovalDocDataObjectList GetAllSAWSApprovalDocDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllSAWSApprovalDocDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllSAWSApprovalDocDTOResponse")]
        System.Threading.Tasks.Task<SAWSApprovalDocDataObjectList> GetAllSAWSApprovalDocDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetSAWSApprovalDocDTOBySAWSApprovalDocID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetSAWSApprovalDocDTOBySAWSApprovalDocIDResp" +
            "onse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetSAWSApprovalDocDTOBySAWSApprovalDocIDFaul" +
            "tDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        SAWSApprovalDocDataObject GetSAWSApprovalDocDTOBySAWSApprovalDocID(System.Guid sawspprovalDocId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetSAWSApprovalDocDTOBySAWSApprovalDocID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetSAWSApprovalDocDTOBySAWSApprovalDocIDResp" +
            "onse")]
        System.Threading.Tasks.Task<SAWSApprovalDocDataObject> GetSAWSApprovalDocDTOBySAWSApprovalDocIDAsync(System.Guid sawspprovalDocId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetSAWSRequestDTOListBySAWSApprovalDocID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetSAWSRequestDTOListBySAWSApprovalDocIDResp" +
            "onse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetSAWSRequestDTOListBySAWSApprovalDocIDFaul" +
            "tDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        SAWSRequestDataObjectList GetSAWSRequestDTOListBySAWSApprovalDocID(System.Guid sawspprovalDocId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetSAWSRequestDTOListBySAWSApprovalDocID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetSAWSRequestDTOListBySAWSApprovalDocIDResp" +
            "onse")]
        System.Threading.Tasks.Task<SAWSRequestDataObjectList> GetSAWSRequestDTOListBySAWSApprovalDocIDAsync(System.Guid sawspprovalDocId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitSAWSApprovalDocDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitSAWSApprovalDocDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/CommitSAWSApprovalDocDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        SAWSApprovalDocResultData CommitSAWSApprovalDocDTO(SAWSApprovalDocResultData sawsApprovalDocData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitSAWSApprovalDocDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitSAWSApprovalDocDTOResponse")]
        System.Threading.Tasks.Task<SAWSApprovalDocResultData> CommitSAWSApprovalDocDTOAsync(SAWSApprovalDocResultData sawsApprovalDocData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllSAWSApprovalHistoryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllSAWSApprovalHistoryDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllSAWSApprovalHistoryDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        SAWSApprovalHistoryDataObjectList GetAllSAWSApprovalHistoryDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllSAWSApprovalHistoryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllSAWSApprovalHistoryDTOResponse")]
        System.Threading.Tasks.Task<SAWSApprovalHistoryDataObjectList> GetAllSAWSApprovalHistoryDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetSAWSApprovalHistoryDTOBySAWSApprovalHisto" +
            "ryID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetSAWSApprovalHistoryDTOBySAWSApprovalHisto" +
            "ryIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetSAWSApprovalHistoryDTOBySAWSApprovalHisto" +
            "ryIDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        SAWSApprovalHistoryDataObject GetSAWSApprovalHistoryDTOBySAWSApprovalHistoryID(System.Guid sawsApprovalHistoryId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetSAWSApprovalHistoryDTOBySAWSApprovalHisto" +
            "ryID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetSAWSApprovalHistoryDTOBySAWSApprovalHisto" +
            "ryIDResponse")]
        System.Threading.Tasks.Task<SAWSApprovalHistoryDataObject> GetSAWSApprovalHistoryDTOBySAWSApprovalHistoryIDAsync(System.Guid sawsApprovalHistoryId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetSAWSApprovalHistoryDTOListByPlanAircraftI" +
            "D", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetSAWSApprovalHistoryDTOListByPlanAircraftI" +
            "DResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetSAWSApprovalHistoryDTOListByPlanAircraftI" +
            "DFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        SAWSApprovalHistoryDataObjectList GetSAWSApprovalHistoryDTOListByPlanAircraftID(System.Guid planAircraftId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetSAWSApprovalHistoryDTOListByPlanAircraftI" +
            "D", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetSAWSApprovalHistoryDTOListByPlanAircraftI" +
            "DResponse")]
        System.Threading.Tasks.Task<SAWSApprovalHistoryDataObjectList> GetSAWSApprovalHistoryDTOListByPlanAircraftIDAsync(System.Guid planAircraftId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllSAWSRequestDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllSAWSRequestDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllSAWSRequestDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        SAWSRequestDataObjectList GetAllSAWSRequestDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllSAWSRequestDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllSAWSRequestDTOResponse")]
        System.Threading.Tasks.Task<SAWSRequestDataObjectList> GetAllSAWSRequestDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetSAWSRequestDTOBySAWSRequestID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetSAWSRequestDTOBySAWSRequestIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetSAWSRequestDTOBySAWSRequestIDFaultDataFau" +
            "lt", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        SAWSRequestDataObject GetSAWSRequestDTOBySAWSRequestID(System.Guid sawsRequestId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetSAWSRequestDTOBySAWSRequestID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetSAWSRequestDTOBySAWSRequestIDResponse")]
        System.Threading.Tasks.Task<SAWSRequestDataObject> GetSAWSRequestDTOBySAWSRequestIDAsync(System.Guid sawsRequestId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetSAWSApprovalHistoryDTOListBySAWSRequestID" +
            "", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetSAWSApprovalHistoryDTOListBySAWSRequestID" +
            "Response")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetSAWSApprovalHistoryDTOListBySAWSRequestID" +
            "FaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        SAWSApprovalHistoryDataObjectList GetSAWSApprovalHistoryDTOListBySAWSRequestID(System.Guid sawsRequestId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetSAWSApprovalHistoryDTOListBySAWSRequestID" +
            "", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetSAWSApprovalHistoryDTOListBySAWSRequestID" +
            "Response")]
        System.Threading.Tasks.Task<SAWSApprovalHistoryDataObjectList> GetSAWSApprovalHistoryDTOListBySAWSRequestIDAsync(System.Guid sawsRequestId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitSAWSRequestDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitSAWSRequestDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/CommitSAWSRequestDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        SAWSRequestResultData CommitSAWSRequestDTO(SAWSRequestResultData sawsRequestData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitSAWSRequestDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitSAWSRequestDTOResponse")]
        System.Threading.Tasks.Task<SAWSRequestResultData> CommitSAWSRequestDTOAsync(SAWSRequestResultData sawsRequestData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetSubOperationHistoryDTOList", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetSubOperationHistoryDTOListResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetSubOperationHistoryDTOListFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        SubOperationHistoryDataObjectList GetSubOperationHistoryDTOList();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetSubOperationHistoryDTOList", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetSubOperationHistoryDTOListResponse")]
        System.Threading.Tasks.Task<SubOperationHistoryDataObjectList> GetSubOperationHistoryDTOListAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAcRegByContractRank", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAcRegByContractRankResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAcRegByContractRankFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        string GetAcRegByContractRank(string contractNum, int rankNumber);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAcRegByContractRank", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAcRegByContractRankResponse")]
        System.Threading.Tasks.Task<string> GetAcRegByContractRankAsync(string contractNum, int rankNumber);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/ValidationByContractRank", ReplyAction = "http://www.UniCloud.com/IAFRPService/ValidationByContractRankResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/ValidationByContractRankFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        bool ValidationByContractRank(string contractNum, int rankNumber);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/ValidationByContractRank", ReplyAction = "http://www.UniCloud.com/IAFRPService/ValidationByContractRankResponse")]
        System.Threading.Tasks.Task<bool> ValidationByContractRankAsync(string contractNum, int rankNumber);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetActionCategoryWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetActionCategoryWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetActionCategoryWithPaginationFaultDataFaul" +
            "t", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ActionCategoryWithPagination GetActionCategoryWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetActionCategoryWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetActionCategoryWithPaginationResponse")]
        System.Threading.Tasks.Task<ActionCategoryWithPagination> GetActionCategoryWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAircraftCategoryWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAircraftCategoryWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAircraftCategoryWithPaginationFaultDataFa" +
            "ult", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AircraftCategoryWithPagination GetAircraftCategoryWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAircraftCategoryWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAircraftCategoryWithPaginationResponse")]
        System.Threading.Tasks.Task<AircraftCategoryWithPagination> GetAircraftCategoryWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAircraftWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAircraftWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAircraftWithPaginationFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AircraftWithPagination GetAircraftWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAircraftWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAircraftWithPaginationResponse")]
        System.Threading.Tasks.Task<AircraftWithPagination> GetAircraftWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAircraftTypeWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAircraftTypeWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAircraftTypeWithPaginationFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AircraftTypeWithPagination GetAircraftTypeWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAircraftTypeWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAircraftTypeWithPaginationResponse")]
        System.Threading.Tasks.Task<AircraftTypeWithPagination> GetAircraftTypeWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAirlineProgrammingWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAirlineProgrammingWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAirlineProgrammingWithPaginationFaultData" +
            "Fault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AirlineProgrammingWithPagination GetAirlineProgrammingWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAirlineProgrammingWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAirlineProgrammingWithPaginationResponse")]
        System.Threading.Tasks.Task<AirlineProgrammingWithPagination> GetAirlineProgrammingWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAnnualSummaryWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAnnualSummaryWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAnnualSummaryWithPaginationFaultDataFault" +
            "", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AnnualSummaryWithPagination GetAnnualSummaryWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAnnualSummaryWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAnnualSummaryWithPaginationResponse")]
        System.Threading.Tasks.Task<AnnualSummaryWithPagination> GetAnnualSummaryWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetApprovalDocWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetApprovalDocWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetApprovalDocWithPaginationFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ApprovalDocWithPagination GetApprovalDocWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetApprovalDocWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetApprovalDocWithPaginationResponse")]
        System.Threading.Tasks.Task<ApprovalDocWithPagination> GetApprovalDocWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetCAACProgrammingWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetCAACProgrammingWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetCAACProgrammingWithPaginationFaultDataFau" +
            "lt", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        CAACProgrammingWithPagination GetCAACProgrammingWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetCAACProgrammingWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetCAACProgrammingWithPaginationResponse")]
        System.Threading.Tasks.Task<CAACProgrammingWithPagination> GetCAACProgrammingWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEnginePlanWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEnginePlanWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetEnginePlanWithPaginationFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        EnginePlanWithPagination GetEnginePlanWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEnginePlanWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEnginePlanWithPaginationResponse")]
        System.Threading.Tasks.Task<EnginePlanWithPagination> GetEnginePlanWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEngineWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEngineWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetEngineWithPaginationFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        EngineWithPagination GetEngineWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEngineWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEngineWithPaginationResponse")]
        System.Threading.Tasks.Task<EngineWithPagination> GetEngineWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEngineTypeWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEngineTypeWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetEngineTypeWithPaginationFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        EngineTypeWithPagination GetEngineTypeWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEngineTypeWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEngineTypeWithPaginationResponse")]
        System.Threading.Tasks.Task<EngineTypeWithPagination> GetEngineTypeWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetNDRCApprovalDocWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetNDRCApprovalDocWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetNDRCApprovalDocWithPaginationFaultDataFau" +
            "lt", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        NDRCApprovalDocWithPagination GetNDRCApprovalDocWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetNDRCApprovalDocWithPagination", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetNDRCApprovalDocWithPaginationResponse")]
        System.Threading.Tasks.Task<NDRCApprovalDocWithPagination> GetNDRCApprovalDocWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllSupplierDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllSupplierDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllSupplierDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        SupplierDataObjectList GetAllSupplierDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllSupplierDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllSupplierDTOResponse")]
        System.Threading.Tasks.Task<SupplierDataObjectList> GetAllSupplierDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetSupplierDTOBySupplierId", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetSupplierDTOBySupplierIdResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetSupplierDTOBySupplierIdFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        SupplierDataObject GetSupplierDTOBySupplierId(System.Guid supplierId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetSupplierDTOBySupplierId", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetSupplierDTOBySupplierIdResponse")]
        System.Threading.Tasks.Task<SupplierDataObject> GetSupplierDTOBySupplierIdAsync(System.Guid supplierId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitSupplierDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitSupplierDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/CommitSupplierDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        SupplierResultData CommitSupplierDTO(SupplierResultData supplierData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitSupplierDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitSupplierDTOResponse")]
        System.Threading.Tasks.Task<SupplierResultData> CommitSupplierDTOAsync(SupplierResultData supplierData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllXmlSettingDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllXmlSettingDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllXmlSettingDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        XmlSettingDataObjectList GetAllXmlSettingDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllXmlSettingDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllXmlSettingDTOResponse")]
        System.Threading.Tasks.Task<XmlSettingDataObjectList> GetAllXmlSettingDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetXmlSettingDTOBySettingType", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetXmlSettingDTOBySettingTypeResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetXmlSettingDTOBySettingTypeFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        XmlSettingDataObject GetXmlSettingDTOBySettingType(string settingType);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetXmlSettingDTOBySettingType", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetXmlSettingDTOBySettingTypeResponse")]
        System.Threading.Tasks.Task<XmlSettingDataObject> GetXmlSettingDTOBySettingTypeAsync(string settingType);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetXmlSettingDTOByXmlSettingID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetXmlSettingDTOByXmlSettingIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetXmlSettingDTOByXmlSettingIDFaultDataFault" +
            "", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        XmlSettingDataObject GetXmlSettingDTOByXmlSettingID(System.Guid xmlSettingID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetXmlSettingDTOByXmlSettingID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetXmlSettingDTOByXmlSettingIDResponse")]
        System.Threading.Tasks.Task<XmlSettingDataObject> GetXmlSettingDTOByXmlSettingIDAsync(System.Guid xmlSettingID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitXmlSettingDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitXmlSettingDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/CommitXmlSettingDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        XmlSettingResultData CommitXmlSettingDTO(XmlSettingResultData XmlSettingData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitXmlSettingDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitXmlSettingDTOResponse")]
        System.Threading.Tasks.Task<XmlSettingResultData> CommitXmlSettingDTOAsync(XmlSettingResultData XmlSettingData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllXmlConfigDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllXmlConfigDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllXmlConfigDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        XmlConfigDataObjectList GetAllXmlConfigDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllXmlConfigDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllXmlConfigDTOResponse")]
        System.Threading.Tasks.Task<XmlConfigDataObjectList> GetAllXmlConfigDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetXmlConfigDTOByConfigType", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetXmlConfigDTOByConfigTypeResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetXmlConfigDTOByConfigTypeFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        XmlConfigDataObject GetXmlConfigDTOByConfigType(string configType);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetXmlConfigDTOByConfigType", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetXmlConfigDTOByConfigTypeResponse")]
        System.Threading.Tasks.Task<XmlConfigDataObject> GetXmlConfigDTOByConfigTypeAsync(string configType);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllActionCategoryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllActionCategoryDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllActionCategoryDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ActionCategoryDataObjectList GetAllActionCategoryDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllActionCategoryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllActionCategoryDTOResponse")]
        System.Threading.Tasks.Task<ActionCategoryDataObjectList> GetAllActionCategoryDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetActionCategoryDTOByActionCategoryID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetActionCategoryDTOByActionCategoryIDRespon" +
            "se")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetActionCategoryDTOByActionCategoryIDFaultD" +
            "ataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ActionCategoryDataObject GetActionCategoryDTOByActionCategoryID(System.Guid actionCategoryId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetActionCategoryDTOByActionCategoryID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetActionCategoryDTOByActionCategoryIDRespon" +
            "se")]
        System.Threading.Tasks.Task<ActionCategoryDataObject> GetActionCategoryDTOByActionCategoryIDAsync(System.Guid actionCategoryId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPurchaseActionCategorys", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPurchaseActionCategorysResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetPurchaseActionCategorysFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ActionCategoryDataObjectList GetPurchaseActionCategorys();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPurchaseActionCategorys", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPurchaseActionCategorysResponse")]
        System.Threading.Tasks.Task<ActionCategoryDataObjectList> GetPurchaseActionCategorysAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetLeaseActionCategorys", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetLeaseActionCategorysResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetLeaseActionCategorysFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ActionCategoryDataObjectList GetLeaseActionCategorys();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetLeaseActionCategorys", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetLeaseActionCategorysResponse")]
        System.Threading.Tasks.Task<ActionCategoryDataObjectList> GetLeaseActionCategorysAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllAircraftBusinessDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllAircraftBusinessDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllAircraftBusinessDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AircraftBusinessDataObjectList GetAllAircraftBusinessDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllAircraftBusinessDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllAircraftBusinessDTOResponse")]
        System.Threading.Tasks.Task<AircraftBusinessDataObjectList> GetAllAircraftBusinessDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAircraftBusinessDTOByAircraftBusinessID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAircraftBusinessDTOByAircraftBusinessIDRe" +
            "sponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAircraftBusinessDTOByAircraftBusinessIDFa" +
            "ultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AircraftBusinessDataObject GetAircraftBusinessDTOByAircraftBusinessID(System.Guid aircraftBusinessId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAircraftBusinessDTOByAircraftBusinessID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAircraftBusinessDTOByAircraftBusinessIDRe" +
            "sponse")]
        System.Threading.Tasks.Task<AircraftBusinessDataObject> GetAircraftBusinessDTOByAircraftBusinessIDAsync(System.Guid aircraftBusinessId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAircraftBusinessDTOListByAircraftID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAircraftBusinessDTOListByAircraftIDRespon" +
            "se")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAircraftBusinessDTOListByAircraftIDFaultD" +
            "ataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AircraftBusinessDataObjectList GetAircraftBusinessDTOListByAircraftID(System.Guid aircraftId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAircraftBusinessDTOListByAircraftID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAircraftBusinessDTOListByAircraftIDRespon" +
            "se")]
        System.Threading.Tasks.Task<AircraftBusinessDataObjectList> GetAircraftBusinessDTOListByAircraftIDAsync(System.Guid aircraftId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllAircraftCategoryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllAircraftCategoryDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllAircraftCategoryDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AircraftCategoryDataObjectList GetAllAircraftCategoryDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllAircraftCategoryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllAircraftCategoryDTOResponse")]
        System.Threading.Tasks.Task<AircraftCategoryDataObjectList> GetAllAircraftCategoryDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAircraftCategoryDTOByAircraftCategoryID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAircraftCategoryDTOByAircraftCategoryIDRe" +
            "sponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAircraftCategoryDTOByAircraftCategoryIDFa" +
            "ultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AircraftCategoryDataObject GetAircraftCategoryDTOByAircraftCategoryID(System.Guid aircraftCategoryID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAircraftCategoryDTOByAircraftCategoryID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAircraftCategoryDTOByAircraftCategoryIDRe" +
            "sponse")]
        System.Threading.Tasks.Task<AircraftCategoryDataObject> GetAircraftCategoryDTOByAircraftCategoryIDAsync(System.Guid aircraftCategoryID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAircraftTypeDTOListByAircraftCategoryID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAircraftTypeDTOListByAircraftCategoryIDRe" +
            "sponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAircraftTypeDTOListByAircraftCategoryIDFa" +
            "ultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AircraftTypeDataObjectList GetAircraftTypeDTOListByAircraftCategoryID(System.Guid aircraftCategoryID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAircraftTypeDTOListByAircraftCategoryID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAircraftTypeDTOListByAircraftCategoryIDRe" +
            "sponse")]
        System.Threading.Tasks.Task<AircraftTypeDataObjectList> GetAircraftTypeDTOListByAircraftCategoryIDAsync(System.Guid aircraftCategoryID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitAircraftCategoryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitAircraftCategoryDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/CommitAircraftCategoryDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AircraftCategoryResultData CommitAircraftCategoryDTO(AircraftCategoryResultData aircraftCategoryData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitAircraftCategoryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitAircraftCategoryDTOResponse")]
        System.Threading.Tasks.Task<AircraftCategoryResultData> CommitAircraftCategoryDTOAsync(AircraftCategoryResultData aircraftCategoryData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllAircraftDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllAircraftDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllAircraftDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AircraftDataObjectList GetAllAircraftDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllAircraftDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllAircraftDTOResponse")]
        System.Threading.Tasks.Task<AircraftDataObjectList> GetAllAircraftDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAircraftDTOByAircraftID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAircraftDTOByAircraftIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAircraftDTOByAircraftIDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AircraftDataObject GetAircraftDTOByAircraftID(System.Guid aircraftId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAircraftDTOByAircraftID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAircraftDTOByAircraftIDResponse")]
        System.Threading.Tasks.Task<AircraftDataObject> GetAircraftDTOByAircraftIDAsync(System.Guid aircraftId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAircraftDTOListByAirlinesID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAircraftDTOListByAirlinesIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAircraftDTOListByAirlinesIDFaultDataFault" +
            "", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AircraftDataObjectList GetAircraftDTOListByAirlinesID(System.Guid airlinesID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAircraftDTOListByAirlinesID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAircraftDTOListByAirlinesIDResponse")]
        System.Threading.Tasks.Task<AircraftDataObjectList> GetAircraftDTOListByAirlinesIDAsync(System.Guid airlinesID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAircraftDTOListByAircraftTypeID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAircraftDTOListByAircraftTypeIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAircraftDTOListByAircraftTypeIDFaultDataF" +
            "ault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AircraftDataObjectList GetAircraftDTOListByAircraftTypeID(System.Guid aircraftTypeId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAircraftDTOListByAircraftTypeID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAircraftDTOListByAircraftTypeIDResponse")]
        System.Threading.Tasks.Task<AircraftDataObjectList> GetAircraftDTOListByAircraftTypeIDAsync(System.Guid aircraftTypeId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPlanAircraftDTOListByAircraftID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPlanAircraftDTOListByAircraftIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetPlanAircraftDTOListByAircraftIDFaultDataF" +
            "ault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        PlanAircraftDataObjectList GetPlanAircraftDTOListByAircraftID(System.Guid aircraftId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPlanAircraftDTOListByAircraftID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPlanAircraftDTOListByAircraftIDResponse")]
        System.Threading.Tasks.Task<PlanAircraftDataObjectList> GetPlanAircraftDTOListByAircraftIDAsync(System.Guid aircraftId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetOperationHistoryDTOListByAircraftID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetOperationHistoryDTOListByAircraftIDRespon" +
            "se")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetOperationHistoryDTOListByAircraftIDFaultD" +
            "ataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        OperationHistoryDataObjectList GetOperationHistoryDTOListByAircraftID(System.Guid aircraftId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetOperationHistoryDTOListByAircraftID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetOperationHistoryDTOListByAircraftIDRespon" +
            "se")]
        System.Threading.Tasks.Task<OperationHistoryDataObjectList> GetOperationHistoryDTOListByAircraftIDAsync(System.Guid aircraftId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitAircraftDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitAircraftDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/CommitAircraftDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AircraftResultData CommitAircraftDTO(AircraftResultData aircraftData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitAircraftDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitAircraftDTOResponse")]
        System.Threading.Tasks.Task<AircraftResultData> CommitAircraftDTOAsync(AircraftResultData aircraftData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllAircraftTypeDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllAircraftTypeDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllAircraftTypeDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AircraftTypeDataObjectList GetAllAircraftTypeDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllAircraftTypeDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllAircraftTypeDTOResponse")]
        System.Threading.Tasks.Task<AircraftTypeDataObjectList> GetAllAircraftTypeDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAircraftTypeDTOByAircraftTypeID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAircraftTypeDTOByAircraftTypeIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAircraftTypeDTOByAircraftTypeIDFaultDataF" +
            "ault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AircraftTypeDataObject GetAircraftTypeDTOByAircraftTypeID(System.Guid aircraftTypeId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAircraftTypeDTOByAircraftTypeID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAircraftTypeDTOByAircraftTypeIDResponse")]
        System.Threading.Tasks.Task<AircraftTypeDataObject> GetAircraftTypeDTOByAircraftTypeIDAsync(System.Guid aircraftTypeId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitAircraftTypeDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitAircraftTypeDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/CommitAircraftTypeDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AircraftTypeResultData CommitAircraftTypeDTO(AircraftTypeResultData aircraftTypeData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitAircraftTypeDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitAircraftTypeDTOResponse")]
        System.Threading.Tasks.Task<AircraftTypeResultData> CommitAircraftTypeDTOAsync(AircraftTypeResultData aircraftTypeData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllAirlineProgrammingDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllAirlineProgrammingDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllAirlineProgrammingDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AirlineProgrammingDataObjectList GetAllAirlineProgrammingDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllAirlineProgrammingDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllAirlineProgrammingDTOResponse")]
        System.Threading.Tasks.Task<AirlineProgrammingDataObjectList> GetAllAirlineProgrammingDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAirlineProgrammingDTOByAirlineProgramming" +
            "ID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAirlineProgrammingDTOByAirlineProgramming" +
            "IDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAirlineProgrammingDTOByAirlineProgramming" +
            "IDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AirlineProgrammingDataObject GetAirlineProgrammingDTOByAirlineProgrammingID(System.Guid airlineProgrammingId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAirlineProgrammingDTOByAirlineProgramming" +
            "ID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAirlineProgrammingDTOByAirlineProgramming" +
            "IDResponse")]
        System.Threading.Tasks.Task<AirlineProgrammingDataObject> GetAirlineProgrammingDTOByAirlineProgrammingIDAsync(System.Guid airlineProgrammingId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAirlineProgrammingDetailDTOListByAirlineP" +
            "rogrammingID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAirlineProgrammingDetailDTOListByAirlineP" +
            "rogrammingIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAirlineProgrammingDetailDTOListByAirlineP" +
            "rogrammingIDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AirlineProgrammingDetailDataObjectList GetAirlineProgrammingDetailDTOListByAirlineProgrammingID(System.Guid airlineProgrammingId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAirlineProgrammingDetailDTOListByAirlineP" +
            "rogrammingID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAirlineProgrammingDetailDTOListByAirlineP" +
            "rogrammingIDResponse")]
        System.Threading.Tasks.Task<AirlineProgrammingDetailDataObjectList> GetAirlineProgrammingDetailDTOListByAirlineProgrammingIDAsync(System.Guid airlineProgrammingId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitAirlineProgrammingDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitAirlineProgrammingDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/CommitAirlineProgrammingDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AirlineProgrammingResultData CommitAirlineProgrammingDTO(AirlineProgrammingResultData airlineProgrammingData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitAirlineProgrammingDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitAirlineProgrammingDTOResponse")]
        System.Threading.Tasks.Task<AirlineProgrammingResultData> CommitAirlineProgrammingDTOAsync(AirlineProgrammingResultData airlineProgrammingData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetCurrentAirlinesDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetCurrentAirlinesDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetCurrentAirlinesDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AirlinesDataObject GetCurrentAirlinesDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetCurrentAirlinesDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetCurrentAirlinesDTOResponse")]
        System.Threading.Tasks.Task<AirlinesDataObject> GetCurrentAirlinesDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllAirlinesDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllAirlinesDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllAirlinesDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AirlinesDataObjectList GetAllAirlinesDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllAirlinesDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllAirlinesDTOResponse")]
        System.Threading.Tasks.Task<AirlinesDataObjectList> GetAllAirlinesDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllSubsidiaryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllSubsidiaryDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllSubsidiaryDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AirlinesDataObjectList GetAllSubsidiaryDTO(System.Guid masterID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllSubsidiaryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllSubsidiaryDTOResponse")]
        System.Threading.Tasks.Task<AirlinesDataObjectList> GetAllSubsidiaryDTOAsync(System.Guid masterID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllFilialeDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllFilialeDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllFilialeDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AirlinesDataObjectList GetAllFilialeDTO(System.Guid masterID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllFilialeDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllFilialeDTOResponse")]
        System.Threading.Tasks.Task<AirlinesDataObjectList> GetAllFilialeDTOAsync(System.Guid masterID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAirlinesDTOByAirlinesID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAirlinesDTOByAirlinesIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAirlinesDTOByAirlinesIDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AirlinesDataObject GetAirlinesDTOByAirlinesID(System.Guid airlinesId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAirlinesDTOByAirlinesID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAirlinesDTOByAirlinesIDResponse")]
        System.Threading.Tasks.Task<AirlinesDataObject> GetAirlinesDTOByAirlinesIDAsync(System.Guid airlinesId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPlanDTOListByAirlinesID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPlanDTOListByAirlinesIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetPlanDTOListByAirlinesIDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        PlanDataObjectList GetPlanDTOListByAirlinesID(System.Guid airlinesId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPlanDTOListByAirlinesID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPlanDTOListByAirlinesIDResponse")]
        System.Threading.Tasks.Task<PlanDataObjectList> GetPlanDTOListByAirlinesIDAsync(System.Guid airlinesId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetRequestDTOListByAirlinesID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetRequestDTOListByAirlinesIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetRequestDTOListByAirlinesIDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        RequestDataObjectList GetRequestDTOListByAirlinesID(System.Guid airlinesId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetRequestDTOListByAirlinesID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetRequestDTOListByAirlinesIDResponse")]
        System.Threading.Tasks.Task<RequestDataObjectList> GetRequestDTOListByAirlinesIDAsync(System.Guid airlinesId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetSubAirlinesByAirlinesID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetSubAirlinesByAirlinesIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetSubAirlinesByAirlinesIDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AirlinesDataObjectList GetSubAirlinesByAirlinesID(System.Guid airlinesId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetSubAirlinesByAirlinesID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetSubAirlinesByAirlinesIDResponse")]
        System.Threading.Tasks.Task<AirlinesDataObjectList> GetSubAirlinesByAirlinesIDAsync(System.Guid airlinesId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitAirlinesDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitAirlinesDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/CommitAirlinesDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AirlinesResultData CommitAirlinesDTO(AirlinesResultData AirlinesData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitAirlinesDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitAirlinesDTOResponse")]
        System.Threading.Tasks.Task<AirlinesResultData> CommitAirlinesDTOAsync(AirlinesResultData AirlinesData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllAnnualDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllAnnualDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllAnnualDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AnnualDataObjectList GetAllAnnualDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllAnnualDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllAnnualDTOResponse")]
        System.Threading.Tasks.Task<AnnualDataObjectList> GetAllAnnualDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAnnualDTOByAnnualID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAnnualDTOByAnnualIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAnnualDTOByAnnualIDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AnnualDataObject GetAnnualDTOByAnnualID(System.Guid annualId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAnnualDTOByAnnualID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAnnualDTOByAnnualIDResponse")]
        System.Threading.Tasks.Task<AnnualDataObject> GetAnnualDTOByAnnualIDAsync(System.Guid annualId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetCurrentAnnualDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetCurrentAnnualDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetCurrentAnnualDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AnnualDataObject GetCurrentAnnualDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetCurrentAnnualDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetCurrentAnnualDTOResponse")]
        System.Threading.Tasks.Task<AnnualDataObject> GetCurrentAnnualDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllAnnualSummaryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllAnnualSummaryDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllAnnualSummaryDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AnnualSummaryDataObjectList GetAllAnnualSummaryDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllAnnualSummaryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllAnnualSummaryDTOResponse")]
        System.Threading.Tasks.Task<AnnualSummaryDataObjectList> GetAllAnnualSummaryDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAnnualSummaryDTOByAnnualSummaryID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAnnualSummaryDTOByAnnualSummaryIDResponse" +
            "")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAnnualSummaryDTOByAnnualSummaryIDFaultDat" +
            "aFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AnnualSummaryDataObject GetAnnualSummaryDTOByAnnualSummaryID(System.Guid annualSummaryId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAnnualSummaryDTOByAnnualSummaryID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAnnualSummaryDTOByAnnualSummaryIDResponse" +
            "")]
        System.Threading.Tasks.Task<AnnualSummaryDataObject> GetAnnualSummaryDTOByAnnualSummaryIDAsync(System.Guid annualSummaryId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitAnnualSummaryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitAnnualSummaryDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/CommitAnnualSummaryDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AnnualSummaryResultData CommitAnnualSummaryDTO(AnnualSummaryResultData annualSummaryData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitAnnualSummaryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitAnnualSummaryDTOResponse")]
        System.Threading.Tasks.Task<AnnualSummaryResultData> CommitAnnualSummaryDTOAsync(AnnualSummaryResultData annualSummaryData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllApprovalDocDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllApprovalDocDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllApprovalDocDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ApprovalDocDataObjectList GetAllApprovalDocDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllApprovalDocDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllApprovalDocDTOResponse")]
        System.Threading.Tasks.Task<ApprovalDocDataObjectList> GetAllApprovalDocDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetUnUsedApprovalDocDTOList", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetUnUsedApprovalDocDTOListResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetUnUsedApprovalDocDTOListFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ApprovalDocDataObjectList GetUnUsedApprovalDocDTOList();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetUnUsedApprovalDocDTOList", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetUnUsedApprovalDocDTOListResponse")]
        System.Threading.Tasks.Task<ApprovalDocDataObjectList> GetUnUsedApprovalDocDTOListAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetApprovalDocDTOByApprovalDocID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetApprovalDocDTOByApprovalDocIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetApprovalDocDTOByApprovalDocIDFaultDataFau" +
            "lt", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ApprovalDocDataObject GetApprovalDocDTOByApprovalDocID(System.Guid approvalDocId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetApprovalDocDTOByApprovalDocID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetApprovalDocDTOByApprovalDocIDResponse")]
        System.Threading.Tasks.Task<ApprovalDocDataObject> GetApprovalDocDTOByApprovalDocIDAsync(System.Guid approvalDocId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetRequestDTOListByApprovalDocID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetRequestDTOListByApprovalDocIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetRequestDTOListByApprovalDocIDFaultDataFau" +
            "lt", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        RequestDataObjectList GetRequestDTOListByApprovalDocID(System.Guid approvalDocId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetRequestDTOListByApprovalDocID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetRequestDTOListByApprovalDocIDResponse")]
        System.Threading.Tasks.Task<RequestDataObjectList> GetRequestDTOListByApprovalDocIDAsync(System.Guid approvalDocId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitApprovalDocDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitApprovalDocDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/CommitApprovalDocDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ApprovalDocResultData CommitApprovalDocDTO(ApprovalDocResultData approvalDocData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitApprovalDocDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitApprovalDocDTOResponse")]
        System.Threading.Tasks.Task<ApprovalDocResultData> CommitApprovalDocDTOAsync(ApprovalDocResultData approvalDocData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllApprovalHistoryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllApprovalHistoryDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllApprovalHistoryDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ApprovalHistoryDataObjectList GetAllApprovalHistoryDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllApprovalHistoryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllApprovalHistoryDTOResponse")]
        System.Threading.Tasks.Task<ApprovalHistoryDataObjectList> GetAllApprovalHistoryDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetApprovalHistoryDTOByApprovalHistoryID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetApprovalHistoryDTOByApprovalHistoryIDResp" +
            "onse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetApprovalHistoryDTOByApprovalHistoryIDFaul" +
            "tDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ApprovalHistoryDataObject GetApprovalHistoryDTOByApprovalHistoryID(System.Guid approvalHistoryId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetApprovalHistoryDTOByApprovalHistoryID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetApprovalHistoryDTOByApprovalHistoryIDResp" +
            "onse")]
        System.Threading.Tasks.Task<ApprovalHistoryDataObject> GetApprovalHistoryDTOByApprovalHistoryIDAsync(System.Guid approvalHistoryId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetApprovalHistoryDTOListByPlanAircraftID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetApprovalHistoryDTOListByPlanAircraftIDRes" +
            "ponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetApprovalHistoryDTOListByPlanAircraftIDFau" +
            "ltDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ApprovalHistoryDataObjectList GetApprovalHistoryDTOListByPlanAircraftID(System.Guid planAircraftId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetApprovalHistoryDTOListByPlanAircraftID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetApprovalHistoryDTOListByPlanAircraftIDRes" +
            "ponse")]
        System.Threading.Tasks.Task<ApprovalHistoryDataObjectList> GetApprovalHistoryDTOListByPlanAircraftIDAsync(System.Guid planAircraftId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllEngineBusinessHistoryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllEngineBusinessHistoryDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllEngineBusinessHistoryDTOFaultDataFault" +
            "", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        EngineBusinessHistoryDataObjectList GetAllEngineBusinessHistoryDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllEngineBusinessHistoryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllEngineBusinessHistoryDTOResponse")]
        System.Threading.Tasks.Task<EngineBusinessHistoryDataObjectList> GetAllEngineBusinessHistoryDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEngineBusinessHistoryDTOByEngineBusinessH" +
            "istoryID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEngineBusinessHistoryDTOByEngineBusinessH" +
            "istoryIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetEngineBusinessHistoryDTOByEngineBusinessH" +
            "istoryIDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        EngineBusinessHistoryDataObject GetEngineBusinessHistoryDTOByEngineBusinessHistoryID(System.Guid engineBusinessHistoryId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEngineBusinessHistoryDTOByEngineBusinessH" +
            "istoryID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEngineBusinessHistoryDTOByEngineBusinessH" +
            "istoryIDResponse")]
        System.Threading.Tasks.Task<EngineBusinessHistoryDataObject> GetEngineBusinessHistoryDTOByEngineBusinessHistoryIDAsync(System.Guid engineBusinessHistoryId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEngineBusinessHistoryDTOListByEngineID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEngineBusinessHistoryDTOListByEngineIDRes" +
            "ponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetEngineBusinessHistoryDTOListByEngineIDFau" +
            "ltDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        EngineBusinessHistoryDataObjectList GetEngineBusinessHistoryDTOListByEngineID(System.Guid engineId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEngineBusinessHistoryDTOListByEngineID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEngineBusinessHistoryDTOListByEngineIDRes" +
            "ponse")]
        System.Threading.Tasks.Task<EngineBusinessHistoryDataObjectList> GetEngineBusinessHistoryDTOListByEngineIDAsync(System.Guid engineId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllEngineOwnerShipHistoryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllEngineOwnerShipHistoryDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllEngineOwnerShipHistoryDTOFaultDataFaul" +
            "t", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        EngineOwnerShipHistoryDataObjectList GetAllEngineOwnerShipHistoryDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllEngineOwnerShipHistoryDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllEngineOwnerShipHistoryDTOResponse")]
        System.Threading.Tasks.Task<EngineOwnerShipHistoryDataObjectList> GetAllEngineOwnerShipHistoryDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEngineOwnershipHistoryDTOByEngineOwnerShi" +
            "pHistoryID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEngineOwnershipHistoryDTOByEngineOwnerShi" +
            "pHistoryIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetEngineOwnershipHistoryDTOByEngineOwnerShi" +
            "pHistoryIDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        EngineOwnerShipHistoryDataObject GetEngineOwnershipHistoryDTOByEngineOwnerShipHistoryID(System.Guid engineOwnerShipHistoryId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEngineOwnershipHistoryDTOByEngineOwnerShi" +
            "pHistoryID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEngineOwnershipHistoryDTOByEngineOwnerShi" +
            "pHistoryIDResponse")]
        System.Threading.Tasks.Task<EngineOwnerShipHistoryDataObject> GetEngineOwnershipHistoryDTOByEngineOwnerShipHistoryIDAsync(System.Guid engineOwnerShipHistoryId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEngineOwnerShipHistoryDTOListByEngineID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEngineOwnerShipHistoryDTOListByEngineIDRe" +
            "sponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetEngineOwnerShipHistoryDTOListByEngineIDFa" +
            "ultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        EngineOwnerShipHistoryDataObjectList GetEngineOwnerShipHistoryDTOListByEngineID(System.Guid engineId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEngineOwnerShipHistoryDTOListByEngineID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEngineOwnerShipHistoryDTOListByEngineIDRe" +
            "sponse")]
        System.Threading.Tasks.Task<EngineOwnerShipHistoryDataObjectList> GetEngineOwnerShipHistoryDTOListByEngineIDAsync(System.Guid engineId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllEnginePlanDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllEnginePlanDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllEnginePlanDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        EnginePlanDataObjectList GetAllEnginePlanDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllEnginePlanDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllEnginePlanDTOResponse")]
        System.Threading.Tasks.Task<EnginePlanDataObjectList> GetAllEnginePlanDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEnginePlanDTOByEnginePlanID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEnginePlanDTOByEnginePlanIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetEnginePlanDTOByEnginePlanIDFaultDataFault" +
            "", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        EnginePlanDataObject GetEnginePlanDTOByEnginePlanID(System.Guid enginePlanId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEnginePlanDTOByEnginePlanID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEnginePlanDTOByEnginePlanIDResponse")]
        System.Threading.Tasks.Task<EnginePlanDataObject> GetEnginePlanDTOByEnginePlanIDAsync(System.Guid enginePlanId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEnginePlanHistoryDTOListByEnginePlanID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEnginePlanHistoryDTOListByEnginePlanIDRes" +
            "ponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetEnginePlanHistoryDTOListByEnginePlanIDFau" +
            "ltDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        EnginePlanHistoryDataObjectList GetEnginePlanHistoryDTOListByEnginePlanID(System.Guid enginePlanId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEnginePlanHistoryDTOListByEnginePlanID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEnginePlanHistoryDTOListByEnginePlanIDRes" +
            "ponse")]
        System.Threading.Tasks.Task<EnginePlanHistoryDataObjectList> GetEnginePlanHistoryDTOListByEnginePlanIDAsync(System.Guid enginePlanId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetMaxVersionNumberByCurrentAnnualInEnginePl" +
            "an", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetMaxVersionNumberByCurrentAnnualInEnginePl" +
            "anResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetMaxVersionNumberByCurrentAnnualInEnginePl" +
            "anFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        int GetMaxVersionNumberByCurrentAnnualInEnginePlan();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetMaxVersionNumberByCurrentAnnualInEnginePl" +
            "an", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetMaxVersionNumberByCurrentAnnualInEnginePl" +
            "anResponse")]
        System.Threading.Tasks.Task<int> GetMaxVersionNumberByCurrentAnnualInEnginePlanAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitEnginePlanDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitEnginePlanDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/CommitEnginePlanDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        EnginePlanResultData CommitEnginePlanDTO(EnginePlanResultData enginePlanData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitEnginePlanDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitEnginePlanDTOResponse")]
        System.Threading.Tasks.Task<EnginePlanResultData> CommitEnginePlanDTOAsync(EnginePlanResultData enginePlanData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllEngineDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllEngineDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllEngineDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        EngineDataObjectList GetAllEngineDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllEngineDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllEngineDTOResponse")]
        System.Threading.Tasks.Task<EngineDataObjectList> GetAllEngineDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEngineDTOByEngineID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEngineDTOByEngineIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetEngineDTOByEngineIDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        EngineDataObject GetEngineDTOByEngineID(System.Guid engineID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEngineDTOByEngineID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEngineDTOByEngineIDResponse")]
        System.Threading.Tasks.Task<EngineDataObject> GetEngineDTOByEngineIDAsync(System.Guid engineID);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEngineDTOListByAirlinesID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEngineDTOListByAirlinesIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetEngineDTOListByAirlinesIDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        EngineDataObjectList GetEngineDTOListByAirlinesID(System.Guid airlinesId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEngineDTOListByAirlinesID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEngineDTOListByAirlinesIDResponse")]
        System.Threading.Tasks.Task<EngineDataObjectList> GetEngineDTOListByAirlinesIDAsync(System.Guid airlinesId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEngineDTOListByEngineTypeID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEngineDTOListByEngineTypeIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetEngineDTOListByEngineTypeIDFaultDataFault" +
            "", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        EngineDataObjectList GetEngineDTOListByEngineTypeID(System.Guid engineTypeId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEngineDTOListByEngineTypeID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEngineDTOListByEngineTypeIDResponse")]
        System.Threading.Tasks.Task<EngineDataObjectList> GetEngineDTOListByEngineTypeIDAsync(System.Guid engineTypeId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPlanEngineDTOListByEngineID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPlanEngineDTOListByEngineIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetPlanEngineDTOListByEngineIDFaultDataFault" +
            "", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        PlanEngineDataObjectList GetPlanEngineDTOListByEngineID(System.Guid engineId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetPlanEngineDTOListByEngineID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetPlanEngineDTOListByEngineIDResponse")]
        System.Threading.Tasks.Task<PlanEngineDataObjectList> GetPlanEngineDTOListByEngineIDAsync(System.Guid engineId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitEngineDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitEngineDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/CommitEngineDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        EngineResultData CommitEngineDTO(EngineResultData engineData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitEngineDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitEngineDTOResponse")]
        System.Threading.Tasks.Task<EngineResultData> CommitEngineDTOAsync(EngineResultData engineData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllEngineTypeDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllEngineTypeDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllEngineTypeDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        EngineTypeDataObjectList GetAllEngineTypeDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllEngineTypeDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllEngineTypeDTOResponse")]
        System.Threading.Tasks.Task<EngineTypeDataObjectList> GetAllEngineTypeDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEngineTypeDTOByEngineTypeID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEngineTypeDTOByEngineTypeIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetEngineTypeDTOByEngineTypeIDFaultDataFault" +
            "", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        EngineTypeDataObject GetEngineTypeDTOByEngineTypeID(System.Guid engineTypeId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetEngineTypeDTOByEngineTypeID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetEngineTypeDTOByEngineTypeIDResponse")]
        System.Threading.Tasks.Task<EngineTypeDataObject> GetEngineTypeDTOByEngineTypeIDAsync(System.Guid engineTypeId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitEngineTypeDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitEngineTypeDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/CommitEngineTypeDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        EngineTypeResultData CommitEngineTypeDTO(EngineTypeResultData engineTypeData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitEngineTypeDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitEngineTypeDTOResponse")]
        System.Threading.Tasks.Task<EngineTypeResultData> CommitEngineTypeDTOAsync(EngineTypeResultData engineTypeData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllMailAddressDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllMailAddressDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllMailAddressDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        MailAddressDataObjectList GetAllMailAddressDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllMailAddressDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllMailAddressDTOResponse")]
        System.Threading.Tasks.Task<MailAddressDataObjectList> GetAllMailAddressDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetMailAddressDTOByMailAddressID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetMailAddressDTOByMailAddressIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetMailAddressDTOByMailAddressIDFaultDataFau" +
            "lt", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        MailAddressDataObject GetMailAddressDTOByMailAddressID(System.Guid mailAddressId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetMailAddressDTOByMailAddressID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetMailAddressDTOByMailAddressIDResponse")]
        System.Threading.Tasks.Task<MailAddressDataObject> GetMailAddressDTOByMailAddressIDAsync(System.Guid mailAddressId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetMailAddressDTOByOwnerID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetMailAddressDTOByOwnerIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetMailAddressDTOByOwnerIDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        MailAddressDataObject GetMailAddressDTOByOwnerID(System.Guid ownerId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetMailAddressDTOByOwnerID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetMailAddressDTOByOwnerIDResponse")]
        System.Threading.Tasks.Task<MailAddressDataObject> GetMailAddressDTOByOwnerIDAsync(System.Guid ownerId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitMailAddressDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitMailAddressDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/CommitMailAddressDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        MailAddressResultData CommitMailAddressDTO(MailAddressResultData mailAddressData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/CommitMailAddressDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/CommitMailAddressDTOResponse")]
        System.Threading.Tasks.Task<MailAddressResultData> CommitMailAddressDTOAsync(MailAddressResultData mailAddressData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllManagerDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllManagerDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllManagerDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ManagerDataObjectList GetAllManagerDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllManagerDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllManagerDTOResponse")]
        System.Threading.Tasks.Task<ManagerDataObjectList> GetAllManagerDTOAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetManagerDTOByOwnerID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetManagerDTOByOwnerIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetManagerDTOByOwnerIDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ManagerDataObject GetManagerDTOByOwnerID(System.Guid ownerId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetManagerDTOByOwnerID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetManagerDTOByOwnerIDResponse")]
        System.Threading.Tasks.Task<ManagerDataObject> GetManagerDTOByOwnerIDAsync(System.Guid ownerId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetManagerDTOByManagerID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetManagerDTOByManagerIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetManagerDTOByManagerIDFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ManagerDataObject GetManagerDTOByManagerID(System.Guid managerId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetManagerDTOByManagerID", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetManagerDTOByManagerIDResponse")]
        System.Threading.Tasks.Task<ManagerDataObject> GetManagerDTOByManagerIDAsync(System.Guid managerId);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllManufacturerDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllManufacturerDTOResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAFRPService/GetAllManufacturerDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        ManufacturerDataObjectList GetAllManufacturerDTO();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAFRPService/GetAllManufacturerDTO", ReplyAction = "http://www.UniCloud.com/IAFRPService/GetAllManufacturerDTOResponse")]
        System.Threading.Tasks.Task<ManufacturerDataObjectList> GetAllManufacturerDTOAsync();
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAFRPServiceChannel : IAFRPService, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AFRPServiceClient : System.ServiceModel.ClientBase<IAFRPService>, IAFRPService
    {

        public AFRPServiceClient()
        {
        }

        public AFRPServiceClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public AFRPServiceClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public AFRPServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public AFRPServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        public NDRCRequestWithPagination GetNDRCRequestWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetNDRCRequestWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<NDRCRequestWithPagination> GetNDRCRequestWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetNDRCRequestWithPaginationAsync(pagination);
        }

        public PlanAircraftWithPagination GetPlanAircraftWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetPlanAircraftWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<PlanAircraftWithPagination> GetPlanAircraftWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetPlanAircraftWithPaginationAsync(pagination);
        }

        public PlanEngineWithPagination GetPlanEngineWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetPlanEngineWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<PlanEngineWithPagination> GetPlanEngineWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetPlanEngineWithPaginationAsync(pagination);
        }

        public PlanWithPagination GetPlanWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetPlanWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<PlanWithPagination> GetPlanWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetPlanWithPaginationAsync(pagination);
        }

        public ProgrammCategoryWithPagination GetProgrammCategoryWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetProgrammCategoryWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<ProgrammCategoryWithPagination> GetProgrammCategoryWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetProgrammCategoryWithPaginationAsync(pagination);
        }

        public ProgrammingWithPagination GetProgrammingWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetProgrammingWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<ProgrammingWithPagination> GetProgrammingWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetProgrammingWithPaginationAsync(pagination);
        }

        public RAApprovalDocWithPagination GetRAApprovalDocWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetRAApprovalDocWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<RAApprovalDocWithPagination> GetRAApprovalDocWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetRAApprovalDocWithPaginationAsync(pagination);
        }

        public RARequestWithPagination GetRARequestWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetRARequestWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<RARequestWithPagination> GetRARequestWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetRARequestWithPaginationAsync(pagination);
        }

        public RequestWithPagination GetRequestWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetRequestWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<RequestWithPagination> GetRequestWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetRequestWithPaginationAsync(pagination);
        }

        public SAWSApprovalDocWithPagination GetSAWSApprovalDocWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetSAWSApprovalDocWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<SAWSApprovalDocWithPagination> GetSAWSApprovalDocWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetSAWSApprovalDocWithPaginationAsync(pagination);
        }

        public SAWSRequestWithPagination GetSAWSRequestWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetSAWSRequestWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<SAWSRequestWithPagination> GetSAWSRequestWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetSAWSRequestWithPaginationAsync(pagination);
        }

        public XmlConfigWithPagination GetXmlConfigWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetXmlConfigWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<XmlConfigWithPagination> GetXmlConfigWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetXmlConfigWithPaginationAsync(pagination);
        }

        public AirlinesWithPagination GetAirlinesWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetAirlinesWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<AirlinesWithPagination> GetAirlinesWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetAirlinesWithPaginationAsync(pagination);
        }

        public AirlinesWithPagination GetAllSubsidiarysWithPagination(System.Guid masterID, UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetAllSubsidiarysWithPagination(masterID, pagination);
        }

        public System.Threading.Tasks.Task<AirlinesWithPagination> GetAllSubsidiarysWithPaginationAsync(System.Guid masterID, UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetAllSubsidiarysWithPaginationAsync(masterID, pagination);
        }

        public AirlinesWithPagination GetAllFilialesWithPagination(System.Guid masterID, UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetAllFilialesWithPagination(masterID, pagination);
        }

        public System.Threading.Tasks.Task<AirlinesWithPagination> GetAllFilialesWithPaginationAsync(System.Guid masterID, UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetAllFilialesWithPaginationAsync(masterID, pagination);
        }

        public MailAddressWithPagination GetMailAddressWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetMailAddressWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<MailAddressWithPagination> GetMailAddressWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetMailAddressWithPaginationAsync(pagination);
        }

        public ManagerWithPagination GetManagerWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetManagerWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<ManagerWithPagination> GetManagerWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetManagerWithPaginationAsync(pagination);
        }

        public ManufacturerWithPagination GetManufacturerWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetManufacturerWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<ManufacturerWithPagination> GetManufacturerWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetManufacturerWithPaginationAsync(pagination);
        }

        public OperatorWithPagination GetOperatorWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetOperatorWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<OperatorWithPagination> GetOperatorWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetOperatorWithPaginationAsync(pagination);
        }

        public OwnerWithPagination GetOwnerWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetOwnerWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<OwnerWithPagination> GetOwnerWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetOwnerWithPaginationAsync(pagination);
        }

        public XmlSettingWithPagination GetXmlSettingWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetXmlSettingWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<XmlSettingWithPagination> GetXmlSettingWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetXmlSettingWithPaginationAsync(pagination);
        }

        public ManufacturerDataObject GetManufacturerDTOByManufacturerID(System.Guid manufacturerId)
        {
            return base.Channel.GetManufacturerDTOByManufacturerID(manufacturerId);
        }

        public System.Threading.Tasks.Task<ManufacturerDataObject> GetManufacturerDTOByManufacturerIDAsync(System.Guid manufacturerId)
        {
            return base.Channel.GetManufacturerDTOByManufacturerIDAsync(manufacturerId);
        }

        public ManufacturerDataObject GetManufacturerDTOByOwnerID(System.Guid ownerId)
        {
            return base.Channel.GetManufacturerDTOByOwnerID(ownerId);
        }

        public System.Threading.Tasks.Task<ManufacturerDataObject> GetManufacturerDTOByOwnerIDAsync(System.Guid ownerId)
        {
            return base.Channel.GetManufacturerDTOByOwnerIDAsync(ownerId);
        }

        public AircraftTypeDataObjectList GetAircraftTypeDTOListByManufacturerID(System.Guid manufacturerId)
        {
            return base.Channel.GetAircraftTypeDTOListByManufacturerID(manufacturerId);
        }

        public System.Threading.Tasks.Task<AircraftTypeDataObjectList> GetAircraftTypeDTOListByManufacturerIDAsync(System.Guid manufacturerId)
        {
            return base.Channel.GetAircraftTypeDTOListByManufacturerIDAsync(manufacturerId);
        }

        public NDRCApprovalDocDataObjectList GetAllNDRCApprovalDocDTO()
        {
            return base.Channel.GetAllNDRCApprovalDocDTO();
        }

        public System.Threading.Tasks.Task<NDRCApprovalDocDataObjectList> GetAllNDRCApprovalDocDTOAsync()
        {
            return base.Channel.GetAllNDRCApprovalDocDTOAsync();
        }

        public NDRCApprovalDocDataObject GetNDRCApprovalDocDTOByNDRCApprovalDocID(System.Guid ndrcRaApprovalDocId)
        {
            return base.Channel.GetNDRCApprovalDocDTOByNDRCApprovalDocID(ndrcRaApprovalDocId);
        }

        public System.Threading.Tasks.Task<NDRCApprovalDocDataObject> GetNDRCApprovalDocDTOByNDRCApprovalDocIDAsync(System.Guid ndrcRaApprovalDocId)
        {
            return base.Channel.GetNDRCApprovalDocDTOByNDRCApprovalDocIDAsync(ndrcRaApprovalDocId);
        }

        public NDRCRequestDataObjectList GetNDRCRequestDTOListByNDRCApprovalDocID(System.Guid ndrcRaApprovalDocId)
        {
            return base.Channel.GetNDRCRequestDTOListByNDRCApprovalDocID(ndrcRaApprovalDocId);
        }

        public System.Threading.Tasks.Task<NDRCRequestDataObjectList> GetNDRCRequestDTOListByNDRCApprovalDocIDAsync(System.Guid ndrcRaApprovalDocId)
        {
            return base.Channel.GetNDRCRequestDTOListByNDRCApprovalDocIDAsync(ndrcRaApprovalDocId);
        }

        public NDRCApprovalDocResultData CommitNDRCApprovalDocDTO(NDRCApprovalDocResultData ndrcApprovalDocData)
        {
            return base.Channel.CommitNDRCApprovalDocDTO(ndrcApprovalDocData);
        }

        public System.Threading.Tasks.Task<NDRCApprovalDocResultData> CommitNDRCApprovalDocDTOAsync(NDRCApprovalDocResultData ndrcApprovalDocData)
        {
            return base.Channel.CommitNDRCApprovalDocDTOAsync(ndrcApprovalDocData);
        }

        public NDRCApprovalHistoryDataObjectList GetAllNDRCApprovalHistoryDTO()
        {
            return base.Channel.GetAllNDRCApprovalHistoryDTO();
        }

        public System.Threading.Tasks.Task<NDRCApprovalHistoryDataObjectList> GetAllNDRCApprovalHistoryDTOAsync()
        {
            return base.Channel.GetAllNDRCApprovalHistoryDTOAsync();
        }

        public NDRCApprovalHistoryDataObject GetNDRCApprovalHistoryDTOByNDRCApprovalHistoryID(System.Guid ndrcApprovalHistoryId)
        {
            return base.Channel.GetNDRCApprovalHistoryDTOByNDRCApprovalHistoryID(ndrcApprovalHistoryId);
        }

        public System.Threading.Tasks.Task<NDRCApprovalHistoryDataObject> GetNDRCApprovalHistoryDTOByNDRCApprovalHistoryIDAsync(System.Guid ndrcApprovalHistoryId)
        {
            return base.Channel.GetNDRCApprovalHistoryDTOByNDRCApprovalHistoryIDAsync(ndrcApprovalHistoryId);
        }

        public NDRCApprovalHistoryDataObjectList GetNDRCApprovalHistoryDTOListByPlanAircraftID(System.Guid planAircraftId)
        {
            return base.Channel.GetNDRCApprovalHistoryDTOListByPlanAircraftID(planAircraftId);
        }

        public System.Threading.Tasks.Task<NDRCApprovalHistoryDataObjectList> GetNDRCApprovalHistoryDTOListByPlanAircraftIDAsync(System.Guid planAircraftId)
        {
            return base.Channel.GetNDRCApprovalHistoryDTOListByPlanAircraftIDAsync(planAircraftId);
        }

        public NDRCRequestDataObjectList GetAllNDRCRequestDTO()
        {
            return base.Channel.GetAllNDRCRequestDTO();
        }

        public System.Threading.Tasks.Task<NDRCRequestDataObjectList> GetAllNDRCRequestDTOAsync()
        {
            return base.Channel.GetAllNDRCRequestDTOAsync();
        }

        public NDRCRequestDataObject GetNDRCRequestDTOByNDRCRequestID(System.Guid ndrcRequestId)
        {
            return base.Channel.GetNDRCRequestDTOByNDRCRequestID(ndrcRequestId);
        }

        public System.Threading.Tasks.Task<NDRCRequestDataObject> GetNDRCRequestDTOByNDRCRequestIDAsync(System.Guid ndrcRequestId)
        {
            return base.Channel.GetNDRCRequestDTOByNDRCRequestIDAsync(ndrcRequestId);
        }

        public NDRCApprovalHistoryDataObjectList GetNDRCApprovalHistoryDTOListByNDRCRequestID(System.Guid ndrcRequestId)
        {
            return base.Channel.GetNDRCApprovalHistoryDTOListByNDRCRequestID(ndrcRequestId);
        }

        public System.Threading.Tasks.Task<NDRCApprovalHistoryDataObjectList> GetNDRCApprovalHistoryDTOListByNDRCRequestIDAsync(System.Guid ndrcRequestId)
        {
            return base.Channel.GetNDRCApprovalHistoryDTOListByNDRCRequestIDAsync(ndrcRequestId);
        }

        public NDRCRequestResultData CommitNDRCRequestDTO(NDRCRequestResultData ndrcRequestData)
        {
            return base.Channel.CommitNDRCRequestDTO(ndrcRequestData);
        }

        public System.Threading.Tasks.Task<NDRCRequestResultData> CommitNDRCRequestDTOAsync(NDRCRequestResultData ndrcRequestData)
        {
            return base.Channel.CommitNDRCRequestDTOAsync(ndrcRequestData);
        }

        public OperationHistoryDataObjectList GetAllOperationHistoryDTO()
        {
            return base.Channel.GetAllOperationHistoryDTO();
        }

        public System.Threading.Tasks.Task<OperationHistoryDataObjectList> GetAllOperationHistoryDTOAsync()
        {
            return base.Channel.GetAllOperationHistoryDTOAsync();
        }

        public OperationHistoryDataObject GetOperationHistoryDTOByOperationHistoryID(System.Guid operationHistoryId)
        {
            return base.Channel.GetOperationHistoryDTOByOperationHistoryID(operationHistoryId);
        }

        public System.Threading.Tasks.Task<OperationHistoryDataObject> GetOperationHistoryDTOByOperationHistoryIDAsync(System.Guid operationHistoryId)
        {
            return base.Channel.GetOperationHistoryDTOByOperationHistoryIDAsync(operationHistoryId);
        }

        public SubOperationHistoryDataObjectList GetSubOperationHistoryDTOListByOperationHistoryID(System.Guid operationHistoryId)
        {
            return base.Channel.GetSubOperationHistoryDTOListByOperationHistoryID(operationHistoryId);
        }

        public System.Threading.Tasks.Task<SubOperationHistoryDataObjectList> GetSubOperationHistoryDTOListByOperationHistoryIDAsync(System.Guid operationHistoryId)
        {
            return base.Channel.GetSubOperationHistoryDTOListByOperationHistoryIDAsync(operationHistoryId);
        }

        public OwnerDataObjectList GetAllOwnerDTO()
        {
            return base.Channel.GetAllOwnerDTO();
        }

        public System.Threading.Tasks.Task<OwnerDataObjectList> GetAllOwnerDTOAsync()
        {
            return base.Channel.GetAllOwnerDTOAsync();
        }

        public OwnerDataObject GetOwnerDTOByOwnerID(System.Guid ownerId)
        {
            return base.Channel.GetOwnerDTOByOwnerID(ownerId);
        }

        public System.Threading.Tasks.Task<OwnerDataObject> GetOwnerDTOByOwnerIDAsync(System.Guid ownerId)
        {
            return base.Channel.GetOwnerDTOByOwnerIDAsync(ownerId);
        }

        public OwnershipHistoryDataObjectList GetOwnershipHistoryDTOListBySupplierID(System.Guid ownerId)
        {
            return base.Channel.GetOwnershipHistoryDTOListBySupplierID(ownerId);
        }

        public System.Threading.Tasks.Task<OwnershipHistoryDataObjectList> GetOwnershipHistoryDTOListBySupplierIDAsync(System.Guid ownerId)
        {
            return base.Channel.GetOwnershipHistoryDTOListBySupplierIDAsync(ownerId);
        }

        public OwnerResultData CommitOwnerDTO(OwnerResultData ownerData)
        {
            return base.Channel.CommitOwnerDTO(ownerData);
        }

        public System.Threading.Tasks.Task<OwnerResultData> CommitOwnerDTOAsync(OwnerResultData ownerData)
        {
            return base.Channel.CommitOwnerDTOAsync(ownerData);
        }

        public OwnershipHistoryDataObjectList GetAllOwnershipHistoryDTO()
        {
            return base.Channel.GetAllOwnershipHistoryDTO();
        }

        public System.Threading.Tasks.Task<OwnershipHistoryDataObjectList> GetAllOwnershipHistoryDTOAsync()
        {
            return base.Channel.GetAllOwnershipHistoryDTOAsync();
        }

        public OwnershipHistoryDataObject GetOwnershipHistoryDTOByOwnershipHistoryID(System.Guid ownershipHistoryId)
        {
            return base.Channel.GetOwnershipHistoryDTOByOwnershipHistoryID(ownershipHistoryId);
        }

        public System.Threading.Tasks.Task<OwnershipHistoryDataObject> GetOwnershipHistoryDTOByOwnershipHistoryIDAsync(System.Guid ownershipHistoryId)
        {
            return base.Channel.GetOwnershipHistoryDTOByOwnershipHistoryIDAsync(ownershipHistoryId);
        }

        public OwnershipHistoryDataObjectList GetOwnershipHistoryDTOListByAircraftID(System.Guid aircraftId)
        {
            return base.Channel.GetOwnershipHistoryDTOListByAircraftID(aircraftId);
        }

        public System.Threading.Tasks.Task<OwnershipHistoryDataObjectList> GetOwnershipHistoryDTOListByAircraftIDAsync(System.Guid aircraftId)
        {
            return base.Channel.GetOwnershipHistoryDTOListByAircraftIDAsync(aircraftId);
        }

        public PlanAircraftDataObjectList GetAllPlanAircraftDTO()
        {
            return base.Channel.GetAllPlanAircraftDTO();
        }

        public System.Threading.Tasks.Task<PlanAircraftDataObjectList> GetAllPlanAircraftDTOAsync()
        {
            return base.Channel.GetAllPlanAircraftDTOAsync();
        }

        public PlanAircraftDataObject GetPlanAircraftDTOByPlanAircraftID(System.Guid planAircraftId)
        {
            return base.Channel.GetPlanAircraftDTOByPlanAircraftID(planAircraftId);
        }

        public System.Threading.Tasks.Task<PlanAircraftDataObject> GetPlanAircraftDTOByPlanAircraftIDAsync(System.Guid planAircraftId)
        {
            return base.Channel.GetPlanAircraftDTOByPlanAircraftIDAsync(planAircraftId);
        }

        public PlanHistoryDataObjectList GetPlanHistoryDTOListByPlanAircraftID(System.Guid planAircraftId)
        {
            return base.Channel.GetPlanHistoryDTOListByPlanAircraftID(planAircraftId);
        }

        public System.Threading.Tasks.Task<PlanHistoryDataObjectList> GetPlanHistoryDTOListByPlanAircraftIDAsync(System.Guid planAircraftId)
        {
            return base.Channel.GetPlanHistoryDTOListByPlanAircraftIDAsync(planAircraftId);
        }

        public PlanAircraftResultData CommitPlanAircraftDTO(PlanAircraftResultData planAircraftData)
        {
            return base.Channel.CommitPlanAircraftDTO(planAircraftData);
        }

        public System.Threading.Tasks.Task<PlanAircraftResultData> CommitPlanAircraftDTOAsync(PlanAircraftResultData planAircraftData)
        {
            return base.Channel.CommitPlanAircraftDTOAsync(planAircraftData);
        }

        public PlanDataObjectList GetAllPlanDTO()
        {
            return base.Channel.GetAllPlanDTO();
        }

        public System.Threading.Tasks.Task<PlanDataObjectList> GetAllPlanDTOAsync()
        {
            return base.Channel.GetAllPlanDTOAsync();
        }

        public PlanDataObject GetPlanDTOByPlanID(System.Guid planId)
        {
            return base.Channel.GetPlanDTOByPlanID(planId);
        }

        public System.Threading.Tasks.Task<PlanDataObject> GetPlanDTOByPlanIDAsync(System.Guid planId)
        {
            return base.Channel.GetPlanDTOByPlanIDAsync(planId);
        }

        public PlanDataObjectList GetPlanDTOListByAnnualID(System.Guid annualId)
        {
            return base.Channel.GetPlanDTOListByAnnualID(annualId);
        }

        public System.Threading.Tasks.Task<PlanDataObjectList> GetPlanDTOListByAnnualIDAsync(System.Guid annualId)
        {
            return base.Channel.GetPlanDTOListByAnnualIDAsync(annualId);
        }

        public PlanHistoryDataObjectList GetPlanHistoryDTOListByPlanID(System.Guid planId)
        {
            return base.Channel.GetPlanHistoryDTOListByPlanID(planId);
        }

        public System.Threading.Tasks.Task<PlanHistoryDataObjectList> GetPlanHistoryDTOListByPlanIDAsync(System.Guid planId)
        {
            return base.Channel.GetPlanHistoryDTOListByPlanIDAsync(planId);
        }

        public PlanDataObject GetCurrentPlanDTO()
        {
            return base.Channel.GetCurrentPlanDTO();
        }

        public System.Threading.Tasks.Task<PlanDataObject> GetCurrentPlanDTOAsync()
        {
            return base.Channel.GetCurrentPlanDTOAsync();
        }

        public PlanResultData CommitPlanDTO(PlanResultData planData)
        {
            return base.Channel.CommitPlanDTO(planData);
        }

        public System.Threading.Tasks.Task<PlanResultData> CommitPlanDTOAsync(PlanResultData planData)
        {
            return base.Channel.CommitPlanDTOAsync(planData);
        }

        public PlanEngineDataObjectList GetAllPlanEngineDTO()
        {
            return base.Channel.GetAllPlanEngineDTO();
        }

        public System.Threading.Tasks.Task<PlanEngineDataObjectList> GetAllPlanEngineDTOAsync()
        {
            return base.Channel.GetAllPlanEngineDTOAsync();
        }

        public PlanEngineDataObject GetPlanEngineDTOByPlanEngineID(System.Guid planEngineId)
        {
            return base.Channel.GetPlanEngineDTOByPlanEngineID(planEngineId);
        }

        public System.Threading.Tasks.Task<PlanEngineDataObject> GetPlanEngineDTOByPlanEngineIDAsync(System.Guid planEngineId)
        {
            return base.Channel.GetPlanEngineDTOByPlanEngineIDAsync(planEngineId);
        }

        public EnginePlanHistoryDataObjectList GetEnginePlanHistoryDTOListByPlanEngineID(System.Guid planEngineId)
        {
            return base.Channel.GetEnginePlanHistoryDTOListByPlanEngineID(planEngineId);
        }

        public System.Threading.Tasks.Task<EnginePlanHistoryDataObjectList> GetEnginePlanHistoryDTOListByPlanEngineIDAsync(System.Guid planEngineId)
        {
            return base.Channel.GetEnginePlanHistoryDTOListByPlanEngineIDAsync(planEngineId);
        }

        public PlanEngineResultData CommitPlanEngineDTO(PlanEngineResultData planEngineData)
        {
            return base.Channel.CommitPlanEngineDTO(planEngineData);
        }

        public System.Threading.Tasks.Task<PlanEngineResultData> CommitPlanEngineDTOAsync(PlanEngineResultData planEngineData)
        {
            return base.Channel.CommitPlanEngineDTOAsync(planEngineData);
        }

        public ProgrammingDataObjectList GetAllProgrammingDTO()
        {
            return base.Channel.GetAllProgrammingDTO();
        }

        public System.Threading.Tasks.Task<ProgrammingDataObjectList> GetAllProgrammingDTOAsync()
        {
            return base.Channel.GetAllProgrammingDTOAsync();
        }

        public ProgrammingDataObject GetProgrammingDTOByProgrammingID(System.Guid programmingId)
        {
            return base.Channel.GetProgrammingDTOByProgrammingID(programmingId);
        }

        public System.Threading.Tasks.Task<ProgrammingDataObject> GetProgrammingDTOByProgrammingIDAsync(System.Guid programmingId)
        {
            return base.Channel.GetProgrammingDTOByProgrammingIDAsync(programmingId);
        }

        public CAACProgrammingDataObjectList GetAllCAACProgrammingDTO()
        {
            return base.Channel.GetAllCAACProgrammingDTO();
        }

        public System.Threading.Tasks.Task<CAACProgrammingDataObjectList> GetAllCAACProgrammingDTOAsync()
        {
            return base.Channel.GetAllCAACProgrammingDTOAsync();
        }

        public CAACProgrammingDataObject GetCAACProgrammingDTOByCaacProgrammingID(System.Guid caacProgrammingID)
        {
            return base.Channel.GetCAACProgrammingDTOByCaacProgrammingID(caacProgrammingID);
        }

        public System.Threading.Tasks.Task<CAACProgrammingDataObject> GetCAACProgrammingDTOByCaacProgrammingIDAsync(System.Guid caacProgrammingID)
        {
            return base.Channel.GetCAACProgrammingDTOByCaacProgrammingIDAsync(caacProgrammingID);
        }

        public CAACProgrammingDetailDataObjectList GetCAACProgrammingDetailDTOListByCaacProgrammingID(System.Guid caacProgrammingId)
        {
            return base.Channel.GetCAACProgrammingDetailDTOListByCaacProgrammingID(caacProgrammingId);
        }

        public System.Threading.Tasks.Task<CAACProgrammingDetailDataObjectList> GetCAACProgrammingDetailDTOListByCaacProgrammingIDAsync(System.Guid caacProgrammingId)
        {
            return base.Channel.GetCAACProgrammingDetailDTOListByCaacProgrammingIDAsync(caacProgrammingId);
        }

        public CAACProgrammingResultData CommitCAACProgrammingDTO(CAACProgrammingResultData caacProgrammingData)
        {
            return base.Channel.CommitCAACProgrammingDTO(caacProgrammingData);
        }

        public System.Threading.Tasks.Task<CAACProgrammingResultData> CommitCAACProgrammingDTOAsync(CAACProgrammingResultData caacProgrammingData)
        {
            return base.Channel.CommitCAACProgrammingDTOAsync(caacProgrammingData);
        }

        public RAApprovalDocDataObjectList GetAllRAApprovalDocDTO()
        {
            return base.Channel.GetAllRAApprovalDocDTO();
        }

        public System.Threading.Tasks.Task<RAApprovalDocDataObjectList> GetAllRAApprovalDocDTOAsync()
        {
            return base.Channel.GetAllRAApprovalDocDTOAsync();
        }

        public RAApprovalDocDataObject GetRAApprovalDocDTOByRAApprovalDocID(System.Guid raApprovalDocId)
        {
            return base.Channel.GetRAApprovalDocDTOByRAApprovalDocID(raApprovalDocId);
        }

        public System.Threading.Tasks.Task<RAApprovalDocDataObject> GetRAApprovalDocDTOByRAApprovalDocIDAsync(System.Guid raApprovalDocId)
        {
            return base.Channel.GetRAApprovalDocDTOByRAApprovalDocIDAsync(raApprovalDocId);
        }

        public RARequestDataObjectList GetRARequestDTOListByRAApprovalDocID(System.Guid raApprovalDocId)
        {
            return base.Channel.GetRARequestDTOListByRAApprovalDocID(raApprovalDocId);
        }

        public System.Threading.Tasks.Task<RARequestDataObjectList> GetRARequestDTOListByRAApprovalDocIDAsync(System.Guid raApprovalDocId)
        {
            return base.Channel.GetRARequestDTOListByRAApprovalDocIDAsync(raApprovalDocId);
        }

        public RAApprovalDocResultData CommitRAApprovalDocDTO(RAApprovalDocResultData raApprovalDocData)
        {
            return base.Channel.CommitRAApprovalDocDTO(raApprovalDocData);
        }

        public System.Threading.Tasks.Task<RAApprovalDocResultData> CommitRAApprovalDocDTOAsync(RAApprovalDocResultData raApprovalDocData)
        {
            return base.Channel.CommitRAApprovalDocDTOAsync(raApprovalDocData);
        }

        public RAApprovalHistoryDataObjectList GetAllRAApprovalHistoryDTO()
        {
            return base.Channel.GetAllRAApprovalHistoryDTO();
        }

        public System.Threading.Tasks.Task<RAApprovalHistoryDataObjectList> GetAllRAApprovalHistoryDTOAsync()
        {
            return base.Channel.GetAllRAApprovalHistoryDTOAsync();
        }

        public RAApprovalHistoryDataObject GetRAApprovalHistoryDTOByRAApprovalHistoryID(System.Guid raApprovalHistoryId)
        {
            return base.Channel.GetRAApprovalHistoryDTOByRAApprovalHistoryID(raApprovalHistoryId);
        }

        public System.Threading.Tasks.Task<RAApprovalHistoryDataObject> GetRAApprovalHistoryDTOByRAApprovalHistoryIDAsync(System.Guid raApprovalHistoryId)
        {
            return base.Channel.GetRAApprovalHistoryDTOByRAApprovalHistoryIDAsync(raApprovalHistoryId);
        }

        public RAApprovalHistoryDataObjectList GetRAApprovalHistoryDTOListByPlanAircraftID(System.Guid planAircraftId)
        {
            return base.Channel.GetRAApprovalHistoryDTOListByPlanAircraftID(planAircraftId);
        }

        public System.Threading.Tasks.Task<RAApprovalHistoryDataObjectList> GetRAApprovalHistoryDTOListByPlanAircraftIDAsync(System.Guid planAircraftId)
        {
            return base.Channel.GetRAApprovalHistoryDTOListByPlanAircraftIDAsync(planAircraftId);
        }

        public RARequestDataObjectList GetAllRARequestDTO()
        {
            return base.Channel.GetAllRARequestDTO();
        }

        public System.Threading.Tasks.Task<RARequestDataObjectList> GetAllRARequestDTOAsync()
        {
            return base.Channel.GetAllRARequestDTOAsync();
        }

        public RARequestDataObject GetRARequestDTOByRARequestID(System.Guid raRequestId)
        {
            return base.Channel.GetRARequestDTOByRARequestID(raRequestId);
        }

        public System.Threading.Tasks.Task<RARequestDataObject> GetRARequestDTOByRARequestIDAsync(System.Guid raRequestId)
        {
            return base.Channel.GetRARequestDTOByRARequestIDAsync(raRequestId);
        }

        public RAApprovalHistoryDataObjectList GetRAApprovalHistoryDTOListByRARequestID(System.Guid raRequestId)
        {
            return base.Channel.GetRAApprovalHistoryDTOListByRARequestID(raRequestId);
        }

        public System.Threading.Tasks.Task<RAApprovalHistoryDataObjectList> GetRAApprovalHistoryDTOListByRARequestIDAsync(System.Guid raRequestId)
        {
            return base.Channel.GetRAApprovalHistoryDTOListByRARequestIDAsync(raRequestId);
        }

        public RARequestResultData CommitRARequestDTO(RARequestResultData raRequestData)
        {
            return base.Channel.CommitRARequestDTO(raRequestData);
        }

        public System.Threading.Tasks.Task<RARequestResultData> CommitRARequestDTOAsync(RARequestResultData raRequestData)
        {
            return base.Channel.CommitRARequestDTOAsync(raRequestData);
        }

        public RequestDataObjectList GetAllRequestDTO()
        {
            return base.Channel.GetAllRequestDTO();
        }

        public System.Threading.Tasks.Task<RequestDataObjectList> GetAllRequestDTOAsync()
        {
            return base.Channel.GetAllRequestDTOAsync();
        }

        public RequestDataObject GetRequestDTOByRequestID(System.Guid requestId)
        {
            return base.Channel.GetRequestDTOByRequestID(requestId);
        }

        public System.Threading.Tasks.Task<RequestDataObject> GetRequestDTOByRequestIDAsync(System.Guid requestId)
        {
            return base.Channel.GetRequestDTOByRequestIDAsync(requestId);
        }

        public ApprovalHistoryDataObjectList GetApprovalHistoryDTOListByRequestID(System.Guid requestId)
        {
            return base.Channel.GetApprovalHistoryDTOListByRequestID(requestId);
        }

        public System.Threading.Tasks.Task<ApprovalHistoryDataObjectList> GetApprovalHistoryDTOListByRequestIDAsync(System.Guid requestId)
        {
            return base.Channel.GetApprovalHistoryDTOListByRequestIDAsync(requestId);
        }

        public RequestResultData CommitRequestDTO(RequestResultData requestData)
        {
            return base.Channel.CommitRequestDTO(requestData);
        }

        public System.Threading.Tasks.Task<RequestResultData> CommitRequestDTOAsync(RequestResultData requestData)
        {
            return base.Channel.CommitRequestDTOAsync(requestData);
        }

        public SAWSApprovalDocDataObjectList GetAllSAWSApprovalDocDTO()
        {
            return base.Channel.GetAllSAWSApprovalDocDTO();
        }

        public System.Threading.Tasks.Task<SAWSApprovalDocDataObjectList> GetAllSAWSApprovalDocDTOAsync()
        {
            return base.Channel.GetAllSAWSApprovalDocDTOAsync();
        }

        public SAWSApprovalDocDataObject GetSAWSApprovalDocDTOBySAWSApprovalDocID(System.Guid sawspprovalDocId)
        {
            return base.Channel.GetSAWSApprovalDocDTOBySAWSApprovalDocID(sawspprovalDocId);
        }

        public System.Threading.Tasks.Task<SAWSApprovalDocDataObject> GetSAWSApprovalDocDTOBySAWSApprovalDocIDAsync(System.Guid sawspprovalDocId)
        {
            return base.Channel.GetSAWSApprovalDocDTOBySAWSApprovalDocIDAsync(sawspprovalDocId);
        }

        public SAWSRequestDataObjectList GetSAWSRequestDTOListBySAWSApprovalDocID(System.Guid sawspprovalDocId)
        {
            return base.Channel.GetSAWSRequestDTOListBySAWSApprovalDocID(sawspprovalDocId);
        }

        public System.Threading.Tasks.Task<SAWSRequestDataObjectList> GetSAWSRequestDTOListBySAWSApprovalDocIDAsync(System.Guid sawspprovalDocId)
        {
            return base.Channel.GetSAWSRequestDTOListBySAWSApprovalDocIDAsync(sawspprovalDocId);
        }

        public SAWSApprovalDocResultData CommitSAWSApprovalDocDTO(SAWSApprovalDocResultData sawsApprovalDocData)
        {
            return base.Channel.CommitSAWSApprovalDocDTO(sawsApprovalDocData);
        }

        public System.Threading.Tasks.Task<SAWSApprovalDocResultData> CommitSAWSApprovalDocDTOAsync(SAWSApprovalDocResultData sawsApprovalDocData)
        {
            return base.Channel.CommitSAWSApprovalDocDTOAsync(sawsApprovalDocData);
        }

        public SAWSApprovalHistoryDataObjectList GetAllSAWSApprovalHistoryDTO()
        {
            return base.Channel.GetAllSAWSApprovalHistoryDTO();
        }

        public System.Threading.Tasks.Task<SAWSApprovalHistoryDataObjectList> GetAllSAWSApprovalHistoryDTOAsync()
        {
            return base.Channel.GetAllSAWSApprovalHistoryDTOAsync();
        }

        public SAWSApprovalHistoryDataObject GetSAWSApprovalHistoryDTOBySAWSApprovalHistoryID(System.Guid sawsApprovalHistoryId)
        {
            return base.Channel.GetSAWSApprovalHistoryDTOBySAWSApprovalHistoryID(sawsApprovalHistoryId);
        }

        public System.Threading.Tasks.Task<SAWSApprovalHistoryDataObject> GetSAWSApprovalHistoryDTOBySAWSApprovalHistoryIDAsync(System.Guid sawsApprovalHistoryId)
        {
            return base.Channel.GetSAWSApprovalHistoryDTOBySAWSApprovalHistoryIDAsync(sawsApprovalHistoryId);
        }

        public SAWSApprovalHistoryDataObjectList GetSAWSApprovalHistoryDTOListByPlanAircraftID(System.Guid planAircraftId)
        {
            return base.Channel.GetSAWSApprovalHistoryDTOListByPlanAircraftID(planAircraftId);
        }

        public System.Threading.Tasks.Task<SAWSApprovalHistoryDataObjectList> GetSAWSApprovalHistoryDTOListByPlanAircraftIDAsync(System.Guid planAircraftId)
        {
            return base.Channel.GetSAWSApprovalHistoryDTOListByPlanAircraftIDAsync(planAircraftId);
        }

        public SAWSRequestDataObjectList GetAllSAWSRequestDTO()
        {
            return base.Channel.GetAllSAWSRequestDTO();
        }

        public System.Threading.Tasks.Task<SAWSRequestDataObjectList> GetAllSAWSRequestDTOAsync()
        {
            return base.Channel.GetAllSAWSRequestDTOAsync();
        }

        public SAWSRequestDataObject GetSAWSRequestDTOBySAWSRequestID(System.Guid sawsRequestId)
        {
            return base.Channel.GetSAWSRequestDTOBySAWSRequestID(sawsRequestId);
        }

        public System.Threading.Tasks.Task<SAWSRequestDataObject> GetSAWSRequestDTOBySAWSRequestIDAsync(System.Guid sawsRequestId)
        {
            return base.Channel.GetSAWSRequestDTOBySAWSRequestIDAsync(sawsRequestId);
        }

        public SAWSApprovalHistoryDataObjectList GetSAWSApprovalHistoryDTOListBySAWSRequestID(System.Guid sawsRequestId)
        {
            return base.Channel.GetSAWSApprovalHistoryDTOListBySAWSRequestID(sawsRequestId);
        }

        public System.Threading.Tasks.Task<SAWSApprovalHistoryDataObjectList> GetSAWSApprovalHistoryDTOListBySAWSRequestIDAsync(System.Guid sawsRequestId)
        {
            return base.Channel.GetSAWSApprovalHistoryDTOListBySAWSRequestIDAsync(sawsRequestId);
        }

        public SAWSRequestResultData CommitSAWSRequestDTO(SAWSRequestResultData sawsRequestData)
        {
            return base.Channel.CommitSAWSRequestDTO(sawsRequestData);
        }

        public System.Threading.Tasks.Task<SAWSRequestResultData> CommitSAWSRequestDTOAsync(SAWSRequestResultData sawsRequestData)
        {
            return base.Channel.CommitSAWSRequestDTOAsync(sawsRequestData);
        }

        public SubOperationHistoryDataObjectList GetSubOperationHistoryDTOList()
        {
            return base.Channel.GetSubOperationHistoryDTOList();
        }

        public System.Threading.Tasks.Task<SubOperationHistoryDataObjectList> GetSubOperationHistoryDTOListAsync()
        {
            return base.Channel.GetSubOperationHistoryDTOListAsync();
        }

        public string GetAcRegByContractRank(string contractNum, int rankNumber)
        {
            return base.Channel.GetAcRegByContractRank(contractNum, rankNumber);
        }

        public System.Threading.Tasks.Task<string> GetAcRegByContractRankAsync(string contractNum, int rankNumber)
        {
            return base.Channel.GetAcRegByContractRankAsync(contractNum, rankNumber);
        }

        public bool ValidationByContractRank(string contractNum, int rankNumber)
        {
            return base.Channel.ValidationByContractRank(contractNum, rankNumber);
        }

        public System.Threading.Tasks.Task<bool> ValidationByContractRankAsync(string contractNum, int rankNumber)
        {
            return base.Channel.ValidationByContractRankAsync(contractNum, rankNumber);
        }

        public ActionCategoryWithPagination GetActionCategoryWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetActionCategoryWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<ActionCategoryWithPagination> GetActionCategoryWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetActionCategoryWithPaginationAsync(pagination);
        }

        public AircraftCategoryWithPagination GetAircraftCategoryWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetAircraftCategoryWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<AircraftCategoryWithPagination> GetAircraftCategoryWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetAircraftCategoryWithPaginationAsync(pagination);
        }

        public AircraftWithPagination GetAircraftWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetAircraftWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<AircraftWithPagination> GetAircraftWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetAircraftWithPaginationAsync(pagination);
        }

        public AircraftTypeWithPagination GetAircraftTypeWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetAircraftTypeWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<AircraftTypeWithPagination> GetAircraftTypeWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetAircraftTypeWithPaginationAsync(pagination);
        }

        public AirlineProgrammingWithPagination GetAirlineProgrammingWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetAirlineProgrammingWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<AirlineProgrammingWithPagination> GetAirlineProgrammingWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetAirlineProgrammingWithPaginationAsync(pagination);
        }

        public AnnualSummaryWithPagination GetAnnualSummaryWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetAnnualSummaryWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<AnnualSummaryWithPagination> GetAnnualSummaryWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetAnnualSummaryWithPaginationAsync(pagination);
        }

        public ApprovalDocWithPagination GetApprovalDocWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetApprovalDocWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<ApprovalDocWithPagination> GetApprovalDocWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetApprovalDocWithPaginationAsync(pagination);
        }

        public CAACProgrammingWithPagination GetCAACProgrammingWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetCAACProgrammingWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<CAACProgrammingWithPagination> GetCAACProgrammingWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetCAACProgrammingWithPaginationAsync(pagination);
        }

        public EnginePlanWithPagination GetEnginePlanWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetEnginePlanWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<EnginePlanWithPagination> GetEnginePlanWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetEnginePlanWithPaginationAsync(pagination);
        }

        public EngineWithPagination GetEngineWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetEngineWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<EngineWithPagination> GetEngineWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetEngineWithPaginationAsync(pagination);
        }

        public EngineTypeWithPagination GetEngineTypeWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetEngineTypeWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<EngineTypeWithPagination> GetEngineTypeWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetEngineTypeWithPaginationAsync(pagination);
        }

        public NDRCApprovalDocWithPagination GetNDRCApprovalDocWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetNDRCApprovalDocWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<NDRCApprovalDocWithPagination> GetNDRCApprovalDocWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetNDRCApprovalDocWithPaginationAsync(pagination);
        }

        public SupplierDataObjectList GetAllSupplierDTO()
        {
            return base.Channel.GetAllSupplierDTO();
        }

        public System.Threading.Tasks.Task<SupplierDataObjectList> GetAllSupplierDTOAsync()
        {
            return base.Channel.GetAllSupplierDTOAsync();
        }

        public SupplierDataObject GetSupplierDTOBySupplierId(System.Guid supplierId)
        {
            return base.Channel.GetSupplierDTOBySupplierId(supplierId);
        }

        public System.Threading.Tasks.Task<SupplierDataObject> GetSupplierDTOBySupplierIdAsync(System.Guid supplierId)
        {
            return base.Channel.GetSupplierDTOBySupplierIdAsync(supplierId);
        }

        public SupplierResultData CommitSupplierDTO(SupplierResultData supplierData)
        {
            return base.Channel.CommitSupplierDTO(supplierData);
        }

        public System.Threading.Tasks.Task<SupplierResultData> CommitSupplierDTOAsync(SupplierResultData supplierData)
        {
            return base.Channel.CommitSupplierDTOAsync(supplierData);
        }

        public XmlSettingDataObjectList GetAllXmlSettingDTO()
        {
            return base.Channel.GetAllXmlSettingDTO();
        }

        public System.Threading.Tasks.Task<XmlSettingDataObjectList> GetAllXmlSettingDTOAsync()
        {
            return base.Channel.GetAllXmlSettingDTOAsync();
        }

        public XmlSettingDataObject GetXmlSettingDTOBySettingType(string settingType)
        {
            return base.Channel.GetXmlSettingDTOBySettingType(settingType);
        }

        public System.Threading.Tasks.Task<XmlSettingDataObject> GetXmlSettingDTOBySettingTypeAsync(string settingType)
        {
            return base.Channel.GetXmlSettingDTOBySettingTypeAsync(settingType);
        }

        public XmlSettingDataObject GetXmlSettingDTOByXmlSettingID(System.Guid xmlSettingID)
        {
            return base.Channel.GetXmlSettingDTOByXmlSettingID(xmlSettingID);
        }

        public System.Threading.Tasks.Task<XmlSettingDataObject> GetXmlSettingDTOByXmlSettingIDAsync(System.Guid xmlSettingID)
        {
            return base.Channel.GetXmlSettingDTOByXmlSettingIDAsync(xmlSettingID);
        }

        public XmlSettingResultData CommitXmlSettingDTO(XmlSettingResultData XmlSettingData)
        {
            return base.Channel.CommitXmlSettingDTO(XmlSettingData);
        }

        public System.Threading.Tasks.Task<XmlSettingResultData> CommitXmlSettingDTOAsync(XmlSettingResultData XmlSettingData)
        {
            return base.Channel.CommitXmlSettingDTOAsync(XmlSettingData);
        }

        public XmlConfigDataObjectList GetAllXmlConfigDTO()
        {
            return base.Channel.GetAllXmlConfigDTO();
        }

        public System.Threading.Tasks.Task<XmlConfigDataObjectList> GetAllXmlConfigDTOAsync()
        {
            return base.Channel.GetAllXmlConfigDTOAsync();
        }

        public XmlConfigDataObject GetXmlConfigDTOByConfigType(string configType)
        {
            return base.Channel.GetXmlConfigDTOByConfigType(configType);
        }

        public System.Threading.Tasks.Task<XmlConfigDataObject> GetXmlConfigDTOByConfigTypeAsync(string configType)
        {
            return base.Channel.GetXmlConfigDTOByConfigTypeAsync(configType);
        }

        public ActionCategoryDataObjectList GetAllActionCategoryDTO()
        {
            return base.Channel.GetAllActionCategoryDTO();
        }

        public System.Threading.Tasks.Task<ActionCategoryDataObjectList> GetAllActionCategoryDTOAsync()
        {
            return base.Channel.GetAllActionCategoryDTOAsync();
        }

        public ActionCategoryDataObject GetActionCategoryDTOByActionCategoryID(System.Guid actionCategoryId)
        {
            return base.Channel.GetActionCategoryDTOByActionCategoryID(actionCategoryId);
        }

        public System.Threading.Tasks.Task<ActionCategoryDataObject> GetActionCategoryDTOByActionCategoryIDAsync(System.Guid actionCategoryId)
        {
            return base.Channel.GetActionCategoryDTOByActionCategoryIDAsync(actionCategoryId);
        }

        public ActionCategoryDataObjectList GetPurchaseActionCategorys()
        {
            return base.Channel.GetPurchaseActionCategorys();
        }

        public System.Threading.Tasks.Task<ActionCategoryDataObjectList> GetPurchaseActionCategorysAsync()
        {
            return base.Channel.GetPurchaseActionCategorysAsync();
        }

        public ActionCategoryDataObjectList GetLeaseActionCategorys()
        {
            return base.Channel.GetLeaseActionCategorys();
        }

        public System.Threading.Tasks.Task<ActionCategoryDataObjectList> GetLeaseActionCategorysAsync()
        {
            return base.Channel.GetLeaseActionCategorysAsync();
        }

        public AircraftBusinessDataObjectList GetAllAircraftBusinessDTO()
        {
            return base.Channel.GetAllAircraftBusinessDTO();
        }

        public System.Threading.Tasks.Task<AircraftBusinessDataObjectList> GetAllAircraftBusinessDTOAsync()
        {
            return base.Channel.GetAllAircraftBusinessDTOAsync();
        }

        public AircraftBusinessDataObject GetAircraftBusinessDTOByAircraftBusinessID(System.Guid aircraftBusinessId)
        {
            return base.Channel.GetAircraftBusinessDTOByAircraftBusinessID(aircraftBusinessId);
        }

        public System.Threading.Tasks.Task<AircraftBusinessDataObject> GetAircraftBusinessDTOByAircraftBusinessIDAsync(System.Guid aircraftBusinessId)
        {
            return base.Channel.GetAircraftBusinessDTOByAircraftBusinessIDAsync(aircraftBusinessId);
        }

        public AircraftBusinessDataObjectList GetAircraftBusinessDTOListByAircraftID(System.Guid aircraftId)
        {
            return base.Channel.GetAircraftBusinessDTOListByAircraftID(aircraftId);
        }

        public System.Threading.Tasks.Task<AircraftBusinessDataObjectList> GetAircraftBusinessDTOListByAircraftIDAsync(System.Guid aircraftId)
        {
            return base.Channel.GetAircraftBusinessDTOListByAircraftIDAsync(aircraftId);
        }

        public AircraftCategoryDataObjectList GetAllAircraftCategoryDTO()
        {
            return base.Channel.GetAllAircraftCategoryDTO();
        }

        public System.Threading.Tasks.Task<AircraftCategoryDataObjectList> GetAllAircraftCategoryDTOAsync()
        {
            return base.Channel.GetAllAircraftCategoryDTOAsync();
        }

        public AircraftCategoryDataObject GetAircraftCategoryDTOByAircraftCategoryID(System.Guid aircraftCategoryID)
        {
            return base.Channel.GetAircraftCategoryDTOByAircraftCategoryID(aircraftCategoryID);
        }

        public System.Threading.Tasks.Task<AircraftCategoryDataObject> GetAircraftCategoryDTOByAircraftCategoryIDAsync(System.Guid aircraftCategoryID)
        {
            return base.Channel.GetAircraftCategoryDTOByAircraftCategoryIDAsync(aircraftCategoryID);
        }

        public AircraftTypeDataObjectList GetAircraftTypeDTOListByAircraftCategoryID(System.Guid aircraftCategoryID)
        {
            return base.Channel.GetAircraftTypeDTOListByAircraftCategoryID(aircraftCategoryID);
        }

        public System.Threading.Tasks.Task<AircraftTypeDataObjectList> GetAircraftTypeDTOListByAircraftCategoryIDAsync(System.Guid aircraftCategoryID)
        {
            return base.Channel.GetAircraftTypeDTOListByAircraftCategoryIDAsync(aircraftCategoryID);
        }

        public AircraftCategoryResultData CommitAircraftCategoryDTO(AircraftCategoryResultData aircraftCategoryData)
        {
            return base.Channel.CommitAircraftCategoryDTO(aircraftCategoryData);
        }

        public System.Threading.Tasks.Task<AircraftCategoryResultData> CommitAircraftCategoryDTOAsync(AircraftCategoryResultData aircraftCategoryData)
        {
            return base.Channel.CommitAircraftCategoryDTOAsync(aircraftCategoryData);
        }

        public AircraftDataObjectList GetAllAircraftDTO()
        {
            return base.Channel.GetAllAircraftDTO();
        }

        public System.Threading.Tasks.Task<AircraftDataObjectList> GetAllAircraftDTOAsync()
        {
            return base.Channel.GetAllAircraftDTOAsync();
        }

        public AircraftDataObject GetAircraftDTOByAircraftID(System.Guid aircraftId)
        {
            return base.Channel.GetAircraftDTOByAircraftID(aircraftId);
        }

        public System.Threading.Tasks.Task<AircraftDataObject> GetAircraftDTOByAircraftIDAsync(System.Guid aircraftId)
        {
            return base.Channel.GetAircraftDTOByAircraftIDAsync(aircraftId);
        }

        public AircraftDataObjectList GetAircraftDTOListByAirlinesID(System.Guid airlinesID)
        {
            return base.Channel.GetAircraftDTOListByAirlinesID(airlinesID);
        }

        public System.Threading.Tasks.Task<AircraftDataObjectList> GetAircraftDTOListByAirlinesIDAsync(System.Guid airlinesID)
        {
            return base.Channel.GetAircraftDTOListByAirlinesIDAsync(airlinesID);
        }

        public AircraftDataObjectList GetAircraftDTOListByAircraftTypeID(System.Guid aircraftTypeId)
        {
            return base.Channel.GetAircraftDTOListByAircraftTypeID(aircraftTypeId);
        }

        public System.Threading.Tasks.Task<AircraftDataObjectList> GetAircraftDTOListByAircraftTypeIDAsync(System.Guid aircraftTypeId)
        {
            return base.Channel.GetAircraftDTOListByAircraftTypeIDAsync(aircraftTypeId);
        }

        public PlanAircraftDataObjectList GetPlanAircraftDTOListByAircraftID(System.Guid aircraftId)
        {
            return base.Channel.GetPlanAircraftDTOListByAircraftID(aircraftId);
        }

        public System.Threading.Tasks.Task<PlanAircraftDataObjectList> GetPlanAircraftDTOListByAircraftIDAsync(System.Guid aircraftId)
        {
            return base.Channel.GetPlanAircraftDTOListByAircraftIDAsync(aircraftId);
        }

        public OperationHistoryDataObjectList GetOperationHistoryDTOListByAircraftID(System.Guid aircraftId)
        {
            return base.Channel.GetOperationHistoryDTOListByAircraftID(aircraftId);
        }

        public System.Threading.Tasks.Task<OperationHistoryDataObjectList> GetOperationHistoryDTOListByAircraftIDAsync(System.Guid aircraftId)
        {
            return base.Channel.GetOperationHistoryDTOListByAircraftIDAsync(aircraftId);
        }

        public AircraftResultData CommitAircraftDTO(AircraftResultData aircraftData)
        {
            return base.Channel.CommitAircraftDTO(aircraftData);
        }

        public System.Threading.Tasks.Task<AircraftResultData> CommitAircraftDTOAsync(AircraftResultData aircraftData)
        {
            return base.Channel.CommitAircraftDTOAsync(aircraftData);
        }

        public AircraftTypeDataObjectList GetAllAircraftTypeDTO()
        {
            return base.Channel.GetAllAircraftTypeDTO();
        }

        public System.Threading.Tasks.Task<AircraftTypeDataObjectList> GetAllAircraftTypeDTOAsync()
        {
            return base.Channel.GetAllAircraftTypeDTOAsync();
        }

        public AircraftTypeDataObject GetAircraftTypeDTOByAircraftTypeID(System.Guid aircraftTypeId)
        {
            return base.Channel.GetAircraftTypeDTOByAircraftTypeID(aircraftTypeId);
        }

        public System.Threading.Tasks.Task<AircraftTypeDataObject> GetAircraftTypeDTOByAircraftTypeIDAsync(System.Guid aircraftTypeId)
        {
            return base.Channel.GetAircraftTypeDTOByAircraftTypeIDAsync(aircraftTypeId);
        }

        public AircraftTypeResultData CommitAircraftTypeDTO(AircraftTypeResultData aircraftTypeData)
        {
            return base.Channel.CommitAircraftTypeDTO(aircraftTypeData);
        }

        public System.Threading.Tasks.Task<AircraftTypeResultData> CommitAircraftTypeDTOAsync(AircraftTypeResultData aircraftTypeData)
        {
            return base.Channel.CommitAircraftTypeDTOAsync(aircraftTypeData);
        }

        public AirlineProgrammingDataObjectList GetAllAirlineProgrammingDTO()
        {
            return base.Channel.GetAllAirlineProgrammingDTO();
        }

        public System.Threading.Tasks.Task<AirlineProgrammingDataObjectList> GetAllAirlineProgrammingDTOAsync()
        {
            return base.Channel.GetAllAirlineProgrammingDTOAsync();
        }

        public AirlineProgrammingDataObject GetAirlineProgrammingDTOByAirlineProgrammingID(System.Guid airlineProgrammingId)
        {
            return base.Channel.GetAirlineProgrammingDTOByAirlineProgrammingID(airlineProgrammingId);
        }

        public System.Threading.Tasks.Task<AirlineProgrammingDataObject> GetAirlineProgrammingDTOByAirlineProgrammingIDAsync(System.Guid airlineProgrammingId)
        {
            return base.Channel.GetAirlineProgrammingDTOByAirlineProgrammingIDAsync(airlineProgrammingId);
        }

        public AirlineProgrammingDetailDataObjectList GetAirlineProgrammingDetailDTOListByAirlineProgrammingID(System.Guid airlineProgrammingId)
        {
            return base.Channel.GetAirlineProgrammingDetailDTOListByAirlineProgrammingID(airlineProgrammingId);
        }

        public System.Threading.Tasks.Task<AirlineProgrammingDetailDataObjectList> GetAirlineProgrammingDetailDTOListByAirlineProgrammingIDAsync(System.Guid airlineProgrammingId)
        {
            return base.Channel.GetAirlineProgrammingDetailDTOListByAirlineProgrammingIDAsync(airlineProgrammingId);
        }

        public AirlineProgrammingResultData CommitAirlineProgrammingDTO(AirlineProgrammingResultData airlineProgrammingData)
        {
            return base.Channel.CommitAirlineProgrammingDTO(airlineProgrammingData);
        }

        public System.Threading.Tasks.Task<AirlineProgrammingResultData> CommitAirlineProgrammingDTOAsync(AirlineProgrammingResultData airlineProgrammingData)
        {
            return base.Channel.CommitAirlineProgrammingDTOAsync(airlineProgrammingData);
        }

        public AirlinesDataObject GetCurrentAirlinesDTO()
        {
            return base.Channel.GetCurrentAirlinesDTO();
        }

        public System.Threading.Tasks.Task<AirlinesDataObject> GetCurrentAirlinesDTOAsync()
        {
            return base.Channel.GetCurrentAirlinesDTOAsync();
        }

        public AirlinesDataObjectList GetAllAirlinesDTO()
        {
            return base.Channel.GetAllAirlinesDTO();
        }

        public System.Threading.Tasks.Task<AirlinesDataObjectList> GetAllAirlinesDTOAsync()
        {
            return base.Channel.GetAllAirlinesDTOAsync();
        }

        public AirlinesDataObjectList GetAllSubsidiaryDTO(System.Guid masterID)
        {
            return base.Channel.GetAllSubsidiaryDTO(masterID);
        }

        public System.Threading.Tasks.Task<AirlinesDataObjectList> GetAllSubsidiaryDTOAsync(System.Guid masterID)
        {
            return base.Channel.GetAllSubsidiaryDTOAsync(masterID);
        }

        public AirlinesDataObjectList GetAllFilialeDTO(System.Guid masterID)
        {
            return base.Channel.GetAllFilialeDTO(masterID);
        }

        public System.Threading.Tasks.Task<AirlinesDataObjectList> GetAllFilialeDTOAsync(System.Guid masterID)
        {
            return base.Channel.GetAllFilialeDTOAsync(masterID);
        }

        public AirlinesDataObject GetAirlinesDTOByAirlinesID(System.Guid airlinesId)
        {
            return base.Channel.GetAirlinesDTOByAirlinesID(airlinesId);
        }

        public System.Threading.Tasks.Task<AirlinesDataObject> GetAirlinesDTOByAirlinesIDAsync(System.Guid airlinesId)
        {
            return base.Channel.GetAirlinesDTOByAirlinesIDAsync(airlinesId);
        }

        public PlanDataObjectList GetPlanDTOListByAirlinesID(System.Guid airlinesId)
        {
            return base.Channel.GetPlanDTOListByAirlinesID(airlinesId);
        }

        public System.Threading.Tasks.Task<PlanDataObjectList> GetPlanDTOListByAirlinesIDAsync(System.Guid airlinesId)
        {
            return base.Channel.GetPlanDTOListByAirlinesIDAsync(airlinesId);
        }

        public RequestDataObjectList GetRequestDTOListByAirlinesID(System.Guid airlinesId)
        {
            return base.Channel.GetRequestDTOListByAirlinesID(airlinesId);
        }

        public System.Threading.Tasks.Task<RequestDataObjectList> GetRequestDTOListByAirlinesIDAsync(System.Guid airlinesId)
        {
            return base.Channel.GetRequestDTOListByAirlinesIDAsync(airlinesId);
        }

        public AirlinesDataObjectList GetSubAirlinesByAirlinesID(System.Guid airlinesId)
        {
            return base.Channel.GetSubAirlinesByAirlinesID(airlinesId);
        }

        public System.Threading.Tasks.Task<AirlinesDataObjectList> GetSubAirlinesByAirlinesIDAsync(System.Guid airlinesId)
        {
            return base.Channel.GetSubAirlinesByAirlinesIDAsync(airlinesId);
        }

        public AirlinesResultData CommitAirlinesDTO(AirlinesResultData AirlinesData)
        {
            return base.Channel.CommitAirlinesDTO(AirlinesData);
        }

        public System.Threading.Tasks.Task<AirlinesResultData> CommitAirlinesDTOAsync(AirlinesResultData AirlinesData)
        {
            return base.Channel.CommitAirlinesDTOAsync(AirlinesData);
        }

        public AnnualDataObjectList GetAllAnnualDTO()
        {
            return base.Channel.GetAllAnnualDTO();
        }

        public System.Threading.Tasks.Task<AnnualDataObjectList> GetAllAnnualDTOAsync()
        {
            return base.Channel.GetAllAnnualDTOAsync();
        }

        public AnnualDataObject GetAnnualDTOByAnnualID(System.Guid annualId)
        {
            return base.Channel.GetAnnualDTOByAnnualID(annualId);
        }

        public System.Threading.Tasks.Task<AnnualDataObject> GetAnnualDTOByAnnualIDAsync(System.Guid annualId)
        {
            return base.Channel.GetAnnualDTOByAnnualIDAsync(annualId);
        }

        public AnnualDataObject GetCurrentAnnualDTO()
        {
            return base.Channel.GetCurrentAnnualDTO();
        }

        public System.Threading.Tasks.Task<AnnualDataObject> GetCurrentAnnualDTOAsync()
        {
            return base.Channel.GetCurrentAnnualDTOAsync();
        }

        public AnnualSummaryDataObjectList GetAllAnnualSummaryDTO()
        {
            return base.Channel.GetAllAnnualSummaryDTO();
        }

        public System.Threading.Tasks.Task<AnnualSummaryDataObjectList> GetAllAnnualSummaryDTOAsync()
        {
            return base.Channel.GetAllAnnualSummaryDTOAsync();
        }

        public AnnualSummaryDataObject GetAnnualSummaryDTOByAnnualSummaryID(System.Guid annualSummaryId)
        {
            return base.Channel.GetAnnualSummaryDTOByAnnualSummaryID(annualSummaryId);
        }

        public System.Threading.Tasks.Task<AnnualSummaryDataObject> GetAnnualSummaryDTOByAnnualSummaryIDAsync(System.Guid annualSummaryId)
        {
            return base.Channel.GetAnnualSummaryDTOByAnnualSummaryIDAsync(annualSummaryId);
        }

        public AnnualSummaryResultData CommitAnnualSummaryDTO(AnnualSummaryResultData annualSummaryData)
        {
            return base.Channel.CommitAnnualSummaryDTO(annualSummaryData);
        }

        public System.Threading.Tasks.Task<AnnualSummaryResultData> CommitAnnualSummaryDTOAsync(AnnualSummaryResultData annualSummaryData)
        {
            return base.Channel.CommitAnnualSummaryDTOAsync(annualSummaryData);
        }

        public ApprovalDocDataObjectList GetAllApprovalDocDTO()
        {
            return base.Channel.GetAllApprovalDocDTO();
        }

        public System.Threading.Tasks.Task<ApprovalDocDataObjectList> GetAllApprovalDocDTOAsync()
        {
            return base.Channel.GetAllApprovalDocDTOAsync();
        }

        public ApprovalDocDataObjectList GetUnUsedApprovalDocDTOList()
        {
            return base.Channel.GetUnUsedApprovalDocDTOList();
        }

        public System.Threading.Tasks.Task<ApprovalDocDataObjectList> GetUnUsedApprovalDocDTOListAsync()
        {
            return base.Channel.GetUnUsedApprovalDocDTOListAsync();
        }

        public ApprovalDocDataObject GetApprovalDocDTOByApprovalDocID(System.Guid approvalDocId)
        {
            return base.Channel.GetApprovalDocDTOByApprovalDocID(approvalDocId);
        }

        public System.Threading.Tasks.Task<ApprovalDocDataObject> GetApprovalDocDTOByApprovalDocIDAsync(System.Guid approvalDocId)
        {
            return base.Channel.GetApprovalDocDTOByApprovalDocIDAsync(approvalDocId);
        }

        public RequestDataObjectList GetRequestDTOListByApprovalDocID(System.Guid approvalDocId)
        {
            return base.Channel.GetRequestDTOListByApprovalDocID(approvalDocId);
        }

        public System.Threading.Tasks.Task<RequestDataObjectList> GetRequestDTOListByApprovalDocIDAsync(System.Guid approvalDocId)
        {
            return base.Channel.GetRequestDTOListByApprovalDocIDAsync(approvalDocId);
        }

        public ApprovalDocResultData CommitApprovalDocDTO(ApprovalDocResultData approvalDocData)
        {
            return base.Channel.CommitApprovalDocDTO(approvalDocData);
        }

        public System.Threading.Tasks.Task<ApprovalDocResultData> CommitApprovalDocDTOAsync(ApprovalDocResultData approvalDocData)
        {
            return base.Channel.CommitApprovalDocDTOAsync(approvalDocData);
        }

        public ApprovalHistoryDataObjectList GetAllApprovalHistoryDTO()
        {
            return base.Channel.GetAllApprovalHistoryDTO();
        }

        public System.Threading.Tasks.Task<ApprovalHistoryDataObjectList> GetAllApprovalHistoryDTOAsync()
        {
            return base.Channel.GetAllApprovalHistoryDTOAsync();
        }

        public ApprovalHistoryDataObject GetApprovalHistoryDTOByApprovalHistoryID(System.Guid approvalHistoryId)
        {
            return base.Channel.GetApprovalHistoryDTOByApprovalHistoryID(approvalHistoryId);
        }

        public System.Threading.Tasks.Task<ApprovalHistoryDataObject> GetApprovalHistoryDTOByApprovalHistoryIDAsync(System.Guid approvalHistoryId)
        {
            return base.Channel.GetApprovalHistoryDTOByApprovalHistoryIDAsync(approvalHistoryId);
        }

        public ApprovalHistoryDataObjectList GetApprovalHistoryDTOListByPlanAircraftID(System.Guid planAircraftId)
        {
            return base.Channel.GetApprovalHistoryDTOListByPlanAircraftID(planAircraftId);
        }

        public System.Threading.Tasks.Task<ApprovalHistoryDataObjectList> GetApprovalHistoryDTOListByPlanAircraftIDAsync(System.Guid planAircraftId)
        {
            return base.Channel.GetApprovalHistoryDTOListByPlanAircraftIDAsync(planAircraftId);
        }

        public EngineBusinessHistoryDataObjectList GetAllEngineBusinessHistoryDTO()
        {
            return base.Channel.GetAllEngineBusinessHistoryDTO();
        }

        public System.Threading.Tasks.Task<EngineBusinessHistoryDataObjectList> GetAllEngineBusinessHistoryDTOAsync()
        {
            return base.Channel.GetAllEngineBusinessHistoryDTOAsync();
        }

        public EngineBusinessHistoryDataObject GetEngineBusinessHistoryDTOByEngineBusinessHistoryID(System.Guid engineBusinessHistoryId)
        {
            return base.Channel.GetEngineBusinessHistoryDTOByEngineBusinessHistoryID(engineBusinessHistoryId);
        }

        public System.Threading.Tasks.Task<EngineBusinessHistoryDataObject> GetEngineBusinessHistoryDTOByEngineBusinessHistoryIDAsync(System.Guid engineBusinessHistoryId)
        {
            return base.Channel.GetEngineBusinessHistoryDTOByEngineBusinessHistoryIDAsync(engineBusinessHistoryId);
        }

        public EngineBusinessHistoryDataObjectList GetEngineBusinessHistoryDTOListByEngineID(System.Guid engineId)
        {
            return base.Channel.GetEngineBusinessHistoryDTOListByEngineID(engineId);
        }

        public System.Threading.Tasks.Task<EngineBusinessHistoryDataObjectList> GetEngineBusinessHistoryDTOListByEngineIDAsync(System.Guid engineId)
        {
            return base.Channel.GetEngineBusinessHistoryDTOListByEngineIDAsync(engineId);
        }

        public EngineOwnerShipHistoryDataObjectList GetAllEngineOwnerShipHistoryDTO()
        {
            return base.Channel.GetAllEngineOwnerShipHistoryDTO();
        }

        public System.Threading.Tasks.Task<EngineOwnerShipHistoryDataObjectList> GetAllEngineOwnerShipHistoryDTOAsync()
        {
            return base.Channel.GetAllEngineOwnerShipHistoryDTOAsync();
        }

        public EngineOwnerShipHistoryDataObject GetEngineOwnershipHistoryDTOByEngineOwnerShipHistoryID(System.Guid engineOwnerShipHistoryId)
        {
            return base.Channel.GetEngineOwnershipHistoryDTOByEngineOwnerShipHistoryID(engineOwnerShipHistoryId);
        }

        public System.Threading.Tasks.Task<EngineOwnerShipHistoryDataObject> GetEngineOwnershipHistoryDTOByEngineOwnerShipHistoryIDAsync(System.Guid engineOwnerShipHistoryId)
        {
            return base.Channel.GetEngineOwnershipHistoryDTOByEngineOwnerShipHistoryIDAsync(engineOwnerShipHistoryId);
        }

        public EngineOwnerShipHistoryDataObjectList GetEngineOwnerShipHistoryDTOListByEngineID(System.Guid engineId)
        {
            return base.Channel.GetEngineOwnerShipHistoryDTOListByEngineID(engineId);
        }

        public System.Threading.Tasks.Task<EngineOwnerShipHistoryDataObjectList> GetEngineOwnerShipHistoryDTOListByEngineIDAsync(System.Guid engineId)
        {
            return base.Channel.GetEngineOwnerShipHistoryDTOListByEngineIDAsync(engineId);
        }

        public EnginePlanDataObjectList GetAllEnginePlanDTO()
        {
            return base.Channel.GetAllEnginePlanDTO();
        }

        public System.Threading.Tasks.Task<EnginePlanDataObjectList> GetAllEnginePlanDTOAsync()
        {
            return base.Channel.GetAllEnginePlanDTOAsync();
        }

        public EnginePlanDataObject GetEnginePlanDTOByEnginePlanID(System.Guid enginePlanId)
        {
            return base.Channel.GetEnginePlanDTOByEnginePlanID(enginePlanId);
        }

        public System.Threading.Tasks.Task<EnginePlanDataObject> GetEnginePlanDTOByEnginePlanIDAsync(System.Guid enginePlanId)
        {
            return base.Channel.GetEnginePlanDTOByEnginePlanIDAsync(enginePlanId);
        }

        public EnginePlanHistoryDataObjectList GetEnginePlanHistoryDTOListByEnginePlanID(System.Guid enginePlanId)
        {
            return base.Channel.GetEnginePlanHistoryDTOListByEnginePlanID(enginePlanId);
        }

        public System.Threading.Tasks.Task<EnginePlanHistoryDataObjectList> GetEnginePlanHistoryDTOListByEnginePlanIDAsync(System.Guid enginePlanId)
        {
            return base.Channel.GetEnginePlanHistoryDTOListByEnginePlanIDAsync(enginePlanId);
        }

        public int GetMaxVersionNumberByCurrentAnnualInEnginePlan()
        {
            return base.Channel.GetMaxVersionNumberByCurrentAnnualInEnginePlan();
        }

        public System.Threading.Tasks.Task<int> GetMaxVersionNumberByCurrentAnnualInEnginePlanAsync()
        {
            return base.Channel.GetMaxVersionNumberByCurrentAnnualInEnginePlanAsync();
        }

        public EnginePlanResultData CommitEnginePlanDTO(EnginePlanResultData enginePlanData)
        {
            return base.Channel.CommitEnginePlanDTO(enginePlanData);
        }

        public System.Threading.Tasks.Task<EnginePlanResultData> CommitEnginePlanDTOAsync(EnginePlanResultData enginePlanData)
        {
            return base.Channel.CommitEnginePlanDTOAsync(enginePlanData);
        }

        public EngineDataObjectList GetAllEngineDTO()
        {
            return base.Channel.GetAllEngineDTO();
        }

        public System.Threading.Tasks.Task<EngineDataObjectList> GetAllEngineDTOAsync()
        {
            return base.Channel.GetAllEngineDTOAsync();
        }

        public EngineDataObject GetEngineDTOByEngineID(System.Guid engineID)
        {
            return base.Channel.GetEngineDTOByEngineID(engineID);
        }

        public System.Threading.Tasks.Task<EngineDataObject> GetEngineDTOByEngineIDAsync(System.Guid engineID)
        {
            return base.Channel.GetEngineDTOByEngineIDAsync(engineID);
        }

        public EngineDataObjectList GetEngineDTOListByAirlinesID(System.Guid airlinesId)
        {
            return base.Channel.GetEngineDTOListByAirlinesID(airlinesId);
        }

        public System.Threading.Tasks.Task<EngineDataObjectList> GetEngineDTOListByAirlinesIDAsync(System.Guid airlinesId)
        {
            return base.Channel.GetEngineDTOListByAirlinesIDAsync(airlinesId);
        }

        public EngineDataObjectList GetEngineDTOListByEngineTypeID(System.Guid engineTypeId)
        {
            return base.Channel.GetEngineDTOListByEngineTypeID(engineTypeId);
        }

        public System.Threading.Tasks.Task<EngineDataObjectList> GetEngineDTOListByEngineTypeIDAsync(System.Guid engineTypeId)
        {
            return base.Channel.GetEngineDTOListByEngineTypeIDAsync(engineTypeId);
        }

        public PlanEngineDataObjectList GetPlanEngineDTOListByEngineID(System.Guid engineId)
        {
            return base.Channel.GetPlanEngineDTOListByEngineID(engineId);
        }

        public System.Threading.Tasks.Task<PlanEngineDataObjectList> GetPlanEngineDTOListByEngineIDAsync(System.Guid engineId)
        {
            return base.Channel.GetPlanEngineDTOListByEngineIDAsync(engineId);
        }

        public EngineResultData CommitEngineDTO(EngineResultData engineData)
        {
            return base.Channel.CommitEngineDTO(engineData);
        }

        public System.Threading.Tasks.Task<EngineResultData> CommitEngineDTOAsync(EngineResultData engineData)
        {
            return base.Channel.CommitEngineDTOAsync(engineData);
        }

        public EngineTypeDataObjectList GetAllEngineTypeDTO()
        {
            return base.Channel.GetAllEngineTypeDTO();
        }

        public System.Threading.Tasks.Task<EngineTypeDataObjectList> GetAllEngineTypeDTOAsync()
        {
            return base.Channel.GetAllEngineTypeDTOAsync();
        }

        public EngineTypeDataObject GetEngineTypeDTOByEngineTypeID(System.Guid engineTypeId)
        {
            return base.Channel.GetEngineTypeDTOByEngineTypeID(engineTypeId);
        }

        public System.Threading.Tasks.Task<EngineTypeDataObject> GetEngineTypeDTOByEngineTypeIDAsync(System.Guid engineTypeId)
        {
            return base.Channel.GetEngineTypeDTOByEngineTypeIDAsync(engineTypeId);
        }

        public EngineTypeResultData CommitEngineTypeDTO(EngineTypeResultData engineTypeData)
        {
            return base.Channel.CommitEngineTypeDTO(engineTypeData);
        }

        public System.Threading.Tasks.Task<EngineTypeResultData> CommitEngineTypeDTOAsync(EngineTypeResultData engineTypeData)
        {
            return base.Channel.CommitEngineTypeDTOAsync(engineTypeData);
        }

        public MailAddressDataObjectList GetAllMailAddressDTO()
        {
            return base.Channel.GetAllMailAddressDTO();
        }

        public System.Threading.Tasks.Task<MailAddressDataObjectList> GetAllMailAddressDTOAsync()
        {
            return base.Channel.GetAllMailAddressDTOAsync();
        }

        public MailAddressDataObject GetMailAddressDTOByMailAddressID(System.Guid mailAddressId)
        {
            return base.Channel.GetMailAddressDTOByMailAddressID(mailAddressId);
        }

        public System.Threading.Tasks.Task<MailAddressDataObject> GetMailAddressDTOByMailAddressIDAsync(System.Guid mailAddressId)
        {
            return base.Channel.GetMailAddressDTOByMailAddressIDAsync(mailAddressId);
        }

        public MailAddressDataObject GetMailAddressDTOByOwnerID(System.Guid ownerId)
        {
            return base.Channel.GetMailAddressDTOByOwnerID(ownerId);
        }

        public System.Threading.Tasks.Task<MailAddressDataObject> GetMailAddressDTOByOwnerIDAsync(System.Guid ownerId)
        {
            return base.Channel.GetMailAddressDTOByOwnerIDAsync(ownerId);
        }

        public MailAddressResultData CommitMailAddressDTO(MailAddressResultData mailAddressData)
        {
            return base.Channel.CommitMailAddressDTO(mailAddressData);
        }

        public System.Threading.Tasks.Task<MailAddressResultData> CommitMailAddressDTOAsync(MailAddressResultData mailAddressData)
        {
            return base.Channel.CommitMailAddressDTOAsync(mailAddressData);
        }

        public ManagerDataObjectList GetAllManagerDTO()
        {
            return base.Channel.GetAllManagerDTO();
        }

        public System.Threading.Tasks.Task<ManagerDataObjectList> GetAllManagerDTOAsync()
        {
            return base.Channel.GetAllManagerDTOAsync();
        }

        public ManagerDataObject GetManagerDTOByOwnerID(System.Guid ownerId)
        {
            return base.Channel.GetManagerDTOByOwnerID(ownerId);
        }

        public System.Threading.Tasks.Task<ManagerDataObject> GetManagerDTOByOwnerIDAsync(System.Guid ownerId)
        {
            return base.Channel.GetManagerDTOByOwnerIDAsync(ownerId);
        }

        public ManagerDataObject GetManagerDTOByManagerID(System.Guid managerId)
        {
            return base.Channel.GetManagerDTOByManagerID(managerId);
        }

        public System.Threading.Tasks.Task<ManagerDataObject> GetManagerDTOByManagerIDAsync(System.Guid managerId)
        {
            return base.Channel.GetManagerDTOByManagerIDAsync(managerId);
        }

        public ManufacturerDataObjectList GetAllManufacturerDTO()
        {
            return base.Channel.GetAllManufacturerDTO();
        }

        public System.Threading.Tasks.Task<ManufacturerDataObjectList> GetAllManufacturerDTOAsync()
        {
            return base.Channel.GetAllManufacturerDTOAsync();
        }
    }
}
