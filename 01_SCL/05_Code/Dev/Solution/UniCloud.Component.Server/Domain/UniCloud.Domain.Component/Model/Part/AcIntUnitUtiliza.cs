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
	/// 飞机控制单位利用率
	/// </summary>
	public class AcIntUnitUtiliza:IntAggregateRoot
	{
        /// <summary>
        /// 飞机
        /// </summary>
        public virtual string AcReg
        {
            get;
            set;
        }

        /// <summary>
        /// 厂家注册号
        /// </summary>
        public virtual string Msn
        {
            get;
            set;
        }

        /// <summary>
        /// 设置单位
        /// </summary>
		public virtual string Unit
		{
			get;
			set;
		}

        /// <summary>
        /// 利用率
        /// </summary>
		public virtual decimal Utiliza
		{
			get;
			set;
		}

        /// <summary>
        /// 预期增长量 大于0
        /// </summary>
        public virtual decimal UtilizaRate
        {
            get;
            set;
        }

	}
}

