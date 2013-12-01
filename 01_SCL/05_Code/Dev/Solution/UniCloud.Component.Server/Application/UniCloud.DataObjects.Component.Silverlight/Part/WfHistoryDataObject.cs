#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/27 15:14:30

// 文件名：WfHistoryDataObject
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

namespace UniCloud.DataObjects.Silverlight
{
    /// <summary>
    ///WfHistoryDataObject
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "WfHistoryDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public partial class WfHistoryDataObject : BaseDataObject
    {
        private int IDField;
        private string SeqField;
        private string AuditorField;
        private DateTime? AuditTimeField;
        private string AuditNotesField;
        private string ResultField;
        private string BusinessField;
        private int BusinessIDField;
        private string DepartmentField;
        private string DescriptionField;
        private bool IsWfReadOnlyField;
        private bool IsSubmitField;

        [DataMemberAttribute()]
        public bool IsSubmit
        {
            get
            {
                return this.IsSubmitField;
            }
            set
            {
                if (this.IsSubmitField != value)
                {
                    this.IsSubmitField = value;
                    this.RaisePropertyChanged("IsSubmit");
                }
            }
        }

        [DataMemberAttribute()]
        public bool IsWfReadOnly
        {
            get
            {
                return this.IsWfReadOnlyField;
            }
            set
            {
                if (this.IsWfReadOnlyField != value)
                {
                    this.IsWfReadOnlyField = value;
                    this.RaisePropertyChanged("IsWfReadOnly");
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

        [DataMemberAttribute()]
        public string Seq
        {
            get
            {
                return this.SeqField;
            }
            set
            {
                if (this.SeqField != value)
                {
                    this.SeqField = value;
                    this.RaisePropertyChanged("Seq");
                }
            }
        }

        [DataMemberAttribute()]
        public string Auditor
        {
            get
            {
                return this.AuditorField;
            }
            set
            {
                if (this.AuditorField != value)
                {
                    this.AuditorField = value;
                    this.RaisePropertyChanged("Auditor");
                }
            }
        }

        [DataMemberAttribute()]
        public DateTime? AuditTime
        {
            get
            {
                return this.AuditTimeField;
            }
            set
            {
                if (this.AuditTimeField != value)
                {
                    this.AuditTimeField = value;
                    this.RaisePropertyChanged("AuditTime");
                }
            }
        }

        [DataMemberAttribute()]
        public string AuditNotes
        {
            get
            {
                return this.AuditNotesField;
            }
            set
            {
                if (this.AuditNotesField != value)
                {
                    this.AuditNotesField = value;
                    this.RaisePropertyChanged("AuditNotes");
                }
            }
        }

        [DataMemberAttribute()]
        public string Result
        {
            get
            {
                return this.ResultField;
            }
            set
            {
                if (this.ResultField != value)
                {
                    this.ResultField = value;
                    this.RaisePropertyChanged("Result");
                }
            }
        }

        [DataMemberAttribute()]
        public string Business
        {
            get
            {
                return this.BusinessField;
            }
            set
            {
                if (this.BusinessField != value)
                {
                    this.BusinessField = value;
                    this.RaisePropertyChanged("Business");
                }
            }
        }

        [DataMemberAttribute()]
        public int BusinessID
        {
            get
            {
                return this.BusinessIDField;
            }
            set
            {
                if (this.BusinessIDField != value)
                {
                    this.BusinessIDField = value;
                    this.RaisePropertyChanged("BusinessID");
                }
            }
        }

        [DataMemberAttribute()]
        public string Department
        {
            get
            {
                return this.DepartmentField;
            }
            set
            {
                if (this.DepartmentField != value)
                {
                    this.DepartmentField = value;
                    this.RaisePropertyChanged("Department");
                }
            }
        }

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
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
    }

    /// <summary>
    /// WfHistoryDataObjectList
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [CollectionDataContractAttribute(Name = "WfHistoryDataObjectList", ItemName = "WfHistoryDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class WfHistoryDataObjectList : BaseDataObjectList<WfHistoryDataObject>
    {
    }

    /// <summary>
    /// WfHistoryResultData
    /// </summary>
    [DataContractAttribute(Name = "WfHistoryResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(WfHistoryResultData))]
    public class WfHistoryResultData : ResultData<WfHistoryDataObject>
    {
    }

    /// <summary>
    /// WfHistoryWithPagination
    /// </summary>
    [DataContractAttribute(Name = "WfHistoryWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(WfHistoryWithPagination))]
    public class WfHistoryWithPagination : BaseDataObjectListWithPagination<WfHistoryDataObject>
    {
    }
}
