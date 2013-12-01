#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/10/16 10:37:28
* 文件名：EgtMargin
* 版本：V1.0.0
*
* 修改者： 时间： 
* 修改说明：
* ========================================================================
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniCloud.Domain.Model
{
    public class EgtMargin : IntAggregateRoot
    {
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
        /// 裕度
        /// </summary>
        public virtual decimal? Egtm
        {
            get;
            set;
        }

        /// <summary>
        /// 操作人
        /// </summary>
        public virtual string Operator
        {
            get;
            set;
        }

        /// <summary>
        /// 操作时间
        /// </summary>
        public virtual DateTime? OperateDate
        {
            get;
            set;
        }
    }
}
