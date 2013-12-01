#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/17 23:23:10

// 文件名：ScnMainQuery
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UniCloud.DataObjects;
using UniCloud.Domain.Model;
using UniCloud.Domain.Repositories.EntityFramework;
using UniCloud.Domain.Specifications;

namespace UniCloud.Query
{
    /// <summary>
    /// 表示用于ScnMain的查询接口。
    /// </summary>
    public class ScnMainQuery : IScnMainQuery
    {
        private readonly ComponentDbContext _context;

        public ScnMainQuery(IUniCloudDbContext context)
        {
            _context = context as ComponentDbContext;
        }

        #region Query ScnMain

        /// <summary>
        /// 获取所有ScnMain
        /// </summary>
        /// <returns>所有的ScnMain。</returns>
        public ScnMainDataObjectList GetScnMains(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            Expression<Func<ScnMain, bool>> source = p => true;
            return GetScnMainList(source);
        }

        /// <summary>
        /// 获取所有ScnMain分页信息
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns>所有的ScnMain分页信息。</returns>
        public ScnMainWithPagination GetScnMainWithPagination(Pagination pagination, string organization)
        {
            Expression<Func<ScnMain, bool>> wherePredicate = p => true;
            //如果不是技术标准室，则只查询相应的科室SCN
            if (organization != "技术标准室")
            {
                wherePredicate=wherePredicate.And(a => a.Organization == organization);
            }
            Expression<Func<ScnMain, dynamic>> sortPredicate = t => t.ID;
            return GetScnMainPage(wherePredicate, sortPredicate, pagination);
        }

        /// <summary>
        /// 通过ScnMainId获取相应的ScnMain
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ScnMainDataObject GetScnMainByID(int id)
        {
            Expression<Func<ScnMain, bool>> source = p => p.ID == id;
            var result = GetScnMainList(source);
            return result == null ? null : result.FirstOrDefault();
        }

        #endregion

        #region Common Query

        private ScnMainDataObjectList GetScnMainList(Expression<Func<ScnMain, bool>> source)
        {
            var queryResult = (_context.ScnMains.Where(source).Select(t => new ScnMainDataObject()
               {
                   ScnNo = t.ScnNo,
                   AcTypeID = t.AcTypeID,
                   AcTypeGuid = t.AcTypeGuid,
                   AcModelID = t.AcModelID,
                   AcModelGuid = t.AcModelGuid,
                   Version = t.Version,
                   State = t.State,
                   Description = t.Description,
                   ScnType = t.ScnType,
                   CloseSituation = t.CloseSituation,
                   ColseTime = t.ColseTime,
                   CreateUser = t.CreateUser,
                   CreateTime = t.CreateTime,
                   ScnTitle = t.ScnTitle,
                   ModName = t.ModName,
                   Organization = t.Organization,
                   VerifyStatus = t.VerifyStatus,
                   Ata = t.Ata,
                   ID = t.ID,
               })).ToList();
            if (!queryResult.Any()) return new ScnMainDataObjectList();
            var transferResult = new ScnMainDataObjectList();
            queryResult.ForEach(transferResult.Add);
            return transferResult;
        }

        private ScnMainWithPagination GetScnMainPage(Expression<Func<ScnMain, bool>> wherePredicate,
                   Expression<Func<ScnMain, dynamic>> sortPredicate,
                   Pagination pagination)
        {
            Expression<Func<ScnMain, ScnMainDataObject>> mapper = t => new ScnMainDataObject
               {
                   ScnNo = t.ScnNo,
                   AcTypeID = t.AcTypeID,
                   AcTypeGuid = t.AcTypeGuid,
                   AcModelID = t.AcModelID,
                   AcModelGuid = t.AcModelGuid,
                   Version = t.Version,
                   State = t.State,
                   Description = t.Description,
                   ScnType = t.ScnType,
                   CloseSituation = t.CloseSituation,
                   ColseTime = t.ColseTime,
                   CreateUser = t.CreateUser,
                   CreateTime = t.CreateTime,
                   ScnTitle = t.ScnTitle,
                   ModName = t.ModName,
                   Organization=t.Organization,
                   VerifyStatus=t.VerifyStatus,
                   Ata=t.Ata,
                   ID = t.ID,
               };
            var ScnMainResult = _context.LoadPageDataObjects<ScnMain, ScnMainDataObject>(wherePredicate, sortPredicate, pagination, mapper);
            if (ScnMainResult == null) return null;
            pagination.TotalPages = ScnMainResult.TotalPages;
            var ScnMainWithPagination = new ScnMainWithPagination
               {
                   Pagination = pagination,
                   BaseDataObjectList = new BaseDataObjectList<ScnMainDataObject>()
               };
            foreach (var value in ScnMainResult.Data)
            {
                ScnMainWithPagination.BaseDataObjectList.Add(value);
            }
            return ScnMainWithPagination;
        }

