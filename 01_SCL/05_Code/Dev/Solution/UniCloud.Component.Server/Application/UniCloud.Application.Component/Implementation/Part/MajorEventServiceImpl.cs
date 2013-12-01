#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/16 16:16:39

// 文件名：MajorEventServiceImpl
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
    /// 表示与MajorEvent相关的应用层服务的一种实现。
    /// </summary>
    public class MajorEventServiceImpl : ApplicationService, IMajorEventService
    {
        #region Private Fields
        private readonly IMajorEventRepository _majorEventRepository;
        private readonly IMajorEventQuery _majorEventQuery;
        private readonly IDomainService _domainService;
        private readonly IAttactDocumentService _attactDocumentService;

        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个<c>MajorEventServiceImpl</c>类型的实例。
        /// </summary>
        /// <param name="context">用来初始化<c>MajorEventServiceImpl</c>类型的仓储上下文实例。</param>
        /// <param name="majorEventRepository">“MajorEvent”仓储实例。</param>
        /// <param name="majorEventQuery">“majorEventQuery”查询实例。</param>
        /// <param name="domainService">“领域服务”实例。</param>
        public MajorEventServiceImpl(IRepositoryContext context,
        IMajorEventRepository majorEventRepository,
        IMajorEventQuery majorEventQuery,
        IAttactDocumentService attactDocumentService,
        IDomainService domainService)
            : base(context)
        {
            this._majorEventRepository = majorEventRepository;
            this._majorEventQuery = majorEventQuery;
            this._domainService = domainService;
            this._attactDocumentService = attactDocumentService;
        }
        #endregion

        #region IMajorEventService

        /// <summary>
        /// 创建MajorEvent。
        /// </summary>
        /// <param name="majorEvents">需要创建的MajorEvent。</param>
        /// <returns>创建的MajorEvent。</returns>
        public MajorEventDataObjectList CreateMajorEvents(MajorEventDataObjectList majorEvents)
        {
            return PerformCreateObjects<MajorEventDataObjectList, MajorEventDataObject, MajorEvent>(majorEvents, _majorEventRepository);
        }

        /// <summary>
        /// 删除MajorEvent信息。
        /// </summary>
        /// <param name="majorEventIDs">需要更新的MajorEvent信息的ID值。</param>
        public IDList DeleteMajorEvents(IDList majorEventIDs)
        {
            PerformDeleteObjects(majorEventIDs, _majorEventRepository);
            return majorEventIDs;
        }

        /// <summary>
        /// 更新MajorEvent信息。
        /// </summary>
        /// <param name="majorEvents">需要更新的MajorEvent信息。</param>
        public MajorEventDataObjectList UpdateMajorEvents(MajorEventDataObjectList majorEvents)
        {
            return PerformUpdateObjects<MajorEventDataObjectList, MajorEventDataObject, MajorEvent>(majorEvents,
               _majorEventRepository,
               pdo => pdo.ID,
               (p, pdo) =>
               {
               });
        }

        /// <summary>
        /// 提交MajorEvent的增删改数据
        /// </summary>
        /// <param name="majorEventData"></param>
        /// <returns>提交成功的数据</returns>
        public MajorEventResultData CommitMajorEvents(MajorEventResultData majorEventData)
        {
            var resultData = new MajorEventResultData
            {
                AddedCollection =
                   new MajorEventDataObjectList(),
                DeletedCollection = new List<string>(),
                ModefiedCollection =
                   new MajorEventDataObjectList()
            };
            var addList = new List<MajorEvent>();
            IEnumerable<string> deleteList = new List<string>();
            var updateList = new List<MajorEvent>();

            List<AttactDocumentDataObject> addDocs = new  List<AttactDocumentDataObject>();
             List<AttactDocumentDataObject> updateDocs = new  List<AttactDocumentDataObject>();
            IDList deleteDocs = new IDList();

            #region Input

            if (majorEventData.AddedCollection != null && majorEventData.AddedCollection.Any())
            {
                majorEventData.AddedCollection.ForEach(
                p =>
                {
                    ValidateMajorEvents(p);
                    //将文档加入临时变量
                    foreach (var document in p.AttactDocuments)
                    {
                        addDocs.Add(document);
                    }
                    addList.Add(Mapper.Map<MajorEventDataObject, MajorEvent>(p));
                });
            }
            if (majorEventData.DeletedCollection != null && majorEventData.DeletedCollection.Any())
            {
                deleteList = majorEventData.DeletedCollection;
            }
            if (majorEventData.ModefiedCollection != null && majorEventData.ModefiedCollection.Any())
            {
                majorEventData.ModefiedCollection.ForEach(
                   p =>
                   {
                       ValidateMajorEvents(p);
                       //将文档加入临时变量
                       foreach (var document in p.AttactDocuments)
                       {
                           updateDocs.Add(document);
                       }
                       updateList.Add(Mapper.Map<MajorEventDataObject, MajorEvent>(p));
                   });
            }

            #endregion

            _majorEventRepository.CommitMajorEvent(addList, deleteList, updateList);

            foreach (var doc in addDocs)
            {
                doc.Business = "majorevent";
                doc.BusinessID = addList.FirstOrDefault().ID;
            }

            foreach (var doc in updateDocs)
            {
                doc.Business = "majorevent";
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

            var addResults = new ObservableCollection<MajorEventDataObject>();
            if (addList.Any())
            {
                addList.ForEach(
                   p => addResults.Add(Mapper.Map<MajorEvent, MajorEventDataObject>(p)));
                resultData.AddedCollection = addResults;
            }
            var updateResults = new ObservableCollection<MajorEventDataObject>();
            if (updateList.Any())
            {
                updateList.ForEach(
                   p => updateResults.Add(Mapper.Map<MajorEvent, MajorEventDataObject>(p)));
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
        /// 验证是否有输入机号与SN
        /// </summary>
        /// <param name="major"></param>
        private void ValidateMajorEvents(MajorEventDataObject major)
        {
            if (string.IsNullOrWhiteSpace(major.Ac))
            {
                throw new DomainException("无法保存!请输入机号.");
            }
            if (string.IsNullOrWhiteSpace(major.Sn))
            {
                throw new DomainException("无法保存!请输入件号.");
            }
        }
        #endregion

    }
}
