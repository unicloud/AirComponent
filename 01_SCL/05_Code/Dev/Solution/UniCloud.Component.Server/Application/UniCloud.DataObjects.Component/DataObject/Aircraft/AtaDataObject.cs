using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UniCloud.DataObjects.AcConfiguration
{
    /// <summary>
    /// 章节
    /// </summary>
    [DataContract(IsReference = false)]
    public class AtaDataObject : IBaseDto
    {
        public AtaDataObject()
        {
            Guid = Guid.NewGuid();
            ChildAtas = new AtaDataObjectList();
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
        /// 章节
        /// </summary>
        [DataMember]
        public string ATA
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
        public int? ParentID
        {
            get;
            set;
        }

        [DataMember]
        public AtaDataObjectList ChildAtas
        {
            get;
            set;
        }

        [DataMember]
        public AtaDataObject ParentAta
        {
            get;
            set;
        }
        
    }

    [CollectionDataContract]
    public partial class AtaDataObjectList : List<AtaDataObject>
    {
    }

    /// <summary>
    /// AtaResultData
    /// </summary>
    [KnownType(typeof(AtaResultData))]
    public class AtaResultData : ResultData<AtaDataObject>
    {
    }
   /// <summary>
   /// AtaWithPagination
   /// </summary>
   [KnownType(typeof(AtaWithPagination))]
   public class AtaWithPagination : BaseDataObjectListWithPagination<AtaDataObject>
   {
   }
}
