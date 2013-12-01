#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/18 11:52:26

// 文件名：AdsbComplyServiceImpl
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
   /// 表示与AdsbComply相关的应用层服务的一种实现。
   /// </summary>
   public class AdsbComplyServiceImpl : ApplicationService, IAdsbComplyService
   {
      #region Private Fields
      private readonly IAdsbComplyRepository _adsbComplyRepository;
      private readonly IAdsbComplyQuery _adsbComplyQuery;
      private readonly IDomainService _domainService;
      #endregion
      
      #region Ctor
      /// <summary>
      /// 初始化一个<c>AdsbComplyServiceImpl</c>类型的实例。
      /// </summary>
      /// <param name="context">用来初始化<c>AdsbComplyServiceImpl</c>类型的仓储上下文实例。</param>
      /// <param name="adsbComplyRepository">“AdsbComply”仓储实例。</param>
      /// <param name="adsbComplyQuery">“adsbComplyQuery”查询实例。</param>
      /// <param name="domainService">“领域服务”实例。</param>
      public AdsbComplyServiceImpl(IRepositoryContext context,
      IAdsbComplyRepository adsbComplyRepository,
      IAdsbComplyQuery adsbComplyQuery,
      IDomainService domainService)
      : base(context)
      {
      this._adsbComplyRepository = adsbComplyRepository;
      this._adsbComplyQuery = adsbComplyQuery;
      this._domainService = domainService;
      }
      #endregion
      
      #region IAdsbComplyService
      
      /// <summary>
      /// 创建AdsbComply。
      /// </summary>
      /// <param name="adsbComplys">需要创建的AdsbComply。</param>
      /// <returns>创建的AdsbComply。</returns>
      public AdsbComplyDataObjectList CreateAdsbComplys(AdsbComplyDataObjectList adsbComplys)
      {
          return PerformCreateObjects<AdsbComplyDataObjectList, AdsbComplyDataObject, AdsbComply>(adsbComplys, _adsbComplyRepository);
      }
      
      /// <summary>
      /// 删除AdsbComply信息。
      /// </summary>
      /// <param name="adsbComplyIDs">需要更新的AdsbComply信息的ID值。</param>
      public IDList DeleteAdsbComplys(IDList adsbComplyIDs)
      {
          PerformDeleteObjects(adsbComplyIDs, _adsbComplyRepository);
          return adsbComplyIDs;
      }
      
      /// <summary>
      /// 更新AdsbComply信息。
      /// </summary>
      /// <param name="adsbComplys">需要更新的AdsbComply信息。</param>
      public AdsbComplyDataObjectList UpdateAdsbComplys(AdsbComplyDataObjectList adsbComplys)
      {
         return PerformUpdateObjects<AdsbComplyDataObjectList, AdsbComplyDataObject, AdsbComply>(adsbComplys,
            _adsbComplyRepository,
            pdo => pdo.ID,
            (p, pdo) =>
            {
            });
      }
      
      /// <summary>
      /// 提交AdsbComply的增删改数据
      /// </summary>
      /// <param name="adsbComplyData"></param>
      /// <returns>提交成功的数据</returns>
      public AdsbComplyResultData CommitAdsbComplys(AdsbComplyResultData adsbComplyData)
      {
         var resultData = new AdsbComplyResultData
         {
            AddedCollection =
               new AdsbComplyDataObjectList(),
            DeletedCollection = new List<string>(),
            ModefiedCollection =
               new AdsbComplyDataObjectList()
         };
         var addList = new List<AdsbComply>();
         IEnumerable<string> deleteList = new List<string>();
         var updateList = new List<AdsbComply>();
         
         #region Input
         
         if (adsbComplyData.AddedCollection != null && adsbComplyData.AddedCollection.Any())
         {
            adsbComplyData.AddedCollection.ForEach(
            p =>
               {
                  addList.Add(Mapper.Map<AdsbComplyDataObject, AdsbComply>(p));
               });
         }
         if (adsbComplyData.DeletedCollection != null && adsbComplyData.DeletedCollection.Any())
         {
            deleteList = adsbComplyData.DeletedCollection;
         }
         if (adsbComplyData.ModefiedCollection != null && adsbComplyData.ModefiedCollection.Any())
         {
            adsbComplyData.ModefiedCollection.ForEach(
               p => updateList.Add(Mapper.Map<AdsbComplyDataObject, AdsbComply>(p)));
         }
         
         #endregion
         
         _adsbComplyRepository.CommitAdsbComply(addList, deleteList, updateList);
         
         #region Output
         
         var addResults = new ObservableCollection<AdsbComplyDataObject>();
         if (addList.Any())
         {
            addList.ForEach(
               p => addResults.Add(Mapper.Map<AdsbComply, AdsbComplyDataObject>(p)));
            resultData.AddedCollection = addResults;
          }
         var updateResults = new ObservableCollection<AdsbComplyDataObject>();
         if (updateList.Any())
         {
            updateList.ForEach(
               p => updateResults.Add(Mapper.Map<AdsbComply, AdsbComplyDataObject>(p)));
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
