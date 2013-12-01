#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/21 22:36:56

// 文件名：AcRegQuery
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

namespace UniCloud.Query.AcConfiguration
{
   /// <summary>
   /// 表示用于AcReg的查询接口。
   /// </summary>
   public class AcRegQuery: IAcRegQuery
   {
      private readonly AcConfigurationDbContext _context;
      
      public AcRegQuery(IUniCloudDbContext context)
      {
         _context = context as AcConfigurationDbContext;
      }
      
      #region Get AcReg
      
      /// <summary>
      /// 获取所有AcReg
      /// </summary>
      /// <returns>所有的AcReg。</returns>
      public AcRegDataObjectList GetAcRegs(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter)
      {
         Expression<Func<AcReg, bool>> source = p => true;
         return GetAcRegList(source);
      }
      
      /// <summary>
      /// 获取所有AcReg分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的AcReg分页信息。</returns>
      public AcRegWithPagination GetAcRegWithPagination(Pagination pagination)
      {
         Expression<Func<AcReg, bool>> wherePredicate = p => true;
         Expression<Func<AcReg, dynamic>> sortPredicate = t =>t.ID;
         return GetAcRegPage(wherePredicate,sortPredicate,pagination);
      }
      
      /// <summary>
      /// 通过AcRegId获取相应的AcReg
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
       public AcRegDataObject GetAcRegByID(int id)
      {
         Expression<Func<AcReg, bool>> source = p => p.ID == id;
         var result = GetAcRegList(source);
         return result == null ? null : result.FirstOrDefault();
      }

       public AcRegDataObject GetAcRegByGuid(string id)
       {
           Guid guid = new Guid(id);
           Expression<Func<AcReg, bool>> source = p => p.Guid == guid;
           var result = GetAcRegList(source);
           return result == null ? null : result.FirstOrDefault();
       }

       /// <summary>
       /// 通过AcRegId获取相应的AcregLicenses
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public AcregLicenseDataObjectList GetAcregLicenseByAcregID(int id)
       {
           var queryResult = _context.AcregLicenses.Where(a => a.AcRegID == id).Select(t =>
               new AcregLicenseDataObject()
               {
                   AcRegGuid=t.AcRegGuid,
                   AcRegID=t.AcRegID,
                   DocumentGuid=t.DocumentGuid,
                   CopyFile=t.CopyFile,
                   ExpireDate=t.ExpireDate,
                   Guid=t.Guid,
                   ID=t.ID,
                   IssuedDate=t.IssuedDate,
                   LicenseTypeID=t.LicenseTypeID,
                   IssuedFrom=t.IssuedFrom,
                   LicenseTypeGuid=t.LicenseTypeGuid,
                   Notes=t.Notes,
                   State=t.State,
                   ValidMonths=t.ValidMonths
               }).ToList();
           var transferResult = new AcregLicenseDataObjectList();
           queryResult.ForEach(transferResult.Add);
           return transferResult;
       }
      #endregion
      
      #region Common Get
      
       private AcRegDataObjectList GetAcRegList(Expression<Func<AcReg, bool>> source)
      {
         var queryResult = (_context.AcRegs.Where(source).Select(t => new AcRegDataObject()
            {
               Guid = t.Guid,
               AcTypeID = t.AcTypeID,
               AcTypeGuid = t.AcTypeGuid,
               Owner = t.Owner,
               Operators = t.Operators,
               ImportCategory = t.ImportCategory,
               ExportCategory = t.ExportCategory,
               RegNumber = t.RegNumber,
               Msn = t.Msn,
               IsOperation = t.IsOperation,
               CreateDate = t.CreateDate,
               FactoryDate = t.FactoryDate,
               ImportDate = t.ImportDate,
               ExportDate = t.ExportDate,
               SeatingCapacity = t.SeatingCapacity,
               CarryingCapacity = t.CarryingCapacity,
               AcModelID = t.AcModelID,
               AcModelGuid = t.AcModelGuid,
               AcConfigID = t.AcConfigID,
               AcConfigGuid = t.AcConfigGuid,
               DecodeConfigID = t.DecodeConfigID,
               DecodeConfigGuid = t.DecodeConfigGuid,
               EngineTr = t.EngineTr,
               OffsetUTC = t.OffsetUTC,
               SubframeLenght = t.SubframeLenght,
               ID = t.ID,
            })).ToList();
         if (!queryResult.Any()) return new AcRegDataObjectList();
         var transferResult = new AcRegDataObjectList();
           queryResult.ForEach(p =>
                               {
                                  p.Manufacturer=  _context.AcTypes.Where(a => a.ID == p.AcTypeID)
                                      .Select(a => a.Manufacturer).FirstOrDefault();
                                   transferResult.Add(p);
                               });
         return transferResult;
      }
      
       private AcRegWithPagination GetAcRegPage(Expression<Func<AcReg, bool>> wherePredicate,
                  Expression<Func<AcReg, dynamic>> sortPredicate,
                  Pagination pagination)
      {
         Expression<Func<AcReg,AcRegDataObject>> mapper=t=> new AcRegDataObject
            {
               Guid = t.Guid,
               AcTypeID = t.AcTypeID,
               AcTypeGuid = t.AcTypeGuid,
               Owner = t.Owner,
               Operators = t.Operators,
               ImportCategory = t.ImportCategory,
               ExportCategory = t.ExportCategory,
               RegNumber = t.RegNumber,
               Msn = t.Msn,
               IsOperation = t.IsOperation,
               CreateDate = t.CreateDate,
               FactoryDate = t.FactoryDate,
               ImportDate = t.ImportDate,
               ExportDate = t.ExportDate,
               SeatingCapacity = t.SeatingCapacity,
               CarryingCapacity = t.CarryingCapacity,
               AcModelID = t.AcModelID,
               AcModelGuid = t.AcModelGuid,
               AcConfigID = t.AcConfigID,
               AcConfigGuid = t.AcConfigGuid,
               DecodeConfigID = t.DecodeConfigID,
               DecodeConfigGuid = t.DecodeConfigGuid,
               EngineTr = t.EngineTr,
               OffsetUTC = t.OffsetUTC,
               SubframeLenght = t.SubframeLenght,
               ID = t.ID,
            };
         var AcRegResult = _context.LoadPageDataObjects<AcReg,AcRegDataObject>(wherePredicate, sortPredicate, pagination, mapper);
         if(AcRegResult==null) return null;
         pagination.TotalPages=AcRegResult.TotalPages;
         var AcRegWithPagination= new AcRegWithPagination
            {
               Pagination=pagination,
               BaseDataObjectList = new BaseDataObjectList<AcRegDataObject>()
            };
         foreach (var value in AcRegResult.Data)
         {
             value.Manufacturer =
                 _context.AcTypes.Where(a => a.ID == value.AcTypeID).Select(a => a.Manufacturer).FirstOrDefault();
               AcRegWithPagination.BaseDataObjectList.Add(value);
            }
            return AcRegWithPagination;
      }
      
      #endregion
      
      #region AcRegDorpDownSource
      
      /// <summary>
      /// 通过AcReg下拉数据集合
      /// </summary>
      /// <param name="colFilter"></param>
      /// <param name="sortFilter"></param>
      /// <returns></returns>
      public KeyValueDataObjectList GetAcRegCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)
      {
         var results=new KeyValueDataObjectList();
         var queryResult = (_context.AcRegs.Select(t => new KeyValueDataObject()
            {
                IntKey=t.ID,
                Name=t.RegNumber
            })).ToList();
         queryResult.ForEach(results.Add);
         return results;
      }
      #endregion



    
   }
}
