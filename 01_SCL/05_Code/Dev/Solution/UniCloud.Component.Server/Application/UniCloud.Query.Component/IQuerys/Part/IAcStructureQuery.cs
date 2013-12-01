#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/19 15:38:44

// 文件名：IAcStructureQuery
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
   /// 表示用于AcStructure的查询接口。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IAcStructureQuery
   {
      #region Query AcStructure
      
      /// <summary>
      /// 获取所有AcStructure
      /// </summary>
      /// <returns>所有的AcStructure。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetAcStructures", ReplyAction ="http://www.UniCloud.com/IPartService/GetAcStructuresResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/GetAcStructuresDataFault")]
      AcStructureDataObjectList GetAcStructures(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter);
      
      /// <summary>
      /// 获取所有AcStructure分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的AcStructure分页信息。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetAcStructureWithPagination", ReplyAction ="http://www.UniCloud.com/IPartService/GetAcStructureWithPaginationResponse")]
      [FaultContract(typeof(FaultData), Name ="FaultData", Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action="http://www.UniCloud.com/IPartService/GetAcStructureWithPaginationDataFault")]
      AcStructureWithPagination GetAcStructureWithPagination(Pagination pagination);
      
      /// <summary>
      /// 通过AcStructureId获取相应的AcStructure
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetAcStructureByID", ReplyAction ="http://www.UniCloud.com/IPartService/GetAcStructureByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IPartService/GetAcStructureByIDDataFault")]
      AcStructureDataObject GetAcStructureByID(int id);
      #endregion
   }
}
