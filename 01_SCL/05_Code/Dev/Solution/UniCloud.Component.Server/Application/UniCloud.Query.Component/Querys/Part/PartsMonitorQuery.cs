#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/17 23:23:10

// 文件名：PartsMonitorQuery
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
   /// 表示用于PartsMonitor的查询接口。
   /// </summary>
   public class PartsMonitorQuery: IPartsMonitorQuery
   {
      private readonly ComponentDbContext _context;
      
      public PartsMonitorQuery(IUniCloudDbContext context)
      {
         _context = context as ComponentDbContext;
      }
      
      #region Query PartsMonitor
      
      /// <summary>
      /// 获取所有PartsMonitor
      /// </summary>
      /// <returns>所有的PartsMonitor。</returns>
      public PartsMonitorDataObjectList GetPartsMonitors(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter)
      {
         Expression<Func<PartsMonitor, bool>> source = p => true;
         return GetPartsMonitorList(source);
      }
      
      /// <summary>
      /// 获取所有PartsMonitor分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的PartsMonitor分页信息。</returns>
      public PartsMonitorWithPagination GetPartsMonitorWithPagination(Pagination pagination)
      {
         Expression<Func<PartsMonitor, bool>> wherePredicate = p => true;
         Expression<Func<PartsMonitor, dynamic>> sortPredicate = t =>t.ID;
         return GetPartsMonitorPage(wherePredicate,sortPredicate,pagination);
      }
      
      /// <summary>
      /// 通过PartsMonitorId获取相应的PartsMonitor
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
       public PartsMonitorDataObject GetPartsMonitorByID(int id)
      {
         Expression<Func<PartsMonitor, bool>> source = p => p.ID == id;
         var result = GetPartsMonitorList(source);
         return result == null ? null : result.FirstOrDefault();
      }
      
      #endregion
      
      #region Common Query
      
       private PartsMonitorDataObjectList GetPartsMonitorList(Expression<Func<PartsMonitor, bool>> source)
      {
         var queryResult = (_context.PartsMonitors.Where(source).Select(t => new PartsMonitorDataObject()
            {
                ExpireDate = t.ExpireDate,                   
                ItemNo = t.ItemNo,                       
                NhItemNo = t.NhItemNo,
                PnRegID = t.PnRegID,                       
                PolicyExec = t.PolicyExec,
                RemainTime = t.RemainTime,
                SnRegID = t.SnRegID,
                UsedTime = t.UsedTime,                       
                Workscope = t.Workscope,
                SnReg = (_context.SnRegs.Where(p=>p.ID == t.SnRegID).Select(a => new SnRegDataObject(){
                    Sn = a.Sn,
                    Pn = a.PnReg.Pn,
                    Ac = a.Ac,
                    Position = a.Position,
                    Ata = a.Ata,
                    Avail = a.Avail,
                    InstallDate = a.InstallDate,
                    RepairDate = a.RepairDate,
                    RemoveDate = a.RemoveDate,
                    Zone = a.Zone,                  
                }).FirstOrDefault()),
                ID = t.ID,
            })).ToList();
         if (!queryResult.Any()) return new PartsMonitorDataObjectList();
         var transferResult = new PartsMonitorDataObjectList();
         queryResult.ForEach(transferResult.Add);
         return transferResult;
      }
      
       private PartsMonitorWithPagination GetPartsMonitorPage(Expression<Func<PartsMonitor, bool>> wherePredicate,
                  Expression<Func<PartsMonitor, dynamic>> sortPredicate,
                  Pagination pagination)
      {
         Expression<Func<PartsMonitor,PartsMonitorDataObject>> mapper=t=> new PartsMonitorDataObject
            {
                ExpireDate = t.ExpireDate,
                ItemNo = t.ItemNo,
                NhItemNo = t.NhItemNo,
                PnRegID = t.PnRegID,
                PolicyExec = t.PolicyExec,
                RemainTime = t.RemainTime,
                SnRegID = t.SnRegID,
                UsedTime = t.UsedTime,
                Workscope = t.Workscope,
                SnReg = (_context.SnRegs.Where(p => p.ID == t.SnRegID).Select(a => new SnRegDataObject()
                {
                    Sn = a.Sn,
                    Pn = a.PnReg.Pn,
                    Ac = a.Ac,
                    Position = a.Position,
                    Ata = a.Ata,
                    Avail =a.Avail,
                    InstallDate = a.InstallDate,
                    RepairDate = a.RepairDate,
                    RemoveDate = a.RemoveDate,
                    Zone = a.Zone,
                }).FirstOrDefault()),
               ID = t.ID,
            };
         var PartsMonitorResult = _context.LoadPageDataObjects<PartsMonitor,PartsMonitorDataObject>(wherePredicate, sortPredicate, pagination, mapper);
         if(PartsMonitorResult==null) return null;
         pagination.TotalPages=PartsMonitorResult.TotalPages;
         var PartsMonitorWithPagination= new PartsMonitorWithPagination
            {
               Pagination=pagination,
               BaseDataObjectList = new BaseDataObjectList<PartsMonitorDataObject>()
            };
         foreach (var value in PartsMonitorResult.Data)
            {
               PartsMonitorWithPagination.BaseDataObjectList.Add(value);
            }
            return PartsMonitorWithPagination;
      }
      
      #endregion
      
   }
}
