#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/6 21:54:49

// 文件名：SnHistoryServiceImpl
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
   /// 表示与SnHistory相关的应用层服务的一种实现。
   /// </summary>
   public class SnHistoryServiceImpl : ApplicationService, ISnHistoryService
   {
      #region Private Fields
      private readonly ISnHistoryRepository _snHistoryRepository;
      private readonly ISnHistoryQuery _snHistoryQuery;
      private readonly IDomainService _domainService;
      #endregion
      
      #region Ctor
      /// <summary>
      /// 初始化一个<c>SnHistoryServiceImpl</c>类型的实例。
      /// </summary>
      /// <param name="context">用来初始化<c>SnHistoryServiceImpl</c>类型的仓储上下文实例。</param>
      /// <param name="snHistoryRepository">“SnHistory”仓储实例。</param>
      /// <param name="snHistoryQuery">“snHistoryQuery”查询实例。</param>
      /// <param name="domainService">“领域服务”实例。</param>
      public SnHistoryServiceImpl(IRepositoryContext context,
      ISnHistoryRepository snHistoryRepository,
      ISnHistoryQuery snHistoryQuery,
      IDomainService domainService)
      : base(context)
      {
      this._snHistoryRepository = snHistoryRepository;
      this._snHistoryQuery = snHistoryQuery;
      this._domainService = domainService;
      }
      #endregion
      
      #region ISnHistoryService
      
      /// <summary>
      /// 创建SnHistory。
      /// </summary>
      /// <param name="snHistorys">需要创建的SnHistory。</param>
      /// <returns>创建的SnHistory。</returns>
      public SnHistoryDataObjectList CreateSnHistorys(SnHistoryDataObjectList snHistorys)
      {
          return PerformCreateObjects<SnHistoryDataObjectList, SnHistoryDataObject, SnHistory>(snHistorys, _snHistoryRepository);
      }
      
      /// <summary>
      /// 删除SnHistory信息。
      /// </summary>
      /// <param name="snHistoryIDs">需要更新的SnHistory信息的ID值。</param>
      public IDList DeleteSnHistorys(IDList snHistoryIDs)
      {
          PerformDeleteObjects(snHistoryIDs, _snHistoryRepository);
          return snHistoryIDs;
      }
      
      /// <summary>
      /// 更新SnHistory信息。
      /// </summary>
      /// <param name="snHistorys">需要更新的SnHistory信息。</param>
      public SnHistoryDataObjectList UpdateSnHistorys(SnHistoryDataObjectList snHistorys)
      {
         return PerformUpdateObjects<SnHistoryDataObjectList, SnHistoryDataObject, SnHistory>(snHistorys,
            _snHistoryRepository,
            pdo => pdo.ID,
            (p, pdo) =>
            {
            });
      }
      
      /// <summary>
      /// 提交SnHistory的增删改数据
      /// </summary>
      /// <param name="snHistoryData"></param>
      /// <returns>提交成功的数据</returns>
      public SnHistoryResultData CommitSnHistorys(SnHistoryResultData snHistoryData)
      {
         var resultData = new SnHistoryResultData
         {
            AddedCollection =
               new SnHistoryDataObjectList(),
            DeletedCollection = new List<string>(),
            ModefiedCollection =
               new SnHistoryDataObjectList()
         };
         var addList = new List<SnHistory>();
         IEnumerable<string> deleteList = new List<string>();
         var updateList = new List<SnHistory>();
         
         #region Input
         
         if (snHistoryData.AddedCollection != null && snHistoryData.AddedCollection.Any())
         {
            snHistoryData.AddedCollection.ForEach(
            p =>
               {
                  addList.Add(Mapper.Map<SnHistoryDataObject, SnHistory>(p));
               });
         }
         if (snHistoryData.DeletedCollection != null && snHistoryData.DeletedCollection.Any())
         {
            deleteList = snHistoryData.DeletedCollection;
         }
         if (snHistoryData.ModefiedCollection != null && snHistoryData.ModefiedCollection.Any())
         {
            snHistoryData.ModefiedCollection.ForEach(
               p => updateList.Add(Mapper.Map<SnHistoryDataObject, SnHistory>(p)));
         }
         
         #endregion
         
         _snHistoryRepository.CommitSnHistory(addList, deleteList, updateList);
         
         #region Output
         
         var addResults = new ObservableCollection<SnHistoryDataObject>();
         if (addList.Any())
         {
            addList.ForEach(
               p => addResults.Add(Mapper.Map<SnHistory, SnHistoryDataObject>(p)));
            resultData.AddedCollection = addResults;
          }
         var updateResults = new ObservableCollection<SnHistoryDataObject>();
         if (updateList.Any())
         {
            updateList.ForEach(
               p => updateResults.Add(Mapper.Map<SnHistory, SnHistoryDataObject>(p)));
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
      
      #region ISnHistoryQuery
      
      /// <summary>
      /// 通过SnHistoryId获取相应的SnHistoryDataObject 有导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public SnHistoryDataObject GetFullSnHistoryByID(int id)
      {
          var result = _snHistoryRepository.GetByKey(id);
         return result!=null?Mapper.Map<SnHistory,SnHistoryDataObject>(result) : null;
      }
      
      /// <summary>
      ///  获取所有的SnHistory信息 有导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public SnHistoryDataObjectList GetFullSnHistorys()
      {
          var results = _snHistoryRepository.GetAll();
         return results!=null?Mapper.Map<IEnumerable<SnHistory>,SnHistoryDataObjectList>(results) : null;
      }
      
      #endregion
   }
}
