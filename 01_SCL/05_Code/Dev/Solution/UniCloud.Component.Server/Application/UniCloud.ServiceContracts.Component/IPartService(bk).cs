using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;

namespace UniCloud.ServiceContracts
{
    /// <summary>
    /// 
    /// </summary>
    [ServiceContract(Namespace = "http://www.UniCloud.com")]
    public interface IPartService : IApplicationServiceContract
    {
        #region Ccin
        /// <summary>
        /// 添加Ccin
        /// </summary>
        /// <param name="ccins"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcinDataObjectList AddCcin(int ccOrderId, CcinDataObjectList ccins);

        /// <summary>
        /// 删除Ccin
        /// </summary>
        /// <param name="ccinIds"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        bool DeleteCcin(int ccOrderId, IDList ccinIds);

        /// <summary>
        /// 更新Ccin
        /// </summary>
        /// <param name="ccins"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcinDataObjectList UpdateCcin(int ccOrderId, CcinDataObjectList ccins);

        /// <summary>
        /// 获取所有Ccin
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcinDataObjectList GetAllCcins(int ccOrderId);

        /// <summary>
        /// 通过ID获取Ccin
        /// </summary>
        /// <param name="ccinId"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcinDataObject GetCcin(int ccOrderId, int ccinId);

        #endregion

        #region CcOrder
        /// <summary>
        /// 添加CcOrder
        /// </summary>
        /// <param name="ccOrders"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcOrderDataObjectList AddCcOrder(CcOrderDataObjectList ccOrders);

        /// <summary>
        /// 删除CcOrder
        /// </summary>
        /// <param name="ccOrderIds"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        bool DeleteCcOrder(IDList ccOrderIds);

        /// <summary>
        /// 更新CcOrder
        /// </summary>
        /// <param name="ccOrders"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcOrderDataObjectList UpdateCcOrder(CcOrderDataObjectList ccOrders);

        /// <summary>
        /// 获取所有CcOrder
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcOrderDataObjectList GetAllCcOrders();

        /// <summary>
        /// 通过ID获取CcOrder
        /// </summary>
        /// <param name="ccOrderId"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcOrderDataObject GetCcOrder(int ccOrderId);


        /// <summary>
        /// 审核拆装记录
        /// </summary>
        /// <param name="ccOrderId"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        bool VerifyCcOrder(int ccOrderId);

        /// <summary>
        /// 根据条件查询拆装记录
        /// </summary>
        /// <param name="pnReg">件号</param>
        /// <param name="snReg">序号（附件）</param>
        /// <param name="ccType">拆装类型</param>
        /// <param name="ccNature">拆装性质</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcOrderDataObjectList QueryCcOrder(string pnReg, string snReg, string ccType, string ccNature);

        /// <summary>
        /// 提交CcOrder的增删改数据
        /// </summary>
        /// <param name="ccOrderData"></param>
        /// <returns>提交成功的数据</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcOrderResultData CommitCcOrders(CcOrderResultData ccOrderData);

        /// <summary>
        /// 获取所有CcOrder分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的CcOrder分页信息。</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcOrderWithPagination GetCcOrderWithPagination(Pagination pagination);
        #endregion

        #region Ccout
        /// <summary>
        /// 添加Ccout
        /// </summary>
        /// <param name="ccouts"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcoutDataObjectList AddCcout(int ccOrderId, CcoutDataObjectList ccouts);

        /// <summary>
        /// 删除Ccout
        /// </summary>
        /// <param name="ccoutIds"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        bool DeleteCcout(int ccOrderId, IDList ccoutIds);

        /// <summary>
        /// 更新Ccout
        /// </summary>
        /// <param name="ccouts"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcoutDataObjectList UpdateCcout(int ccOrderId, CcoutDataObjectList ccouts);

        /// <summary>
        /// 获取所有Ccout
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcoutDataObjectList GetAllCcouts(int ccOrderId);

