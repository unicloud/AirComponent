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
   ///AcModelDataObject
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [DataContractAttribute(Name = "AcModelDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public partial class AcModelDataObject : BaseDataObject
   {
      private int? IDField;
      private Guid GuidField;
      private string NameField;
      private int AcTypeIDField;
      private Guid AcTypeGuidField;
      private string DescriptionField;
      private AcConfigDataObjectList AcConfigsField;
      //private AcTypeDataObject AcTypeField;

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
      public AcConfigDataObjectList AcConfigs
      {
          get
          {
              return this.AcConfigsField;
          }
          set
          {
             if(this.AcConfigsField != value)
             {
                 this.AcConfigsField = value;
                 this.RaisePropertyChanged("AcConfigs");
             }
          }
      }
      
      //[DataMemberAttribute()]
      //public AcTypeDataObject AcType
      //{
      //    get
      //    {
      //        return this.AcTypeField;
      //    }
      //    set
      //    {
      //       if(this.AcTypeField != value)
      //       {
      //           this.AcTypeField = value;
      //           this.RaisePropertyChanged("AcType");
      //       }
      //    }
      //}
      
   }
   
   /// <summary>
   /// AcModelDataObjectList
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [CollectionDataContractAttribute(Name = "AcModelDataObjectList", ItemName = "AcModelDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public class AcModelDataObjectList : BaseDataObjectList<AcModelDataObject>
   {
   }
   
   /// <summary>
   /// AcModelResultData
   /// </summary>
   [DataContractAttribute(Name = "AcModelResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(AcModelResultData))]
   public class AcModelResultData : ResultData<AcModelDataObject>
   {
   }
   
   /// <summary>
   /// AcModelWithPagination
   /// </summary>
   [DataContractAttribute(Name = "AcModelWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(AcModelWithPagination))]
   public class AcModelWithPagination : BaseDataObjectListWithPagination<AcModelDataObject>
   {
   }
}
