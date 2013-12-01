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
    public class OilHistoryRepository : EntityFrameworkIntRepository<OilHistory> , IOilHistoryRepository
    {
        private readonly ComponentDbContext _efContext;

        public OilHistoryRepository(IRepositoryContext context)
            : base(context)
        {
            _efContext = EFContext.Context as ComponentDbContext;
        }
        /// <summary>
        /// 实现对OilHistory的增删改。
        /// 需要添加的OilHistory对象集合
        /// 需要删除的OilHistory的ID集合
        /// 需要更新的OilHistory对象集合
        /// <returns>执行后的更改结果</returns>
        /// </summary>
      public void CommitOilHistory(List<OilHistory> addOilHistorys,  IEnumerable<string> deleteIds,  List<OilHistory> updateOilHistorys)
        {
            AddOilHistorys(addOilHistorys);
            DeleteOilHistorys(deleteIds);
            UpdateOilHistorys(updateOilHistorys);
            _efContext.SaveChanges();
        }

        /// <summary>
        /// 增加OilHistory
        /// </summary>
        /// <param name="addOilHistorys">OilHistory</param>
        private void AddOilHistorys(List<OilHistory> addOilHistorys)
        {
            if (addOilHistorys != null && addOilHistorys.Any())
            {
                addOilHistorys.ForEach(p =>
                {
                    _efContext.Entry(p).State = EntityState.Added;
                });
            }
        }

        /// <summary>
        /// 删除OilHistory
        /// </summary>
        /// <param name="deleteIds">删除OilHistory</param>
        private void DeleteOilHistorys(IEnumerable<string> deleteIds)
        {
            if (deleteIds != null)
            {
                foreach (string id in deleteIds)
                {
                    var result = GetOilHistoryById(id);
                    if (result != null)
                    {
                        _efContext.Entry(result).State = EntityState.Deleted;
                    }
                }
            }
        }

        /// <summary>
        ///     更新OilHistory
        /// </summary>
        /// <param name="updateOilHistorys">更新的OilHistory</param>
        private void UpdateOilHistorys(List<OilHistory> updateOilHistorys)
        {
            if (updateOilHistorys != null && updateOilHistorys.Any())
            {
                foreach (var updateObj in updateOilHistorys)
                {
                    var obj = GetOilHistoryById(updateObj.ID.ToString());
                    if (obj != null)
                    {
                        _efContext.OilHistorys.Attach(obj);
                        obj.AcReg = updateObj.AcReg;
                        obj.Msn = updateObj.Msn;
                        obj.FlightDate = updateObj.FlightDate;
                        obj.FlLogno = updateObj.FlLogno;
                        obj.FlLegno = updateObj.FlLegno;
                        obj.UpliftDer = updateObj.UpliftDer;
                        obj.UpliftArr = updateObj.UpliftArr;
                        obj.Pn = updateObj.Pn;
                        obj.Sn = updateObj.Sn;
                        obj.Ata = updateObj.Ata;
                        obj.Zone = updateObj.Zone;
                        obj.Position = updateObj.Position;
                        obj.Tsn = updateObj.Tsn;
                        obj.Csn = updateObj.Csn;
                        obj.Fh = updateObj.Fh;
                        obj.Cy = updateObj.Cy;
                        obj.UpdateDate = updateObj.UpdateDate;
                        obj.Notes = updateObj.Notes;
                    }
                }
            }
        }

        /// <summary>
        ///     根据OilHistoryID获取OilHistory
        /// </summary>
        /// <param name="id">OilHistory主键</param>
        /// <returns>OilHistory</returns>
        private OilHistory GetOilHistoryById(string id)
        {
            var value = Convert.ToInt32(id);
            return _efContext == null ? null : _efContext.OilHistorys.FirstOrDefault(p => p.ID == value);
        }
    }
}