        /// <summary>
        /// 通过ID获取Ccout
        /// </summary>
        /// <param name="ccoutId"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcoutDataObject GetCcout(int ccOrderId, int ccoutId);

        #endregion

        #region CcpLimit
        /// <summary>
        /// 添加CcpLimit
        /// </summary>
        /// <param name="ccpMainId"></param>
        /// <param name="ccpLimits"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcpLimitDataObjectList AddCcpLimit(int ccpMainId, CcpLimitDataObjectList ccpLimits);

        /// <summary>
        /// 删除CcpLimit
        /// </summary>
        /// <param name="ccpMainId"></param>
        /// <param name="ccpLimits"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void DeleteCcpLimit(int ccpMainId, CcpLimitDataObjectList ccpLimits);

        /// <summary>
        /// 更新CcpLimit
        /// </summary>
        /// <param name="ccpMainId"></param>
        /// <param name="ccpLimits"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcpLimitDataObjectList UpdateCcpLimit(int ccpMainId, CcpLimitDataObjectList ccpLimits);

        /// <summary>
        /// 通过ID获取CcpLimit
        /// </summary>
        /// <param name="ccpMainId"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcpLimitDataObjectList GetCcpLimit(int ccpMainId);

        #endregion

        #region CcpMain
        /// <summary>
        /// 添加CcpMain
        /// </summary>
        /// <param name="ccpMains"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcpMainDataObjectList AddCcpMain(CcpMainDataObjectList ccpMains);

        /// <summary>
        /// 删除CcpMain
        /// </summary>
        /// <param name="ccpMainIds"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void DeleteCcpMain(IDList ccpMainIds);

        /// <summary>
        /// 更新CcpMain
        /// </summary>
        /// <param name="ccpMains"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcpMainDataObjectList UpdateCcpMain(CcpMainDataObjectList ccpMains);

        /// <summary>
        /// 获取所有CcpMain
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcpMainDataObjectList GetAllCcpMains();

        /// <summary>
        /// 通过ID获取CcpMain
        /// </summary>
        /// <param name="ccpMainId"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcpMainDataObject GetCcpMain(int ccpMainId);

        /// <summary>
        /// 根据条件查询CcpMain（展示用）
        /// </summary>
        /// <param name="acModel">机型</param>
        /// <param name="itemNo">附件项号</param>
        /// <param name="ata">章节</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof (FaultData))]
        CcpMainDataObjectList QueryAllCcpMain(string actype, string itemNo, string ata, string state);

        /// <summary>
        /// 获取所有附件项号
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        string[] GetAllItem();

        /// <summary>
        /// 审核附件项
        /// </summary>
        /// <param name="ccpMainId"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void VerifyCcpMain(int ccpMainId);

        /// <summary>
        /// 根据PnID查询附件项号
        /// </summary>
        /// <param name="pnId">PnID</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        string QueryItemNo(int pnId);

        /// <summary>
        /// 根据附件项号查询附件
        /// </summary>
        /// <param name="itemNo"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        PnRegDataObjectList QueryPns(string itemNo);

        /// <summary>
        /// 提交CcpMain的增删改数据
        /// </summary>
        /// <param name="ccpMainData"></param>
        /// <returns>提交成功的数据</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcpMainResultData CommitCcpMains(CcpMainResultData ccpMainData);

        /// <summary>
        /// 获取所有CcpMain分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的CcpMain分页信息。</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcpMainWithPagination GetCcpMainWithPagination(Pagination pagination);
        #endregion

        #region CcpPn
        /// <summary>
        /// 添加CcpPn
        /// </summary>
        /// <param name="ccpMainId"></param>
        /// <param name="ccpPns"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcpPnDataObjectList AddCcpPn(int ccpMainId,CcpPnDataObjectList ccpPns);

