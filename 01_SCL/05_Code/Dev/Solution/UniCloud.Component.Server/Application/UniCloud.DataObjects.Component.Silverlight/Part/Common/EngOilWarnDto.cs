using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UniCloud.DataObjects.Silverlight
{
    /// <summary>
    ///EngOilWarnDto
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "EngOilWarnDto", IsReference = false, 
        Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class EngOilWarnDto : BaseDataObject
    {
        private string PnField;
        private string SnField;
        private DateTime FromDateField;
        private DateTime ToDateField;
        private decimal TocwarnField;
        private decimal Aoc3warnField;
        private decimal Aoc7warnField;
        private decimal Aoc10warnField;

        private string AcRegField;
        private string FlightDateField;
        private string PositionField;
        private decimal TocField;
        private decimal Aoc3Field;
        private decimal Aoc7Field;
        private decimal Aoc10Field;
        private string WarnTagField;

        private OilHistoryDataObjectList DetailsField;
        //---------------------------------输入条件------------
        /// <summary>
        /// 件号
        /// </summary>
        [DataMemberAttribute()]
        public string Pn
        {
            get
            {
                return this.PnField;
            }
            set
            {
                if (this.PnField != value)
                {
                    this.PnField = value;
                    this.RaisePropertyChanged("Pn");
                }
            }
        }

        /// <summary>
        /// 序号
        /// </summary>
        [DataMemberAttribute()]
        public string Sn
        {
            get
            {
                return this.SnField;
            }
            set
            {
                if (this.SnField != value)
                {
                    this.SnField = value;
                    this.RaisePropertyChanged("Sn");
                }
            }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        [DataMemberAttribute()]
        public DateTime FromDate
        {
            get
            {
                return this.FromDateField;
            }
            set
            {
                if (this.FromDateField != value)
                {
                    this.FromDateField = value;
                    this.RaisePropertyChanged("FromDate");
                }
            }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        [DataMemberAttribute()]
        public DateTime ToDate
        {
            get
            {
                return this.ToDateField;
            }
            set
            {
                if (this.ToDateField != value)
                {
                    this.ToDateField = value;
                    this.RaisePropertyChanged("ToDate");
                }
            }
        }
        /// <summary>
        /// 累积油耗率预警值
        /// </summary>
        [DataMemberAttribute()]
        public decimal Tocwarn
        {
            get
            {
                return this.TocwarnField;
            }
            set
            {
                if (this.TocwarnField != value)
                {
                    this.TocwarnField = value;
                    this.RaisePropertyChanged("Tocwarn");
                }
            }
        }        
        /// <summary>
        /// 3天平均累积油耗率预警值
        /// </summary>
        [DataMemberAttribute()]
        public decimal Aoc3warn
        {
            get
            {
                return this.Aoc3warnField;
            }
            set
            {
                if (this.Aoc3warnField != value)
                {
                    this.Aoc3warnField = value;
                    this.RaisePropertyChanged("Aoc3warn");
                }
            }
        }
        /// <summary>
        /// 7天平均累积油耗率预警值
        /// </summary>
        [DataMemberAttribute()]
        public decimal Aoc7warn
        {
            get
            {
                return this.Aoc7warnField;
            }
            set
            {
                if (this.Aoc7warnField != value)
                {
                    this.Aoc7warnField = value;
                    this.RaisePropertyChanged("Aoc7warn");
                }
            }
        }
        /// <summary>
        /// 10天平均累积油耗率预警值
        /// </summary>
        [DataMemberAttribute()]
        public decimal Aoc10warn
        {
            get
            {
                return this.Aoc10warnField;
            }
            set
            {
                if (this.Aoc10warnField != value)
                {
                    this.Aoc10warnField = value;
                    this.RaisePropertyChanged("Aoc10warn");
                }
            }
        }

        //------------------------------------返回值
        /// <summary>
        /// 机号
        /// </summary>
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
        /// <summary>
        /// 机号
        /// </summary>
        [DataMemberAttribute()]
        public string Position
        {
            get
            {
                return this.PositionField;
            }
            set
            {
                if (this.PositionField != value)
                {
                    this.PositionField = value;
                    this.RaisePropertyChanged("Position");
                }
            }
        }
   
        /// <summary>
        /// 加油日期
        /// </summary>
        [DataMemberAttribute()]
        public virtual string FlightDate
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

        /// <summary>
        /// 累积油耗率
        /// </summary>
        [DataMemberAttribute()]
        public decimal Toc
        {
            get
            {
                return this.TocField;
            }
            set
            {
                if (this.TocField != value)
                {
                    this.TocField = value;
                    this.RaisePropertyChanged("Toc");
                }
            }
        }

        /// <summary>
        /// 3天平均累积油耗率
        /// </summary>
        [DataMemberAttribute()]
        public decimal Aoc3
        {
            get
            {
                return this.Aoc3Field;
            }
            set
            {
                if (this.Aoc3Field != value)
                {
                    this.Aoc3Field = value;
                    this.RaisePropertyChanged("Aoc3");
                }
            }
        }
        /// <summary>
        /// 7天平均累积油耗率
        /// </summary>
        [DataMemberAttribute()]
        public decimal Aoc7
        {
            get
            {
                return this.Aoc7Field;
            }
            set
            {
                if (this.Aoc7Field != value)
                {
                    this.Aoc7Field = value;
                    this.RaisePropertyChanged("Aoc7");
                }
            }
        }
        /// <summary>
        /// 10天平均累积油耗率
        /// </summary>
        [DataMemberAttribute()]
        public decimal Aoc10
        {
            get
            {
                return this.Aoc10Field;
            }
            set
            {
                if (this.Aoc10Field != value)
                {
                    this.Aoc10Field = value;
                    this.RaisePropertyChanged("Aoc10");
                }
            }
        }
        /// <summary>
        /// 警告标记
        /// </summary>
        [DataMemberAttribute()]
        public string WarnTag
        {
            get
            {
                return this.WarnTagField;
            }
            set
            {
                if (this.WarnTagField != value)
                {
                    this.WarnTagField = value;
                    this.RaisePropertyChanged("WarnTag");
                }
            }
        }
        /// <summary>
        /// 详细情况
        /// </summary>
        [DataMemberAttribute()]
        public OilHistoryDataObjectList Details
        {
            get
            {
                return this.DetailsField;
            }
            set
            {
                if (this.DetailsField != value)
                {
                    this.DetailsField = value;
                    this.RaisePropertyChanged("Details");
                }
            }
        }
    }

    /// <summary>
    /// EngOilWarnDto
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [CollectionDataContractAttribute(Name = "EngOilWarnDtoList", ItemName = "EngOilWarnDto", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class EngOilWarnDtoList : BaseDataObjectList<EngOilWarnDto>
    {
    }
}
