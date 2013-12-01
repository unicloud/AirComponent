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
    ///UseDetailInfo
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "UseDetailInfo", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public partial class UseDetailInfo : BaseDataObject
    {
        private int TimeField;
        private float ValueField;

        [DataMemberAttribute()]
        public int Time
        {
            get
            {
                return this.TimeField;
            }
            set
            {
                if (this.TimeField != value)
                {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
                }
            }
        }

        [DataMemberAttribute()]
        public float Value
        {
            get
            {
                return this.ValueField;
            }
            set
            {
                if (this.ValueField != value)
                {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
    }

    /// <summary>
    /// UseDetailInfoList
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [CollectionDataContractAttribute(Name = "UseDetailInfoList", ItemName = "UseDetailInfo", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class UseDetailInfoList : BaseDataObjectList<UseDetailInfo>
    {
    }

    /// <summary>
    /// UseDetailInfoResultData
    /// </summary>
    [DataContractAttribute(Name = "UseDetailInfoResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(UseDetailInfoResultData))]
    public class UseDetailInfoResultData : ResultData<UseDetailInfo>
    {
    }
}
