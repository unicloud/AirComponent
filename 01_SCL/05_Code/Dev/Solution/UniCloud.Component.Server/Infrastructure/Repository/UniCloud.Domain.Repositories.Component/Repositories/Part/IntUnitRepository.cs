using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Model;
using UniCloud.Domain.Repositories.EntityFramework;

namespace UniCloud.Domain.Repositories.Repositories
{
    public class IntUnitRepository : EntityFrameworkIntRepository<IntUnit>, IIntUnitRepository
    {
        private readonly ComponentDbContext _efContext;

        public IntUnitRepository(IRepositoryContext context)
            : base(context)
        {
            _efContext = EFContext.Context as ComponentDbContext;
        }
        /// <summary>
        /// 实现对IntUnit的增删改。
        /// 需要添加的IntUnit对象集合
        /// 需要删除的IntUnit的ID集合
        /// 需要更新的IntUnit对象集合
        /// <returns>执行后的更改结果</returns>
        /// </summary>
      public void CommitIntUnit(List<IntUnit> addIntUnits,  IEnumerable<string> deleteIds,  List<IntUnit> updateIntUnits)
        {
            AddIntUnits(addIntUnits);
            DeleteIntUnits(deleteIds);
            UpdateIntUnits(updateIntUnits);
            _efContext.SaveChanges();
        }

        /// <summary>
        /// 增加IntUnit
        /// </summary>
        /// <param name="addIntUnits">IntUnit</param>
        private void AddIntUnits(List<IntUnit> addIntUnits)
        {
            if (addIntUnits != null && addIntUnits.Any())
            {
                addIntUnits.ForEach(p =>
                {
                    _efContext.Entry(p).State = EntityState.Added;
                });
            }
        }

        /// <summary>
        /// 删除IntUnit
        /// </summary>
        /// <param name="deleteIds">删除IntUnit</param>
        private void DeleteIntUnits(IEnumerable<string> deleteIds)
        {
            if (deleteIds != null)
            {
                foreach (string id in deleteIds)
                {
                    var result = GetIntUnitById(id);
                    if (result != null)
                    {
                        _efContext.Entry(result).State = EntityState.Deleted;
                    }
                }
            }
        }

        /// <summary>
        ///     更新IntUnit
        /// </summary>
        /// <param name="updateIntUnits">更新的IntUnit</param>
        private void UpdateIntUnits(List<IntUnit> updateIntUnits)
        {
            if (updateIntUnits != null && updateIntUnits.Any())
            {
                foreach (var updateObj in updateIntUnits)
                {
                    var obj = GetIntUnitById(updateObj.ID.ToString());
                    if (obj != null)
                    {
                        _efContext.IntUnits.Attach(obj);
                        obj.Unit = updateObj.Unit;
                        obj.Descritption = updateObj.Descritption;
                        obj.Type = updateObj.Type;
                        obj.ShortName = updateObj.ShortName;
                    }
                }
            }
        }

        /// <summary>
        ///     根据IntUnitID获取IntUnit
        /// </summary>
        /// <param name="id">IntUnit主键</param>
        /// <returns>IntUnit</returns>
        private IntUnit GetIntUnitById(string id)
        {
            var value = Convert.ToInt32(id);
            return _efContext == null ? null : _efContext.IntUnits.FirstOrDefault(p => p.ID== value);
        }
    }
}
