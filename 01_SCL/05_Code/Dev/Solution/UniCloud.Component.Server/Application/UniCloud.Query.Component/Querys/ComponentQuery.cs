#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/9/21 14:17:49
* 文件名：ComponentQuery
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
using UniCloud.DataObjects;
using UniCloud.Domain.Repositories.EntityFramework;

namespace UniCloud.Query
{
    public class ComponentQuery : IComponentQuery
    {
        private ICcOrderQuery _ccorderQuery;
        private ICcpMainQuery _ccpMainQuery;
        private IIntUnitQuery _intUnitQuery;
        private IOilHistoryQuery _oilHistoryQuery;
        private IPartsMonitorQuery _partsMonitorQuery;
        private IPnRegQuery _pnregQuery;
        private IScnMainQuery _scnMainQuery;
        private ISnHistoryQuery _snHistoryQuery;
        private ISnRegQuery _snregQuery;
        private IWfHistoryQuery _wfhistoryQuery;
        private IWorkScopeQuery _workScopeQuery;

        public ComponentQuery(IUniCloudDbContext context)
        {
            _ccorderQuery = new CcOrderQuery(context);
            _ccpMainQuery = new CcpMainQuery(context);
            _intUnitQuery = new IntUnitQuery(context);
            _oilHistoryQuery = new OilHistoryQuery(context);
            _partsMonitorQuery = new PartsMonitorQuery(context);
            _pnregQuery = new PnRegQuery(context);
            _scnMainQuery = new ScnMainQuery(context);
            _snHistoryQuery = new SnHistoryQuery(context);
            _snregQuery = new SnRegQuery(context);
            _wfhistoryQuery = new WfHistoryQuery(context);
            _workScopeQuery = new WorkScopeQuery(context);
        }

        public CcOrderDataObjectList GetCcOrders()
        {
            return _ccorderQuery.GetCcOrders();
        }

        public CcOrderWithPagination GetCcOrderWithPagination(Pagination pagination)
        {
            return _ccorderQuery.GetCcOrderWithPagination(pagination);
        }

        public CcOrderDataObject GetCcOrderByID(int id)
        {
            return _ccorderQuery.GetCcOrderByID(id);
        }

        public CcpMainDataObjectList GetCcpMains()
        {
            return _ccpMainQuery.GetCcpMains();
        }

        public CcpMainWithPagination GetCcpMainWithPagination(Pagination pagination)
        {
            return _ccpMainQuery.GetCcpMainWithPagination(pagination);
        }

        public CcpMainDataObject GetCcpMainByID(int id)
        {
            return _ccpMainQuery.GetCcpMainByID(id);
        }

        public IntUnitDataObjectList GetIntUnits()
        {
            return _intUnitQuery.GetIntUnits();
        }

        public IntUnitWithPagination GetIntUnitWithPagination(Pagination pagination)
        {
            return _intUnitQuery.GetIntUnitWithPagination(pagination);
        }

        public IntUnitDataObject GetIntUnitByID(int id)
        {
            return _intUnitQuery.GetIntUnitByID(id);
        }

        public OilHistoryDataObjectList GetOilHistorys()
        {
            return _oilHistoryQuery.GetOilHistorys();
        }

        public OilHistoryWithPagination GetOilHistoryWithPagination(Pagination pagination)
        {
            return _oilHistoryQuery.GetOilHistoryWithPagination(pagination);
        }

        public OilHistoryDataObject GetOilHistoryByID(int id)
        {
            return _oilHistoryQuery.GetOilHistoryByID(id);
        }

        public PartsMonitorDataObjectList GetPartsMonitors()
        {
            return _partsMonitorQuery.GetPartsMonitors();
        }

        public PartsMonitorWithPagination GetPartsMonitorWithPagination(Pagination pagination)
        {
            return _partsMonitorQuery.GetPartsMonitorWithPagination(pagination);
        }

        public PartsMonitorDataObject GetPartsMonitorByID(int id)
        {
            return _partsMonitorQuery.GetPartsMonitorByID(id);
        }

        public PnRegDataObjectList GetPnRegs()
        {
            return _pnregQuery.GetPnRegs();
        }

        public PnRegWithPagination GetPnRegWithPagination(Pagination pagination)
        {
            return _pnregQuery.GetPnRegWithPagination(pagination);
        }

        public PnRegDataObject GetPnRegByID(int id)
        {
            return _pnregQuery.GetPnRegByID(id);
        }

        public ScnMainDataObjectList GetScnMains()
        {
            return _scnMainQuery.GetScnMains();
        }

        public ScnMainWithPagination GetScnMainWithPagination(Pagination pagination)
        {
            return _scnMainQuery.GetScnMainWithPagination(pagination);
        }

        public ScnMainDataObject GetScnMainByID(int id)
        {
            return _scnMainQuery.GetScnMainByID(id);
        }

        public SnHistoryDataObjectList GetSnHistorys()
        {
            return _snHistoryQuery.GetSnHistorys();
        }

        public SnHistoryWithPagination GetSnHistoryWithPagination(Pagination pagination)
        {
            return _snHistoryQuery.GetSnHistoryWithPagination(pagination);
        }

        public SnHistoryDataObject GetSnHistoryByID(int id)
        {
            return _snHistoryQuery.GetSnHistoryByID(id);
        }

        public SnRegDataObjectList GetSnRegs()
        {
            return _snregQuery.GetSnRegs();
        }

        public SnRegWithPagination GetSnRegWithPagination(Pagination pagination)
        {
            return _snregQuery.GetSnRegWithPagination(pagination);
        }

        public SnRegDataObject GetSnRegByID(int id)
        {
            return _snregQuery.GetSnRegByID(id);
        }

        public WfHistoryDataObjectList GetWfHistorys()
        {
            return _wfhistoryQuery.GetWfHistorys();
        }

        public WfHistoryWithPagination GetWfHistoryWithPagination(Pagination pagination)
        {
            return _wfhistoryQuery.GetWfHistoryWithPagination(pagination);
        }

        public WfHistoryDataObject GetWfHistoryByID(int id)
        {
            return _wfhistoryQuery.GetWfHistoryByID(id);
        }

        public WorkScopeDataObjectList GetWorkScopes()
        {
            return _workScopeQuery.GetWorkScopes();
        }

        public WorkScopeWithPagination GetWorkScopeWithPagination(Pagination pagination)
        {
            return _workScopeQuery.GetWorkScopeWithPagination(pagination);
        }

        public WorkScopeDataObject GetWorkScopeByID(int id)
        {
            return _workScopeQuery.GetWorkScopeByID(id);
        }


        public SnHistoryDataObjectList QuerySnHistorys(string ac, string itemNo, string pn, DateTime fromDate, DateTime toDate)
        {
            return _snHistoryQuery.QuerySnHistorys(ac, itemNo, pn, fromDate, toDate);
        }
    }
}
