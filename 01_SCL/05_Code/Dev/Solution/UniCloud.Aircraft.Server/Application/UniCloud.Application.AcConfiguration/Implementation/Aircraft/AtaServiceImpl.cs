#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/30 10:17:20

// 文件名：AtaServiceImpl
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
using UniCloud.Query.AcConfiguration;
using UniCloud.ServiceContracts;
using System.Linq;
using UniCloud.Domain.Specifications;

namespace UniCloud.Application.Implementation
{
   /// <summary>
   /// 表示与Ata相关的应用层服务的一种实现。
   /// </summary>
   public class AtaServiceImpl : ApplicationService, IAtaService
   {
      #region Private Fields
      private readonly IAtaRepository _ataRepository;
      private readonly IAtaQuery _ataQuery;
      private readonly IDomainService _domainService;
      #endregion
      
      #region Ctor
      /// <summary>
      /// 初始化一个<c>AtaServiceImpl</c>类型的实例。
      /// </summary>
      /// <param name="context">用来初始化<c>AtaServiceImpl</c>类型的仓储上下文实例。</param>
      /// <param name="ataRepository">“Ata”仓储实例。</param>
      /// <param name="ataQuery">“ataQuery”查询实例。</param>
      /// <param name="domainService">“领域服务”实例。</param>
      public AtaServiceImpl(IRepositoryContext context,
      IAtaRepository ataRepository,
      IAtaQuery ataQuery,
      IDomainService domainService)
      : base(context)
      {
      this._ataRepository = ataRepository;
      this._ataQuery = ataQuery;
      this._domainService = domainService;
      }
      #endregion
      
      #region IAtaService
      
      /// <summary>
      /// 创建Ata。
      /// </summary>
      /// <param name="atas">需要创建的Ata。</param>
      /// <returns>创建的Ata。</returns>
      public AtaDataObjectList CreateAtas(AtaDataObjectList atas)
      {
          return PerformCreateObjects<AtaDataObjectList, AtaDataObject, Ata>(atas, _ataRepository);
      }
      
      /// <summary>
      /// 删除Ata信息。
      /// </summary>
      /// <param name="ataIDs">需要更新的Ata信息的ID值。</param>
      public IDList DeleteAtas(IDList ataIDs)
      {
          PerformDeleteObjects(ataIDs, _ataRepository);
          return ataIDs;
      }
      
      /// <summary>
      /// 更新Ata信息。
      /// </summary>
      /// <param name="atas">需要更新的Ata信息。</param>
      public AtaDataObjectList UpdateAtas(AtaDataObjectList atas)
      {
         return PerformUpdateObjects<AtaDataObjectList, AtaDataObject, Ata>(atas,
            _ataRepository,
            pdo => pdo.ID,
            (p, pdo) =>
            {
                p.ATA = pdo.ATA;
                p.Description = pdo.Description;
            });
      }
      
      /// <summary>
      /// 提交Ata的增删改数据
      /// </summary>
      /// <param name="ataData"></param>
      /// <returns>提交成功的数据</returns>
      public AtaResultData CommitAtas(AtaResultData ataData)
      {
         var resultData = new AtaResultData
         {
            AddedCollection =
               new AtaDataObjectList(),
            DeletedCollection = new List<string>(),
            ModefiedCollection =
               new AtaDataObjectList()
         };
         var addList = new List<Ata>();
         IEnumerable<string> deleteList = new List<string>();
         var updateList = new List<Ata>();
         
          //ATA唯一性校验
          foreach (var ataDto in ataData.AddedCollection)
          {
              var ata = _ataRepository.Exists(Specification<Ata>.Eval(a => a.ATA == ataDto.ATA));
              if (ata)
              {
                  throw new DomainException("无法保存,因数据库中已存在ATA:"+ataDto.ATA);
              }
          }

         #region Input
         
         if (ataData.AddedCollection != null && ataData.AddedCollection.Any())
         {
            ataData.AddedCollection.ForEach(
            p =>
               {
                  addList.Add(Mapper.Map<AtaDataObject, Ata>(p));
               });
         }
         if (ataData.DeletedCollection != null && ataData.DeletedCollection.Any())
         {
            deleteList = ataData.DeletedCollection;
         }
         if (ataData.ModefiedCollection != null && ataData.ModefiedCollection.Any())
         {
            ataData.ModefiedCollection.ForEach(
               p => updateList.Add(Mapper.Map<AtaDataObject, Ata>(p)));
         }
         
         #endregion
         
         _ataRepository.CommitAta(addList, deleteList, updateList);
         
         #region Output
         
         var addResults = new ObservableCollection<AtaDataObject>();
         if (addList.Any())
         {
            addList.ForEach(
               p => addResults.Add(Mapper.Map<Ata, AtaDataObject>(p)));
            resultData.AddedCollection = addResults;
          }
         var updateResults = new ObservableCollection<AtaDataObject>();
         if (updateList.Any())
         {
            updateList.ForEach(
               p => updateResults.Add(Mapper.Map<Ata, AtaDataObject>(p)));
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
      
      #region IAtaQuery
      
      /// <summary>
      /// 获取所有的Ata信息。
      /// </summary>
      /// <returns>所有的Ata信息。</returns>
      public AtaDataObjectList GetAtas(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter)
      {
         return _ataQuery.GetAtas(colFilter,sortFilter);
      }
      
      /// <summary>
      /// 获取所有的Ata分页信息。
      /// </summary>
      /// <returns>所有的Ata分页信息。</returns>
      public AtaWithPagination GetAtaWithPagination(Pagination pagination)
      {
         return _ataQuery.GetAtaWithPagination(pagination);
      }
      
      /// <summary>
      /// 通过AtaId获取相应的AtaDataObject
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public AtaDataObject GetAtaByID(int id)
      {
         return _ataQuery.GetAtaByID(id);
      }
      
      /// <summary>
      /// 通过AtaId获取相应的AtaDataObject 有导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public AtaDataObject GetFullAtaByID(int id)
      {
          var result = _ataRepository.GetByKey(id);
         return result!=null?Mapper.Map<Ata,AtaDataObject>(result) : null;
      }
      
      /// <summary>
      ///  获取所有的Ata信息 有导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public AtaDataObjectList GetFullAtas()
      {
          var results = _ataRepository.GetAll();
         return results!=null?Mapper.Map<IEnumerable<Ata>,AtaDataObjectList>(results) : null;
      }
      
      /// <summary>
      /// 获取Ata下拉数据集合
      /// </summary>
      /// <param name="colFilter"></param>
      /// <param name="sortFilter"></param>
      /// <returns></returns>
      public KeyValueDataObjectList GetAtaCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
      {
         return _ataQuery.GetAtaCol(colFilter,sortFilter);
      }
      
      #endregion
   }
}
