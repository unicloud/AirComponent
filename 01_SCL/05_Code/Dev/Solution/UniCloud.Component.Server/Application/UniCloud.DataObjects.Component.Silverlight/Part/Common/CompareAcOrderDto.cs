using System;
using System.Runtime.Serialization;

namespace UniCloud.DataObjects.Silverlight
{
    [DataContractAttribute(Name = "CompareAcOrderDto", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class CompareAcOrderDto : BaseDataObject
    {

        public CompareAcOrderDto()
        {
            this.AcList = new CompareAcDtoList();
        }

        private String ScnNoField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public String ScnNo
        {
            get
            {
                return this.ScnNoField;
            }
            set
            {
                if (this.ScnNoField != value)
                {
                    this.ScnNoField = value;
                    this.RaisePropertyChanged("ScnNo");
                }
            }
        }

        private Int32 CountField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public Int32 Count
        {
            get
            {
                return this.CountField;
            }
            set
            {
                if (this.CountField != value)
                {
                    this.CountField = value;
                    this.RaisePropertyChanged("Count");
                }
            }
        }

        private String VersionField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public String Version
        {
            get
            {
                return this.VersionField;
            }
            set
            {
                if (this.VersionField != value)
                {
                    this.VersionField = value;
                    this.RaisePropertyChanged("Version");
                }
            }
        }

        private Boolean HasMsn1Field;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public Boolean HasMsn1
        {
            get
            {
                return this.HasMsn1Field;
            }
            set
            {
                if (this.HasMsn1Field != value)
                {
                    this.HasMsn1Field = value;
                    this.RaisePropertyChanged("HasMsn1");
                }
            }
        }

        private Boolean HasMsn2Field;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public Boolean HasMsn2
        {
            get
            {
                return this.HasMsn2Field;
            }
            set
            {
                if (this.HasMsn2Field != value)
                {
                    this.HasMsn2Field = value;
                    this.RaisePropertyChanged("HasMsn2");
                }
            }
        }

        private CompareAcDtoList AcListField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public CompareAcDtoList AcList
        {
            get
            {
                return this.AcListField;
            }
            set
            {
                if (this.AcListField != value)
                {
                    this.AcListField = value;
                    this.RaisePropertyChanged("AcList");
                }
            }
        }

    }

    [CollectionDataContractAttribute(Name = "CompareAcOrderDtoList", ItemName = "CompareAcOrderDto", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class CompareAcOrderDtoList : BaseDataObjectList<CompareAcOrderDto>
    {
    }

    /// <summary>
    /// AttactDocumentResultData
    /// </summary>
    [KnownType(typeof(CompareAcOrderDtoResultData))]
    public class CompareAcOrderDtoResultData : ResultData<CompareAcOrderDto>
    {
    }

    /// <summary>
    /// AttactDocumentWithPagination
    /// </summary>
    [KnownType(typeof(CompareAcOrderDtoWithPagination))]
    public class CompareAcOrderDtoWithPagination : BaseDataObjectListWithPagination<CompareAcOrderDto>
    {
    }
}
