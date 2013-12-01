#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/6 21:54:49

// 文件名：OilHistoryServiceImpl
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System.Collections.Generic;
using System.Collections.ObjectModel;
using AutoMapper;
using Microsoft.Practices.ObjectBuilder2;
using UniCloud.DataObjects;
using UniCloud.Domain.Model;
using UniCloud.Domain.Repositories;
using UniCloud.Domain.Services;
using UniCloud.Query;
using UniCloud.ServiceContracts;
using System.Linq;

namespace UniCloud.Application.Implementation
{
   /// <summary>
   /// 表示与OilHistory相关的应用层服务的一种实现。
   /// </summary>
   public class OilHistoryServiceImpl : ApplicationService, IOilHistoryService
   {
      #region Private Fields
      private readonly IOilHistoryRepository _oilHistoryRepository;
      private readonly IOilHistoryQuery _oilHistoryQuery;
      private readonly IDomainService _domainService;
      #endregion
      
      #region Ctor
      /// <summary>
      /// 初始化一个<c>OilHistoryServiceImpl</c>类型的实例。
      /// </summary>
      /// <param name="context">用来初始化<c>OilHistoryServiceImpl</c>类型的仓储上下文实例。</param>
      /// <param name="oilHistoryRepository">“OilHistory”仓储实例。</param>
      /// <param name="oilHistoryQuery">“oilHistoryQuery”查询实例。</param>
      /// <param name="domainService">“领域服务”实例。</param>
      public OilHistoryServiceImpl(IRepositoryContext context,
      IOilHistoryRepository oilHistoryRepository,
      IOilHistoryQuery oilHistoryQuery,
      IDomainService domainService)
      : base(context)
      {
      this._oilHistoryRepository = oilHistoryRepository;
      this._oilHistoryQuery = oilHistoryQuery;
      this._domainService = domainService;
      }
      #endregion
      
      #region IOilHistoryService
      
      /// <summary>
      /// 创建OilHistory。
      /// </summary>
      /// <param name="oilHistorys">需要创建的OilHistory。</param>
      /// <returns>创建的OilHistory。</returns>
      public OilHistoryDataObjectList CreateOilHistorys(OilHistoryDataObjectList oilHistorys)
      {
          return PerformCreateObjects<OilHistoryDataObjectList, OilHistoryDataObject, OilHistory>(oilHistorys, _oilHistoryRepository);
      }
      
      /// <summary>
      /// 删除OilHistory信息。
      /// </summary>
      /// <param name="oilHistoryIDs">需要更新的OilHistory信息的ID值。</param>
      public IDList DeleteOilHistorys(IDList oilHistoryIDs)
      {
          PerformDeleteObjects(oilHistoryIDs, _oilHistoryRepository);
          return oilHistoryIDs;
      }
      
      /// <summary>
      /// 更新OilHistory信息。
      /// </summary>
      /// <param name="oilHistorys">需要更新的OilHistory信息。</param>
      public OilHistoryDataObjectList UpdateOilHistorys(OilHistoryDataObjectList oilHistorys)
      {
         return PerformUpdateObjects<OilHistoryDataObjectList, OilHistoryDataObject, OilHistory>(oilHistorys,
            _oilHistoryRepository,
            pdo => pdo.ID,
            (p, pdo) =>
            {
            });
      }
      
      /// <summary>
      /// 提交OilHistory的增删改数据
      /// </summary>
      /// <param name="oilHistoryData"></param>
      /// <returns>提交成功的数据</returns>
      public OilHistoryResultData CommitOilHistorys(OilHistoryResultData oilHistoryData)
      {
         var resultData = new OilHistoryResultData
         {
            AddedCollection =
               new OilHistoryDataObjectList(),
            DeletedCollection = new List<string>(),
            ModefiedCollection =
               new OilHistoryDataObjectList()
         };
         var addList = new List<OilHistory>();
         IEnumerable<string> deleteList = new List<string>();
         var updateList = new List<OilHistory>();
         
         #region Input
         
         if (oilHistoryData.AddedCollection != null && oilHistoryData.AddedCollection.Any())
         {
            oilHistoryData.AddedCollection.ForEach(
            p =>
               {
                  addList.Add(Mapper.Map<OilHistoryDataObject, OilHistory>(p));
               });
         }
         if (oilHistoryData.DeletedCollection != null && oilHistoryData.DeletedCollection.Any())
         {
            deleteList = oilHistoryData.DeletedCollection;
         }
         if (oilHistoryData.ModefiedCollection != null && oilHistoryData.ModefiedCollection.Any())
         {
            oilHistoryData.ModefiedCollection.ForEach(
               p => updateList.Add(Mapper.Map<OilHistoryDataObject, OilHistory>(p)));
         }
         
         #endregion
         
         _oilHistoryRepository.CommitOilHistory(addList, deleteList, updateList);
         
         #region Output
         
         var addResults = new ObservableCollection<OilHistoryDataObject>();
         if (addList.Any())
         {
            addList.ForEach(
               p => addResults.Add(Mapper.Map<OilHistory, OilHistoryDataObject>(p)));
            resultData.AddedCollection = addResults;
          }
         var updateResults = new ObservableCollection<OilHistoryDataObject>();
         if (updateList.Any())
         {
            updateList.ForEach(
               p => updateResults.Add(Mapper.Map<OilHistory, OilHistoryDataObject>(p)));
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
      
      #region IOilHistoryQuery
      
      /// <summary>
      /// 通过OilHistoryId获取相应的OilHistoryDataObject 有导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public OilHistoryDataObject GetFullOilHistoryByID(int id)
      {
          var result = _oilHistoryRepository.GetByKey(id);
         return result!=null?Mapper.Map<OilHistory,OilHistoryDataObject>(result) : null;
      }
      
      /// <summary>
      ///  获取所有的OilHistory信息 有导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public OilHistoryDataObjectList GetFullOilHistorys()
      {
          var results = _oilHistoryRepository.GetAll();
         return results!=null?Mapper.Map<IEnumerable<OilHistory>,OilHistoryDataObjectList>(results) : null;
      }
      
      #endregion
        
   }
}
