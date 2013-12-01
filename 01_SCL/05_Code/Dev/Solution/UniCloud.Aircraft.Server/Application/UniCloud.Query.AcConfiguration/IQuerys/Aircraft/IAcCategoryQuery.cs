#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/30 10:17:20

// 文件名：IAcCategoryQuery
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.ServiceModel;
using UniCloud.DataObjects;

namespace UniCloud.Query.AcConfiguration
{
   /// <summary>
   /// 表示用于AcCategory的查询接口。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IAcCategoryQuery
   {
      #region Get AcCategory
      
      /// <summary>
      /// 获取所有AcCategory
      /// </summary>
      /// <returns>所有的AcCategory。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetAcCategorys", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetAcCategorysResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IAircraftService/GetAcCategorysDataFault")]
      AcCategoryDataObjectList GetAcCategorys(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter);
      
      /// <summary>
      /// 获取所有AcCategory分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的AcCategory分页信息。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetAcCategoryWithPagination", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetAcCategoryWithPaginationResponse")]
      [FaultContract(typeof(FaultData), Name ="FaultData", Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action="http://www.UniCloud.com/IAircraftService/GetAcCategoryWithPaginationDataFault")]
      AcCategoryWithPagination GetAcCategoryWithPagination(Pagination pagination);
      
      /// <summary>
      /// 通过AcCategoryId获取相应的AcCategory
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetAcCategoryByID", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetAcCategoryByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IAircraftService/GetAcCategoryByIDDataFault")]
      AcCategoryDataObject GetAcCategoryByID(int id);
      #endregion

      #region AcCategoryDorpDownSource
      
      /// <summary>
      /// 获取AcCategory下拉数据集合
      /// </summary>
      /// <param name="colFilter"></param>
      /// <param name="sortFilter"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetAcCategoryCol", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetAcCategoryColResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IAircraftService/GetAcCategoryColDataFault")]
      KeyValueDataObjectList GetAcCategoryCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);
      #endregion

   }
}
