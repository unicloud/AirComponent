#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/6 21:54:49

// 文件名：CcpMainServiceImpl
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
using System.Linq.Expressions;

namespace UniCloud.Application.Implementation
{
   /// <summary>
   /// 表示与CcpMain相关的应用层服务的一种实现。
   /// </summary>
   public class CcpMainServiceImpl : ApplicationService, ICcpMainService
   {
      #region Private Fields
      private readonly ICcpMainRepository _ccpMainRepository;
      private readonly ICcpMainQuery _ccpMainQuery;
      private readonly IDomainService _domainService;
      private readonly IWfHistoryRepository _wfHistoryRepository;
      private readonly IWfHistoryQuery _wfHistoryQuery;
      private const string ERROR_STRING_NEWLINE = "\n";
      #endregion
      
      #region Ctor
      /// <summary>
      /// 初始化一个<c>CcpMainServiceImpl</c>类型的实例。
      /// </summary>
      /// <param name="context">用来初始化<c>CcpMainServiceImpl</c>类型的仓储上下文实例。</param>
      /// <param name="ccpMainRepository">“CcpMain”仓储实例。</param>
      /// <param name="ccpMainQuery">“ccpMainQuery”查询实例。</param>
      /// <param name="domainService">“领域服务”实例。</param>
      public CcpMainServiceImpl(IRepositoryContext context,
      ICcpMainRepository ccpMainRepository,
      ICcpMainQuery ccpMainQuery,
      IDomainService domainService,
      IWfHistoryRepository wfHistoryRepository,
          IWfHistoryQuery wfHistoryQuery)
      : base(context)
      {
      this._ccpMainRepository = ccpMainRepository;
      this._ccpMainQuery = ccpMainQuery;
      this._domainService = domainService;
      this._wfHistoryRepository = wfHistoryRepository;
      this._wfHistoryQuery = wfHistoryQuery;
      }
      #endregion
      
      #region ICcpMainService
      
      /// <summary>
      /// 创建CcpMain。
      /// </summary>
      /// <param name="ccpMains">需要创建的CcpMain。</param>
      /// <returns>创建的CcpMain。</returns>
      public CcpMainDataObjectList CreateCcpMains(CcpMainDataObjectList ccpMains)
      {
          return PerformCreateObjects<CcpMainDataObjectList, CcpMainDataObject, CcpMain>(ccpMains, _ccpMainRepository);
      }
      
      /// <summary>
      /// 删除CcpMain信息。
      /// </summary>
      /// <param name="ccpMainIDs">需要更新的CcpMain信息的ID值。</param>
      public IDList DeleteCcpMains(IDList ccpMainIDs)
      {
          PerformDeleteObjects(ccpMainIDs, _ccpMainRepository);
          return ccpMainIDs;
      }
      
      /// <summary>
      /// 更新CcpMain信息。
      /// </summary>
      /// <param name="ccpMains">需要更新的CcpMain信息。</param>
      public CcpMainDataObjectList UpdateCcpMains(CcpMainDataObjectList ccpMains)
      {
         return PerformUpdateObjects<CcpMainDataObjectList, CcpMainDataObject, CcpMain>(ccpMains,
            _ccpMainRepository,
            pdo => pdo.ID,
            (p, pdo) =>
            {
            });
      }
      
