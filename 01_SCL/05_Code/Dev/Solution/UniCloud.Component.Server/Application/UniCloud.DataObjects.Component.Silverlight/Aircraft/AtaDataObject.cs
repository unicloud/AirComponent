#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/26 16:23:46

// 文件名：AtaDataObject
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
   ///AtaDataObject
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [DataContractAttribute(Name = "AtaDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public partial class AtaDataObject : BaseDataObject
   {
      private string SequenceField;
      private int? IDField;
      private Guid GuidField;
      private string ATAField;
      private string DescriptionField;
      private int? ParentIDField;
      //private AcTypeDataObjectList ActypesField;
      private AtaDataObjectList ChildAtasField;
      private AtaDataObject ParentAtaField;
   
      [DataMemberAttribute()]
      public string Sequence
      {
          get
          {
              return this.SequenceField;
          }
          set
          {
             if(this.SequenceField != value)
             {
                 this.SequenceField = value;
                 this.RaisePropertyChanged("Sequence");
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
      public string ATA
      {
          get
          {
              return this.ATAField;
          }
          set
          {
             if(this.ATAField != value)
             {
                 this.ATAField = value;
                 this.RaisePropertyChanged("ATA");
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
      public int? ParentID
      {
          get
          {
              return this.ParentIDField;
          }
          set
          {
             if(this.ParentIDField != value)
             {
                 this.ParentIDField = value;
                 this.RaisePropertyChanged("ParentID");
             }
          }
      }
      
      //[DataMemberAttribute()]
      //public AcTypeDataObjectList Actypes
      //{
      //    get
      //    {
      //        return this.ActypesField;
      //    }
      //    set
      //    {
      //       if(this.ActypesField != value)
      //       {
      //           this.ActypesField = value;
      //           this.RaisePropertyChanged("Actypes");
      //       }
      //    }
      //}
      
      [DataMemberAttribute()]
      public AtaDataObjectList ChildAtas
      {
          get
          {
              return this.ChildAtasField;
          }
          set
          {
             if(this.ChildAtasField != value)
             {
                 this.ChildAtasField = value;
                 this.RaisePropertyChanged("ChildAtas");
             }
          }
      }
      
      [DataMemberAttribute()]
      public AtaDataObject ParentAta
      {
          get
          {
              return this.ParentAtaField;
          }
          set
          {
             if(this.ParentAtaField != value)
             {
                 this.ParentAtaField = value;
                 this.RaisePropertyChanged("ParentAta");
             }
          }
      }
      
   }
   
   /// <summary>
   /// AtaDataObjectList
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [CollectionDataContractAttribute(Name = "AtaDataObjectList", ItemName = "AtaDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public class AtaDataObjectList : BaseDataObjectList<AtaDataObject>
   {
   }
   
   /// <summary>
   /// AtaResultData
   /// </summary>
   [DataContractAttribute(Name = "AtaResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(AtaResultData))]
   public class AtaResultData : ResultData<AtaDataObject>
   {
   }
   
   /// <summary>
   /// AtaWithPagination
   /// </summary>
   [DataContractAttribute(Name = "AtaWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(AtaWithPagination))]
   public class AtaWithPagination : BaseDataObjectListWithPagination<AtaDataObject>
   {
   }
}
