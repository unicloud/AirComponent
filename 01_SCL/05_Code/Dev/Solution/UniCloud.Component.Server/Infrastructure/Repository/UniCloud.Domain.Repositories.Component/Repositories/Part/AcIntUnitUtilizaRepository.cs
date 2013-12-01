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
    public class AcIntUnitUtilizaRepository : EntityFrameworkIntRepository<AcIntUnitUtiliza>, IAcIntUnitUtilizaRepository
    {
        private readonly ComponentDbContext _efContext;
        //private readonly AircraftDbContext _acContext;

        public AcIntUnitUtilizaRepository(IRepositoryContext context)
            : base(context)
        {
            _efContext = EFContext.Context as ComponentDbContext;
            //_acContext = EFContext.Context as AircraftDbContext;
        }
        /// <summary>
        /// 实现对AcIntUnitUtiliza的增删改。
        /// 需要添加的AcIntUnitUtiliza对象集合
        /// 需要删除的AcIntUnitUtiliza的ID集合
        /// 需要更新的AcIntUnitUtiliza对象集合
        /// <returns>执行后的更改结果</returns>
        /// </summary>
        public void CommitAcIntUnitUtiliza(List<AcIntUnitUtiliza> addIntUnits, IEnumerable<string> deleteIds, List<AcIntUnitUtiliza> updateIntUnits)
        {
            AddAcIntUnitUtilizas(addIntUnits);
            DeleteAcIntUnitUtilizas(deleteIds);
            UpdateAcIntUnitUtilizas(updateIntUnits);
            _efContext.SaveChanges();
        }

        /// <summary>
        /// 获取飞机以及相关的利用率
        /// </summary>
        /// <returns></returns>
        public List<AcIntUnitUtiliza> GetAcIntUnitUtilizas()
        {
            var queryResult = (_efContext.AcIntUnitUtilizas).ToList();
            if (!queryResult.Any()) return new List<AcIntUnitUtiliza>();
            var transferResult = new List<AcIntUnitUtiliza>();
            queryResult.ForEach(transferResult.Add);
            return transferResult;
        }
        


        /// <summary>
        /// 增加IntUnit
        /// </summary>
        /// <param name="addIntUnits">IntUnit</param>
        private void AddAcIntUnitUtilizas(List<AcIntUnitUtiliza> addAcIntUnitUtilizas)
        {
            if (addAcIntUnitUtilizas != null && addAcIntUnitUtilizas.Any())
            {
                addAcIntUnitUtilizas.ForEach(p =>
                {
                    _efContext.Entry(p).State = EntityState.Added;
                });
            }
        }

        /// <summary>
        /// 删除IntUnit
        /// </summary>
        /// <param name="deleteIds">删除IntUnit</param>
        private void DeleteAcIntUnitUtilizas(IEnumerable<string> deleteIds)
        {
            if (deleteIds != null)
            {
                foreach (string id in deleteIds)
                {
                    var result = GetAcIntUnitUtilizaById(id);
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
        private void UpdateAcIntUnitUtilizas(List<AcIntUnitUtiliza> updateAcIntUnitUtilizas)
        {
            if (updateAcIntUnitUtilizas != null && updateAcIntUnitUtilizas.Any())
            {
                foreach (var updateObj in updateAcIntUnitUtilizas)
                {
                    var obj = GetAcIntUnitUtilizaById(updateObj.ID.ToString());
                    if (obj != null)
                    {
                        _efContext.AcIntUnitUtilizas.Attach(obj);
                        obj.Unit = updateObj.Unit;
                        obj.AcReg = updateObj.AcReg;
                        obj.Msn = updateObj.Msn;
                        obj.Utiliza = updateObj.Utiliza;
                        obj.UtilizaRate = updateObj.UtilizaRate;
                    }
                }
            }
        }

        /// <summary>
        ///     根据IntUnitID获取IntUnit
        /// </summary>
        /// <param name="id">IntUnit主键</param>
        /// <returns>IntUnit</returns>
        private AcIntUnitUtiliza GetAcIntUnitUtilizaById(string id)
        {
            var value = Convert.ToInt32(id);
            return _efContext == null ? null : _efContext.AcIntUnitUtilizas.FirstOrDefault(p => p.ID == value);
        }


    }
}
