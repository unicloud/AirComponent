#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/31 11:55:11

// 文件名：PartsMonitorDetailDataObject
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
   ///PartsMonitorDetailDataObject
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [DataContractAttribute(Name = "PartsMonitorDetailDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public partial class PartsMonitorDetailDataObject : BaseDataObject
   {
      private int PnRegIDField;
      private int SnRegIDField;
      private string ItemNoField;
      private string UnitField;
      private string IeamField;
      private string WorkscopeField;
      private int IntervalField;
      private decimal? UsedField;
      private decimal? RemainField;
      private decimal? UtilizaField;
      private DateTime ExpireDateField;
      private int PartsMonitorIDField;
      private int IDField;
   
      [DataMemberAttribute()]
      public int PnRegID
      {
          get
          {
              return this.PnRegIDField;
          }
          set
          {
             if(this.PnRegIDField != value)
             {
                 this.PnRegIDField = value;
                 this.RaisePropertyChanged("PnRegID");
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
      public string ItemNo
      {
          get
          {
              return this.ItemNoField;
          }
          set
          {
             if(this.ItemNoField != value)
             {
                 this.ItemNoField = value;
                 this.RaisePropertyChanged("ItemNo");
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
             if(this.UnitField != value)
             {
                 this.UnitField = value;
                 this.RaisePropertyChanged("Unit");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string Ieam
      {
          get
          {
              return this.IeamField;
          }
          set
          {
             if(this.IeamField != value)
             {
                 this.IeamField = value;
                 this.RaisePropertyChanged("Ieam");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string Workscope
      {
          get
          {
              return this.WorkscopeField;
          }
          set
          {
             if(this.WorkscopeField != value)
             {
                 this.WorkscopeField = value;
                 this.RaisePropertyChanged("Workscope");
             }
          }
      }
      
      [DataMemberAttribute()]
      public int Interval
      {
          get
          {
              return this.IntervalField;
          }
          set
          {
             if(this.IntervalField != value)
             {
                 this.IntervalField = value;
                 this.RaisePropertyChanged("Interval");
             }
          }
      }
      
      [DataMemberAttribute()]
      public decimal? Used
      {
          get
          {
              return this.UsedField;
          }
          set
          {
             if(this.UsedField != value)
             {
                 this.UsedField = value;
                 this.RaisePropertyChanged("Used");
             }
          }
      }
      
      [DataMemberAttribute()]
      public decimal? Remain
      {
          get
          {
              return this.RemainField;
          }
          set
          {
             if(this.RemainField != value)
             {
                 this.RemainField = value;
                 this.RaisePropertyChanged("Remain");
             }
          }
      }
      
      [DataMemberAttribute()]
      public decimal? Utiliza
      {
          get
          {
              return this.UtilizaField;
          }
          set
          {
             if(this.UtilizaField != value)
             {
                 this.UtilizaField = value;
                 this.RaisePropertyChanged("Utiliza");
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
      public int PartsMonitorID
      {
          get
          {
              return this.PartsMonitorIDField;
          }
          set
          {
             if(this.PartsMonitorIDField != value)
             {
                 this.PartsMonitorIDField = value;
                 this.RaisePropertyChanged("PartsMonitorID");
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
             if(this.IDField != value)
             {
                 this.IDField = value;
                 this.RaisePropertyChanged("ID");
             }
          }
      }
      
   }
   
   /// <summary>
   /// PartsMonitorDetailDataObjectList
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [CollectionDataContractAttribute(Name = "PartsMonitorDetailDataObjectList", ItemName = "PartsMonitorDetailDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public class PartsMonitorDetailDataObjectList : BaseDataObjectList<PartsMonitorDetailDataObject>
   {
   }
   
   /// <summary>
   /// PartsMonitorDetailResultData
   /// </summary>
   [DataContractAttribute(Name = "PartsMonitorDetailResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(PartsMonitorDetailResultData))]
   public class PartsMonitorDetailResultData : ResultData<PartsMonitorDetailDataObject>
   {
   }
   
   /// <summary>
   /// PartsMonitorDetailWithPagination
   /// </summary>
   [DataContractAttribute(Name = "PartsMonitorDetailWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(PartsMonitorDetailWithPagination))]
   public class PartsMonitorDetailWithPagination : BaseDataObjectListWithPagination<PartsMonitorDetailDataObject>
   {
   }
}
