#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/31 11:49:18

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

namespace UniCloud.DataObjects
{
   /// <summary>
   ///PartsMonitorDetailDataObject
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [DataContractAttribute(Name = "PartsMonitorDetailDataObject", IsReference = false)]
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
             }
          }
      }
      
   }
   
   /// <summary>
   /// PartsMonitorDetailDataObjectList
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [CollectionDataContractAttribute(Name = "PartsMonitorDetailDataObjectList", ItemName = "PartsMonitorDetailDataObject")]
   public class PartsMonitorDetailDataObjectList : BaseDataObjectList<PartsMonitorDetailDataObject>
   {
   }
   
   /// <summary>
   /// PartsMonitorDetailResultData
   /// </summary>
   [KnownType(typeof(PartsMonitorDetailResultData))]
   public class PartsMonitorDetailResultData : ResultData<PartsMonitorDetailDataObject>
   {
   }
   
   /// <summary>
   /// PartsMonitorDetailWithPagination
   /// </summary>
   [KnownType(typeof(PartsMonitorDetailWithPagination))]
   public class PartsMonitorDetailWithPagination : BaseDataObjectListWithPagination<PartsMonitorDetailDataObject>
   {
   }
}
