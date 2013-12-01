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
    public class AcCategoryRepository : EntityFrameworkIntRepository<AcCategory>, IAcCategoryRepository
    {

        private readonly AcConfigurationDbContext _efContext;

        public AcCategoryRepository(IRepositoryContext context)
            : base(context)
        {
            _efContext = EFContext.Context as AcConfigurationDbContext;
        }
        /// <summary>
        /// 实现对AcCategory的增删改。
        /// 需要添加的AcCategory对象集合
        /// 需要删除的AcCategory的ID集合
        /// 需要更新的AcCategory对象集合
        /// <returns>执行后的更改结果</returns>
        /// </summary>
      public void CommitAcCategory(List<AcCategory> addAcCategorys,  IEnumerable<string> deleteIds,  List<AcCategory> updateAcCategorys)
        {
            AddAcCategorys(addAcCategorys);
            DeleteAcCategorys(deleteIds);
            UpdateAcCategorys(updateAcCategorys);
            _efContext.SaveChanges();
        }

        /// <summary>
        /// 增加AcCategory
        /// </summary>
        /// <param name="addAcCategorys">AcCategory</param>
        private void AddAcCategorys(List<AcCategory> addAcCategorys)
        {
            if (addAcCategorys != null && addAcCategorys.Any())
            {
                addAcCategorys.ForEach(p =>
                    {
                    _efContext.Entry(p).State = EntityState.Added;
                });
            }
        }

        /// <summary>
        /// 删除AcCategory
        /// </summary>
        /// <param name="deleteIds">删除AcCategory</param>
        private void DeleteAcCategorys(IEnumerable<string> deleteIds)
        {
            if (deleteIds != null)
            {
                foreach (string id in deleteIds)
                {
                    AcCategory ac = new AcCategory() {ID = Convert.ToInt32(id)};
                    //附加到DbContext中
                    _efContext.AcCategorys.Attach(ac);
                    //var result = GetAcCategoryById(id);
                    if (ac != null)
                    {
                        _efContext.Entry(ac).State = EntityState.Deleted;
                    }
                }
            }
        }

        /// <summary>
        ///     更新AcCategory
        /// </summary>
        /// <param name="updateAcCategorys">更新的AcCategory</param>
        private void UpdateAcCategorys(List<AcCategory> updateAcCategorys)
        {
            if (updateAcCategorys != null && updateAcCategorys.Any())
            {
                foreach (var updateObj in updateAcCategorys)
                {
                    var obj = GetAcCategoryById(updateObj.ID.ToString());
                    if (obj != null)
                    {
                        _efContext.AcCategorys.Attach(obj);
                        obj.Guid = !updateObj.Guid.Equals(new Guid()) ? updateObj.Guid : Guid.NewGuid();
                        obj.Level = updateObj.Level;
                        obj.Regional = updateObj.Regional;
                    }
                }
            }
        }

        /// <summary>
        ///     根据AcCategoryID获取AcCategory
        /// </summary>
        /// <param name="id">AcCategory主键</param>
        /// <returns>AcCategory</returns>
        private AcCategory GetAcCategoryById(string id)
        {
            int value = Convert.ToInt32(id);
            return _efContext == null ? null : _efContext.AcCategorys.FirstOrDefault(p => p.ID == value);
        }
    }
}
