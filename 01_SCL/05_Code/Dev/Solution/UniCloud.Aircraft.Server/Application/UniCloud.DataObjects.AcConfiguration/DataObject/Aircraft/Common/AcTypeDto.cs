using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UniCloud.DataObjects
{
    /// <summary>
    /// 飞机系列信息（展示用）
    /// </summary>
    [DataContract(IsReference = false)]
    public class AcTypeDto
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
        /// 座级等级
        /// </summary>
        [DataMember]
        public string AcCategory
        {
            get;
            set;
        }
    }

    [CollectionDataContract]
    public class AcTypeDtoList : BaseDataObjectList<AcTypeDto>
    {
    }
}