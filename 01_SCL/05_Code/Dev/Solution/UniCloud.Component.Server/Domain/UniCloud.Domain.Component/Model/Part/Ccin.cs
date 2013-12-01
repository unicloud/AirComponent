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
	/// 装上信息
	/// </summary>
	public class Ccin:IntEntity
	{
        /// <summary>
        /// 属性
        /// </summary>
        public virtual string Propertys
	    {
            get;
            set;
	    }
        /// <summary>
        /// 推力
        /// </summary>
	    public virtual string EngineTli
	    {
            get;
            set;
	    }

		/// <summary>
		/// 章节
		/// </summary>
		public virtual string Ata
		{
			get;
			set;
		}

		/// <summary>
		/// 区域
		/// </summary>
		public virtual string Zone
		{
			get;
			set;
		}

        /// <summary>
		/// 位置
		/// </summary>
        public virtual string Position
		{
			get;
			set;
		}        
        
		/// <summary>
		/// 顺序号(下级件排序)
		/// </summary>
		public virtual int Seq
		{
			get;
			set;
		}

        /// <summary>
        /// 修理间隔 小时
        /// </summary>
        public virtual int? FhInterval
        {
            get;
            set;
        }

        /// <summary>
        /// 修理间隔 循环
        /// </summary>
        public virtual int? CyInterval
        {
            get;
            set;
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
        /// 序号
        /// </summary>
        public virtual int SnRegID
        {
            get;
            set;
        }
        /// <summary>
        /// 顶级序号
        /// </summary>
        public virtual int? RootSnRegID
        {
            get;
            set;
        }

        /// <summary>
        /// 上级序号
        /// </summary>
        public virtual int? NhSnRegID
        {
            get;
            set;
        }

        /// <summary>
        /// CcOrder外键
        /// </summary>
        public virtual int CcOrderID
        {
            get;
            set;
        }
        public virtual Decimal? Tsn { get; set; }
        public virtual Decimal? Tso { get; set; }
        public virtual Decimal? Tsr { get; set; }
        public virtual Decimal? Csn { get; set; }
        public virtual Decimal? Cso { get; set; }
        public virtual Decimal? Csr { get; set; }        
	}
}
