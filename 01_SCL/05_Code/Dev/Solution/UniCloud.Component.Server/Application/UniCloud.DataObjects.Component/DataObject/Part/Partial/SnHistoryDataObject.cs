#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/27 15:14:30

// 文件名：SnHistoryDataObject
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

    public partial class SnHistoryDataObject : BaseDataObject
    {
        //常用的两条历史时间信息
        [DataMember]
        public virtual SnHistoryUnitDataObject SnHistoryFh 
        {
            set; 
            get; 
        }
        [DataMember]
        public virtual SnHistoryUnitDataObject SnHistoryCy
        {
            set;
            get;

        }

        [DataMember]
        public virtual string Sn
        {
            set;
            get;
        }


        [DataMember]
        public virtual string Pn
        {
            set;
            get;
        }

        [DataMember]
        public virtual string PnSn
        {
            set;
            get;
        }

        [DataMember]
        public virtual string NhPnSn
        {
            set;
            get;
        }

        [DataMember]
        public virtual string RootPnSn
        {
            set;
            get;
        }
    }
}
