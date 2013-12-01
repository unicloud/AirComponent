#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/6 21:54:49

// 文件名：ScnMainServiceImpl
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
using UniCloud.Domain.Specifications;
using UniCloud.Service.Refernce;

namespace UniCloud.Application.Implementation
{
    /// <summary>
    /// 表示与ScnMain相关的应用层服务的一种实现。
    /// </summary>
    public class ScnMainServiceImpl : ApplicationService, IScnMainService
    {
        #region Private Fields
        private readonly IScnMainRepository _scnMainRepository;
        private readonly IScnMainQuery _scnMainQuery;
        private readonly IDomainService _domainService;
        private readonly IWfHistoryRepository _wfHistoryRepository;
        #endregion

        #region Ctor
        /// <summary>
        /// 初始化一个<c>ScnMainServiceImpl</c>类型的实例。
        /// </summary>
        /// <param name="context">用来初始化<c>ScnMainServiceImpl</c>类型的仓储上下文实例。</param>
        /// <param name="scnMainRepository">“ScnMain”仓储实例。</param>
        /// <param name="scnMainQuery">“scnMainQuery”查询实例。</param>
        /// <param name="domainService">“领域服务”实例。</param>
        public ScnMainServiceImpl(IRepositoryContext context,
        IScnMainRepository scnMainRepository,
        IScnMainQuery scnMainQuery,
        IWfHistoryRepository wfHistoryRepository,
        IDomainService domainService)
            : base(context)
        {
            this._scnMainRepository = scnMainRepository;
            this._scnMainQuery = scnMainQuery;
            this._domainService = domainService;
            this._wfHistoryRepository = wfHistoryRepository;
        }
        #endregion

        #region IScnMainService

        /// <summary>
        /// 创建ScnMain。
        /// </summary>
        /// <param name="scnMains">需要创建的ScnMain。</param>
        /// <returns>创建的ScnMain。</returns>
        public ScnMainDataObjectList CreateScnMains(ScnMainDataObjectList scnMains)
        {
            return PerformCreateObjects<ScnMainDataObjectList, ScnMainDataObject, ScnMain>(scnMains, _scnMainRepository);
        }

        /// <summary>
        /// 删除ScnMain信息。
        /// </summary>
        /// <param name="scnMainIDs">需要更新的ScnMain信息的ID值。</param>
        public IDList DeleteScnMains(IDList scnMainIDs)
        {
            PerformDeleteObjects(scnMainIDs, _scnMainRepository);
            return scnMainIDs;
        }

        /// <summary>
        /// 更新ScnMain信息。
        /// </summary>
        /// <param name="scnMains">需要更新的ScnMain信息。</param>
        public ScnMainDataObjectList UpdateScnMains(ScnMainDataObjectList scnMains)
        {
            return PerformUpdateObjects<ScnMainDataObjectList, ScnMainDataObject, ScnMain>(scnMains,
               _scnMainRepository,
               pdo => pdo.ID,
               (p, pdo) =>
               {
               });
        }

