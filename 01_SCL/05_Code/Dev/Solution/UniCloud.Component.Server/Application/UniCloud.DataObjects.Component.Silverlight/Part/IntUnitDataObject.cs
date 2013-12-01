#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/27 15:40:49

// 文件名：IntUnitDataObject
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
using System.ComponentModel.DataAnnotations;

namespace UniCloud.DataObjects.Silverlight
{
    /// <summary>
    ///IntUnitDataObject
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "IntUnitDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public partial class IntUnitDataObject : BaseDataObject
    {
        private int IDField;
        private string UnitField;
        private string DescritptionField;
        private string TypeField;
        private string ShortNameField;

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

        [Required(ErrorMessage = "必填选项")]
        [StringLength(2, ErrorMessage = "长度不能大于2")]
        [DataMemberAttribute()]
        public string Unit
        {
            get
            {
                return this.UnitField;
            }
            set
            {
                if (this.UnitField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Unit" });
                    this.UnitField = value;
                    this.RaisePropertyChanged("Unit");
                }
            }
        }

        [StringLength(20, ErrorMessage = "长度不能大于20")]
        [DataMemberAttribute()]
        public string Descritption
        {
            get
            {
                return this.DescritptionField;
            }
            set
            {
                if (this.DescritptionField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Descritption" });
                    this.DescritptionField = value;
                    this.RaisePropertyChanged("Descritption");
                }
            }
        }

        [StringLength(1, ErrorMessage = "长度不能大于1")]
        [DataMemberAttribute()]
        public string Type
        {
            get
            {
                return this.TypeField;
            }
            set
            {
                if (this.TypeField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "Type" });
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }

        [StringLength(20, ErrorMessage = "长度不能大于20")]
        [DataMemberAttribute()]
        public string ShortName
        {
            get
            {
                return this.ShortNameField;
            }
            set
            {
                if (this.ShortNameField != value)
                {
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = "ShortName" });
                    this.ShortNameField = value;
                    this.RaisePropertyChanged("ShortName");
                }
            }
        }

    }

    /// <summary>
    /// IntUnitDataObjectList
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [CollectionDataContractAttribute(Name = "IntUnitDataObjectList", ItemName = "IntUnitDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class IntUnitDataObjectList : BaseDataObjectList<IntUnitDataObject>
    {
    }

    /// <summary>
    /// IntUnitResultData
    /// </summary>
    [DataContractAttribute(Name = "IntUnitResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(IntUnitResultData))]
    public class IntUnitResultData : ResultData<IntUnitDataObject>
    {
    }

    /// <summary>
    /// CcpPnWithPagination
    /// </summary>
    [DataContractAttribute(Name = "IntUnitWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(IntUnitWithPagination))]
    public class IntUnitWithPagination : BaseDataObjectListWithPagination<IntUnitDataObject>
    {
    }
}
