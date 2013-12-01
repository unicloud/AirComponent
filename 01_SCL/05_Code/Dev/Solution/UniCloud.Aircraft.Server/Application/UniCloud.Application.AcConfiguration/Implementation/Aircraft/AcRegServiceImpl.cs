#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/30 10:17:20

// 文件名：AcRegServiceImpl
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Practices.ObjectBuilder2;
using AutoMapper;
using UniCloud.DataObjects;
using UniCloud.Domain;
using UniCloud.Domain.Model;
using UniCloud.Domain.Repositories;
using UniCloud.Domain.Services;
using UniCloud.Query.AcConfiguration;
using UniCloud.ServiceContracts;
using System.Linq;
using UniCloud.Domain.Specifications;
using UniCloud.Service.Refernce.Services;
using UniCloud.Service.Refernce;

namespace UniCloud.Application.Implementation
{
    /// <summary>
    /// 表示与AcReg相关的应用层服务的一种实现。
    /// </summary>
    public class AcRegServiceImpl : ApplicationService, IAcRegService
    {
        #region Private Fields
        private readonly IAcRegRepository _acRegRepository;
        private readonly IAcRegQuery _acRegQuery;
        private readonly IDomainService _domainService;
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个<c>AcRegServiceImpl</c>类型的实例。
        /// </summary>
        /// <param name="context">用来初始化<c>AcRegServiceImpl</c>类型的仓储上下文实例。</param>
        /// <param name="acRegRepository">“AcReg”仓储实例。</param>
        /// <param name="acRegQuery">“acRegQuery”查询实例。</param>
        /// <param name="domainService">“领域服务”实例。</param>
        public AcRegServiceImpl(IRepositoryContext context,
        IAcRegRepository acRegRepository,
        IAcRegQuery acRegQuery,
        IDomainService domainService)
            : base(context)
        {
            this._acRegRepository = acRegRepository;
            this._acRegQuery = acRegQuery;
            this._domainService = domainService;
        }
        #endregion

        #region IAcRegService

        /// <summary>
        /// 创建AcReg。
        /// </summary>
        /// <param name="acRegs">需要创建的AcReg。</param>
        /// <returns>创建的AcReg。</returns>
        public AcRegDataObjectList CreateAcRegs(AcRegDataObjectList acRegs)
        {
            return PerformCreateObjects<AcRegDataObjectList, AcRegDataObject, AcReg>(acRegs, _acRegRepository);
        }

        /// <summary>
        /// 删除AcReg信息。
        /// </summary>
        /// <param name="acRegIDs">需要更新的AcReg信息的ID值。</param>
        public IDList DeleteAcRegs(AcRegDataObjectList acRegs)
        {
            //判断Acreg 这条记录是否在FlightLog中
            IDList acRegIDs = new IDList();
            foreach (var acReg in acRegs)
            {
                bool isExist =FlightLogService.Instance.ExistFlightWithAcReg(acReg.RegNumber);
                if (isExist)
                {
                    throw new DomainException("无法删除机号为:" + acReg.RegNumber + "的记录,因为存在在该飞机的飞机记录.");
                }
                acRegIDs.Add(acReg.ID.ToString());
            }
            PerformDeleteObjects(acRegIDs, _acRegRepository);
            return acRegIDs;
        }

        /// <summary>
        /// 更新AcReg信息。
        /// </summary>
        /// <param name="acRegs">需要更新的AcReg信息。</param>
        public AcRegDataObjectList UpdateAcRegs(AcRegDataObjectList acRegs)
        {
            return PerformUpdateObjects<AcRegDataObjectList, AcRegDataObject, AcReg>(acRegs,
               _acRegRepository,
               pdo => pdo.ID,
               (p, pdo) =>
               {
                   p.EngineTr = pdo.EngineTr;
                   p.ExportCategory = pdo.ExportCategory;
                   p.ExportDate = pdo.ExportDate;
                   p.FactoryDate = pdo.FactoryDate;
                   p.ImportCategory = pdo.ImportCategory;
                   p.ImportDate = pdo.ImportDate;
                   p.IsOperation = pdo.IsOperation;
                   p.Msn = pdo.Msn;
                   p.OffsetUTC = pdo.OffsetUTC;
                   p.Operators = pdo.Operators;
                   p.Owner = pdo.Owner;
                   p.RegNumber = pdo.RegNumber;
                   p.SeatingCapacity = pdo.SeatingCapacity;
                   p.SubframeLenght = pdo.SubframeLenght;
               });
        }

