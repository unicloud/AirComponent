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
    /// 部件历史信息
    /// </summary>
    [DataContract(IsReference = false)]
    public partial class SnHistoryDataObject
    {
   
        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        public virtual int ID { get; set; }

        public SnHistoryDataObject()
        {
            this.SnHistoryUnits = new SnHistoryUnitDataObjectList();
        }

        /// <summary>
        /// SN组件
        /// </summary>
        [DataMember]
        public virtual int SnRegID { get; set; }

        /// <summary>
        /// 飞机组件
        /// </summary>
        [DataMember]
        public virtual string Source { get; set; }

        /// <summary>
        /// 相关指令号
        /// </summary>
        [DataMember]
        public virtual string Orderno { get; set; }

        /// <summary>
        /// 操作
        /// </summary>
        [DataMember]
        public virtual string Active { get; set; }

        /// <summary>
        /// 位置信息
        /// </summary>
        [DataMember]
        public virtual string Position { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DataMember]
        public virtual string Note { get; set; }

        /// <summary>
        /// 发生日期
        /// </summary>
        [DataMember]
        public virtual DateTime ActiveDate { get; set; }


        [DataMember]
        public virtual string Ata { get; set; }


        [DataMember]
        public virtual SnRegDataObject SnReg { get; set; }

        [DataMember]
        public virtual SnHistoryUnitDataObjectList SnHistoryUnits { get; set; }

        [DataMember]
        public int? NhSnRegID { get; set; }

        [DataMember]
        public int? RootSnRegID { get; set; }
    }

    [CollectionDataContract]
    public class SnHistoryDataObjectList : BaseDataObjectList<SnHistoryDataObject>
    {
    }

    /// <summary>
    /// SnHistoryResultData
    /// </summary>
    [DataContractAttribute(Name = "SnHistoryResultData",
        Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof (SnHistoryResultData))]
    public class SnHistoryResultData : ResultData<SnHistoryDataObject>
    {
    }

    /// <summary>
    /// SnHistoryWithPagination
    /// </summary>
    [KnownType(typeof (SnHistoryWithPagination))]
    public class SnHistoryWithPagination : BaseDataObjectListWithPagination<SnHistoryDataObject>
    {
    }
}