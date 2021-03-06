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

    /// <summary>
	/// ADSB文件信息
	/// </summary>
    public class Adsb : IntAggregateRoot
	{
		/// <summary>
		/// 系列
		/// </summary>
		public virtual string Actype
		{
			get;
			set;
		}

		/// <summary>
		/// 文件类型
		/// </summary>
		public virtual string FileType
		{
			get;
			set;
		}

		/// <summary>
		/// 文件号
		/// </summary>
		public virtual string FileNo
		{
			get;
			set;
		}

		/// <summary>
		/// 文件版本
		/// </summary>
		public virtual string FileVersion
		{
			get;
			set;
		}

		/// <summary>
		/// 文件标题
		/// </summary>
		public virtual string FileTitle
		{
			get;
			set;
		}

		/// <summary>
		/// 来源文件
		/// </summary>
		public virtual string FromFile
		{
			get;
			set;
		}

		/// <summary>
		/// 文件内容描述
		/// </summary>
		public virtual string Content
		{
			get;
			set;
		}

		/// <summary>
		/// 收文日期
		/// </summary>
		public virtual DateTime? ReceiveDate
		{
			get;
			set;
		}

        //public virtual ICollection<AdsbComply> AdsbComplys
        //{
        //    get;
        //    set;
        //}

	}
}

