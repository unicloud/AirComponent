#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/27 15:14:30

// 文件名：WorkScopeDataObject
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
    ///WorkScopeDataObject
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "WorkScopeDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public partial class WorkScopeDataObject : BaseDataObject
    {
        private int IDField;
        private string ScopeField;
        private string DescriptionField;
        private string ShortNameField;
        private string TypeField;

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

        [Required(ErrorMessage="必填选项")]
        [StringLength(2,ErrorMessage="长度不能大于2")]
        [DataMemberAttribute()]
        public string Scope
        {
            get
            {
                return this.ScopeField;
            }
            set
            {
                if (this.ScopeField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Scope" });
                    this.ScopeField = value;
                    this.RaisePropertyChanged("Scope");
                }
            }
        }

        [StringLength(20, ErrorMessage = "长度不能大于20")]
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
        public string ShortName
        {
            get
            {
                return this.ShortNameField;
            }
            set
            {
                if (this.ShortNameField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "ShortName" });
                    this.ShortNameField = value;
                    this.RaisePropertyChanged("ShortName");
                }
            }
        }

        [StringLength(1, ErrorMessage = "长度不能大于1")]
        [DataMemberAttribute()]
        public string Type
        {
            get
            {
                return this.TypeField;
            }
            set
            {
                if (this.TypeField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Type" });
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }

    }

    /// <summary>
    /// WorkScopeDataObjectList
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [CollectionDataContractAttribute(Name = "WorkScopeDataObjectList", ItemName = "WorkScopeDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class WorkScopeDataObjectList : BaseDataObjectList<WorkScopeDataObject>
    {
    }

    /// <summary>
    /// WorkScopeResultData
    /// </summary>
    [DataContractAttribute(Name = "WorkScopeResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(WorkScopeResultData))]
    public class WorkScopeResultData : ResultData<WorkScopeDataObject>
    {
    }

    /// <summary>
    /// WorkScopeWithPagination
    /// </summary>
    [DataContractAttribute(Name = "WorkScopeWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(WorkScopeWithPagination))]
    public class WorkScopeWithPagination : BaseDataObjectListWithPagination<WorkScopeDataObject>
    {
    }
}
