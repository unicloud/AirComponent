#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/27 15:14:30

// 文件名：CcpPnDataObject
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
   ///CcpPnDataObject
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [DataContractAttribute(Name = "CcpPnDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public partial class CcpPnDataObject : BaseDataObject
   {
      private int IDField;
      private string PnField;
      private string SpecPnField;
      private string AcmodelField;
      private string AcconfigField;
      private string AcRegsField;
      private string NotesField;
      private int? QtyField;
      private string IeamField;
      private string SnsField;
      private int? PnRegIDField;
      private int CcpMainIDField;
      private PnRegDataObject PnRegField;
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
      public string Pn
      {
          get
          {
              return this.PnField;
          }
          set
          {
             if(this.PnField != value)
             {
                 this.PnField = value;
                 this.RaisePropertyChanged("Pn");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string SpecPn
      {
          get
          {
              return this.SpecPnField;
          }
          set
          {
             if(this.SpecPnField != value)
             {
                 this.SpecPnField = value;
                 this.RaisePropertyChanged("SpecPn");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string Acmodel
      {
          get
          {
              return this.AcmodelField;
          }
          set
          {
              if (this.AcmodelField != value)
             {
                 this.AcmodelField = value;
                 this.RaisePropertyChanged("Acmodel");
             }
          }
      }
       [DataMemberAttribute()]
      public string Acconfig
      {
          get
          {
              return this.AcconfigField;
          }
          set
          {
              if (this.AcconfigField != value)
              {
                  this.AcconfigField = value;
                  this.RaisePropertyChanged("Acconfig");
              }
          }
      }    
      [DataMemberAttribute()]
      public string AcRegs
      {
          get
          {
              return this.AcRegsField;
          }
          set
          {
             if(this.AcRegsField != value)
             {
                 this.AcRegsField = value;
                 this.RaisePropertyChanged("AcRegs");
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
      public int? Qty
      {
          get
          {
              return this.QtyField;
          }
          set
          {
             if(this.QtyField != value)
             {
                 this.QtyField = value;
                 this.RaisePropertyChanged("Qty");
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
      public string Sns
      {
          get
          {
              return this.SnsField;
          }
          set
          {
             if(this.SnsField != value)
             {
                 this.SnsField = value;
                 this.RaisePropertyChanged("Sns");
             }
          }
      }
      
      [DataMemberAttribute()]
      public int? PnRegID
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
      
      [DataMemberAttribute()]
      public PnRegDataObject PnReg
      {
          get
          {
              return this.PnRegField;
          }
          set
          {
             if(this.PnRegField != value)
             {
                 this.PnRegField = value;
                 this.RaisePropertyChanged("PnReg");
             }
          }
      }
      
   }
   
   /// <summary>
   /// CcpPnDataObjectList
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [CollectionDataContractAttribute(Name = "CcpPnDataObjectList", ItemName = "CcpPnDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public class CcpPnDataObjectList : BaseDataObjectList<CcpPnDataObject>
   {
   }
   
   /// <summary>
   /// CcpPnResultData
   /// </summary>
   [DataContractAttribute(Name = "CcpPnResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(CcpPnResultData))]
   public class CcpPnResultData : ResultData<CcpPnDataObject>
   {
   }
   
   /// <summary>
   /// CcpPnWithPagination
   /// </summary>
   [DataContractAttribute(Name = "CcpPnWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(CcpPnWithPagination))]
   public class CcpPnWithPagination : BaseDataObjectListWithPagination<CcpPnDataObject>
   {
   }
}
