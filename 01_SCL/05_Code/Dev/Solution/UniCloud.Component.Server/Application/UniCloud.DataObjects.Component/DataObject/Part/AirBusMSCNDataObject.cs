#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/13 10:03:05

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

namespace UniCloud.DataObjects
{
   /// <summary>
   ///AirBusMSCNDataObject
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [DataContractAttribute(Name = "AirBusMSCNDataObject", IsReference = false)]
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
   /// AirBusMSCNDataObjectList
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [CollectionDataContractAttribute(Name = "AirBusMSCNDataObjectList", ItemName = "AirBusMSCNDataObject")]
   public class AirBusMSCNDataObjectList : BaseDataObjectList<AirBusMSCNDataObject>
   {
   }
   
   /// <summary>
   /// AirBusMSCNResultData
   /// </summary>
   [KnownType(typeof(AirBusMSCNResultData))]
   public class AirBusMSCNResultData : ResultData<AirBusMSCNDataObject>
   {
   }
   
   /// <summary>
   /// AirBusMSCNWithPagination
   /// </summary>
   [KnownType(typeof(AirBusMSCNWithPagination))]
   public class AirBusMSCNWithPagination : BaseDataObjectListWithPagination<AirBusMSCNDataObject>
   {
   }
}
