#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/16 16:16:39

// 文件名：MajorEventDataObject
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace UniCloud.DataObjects.Silverlight
{
    /// <summary>
    ///MajorEventDataObject
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "MajorEventDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public partial class MajorEventDataObject : BaseDataObject
    {
        private string AcField;
        private string PosField;
        private string SnField;
        private string DescriptionField;
        private string PropertyField;
        private string CloseReasonField;
        private DateTime? CloseDateField;
        private DateTime CreateDateField;
        private int IDField;
        private string SubCloseReasonField;
        private string SubDescriptionField;
       

        public MajorEventDataObject()
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

        [Required(ErrorMessage = "必填选项")]
        [StringLength(6, ErrorMessage = "长度不能大于6")]
        [DataMemberAttribute()]
        public string Ac
        {
            get
            {
                return this.AcField;
            }
            set
            {
                if (this.AcField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Ac" });
                    this.AcField = value;
                    this.RaisePropertyChanged("Ac");
                }
            }
        }

        [StringLength(3, ErrorMessage = "长度不能大于3")]
        [DataMemberAttribute()]
        public string Pos
        {
            get
            {
                return this.PosField;
            }
            set
            {
                if (this.PosField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Pos" });
                    this.PosField = value;
                    this.RaisePropertyChanged("Pos");
                }
            }
        }

        [Required(ErrorMessage = "必填选项")]
        [StringLength(20, ErrorMessage = "长度不能大于20")]
        [DataMemberAttribute()]
        public string Sn
        {
            get
            {
                return this.SnField;
            }
            set
            {
                if (this.SnField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Sn" });
                    this.SnField = value;
                    this.RaisePropertyChanged("Sn");
                }
            }
        }

        [StringLength(2000, ErrorMessage = "长度不能大于2000")]
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

        [StringLength(10, ErrorMessage = "长度不能大于10")]
        [DataMemberAttribute()]
        public string Property
        {
            get
            {
                return this.PropertyField;
            }
            set
            {
                if (this.PropertyField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Property" });
                    this.PropertyField = value;
                    this.RaisePropertyChanged("Property");
                }
            }
        }

        [StringLength(1000, ErrorMessage = "长度不能大于1000")]
        [DataMemberAttribute()]
        public string CloseReason
        {
            get
            {
                return this.CloseReasonField;
            }
            set
            {
                if (this.CloseReasonField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "CloseReason" });
                    this.CloseReasonField = value;
                    this.RaisePropertyChanged("CloseReason");
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

        [DataMemberAttribute()]
        public DateTime CreateDate
        {
            get
            {
                return this.CreateDateField;
            }
            set
            {
                if (this.CreateDateField != value)
                {
                    this.CreateDateField = value;
                    this.RaisePropertyChanged("CreateDate");
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

        /// <summary>
        /// 用来在Grid中显示
        /// </summary>
        [DataMemberAttribute()]
        public string SubCloseReason
        {
            get
            {
                if (CloseReason != null && CloseReason.Length > 20)
                {
                    return CloseReason.Substring(0, 20);
                }
                return this.CloseReason;
            }
            set
            {
                if (this.SubCloseReasonField != value)
                {
                    this.SubCloseReasonField = value;
                    this.RaisePropertyChanged("SubCloseReason");
                }
            }
        }

        [DataMemberAttribute()]
        public string SubDescription
        {
            get
            {
                if (Description != null && Description.Length > 20)
                {
                    return Description.Substring(0, 20);
                }
                return this.Description;
            }
            set
            {
                if (this.SubDescriptionField != value)
                {
                    this.SubDescriptionField = value;
                    this.RaisePropertyChanged("SubDescription");
                }
            }
        }

    }

    /// <summary>
    /// MajorEventDataObjectList
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [CollectionDataContractAttribute(Name = "MajorEventDataObjectList", ItemName = "MajorEventDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class MajorEventDataObjectList : BaseDataObjectList<MajorEventDataObject>
    {
    }

    /// <summary>
    /// MajorEventResultData
    /// </summary>
    [DataContractAttribute(Name = "MajorEventResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(MajorEventResultData))]
    public class MajorEventResultData : ResultData<MajorEventDataObject>
    {
    }

    /// <summary>
    /// MajorEventWithPagination
    /// </summary>
    [DataContractAttribute(Name = "MajorEventWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(MajorEventWithPagination))]
    public class MajorEventWithPagination : BaseDataObjectListWithPagination<MajorEventDataObject>
    {
    }
}
