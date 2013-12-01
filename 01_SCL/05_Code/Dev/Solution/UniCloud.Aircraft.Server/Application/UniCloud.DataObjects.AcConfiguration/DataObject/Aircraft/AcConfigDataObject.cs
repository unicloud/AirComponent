using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UniCloud.DataObjects
{
    /// <summary>
    /// 配置
    /// </summary>
    [DataContract(IsReference = false)]
    public class AcConfigDataObject : IBaseDto
    {
        public AcConfigDataObject()
        {
            Guid = Guid.NewGuid();
            AcModelGuid = new Guid();
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
        /// 机型名称
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// 机型关键字
        /// </summary>
        [DataMember]
        public int AcModelID { get; set; }

        /// <summary>
        /// 机型Guid
        /// </summary>
        [DataMember]
        public Guid AcModelGuid { get; set; }

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

        /// <summary>
        /// 基本重量
        /// </summary>
        [DataMember]
        public decimal BW { get; set; }

        /// <summary>
        /// 基本重量重心
        /// </summary>
        [DataMember]
        public decimal BWF { get; set; }

        /// <summary>
        /// 基本重量指数
        /// </summary>
        [DataMember]
        public decimal BWI { get; set; }

        /// <summary>
        /// 基本空重
        /// </summary>
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

        /// <summary>
        /// 飞机系列ID
        /// </summary>
        [DataMember]
        public int AcTypeID { get; set; }
    }

    [CollectionDataContract]
    public partial class AcConfigDataObjectList : BaseDataObjectList<AcConfigDataObject>
    {
    }

    /// <summary>
    /// AcConfigResultData
    /// </summary>
    [KnownType(typeof(AcConfigResultData))]
    public class AcConfigResultData : ResultData<AcConfigDataObject>
    {
    }
   /// <summary>
   /// AcConfigWithPagination
   /// </summary>
   [KnownType(typeof(AcConfigWithPagination))]
   public class AcConfigWithPagination : BaseDataObjectListWithPagination<AcConfigDataObject>
   {
   }
}
