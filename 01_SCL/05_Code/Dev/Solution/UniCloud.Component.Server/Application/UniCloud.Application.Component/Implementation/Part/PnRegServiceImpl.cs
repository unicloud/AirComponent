#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/6 21:54:49

// 文件名：PnRegServiceImpl
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
   /// 表示与PnReg相关的应用层服务的一种实现。
   /// </summary>
   public class PnRegServiceImpl : ApplicationService, IPnRegService
   {
      #region Private Fields
      private readonly IPnRegRepository _pnRegRepository;
      private readonly IPnRegQuery _pnRegQuery;
      private readonly IDomainService _domainService;
      #endregion
      
      #region Ctor
      /// <summary>
      /// 初始化一个<c>PnRegServiceImpl</c>类型的实例。
      /// </summary>
      /// <param name="context">用来初始化<c>PnRegServiceImpl</c>类型的仓储上下文实例。</param>
      /// <param name="pnRegRepository">“PnReg”仓储实例。</param>
      /// <param name="pnRegQuery">“pnRegQuery”查询实例。</param>
      /// <param name="domainService">“领域服务”实例。</param>
      public PnRegServiceImpl(IRepositoryContext context,
      IPnRegRepository pnRegRepository,
      IPnRegQuery pnRegQuery,
      IDomainService domainService)
      : base(context)
      {
      this._pnRegRepository = pnRegRepository;
      this._pnRegQuery = pnRegQuery;
      this._domainService = domainService;
      }
      #endregion
      
      #region IPnRegService
      
      /// <summary>
      /// 创建PnReg。
      /// </summary>
      /// <param name="pnRegs">需要创建的PnReg。</param>
      /// <returns>创建的PnReg。</returns>
      public PnRegDataObjectList CreatePnRegs(PnRegDataObjectList pnRegs)
      {
          return PerformCreateObjects<PnRegDataObjectList, PnRegDataObject, PnReg>(pnRegs, _pnRegRepository);
      }
      
      /// <summary>
      /// 删除PnReg信息。
      /// </summary>
      /// <param name="pnRegIDs">需要更新的PnReg信息的ID值。</param>
      public IDList DeletePnRegs(IDList pnRegIDs)
      {
          PerformDeleteObjects(pnRegIDs, _pnRegRepository);
          return pnRegIDs;
      }
      
      /// <summary>
      /// 更新PnReg信息。
      /// </summary>
      /// <param name="pnRegs">需要更新的PnReg信息。</param>
      public PnRegDataObjectList UpdatePnRegs(PnRegDataObjectList pnRegs)
      {
         return PerformUpdateObjects<PnRegDataObjectList, PnRegDataObject, PnReg>(pnRegs,
            _pnRegRepository,
            pdo => pdo.ID,
            (p, pdo) =>
            {
            });
      }
      
      /// <summary>
      /// 提交PnReg的增删改数据
      /// </summary>
      /// <param name="pnRegData"></param>
      /// <returns>提交成功的数据</returns>
      public PnRegResultData CommitPnRegs(PnRegResultData pnRegData)
      {
         var resultData = new PnRegResultData
         {
            AddedCollection =
               new PnRegDataObjectList(),
            DeletedCollection = new List<string>(),
            ModefiedCollection =
               new PnRegDataObjectList()
         };
         var addList = new List<PnReg>();
         IEnumerable<string> deleteList = new List<string>();
         var updateList = new List<PnReg>();
         
         #region Input
         
         if (pnRegData.AddedCollection != null && pnRegData.AddedCollection.Any())
         {
            pnRegData.AddedCollection.ForEach(
            p =>
               {
                  addList.Add(Mapper.Map<PnRegDataObject, PnReg>(p));
               });
         }
         if (pnRegData.DeletedCollection != null && pnRegData.DeletedCollection.Any())
         {
            deleteList = pnRegData.DeletedCollection;
         }
         if (pnRegData.ModefiedCollection != null && pnRegData.ModefiedCollection.Any())
         {
            pnRegData.ModefiedCollection.ForEach(
               p => updateList.Add(Mapper.Map<PnRegDataObject, PnReg>(p)));
         }
         
         #endregion
         
         _pnRegRepository.CommitPnReg(addList, deleteList, updateList);
         
         #region Output
         
         var addResults = new ObservableCollection<PnRegDataObject>();
         if (addList.Any())
         {
            addList.ForEach(
               p => addResults.Add(Mapper.Map<PnReg, PnRegDataObject>(p)));
            resultData.AddedCollection = addResults;
          }
         var updateResults = new ObservableCollection<PnRegDataObject>();
         if (updateList.Any())
         {
            updateList.ForEach(
               p => updateResults.Add(Mapper.Map<PnReg, PnRegDataObject>(p)));
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
      
      #region IPnRegQuery
      
      /// <summary>
      /// 通过PnRegId获取相应的PnRegDataObject 有导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public PnRegDataObject GetFullPnRegByID(int id)
      {
          var result = _pnRegRepository.GetByKey(id);
         return result!=null?Mapper.Map<PnReg,PnRegDataObject>(result) : null;
      }
      
      /// <summary>
      ///  获取所有的PnReg信息 有导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public PnRegDataObjectList GetFullPnRegs()
      {
          var results = _pnRegRepository.GetAll();
         return results!=null?Mapper.Map<IEnumerable<PnReg>,PnRegDataObjectList>(results) : null;
      }
      
      #endregion
   }
}
