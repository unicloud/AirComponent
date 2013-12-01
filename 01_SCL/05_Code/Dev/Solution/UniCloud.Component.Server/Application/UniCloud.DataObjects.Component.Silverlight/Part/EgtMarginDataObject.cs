#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/16 10:49:57

// 文件名：EgtMarginDataObject
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
   ///EgtMarginDataObject
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [DataContractAttribute(Name = "EgtMarginDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public partial class EgtMarginDataObject : BaseDataObject
   {
      private int PnRegIDField;
      private int SnRegIDField;
      private decimal EgtmField;
      private string OperatorField;
      private DateTime OperateDateField;
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
      public decimal Egtm
      {
          get
          {
              return this.EgtmField;
          }
          set
          {
             if(this.EgtmField != value)
             {
                 this.EgtmField = value;
                 this.RaisePropertyChanged("Egtm");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string Operator
      {
          get
          {
              return this.OperatorField;
          }
          set
          {
             if(this.OperatorField != value)
             {
                 this.OperatorField = value;
                 this.RaisePropertyChanged("Operator");
             }
          }
      }
      
      [DataMemberAttribute()]
      public DateTime OperateDate
      {
          get
          {
              return this.OperateDateField;
          }
          set
          {
             if(this.OperateDateField != value)
             {
                 this.OperateDateField = value;
                 this.RaisePropertyChanged("OperateDate");
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
   /// EgtMarginDataObjectList
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [CollectionDataContractAttribute(Name = "EgtMarginDataObjectList", ItemName = "EgtMarginDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public class EgtMarginDataObjectList : BaseDataObjectList<EgtMarginDataObject>
   {
   }
   
   /// <summary>
   /// EgtMarginResultData
   /// </summary>
   [DataContractAttribute(Name = "EgtMarginResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(EgtMarginResultData))]
   public class EgtMarginResultData : ResultData<EgtMarginDataObject>
   {
   }
   
   /// <summary>
   /// EgtMarginWithPagination
   /// </summary>
   [DataContractAttribute(Name = "EgtMarginWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(EgtMarginWithPagination))]
   public class EgtMarginWithPagination : BaseDataObjectListWithPagination<EgtMarginDataObject>
   {
   }
}
