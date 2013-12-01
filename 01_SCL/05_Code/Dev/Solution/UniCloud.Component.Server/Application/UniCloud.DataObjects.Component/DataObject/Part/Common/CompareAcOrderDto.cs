#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/11/11 11:43:31
* 文件名：CompareAcOrderDto
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
    public class CompareAcOrderDto
    {
        public CompareAcOrderDto()
        {
            this.AcList = new CompareAcDtoList();
        }

        [DataMember]
        public string ScnNo { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public string Version { get; set; }

        /// <summary>
        /// 是否有MSN1
        /// </summary>
        [DataMember]
        public bool HasMsn1 { get; set; }

        /// <summary>
        /// 是否有MSN2
        /// </summary>
        [DataMember]
        public bool HasMsn2 { get; set; }

        [DataMember]
        public CompareAcDtoList AcList { get; set; }
    }

    [CollectionDataContract]
    public class CompareAcOrderDtoList : BaseDataObjectList<CompareAcOrderDto>
    {
    }

    /// <summary>
    /// AttactDocumentResultData
    /// </summary>
    [KnownType(typeof(CompareAcOrderDtoResultData))]
    public class CompareAcOrderDtoResultData : ResultData<CompareAcOrderDto>
    {
    }

    /// <summary>
    /// AttactDocumentWithPagination
    /// </summary>
    [KnownType(typeof(CompareAcOrderDtoWithPagination))]
    public class CompareAcOrderDtoWithPagination : BaseDataObjectListWithPagination<CompareAcOrderDto>
    {
    }
}
