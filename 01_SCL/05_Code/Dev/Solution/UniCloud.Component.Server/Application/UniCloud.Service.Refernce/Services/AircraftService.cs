#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/10/21 18:07:13
* 文件名：AircraftService
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
using UniCloud.Service.Refernce.ServicesRefernce;

namespace UniCloud.Service.Refernce
{
    public class AircraftService : IAircraftService
    {
        private readonly AircraftServiceClient _service = new AircraftServiceClient();
        private static readonly AircraftService _instance = new AircraftService();

        public static AircraftService Instance
        {
            get { return _instance; }
        }
    }
}
