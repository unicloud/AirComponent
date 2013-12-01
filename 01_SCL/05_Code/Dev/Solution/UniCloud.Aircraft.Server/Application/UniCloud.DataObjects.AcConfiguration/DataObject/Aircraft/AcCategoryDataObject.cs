using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UniCloud.DataObjects
{
    /// <summary>
    /// 座级
    /// </summary>
    [DataContract(IsReference = false)]
    public class AcCategoryDataObject : IBaseDto
    {
        public AcCategoryDataObject()
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
        public Guid Guid { get; set; }

        /// <summary>
        /// 座级等级
        /// </summary>
        [DataMember]
        public string Level { get; set; }

        /// <summary>
        /// 座级描述
        /// </summary>
        [DataMember]
        public string Regional { get; set; }
    }

    [CollectionDataContract]
    public partial class AcCategoryDataObjectList : BaseDataObjectList<AcCategoryDataObject>
    {
    }

    /// <summary>
    /// AcCategoryResultData
    /// </summary>
    [KnownType(typeof(AcCategoryResultData))]
    public class AcCategoryResultData : ResultData<AcCategoryDataObject>
    {
    }
   /// <summary>
   /// AcCategoryWithPagination
   /// </summary>
   [KnownType(typeof(AcCategoryWithPagination))]
   public class AcCategoryWithPagination : BaseDataObjectListWithPagination<AcCategoryDataObject>
   {
   }
}
