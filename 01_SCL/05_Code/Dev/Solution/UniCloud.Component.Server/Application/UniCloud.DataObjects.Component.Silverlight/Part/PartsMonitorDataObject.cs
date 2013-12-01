#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/31 11:55:11

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

namespace UniCloud.DataObjects.Silverlight
{
   /// <summary>
   ///PartsMonitorDataObject
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [DataContractAttribute(Name = "PartsMonitorDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public partial class PartsMonitorDataObject : BaseDataObject
   {
      private int PnRegIDField;
      private int SnRegIDField;
      private SnRegDataObject SnRegField;
      private string ItemNoField;
      private string NhItemNoField;
      private string PolicyExecField;
      private string UsedTimeField;
      private string RemainTimeField;
      private DateTime ExpireDateField;
      private string WorkscopeField;
      private PartsMonitorDetailDataObjectList PartsMonitorDetailsField;
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
                 this.RaisePropertyChanged("NhItemNo");
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
                 this.RaisePropertyChanged("UsedTime");
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
                 this.RaisePropertyChanged("RemainTime");
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
                 this.RaisePropertyChanged("PartsMonitorDetails");
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
   /// PartsMonitorDataObjectList
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [CollectionDataContractAttribute(Name = "PartsMonitorDataObjectList", ItemName = "PartsMonitorDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public class PartsMonitorDataObjectList : BaseDataObjectList<PartsMonitorDataObject>
   {
   }
   
   /// <summary>
   /// PartsMonitorResultData
   /// </summary>
   [DataContractAttribute(Name = "PartsMonitorResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(PartsMonitorResultData))]
   public class PartsMonitorResultData : ResultData<PartsMonitorDataObject>
   {
   }
   
   /// <summary>
   /// PartsMonitorWithPagination
   /// </summary>
   [DataContractAttribute(Name = "PartsMonitorWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(PartsMonitorWithPagination))]
   public class PartsMonitorWithPagination : BaseDataObjectListWithPagination<PartsMonitorDataObject>
   {
   }
}
