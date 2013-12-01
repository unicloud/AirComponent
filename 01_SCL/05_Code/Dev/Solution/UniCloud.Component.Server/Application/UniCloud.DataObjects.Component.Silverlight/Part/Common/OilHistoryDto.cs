#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/27 15:14:30

// 文件名：OilHistoryDataObject
// 版本：V1.0.0
//
// 修改者： 时间：
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace UniCloud.DataObjects.Silverlight
{
    /// <summary>
    ///OilHistoryDto
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "OilHistoryDto", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public partial class OilHistoryDto : BaseDataObject
    {
        private int IDField;
        private string SnRegField;
        private string PnRegField;
        private string PnClassField;
        private decimal UPLIFTField;
        private string FlightlLogField;
        private string AddTimeField;
        private DateTime FlightDateField;
        private string AcRegField;
        private string NotesField;
        private string AddNameField;
        private DateTime UpdateDateField;
        private string UpdateByField;
        private string AtaField;
        private string ZoneField;

        [DataMemberAttribute()]
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

        [DataMemberAttribute()]
        public string SnReg
        {
            get
            {
                return this.SnRegField;
            }
            set
            {
                if (this.SnRegField != value)
                {
                    this.SnRegField = value;
                    this.RaisePropertyChanged("SnReg");
                }
            }
        }

        [DataMemberAttribute()]
        public string PnReg
        {
            get
            {
                return this.PnRegField;
            }
            set
            {
                if (this.PnRegField != value)
                {
                    this.PnRegField = value;
                    this.RaisePropertyChanged("PnReg");
                }
            }
        }

        [DataMemberAttribute()]
        public string PnClass
        {
            get
            {
                return this.PnClassField;
            }
            set
            {
                if (this.PnClassField != value)
                {
                    this.PnClassField = value;
                    this.RaisePropertyChanged("PnClass");
                }
            }
        }

        [DataMemberAttribute()]
        public decimal UPLIFT
        {
            get
            {
                return this.UPLIFTField;
            }
            set
            {
                if (this.UPLIFTField != value)
                {
                    this.UPLIFTField = value;
                    this.RaisePropertyChanged("UPLIFT");
                }
            }
        }

        [DataMemberAttribute()]
        public string FlightlLog
        {
            get
            {
                return this.FlightlLogField;
            }
            set
            {
                if (this.FlightlLogField != value)
                {
                    this.FlightlLogField = value;
                    this.RaisePropertyChanged("FlightlLog");
                }
            }
        }

        [DataMemberAttribute()]
        public string AddTime
        {
            get
            {
                return this.AddTimeField;
            }
            set
            {
                if (this.AddTimeField != value)
                {
                    this.AddTimeField = value;
                    this.RaisePropertyChanged("AddTime");
                }
            }
        }

        [DataMemberAttribute()]
        public DateTime FlightDate
        {
            get
            {
                return this.FlightDateField;
            }
            set
            {
                if (this.FlightDateField != value)
                {
                    this.FlightDateField = value;
                    this.RaisePropertyChanged("FlightDate");
                }
            }
        }

        [DataMemberAttribute()]
        public string AcReg
        {
            get
            {
                return this.AcRegField;
            }
            set
            {
                if (this.AcRegField != value)
                {
                    this.AcRegField = value;
                    this.RaisePropertyChanged("AcReg");
                }
            }
        }

        [DataMemberAttribute()]
        public string Notes
        {
            get
            {
                return this.NotesField;
            }
            set
            {
                if (this.NotesField != value)
                {
                    this.NotesField = value;
                    this.RaisePropertyChanged("Notes");
                }
            }
        }

        [DataMemberAttribute()]
        public string AddName
        {
            get
            {
                return this.AddNameField;
            }
            set
            {
                if (this.AddNameField != value)
                {
                    this.AddNameField = value;
                    this.RaisePropertyChanged("AddName");
                }
            }
        }

        [DataMemberAttribute()]
        public DateTime UpdateDate
        {
            get
            {
                return this.UpdateDateField;
            }
            set
            {
                if (this.UpdateDateField != value)
                {
                    this.UpdateDateField = value;
                    this.RaisePropertyChanged("UpdateDate");
                }
            }
        }

        [DataMemberAttribute()]
        public string UpdateBy
        {
            get
            {
                return this.UpdateByField;
            }
            set
            {
                if (this.UpdateByField != value)
                {
                    this.UpdateByField = value;
                    this.RaisePropertyChanged("UpdateBy");
                }
            }
        }

        [DataMemberAttribute()]
        public string Ata
        {
            get
            {
                return this.AtaField;
            }
            set
            {
                if (this.AtaField != value)
                {
                    this.AtaField = value;
                    this.RaisePropertyChanged("Ata");
                }
            }
        }

        [DataMemberAttribute()]
        public string Zone
        {
            get
            {
                return this.ZoneField;
            }
            set
            {
                if (this.ZoneField != value)
                {
                    this.ZoneField = value;
                    this.RaisePropertyChanged("Zone");
                }
            }
        }

    }

    /// <summary>
    /// OilHistoryDtoList
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [CollectionDataContractAttribute(Name = "OilHistoryDtoList", ItemName = "OilHistoryDto", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class OilHistoryDtoList : BaseDataObjectList<OilHistoryDto>
    {
    }

    /// <summary>
    /// OilHistoryDtoResultData
    /// </summary>
    [DataContractAttribute(Name = "OilHistoryDtoResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(OilHistoryDtoResultData))]
    public class OilHistoryDtoResultData : ResultData<OilHistoryDto>
    {
    }
}
