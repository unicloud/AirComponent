#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/10/6 21:56:38
* 文件名：IPartService
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
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Infrastructure;
using UniCloud.Query;

namespace UniCloud.ServiceContracts
{
    [ServiceContract(Namespace = "http://www.UniCloud.com")]
    public interface IPartService : IApplicationServiceContract, 
        ICcOrderService, ICcOrderQuery, ICcpMainService, ICcpMainQuery,
        IIntUnitService, IIntUnitQuery, IOilHistoryService, IOilHistoryQuery, 
        IOilAnalysisQuery, IOilAnalysisService, IPartsMonitorService, IPartsMonitorQuery,
        IPnRegService, IPnRegQuery, IScnMainService, IScnMainQuery, 
        ISnHistoryService, ISnHistoryQuery,  ISnRegService, ISnRegQuery, 
        IWfHistoryService, IWfHistoryQuery, IWorkScopeService, IWorkScopeQuery,
        IEgtMarginService, IEgtMarginQuery, IMajorEventService, IMajorEventQuery,
        IAttactDocumentService, IAttactDocumentQuery, IAcIntUnitUtilizaService, IAcIntUnitUtilizaQuery,
        IAirBusMSCNService, IAirBusMSCNQuery,IAdsbComplyService,IAdsbComplyQuery,
        IAdsbQuery,IAdsbService,IAcStructureQuery,IAcStructureService
    {
    }
}