        /// <summary>
        /// 提交ScnMain的增删改数据
        /// </summary>
        /// <param name="scnMainData"></param>
        /// <returns>提交成功的数据</returns>
        public ScnMainResultData CommitScnMains(ScnMainResultData scnMainData)
        {
            if (scnMainData.AddedCollection != null)
            {
                //判断合同号，机号是否正确
                foreach (var scnMainDataObject in scnMainData.AddedCollection)
                {
                    if (scnMainDataObject.ScnAcorders.Count > 0)
                    {
                        //TODO:暂时注释2013-11-01
                        //foreach (var scnAcorder in scnMainDataObject.ScnAcorders)
                        //{
                        //    AFRP.AFRPServiceClient _client = new AFRP.AFRPServiceClient();
                        //    var acOrderItem = 0;
                        //    int.TryParse(scnAcorder.AcOrderItem, out acOrderItem);
                        //    //如果不存在这个合同项次，则抛出异常
                        //    if (!_client.ValidationByContractRank(scnAcorder.AcOrder, acOrderItem))
                        //    {
                        //        throw new Exception("不存在合同号:" + scnAcorder.AcOrder + " 合同项次号:" + scnAcorder.AcOrderItem
                        //                            + " 的记录，请重新输入");
                        //    }
                        //}
                    }
                }
            }

            var resultData = new ScnMainResultData
            {
                AddedCollection =
                   new ScnMainDataObjectList(),
                DeletedCollection = new List<string>(),
                ModefiedCollection =
                   new ScnMainDataObjectList()
            };
            var addList = new List<ScnMain>();
            IEnumerable<string> deleteList = new List<string>();
            var updateList = new List<ScnMain>();

            var addWfList = new List<WfHistory>();
            var updateWfList = new List<WfHistory>();


            #region Input

            if (scnMainData.AddedCollection != null && scnMainData.AddedCollection.Any())
            {
                scnMainData.AddedCollection.ForEach(
                p =>
                {
                    addList.Add(Mapper.Map<ScnMainDataObject, ScnMain>(p));
                    //保存文档
                    if (p.Document != null)
                    {
                        var docID = DocumentService.Instance.AddDocument(p.Document);
                        p.DocumentID = docID.Value;
                    }
                    p.WfHistorys.ForEach(e =>
                    {
                        var wf = Mapper.Map<WfHistoryDataObject, WfHistory>(e);

                        wf.BusinessID = p.ID;
                        wf.Business = "scnmain";
                        addWfList.Add(wf);
                    });
                });
            }
            if (scnMainData.DeletedCollection != null && scnMainData.DeletedCollection.Any())
            {
                deleteList = scnMainData.DeletedCollection;
            }
            if (scnMainData.ModefiedCollection != null && scnMainData.ModefiedCollection.Any())
            {
                scnMainData.ModefiedCollection.ForEach(
                    p =>
                    {
                        //更新部分中，如果有DocumentID为空，则认为是新增的
                        if (p.Document != null && (p.DocumentID == Guid.Empty||p.DocumentID==null))
                        {
                            var docID = DocumentService.Instance.AddDocument(p.Document);
                            p.DocumentID = docID.Value;
                        }
                        updateList.Add(Mapper.Map<ScnMainDataObject, ScnMain>(p));
                        updateWfList.AddRange(Mapper.Map<WfHistoryDataObjectList, List<WfHistory>>(p.WfHistorys));
                    });

            }

            #endregion

            _scnMainRepository.CommitScnMain( addList,  deleteList,  updateList);
            //处理wfhistory

            //只增加一条记录的有效
            if (addList.Count > 0)
            {
                addWfList.ForEach(a =>
                {
                    a.BusinessID = addList.First().ID;
                });
            }


            IEnumerable<string> list = new List<string>();
            _wfHistoryRepository.CommitWfHistory( addWfList,  list,  updateWfList);
            this.Context.Commit();

            #region Output

            var addResults = new ObservableCollection<ScnMainDataObject>();
            if (addList.Any())
            {
                addList.ForEach(
                    p =>
                    {
                        var dto = Mapper.Map<ScnMain, ScnMainDataObject>(p);
                        var wfDtos = Mapper.Map<List<WfHistory>, WfHistoryDataObjectList>(addWfList);
                        dto.WfHistorys = wfDtos;
                        //取机号
                        if (dto.ScnAcorders.Count > 0)
                        {
                            foreach (var acorder in dto.ScnAcorders)
                            {
                                AFRP.AFRPServiceClient _client = new AFRP.AFRPServiceClient();
                                acorder.Acreg = _client.GetAcRegByContractRank(acorder.AcOrder, int.Parse(acorder.AcOrderItem));
                            }
                        }
                        addResults.Add(dto);
                    });
                resultData.AddedCollection = addResults;
            }
            var updateResults = new ObservableCollection<ScnMainDataObject>();
            if (updateList.Any())
            {
                updateList.ForEach(
                    p =>
                    {
                        var dto = Mapper.Map<ScnMain, ScnMainDataObject>(p);
                        var wfDtos = Mapper.Map<List<WfHistory>, WfHistoryDataObjectList>(addWfList);
                        dto.WfHistorys = wfDtos;
                        //取机号
                        if (dto.ScnAcorders.Count > 0)
                        {
                            foreach (var acorder in dto.ScnAcorders)
                            {
                                AFRP.AFRPServiceClient _client = new AFRP.AFRPServiceClient();
                                acorder.Acreg = _client.GetAcRegByContractRank(acorder.AcOrder, int.Parse(acorder.AcOrderItem));
                            }
                        }
                        addResults.Add(dto);
                    });
                resultData.ModefiedCollection = updateResults;
            }
            if (deleteList != null && deleteList.Any())
            {
                resultData.DeletedCollection = deleteList;
            }

            #endregion

            return resultData;
        }


        /// <summary>
        /// 通过ScnMainId获取相应的ScnMainDataObject 有导航属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ScnMainDataObject GetFullScnMainByID(int id)
        {
            var result = _scnMainRepository.GetByKey(id);
            if (result != null)
            {
                var scnMainDto = Mapper.Map<ScnMain, ScnMainDataObject>(result);
                var wfHistorys =
                    _wfHistoryRepository.GetAll(
                        Specification<WfHistory>.Eval(
                            w => w.BusinessID == scnMainDto.ID && w.Business.ToLower() == "scnmain"));
                if (wfHistorys.Count() > 0)
                {
                    var wfHistoryDtos = Mapper.Map<IEnumerable<WfHistory>, WfHistoryDataObjectList>(wfHistorys);
                    scnMainDto.WfHistorys = wfHistoryDtos;
                }
                return scnMainDto;
            }
            else
                return null;
        }

        /// <summary>
        ///  获取所有的ScnMain信息 有导航属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ScnMainDataObjectList GetFullScnMains()
        {
            var results = _scnMainRepository.GetAll();
            return results != null ? Mapper.Map<IEnumerable<ScnMain>, ScnMainDataObjectList>(results) : null;
        }

        #endregion
    }
}
