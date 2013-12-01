#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/27 15:14:30

// 文件名：CcpMainDataObject
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
    ///UtilizationData
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "UtilizationData", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public partial class UtilizationData : BaseDataObject
    {
        private float FlightHoursField;
        private float FlightCyclesField;
        private UseDetailInfoList UseDetailsField;

        [DataMemberAttribute()]
        public float FlightHours
        {
            get
            {
                return this.FlightHoursField;
            }
            set
            {
                if (this.FlightHoursField != value)
                {
                    this.FlightHoursField = value;
                    this.RaisePropertyChanged("FlightHours");
                }
            }
        }

        [DataMemberAttribute()]
        public float FlightCycles
        {
            get
            {
                return this.FlightCyclesField;
            }
            set
            {
                if (this.FlightCyclesField != value)
                {
                    this.FlightCyclesField = value;
                    this.RaisePropertyChanged("FlightCycles");
                }
            }
        }

        [DataMemberAttribute()]
        public UseDetailInfoList UseDetails
        {
            get
            {
                return this.UseDetailsField;
            }
            set
            {
                if (this.UseDetailsField != value)
                {
                    this.UseDetailsField = value;
                    this.RaisePropertyChanged("UseDetails");
                }
            }
        }
    }

    /// <summary>
    /// UtilizationDataResultData
    /// </summary>
    [DataContractAttribute(Name = "UtilizationDataResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(UtilizationDataResultData))]
    public class UtilizationDataResultData : ResultData<UtilizationData>
    {
    }
}
