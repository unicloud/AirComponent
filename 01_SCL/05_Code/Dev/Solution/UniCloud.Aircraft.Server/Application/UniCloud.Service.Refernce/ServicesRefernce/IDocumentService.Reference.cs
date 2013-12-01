using UniCloud.DataObjects;

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace = "http://www.UniCloud.com", ConfigurationName = "Doc.IDocumentService")]
public interface IDocumentService {

	[System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IDocumentService/GetDocumentTypeDataObjectList", ReplyAction = "http://www.UniCloud.com/IDocumentService/GetDocumentTypeDataObjectListResponse")]
	[System.ServiceModel.FaultContractAttribute(typeof(FaultData), Action = "http://www.UniCloud.com/IDocumentService/GetDocumentTypeDataObjectListFaultDataFa" +
		"ult", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
	DocumentTypeDataObjectList GetDocumentTypeDataObjectList();

	[System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IDocumentService/GetDocumentTypeDataObjectList", ReplyAction = "http://www.UniCloud.com/IDocumentService/GetDocumentTypeDataObjectListResponse")]
	System.Threading.Tasks.Task<DocumentTypeDataObjectList> GetDocumentTypeDataObjectListAsync();

	[System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IDocumentService/ExistDocumentType", ReplyAction = "http://www.UniCloud.com/IDocumentService/ExistDocumentTypeResponse")]
	[System.ServiceModel.FaultContractAttribute(typeof(FaultData), Action = "http://www.UniCloud.com/IDocumentService/ExistDocumentTypeFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
	bool ExistDocumentType(string name);

	[System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IDocumentService/ExistDocumentType", ReplyAction = "http://www.UniCloud.com/IDocumentService/ExistDocumentTypeResponse")]
	System.Threading.Tasks.Task<bool> ExistDocumentTypeAsync(string name);

	[System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IDocumentService/GetPaginationOfficialDocumentDataObject", ReplyAction = "http://www.UniCloud.com/IDocumentService/GetPaginationOfficialDocumentDataObjectR" +
		"esponse")]
	[System.ServiceModel.FaultContractAttribute(typeof(FaultData), Action = "http://www.UniCloud.com/IDocumentService/GetPaginationOfficialDocumentDataObjectF" +
		"aultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    OfficialDocumentDataObjectWithPagination GetPaginationOfficialDocumentDataObject(Pagination pagination);

	[System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IDocumentService/GetPaginationOfficialDocumentDataObject", ReplyAction = "http://www.UniCloud.com/IDocumentService/GetPaginationOfficialDocumentDataObjectR" +
		"esponse")]
    System.Threading.Tasks.Task<OfficialDocumentDataObjectWithPagination> GetPaginationOfficialDocumentDataObjectAsync(Pagination pagination);

	[System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IDocumentService/GetAllOfficialDocument", ReplyAction = "http://www.UniCloud.com/IDocumentService/GetAllOfficialDocumentResponse")]
	[System.ServiceModel.FaultContractAttribute(typeof(FaultData), Action = "http://www.UniCloud.com/IDocumentService/GetAllOfficialDocumentFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
	OfficialDocumentDataObjectList GetAllOfficialDocument();

	[System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IDocumentService/GetAllOfficialDocument", ReplyAction = "http://www.UniCloud.com/IDocumentService/GetAllOfficialDocumentResponse")]
	System.Threading.Tasks.Task<OfficialDocumentDataObjectList> GetAllOfficialDocumentAsync();

	[System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IDocumentService/GetDocumentDataObjectByDocID", ReplyAction = "http://www.UniCloud.com/IDocumentService/GetDocumentDataObjectByDocIDResponse")]
	[System.ServiceModel.FaultContractAttribute(typeof(FaultData), Action = "http://www.UniCloud.com/IDocumentService/GetDocumentDataObjectByDocIDFaultDataFau" +
		"lt", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
	DocumentDataObject GetDocumentDataObjectByDocID(System.Guid docID);

	[System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IDocumentService/GetDocumentDataObjectByDocID", ReplyAction = "http://www.UniCloud.com/IDocumentService/GetDocumentDataObjectByDocIDResponse")]
	System.Threading.Tasks.Task<DocumentDataObject> GetDocumentDataObjectByDocIDAsync(System.Guid docID);

	[System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IDocumentService/GetAllStandardDocument", ReplyAction = "http://www.UniCloud.com/IDocumentService/GetAllStandardDocumentResponse")]
	[System.ServiceModel.FaultContractAttribute(typeof(FaultData), Action = "http://www.UniCloud.com/IDocumentService/GetAllStandardDocumentFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
	StandardDocumentDataObjectList GetAllStandardDocument();

	[System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IDocumentService/GetAllStandardDocument", ReplyAction = "http://www.UniCloud.com/IDocumentService/GetAllStandardDocumentResponse")]
	System.Threading.Tasks.Task<StandardDocumentDataObjectList> GetAllStandardDocumentAsync();

	[System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IDocumentService/GetPaginationStandardDocumentDataObject", ReplyAction = "http://www.UniCloud.com/IDocumentService/GetPaginationStandardDocumentDataObjectR" +
		"esponse")]
	[System.ServiceModel.FaultContractAttribute(typeof(FaultData), Action = "http://www.UniCloud.com/IDocumentService/GetPaginationStandardDocumentDataObjectF" +
		"aultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
	StandardDocumentDataObjectWithPagination GetPaginationStandardDocumentDataObject(Pagination pagination);

	[System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IDocumentService/GetPaginationStandardDocumentDataObject", ReplyAction = "http://www.UniCloud.com/IDocumentService/GetPaginationStandardDocumentDataObjectR" +
		"esponse")]
    System.Threading.Tasks.Task<StandardDocumentDataObjectWithPagination> GetPaginationStandardDocumentDataObjectAsync(Pagination pagination);

	[System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IDocumentService/GetDocumentFileStream", ReplyAction = "http://www.UniCloud.com/IDocumentService/GetDocumentFileStreamResponse")]
	[System.ServiceModel.FaultContractAttribute(typeof(FaultData), Action = "http://www.UniCloud.com/IDocumentService/GetDocumentFileStreamFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
	byte[] GetDocumentFileStream(System.Guid documentID);

	[System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IDocumentService/GetDocumentFileStream", ReplyAction = "http://www.UniCloud.com/IDocumentService/GetDocumentFileStreamResponse")]
	System.Threading.Tasks.Task<byte[]> GetDocumentFileStreamAsync(System.Guid documentID);

	[System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IDocumentService/CommitStandardDocumentDTO", ReplyAction = "http://www.UniCloud.com/IDocumentService/CommitStandardDocumentDTOResponse")]
	[System.ServiceModel.FaultContractAttribute(typeof(FaultData), Action = "http://www.UniCloud.com/IDocumentService/CommitStandardDocumentDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
	ResultDataStandardDocumentDataObject CommitStandardDocumentDTO(ResultDataStandardDocumentDataObject standardDocumentData);

	[System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IDocumentService/CommitStandardDocumentDTO", ReplyAction = "http://www.UniCloud.com/IDocumentService/CommitStandardDocumentDTOResponse")]
	System.Threading.Tasks.Task<ResultDataStandardDocumentDataObject> CommitStandardDocumentDTOAsync(ResultDataStandardDocumentDataObject standardDocumentData);

	[System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IDocumentService/CommitOfficialDocumentDTO", ReplyAction = "http://www.UniCloud.com/IDocumentService/CommitOfficialDocumentDTOResponse")]
	[System.ServiceModel.FaultContractAttribute(typeof(FaultData), Action = "http://www.UniCloud.com/IDocumentService/CommitOfficialDocumentDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
	ResultDataOfficialDocumentDataObject CommitOfficialDocumentDTO(ResultDataOfficialDocumentDataObject officialDocumentData);

	[System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IDocumentService/CommitOfficialDocumentDTO", ReplyAction = "http://www.UniCloud.com/IDocumentService/CommitOfficialDocumentDTOResponse")]
	System.Threading.Tasks.Task<ResultDataOfficialDocumentDataObject> CommitOfficialDocumentDTOAsync(ResultDataOfficialDocumentDataObject officialDocumentData);

	[System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IDocumentService/AddContractDTO", ReplyAction = "http://www.UniCloud.com/IDocumentService/AddContractDTOResponse")]
	[System.ServiceModel.FaultContractAttribute(typeof(FaultData), Action = "http://www.UniCloud.com/IDocumentService/AddContractDTOFaultDataFault", Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
	System.Nullable<System.Guid> AddContractDTO(DocumentDataObject document);

	[System.ServiceModel.OperationContractAttribute(Action = "http://www.UniCloud.com/IDocumentService/AddContractDTO", ReplyAction = "http://www.UniCloud.com/IDocumentService/AddContractDTOResponse")]
	System.Threading.Tasks.Task<System.Nullable<System.Guid>> AddContractDTOAsync(DocumentDataObject document);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IDocumentServiceChannel : IDocumentService, System.ServiceModel.IClientChannel {
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class DocumentServiceClient : System.ServiceModel.ClientBase<IDocumentService>, IDocumentService {

	public DocumentServiceClient() {
	}

	public DocumentServiceClient(string endpointConfigurationName) :
		base(endpointConfigurationName) {
	}

	public DocumentServiceClient(string endpointConfigurationName, string remoteAddress) :
		base(endpointConfigurationName, remoteAddress) {
	}

	public DocumentServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
		base(endpointConfigurationName, remoteAddress) {
	}

	public DocumentServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
		base(binding, remoteAddress) {
	}

	public DocumentTypeDataObjectList GetDocumentTypeDataObjectList() {
		return base.Channel.GetDocumentTypeDataObjectList();
	}

	public System.Threading.Tasks.Task<DocumentTypeDataObjectList> GetDocumentTypeDataObjectListAsync() {
		return base.Channel.GetDocumentTypeDataObjectListAsync();
	}

	public bool ExistDocumentType(string name) {
		return base.Channel.ExistDocumentType(name);
	}

	public System.Threading.Tasks.Task<bool> ExistDocumentTypeAsync(string name) {
		return base.Channel.ExistDocumentTypeAsync(name);
	}

    public OfficialDocumentDataObjectWithPagination GetPaginationOfficialDocumentDataObject(Pagination pagination)
    {
		return base.Channel.GetPaginationOfficialDocumentDataObject(pagination);
	}

    public System.Threading.Tasks.Task<OfficialDocumentDataObjectWithPagination> GetPaginationOfficialDocumentDataObjectAsync(Pagination pagination)
    {
		return base.Channel.GetPaginationOfficialDocumentDataObjectAsync(pagination);
	}

	public OfficialDocumentDataObjectList GetAllOfficialDocument() {
		return base.Channel.GetAllOfficialDocument();
	}

	public System.Threading.Tasks.Task<OfficialDocumentDataObjectList> GetAllOfficialDocumentAsync() {
		return base.Channel.GetAllOfficialDocumentAsync();
	}

	public DocumentDataObject GetDocumentDataObjectByDocID(System.Guid docID) {
		return base.Channel.GetDocumentDataObjectByDocID(docID);
	}

	public System.Threading.Tasks.Task<DocumentDataObject> GetDocumentDataObjectByDocIDAsync(System.Guid docID) {
		return base.Channel.GetDocumentDataObjectByDocIDAsync(docID);
	}

	public StandardDocumentDataObjectList GetAllStandardDocument() {
		return base.Channel.GetAllStandardDocument();
	}

	public System.Threading.Tasks.Task<StandardDocumentDataObjectList> GetAllStandardDocumentAsync() {
		return base.Channel.GetAllStandardDocumentAsync();
	}

    public StandardDocumentDataObjectWithPagination GetPaginationStandardDocumentDataObject(Pagination pagination)
    {
		return base.Channel.GetPaginationStandardDocumentDataObject(pagination);
	}

    public System.Threading.Tasks.Task<StandardDocumentDataObjectWithPagination> GetPaginationStandardDocumentDataObjectAsync(Pagination pagination)
    {
		return base.Channel.GetPaginationStandardDocumentDataObjectAsync(pagination);
	}

	public byte[] GetDocumentFileStream(System.Guid documentID) {
		return base.Channel.GetDocumentFileStream(documentID);
	}

	public System.Threading.Tasks.Task<byte[]> GetDocumentFileStreamAsync(System.Guid documentID) {
		return base.Channel.GetDocumentFileStreamAsync(documentID);
	}

	public ResultDataStandardDocumentDataObject CommitStandardDocumentDTO(ResultDataStandardDocumentDataObject standardDocumentData) {
		return base.Channel.CommitStandardDocumentDTO(standardDocumentData);
	}

	public System.Threading.Tasks.Task<ResultDataStandardDocumentDataObject> CommitStandardDocumentDTOAsync(ResultDataStandardDocumentDataObject standardDocumentData) {
		return base.Channel.CommitStandardDocumentDTOAsync(standardDocumentData);
	}

	public ResultDataOfficialDocumentDataObject CommitOfficialDocumentDTO(ResultDataOfficialDocumentDataObject officialDocumentData) {
		return base.Channel.CommitOfficialDocumentDTO(officialDocumentData);
	}

	public System.Threading.Tasks.Task<ResultDataOfficialDocumentDataObject> CommitOfficialDocumentDTOAsync(ResultDataOfficialDocumentDataObject officialDocumentData) {
		return base.Channel.CommitOfficialDocumentDTOAsync(officialDocumentData);
	}

	public System.Nullable<System.Guid> AddContractDTO(DocumentDataObject document) {
		return base.Channel.AddContractDTO(document);
	}

	public System.Threading.Tasks.Task<System.Nullable<System.Guid>> AddContractDTOAsync(DocumentDataObject document) {
		return base.Channel.AddContractDTOAsync(document);
	}
}
