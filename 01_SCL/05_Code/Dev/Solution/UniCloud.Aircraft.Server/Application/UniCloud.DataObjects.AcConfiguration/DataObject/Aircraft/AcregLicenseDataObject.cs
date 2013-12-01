using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UniCloud.DataObjects
{
    /// <summary>
    /// 飞机证照
    /// </summary>
    [DataContract(IsReference = false)]
    public class AcregLicenseDataObject : IBaseDto
    {
        public AcregLicenseDataObject()
        {
            Guid = Guid.NewGuid();
        }

        #region IBaseDto成员
        public string Sequence
        {
            get { return "seq_ac_reg"; }
        }

        [DataMember]
        public Nullable<int> ID
        {
            get;
            set;
        }
        #endregion

        /// <summary>
        /// Guid
        /// </summary>
        [DataMember]
        public Guid Guid
        {
            get;
            set;
        }

        /// <summary>
        /// 证照类型
        /// </summary>
        [DataMember]
        public int LicenseTypeID
        {
            get;
            set;
        }

        /// <summary>
        /// LicenseTypeGuid
        /// </summary>
        [DataMember]
        public Guid LicenseTypeGuid
        {
            get;
            set;
        }

        [DataMember]
        public int AcRegID
        {
            get;
            set;
        }

        [DataMember]
        public Guid AcRegGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public string Notes
        {
            get;
            set;
        }

        /// <summary>
        /// 发证单位
        /// </summary>
        [DataMember]
        public string IssuedFrom
        {
            get;
            set;
        }

        /// <summary>
        /// 发证日期
        /// </summary>
        [DataMember]
        public DateTime IssuedDate
        {
            get;
            set;
        }

        /// <summary>
        /// 有效期（月）
        /// </summary>
        [DataMember]
        public int ValidMonths
        {
            get;
            set;
        }

        [DataMember]
        public DateTime ExpireDate
        {
            get;
            set;
        }

        /// <summary>
        /// 状态
        /// </summary>
        [DataMember]
        public string State
        {
            get;
            set;
        }

        /// <summary>
        /// 电子拷贝件
        /// </summary>
        [DataMember]
        public string CopyFile
        {
            get;
            set;
        }

        public Guid? DocumentGuid
        {
            get;
            set;
        }

        [DataMember]
        public LicenseTypeDataObject LicenseType
        {
            get;
            set;
        }
       
        [DataMember]
        public DocumentDataObject Document
        {
            get;
            set;
        }
    }

    [CollectionDataContract]
    public partial class AcregLicenseDataObjectList : BaseDataObjectList<AcregLicenseDataObject>
    {
    }

    /// <summary>
    /// AcregLicenseResultData
    /// </summary>
    [KnownType(typeof(AcregLicenseResultData))]
    public class AcregLicenseResultData : ResultData<AcregLicenseDataObject>
    {
    }
   /// <summary>
   /// AcregLicenseWithPagination
   /// </summary>
   [KnownType(typeof(AcregLicenseWithPagination))]
   public class AcregLicenseWithPagination : BaseDataObjectListWithPagination<AcregLicenseDataObject>
   {
   }
}
