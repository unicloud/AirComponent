#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/27 15:14:30

// 文件名：CcinDataObject
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
    ///CcinDataObject
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "CcinDataObject", IsReference = false,
        Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public partial class CcinDataObject : BaseDataObject
    {
        private int IDField;
        private int PnRegIDField;
        private int SnRegIDField;
        private string AtaField;
        private string PropertysField;
        private string ZoneField;
        private string EngineTliField;
        private int SeqField;
        private int? RootSnRegIDField;
        private int? NhSnRegIDField;
        private int CcOrderIDField;
        private string PnField;
        private string SnField;
        private int? FhIntervalField;
        private int? CyIntervalField;
        private Decimal? TsnField;
        private Decimal? TsoField;
        private Decimal? TsrField;
        private Decimal? CsnField;
        private Decimal? CsoField;
        private Decimal? CsrField;

        public CcinDataObject()
        {
        }

        private SnRegDataObject SnRegField;
        [DataMember]
        public SnRegDataObject SnReg
        {
            get
            {
                return this.SnRegField;
            }
            set
            {
                if (this.SnRegField != value)
                {
                    this.SnRegField = value;
                    this.RaisePropertyChanged("SnReg");
                }
            }
        }

        private bool IsNewField;
        [DataMember]
        public bool IsNew
        {
            get
            {
                return this.IsNewField;
            }
            set
            {
                if (this.IsNewField != value)
                {
                    this.IsNewField = value;
                    this.RaisePropertyChanged("IsNew");
                }
            }
        }
        [DataMemberAttribute]
        public virtual Decimal? Tsn
        {
            get { return this.TsnField; }
            set
            {
                if (this.TsnField != value)
                {
                    this.TsnField = value;
                    this.RaisePropertyChanged("Tsn");
                }
            }
        }
        [DataMemberAttribute]
        public virtual Decimal? Tso
        {
            get { return this.TsoField; }
            set
            {
                if (this.TsoField != value)
                {
                    this.TsoField = value;
                    this.RaisePropertyChanged("Tso");
                }
            }
        }
        [DataMemberAttribute]
        public virtual Decimal? Tsr
        {
            get { return this.TsrField; }
            set
            {
                if (this.TsrField != value)
                {
                    this.TsrField = value;
                    this.RaisePropertyChanged("Tsr");
                }
            }
        }
        [DataMemberAttribute]
        public virtual Decimal? Csn
        {
            get { return this.CsnField; }
            set
            {
                if (this.CsnField != value)
                {
                    this.CsnField = value;
                    this.RaisePropertyChanged("Csn");
                }
            }
        }
        [DataMemberAttribute]
        public virtual Decimal? Cso
        {
            get { return this.CsoField; }
            set
            {
                if (this.CsoField != value)
                {
                    this.CsoField = value;
                    this.RaisePropertyChanged("Cso");
                }
            }
        }
        [DataMemberAttribute]
        public virtual Decimal? Csr
        {
            get { return this.CsrField; }
            set
            {
                if (this.CsrField != value)
                {
                    this.CsrField = value;
                    this.RaisePropertyChanged("Csr");
                }
            }
        }

        /// <summary>
        /// 修理间隔 小时
        /// </summary>
        [DataMemberAttribute]
        public virtual int? FhInterval
        {
            get { return this.FhIntervalField; }
            set
            {
                if (this.FhIntervalField != value)
                {
                    this.FhIntervalField = value;
                    this.RaisePropertyChanged("FhInterval");
                }
            }
        }

        /// <summary>
        /// 修理间隔 循环
        /// </summary>
        [DataMemberAttribute]
        public virtual int? CyInterval
        {
            get { return this.CyIntervalField; }
            set
            {
                if (this.CyIntervalField != value)
                {
                    this.CyIntervalField = value;
                    this.RaisePropertyChanged("CyInterval");
                }
            }
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
                    this.RaisePropertyChanged("Sn");
                }
            }
        }


        [DataMemberAttribute()]
        public int ID
        {
            get { return this.IDField; }
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
        public int SnRegID
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
        public string EngineTli
        {
            get { return this.EngineTliField; }
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
        public string Ata
        {
            get { return this.AtaField; }
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
        public string Propertys
        {
            get { return this.PropertysField; }
            set
            {
                if (this.PropertysField != value)
                {
                    this.PropertysField = value;
                    this.RaisePropertyChanged("Propertys");
                }
            }
        }

        [DataMemberAttribute()]
        public string Zone
        {
            get { return this.ZoneField; }
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
        public int Seq
        {
            get { return this.SeqField; }
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
        public int? RootSnRegID
        {
            get { return this.RootSnRegIDField; }
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
        public int? NhSnRegID
        {
            get { return this.NhSnRegIDField; }
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
        public int CcOrderID
        {
            get { return this.CcOrderIDField; }
            set
            {
                if (this.CcOrderIDField != value)
                {
                    this.CcOrderIDField = value;
                    this.RaisePropertyChanged("CcOrderID");
                }
            }
        }

    }

    /// <summary>
   /// CcinDataObjectList
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [CollectionDataContractAttribute(Name = "CcinDataObjectList", ItemName = "CcinDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public class CcinDataObjectList : BaseDataObjectList<CcinDataObject>
   {
   }
   
   /// <summary>
   /// CcinResultData
   /// </summary>
   [DataContractAttribute(Name = "CcinResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(CcinResultData))]
   public class CcinResultData : ResultData<CcinDataObject>
   {
   }
   
   /// <summary>
   /// CcinWithPagination
   /// </summary>
   [DataContractAttribute(Name = "CcinWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(CcinWithPagination))]
   public class CcinWithPagination : BaseDataObjectListWithPagination<CcinDataObject>
   {
   }
}
