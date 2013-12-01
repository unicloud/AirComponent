#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/9/22 0:10:28
* 文件名：Aircraft
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

namespace UniCloud.Query.AcConfiguration
{
    public class AircraftQuery : IAircraftQuery
    {
        private readonly AcConfigurationDbContext _context;

        private IAcCategoryQuery _acCategoryQuery;
        private IAcRegQuery _acRegQuery;
        private IAcTypeQuery _acTypeQuery;
        private IAtaQuery _ataQuery;
        private ILicenseTypeQuery _licenseTypeQuery;

        public AircraftQuery(IUniCloudDbContext context)
        {
            _acCategoryQuery = new AcCategoryQuery(context);
            _acRegQuery = new AcRegQuery(context);
            _acTypeQuery = new AcTypeQuery(context);
            _ataQuery = new AtaQuery(context);
            _licenseTypeQuery = new LicenseTypeQuery(context);
            _context = context as AcConfigurationDbContext;
        }

        #region 其它接口
        public AcCategoryDataObjectList GetAcCategorys()
        {
            return _acCategoryQuery.GetAcCategorys();
        }

        public AcCategoryWithPagination GetAcCategoryWithPagination(Pagination pagination)
        {
            return _acCategoryQuery.GetAcCategoryWithPagination(pagination);
        }

        public AcCategoryDataObject GetAcCategoryByID(int id)
        {
            return _acCategoryQuery.GetAcCategoryByID(id);
        }

        public AcRegDataObjectList GetAcRegs()
        {
            return _acRegQuery.GetAcRegs();
        }

        public AcRegWithPagination GetAcRegWithPagination(Pagination pagination)
        {
            return _acRegQuery.GetAcRegWithPagination(pagination);
        }

        public AcRegDataObject GetAcRegByID(int id)
        {
            return _acRegQuery.GetAcRegByID(id);
        }

        public AcTypeDataObjectList GetAcTypes()
        {
            return _acTypeQuery.GetAcTypes();
        }

        public AcTypeWithPagination GetAcTypeWithPagination(Pagination pagination)
        {
            return _acTypeQuery.GetAcTypeWithPagination(pagination);
        }

        public AcTypeDataObject GetAcTypeByID(int id)
        {
            return _acTypeQuery.GetAcTypeByID(id);
        }

        public AtaDataObjectList GetAtas()
        {
            return _ataQuery.GetAtas();
        }

        public AtaWithPagination GetAtaWithPagination(Pagination pagination)
        {
            return _ataQuery.GetAtaWithPagination(pagination);
        }

        public AtaDataObject GetAtaByID(int id)
        {
            return _ataQuery.GetAtaByID(id);
        }

        public LicenseTypeDataObjectList GetLicenseTypes()
        {
            return _licenseTypeQuery.GetLicenseTypes();
        }

        public LicenseTypeWithPagination GetLicenseTypeWithPagination(Pagination pagination)
        {
            return _licenseTypeQuery.GetLicenseTypeWithPagination(pagination);
        }

        public LicenseTypeDataObject GetLicenseTypeByID(int id)
        {
            return _licenseTypeQuery.GetLicenseTypeByID(id);
        }
        #endregion

        #region IAircraftQuery
        public AcModelDataObjectList GetAcModels()
        {
            var queryResult = (_context.AcModels.Select(t => new AcModelDataObject()
            {
                Guid = t.Guid,
                AcTypeID = t.AcTypeID,
                AcTypeGuid = t.AcTypeGuid,
                Description=t.Description,
                Name=t.Name,
                ID = t.ID,
            })).ToList();
            if (!queryResult.Any()) return new AcModelDataObjectList();
            var transferResult = new AcModelDataObjectList();
            queryResult.ForEach(transferResult.Add);
            return transferResult;
        }

        public AcConfigDataObjectList GetAcConfigs()
        {
            var queryResult = (_context.AcConfigs.Select(t => new AcConfigDataObject()
            {
                Guid = t.Guid,
                AcModelGuid=t.AcModelGuid,
                AcModelID=t.AcModelID,
                BEW =t.BEW,
                BW = t.BW,
                BWF = t.BWF,
                BWI = t.BWI,
                MCC =t.MCC,
                MLW =t.MLW,
                MMFW=t.MMFW,
                MTOW =t.MTOW,
                MTW =t.MTW,
                MZFW =t.MZFW,
                Description = t.Description,
                Name = t.Name,
                ID = t.ID,
            })).ToList();
            if (!queryResult.Any()) return new AcConfigDataObjectList();
            var transferResult = new AcConfigDataObjectList();
            queryResult.ForEach(transferResult.Add);
            return transferResult;
        }
        #endregion
    }
}
