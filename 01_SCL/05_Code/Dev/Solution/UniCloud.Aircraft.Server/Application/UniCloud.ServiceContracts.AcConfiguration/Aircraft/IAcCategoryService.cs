#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/9/30 10:17:20

// 文件名：IAcCategoryService
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
   /// 表示与AcCategory相关的应用层服务契约。
   /// </summary>
   [ServiceContract(Namespace ="http://www.UniCloud.com")]
   public interface IAcCategoryService
   {
      /// <summary>
      /// 创建AcCategory。
      /// </summary>
      /// <param name="acCategorys">需要创建的AcCategory。</param>
      /// <returns>创建的AcCategory。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/CreateAcCategorys", ReplyAction ="http://www.UniCloud.com/IAircraftService/CreateAcCategorysResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IAircraftService/CreateAcCategorysDataFault")]
      [Caching(CachingMethod.Remove, "GetAcCategorys")]
      AcCategoryDataObjectList CreateAcCategorys(AcCategoryDataObjectList acCategorys);
      
      /// <summary>
      /// 删除AcCategory信息。
      /// </summary>
      /// <param name="acCategoryIDs">需要更新的AcCategory信息的ID值。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/DeleteAcCategorys", ReplyAction ="http://www.UniCloud.com/IAircraftService/DeleteAcCategorysResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IAircraftService/DeleteAcCategorysDataFault")]
      [Caching(CachingMethod.Remove, "GetAcCategorys")]
      IDList DeleteAcCategorys(IDList acCategoryIDs);
      
      /// <summary>
      /// 更新AcCategory信息。
      /// </summary>
      /// <param name="acCategorys">需要更新的AcCategory信息。</param>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/UpdateAcCategorys", ReplyAction ="http://www.UniCloud.com/IAircraftService/UpdateAcCategorysResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IAircraftService/UpdateAcCategorysDataFault")]
      [Caching(CachingMethod.Remove, "GetAcCategorys")]
      AcCategoryDataObjectList UpdateAcCategorys(AcCategoryDataObjectList acCategorys);
      
      /// <summary>
      /// 提交AcCategory的增删改数据
      /// </summary>
      /// <param name="acCategoryData"></param>
      /// <returns>提交成功的数据</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/CommitAcCategorys", ReplyAction ="http://www.UniCloud.com/IAircraftService/CommitAcCategorysResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IAircraftService/CommitAcCategorysDataFault")]
      [Caching(CachingMethod.Remove, "GetAcCategorys")]
      AcCategoryResultData CommitAcCategorys(AcCategoryResultData acCategoryData);
      
      /// <summary>
      /// 通过AcCategoryId获取相应的AcCategory 带导航属性
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetFullAcCategoryByID", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetFullAcCategoryByIDResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData",Namespace="http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" ,Action="http://www.UniCloud.com/IAircraftService/GetFullAcCategoryByIDDataFault")]
      AcCategoryDataObject GetFullAcCategoryByID(int id);
      
      /// <summary>
      /// 获取所有AcCategory 带导航属性
      /// </summary>
      /// <returns>所有的AcCategory。</returns>
      [OperationContract(Action ="http://www.UniCloud.com/IAircraftService/GetFullAcCategorys", ReplyAction ="http://www.UniCloud.com/IAircraftService/GetFullAcCategorysResponse")]
      [FaultContract(typeof(FaultData),Name ="FaultData", Action="http://www.UniCloud.com/IAircraftService/GetFullAcCategorysDataFault")]
      AcCategoryDataObjectList GetFullAcCategorys();
   }
}
