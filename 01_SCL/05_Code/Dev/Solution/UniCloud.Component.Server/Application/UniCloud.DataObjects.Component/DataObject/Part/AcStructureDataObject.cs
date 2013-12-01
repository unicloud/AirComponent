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
using System.Runtime.Serialization;

namespace UniCloud.DataObjects
{
    /// <summary>
    ///AcStructureDataObject
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "AcStructureDataObject", IsReference = false)]
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
                    this.ActypeField = value;
                }
            }
        }

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
                    this.AcmodelField = value;
                }
            }
        }

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
                    this.ReportNoField = value;
                }
            }
        }

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
                    this.ReportTypeField = value;
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
                    this.IsDeferField = value;
                }
            }
        }

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
                    this.AcregField = value;
                }
            }
        }

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
                    this.TecAssField = value;
                }
            }
        }

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
                    this.TreatResultField = value;
                }
            }
        }

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
                    this.StatusField = value;
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
                    this.SourceField = value;
                }
            }
        }

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
                    this.LevelField = value;
                }
            }
        }

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
                    this.RepairDeadlineField = value;
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
    /// AcStructureDataObjectList
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [CollectionDataContractAttribute(Name = "AcStructureDataObjectList", ItemName = "AcStructureDataObject")]
    public class AcStructureDataObjectList : BaseDataObjectList<AcStructureDataObject>
    {
    }

    /// <summary>
    /// AcStructureResultData
    /// </summary>
    [KnownType(typeof(AcStructureResultData))]
    public class AcStructureResultData : ResultData<AcStructureDataObject>
    {
    }

    /// <summary>
    /// AcStructureWithPagination
    /// </summary>
    [KnownType(typeof(AcStructureWithPagination))]
    public class AcStructureWithPagination : BaseDataObjectListWithPagination<AcStructureDataObject>
    {
    }
}
