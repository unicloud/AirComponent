#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/21 22:36:56

// 文件名：AcTypeQuery
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

namespace UniCloud.Query.AcConfiguration
{
    /// <summary>
    /// 表示用于AcType的查询接口。
    /// </summary>
    public class AcTypeQuery : IAcTypeQuery
    {
        private readonly AcConfigurationDbContext _context;

        public AcTypeQuery(IUniCloudDbContext context)
        {
            _context = context as AcConfigurationDbContext;
        }

        #region Get AcType

        /// <summary>
        /// 获取所有AcType
        /// </summary>
        /// <returns>所有的AcType。</returns>
        public AcTypeDataObjectList GetAcTypes(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            Expression<Func<AcType, bool>> source = p => true;
            return GetAcTypeList(source);
        }

        /// <summary>
        /// 获取所有AcType分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的AcType分页信息。</returns>
        public AcTypeWithPagination GetAcTypeWithPagination(Pagination pagination)
        {
            Expression<Func<AcType, bool>> wherePredicate = p => true;
            Expression<Func<AcType, dynamic>> sortPredicate = t => t.ID;
            return GetAcTypePage(wherePredicate, sortPredicate, pagination);
        }

        /// <summary>
        /// 通过AcTypeId获取相应的AcType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AcTypeDataObject GetAcTypeByID(int id)
        {
            Expression<Func<AcType, bool>> source = p => p.ID == id;
            var result = GetAcTypeList(source);
            return result == null ? null : result.FirstOrDefault();
        }

        /// <summary>
        /// 通过AcTypeId获取相应的AcType
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AcTypeDataObject GetAcTypeByGuid(string id)
        {
            Guid guid = new Guid(id);
            Expression<Func<AcType, bool>> source = p => p.Guid == guid;
            var result = GetAcTypeList(source);
            return result == null ? null : result.FirstOrDefault();
        }
       
        #endregion

        #region AcConfig
        /// <summary>
        /// 获取所有AcConfig
        /// </summary>
        /// <returns>所有的AcConfig。</returns>
        public AcConfigDataObjectList GetAcConfigs(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            Expression<Func<AcConfig, bool>> source = p => true;
            return GetAcConfigList(source);
        }

        public AcConfigDataObject GetAcConfigByID(int Id)
        {
            Expression<Func<AcConfig, bool>> source = p => p.ID == Id;
            var result = GetAcConfigList(source);
            return result == null ? null : result.FirstOrDefault();
        }

        public AcConfigDataObject GetAcConfigByGuid(string Id)
        {
            Guid guid = new Guid(Id);
            Expression<Func<AcConfig, bool>> source = p => p.Guid == guid;
            var result = GetAcConfigList(source);
            return result == null ? null : result.FirstOrDefault();
        }

        public AcConfigDataObjectList GetAcConfigList(Expression<Func<AcConfig, bool>> source)
        {
            var queryResult = (_context.AcConfigs.Where(source).Select(t => new AcConfigDataObject()
            {
                ID = t.ID,
                Guid = t.Guid,
                Name = t.Name,
                Description = t.Description,
                BEW = t.BEW,
                BW = t.BW,
                BWF = t.BWF,
                BWI = t.BWI,
                MCC = t.MCC,
                MLW = t.MLW,
                MMFW = t.MMFW,
                MTOW = t.MTOW,
                MTW = t.MTW,
                MZFW = t.MZFW,
                AcModelID = t.AcModelID,
                AcModelGuid = t.AcModelGuid
            })).ToList();
            if (!queryResult.Any()) return new AcConfigDataObjectList();
            var transferResult = new AcConfigDataObjectList();
            queryResult.ForEach(q =>
            {
                q.AcTypeID = (from a in _context.AcTypes
                              from m in a.Acmodels
                              where m.ID == q.AcModelID
                              select a.ID).FirstOrDefault();
                transferResult.Add(q);
            });
            return transferResult;
        }
        #endregion

        #region AcModel

        /// <summary>
        /// 获取所有AcModel
        /// </summary>
        /// <returns>所有的AcModel。</returns>
        public AcModelDataObjectList GetAcModels(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            Expression<Func<AcModel, bool>> source = p => true;
            return GetAcModelList(source);
        }

        public AcModelDataObject GetAcModelByID(int id)
        {
            Expression<Func<AcModel, bool>> source = p => p.ID == id;
            var result = GetAcModelList(source);
            return result == null ? null : result.FirstOrDefault();
        }

