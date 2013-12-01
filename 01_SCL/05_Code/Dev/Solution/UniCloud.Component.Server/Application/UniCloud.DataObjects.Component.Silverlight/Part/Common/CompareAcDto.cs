using System;
using System.Runtime.Serialization;

namespace UniCloud.DataObjects.Silverlight
{
    [DataContractAttribute(Name = "CompareAcDto", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class CompareAcDto : BaseDataObject
    {
        private Nullable<Decimal> PriceField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public Nullable<Decimal> Price
        {
            get
            {
                return this.PriceField;
            }
            set
            {
                if (this.PriceField != value)
                {
                    this.PriceField = value;
                    this.RaisePropertyChanged("Price");
                }
            }
        }

        private String ScnTitleField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public String ScnTitle
        {
            get
            {
                return this.ScnTitleField;
            }
            set
            {
                if (this.ScnTitleField != value)
                {
                    this.ScnTitleField = value;
                    this.RaisePropertyChanged("ScnTitle");
                }
            }
        }

        private String ModField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public String Mod
        {
            get
            {
                return this.ModField;
            }
            set
            {
                if (this.ModField != value)
                {
                    this.ModField = value;
                    this.RaisePropertyChanged("Mod");
                }
            }
        }

        private String MsnField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public String Msn
        {
            get
            {
                return this.MsnField;
            }
            set
            {
                if (this.MsnField != value)
                {
                    this.MsnField = value;
                    this.RaisePropertyChanged("Msn");
                }
            }
        }

    }

    [CollectionDataContractAttribute(Name = "CompareAcDtoList", ItemName = "CompareAcDto", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class CompareAcDtoList : BaseDataObjectList<CompareAcDto>
    {
    }
}
