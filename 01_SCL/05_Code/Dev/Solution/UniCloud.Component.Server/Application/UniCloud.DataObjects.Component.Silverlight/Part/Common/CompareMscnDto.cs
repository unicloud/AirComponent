using System;
using System.Runtime.Serialization;

namespace UniCloud.DataObjects.Silverlight
{
    [DataContractAttribute(Name = "CompareMscnDto", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class CompareMscnDto : BaseDataObject
    {
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

        private String MscnNoField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public String MscnNo
        {
            get
            {
                return this.MscnNoField;
            }
            set
            {
                if (this.MscnNoField != value)
                {
                    this.MscnNoField = value;
                    this.RaisePropertyChanged("MscnNo");
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

        private Boolean SysHasField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public Boolean SysHas
        {
            get
            {
                return this.SysHasField;
            }
            set
            {
                if (this.SysHasField != value)
                {
                    this.SysHasField = value;
                    this.RaisePropertyChanged("SysHas");
                }
            }
        }

        private Boolean AirBusHasField;
        /// <summary>
        ///
        /// </summary>
        [DataMemberAttribute()]
        public Boolean AirBusHas
        {
            get
            {
                return this.AirBusHasField;
            }
            set
            {
                if (this.AirBusHasField != value)
                {
                    this.AirBusHasField = value;
                    this.RaisePropertyChanged("AirBusHas");
                }
            }
        }

    }

    [CollectionDataContractAttribute(Name = "CompareMscnDtoList", ItemName = "CompareMscnDto", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class CompareMscnDtoList : BaseDataObjectList<CompareMscnDto>
    {
    }
}
