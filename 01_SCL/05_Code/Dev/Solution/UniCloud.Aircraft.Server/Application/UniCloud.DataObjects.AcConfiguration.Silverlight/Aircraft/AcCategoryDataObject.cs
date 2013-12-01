#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/26 16:23:46

// 文件名：AcCategoryDataObject
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
   ///AcCategoryDataObject
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [DataContractAttribute(Name = "AcCategoryDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public partial class AcCategoryDataObject : BaseDataObject
   {
      private int? IDField;
      private Guid GuidField;
      private string LevelField;
      private string RegionalField;
   
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
      public string Level
      {
          get
          {
              return this.LevelField;
          }
          set
          {
             if(this.LevelField != value)
             {
                 this.LevelField = value;
                 this.RaisePropertyChanged("Level");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string Regional
      {
          get
          {
              return this.RegionalField;
          }
          set
          {
             if(this.RegionalField != value)
             {
                 this.RegionalField = value;
                 this.RaisePropertyChanged("Regional");
             }
          }
      }
      
   }
   
   /// <summary>
   /// AcCategoryDataObjectList
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [CollectionDataContractAttribute(Name = "AcCategoryDataObjectList", ItemName = "AcCategoryDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public class AcCategoryDataObjectList : BaseDataObjectList<AcCategoryDataObject>
   {
   }
   
   /// <summary>
   /// AcCategoryResultData
   /// </summary>
   [DataContractAttribute(Name = "AcCategoryResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(AcCategoryResultData))]
   public class AcCategoryResultData : ResultData<AcCategoryDataObject>
   {
   }
   
   /// <summary>
   /// AcCategoryWithPagination
   /// </summary>
   [DataContractAttribute(Name = "AcCategoryWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(AcCategoryWithPagination))]
   public class AcCategoryWithPagination : BaseDataObjectListWithPagination<AcCategoryDataObject>
   {
   }
}
