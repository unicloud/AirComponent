#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/26 16:23:46

// 文件名：AcRegDataObject
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
    ///AcRegDto
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "AcRegDto", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public partial class AcRegDto : BaseDataObject
    {
        private string SequenceField;
        private int IDField;
        private Guid GuidField;
        private string OwnerField;
        private string AcTypeField;
        private string OperatorsField;
        private string ImportCategoryField;
        private string RegNumberField;
        private string MsnField;
        private bool IsOperationField;
        private DateTime CreateDateField;
        private DateTime FactoryDateField;
        private DateTime ImportDateField;
        private DateTime ExportDateField;
        private int SeatingCapacityField;
        private decimal CarryingCapacityField;
        private string AcModelField;
        private string AcConfigField;
        private string EngineTrField;
        private int OffsetUTCField;
        private int SubframeLenghtField;
        private string ExportCategoryField;
        private string ManufacturerField;

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
        public string Owner
        {
            get
            {
                return this.OwnerField;
            }
            set
            {
                if (this.OwnerField != value)
                {
                    this.OwnerField = value;
                    this.RaisePropertyChanged("Owner");
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
        public string Operators
        {
            get
            {
                return this.OperatorsField;
            }
            set
            {
                if (this.OperatorsField != value)
                {
                    this.OperatorsField = value;
                    this.RaisePropertyChanged("Operators");
                }
            }
        }

        [DataMemberAttribute()]
        public string ImportCategory
        {
            get
            {
                return this.ImportCategoryField;
            }
            set
            {
                if (this.ImportCategoryField != value)
                {
                    this.ImportCategoryField = value;
                    this.RaisePropertyChanged("ImportCategory");
                }
            }
        }

        [DataMemberAttribute()]
        public string RegNumber
        {
            get
            {
                return this.RegNumberField;
            }
            set
            {
                if (this.RegNumberField != value)
                {
                    this.RegNumberField = value;
                    this.RaisePropertyChanged("RegNumber");
                }
            }
        }

        [DataMemberAttribute()]
        public string Msn
        {
            get
            {
                return this.MsnField;
            }
            set
            {
                if (this.MsnField != value)
                {
                    this.MsnField = value;
                    this.RaisePropertyChanged("Msn");
                }
            }
        }

        [DataMemberAttribute()]
        public bool IsOperation
        {
            get
            {
                return this.IsOperationField;
            }
            set
            {
                if (this.IsOperationField != value)
                {
                    this.IsOperationField = value;
                    this.RaisePropertyChanged("IsOperation");
                }
            }
        }

        [DataMemberAttribute()]
        public DateTime CreateDate
        {
            get
            {
                return this.CreateDateField;
            }
            set
            {
                if (this.CreateDateField != value)
                {
                    this.CreateDateField = value;
                    this.RaisePropertyChanged("CreateDate");
                }
            }
        }

        [DataMemberAttribute()]
        public DateTime FactoryDate
        {
            get
            {
                return this.FactoryDateField;
            }
            set
            {
                if (this.FactoryDateField != value)
                {
                    this.FactoryDateField = value;
                    this.RaisePropertyChanged("FactoryDate");
                }
            }
        }

        [DataMemberAttribute()]
        public DateTime ImportDate
        {
            get
            {
                return this.ImportDateField;
            }
            set
            {
                if (this.ImportDateField != value)
                {
                    this.ImportDateField = value;
                    this.RaisePropertyChanged("ImportDate");
                }
            }
        }

        [DataMemberAttribute()]
        public DateTime ExportDate
        {
            get
            {
                return this.ExportDateField;
            }
            set
            {
                if (this.ExportDateField != value)
                {
                    this.ExportDateField = value;
                    this.RaisePropertyChanged("ExportDate");
                }
            }
        }

        [DataMemberAttribute()]
        public int SeatingCapacity
        {
            get
            {
                return this.SeatingCapacityField;
            }
            set
            {
                if (this.SeatingCapacityField != value)
                {
                    this.SeatingCapacityField = value;
                    this.RaisePropertyChanged("SeatingCapacity");
                }
            }
        }

        [DataMemberAttribute()]
        public decimal CarryingCapacity
        {
            get
            {
                return this.CarryingCapacityField;
            }
            set
            {
                if (this.CarryingCapacityField != value)
                {
                    this.CarryingCapacityField = value;
                    this.RaisePropertyChanged("CarryingCapacity");
                }
            }
        }

        [DataMemberAttribute()]
        public string AcModel
        {
            get
            {
                return this.AcModelField;
            }
            set
            {
                if (this.AcModelField != value)
                {
                    this.AcModelField = value;
                    this.RaisePropertyChanged("AcModel");
                }
            }
        }

        [DataMemberAttribute()]
        public string AcConfig
        {
            get
            {
                return this.AcConfigField;
            }
            set
            {
                if (this.AcConfigField != value)
                {
                    this.AcConfigField = value;
                    this.RaisePropertyChanged("AcConfig");
                }
            }
        }

        [DataMemberAttribute()]
        public string EngineTr
        {
            get
            {
                return this.EngineTrField;
            }
            set
            {
                if (this.EngineTrField != value)
                {
                    this.EngineTrField = value;
                    this.RaisePropertyChanged("EngineTr");
                }
            }
        }

        [DataMemberAttribute()]
        public int OffsetUTC
        {
            get
            {
                return this.OffsetUTCField;
            }
            set
            {
                if (this.OffsetUTCField != value)
                {
                    this.OffsetUTCField = value;
                    this.RaisePropertyChanged("OffsetUTC");
                }
            }
        }

        [DataMemberAttribute()]
        public int SubframeLenght
        {
            get
            {
                return this.SubframeLenghtField;
            }
            set
            {
                if (this.SubframeLenghtField != value)
                {
                    this.SubframeLenghtField = value;
                    this.RaisePropertyChanged("SubframeLenght");
                }
            }
        }

        [DataMemberAttribute()]
        public string ExportCategory
        {
            get
            {
                return this.ExportCategoryField;
            }
            set
            {
                if (this.ExportCategoryField != value)
                {
                    this.ExportCategoryField = value;
                    this.RaisePropertyChanged("ExportCategory");
                }
            }
        }

        [DataMemberAttribute()]
        public string Manufacturer
        {
            get
            {
                return this.ManufacturerField;
            }
            set
            {
                if (this.ManufacturerField != value)
                {
                    this.ManufacturerField = value;
                    this.RaisePropertyChanged("Manufacturer");
                }
            }
        }

    }

    /// <summary>
    /// AcRegDataObjectList
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [CollectionDataContractAttribute(Name = "AcRegDtoList", ItemName = "AcRegDto", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class AcRegDtoList : BaseDataObjectList<AcRegDto>
    {
    }

    /// <summary>
    /// AcRegDtoResultData
    /// </summary>
    [DataContractAttribute(Name = "AcRegDtoResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(AcRegDtoResultData))]
    public class AcRegDtoResultData : ResultData<AcRegDto>
    {
    }
}