        /// <summary>
        /// 提交AcReg的增删改数据
        /// </summary>
        /// <param name="acRegData"></param>
        /// <returns>提交成功的数据</returns>
        public AcRegResultData CommitAcRegs(AcRegResultData acRegData)
        {
            var resultData = new AcRegResultData
            {
                AddedCollection =
                   new AcRegDataObjectList(),
                DeletedCollection = new List<string>(),
                ModefiedCollection =
                   new AcRegDataObjectList()
            };
            var addList = new List<AcReg>();
            IEnumerable<string> deleteList = new List<string>();
            var updateList = new List<AcReg>();

            if (acRegData.AddedCollection != null)
            {
                //机号，MSN唯一性校验
                foreach (var acRegDataObject in acRegData.AddedCollection)
                {
                    IsExistAcreg(acRegDataObject);
                    IsExistMsn(acRegDataObject);
                }
            }

            if (acRegData.ModefiedCollection != null)
            {
                //机号，MSN唯一性校验
                foreach (var acRegDataObject in acRegData.ModefiedCollection)
                {
                    if (acRegDataObject.ID.HasValue)
                    {
                        var acreg = _acRegQuery.GetAcRegByID(acRegDataObject.ID.Value);
                        if (acreg.RegNumber != acRegDataObject.RegNumber)
                        {
                            IsExistAcreg(acRegDataObject);
                        }
                        if (acreg.Msn != acRegDataObject.Msn)
                        {
                            IsExistMsn(acRegDataObject);
                        }
                    }
                }
            }


            #region Input

            if (acRegData.AddedCollection != null && acRegData.AddedCollection.Any())
            {
                acRegData.AddedCollection.ForEach(
                p =>
                {
                    foreach (var acregLicense in p.AcregLicenses)
                    {
                        if (acregLicense.Document != null)
                        {

                            var docID = DocumentService.Instance.AddDocuemnt(acregLicense.Document);
                            acregLicense.DocumentGuid = docID;
                        }
                    }
                    addList.Add(Mapper.Map<AcRegDataObject, AcReg>(p));
                });
            }
            if (acRegData.DeletedCollection != null && acRegData.DeletedCollection.Any())
            {
                deleteList = acRegData.DeletedCollection;
            }
            if (acRegData.ModefiedCollection != null && acRegData.ModefiedCollection.Any())
            {
                acRegData.ModefiedCollection.ForEach(
                   p =>
                   {
                       foreach (var acregLicense in p.AcregLicenses)
                       {
                           if (acregLicense.Document != null)
                           {
                               var docID = DocumentService.Instance.AddDocuemnt(acregLicense.Document);
                               acregLicense.DocumentGuid = docID;
                           }
                       }
                       updateList.Add(Mapper.Map<AcRegDataObject, AcReg>(p));
                   });
            }

            #endregion

            _acRegRepository.CommitAcReg(addList, deleteList, updateList);

            #region Output

            var addResults = new ObservableCollection<AcRegDataObject>();
            if (addList.Any())
            {
                addList.ForEach(
                   p => addResults.Add(Mapper.Map<AcReg, AcRegDataObject>(p)));
                resultData.AddedCollection = addResults;
            }
            var updateResults = new ObservableCollection<AcRegDataObject>();
            if (updateList.Any())
            {
                updateList.ForEach(
                   p => updateResults.Add(Mapper.Map<AcReg, AcRegDataObject>(p)));
                resultData.ModefiedCollection = updateResults;
            }
            if (deleteList != null && deleteList.Any())
            {
                resultData.DeletedCollection = deleteList;
            }

            #endregion

            return resultData;
        }

        private void IsExistAcreg(AcRegDataObject acreg)
        {
            var extAc = _acRegRepository.Exists(Specification<AcReg>.Eval(
                       a => a.RegNumber == acreg.RegNumber));
            if (extAc)
            {
                throw new DomainException("无法保存!数据库中已存在机号为:" + acreg.RegNumber + "的记录.");
            }
        }

        private void IsExistMsn(AcRegDataObject acreg)
        {
            var extMsn = _acRegRepository.Exists(Specification<AcReg>.Eval(
             a => a.Msn == acreg.Msn));
            if (extMsn)
            {
                throw new DomainException("无法保存!数据库中已存在MSN为:" + acreg.Msn + "的记录.");
            }
        }

        #endregion

        #region IAcRegQuery

        /// <summary>
        /// 获取所有的AcReg信息。
        /// </summary>
        /// <returns>所有的AcReg信息。</returns>
        public AcRegDataObjectList GetAcRegs(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return _acRegQuery.GetAcRegs(colFilter, sortFilter);
        }

        /// <summary>
        /// 获取所有的AcReg分页信息。
        /// </summary>
        /// <returns>所有的AcReg分页信息。</returns>
        public AcRegWithPagination GetAcRegWithPagination(Pagination pagination)
        {
            return _acRegQuery.GetAcRegWithPagination(pagination);
        }

        /// <summary>
        /// 通过AcRegId获取相应的AcRegDataObject
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AcRegDataObject GetAcRegByID(int id)
        {
            return _acRegQuery.GetAcRegByID(id);
        }

        /// <summary>
        /// 通过AcRegId获取相应的AcRegDataObject 有导航属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AcRegDataObject GetFullAcRegByID(int id)
        {
            var result = _acRegRepository.GetByKey(id);
            return result != null ? Mapper.Map<AcReg, AcRegDataObject>(result) : null;
        }

        public AcRegDataObject GetFullAcRegByGuid(string id)
        {
            Guid guid = new Guid(id);
            var result = _acRegRepository.Get(Specification<AcReg>.Eval(a => a.Guid == guid));
            return result != null ? Mapper.Map<AcReg, AcRegDataObject>(result) : null;
        }
        public AcRegDataObject GetFullAcRegByReg(string reg)
        {

            var result = _acRegRepository.Get(Specification<AcReg>.Eval(a => a.RegNumber == reg));
            return result != null ? Mapper.Map<AcReg, AcRegDataObject>(result) : null;
        }
        
        /// <summary>
        ///  获取所有的AcReg信息 有导航属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AcRegDataObjectList GetFullAcRegs()
        {
            var results = _acRegRepository.GetAll();
            return results != null ? Mapper.Map<IEnumerable<AcReg>, AcRegDataObjectList>(results) : null;
        }

        /// <summary>
        /// 获取AcReg下拉数据集合
        /// </summary>
        /// <param name="colFilter"></param>
        /// <param name="sortFilter"></param>
        /// <returns></returns>
        public KeyValueDataObjectList GetAcRegCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
        {
            return _acRegQuery.GetAcRegCol(colFilter, sortFilter);
        }

        #endregion
    }
}
