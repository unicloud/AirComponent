#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/26 16:23:46

// 文件名：AcConfigDataObject
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
    ///AcConfigDataObject
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "AcConfigDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public partial class AcConfigDataObject : BaseDataObject
    {
        private int? IDField;
        private Guid GuidField;
        private string NameField;
        private int AcModelIDField;
        private Guid AcModelGuidField;
        private string DescriptionField;
        private decimal MTWField;
        private decimal BWField;
        private decimal BWFField;
        private decimal BWIField;
        private decimal BEWField;
        private decimal MTOWField;
        private decimal MLWField;
        private decimal MZFWField;
        private decimal MMFWField;
        private decimal MCCField;
        private int AcTypeIDField;
        //private AcModelDataObject AcModelField;

        /// <summary>
        /// 飞机系列ID
        /// </summary>
        [DataMemberAttribute()]
        public int AcTypeID
        {
            get
            {
                return this.AcTypeIDField;
            }
            set
            {
                if (this.AcTypeIDField != value)
                {
                    this.AcTypeIDField = value;
                    this.RaisePropertyChanged("AcTypeID");
                }
            }
        }

        [DataMemberAttribute()]
        public int? ID
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
        public Guid Guid
        {
            get
            {
                return this.GuidField;
            }
            set
            {
                if (this.GuidField != value)
                {
                    this.GuidField = value;
                    this.RaisePropertyChanged("Guid");
                }
            }
        }

        [DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                if (this.NameField != value)
                {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }

        [DataMemberAttribute()]
        public int AcModelID
        {
            get
            {
                return this.AcModelIDField;
            }
            set
            {
                if (this.AcModelIDField != value)
                {
                    this.AcModelIDField = value;
                    this.RaisePropertyChanged("AcModelID");
                }
            }
        }

        [DataMemberAttribute()]
        public Guid AcModelGuid
        {
            get
            {
                return this.AcModelGuidField;
            }
            set
            {
                if (this.AcModelGuidField != value)
                {
                    this.AcModelGuidField = value;
                    this.RaisePropertyChanged("AcModelGuid");
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
        public decimal MTW
        {
            get
            {
                return this.MTWField;
            }
            set
            {
                if (this.MTWField != value)
                {
                    this.MTWField = value;
                    this.RaisePropertyChanged("MTW");
                }
            }
        }

        [DataMemberAttribute()]
        public decimal BW
        {
            get
            {
                return this.BWField;
            }
            set
            {
                if (this.BWField != value)
                {
                    this.BWField = value;
                    this.RaisePropertyChanged("BW");
                }
            }
        }

        [DataMemberAttribute()]
        public decimal BWF
        {
            get
            {
                return this.BWFField;
            }
            set
            {
                if (this.BWFField != value)
                {
                    this.BWFField = value;
                    this.RaisePropertyChanged("BWF");
                }
            }
        }

        [DataMemberAttribute()]
        public decimal BWI
        {
            get
            {
                return this.BWIField;
            }
            set
            {
                if (this.BWIField != value)
                {
                    this.BWIField = value;
                    this.RaisePropertyChanged("BWI");
                }
            }
        }

        [DataMemberAttribute()]
        public decimal BEW
        {
            get
            {
                return this.BEWField;
            }
            set
            {
                if (this.BEWField != value)
                {
                    this.BEWField = value;
                    this.RaisePropertyChanged("BEW");
                }
            }
        }

        [DataMemberAttribute()]
        public decimal MTOW
        {
            get
            {
                return this.MTOWField;
            }
            set
            {
                if (this.MTOWField != value)
                {
                    this.MTOWField = value;
                    this.RaisePropertyChanged("MTOW");
                }
            }
        }

        [DataMemberAttribute()]
        public decimal MLW
        {
            get
            {
                return this.MLWField;
            }
            set
            {
                if (this.MLWField != value)
                {
                    this.MLWField = value;
                    this.RaisePropertyChanged("MLW");
                }
            }
        }

        [DataMemberAttribute()]
        public decimal MZFW
        {
            get
            {
                return this.MZFWField;
            }
            set
            {
                if (this.MZFWField != value)
                {
                    this.MZFWField = value;
                    this.RaisePropertyChanged("MZFW");
                }
            }
        }

        [DataMemberAttribute()]
        public decimal MMFW
        {
            get
            {
                return this.MMFWField;
            }
            set
            {
                if (this.MMFWField != value)
                {
                    this.MMFWField = value;
                    this.RaisePropertyChanged("MMFW");
                }
            }
        }

        [DataMemberAttribute()]
        public decimal MCC
        {
            get
            {
                return this.MCCField;
            }
            set
            {
                if (this.MCCField != value)
                {
                    this.MCCField = value;
                    this.RaisePropertyChanged("MCC");
                }
            }
        }

        //[DataMemberAttribute()]
        //public AcModelDataObject AcModel
        //{
        //    get
        //    {
        //        return this.AcModelField;
        //    }
        //    set
        //    {
        //       if(this.AcModelField != value)
        //       {
        //           this.AcModelField = value;
        //           this.RaisePropertyChanged("AcModel");
        //       }
        //    }
        //}

    }

    /// <summary>
    /// AcConfigDataObjectList
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [CollectionDataContractAttribute(Name = "AcConfigDataObjectList", ItemName = "AcConfigDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class AcConfigDataObjectList : BaseDataObjectList<AcConfigDataObject>
    {
    }

    /// <summary>
    /// AcConfigResultData
    /// </summary>
    [DataContractAttribute(Name = "AcConfigResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(AcConfigResultData))]
    public class AcConfigResultData : ResultData<AcConfigDataObject>
    {
    }

    /// <summary>
    /// AcConfigWithPagination
    /// </summary>
    [DataContractAttribute(Name = "AcConfigWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(AcConfigWithPagination))]
    public class AcConfigWithPagination : BaseDataObjectListWithPagination<AcConfigDataObject>
    {
    }
}
