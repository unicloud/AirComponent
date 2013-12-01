#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/26 16:23:46

// 文件名：AcregLicenseDataObject
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
   ///AcregLicenseDataObject
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [DataContractAttribute(Name = "AcregLicenseDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public partial class AcregLicenseDataObject : BaseDataObject
   {
      private int? IDField;
      private Guid GuidField;
      private int LicenseTypeIDField;
      private Guid LicenseTypeGuidField;
      private int AcRegIDField;
      private Guid AcRegGuidField;
      private string NotesField;
      private string IssuedFromField;
      private DateTime IssuedDateField;
      private int ValidMonthsField;
      private DateTime ExpireDateField;
      private string StateField;
      private string CopyFileField;
       private Guid? DocumentGuidField;
      //private AcRegDataObject AcregField;
      private LicenseTypeDataObject LicenseTypeField;
      private DocumentDataObject DocumentField;

      [DataMemberAttribute()]
      public DocumentDataObject Document
      {
          get
          {
              return this.DocumentField;
          }
          set
          {
              if (this.DocumentField != value)
              {
                  this.DocumentField = value;
              }
          }
      }

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
      public Guid? DocumentGuid
      {
          get
          {
              return this.DocumentGuidField;
          }
          set
          {
              if (this.DocumentGuidField != value)
              {
                  this.DocumentGuidField = value;
                  this.RaisePropertyChanged("DocumentGuid");
              }
          }
      }
      
      [DataMemberAttribute()]
      public int LicenseTypeID
      {
          get
          {
              return this.LicenseTypeIDField;
          }
          set
          {
             if(this.LicenseTypeIDField != value)
             {
                 this.LicenseTypeIDField = value;
                 this.RaisePropertyChanged("LicenseTypeID");
             }
          }
      }
      
      [DataMemberAttribute()]
      public Guid LicenseTypeGuid
      {
          get
          {
              return this.LicenseTypeGuidField;
          }
          set
          {
             if(this.LicenseTypeGuidField != value)
             {
                 this.LicenseTypeGuidField = value;
                 this.RaisePropertyChanged("LicenseTypeGuid");
             }
          }
      }
      
      [DataMemberAttribute()]
      public int AcRegID
      {
          get
          {
              return this.AcRegIDField;
          }
          set
          {
             if(this.AcRegIDField != value)
             {
                 this.AcRegIDField = value;
                 this.RaisePropertyChanged("AcRegID");
             }
          }
      }
      
      [DataMemberAttribute()]
      public Guid AcRegGuid
      {
          get
          {
              return this.AcRegGuidField;
          }
          set
          {
             if(this.AcRegGuidField != value)
             {
                 this.AcRegGuidField = value;
                 this.RaisePropertyChanged("AcRegGuid");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string Notes
      {
          get
          {
              return this.NotesField;
          }
          set
          {
             if(this.NotesField != value)
             {
                 this.NotesField = value;
                 this.RaisePropertyChanged("Notes");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string IssuedFrom
      {
          get
          {
              return this.IssuedFromField;
          }
          set
          {
             if(this.IssuedFromField != value)
             {
                 this.IssuedFromField = value;
                 this.RaisePropertyChanged("IssuedFrom");
             }
          }
      }
      
      [DataMemberAttribute()]
      public DateTime IssuedDate
      {
          get
          {
              return this.IssuedDateField;
          }
          set
          {
             if(this.IssuedDateField != value)
             {
                 this.IssuedDateField = value;
                 this.RaisePropertyChanged("IssuedDate");
             }
          }
      }
      
      [DataMemberAttribute()]
      public int ValidMonths
      {
          get
          {
              return this.ValidMonthsField;
          }
          set
          {
             if(this.ValidMonthsField != value)
             {
                 this.ValidMonthsField = value;
                 this.RaisePropertyChanged("ValidMonths");
             }
          }
      }
      
      [DataMemberAttribute()]
      public DateTime ExpireDate
      {
          get
          {
              return this.ExpireDateField;
          }
          set
          {
             if(this.ExpireDateField != value)
             {
                 this.ExpireDateField = value;
                 this.RaisePropertyChanged("ExpireDate");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string State
      {
          get
          {
              return this.StateField;
          }
          set
          {
             if(this.StateField != value)
             {
                 this.StateField = value;
                 this.RaisePropertyChanged("State");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string CopyFile
      {
          get
          {
              return this.CopyFileField;
          }
          set
          {
             if(this.CopyFileField != value)
             {
                 this.CopyFileField = value;
                 this.RaisePropertyChanged("CopyFile");
             }
          }
      }
      
      //[DataMemberAttribute()]
      //public AcRegDataObject Acreg
      //{
      //    get
      //    {
      //        return this.AcregField;
      //    }
      //    set
      //    {
      //       if(this.AcregField != value)
      //       {
      //           this.AcregField = value;
      //           this.RaisePropertyChanged("Acreg");
      //       }
      //    }
      //}
      
      [DataMemberAttribute()]
      public LicenseTypeDataObject LicenseType
      {
          get
          {
              return this.LicenseTypeField;
          }
          set
          {
             if(this.LicenseTypeField != value)
             {
                 this.LicenseTypeField = value;
                 this.RaisePropertyChanged("LicenseType");
             }
          }
      }
      
   }
   
   /// <summary>
   /// AcregLicenseDataObjectList
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [CollectionDataContractAttribute(Name = "AcregLicenseDataObjectList", ItemName = "AcregLicenseDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public class AcregLicenseDataObjectList : BaseDataObjectList<AcregLicenseDataObject>
   {
   }
   
   /// <summary>
   /// AcregLicenseResultData
   /// </summary>
   [DataContractAttribute(Name = "AcregLicenseResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(AcregLicenseResultData))]
   public class AcregLicenseResultData : ResultData<AcregLicenseDataObject>
   {
   }
   
   /// <summary>
   /// AcregLicenseWithPagination
   /// </summary>
   [DataContractAttribute(Name = "AcregLicenseWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(AcregLicenseWithPagination))]
   public class AcregLicenseWithPagination : BaseDataObjectListWithPagination<AcregLicenseDataObject>
   {
   }
}
