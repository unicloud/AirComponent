#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/18 11:52:26

// 文件名：AdsbComplyQuery
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
using UniCloud.Domain.Specifications;
using UniCloud.Domain.Repositories.EntityFramework;

namespace UniCloud.Query
{
    /// <summary>
    /// 表示用于AdsbComply的查询接口。
    /// </summary>
    public class AdsbComplyQuery : IAdsbComplyQuery
    {
        private readonly ComponentDbContext _context;

        public AdsbComplyQuery(IUniCloudDbContext context)
        {
            _context = context as ComponentDbContext;
        }

        #region Query AdsbComply

        /// <summary>
        /// 获取所有AdsbComply
        /// </summary>
        /// <returns>所有的AdsbComply。</returns>
        public AdsbComplyDataObjectList GetAdsbComplys(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            Expression<Func<AdsbComply, bool>> source = p => true;
            return GetAdsbComplyList(source);
        }

        /// <summary>
        /// 获取所有AdsbComply分页信息
        /// </summary>
        /// <param name="isAD">Null:取全部 True:取AD   False:取SB</param>
        /// <param name="pagination"></param>
        /// <returns>所有的AdsbComply分页信息。</returns>
        public AdsbComplyWithPagination GetAdsbComplyWithPagination(bool? isAD, Pagination pagination)
        {
            Expression<Func<AdsbComply, bool>> wherePredicate = p => true;
            if (isAD.HasValue)
            {
                if (isAD.Value)
                {
                    wherePredicate = wherePredicate.And(p => p.FileType.Contains("AD"));
                }
                else
                {
                    wherePredicate = wherePredicate.And(p => !p.FileType.Contains("AD"));
                }
            }
            Expression<Func<AdsbComply, dynamic>> sortPredicate = t => t.ComplyDate;
            return GetAdsbComplyPage(wherePredicate, sortPredicate, pagination);
        }

        /// <summary>
        /// 通过AdsbComplyId获取相应的AdsbComply
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AdsbComplyDataObject GetAdsbComplyByID(int id)
        {
            Expression<Func<AdsbComply, bool>> source = p => p.ID == id;
            var result = GetAdsbComplyList(source);
            return result == null ? null : result.FirstOrDefault();
        }

        #endregion

        #region Common Query

        private AdsbComplyDataObjectList GetAdsbComplyList(Expression<Func<AdsbComply, bool>> source)
        {
            var queryResult = (_context.AdsbComplys.Where(source).Select(t => new AdsbComplyDataObject()
               {
                   Actype = t.Actype,
                   FileType = t.FileType,
                   FileNo = t.FileNo,
                   FileVersion = t.FileVersion,
                   ComplyAc = t.ComplyAc,
                   ComplyStatus = t.ComplyStatus,
                   ComplyDate = t.ComplyDate,
                   ComplyNotes = t.ComplyNotes,
                   ComplyClose = t.ComplyClose,
                   ComFee = t.ComFee,
                   ComFeeNotes = t.ComFeeNotes,
                   ComFeeCurrency = t.ComFeeCurrency,
                   AdsbID = t.AdsbID,
                   ID = t.ID,
               })).ToList();
            if (!queryResult.Any()) return new AdsbComplyDataObjectList();
            var transferResult = new AdsbComplyDataObjectList();
            queryResult.ForEach(transferResult.Add);
            return transferResult;
        }

        private AdsbComplyWithPagination GetAdsbComplyPage(Expression<Func<AdsbComply, bool>> wherePredicate,
                   Expression<Func<AdsbComply, dynamic>> sortPredicate,
                   Pagination pagination)
        {
            Expression<Func<AdsbComply, AdsbComplyDataObject>> mapper = t => new AdsbComplyDataObject
               {
                   Actype = t.Actype,
                   FileType = t.FileType,
                   FileNo = t.FileNo,
                   FileVersion = t.FileVersion,
                   ComplyAc = t.ComplyAc,
                   ComplyStatus = t.ComplyStatus,
                   ComplyDate = t.ComplyDate,
                   ComplyNotes = t.ComplyNotes,
                   ComplyClose = t.ComplyClose,
                   ComFee = t.ComFee,
                   ComFeeNotes = t.ComFeeNotes,
                   ComFeeCurrency = t.ComFeeCurrency,
                   AdsbID = t.AdsbID,
                   ID = t.ID,
               };
            var AdsbComplyResult = _context.LoadPageDataObjects<AdsbComply, AdsbComplyDataObject>(wherePredicate, sortPredicate, pagination, mapper, SortOrder.Descending);
            if (AdsbComplyResult == null) return null;
            pagination.TotalPages = AdsbComplyResult.TotalPages;
            var AdsbComplyWithPagination = new AdsbComplyWithPagination
               {
                   Pagination = pagination,
                   BaseDataObjectList = new BaseDataObjectList<AdsbComplyDataObject>()
               };
            foreach (var value in AdsbComplyResult.Data)
            {
                AdsbComplyWithPagination.BaseDataObjectList.Add(value);
            }
            return AdsbComplyWithPagination;
        }

        #endregion

    }
}
