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

namespace UniCloud.DataObjects.Silverlight
{
    [DataContract(Name = "EngineReportDto", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class EngineReportDto : BaseDataObject
    {
        private int IDField;
        [DataMember()]
        public int ID
        {
            get
            {
                return this.IDField;
            }
            set
            {
                if (this.IDField != value)
                {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        private SnRegDataObject SnregField;
        /// <summary>
        /// SN
        /// </summary>
        [DataMember]
        public SnRegDataObject Snreg
        {
            get
            {
                return this.SnregField;
            }
            set
            {
                if (this.SnregField != value)
                {
                    this.SnregField = value;
                    this.RaisePropertyChanged("Snreg");
                }
            }
        }

        private string FHMField;
        /// <summary>
        /// FC/M(月使用小时)
        /// </summary>
        [DataMember]
        public string FHM
        {
            get
            {
                return this.FHMField;
            }
            set
            {
                if (this.FHMField != value)
                {
                    this.FHMField = value;
                    this.RaisePropertyChanged("FHM");
                }
            }
        }

        private string FCMField;
        /// <summary>
        /// FC/M(月使用循环)
        /// </summary>
        [DataMember]
        public string FCM
        {
            get
            {
                return this.FCMField;
            }
            set
            {
                if (this.FCMField != value)
                {
                    this.FCMField = value;
                    this.RaisePropertyChanged("FCM");
                }
            }
        }

        private string TSNField;
        /// <summary>
        /// TSN(自出厂最新时间)
        /// </summary>
        [DataMember]
        public string TSN
        {
            get
            {
                return this.TSNField;
            }
            set
            {
                if (this.TSNField != value)
                {
                    this.TSNField = value;
                    this.RaisePropertyChanged("TSN");
                }
            }
        }

        private string CSNField;
        /// <summary>
        /// CSN（自出厂最新循环）
        /// </summary>
        [DataMember]
        public string CSN
        {
            get
            {
                return this.CSNField;
            }
            set
            {
                if (this.CSNField != value)
                {
                    this.CSNField = value;
                    this.RaisePropertyChanged("CSN");
                }
            }
        }


        private string TSLSVField;
        /// <summary>
        ///TSLSV(自最近一次维修到现在使用时间)
        /// </summary>
        [DataMember]
        public string TSLSV
        {
            get
            {
                return this.TSLSVField;
            }
            set
            {
                if (this.TSLSVField != value)
                {
                    this.TSLSVField = value;
                    this.RaisePropertyChanged("TSLSV");
                }
            }
        }

        private string CSLSVField;
        /// <summary>
        ///CSLSV(自最近一次维修到现在使用循环)
        /// </summary>
        [DataMember]
        public string CSLSV
        {
            get
            {
                return this.CSLSVField;
            }
            set
            {
                if (this.CSLSVField != value)
                {
                    this.CSLSVField = value;
                    this.RaisePropertyChanged("CSLSV");
                }
            }
        }

        private string FCM24KField;
        /// <summary>
        /// FC/M 24K(24K推力下月使用时间)
        /// </summary>
        [DataMember]
        public string FCM24K
        {
            get
            {
                return this.FCM24KField;
            }
            set
            {
                if (this.FCM24KField != value)
                {
                    this.FCM24KField = value;
                    this.RaisePropertyChanged("FCM24K");
                }
            }
        }

        private string FCM27KField;
        /// <summary>
        /// FC/M 27K(27K推力下月使用时间)
        /// </summary>
        [DataMember]
        public string FCM27K
        {
            get
            {
                return this.FCM27KField;
            }
            set
            {
                if (this.FCM27KField != value)
                {
                    this.FCM27KField = value;
                    this.RaisePropertyChanged("FCM27K");
                }
            }
        }

        private string FCM27MField;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string FCM27M
        {
            get
            {
                return this.FCM27MField;
            }
            set
            {
                if (this.FCM27MField != value)
                {
                    this.FCM27MField = value;
                    this.RaisePropertyChanged("FCM27M");
                }
            }
        }

        private string FCM27EField;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string FCM27E
        {
            get
            {
                return this.FCM27EField;
            }
            set
            {
                if (this.FCM27EField != value)
                {
                    this.FCM27EField = value;
                    this.RaisePropertyChanged("FCM27E");
                }
            }
        }

        private string FCM39KField;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string FCM39K
        {
            get
            {
                return this.FCM39KField;
            }
            set
            {
                if (this.FCM39KField != value)
                {
                    this.FCM39KField = value;
                    this.RaisePropertyChanged("FCM39K");
                }
            }
        }

        private string FCM33KField;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string FCM33K
        {
            get
            {
                return this.FCM33KField;
            }
            set
            {
                if (this.FCM33KField != value)
                {
                    this.FCM33KField = value;
                    this.RaisePropertyChanged("FCM33K");
                }
            }
        }

        private DateTime? PlanRepairDateField;
        /// <summary>
        /// 预计修理日期
        /// </summary>
        [DataMember]
        public DateTime? PlanRepairDate
        {
            get
            {
                return this.PlanRepairDateField;
            }
            set
            {
                if (this.PlanRepairDateField != value)
                {
                    this.PlanRepairDateField = value;
                    this.RaisePropertyChanged("PlanRepairDate");
                }
            }
        }

        private DateTime? EgtExpireTimeField;
        /// <summary>
        /// EGT裕度到期时间
        /// </summary>
        [DataMember]
        public DateTime? EgtExpireTime
        {
            get
            {
                return this.EgtExpireTimeField;
            }
            set
            {
                if (this.EgtExpireTimeField != value)
                {
                    this.EgtExpireTimeField = value;
                    this.RaisePropertyChanged("EgtExpireTime");
                }
            }
        }
        private SnRegDataObjectList ChildSnregsField;
        /// <summary>
        /// 发动机下级件
        /// </summary>
        [DataMember]
        public SnRegDataObjectList ChildSnregs
        {
            get
            {
                return this.ChildSnregsField;
            }
            set
            {
                this.ChildSnregsField = value;
                this.RaisePropertyChanged("ChildSnregs");
            }
        }
        private SnHistoryDataObjectList SnHistorysField;
        /// <summary>
        /// 拆装记录
        /// </summary>
        [DataMember]
        public SnHistoryDataObjectList SnHistorys
        {
            get
            {
                return this.SnHistorysField;
            }
            set
            {
                this.SnHistorysField = value;
                this.RaisePropertyChanged("SnHistorys");
            }
        }

        private SnHistoryDataObjectList RepairHistorysField;
        /// <summary>
        /// 修理记录
        /// </summary>
        [DataMember]
        public SnHistoryDataObjectList RepairHistorys
        {
            get
            {
                return this.RepairHistorysField;
            }
            set
            {
                this.RepairHistorysField = value;
                this.RaisePropertyChanged("RepairHistorys");
            }
        }

        private SnHistoryDataObjectList EngLeaseHistorysField;
        /// <summary>
        /// 租赁记录
        /// </summary>
        [DataMember]
        public SnHistoryDataObjectList EngLeaseHistorys
        {
            get
            {
                return this.EngLeaseHistorysField;
            }
            set
            {
                this.EngLeaseHistorysField = value;
                this.RaisePropertyChanged("EngLeaseHistorys");
            }
        }
    }

  [CollectionDataContractAttribute(Name = "EngineReportDtoList", ItemName = "EngineReportDto", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
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
