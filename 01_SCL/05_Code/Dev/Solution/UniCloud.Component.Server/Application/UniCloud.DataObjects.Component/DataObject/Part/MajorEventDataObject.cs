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

namespace UniCloud.DataObjects
{
    /// <summary>
    ///MajorEventDataObject
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "MajorEventDataObject", IsReference = false)]
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

        public MajorEventDataObject()
        {
            this.AttactDocuments = new AttactDocumentDataObjectList();
        }

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
                    this.AcField = value;
                }
            }
        }

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
                    this.PosField = value;
                }
            }
        }

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
                    this.SnField = value;
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
                }
            }
        }

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
                    this.PropertyField = value;
                }
            }
        }

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
                    this.CloseReasonField = value;
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
                }
            }
        }

    }

    /// <summary>
    /// MajorEventDataObjectList
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [CollectionDataContractAttribute(Name = "MajorEventDataObjectList", ItemName = "MajorEventDataObject")]
    public class MajorEventDataObjectList : BaseDataObjectList<MajorEventDataObject>
    {
    }

    /// <summary>
    /// MajorEventResultData
    /// </summary>
    [KnownType(typeof(MajorEventResultData))]
    public class MajorEventResultData : ResultData<MajorEventDataObject>
    {
    }

    /// <summary>
    /// MajorEventWithPagination
    /// </summary>
    [KnownType(typeof(MajorEventWithPagination))]
    public class MajorEventWithPagination : BaseDataObjectListWithPagination<MajorEventDataObject>
    {
    }
}
