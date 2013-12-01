#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/21 9:41:58

// 文件名：ScnMainDataObject.Partial
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
    ///ScnMainDataObject
    /// </summary>
    public partial class ScnMainDataObject
    {
        private WfHistoryDataObjectList WfHistorysField;

        [DataMemberAttribute()]
        public WfHistoryDataObjectList WfHistorys
        {
            get
            {
                return this.WfHistorysField;
            }
            set
            {
                if (this.WfHistorysField != value)
                {
                    this.WfHistorysField = value;
                }
            }
        }

    }
}