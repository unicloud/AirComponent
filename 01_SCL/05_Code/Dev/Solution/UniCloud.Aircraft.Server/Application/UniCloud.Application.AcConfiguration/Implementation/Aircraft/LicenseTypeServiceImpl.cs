#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/30 10:17:20

// 文件名：LicenseTypeServiceImpl
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
   /// 表示与LicenseType相关的应用层服务的一种实现。
   /// </summary>
   public class LicenseTypeServiceImpl : ApplicationService, ILicenseTypeService
   {
      #region Private Fields
      private readonly ILicenseTypeRepository _licenseTypeRepository;
      private readonly ILicenseTypeQuery _licenseTypeQuery;
      private readonly IDomainService _domainService;
      #endregion
      
      #region Ctor
      /// <summary>
      /// 初始化一个<c>LicenseTypeServiceImpl</c>类型的实例。
      /// </summary>
      /// <param name="context">用来初始化<c>LicenseTypeServiceImpl</c>类型的仓储上下文实例。</param>
      /// <param name="licenseTypeRepository">“LicenseType”仓储实例。</param>
      /// <param name="licenseTypeQuery">“licenseTypeQuery”查询实例。</param>
      /// <param name="domainService">“领域服务”实例。</param>
      public LicenseTypeServiceImpl(IRepositoryContext context,
      ILicenseTypeRepository licenseTypeRepository,
      ILicenseTypeQuery licenseTypeQuery,
      IDomainService domainService)
      : base(context)
      {
      this._licenseTypeRepository = licenseTypeRepository;
      this._licenseTypeQuery = licenseTypeQuery;
      this._domainService = domainService;
      }
      #endregion
      
      #region ILicenseTypeService
      
      /// <summary>
      /// 创建LicenseType。
      /// </summary>
      /// <param name="licenseTypes">需要创建的LicenseType。</param>
      /// <returns>创建的LicenseType。</returns>
      public LicenseTypeDataObjectList CreateLicenseTypes(LicenseTypeDataObjectList licenseTypes)
      {
          return PerformCreateObjects<LicenseTypeDataObjectList, LicenseTypeDataObject, LicenseType>(licenseTypes, _licenseTypeRepository);
      }
      
      /// <summary>
      /// 删除LicenseType信息。
      /// </summary>
      /// <param name="licenseTypeIDs">需要更新的LicenseType信息的ID值。</param>
      public IDList DeleteLicenseTypes(IDList licenseTypeIDs)
      {
          PerformDeleteObjects(licenseTypeIDs, _licenseTypeRepository);
          return licenseTypeIDs;
      }
      
      /// <summary>
      /// 更新LicenseType信息。
      /// </summary>
      /// <param name="licenseTypes">需要更新的LicenseType信息。</param>
      public LicenseTypeDataObjectList UpdateLicenseTypes(LicenseTypeDataObjectList licenseTypes)
      {
         return PerformUpdateObjects<LicenseTypeDataObjectList, LicenseTypeDataObject, LicenseType>(licenseTypes,
            _licenseTypeRepository,
            pdo => pdo.ID,
            (p, pdo) =>
            {
                p.Description = pdo.Description;
                p.HasFile = pdo.HasFile;
                p.Type = pdo.Type;
            });
      }
      
      /// <summary>
      /// 提交LicenseType的增删改数据
      /// </summary>
      /// <param name="licenseTypeData"></param>
      /// <returns>提交成功的数据</returns>
      public LicenseTypeResultData CommitLicenseTypes(LicenseTypeResultData licenseTypeData)
      {
         var resultData = new LicenseTypeResultData
         {
            AddedCollection =
               new LicenseTypeDataObjectList(),
            DeletedCollection = new List<string>(),
            ModefiedCollection =
               new LicenseTypeDataObjectList()
         };
         var addList = new List<LicenseType>();
         IEnumerable<string> deleteList = new List<string>();
         var updateList = new List<LicenseType>();
         
         #region Input
         
         if (licenseTypeData.AddedCollection != null && licenseTypeData.AddedCollection.Any())
         {
            licenseTypeData.AddedCollection.ForEach(
            p =>
               {
                   //新增时验证唯一性
                   IsExistLicenseType(p);
                  addList.Add(Mapper.Map<LicenseTypeDataObject, LicenseType>(p));
               });
         }
         if (licenseTypeData.DeletedCollection != null && licenseTypeData.DeletedCollection.Any())
         {
            deleteList = licenseTypeData.DeletedCollection;
         }
         if (licenseTypeData.ModefiedCollection != null && licenseTypeData.ModefiedCollection.Any())
         {
            licenseTypeData.ModefiedCollection.ForEach(
               p =>
               {
                   var licenseType = _licenseTypeRepository.GetByKey(p.ID);
                   //更新时验证唯一性
                   if (p.Type != licenseType.Type)
                   {
                       IsExistLicenseType(p);
                   }
                   updateList.Add(Mapper.Map<LicenseTypeDataObject, LicenseType>(p));
               });
         }
         
         #endregion
         
         _licenseTypeRepository.CommitLicenseType(addList, deleteList, updateList);
         
         #region Output
         
         var addResults = new ObservableCollection<LicenseTypeDataObject>();
         if (addList.Any())
         {
            addList.ForEach(
               p => addResults.Add(Mapper.Map<LicenseType, LicenseTypeDataObject>(p)));
            resultData.AddedCollection = addResults;
          }
         var updateResults = new ObservableCollection<LicenseTypeDataObject>();
         if (updateList.Any())
         {
            updateList.ForEach(
               p => updateResults.Add(Mapper.Map<LicenseType, LicenseTypeDataObject>(p)));
            resultData.ModefiedCollection = updateResults;
          }
         if (deleteList != null && deleteList.Any())
         {
            resultData.DeletedCollection = deleteList;
         }
         
         #endregion
         
         return resultData;
      }

      private void IsExistLicenseType(LicenseTypeDataObject licenseType)
      {
          bool isExist = _licenseTypeRepository.Exists(Specification<LicenseType>.Eval(a => a.Type == licenseType.Type));
          if (isExist)
          {
              throw new DomainException("无法保存!数据库中已存在证照类型为:" + licenseType.Type + "的记录.");
          }
      }

      #endregion
      
      


      #region ILicenseTypeQuery
      
      /// <summary>
      /// 获取所有的LicenseType信息。
      /// </summary>
      /// <returns>所有的LicenseType信息。</returns>
      public LicenseTypeDataObjectList GetLicenseTypes(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter)
      {
         return _licenseTypeQuery.GetLicenseTypes(colFilter,sortFilter);
      }
      
      /// <summary>
      /// 获取所有的LicenseType分页信息。
      /// </summary>
      /// <returns>所有的LicenseType分页信息。</returns>
      public LicenseTypeWithPagination GetLicenseTypeWithPagination(Pagination pagination)
      {
         return _licenseTypeQuery.GetLicenseTypeWithPagination(pagination);
      }
      
      /// <summary>
      /// 通过LicenseTypeId获取相应的LicenseTypeDataObject
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public LicenseTypeDataObject GetLicenseTypeByID(int id)
      {
         return _licenseTypeQuery.GetLicenseTypeByID(id);
      }
      
      /// <summary>
      /// 通过LicenseTypeId获取相应的LicenseTypeDataObject 有导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public LicenseTypeDataObject GetFullLicenseTypeByID(int id)
      {
          var result = _licenseTypeRepository.GetByKey(id);
         return result!=null?Mapper.Map<LicenseType,LicenseTypeDataObject>(result) : null;
      }
      
      /// <summary>
      ///  获取所有的LicenseType信息 有导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public LicenseTypeDataObjectList GetFullLicenseTypes()
      {
          var results = _licenseTypeRepository.GetAll();
         return results!=null?Mapper.Map<IEnumerable<LicenseType>,LicenseTypeDataObjectList>(results) : null;
      }
      
      /// <summary>
      /// 获取LicenseType下拉数据集合
      /// </summary>
      /// <param name="colFilter"></param>
      /// <param name="sortFilter"></param>
      /// <returns></returns>
      public KeyValueDataObjectList GetLicenseTypeCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
      {
         return _licenseTypeQuery.GetLicenseTypeCol(colFilter,sortFilter);
      }
      
      #endregion
   }
}