      /// <summary>
      /// 提交CcpMain的增删改数据
      /// </summary>
      /// <param name="ccpMainData"></param>
      /// <returns>提交成功的数据</returns>
      public CcpMainResultData CommitCcpMains(CcpMainResultData ccpMainData)
      {
         var resultData = new CcpMainResultData
         {
            AddedCollection = new CcpMainDataObjectList(),
            DeletedCollection = new List<string>(),
            ModefiedCollection = new CcpMainDataObjectList()
         };
         var addList = new List<CcpMain>();
         IEnumerable<string> deleteList = new List<string>();
         var updateList = new List<CcpMain>();
         
         #region Input
         
         if (ccpMainData.AddedCollection != null && ccpMainData.AddedCollection.Any())
         {
            ccpMainData.AddedCollection.ForEach(p =>
               {
                  CheckAndFillCcpMain(p);
                  addList.Add(Mapper.Map<CcpMainDataObject, CcpMain>(p));
               });
         }
         if (ccpMainData.DeletedCollection != null && ccpMainData.DeletedCollection.Any())
         {
            deleteList = ccpMainData.DeletedCollection;
         }
         if (ccpMainData.ModefiedCollection != null && ccpMainData.ModefiedCollection.Any())
         {
            ccpMainData.ModefiedCollection.ForEach(p => 
                {
                    CheckAndFillCcpMain(p);
                    updateList.Add(Mapper.Map<CcpMainDataObject, CcpMain>(p));
                });
         }
         
         #endregion
         
         _ccpMainRepository.CommitCcpMain(addList, deleteList, updateList);
         
         #region Output
         
         var addResults = new ObservableCollection<CcpMainDataObject>();
         if (addList.Any())
         {
            addList.ForEach(
               p => addResults.Add(Mapper.Map<CcpMain, CcpMainDataObject>(p)));
            resultData.AddedCollection = addResults;
          }
         var updateResults = new ObservableCollection<CcpMainDataObject>();
         if (updateList.Any())
         {
            updateList.ForEach(
               p => updateResults.Add(Mapper.Map<CcpMain, CcpMainDataObject>(p)));
            resultData.ModefiedCollection = updateResults;
          }
         if (deleteList != null && deleteList.Any())
         {
            resultData.DeletedCollection = deleteList;
         }
         
         #endregion
         
         return resultData;
      }
      private void CheckAndFillCcpMain(CcpMainDataObject ccp)
      {
          string error = "";
          //判断附件项有效性
          CheckCcpMain(ref ccp,ref error);
          //判断适用性的有效性
          CheckCcpPn(ref ccp,ref error);
          //判断间隔的有效性
          CheckCcpLimit(ref ccp,ref error);

          if (!"".Equals(error))
          {
              throw new Exception(error);
          }
      }

