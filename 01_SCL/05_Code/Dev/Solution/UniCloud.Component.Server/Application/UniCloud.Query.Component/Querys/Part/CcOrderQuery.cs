#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/17 23:23:10

// 文件名：CcOrderQuery
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Linq;
using System.Linq.Expressions;
using UniCloud.DataObjects;
using UniCloud.Domain.Model;
using UniCloud.Domain.Repositories.EntityFramework;

namespace UniCloud.Query
{
    /// <summary>
    /// 表示用于CcOrder的查询接口。
    /// </summary>
    public class CcOrderQuery : ICcOrderQuery
    {
        private readonly ComponentDbContext _context;

        public CcOrderQuery(IUniCloudDbContext context)
        {
            _context = context as ComponentDbContext;
        }

        #region Mapper
        Expression<Func<CcOrder, CcOrderDataObject>> ccorderMapper = t => new CcOrderDataObject
        {
            OrderNo = t.OrderNo,
            Cctype = t.Cctype,
            AcReg = t.AcReg,
            SwapAcreg = t.SwapAcreg,
            RemReason = t.RemReason,
            WoNo = t.WoNo,
            WoItem = t.WoItem,
            WoType = t.WoType,
            UpdateDate = t.UpdateDate,
            UpdateBy = t.UpdateBy,
            State = t.State,
            Operator = t.Operator,
            OperatDate = t.OperatDate,
            ID = t.ID,
            PnRegID = t.PnRegID,
            SnRegID = t.SnRegID
        };

        Expression<Func<Ccin, CcinDataObject>> ccinMapper = t => new CcinDataObject
        {
            Ata = t.Ata,
            CcOrderID = t.CcOrderID,
            ID = t.ID,
            EngineTli = t.EngineTli,
            NhSnRegID = t.NhSnRegID,
            PnRegID = t.PnRegID,
            RootSnRegID = t.RootSnRegID,
            SnRegID = t.SnRegID,
            Zone = t.Zone,
            Seq = t.Seq
        };

        Expression<Func<Ccout, CcoutDataObject>> ccoutMapper = t => new CcoutDataObject
        {
            Ata = t.Ata,
            ID = t.ID,
            NhSnRegID = t.NhSnRegID,
            PnRegID = t.PnRegID,
            RootSnRegID = t.RootSnRegID,
            UnScheduled = t.UnScheduled,
            SnRegID = t.SnRegID,
            Seq = t.Seq,
            Zone = t.Zone,
            CcOrderID = t.CcOrderID
        };
        #endregion

        #region Query CcOrder

        /// <summary>
        /// 获取所有CcOrder
        /// </summary>
        /// <returns>所有的CcOrder。</returns>
        public CcOrderDataObjectList GetCcOrders(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            Expression<Func<CcOrder, bool>> source = p => true;
            return GetCcOrderList(source);
        }

        /// <summary>
        /// 获取所有CcOrder分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的CcOrder分页信息。</returns>
        public CcOrderWithPagination GetCcOrderWithPagination(Pagination pagination)
        {
            Expression<Func<CcOrder, bool>> wherePredicate = p => true;
            Expression<Func<CcOrder, dynamic>> sortPredicate = t => t.ID;
            return GetCcOrderPage(wherePredicate, sortPredicate, pagination);
        }

        /// <summary>
        /// 通过CcOrderId获取相应的CcOrder
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CcOrderDataObject GetCcOrderByID(int id)
        {
            Expression<Func<CcOrder, bool>> source = p => p.ID == id;
            var result = GetCcOrderList(source);
            return result == null ? null : result.FirstOrDefault();
        }

        #endregion

        #region Common Query

