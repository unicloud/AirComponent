#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/10/9 15:46:15
* 文件名：FlightLogService
* 版本：V1.0.0
*
* 修改者： 时间： 
* 修改说明：
* ========================================================================
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniCloud.Service.Refernce.Services
{
    public class FlightLogService : IFlightLogService
    {
        private readonly FlightLogServiceClient _service = new FlightLogServiceClient();
        private static readonly FlightLogService _instance = new FlightLogService();

        public static FlightLogService Instance
        {
            get { return _instance; }
        }

        public bool ExistFlightWithAcReg(string acreg)
        {
            return _service.ExistFlightWithAcReg(acreg);
        }
    }
}
