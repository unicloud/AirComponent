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
    public class PnRegRepository : EntityFrameworkIntRepository<PnReg>, IPnRegRepository
    {
        private readonly ComponentDbContext _efContext;

        public PnRegRepository(IRepositoryContext context)
            : base(context)
        {
            _efContext = EFContext.Context as ComponentDbContext;
        }
        /// <summary>
        /// 实现对PnReg的增删改。
        /// 需要添加的PnReg对象集合
        /// 需要删除的PnReg的ID集合
        /// 需要更新的PnReg对象集合
        /// <returns>执行后的更改结果</returns>
        /// </summary>
      public void CommitPnReg(List<PnReg> addPnRegs,  IEnumerable<string> deleteIds,  List<PnReg> updatePnRegs)
        {
            AddPnRegs(addPnRegs);
            DeletePnRegs(deleteIds);
            UpdatePnRegs(updatePnRegs);
            _efContext.SaveChanges();
        }

        /// <summary>
        /// 增加PnReg
        /// </summary>
        /// <param name="addPnRegs">PnReg</param>
        private void AddPnRegs(List<PnReg> addPnRegs)
        {
            if (addPnRegs != null && addPnRegs.Any())
            {
                addPnRegs.ForEach(p =>
                {
                    _efContext.Entry(p).State = EntityState.Added;
                });
            }
        }

        /// <summary>
        /// 删除PnReg
        /// </summary>
        /// <param name="deleteIds">删除PnReg</param>
        private void DeletePnRegs(IEnumerable<string> deleteIds)
        {
            if (deleteIds != null)
            {
                foreach (string id in deleteIds)
                {
                    var result = GetPnRegById(id);
                    if (result != null)
                    {
                        _efContext.Entry(result).State = EntityState.Deleted;
                    }
                }
            }
        }

        /// <summary>
        ///     更新PnReg
        /// </summary>
        /// <param name="updatePnRegs">更新的PnReg</param>
        private void UpdatePnRegs(List<PnReg> updatePnRegs)
        {
            if (updatePnRegs != null && updatePnRegs.Any())
            {
                foreach (var updateObj in updatePnRegs)
                {
                    var obj = GetPnRegById(updateObj.ID.ToString());
                    if (obj != null)
                    {
                        _efContext.PnRegs.Attach(obj);
                        obj.Ata = updateObj.Ata;
                        obj.Pn = updateObj.Pn;
                        obj.PnClass = updateObj.PnClass;
                        obj.Vendor = updateObj.Vendor;
                        obj.UpdateTime = updateObj.UpdateTime;
                        obj.Updateby = updateObj.Updateby;
                        obj.SpecPn = updateObj.SpecPn;
                        obj.State = updateObj.State;
                        obj.IsLife = updateObj.IsLife;
                        obj.Description = updateObj.Description;
                        obj.EGTLimit = updateObj.EGTLimit > 0 ? updateObj.EGTLimit : obj.EGTLimit;
                        obj.IOC = updateObj.IOC > 0 ? updateObj.IOC : obj.IOC;
                        obj.AOC3 = updateObj.AOC3 > 0 ? updateObj.AOC3 : obj.AOC3;
                        obj.AOC7 = updateObj.AOC7 > 0 ? updateObj.AOC7 : obj.AOC7;
                        obj.IOCA = updateObj.IOCA > 0 ? updateObj.IOCA : obj.IOCA;
                    }
                }
            }
        }

        /// <summary>
        ///     根据PnRegID获取PnReg
        /// </summary>
        /// <param name="id">PnReg主键</param>
        /// <returns>PnReg</returns>
        private PnReg GetPnRegById(string id)
        {
            var value = Convert.ToInt32(id);
            return _efContext == null ? null : _efContext.PnRegs.FirstOrDefault(p => p.ID== value);
        }


        public IQueryable<PnReg> TakeTop(int count)
        {
            return _efContext.PnRegs.Take(count).OrderByDescending(p => p.ID);
        }
    }
}
