#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/21 9:41:58

// 文件名：AttactDocumentServiceImpl
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
using UniCloud.Service.Refernce;

namespace UniCloud.Application.Implementation
{
    /// <summary>
    /// 表示与AttactDocument相关的应用层服务的一种实现。
    /// </summary>
    public class AttactDocumentServiceImpl : ApplicationService, IAttactDocumentService
    {
        #region Private Fields
        private readonly IAttactDocumentRepository _attactDocumentRepository;
        private readonly IAttactDocumentQuery _attactDocumentQuery;
        private readonly IDomainService _domainService;
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个<c>AttactDocumentServiceImpl</c>类型的实例。
        /// </summary>
        /// <param name="context">用来初始化<c>AttactDocumentServiceImpl</c>类型的仓储上下文实例。</param>
        /// <param name="attactDocumentRepository">“AttactDocument”仓储实例。</param>
        /// <param name="attactDocumentQuery">“attactDocumentQuery”查询实例。</param>
        /// <param name="domainService">“领域服务”实例。</param>
        public AttactDocumentServiceImpl(IRepositoryContext context,
        IAttactDocumentRepository attactDocumentRepository,
        IAttactDocumentQuery attactDocumentQuery,
        IDomainService domainService)
            : base(context)
        {
            this._attactDocumentRepository = attactDocumentRepository;
            this._attactDocumentQuery = attactDocumentQuery;
            this._domainService = domainService;
        }
        #endregion

        #region IAttactDocumentService

        /// <summary>
        /// 创建AttactDocument。
        /// </summary>
        /// <param name="attactDocuments">需要创建的AttactDocument。</param>
        /// <returns>创建的AttactDocument。</returns>
        public AttactDocumentDataObjectList CreateAttactDocuments(AttactDocumentDataObjectList attactDocuments)
        {
            return PerformCreateObjects<AttactDocumentDataObjectList, AttactDocumentDataObject, AttactDocument>(attactDocuments, _attactDocumentRepository);
        }

        /// <summary>
        /// 删除AttactDocument信息。
        /// </summary>
        /// <param name="attactDocumentIDs">需要更新的AttactDocument信息的ID值。</param>
        public IDList DeleteAttactDocuments(IDList attactDocumentIDs)
        {
            PerformDeleteObjects(attactDocumentIDs, _attactDocumentRepository);
            return attactDocumentIDs;
        }

        /// <summary>
        /// 更新AttactDocument信息。
        /// </summary>
        /// <param name="attactDocuments">需要更新的AttactDocument信息。</param>
        public AttactDocumentDataObjectList UpdateAttactDocuments(AttactDocumentDataObjectList attactDocuments)
        {
            return PerformUpdateObjects<AttactDocumentDataObjectList, AttactDocumentDataObject, AttactDocument>(attactDocuments,
               _attactDocumentRepository,
               pdo => pdo.ID,
               (p, pdo) =>
               {
               });
        }

        /// <summary>
        /// 提交AttactDocument的增删改数据
        /// </summary>
        /// <param name="attactDocumentData"></param>
        /// <returns>提交成功的数据</returns>
        public AttactDocumentResultData CommitAttactDocuments(AttactDocumentResultData attactDocumentData)
        {
            var resultData = new AttactDocumentResultData
            {
                AddedCollection =
                   new AttactDocumentDataObjectList(),
                DeletedCollection = new List<string>(),
                ModefiedCollection =
                   new AttactDocumentDataObjectList()
            };
            var addList = new List<AttactDocument>();
            IEnumerable<string> deleteList = new List<string>();
            var updateList = new List<AttactDocument>();

            #region Input

            if (attactDocumentData.AddedCollection != null && attactDocumentData.AddedCollection.Any())
            {
                attactDocumentData.AddedCollection.ForEach(
                p =>
                {
                    //保存文档
                    if (p.Document != null)
                    {
                        var docID = DocumentService.Instance.AddDocument(p.Document);
                        p.DocumentID = docID.Value;
                    }
                    addList.Add(Mapper.Map<AttactDocumentDataObject, AttactDocument>(p));
                });
            }
            if (attactDocumentData.DeletedCollection != null && attactDocumentData.DeletedCollection.Any())
            {
                deleteList = attactDocumentData.DeletedCollection;
            }
            if (attactDocumentData.ModefiedCollection != null && attactDocumentData.ModefiedCollection.Any())
            {
                attactDocumentData.ModefiedCollection.ForEach(
                   p =>
                   {
                       //更新部分中，如果有DocumentID为空，则认为是新增的
                       if (p.Document != null && p.DocumentID == Guid.Empty)
                       {
                           var docID = DocumentService.Instance.AddDocument(p.Document);
                           p.DocumentID = docID.Value;
                       }
                       updateList.Add(Mapper.Map<AttactDocumentDataObject, AttactDocument>(p));
                   });
            }

            #endregion

            _attactDocumentRepository.CommitAttactDocument(addList, deleteList, updateList);

            #region Output

            var addResults = new ObservableCollection<AttactDocumentDataObject>();
            if (addList.Any())
            {
                addList.ForEach(
                   p => addResults.Add(Mapper.Map<AttactDocument, AttactDocumentDataObject>(p)));
                resultData.AddedCollection = addResults;
            }
            var updateResults = new ObservableCollection<AttactDocumentDataObject>();
            if (updateList.Any())
            {
                updateList.ForEach(
                   p => updateResults.Add(Mapper.Map<AttactDocument, AttactDocumentDataObject>(p)));
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
