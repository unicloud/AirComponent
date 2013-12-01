#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/30 10:17:20

// 文件名：AcTypeServiceImpl
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
using UniCloud.Domain.Services;
using UniCloud.Query.AcConfiguration;
using UniCloud.ServiceContracts;
using System.Linq;
using UniCloud.Domain.Repositories;
using UniCloud.Domain.Specifications;

namespace UniCloud.Application.Implementation
{
    /// <summary>
    /// 表示与AcType相关的应用层服务的一种实现。
    /// </summary>
    public class AcTypeServiceImpl : ApplicationService, IAcTypeService
    {
        #region Private Fields
        private readonly IAcTypeRepository _acTypeRepository;
        private readonly IAcRegRepository _acRegRepository;
        private readonly IAcTypeQuery _acTypeQuery;
        private readonly IDomainService _domainService;
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个<c>AcTypeServiceImpl</c>类型的实例。
        /// </summary>
        /// <param name="context">用来初始化<c>AcTypeServiceImpl</c>类型的仓储上下文实例。</param>
        /// <param name="acTypeRepository">“AcType”仓储实例。</param>
        /// <param name="acTypeQuery">“acTypeQuery”查询实例。</param>
        /// <param name="domainService">“领域服务”实例。</param>
        public AcTypeServiceImpl(IRepositoryContext context,
        IAcTypeRepository acTypeRepository,
        IAcRegRepository acRegRepository,
        IAcTypeQuery acTypeQuery,
        IDomainService domainService)
            : base(context)
        {
            this._acTypeRepository = acTypeRepository;
            this._acTypeQuery = acTypeQuery;
            this._domainService = domainService;
            this._acRegRepository = acRegRepository;
        }
        #endregion

        #region IAcTypeService

        /// <summary>
        /// 创建AcType。
        /// </summary>
        /// <param name="acTypes">需要创建的AcType。</param>
        /// <returns>创建的AcType。</returns>
        public AcTypeDataObjectList CreateAcTypes(AcTypeDataObjectList acTypes)
        {
            return PerformCreateObjects<AcTypeDataObjectList, AcTypeDataObject, AcType>(acTypes, _acTypeRepository);
        }

        /// <summary>
        /// 删除AcType信息。
        /// </summary>
        /// <param name="acTypeIDs">需要更新的AcType信息的ID值。</param>
        public bool DeleteAcTypes(IDList acTypeIDs)
        {
            var actypeidlist = new IDList();
            foreach (var actypeId in acTypeIDs)
            {
                var acType = _acTypeRepository.Get(Specification<AcType>.Eval(a => a.ID.ToString() == actypeId));
                if (acType != null)
                {
                    //判断其下是否有相关的acmodel
                    if (acType.Acmodels.Count > 0)
                    {
                        throw new DomainException("无法删除飞机系列:" + acType.Name + ",因为还有与其关联的飞机机型信息");
                    }
                    //判断其下是否有相关的飞机
                    var acReg = _acRegRepository.Get(Specification<AcReg>.Eval(a => a.AcTypeID.ToString() == actypeId));
                    if (acReg == null)
                    {
                        actypeidlist.Add(actypeId);
                    }
                    else
                        throw new DomainException("无法删除飞机系列:" + acType.Name + ",因为还有与其关联的飞机信息");
                }
            }
            foreach (var actypeid in actypeidlist)
            {
                var acType = _acTypeRepository.Get(Specification<AcType>.Eval(a => a.ID.ToString() == actypeid));
                if (acType != null)
                    _acTypeRepository.DeleteAcType(acType);
            }
            return true;
        }

        /// <summary>
        /// 更新AcType信息。
        /// </summary>
        /// <param name="acTypes">需要更新的AcType信息。</param>
        public AcTypeDataObjectList UpdateAcTypes(AcTypeDataObjectList acTypes)
        {
            return PerformUpdateObjects<AcTypeDataObjectList, AcTypeDataObject, AcType>(acTypes,
               _acTypeRepository,
               pdo => pdo.ID,
               (p, pdo) =>
               {
                   p.AcCategory = pdo.AcCategory;
                   p.Description = pdo.Description;
                   p.Manufacturer = pdo.Manufacturer;
                   p.Name = pdo.Name;
               });
        }

