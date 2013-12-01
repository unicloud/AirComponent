#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/6 21:54:49

// 文件名：IntUnitServiceImpl
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
    /// 表示与IntUnit相关的应用层服务的一种实现。
    /// </summary>
    public class IntUnitServiceImpl : ApplicationService, IIntUnitService
    {
        #region Private Fields
        private readonly IIntUnitRepository _intUnitRepository;
        private readonly IIntUnitQuery _intUnitQuery;
        private readonly IDomainService _domainService;
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个<c>IntUnitServiceImpl</c>类型的实例。
        /// </summary>
        /// <param name="context">用来初始化<c>IntUnitServiceImpl</c>类型的仓储上下文实例。</param>
        /// <param name="intUnitRepository">“IntUnit”仓储实例。</param>
        /// <param name="intUnitQuery">“intUnitQuery”查询实例。</param>
        /// <param name="domainService">“领域服务”实例。</param>
        public IntUnitServiceImpl(IRepositoryContext context,
        IIntUnitRepository intUnitRepository,
        IIntUnitQuery intUnitQuery,
        IDomainService domainService)
            : base(context)
        {
            this._intUnitRepository = intUnitRepository;
            this._intUnitQuery = intUnitQuery;
            this._domainService = domainService;
        }
        #endregion

        #region IIntUnitService

        /// <summary>
        /// 创建IntUnit。
        /// </summary>
        /// <param name="intUnits">需要创建的IntUnit。</param>
        /// <returns>创建的IntUnit。</returns>
        public IntUnitDataObjectList CreateIntUnits(IntUnitDataObjectList intUnits)
        {
            return PerformCreateObjects<IntUnitDataObjectList, IntUnitDataObject, IntUnit>(intUnits, _intUnitRepository);
        }

        /// <summary>
        /// 删除IntUnit信息。
        /// </summary>
        /// <param name="intUnitIDs">需要更新的IntUnit信息的ID值。</param>
        public IDList DeleteIntUnits(IDList intUnitIDs)
        {
            PerformDeleteObjects(intUnitIDs, _intUnitRepository);
            return intUnitIDs;
        }

        /// <summary>
        /// 更新IntUnit信息。
        /// </summary>
        /// <param name="intUnits">需要更新的IntUnit信息。</param>
        public IntUnitDataObjectList UpdateIntUnits(IntUnitDataObjectList intUnits)
        {
            return PerformUpdateObjects<IntUnitDataObjectList, IntUnitDataObject, IntUnit>(intUnits,
               _intUnitRepository,
               pdo => pdo.ID,
               (p, pdo) =>
               {
                   p.Descritption = pdo.Descritption;
                   p.ShortName = p.ShortName;
                   p.Type = p.Type;
                   p.Unit = p.Unit;
               });
        }

        /// <summary>
        /// 提交IntUnit的增删改数据
        /// </summary>
        /// <param name="intUnitData"></param>
        /// <returns>提交成功的数据</returns>
        public IntUnitResultData CommitIntUnits(IntUnitResultData intUnitData)
        {
            var resultData = new IntUnitResultData
            {
                AddedCollection =
                   new IntUnitDataObjectList(),
                DeletedCollection = new List<string>(),
                ModefiedCollection =
                   new IntUnitDataObjectList()
            };
            var addList = new List<IntUnit>();
            IEnumerable<string> deleteList = new List<string>();
            var updateList = new List<IntUnit>();

            //唯一性校验
            if (intUnitData.AddedCollection != null && intUnitData.AddedCollection.Any())
            {
                foreach (var intUnitDataObject in intUnitData.AddedCollection)
                {
                    IsExistIntUnit(intUnitDataObject);
                }
            }

            if (intUnitData.ModefiedCollection != null && intUnitData.ModefiedCollection.Any())
            {
                foreach (var intUnitDataObject in intUnitData.ModefiedCollection)
                {
                    var intUnit = _intUnitRepository.GetByKey(intUnitDataObject.ID);
                    if (intUnit != null && intUnit.Unit != intUnitDataObject.Unit)
                    {
                        IsExistIntUnit(intUnitDataObject);
                    }
                }
            }


            #region Input

            if (intUnitData.AddedCollection != null && intUnitData.AddedCollection.Any())
            {
                intUnitData.AddedCollection.ForEach(
                p =>
                {
                    addList.Add(Mapper.Map<IntUnitDataObject, IntUnit>(p));
                });
            }
            if (intUnitData.DeletedCollection != null && intUnitData.DeletedCollection.Any())
            {
                deleteList = intUnitData.DeletedCollection;
            }
            if (intUnitData.ModefiedCollection != null && intUnitData.ModefiedCollection.Any())
            {
                intUnitData.ModefiedCollection.ForEach(
                   p => updateList.Add(Mapper.Map<IntUnitDataObject, IntUnit>(p)));
            }

            #endregion

            _intUnitRepository.CommitIntUnit(addList, deleteList, updateList);

            #region Output

            var addResults = new ObservableCollection<IntUnitDataObject>();
            if (addList.Any())
            {
                addList.ForEach(
                   p => addResults.Add(Mapper.Map<IntUnit, IntUnitDataObject>(p)));
                resultData.AddedCollection = addResults;
            }
            var updateResults = new ObservableCollection<IntUnitDataObject>();
            if (updateList.Any())
            {
                updateList.ForEach(
                   p => updateResults.Add(Mapper.Map<IntUnit, IntUnitDataObject>(p)));
                resultData.ModefiedCollection = updateResults;
            }
            if (deleteList != null && deleteList.Any())
            {
                resultData.DeletedCollection = deleteList;
            }

            #endregion

            return resultData;
        }


        private void IsExistIntUnit(IntUnitDataObject intUnit)
        {
            var isIntUnitExist =
                    _intUnitRepository.Exists(Specification<IntUnit>.Eval(a => a.Unit == intUnit.Unit));
            if (isIntUnitExist)
            {
                throw new DomainException("无法保存!数据库中已存在时限单位为:" + intUnit.Unit + "的记录.");
            }
        }

        #endregion

    }
}
