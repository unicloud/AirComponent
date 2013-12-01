#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/27 15:14:30

// 文件名：SnHistoryUnitDataObject
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
   ///SnHistoryUnitDataObject
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [DataContractAttribute(Name = "SnHistoryUnitDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public partial class SnHistoryUnitDataObject : BaseDataObject
   {
      private int IDField;
      private int SnHistoryIDField;
      private string UnitField;
      private decimal USOField;
      private decimal USNField;
      private decimal USRField;
      private decimal USIField;
      private IntUnitDataObject IntUnitField;
      //private SnHistoryDataObject SnHistoryField;
   
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
      public int SnHistoryID
      {
          get
          {
              return this.SnHistoryIDField;
          }
          set
          {
             if(this.SnHistoryIDField != value)
             {
                 this.SnHistoryIDField = value;
                 this.RaisePropertyChanged("SnHistoryID");
             }
          }
      }
      
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
                 this.UnitField = value;
                 this.RaisePropertyChanged("Unit");
             }
          }
      }
      
      [DataMemberAttribute()]
      public decimal USO
      {
          get
          {
              return this.USOField;
          }
          set
          {
             if(this.USOField != value)
             {
                 this.USOField = value;
                 this.RaisePropertyChanged("USO");
             }
          }
      }
      
      [DataMemberAttribute()]
      public decimal USN
      {
          get
          {
              return this.USNField;
          }
          set
          {
             if(this.USNField != value)
             {
                 this.USNField = value;
                 this.RaisePropertyChanged("USN");
             }
          }
      }
      
      [DataMemberAttribute()]
      public decimal USR
      {
          get
          {
              return this.USRField;
          }
          set
          {
             if(this.USRField != value)
             {
                 this.USRField = value;
                 this.RaisePropertyChanged("USR");
             }
          }
      }
      [DataMemberAttribute()]
      public decimal USI
      {
          get
          {
              return this.USIField;
          }
          set
          {
              if (this.USIField != value)
              {
                  this.USIField = value;
                  this.RaisePropertyChanged("USI");
              }
          }
      }
      
      [DataMemberAttribute()]
      public IntUnitDataObject IntUnit
      {
          get
          {
              return this.IntUnitField;
          }
          set
          {
             if(this.IntUnitField != value)
             {
                 this.IntUnitField = value;
                 this.RaisePropertyChanged("IntUnit");
             }
          }
      }
      
      //[DataMemberAttribute()]
      //public SnHistoryDataObject SnHistory
      //{
      //    get
      //    {
      //        return this.SnHistoryField;
      //    }
      //    set
      //    {
      //       if(this.SnHistoryField != value)
      //       {
      //           this.SnHistoryField = value;
      //           this.RaisePropertyChanged("SnHistory");
      //       }
      //    }
      //}
      
   }
   
   /// <summary>
   /// SnHistoryUnitDataObjectList
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [CollectionDataContractAttribute(Name = "SnHistoryUnitDataObjectList", ItemName = "SnHistoryUnitDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public class SnHistoryUnitDataObjectList : BaseDataObjectList<SnHistoryUnitDataObject>
   {
   }
   
   /// <summary>
   /// SnHistoryUnitResultData
   /// </summary>
   [DataContractAttribute(Name = "SnHistoryUnitResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(SnHistoryUnitResultData))]
   public class SnHistoryUnitResultData : ResultData<SnHistoryUnitDataObject>
   {
   }
   
   /// <summary>
   /// SnHistoryUnitWithPagination
   /// </summary>
   [DataContractAttribute(Name = "SnHistoryUnitWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(SnHistoryUnitWithPagination))]
   public class SnHistoryUnitWithPagination : BaseDataObjectListWithPagination<SnHistoryUnitDataObject>
   {
   }
}
