using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UniCloud.DataObjects
{
    /// <summary>
    /// 系列/客户机型
    /// </summary>
    [DataContract(IsReference = false)]
    public class AcTypeDataObject : IBaseDto
    {
        public AcTypeDataObject()
        {
            Guid = Guid.NewGuid();
            AcCategoryGuid = new Guid();
            Acmodels = new AcModelDataObjectList();
            Atas = new AtaDataObjectList();
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
        /// 系列
        /// </summary>
        [DataMember]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 描述
        /// </summary>
        [DataMember]
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 厂商
        /// </summary>
        [DataMember]
        public string Manufacturer
        {
            get;
            set;
        }

        /// <summary>
        /// 座级等级编号
        /// </summary>
        [DataMember]
        public string AcCategory
        {
            get;
            set;
        }

        /// <summary>
        /// AcCategoryGuid
        /// </summary>
        [DataMember]
        public Guid AcCategoryGuid
        {
            get;
            set;
        }

        [DataMember]
        public AtaDataObjectList Atas
        {
            get;
            set;
        }

        [DataMember]
        public AcModelDataObjectList Acmodels
        {
            get;
            set;
        }
    }

    [CollectionDataContract]
    public partial class AcTypeDataObjectList : BaseDataObjectList<AcTypeDataObject>
    {
    }

    /// <summary>
    /// AcTypeResultData
    /// </summary>
    [KnownType(typeof(AcTypeResultData))]
    public class AcTypeResultData : ResultData<AcTypeDataObject>
    {
    }
   /// <summary>
   /// AcTypeWithPagination
   /// </summary>
   [KnownType(typeof(AcTypeWithPagination))]
   public class AcTypeWithPagination : BaseDataObjectListWithPagination<AcTypeDataObject>
   {
   }
}
