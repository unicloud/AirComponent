#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/19 15:38:44

// 文件名：AcStructureQuery
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
    /// 表示用于AcStructure的查询接口。
    /// </summary>
    public class AcStructureQuery : IAcStructureQuery
    {
        private readonly ComponentDbContext _context;

        public AcStructureQuery(IUniCloudDbContext context)
        {
            _context = context as ComponentDbContext;
        }

        #region Query AcStructure

        /// <summary>
        /// 获取所有AcStructure
        /// </summary>
        /// <returns>所有的AcStructure。</returns>
        public AcStructureDataObjectList GetAcStructures(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            Expression<Func<AcStructure, bool>> source = p => true;
            return GetAcStructureList(source);
        }

        /// <summary>
        /// 获取所有AcStructure分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的AcStructure分页信息。</returns>
        public AcStructureWithPagination GetAcStructureWithPagination(Pagination pagination)
        {
            Expression<Func<AcStructure, bool>> wherePredicate = p => true;
            Expression<Func<AcStructure, dynamic>> sortPredicate = t => t.ID;
            return GetAcStructurePage(wherePredicate, sortPredicate, pagination);
        }

        /// <summary>
        /// 通过AcStructureId获取相应的AcStructure
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AcStructureDataObject GetAcStructureByID(int id)
        {
            Expression<Func<AcStructure, bool>> source = p => p.ID == id;
            var result = GetAcStructureList(source).FirstOrDefault();
            if (result != null)
            {
                var docs =
                    _context.AttactDocuments.Where(
                        a => a.BusinessID == result.ID && a.Business.ToLower() == "acstructure")
                        .Select(p => new AttactDocumentDataObject
                        {
                            Business = p.Business,
                            BusinessID = p.BusinessID,
                            DocumentID = p.DocumentID,
                            DocumentType = p.DocumentType,
                            ExtendType = p.ExtendType,
                            FileName = p.FileName,
                            Uploader = p.Uploader,
                            ID = p.ID,
                            UploadTime = p.UploadTime
                        }).ToList();
                result.AttactDocuments.AddRange(docs);
            }
            return result;
        }

        #endregion

        #region Common Query

        private AcStructureDataObjectList GetAcStructureList(Expression<Func<AcStructure, bool>> source)
        {
            var queryResult = (_context.AcStructures.Where(source).Select(t => new AcStructureDataObject()
               {
                   Actype = t.Actype,
                   Acmodel = t.Acmodel,
                   ReportNo = t.ReportNo,
                   ReportType = t.ReportType,
                   ReportDate = t.ReportDate,
                   Description = t.Description,
                   IsDefer = t.IsDefer,
                   Acreg = t.Acreg,
                   TecAss = t.TecAss,
                   TreatResult = t.TreatResult,
                   Status = t.Status,
                   CloseDate = t.CloseDate,
                   Source = t.Source,
                   Level = t.Level,
                   RepairDeadline = t.RepairDeadline,
                   ID = t.ID,
               })).ToList();
            if (!queryResult.Any()) return new AcStructureDataObjectList();
            var transferResult = new AcStructureDataObjectList();
            queryResult.ForEach(transferResult.Add);
            return transferResult;
        }

        private AcStructureWithPagination GetAcStructurePage(Expression<Func<AcStructure, bool>> wherePredicate,
                   Expression<Func<AcStructure, dynamic>> sortPredicate,
                   Pagination pagination)
        {
            Expression<Func<AcStructure, AcStructureDataObject>> mapper = t => new AcStructureDataObject
               {
                   Actype = t.Actype,
                   Acmodel = t.Acmodel,
                   ReportNo = t.ReportNo,
                   ReportType = t.ReportType,
                   ReportDate = t.ReportDate,
                   Description = t.Description,
                   IsDefer = t.IsDefer,
                   Acreg = t.Acreg,
                   TecAss = t.TecAss,
                   TreatResult = t.TreatResult,
                   Status = t.Status,
                   CloseDate = t.CloseDate,
                   Source = t.Source,
                   Level = t.Level,
                   RepairDeadline = t.RepairDeadline,
                   ID = t.ID,
               };
            var AcStructureResult = _context.LoadPageDataObjects<AcStructure, AcStructureDataObject>(wherePredicate, sortPredicate, pagination, mapper);
            if (AcStructureResult == null) return null;
            pagination.TotalPages = AcStructureResult.TotalPages;
            var AcStructureWithPagination = new AcStructureWithPagination
               {
                   Pagination = pagination,
                   BaseDataObjectList = new BaseDataObjectList<AcStructureDataObject>()
               };
            foreach (var value in AcStructureResult.Data)
            {
                AcStructureWithPagination.BaseDataObjectList.Add(value);
            }
            return AcStructureWithPagination;
        }

        #endregion

    }
}