      private void CheckCcpMain(ref CcpMainDataObject ccp,ref string error)
      {
          //TODO 判断录入的附件项、版本号是否存在，如果存在，提示用户根据具体情况进行系统操作。
          var ccpMainlist = new CcpMainDataObjectList();
          string actype = ccp.AcType;
          string itemNo = ccp.ItemNo;
          string nhItemNo = ccp.NhItemNo;
          int version = ccp.Version;
          //机型必填性校验
          if (string.IsNullOrEmpty(actype))
          {
              error = error + "附件项,请输入机型" + ERROR_STRING_NEWLINE;
          }          
          //附件项号必填性校验
          if (string.IsNullOrEmpty(itemNo))
          {
              error = error + "附件项,请输入附件项号" + ERROR_STRING_NEWLINE;  
          }
          //上级附件项存在性校验
          if (!string.IsNullOrEmpty(nhItemNo))
          {
              Expression<Func<CcpMain, bool>> express2 = c => true;
              express2 = express2.And(main => main.AcType.Equals(actype));
              express2 = express2.And(main => main.ItemNo.Equals(nhItemNo));
              var nhCcpMains = _ccpMainRepository.GetAll(Specification<CcpMain>.Eval(express2)).ToList();
              if (nhCcpMains.Count<=0)
              {
                  error = error + "附件项,您输入的机型：[" + actype + "]上级附件项号：[" + nhItemNo + "]在本系统中不存在." + ERROR_STRING_NEWLINE;  
              }
          }

          //编辑情况下面
          if (ccp.ID != null&&ccp.ID >0)
          {
              var dbccp = GetFullCcpMainByID(ccp.ID);
              if (dbccp==null)
              {
                  error = error + "您输入的附件项：[" + itemNo + "]在本系统中不存在.\n";  
              }
              if (!itemNo.Equals(dbccp.ItemNo))
              {
                  error = error + "附件项：[" + itemNo + "]不能修改，原附件项号为：[" + dbccp.ItemNo + "]" + ERROR_STRING_NEWLINE;  
              }                                          
          }
          else {
              //新增情况下附件项版本是否已经存在
              Expression<Func<CcpMain, bool>> express = c => true;
              express = express.And(main => main.Version == version);
              express = express.And(main => main.ItemNo.Equals(itemNo));
              express = express.And(main => main.AcType.Equals(actype));
              var ccpMains = _ccpMainRepository.GetAll(Specification<CcpMain>.Eval(express)).ToList();
              if (ccpMains.Count > 0)
              {
                  error = error + "您输入的机型：[" + actype + "]附件项号：[" + itemNo + "]版本：[" + version + "]在本系统中已经存在." + ERROR_STRING_NEWLINE;
              }
          }

      }
      private void CheckCcpPn(ref CcpMainDataObject ccp,ref string warn) 
      {
          if (ccp != null && ccp.CcpPns != null && ccp.CcpPns.Count > 0) 
          {
              //TODO 判断适用性是否重复，既适用性的件号是否已经存在，适用性的件号、机型、配置是否包含。             
              var cpns = ccp.CcpPns;
              //判断间隔必填项内容
              for (int i = 0; i < cpns.Count; i++)
              {
                  var cpn = cpns[i];
                  if (String.IsNullOrEmpty(cpn.Pn))
                  {
                      int j = i + 1;
                      warn = warn + "适用件号,第[" + j + "]行，[厂家件号]不能为空" + ERROR_STRING_NEWLINE;
                  }                  
              }
              //TODO 判断录入间隔是否唯一性，间隔组、到期工作、单位
              var q =
                from p in cpns
                group p by new { p.Pn, p.Acmodel, p.Acconfig} into g
                select new
                {
                    g.Key,
                    NumProducts = g.Count()
                };
              foreach (var gp in q)
              {
                  if (gp.NumProducts > 1 && String.IsNullOrEmpty(gp.Key.Acmodel)&& String.IsNullOrEmpty(gp.Key.Acconfig))
                  {
                      warn = warn + "适用件号,厂家件号：[" + gp.Key.Pn + "]" + "，在没机型以及配置限定的情况下不能重复." + ERROR_STRING_NEWLINE;
                  }
                  else if (gp.NumProducts > 1 && !String.IsNullOrEmpty(gp.Key.Acconfig))
                  {
                      warn = warn + "适用件号,厂家件号：[" + gp.Key.Pn + "]" + "机型：[" + gp.Key.Acmodel + "]" + "，在没有配置限定的情况下不能重复." + ERROR_STRING_NEWLINE;
                  }
                  else if (gp.NumProducts > 1 && !String.IsNullOrEmpty(gp.Key.Acconfig) && !String.IsNullOrEmpty(gp.Key.Acconfig))
                  {
                      warn = warn + "适用件号,厂家件号：[" + gp.Key.Pn + "]" + "机型：[" + gp.Key.Acmodel + "]" + "配置：[" + gp.Key.Acmodel + "]" + "，不能重复." + ERROR_STRING_NEWLINE;
                  }
              }
          }
          
      }
      private void CheckCcpLimit(ref CcpMainDataObject ccp,ref string warn)
      {
          var limits = ccp.CcpLimits;
          if (ccp != null && limits != null && limits.Count > 0)
          {
              //判断间隔必填项内容
              for (int i = 0; i < limits.Count; i++)
              {
                  int j = i + 1;
                  var lm = limits[i];
                  if (String.IsNullOrEmpty(lm.Ieam))
                  {
                      
                      warn = warn + "控制间隔,第[" + j + "行，[组别]不能为空" + ERROR_STRING_NEWLINE;
                  }
                  if (String.IsNullOrEmpty(lm.WorkScope))
                  {
                      warn = warn + "控制间隔,第[" + j + "行，[到限工作]不能为空" + ERROR_STRING_NEWLINE;
                  }
                  if (String.IsNullOrEmpty(lm.Unit))
                  {
                      warn = warn + "控制间隔,第[" + j + "行，[间隔单位]不能为空" + ERROR_STRING_NEWLINE;
                  }
                  if (lm.Interval == null || lm.Interval <= 0)
                  {
                      warn = warn + "控制间隔,第[" + j + "行，[间隔]不能为空" + ERROR_STRING_NEWLINE;
                  }
              }
              //TODO 判断录入间隔是否唯一性，间隔组、到期工作、单位
              var q =
                from p in limits
                group p by new { p.Ieam, p.WorkScope, p.Unit,p.RangeType } into g
                select new
                {
                    g.Key,
                    NumProducts = g.Count()
                };
              foreach (var gp in q)
              {
                  if (gp.NumProducts>1 && String.IsNullOrEmpty(gp.Key.RangeType))
                  {
                      warn = warn + "控制间隔,间隔组别：[" + gp.Key.Ieam + "]" + "到限工作：[" + gp.Key.WorkScope + "]"
                          + "间隔单位：[" + gp.Key.Unit + "]" + "，在没适用范围情况下不能重复." + ERROR_STRING_NEWLINE;
                  }
                  else if (gp.NumProducts > 1 && !String.IsNullOrEmpty(gp.Key.RangeType))
                  {
                      bool isError = false;
                      //校验同一种适用范围间隔，范围是否有重叠现象.
                      var lm = limits.Where(o => o.Unit == gp.Key.Unit && gp.Key.Ieam == o.Ieam && gp.Key.WorkScope == o.WorkScope 
                          && gp.Key.RangeType == o.RangeType).ToList();
                      
                          for (int i = 0; i < lm.Count-1; i++) {
                              var cursor = lm[i];
                              for (int j = i+1; j < lm.Count; j++)
                              {
                                  var next = lm[j];
                                  if ((cursor.RangeMin > next.RangeMin && cursor.RangeMin < next.RangeMax) || (cursor.RangeMax > next.RangeMin && cursor.RangeMax < next.RangeMax))
                                  {
                                      isError = true;
                                  }
                              }
                          }
                          if (isError) {
                              warn = warn + "控制间隔,间隔组别：[" + gp.Key.Ieam + "]" + "到限工作：[" + gp.Key.WorkScope + "]"
                                 + "间隔单位：[" + gp.Key.Unit + "]" + "范围单位：[" + gp.Key.Unit + "]的[" + lm.Count + "]条，适用范围有交差，会引发歧义." + ERROR_STRING_NEWLINE;
                        }                                  
                  }
              }
          }
      }

