#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/16 10:49:57

// 文件名：EgtMarginServiceImpl
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

namespace UniCloud.Application.Implementation
{
    /// <summary>
    /// 表示与EgtMargin相关的应用层服务的一种实现。
    /// </summary>
    public class EgtMarginServiceImpl : ApplicationService, IEgtMarginService
    {
        #region Private Fields
        private readonly IEgtMarginRepository _egtMarginRepository;
        private readonly IEgtMarginQuery _egtMarginQuery;
        private readonly IDomainService _domainService;
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个<c>EgtMarginServiceImpl</c>类型的实例。
        /// </summary>
        /// <param name="context">用来初始化<c>EgtMarginServiceImpl</c>类型的仓储上下文实例。</param>
        /// <param name="egtMarginRepository">“EgtMargin”仓储实例。</param>
        /// <param name="egtMarginQuery">“egtMarginQuery”查询实例。</param>
        /// <param name="domainService">“领域服务”实例。</param>
        public EgtMarginServiceImpl(IRepositoryContext context,
        IEgtMarginRepository egtMarginRepository,
        IEgtMarginQuery egtMarginQuery,
        IDomainService domainService)
            : base(context)
        {
            this._egtMarginRepository = egtMarginRepository;
            this._egtMarginQuery = egtMarginQuery;
            this._domainService = domainService;
        }
        #endregion

        #region IEgtMarginService

        /// <summary>
        /// 创建EgtMargin。
        /// </summary>
        /// <param name="egtMargins">需要创建的EgtMargin。</param>
        /// <returns>创建的EgtMargin。</returns>
        public EgtMarginDataObjectList CreateEgtMargins(EgtMarginDataObjectList egtMargins)
        {
            return PerformCreateObjects<EgtMarginDataObjectList, EgtMarginDataObject, EgtMargin>(egtMargins, _egtMarginRepository);
        }

        /// <summary>
        /// 删除EgtMargin信息。
        /// </summary>
        /// <param name="egtMarginIDs">需要更新的EgtMargin信息的ID值。</param>
        public IDList DeleteEgtMargins(IDList egtMarginIDs)
        {
            PerformDeleteObjects(egtMarginIDs, _egtMarginRepository);
            return egtMarginIDs;
        }

        /// <summary>
        /// 更新EgtMargin信息。
        /// </summary>
        /// <param name="egtMargins">需要更新的EgtMargin信息。</param>
        public EgtMarginDataObjectList UpdateEgtMargins(EgtMarginDataObjectList egtMargins)
        {
            return PerformUpdateObjects<EgtMarginDataObjectList, EgtMarginDataObject, EgtMargin>(egtMargins,
               _egtMarginRepository,
               pdo => pdo.ID,
               (p, pdo) =>
               {
                   p.Egtm = pdo.Egtm;
                   p.OperateDate = DateTime.Now;
               });
        }

        /// <summary>
        /// 提交EgtMargin的增删改数据
        /// </summary>
        /// <param name="egtMarginData"></param>
        /// <returns>提交成功的数据</returns>
        public EgtMarginResultData CommitEgtMargins(EgtMarginResultData egtMarginData)
        {
            var resultData = new EgtMarginResultData
            {
                AddedCollection =
                   new EgtMarginDataObjectList(),
                DeletedCollection = new List<string>(),
                ModefiedCollection =
                   new EgtMarginDataObjectList()
            };
            var addList = new List<EgtMargin>();
            IEnumerable<string> deleteList = new List<string>();
            var updateList = new List<EgtMargin>();

            #region Input

            if (egtMarginData.AddedCollection != null && egtMarginData.AddedCollection.Any())
            {
                egtMarginData.AddedCollection.ForEach(
                p =>
                {
                    addList.Add(Mapper.Map<EgtMarginDataObject, EgtMargin>(p));
                });
            }
            if (egtMarginData.DeletedCollection != null && egtMarginData.DeletedCollection.Any())
            {
                deleteList = egtMarginData.DeletedCollection;
            }
            if (egtMarginData.ModefiedCollection != null && egtMarginData.ModefiedCollection.Any())
            {
                egtMarginData.ModefiedCollection.ForEach(
                   p => updateList.Add(Mapper.Map<EgtMarginDataObject, EgtMargin>(p)));
            }

            #endregion

            _egtMarginRepository.CommitEgtMargin(addList, deleteList, updateList);

            #region Output

            var addResults = new ObservableCollection<EgtMarginDataObject>();
            if (addList.Any())
            {
                addList.ForEach(
                   p => addResults.Add(Mapper.Map<EgtMargin, EgtMarginDataObject>(p)));
                resultData.AddedCollection = addResults;
            }
            var updateResults = new ObservableCollection<EgtMarginDataObject>();
            if (updateList.Any())
            {
                updateList.ForEach(
                   p => updateResults.Add(Mapper.Map<EgtMargin, EgtMarginDataObject>(p)));
                resultData.ModefiedCollection = updateResults;
            }
            if (deleteList != null && deleteList.Any())
            {
                resultData.DeletedCollection = deleteList;
            }

            #endregion

            return resultData;
        }
        #endregion
    }
}
