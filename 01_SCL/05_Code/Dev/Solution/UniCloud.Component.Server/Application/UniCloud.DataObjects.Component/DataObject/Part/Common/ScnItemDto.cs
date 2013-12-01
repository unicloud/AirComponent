using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UniCloud.DataObjects
{
    /// <summary>
    /// SCN明细
    /// </summary>
    [DataContract(IsReference = false)]
    public class ScnItemDto
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
        /// 附件项
        /// </summary>
        [DataMember]
        public virtual string ScnNo
        {
            get;
            set;
        }

        /// <summary>
        /// 项次
        /// </summary>
        [DataMember]
        public virtual int ItemNo
        {
            get;
            set;
        }

        /// <summary>
        /// 部件类型
        /// </summary>
        [DataMember]
        public virtual string PnClass
        {
            get;
            set;
        }

        /// <summary>
        /// ATA章节
        /// </summary>
        [DataMember]
        public virtual string Ata
        {
            get;
            set;
        }

        /// <summary>
        /// 件号
        /// </summary>
        [DataMember]
        public virtual string Pn
        {
            get;
            set;
        }

        /// <summary>
        /// 产品描述
        /// </summary>
        [DataMember]
        public virtual string Description
        {
            get;
            set;
        }

        /// <summary>
        /// 供应商
        /// </summary>
        [DataMember]
        public virtual string Vendor
        {
            get;
            set;
        }

        [DataMember]
        public virtual string Notes
        {
            get;
            set;
        }

        /// <summary>
        /// 数量
        /// </summary>
        [DataMember]
        public virtual int Qty
        {
            get;
            set;
        }

        /// <summary>
        /// 单价
        /// </summary>
        [DataMember]
        public virtual double Price
        {
            get;
            set;
        }

        /// <summary>
        /// 总价
        /// </summary>
        [DataMember]
        public virtual double TotalPrice
        {
            get;
            set;
        }

        /// <summary>
        /// 币种
        /// </summary>
        [DataMember]
        public virtual string Currency
        {
            get;
            set;
        }
    }

    public class ScnItemDtoList:List<ScnItemDto>
    {
    }
}
