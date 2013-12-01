#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/9/26 12:54:29
* 文件名：CcOrderEvent
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
using UniCloud.Domain.Events;
using UniCloud.Domain;
using UniCloud.Domain.Model;

namespace UniCloud.Domain.Events
{
    public class CcOrderEvent : DomainEvent
    {
        #region Ctor
        /// <summary>
        /// 初始化一个新的<c>CcOrderEvent</c>类型的实例。
        /// </summary>
        /// <param name="source">产生领域事件的事件源对象。</param>
        public CcOrderEvent(IEntity source) : base(source) { }
        #endregion

        #region Public Properties
        /// <summary>
        /// 操作日期。
        /// </summary>
        public DateTime OperateDate { get; set; }

        /// <summary>
        /// 飞机号
        /// </summary>
        public string Acreg { get; set; }

        /// <summary>
        /// 交换飞机
        /// </summary>
        public string SwapAcreg { get; set; }

        /// <summary>
        /// Sn历史
        /// </summary>
        public List<SnHistory> SnHistorys { get; set; }
        #endregion
    }
}
