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
	/// 预期时间监控
	/// </summary>
	public class PartsMonitorDetail:IntEntity
	{
        /// <summary>
        /// 件号主键
        /// </summary>
        public virtual int PnRegID
        {
            get;
            set;
        }

        /// <summary>
        /// 部件ID
        /// </summary>
        public int SnRegID
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
		/// 控制单位ID
		/// </summary>
		public virtual string Unit
		{
			get;
			set;
		}

        /// <summary>
        /// 时限组
        /// </summary>
        public virtual string Ieam
        {
            get;
            set;
        }
        /// <summary>
        /// 到限工作
        /// </summary>
        public virtual string Workscope
        {
            get;
            set;
        }
        /// <summary>
        /// 时限
        /// </summary>
        public virtual int Interval
        {
            get;
            set;
        }
		/// <summary>
		/// 使用时间
		/// </summary>
		public virtual decimal? Used
		{
			get;
			set;
		}
        /// <summary>
        /// 剩余时间
        /// </summary>
        public virtual decimal? Remain
        {
            get;
            set;
        }

        /// <summary>
        /// 参考利用率
        /// </summary>
        public virtual decimal? Utiliza
        {
            get;
            set;
        }

		public virtual DateTime ExpireDate
		{
			get;
			set;
		}

        public int PartsMonitorID
        {
            get;
            set;
        }

    }
}