        /// <summary>
        /// 提交AcType的增删改数据
        /// </summary>
        /// <param name="acTypeData"></param>
        /// <returns>提交成功的数据</returns>
        public AcTypeResultData CommitAcTypes(AcTypeResultData acTypeData)
        {
            var resultData = new AcTypeResultData
            {
                AddedCollection =
                   new AcTypeDataObjectList(),
                DeletedCollection = new List<string>(),
                ModefiedCollection =
                   new AcTypeDataObjectList()
            };
            var addList = new List<AcType>();
            IEnumerable<string> deleteList = new List<string>();
            var updateList = new List<AcType>();

            #region Input

            if (acTypeData.AddedCollection != null && acTypeData.AddedCollection.Any())
            {
                acTypeData.AddedCollection.ForEach(
                p =>
                {
                    addList.Add(Mapper.Map<AcTypeDataObject, AcType>(p));
                });
            }
            if (acTypeData.DeletedCollection != null && acTypeData.DeletedCollection.Any())
            {
                deleteList = acTypeData.DeletedCollection;
            }
            if (acTypeData.ModefiedCollection != null && acTypeData.ModefiedCollection.Any())
            {
                acTypeData.ModefiedCollection.ForEach(
                   p => updateList.Add(Mapper.Map<AcTypeDataObject, AcType>(p)));
            }

            #endregion

            _acTypeRepository.CommitAcType(addList, deleteList, updateList);

            #region Output

            var addResults = new ObservableCollection<AcTypeDataObject>();
            if (addList.Any())
            {
                addList.ForEach(
                   p => addResults.Add(Mapper.Map<AcType, AcTypeDataObject>(p)));
                resultData.AddedCollection = addResults;
            }
            var updateResults = new ObservableCollection<AcTypeDataObject>();
            if (updateList.Any())
            {
                updateList.ForEach(
                   p => updateResults.Add(Mapper.Map<AcType, AcTypeDataObject>(p)));
                resultData.ModefiedCollection = updateResults;
            }
            if (deleteList != null && deleteList.Any())
            {
                resultData.DeletedCollection = deleteList;
            }

            #endregion

            return resultData;
        }

        public AcTypeDataObjectList ManageAcTypeAta(AcTypeDataObjectList actypes)
        {
            var acTypeList = Mapper.Map<AcTypeDataObjectList, List<AcType>>(actypes);
            var acTypeDtos = _acTypeRepository.ManageAcTypeAta(acTypeList);
            return Mapper.Map<List<AcType>, AcTypeDataObjectList>(acTypeDtos);
        }

        public AcModelDataObjectList CreateAcModels(int acTypeId, AcModelDataObjectList acModels)
        {
            var acType = _acTypeRepository.GetByKey(acTypeId);
            if (acType != null)
            {
                for (int i = 0; i < acModels.Count; i++)
                {
                    acModels[i].AcTypeGuid = acType.Guid;
                    acType.Acmodels.Add(Mapper.Map<AcModelDataObject, AcModel>(acModels[i]));
                }
                _acTypeRepository.Update(acType);
                _acTypeRepository.Context.Commit();
            }
            return acModels;
        }

        public AcModelDataObjectList UpdateAcModels(int acTypeId, AcModelDataObjectList acModels)
        {
            var acType = _acTypeRepository.GetByKey(acTypeId);
            if (acType != null)
            {
                SetAcModel(acModels, acType);
                _acTypeRepository.Update(acType);
                _acTypeRepository.Context.Commit();
            }
            return acModels;
        }

