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
    /// 工作代码
    /// </summary>
    [DataContract(IsReference = false)]
    public partial class WorkScopeDataObject
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        public virtual int ID { get; set; }

        [DataMember]
        public virtual string Scope { get; set; }

        [DataMember]
        public virtual string Description { get; set; }

        [DataMember]
        public virtual string ShortName { get; set; }

        [DataMember]
        public virtual string Type { get; set; }
    }

    [CollectionDataContract]
    public class WorkScopeDataObjectList : BaseDataObjectList<WorkScopeDataObject>
    {
    }

    /// <summary>
    /// WorkScopeResultData
    /// </summary>
    [DataContractAttribute(Name = "WorkScopeResultData",
        Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof (WorkScopeResultData))]
    public class WorkScopeResultData : ResultData<WorkScopeDataObject>
    {
    }

    /// <summary>
    /// WorkScopeWithPagination
    /// </summary>
    [KnownType(typeof (WorkScopeWithPagination))]
    public class WorkScopeWithPagination : BaseDataObjectListWithPagination<WorkScopeDataObject>
    {
    }
}
