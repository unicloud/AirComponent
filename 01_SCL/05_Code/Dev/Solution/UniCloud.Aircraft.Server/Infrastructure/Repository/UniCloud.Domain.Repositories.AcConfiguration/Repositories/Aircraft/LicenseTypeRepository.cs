using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Model;
using UniCloud.Domain.Repositories;
using UniCloud.Domain.Repositories.EntityFramework;

namespace UniCloud.Domain.Repositories.Repositories
{
    public class LicenseTypeRepository : EntityFrameworkIntRepository<LicenseType>, ILicenseTypeRepository
    {
        private readonly AcConfigurationDbContext _efContext;

        public LicenseTypeRepository(IRepositoryContext context)
            : base(context)
        {
            _efContext = EFContext.Context as AcConfigurationDbContext;
        }

        /// <summary>
        /// 实现对LicenseType的增删改。
        /// 需要添加的LicenseType对象集合
        /// 需要删除的LicenseType的ID集合
        /// 需要更新的LicenseType对象集合
        /// <returns>执行后的更改结果</returns>
        /// </summary>
      public void CommitLicenseType(List<LicenseType> addLicenseTypes,  IEnumerable<string> deleteIds,  List<LicenseType> updateLicenseTypes)
        {
            AddLicenseTypes(addLicenseTypes);
            DeleteLicenseTypes(deleteIds);
            UpdateLicenseTypes(updateLicenseTypes);
            _efContext.SaveChanges();
        }

        /// <summary>
        /// 增加LicenseType
        /// </summary>
        /// <param name="addLicenseTypes">LicenseType</param>
        private void AddLicenseTypes(List<LicenseType> addLicenseTypes)
        {
            if (addLicenseTypes != null && addLicenseTypes.Any())
            {
                addLicenseTypes.ForEach(p =>
                {
                    _efContext.Entry(p).State = EntityState.Added;
                });
            }
        }

        /// <summary>
        /// 删除LicenseType
        /// </summary>
        /// <param name="deleteIds">删除LicenseType</param>
        private void DeleteLicenseTypes(IEnumerable<string> deleteIds)
        {
            if (deleteIds != null)
            {
                foreach (string id in deleteIds)
                {
                    var result = GetLicenseTypeById(id);
                    if (result != null)
                    {
                        _efContext.Entry(result).State = EntityState.Deleted;
                    }
                }
            }
        }

        /// <summary>
        ///     更新LicenseType
        /// </summary>
        /// <param name="updateLicenseTypes">更新的LicenseType</param>
        private void UpdateLicenseTypes(List<LicenseType> updateLicenseTypes)
        {
            if (updateLicenseTypes != null && updateLicenseTypes.Any())
            {
                foreach (var updateObj in updateLicenseTypes)
                {
                    var obj = GetLicenseTypeById(updateObj.ID.ToString());
                    if (obj != null)
                    {
                        _efContext.LicenseTypes.Attach(obj);
                        obj.Guid = !updateObj.Guid.Equals(new Guid()) ? updateObj.Guid : Guid.NewGuid();
                        obj.Description = updateObj.Description;
                        obj.HasFile = updateObj.HasFile;
                    }
                }
            }
        }

        /// <summary>
        ///     根据LicenseTypeID获取LicenseType
        /// </summary>
        /// <param name="id">LicenseType主键</param>
        /// <returns>LicenseType</returns>
        private LicenseType GetLicenseTypeById(string id)
        {
            int value = Convert.ToInt32(id);
            return _efContext == null ? null : _efContext.LicenseTypes.FirstOrDefault(p => p.ID== value);
        }
    }
}
