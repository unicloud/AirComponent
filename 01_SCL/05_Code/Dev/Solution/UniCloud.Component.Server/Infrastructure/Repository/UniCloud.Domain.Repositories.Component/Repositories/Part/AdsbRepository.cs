#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/18 11:52:26

// 文件名：AdsbRepository
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UniCloud.Domain.Model;
using UniCloud.Domain.Repositories.EntityFramework;

namespace UniCloud.Domain.Repositories.Repositories
{
    public class AdsbRepository : EntityFrameworkIntRepository<Adsb>, IAdsbRepository
    {
        private readonly ComponentDbContext _efContext;

        public AdsbRepository(IRepositoryContext context)
            : base(context)
        {
            _efContext = EFContext.Context as ComponentDbContext;
        }
        /// <summary>
        /// 实现对Adsb的增删改。
        /// 需要添加的Adsb对象集合
        /// 需要删除的Adsb的ID集合
        /// 需要更新的Adsb对象集合
        /// <returns>执行后的更改结果</returns>
        /// </summary>
        public void CommitAdsb(List<Adsb> addAdsbs, IEnumerable<string> deleteIds, List<Adsb> updateAdsbs)
        {
            AddAdsbs(addAdsbs);
            DeleteAdsbs(deleteIds);
            UpdateAdsbs(updateAdsbs);
            _efContext.SaveChanges();
        }

        /// <summary>
        /// 增加Adsb
        /// </summary>
        /// <param name="addAdsbs">Adsb</param>
        private void AddAdsbs(List<Adsb> addAdsbs)
        {
            if (addAdsbs != null && addAdsbs.Any())
            {
                addAdsbs.ForEach(p =>
                {
                    _efContext.Entry(p).State = EntityState.Added;
                   
                });
            }
        }

        /// <summary>
        /// 删除Adsb
        /// </summary>
        /// <param name="deleteIds">删除Adsb</param>
        private void DeleteAdsbs(IEnumerable<string> deleteIds)
        {
            if (deleteIds != null)
            {
                foreach (var id in deleteIds)
                {
                    var result = GetAdsbById(id.ToString());
                    if (result != null)
                    {
                        _efContext.Entry(result).State = EntityState.Deleted;
                    }
                }
            }
        }

        /// <summary>
        ///     更新Adsb
        /// </summary>
        /// <param name="updateAdsbs">更新的Adsb</param>
        private void UpdateAdsbs(List<Adsb> updateAdsbs)
        {
            if (updateAdsbs != null && updateAdsbs.Any())
            {
                foreach (var updateObj in updateAdsbs)
                {
                    var obj = GetAdsbById(updateObj.ID.ToString());
                    if (obj != null)
                    {
                        _efContext.Adsbs.Attach(obj);
                        obj.Actype = string.IsNullOrWhiteSpace(updateObj.Actype) ? obj.Actype : updateObj.Actype;
                        obj.Content = string.IsNullOrWhiteSpace(updateObj.Content) ? obj.Content : updateObj.Content;
                        obj.FileNo = string.IsNullOrWhiteSpace(updateObj.FileNo) ? obj.FileNo : updateObj.FileNo;
                        obj.FileType = string.IsNullOrWhiteSpace(updateObj.FileType) ? obj.FileType : updateObj.FileType;
                        obj.FileVersion = string.IsNullOrWhiteSpace(updateObj.FileVersion) ?
                            obj.FileVersion : updateObj.FileVersion;
                        obj.FileTitle = string.IsNullOrWhiteSpace(updateObj.FileTitle) ? obj.FileTitle : updateObj.FileTitle;
                        obj.FromFile = string.IsNullOrWhiteSpace(updateObj.FromFile) ? obj.FromFile : updateObj.FromFile;
                        obj.ReceiveDate = updateObj.ReceiveDate.HasValue ? updateObj.ReceiveDate : obj.ReceiveDate;
                    }
                }
            }
        }

        /// <summary>
        ///     根据AdsbID获取Adsb
        /// </summary>
        /// <param name="id">Adsb主键</param>
        /// <returns>Adsb</returns>
        private Adsb GetAdsbById(string id)
        {
            int key = Convert.ToInt32(id);
            return _efContext == null ? null : _efContext.Adsbs.FirstOrDefault(p => p.ID == key);
        }
    }
}