        private void SetAcModel(AcModelDataObjectList acModels, AcType acType)
        {
            foreach (var acmodel in acModels)
            {
                var model = acType.Acmodels.FirstOrDefault(a => a.ID == acmodel.ID);
                if (model != null)
                {
                    model.Guid = acmodel.Guid;
                    if (!string.IsNullOrEmpty(acmodel.Description))
                        model.Description = acmodel.Description;
                    model.AcTypeGuid = acType.Guid;
                    foreach (var acconfig in acmodel.AcConfigs)
                    {
                        var config = model.AcConfigs.FirstOrDefault(co => co.ID == acconfig.ID);
                        if (config != null)
                        {
                            config.Guid = acconfig.Guid;
                            if (!string.IsNullOrEmpty(acconfig.Description))
                                config.Description = acconfig.Description;
                            config.AcModelGuid = model.Guid;
                            config.BEW = acconfig.BEW;
                            config.BW = acconfig.BW;
                            config.BWF = acconfig.BWF;
                            config.BWI = acconfig.BWI;
                            config.MCC = acconfig.MCC;
                            config.MLW = acconfig.MLW;
                            config.MMFW = acconfig.MMFW;
                            config.MTOW = acconfig.MTOW;
                            config.MTW = acconfig.MTW;
                            config.MZFW = acconfig.MZFW;
                        }
                        else
                        {
                            acconfig.AcModelGuid = acmodel.Guid;
                            model.AcConfigs.Add(Mapper.Map<AcConfigDataObject, AcConfig>(acconfig));
                        }
                    }
                }
            }
        }

        public AcConfigDataObjectList CreateAcConfigs(int acTypeId, int acModelId, AcConfigDataObjectList acConfigs)
        {
            var acType = _acTypeRepository.GetByKey(acTypeId);
            if (acType != null)
            {
                var acmodel = acType.Acmodels.FirstOrDefault(a => a.ID == acModelId);
                if (acmodel != null)
                {
                    for (int i = 0; i < acConfigs.Count; i++)
                    {
                        acConfigs[i].AcModelGuid = acmodel.Guid;
                        acmodel.AcConfigs.Add(Mapper.Map<AcConfigDataObject, AcConfig>(acConfigs[i]));
                    }
                    _acTypeRepository.Update(acType);
                    _acTypeRepository.Context.Commit();
                }
            }
            return acConfigs;
        }

        public AcConfigDataObjectList UpdateAcConfigs(int acTypeId, int acModelId, AcConfigDataObjectList acConfigs)
        {
            var acType = _acTypeRepository.GetByKey(acTypeId);
            if (acType != null)
            {
                var acmodel = acType.Acmodels.FirstOrDefault(a => a.ID == acModelId);
                if (acmodel != null)
                {
                    SetAcConfig(acConfigs, acmodel);
                    _acTypeRepository.Update(acType);
                    _acTypeRepository.Context.Commit();
                }
            }
            return acConfigs;
        }

        private void SetAcConfig(AcConfigDataObjectList acConfigs, AcModel acmodel)
        {
            foreach (var acConfig in acConfigs)
            {
                var config = acmodel.AcConfigs.FirstOrDefault(a => a.ID == acConfig.ID);
                if (config != null)
                {
                    config.Guid = acConfig.Guid;
                    if (!string.IsNullOrEmpty(acConfig.Description))
                        config.Description = acConfig.Description;
                    config.AcModelGuid = acmodel.Guid;
                    config.BEW = acConfig.BEW;
                    config.BW = acConfig.BW;
                    config.BWF = acConfig.BWF;
                    config.BWI = acConfig.BWI;
                    config.MCC = acConfig.MCC;
                    config.MLW = acConfig.MLW;
                    config.MMFW = acConfig.MMFW;
                    config.MTOW = acConfig.MTOW;
                    config.MTW = acConfig.MTW;
                    config.MZFW = acConfig.MZFW;
                }
            }
        }

