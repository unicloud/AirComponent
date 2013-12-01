#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/11/13 16:07:36
* 文件名：CompareMscnDto
* 版本：V1.0.0
*
* 修改者： 时间： 
* 修改说明：
* ========================================================================
*/
#endregion
using System.Runtime.Serialization;

namespace UniCloud.DataObjects
{
    /// <summary>
    /// 显示与空客对比的模型
    /// </summary>
    public   class CompareMscnDto
    {
        [DataMember]
        public int ID { get; set; }

        /// <summary>
        /// MSCN号
        /// </summary>
        [DataMember]
        public string MscnNo { get; set; }

        /// <summary>
        /// MSN号
        /// </summary>
        [DataMember]
        public string Msn { get; set; }

        /// <summary>
        /// 是否存在系统中
        /// </summary>
        [DataMember]
        public bool SysHas { get; set; }

        /// <summary>
        /// 是否存在空客中
        /// </summary>
        [DataMember]
        public bool AirBusHas { get; set; }
    }

    [CollectionDataContract]
    public class CompareMscnDtoList : BaseDataObjectList<CompareMscnDto>
    {
    }
}
