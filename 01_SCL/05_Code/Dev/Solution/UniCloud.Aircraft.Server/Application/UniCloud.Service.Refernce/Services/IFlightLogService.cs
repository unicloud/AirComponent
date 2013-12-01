#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/10/9 15:46:03
* 文件名：IFlightLogService
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
    public interface IFlightLogService
    {
        /// <summary>
        /// Flightlog中是否存在该机号数据
        /// </summary>
        /// <param name="acreg">机号</param>
        /// <returns></returns>
        bool ExistFlightWithAcReg(string acreg);
    }
}
