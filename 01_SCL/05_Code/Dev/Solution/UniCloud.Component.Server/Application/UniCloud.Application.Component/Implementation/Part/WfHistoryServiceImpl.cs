#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/6 21:54:49

// 文件名：WfHistoryServiceImpl
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
   /// 表示与WfHistory相关的应用层服务的一种实现。
   /// </summary>
   public class WfHistoryServiceImpl : ApplicationService, IWfHistoryService
   {
      #region Private Fields
      private readonly IWfHistoryRepository _wfHistoryRepository;
      private readonly IWfHistoryQuery _wfHistoryQuery;
      private readonly IDomainService _domainService;
      #endregion
      
      #region Ctor
      /// <summary>
      /// 初始化一个<c>WfHistoryServiceImpl</c>类型的实例。
      /// </summary>
      /// <param name="context">用来初始化<c>WfHistoryServiceImpl</c>类型的仓储上下文实例。</param>
      /// <param name="wfHistoryRepository">“WfHistory”仓储实例。</param>
      /// <param name="wfHistoryQuery">“wfHistoryQuery”查询实例。</param>
      /// <param name="domainService">“领域服务”实例。</param>
      public WfHistoryServiceImpl(IRepositoryContext context,
      IWfHistoryRepository wfHistoryRepository,
      IWfHistoryQuery wfHistoryQuery,
      IDomainService domainService)
      : base(context)
      {
      this._wfHistoryRepository = wfHistoryRepository;
      this._wfHistoryQuery = wfHistoryQuery;
      this._domainService = domainService;
      }
      #endregion
      
      #region IWfHistoryService
      
      /// <summary>
      /// 创建WfHistory。
      /// </summary>
      /// <param name="wfHistorys">需要创建的WfHistory。</param>
      /// <returns>创建的WfHistory。</returns>
      public WfHistoryDataObjectList CreateWfHistorys(WfHistoryDataObjectList wfHistorys)
      {
          return PerformCreateObjects<WfHistoryDataObjectList, WfHistoryDataObject, WfHistory>(wfHistorys, _wfHistoryRepository);
      }
      
      /// <summary>
      /// 删除WfHistory信息。
      /// </summary>
      /// <param name="wfHistoryIDs">需要更新的WfHistory信息的ID值。</param>
      public IDList DeleteWfHistorys(IDList wfHistoryIDs)
      {
          PerformDeleteObjects(wfHistoryIDs, _wfHistoryRepository);
          return wfHistoryIDs;
      }
      
      /// <summary>
      /// 更新WfHistory信息。
      /// </summary>
      /// <param name="wfHistorys">需要更新的WfHistory信息。</param>
      public WfHistoryDataObjectList UpdateWfHistorys(WfHistoryDataObjectList wfHistorys)
      {
         return PerformUpdateObjects<WfHistoryDataObjectList, WfHistoryDataObject, WfHistory>(wfHistorys,
            _wfHistoryRepository,
            pdo => pdo.ID,
            (p, pdo) =>
            {
            });
      }
      
      /// <summary>
      /// 提交WfHistory的增删改数据
      /// </summary>
      /// <param name="wfHistoryData"></param>
      /// <returns>提交成功的数据</returns>
      public WfHistoryResultData CommitWfHistorys(WfHistoryResultData wfHistoryData)
      {
         var resultData = new WfHistoryResultData
         {
            AddedCollection =
               new WfHistoryDataObjectList(),
            DeletedCollection = new List<string>(),
            ModefiedCollection =
               new WfHistoryDataObjectList()
         };
         var addList = new List<WfHistory>();
         IEnumerable<string> deleteList = new List<string>();
         var updateList = new List<WfHistory>();
         
         #region Input
         
         if (wfHistoryData.AddedCollection != null && wfHistoryData.AddedCollection.Any())
         {
            wfHistoryData.AddedCollection.ForEach(
            p =>
               {
                  addList.Add(Mapper.Map<WfHistoryDataObject, WfHistory>(p));
               });
         }
         if (wfHistoryData.DeletedCollection != null && wfHistoryData.DeletedCollection.Any())
         {
            deleteList = wfHistoryData.DeletedCollection;
         }
         if (wfHistoryData.ModefiedCollection != null && wfHistoryData.ModefiedCollection.Any())
         {
            wfHistoryData.ModefiedCollection.ForEach(
               p => updateList.Add(Mapper.Map<WfHistoryDataObject, WfHistory>(p)));
         }
         
         #endregion
         
         _wfHistoryRepository.CommitWfHistory(addList, deleteList, updateList);
         
         #region Output
         
         var addResults = new ObservableCollection<WfHistoryDataObject>();
         if (addList.Any())
         {
            addList.ForEach(
               p => addResults.Add(Mapper.Map<WfHistory, WfHistoryDataObject>(p)));
            resultData.AddedCollection = addResults;
          }
         var updateResults = new ObservableCollection<WfHistoryDataObject>();
         if (updateList.Any())
         {
            updateList.ForEach(
               p => updateResults.Add(Mapper.Map<WfHistory, WfHistoryDataObject>(p)));
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
      
      #region IWfHistoryQuery
      /// <summary>
      /// 通过WfHistoryId获取相应的WfHistoryDataObject 有导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public WfHistoryDataObject GetFullWfHistoryByID(int id)
      {
          var result = _wfHistoryRepository.GetByKey(id);
         return result!=null?Mapper.Map<WfHistory,WfHistoryDataObject>(result) : null;
      }
      
      /// <summary>
      ///  获取所有的WfHistory信息 有导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public WfHistoryDataObjectList GetFullWfHistorys()
      {
          var results = _wfHistoryRepository.GetAll();
         return results!=null?Mapper.Map<IEnumerable<WfHistory>,WfHistoryDataObjectList>(results) : null;
      }
      
      #endregion
   }
}
