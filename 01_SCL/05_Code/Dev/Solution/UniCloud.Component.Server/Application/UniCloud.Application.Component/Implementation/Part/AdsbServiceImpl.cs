#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/18 11:52:26

// 文件名：AdsbServiceImpl
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
   /// 表示与Adsb相关的应用层服务的一种实现。
   /// </summary>
   public class AdsbServiceImpl : ApplicationService, IAdsbService
   {
      #region Private Fields
      private readonly IAdsbRepository _adsbRepository;
      private readonly IAdsbQuery _adsbQuery;
      private readonly IDomainService _domainService;
      #endregion
      
      #region Ctor
      /// <summary>
      /// 初始化一个<c>AdsbServiceImpl</c>类型的实例。
      /// </summary>
      /// <param name="context">用来初始化<c>AdsbServiceImpl</c>类型的仓储上下文实例。</param>
      /// <param name="adsbRepository">“Adsb”仓储实例。</param>
      /// <param name="adsbQuery">“adsbQuery”查询实例。</param>
      /// <param name="domainService">“领域服务”实例。</param>
      public AdsbServiceImpl(IRepositoryContext context,
      IAdsbRepository adsbRepository,
      IAdsbQuery adsbQuery,
      IDomainService domainService)
      : base(context)
      {
      this._adsbRepository = adsbRepository;
      this._adsbQuery = adsbQuery;
      this._domainService = domainService;
      }
      #endregion
      
      #region IAdsbService
      
      /// <summary>
      /// 创建Adsb。
      /// </summary>
      /// <param name="adsbs">需要创建的Adsb。</param>
      /// <returns>创建的Adsb。</returns>
      public AdsbDataObjectList CreateAdsbs(AdsbDataObjectList adsbs)
      {
          return PerformCreateObjects<AdsbDataObjectList, AdsbDataObject, Adsb>(adsbs, _adsbRepository);
      }
      
      /// <summary>
      /// 删除Adsb信息。
      /// </summary>
      /// <param name="adsbIDs">需要更新的Adsb信息的ID值。</param>
      public IDList DeleteAdsbs(IDList adsbIDs)
      {
          PerformDeleteObjects(adsbIDs, _adsbRepository);
          return adsbIDs;
      }
      
      /// <summary>
      /// 更新Adsb信息。
      /// </summary>
      /// <param name="adsbs">需要更新的Adsb信息。</param>
      public AdsbDataObjectList UpdateAdsbs(AdsbDataObjectList adsbs)
      {
         return PerformUpdateObjects<AdsbDataObjectList, AdsbDataObject, Adsb>(adsbs,
            _adsbRepository,
            pdo => pdo.ID,
            (p, pdo) =>
            {
            });
      }
      
      /// <summary>
      /// 提交Adsb的增删改数据
      /// </summary>
      /// <param name="adsbData"></param>
      /// <returns>提交成功的数据</returns>
      public AdsbResultData CommitAdsbs(AdsbResultData adsbData)
      {
         var resultData = new AdsbResultData
         {
            AddedCollection =
               new AdsbDataObjectList(),
            DeletedCollection = new List<string>(),
            ModefiedCollection =
               new AdsbDataObjectList()
         };
         var addList = new List<Adsb>();
         IEnumerable<string> deleteList = new List<string>();
         var updateList = new List<Adsb>();
         
         #region Input
         
         if (adsbData.AddedCollection != null && adsbData.AddedCollection.Any())
         {
            adsbData.AddedCollection.ForEach(
            p =>
               {
                  addList.Add(Mapper.Map<AdsbDataObject, Adsb>(p));
               });
         }
         if (adsbData.DeletedCollection != null && adsbData.DeletedCollection.Any())
         {
            deleteList = adsbData.DeletedCollection;
         }
         if (adsbData.ModefiedCollection != null && adsbData.ModefiedCollection.Any())
         {
            adsbData.ModefiedCollection.ForEach(
               p => updateList.Add(Mapper.Map<AdsbDataObject, Adsb>(p)));
         }
         
         #endregion
         
         _adsbRepository.CommitAdsb(addList, deleteList, updateList);
         
         #region Output
         
         var addResults = new ObservableCollection<AdsbDataObject>();
         if (addList.Any())
         {
            addList.ForEach(
               p => addResults.Add(Mapper.Map<Adsb, AdsbDataObject>(p)));
            resultData.AddedCollection = addResults;
          }
         var updateResults = new ObservableCollection<AdsbDataObject>();
         if (updateList.Any())
         {
            updateList.ForEach(
               p => updateResults.Add(Mapper.Map<Adsb, AdsbDataObject>(p)));
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
