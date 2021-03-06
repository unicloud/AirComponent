﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     如果重新生成代码，将丢失对此文件所做的更改。
// </auto-generated>
//------------------------------------------------------------------------------
namespace UniCloud.DataObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;

    /// <summary>
    /// 附件件号
    /// </summary>
    [DataContract(IsReference = false)]
    public partial class CcpPnDataObject
    {

        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        public virtual int ID { get; set; }

        /// <summary>
        /// 厂家件号
        /// </summary>
        [DataMember]
        public virtual string Pn { get; set; }

        /// <summary>
        /// 规范件号
        /// </summary>
        [DataMember]
        public virtual string SpecPn { get; set; }

        /// <summary>
        /// 适用飞机机型
        /// </summary>
        [DataMember]
        public virtual string Acmodel { get; set; }
        /// <summary>
        /// 适用飞机配置
        /// </summary>
        [DataMember]
        public virtual string Acconfig { get; set; }
        /// <summary>
        /// 适用飞机
        /// </summary>
        [DataMember]
        public virtual string AcRegs { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DataMember]
        public virtual string Notes { get; set; }

        /// <summary>
        /// 预期装机数量
        /// </summary>
        [DataMember]
        public virtual int? Qty { get; set; }

        /// <summary>
        /// 时限组
        /// </summary>
        [DataMember]
        public virtual string Ieam { get; set; }

        [DataMember]
        public virtual string Sns { get; set; }

        [DataMember]
        public virtual int? PnRegID { get; set; }

        [DataMember]
        public virtual int CcpMainID { get; set; }

    }

    [CollectionDataContract]
    public class CcpPnDataObjectList : BaseDataObjectList<CcpPnDataObject>
    {
    }

    /// <summary>
    /// CcpPnResultData
    /// </summary>
    [DataContractAttribute(Name = "CcpPnResultData",
        Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof (CcpPnResultData))]
    public class CcpPnResultData : ResultData<CcpPnDataObject>
    {
    }

    /// <summary>
    /// CcpPnWithPagination
    /// </summary>
    [KnownType(typeof (CcpPnWithPagination))]
    public class CcpPnWithPagination : BaseDataObjectListWithPagination<CcpPnDataObject>
    {
    }
}

