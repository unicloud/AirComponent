using System;
using System.Runtime.Serialization;

namespace UniCloud.DataObjects.Silverlight
{
    [DataContractAttribute(Name = "AdsbDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class AdsbDataObject : BaseDataObject
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

        private String FileTitleField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public String FileTitle
        {
            get
            {
                return this.FileTitleField;
            }
            set
            {
                if (this.FileTitleField != value)
                {
                    this.FileTitleField = value;
                    this.RaisePropertyChanged("FileTitle");
                }
            }
        }

        private String FromFileField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public String FromFile
        {
            get
            {
                return this.FromFileField;
            }
            set
            {
                if (this.FromFileField != value)
                {
                    this.FromFileField = value;
                    this.RaisePropertyChanged("FromFile");
                }
            }
        }

        private String ContentField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public String Content
        {
            get
            {
                return this.ContentField;
            }
            set
            {
                if (this.ContentField != value)
                {
                    this.ContentField = value;
                    this.RaisePropertyChanged("Content");
                }
            }
        }

        private Nullable<DateTime> ReceiveDateField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public Nullable<DateTime> ReceiveDate
        {
            get
            {
                return this.ReceiveDateField;
            }
            set
            {
                if (this.ReceiveDateField != value)
                {
                    this.ReceiveDateField = value;
                    this.RaisePropertyChanged("ReceiveDate");
                }
            }
        }

        private AdsbComplyDataObjectList AdsbComplysField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public AdsbComplyDataObjectList AdsbComplys
        {
            get
            {
                return this.AdsbComplysField;
            }
            set
            {
                if (this.AdsbComplysField != value)
                {
                    this.AdsbComplysField = value;
                    this.RaisePropertyChanged("AdsbComply");
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

    }

    [CollectionDataContractAttribute(Name = "AdsbDataObjectList", ItemName = "AdsbDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class AdsbDataObjectList : BaseDataObjectList<AdsbDataObject>
    {
    }

    /// <summary>
    /// AdsbComplyDataObjectResultData
    /// </summary>
    [DataContractAttribute(Name = "AdsbResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(AdsbResultData))]
    public class AdsbResultData : ResultData<AdsbDataObjectList>
    {
    }

    /// <summary>
    /// AdsbComplyDataObjectWithPagination
    /// </summary>
    [DataContractAttribute(Name = "AdsbWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(AdsbWithPagination))]
    public class AdsbWithPagination : BaseDataObjectListWithPagination<AdsbDataObjectList>
    {
    }
}