        private CcOrderDataObjectList GetCcOrderList(Expression<Func<CcOrder, bool>> source)
        {
            var queryResult = (_context.CcOrders.Where(source).Select(ccorderMapper)).ToList();

            if (!queryResult.Any()) return new CcOrderDataObjectList();
            var transferResult = new CcOrderDataObjectList();
            queryResult.ForEach(p =>
                                {
                                    p.Ccout = (from t in _context.Ccouts
                                               join sn in _context.SnRegs on t.SnRegID equals sn.ID into sn2
                                               from sn in sn2.DefaultIfEmpty()
                                               join pn in _context.PnRegs on t.PnRegID equals pn.ID into pn2
                                               from pn in pn2.DefaultIfEmpty()
                                               where t.CcOrderID == p.ID
                                               select new CcoutDataObject
                                               {
                                                   Ata = t.Ata,
                                                   ID = t.ID,
                                                   NhSnRegID = t.NhSnRegID,
                                                   PnRegID = t.PnRegID,
                                                   RootSnRegID = t.RootSnRegID,
                                                   UnScheduled = t.UnScheduled,
                                                   SnRegID = t.SnRegID,
                                                   Seq = t.Seq,
                                                   Zone = t.Zone,
                                                   CcOrderID = t.CcOrderID,
                                                   Pn = pn.Pn,
                                                   Sn = sn.Sn
                                               }).FirstOrDefault();
                                    p.Ccouts.Add(p.Ccout);
                                    p.Ccin = (from t in _context.Ccins
                                              join sn in _context.SnRegs on t.SnRegID equals sn.ID into sn2
                                              from sn in sn2.DefaultIfEmpty()
                                              join pn in _context.PnRegs on t.PnRegID equals pn.ID into pn2
                                              from pn in pn2.DefaultIfEmpty()
                                              where t.CcOrderID == p.ID
                                              select new CcinDataObject()
                                              {
                                                  Ata = t.Ata,
                                                  CcOrderID = t.CcOrderID,
                                                  ID = t.ID,
                                                  EngineTli = t.EngineTli,
                                                  NhSnRegID = t.NhSnRegID,
                                                  PnRegID = t.PnRegID,
                                                  RootSnRegID = t.RootSnRegID,
                                                  SnRegID = t.SnRegID,
                                                  Zone = t.Zone,
                                                  Seq = t.Seq,
                                                  Pn = pn.Pn,
                                                  Sn = sn.Sn
                                              }).FirstOrDefault();
                                    p.Ccins.Add(p.Ccin);
                                    transferResult.Add(p);
                                }
                );
            return transferResult;
        }

        private CcOrderWithPagination GetCcOrderPage(Expression<Func<CcOrder, bool>> wherePredicate,
                   Expression<Func<CcOrder, dynamic>> sortPredicate,
                   Pagination pagination)
        {

            var CcOrderResult = _context.LoadPageDataObjects<CcOrder, CcOrderDataObject>(wherePredicate, sortPredicate, pagination, ccorderMapper);
            if (CcOrderResult == null) return null;
            pagination.TotalPages = CcOrderResult.TotalPages;
            var CcOrderWithPagination = new CcOrderWithPagination
               {
                   Pagination = pagination,
                   BaseDataObjectList = new BaseDataObjectList<CcOrderDataObject>()
               };
            foreach (var value in CcOrderResult.Data)
            {
                value.Ccout = (from t in _context.Ccouts
                               join sn in _context.SnRegs on t.SnRegID equals sn.ID into sn2
                               from sn in sn2.DefaultIfEmpty()
                               join pn in _context.PnRegs on t.PnRegID equals pn.ID into pn2
                               from pn in pn2.DefaultIfEmpty()
                               where t.CcOrderID == value.ID
                               select new CcoutDataObject
                                      {
                                          Ata = t.Ata,
                                          ID = t.ID,
                                          NhSnRegID = t.NhSnRegID,
                                          PnRegID = t.PnRegID,
                                          RootSnRegID = t.RootSnRegID,
                                          UnScheduled = t.UnScheduled,
                                          SnRegID = t.SnRegID,
                                          Seq = t.Seq,
                                          Zone = t.Zone,
                                          CcOrderID = t.CcOrderID,
                                          Pn = pn.Pn,
                                          Sn = sn.Sn
                                      }).FirstOrDefault();
                value.Ccouts.Add(value.Ccout);

                value.Ccin = (from t in _context.Ccins
                              join sn in _context.SnRegs on t.SnRegID equals sn.ID into sn2
                              from sn in sn2.DefaultIfEmpty()
                              join pn in _context.PnRegs on t.PnRegID equals pn.ID into pn2
                              from pn in pn2.DefaultIfEmpty()
                              where t.CcOrderID == value.ID
                              select new CcinDataObject()
                                {
                                    Ata = t.Ata,
                                    CcOrderID = t.CcOrderID,
                                    ID = t.ID,
                                    EngineTli = t.EngineTli,
                                    NhSnRegID = t.NhSnRegID,
                                    PnRegID = t.PnRegID,
                                    RootSnRegID = t.RootSnRegID,
                                    SnRegID = t.SnRegID,
                                    Zone = t.Zone,
                                    Seq = t.Seq,
                                    Pn = pn.Pn,
                                    Sn = sn.Sn
                                }).FirstOrDefault();
                value.Ccins.Add(value.Ccin);
                CcOrderWithPagination.BaseDataObjectList.Add(value);
            }
            return CcOrderWithPagination;
        }

