#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/13 10:03:06

// 文件名：AirBusMSCNQuery
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
    /// 表示用于AirBusMSCN的查询接口。
    /// </summary>
    public class AirBusMSCNQuery : IAirBusMSCNQuery
    {
        private readonly ComponentDbContext _context;

        public AirBusMSCNQuery(IUniCloudDbContext context)
        {
            _context = context as ComponentDbContext;
        }

        #region Query AirBusMSCN

        /// <summary>
        /// 获取所有AirBusMSCN
        /// </summary>
        /// <returns>所有的AirBusMSCN。</returns>
        public AirBusMSCNDataObjectList GetAirBusMSCNs(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            Expression<Func<AirBusMSCN, bool>> source = p => true;
            return GetAirBusMSCNList(source);
        }

        /// <summary>
        /// 获取所有AirBusMSCN分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的AirBusMSCN分页信息。</returns>
        public AirBusMSCNWithPagination GetAirBusMSCNWithPagination(Pagination pagination)
        {
            Expression<Func<AirBusMSCN, bool>> wherePredicate = p => true;
            Expression<Func<AirBusMSCN, dynamic>> sortPredicate = t => t.ID;
            return GetAirBusMSCNPage(wherePredicate, sortPredicate, pagination);
        }

        /// <summary>
        /// 通过AirBusMSCNId获取相应的AirBusMSCN
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AirBusMSCNDataObject GetAirBusMSCNByID(int id)
        {
            Expression<Func<AirBusMSCN, bool>> source = p => p.ID == id;
            var result = GetAirBusMSCNList(source);
            return result == null ? null : result.FirstOrDefault();
        }

        #endregion

        #region Common Query

        private AirBusMSCNDataObjectList GetAirBusMSCNList(Expression<Func<AirBusMSCN, bool>> source)
        {
            var queryResult = (_context.AirBusMSCNs.Where(source).Select(t => new AirBusMSCNDataObject()
               {
                   MscnNo = t.MscnNo,
                   MscnTitle = t.MscnTitle,
                   Ata = t.Ata,
                   Mod = t.Mod,
                   Status = t.Status,
                   Msn = t.Msn,
                   Fleet = t.Fleet,
                   ID = t.ID,
               })).ToList();
            if (!queryResult.Any()) return new AirBusMSCNDataObjectList();
            var transferResult = new AirBusMSCNDataObjectList();
            queryResult.ForEach(transferResult.Add);
            return transferResult;
        }

        private AirBusMSCNWithPagination GetAirBusMSCNPage(Expression<Func<AirBusMSCN, bool>> wherePredicate,
                   Expression<Func<AirBusMSCN, dynamic>> sortPredicate,
                   Pagination pagination)
        {
            Expression<Func<AirBusMSCN, AirBusMSCNDataObject>> mapper = t => new AirBusMSCNDataObject
               {
                   MscnNo = t.MscnNo,
                   MscnTitle = t.MscnTitle,
                   Ata = t.Ata,
                   Mod = t.Mod,
                   Status = t.Status,
                   Msn = t.Msn,
                   Fleet = t.Fleet,
                   ID = t.ID,
               };
            var AirBusMSCNResult = _context.LoadPageDataObjects<AirBusMSCN, AirBusMSCNDataObject>(wherePredicate, sortPredicate, pagination, mapper);
            if (AirBusMSCNResult == null) return null;
            pagination.TotalPages = AirBusMSCNResult.TotalPages;
            var AirBusMSCNWithPagination = new AirBusMSCNWithPagination
               {
                   Pagination = pagination,
                   BaseDataObjectList = new BaseDataObjectList<AirBusMSCNDataObject>()
               };
            foreach (var value in AirBusMSCNResult.Data)
            {
                AirBusMSCNWithPagination.BaseDataObjectList.Add(value);
            }
            return AirBusMSCNWithPagination;
        }

        public CompareMscnDtoList CompareMscn(string fleet, string importType, AirBusMSCNDataObjectList airBus)
        {
            CompareMscnDtoList results = new CompareMscnDtoList();
            //找该批次加飞机
            var sysResults = (from main in _context.ScnMains
                              from scn in main.ScnAcorders
                              where scn.CSCNumber == fleet && main.ScnType == "MSCN"
                              select new CompareMscnDto
                                     {
                                         MscnNo = main.ScnNo,
                                         Msn = scn.MSN,
                                         SysHas = true,
                                     }).ToList();
            //如果是系统导入，从系统中取数据填充到airBus
            if (importType.Equals("sys", StringComparison.CurrentCultureIgnoreCase))
            {
                var sysSaveResults = _context.AirBusMSCNs.Where(a => a.Fleet == fleet)
                    .Select(p => new AirBusMSCNDataObject()
                    {
                        Ata = p.Ata,
                        Fleet = p.Fleet,
                        ID = p.ID,
                        Mod = p.Mod,
                        MscnNo = p.MscnNo,
                        MscnTitle = p.MscnTitle,
                        Msn = p.Msn,
                        Status = p.Status
                    }).ToList();
                airBus = new AirBusMSCNDataObjectList();
                sysSaveResults.ForEach(airBus.Add);
            }

            //循环遍历传入集合
            foreach (var bus in airBus)
            {
                CompareMscnDto cp = new CompareMscnDto() { MscnNo = bus.MscnNo, Msn = bus.Msn, AirBusHas = true };
                var sysHas = sysResults.Where(a => a.MscnNo == bus.MscnNo).FirstOrDefault();
                if (sysHas != null)
                {
                    cp.SysHas = true;
                    sysResults.Remove(sysHas);
                }
                results.Add(cp);
                //如果是SVC中导入，则增加保存功能
                if (importType.Equals("svc", StringComparison.CurrentCultureIgnoreCase))
                {
                    //将导出的数据保存到数据库中
                    var isExist = _context.AirBusMSCNs.Where(a => a.MscnNo == bus.MscnNo).FirstOrDefault();
                    //如果数据库中不存在，则保存
                    if (isExist == null)
                    {
                        AirBusMSCN mscn = new AirBusMSCN()
                                          {
                                              Ata = bus.Ata,
                                              Fleet = bus.Fleet,
                                              Mod = bus.Mod,
                                              MscnNo = bus.MscnNo,
                                              MscnTitle = bus.MscnTitle,
                                              Msn = bus.Msn,
                                              Status = bus.Status
                                          };
                        _context.AirBusMSCNs.Add(mscn);
                    }
                }
            }
            if (importType.Equals("svc", StringComparison.CurrentCultureIgnoreCase))
            {
                _context.SaveChanges();
            }
            //增加系统中取出来剩下的
            results.AddRange(sysResults);
            return results;
        }

        #endregion

    }
}
