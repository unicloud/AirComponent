#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/10/21 18:06:42
* 文件名：IAFRPService
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

namespace UniCloud.Service.Refernce
{
    public interface IAFRPService
    {
        /// <summary>
        /// 根据飞机号，起始截止时间 ，查询飞机飞行时间.
        /// </summary>
        /// <param name="docID">文档主键</param>
        /// <returns>文档</returns>
        Decimal[] GetAcFlightTimeByDate(string ac,DateTime fromDate,DateTime toDate);
    }
}
