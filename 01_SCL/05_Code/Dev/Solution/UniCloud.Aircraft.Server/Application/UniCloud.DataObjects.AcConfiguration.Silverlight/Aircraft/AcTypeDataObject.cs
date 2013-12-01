#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/26 16:23:46

// 文件名：AcTypeDataObject
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
   ///AcTypeDataObject
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [DataContractAttribute(Name = "AcTypeDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public partial class AcTypeDataObject : BaseDataObject
   {
      private int? IDField;
      private Guid GuidField;
      private string NameField;
      private string DescriptionField;
      private string ManufacturerField;
      private string AcCategoryField;
      private Guid AcCategoryGuidField;
      private AtaDataObjectList AtasField;
      private AcModelDataObjectList AcmodelsField;
   
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
      public string Name
      {
          get
          {
              return this.NameField;
          }
          set
          {
             if(this.NameField != value)
             {
                 this.NameField = value;
                 this.RaisePropertyChanged("Name");
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
             if(this.DescriptionField != value)
             {
                 this.DescriptionField = value;
                 this.RaisePropertyChanged("Description");
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
             if(this.ManufacturerField != value)
             {
                 this.ManufacturerField = value;
                 this.RaisePropertyChanged("Manufacturer");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string AcCategory
      {
          get
          {
              return this.AcCategoryField;
          }
          set
          {
              if (this.AcCategoryField != value)
             {
                 this.AcCategoryField = value;
                 this.RaisePropertyChanged("AcCategory");
             }
          }
      }
      
      [DataMemberAttribute()]
      public Guid AcCategoryGuid
      {
          get
          {
              return this.AcCategoryGuidField;
          }
          set
          {
             if(this.AcCategoryGuidField != value)
             {
                 this.AcCategoryGuidField = value;
                 this.RaisePropertyChanged("AcCategoryGuid");
             }
          }
      }
      
      [DataMemberAttribute()]
      public AtaDataObjectList Atas
      {
          get
          {
              return this.AtasField;
          }
          set
          {
             if(this.AtasField != value)
             {
                 this.AtasField = value;
                 this.RaisePropertyChanged("Atas");
             }
          }
      }
      
      [DataMemberAttribute()]
      public AcModelDataObjectList Acmodels
      {
          get
          {
              return this.AcmodelsField;
          }
          set
          {
             if(this.AcmodelsField != value)
             {
                 this.AcmodelsField = value;
                 this.RaisePropertyChanged("Acmodels");
             }
          }
      }
   }
   
   /// <summary>
   /// AcTypeDataObjectList
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [CollectionDataContractAttribute(Name = "AcTypeDataObjectList", ItemName = "AcTypeDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public class AcTypeDataObjectList : BaseDataObjectList<AcTypeDataObject>
   {
   }
   
   /// <summary>
   /// AcTypeResultData
   /// </summary>
   [DataContractAttribute(Name = "AcTypeResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(AcTypeResultData))]
   public class AcTypeResultData : ResultData<AcTypeDataObject>
   {
   }
   
   /// <summary>
   /// AcTypeWithPagination
   /// </summary>
   [DataContractAttribute(Name = "AcTypeWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(AcTypeWithPagination))]
   public class AcTypeWithPagination : BaseDataObjectListWithPagination<AcTypeDataObject>
   {
   }
}
