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
    public class LicenseTypeDataObject : IBaseDto
    {
        public LicenseTypeDataObject()
        {
            Guid = Guid.NewGuid();
            //AcregLicenses = new AcregLicenseDataObjectList();
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

        [DataMember]
        public string Type
        {
            get;
            set;
        }

        [DataMember]
        public string Description
        {
            get;
            set;
        }

        [DataMember]
        public bool HasFile
        {
            get;
            set;
        }

        //[DataMember]
        //public AcregLicenseDataObjectList AcregLicenses
        //{
        //    get;
        //    set;
        //}
    }

    [CollectionDataContract]
    public partial class LicenseTypeDataObjectList : BaseDataObjectList<LicenseTypeDataObject>
    {
    }

    /// <summary>
    /// LicenseTypeResultData
    /// </summary>
    [KnownType(typeof(LicenseTypeResultData))]
    public class LicenseTypeResultData : ResultData<LicenseTypeDataObject>
    {
    }
   /// <summary>
   /// LicenseTypeWithPagination
   /// </summary>
   [KnownType(typeof(LicenseTypeWithPagination))]
   public class LicenseTypeWithPagination : BaseDataObjectListWithPagination<LicenseTypeDataObject>
   {
   }
}
