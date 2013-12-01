using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UniCloud.DataObjects
{
    /// <summary>
    /// 附件序号
    /// </summary>
    [DataContract(IsReference = false)]
    public class SnRegDto
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        public virtual int ID
        {
            get;
            set;
        }

        /// <summary>
        /// 序号
        /// </summary>
        [DataMember]
        public virtual string Sn
        {
            get;
            set;
        }

        /// <summary>
        /// 飞机
        /// </summary>
        [DataMember]
        public virtual string AcReg
        {
            get;
            set;
        }

        /// <summary>
        /// ATA
        /// </summary>
        [DataMember]
        public virtual string Ata
        {
            get;
            set;
        }

        /// <summary>
        /// 安装位置描述
        /// </summary>
        [DataMember]
        public virtual string Position
        {
            get;
            set;
        }

        /// <summary>
        /// 安装日期
        /// </summary>
        [DataMember]
        public virtual DateTime InstallDate
        {
            get;
            set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public virtual string Note
        {
            get;
            set;
        }

        /// <summary>
        /// 状态
        /// </summary>
        [DataMember]
        public virtual string Avail
        {
            get;
            set;
        }

        /// <summary>
        /// 是否寿控
        /// </summary>
        [DataMember]
        public virtual bool IsLife
        {
            get;
            set;
        }

        /// <summary>
        /// 上级序号
        /// </summary>
        [DataMember]
        public virtual string NhSnReg
        {
            get;
            set;
        }

        /// <summary>
        /// 顶级序号
        /// </summary>
        [DataMember]
        public virtual string RootSnReg
        {
            get;
            set;
        }

        [DataMember]
        public virtual string Zone
        {
            get;
            set;
        }

        [DataMember]
        public virtual string PnReg
        {
            get;
            set;
        }

        [DataMember]
        public virtual string ItemNo
        {
            get;
            set;
        }
    }

    [CollectionDataContract]
    public class SnRegDtoList : List<SnRegDto>
    {
    }
}
