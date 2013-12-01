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
    using UniCloud.Domain;

    /// <summary>
    /// 系列/客户机型
    /// </summary>
    public class AcType : IntAggregateRoot
    {
        public AcType()
        {
            //this.AcRegs = new HashSet<AcReg>();
            this.Acmodels = new HashSet<AcModel>();
            this.Atas = new HashSet<Ata>();
            this.Guid = new Guid();
        }

        /// <summary>
        /// Guid
        /// </summary>
        public virtual Guid Guid
        {
            get;
            set;
        }

        /// <summary>
        /// 系列
        /// </summary>
        public virtual string Name
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

        /// <summary>
        /// 厂商
        /// </summary>
        public virtual string Manufacturer
        {
            get;
            set;
        }

        /// <summary>
        /// 座级等级编号
        /// </summary>
        public virtual string AcCategory
        {
            get;
            set;
        }

        ///// <summary>
        ///// AcCategoryGuid
        ///// </summary>
        //public virtual Guid AcCategoryGuid
        //{
        //    get;
        //    set;
        //}

        public virtual ICollection<Ata> Atas
        {
            get;
            set;
        }

        public virtual ICollection<AcModel> Acmodels
        {
            get;
            set;
        }

        //public virtual AcCategory AcCategory
        //{
        //    get;
        //    set;
        //}

        //public virtual ICollection<AcReg> AcRegs
        //{
        //    get;
        //    set;
        //}
        public override bool Equals(object obj)
        {
            if (!(obj is AcType))
                return false;
            var actype = obj as AcType;
            if (actype == null)
                return false;
            if (actype.Name.Equals(Name))
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

    }
}
