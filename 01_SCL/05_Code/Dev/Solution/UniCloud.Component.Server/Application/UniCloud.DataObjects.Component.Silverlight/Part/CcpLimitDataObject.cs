#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/27 15:14:30

// 文件名：CcpLimitDataObject
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
   ///CcpLimitDataObject
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [DataContractAttribute(Name = "CcpLimitDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public partial class CcpLimitDataObject : BaseDataObject
   {
      private int IDField;
      private string IeamField;
      private int RangeMinField;
      private string ControlTypeField;
      private string ControlNoField;
      private string EngineTliField;
      private string UnitField;
      private int IntervalField;
      private string ControlGroupField;
      private int RangeMaxField;
      private string RangeTypeField;
      private string WorkScopeField;
      private int? WorkScopeIDField;
      private string PolicyExecField;
      private string SourceField;
      private string NotesField;
      private WorkScopeDataObject WorkScopeItemField;
      private IntUnitDataObject IntUnitField;
      private int CcpMainIDField;
      //private CcpMainDataObject CcpMainField;
   
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
      public int? RangeMin
      {
          get
          {
              return this.RangeMinField;
          }
          set
          {
             if(this.RangeMinField != value)
             {
                 this.RangeMinField = value == null ? 0 : value.Value;
                 this.RaisePropertyChanged("RangeMin");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string ControlType
      {
          get
          {
              return this.ControlTypeField;
          }
          set
          {
             if(this.ControlTypeField != value)
             {
                 this.ControlTypeField = value;
                 this.RaisePropertyChanged("ControlType");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string ControlNo
      {
          get
          {
              return this.ControlNoField;
          }
          set
          {
             if(this.ControlNoField != value)
             {
                 this.ControlNoField = value;
                 this.RaisePropertyChanged("ControlNo");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string EngineTli
      {
          get
          {
              return this.EngineTliField;
          }
          set
          {
             if(this.EngineTliField != value)
             {
                 this.EngineTliField = value;
                 this.RaisePropertyChanged("EngineTli");
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
      public string ControlGroup
      {
          get
          {
              return this.ControlGroupField;
          }
          set
          {
             if(this.ControlGroupField != value)
             {
                 this.ControlGroupField = value;
                 this.RaisePropertyChanged("ControlGroup");
             }
          }
      }
      
      [DataMemberAttribute()]
      public int? RangeMax
      {
          get
          {
              return this.RangeMaxField;
          }
          set
          {
             if(this.RangeMaxField != value)
             {
                 this.RangeMaxField = value == null ? 0 : value.Value;
                 this.RaisePropertyChanged("RangeMax");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string RangeType
      {
          get
          {
              return this.RangeTypeField;
          }
          set
          {
             if(this.RangeTypeField != value)
             {
                 this.RangeTypeField = value;
                 this.RaisePropertyChanged("RangeType");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string WorkScope
      {
          get
          {
              return this.WorkScopeField;
          }
          set
          {
             if(this.WorkScopeField != value)
             {
                 this.WorkScopeField = value;
                 this.RaisePropertyChanged("WorkScope");
             }
          }
      }
      
      [DataMemberAttribute()]
      public int? WorkScopeID
      {
          get
          {
              return this.WorkScopeIDField;
          }
          set
          {
             if(this.WorkScopeIDField != value)
             {
                 this.WorkScopeIDField = value;
                 this.RaisePropertyChanged("WorkScopeID");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string PolicyExec
      {
          get
          {
              return this.PolicyExecField;
          }
          set
          {
             if(this.PolicyExecField != value)
             {
                 this.PolicyExecField = value;
                 this.RaisePropertyChanged("PolicyExec");
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
             if(this.SourceField != value)
             {
                 this.SourceField = value;
                 this.RaisePropertyChanged("Source");
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
      public WorkScopeDataObject WorkScopeItem
      {
          get
          {
              return this.WorkScopeItemField;
          }
          set
          {
             if(this.WorkScopeItemField != value)
             {
                 this.WorkScopeItemField = value;
                 this.RaisePropertyChanged("WorkScopeItem");
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
      
      [DataMemberAttribute()]
      public int CcpMainID
      {
          get
          {
              return this.CcpMainIDField;
          }
          set
          {
             if(this.CcpMainIDField != value)
             {
                 this.CcpMainIDField = value;
                 this.RaisePropertyChanged("CcpMainID");
             }
          }
      }
      
      //[DataMemberAttribute()]
      //public CcpMainDataObject CcpMain
      //{
      //    get
      //    {
      //        return this.CcpMainField;
      //    }
      //    set
      //    {
      //       if(this.CcpMainField != value)
      //       {
      //           this.CcpMainField = value;
      //           this.RaisePropertyChanged("CcpMain");
      //       }
      //    }
      //}
      
   }
   
   /// <summary>
   /// CcpLimitDataObjectList
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [CollectionDataContractAttribute(Name = "CcpLimitDataObjectList", ItemName = "CcpLimitDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public class CcpLimitDataObjectList : BaseDataObjectList<CcpLimitDataObject>
   {
   }
   
   /// <summary>
   /// CcpLimitResultData
   /// </summary>
   [DataContractAttribute(Name = "CcpLimitResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(CcpLimitResultData))]
   public class CcpLimitResultData : ResultData<CcpLimitDataObject>
   {
   }
   
   /// <summary>
   /// CcpLimitWithPagination
   /// </summary>
   [DataContractAttribute(Name = "CcpLimitWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(CcpLimitWithPagination))]
   public class CcpLimitWithPagination : BaseDataObjectListWithPagination<CcpLimitDataObject>
   {
   }
}
