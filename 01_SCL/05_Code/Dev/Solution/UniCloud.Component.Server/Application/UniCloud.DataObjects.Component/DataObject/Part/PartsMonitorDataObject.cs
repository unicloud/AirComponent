#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/31 11:49:18

// 文件名：PartsMonitorDataObject
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
   ///PartsMonitorDataObject
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [DataContractAttribute(Name = "PartsMonitorDataObject", IsReference = false)]
   public partial class PartsMonitorDataObject : BaseDataObject
   {
      private int PnRegIDField;
      private int SnRegIDField;
      private string ItemNoField;
      private string NhItemNoField;
      private string PolicyExecField;
      private string UsedTimeField;
      private string RemainTimeField;
      private DateTime ExpireDateField;
      private string WorkscopeField;
      private PartsMonitorDetailDataObjectList PartsMonitorDetailsField;
      private SnRegDataObject SnRegField;
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
      public SnRegDataObject SnReg
      {
          get
          {
              return this.SnRegField;
          }
          set
          {
              if (this.SnRegField != value)
              {
                  this.SnRegField = value;
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
      public string NhItemNo
      {
          get
          {
              return this.NhItemNoField;
          }
          set
          {
             if(this.NhItemNoField != value)
             {
                 this.NhItemNoField = value;
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
             }
          }
      }
      
      [DataMemberAttribute()]
      public string UsedTime
      {
          get
          {
              return this.UsedTimeField;
          }
          set
          {
             if(this.UsedTimeField != value)
             {
                 this.UsedTimeField = value;
             }
          }
      }
      
      [DataMemberAttribute()]
      public string RemainTime
      {
          get
          {
              return this.RemainTimeField;
          }
          set
          {
             if(this.RemainTimeField != value)
             {
                 this.RemainTimeField = value;
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
      public PartsMonitorDetailDataObjectList PartsMonitorDetails
      {
          get
          {
              return this.PartsMonitorDetailsField;
          }
          set
          {
             if(this.PartsMonitorDetailsField != value)
             {
                 this.PartsMonitorDetailsField = value;
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
   /// PartsMonitorDataObjectList
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [CollectionDataContractAttribute(Name = "PartsMonitorDataObjectList", ItemName = "PartsMonitorDataObject")]
   public class PartsMonitorDataObjectList : BaseDataObjectList<PartsMonitorDataObject>
   {
   }
   
   /// <summary>
   /// PartsMonitorResultData
   /// </summary>
   [KnownType(typeof(PartsMonitorResultData))]
   public class PartsMonitorResultData : ResultData<PartsMonitorDataObject>
   {
   }
   
   /// <summary>
   /// PartsMonitorWithPagination
   /// </summary>
   [KnownType(typeof(PartsMonitorWithPagination))]
   public class PartsMonitorWithPagination : BaseDataObjectListWithPagination<PartsMonitorDataObject>
   {
   }
}
