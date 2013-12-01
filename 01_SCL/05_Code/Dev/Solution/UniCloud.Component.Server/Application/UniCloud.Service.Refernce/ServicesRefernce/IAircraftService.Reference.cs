#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/10/21 17:58:12
* 文件名：IAircraftService
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
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://www.UniCloud.com", ConfigurationName = "AircraftService.IAircraftService")]
    public interface IAircraftService
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/CreateAcCategorys", ReplyAction = "http://www.UniCloud.com/IAircraftService/CreateAcCategorysResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/CreateAcCategorysDataFault", Name = "FaultData")]
        AcCategoryDataObjectList CreateAcCategorys(AcCategoryDataObjectList acCategorys);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/CreateAcCategorys", ReplyAction = "http://www.UniCloud.com/IAircraftService/CreateAcCategorysResponse")]
        System.Threading.Tasks.Task<AcCategoryDataObjectList> CreateAcCategorysAsync(AcCategoryDataObjectList acCategorys);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/DeleteAcCategorys", ReplyAction = "http://www.UniCloud.com/IAircraftService/DeleteAcCategorysResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/DeleteAcCategorysDataFault", Name = "FaultData")]
        IDList DeleteAcCategorys(IDList acCategoryIDs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/DeleteAcCategorys", ReplyAction = "http://www.UniCloud.com/IAircraftService/DeleteAcCategorysResponse")]
        System.Threading.Tasks.Task<IDList> DeleteAcCategorysAsync(IDList acCategoryIDs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/UpdateAcCategorys", ReplyAction = "http://www.UniCloud.com/IAircraftService/UpdateAcCategorysResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/UpdateAcCategorysDataFault", Name = "FaultData")]
        AcCategoryDataObjectList UpdateAcCategorys(AcCategoryDataObjectList acCategorys);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/UpdateAcCategorys", ReplyAction = "http://www.UniCloud.com/IAircraftService/UpdateAcCategorysResponse")]
        System.Threading.Tasks.Task<AcCategoryDataObjectList> UpdateAcCategorysAsync(AcCategoryDataObjectList acCategorys);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/CommitAcCategorys", ReplyAction = "http://www.UniCloud.com/IAircraftService/CommitAcCategorysResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/CommitAcCategorysDataFault", Name = "FaultData")]
        AcCategoryResultData CommitAcCategorys(AcCategoryResultData acCategoryData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/CommitAcCategorys", ReplyAction = "http://www.UniCloud.com/IAircraftService/CommitAcCategorysResponse")]
        System.Threading.Tasks.Task<AcCategoryResultData> CommitAcCategorysAsync(AcCategoryResultData acCategoryData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullAcCategoryByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAcCategoryByIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetFullAcCategoryByIDDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AcCategoryDataObject GetFullAcCategoryByID(int id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullAcCategoryByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAcCategoryByIDResponse")]
        System.Threading.Tasks.Task<AcCategoryDataObject> GetFullAcCategoryByIDAsync(int id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullAcCategorys", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAcCategorysResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetFullAcCategorysDataFault", Name = "FaultData")]
        AcCategoryDataObjectList GetFullAcCategorys();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullAcCategorys", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAcCategorysResponse")]
        System.Threading.Tasks.Task<AcCategoryDataObjectList> GetFullAcCategorysAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcCategorys", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcCategorysResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAcCategorysDataFault", Name = "FaultData")]
        AcCategoryDataObjectList GetAcCategorys(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcCategorys", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcCategorysResponse")]
        System.Threading.Tasks.Task<AcCategoryDataObjectList> GetAcCategorysAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcCategoryWithPagination", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcCategoryWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAcCategoryWithPaginationDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AcCategoryWithPagination GetAcCategoryWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcCategoryWithPagination", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcCategoryWithPaginationResponse")]
        System.Threading.Tasks.Task<AcCategoryWithPagination> GetAcCategoryWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcCategoryByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcCategoryByIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAcCategoryByIDDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AcCategoryDataObject GetAcCategoryByID(int id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcCategoryByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcCategoryByIDResponse")]
        System.Threading.Tasks.Task<AcCategoryDataObject> GetAcCategoryByIDAsync(int id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcCategoryCol", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcCategoryColResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAcCategoryColDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        KeyValueDataObjectList GetAcCategoryCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcCategoryCol", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcCategoryColResponse")]
        System.Threading.Tasks.Task<KeyValueDataObjectList> GetAcCategoryColAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/CreateAcRegs", ReplyAction = "http://www.UniCloud.com/IAircraftService/CreateAcRegsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/CreateAcRegsDataFault", Name = "FaultData")]
        AcRegDataObjectList CreateAcRegs(AcRegDataObjectList acRegs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/CreateAcRegs", ReplyAction = "http://www.UniCloud.com/IAircraftService/CreateAcRegsResponse")]
        System.Threading.Tasks.Task<AcRegDataObjectList> CreateAcRegsAsync(AcRegDataObjectList acRegs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/DeleteAcRegs", ReplyAction = "http://www.UniCloud.com/IAircraftService/DeleteAcRegsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/DeleteAcRegsDataFault", Name = "FaultData")]
        IDList DeleteAcRegs(AcRegDataObjectList acRegs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/DeleteAcRegs", ReplyAction = "http://www.UniCloud.com/IAircraftService/DeleteAcRegsResponse")]
        System.Threading.Tasks.Task<IDList> DeleteAcRegsAsync(AcRegDataObjectList acRegs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/UpdateAcRegs", ReplyAction = "http://www.UniCloud.com/IAircraftService/UpdateAcRegsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/UpdateAcRegsDataFault", Name = "FaultData")]
        AcRegDataObjectList UpdateAcRegs(AcRegDataObjectList acRegs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/UpdateAcRegs", ReplyAction = "http://www.UniCloud.com/IAircraftService/UpdateAcRegsResponse")]
        System.Threading.Tasks.Task<AcRegDataObjectList> UpdateAcRegsAsync(AcRegDataObjectList acRegs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/CommitAcRegs", ReplyAction = "http://www.UniCloud.com/IAircraftService/CommitAcRegsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/CommitAcRegsDataFault", Name = "FaultData")]
        AcRegResultData CommitAcRegs(AcRegResultData acRegData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/CommitAcRegs", ReplyAction = "http://www.UniCloud.com/IAircraftService/CommitAcRegsResponse")]
        System.Threading.Tasks.Task<AcRegResultData> CommitAcRegsAsync(AcRegResultData acRegData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullAcRegByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAcRegByIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetFullAcRegByIDDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AcRegDataObject GetFullAcRegByID(int id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullAcRegByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAcRegByIDResponse")]
        System.Threading.Tasks.Task<AcRegDataObject> GetFullAcRegByIDAsync(int id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullAcRegByGuid", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAcRegByGuidResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetFullAcRegByGuidDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AcRegDataObject GetFullAcRegByGuid(string id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullAcRegByGuid", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAcRegByGuidResponse")]
        System.Threading.Tasks.Task<AcRegDataObject> GetFullAcRegByGuidAsync(string id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullAcRegByReg", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAcRegByRegResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetFullAcRegByRegDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AcRegDataObject GetFullAcRegByReg(string reg);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullAcRegByReg", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAcRegByRegResponse")]
        System.Threading.Tasks.Task<AcRegDataObject> GetFullAcRegByRegAsync(string reg);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullAcRegs", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAcRegsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetFullAcRegsDataFault", Name = "FaultData")]
        AcRegDataObjectList GetFullAcRegs();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullAcRegs", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAcRegsResponse")]
        System.Threading.Tasks.Task<AcRegDataObjectList> GetFullAcRegsAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcRegs", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcRegsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAcRegsDataFault", Name = "FaultData")]
        AcRegDataObjectList GetAcRegs(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcRegs", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcRegsResponse")]
        System.Threading.Tasks.Task<AcRegDataObjectList> GetAcRegsAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcRegWithPagination", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcRegWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAcRegWithPaginationDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AcRegWithPagination GetAcRegWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcRegWithPagination", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcRegWithPaginationResponse")]
        System.Threading.Tasks.Task<AcRegWithPagination> GetAcRegWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcRegByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcRegByIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAcRegByIDDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AcRegDataObject GetAcRegByID(int id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcRegByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcRegByIDResponse")]
        System.Threading.Tasks.Task<AcRegDataObject> GetAcRegByIDAsync(int id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcRegByGuid", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcRegByGuidResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAcRegByGuidDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AcRegDataObject GetAcRegByGuid(string id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcRegByGuid", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcRegByGuidResponse")]
        System.Threading.Tasks.Task<AcRegDataObject> GetAcRegByGuidAsync(string id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcregLicenseByAcregID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcregLicenseByAcregIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAcregLicenseByAcregIDDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AcregLicenseDataObjectList GetAcregLicenseByAcregID(int id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcregLicenseByAcregID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcregLicenseByAcregIDResponse")]
        System.Threading.Tasks.Task<AcregLicenseDataObjectList> GetAcregLicenseByAcregIDAsync(int id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcRegCol", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcRegColResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAcRegColDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        KeyValueDataObjectList GetAcRegCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcRegCol", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcRegColResponse")]
        System.Threading.Tasks.Task<KeyValueDataObjectList> GetAcRegColAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/CreateAcTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/CreateAcTypesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/CreateAcTypesDataFault", Name = "FaultData")]
        AcTypeDataObjectList CreateAcTypes(AcTypeDataObjectList acTypes);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/CreateAcTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/CreateAcTypesResponse")]
        System.Threading.Tasks.Task<AcTypeDataObjectList> CreateAcTypesAsync(AcTypeDataObjectList acTypes);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/DeleteAcTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/DeleteAcTypesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/DeleteAcTypesDataFault", Name = "FaultData")]
        bool DeleteAcTypes(IDList acTypeIDs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/DeleteAcTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/DeleteAcTypesResponse")]
        System.Threading.Tasks.Task<bool> DeleteAcTypesAsync(IDList acTypeIDs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/UpdateAcTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/UpdateAcTypesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/UpdateAcTypesDataFault", Name = "FaultData")]
        AcTypeDataObjectList UpdateAcTypes(AcTypeDataObjectList acTypes);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/UpdateAcTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/UpdateAcTypesResponse")]
        System.Threading.Tasks.Task<AcTypeDataObjectList> UpdateAcTypesAsync(AcTypeDataObjectList acTypes);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/CommitAcTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/CommitAcTypesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/CommitAcTypesDataFault", Name = "FaultData")]
        AcTypeResultData CommitAcTypes(AcTypeResultData acTypeData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/CommitAcTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/CommitAcTypesResponse")]
        System.Threading.Tasks.Task<AcTypeResultData> CommitAcTypesAsync(AcTypeResultData acTypeData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullAcTypeByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAcTypeByIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetFullAcTypeByIDDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AcTypeDataObject GetFullAcTypeByID(int id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullAcTypeByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAcTypeByIDResponse")]
        System.Threading.Tasks.Task<AcTypeDataObject> GetFullAcTypeByIDAsync(int id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullAcTypeByGuid", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAcTypeByGuidResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetFullAcTypeByGuidDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AcTypeDataObject GetFullAcTypeByGuid(string id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullAcTypeByGuid", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAcTypeByGuidResponse")]
        System.Threading.Tasks.Task<AcTypeDataObject> GetFullAcTypeByGuidAsync(string id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullAcTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAcTypesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetFullAcTypesDataFault", Name = "FaultData")]
        AcTypeDataObjectList GetFullAcTypes();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullAcTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAcTypesResponse")]
        System.Threading.Tasks.Task<AcTypeDataObjectList> GetFullAcTypesAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/ManageAcTypeAta", ReplyAction = "http://www.UniCloud.com/IAircraftService/ManageAcTypeAtaResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/ManageAcTypeAtaDataFault", Name = "FaultData")]
        AcTypeDataObjectList ManageAcTypeAta(AcTypeDataObjectList actypes);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/ManageAcTypeAta", ReplyAction = "http://www.UniCloud.com/IAircraftService/ManageAcTypeAtaResponse")]
        System.Threading.Tasks.Task<AcTypeDataObjectList> ManageAcTypeAtaAsync(AcTypeDataObjectList actypes);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/CreateAcModels", ReplyAction = "http://www.UniCloud.com/IAircraftService/CreateAcModelsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/CreateAcModelsDataFault", Name = "FaultData")]
        AcModelDataObjectList CreateAcModels(int acTypeId, AcModelDataObjectList acModels);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/CreateAcModels", ReplyAction = "http://www.UniCloud.com/IAircraftService/CreateAcModelsResponse")]
        System.Threading.Tasks.Task<AcModelDataObjectList> CreateAcModelsAsync(int acTypeId, AcModelDataObjectList acModels);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/UpdateAcModels", ReplyAction = "http://www.UniCloud.com/IAircraftService/UpdateAcModelsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/UpdateAcModelsDataFault", Name = "FaultData")]
        AcModelDataObjectList UpdateAcModels(int acTypeId, AcModelDataObjectList acModels);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/UpdateAcModels", ReplyAction = "http://www.UniCloud.com/IAircraftService/UpdateAcModelsResponse")]
        System.Threading.Tasks.Task<AcModelDataObjectList> UpdateAcModelsAsync(int acTypeId, AcModelDataObjectList acModels);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/CreateAcConfigs", ReplyAction = "http://www.UniCloud.com/IAircraftService/CreateAcConfigsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/CreateAcConfigsDataFault", Name = "FaultData")]
        AcConfigDataObjectList CreateAcConfigs(int acTypeId, int acModelId, AcConfigDataObjectList acConfigs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/CreateAcConfigs", ReplyAction = "http://www.UniCloud.com/IAircraftService/CreateAcConfigsResponse")]
        System.Threading.Tasks.Task<AcConfigDataObjectList> CreateAcConfigsAsync(int acTypeId, int acModelId, AcConfigDataObjectList acConfigs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/UpdateAcConfigs", ReplyAction = "http://www.UniCloud.com/IAircraftService/UpdateAcConfigsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/UpdateAcConfigsDataFault", Name = "FaultData")]
        AcConfigDataObjectList UpdateAcConfigs(int acTypeId, int acModelId, AcConfigDataObjectList acConfigs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/UpdateAcConfigs", ReplyAction = "http://www.UniCloud.com/IAircraftService/UpdateAcConfigsResponse")]
        System.Threading.Tasks.Task<AcConfigDataObjectList> UpdateAcConfigsAsync(int acTypeId, int acModelId, AcConfigDataObjectList acConfigs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/DeleteAcModels", ReplyAction = "http://www.UniCloud.com/IAircraftService/DeleteAcModelsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/DeleteAcModelsDataFault", Name = "FaultData")]
        bool DeleteAcModels(int acTypeId, AcModelDataObjectList acModels);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/DeleteAcModels", ReplyAction = "http://www.UniCloud.com/IAircraftService/DeleteAcModelsResponse")]
        System.Threading.Tasks.Task<bool> DeleteAcModelsAsync(int acTypeId, AcModelDataObjectList acModels);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/DeleteAcConfigs", ReplyAction = "http://www.UniCloud.com/IAircraftService/DeleteAcConfigsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/DeleteAcConfigsDataFault", Name = "FaultData")]
        bool DeleteAcConfigs(int acTypeId, int acModelId, AcConfigDataObjectList acConfigs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/DeleteAcConfigs", ReplyAction = "http://www.UniCloud.com/IAircraftService/DeleteAcConfigsResponse")]
        System.Threading.Tasks.Task<bool> DeleteAcConfigsAsync(int acTypeId, int acModelId, AcConfigDataObjectList acConfigs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcTypesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAcTypesDataFault", Name = "FaultData")]
        AcTypeDataObjectList GetAcTypes(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcTypesResponse")]
        System.Threading.Tasks.Task<AcTypeDataObjectList> GetAcTypesAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcTypeWithPagination", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcTypeWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAcTypeWithPaginationDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AcTypeWithPagination GetAcTypeWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcTypeWithPagination", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcTypeWithPaginationResponse")]
        System.Threading.Tasks.Task<AcTypeWithPagination> GetAcTypeWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcTypeByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcTypeByIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAcTypeByIDDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AcTypeDataObject GetAcTypeByID(int id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcTypeByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcTypeByIDResponse")]
        System.Threading.Tasks.Task<AcTypeDataObject> GetAcTypeByIDAsync(int id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcTypeByGuid", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcTypeByGuidResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAcTypeByGuidDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AcTypeDataObject GetAcTypeByGuid(string id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcTypeByGuid", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcTypeByGuidResponse")]
        System.Threading.Tasks.Task<AcTypeDataObject> GetAcTypeByGuidAsync(string id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcModels", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcModelsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAcModelsDataFault", Name = "FaultData")]
        AcModelDataObjectList GetAcModels(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcModels", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcModelsResponse")]
        System.Threading.Tasks.Task<AcModelDataObjectList> GetAcModelsAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcModelByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcModelByIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAcModelByIDDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AcModelDataObject GetAcModelByID(int Id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcModelByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcModelByIDResponse")]
        System.Threading.Tasks.Task<AcModelDataObject> GetAcModelByIDAsync(int Id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcModelByGuid", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcModelByGuidResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAcModelByGuidDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AcModelDataObject GetAcModelByGuid(string Id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcModelByGuid", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcModelByGuidResponse")]
        System.Threading.Tasks.Task<AcModelDataObject> GetAcModelByGuidAsync(string Id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcConfigs", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcConfigsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAcConfigsDataFault", Name = "FaultData")]
        AcConfigDataObjectList GetAcConfigs(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcConfigs", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcConfigsResponse")]
        System.Threading.Tasks.Task<AcConfigDataObjectList> GetAcConfigsAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcConfigByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcConfigByIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAcConfigByIDDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AcConfigDataObject GetAcConfigByID(int Id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcConfigByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcConfigByIDResponse")]
        System.Threading.Tasks.Task<AcConfigDataObject> GetAcConfigByIDAsync(int Id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcConfigByGuid", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcConfigByGuidResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAcConfigByGuidDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        AcConfigDataObject GetAcConfigByGuid(string Id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcConfigByGuid", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcConfigByGuidResponse")]
        System.Threading.Tasks.Task<AcConfigDataObject> GetAcConfigByGuidAsync(string Id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcTypeCol", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcTypeColResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAcTypeColDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        KeyValueDataObjectList GetAcTypeCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcTypeCol", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcTypeColResponse")]
        System.Threading.Tasks.Task<KeyValueDataObjectList> GetAcTypeColAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcConfigCol", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcConfigColResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAcConfigColDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        KeyValueDataObjectList GetAcConfigCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcConfigCol", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcConfigColResponse")]
        System.Threading.Tasks.Task<KeyValueDataObjectList> GetAcConfigColAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcModelCol", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcModelColResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAcModelColDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        KeyValueDataObjectList GetAcModelCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAcModelCol", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAcModelColResponse")]
        System.Threading.Tasks.Task<KeyValueDataObjectList> GetAcModelColAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/CreateAtas", ReplyAction = "http://www.UniCloud.com/IAircraftService/CreateAtasResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/CreateAtasDataFault", Name = "FaultData")]
        AtaDataObjectList CreateAtas(AtaDataObjectList atas);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/CreateAtas", ReplyAction = "http://www.UniCloud.com/IAircraftService/CreateAtasResponse")]
        System.Threading.Tasks.Task<AtaDataObjectList> CreateAtasAsync(AtaDataObjectList atas);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/DeleteAtas", ReplyAction = "http://www.UniCloud.com/IAircraftService/DeleteAtasResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/DeleteAtasDataFault", Name = "FaultData")]
        IDList DeleteAtas(IDList ataIDs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/DeleteAtas", ReplyAction = "http://www.UniCloud.com/IAircraftService/DeleteAtasResponse")]
        System.Threading.Tasks.Task<IDList> DeleteAtasAsync(IDList ataIDs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/UpdateAtas", ReplyAction = "http://www.UniCloud.com/IAircraftService/UpdateAtasResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/UpdateAtasDataFault", Name = "FaultData")]
        AtaDataObjectList UpdateAtas(AtaDataObjectList atas);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/UpdateAtas", ReplyAction = "http://www.UniCloud.com/IAircraftService/UpdateAtasResponse")]
        System.Threading.Tasks.Task<AtaDataObjectList> UpdateAtasAsync(AtaDataObjectList atas);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/CommitAtas", ReplyAction = "http://www.UniCloud.com/IAircraftService/CommitAtasResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/CommitAtasDataFault", Name = "FaultData")]
        UniCloud.DataObjects.AtaResultData CommitAtas(UniCloud.DataObjects.AtaResultData ataData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/CommitAtas", ReplyAction = "http://www.UniCloud.com/IAircraftService/CommitAtasResponse")]
        System.Threading.Tasks.Task<UniCloud.DataObjects.AtaResultData> CommitAtasAsync(UniCloud.DataObjects.AtaResultData ataData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullAtaByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAtaByIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetFullAtaByIDDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        UniCloud.DataObjects.AtaDataObject GetFullAtaByID(int id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullAtaByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAtaByIDResponse")]
        System.Threading.Tasks.Task<UniCloud.DataObjects.AtaDataObject> GetFullAtaByIDAsync(int id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullAtas", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAtasResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetFullAtasDataFault", Name = "FaultData")]
        AtaDataObjectList GetFullAtas();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullAtas", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullAtasResponse")]
        System.Threading.Tasks.Task<AtaDataObjectList> GetFullAtasAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAtas", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAtasResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAtasDataFault", Name = "FaultData")]
        AtaDataObjectList GetAtas(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAtas", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAtasResponse")]
        System.Threading.Tasks.Task<AtaDataObjectList> GetAtasAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAtaWithPagination", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAtaWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAtaWithPaginationDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        UniCloud.DataObjects.AtaWithPagination GetAtaWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAtaWithPagination", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAtaWithPaginationResponse")]
        System.Threading.Tasks.Task<UniCloud.DataObjects.AtaWithPagination> GetAtaWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAtaByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAtaByIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAtaByIDDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        UniCloud.DataObjects.AtaDataObject GetAtaByID(int id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAtaByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAtaByIDResponse")]
        System.Threading.Tasks.Task<UniCloud.DataObjects.AtaDataObject> GetAtaByIDAsync(int id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAtaByGuid", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAtaByGuidResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAtaByGuidDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        UniCloud.DataObjects.AtaDataObject GetAtaByGuid(string id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAtaByGuid", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAtaByGuidResponse")]
        System.Threading.Tasks.Task<UniCloud.DataObjects.AtaDataObject> GetAtaByGuidAsync(string id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAtaCol", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAtaColResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetAtaColDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        KeyValueDataObjectList GetAtaCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetAtaCol", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAtaColResponse")]
        System.Threading.Tasks.Task<KeyValueDataObjectList> GetAtaColAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/CreateLicenseTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/CreateLicenseTypesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/CreateLicenseTypesDataFault", Name = "FaultData")]
        LicenseTypeDataObjectList CreateLicenseTypes(LicenseTypeDataObjectList licenseTypes);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/CreateLicenseTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/CreateLicenseTypesResponse")]
        System.Threading.Tasks.Task<LicenseTypeDataObjectList> CreateLicenseTypesAsync(LicenseTypeDataObjectList licenseTypes);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/DeleteLicenseTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/DeleteLicenseTypesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/DeleteLicenseTypesDataFault", Name = "FaultData")]
        IDList DeleteLicenseTypes(IDList licenseTypeIDs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/DeleteLicenseTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/DeleteLicenseTypesResponse")]
        System.Threading.Tasks.Task<IDList> DeleteLicenseTypesAsync(IDList licenseTypeIDs);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/UpdateLicenseTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/UpdateLicenseTypesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/UpdateLicenseTypesDataFault", Name = "FaultData")]
        LicenseTypeDataObjectList UpdateLicenseTypes(LicenseTypeDataObjectList licenseTypes);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/UpdateLicenseTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/UpdateLicenseTypesResponse")]
        System.Threading.Tasks.Task<LicenseTypeDataObjectList> UpdateLicenseTypesAsync(LicenseTypeDataObjectList licenseTypes);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/CommitLicenseTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/CommitLicenseTypesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/CommitLicenseTypesDataFault", Name = "FaultData")]
        LicenseTypeResultData CommitLicenseTypes(LicenseTypeResultData licenseTypeData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/CommitLicenseTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/CommitLicenseTypesResponse")]
        System.Threading.Tasks.Task<LicenseTypeResultData> CommitLicenseTypesAsync(LicenseTypeResultData licenseTypeData);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullLicenseTypeByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullLicenseTypeByIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetFullLicenseTypeByIDDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        LicenseTypeDataObject GetFullLicenseTypeByID(int id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullLicenseTypeByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullLicenseTypeByIDResponse")]
        System.Threading.Tasks.Task<LicenseTypeDataObject> GetFullLicenseTypeByIDAsync(int id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullLicenseTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullLicenseTypesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetFullLicenseTypesDataFault", Name = "FaultData")]
        LicenseTypeDataObjectList GetFullLicenseTypes();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetFullLicenseTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetFullLicenseTypesResponse")]
        System.Threading.Tasks.Task<LicenseTypeDataObjectList> GetFullLicenseTypesAsync();

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetLicenseTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetLicenseTypesResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetLicenseTypesDataFault", Name = "FaultData")]
        LicenseTypeDataObjectList GetLicenseTypes(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetLicenseTypes", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetLicenseTypesResponse")]
        System.Threading.Tasks.Task<LicenseTypeDataObjectList> GetLicenseTypesAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetLicenseTypeWithPagination", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetLicenseTypeWithPaginationResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetLicenseTypeWithPaginationDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        LicenseTypeWithPagination GetLicenseTypeWithPagination(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetLicenseTypeWithPagination", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetLicenseTypeWithPaginationResponse")]
        System.Threading.Tasks.Task<LicenseTypeWithPagination> GetLicenseTypeWithPaginationAsync(UniCloud.DataObjects.Pagination pagination);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetLicenseTypeByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetLicenseTypeByIDResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetLicenseTypeByIDDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        LicenseTypeDataObject GetLicenseTypeByID(int id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetLicenseTypeByID", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetLicenseTypeByIDResponse")]
        System.Threading.Tasks.Task<LicenseTypeDataObject> GetLicenseTypeByIDAsync(int id);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetLicenseTypeCol", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetLicenseTypeColResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(UniCloud.DataObjects.FaultData), Action = "http://www.UniCloud.com/IAircraftService/GetLicenseTypeColDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
        KeyValueDataObjectList GetLicenseTypeCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);

        [System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IAircraftService/GetLicenseTypeCol", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetLicenseTypeColResponse")]
        System.Threading.Tasks.Task<KeyValueDataObjectList> GetLicenseTypeColAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAircraftServiceChannel : IAircraftService, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AircraftServiceClient : System.ServiceModel.ClientBase<IAircraftService>, IAircraftService
    {

        public AircraftServiceClient()
        {
        }

        public AircraftServiceClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public AircraftServiceClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public AircraftServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public AircraftServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        public AcCategoryDataObjectList CreateAcCategorys(AcCategoryDataObjectList acCategorys)
        {
            return base.Channel.CreateAcCategorys(acCategorys);
        }

        public System.Threading.Tasks.Task<AcCategoryDataObjectList> CreateAcCategorysAsync(AcCategoryDataObjectList acCategorys)
        {
            return base.Channel.CreateAcCategorysAsync(acCategorys);
        }

        public IDList DeleteAcCategorys(IDList acCategoryIDs)
        {
            return base.Channel.DeleteAcCategorys(acCategoryIDs);
        }

        public System.Threading.Tasks.Task<IDList> DeleteAcCategorysAsync(IDList acCategoryIDs)
        {
            return base.Channel.DeleteAcCategorysAsync(acCategoryIDs);
        }

        public AcCategoryDataObjectList UpdateAcCategorys(AcCategoryDataObjectList acCategorys)
        {
            return base.Channel.UpdateAcCategorys(acCategorys);
        }

        public System.Threading.Tasks.Task<AcCategoryDataObjectList> UpdateAcCategorysAsync(AcCategoryDataObjectList acCategorys)
        {
            return base.Channel.UpdateAcCategorysAsync(acCategorys);
        }

        public AcCategoryResultData CommitAcCategorys(AcCategoryResultData acCategoryData)
        {
            return base.Channel.CommitAcCategorys(acCategoryData);
        }

        public System.Threading.Tasks.Task<AcCategoryResultData> CommitAcCategorysAsync(AcCategoryResultData acCategoryData)
        {
            return base.Channel.CommitAcCategorysAsync(acCategoryData);
        }

        public AcCategoryDataObject GetFullAcCategoryByID(int id)
        {
            return base.Channel.GetFullAcCategoryByID(id);
        }

        public System.Threading.Tasks.Task<AcCategoryDataObject> GetFullAcCategoryByIDAsync(int id)
        {
            return base.Channel.GetFullAcCategoryByIDAsync(id);
        }

        public AcCategoryDataObjectList GetFullAcCategorys()
        {
            return base.Channel.GetFullAcCategorys();
        }

        public System.Threading.Tasks.Task<AcCategoryDataObjectList> GetFullAcCategorysAsync()
        {
            return base.Channel.GetFullAcCategorysAsync();
        }

        public AcCategoryDataObjectList GetAcCategorys(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetAcCategorys(colFilter, sortFilter);
        }

        public System.Threading.Tasks.Task<AcCategoryDataObjectList> GetAcCategorysAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetAcCategorysAsync(colFilter, sortFilter);
        }

        public AcCategoryWithPagination GetAcCategoryWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetAcCategoryWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<AcCategoryWithPagination> GetAcCategoryWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetAcCategoryWithPaginationAsync(pagination);
        }

        public AcCategoryDataObject GetAcCategoryByID(int id)
        {
            return base.Channel.GetAcCategoryByID(id);
        }

        public System.Threading.Tasks.Task<AcCategoryDataObject> GetAcCategoryByIDAsync(int id)
        {
            return base.Channel.GetAcCategoryByIDAsync(id);
        }

        public KeyValueDataObjectList GetAcCategoryCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetAcCategoryCol(colFilter, sortFilter);
        }

        public System.Threading.Tasks.Task<KeyValueDataObjectList> GetAcCategoryColAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetAcCategoryColAsync(colFilter, sortFilter);
        }

        public AcRegDataObjectList CreateAcRegs(AcRegDataObjectList acRegs)
        {
            return base.Channel.CreateAcRegs(acRegs);
        }

        public System.Threading.Tasks.Task<AcRegDataObjectList> CreateAcRegsAsync(AcRegDataObjectList acRegs)
        {
            return base.Channel.CreateAcRegsAsync(acRegs);
        }

        public IDList DeleteAcRegs(AcRegDataObjectList acRegs)
        {
            return base.Channel.DeleteAcRegs(acRegs);
        }

        public System.Threading.Tasks.Task<IDList> DeleteAcRegsAsync(AcRegDataObjectList acRegs)
        {
            return base.Channel.DeleteAcRegsAsync(acRegs);
        }

        public AcRegDataObjectList UpdateAcRegs(AcRegDataObjectList acRegs)
        {
            return base.Channel.UpdateAcRegs(acRegs);
        }

        public System.Threading.Tasks.Task<AcRegDataObjectList> UpdateAcRegsAsync(AcRegDataObjectList acRegs)
        {
            return base.Channel.UpdateAcRegsAsync(acRegs);
        }

        public AcRegResultData CommitAcRegs(AcRegResultData acRegData)
        {
            return base.Channel.CommitAcRegs(acRegData);
        }

        public System.Threading.Tasks.Task<AcRegResultData> CommitAcRegsAsync(AcRegResultData acRegData)
        {
            return base.Channel.CommitAcRegsAsync(acRegData);
        }

        public AcRegDataObject GetFullAcRegByID(int id)
        {
            return base.Channel.GetFullAcRegByID(id);
        }

        public System.Threading.Tasks.Task<AcRegDataObject> GetFullAcRegByIDAsync(int id)
        {
            return base.Channel.GetFullAcRegByIDAsync(id);
        }

        public AcRegDataObject GetFullAcRegByGuid(string id)
        {
            return base.Channel.GetFullAcRegByGuid(id);
        }

        public System.Threading.Tasks.Task<AcRegDataObject> GetFullAcRegByGuidAsync(string id)
        {
            return base.Channel.GetFullAcRegByGuidAsync(id);
        }

        public AcRegDataObject GetFullAcRegByReg(string reg)
        {
            return base.Channel.GetFullAcRegByReg(reg);
        }

        public System.Threading.Tasks.Task<AcRegDataObject> GetFullAcRegByRegAsync(string reg)
        {
            return base.Channel.GetFullAcRegByRegAsync(reg);
        }

        public AcRegDataObjectList GetFullAcRegs()
        {
            return base.Channel.GetFullAcRegs();
        }

        public System.Threading.Tasks.Task<AcRegDataObjectList> GetFullAcRegsAsync()
        {
            return base.Channel.GetFullAcRegsAsync();
        }

        public AcRegDataObjectList GetAcRegs(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetAcRegs(colFilter, sortFilter);
        }

        public System.Threading.Tasks.Task<AcRegDataObjectList> GetAcRegsAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetAcRegsAsync(colFilter, sortFilter);
        }

        public AcRegWithPagination GetAcRegWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetAcRegWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<AcRegWithPagination> GetAcRegWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetAcRegWithPaginationAsync(pagination);
        }

        public AcRegDataObject GetAcRegByID(int id)
        {
            return base.Channel.GetAcRegByID(id);
        }

        public System.Threading.Tasks.Task<AcRegDataObject> GetAcRegByIDAsync(int id)
        {
            return base.Channel.GetAcRegByIDAsync(id);
        }

        public AcRegDataObject GetAcRegByGuid(string id)
        {
            return base.Channel.GetAcRegByGuid(id);
        }

        public System.Threading.Tasks.Task<AcRegDataObject> GetAcRegByGuidAsync(string id)
        {
            return base.Channel.GetAcRegByGuidAsync(id);
        }

        public AcregLicenseDataObjectList GetAcregLicenseByAcregID(int id)
        {
            return base.Channel.GetAcregLicenseByAcregID(id);
        }

        public System.Threading.Tasks.Task<AcregLicenseDataObjectList> GetAcregLicenseByAcregIDAsync(int id)
        {
            return base.Channel.GetAcregLicenseByAcregIDAsync(id);
        }

        public KeyValueDataObjectList GetAcRegCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetAcRegCol(colFilter, sortFilter);
        }

        public System.Threading.Tasks.Task<KeyValueDataObjectList> GetAcRegColAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetAcRegColAsync(colFilter, sortFilter);
        }

        public AcTypeDataObjectList CreateAcTypes(AcTypeDataObjectList acTypes)
        {
            return base.Channel.CreateAcTypes(acTypes);
        }

        public System.Threading.Tasks.Task<AcTypeDataObjectList> CreateAcTypesAsync(AcTypeDataObjectList acTypes)
        {
            return base.Channel.CreateAcTypesAsync(acTypes);
        }

        public bool DeleteAcTypes(IDList acTypeIDs)
        {
            return base.Channel.DeleteAcTypes(acTypeIDs);
        }

        public System.Threading.Tasks.Task<bool> DeleteAcTypesAsync(IDList acTypeIDs)
        {
            return base.Channel.DeleteAcTypesAsync(acTypeIDs);
        }

        public AcTypeDataObjectList UpdateAcTypes(AcTypeDataObjectList acTypes)
        {
            return base.Channel.UpdateAcTypes(acTypes);
        }

        public System.Threading.Tasks.Task<AcTypeDataObjectList> UpdateAcTypesAsync(AcTypeDataObjectList acTypes)
        {
            return base.Channel.UpdateAcTypesAsync(acTypes);
        }

        public AcTypeResultData CommitAcTypes(AcTypeResultData acTypeData)
        {
            return base.Channel.CommitAcTypes(acTypeData);
        }

        public System.Threading.Tasks.Task<AcTypeResultData> CommitAcTypesAsync(AcTypeResultData acTypeData)
        {
            return base.Channel.CommitAcTypesAsync(acTypeData);
        }

        public AcTypeDataObject GetFullAcTypeByID(int id)
        {
            return base.Channel.GetFullAcTypeByID(id);
        }

        public System.Threading.Tasks.Task<AcTypeDataObject> GetFullAcTypeByIDAsync(int id)
        {
            return base.Channel.GetFullAcTypeByIDAsync(id);
        }

        public AcTypeDataObject GetFullAcTypeByGuid(string id)
        {
            return base.Channel.GetFullAcTypeByGuid(id);
        }

        public System.Threading.Tasks.Task<AcTypeDataObject> GetFullAcTypeByGuidAsync(string id)
        {
            return base.Channel.GetFullAcTypeByGuidAsync(id);
        }

        public AcTypeDataObjectList GetFullAcTypes()
        {
            return base.Channel.GetFullAcTypes();
        }

        public System.Threading.Tasks.Task<AcTypeDataObjectList> GetFullAcTypesAsync()
        {
            return base.Channel.GetFullAcTypesAsync();
        }

        public AcTypeDataObjectList ManageAcTypeAta(AcTypeDataObjectList actypes)
        {
            return base.Channel.ManageAcTypeAta(actypes);
        }

        public System.Threading.Tasks.Task<AcTypeDataObjectList> ManageAcTypeAtaAsync(AcTypeDataObjectList actypes)
        {
            return base.Channel.ManageAcTypeAtaAsync(actypes);
        }

        public AcModelDataObjectList CreateAcModels(int acTypeId, AcModelDataObjectList acModels)
        {
            return base.Channel.CreateAcModels(acTypeId, acModels);
        }

        public System.Threading.Tasks.Task<AcModelDataObjectList> CreateAcModelsAsync(int acTypeId, AcModelDataObjectList acModels)
        {
            return base.Channel.CreateAcModelsAsync(acTypeId, acModels);
        }

        public AcModelDataObjectList UpdateAcModels(int acTypeId, AcModelDataObjectList acModels)
        {
            return base.Channel.UpdateAcModels(acTypeId, acModels);
        }

        public System.Threading.Tasks.Task<AcModelDataObjectList> UpdateAcModelsAsync(int acTypeId, AcModelDataObjectList acModels)
        {
            return base.Channel.UpdateAcModelsAsync(acTypeId, acModels);
        }

        public AcConfigDataObjectList CreateAcConfigs(int acTypeId, int acModelId, AcConfigDataObjectList acConfigs)
        {
            return base.Channel.CreateAcConfigs(acTypeId, acModelId, acConfigs);
        }

        public System.Threading.Tasks.Task<AcConfigDataObjectList> CreateAcConfigsAsync(int acTypeId, int acModelId, AcConfigDataObjectList acConfigs)
        {
            return base.Channel.CreateAcConfigsAsync(acTypeId, acModelId, acConfigs);
        }

        public AcConfigDataObjectList UpdateAcConfigs(int acTypeId, int acModelId, AcConfigDataObjectList acConfigs)
        {
            return base.Channel.UpdateAcConfigs(acTypeId, acModelId, acConfigs);
        }

        public System.Threading.Tasks.Task<AcConfigDataObjectList> UpdateAcConfigsAsync(int acTypeId, int acModelId, AcConfigDataObjectList acConfigs)
        {
            return base.Channel.UpdateAcConfigsAsync(acTypeId, acModelId, acConfigs);
        }

        public bool DeleteAcModels(int acTypeId, AcModelDataObjectList acModels)
        {
            return base.Channel.DeleteAcModels(acTypeId, acModels);
        }

        public System.Threading.Tasks.Task<bool> DeleteAcModelsAsync(int acTypeId, AcModelDataObjectList acModels)
        {
            return base.Channel.DeleteAcModelsAsync(acTypeId, acModels);
        }

        public bool DeleteAcConfigs(int acTypeId, int acModelId, AcConfigDataObjectList acConfigs)
        {
            return base.Channel.DeleteAcConfigs(acTypeId, acModelId, acConfigs);
        }

        public System.Threading.Tasks.Task<bool> DeleteAcConfigsAsync(int acTypeId, int acModelId, AcConfigDataObjectList acConfigs)
        {
            return base.Channel.DeleteAcConfigsAsync(acTypeId, acModelId, acConfigs);
        }

        public AcTypeDataObjectList GetAcTypes(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetAcTypes(colFilter, sortFilter);
        }

        public System.Threading.Tasks.Task<AcTypeDataObjectList> GetAcTypesAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetAcTypesAsync(colFilter, sortFilter);
        }

        public AcTypeWithPagination GetAcTypeWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetAcTypeWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<AcTypeWithPagination> GetAcTypeWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetAcTypeWithPaginationAsync(pagination);
        }

        public AcTypeDataObject GetAcTypeByID(int id)
        {
            return base.Channel.GetAcTypeByID(id);
        }

        public System.Threading.Tasks.Task<AcTypeDataObject> GetAcTypeByIDAsync(int id)
        {
            return base.Channel.GetAcTypeByIDAsync(id);
        }

        public AcTypeDataObject GetAcTypeByGuid(string id)
        {
            return base.Channel.GetAcTypeByGuid(id);
        }

        public System.Threading.Tasks.Task<AcTypeDataObject> GetAcTypeByGuidAsync(string id)
        {
            return base.Channel.GetAcTypeByGuidAsync(id);
        }

        public AcModelDataObjectList GetAcModels(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetAcModels(colFilter, sortFilter);
        }

        public System.Threading.Tasks.Task<AcModelDataObjectList> GetAcModelsAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetAcModelsAsync(colFilter, sortFilter);
        }

        public AcModelDataObject GetAcModelByID(int Id)
        {
            return base.Channel.GetAcModelByID(Id);
        }

        public System.Threading.Tasks.Task<AcModelDataObject> GetAcModelByIDAsync(int Id)
        {
            return base.Channel.GetAcModelByIDAsync(Id);
        }

        public AcModelDataObject GetAcModelByGuid(string Id)
        {
            return base.Channel.GetAcModelByGuid(Id);
        }

        public System.Threading.Tasks.Task<AcModelDataObject> GetAcModelByGuidAsync(string Id)
        {
            return base.Channel.GetAcModelByGuidAsync(Id);
        }

        public AcConfigDataObjectList GetAcConfigs(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetAcConfigs(colFilter, sortFilter);
        }

        public System.Threading.Tasks.Task<AcConfigDataObjectList> GetAcConfigsAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetAcConfigsAsync(colFilter, sortFilter);
        }

        public AcConfigDataObject GetAcConfigByID(int Id)
        {
            return base.Channel.GetAcConfigByID(Id);
        }

        public System.Threading.Tasks.Task<AcConfigDataObject> GetAcConfigByIDAsync(int Id)
        {
            return base.Channel.GetAcConfigByIDAsync(Id);
        }

        public AcConfigDataObject GetAcConfigByGuid(string Id)
        {
            return base.Channel.GetAcConfigByGuid(Id);
        }

        public System.Threading.Tasks.Task<AcConfigDataObject> GetAcConfigByGuidAsync(string Id)
        {
            return base.Channel.GetAcConfigByGuidAsync(Id);
        }

        public KeyValueDataObjectList GetAcTypeCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetAcTypeCol(colFilter, sortFilter);
        }

        public System.Threading.Tasks.Task<KeyValueDataObjectList> GetAcTypeColAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetAcTypeColAsync(colFilter, sortFilter);
        }

        public KeyValueDataObjectList GetAcConfigCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetAcConfigCol(colFilter, sortFilter);
        }

        public System.Threading.Tasks.Task<KeyValueDataObjectList> GetAcConfigColAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetAcConfigColAsync(colFilter, sortFilter);
        }

        public KeyValueDataObjectList GetAcModelCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetAcModelCol(colFilter, sortFilter);
        }

        public System.Threading.Tasks.Task<KeyValueDataObjectList> GetAcModelColAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetAcModelColAsync(colFilter, sortFilter);
        }

        public AtaDataObjectList CreateAtas(AtaDataObjectList atas)
        {
            return base.Channel.CreateAtas(atas);
        }

        public System.Threading.Tasks.Task<AtaDataObjectList> CreateAtasAsync(AtaDataObjectList atas)
        {
            return base.Channel.CreateAtasAsync(atas);
        }

        public IDList DeleteAtas(IDList ataIDs)
        {
            return base.Channel.DeleteAtas(ataIDs);
        }

        public System.Threading.Tasks.Task<IDList> DeleteAtasAsync(IDList ataIDs)
        {
            return base.Channel.DeleteAtasAsync(ataIDs);
        }

        public AtaDataObjectList UpdateAtas(AtaDataObjectList atas)
        {
            return base.Channel.UpdateAtas(atas);
        }

        public System.Threading.Tasks.Task<AtaDataObjectList> UpdateAtasAsync(AtaDataObjectList atas)
        {
            return base.Channel.UpdateAtasAsync(atas);
        }

        public UniCloud.DataObjects.AtaResultData CommitAtas(UniCloud.DataObjects.AtaResultData ataData)
        {
            return base.Channel.CommitAtas(ataData);
        }

        public System.Threading.Tasks.Task<UniCloud.DataObjects.AtaResultData> CommitAtasAsync(UniCloud.DataObjects.AtaResultData ataData)
        {
            return base.Channel.CommitAtasAsync(ataData);
        }

        public UniCloud.DataObjects.AtaDataObject GetFullAtaByID(int id)
        {
            return base.Channel.GetFullAtaByID(id);
        }

        public System.Threading.Tasks.Task<UniCloud.DataObjects.AtaDataObject> GetFullAtaByIDAsync(int id)
        {
            return base.Channel.GetFullAtaByIDAsync(id);
        }

        public AtaDataObjectList GetFullAtas()
        {
            return base.Channel.GetFullAtas();
        }

        public System.Threading.Tasks.Task<AtaDataObjectList> GetFullAtasAsync()
        {
            return base.Channel.GetFullAtasAsync();
        }

        public AtaDataObjectList GetAtas(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetAtas(colFilter, sortFilter);
        }

        public System.Threading.Tasks.Task<AtaDataObjectList> GetAtasAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetAtasAsync(colFilter, sortFilter);
        }

        public UniCloud.DataObjects.AtaWithPagination GetAtaWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetAtaWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<UniCloud.DataObjects.AtaWithPagination> GetAtaWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetAtaWithPaginationAsync(pagination);
        }

        public UniCloud.DataObjects.AtaDataObject GetAtaByID(int id)
        {
            return base.Channel.GetAtaByID(id);
        }

        public System.Threading.Tasks.Task<UniCloud.DataObjects.AtaDataObject> GetAtaByIDAsync(int id)
        {
            return base.Channel.GetAtaByIDAsync(id);
        }

        public UniCloud.DataObjects.AtaDataObject GetAtaByGuid(string id)
        {
            return base.Channel.GetAtaByGuid(id);
        }

        public System.Threading.Tasks.Task<UniCloud.DataObjects.AtaDataObject> GetAtaByGuidAsync(string id)
        {
            return base.Channel.GetAtaByGuidAsync(id);
        }

        public KeyValueDataObjectList GetAtaCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetAtaCol(colFilter, sortFilter);
        }

        public System.Threading.Tasks.Task<KeyValueDataObjectList> GetAtaColAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetAtaColAsync(colFilter, sortFilter);
        }

        public LicenseTypeDataObjectList CreateLicenseTypes(LicenseTypeDataObjectList licenseTypes)
        {
            return base.Channel.CreateLicenseTypes(licenseTypes);
        }

        public System.Threading.Tasks.Task<LicenseTypeDataObjectList> CreateLicenseTypesAsync(LicenseTypeDataObjectList licenseTypes)
        {
            return base.Channel.CreateLicenseTypesAsync(licenseTypes);
        }

        public IDList DeleteLicenseTypes(IDList licenseTypeIDs)
        {
            return base.Channel.DeleteLicenseTypes(licenseTypeIDs);
        }

        public System.Threading.Tasks.Task<IDList> DeleteLicenseTypesAsync(IDList licenseTypeIDs)
        {
            return base.Channel.DeleteLicenseTypesAsync(licenseTypeIDs);
        }

        public LicenseTypeDataObjectList UpdateLicenseTypes(LicenseTypeDataObjectList licenseTypes)
        {
            return base.Channel.UpdateLicenseTypes(licenseTypes);
        }

        public System.Threading.Tasks.Task<LicenseTypeDataObjectList> UpdateLicenseTypesAsync(LicenseTypeDataObjectList licenseTypes)
        {
            return base.Channel.UpdateLicenseTypesAsync(licenseTypes);
        }

        public LicenseTypeResultData CommitLicenseTypes(LicenseTypeResultData licenseTypeData)
        {
            return base.Channel.CommitLicenseTypes(licenseTypeData);
        }

        public System.Threading.Tasks.Task<LicenseTypeResultData> CommitLicenseTypesAsync(LicenseTypeResultData licenseTypeData)
        {
            return base.Channel.CommitLicenseTypesAsync(licenseTypeData);
        }

        public LicenseTypeDataObject GetFullLicenseTypeByID(int id)
        {
            return base.Channel.GetFullLicenseTypeByID(id);
        }

        public System.Threading.Tasks.Task<LicenseTypeDataObject> GetFullLicenseTypeByIDAsync(int id)
        {
            return base.Channel.GetFullLicenseTypeByIDAsync(id);
        }

        public LicenseTypeDataObjectList GetFullLicenseTypes()
        {
            return base.Channel.GetFullLicenseTypes();
        }

        public System.Threading.Tasks.Task<LicenseTypeDataObjectList> GetFullLicenseTypesAsync()
        {
            return base.Channel.GetFullLicenseTypesAsync();
        }

        public LicenseTypeDataObjectList GetLicenseTypes(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetLicenseTypes(colFilter, sortFilter);
        }

        public System.Threading.Tasks.Task<LicenseTypeDataObjectList> GetLicenseTypesAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetLicenseTypesAsync(colFilter, sortFilter);
        }

        public LicenseTypeWithPagination GetLicenseTypeWithPagination(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetLicenseTypeWithPagination(pagination);
        }

        public System.Threading.Tasks.Task<LicenseTypeWithPagination> GetLicenseTypeWithPaginationAsync(UniCloud.DataObjects.Pagination pagination)
        {
            return base.Channel.GetLicenseTypeWithPaginationAsync(pagination);
        }

        public LicenseTypeDataObject GetLicenseTypeByID(int id)
        {
            return base.Channel.GetLicenseTypeByID(id);
        }

        public System.Threading.Tasks.Task<LicenseTypeDataObject> GetLicenseTypeByIDAsync(int id)
        {
            return base.Channel.GetLicenseTypeByIDAsync(id);
        }

        public KeyValueDataObjectList GetLicenseTypeCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetLicenseTypeCol(colFilter, sortFilter);
        }

        public System.Threading.Tasks.Task<KeyValueDataObjectList> GetLicenseTypeColAsync(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return base.Channel.GetLicenseTypeColAsync(colFilter, sortFilter);
        }
    }
}
