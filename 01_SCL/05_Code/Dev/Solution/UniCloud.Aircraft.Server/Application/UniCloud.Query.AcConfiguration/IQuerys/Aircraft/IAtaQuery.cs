#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/30 10:17:20

// 文件名：IAtaQuery
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
   /// 表示用于Ata的查询接口。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IAtaQuery
   {
      #region Get Ata
      
      /// <summary>
      /// 获取所有Ata
      /// </summary>
      /// <returns>所有的Ata。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetAtas", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetAtasResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IAircraftService/GetAtasDataFault")]
      AtaDataObjectList GetAtas(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter);
      
      /// <summary>
      /// 获取所有Ata分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的Ata分页信息。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetAtaWithPagination", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetAtaWithPaginationResponse")]
      [FaultContract(typeof(FaultData), Name ="FaultData", Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action="http://www.UniCloud.com/IAircraftService/GetAtaWithPaginationDataFault")]
      AtaWithPagination GetAtaWithPagination(Pagination pagination);
      
      /// <summary>
      /// 通过AtaId获取相应的Ata
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetAtaByID", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetAtaByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IAircraftService/GetAtaByIDDataFault")]
      AtaDataObject GetAtaByID(int id);

      /// <summary>
      /// 通过Ata GuId获取相应的Ata
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action = "http://www.UniCloud.com/IAircraftService/GetAtaByGuid", ReplyAction = "http://www.UniCloud.com/IAircraftService/GetAtaByGuidResponse")]
      [FaultContract(typeof(FaultData), Name = "FaultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action = "http://www.UniCloud.com/IAircraftService/GetAtaByGuidDataFault")]
      AtaDataObject GetAtaByGuid(string id);
      #endregion
      #region AtaDorpDownSource
      
      /// <summary>
      /// 获取Ata下拉数据集合
      /// </summary>
      /// <param name="colFilter"></param>
      /// <param name="sortFilter"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetAtaCol", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetAtaColResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IAircraftService/GetAtaColDataFault")]
      KeyValueDataObjectList GetAtaCol(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);
      #endregion

   }
}
