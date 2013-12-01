using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UniCloud.DataObjects
{
    /// <summary>
    /// 飞机
    /// </summary>
    [DataContract(IsReference = false)]
    public class AcRegDataObject : IBaseDto
    {
        public AcRegDataObject()
        {
            Guid = Guid.NewGuid();
            AcregLicenses = new AcregLicenseDataObjectList();
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
        /// 所有权方
        /// </summary>
        [DataMember]
        public string Owner
        {
            get;
            set;
        }

        /// <summary>
        /// 机型外键
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
        /// 运营方
        /// </summary>
        [DataMember]
        public string Operators
        {
            get;
            set;
        }

        /// <summary>
        /// 引进方式
        /// </summary>
        [DataMember]
        public string ImportCategory
        {
            get;
            set;
        }

        /// <summary>
        /// 退出方式
        /// </summary>
        [DataMember]
        public string ExportCategory
        {
            get;
            set;
        }

        /// <summary>
        /// 注册号
        /// </summary>
        [DataMember]
        public string RegNumber
        {
            get;
            set;
        }

        /// <summary>
        /// 出厂序列号
        /// </summary>
        [DataMember]
        public string Msn
        {
            get;
            set;
        }

        /// <summary>
        /// 运营状态
        /// </summary>
        [DataMember]
        public bool IsOperation
        {
            get;
            set;
        }

        /// <summary>
        /// 创建日期
        /// </summary>
        [DataMember]
        public DateTime CreateDate
        {
            get;
            set;
        }

        /// <summary>
        /// 出厂日期
        /// </summary>
        [DataMember]
        public DateTime FactoryDate
        {
            get;
            set;
        }

        /// <summary>
        /// 引进日期
        /// </summary>
        [DataMember]
        public DateTime ImportDate
        {
            get;
            set;
        }

        /// <summary>
        /// 注销日期
        /// </summary>
        [DataMember]
        public DateTime? ExportDate
        {
            get;
            set;
        }

        /// <summary>
        /// 座位数
        /// </summary>
        [DataMember]
        public int SeatingCapacity
        {
            get;
            set;
        }

        /// <summary>
        /// 商载量
        /// </summary>
        [DataMember]
        public decimal CarryingCapacity
        {
            get;
            set;
        }

        [DataMember]
        public int AcModelID
        {
            get;
            set;
        }

        /// <summary>
        /// AcModelGuid
        /// </summary>
        [DataMember]
        public Guid AcModelGuid
        {
            get;
            set;
        }

        [DataMember]
        public int AcConfigID
        {
            get;
            set;
        }

        /// <summary>
        /// AcConfigGuid
        /// </summary>
        [DataMember]
        public Guid AcConfigGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 译码配置
        /// </summary>
        [DataMember]
        public int? DecodeConfigID
        {
            get;
            set;
        }

        /// <summary>
        /// DecodeConfigGuid
        /// </summary>
        [DataMember]
        public Guid DecodeConfigGuid
        {
            get;
            set;
        }

        /// <summary>
        /// 发动机推力
        /// </summary>
        [DataMember]
        public string EngineTr
        {
            get;
            set;
        }

        /// <summary>
        /// 标准时差
        /// </summary>
        [DataMember]
        public int OffsetUTC
        {
            get;
            set;
        }

        /// <summary>
        /// QAR帧长
        /// </summary>
        [DataMember]
        public int SubframeLenght
        {
            get;
            set;
        }

        [DataMember]
        public AcregLicenseDataObjectList AcregLicenses
        {
            get;
            set;
        }

        [DataMember]
        public string Manufacturer
        {
            get;
            set;
        }
    }

    [CollectionDataContract]
    public partial class AcRegDataObjectList : BaseDataObjectList<AcRegDataObject>
    {
    }

    /// <summary>
    /// AcRegResultData
    /// </summary>
    [KnownType(typeof(AcRegResultData))]
    public class AcRegResultData : ResultData<AcRegDataObject>
    {
    }
   /// <summary>
   /// AcRegWithPagination
   /// </summary>
   [KnownType(typeof(AcRegWithPagination))]
   public class AcRegWithPagination : BaseDataObjectListWithPagination<AcRegDataObject>
   {
   }
}
