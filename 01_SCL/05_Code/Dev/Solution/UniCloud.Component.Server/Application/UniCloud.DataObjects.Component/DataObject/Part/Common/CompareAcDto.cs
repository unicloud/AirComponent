#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/11/11 17:51:27
* 文件名：CompareAcDto
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
    [DataContract]
    public class CompareAcDto
    {
        [DataMember]
        public decimal? Price { get; set; }

        [DataMember]
        public string ScnTitle { get; set; }

        [DataMember]
        public string Mod { get; set; }

        [DataMember]
        public string Msn { get; set; }
    }

    [CollectionDataContract]
    public class CompareAcDtoList : BaseDataObjectList<CompareAcDto>
    {
    }
}
