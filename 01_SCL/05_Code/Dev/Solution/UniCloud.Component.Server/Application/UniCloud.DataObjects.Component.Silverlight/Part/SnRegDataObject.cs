#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/27 15:14:30

// 文件名：SnRegDataObject
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
    ///SnRegDataObject
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "SnRegDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public partial class SnRegDataObject : BaseDataObject
    {
        private int IDField;
        private int PnRegIDField;
        private string SnField;
        private string AcField;
        private string AtaField;
        private string PositionField;
        private DateTime InstallDateField;
        private string NoteField;
        private string AvailField;
        private int? NhSnRegIDField;
        private int? RootSnRegIDField;
        private string ZoneField;
        private string EngineTliField;
        private DateTime? RemoveDateField;
        private DateTime? RepairDateField;
        private string OwnerField;
        private string LeaserField;
        private string PropertysField;
        private string IntervalField;
        private string SyncAMASISField;
        private bool IsSyncAMASISField;
        private PnRegDataObject PnRegField;
        private SnRegDataObject NhSnRegField;
        private SnRegDataObject RootSnRegField;
        private SnHistoryDataObject snHistory;
        private EgtMarginDataObjectList EgtMarginsField;
        private AttactDocumentDataObjectList AttactDocumentsField;
        private DateTime? OperateDateField;
        private string OperatorField;
        private decimal? EgtmField;
        private int? EgtMarginIDField;

        public SnRegDataObject()
        {
            this.EgtMargins = new EgtMarginDataObjectList();
            this.AttactDocuments = new AttactDocumentDataObjectList();
        }

        #region 一般属性

        [DataMemberAttribute()]
        public int? EgtMarginID
        {
            get
            {
                return this.EgtMarginIDField;
            }
            set
            {
                if (this.EgtMarginIDField != value)
                {
                    this.EgtMarginIDField = value;
                    this.RaisePropertyChanged("EgtMarginID");
                }
            }
        }


        /// <summary>
        ///  拆下时间
        /// </summary>
        [DataMemberAttribute()]
        public virtual DateTime? RemoveDate
        {
            get
            {
                return this.RemoveDateField;
            }
            set
            {
                if (this.RemoveDateField != value)
                {
                    this.RemoveDateField = value;
                    this.RaisePropertyChanged("RemoveDate");
                }
            }
        }

        /// <summary>
        ///  送修时间
        /// </summary>
        [DataMemberAttribute()]
        public virtual DateTime? RepairDate
        {
            get
            {
                return this.RepairDateField;
            }
            set
            {
                if (this.RepairDateField != value)
                {
                    this.RepairDateField = value;
                    this.RaisePropertyChanged("RepairDate");
                }
            }
        }

        /// <summary>
        ///  所有人
        /// </summary>
        [DataMemberAttribute()]
        public virtual string Owner
        {
            get
            {
                return this.OwnerField;
            }
            set
            {
                if (this.OwnerField != value)
                {
                    this.OwnerField = value;
                    this.RaisePropertyChanged("Owner");
                }
            }
        }

        /// <summary>
        ///  出租人
        /// </summary>
        [DataMemberAttribute()]
        public virtual string Leaser
        {
            get
            {
                return this.LeaserField;
            }
            set
            {
                if (this.LeaserField != value)
                {
                    this.LeaserField = value;
                    this.RaisePropertyChanged("Leaser");
                }
            }
        }

        /// <summary>
        ///  引进类型
        /// </summary>
        [DataMemberAttribute()]
        public virtual string Propertys
        {
            get
            {
                return this.PropertysField;
            }
            set
            {
                if (this.PropertysField != value)
                {
                    this.PropertysField = value;
                    this.RaisePropertyChanged("Propertys");
                }
            }
        }
        /// <summary>
        ///  引进类型
        /// </summary>
        [DataMemberAttribute()]
        public virtual string Interval
        {
            get
            {
                return this.IntervalField;
            }
            set
            {
                if (this.IntervalField != value)
                {
                    this.IntervalField = value;
                    this.RaisePropertyChanged("Interval");
                }
            }
        }
        /// <summary>
        /// 是否同步AMASIS Y/N
        /// </summary>
        [DataMemberAttribute()]
        public virtual string SyncAMASIS
        {
            get
            {
                return this.SyncAMASISField;
            }
            set
            {
                if (this.SyncAMASISField != value)
                {
                    this.SyncAMASISField = value;
                    this.RaisePropertyChanged("SyncAMASIS");
                }
            }
        }

        /// <summary>
        /// 是否同步AMASIS Y/N
        /// </summary>
        [DataMemberAttribute()]
        public virtual bool IsSyncAMASIS
        {
            get
            {
                if (SyncAMASISField == "Y")
                    IsSyncAMASISField = true;
                else if (SyncAMASISField == "N")
                    IsSyncAMASISField = false;
                return this.IsSyncAMASISField;
            }
            set
            {
                if (this.IsSyncAMASISField != value)
                {
                    this.IsSyncAMASISField = value;
                    if (IsSyncAMASISField)
                        SyncAMASIS = "Y";
                    else
                        SyncAMASIS = "N";
                    this.RaisePropertyChanged("IsSyncAMASIS");
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
        public int PnRegID
        {
            get
            {
                return this.PnRegIDField;
            }
            set
            {
                if (this.PnRegIDField != value)
                {
                    this.PnRegIDField = value;
                    this.RaisePropertyChanged("PnRegID");
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
                    this.RaisePropertyChanged("Sn");
                }
            }
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
                    this.RaisePropertyChanged("Ac");
                }
            }
        }


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
                    this.AtaField = value;
                    this.RaisePropertyChanged("Ata");
                }
            }
        }

        [DataMemberAttribute()]
        public string Position
        {
            get
            {
                return this.PositionField;
            }
            set
            {
                if (this.PositionField != value)
                {
                    this.PositionField = value;
                    this.RaisePropertyChanged("Position");
                }
            }
        }

        [DataMemberAttribute()]
        public DateTime InstallDate
        {
            get
            {
                return this.InstallDateField;
            }
            set
            {
                if (this.InstallDateField != value)
                {
                    this.InstallDateField = value;
                    this.RaisePropertyChanged("InstallDate");
                }
            }
        }

        [DataMemberAttribute()]
        public string Note
        {
            get
            {
                return this.NoteField;
            }
            set
            {
                if (this.NoteField != value)
                {
                    this.NoteField = value;
                    this.RaisePropertyChanged("Note");
                }
            }
        }

        [DataMemberAttribute()]
        public string Avail
        {
            get
            {
                return this.AvailField;
            }
            set
            {
                if (this.AvailField != value)
                {
                    this.AvailField = value;
                    this.RaisePropertyChanged("Avail");
                }
            }
        }

        [DataMemberAttribute()]
        public int? NhSnRegID
        {
            get
            {
                return this.NhSnRegIDField;
            }
            set
            {
                if (this.NhSnRegIDField != value)
                {
                    this.NhSnRegIDField = value;
                    this.RaisePropertyChanged("NhSnRegID");
                }
            }
        }

        [DataMemberAttribute()]
        public int? RootSnRegID
        {
            get
            {
                return this.RootSnRegIDField;
            }
            set
            {
                if (this.RootSnRegIDField != value)
                {
                    this.RootSnRegIDField = value;
                    this.RaisePropertyChanged("RootSnRegID");
                }
            }
        }

        [DataMemberAttribute()]
        public string Zone
        {
            get
            {
                return this.ZoneField;
            }
            set
            {
                if (this.ZoneField != value)
                {
                    this.ZoneField = value;
                    this.RaisePropertyChanged("Zone");
                }
            }
        }
        [DataMemberAttribute()]
        public string EngineTli
        {
            get
            {
                return this.EngineTliField;
            }
            set
            {
                if (this.EngineTliField != value)
                {
                    this.EngineTliField = value;
                    this.RaisePropertyChanged("EngineTli");
                }
            }
        }

        [DataMemberAttribute()]
        public decimal? Egtm
        {
            get
            {
                return this.EgtmField;
            }
            set
            {
                if (this.EgtmField != value)
                {
                    this.EgtmField = value;
                    this.RaisePropertyChanged("Egtm");
                }
            }
        }

        [DataMemberAttribute()]
        public string Operator
        {
            get
            {
                return this.OperatorField;
            }
            set
            {
                if (this.OperatorField != value)
                {
                    this.OperatorField = value;
                    this.RaisePropertyChanged("Operator");
                }
            }
        }

        [DataMemberAttribute()]
        public DateTime? OperateDate
        {
            get
            {
                return this.OperateDateField;
            }
            set
            {
                if (this.OperateDateField != value)
                {
                    this.OperateDateField = value;
                    this.RaisePropertyChanged("OperateDate");
                }
            }
        }
        #endregion

        #region 导航属性
        [DataMemberAttribute()]
        public PnRegDataObject PnReg
        {
            get
            {
                return this.PnRegField;
            }
            set
            {
                if (this.PnRegField != value)
                {
                    this.PnRegField = value;
                    this.RaisePropertyChanged("PnReg");
                }
            }
        }
        [DataMemberAttribute()]
        public SnRegDataObject NhSnReg
        {
            get
            {
                return this.NhSnRegField;
            }
            set
            {
                if (this.NhSnRegField != value)
                {
                    this.NhSnRegField = value;
                    this.RaisePropertyChanged("NhSnReg");
                }
            }
        }
        [DataMemberAttribute()]
        public SnRegDataObject RootSnReg
        {
            get
            {
                return this.RootSnRegField;
            }
            set
            {
                if (this.RootSnRegField != value)
                {
                    this.RootSnRegField = value;
                    this.RaisePropertyChanged("RootSnReg");
                }
            }
        }

       
        /// <summary>
        /// 附件文档
        /// </summary>
        [DataMemberAttribute()]
        public virtual AttactDocumentDataObjectList AttactDocuments
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


        /// <summary>
        /// EGT裕度
        /// </summary>
        [DataMemberAttribute()]
        public virtual EgtMarginDataObjectList EgtMargins
        {
            get
            {
                return this.EgtMarginsField;
            }
            set
            {
                if (this.EgtMarginsField != value)
                {
                    this.EgtMarginsField = value;
                    this.RaisePropertyChanged("EgtMargins");
                }
            }
        }
        #endregion



    }

    /// <summary>
    /// SnRegDataObjectList
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [CollectionDataContractAttribute(Name = "SnRegDataObjectList", ItemName = "SnRegDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class SnRegDataObjectList : BaseDataObjectList<SnRegDataObject>
    {
    }

    /// <summary>
    /// SnRegResultData
    /// </summary>
    [DataContractAttribute(Name = "SnRegResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(SnRegResultData))]
    public class SnRegResultData : ResultData<SnRegDataObject>
    {
    }

    /// <summary>
    /// SnRegWithPagination
    /// </summary>
    [DataContractAttribute(Name = "SnRegWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(SnRegWithPagination))]
    public class SnRegWithPagination : BaseDataObjectListWithPagination<SnRegDataObject>
    {
    }
}
