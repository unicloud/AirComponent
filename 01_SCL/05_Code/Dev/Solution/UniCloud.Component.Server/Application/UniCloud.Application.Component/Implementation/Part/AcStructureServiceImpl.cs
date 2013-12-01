#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/19 15:38:44

// 文件名：AcStructureServiceImpl
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
    /// 表示与AcStructure相关的应用层服务的一种实现。
    /// </summary>
    public class AcStructureServiceImpl : ApplicationService, IAcStructureService
    {
        #region Private Fields
        private readonly IAcStructureRepository _acStructureRepository;
        private readonly IAcStructureQuery _acStructureQuery;
        private readonly IDomainService _domainService;
        private readonly IAttactDocumentService _attactDocumentService;
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个<c>AcStructureServiceImpl</c>类型的实例。
        /// </summary>
        /// <param name="context">用来初始化<c>AcStructureServiceImpl</c>类型的仓储上下文实例。</param>
        /// <param name="acStructureRepository">“AcStructure”仓储实例。</param>
        /// <param name="acStructureQuery">“acStructureQuery”查询实例。</param>
        /// <param name="domainService">“领域服务”实例。</param>
        public AcStructureServiceImpl(IRepositoryContext context,
        IAcStructureRepository acStructureRepository,
        IAcStructureQuery acStructureQuery,
        IAttactDocumentService attactDocumentService,
        IDomainService domainService)
            : base(context)
        {
            this._acStructureRepository = acStructureRepository;
            this._acStructureQuery = acStructureQuery;
            this._domainService = domainService;
            this._attactDocumentService = attactDocumentService;
        }
        #endregion

        #region IAcStructureService

        /// <summary>
        /// 创建AcStructure。
        /// </summary>
        /// <param name="acStructures">需要创建的AcStructure。</param>
        /// <returns>创建的AcStructure。</returns>
        public AcStructureDataObjectList CreateAcStructures(AcStructureDataObjectList acStructures)
        {
            return PerformCreateObjects<AcStructureDataObjectList, AcStructureDataObject, AcStructure>(acStructures, _acStructureRepository);
        }

        /// <summary>
        /// 删除AcStructure信息。
        /// </summary>
        /// <param name="acStructureIDs">需要更新的AcStructure信息的ID值。</param>
        public IDList DeleteAcStructures(IDList acStructureIDs)
        {
            PerformDeleteObjects(acStructureIDs, _acStructureRepository);
            return acStructureIDs;
        }

        /// <summary>
        /// 更新AcStructure信息。
        /// </summary>
        /// <param name="acStructures">需要更新的AcStructure信息。</param>
        public AcStructureDataObjectList UpdateAcStructures(AcStructureDataObjectList acStructures)
        {
            return PerformUpdateObjects<AcStructureDataObjectList, AcStructureDataObject, AcStructure>(acStructures,
               _acStructureRepository,
               pdo => pdo.ID,
               (p, pdo) =>
               {
               });
        }

        /// <summary>
        /// 提交AcStructure的增删改数据
        /// </summary>
        /// <param name="acStructureData"></param>
        /// <returns>提交成功的数据</returns>
        public AcStructureResultData CommitAcStructures(AcStructureResultData acStructureData)
        {
            var resultData = new AcStructureResultData
            {
                AddedCollection =
                   new AcStructureDataObjectList(),
                DeletedCollection = new List<string>(),
                ModefiedCollection =
                   new AcStructureDataObjectList()
            };
            var addList = new List<AcStructure>();
            IEnumerable<string> deleteList = new List<string>();
            var updateList = new List<AcStructure>();

            List<AttactDocumentDataObject> addDocs = new List<AttactDocumentDataObject>();
            List<AttactDocumentDataObject> updateDocs = new List<AttactDocumentDataObject>();
            IDList deleteDocs = new IDList();

            #region Input

            if (acStructureData.AddedCollection != null && acStructureData.AddedCollection.Any())
            {
                acStructureData.AddedCollection.ForEach(
                p =>
                {
                    //将文档加入临时变量
                    foreach (var document in p.AttactDocuments)
                    {
                        addDocs.Add(document);
                    }
                    addList.Add(Mapper.Map<AcStructureDataObject, AcStructure>(p));
                });
            }
            if (acStructureData.DeletedCollection != null && acStructureData.DeletedCollection.Any())
            {
                deleteList = acStructureData.DeletedCollection;
            }
            if (acStructureData.ModefiedCollection != null && acStructureData.ModefiedCollection.Any())
            {
                acStructureData.ModefiedCollection.ForEach(
                   p =>
                   {
                       //将文档加入临时变量
                       foreach (var document in p.AttactDocuments)
                       {
                           updateDocs.Add(document);
                       }
                       updateList.Add(Mapper.Map<AcStructureDataObject, AcStructure>(p));
                   });
            }

            #endregion

            _acStructureRepository.CommitAcStructure(addList, deleteList, updateList);

            foreach (var doc in addDocs)
            {
                doc.Business = "acstructure";
                doc.BusinessID = addList.FirstOrDefault().ID;
            }

            foreach (var doc in updateDocs)
            {
                doc.Business = "acstructure";
                doc.BusinessID = updateList.FirstOrDefault().ID;
            }

            //保存文档 存在一个BUG，只能保存单个MajorEvent,不然无法获取businessID
            AttactDocumentResultData docResultData = new AttactDocumentResultData()
            {
                AddedCollection = addDocs,
                ModefiedCollection = updateDocs,
                DeletedCollection = deleteDocs
            };
            _attactDocumentService.CommitAttactDocuments(docResultData);

            #region Output

            var addResults = new ObservableCollection<AcStructureDataObject>();
            if (addList.Any())
            {
                addList.ForEach(
                   p => addResults.Add(Mapper.Map<AcStructure, AcStructureDataObject>(p)));
                resultData.AddedCollection = addResults;
            }
            var updateResults = new ObservableCollection<AcStructureDataObject>();
            if (updateList.Any())
            {
                updateList.ForEach(
                   p => updateResults.Add(Mapper.Map<AcStructure, AcStructureDataObject>(p)));
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
