#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/27 15:14:30

// 文件名：ScnMainDataObject
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
    ///ScnMainDataObject
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "ScnMainDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public partial class ScnMainDataObject : BaseDataObject
    {
        private int IDField;
        private string ScnNoField;
        private int AcTypeIDField;
        private Guid AcTypeGuidField;
        private int AcModelIDField;
        private Guid AcModelGuidField;
        private string VersionField;
        private string StateField;
        private string DescriptionField;
        private string ScnTypeField;
        private int CloseSituationField;
        private DateTime? ColseTimeField;
        private string CreateUserField;
        private DateTime CreateTimeField;
        private string ScnTitleField;
        private string ModNameField;
        private decimal AmountField;
        private Guid? DocumentIDField;
        private ScnItemDataObjectList ScnItemsField;
        private ScnAcorderDataObjectList ScnAcordersField;
        private WfHistoryDataObjectList WfHistorysField;
        private DocumentDataObject DocumentField;
        private string AtaField;
        private string MoneyOnMsnField;
        private string OrganizationField;
        private string VerifyStatusField;

        public ScnMainDataObject()
        {
            ScnItems = new ScnItemDataObjectList();
            ScnAcorders = new ScnAcorderDataObjectList();
            WfHistorys = new WfHistoryDataObjectList();
        }

        /// <summary>
        /// 关联部门
        /// </summary>
        [DataMemberAttribute()]
        public string Organization
        {
            get
            {
                return this.OrganizationField;
            }
            set
            {
                if (this.OrganizationField != value)
                {
                    this.OrganizationField = value;
                    this.RaisePropertyChanged("Organization");
                }
            }
        }

        /// <summary>
        /// 审核状态
        /// </summary>
        [DataMemberAttribute()]
        public string VerifyStatus
        {
            get
            {
                return this.VerifyStatusField;
            }
            set
            {
                if (this.VerifyStatusField != value)
                {
                    this.VerifyStatusField = value;
                    this.RaisePropertyChanged("VerifyStatus");
                }
            }
        }

        [DataMemberAttribute()]
        public DocumentDataObject Document
        {
            get
            {
                return this.DocumentField;
            }
            set
            {
                if (this.DocumentField != value)
                {
                    this.DocumentField = value;
                    this.RaisePropertyChanged("Document");
                }
            }
        }

        [DataMemberAttribute()]
        public Guid? DocumentID
        {
            get
            {
                return this.DocumentIDField;
            }
            set
            {
                if (this.DocumentIDField != value)
                {
                    this.DocumentIDField = value;
                    this.RaisePropertyChanged("DocumentID");
                }
            }
        }

        [DataMemberAttribute()]
        public decimal Amount
        {
            get
            {
                return this.AmountField;
            }
            set
            {
                if (this.AmountField != value)
                {
                    this.AmountField = value;
                    this.RaisePropertyChanged("Amount");
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

        [Required(ErrorMessage = "必填选项")]
        [StringLength(20, ErrorMessage = "长度不能大于20")]
        [DataMemberAttribute()]
        public string ScnNo
        {
            get
            {
                return this.ScnNoField;
            }
            set
            {
                if (this.ScnNoField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "ScnNo" });
                    this.ScnNoField = value;
                    this.RaisePropertyChanged("ScnNo");
                }
            }
        }

        [DataMemberAttribute()]
        public int AcTypeID
        {
            get
            {
                return this.AcTypeIDField;
            }
            set
            {
                if (this.AcTypeIDField != value)
                {
                    this.AcTypeIDField = value;
                    this.RaisePropertyChanged("AcTypeID");
                }
            }
        }

        [DataMemberAttribute()]
        public Guid AcTypeGuid
        {
            get
            {
                return this.AcTypeGuidField;
            }
            set
            {
                if (this.AcTypeGuidField != value)
                {
                    this.AcTypeGuidField = value;
                    this.RaisePropertyChanged("AcTypeGuid");
                }
            }
        }

        [DataMemberAttribute()]
        public int AcModelID
        {
            get
            {
                return this.AcModelIDField;
            }
            set
            {
                if (this.AcModelIDField != value)
                {
                    this.AcModelIDField = value;
                    this.RaisePropertyChanged("AcModelID");
                }
            }
        }

        [DataMemberAttribute()]
        public Guid AcModelGuid
        {
            get
            {
                return this.AcModelGuidField;
            }
            set
            {
                if (this.AcModelGuidField != value)
                {
                    this.AcModelGuidField = value;
                    this.RaisePropertyChanged("AcModelGuid");
                }
            }
        }

        [StringLength(2, ErrorMessage = "长度不能大于2")]
        [DataMemberAttribute()]
        public string Version
        {
            get
            {
                return this.VersionField;
            }
            set
            {
                if (this.VersionField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Version" });
                    this.VersionField = value;
                    this.RaisePropertyChanged("Version");
                }
            }
        }

        [DataMemberAttribute()]
        public string State
        {
            get
            {
                return this.StateField;
            }
            set
            {
                if (this.StateField != value)
                {
                    this.StateField = value;
                    this.RaisePropertyChanged("State");
                }
            }
        }

        [Required(ErrorMessage = "必填选项")]
        [StringLength(4, ErrorMessage = "长度不能大于4")]
        [DataMemberAttribute()]
        public string ScnType
        {
            get
            {
                return this.ScnTypeField;
            }
            set
            {
                if (this.ScnTypeField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "ScnType" });
                    this.ScnTypeField = value;
                    this.RaisePropertyChanged("ScnType");
                }
            }
        }

        [DataMemberAttribute()]
        public int CloseSituation
        {
            get
            {
                return this.CloseSituationField;
            }
            set
            {
                if (this.CloseSituationField != value)
                {
                    this.CloseSituationField = value;
                    this.RaisePropertyChanged("CloseSituation");
                }
            }
        }

        [DataMemberAttribute()]
        public DateTime? ColseTime
        {
            get
            {
                return this.ColseTimeField;
            }
            set
            {
                if (this.ColseTimeField != value)
                {
                    this.ColseTimeField = value;
                    this.RaisePropertyChanged("ColseTime");
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

        [DataMemberAttribute()]
        public string CreateUser
        {
            get
            {
                return this.CreateUserField;
            }
            set
            {
                if (this.CreateUserField != value)
                {
                    this.CreateUserField = value;
                    this.RaisePropertyChanged("CreateUser");
                }
            }
        }

        [DataMemberAttribute()]
        public DateTime CreateTime
        {
            get
            {
                return this.CreateTimeField;
            }
            set
            {
                if (this.CreateTimeField != value)
                {
                    this.CreateTimeField = value;
                    this.RaisePropertyChanged("CreateTime");
                }
            }
        }

        [Required(ErrorMessage="必填选项")]
        [StringLength(50, ErrorMessage = "长度不能大于50")]
        [DataMemberAttribute()]
        public string ScnTitle
        {
            get
            {
                return this.ScnTitleField;
            }
            set
            {
                if (this.ScnTitleField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "ScnTitle" });
                    this.ScnTitleField = value;
                    this.RaisePropertyChanged("ScnTitle");
                }
            }
        }

        [Required(ErrorMessage = "必填选项")]
        [StringLength(20, ErrorMessage = "长度不能大于20")]
        [DataMemberAttribute()]
        public string ModName
        {
            get
            {
                return this.ModNameField;
            }
            set
            {
                if (this.ModNameField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "ModName" });
                    this.ModNameField = value;
                    this.RaisePropertyChanged("ModName");
                }
            }
        }

        [StringLength(8, ErrorMessage = "长度不能大于8")]
        [DataMemberAttribute()]
        public string Ata
        {
            get
            {
                return this.AtaField;
            }
            set
            {
                if (this.AtaField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Ata" });
                    this.AtaField = value;
                    this.RaisePropertyChanged("Ata");
                }
            }
        }

        /// <summary>
        /// 关联MSN的飞机
        /// </summary>
        [DataMemberAttribute()]
        public string MoneyOnMsn
        {
            get
            {
                return this.MoneyOnMsnField;
            }
            set
            {
                if (this.MoneyOnMsnField != value)
                {
                    this.MoneyOnMsnField = value;
                    this.RaisePropertyChanged("MoneyOnMsn");
                }
            }
        }

    

        [DataMemberAttribute()]
        public ScnItemDataObjectList ScnItems
        {
            get
            {
                return this.ScnItemsField;
            }
            set
            {
                if (this.ScnItemsField != value)
                {
                    this.ScnItemsField = value;
                    this.RaisePropertyChanged("ScnItems");
                }
            }
        }

        [DataMemberAttribute()]
        public ScnAcorderDataObjectList ScnAcorders
        {
            get
            {
                return this.ScnAcordersField;
            }
            set
            {
                if (this.ScnAcordersField != value)
                {
                    this.ScnAcordersField = value;
                    this.RaisePropertyChanged("ScnAcorders");
                }
            }
        }

        [DataMember]
        public WfHistoryDataObjectList WfHistorys
        {
            get
            {
                return this.WfHistorysField;
            }
            set
            {
                if (this.WfHistorysField != value)
                {
                    this.WfHistorysField = value;
                    this.RaisePropertyChanged("WfHistorys");
                }
            }
        }
    }

    /// <summary>
    /// ScnMainDataObjectList
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [CollectionDataContractAttribute(Name = "ScnMainDataObjectList", ItemName = "ScnMainDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class ScnMainDataObjectList : BaseDataObjectList<ScnMainDataObject>
    {
    }

    /// <summary>
    /// ScnMainResultData
    /// </summary>
    [DataContractAttribute(Name = "ScnMainResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(ScnMainResultData))]
    public class ScnMainResultData : ResultData<ScnMainDataObject>
    {
    }

    /// <summary>
    /// ScnMainWithPagination
    /// </summary>
    [DataContractAttribute(Name = "ScnMainWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(ScnMainWithPagination))]
    public class ScnMainWithPagination : BaseDataObjectListWithPagination<ScnMainDataObject>
    {
    }
}
