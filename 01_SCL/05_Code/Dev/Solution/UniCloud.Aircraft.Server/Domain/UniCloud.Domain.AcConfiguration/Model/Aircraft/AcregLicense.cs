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
    /// 飞机证照
    /// </summary>
    public class AcregLicense : IntEntity
    {
        public AcregLicense()
        {
            this.Guid = new Guid();
            this.DocumentGuid=new Guid();
            this.LicenseTypeGuid = new Guid();
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
        /// 证照类型
        /// </summary>
        public virtual int LicenseTypeID
        {
            get;
            set;
        }

        /// <summary>
        /// LicenseTypeGuid
        /// </summary>
        public virtual Guid LicenseTypeGuid
        {
            get;
            set;
        }

        public virtual int AcRegID
        {
            get;
            set;
        }

        public virtual Guid AcRegGuid
        {
            get;
            set;
        }

        public virtual Guid? DocumentGuid
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
        /// 发证单位
        /// </summary>
        public virtual string IssuedFrom
        {
            get;
            set;
        }

        /// <summary>
        /// 发证日期
        /// </summary>
        public virtual DateTime IssuedDate
        {
            get;
            set;
        }

        /// <summary>
        /// 有效期（月）
        /// </summary>
        public virtual int ValidMonths
        {
            get;
            set;
        }

        public virtual DateTime ExpireDate
        {
            get;
            set;
        }

        /// <summary>
        /// 状态
        /// </summary>
        public virtual string State
        {
            get;
            set;
        }

        /// <summary>
        /// 电子拷贝件
        /// </summary>
        public virtual string CopyFile
        {
            get;
            set;
        }

        //public virtual AcReg Acreg
        //{
        //    get;
        //    set;
        //}

        public virtual LicenseType LicenseType
        {
            get;
            set;
        }

    }
}
