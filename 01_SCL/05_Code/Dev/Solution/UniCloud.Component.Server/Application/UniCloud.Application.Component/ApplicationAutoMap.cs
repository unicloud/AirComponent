using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using UniCloud.DataObjects;
using UniCloud.Domain.Model;


namespace UniCloud.Application
{
    public class ApplicationAutoMap
    {
        public static void Initialize()
        {
            Mapper.CreateMap<Ccin, CcinDataObject>();
            Mapper.CreateMap<CcinDataObject, Ccin>();
            Mapper.CreateMap<CcOrder, CcOrderDataObject>();
                //.ForMember(p => p.Ccouts, t => t.MapFrom(a => a.Ccouts.FirstOrDefault()))
                //.ForMember(p => p.Ccins, t => t.MapFrom(a => a.Ccins.FirstOrDefault()));
            Mapper.CreateMap<CcOrderDataObject, CcOrder>()
                //.ForMember(p => p.Ccins, t => t.Ignore())
                //.ForMember(p => p.Ccouts, t => t.Ignore())
                ;
            Mapper.CreateMap<Ccout, CcoutDataObject>();
            Mapper.CreateMap<CcoutDataObject, Ccout>();
            Mapper.CreateMap<CcpLimit, CcpLimitDataObject>();
            Mapper.CreateMap<CcpLimitDataObject, CcpLimit>().ForMember(p => p.WorkScopeItem, t => t.Ignore());
            Mapper.CreateMap<CcpMain, CcpMainDataObject>();
            Mapper.CreateMap<CcpMainDataObject, CcpMain>();
            Mapper.CreateMap<CcpPn, CcpPnDataObject>();
            Mapper.CreateMap<CcpPnDataObject, CcpPn>();
            Mapper.CreateMap<IntUnit, IntUnitDataObject>();
            Mapper.CreateMap<IntUnitDataObject, IntUnit>();
            Mapper.CreateMap<AcIntUnitUtiliza, AcIntUnitUtilizaDataObject>();
            Mapper.CreateMap<AcIntUnitUtilizaDataObject, AcIntUnitUtiliza>();
            Mapper.CreateMap<OilHistory, OilHistoryDataObject>();
            Mapper.CreateMap<OilHistoryDataObject, OilHistory>();
            Mapper.CreateMap<OilAnalysis, OilAnalysisDataObject>();
            Mapper.CreateMap<OilAnalysisDataObject, OilAnalysis>();
            Mapper.CreateMap<PartsMonitor, PartsMonitorDataObject>();
            Mapper.CreateMap<PartsMonitorDataObject, PartsMonitor>();
            Mapper.CreateMap<PartsMonitorDetail, PartsMonitorDetailDataObject>();
            Mapper.CreateMap<PartsMonitorDetailDataObject, PartsMonitorDetail>();
            Mapper.CreateMap<PnReg, PnRegDataObject>();
            Mapper.CreateMap<PnRegDataObject, PnReg>();
            Mapper.CreateMap<ScnAcorder, ScnAcorderDataObject>();
            Mapper.CreateMap<ScnAcorderDataObject, ScnAcorder>();
            Mapper.CreateMap<ScnItem, ScnItemDataObject>();
            Mapper.CreateMap<ScnItemDataObject, ScnItem>();
            Mapper.CreateMap<ScnMain, ScnMainDataObject>();
            Mapper.CreateMap<ScnMainDataObject, ScnMain>();
            Mapper.CreateMap<SnHistory, SnHistoryDataObject>();
            Mapper.CreateMap<SnHistoryDataObject, SnHistory>();
            Mapper.CreateMap<SnHistoryUnit, SnHistoryUnitDataObject>();
            Mapper.CreateMap<SnHistoryUnitDataObject, SnHistoryUnit>();
            Mapper.CreateMap<SnReg, SnRegDataObject>();
            Mapper.CreateMap<SnRegDataObject, SnReg>().ForMember(p => p.PnReg, t => t.Ignore());
            Mapper.CreateMap<WfHistory, WfHistoryDataObject>();
            Mapper.CreateMap<WfHistoryDataObject, WfHistory>();
            Mapper.CreateMap<WorkScope, WorkScopeDataObject>();
            Mapper.CreateMap<WorkScopeDataObject, WorkScope>();

            Mapper.CreateMap<EgtMargin, EgtMarginDataObject>();
            Mapper.CreateMap<EgtMarginDataObject, EgtMargin>();
            Mapper.CreateMap<AttactDocument, AttactDocumentDataObject>();
            Mapper.CreateMap<AttactDocumentDataObject, AttactDocument>();
            Mapper.CreateMap<MajorEvent, MajorEventDataObject>();
            Mapper.CreateMap<MajorEventDataObject, MajorEvent>();
            Mapper.CreateMap<AirBusMSCN, AirBusMSCNDataObject>();
            Mapper.CreateMap<AirBusMSCNDataObject, AirBusMSCN>();

            Mapper.CreateMap<Adsb, AdsbDataObject>();
            Mapper.CreateMap<AdsbDataObject, Adsb>();
            Mapper.CreateMap<AdsbComply, AdsbComplyDataObject>();
            Mapper.CreateMap<AdsbComplyDataObject, AdsbComply>();
            Mapper.CreateMap<AcStructure, AcStructureDataObject>();
            Mapper.CreateMap<AcStructureDataObject, AcStructure>();
        }
    }
}
