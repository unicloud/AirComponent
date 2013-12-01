#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/17 23:23:10

// 文件名：IIntUnitQuery
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.ServiceModel;
using UniCloud.DataObjects;

namespace UniCloud.Query
{
   /// <summary>
   /// 表示用于IntUnit的查询接口。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IIntUnitQuery
   {
      #region Query IntUnit
      
      /// <summary>
      /// 获取所有IntUnit
      /// </summary>
      /// <returns>所有的IntUnit。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetIntUnits", ReplyAction ="http://www.UniCloud.com/IPartService/GetIntUnitsResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/GetIntUnitsDataFault")]
      IntUnitDataObjectList GetIntUnits(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter);
      
      /// <summary>
      /// 获取所有IntUnit分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的IntUnit分页信息。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetIntUnitWithPagination", ReplyAction ="http://www.UniCloud.com/IPartService/GetIntUnitWithPaginationResponse")]
      [FaultContract(typeof(FaultData), Name ="FaultData", Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action="http://www.UniCloud.com/IPartService/GetIntUnitWithPaginationDataFault")]
      IntUnitWithPagination GetIntUnitWithPagination(Pagination pagination);
      
      /// <summary>
      /// 通过IntUnitId获取相应的IntUnit
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetIntUnitByID", ReplyAction ="http://www.UniCloud.com/IPartService/GetIntUnitByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IPartService/GetIntUnitByIDDataFault")]
      IntUnitDataObject GetIntUnitByID(int id);
      #endregion
   }
}
