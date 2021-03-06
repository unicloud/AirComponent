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
	/// 附件件号
	/// </summary>
	public class CcpPn :IntEntity
	{
		/// <summary>
		/// 厂家件号
		/// </summary>
		public virtual string Pn
		{
			get;
			set;
		}

		/// <summary>
		/// 规范件号
		/// </summary>
		public virtual string SpecPn
		{
			get;
			set;
		}

		/// <summary>
		/// 适用飞机机型
		/// </summary>
		public virtual string Acmodel
		{
			get;
			set;
		}
        /// <summary>
        /// 适用飞机配置
        /// </summary>
        public virtual string Acconfig
        {
            get;
            set;
        }

		/// <summary>
		/// 适用飞机
		/// </summary>
		public virtual string AcRegs
		{
			get;
			set;
		}

		/// <summary>
		/// 备注
		/// </summary>
		public virtual string Notes
		{
			get;
			set;
		}

		/// <summary>
		/// 预期装机数量
		/// </summary>
		public virtual int? Qty
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

		public virtual string Sns
		{
			get;
			set;
		}

        public virtual int? PnRegID 
        { 
            get;
            set;
        }

	    public virtual int CcpMainID
	    {
	        get;
            set;
	    }

	}
}