        #endregion

        #region 发动机拆装

        //ENG会有多条记录
        public CcOrderWithPagination GetEngCcOrderWithPagination(Pagination pagination)
        {
            Expression<Func<CcOrder, bool>> wherePredicate = p => p.PnRegID > 0 && p.SnRegID > 0;
            Expression<Func<CcOrder, dynamic>> sortPredicate = t => t.ID;
            return GetEngCcOrderPage(wherePredicate, sortPredicate, pagination);
        }

        private CcOrderWithPagination GetEngCcOrderPage(Expression<Func<CcOrder, bool>> wherePredicate,
                   Expression<Func<CcOrder, dynamic>> sortPredicate,
                   Pagination pagination)
        {

            var CcOrderResult = _context.LoadPageDataObjects<CcOrder, CcOrderDataObject>(wherePredicate, sortPredicate, pagination, ccorderMapper);
            if (CcOrderResult == null) return null;
            pagination.TotalPages = CcOrderResult.TotalPages;
            var CcOrderWithPagination = new CcOrderWithPagination
            {
                Pagination = pagination,
                BaseDataObjectList = new BaseDataObjectList<CcOrderDataObject>()
            };

            //if (CcOrderResult.Data.Count > 0)
            //{
            //    var value = CcOrderResult.Data.FirstOrDefault();
            //    var ccouts = (from t in _context.Ccouts
            //                  join sn in _context.SnRegs on t.SnRegID equals sn.ID
            //                  join pn in _context.PnRegs on t.PnRegID equals pn.ID
            //                  where t.CcOrderID == value.ID
            //                  select new CcoutDataObject
            //                  {
            //                      Ata = t.Ata,
            //                      ID = t.ID,
            //                      NhSnRegID = t.NhSnRegID,
            //                      PnRegID = t.PnRegID,
            //                      RootSnRegID = t.RootSnRegID,
            //                      UnScheduled = t.UnScheduled,
            //                      SnRegID = t.SnRegID,
            //                      Seq = t.Seq,
            //                      Zone = t.Zone,
            //                      CcOrderID = t.CcOrderID,
            //                      Pn = pn.Pn,
            //                      Sn = sn.Sn
            //                  }).ToList();
            //    value.Ccouts.AddRange(ccouts);

            //    var ccins = (from t in _context.Ccins
            //                 join sn in _context.SnRegs on t.SnRegID equals sn.ID
            //                 join pn in _context.PnRegs on t.PnRegID equals pn.ID
            //                 where t.CcOrderID == value.ID
            //                 select new CcinDataObject()
            //                 {
            //                     Ata = t.Ata,
            //                     CcOrderID = t.CcOrderID,
            //                     ID = t.ID,
            //                     EngineTli = t.EngineTli,
            //                     NhSnRegID = t.NhSnRegID,
            //                     PnRegID = t.PnRegID,
            //                     RootSnRegID = t.RootSnRegID,
            //                     SnRegID = t.SnRegID,
            //                     Zone = t.Zone,
            //                     Seq = t.Seq,
            //                     Pn = pn.Pn,
            //                     Sn = sn.Sn
            //                 }).ToList();
            //    value.Ccins.AddRange(ccins);
            //}

            //取第一条记录的Ccins与Ccouts
            foreach (var value in CcOrderResult.Data)
            {
                value.Pn = _context.PnRegs.Where(a => a.ID == value.PnRegID).Select(a => a.Pn).FirstOrDefault();
                value.Sn = _context.SnRegs.Where(a => a.ID == value.SnRegID).Select(a => a.Sn).FirstOrDefault();
                CcOrderWithPagination.BaseDataObjectList.Add(value);
            }
            return CcOrderWithPagination;
        }

