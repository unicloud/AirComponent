#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/27 15:14:30

// 文件名：SnHistoryDataObject
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
   ///SnHistoryDataObject
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [DataContractAttribute(Name = "SnHistoryDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public partial class SnHistoryDataObject : BaseDataObject
   {
      private int IDField;
      private int SnRegIDField;
      private string SourceField;
      private string ActiveField;
      private string PositionField;
      private string NoteField;
      private DateTime ActiveDateField;
      private string AtaField;
      private string OrdernoField;
           
      private SnRegDataObject SnRegField;
      private SnHistoryUnitDataObjectList SnHistoryUnitsField;
      private int? NhSnRegIDField;
      private int? RootSnRegIDField;
   
      [DataMemberAttribute()]
      public int ID
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
      public int SnRegID
      {
          get
          {
              return this.SnRegIDField;
          }
          set
          {
             if(this.SnRegIDField != value)
             {
                 this.SnRegIDField = value;
                 this.RaisePropertyChanged("SnRegID");
             }
          }
      }

      [DataMemberAttribute()]
      public string Source
      {
          get
          {
              return this.SourceField;
          }
          set
          {
              if (this.SourceField != value)
              {
                  this.SourceField = value;
                  this.RaisePropertyChanged("Source");
              }
          }
      }      
      [DataMemberAttribute()]
      public string Orderno
      {
          get
          {
              return this.OrdernoField;
          }
          set
          {
              if (this.OrdernoField != value)
             {
                 this.OrdernoField = value;
                 this.RaisePropertyChanged("Orderno");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string Active
      {
          get
          {
              return this.ActiveField;
          }
          set
          {
             if(this.ActiveField != value)
             {
                 this.ActiveField = value;
                 this.RaisePropertyChanged("Active");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string Position
      {
          get
          {
              return this.PositionField;
          }
          set
          {
             if(this.PositionField != value)
             {
                 this.PositionField = value;
                 this.RaisePropertyChanged("Position");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string Note
      {
          get
          {
              return this.NoteField;
          }
          set
          {
             if(this.NoteField != value)
             {
                 this.NoteField = value;
                 this.RaisePropertyChanged("Note");
             }
          }
      }
      
      [DataMemberAttribute()]
      public DateTime ActiveDate
      {
          get
          {
              return this.ActiveDateField;
          }
          set
          {
             if(this.ActiveDateField != value)
             {
                 this.ActiveDateField = value;
                 this.RaisePropertyChanged("ActiveDate");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string Ata
      {
          get
          {
              return this.AtaField;
          }
          set
          {
             if(this.AtaField != value)
             {
                 this.AtaField = value;
                 this.RaisePropertyChanged("Ata");
             }
          }
      }
      
      [DataMemberAttribute()]
      public SnRegDataObject SnReg
      {
          get
          {
              return this.SnRegField;
          }
          set
          {
             if(this.SnRegField != value)
             {
                 this.SnRegField = value;
                 this.RaisePropertyChanged("SnReg");
             }
          }
      }
      
      [DataMemberAttribute()]
      public SnHistoryUnitDataObjectList SnHistoryUnits
      {
          get
          {
              return this.SnHistoryUnitsField;
          }
          set
          {
             if(this.SnHistoryUnitsField != value)
             {
                 this.SnHistoryUnitsField = value;
                 this.RaisePropertyChanged("SnHistoryUnits");
             }
          }
      }
      
      [DataMemberAttribute()]
      public int? NhSnRegID
      {
          get
          {
              return this.NhSnRegIDField;
          }
          set
          {
             if(this.NhSnRegIDField != value)
             {
                 this.NhSnRegIDField = value;
                 this.RaisePropertyChanged("NhSnRegID");
             }
          }
      }
      
      [DataMemberAttribute()]
      public int? RootSnRegID
      {
          get
          {
              return this.RootSnRegIDField;
          }
          set
          {
             if(this.RootSnRegIDField != value)
             {
                 this.RootSnRegIDField = value;
                 this.RaisePropertyChanged("RootSnRegID");
             }
          }
      }
      
   }
   
   /// <summary>
   /// SnHistoryDataObjectList
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [CollectionDataContractAttribute(Name = "SnHistoryDataObjectList", ItemName = "SnHistoryDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public class SnHistoryDataObjectList : BaseDataObjectList<SnHistoryDataObject>
   {
   }
   
   /// <summary>
   /// SnHistoryResultData
   /// </summary>
   [DataContractAttribute(Name = "SnHistoryResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(SnHistoryResultData))]
   public class SnHistoryResultData : ResultData<SnHistoryDataObject>
   {
   }
   
   /// <summary>
   /// SnHistoryWithPagination
   /// </summary>
   [DataContractAttribute(Name = "SnHistoryWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(SnHistoryWithPagination))]
   public class SnHistoryWithPagination : BaseDataObjectListWithPagination<SnHistoryDataObject>
   {
   }
}