      /// <summary>
      /// 根据条件查询CcpMain（展示用）
      /// </summary>
      /// <param name="acType">机型</param>
      /// <param name="itemNo">附件项号</param>
      /// <param name="ataId">章节ID</param>
      /// <param name="stateStation">状态</param>
      /// <returns></returns>
      public CcpMainDataObjectList QueryAllCcpMain(string acType, string itemNo, string ata, string stateStation)
      {
          var ccpMainlist = new CcpMainDataObjectList();
          Expression<Func<CcpMain, bool>> express = c => true;
          if (!string.IsNullOrEmpty(acType))
          {
              express = express.And(main => main.AcType.Equals(acType));
          }
          if (!string.IsNullOrEmpty(itemNo))
          {
              express = express.And(main => main.ItemNo.Equals(itemNo));
          }
          if (!string.IsNullOrEmpty(ata))
          {
              express = express.And(main => main.Ata == ata);
          }
          if (!string.IsNullOrEmpty(stateStation))
          {
              express = express.And(main => main.State == stateStation);
          }
          var ccpMains = _ccpMainRepository.GetAll(Specification<CcpMain>.Eval(express)).Select(c => new CcpMainDataObject
          {
              ID = c.ID,
              AcType = c.AcType,
              Description = c.Description,
              IsLife = c.IsLife,
              ItemNo = c.ItemNo,
              Ata = c.Ata,
              NhItemNo = c.NhItemNo,
              State = c.State,
              UpdateTime = c.UpdateTime,
              Updateby = c.Updateby,
              Version = c.Version
          });

          ccpMainlist.AddRange(ccpMains);
          return ccpMainlist;
      }
      
      /// <summary>
      /// 通过CcpMainId获取相应的CcpMainDataObject 有导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public CcpMainDataObject GetFullCcpMainByID(int id)
      {
          CcpMainDataObject cm = null;
          var result = _ccpMainRepository.GetByKey(id);
          if(result!=null){
          
             cm = Mapper.Map<CcpMain,CcpMainDataObject>(result);
             cm.WfHistorys = _wfHistoryQuery.GetWfHistorysByBusiness("CcpMain",id);
          
          }
         
          return cm;
      }
      
      /// <summary>
      ///  获取所有的CcpMain信息 有导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public CcpMainDataObjectList GetFullCcpMains()
      {
          var results = _ccpMainRepository.GetAll();
         return results!=null?Mapper.Map<IEnumerable<CcpMain>,CcpMainDataObjectList>(results) : null;
      }

      /// <summary>
      /// 审核附件项
      /// </summary>
      /// <param name="ccpMainId"></param>
      public bool VerifyCcpMain(int ccpMainId)
      {
          var ccpMain = _ccpMainRepository.Get(Specification<CcpMain>.Eval(c => c.ID == ccpMainId && c.State.ToUpper() == "E"));
          if (ccpMain != null)
          {
              var ccpMainC = _ccpMainRepository.Get(Specification<CcpMain>.Eval(c => ccpMain.AcType.Equals(c.AcType) && c.ItemNo == ccpMain.ItemNo && c.State.ToUpper() == "C"));
              if (ccpMainC != null)
              {
                  ccpMainC.State = "H";
                  _ccpMainRepository.Update(ccpMainC);
              }
              ccpMain.State = "C";
              _ccpMainRepository.Update(ccpMain);
              _ccpMainRepository.Context.Commit();
          }
          // 生成审批历史记录
          WfHistory wf = new WfHistory();
          wf.Business = "CcpMain";
          wf.BusinessID = ccpMainId;
          wf.AuditNotes = "";
          wf.Auditor = "SYS";
          wf.AuditTime = DateTime.Now;
          wf.Department="";
          wf.Seq="1";
          wf.Result="生效";
          _wfHistoryRepository.Add(wf);
          _wfHistoryRepository.Context.Commit();
          //TODO 抛出领域事件，附件项生效，重新计算附件到期预测。
          return true;
      }

      #endregion
   }
}