        public CcOrderDataObject GetEngCcOrderByID(int id)
        {
            Expression<Func<CcOrder, bool>> source = p => p.ID == id;
            var result = GetEngCcOrderList(source);
            return result == null ? null : result.FirstOrDefault();
        }

        private CcOrderDataObjectList GetEngCcOrderList(Expression<Func<CcOrder, bool>> source)
        {
            var queryResult = (_context.CcOrders.Where(source).Select(ccorderMapper)).ToList();

            if (!queryResult.Any()) return new CcOrderDataObjectList();
            var transferResult = new CcOrderDataObjectList();
            queryResult.ForEach(p =>
            {
                p.Pn = _context.PnRegs.Where(a => a.ID == p.PnRegID).Select(a => a.Pn).FirstOrDefault();
                p.Sn = _context.SnRegs.Where(a => a.ID == p.SnRegID).Select(a => a.Sn).FirstOrDefault();
                var ccouts = (from t in _context.Ccouts
                              join sn in _context.SnRegs on t.SnRegID equals sn.ID
                              join pn in _context.PnRegs on t.PnRegID equals pn.ID
                              where t.CcOrderID == p.ID
                              select new CcoutDataObject
                              {
                                  Ata = t.Ata,
                                  ID = t.ID,
                                  NhSnRegID = t.NhSnRegID,
                                  PnRegID = t.PnRegID,
                                  RootSnRegID = t.RootSnRegID,
                                  UnScheduled = t.UnScheduled,
                                  SnRegID = t.SnRegID,
                                  Seq = t.Seq,
                                  Zone = t.Zone,
                                  CcOrderID = t.CcOrderID,
                                  Pn = pn.Pn,
                                  Sn = sn.Sn
                              }).ToList();
                p.Ccouts.AddRange(ccouts);
                var ccins = (from t in _context.Ccins
                             join sn in _context.SnRegs on t.SnRegID equals sn.ID
                             join pn in _context.PnRegs on t.PnRegID equals pn.ID
                             where t.CcOrderID == p.ID
                             select new CcinDataObject()
                             {
                                 Ata = t.Ata,
                                 CcOrderID = t.CcOrderID,
                                 ID = t.ID,
                                 EngineTli = t.EngineTli,
                                 NhSnRegID = t.NhSnRegID,
                                 PnRegID = t.PnRegID,
                                 RootSnRegID = t.RootSnRegID,
                                 SnRegID = t.SnRegID,
                                 Zone = t.Zone,
                                 Seq = t.Seq,
                                 Pn = pn.Pn,
                                 Sn = sn.Sn
                             }).ToList();
                p.Ccins.AddRange(ccins);
                transferResult.Add(p);
            }
                );
            return transferResult;
        }
        #endregion
    }
}
