#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/18 11:52:26

// 文件名：AdsbComplyRepository
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
    public class AdsbComplyRepository : EntityFrameworkIntRepository<AdsbComply>, IAdsbComplyRepository
    {
        private readonly ComponentDbContext _efContext;

        public AdsbComplyRepository(IRepositoryContext context)
            : base(context)
        {
            _efContext = EFContext.Context as ComponentDbContext;
        }
        /// <summary>
        /// 实现对AdsbComply的增删改。
        /// 需要添加的AdsbComply对象集合
        /// 需要删除的AdsbComply的ID集合
        /// 需要更新的AdsbComply对象集合
        /// <returns>执行后的更改结果</returns>
        /// </summary>
        public void CommitAdsbComply(List<AdsbComply> addAdsbComplys, IEnumerable<string> deleteIds, List<AdsbComply> updateAdsbComplys)
        {
            AddAdsbComplys(addAdsbComplys);
            DeleteAdsbComplys(deleteIds);
            UpdateAdsbComplys(updateAdsbComplys);
            _efContext.SaveChanges();
        }

        /// <summary>
        /// 增加AdsbComply
        /// </summary>
        /// <param name="addAdsbComplys">AdsbComply</param>
        private void AddAdsbComplys(List<AdsbComply> addAdsbComplys)
        {
            if (addAdsbComplys != null && addAdsbComplys.Any())
            {
                addAdsbComplys.ForEach(p =>
                {
                    _efContext.Entry(p).State = EntityState.Added;
                });
            }
        }

        /// <summary>
        /// 删除AdsbComply
        /// </summary>
        /// <param name="deleteIds">删除AdsbComply</param>
        private void DeleteAdsbComplys(IEnumerable<string> deleteIds)
        {
            if (deleteIds != null)
            {
                foreach (var id in deleteIds)
                {
                    var result = GetAdsbComplyById(id.ToString());
                    if (result != null)
                    {
                        _efContext.Entry(result).State = EntityState.Deleted;
                    }
                }
            }
        }

        /// <summary>
        ///     更新AdsbComply
        /// </summary>
        /// <param name="updateAdsbComplys">更新的AdsbComply</param>
        private void UpdateAdsbComplys(List<AdsbComply> updateAdsbComplys)
        {
            if (updateAdsbComplys != null && updateAdsbComplys.Any())
            {
                foreach (var updateObj in updateAdsbComplys)
                {
                    var obj = GetAdsbComplyById(updateObj.ID.ToString());
                    if (obj != null)
                    {
                        _efContext.AdsbComplys.Attach(obj);
                        obj.Actype = string.IsNullOrWhiteSpace(updateObj.Actype)?obj.Actype:updateObj.Actype;
                        obj.ComFeeNotes = string.IsNullOrWhiteSpace(updateObj.ComFeeNotes) ?
                            obj.ComFeeNotes : updateObj.ComFeeNotes;
                        obj.ComplyAc = string.IsNullOrWhiteSpace(updateObj.ComplyAc) ? 
                            obj.ComplyAc : updateObj.ComplyAc;
                        obj.ComplyClose = string.IsNullOrWhiteSpace(updateObj.ComplyClose) ?
                            obj.ComplyClose : updateObj.ComplyClose;
                        obj.ComplyStatus = string.IsNullOrWhiteSpace(updateObj.ComplyStatus) ?
                            obj.ComplyStatus : updateObj.ComplyStatus;
                        obj.ComplyNotes = string.IsNullOrWhiteSpace(updateObj.ComplyNotes) ?
                           obj.ComplyNotes : updateObj.ComplyNotes;
                        obj.ComFeeCurrency = string.IsNullOrWhiteSpace(updateObj.ComFeeCurrency) ?
                           obj.ComFeeCurrency : updateObj.ComFeeCurrency;
                        obj.FileNo = string.IsNullOrWhiteSpace(updateObj.FileNo) ? obj.FileNo : updateObj.FileNo;
                        obj.FileType = string.IsNullOrWhiteSpace(updateObj.FileType) ? obj.FileType : updateObj.FileType;
                        obj.FileVersion = string.IsNullOrWhiteSpace(updateObj.FileVersion) ?
                            obj.FileVersion : updateObj.FileVersion;
                        obj.AdsbID = updateObj.AdsbID>0?updateObj.AdsbID:obj.AdsbID;
                        obj.ComFee = updateObj.ComFee.HasValue?updateObj.ComFee:obj.ComFee;
                        obj.ComplyDate = updateObj.ComplyDate.HasValue?updateObj.ComplyDate:
                            obj.ComplyDate;
                    }
                }
            }
        }

        /// <summary>
        ///     根据AdsbComplyID获取AdsbComply
        /// </summary>
        /// <param name="id">AdsbComply主键</param>
        /// <returns>AdsbComply</returns>
        private AdsbComply GetAdsbComplyById(string id)
        {
            int key = Convert.ToInt32(id);
            return _efContext == null ? null : _efContext.AdsbComplys.FirstOrDefault(p => p.ID == key);
        }
    }
}
