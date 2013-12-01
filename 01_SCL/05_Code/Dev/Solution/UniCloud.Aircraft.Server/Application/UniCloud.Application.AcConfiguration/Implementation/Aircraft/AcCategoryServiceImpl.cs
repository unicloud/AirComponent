#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/30 10:17:20

// 文件名：AcCategoryServiceImpl
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

namespace UniCloud.Application.Implementation
{
   /// <summary>
   /// 表示与AcCategory相关的应用层服务的一种实现。
   /// </summary>
   public class AcCategoryServiceImpl : ApplicationService, IAcCategoryService
   {
      #region Private Fields
      private readonly IAcCategoryRepository _acCategoryRepository;
      private readonly IAcCategoryQuery _acCategoryQuery;
      private readonly IDomainService _domainService;
      #endregion
      
      #region Ctor
      /// <summary>
      /// 初始化一个<c>AcCategoryServiceImpl</c>类型的实例。
      /// </summary>
      /// <param name="context">用来初始化<c>AcCategoryServiceImpl</c>类型的仓储上下文实例。</param>
      /// <param name="acCategoryRepository">“AcCategory”仓储实例。</param>
      /// <param name="acCategoryQuery">“acCategoryQuery”查询实例。</param>
      /// <param name="domainService">“领域服务”实例。</param>
      public AcCategoryServiceImpl(IRepositoryContext context,
      IAcCategoryRepository acCategoryRepository,
      IAcCategoryQuery acCategoryQuery,
      IDomainService domainService)
      : base(context)
      {
      this._acCategoryRepository = acCategoryRepository;
      this._acCategoryQuery = acCategoryQuery;
      this._domainService = domainService;
      }
      #endregion
      
      #region IAcCategoryService
      
      /// <summary>
      /// 创建AcCategory。
      /// </summary>
      /// <param name="acCategorys">需要创建的AcCategory。</param>
      /// <returns>创建的AcCategory。</returns>
      public AcCategoryDataObjectList CreateAcCategorys(AcCategoryDataObjectList acCategorys)
      {
          return PerformCreateObjects<AcCategoryDataObjectList, AcCategoryDataObject, AcCategory>(acCategorys, _acCategoryRepository);
      }
      
      /// <summary>
      /// 删除AcCategory信息。
      /// </summary>
      /// <param name="acCategoryIDs">需要更新的AcCategory信息的ID值。</param>
      public IDList DeleteAcCategorys(IDList acCategoryIDs)
      {
          PerformDeleteObjects(acCategoryIDs, _acCategoryRepository);
          return acCategoryIDs;
      }
      
      /// <summary>
      /// 更新AcCategory信息。
      /// </summary>
      /// <param name="acCategorys">需要更新的AcCategory信息。</param>
      public AcCategoryDataObjectList UpdateAcCategorys(AcCategoryDataObjectList acCategorys)
      {
         return PerformUpdateObjects<AcCategoryDataObjectList, AcCategoryDataObject, AcCategory>(acCategorys,
            _acCategoryRepository,
            pdo => pdo.ID,
            (p, pdo) =>
            {
                p.Level = pdo.Level;
                p.Regional = pdo.Regional;
            });
      }
      
      /// <summary>
      /// 提交AcCategory的增删改数据
      /// </summary>
      /// <param name="acCategoryData"></param>
      /// <returns>提交成功的数据</returns>
      public AcCategoryResultData CommitAcCategorys(AcCategoryResultData acCategoryData)
      {
         var resultData = new AcCategoryResultData
         {
            AddedCollection =
               new AcCategoryDataObjectList(),
            DeletedCollection = new List<string>(),
            ModefiedCollection =
               new AcCategoryDataObjectList()
         };
         var addList = new List<AcCategory>();
         IEnumerable<string> deleteList = new List<string>();
         var updateList = new List<AcCategory>();
         
         #region Input
         
         if (acCategoryData.AddedCollection != null && acCategoryData.AddedCollection.Any())
         {
            acCategoryData.AddedCollection.ForEach(
            p =>
               {
                  addList.Add(Mapper.Map<AcCategoryDataObject, AcCategory>(p));
               });
         }
         if (acCategoryData.DeletedCollection != null && acCategoryData.DeletedCollection.Any())
         {
            deleteList = acCategoryData.DeletedCollection;
         }
         if (acCategoryData.ModefiedCollection != null && acCategoryData.ModefiedCollection.Any())
         {
            acCategoryData.ModefiedCollection.ForEach(
               p => updateList.Add(Mapper.Map<AcCategoryDataObject, AcCategory>(p)));
         }
         
         #endregion
         
         _acCategoryRepository.CommitAcCategory(addList, deleteList, updateList);
         
         #region Output
         
         var addResults = new ObservableCollection<AcCategoryDataObject>();
         if (addList.Any())
         {
            addList.ForEach(
               p => addResults.Add(Mapper.Map<AcCategory, AcCategoryDataObject>(p)));
            resultData.AddedCollection = addResults;
          }
         var updateResults = new ObservableCollection<AcCategoryDataObject>();
         if (updateList.Any())
         {
            updateList.ForEach(
               p => updateResults.Add(Mapper.Map<AcCategory, AcCategoryDataObject>(p)));
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
      
      #region IAcCategoryQuery
      
      /// <summary>
      /// 获取所有的AcCategory信息。
      /// </summary>
      /// <returns>所有的AcCategory信息。</returns>
      public AcCategoryDataObjectList GetAcCategorys(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter)
      {
         return _acCategoryQuery.GetAcCategorys(colFilter,sortFilter);
      }
      
      /// <summary>
      /// 获取所有的AcCategory分页信息。
      /// </summary>
      /// <returns>所有的AcCategory分页信息。</returns>
      public AcCategoryWithPagination GetAcCategoryWithPagination(Pagination pagination)
      {
         return _acCategoryQuery.GetAcCategoryWithPagination(pagination);
      }
      
      /// <summary>
      /// 通过AcCategoryId获取相应的AcCategoryDataObject
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public AcCategoryDataObject GetAcCategoryByID(int id)
      {
         return _acCategoryQuery.GetAcCategoryByID(id);
      }
      
      /// <summary>
      /// 通过AcCategoryId获取相应的AcCategoryDataObject 有导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public AcCategoryDataObject GetFullAcCategoryByID(int id)
      {
          var result = _acCategoryRepository.GetByKey(id);
         return result!=null?Mapper.Map<AcCategory,AcCategoryDataObject>(result) : null;
      }
      
      /// <summary>
      ///  获取所有的AcCategory信息 有导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public AcCategoryDataObjectList GetFullAcCategorys()
      {
          var results = _acCategoryRepository.GetAll();
         return results!=null?Mapper.Map<IEnumerable<AcCategory>,AcCategoryDataObjectList>(results) : null;
      }
      
      /// <summary>
      /// 获取AcCategory下拉数据集合
      /// </summary>
      /// <param name="colFilter"></param>
      /// <param name="sortFilter"></param>
      /// <returns></returns>
      public KeyValueDataObjectList GetAcCategoryCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
      {
         return _acCategoryQuery.GetAcCategoryCol(colFilter,sortFilter);
      }
      
      #endregion
   }
}
