#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/27 15:14:30

// 文件名：CcpMainDataObject
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
   ///CcpMainDataObject
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [DataContractAttribute(Name = "CcpMainDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public partial class CcpMainDataObject : BaseDataObject
   {
      private int IDField;
      private string ItemNoField;
      private string AcTypeField;
      private string AtaField;
      private string DescriptionField;
      private bool IsLifeField;
      private string StateField;
      private int VersionField;
      private string NhItemNoField;
      private string UpdatebyField;
      private DateTime UpdateTimeField;
      private CcpLimitDataObjectList CcpLimitsField;
      private CcpPnDataObjectList CcpPnsField;
      private WfHistoryDataObjectList WfHistorysField;
   
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
      public string AcType
      {
          get
          {
              return this.AcTypeField;
          }
          set
          {
              if (this.AcTypeField != value)
             {
                 this.AcTypeField = value;
                 this.RaisePropertyChanged("AcType");
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
              if (this.AtaField != value)
             {
                 this.AtaField = value;
                 this.RaisePropertyChanged("Ata");
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
      public bool IsLife
      {
          get
          {
              return this.IsLifeField;
          }
          set
          {
             if(this.IsLifeField != value)
             {
                 this.IsLifeField = value;
                 this.RaisePropertyChanged("IsLife");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string State
      {
          get
          {
              return this.StateField;
          }
          set
          {
             if(this.StateField != value)
             {
                 this.StateField = value;
                 this.RaisePropertyChanged("State");
             }
          }
      }
      
      [DataMemberAttribute()]
      public int Version
      {
          get
          {
              return this.VersionField;
          }
          set
          {
             if(this.VersionField != value)
             {
                 this.VersionField = value;
                 this.RaisePropertyChanged("Version");
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
      public string Updateby
      {
          get
          {
              return this.UpdatebyField;
          }
          set
          {
             if(this.UpdatebyField != value)
             {
                 this.UpdatebyField = value;
                 this.RaisePropertyChanged("Updateby");
             }
          }
      }
      
      [DataMemberAttribute()]
      public DateTime UpdateTime
      {
          get
          {
              return this.UpdateTimeField;
          }
          set
          {
             if(this.UpdateTimeField != value)
             {
                 this.UpdateTimeField = value;
                 this.RaisePropertyChanged("UpdateTime");
             }
          }
      }
      
      [DataMemberAttribute()]
      public CcpLimitDataObjectList CcpLimits
      {
          get
          {
              return this.CcpLimitsField;
          }
          set
          {
             if(this.CcpLimitsField != value)
             {
                 this.CcpLimitsField = value;
                 this.RaisePropertyChanged("CcpLimits");
             }
          }
      }
      
      [DataMemberAttribute()]
      public CcpPnDataObjectList CcpPns
      {
          get
          {
              return this.CcpPnsField;
          }
          set
          {
             if(this.CcpPnsField != value)
             {
                 this.CcpPnsField = value;
                 this.RaisePropertyChanged("CcpPns");
             }
          }
      }
      
      [DataMemberAttribute()]
      public WfHistoryDataObjectList WfHistorys
      {
          get
          {
              return this.WfHistorysField;
          }
          set
          {
             if(this.WfHistorysField != value)
             {
                 this.WfHistorysField = value;
                 this.RaisePropertyChanged("WfHistorys");
             }
          }
      }
      
   }
   
   /// <summary>
   /// CcpMainDataObjectList
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [CollectionDataContractAttribute(Name = "CcpMainDataObjectList", ItemName = "CcpMainDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public class CcpMainDataObjectList : BaseDataObjectList<CcpMainDataObject>
   {
   }
   
   /// <summary>
   /// CcpMainResultData
   /// </summary>
   [DataContractAttribute(Name = "CcpMainResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(CcpMainResultData))]
   public class CcpMainResultData : ResultData<CcpMainDataObject>
   {
   }
   
   /// <summary>
   /// CcpMainWithPagination
   /// </summary>
   [DataContractAttribute(Name = "CcpMainWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(CcpMainWithPagination))]
   public class CcpMainWithPagination : BaseDataObjectListWithPagination<CcpMainDataObject>
   {
   }
}
