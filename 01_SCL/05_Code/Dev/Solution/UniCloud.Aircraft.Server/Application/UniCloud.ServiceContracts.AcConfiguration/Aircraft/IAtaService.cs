#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/30 10:17:20

// 文件名：IAtaService
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.ServiceModel;
using UniCloud.DataObjects;
using UniCloud.Infrastructure;
using UniCloud.Infrastructure.Caching;
using UniCloud.Query.AcConfiguration;

namespace UniCloud.ServiceContracts
{
   /// <summary>
   /// 表示与Ata相关的应用层服务契约。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IAtaService
   {
      /// <summary>
      /// 创建Ata。
      /// </summary>
      /// <param name="atas">需要创建的Ata。</param>
      /// <returns>创建的Ata。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/CreateAtas", ReplyAction ="http://www.UniCloud.com/IAircraftService/CreateAtasResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IAircraftService/CreateAtasDataFault")]
      [Caching(CachingMethod.Remove, "GetAtas")]
      AtaDataObjectList CreateAtas(AtaDataObjectList atas);
      
      /// <summary>
      /// 删除Ata信息。
      /// </summary>
      /// <param name="ataIDs">需要更新的Ata信息的ID值。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/DeleteAtas", ReplyAction ="http://www.UniCloud.com/IAircraftService/DeleteAtasResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IAircraftService/DeleteAtasDataFault")]
      [Caching(CachingMethod.Remove, "GetAtas")]
      IDList DeleteAtas(IDList ataIDs);
      
      /// <summary>
      /// 更新Ata信息。
      /// </summary>
      /// <param name="atas">需要更新的Ata信息。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/UpdateAtas", ReplyAction ="http://www.UniCloud.com/IAircraftService/UpdateAtasResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IAircraftService/UpdateAtasDataFault")]
      [Caching(CachingMethod.Remove, "GetAtas")]
      AtaDataObjectList UpdateAtas(AtaDataObjectList atas);
      
      /// <summary>
      /// 提交Ata的增删改数据
      /// </summary>
      /// <param name="ataData"></param>
      /// <returns>提交成功的数据</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/CommitAtas", ReplyAction ="http://www.UniCloud.com/IAircraftService/CommitAtasResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IAircraftService/CommitAtasDataFault")]
      [Caching(CachingMethod.Remove, "GetAtas")]
      AtaResultData CommitAtas(AtaResultData ataData);
      
      /// <summary>
      /// 通过AtaId获取相应的Ata 带导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetFullAtaByID", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetFullAtaByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IAircraftService/GetFullAtaByIDDataFault")]
      AtaDataObject GetFullAtaByID(int id);
      
      /// <summary>
      /// 获取所有Ata 带导航属性
      /// </summary>
      /// <returns>所有的Ata。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetFullAtas", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetFullAtasResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IAircraftService/GetFullAtasDataFault")]
      AtaDataObjectList GetFullAtas();
   }
}
