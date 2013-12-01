#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/9/21 14:10:20
* 文件名：IComponent
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

namespace UniCloud.Query
{
    public interface IComponentQuery : ICcOrderQuery, ICcpMainQuery, IIntUnitQuery, IOilHistoryQuery,
        IPartsMonitorQuery, IPnRegQuery, IScnMainQuery, ISnHistoryQuery, ISnRegQuery, IWfHistoryQuery, IWorkScopeQuery
    {
    }
}
