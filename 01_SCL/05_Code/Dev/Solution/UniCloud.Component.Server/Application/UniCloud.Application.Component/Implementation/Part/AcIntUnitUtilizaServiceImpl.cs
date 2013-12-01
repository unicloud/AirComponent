#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/6 11:27:30

// 文件名：AcIntUnitUtilizaServiceImpl
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
    /// 表示与AcIntUnitUtiliza相关的应用层服务的一种实现。
    /// </summary>
    public class AcIntUnitUtilizaServiceImpl : ApplicationService, IAcIntUnitUtilizaService
    {
        #region Private Fields
        private readonly IAcIntUnitUtilizaRepository _acIntUnitUtilizaRepository;
        private readonly IAcIntUnitUtilizaQuery _acIntUnitUtilizaQuery;
        private readonly IDomainService _domainService;
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个<c>AcIntUnitUtilizaServiceImpl</c>类型的实例。
        /// </summary>
        /// <param name="context">用来初始化<c>AcIntUnitUtilizaServiceImpl</c>类型的仓储上下文实例。</param>
        /// <param name="acIntUnitUtilizaRepository">“AcIntUnitUtiliza”仓储实例。</param>
        /// <param name="acIntUnitUtilizaQuery">“acIntUnitUtilizaQuery”查询实例。</param>
        /// <param name="domainService">“领域服务”实例。</param>
        public AcIntUnitUtilizaServiceImpl(IRepositoryContext context,
        IAcIntUnitUtilizaRepository acIntUnitUtilizaRepository,
        IAcIntUnitUtilizaQuery acIntUnitUtilizaQuery,
        IDomainService domainService)
            : base(context)
        {
            this._acIntUnitUtilizaRepository = acIntUnitUtilizaRepository;
            this._acIntUnitUtilizaQuery = acIntUnitUtilizaQuery;
            this._domainService = domainService;
        }
        #endregion

        #region IAcIntUnitUtilizaService

        /// <summary>
        /// 创建AcIntUnitUtiliza。
        /// </summary>
        /// <param name="acIntUnitUtilizas">需要创建的AcIntUnitUtiliza。</param>
        /// <returns>创建的AcIntUnitUtiliza。</returns>
        public AcIntUnitUtilizaDataObjectList CreateAcIntUnitUtilizas(AcIntUnitUtilizaDataObjectList acIntUnitUtilizas)
        {
            return PerformCreateObjects<AcIntUnitUtilizaDataObjectList, AcIntUnitUtilizaDataObject, AcIntUnitUtiliza>(acIntUnitUtilizas, _acIntUnitUtilizaRepository);
        }

        /// <summary>
        /// 删除AcIntUnitUtiliza信息。
        /// </summary>
        /// <param name="acIntUnitUtilizaIDs">需要更新的AcIntUnitUtiliza信息的ID值。</param>
        public IDList DeleteAcIntUnitUtilizas(IDList acIntUnitUtilizaIDs)
        {
            PerformDeleteObjects(acIntUnitUtilizaIDs, _acIntUnitUtilizaRepository);
            return acIntUnitUtilizaIDs;
        }

        /// <summary>
        /// 更新AcIntUnitUtiliza信息。
        /// </summary>
        /// <param name="acIntUnitUtilizas">需要更新的AcIntUnitUtiliza信息。</param>
        public AcIntUnitUtilizaDataObjectList UpdateAcIntUnitUtilizas(AcIntUnitUtilizaDataObjectList acIntUnitUtilizas)
        {
            return PerformUpdateObjects<AcIntUnitUtilizaDataObjectList, AcIntUnitUtilizaDataObject, AcIntUnitUtiliza>(acIntUnitUtilizas,
               _acIntUnitUtilizaRepository,
               pdo => pdo.ID,
               (p, pdo) =>
               {
               });
        }

        /// <summary>
        /// 提交AcIntUnitUtiliza的增删改数据
        /// </summary>
        /// <param name="acIntUnitUtilizaData"></param>
        /// <returns>提交成功的数据</returns>
        public AcIntUnitUtilizaResultData CommitAcIntUnitUtilizas(AcIntUnitUtilizaResultData acIntUnitUtilizaData)
        {
            var resultData = new AcIntUnitUtilizaResultData
            {
                AddedCollection =
                   new AcIntUnitUtilizaDataObjectList(),
                DeletedCollection = new List<string>(),
                ModefiedCollection =
                   new AcIntUnitUtilizaDataObjectList()
            };
            var addList = new List<AcIntUnitUtiliza>();
            IEnumerable<string> deleteList = new List<string>();
            var updateList = new List<AcIntUnitUtiliza>();

            #region Input

            if (acIntUnitUtilizaData.AddedCollection != null && acIntUnitUtilizaData.AddedCollection.Any())
            {
                acIntUnitUtilizaData.AddedCollection.ForEach(
                p =>
                {

                    ValidateAcIntUnitUtiliza(p,true);
                    addList.Add(Mapper.Map<AcIntUnitUtilizaDataObject, AcIntUnitUtiliza>(p));
                });
            }
            if (acIntUnitUtilizaData.DeletedCollection != null && acIntUnitUtilizaData.DeletedCollection.Any())
            {
                deleteList = acIntUnitUtilizaData.DeletedCollection;
            }
            if (acIntUnitUtilizaData.ModefiedCollection != null && acIntUnitUtilizaData.ModefiedCollection.Any())
            {
                acIntUnitUtilizaData.ModefiedCollection.ForEach(
                   p =>
                   {
                       ValidateAcIntUnitUtiliza(p,false);
                       updateList.Add(Mapper.Map<AcIntUnitUtilizaDataObject, AcIntUnitUtiliza>(p));
                   });
            }

            #endregion

            _acIntUnitUtilizaRepository.CommitAcIntUnitUtiliza(addList, deleteList, updateList);

            #region Output

            var addResults = new ObservableCollection<AcIntUnitUtilizaDataObject>();
            if (addList.Any())
            {
                addList.ForEach(
                   p => addResults.Add(Mapper.Map<AcIntUnitUtiliza, AcIntUnitUtilizaDataObject>(p)));
                resultData.AddedCollection = addResults;
            }
            var updateResults = new ObservableCollection<AcIntUnitUtilizaDataObject>();
            if (updateList.Any())
            {
                updateList.ForEach(
                   p => updateResults.Add(Mapper.Map<AcIntUnitUtiliza, AcIntUnitUtilizaDataObject>(p)));
                resultData.ModefiedCollection = updateResults;
            }
            if (deleteList != null && deleteList.Any())
            {
                resultData.DeletedCollection = deleteList;
            }

            #endregion

            return resultData;
        }

        /// <summary>
        /// 验证 Acreg与Unit不能重复
        /// </summary>
        /// <param name="utiliza"></param>
        /// <param name="isAdd"></param>
        private void ValidateAcIntUnitUtiliza(AcIntUnitUtilizaDataObject utiliza,bool isAdd)
        {
            if (isAdd)
            {
                //新增验证
                var isExist = _acIntUnitUtilizaRepository.Exists(Specification<AcIntUnitUtiliza>.Eval(
                    a => a.AcReg == utiliza.AcReg && a.Unit == utiliza.Unit));
                if (isExist)
                    throw new DomainException("无法保存!数据库中已存在机号:" + utiliza.AcReg +
                                              " 单位:" + utiliza.Unit + "的记录.");
            }
            else
            {
                //修改验证
                var acUtilica = _acIntUnitUtilizaRepository.Get(Specification<AcIntUnitUtiliza>.Eval(
                    a => a.AcReg == utiliza.AcReg && a.Unit == utiliza.Unit));
                if (acUtilica != null && acUtilica.ID != utiliza.ID)
                {
                    throw new DomainException("无法保存!数据库中已存在机号:" + utiliza.AcReg +
                                           " 单位:" + utiliza.Unit + "的记录.");
                }
            }
        }

        #endregion

        #region IAcIntUnitUtilizaQuery

        /// <summary>
        /// 获取所有的AcIntUnitUtiliza信息。
        /// </summary>
        /// <returns>所有的AcIntUnitUtiliza信息。</returns>
        public AcIntUnitUtilizaDataObjectList GetAcIntUnitUtilizas()
        {
            var results = _acIntUnitUtilizaRepository.GetAll();
            return results != null ? Mapper.Map<IEnumerable<AcIntUnitUtiliza>, AcIntUnitUtilizaDataObjectList>(results) : null;
        }

        /// <summary>
        /// 获取所有的AcIntUnitUtiliza分页信息。
        /// </summary>
        /// <returns>所有的AcIntUnitUtiliza分页信息。</returns>
        public AcIntUnitUtilizaWithPagination GetAcIntUnitUtilizaWithPagination(Pagination pagination)
        {
            return _acIntUnitUtilizaQuery.GetAcIntUnitUtilizaWithPagination(pagination);
        }

        /// <summary>
        /// 通过AcIntUnitUtilizaId获取相应的AcIntUnitUtilizaDataObject
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AcIntUnitUtilizaDataObject GetAcIntUnitUtilizaByID(int id)
        {
            return _acIntUnitUtilizaQuery.GetAcIntUnitUtilizaByID(id);
        }

        #endregion

    }
}