        public AcModelDataObject GetAcModelByGuid(string id)
        {
            Guid guid = new Guid(id);
            Expression<Func<AcModel, bool>> source = p => p.Guid == guid;
            var result = GetAcModelList(source);
            return result == null ? null : result.FirstOrDefault();
        }

        public AcModelDataObjectList GetAcModelList(Expression<Func<AcModel, bool>> source)
        {
            var queryResult = (_context.AcModels.Where(source).Select(t => new AcModelDataObject()
            {
                Guid = t.Guid,
                Name = t.Name,
                Description = t.Description,
                ID = t.ID,
                AcTypeID = t.AcTypeID,
                AcTypeGuid = t.AcTypeGuid
            })).ToList();
            if (!queryResult.Any()) return new AcModelDataObjectList();
            var transferResult = new AcModelDataObjectList();
            queryResult.ForEach(transferResult.Add);
            return transferResult;
        }

        #endregion

        #region Common Get

        private AcTypeDataObjectList GetAcTypeList(Expression<Func<AcType, bool>> source)
        {
            var queryResult = (_context.AcTypes.Where(source).Select(t => new AcTypeDataObject()
               {
                   Guid = t.Guid,
                   Name = t.Name,
                   Description = t.Description,
                   Manufacturer = t.Manufacturer,
                   AcCategory = t.AcCategory,
                   ID = t.ID,
               })).ToList();
            if (!queryResult.Any()) return new AcTypeDataObjectList();
            var transferResult = new AcTypeDataObjectList();
            queryResult.ForEach(transferResult.Add);
            return transferResult;
        }

        private AcTypeWithPagination GetAcTypePage(Expression<Func<AcType, bool>> wherePredicate,
                   Expression<Func<AcType, dynamic>> sortPredicate,
                   Pagination pagination)
        {
            Expression<Func<AcType, AcTypeDataObject>> mapper = t => new AcTypeDataObject
               {
                   Guid = t.Guid,
                   Name = t.Name,
                   Description = t.Description,
                   Manufacturer = t.Manufacturer,
                   AcCategory = t.AcCategory,
                   ID = t.ID,
               };
            var AcTypeResult = _context.LoadPageDataObjects<AcType, AcTypeDataObject>(wherePredicate, sortPredicate, pagination, mapper);
            if (AcTypeResult == null) return null;
            pagination.TotalPages = AcTypeResult.TotalPages;
            var AcTypeWithPagination = new AcTypeWithPagination
               {
                   Pagination = pagination,
                   BaseDataObjectList = new BaseDataObjectList<AcTypeDataObject>()
               };
            foreach (var value in AcTypeResult.Data)
            {
                AcTypeWithPagination.BaseDataObjectList.Add(value);
            }
            return AcTypeWithPagination;
        }

        #endregion

        #region AcTypeDorpDownSource

        /// <summary>
        /// 通过AcType下拉数据集合
        /// </summary>
        /// <param name="colFilter"></param>
        /// <param name="sortFilter"></param>
        /// <returns></returns>
        public KeyValueDataObjectList GetAcTypeCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            var results = new KeyValueDataObjectList();
            var queryResult = (_context.AcTypes.Select(t => new KeyValueDataObject()
               {
                   IntKey = t.ID,
                   Name = t.Name
               })).ToList();
            queryResult.ForEach(results.Add);
            return results;
        }

        /// <summary>
        /// 通过AcConfig下拉数据集合
        /// </summary>
        /// <param name="colFilter"></param>
        /// <param name="sortFilter"></param>
        /// <returns></returns>
        public KeyValueDataObjectList GetAcConfigCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            var results = new KeyValueDataObjectList();
            var queryResult = (_context.AcConfigs.Select(t => new KeyValueDataObject()
            {
                IntKey = t.ID,
                Name = t.Name
            })).ToList();
            queryResult.ForEach(results.Add);
            return results;
        }

        /// <summary>
        /// 通过AcModel下拉数据集合
        /// </summary>
        /// <param name="colFilter"></param>
        /// <param name="sortFilter"></param>
        /// <returns></returns>
        public KeyValueDataObjectList GetAcModelCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            var results = new KeyValueDataObjectList();
            var queryResult = (_context.AcModels.Select(t => new KeyValueDataObject()
            {
                IntKey = t.ID,
                Name = t.Name
            })).ToList();
            queryResult.ForEach(results.Add);
            return results;
        }
        #endregion
    }
}
