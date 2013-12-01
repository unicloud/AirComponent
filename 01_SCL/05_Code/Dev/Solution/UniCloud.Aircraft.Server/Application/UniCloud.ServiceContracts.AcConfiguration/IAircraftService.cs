#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/9/30 11:38:55
* 文件名：IAircraftService
* 版本：V1.0.0
*
* 修改者： 时间： 
* 修改说明：
* ========================================================================
*/
#endregion
using System.ServiceModel;
using UniCloud.Query.AcConfiguration;

namespace UniCloud.ServiceContracts
{

    [ServiceContract(Namespace = "http://www.UniCloud.com")]
    public interface IAircraftService:IAcCategoryService,IAcCategoryQuery,IAcRegService,IAcRegQuery,
        IAcTypeService,IAcTypeQuery, IAtaService,IAtaQuery,ILicenseTypeService,ILicenseTypeQuery
    {
    }
}
