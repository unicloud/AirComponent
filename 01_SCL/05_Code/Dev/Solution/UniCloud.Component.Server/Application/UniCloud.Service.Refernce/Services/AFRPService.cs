#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/10/21 18:06:57
* 文件名：AFRPService
* 版本：V1.0.0
*
* 修改者： 时间： 
* 修改说明：
* ========================================================================
*/
#endregion
using UniCloud.Service.Refernce.ServicesRefernce;

namespace UniCloud.Service.Refernce
{
    public class AFRPService : IAFRPService
    {
        private readonly AFRPServiceClient _service = new AFRPServiceClient();
        private static readonly AFRPService _instance = new AFRPService();

        public static AFRPService Instance
        {
            get { return _instance; }
        }

        public decimal[] GetAcFlightTimeByDate(string ac, System.DateTime fromDate, System.DateTime toDate)
        {
            //TODO 
            
            return new decimal[] { 50,30,50,20,50,50};
        }
    }
}
