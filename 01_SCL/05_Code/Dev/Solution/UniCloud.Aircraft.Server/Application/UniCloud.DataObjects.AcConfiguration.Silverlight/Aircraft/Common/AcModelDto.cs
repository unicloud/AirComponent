#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/26 16:23:46

// 文件名：AcModelDataObject
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
    ///AcModelDto
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "AcModelDto", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public partial class AcModelDto : BaseDataObject
    {
        private string SequenceField;
        private int IDField;
        private Guid GuidField;
        private string NameField;
        private string AcTypeField;
        private string DescriptionField;

        [DataMemberAttribute()]
        public string Sequence
        {
            get
            {
                return this.SequenceField;
            }
            set
            {
                if (this.SequenceField != value)
                {
                    this.SequenceField = value;
                    this.RaisePropertyChanged("Sequence");
                }
            }
        }

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
        public Guid Guid
        {
            get
            {
                return this.GuidField;
            }
            set
            {
                if (this.GuidField != value)
                {
                    this.GuidField = value;
                    this.RaisePropertyChanged("Guid");
                }
            }
        }

        [DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                if (this.NameField != value)
                {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }

        [DataMemberAttribute()]
        public string AcType
        {
            get
            {
                return this.AcTypeField;
            }
            set
            {
                if (this.AcTypeField != value)
                {
                    this.AcTypeField = value;
                    this.RaisePropertyChanged("AcType");
                }
            }
        }

        [DataMemberAttribute()]
        public string Description
        {
            get
            {
                return this.DescriptionField;
            }
            set
            {
                if (this.DescriptionField != value)
                {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }

    }

    /// <summary>
    /// AcModelDtoList
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [CollectionDataContractAttribute(Name = "AcModelDtoList", ItemName = "AcModelDto", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class AcModelDtoList : BaseDataObjectList<AcModelDto>
    {
    }

    /// <summary>
    /// AcModelDtoResultData
    /// </summary>
    [DataContractAttribute(Name = "AcModelResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(AcModelDtoResultData))]
    public class AcModelDtoResultData : ResultData<AcModelDto>
    {
    }
}
