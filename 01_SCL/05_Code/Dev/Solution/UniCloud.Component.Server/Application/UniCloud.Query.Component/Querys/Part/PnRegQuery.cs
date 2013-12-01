#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/17 23:23:10

// 文件名：PnRegQuery
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
    /// 表示用于PnReg的查询接口。
    /// </summary>
    public class PnRegQuery : IPnRegQuery
    {
        private readonly ComponentDbContext _context;

        public PnRegQuery(IUniCloudDbContext context)
        {
            _context = context as ComponentDbContext;
        }

        #region Query PnReg

        /// <summary>
        /// 获取所有PnReg
        /// </summary>
        /// <returns>所有的PnReg。</returns>
        public PnRegDataObjectList GetPnRegs(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            Expression<Func<PnReg, bool>> source = p => true;
            return GetPnRegList(source);
        }

        /// <summary>
        /// 获取所有PnReg分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的PnReg分页信息。</returns>
        public PnRegWithPagination GetPnRegWithPagination(Pagination pagination, bool isEngPart)
        {
            Expression<Func<PnReg, bool>> wherePredicate = p => true;
            if (isEngPart)
            {
                wherePredicate = p => p.PnClass == "ENG";
            }
            Expression<Func<PnReg, dynamic>> sortPredicate = t => t.ID;
            return GetPnRegPage(wherePredicate, sortPredicate, pagination);
        }

        /// <summary>
        /// 通过PnRegId获取相应的PnReg
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PnRegDataObject GetPnRegByID(int id)
        {
            Expression<Func<PnReg, bool>> source = p => p.ID == id;
            var result = GetPnRegList(source);
            return result == null ? null : result.FirstOrDefault();
        }

        #endregion

        #region Common Query

        private PnRegDataObjectList GetPnRegList(Expression<Func<PnReg, bool>> source)
        {
            var queryResult = (_context.PnRegs.Where(source).Select(mapper)).ToList();
            if (!queryResult.Any()) return new PnRegDataObjectList();
            var transferResult = new PnRegDataObjectList();
            queryResult.ForEach(transferResult.Add);
            return transferResult;
        }

        Expression<Func<PnReg, PnRegDataObject>> mapper = t => new PnRegDataObject
        {
            Pn = t.Pn,
            PnClass = t.PnClass,
            Ata = t.Ata,
            Vendor = t.Vendor,
            UpdateTime = t.UpdateTime,
            Updateby = t.Updateby,
            State = t.State,
            SpecPn = t.SpecPn,
            IsLife = t.IsLife,
            Description = t.Description,
            TrainRate = t.TrainRate,
            EGTLimit = t.EGTLimit,
            AOC3 = t.AOC3,
            AOC7 = t.AOC7,
            IOC = t.IOC,
            IOCA = t.IOCA,
            ID = t.ID,
        };

        private PnRegWithPagination GetPnRegPage(Expression<Func<PnReg, bool>> wherePredicate,
                   Expression<Func<PnReg, dynamic>> sortPredicate,
                   Pagination pagination)
        {

            var PnRegResult = _context.LoadPageDataObjects<PnReg, PnRegDataObject>(wherePredicate, sortPredicate, pagination, mapper);
            if (PnRegResult == null) return null;
            pagination.TotalPages = PnRegResult.TotalPages;
            var PnRegWithPagination = new PnRegWithPagination
               {
                   Pagination = pagination,
                   BaseDataObjectList = new BaseDataObjectList<PnRegDataObject>()
               };
            foreach (var value in PnRegResult.Data)
            {
                PnRegWithPagination.BaseDataObjectList.Add(value);
            }
            return PnRegWithPagination;
        }

        #endregion

        public PnRegDataObject GetPnRegByPn(string pn)
        {

            Expression<Func<PnReg, bool>> source = p => pn.Trim().Equals(p.Pn);
            var result = GetPnRegList(source);
            return result == null ? null : result.FirstOrDefault();
        }

        /// <summary>
        /// 查询以某字符开头的10个PN名值对
        /// </summary>
        /// <param name="pn"></param>
        /// <returns></returns>
        public KeyValueDataObjectList QueryPnregCol(string pn)
        {
            KeyValueDataObjectList results = new KeyValueDataObjectList();
            var queryResults = _context.PnRegs.Where(p => p.Pn.StartsWith(pn)).OrderBy(p => p.Pn)
                .Take(10).Select(t => new KeyValueDataObject()
                      {
                          IntKey = t.ID,
                          Name = t.Pn
                      }).ToList();
            if (queryResults.Any())
            {
                queryResults.ForEach(results.Add);
            }
            return results;
        }

        public PnRegWithPagination GetEngPnOilWithPagination(Pagination pagination)
        {
            Expression<Func<PnReg, bool>> wherePredicate = p => p.PnClass == "ENG" || p.PnClass == "APU";
            Expression<Func<PnReg, dynamic>> sortPredicate = t => t.ID;
            return GetPnRegPage(wherePredicate, sortPredicate, pagination);
        }
    }
}
