#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/11/13 9:50:48
* 文件名：AirBusMSCN
* 版本：V1.0.0
*
* 修改者： 时间： 
* 修改说明：
* ========================================================================
*/
#endregion

namespace UniCloud.Domain.Model
{
    /// <summary>
    /// 空客在线导出MSCN数据
    /// </summary>
    public class AirBusMSCN : IntAggregateRoot
    {
        /// <summary>
        /// MSN编号
        /// </summary>
        public string MscnNo { get; set; }

        /// <summary>
        /// MSCN标题
        /// </summary>
        public string MscnTitle { get; set; }

        /// <summary>
        /// ATA
        /// </summary>
        public string Ata { get; set; }

        /// <summary>
        /// Mod
        /// </summary>
        public string Mod { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 飞机MSN
        /// </summary>
        public string Msn { get; set; }

        /// <summary>
        /// 机队
        /// </summary>
        public string Fleet { get; set; }

    }
}
