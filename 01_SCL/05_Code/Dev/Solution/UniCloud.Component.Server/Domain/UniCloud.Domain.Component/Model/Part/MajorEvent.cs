#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/10/16 16:09:50
* 文件名：MajorEvent
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
    public class MajorEvent:IntAggregateRoot
    {
        /// <summary>
        /// 机号
        /// </summary>
        public virtual string Ac { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        public virtual string Pos { get; set; }

        /// <summary>
        /// SN
        /// </summary>
        public virtual string Sn { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        ///性质
        /// </summary>
        public virtual string Property { get; set; }

        /// <summary>
        /// 关闭原因
        /// </summary>
        public virtual string CloseReason { get; set; }

        /// <summary>
        /// 关闭日期
        /// </summary>
        public virtual DateTime? CloseDate { get; set; }

        /// <summary>
        /// 发生日期
        /// </summary>
        public virtual DateTime CreateDate { get; set; }
        
    }
}
