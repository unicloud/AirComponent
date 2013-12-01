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
    /// 章节
    /// </summary>
    public class Ata : IntAggregateRoot
    {
        public Ata()
        {
            this.Guid = new Guid();
            this.ChildAtas = new HashSet<Ata>();
            //this.Actypes = new HashSet<AcType>();
            //this.AcTypeGuid = new Guid();
        }
        /// <summary>
        /// Guid
        /// </summary>
        public virtual Guid Guid
        {
            get;
            set;
        }

        ///// <summary>
        ///// 系列主键
        ///// </summary>
        //public virtual int AcTypeID
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// AcTypeGuid
        ///// </summary>
        //public virtual Guid AcTypeGuid
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// 章节
        /// </summary>
        public virtual string ATA
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

        public virtual int? ParentID 
        { 
            get;
            set;
        }

        //public virtual ICollection<AcType> Actypes
        //{
        //    get;
        //    set;
        //}

        public virtual  ICollection<Ata> ChildAtas
        {
            get;
            set;
        }

        public virtual Ata ParentAta
        {
            get;
            set;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Ata))
                return false;
            var ata = obj as Ata;
            if (ata == null)
                return false;
            if (ata.ParentAta == null && this.ParentAta == null)
            {
                if (ata.ATA.Equals(ATA))
                    return true;
            }
            else if (ata.ParentAta != null && this.ParentAta != null)
            {
                if (ata.ATA.Equals(ATA) && ata.ParentAta.Equals(this.ParentAta))
                    return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            if (this.ParentAta != null)
                return ATA.GetHashCode() ^ this.ParentAta.GetHashCode();
            else
                return ATA.GetHashCode();
        }

    }
}

