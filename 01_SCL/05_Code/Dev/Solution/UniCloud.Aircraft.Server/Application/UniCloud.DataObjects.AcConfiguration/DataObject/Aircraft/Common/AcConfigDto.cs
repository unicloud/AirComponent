using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UniCloud.DataObjects
{
    /// <summary>
    /// 飞机配置（展示用）
    /// </summary>
    [DataContract(IsReference = false)]
    public class AcConfigDto
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
        public Guid Guid { get; set; }

        /// <summary>
        /// 机型名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 机型
        /// </summary>
        [DataMember]
        public string AcModel { get; set; }

        /// <summary>
        /// 系列
        /// </summary>
        [DataMember]
        public string AcType { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// 飞机最大滑行重量
        /// </summary>
        [DataMember]
        public decimal MTW { get; set; }

        [DataMember]
        public decimal BW { get; set; }

        /// <summary>
        /// 基本重量重心
        /// </summary>
        [DataMember]
        public decimal BWF { get; set; }

        /// <summary>
        /// 基本重量
        /// </summary>
        [DataMember]
        public decimal BWI { get; set; }

        [DataMember]
        public decimal BEW { get; set; }

        /// <summary>
        /// 飞机最大起飞重量
        /// </summary>
        [DataMember]
        public decimal MTOW { get; set; }

        /// <summary>
        /// 飞机最大着陆重量
        /// </summary>
        [DataMember]
        public decimal MLW { get; set; }

        /// <summary>
        /// 飞机最大零燃油重量
        /// </summary>
        [DataMember]
        public decimal MZFW { get; set; }

        /// <summary>
        /// 飞机最大可用燃油
        /// </summary>
        [DataMember]
        public decimal MMFW { get; set; }

        /// <summary>
        /// 飞机最大商载
        /// </summary>
        [DataMember]
        public decimal MCC { get; set; }
    }

    [CollectionDataContract]
    public class AcConfigDtoList : BaseDataObjectList<AcConfigDto>
    {
    }
}
