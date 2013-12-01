#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/11/4 14:01:05
* 文件名：EngineReportDto
* 版本：V1.0.0
*
* 修改者： 时间： 
* 修改说明：
* ========================================================================
*/
#endregion
using System;
using System.Runtime.Serialization;

namespace UniCloud.DataObjects
{
    [DataContract]
    public class EngineReportDto
    {

        /// <summary>
        /// 主键ID
        /// </summary>
        [DataMember]
        public virtual int ID
        {
            get;
            set;
        }

        public EngineReportDto()
        {
            this.ChildSnregs = new SnRegDataObjectList();
            this.EngLeaseHistorys = new SnHistoryDataObjectList();
            this.SnHistorys = new SnHistoryDataObjectList();
            this.RepairHistorys = new SnHistoryDataObjectList();
        }
        /// <summary>
        /// Snreg
        /// </summary>
        [DataMember]
        public SnRegDataObject Snreg { get; set; }


        /// <summary>
        /// FH/M(月使用时间)
        /// </summary>
        [DataMember]
        public string FHM { get; set; } 

        /// <summary>
        /// FC/M(月使用循环)
        /// </summary>
        [DataMember]
        public string FCM { get; set; }

        /// <summary>
        /// TSN(自出厂最新时间)
        /// </summary>
        [DataMember]
        public string TSN { get; set; }
 
        /// <summary>
        /// CSN（自出厂最新循环）
        /// </summary>
        [DataMember]
        public string CSN { get; set; }
        
        /// <summary>
        /// TSLSV(自最近一次维修到现在使用时间)
        /// </summary>
        [DataMember]
        public string TSLSV { get; set; }
        
        /// <summary>
        /// CSLSV(自最近一次维修到现在使用时间)
        /// </summary>
        [DataMember]
        public string CSLSV { get; set; }
        
        /// <summary>
        /// FC/M 24K(24K推力下月使用时间)
        /// </summary>
        [DataMember]
        public string FCM24K { get; set; }  
        
        //FC/M 27K
        [DataMember]
        public string FCM27K { get; set; }
        
        //FC/M 27M
        [DataMember]
        public string FCM27M { get; set; }
        
        //FC/M 27E
        [DataMember]
        public string FCM27E { get; set; }
        
        //FC/M30K
        [DataMember]
        public string FCM39K { get; set; }
        
        //FC/M 33K  
        [DataMember]
        public string FCM33K { get; set; }

        /// <summary>
        /// 预计修理日期
        /// </summary>
        [DataMember]
        public DateTime? PlanRepairDate { get; set; }

        /// <summary>
        /// EGT裕度到期时间
        /// </summary>
        [DataMember]
        public DateTime? EgtExpireTime { get; set; }

        /// <summary>
        /// 发动机下级件
        /// </summary>
        [DataMember]
        public SnRegDataObjectList ChildSnregs { get; set; }

        /// <summary>
        /// 拆装记录
        /// </summary>
        [DataMember]
        public SnHistoryDataObjectList SnHistorys { get; set; }

        /// <summary>
        /// 修理记录
        /// </summary>
        [DataMember]
        public SnHistoryDataObjectList RepairHistorys { get; set; }

        /// <summary>
        /// 租赁记录
        /// </summary>
        [DataMember]
        public SnHistoryDataObjectList EngLeaseHistorys { get; set; }
    }

    [CollectionDataContract]
    public class EngineReportDtoList : BaseDataObjectList<EngineReportDto>
    {
    }

    /// <summary>
    /// AttactDocumentResultData
    /// </summary>
    [KnownType(typeof(EngineReportDtoResultData))]
    public class EngineReportDtoResultData : ResultData<EngineReportDto>
    {
    }

    /// <summary>
    /// AttactDocumentWithPagination
    /// </summary>
    [KnownType(typeof(EngineReportDtoWithPagination))]
    public class EngineReportDtoWithPagination : BaseDataObjectListWithPagination<EngineReportDto>
    {
    }
}
