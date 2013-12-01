#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/26 16:23:46

// 文件名：LicenseTypeDataObject
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
   ///LicenseTypeDataObject
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [DataContractAttribute(Name = "LicenseTypeDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public partial class LicenseTypeDataObject : BaseDataObject
   {
      private int? IDField;
      private Guid GuidField;
      private string TypeField;
      private string DescriptionField;
      private bool HasFileField;
   
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
      public string Type
      {
          get
          {
              return this.TypeField;
          }
          set
          {
             if(this.TypeField != value)
             {
                 this.TypeField = value;
                 this.RaisePropertyChanged("Type");
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
      public bool HasFile
      {
          get
          {
              return this.HasFileField;
          }
          set
          {
             if(this.HasFileField != value)
             {
                 this.HasFileField = value;
                 this.RaisePropertyChanged("HasFile");
             }
          }
      }
      
   }
   
   /// <summary>
   /// LicenseTypeDataObjectList
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [CollectionDataContractAttribute(Name = "LicenseTypeDataObjectList", ItemName = "LicenseTypeDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public class LicenseTypeDataObjectList : BaseDataObjectList<LicenseTypeDataObject>
   {
   }
   
   /// <summary>
   /// LicenseTypeResultData
   /// </summary>
   [DataContractAttribute(Name = "LicenseTypeResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(LicenseTypeResultData))]
   public class LicenseTypeResultData : ResultData<LicenseTypeDataObject>
   {
   }
   
   /// <summary>
   /// LicenseTypeWithPagination
   /// </summary>
   [DataContractAttribute(Name = "LicenseTypeWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(LicenseTypeWithPagination))]
   public class LicenseTypeWithPagination : BaseDataObjectListWithPagination<LicenseTypeDataObject>
   {
   }
}
