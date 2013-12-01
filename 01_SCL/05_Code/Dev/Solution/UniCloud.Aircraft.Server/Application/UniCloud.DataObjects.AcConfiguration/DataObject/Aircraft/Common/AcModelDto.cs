using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UniCloud.DataObjects
{
    /// <summary>
    /// 机型信息（展示用）
    /// </summary>
    [DataContract(IsReference = false)]
    public class AcModelDto
    {
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int ID
        {
            get;
            set;
        }

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
        /// 系列
        /// </summary>
        [DataMember]
        public string AcType
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
    }

    [CollectionDataContract]
    public class AcModelDtoList : BaseDataObjectList<AcModelDto>
    {
    }
}
