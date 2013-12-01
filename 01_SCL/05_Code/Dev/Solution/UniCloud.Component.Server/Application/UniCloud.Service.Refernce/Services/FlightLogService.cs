#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/11/14 11:35:46
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
using UniCloud.Service.Refernce.ServicesRefernce;

namespace UniCloud.Service.Refernce
{
    public class FlightLogService : IFlightLogService
    {
        private readonly FlightLogServiceClient _service = new FlightLogServiceClient();
        private static readonly FlightLogService _instance = new FlightLogService();

        public static FlightLogService Instance
        {
            get { return _instance; }
        }
    }
}
