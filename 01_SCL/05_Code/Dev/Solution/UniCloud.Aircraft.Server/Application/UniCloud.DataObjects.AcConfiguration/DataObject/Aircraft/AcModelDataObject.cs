using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UniCloud.DataObjects
{
    /// <summary>
    /// 机型
    /// </summary>
    [DataContract(IsReference = false)]
    public class AcModelDataObject : IBaseDto
    {
        public AcModelDataObject()
        {
            Guid = Guid.NewGuid();
            AcTypeGuid = new Guid();
            AcConfigs = new AcConfigDataObjectList();
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
        /// 名称
        /// </summary>
        [DataMember]
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 系列主键
        /// </summary>
        [DataMember]
        public int AcTypeID
        {
            get;
            set;
        }

        /// <summary>
        /// AcTypeGuid
        /// </summary>
        [DataMember]
        public Guid AcTypeGuid
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

        [DataMember]
        public AcConfigDataObjectList AcConfigs
        {
            get;
            set;
        }
    }

    [CollectionDataContract]
    public partial class AcModelDataObjectList : BaseDataObjectList<AcModelDataObject>
    {
    }

    /// <summary>
    /// AcModelResultData
    /// </summary>
    [KnownType(typeof(AcModelResultData))]
    public class AcModelResultData : ResultData<AcModelDataObject>
    {
    }
   /// <summary>
   /// AcModelWithPagination
   /// </summary>
   [KnownType(typeof(AcModelWithPagination))]
   public class AcModelWithPagination : BaseDataObjectListWithPagination<AcModelDataObject>
   {
   }
}