        public bool DeleteAcModels(int acTypeId, AcModelDataObjectList acModels)
        {
            var acType = _acTypeRepository.GetByKey(acTypeId);
            if (acType != null)
            {
                var acmodelist = new AcModelDataObjectList();
                foreach (var acModel in acModels)
                {
                    //判断是否有关联的飞机配置信息
                    var oriAcModel = acType.Acmodels.FirstOrDefault(a => a.ID == acModel.ID);
                    if(oriAcModel!=null&&oriAcModel.AcConfigs.Count>0)
                        throw new DomainException("无法删除飞机机型:" + oriAcModel.Name + ",因为还有与其关联的飞机配置信息");
                    //判断是否有关联的飞机
                    var acReg = _acRegRepository.Get(Specification<AcReg>.Eval(a => a.AcModelID == acModel.ID));
                    if (acReg == null)
                    {
                        acmodelist.Add(acModel);
                    }
                    else
                        throw new DomainException("无法删除飞机机型:" + acModel.Name + ",因为还有与其关联的飞机信息");
                }
                _acTypeRepository.DeleteAcModel(acType, acmodelist.Select(Mapper.Map<AcModelDataObject, AcModel>));
                _acTypeRepository.Context.Commit();
            }
            return true;
        }

        public bool DeleteAcConfigs(int acTypeId, int acModelId, AcConfigDataObjectList acConfigs)
        {
            var acType = _acTypeRepository.GetByKey(acTypeId);
            if (acType != null)
            {
                var acmodel = acType.Acmodels.FirstOrDefault(a => a.ID == acModelId);
                if (acmodel != null)
                {
                    var acconfiglist = new AcConfigDataObjectList();
                    foreach (var acConfig in acConfigs)
                    {
                        var acreg = _acRegRepository.Get(Specification<AcReg>.Eval(a => a.AcConfigID == acConfig.ID));
                        if (acreg == null)
                        {
                            acconfiglist.Add(acConfig);
                        }
                        else
                            throw new DomainException("无法删除飞机配置:" + acConfig.Name + ",因为还有与其关联的飞机信息");
                    }
                    _acTypeRepository.DeleteAcConfig(acType, acmodel, acconfiglist.Select(Mapper.Map<AcConfigDataObject, AcConfig>));
                    _acTypeRepository.Context.Commit();
                }
            }
            return true;
        }

        #endregion

        #region IAcTypeQuery

        /// <summary>
        /// 获取所有的AcType信息。
        /// </summary>
        /// <returns>所有的AcType信息。</returns>
        public AcTypeDataObjectList GetAcTypes(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return _acTypeQuery.GetAcTypes(colFilter, sortFilter);
        }

        /// <summary>
        /// 获取所有的AcType分页信息。
        /// </summary>
        /// <returns>所有的AcType分页信息。</returns>
        public AcTypeWithPagination GetAcTypeWithPagination(Pagination pagination)
        {
            return _acTypeQuery.GetAcTypeWithPagination(pagination);
        }

        /// <summary>
        /// 通过AcTypeId获取相应的AcTypeDataObject
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AcTypeDataObject GetAcTypeByID(int id)
        {
            return _acTypeQuery.GetAcTypeByID(id);
        }

        /// <summary>
        /// 通过AcTypeId获取相应的AcTypeDataObject 有导航属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AcTypeDataObject GetFullAcTypeByID(int id)
        {
            var result = _acTypeRepository.GetByKey(id);
            return result != null ? Mapper.Map<AcType, AcTypeDataObject>(result) : null;
        }

        public AcTypeDataObject GetFullAcTypeByGuid(string id)
        {
            Guid guid = new Guid(id);
            var result = _acTypeRepository.Get(Specification<AcType>.Eval(a => a.Guid == guid));
            return result != null ? Mapper.Map<AcType, AcTypeDataObject>(result) : null;
        }

        /// <summary>
        ///  获取所有的AcType信息 有导航属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AcTypeDataObjectList GetFullAcTypes()
        {
            var results = _acTypeRepository.GetAll();
            return results != null ? Mapper.Map<IEnumerable<AcType>, AcTypeDataObjectList>(results) : null;
        }

        /// <summary>
        /// 获取AcType下拉数据集合
        /// </summary>
        /// <param name="colFilter"></param>
        /// <param name="sortFilter"></param>
        /// <returns></returns>
        public KeyValueDataObjectList GetAcTypeCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return _acTypeQuery.GetAcTypeCol(colFilter, sortFilter);
        }

        #endregion
    }
}
