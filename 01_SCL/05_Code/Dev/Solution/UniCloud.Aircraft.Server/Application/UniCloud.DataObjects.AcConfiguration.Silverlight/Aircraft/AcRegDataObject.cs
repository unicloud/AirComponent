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
using System.ComponentModel.DataAnnotations;

namespace UniCloud.DataObjects.Silverlight
{
   /// <summary>
   ///AcRegDataObject
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [DataContractAttribute(Name = "AcRegDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public partial class AcRegDataObject : BaseDataObject
   {
      private int? IDField;
      private Guid GuidField;
       private string OwnerField;
      private int AcTypeIDField;
      private Guid AcTypeGuidField;
      private string OperatorsField;
      private string ImportCategoryField;
      private string RegNumberField;
      private string MsnField;
      private bool IsOperationField;
      private DateTime CreateDateField;
      private DateTime? FactoryDateField;
      private DateTime? ImportDateField;
      private DateTime? ExportDateField;
      private int SeatingCapacityField;
      private decimal CarryingCapacityField;
      private int AcModelIDField;
      private Guid AcModelGuidField;
      private int AcConfigIDField;
      private Guid AcConfigGuidField;
      private int? DecodeConfigIDField;
      private Guid DecodeConfigGuidField;
      private string EngineTrField;
      private int OffsetUTCField;
      private int SubframeLenghtField;
       private string ExportCategoryField;
       private string ManufacturerField;
      private AcregLicenseDataObjectList AcregLicensesField;
   
      [DataMemberAttribute()]
      public int? ID
      {
          get
          {
              return this.IDField;
          }
          set
          {
             if(this.IDField != value)
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
             if(this.GuidField != value)
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

       [Required(ErrorMessage = "必填选项")]
      [DataMemberAttribute()]
      public int AcTypeID
      {
          get
          {
              return this.AcTypeIDField;
          }
          set
          {
             if(this.AcTypeIDField != value)
             {
                 this.ValidateProperty("AcTypeID", value);
                 this.AcTypeIDField = value;
                 this.RaisePropertyChanged("AcTypeID");
             }
          }
      }
      
      [DataMemberAttribute()]
      public Guid AcTypeGuid
      {
          get
          {
              return this.AcTypeGuidField;
          }
          set
          {
             if(this.AcTypeGuidField != value)
             {
                 this.AcTypeGuidField = value;
                 this.RaisePropertyChanged("AcTypeGuid");
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
             if(this.OperatorsField != value)
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
             if(this.ImportCategoryField != value)
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
             if(this.RegNumberField != value)
             {
                 this.RegNumberField = value;
                 this.RaisePropertyChanged("RegNumber");
             }
          }
      }

       [Required(ErrorMessage = "必填选项")]
      [DataMemberAttribute()]
      public string Msn
      {
          get
          {
              return this.MsnField;
          }
          set
          {
             if(this.MsnField != value)
             {
                 this.ValidateProperty("Msn", value);
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
             if(this.IsOperationField != value)
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
             if(this.CreateDateField != value)
             {
                 this.CreateDateField = value;
                 this.RaisePropertyChanged("CreateDate");
             }
          }
      }
      
      [DataMemberAttribute()]
      public DateTime? FactoryDate
      {
          get
          {
              return this.FactoryDateField;
          }
          set
          {
             if(this.FactoryDateField != value)
             {
                 this.FactoryDateField = value;
                 this.RaisePropertyChanged("FactoryDate");
             }
          }
      }
      
      [DataMemberAttribute()]
      public DateTime? ImportDate
      {
          get
          {
              return this.ImportDateField;
          }
          set
          {
             if(this.ImportDateField != value)
             {
                 this.ImportDateField = value;
                 this.RaisePropertyChanged("ImportDate");
             }
          }
      }
      
      [DataMemberAttribute()]
      public DateTime? ExportDate
      {
          get
          {
              return this.ExportDateField;
          }
          set
          {
             if(this.ExportDateField != value)
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
             if(this.SeatingCapacityField != value)
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
             if(this.CarryingCapacityField != value)
             {
                 this.CarryingCapacityField = value;
                 this.RaisePropertyChanged("CarryingCapacity");
             }
          }
      }

       [Required(ErrorMessage = "必填选项")]
      [DataMemberAttribute()]
      public int AcModelID
      {
          get
          {
              return this.AcModelIDField;
          }
          set
          {
             if(this.AcModelIDField != value)
             {
                 this.ValidateProperty("AcModelID", value);
                 this.AcModelIDField = value;
                 this.RaisePropertyChanged("AcModelID");
             }
          }
      }
      
      [DataMemberAttribute()]
      public Guid AcModelGuid
      {
          get
          {
              return this.AcModelGuidField;
          }
          set
          {
             if(this.AcModelGuidField != value)
             {
                 this.AcModelGuidField = value;
                 this.RaisePropertyChanged("AcModelGuid");
             }
          }
      }

       [Required(ErrorMessage = "必填选项")]
      [DataMemberAttribute()]
      public int AcConfigID
      {
          get
          {
              return this.AcConfigIDField;
          }
          set
          {
             if(this.AcConfigIDField != value)
             {
                 this.ValidateProperty("AcConfigID", value);
                 this.AcConfigIDField = value;
                 this.RaisePropertyChanged("AcConfigID");
             }
          }
      }
      
      [DataMemberAttribute()]
      public Guid AcConfigGuid
      {
          get
          {
              return this.AcConfigGuidField;
          }
          set
          {
             if(this.AcConfigGuidField != value)
             {
                 this.AcConfigGuidField = value;
                 this.RaisePropertyChanged("AcConfigGuid");
             }
          }
      }
      
      [DataMemberAttribute()]
      public int? DecodeConfigID
      {
          get
          {
              return this.DecodeConfigIDField;
          }
          set
          {
             if(this.DecodeConfigIDField != value)
             {
                 this.DecodeConfigIDField = value;
                 this.RaisePropertyChanged("DecodeConfigID");
             }
          }
      }
      
      [DataMemberAttribute()]
      public Guid DecodeConfigGuid
      {
          get
          {
              return this.DecodeConfigGuidField;
          }
          set
          {
             if(this.DecodeConfigGuidField != value)
             {
                 this.DecodeConfigGuidField = value;
                 this.RaisePropertyChanged("DecodeConfigGuid");
             }
          }
      }

       [Required(ErrorMessage = "必填选项")]
      [DataMemberAttribute()]
      public string EngineTr
      {
          get
          {
              return this.EngineTrField;
          }
          set
          {
             if(this.EngineTrField != value)
             {
                 this.ValidateProperty("EngineTr", value);
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
             if(this.OffsetUTCField != value)
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
             if(this.SubframeLenghtField != value)
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
      public AcregLicenseDataObjectList AcregLicenses
      {
          get
          {
              return this.AcregLicensesField;
          }
          set
          {
             if(this.AcregLicensesField != value)
             {
                 this.AcregLicensesField = value;
                 this.RaisePropertyChanged("AcregLicenses");
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
   [CollectionDataContractAttribute(Name = "AcRegDataObjectList", ItemName = "AcRegDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public class AcRegDataObjectList : BaseDataObjectList<AcRegDataObject>
   {
   }
   
   /// <summary>
   /// AcRegResultData
   /// </summary>
   [DataContractAttribute(Name = "AcRegResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(AcRegResultData))]
   public class AcRegResultData : ResultData<AcRegDataObject>
   {
   }
   
   /// <summary>
   /// AcRegWithPagination
   /// </summary>
   [DataContractAttribute(Name = "AcRegWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(AcRegWithPagination))]
   public class AcRegWithPagination : BaseDataObjectListWithPagination<AcRegDataObject>
   {
   }
}
