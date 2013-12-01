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
    public class SnRegRepository : EntityFrameworkIntRepository<SnReg>,ISnRegRepository
    {
        private readonly ComponentDbContext _efContext;

        public SnRegRepository(IRepositoryContext context)
            : base(context)
        {
            _efContext = EFContext.Context as ComponentDbContext;
        }
        /// <summary>
        /// 实现对SnReg的增删改。
        /// 需要添加的SnReg对象集合
        /// 需要删除的SnReg的ID集合
        /// 需要更新的SnReg对象集合
        /// <returns>执行后的更改结果</returns>
        /// </summary>
        public void CommitSnReg( List<SnReg> addSnRegs,  IEnumerable<string> deleteIds,  List<SnReg> updateSnRegs)
        {
            AddSnRegs(addSnRegs);
            DeleteSnRegs(deleteIds);
            UpdateSnRegs(updateSnRegs);
            _efContext.SaveChanges();
        }

        /// <summary>
        /// 增加SnReg
        /// </summary>
        /// <param name="addSnRegs">SnReg</param>
        private void AddSnRegs(List<SnReg> addSnRegs)
        {
            if (addSnRegs != null && addSnRegs.Any())
            {
                addSnRegs.ForEach(p =>
                {
                    _efContext.Entry(p).State = EntityState.Added;
                });
            }
        }

        /// <summary>
        /// 删除SnReg
        /// </summary>
        /// <param name="deleteIds">删除SnReg</param>
        private void DeleteSnRegs(IEnumerable<string> deleteIds)
        {
            if (deleteIds != null)
            {
                foreach (var id in deleteIds)
                {
                    var result = GetSnRegById(id);
                    if (result != null)
                    {
                        _efContext.Entry(result).State = EntityState.Deleted;
                    }
                }
            }
        }

        /// <summary>
        ///     更新SnReg
        /// </summary>
        /// <param name="updateSnRegs">更新的SnReg</param>
        private void UpdateSnRegs(List<SnReg> updateSnRegs)
        {
            if (updateSnRegs != null && updateSnRegs.Any())
            {
                foreach (var updateObj in updateSnRegs)
                {
                    var obj = GetSnRegById(updateObj.ID.ToString());
                    if (obj != null)
                    {
                        _efContext.SnRegs.Attach(obj);
                       
                        obj.PnRegID = updateObj.PnRegID;
                        obj.Sn = updateObj.Sn;
                        obj.Ac = updateObj.Ac;                        
                        obj.Ata = updateObj.Ata;
                        obj.EngineTli = updateObj.EngineTli;
                        obj.Position = updateObj.Position;
                        obj.InstallDate = updateObj.InstallDate;
                        obj.Note = updateObj.Note;
                        obj.Avail = updateObj.Avail;
                        obj.NhSnRegID = updateObj.NhSnRegID;
                        obj.RootSnRegID = updateObj.RootSnRegID;
                        obj.Zone = updateObj.Zone;
                        obj.SyncAMASIS = updateObj.SyncAMASIS;
                    }
                }
            }
        }

        /// <summary>
        ///     根据SnRegID获取SnReg
        /// </summary>
        /// <param name="id">SnReg主键</param>
        /// <returns>SnReg</returns>
        private SnReg GetSnRegById(string id)
        {
            var value = Convert.ToInt32(id);
            return _efContext == null ? null : _efContext.SnRegs.FirstOrDefault(p => p.ID == value);
        }
    }
}
