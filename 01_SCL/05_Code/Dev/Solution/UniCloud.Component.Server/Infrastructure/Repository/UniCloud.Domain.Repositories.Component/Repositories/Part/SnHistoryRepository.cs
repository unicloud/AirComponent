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
    public class SnHistoryRepository : EntityFrameworkIntRepository<SnHistory>, ISnHistoryRepository
    {
        private readonly ComponentDbContext _efContext;

        public SnHistoryRepository(IRepositoryContext context)
            : base(context)
        {
            _efContext = EFContext.Context as ComponentDbContext;
        }
        /// <summary>
        /// 实现对SnHistory的增删改。
        /// 需要添加的SnHistory对象集合
        /// 需要删除的SnHistory的ID集合
        /// 需要更新的SnHistory对象集合
        /// <returns>执行后的更改结果</returns>
        /// </summary>
      public void CommitSnHistory(List<SnHistory> addSnHistorys,  IEnumerable<string> deleteIds,  List<SnHistory> updateSnHistorys)
        {
            AddSnHistorys(addSnHistorys);
            DeleteSnHistorys(deleteIds);
            UpdateSnHistorys(updateSnHistorys);
            _efContext.SaveChanges();
        }

        /// <summary>
        /// 增加SnHistory
        /// </summary>
        /// <param name="addSnHistorys">SnHistory</param>
        private void AddSnHistorys(List<SnHistory> addSnHistorys)
        {
            if (addSnHistorys != null && addSnHistorys.Any())
            {
                addSnHistorys.ForEach(p =>
                {
                    for (int i = p.SnHistoryUnits.Count - 1; i >= 0; i--)
                    {
                        var snunit = p.SnHistoryUnits.ElementAt(i);
                        _efContext.Entry(snunit).State = EntityState.Added;
                    }
                    _efContext.Entry(p).State = EntityState.Added;
                });
            }
        }

        /// <summary>
        /// 删除SnHistory
        /// </summary>
        /// <param name="deleteIds">删除SnHistory</param>
        private void DeleteSnHistorys(IEnumerable<string> deleteIds)
        {
            if (deleteIds != null)
            {
                foreach (var id in deleteIds)
                {
                    var result = GetSnHistoryById(id);
                    if (result != null)
                    {
                        for (int i = result.SnHistoryUnits.Count - 1; i >= 0; i--)
                        {
                            var snunit = result.SnHistoryUnits.ElementAt(i);
                            _efContext.Entry(snunit).State = EntityState.Deleted;
                        }
                        _efContext.Entry(result).State = EntityState.Deleted;
                    }
                }
            }
        }

        /// <summary>
        ///     更新SnHistory
        /// </summary>
        /// <param name="updateSnHistorys">更新的SnHistory</param>
        private void UpdateSnHistorys(List<SnHistory> updateSnHistorys)
        {
            if (updateSnHistorys != null && updateSnHistorys.Any())
            {
                foreach (var updateObj in updateSnHistorys)
                {
                    var obj = GetSnHistoryById(updateObj.ID.ToString());
                    if (obj != null)
                    {
                        _efContext.SnHistorys.Attach(obj);
                        #region 更新SnHistory内容
                        obj.SnRegID = updateObj.SnRegID;
                        obj.Source = updateObj.Source;                        
                        obj.Active = updateObj.Active;
                        obj.ActiveDate = updateObj.ActiveDate;
                        obj.Position = updateObj.Position;
                        obj.Note = updateObj.Note;
                        obj.Ata = updateObj.Ata;
                        obj.Orderno = updateObj.Orderno;                        
                        #endregion

                        #region 更新SnHistoryUnit内容
                        for (int i = obj.SnHistoryUnits.Count - 1; i >= 0; i--)
                        {
                            var unit = obj.SnHistoryUnits.ElementAt(i);
                            if (updateObj.SnHistoryUnits.FirstOrDefault(u => u.ID == unit.ID) == null)
                                _efContext.Entry(unit).State = EntityState.Deleted;
                        }
                        foreach (var snHistoryUnit in updateObj.SnHistoryUnits)
                        {
                            var unit = obj.SnHistoryUnits.FirstOrDefault(u => u.ID == snHistoryUnit.ID);
                            if (unit != null)
                            {
                                unit.Unit = snHistoryUnit.Unit;
                                unit.USN = snHistoryUnit.USN;
                                unit.USO = snHistoryUnit.USO;
                                unit.USR = snHistoryUnit.USR;
                            }
                            else
                            {
                                snHistoryUnit.SnHistoryID = obj.ID;
                                _efContext.Entry(snHistoryUnit).State = EntityState.Added;
                            }
                        } 
                        #endregion
                    }
                }
            }
        }

        /// <summary>
        ///     根据SnHistoryID获取SnHistory
        /// </summary>
        /// <param name="id">SnHistory主键</param>
        /// <returns>SnHistory</returns>
        private SnHistory GetSnHistoryById(string id)
        {
            var value = Convert.ToInt32(id);
            return _efContext == null ? null : _efContext.SnHistorys.FirstOrDefault(p => p.ID == value);
        }
        /// <summary>
        /// 通过SnHistoryId获取相应的SnHistory
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SnHistory GetLastSnHistoryBySnregID(string snregID)
        {
            var value = Convert.ToInt32(snregID);
            return _efContext == null ? null : _efContext.SnHistorys.OrderByDescending(o => o.ID).FirstOrDefault(p => p.SnRegID == value);
        }
        public void DeleteSnHistory(SnHistory snHistory)
        {
            if (snHistory == null || snHistory.SnHistoryUnits == null)
                return;
            for (int i = snHistory.SnHistoryUnits.Count - 1; i >= 0; i--)
            {
                this.DoEntityRegisterDeleted(snHistory.SnHistoryUnits.ElementAt(i));
            }
            this.Remove(snHistory);
            this.Context.Commit();
        }

        public void DeleteSnHistoryUnit(SnHistory snHistory, IEnumerable<SnHistoryUnit> snHistoryUnits)
        {
            if (snHistory == null || snHistory.SnHistoryUnits == null || snHistoryUnits == null)
                return;
            for (int i = snHistory.SnHistoryUnits.Count - 1; i >= 0; i--)
            {
                if (snHistoryUnits.FirstOrDefault(s => s.ID == snHistory.SnHistoryUnits.ElementAt(i).ID) != null)
                    this.DoEntityRegisterDeleted(snHistory.SnHistoryUnits.ElementAt(i));
            }
            this.Update(snHistory);
            this.Context.Commit();
        }

    }
}
