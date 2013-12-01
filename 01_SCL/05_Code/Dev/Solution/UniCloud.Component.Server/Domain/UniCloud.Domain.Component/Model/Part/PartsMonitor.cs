﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成
//     如果重新生成代码，将丢失对此文件所做的更改。
// </auto-generated>
//------------------------------------------------------------------------------
namespace UniCloud.Domain.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 附件预测到期日期
    /// </summary>
    public class PartsMonitor : IntAggregateRoot
    {
        public PartsMonitor()
        {
            this.PartsMonitorDetails = new HashSet<PartsMonitorDetail>();
        }
        /// <summary>
        /// 件号主键
        /// </summary>
        public virtual int PnRegID
        {
            get;
            set;
        }

        /// <summary>
        /// 序号主键
        /// </summary>
        public virtual int SnRegID
        {
            get;
            set;
        }

        /// <summary>
        /// 附件项号
        /// </summary>
        public virtual string ItemNo
        {
            get;
            set;
        }
        /// <summary>
        /// 上级附件项号
        /// </summary>
        public virtual string NhItemNo
        {
            get;
            set;
        }

        /// <summary>
        /// 执行策略 MaxLength(2)
        /// </summary>
        public virtual string PolicyExec
        {
            get;
            set;
        }

        /// <summary>
        /// 已经使用时间 MaxLength(20)
        /// </summary>
        public virtual string UsedTime
        {
            get;
            set;
        }

        /// <summary>
        /// 剩余时间 MaxLength(20)
        /// </summary>
        public virtual string RemainTime
        {
            get;
            set;
        }
        /// <summary>
        /// 到期日期
        /// </summary>
        public virtual DateTime ExpireDate
        {
            get;
            set;
        }

        /// <summary>
        /// 工作代码 MaxLength(2)
        /// </summary>
        public virtual string Workscope
        {
            get;
            set;
        }

        /// <summary>
        /// 工作代码 MaxLength(2)
        /// </summary>
        public virtual SnReg Snreg
        {
            get;
            set;
        }

        public virtual ICollection<PartsMonitorDetail> PartsMonitorDetails
        {
            get;
            set;
        }

    }
}
