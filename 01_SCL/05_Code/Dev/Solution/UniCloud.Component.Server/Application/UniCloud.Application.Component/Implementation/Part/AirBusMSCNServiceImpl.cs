#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/13 10:03:07

// 文件名：AirBusMSCNServiceImpl
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
using UniCloud.ServiceContracts;
using System.Linq;
using UniCloud.Query;

namespace UniCloud.Application.Implementation
{
    /// <summary>
    /// 表示与AirBusMSCN相关的应用层服务的一种实现。
    /// </summary>
    public class AirBusMSCNServiceImpl : ApplicationService, IAirBusMSCNService
    {
        #region Private Fields
        private readonly IAirBusMSCNRepository _airBusMSCNRepository;
        private readonly IAirBusMSCNQuery _airBusMSCNQuery;
        private readonly IDomainService _domainService;
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个<c>AirBusMSCNServiceImpl</c>类型的实例。
        /// </summary>
        /// <param name="context">用来初始化<c>AirBusMSCNServiceImpl</c>类型的仓储上下文实例。</param>
        /// <param name="airBusMSCNRepository">“AirBusMSCN”仓储实例。</param>
        /// <param name="airBusMSCNQuery">“airBusMSCNQuery”查询实例。</param>
        /// <param name="domainService">“领域服务”实例。</param>
        public AirBusMSCNServiceImpl(IRepositoryContext context,
        IAirBusMSCNRepository airBusMSCNRepository,
        IAirBusMSCNQuery airBusMSCNQuery,
        IDomainService domainService)
            : base(context)
        {
            this._airBusMSCNRepository = airBusMSCNRepository;
            this._airBusMSCNQuery = airBusMSCNQuery;
            this._domainService = domainService;
        }
        #endregion

        #region IAirBusMSCNService

        /// <summary>
        /// 创建AirBusMSCN。
        /// </summary>
        /// <param name="airBusMSCNs">需要创建的AirBusMSCN。</param>
        /// <returns>创建的AirBusMSCN。</returns>
        public AirBusMSCNDataObjectList CreateAirBusMSCNs(AirBusMSCNDataObjectList airBusMSCNs)
        {
            return PerformCreateObjects<AirBusMSCNDataObjectList, AirBusMSCNDataObject, AirBusMSCN>(airBusMSCNs, _airBusMSCNRepository);
        }

        /// <summary>
        /// 删除AirBusMSCN信息。
        /// </summary>
        /// <param name="airBusMSCNIDs">需要更新的AirBusMSCN信息的ID值。</param>
        public IDList DeleteAirBusMSCNs(IDList airBusMSCNIDs)
        {
            PerformDeleteObjects(airBusMSCNIDs, _airBusMSCNRepository);
            return airBusMSCNIDs;
        }

        /// <summary>
        /// 更新AirBusMSCN信息。
        /// </summary>
        /// <param name="airBusMSCNs">需要更新的AirBusMSCN信息。</param>
        public AirBusMSCNDataObjectList UpdateAirBusMSCNs(AirBusMSCNDataObjectList airBusMSCNs)
        {
            return PerformUpdateObjects<AirBusMSCNDataObjectList, AirBusMSCNDataObject, AirBusMSCN>(airBusMSCNs,
               _airBusMSCNRepository,
               pdo => pdo.ID,
               (p, pdo) =>
               {
               });
        }

        /// <summary>
        /// 提交AirBusMSCN的增删改数据
        /// </summary>
        /// <param name="airBusMSCNData"></param>
        /// <returns>提交成功的数据</returns>
        public AirBusMSCNResultData CommitAirBusMSCNs(AirBusMSCNResultData airBusMSCNData)
        {
            var resultData = new AirBusMSCNResultData
            {
                AddedCollection =
                   new AirBusMSCNDataObjectList(),
                DeletedCollection = new List<string>(),
                ModefiedCollection =
                   new AirBusMSCNDataObjectList()
            };
            var addList = new List<AirBusMSCN>();
            IEnumerable<string> deleteList = new List<string>();
            var updateList = new List<AirBusMSCN>();

            #region Input

            if (airBusMSCNData.AddedCollection != null && airBusMSCNData.AddedCollection.Any())
            {
                airBusMSCNData.AddedCollection.ForEach(
                p =>
                {
                    addList.Add(Mapper.Map<AirBusMSCNDataObject, AirBusMSCN>(p));
                });
            }
            if (airBusMSCNData.DeletedCollection != null && airBusMSCNData.DeletedCollection.Any())
            {
                deleteList = airBusMSCNData.DeletedCollection;
            }
            if (airBusMSCNData.ModefiedCollection != null && airBusMSCNData.ModefiedCollection.Any())
            {
                airBusMSCNData.ModefiedCollection.ForEach(
                   p => updateList.Add(Mapper.Map<AirBusMSCNDataObject, AirBusMSCN>(p)));
            }

            #endregion

            _airBusMSCNRepository.CommitAirBusMSCN(addList, deleteList, updateList);

            #region Output

            var addResults = new ObservableCollection<AirBusMSCNDataObject>();
            if (addList.Any())
            {
                addList.ForEach(
                   p => addResults.Add(Mapper.Map<AirBusMSCN, AirBusMSCNDataObject>(p)));
                resultData.AddedCollection = addResults;
            }
            var updateResults = new ObservableCollection<AirBusMSCNDataObject>();
            if (updateList.Any())
            {
                updateList.ForEach(
                   p => updateResults.Add(Mapper.Map<AirBusMSCN, AirBusMSCNDataObject>(p)));
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
