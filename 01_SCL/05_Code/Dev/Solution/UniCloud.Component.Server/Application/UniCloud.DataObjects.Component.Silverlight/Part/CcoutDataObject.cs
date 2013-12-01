#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/27 15:14:30

// 文件名：CcoutDataObject
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
    ///CcoutDataObject
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "CcoutDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public partial class CcoutDataObject : BaseDataObject
    {
        private int IDField;
        private int PnRegIDField;
        private int SnRegIDField;
        private string AtaField;
        private string PositionField;
        private string ZoneField;
        private int SeqField;
        private int? RootSnRegIDField;
        private int? NhSnRegIDField;
        private bool UnScheduledField;
        private int CcOrderIDField;
        private string PnField;
        private string SnField;
        private bool IsClaimField;

        /// <summary>
        /// 是否要求索赔
        /// </summary>
        [DataMemberAttribute()]
        public bool IsClaim
        {
            get { return this.IsClaimField; }
            set
            {
                if (this.IsClaimField != value)
                {
                    this.IsClaimField = value;
                    this.RaisePropertyChanged("IsClaim");
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
        public int SnRegID
        {
            get
            {
                return this.SnRegIDField;
            }
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
        public int Seq
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
        public bool UnScheduled
        {
            get
            {
                return this.UnScheduledField;
            }
            set
            {
                if (this.UnScheduledField != value)
                {
                    this.UnScheduledField = value;
                    this.RaisePropertyChanged("UnScheduled");
                }
            }
        }

        [DataMemberAttribute()]
        public int CcOrderID
        {
            get
            {
                return this.CcOrderIDField;
            }
            set
            {
                if (this.CcOrderIDField != value)
                {
                    this.CcOrderIDField = value;
                    this.RaisePropertyChanged("CcOrderID");
                }
            }
        }

        //[DataMemberAttribute()]
        //public CcOrderDataObject CcOrder
        //{
        //    get
        //    {
        //        return this.CcOrderField;
        //    }
        //    set
        //    {
        //       if(this.CcOrderField != value)
        //       {
        //           this.CcOrderField = value;
        //           this.RaisePropertyChanged("CcOrder");
        //       }
        //    }
        //}

    }

    /// <summary>
    /// CcoutDataObjectList
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [CollectionDataContractAttribute(Name = "CcoutDataObjectList", ItemName = "CcoutDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class CcoutDataObjectList : BaseDataObjectList<CcoutDataObject>
    {
    }

    /// <summary>
    /// CcoutResultData
    /// </summary>
    [DataContractAttribute(Name = "CcoutResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(CcoutResultData))]
    public class CcoutResultData : ResultData<CcoutDataObject>
    {
    }

    /// <summary>
    /// CcoutWithPagination
    /// </summary>
    [DataContractAttribute(Name = "CcoutWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(CcoutWithPagination))]
    public class CcoutWithPagination : BaseDataObjectListWithPagination<CcoutDataObject>
    {
    }
}
