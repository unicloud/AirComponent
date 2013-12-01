#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/17 23:23:10

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
using UniCloud.DataObjects.AcConfiguration;

namespace UniCloud.Query
{
   /// <summary>
   /// 表示用于Ata的查询接口。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IAtaQuery
   {
      #region Query Ata
      
      /// <summary>
      /// 获取所有Ata
      /// </summary>
      /// <returns>所有的Ata。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetAtas", ReplyAction ="http://www.UniCloud.com/IPartService/GetAtasResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IPartService/GetAtasDataFault")]
      AtaDataObjectList GetAtas();
      
      /// <summary>
      /// 获取所有Ata分页信息
      /// </summary>
      /// <param name="pagination"></param>
      /// <returns>所有的Ata分页信息。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetAtaWithPagination", ReplyAction ="http://www.UniCloud.com/IPartService/GetAtaWithPaginationResponse")]
      [FaultContract(typeof(FaultData), Name ="FaultData", Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects", Action="http://www.UniCloud.com/IPartService/GetAtaWithPaginationDataFault")]
      AtaWithPagination GetAtaWithPagination(Pagination pagination);
      
      /// <summary>
      /// 通过AtaId获取相应的Ata
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IPartService/GetAtaByID", ReplyAction ="http://www.UniCloud.com/IPartService/GetAtaByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IPartService/GetAtaByIDDataFault")]
      AtaDataObject GetAtaByID(int id);
      #endregion
   }
}
