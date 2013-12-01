#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/6 21:54:49

// 文件名：WorkScopeServiceImpl
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoMapper;
using Microsoft.Practices.ObjectBuilder2;
using UniCloud.DataObjects;
using UniCloud.Domain;
using UniCloud.Domain.Model;
using UniCloud.Domain.Repositories;
using UniCloud.Domain.Services;
using UniCloud.Query;
using UniCloud.ServiceContracts;
using System.Linq;
using UniCloud.Domain.Specifications;


namespace UniCloud.Application.Implementation
{
    /// <summary>
    /// 表示与WorkScope相关的应用层服务的一种实现。
    /// </summary>
    public class WorkScopeServiceImpl : ApplicationService, IWorkScopeService
    {
        #region Private Fields
        private readonly IWorkScopeRepository _workScopeRepository;
        private readonly IWorkScopeQuery _workScopeQuery;
        private readonly IDomainService _domainService;
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个<c>WorkScopeServiceImpl</c>类型的实例。
        /// </summary>
        /// <param name="context">用来初始化<c>WorkScopeServiceImpl</c>类型的仓储上下文实例。</param>
        /// <param name="workScopeRepository">“WorkScope”仓储实例。</param>
        /// <param name="workScopeQuery">“workScopeQuery”查询实例。</param>
        /// <param name="domainService">“领域服务”实例。</param>
        public WorkScopeServiceImpl(IRepositoryContext context,
        IWorkScopeRepository workScopeRepository,
        IWorkScopeQuery workScopeQuery,
        IDomainService domainService)
            : base(context)
        {
            this._workScopeRepository = workScopeRepository;
            this._workScopeQuery = workScopeQuery;
            this._domainService = domainService;
        }
        #endregion

        #region IWorkScopeService

        /// <summary>
        /// 创建WorkScope。
        /// </summary>
        /// <param name="workScopes">需要创建的WorkScope。</param>
        /// <returns>创建的WorkScope。</returns>
        public WorkScopeDataObjectList CreateWorkScopes(WorkScopeDataObjectList workScopes)
        {
            return PerformCreateObjects<WorkScopeDataObjectList, WorkScopeDataObject, WorkScope>(workScopes, _workScopeRepository);
        }

        /// <summary>
        /// 删除WorkScope信息。
        /// </summary>
        /// <param name="workScopeIDs">需要更新的WorkScope信息的ID值。</param>
        public IDList DeleteWorkScopes(IDList workScopeIDs)
        {
            PerformDeleteObjects(workScopeIDs, _workScopeRepository);
            return workScopeIDs;
        }

        /// <summary>
        /// 更新WorkScope信息。
        /// </summary>
        /// <param name="workScopes">需要更新的WorkScope信息。</param>
        public WorkScopeDataObjectList UpdateWorkScopes(WorkScopeDataObjectList workScopes)
        {
            return PerformUpdateObjects<WorkScopeDataObjectList, WorkScopeDataObject, WorkScope>(workScopes,
               _workScopeRepository,
               pdo => pdo.ID,
               (p, pdo) =>
               {
               });
        }

        /// <summary>
        /// 提交WorkScope的增删改数据
        /// </summary>
        /// <param name="workScopeData"></param>
        /// <returns>提交成功的数据</returns>
        public WorkScopeResultData CommitWorkScopes(WorkScopeResultData workScopeData)
        {
            var resultData = new WorkScopeResultData
            {
                AddedCollection =
                   new WorkScopeDataObjectList(),
                DeletedCollection = new List<string>(),
                ModefiedCollection =
                   new WorkScopeDataObjectList()
            };
            var addList = new List<WorkScope>();
            IEnumerable<string> deleteList = new List<string>();
            var updateList = new List<WorkScope>();

            //唯一性校验
            if (workScopeData.AddedCollection != null && workScopeData.AddedCollection.Any())
            {
                foreach (var workScopeDataObject in workScopeData.AddedCollection)
                {
                    IsExistWorkScope(workScopeDataObject);
                }
            }

            if (workScopeData.ModefiedCollection != null && workScopeData.ModefiedCollection.Any())
            {
                foreach (var workScopeDataObject in workScopeData.ModefiedCollection)
                {
                    var workScope = _workScopeRepository.GetByKey(workScopeDataObject.ID);
                    if (workScope != null && workScope.Scope != workScopeDataObject.Scope)
                    {
                        IsExistWorkScope(workScopeDataObject);
                    }
                }
            }


            #region Input

            if (workScopeData.AddedCollection != null && workScopeData.AddedCollection.Any())
            {
                workScopeData.AddedCollection.ForEach(
                p =>
                {
                    addList.Add(Mapper.Map<WorkScopeDataObject, WorkScope>(p));
                });
            }
            if (workScopeData.DeletedCollection != null && workScopeData.DeletedCollection.Any())
            {
                deleteList = workScopeData.DeletedCollection;
            }
            if (workScopeData.ModefiedCollection != null && workScopeData.ModefiedCollection.Any())
            {
                workScopeData.ModefiedCollection.ForEach(
                   p => updateList.Add(Mapper.Map<WorkScopeDataObject, WorkScope>(p)));
            }

            #endregion

            _workScopeRepository.CommitWorkScope(addList, deleteList, updateList);

            #region Output

            var addResults = new ObservableCollection<WorkScopeDataObject>();
            if (addList.Any())
            {
                addList.ForEach(
                   p => addResults.Add(Mapper.Map<WorkScope, WorkScopeDataObject>(p)));
                resultData.AddedCollection = addResults;
            }
            var updateResults = new ObservableCollection<WorkScopeDataObject>();
            if (updateList.Any())
            {
                updateList.ForEach(
                   p => updateResults.Add(Mapper.Map<WorkScope, WorkScopeDataObject>(p)));
                resultData.ModefiedCollection = updateResults;
            }
            if (deleteList != null && deleteList.Any())
            {
                resultData.DeletedCollection = deleteList;
            }

            #endregion

            return resultData;
        }

        private void IsExistWorkScope(WorkScopeDataObject workScope)
        {
            var isIntUnitExist =
                    _workScopeRepository.Exists(Specification<WorkScope>.Eval(a => a.Scope == workScope.Scope));
            if (isIntUnitExist)
            {
                throw new DomainException("无法保存!数据库中已存在工作代码为:" + workScope.Scope + "的记录.");
            }
        }
        #endregion
    }
}
