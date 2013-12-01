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
    /// SCN
    /// </summary>
    [DataContract(IsReference = false)]
    public partial class ScnMainDataObject
    {
        public ScnMainDataObject()
        {
            this.ScnItems = new ScnItemDataObjectList();
            this.ScnAcorders = new ScnAcorderDataObjectList();
            this.WfHistorys = new WfHistoryDataObjectList();
        }

        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        public virtual int ID { get; set; }

        [DataMember]
        public virtual string ScnNo { get; set; }

        [DataMember]
        public virtual int AcTypeID { get; set; }

        [DataMember]
        public virtual Guid AcTypeGuid { get; set; }

        [DataMember]
        public virtual int AcModelID { get; set; }

        [DataMember]
        public virtual Guid AcModelGuid { get; set; }

        [DataMember]
        public virtual string Version { get; set; }

        [DataMember]
        public virtual string State { get; set; }

        [DataMember]
        public virtual string Description { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [DataMember]
        public virtual string ScnType { get; set; }

        /// <summary>
        /// 关闭情况
        /// </summary>
        [DataMember]
        public virtual int CloseSituation { get; set; }

        /// <summary>
        /// 关闭时间
        /// </summary>
        [DataMember]
        public virtual DateTime? ColseTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        [DataMember]
        public virtual string CreateUser { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        public virtual DateTime CreateTime { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [DataMember]
        public virtual string ScnTitle { get; set; }

        /// <summary>
        /// Mod号
        /// </summary>
        [DataMember]
        public virtual string ModName { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        [DataMember]
        public virtual decimal Amount {get;set;}

        /// <summary>
        /// 附件关联ID
        /// </summary>
        [DataMember]
        public virtual Guid? DocumentID {get;set;}

        /// <summary>
        /// 关联MSN的飞机
        /// </summary>
        [DataMember]
        public virtual string MoneyOnMsn
        {
            get;
            set;
        }

        /// <summary>
        /// ATA
        /// </summary>
        [DataMember]
        public virtual string Ata { get; set; }

        /// <summary>
        /// 关联部门
        /// </summary>
        [DataMember]
        public virtual string Organization
        {
            get;
            set;
        }

        /// <summary>
        /// 审核状态
        /// </summary>
        [DataMember]
        public virtual string VerifyStatus
        {
            get;
            set;
        }

        [DataMember]
        public virtual ScnItemDataObjectList ScnItems { get; set; }

        [DataMember]
        public virtual ScnAcorderDataObjectList ScnAcorders { get; set; }

        [DataMember]
        public virtual DocumentDataObject Document { get; set; }

    }

    [CollectionDataContract]
    public class ScnMainDataObjectList : BaseDataObjectList<ScnMainDataObject>
    {
    }

    /// <summary>
    /// ScnMainResultData
    /// </summary>
    [DataContractAttribute(Name = "ScnMainResultData",
        Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof (ScnMainResultData))]
    public class ScnMainResultData : ResultData<ScnMainDataObject>
    {
    }

    /// <summary>
    /// ScnMainWithPagination
    /// </summary>
    [KnownType(typeof (ScnMainWithPagination))]
    public class ScnMainWithPagination : BaseDataObjectListWithPagination<ScnMainDataObject>
    {
    }
}