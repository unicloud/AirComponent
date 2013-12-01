#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/9/26 13:01:02
* 文件名：CcOrderHandler
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
using UniCloud.Domain.Events;

namespace UniCloud.Events.Handlers
{
    public class CcOrderHandler :IEventHandler<CcOrderEvent>
    {
        public void Handle(CcOrderEvent ev)
        {
            //TODO:做一些事件处理操作
            //测试代码 正式写时要删掉
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\log.txt",true))
            {
                sw.WriteLine(ev.Acreg);
                sw.WriteLine(ev.SnHistorys.Count);
                sw.WriteLine(ev.OperateDate);
            }
        }
    }
}
