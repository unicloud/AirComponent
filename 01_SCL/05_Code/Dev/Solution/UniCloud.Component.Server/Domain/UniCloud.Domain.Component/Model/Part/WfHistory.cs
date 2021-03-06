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

	public class WfHistory:IntAggregateRoot
	{
		/// <summary>
		/// 序列号
		/// </summary>
		public virtual string Seq
		{
			get;
			set;
		}

		/// <summary>
		/// 审核人
		/// </summary>
		public virtual string Auditor
		{
			get;
			set;
		}

		/// <summary>
		/// 审核时间
		/// </summary>
		public virtual DateTime? AuditTime
		{
			get;
			set;
		}

		public virtual string AuditNotes
		{
			get;
			set;
		}

		public virtual string Result
		{
			get;
			set;
		}

		/// <summary>
		/// 业务代码
		/// </summary>
		public virtual string Business
		{
			get;
			set;
		}

		public virtual int BusinessID
		{
			get;
			set;
		}

        /// <summary>
        /// 部门
        /// </summary>
        public virtual string Department
        {
            get;
            set;
        }

        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description
        {
            get;
            set;
        }

        ///// <summary>
        ///// 是否提交
        ///// </summary>
        //public virtual bool IsSubmit
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// ScnMain外键
        ///// </summary>
        //public virtual int ScnMainID
        //{
        //    get;
        //    set;
        //}

        #region 重写Equals与GetHashCode方法
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            if (obj == (object)null)
                return false;
            if (obj is WfHistory)
            {
                var wfhistory = obj as WfHistory;
                return
                this.Department == wfhistory.Department&&this.AuditTime==wfhistory.AuditTime;
            }
            else
                return false;
        }

        public override int GetHashCode()
        {
            return this.Department.GetHashCode()^this.AuditTime.GetHashCode();
        }
        #endregion
       
	}
}