        public CompareAcOrderDtoWithPagination CompareAcOrders(string msn1, string msn2, Pagination pagination)
        {
            //获取飞机的所有SCN
            //var scnAcOrders1 = _context.ScnAcorders.Where(a => a.MSN == msn1).ToList();
            //var scnAcOrders2 =_context.ScnAcorders.Where(a => a.MSN == msn2).ToList();
            List<string> msnList = new List<string>() {msn1, msn2};
            //scn编号  飞机msn1 飞机msn2
            var skip1 = (pagination.PageNumber - 1) * pagination.PageSize;
            var take1 = pagination.PageSize;

            var group = from scn in _context.ScnAcorders
                        join main in _context.ScnMains on scn.ScnMainID equals main.ID
                        where msnList.Contains(scn.MSN)
                        group main by new {ScnNo = main.ScnNo, Ver = main.Version};
            
            var comAcs = (group.Select(p=>new CompareAcOrderDto()
                                 {
                                     Count = p.Count(),
                                     ScnNo = p.Key.ScnNo,
                                     Version=p.Key.Ver
                                 })).OrderBy(p=>p.ScnNo).Skip(skip1).Take(take1).ToList();
            pagination.TotalItemCounts = group.Count();
            pagination.TotalPages = (pagination.TotalItemCounts + pagination.PageSize - 1) / pagination.PageSize;
            var compareAcWithPagination = new CompareAcOrderDtoWithPagination
            {
                Pagination = pagination,
                BaseDataObjectList = new BaseDataObjectList<CompareAcOrderDto>()
            };
            foreach (var value in comAcs)
            {
                var ac1 = (from main in _context.ScnMains
                           from scn in main.ScnAcorders
                           where main.ScnNo == value.ScnNo && main.Version == value.Version
                                 && scn.MSN == msn1
                           select new CompareAcDto()
                                  {
                                      Mod = main.ModName,
                                      Price = scn.Price,
                                      ScnTitle = main.ScnTitle,
                                      Msn=scn.MSN
                                  }).FirstOrDefault();
                if (ac1 == null)
                {
                    ac1 = new CompareAcDto() { Msn = msn1 };
                    value.HasMsn1 = false;
                }
                else
                    value.HasMsn1 = true;
                value.AcList.Add(ac1);

                var ac2 = (from main in _context.ScnMains
                           from scn in main.ScnAcorders
                           where main.ScnNo == value.ScnNo && main.Version == value.Version
                                 && scn.MSN == msn2
                           select new CompareAcDto()
                           {
                               Mod = main.ModName,
                               Price = scn.Price,
                               ScnTitle = main.ScnTitle,
                               Msn = scn.MSN
                           }).FirstOrDefault();
                if (ac2 == null)
                {
                    ac2 = new CompareAcDto() { Msn = msn2 };
                    value.HasMsn2 = false;
                }
                else
                    value.HasMsn2 = true;
                value.AcList.Add(ac2);
                compareAcWithPagination.BaseDataObjectList.Add(value);
            }
            return compareAcWithPagination;
        }

        public KeyValueDataObjectList GetAcOrderMsns()
        {
            KeyValueDataObjectList list = new KeyValueDataObjectList();
            var results = _context.ScnAcorders.Select(a => a.MSN).Distinct();
            foreach (var result in results)
            {
                if (!string.IsNullOrWhiteSpace(result))
                {
                    KeyValueDataObject kv = new KeyValueDataObject();
                    kv.Name = result;
                    kv.StringKey = result;
                    list.Add(kv);
                }
            }
            return list;
        }

        #endregion

    }
}