        /// <summary>
        /// 删除CcpPn
        /// </summary>
        /// <param name="ccpMainId"></param>
        /// <param name="ccpPns"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void DeleteCcpPn(int ccpMainId, CcpPnDataObjectList ccpPns);

        /// <summary>
        /// 更新CcpPn
        /// </summary>
        /// <param name="ccpMainId"></param>
        /// <param name="ccpPns"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcpPnDataObjectList UpdateCcpPn(int ccpMainId,CcpPnDataObjectList ccpPns);

        /// <summary>
        /// 通过ID获取CcpPn
        /// </summary>
        /// <param name="ccpMainId"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        CcpPnDataObjectList GetCcpPn(int ccpMainId);

        #endregion

        #region IntUnit
        /// <summary>
        /// 添加IntUnit
        /// </summary>
        /// <param name="intUnits"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        IntUnitDataObjectList AddIntUnit(IntUnitDataObjectList intUnits);

        /// <summary>
        /// 删除IntUnit
        /// </summary>
        /// <param name="intUnitIds"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void DeleteIntUnit(IDList intUnitIds);

        /// <summary>
        /// 更新IntUnit
        /// </summary>
        /// <param name="intUnits"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        IntUnitDataObjectList UpdateIntUnit(IntUnitDataObjectList intUnits);

        /// <summary>
        /// 获取所有IntUnit
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        IntUnitDataObjectList GetAllIntUnits();

        /// <summary>
        /// 通过ID获取IntUnit
        /// </summary>
        /// <param name="intUnitId"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        IntUnitDataObject GetIntUnit(int intUnitId);

        /// <summary>
        /// 提交IntUnit的增删改数据
        /// </summary>
        /// <param name="intUnitData"></param>
        /// <returns>提交成功的数据</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        IntUnitResultData CommitIntUnits(IntUnitResultData intUnitData);

        /// <summary>
        /// 获取所有IntUnit分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的IntUnit分页信息。</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        IntUnitWithPagination GetIntUnitWithPagination(Pagination pagination);
        #endregion

        #region OilHistory
        /// <summary>
        /// 添加OilHistory
        /// </summary>
        /// <param name="oilHistorys"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        OilHistoryDataObjectList AddOilHistory(OilHistoryDataObjectList oilHistorys);

        /// <summary>
        /// 删除OilHistory
        /// </summary>
        /// <param name="oilHistoryIds"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        bool DeleteOilHistory(IDList oilHistoryIds);

        /// <summary>
        /// 更新OilHistory
        /// </summary>
        /// <param name="oilHistorys"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        OilHistoryDataObjectList UpdateOilHistory(OilHistoryDataObjectList oilHistorys);

        /// <summary>
        /// 获取所有OilHistory
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        OilHistoryDataObjectList GetAllOilHistorys();

        /// <summary>
        /// 通过ID获取OilHistory
        /// </summary>
        /// <param name="oilHistoryId"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        OilHistoryDataObject GetOilHistory(int oilHistoryId);

        /// <summary>
        /// 分析Apu
        /// </summary>
        /// <param name="pn">件号</param>
        /// <param name="sn">序号</param>
        /// <param name="average">滚动平均周期值</param>
        /// <param name="warnValue">消耗率警戒值</param>
        /// <param name="warnAddValue">滑油消耗率趋势增量警戒值</param>
        /// <param name="startTime">分析起始日期</param>
        /// <param name="endTime">分析起始日期</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        APUWarningDtoList AnalyAPUWarn(string pn, string sn, int average, int warnValue, int warnAddValue,
                                       DateTime startTime, DateTime endTime);

        /// <summary>
        /// 查询添加滑油信息
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        OilHistoryDtoList GetAllOilHistoryDto();

        /// <summary>
        /// 提交OilHistory的增删改数据
        /// </summary>
        /// <param name="oilHistoryData"></param>
        /// <returns>提交成功的数据</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        OilHistoryResultData CommitOilHistorys(OilHistoryResultData oilHistoryData);

