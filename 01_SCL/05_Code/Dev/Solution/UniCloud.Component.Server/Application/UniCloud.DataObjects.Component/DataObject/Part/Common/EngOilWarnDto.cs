using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UniCloud.DataObjects
{
    [DataContract(IsReference = false)]
    public class EngOilWarnDto
    {

        //---------------------------------输入条件------------
        /// <summary>
        /// 件号
        /// </summary>
        [DataMember]
        public string Pn
        {
            get;
            set;
        }

        /// <summary>
        /// 序号
        /// </summary>
        [DataMember]
        public string Sn
        {
            get;
            set;
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        [DataMember]
        public DateTime FromDate
        {
            get;
            set;
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        [DataMember]
        public DateTime ToDate
        {
            get;
            set;
        }
        /// <summary>
        /// 累积油耗率预警值
        /// </summary>
        [DataMember]
        public decimal Tocwarn
        {
            get;
            set;
        }        
        /// <summary>
        /// 3天平均累积油耗率预警值
        /// </summary>
        [DataMember]
        public decimal Aoc3warn
        {
            get;
            set;
        }
        /// <summary>
        /// 7天平均累积油耗率预警值
        /// </summary>
        [DataMember]
        public decimal Aoc7warn
        {
            get;
            set;
        }
        /// <summary>
        /// 10天平均累积油耗率预警值
        /// </summary>
        [DataMember]
        public decimal Aoc10warn
        {
            get;
            set;
        }
        /// <summary>
        /// 警告标记
        /// </summary>
        [DataMember]
        public string WarnTag
        {
            get;
            set;
        }
        //------------------------------------返回值
        /// <summary>
        /// 机号
        /// </summary>
        [DataMember]
        public string AcReg
        {
            get;
            set;
        }
        /// <summary>
        /// 机号
        /// </summary>
        [DataMember]
        public string Position
        {
            get;
            set;

        }
        /// <summary>
        /// 加油日期
        /// </summary>
        [DataMember]
        public virtual string FlightDate { get; set; }



        /// <summary>
        /// 累积油耗率
        /// </summary>
        [DataMember]
        public decimal Toc
        {
            get;
            set;
        }

        /// <summary>
        /// 3天平均累积油耗率
        /// </summary>
        [DataMember]
        public decimal Aoc3
        {
            get;
            set;
        }
        /// <summary>
        /// 7天平均累积油耗率
        /// </summary>
        [DataMember]
        public decimal Aoc7
        {
            get;
            set;
        }
        /// <summary>
        /// 10天平均累积油耗率
        /// </summary>
        [DataMember]
        public decimal Aoc10
        {
            get;
            set;
        }
        /// <summary>
        /// 详细情况
        /// </summary>
        [DataMember]
        public OilHistoryDataObjectList Details
        {
            get;
            set;
        }
    }

    [CollectionDataContract]
    public class EngOilWarnDtoList : BaseDataObjectList<EngOilWarnDto>
    {
    }
}
