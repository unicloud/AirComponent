#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/27 15:14:30

// 文件名：SnRegDataObject
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace UniCloud.DataObjects
{

    public partial class SnRegDataObject : BaseDataObject
    {
        //最近一次历史记录
        [DataMember]
        public virtual SnHistoryDataObject snHistory { set; get; }
        
        //常用的两个单位的最近使用时间信息
        [DataMember]
        public virtual SnHistoryUnitDataObject SnTsn { set; get; }
        [DataMember]
        public virtual SnHistoryUnitDataObject SnCsn { set; get; }

        [DataMember]
        public virtual string Pn
        {
            set;
            get;
        }
        [DataMember]
        public string NhPnSn { set; get; }
        [DataMember]
        public string RootPnSn { set; get; }
        /// <summary>
        /// 附件项号
        /// </summary>
        [DataMember]
        public virtual string ItemNo { get; set; }

        [DataMemberAttribute()]
        public virtual string PnSn { get; set; }

        private AttactDocumentDataObjectList AttactDocumentsField;

        [DataMemberAttribute()]
        public AttactDocumentDataObjectList AttactDocuments
        {
            get
            {
                return this.AttactDocumentsField;
            }
            set
            {
                if (this.AttactDocumentsField != value)
                {
                    this.AttactDocumentsField = value;
                }
            }
        }



        [DataMemberAttribute()]
        public decimal? Egtm { get; set; }

        [DataMemberAttribute()]
        public string Operator { get; set; }

        [DataMemberAttribute()]
        public DateTime? OperateDate { get; set; }

        [DataMemberAttribute()]
        public int? EgtMarginID { get; set; }

        #region 虚拟属性 监控到期算法特用
        //[DataMemberAttribute()]
        //public virtual String PnClass
        //{
        //    get;
        //    set;
        //}
        //[DataMemberAttribute()]
        //public virtual int? TrainRate
        //{
        //    get;
        //    set;
        //}
        //[DataMemberAttribute()]
        //public virtual String RootPnClass
        //{
        //    get;
        //    set;
        //}

        //[DataMemberAttribute()]
        //public virtual SnHistoryDataObject ccHistory
        //{
        //    get;
        //    set;
        //}

        #endregion
    }
}
