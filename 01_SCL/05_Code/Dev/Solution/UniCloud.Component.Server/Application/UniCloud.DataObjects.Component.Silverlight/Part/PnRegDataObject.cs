#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/27 15:14:30

// 文件名：PnRegDataObject
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
    ///PnRegDataObject
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "PnRegDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public partial class PnRegDataObject : BaseDataObject
    {
        private int IDField;
        private string PnField;
        private string PnClassField;
        private string VendorField;
        private DateTime UpdateTimeField;
        private string UpdatebyField;
        private string StateField;
        private string SpecPnField;
        private bool IsLifeField;
        private string DescriptionField;
        private int? TrainRateField;
        private decimal? EGTLimitField;
        private string AtaField;

        /// <summary>
        /// 发动机EGT裕度下限
        /// </summary>
        [DataMemberAttribute]
        public virtual decimal? EGTLimit
        {
            get
            {
                return this.EGTLimitField;
            }
            set
            {
                if (this.EGTLimitField != value)
                {
                    this.EGTLimitField = value;
                    this.RaisePropertyChanged("EGTLimit");
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

        [Required(ErrorMessage="必填选项")]
        [DataMemberAttribute()]
        public string Pn
        {
            get
            {
                return this.PnField;
            }
            set
            {
                if (this.PnField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Pn" });
                    this.PnField = value;
                    this.RaisePropertyChanged("Pn");
                    
                }
            }
        }

        [DataMemberAttribute()]
        public string PnClass
        {
            get
            {
                return this.PnClassField;
            }
            set
            {
                if (this.PnClassField != value)
                {
                    this.PnClassField = value;
                    this.RaisePropertyChanged("PnClass");
                }
            }
        }

        [DataMemberAttribute()]
        public string Vendor
        {
            get
            {
                return this.VendorField;
            }
            set
            {
                if (this.VendorField != value)
                {
                    this.VendorField = value;
                    this.RaisePropertyChanged("Vendor");
                }
            }
        }

        [DataMemberAttribute()]
        public DateTime UpdateTime
        {
            get
            {
                return this.UpdateTimeField;
            }
            set
            {
                if (this.UpdateTimeField != value)
                {
                    this.UpdateTimeField = value;
                    this.RaisePropertyChanged("UpdateTime");
                }
            }
        }

        [DataMemberAttribute()]
        public string Updateby
        {
            get
            {
                return this.UpdatebyField;
            }
            set
            {
                if (this.UpdatebyField != value)
                {
                    this.UpdatebyField = value;
                    this.RaisePropertyChanged("Updateby");
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
        public string SpecPn
        {
            get
            {
                return this.SpecPnField;
            }
            set
            {
                if (this.SpecPnField != value)
                {
                    this.SpecPnField = value;
                    this.RaisePropertyChanged("SpecPn");
                }
            }
        }

        [DataMemberAttribute()]
        public bool IsLife
        {
            get
            {
                return this.IsLifeField;
            }
            set
            {
                if (this.IsLifeField != value)
                {
                    this.IsLifeField = value;
                    this.RaisePropertyChanged("IsLife");
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
        [DataMemberAttribute()]
        public int? TrainRate
        {
            get
            {
                return this.TrainRateField;
            }
            set
            {
                if (this.TrainRateField != value)
                {
                    this.TrainRateField = value;
                    this.RaisePropertyChanged("TrainRate");
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

        private Nullable<Decimal> AOC3Field;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public Nullable<Decimal> AOC3
        {
            get
            {
                return this.AOC3Field;
            }
            set
            {
                if (this.AOC3Field != value)
                {
                    this.AOC3Field = value;
                    this.RaisePropertyChanged("AOC3");
                }
            }
        }

        private Nullable<Decimal> AOC7Field;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public Nullable<Decimal> AOC7
        {
            get
            {
                return this.AOC7Field;
            }
            set
            {
                if (this.AOC7Field != value)
                {
                    this.AOC7Field = value;
                    this.RaisePropertyChanged("AOC7");
                }
            }
        }

        private Nullable<Decimal> IOCField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public Nullable<Decimal> IOC
        {
            get
            {
                return this.IOCField;
            }
            set
            {
                if (this.IOCField != value)
                {
                    this.IOCField = value;
                    this.RaisePropertyChanged("IOC");
                }
            }
        }

        private Nullable<Decimal> IOCAField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public Nullable<Decimal> IOCA
        {
            get
            {
                return this.IOCAField;
            }
            set
            {
                if (this.IOCAField != value)
                {
                    this.IOCAField = value;
                    this.RaisePropertyChanged("IOCA");
                }
            }
        }

    }

    /// <summary>
    /// PnRegDataObjectList
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [CollectionDataContractAttribute(Name = "PnRegDataObjectList", ItemName = "PnRegDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class PnRegDataObjectList : BaseDataObjectList<PnRegDataObject>
    {
    }

    /// <summary>
    /// PnRegResultData
    /// </summary>
    [DataContractAttribute(Name = "PnRegResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(PnRegResultData))]
    public class PnRegResultData : ResultData<PnRegDataObject>
    {
    }

    /// <summary>
    /// PnRegWithPagination
    /// </summary>
    [DataContractAttribute(Name = "PnRegWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(PnRegWithPagination))]
    public class PnRegWithPagination : BaseDataObjectListWithPagination<PnRegDataObject>
    {
    }
}