        /// <summary>
        /// 获取所有OilHistory分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的OilHistory分页信息。</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        OilHistoryWithPagination GetOilHistoryWithPagination(Pagination pagination);
        #endregion

        #region PartsMonitor
        /// <summary>
        /// 添加PartsMonitor
        /// </summary>
        /// <param name="partsMonitors"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        PartsMonitorDataObjectList AddPartsMonitor(PartsMonitorDataObjectList partsMonitors);

        /// <summary>
        /// 删除PartsMonitor
        /// </summary>
        /// <param name="partsMonitorIds"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        bool DeletePartsMonitor(IDList partsMonitorIds);

        /// <summary>
        /// 更新PartsMonitor
        /// </summary>
        /// <param name="partsMonitors"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        PartsMonitorDataObjectList UpdatePartsMonitor(PartsMonitorDataObjectList partsMonitors);

        /// <summary>
        /// 获取所有PartsMonitor
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        PartsMonitorDataObjectList GetAllPartsMonitors();

        /// <summary>
        /// 通过ID获取PartsMonitor
        /// </summary>
        /// <param name="partsMonitorId"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        PartsMonitorDataObject GetPartsMonitor(int partsMonitorId);

        /// <summary>
        /// 通过条件查找PartsMonitor(展示用)
        /// </summary>
        /// <param name="acReg">飞机</param>
        /// <param name="ccpMainID">附件项ID</param>
        /// <param name="pnRegID">件号ID</param>
        /// <param name="snRegID">附件ID（序号ID）</param>
        /// <param name="expireDate">到期日期</param>
        /// <param name="position">安装位置</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        PartsMonitorDataObjectList QueryPartsMonitor(string acReg, int ccpMainID, int pnRegID, int snRegID, DateTime expireDate,
                                              string position);

        /// <summary>
        /// 计算附件利用率
        /// </summary>
        /// <param name="acRegID">飞机ID</param>
        /// <param name="ccpMainID">附件项ID</param>
        /// <param name="pnRegID">件号ID</param>
        /// <param name="snRegID">附件ID（序号ID）</param>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="calculateType">采用哪种方式进行计算（0：日利用率，1：周利用率，2：月利用率）</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        UtilizationData CalculateUtilization(int acRegID, int ccpMainID, int pnRegID, int snRegID, DateTime startTime,
                                             DateTime endTime, int calculateType);

        /// <summary>
        /// 提交PartsMonitor的增删改数据
        /// </summary>
        /// <param name="partsMonitorData"></param>
        /// <returns>提交成功的数据</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        PartsMonitorResultData CommitPartsMonitors(PartsMonitorResultData partsMonitorData);

        /// <summary>
        /// 获取所有PartsMonitor分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的PartsMonitor分页信息。</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        PartsMonitorWithPagination GetPartsMonitorWithPagination(Pagination pagination);

        /// <summary>
        /// 根据输入条件，对不同范围内的部件进行重新计算
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        bool CalculatePartsDue(PartsMonitorDataObject filter);

        #endregion

        #region PartsMonitorDetail
        /// <summary>
        /// 添加PartsMonitorDetail
        /// </summary>
        /// <param name="partsMonitorDetails"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        PartsMonitorDetailDataObjectList AddPartsMonitorDetail(int partsMonitorId, PartsMonitorDetailDataObjectList partsMonitorDetails);

        /// <summary>
        /// 删除PartsMonitorDetail
        /// </summary>
        /// <param name="partsMonitorDetailIds"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        bool DeletePartsMonitorDetail(int partsMonitorId, IDList partsMonitorDetailIds);

        /// <summary>
        /// 更新PartsMonitorDetail
        /// </summary>
        /// <param name="partsMonitorDetails"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        PartsMonitorDetailDataObjectList UpdatePartsMonitorDetail(int partsMonitorId, PartsMonitorDetailDataObjectList partsMonitorDetails);

        /// <summary>
        /// 获取所有PartsMonitorDetail
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        PartsMonitorDetailDataObjectList GetAllPartsMonitorDetails(int partsMonitorId);

        /// <summary>
        /// 获取部件所有PartsMonitorDetail
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        PartsMonitorDetailDataObjectList GetPartsMonitorDetailByMonitor(string[] keys);
       
        /// <summary>
        /// 通过ID获取PartsMonitorDetail
        /// </summary>
        /// <param name="partsMonitorDetailId"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        PartsMonitorDetailDataObject GetPartsMonitorDetail(int partsMonitorId, int partsMonitorDetailId);

        #endregion

        #region PnReg
        /// <summary>
        /// 添加PnReg
        /// </summary>
        /// <param name="pnRegs"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        PnRegDataObjectList AddPnReg(PnRegDataObjectList pnRegs);

        /// <summary>
        /// 删除PnReg
        /// </summary>
        /// <param name="pnRegIds"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void DeletePnReg(IDList pnRegIds);

        /// <summary>
        /// 更新PnReg
        /// </summary>
        /// <param name="pnRegs"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        PnRegDataObjectList UpdatePnReg(PnRegDataObjectList pnRegs);

        /// <summary>
        /// 获取所有PnReg
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        PnRegDataObjectList GetAllPnRegs();

        /// <summary>
        /// 通过ID获取PnReg
        /// </summary>
        /// <param name="pnRegId"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        PnRegDataObject GetPnReg(int pnRegId);

        /// <summary>
        /// 提交PnReg的增删改数据
        /// </summary>
        /// <param name="pnRegData"></param>
        /// <returns>提交成功的数据</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        PnRegResultData CommitPnRegs(PnRegResultData pnRegData);

        /// <summary>
        /// 获取所有PnReg分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的PnReg分页信息。</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        PnRegWithPagination GetPnRegWithPagination(Pagination pagination);
        #endregion

        #region ScnAcorder
        /// <summary>
        /// 添加ScnAcorder
        /// </summary>
        /// <param name="scnAcorders"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        ScnAcorderDataObjectList AddScnAcorder(int scnMainId, ScnAcorderDataObjectList scnAcorders);

        /// <summary>
        /// 删除ScnAcorder
        /// </summary>
        /// <param name="scnAcorderIds"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        bool DeleteScnAcorder(int scnMainId, IDList scnAcorderIds);

        /// <summary>
        /// 更新ScnAcorder
        /// </summary>
        /// <param name="scnAcorders"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        ScnAcorderDataObjectList UpdateScnAcorder(int scnMainId, ScnAcorderDataObjectList scnAcorders);

        /// <summary>
        /// 获取所有ScnAcorder
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        ScnAcorderDataObjectList GetAllScnAcorders(int scnMainId);

        /// <summary>
        /// 通过ID获取ScnAcorder
        /// </summary>
        /// <param name="scnAcorderId"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        ScnAcorderDataObject GetScnAcorder(int scnMainId, int scnAcorderId);

        #endregion

        #region ScnItem
        /// <summary>
        /// 添加ScnItem
        /// </summary>
        /// <param name="scnItems"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        ScnItemDataObjectList AddScnItem(int scnMainId, ScnItemDataObjectList scnItems);

        /// <summary>
        /// 删除ScnItem
        /// </summary>
        /// <param name="scnItemIds"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        bool DeleteScnItem(int scnMainId, IDList scnItemIds);

        /// <summary>
        /// 更新ScnItem
        /// </summary>
        /// <param name="scnItems"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        ScnItemDataObjectList UpdateScnItem(int scnMainId, ScnItemDataObjectList scnItems);

        /// <summary>
        /// 获取所有ScnItem
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        ScnItemDataObjectList GetAllScnItems(int scnMainId);

        /// <summary>
        /// 通过ID获取ScnItem
        /// </summary>
        /// <param name="scnItemId"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        ScnItemDataObject GetScnItem(int scnMainId, int scnItemId);

        /// <summary>
        /// 根据ScnMainID查询所属明细
        /// </summary>
        /// <param name="scnMainId"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        ScnItemDtoList QueryAllScnItems(int scnMainId);
        #endregion

        #region ScnMain
        /// <summary>
        /// 添加ScnMain
        /// </summary>
        /// <param name="scnMains"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        ScnMainDataObjectList AddScnMain(ScnMainDataObjectList scnMains);

        /// <summary>
        /// 删除ScnMain
        /// </summary>
        /// <param name="scnMainIds"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        bool DeleteScnMain(IDList scnMainIds);

        /// <summary>
        /// 更新ScnMain
        /// </summary>
        /// <param name="scnMains"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        ScnMainDataObjectList UpdateScnMain(ScnMainDataObjectList scnMains);

        /// <summary>
        /// 获取所有ScnMain
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        ScnMainDataObjectList GetAllScnMains();

        /// <summary>
        /// 通过ID获取ScnMain
        /// </summary>
        /// <param name="scnMainId"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        ScnMainDataObject GetScnMain(int scnMainId);

        /// <summary>
        /// 提交ScnMain的增删改数据
        /// </summary>
        /// <param name="scnMainData"></param>
        /// <returns>提交成功的数据</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        ScnMainResultData CommitScnMains(ScnMainResultData scnMainData);

        /// <summary>
        /// 获取所有ScnMain分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的ScnMain分页信息。</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        ScnMainWithPagination GetScnMainWithPagination(Pagination pagination);
        #endregion

        #region SnHistory
        /// <summary>
        /// 添加SnHistory
        /// </summary>
        /// <param name="snHistorys"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        SnHistoryDataObjectList AddSnHistory(SnHistoryDataObjectList snHistorys);

        /// <summary>
        /// 删除SnHistory
        /// </summary>
        /// <param name="snHistoryIds"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void DeleteSnHistory(IDList snHistoryIds);

        /// <summary>
        /// 更新SnHistory
        /// </summary>
        /// <param name="snHistorys"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        SnHistoryDataObjectList UpdateSnHistory(SnHistoryDataObjectList snHistorys);

        /// <summary>
        /// 获取所有SnHistory
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        SnHistoryDataObjectList GetAllSnHistorys();

        /// <summary>
        /// 通过ID获取SnHistory
        /// </summary>
        /// <param name="snHistoryId"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        SnHistoryDataObject GetSnHistory(int snHistoryId);

        /// <summary>
        /// 根据SnRegID获取SnHistory
        /// </summary>
        /// <param name="snRegID"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        SnHistoryDataObjectList GetSnHistoryBySnRegID(int snRegID);

        /// <summary>
        /// 提交SnHistory的增删改数据
        /// </summary>
        /// <param name="snHistoryData"></param>
        /// <returns>提交成功的数据</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        SnHistoryResultData CommitSnHistorys(SnHistoryResultData snHistoryData);

        /// <summary>
        /// 获取所有SnHistory分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的SnHistory分页信息。</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        SnHistoryWithPagination GetSnHistoryWithPagination(Pagination pagination);

        ///// <summary>
        ///// 条件查询附件
        ///// </summary>
        ///// <param name="ac">飞机号</param>
        ///// <param name="itemNo">附件项</param>
        ///// <param name="pn">件号</param>
        ///// <param name="fromDate">开始日期</param>
        ///// <param name="toDate">结束日期</param>
        ///// <returns></returns>
        //[OperationContract]
        //[FaultContract(typeof(FaultData))]
        //SnHistoryDataObjectList QuerySnHistorys(string ac, string itemNo, string pn, DateTime fromDate, DateTime toDate);

        #endregion

        #region SnHistoryUnit
        /// <summary>
        /// 添加SnHistoryUnit
        /// </summary>
        /// <param name="snHistoryId"></param>
        /// <param name="snHistoryUnits"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        SnHistoryUnitDataObjectList AddSnHistoryUnit(int snHistoryId,SnHistoryUnitDataObjectList snHistoryUnits);

        /// <summary>
        /// 删除SnHistoryUnit
        /// </summary>
        /// <param name="snHistoryId"></param>
        /// <param name="snHistoryUnits"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void DeleteSnHistoryUnit(int snHistoryId, SnHistoryUnitDataObjectList snHistoryUnits);

        /// <summary>
        /// 更新SnHistoryUnit
        /// </summary>
        /// <param name="snHistoryId"></param>
        /// <param name="snHistoryUnits"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        SnHistoryUnitDataObjectList UpdateSnHistoryUnit(int snHistoryId, SnHistoryUnitDataObjectList snHistoryUnits);

        /// <summary>
        /// 通过SnHistoryID获取SnHistoryUnit
        /// </summary>
        /// <param name="snHistoryId"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        SnHistoryUnitDataObjectList GetSnHistoryUnit(int snHistoryId);

        #endregion

        #region SnReg
        /// <summary>
        /// 添加SnReg
        /// </summary>
        /// <param name="snRegs"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        SnRegDataObjectList AddSnReg(SnRegDataObjectList snRegs);
        
        /// <summary>
        /// 添加SnReg
        /// </summary>
        /// <param name="snRegs"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        SnRegDataObjectList ImportSnRegs(SnRegDataObjectList snRegs);

        /// <summary>
        /// 添加SnReg
        /// </summary>
        /// <param name="snRegs"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        bool ApprSnRegs(IDList snRegIds);

        /// <summary>
        /// 删除SnReg
        /// </summary>
        /// <param name="snRegIds"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void DeleteSnReg(IDList snRegIds);

        /// <summary>
        /// 更新SnReg
        /// </summary>
        /// <param name="snRegs"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        SnRegDataObjectList UpdateSnReg(SnRegDataObjectList snRegs);

        /// <summary>
        /// 获取所有SnReg
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        SnRegDataObjectList GetAllSnRegs();

        /// <summary>
        /// 通过ID获取SnReg
        /// </summary>
        /// <param name="snRegId"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        SnRegDataObject GetSnReg(int snRegId);

        ///// <summary>
        ///// 条件查询附件
        ///// </summary>
        ///// <param name="ac">飞机号</param>
        ///// <param name="itemNo">附件项</param>
        ///// <param name="pn">件号</param>
        ///// <returns></returns>
        //[OperationContract]
        //[FaultContract(typeof(FaultData))]
        //SnRegDataObjectList QuerySnRegs(string ac, string itemNo, string pn);

        ///// <summary>
        ///// 条件查询附件
        ///// </summary>
        ///// <param name="ac">飞机</param>
        ///// <param name="avail">状态</param>
        ///// <param name="itemNo">附件项号</param>
        ///// <param name="pn">件号</param>
        ///// <returns></returns>        
        //[OperationContract]
        //[FaultContract(typeof (FaultData))]
        //SnRegDataObjectList QuerySnRegDtos(string ac,string avail,string itemNo, string pn);

        /// <summary>
        /// 条件查询附件
        /// </summary>
        /// <param name="ac">飞机号</param>
        /// <param name="pnRegId">件号ID</param>
        /// <param name="sn">序号</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        SnRegDataObjectList QuerySnRegs(string ac, int pnRegId, string sn);

        /// <summary>
        /// 条件查询附件
        /// </summary>
        /// <param name="itemNo">附件项号</param>
        /// <param name="pnId">件号ID</param>
        /// <param name="snId">序号ID</param>
        /// <param name="ac">飞机ID</param>
        /// <param name="avail">状态</param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        SnRegDataObjectList QuerySnRegDtos(string itemNo, int pnId, int snId, string ac, string avail);

        /// <summary>
        /// 提交SnReg的增删改数据
        /// </summary>
        /// <param name="snRegData"></param>
        /// <returns>提交成功的数据</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        SnRegResultData CommitSnRegs(SnRegResultData snRegData);

        /// <summary>
        /// 获取所有SnReg分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的SnReg分页信息。</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        SnRegWithPagination GetSnRegWithPagination(Pagination pagination);
        #endregion

        #region WfHistory
        /// <summary>
        /// 添加WfHistory
        /// </summary>
        /// <param name="wfHistorys"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        WfHistoryDataObjectList AddWfHistory(WfHistoryDataObjectList wfHistorys);

        /// <summary>
        /// 删除WfHistory
        /// </summary>
        /// <param name="wfHistoryIds"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void DeleteWfHistory(IDList wfHistoryIds);

        /// <summary>
        /// 更新WfHistory
        /// </summary>
        /// <param name="wfHistorys"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        WfHistoryDataObjectList UpdateWfHistory(WfHistoryDataObjectList wfHistorys);

        /// <summary>
        /// 获取所有WfHistory
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        WfHistoryDataObjectList GetAllWfHistorys();

        /// <summary>
        /// 通过ID获取WfHistory
        /// </summary>
        /// <param name="wfHistoryId"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        WfHistoryDataObject GetWfHistory(int wfHistoryId);

        /// <summary>
        /// 通过业务代码与Id获取WfHistroy
        /// </summary>
        /// <param name="businessId"></param>
        /// <param name="business"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof (FaultData))]
        WfHistoryDataObjectList GetWfHistoryByBusiness(int businessId, string business);

        /// <summary>
        /// 通过业务代码与Id及部门获取WfHistroy
        /// </summary>
        /// <param name="businessId"></param>
        /// <param name="business"></param>
        /// <param name="department"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        WfHistoryDataObject QueryWfHistory(int businessId, string business, string department);

        /// <summary>
        /// 提交WfHistory的增删改数据
        /// </summary>
        /// <param name="wfHistoryData"></param>
        /// <returns>提交成功的数据</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        WfHistoryResultData CommitWfHistorys(WfHistoryResultData wfHistoryData);

        /// <summary>
        /// 获取所有WfHistory分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的WfHistory分页信息。</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        WfHistoryWithPagination GetWfHistoryWithPagination(Pagination pagination);
        #endregion

        #region WorkScope
        /// <summary>
        /// 添加WorkScope
        /// </summary>
        /// <param name="workScopes"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        WorkScopeDataObjectList AddWorkScope(WorkScopeDataObjectList workScopes);

        /// <summary>
        /// 删除WorkScope
        /// </summary>
        /// <param name="workScopeIds"></param>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        void DeleteWorkScope(IDList workScopeIds);

        /// <summary>
        /// 更新WorkScope
        /// </summary>
        /// <param name="workScopes"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        WorkScopeDataObjectList UpdateWorkScope(WorkScopeDataObjectList workScopes);

        /// <summary>
        /// 获取所有WorkScope
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        WorkScopeDataObjectList GetAllWorkScopes();

        /// <summary>
        /// 通过ID获取WorkScope
        /// </summary>
        /// <param name="workScopeId"></param>
        /// <returns></returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        WorkScopeDataObject GetWorkScope(int workScopeId);

        /// <summary>
        /// 提交WorkScope的增删改数据
        /// </summary>
        /// <param name="workScopeData"></param>
        /// <returns>提交成功的数据</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        WorkScopeResultData CommitWorkScopes(WorkScopeResultData workScopeData);

        /// <summary>
        /// 获取所有WorkScope分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的WorkScope分页信息。</returns>
        [OperationContract]
        [FaultContract(typeof(FaultData))]
        WorkScopeWithPagination GetWorkScopeWithPagination(Pagination pagination);
        #endregion


    }
}
