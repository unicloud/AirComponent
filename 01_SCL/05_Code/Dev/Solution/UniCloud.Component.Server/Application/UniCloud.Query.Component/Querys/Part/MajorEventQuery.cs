#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/16 16:16:39

// 文件名：MajorEventQuery
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
    /// 表示用于MajorEvent的查询接口。
    /// </summary>
    public class MajorEventQuery : IMajorEventQuery
    {
        private readonly ComponentDbContext _context;

        public MajorEventQuery(IUniCloudDbContext context)
        {
            _context = context as ComponentDbContext;
        }

        #region Query MajorEvent

        /// <summary>
        /// 获取所有MajorEvent
        /// </summary>
        /// <returns>所有的MajorEvent。</returns>
        public MajorEventDataObjectList GetMajorEvents(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            Expression<Func<MajorEvent, bool>> source = p => true;
            return GetMajorEventList(source);
        }

        /// <summary>
        /// 获取所有MajorEvent分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的MajorEvent分页信息。</returns>
        public MajorEventWithPagination GetMajorEventWithPagination(Pagination pagination)
        {
            Expression<Func<MajorEvent, bool>> wherePredicate = p => true;
            Expression<Func<MajorEvent, dynamic>> sortPredicate = t => t.ID;
            return GetMajorEventPage(wherePredicate, sortPredicate, pagination);
        }

        /// <summary>
        /// 通过MajorEventId获取相应的MajorEvent
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MajorEventDataObject GetMajorEventByID(int id)
        {
            Expression<Func<MajorEvent, bool>> source = p => p.ID == id;
            var result = GetMajorEventList(source).FirstOrDefault();
            if (result != null)
            {
                var docs =
                    _context.AttactDocuments.Where(
                        a => a.BusinessID == result.ID && a.Business.ToLower() == "majorevent")
                        .Select(p => new AttactDocumentDataObject
                                     {
                                         Business=p.Business,
                                         BusinessID=p.BusinessID,
                                         DocumentID=p.DocumentID,
                                         DocumentType=p.DocumentType,
                                         ExtendType=p.ExtendType,
                                         FileName=p.FileName,
                                         Uploader=p.Uploader,
                                         ID=p.ID,
                                         UploadTime=p.UploadTime
                                     }).ToList();
                result.AttactDocuments.AddRange(docs);
            }
            return result;
        }

        #endregion

        #region Common Query

        private MajorEventDataObjectList GetMajorEventList(Expression<Func<MajorEvent, bool>> source)
        {
            var queryResult = (_context.MajorEvents.Where(source).Select(t => new MajorEventDataObject()
               {
                   Ac = t.Ac,
                   Pos = t.Pos,
                   Sn = t.Sn,
                   Description = t.Description,
                   Property = t.Property,
                   CloseReason = t.CloseReason,
                   CloseDate = t.CloseDate,
                   CreateDate = t.CreateDate,
                   ID = t.ID,
               })).ToList();
            if (!queryResult.Any()) return new MajorEventDataObjectList();
            var transferResult = new MajorEventDataObjectList();
            queryResult.ForEach(transferResult.Add);
            return transferResult;
        }

        private MajorEventWithPagination GetMajorEventPage(Expression<Func<MajorEvent, bool>> wherePredicate,
                   Expression<Func<MajorEvent, dynamic>> sortPredicate,
                   Pagination pagination)
        {
            Expression<Func<MajorEvent, MajorEventDataObject>> mapper = t => new MajorEventDataObject
               {
                   Ac = t.Ac,
                   Pos = t.Pos,
                   Sn = t.Sn,
                   Description = t.Description,
                   Property = t.Property,
                   CloseReason = t.CloseReason,
                   CloseDate = t.CloseDate,
                   CreateDate = t.CreateDate,
                   ID = t.ID,
               };
            var MajorEventResult = _context.LoadPageDataObjects<MajorEvent, MajorEventDataObject>(wherePredicate, sortPredicate, pagination, mapper);
            if (MajorEventResult == null) return null;
            pagination.TotalPages = MajorEventResult.TotalPages;
            var MajorEventWithPagination = new MajorEventWithPagination
               {
                   Pagination = pagination,
                   BaseDataObjectList = new BaseDataObjectList<MajorEventDataObject>()
               };
            foreach (var value in MajorEventResult.Data)
            {
                MajorEventWithPagination.BaseDataObjectList.Add(value);
            }
            return MajorEventWithPagination;
        }

        #endregion

    }
}
