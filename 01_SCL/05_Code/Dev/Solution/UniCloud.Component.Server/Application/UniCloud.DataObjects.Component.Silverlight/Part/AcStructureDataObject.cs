#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/19 15:38:43

// 文件名：AcStructureDataObject
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace UniCloud.DataObjects.Silverlight
{
    /// <summary>
    ///AcStructureDataObject
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "AcStructureDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public partial class AcStructureDataObject : BaseDataObject
    {
        private string ActypeField;
        private string AcmodelField;
        private string ReportNoField;
        private string ReportTypeField;
        private DateTime? ReportDateField;
        private string DescriptionField;
        private string IsDeferField;
        private string AcregField;
        private string TecAssField;
        private string TreatResultField;
        private string StatusField;
        private DateTime? CloseDateField;
        private string SourceField;
        private string LevelField;
        private string RepairDeadlineField;
        private int IDField;

        public AcStructureDataObject()
        {
            this.AttactDocuments = new AttactDocumentDataObjectList();
        }

        private AttactDocumentDataObjectList AttactDocumentsField;
        [DataMember]
        public AttactDocumentDataObjectList AttactDocuments
        {
            get
            {
                return this.AttactDocumentsField;
            }
            set
            {
                if (this.AttactDocumentsField != value)
                {
                    this.AttactDocumentsField = value;
                    this.RaisePropertyChanged("AttactDocuments");
                }
            }
        }


        [StringLength(10, ErrorMessage = "长度不能大于10")]
        [DataMemberAttribute()]
        public string Actype
        {
            get
            {
                return this.ActypeField;
            }
            set
            {
                if (this.ActypeField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Actype" });
                    this.ActypeField = value;
                    this.RaisePropertyChanged("Actype");
                }
            }
        }

        [StringLength(10, ErrorMessage = "长度不能大于10")]
        [DataMemberAttribute()]
        public string Acmodel
        {
            get
            {
                return this.AcmodelField;
            }
            set
            {
                if (this.AcmodelField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Acmodel" });
                    this.AcmodelField = value;
                    this.RaisePropertyChanged("Acmodel");
                }
            }
        }

        [StringLength(20, ErrorMessage = "长度不能大于20")]
        [DataMemberAttribute()]
        public string ReportNo
        {
            get
            {
                return this.ReportNoField;
            }
            set
            {
                if (this.ReportNoField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "ReportNo" });
                    this.ReportNoField = value;
                    this.RaisePropertyChanged("ReportNo");
                }
            }
        }

        [StringLength(10, ErrorMessage = "长度不能大于10")]
        [DataMemberAttribute()]
        public string ReportType
        {
            get
            {
                return this.ReportTypeField;
            }
            set
            {
                if (this.ReportTypeField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "ReportType" });
                    this.ReportTypeField = value;
                    this.RaisePropertyChanged("ReportType");
                }
            }
        }

        [DataMemberAttribute()]
        public DateTime? ReportDate
        {
            get
            {
                return this.ReportDateField;
            }
            set
            {
                if (this.ReportDateField != value)
                {
                    this.ReportDateField = value;
                    this.RaisePropertyChanged("ReportDate");
                }
            }
        }

        [StringLength(1000, ErrorMessage = "长度不能大于1000")]
        [DataMemberAttribute()]
        public string Description
        {
            get
            {
                return this.DescriptionField;
            }
            set
            {
                if (this.DescriptionField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Description" });
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }

        [StringLength(4, ErrorMessage = "长度不能大于4")]
        [DataMemberAttribute()]
        public string IsDefer
        {
            get
            {
                return this.IsDeferField;
            }
            set
            {
                if (this.IsDeferField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "IsDefer" });
                    this.IsDeferField = value;
                    this.RaisePropertyChanged("IsDefer");
                }
            }
        }

        [Required(ErrorMessage="必填选项")]
        [StringLength(10, ErrorMessage = "长度不能大于10")]
        [DataMemberAttribute()]
        public string Acreg
        {
            get
            {
                return this.AcregField;
            }
            set
            {
                if (this.AcregField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Acreg" });
                    this.AcregField = value;
                    this.RaisePropertyChanged("Acreg");
                }
            }
        }

        [StringLength(1000, ErrorMessage = "长度不能大于1000")]
        [DataMemberAttribute()]
        public string TecAss
        {
            get
            {
                return this.TecAssField;
            }
            set
            {
                if (this.TecAssField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "TecAss" });
                    this.TecAssField = value;
                    this.RaisePropertyChanged("TecAss");
                }
            }
        }

        [StringLength(1000, ErrorMessage = "长度不能大于1000")]
        [DataMemberAttribute()]
        public string TreatResult
        {
            get
            {
                return this.TreatResultField;
            }
            set
            {
                if (this.TreatResultField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "TreatResult" });
                    this.TreatResultField = value;
                    this.RaisePropertyChanged("TreatResult");
                }
            }
        }

        [StringLength(6, ErrorMessage = "长度不能大于6")]
        [DataMemberAttribute()]
        public string Status
        {
            get
            {
                return this.StatusField;
            }
            set
            {
                if (this.StatusField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Status" });
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }

        [DataMemberAttribute()]
        public DateTime? CloseDate
        {
            get
            {
                return this.CloseDateField;
            }
            set
            {
                if (this.CloseDateField != value)
                {
                    this.CloseDateField = value;
                    this.RaisePropertyChanged("CloseDate");
                }
            }
        }

        [StringLength(100, ErrorMessage = "长度不能大于100")]
        [DataMemberAttribute()]
        public string Source
        {
            get
            {
                return this.SourceField;
            }
            set
            {
                if (this.SourceField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Source" });
                    this.SourceField = value;
                    this.RaisePropertyChanged("Source");
                }
            }
        }

        [StringLength(10, ErrorMessage = "长度不能大于10")]
        [DataMemberAttribute()]
        public string Level
        {
            get
            {
                return this.LevelField;
            }
            set
            {
                if (this.LevelField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Level" });
                    this.LevelField = value;
                    this.RaisePropertyChanged("Level");
                }
            }
        }

        [StringLength(10, ErrorMessage = "长度不能大于10")]
        [DataMemberAttribute()]
        public string RepairDeadline
        {
            get
            {
                return this.RepairDeadlineField;
            }
            set
            {
                if (this.RepairDeadlineField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "RepairDeadline" });
                    this.RepairDeadlineField = value;
                    this.RaisePropertyChanged("RepairDeadline");
                }
            }
        }

        [DataMemberAttribute()]
        public int ID
        {
            get
            {
                return this.IDField;
            }
            set
            {
                if (this.IDField != value)
                {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }

    }

    /// <summary>
    /// AcStructureDataObjectList
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [CollectionDataContractAttribute(Name = "AcStructureDataObjectList", ItemName = "AcStructureDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class AcStructureDataObjectList : BaseDataObjectList<AcStructureDataObject>
    {
    }

    /// <summary>
    /// AcStructureResultData
    /// </summary>
    [DataContractAttribute(Name = "AcStructureResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(AcStructureResultData))]
    public class AcStructureResultData : ResultData<AcStructureDataObject>
    {
    }

    /// <summary>
    /// AcStructureWithPagination
    /// </summary>
    [DataContractAttribute(Name = "AcStructureWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(AcStructureWithPagination))]
    public class AcStructureWithPagination : BaseDataObjectListWithPagination<AcStructureDataObject>
    {
    }
}
