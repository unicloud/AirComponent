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

    [DataContract(IsReference = false)]
    public partial class WfHistoryDataObject
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        public virtual int ID { get; set; }

        /// <summary>
        /// 序列号
        /// </summary>
        [DataMember]
        public virtual string Seq { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        [DataMember]
        public virtual string Auditor { get; set; }

        /// <summary>
        /// 审核时间
        /// </summary>
        [DataMember]
        public virtual DateTime? AuditTime { get; set; }

        [DataMember]
        public virtual string AuditNotes { get; set; }

        [DataMember]
        public virtual string Result { get; set; }

        /// <summary>
        /// 业务代码
        /// </summary>
        [DataMember]
        public virtual string Business { get; set; }

        [DataMember]
        public virtual int BusinessID { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [DataMember]
        public virtual string Department { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DataMember]
        public virtual string Description { get; set; }

        /// <summary>
        /// 是否提交
        /// </summary>
        [DataMember]
        public virtual bool IsSubmit
        {
            get;
            set;
        }
    }

    [CollectionDataContract]
    public class WfHistoryDataObjectList : BaseDataObjectList<WfHistoryDataObject>
    {
    }

    /// <summary>
    /// WfHistoryResultData
    /// </summary>
    [DataContractAttribute(Name = "WfHistoryResultData",
        Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof (WfHistoryResultData))]
    public class WfHistoryResultData : ResultData<WfHistoryDataObject>
    {
    }

    /// <summary>
    /// WfHistoryWithPagination
    /// </summary>
    [KnownType(typeof (WfHistoryWithPagination))]
    public class WfHistoryWithPagination : BaseDataObjectListWithPagination<WfHistoryDataObject>
    {
    }
}
