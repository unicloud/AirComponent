using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace UniCloud.DataObjects.Silverlight
{
    [DataContractAttribute(Name = "AdsbComplyDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class AdsbComplyDataObject : BaseDataObject
    {
        private String ActypeField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public String Actype
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
                    this.RaisePropertyChanged("Actype");
                }
            }
        }

        private String FileTypeField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public String FileType
        {
            get
            {
                return this.FileTypeField;
            }
            set
            {
                if (this.FileTypeField != value)
                {
                    this.FileTypeField = value;
                    this.RaisePropertyChanged("FileType");
                }
            }
        }

        private String FileNoField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public String FileNo
        {
            get
            {
                return this.FileNoField;
            }
            set
            {
                if (this.FileNoField != value)
                {
                    this.FileNoField = value;
                    this.RaisePropertyChanged("FileNo");
                }
            }
        }

        private String FileVersionField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public String FileVersion
        {
            get
            {
                return this.FileVersionField;
            }
            set
            {
                if (this.FileVersionField != value)
                {
                    this.FileVersionField = value;
                    this.RaisePropertyChanged("FileVersion");
                }
            }
        }

        private String ComplyAcField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public String ComplyAc
        {
            get
            {
                return this.ComplyAcField;
            }
            set
            {
                if (this.ComplyAcField != value)
                {
                    this.ComplyAcField = value;
                    this.RaisePropertyChanged("ComplyAc");
                }
            }
        }

        private String ComplyStatusField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public String ComplyStatus
        {
            get
            {
                return this.ComplyStatusField;
            }
            set
            {
                if (this.ComplyStatusField != value)
                {
                    this.ComplyStatusField = value;
                    this.RaisePropertyChanged("ComplyStatus");
                }
            }
        }

        private Nullable<DateTime> ComplyDateField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public Nullable<DateTime> ComplyDate
        {
            get
            {
                return this.ComplyDateField;
            }
            set
            {
                if (this.ComplyDateField != value)
                {
                    this.ComplyDateField = value;
                    this.RaisePropertyChanged("ComplyDate");
                }
            }
        }

        private String ComplyNotesField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public String ComplyNotes
        {
            get
            {
                return this.ComplyNotesField;
            }
            set
            {
                if (this.ComplyNotesField != value)
                {
                    this.ComplyNotesField = value;
                    this.RaisePropertyChanged("ComplyNotes");
                }
            }
        }

        private String ComplyCloseField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public String ComplyClose
        {
            get
            {
                return this.ComplyCloseField;
            }
            set
            {
                if (this.ComplyCloseField != value)
                {
                    this.ComplyCloseField = value;
                    this.RaisePropertyChanged("ComplyClose");
                }
            }
        }

        private Nullable<Decimal> ComFeeField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public Nullable<Decimal> ComFee
        {
            get
            {
                return this.ComFeeField;
            }
            set
            {
                if (this.ComFeeField != value)
                {
                    this.ComFeeField = value;
                    this.RaisePropertyChanged("ComFee");
                }
            }
        }

        private String ComFeeNotesField;
        /// <summary>
        ///
        /// </summary>
        [StringLength(200, ErrorMessage = "长度不能大于200")]
        [DataMemberAttribute()]
        public String ComFeeNotes
        {
            get
            {
                return this.ComFeeNotesField;
            }
            set
            {
                if (this.ComFeeNotesField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "ComFeeNotes" });
                    this.ComFeeNotesField = value;
                    this.RaisePropertyChanged("ComFeeNotes");
                }
            }
        }

        private String ComFeeCurrencyField;
        /// <summary>
        ///
        /// </summary>
        [StringLength(8, ErrorMessage = "长度不能大于8")]
        [DataMemberAttribute()]
        public String ComFeeCurrency
        {
            get
            {
                return this.ComFeeCurrencyField;
            }
            set
            {
                if (this.ComFeeCurrencyField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "ComFeeCurrency" });
                    this.ComFeeCurrencyField = value;
                    this.RaisePropertyChanged("ComFeeCurrency");
                }
            }
        }

        private Int32 IDField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public Int32 ID
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

        private String IdField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public String Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                if (this.IdField != value)
                {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }

        private AdsbDataObject AdsbField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public AdsbDataObject Adsb
        {
            get
            {
                return this.AdsbField;
            }
            set
            {
                if (this.AdsbField != value)
                {
                    this.AdsbField = value;
                    this.RaisePropertyChanged("Adsb");
                }
            }
        }

        private int AdsbIDField;

        [DataMemberAttribute()]
        public int AdsbID
        {
            get
            {
                return this.AdsbIDField;
            }
            set
            {
                if (this.AdsbIDField != value)
                {
                    this.AdsbIDField = value;
                    this.RaisePropertyChanged("AdsbID");
                }
            }
        }
    }

    [CollectionDataContractAttribute(Name = "AdsbComplyDataObjectList", ItemName = "AdsbComplyDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class AdsbComplyDataObjectList : BaseDataObjectList<AdsbComplyDataObject>
    {
    }

    /// <summary>
    /// AdsbComplyDataObjectResultData
    /// </summary>
    [DataContractAttribute(Name = "AdsbComplyResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(AdsbComplyResultData))]
    public class AdsbComplyResultData : ResultData<AdsbComplyDataObject>
    {
    }

    /// <summary>
    /// AdsbComplyDataObjectWithPagination
    /// </summary>
    [DataContractAttribute(Name = "AdsbComplyWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(AdsbComplyWithPagination))]
    public class AdsbComplyWithPagination : BaseDataObjectListWithPagination<AdsbComplyDataObject>
    {
    }
}
