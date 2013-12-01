#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/21 9:41:58

// 文件名：CcOrderDataObject.Partial
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace UniCloud.DataObjects
{
    /// <summary>
    ///CcOrderDataObject
    /// </summary>
    public partial class CcOrderDataObject
    {
        [DataMember]
        public virtual CcoutDataObject Ccout { get; set; }

        [DataMember]
        public virtual CcinDataObject Ccin { get; set; }


        [DataMember]
        public virtual string Pn { get; set; }

        [DataMember]
        public virtual string Sn { get; set; }

        /// <summary>
        /// 顶级序号
        /// </summary>
        [DataMember]
        public virtual int? RootSnRegID { get; set; }
    }
}
