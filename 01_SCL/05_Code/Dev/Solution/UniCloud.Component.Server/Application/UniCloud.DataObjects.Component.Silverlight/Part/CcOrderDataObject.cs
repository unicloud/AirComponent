#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/27 15:14:30

// 文件名：CcOrderDataObject
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
    ///CcOrderDataObject
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "CcOrderDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public partial class CcOrderDataObject : BaseDataObject
    {
        private int IDField;
        private string OrderNoField;
        private string CctypeField;
        private string AcRegField;
        private string SwapAcregField;
        private string RemReasonField;
        private string WoNoField;
        private string WoItemField;
        private string WoTypeField;
        private DateTime UpdateDateField;
        private string UpdateByField;
        private string StateField;
        private string OperatorField;
        private DateTime OperatDateField;
        private int? PnRegIDField;
        private int? SnRegIDField;
        private string PnField;
        private string SnField;
        private CcoutDataObjectList CcoutsField;
        private CcinDataObjectList CcinsField;
        private CcoutDataObject CcoutField;
        private CcinDataObject CcinField;

        public CcOrderDataObject()
        {
            this.Ccouts = new CcoutDataObjectList();
            this.Ccins = new CcinDataObjectList();
        }

        [DataMemberAttribute()]
        public string Pn
        {
            get { return this.PnField; }
            set
            {
                if (this.PnField != value)
                {
                    this.PnField = value;
                    this.RaisePropertyChanged("Pn");
                }
            }
        }

        [DataMemberAttribute()]
        public string Sn
        {
            get { return this.SnField; }
            set
            {
                if (this.SnField != value)
                {
                    this.SnField = value;
                    this.RaisePropertyChanged("SnField");
                }
            }
        }

        [DataMemberAttribute()]
        public int? PnRegID
        {
            get { return this.PnRegIDField; }
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
        public int? SnRegID
        {
            get { return this.SnRegIDField; }
            set
            {
                if (this.SnRegIDField != value)
                {
                    this.SnRegIDField = value;
                    this.RaisePropertyChanged("SnRegID");
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
        public string OrderNo
        {
            get
            {
                return this.OrderNoField;
            }
            set
            {
                if (this.OrderNoField != value)
                {
                    this.OrderNoField = value;
                    this.RaisePropertyChanged("OrderNo");
                }
            }
        }

        [DataMemberAttribute()]
        public string Cctype
        {
            get
            {
                return this.CctypeField;
            }
            set
            {
                if (this.CctypeField != value)
                {
                    this.CctypeField = value;
                    this.RaisePropertyChanged("Cctype");
                }
            }
        }

        [DataMemberAttribute()]
        public string AcReg
        {
            get
            {
                return this.AcRegField;
            }
            set
            {
                if (this.AcRegField != value)
                {
                    this.AcRegField = value;
                    this.RaisePropertyChanged("AcReg");
                }
            }
        }


        [DataMemberAttribute()]
        public string SwapAcreg
        {
            get
            {
                return this.SwapAcregField;
            }
            set
            {
                if (this.SwapAcregField != value)
                {
                    this.SwapAcregField = value;
                    this.RaisePropertyChanged("SwapAcreg");
                }
            }
        }

        [DataMemberAttribute()]
        public string RemReason
        {
            get
            {
                return this.RemReasonField;
            }
            set
            {
                if (this.RemReasonField != value)
                {
                    this.RemReasonField = value;
                    this.RaisePropertyChanged("RemReason");
                }
            }
        }

        [DataMemberAttribute()]
        public string WoNo
        {
            get
            {
                return this.WoNoField;
            }
            set
            {
                if (this.WoNoField != value)
                {
                    this.WoNoField = value;
                    this.RaisePropertyChanged("WoNo");
                }
            }
        }

        [DataMemberAttribute()]
        public string WoItem
        {
            get
            {
                return this.WoItemField;
            }
            set
            {
                if (this.WoItemField != value)
                {
                    this.WoItemField = value;
                    this.RaisePropertyChanged("WoItem");
                }
            }
        }

        [DataMemberAttribute()]
        public string WoType
        {
            get
            {
                return this.WoTypeField;
            }
            set
            {
                if (this.WoTypeField != value)
                {
                    this.WoTypeField = value;
                    this.RaisePropertyChanged("WoType");
                }
            }
        }

        [DataMemberAttribute()]
        public DateTime UpdateDate
        {
            get
            {
                return this.UpdateDateField;
            }
            set
            {
                if (this.UpdateDateField != value)
                {
                    this.UpdateDateField = value;
                    this.RaisePropertyChanged("UpdateDate");
                }
            }
        }

        [DataMemberAttribute()]
        public string UpdateBy
        {
            get
            {
                return this.UpdateByField;
            }
            set
            {
                if (this.UpdateByField != value)
                {
                    this.UpdateByField = value;
                    this.RaisePropertyChanged("UpdateBy");
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
        public DateTime OperatDate
        {
            get
            {
                return this.OperatDateField;
            }
            set
            {
                if (this.OperatDateField != value)
                {
                    this.OperatDateField = value;
                    this.RaisePropertyChanged("OperatDate");
                }
            }
        }

        [DataMemberAttribute()]
        public CcoutDataObjectList Ccouts
        {
            get
            {
                return this.CcoutsField;
            }
            set
            {
                if (this.CcoutsField != value)
                {
                    this.CcoutsField = value;
                    this.RaisePropertyChanged("Ccouts");
                }
            }
        }

        [DataMemberAttribute()]
        public CcinDataObjectList Ccins
        {
            get
            {
                return this.CcinsField;
            }
            set
            {
                if (this.CcinsField != value)
                {
                    this.CcinsField = value;
                    this.RaisePropertyChanged("Ccins");
                }
            }
        }

        [DataMember]
        public CcinDataObject Ccin
        {
            get { return this.CcinField; }
            set
            {
                if (this.CcinField != value)
                {
                    this.CcinField = value;
                    this.RaisePropertyChanged("Ccin");
                }
            }
        }


        [DataMember]
        public CcoutDataObject Ccout
        {
            get { return this.CcoutField; }
            set
            {
                if (this.CcoutField != value)
                {
                    this.CcoutField = value;
                    this.RaisePropertyChanged("Ccout");
                }
            }
        }

    }

    /// <summary>
    /// CcOrderDataObjectList
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [CollectionDataContractAttribute(Name = "CcOrderDataObjectList", ItemName = "CcOrderDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class CcOrderDataObjectList : BaseDataObjectList<CcOrderDataObject>
    {
    }

    /// <summary>
    /// CcOrderResultData
    /// </summary>
    [DataContractAttribute(Name = "CcOrderResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(CcOrderResultData))]
    public class CcOrderResultData : ResultData<CcOrderDataObject>
    {
    }

    /// <summary>
    /// CcOrderWithPagination
    /// </summary>
    [DataContractAttribute(Name = "CcOrderWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(CcOrderWithPagination))]
    public class CcOrderWithPagination : BaseDataObjectListWithPagination<CcOrderDataObject>
    {
    }
}
