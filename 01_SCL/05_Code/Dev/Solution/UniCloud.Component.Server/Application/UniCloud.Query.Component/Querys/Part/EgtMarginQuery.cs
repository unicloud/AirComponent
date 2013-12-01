#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/16 10:49:57

// 文件名：EgtMarginQuery
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Linq;
using System.Linq.Expressions;
using UniCloud.DataObjects;
using UniCloud.Domain.Model;
using UniCloud.Domain.Repositories.EntityFramework;

namespace UniCloud.Query
{
   /// <summary>
   /// 表示用于EgtMargin的查询接口。
   /// </summary>
   public class EgtMarginQuery: IEgtMarginQuery
   {
       private readonly ComponentDbContext _context;
      
      public EgtMarginQuery(IUniCloudDbContext context)
      {
          _context = context as ComponentDbContext;
      }
      
      #region Query EgtMargin
      
      /// <summary>
      /// 获取所有EgtMargin
      /// </summary>
      /// <returns>所有的EgtMargin。</returns>
      public EgtMarginDataObjectList GetEgtMargins(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter)
      {
         Expression<Func<EgtMargin, bool>> source = p => true;
         return GetEgtMarginList(source);
      }
      
      /// <summary>
      /// 获取所有EgtMargin分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的EgtMargin分页信息。</returns>
      public EgtMarginWithPagination GetEgtMarginWithPagination(Pagination pagination)
      {
         Expression<Func<EgtMargin, bool>> wherePredicate = p => true;
         Expression<Func<EgtMargin, dynamic>> sortPredicate = t =>t.ID;
         return GetEgtMarginPage(wherePredicate,sortPredicate,pagination);
      }
      
      /// <summary>
      /// 通过EgtMarginId获取相应的EgtMargin
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
       public EgtMarginDataObject GetEgtMarginByID(int id)
      {
         Expression<Func<EgtMargin, bool>> source = p => p.ID == id;
         var result = GetEgtMarginList(source);
         return result == null ? null : result.FirstOrDefault();
      }
      
      #endregion
      
      #region Common Query
      
       private EgtMarginDataObjectList GetEgtMarginList(Expression<Func<EgtMargin, bool>> source)
      {
         var queryResult = (_context.EgtMargins.Where(source).Select(t => new EgtMarginDataObject()
            {
               PnRegID = t.PnRegID,
               SnRegID = t.SnRegID,
               Egtm = t.Egtm,
               Operator = t.Operator,
               OperateDate = t.OperateDate,
               ID = t.ID,
            })).ToList();
         if (!queryResult.Any()) return new EgtMarginDataObjectList();
         var transferResult = new EgtMarginDataObjectList();
         queryResult.ForEach(transferResult.Add);
         return transferResult;
      }
      
       private EgtMarginWithPagination GetEgtMarginPage(Expression<Func<EgtMargin, bool>> wherePredicate,
                  Expression<Func<EgtMargin, dynamic>> sortPredicate,
                  Pagination pagination)
      {
         Expression<Func<EgtMargin,EgtMarginDataObject>> mapper=t=> new EgtMarginDataObject
            {
               PnRegID = t.PnRegID,
               SnRegID = t.SnRegID,
               Egtm = t.Egtm,
               Operator = t.Operator,
               OperateDate = t.OperateDate,
               ID = t.ID,
            };
         var EgtMarginResult = _context.LoadPageDataObjects<EgtMargin,EgtMarginDataObject>(wherePredicate, sortPredicate, pagination, mapper);
         if(EgtMarginResult==null) return null;
         pagination.TotalPages=EgtMarginResult.TotalPages;
         var EgtMarginWithPagination= new EgtMarginWithPagination
            {
               Pagination=pagination,
               BaseDataObjectList = new BaseDataObjectList<EgtMarginDataObject>()
            };
         foreach (var value in EgtMarginResult.Data)
            {
               EgtMarginWithPagination.BaseDataObjectList.Add(value);
            }
            return EgtMarginWithPagination;
      }

       /// <summary>
       /// 通过EgtMarginId获取相应的EgtMargin
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public SnReg GetSnRegBySn(string sn)
       {
           var result = _context.SnRegs.Where(a => a.Sn == sn)
               .FirstOrDefault();
           return result;
       }

       public bool SaveSnregEgts(SnRegDataObjectList snregs)
       {
           foreach (var snreg in snregs)
           {
               if (snreg.Egtm.HasValue)
               {
                   //通过PN查询对应的SNREG
                   var sn = _context.SnRegs.Where(a => a.Sn == snreg.Sn).FirstOrDefault();
                   if (sn != null)
                   {
                       if (snreg.EgtMarginID.HasValue)
                       {
                           //如果数据库中EGTM与前台不一致，则说明有变化，新增一条记录
                           if (snreg.Egtm != sn.Egtm)
                           {
                               EgtMargin egt = new EgtMargin()
                               {
                                   Egtm = snreg.Egtm,
                                   OperateDate = DateTime.Now,
                                   Operator = snreg.Operator,
                                   PnRegID = snreg.PnRegID,
                                   SnRegID = snreg.ID
                               };
                               _context.EgtMargins.Add(egt);
                               sn.Egtm = snreg.Egtm;
                           }
                       }
                       else
                       {
                           EgtMargin egt = new EgtMargin()
                           {
                               Egtm = snreg.Egtm,
                               OperateDate = DateTime.Now,
                               Operator = snreg.Operator,
                               PnRegID = snreg.PnRegID,
                               SnRegID = snreg.ID
                           };
                           _context.EgtMargins.Add(egt);
                           sn.Egtm = snreg.Egtm;
                       }
                   }
               }
           }
           _context.SaveChanges();
           return true;
       }

       /// <summary>
       /// 保存导入的EGT文件
       /// </summary>
       /// <param name="snregs"></param>
       /// <returns></returns>
       public bool SaveImportEgts(SnRegDataObjectList snregs)
       {
           foreach (var snreg in snregs)
           {
               //通过PN查询对应的SNREG
               var sn = _context.SnRegs.Where(a => a.Sn == snreg.Sn).FirstOrDefault();
               if (sn != null)
               {
                   //当前SNREG增加一个EGTM记录
                   EgtMargin egt = new EgtMargin()
                   {
                       Egtm = snreg.Egtm,
                       OperateDate = DateTime.Now,
                       Operator = snreg.Operator,
                       PnRegID = sn.PnRegID,
                       SnRegID = sn.ID
                   };
                   _context.EgtMargins.Add(egt);
                   sn.Egtm = snreg.Egtm;
               }
           }
           _context.SaveChanges();
           return true;
       }
      
      #endregion
      
   }
}
