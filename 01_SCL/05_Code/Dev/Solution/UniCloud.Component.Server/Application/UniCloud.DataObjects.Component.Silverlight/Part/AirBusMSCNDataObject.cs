#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/13 10:03:06

// 文件名：AirBusMSCNDataObject
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
   ///AirBusMSCNDataObject
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [DataContractAttribute(Name = "AirBusMSCNDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public partial class AirBusMSCNDataObject : BaseDataObject
   {
      private string MscnNoField;
      private string MscnTitleField;
      private string AtaField;
      private string ModField;
      private string StatusField;
      private string MsnField;
      private string FleetField;
      private int IDField;
   
      [DataMemberAttribute()]
      public string MscnNo
      {
          get
          {
              return this.MscnNoField;
          }
          set
          {
             if(this.MscnNoField != value)
             {
                 this.MscnNoField = value;
                 this.RaisePropertyChanged("MscnNo");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string MscnTitle
      {
          get
          {
              return this.MscnTitleField;
          }
          set
          {
             if(this.MscnTitleField != value)
             {
                 this.MscnTitleField = value;
                 this.RaisePropertyChanged("MscnTitle");
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
      public string Mod
      {
          get
          {
              return this.ModField;
          }
          set
          {
             if(this.ModField != value)
             {
                 this.ModField = value;
                 this.RaisePropertyChanged("Mod");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string Status
      {
          get
          {
              return this.StatusField;
          }
          set
          {
             if(this.StatusField != value)
             {
                 this.StatusField = value;
                 this.RaisePropertyChanged("Status");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string Msn
      {
          get
          {
              return this.MsnField;
          }
          set
          {
             if(this.MsnField != value)
             {
                 this.MsnField = value;
                 this.RaisePropertyChanged("Msn");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string Fleet
      {
          get
          {
              return this.FleetField;
          }
          set
          {
             if(this.FleetField != value)
             {
                 this.FleetField = value;
                 this.RaisePropertyChanged("Fleet");
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
   /// AirBusMSCNDataObjectList
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [CollectionDataContractAttribute(Name = "AirBusMSCNDataObjectList", ItemName = "AirBusMSCNDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public class AirBusMSCNDataObjectList : BaseDataObjectList<AirBusMSCNDataObject>
   {
   }
   
   /// <summary>
   /// AirBusMSCNResultData
   /// </summary>
   [DataContractAttribute(Name = "AirBusMSCNResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(AirBusMSCNResultData))]
   public class AirBusMSCNResultData : ResultData<AirBusMSCNDataObject>
   {
   }
   
   /// <summary>
   /// AirBusMSCNWithPagination
   /// </summary>
   [DataContractAttribute(Name = "AirBusMSCNWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(AirBusMSCNWithPagination))]
   public class AirBusMSCNWithPagination : BaseDataObjectListWithPagination<AirBusMSCNDataObject>
   {
   }
}
