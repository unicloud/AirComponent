#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/22 15:27:10

// 文件名：OilHistoryDataObject
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
   ///OilHistoryDataObject
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [DataContractAttribute(Name = "OilHistoryDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public partial class OilHistoryDataObject : BaseDataObject
   {
      private int IDField;
      private string AcRegField;
      private string MsnField;
      private DateTime FlightDateField;
      private string FlLognoField;
      private string FlLegnoField;
      private decimal UpliftDerField;
      private decimal UpliftArrField;
      private string PnField;
      private string SnField;
      private string AtaField;
      private string ZoneField;
      private string PositionField;
      private decimal TsnField;
      private decimal CsnField;
      private decimal FhField;
      private decimal CyField;
      private DateTime UpdateDateField;
      private string NotesField;
      private string InstalDateField;
   
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
      public string AcReg
      {
          get
          {
              return this.AcRegField;
          }
          set
          {
             if(this.AcRegField != value)
             {
                 this.AcRegField = value;
                 this.RaisePropertyChanged("AcReg");
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
      public DateTime FlightDate
      {
          get
          {
              return this.FlightDateField;
          }
          set
          {
             if(this.FlightDateField != value)
             {
                 this.FlightDateField = value;
                 this.RaisePropertyChanged("FlightDate");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string FlLogno
      {
          get
          {
              return this.FlLognoField;
          }
          set
          {
             if(this.FlLognoField != value)
             {
                 this.FlLognoField = value;
                 this.RaisePropertyChanged("FlLogno");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string FlLegno
      {
          get
          {
              return this.FlLegnoField;
          }
          set
          {
             if(this.FlLegnoField != value)
             {
                 this.FlLegnoField = value;
                 this.RaisePropertyChanged("FlLegno");
             }
          }
      }
      
      [DataMemberAttribute()]
      public decimal UpliftDer
      {
          get
          {
              return this.UpliftDerField;
          }
          set
          {
             if(this.UpliftDerField != value)
             {
                 this.UpliftDerField = value;
                 this.RaisePropertyChanged("UpliftDer");
             }
          }
      }
      
      [DataMemberAttribute()]
      public decimal UpliftArr
      {
          get
          {
              return this.UpliftArrField;
          }
          set
          {
             if(this.UpliftArrField != value)
             {
                 this.UpliftArrField = value;
                 this.RaisePropertyChanged("UpliftArr");
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
      public string Sn
      {
          get
          {
              return this.SnField;
          }
          set
          {
             if(this.SnField != value)
             {
                 this.SnField = value;
                 this.RaisePropertyChanged("Sn");
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
      public string Zone
      {
          get
          {
              return this.ZoneField;
          }
          set
          {
             if(this.ZoneField != value)
             {
                 this.ZoneField = value;
                 this.RaisePropertyChanged("Zone");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string Position
      {
          get
          {
              return this.PositionField;
          }
          set
          {
             if(this.PositionField != value)
             {
                 this.PositionField = value;
                 this.RaisePropertyChanged("Position");
             }
          }
      }
      
      [DataMemberAttribute()]
      public decimal Tsn
      {
          get
          {
              return this.TsnField;
          }
          set
          {
             if(this.TsnField != value)
             {
                 this.TsnField = value;
                 this.RaisePropertyChanged("Tsn");
             }
          }
      }
      
      [DataMemberAttribute()]
      public decimal Csn
      {
          get
          {
              return this.CsnField;
          }
          set
          {
             if(this.CsnField != value)
             {
                 this.CsnField = value;
                 this.RaisePropertyChanged("Csn");
             }
          }
      }
      
      [DataMemberAttribute()]
      public decimal Fh
      {
          get
          {
              return this.FhField;
          }
          set
          {
             if(this.FhField != value)
             {
                 this.FhField = value;
                 this.RaisePropertyChanged("Fh");
             }
          }
      }
      
      [DataMemberAttribute()]
      public decimal Cy
      {
          get
          {
              return this.CyField;
          }
          set
          {
             if(this.CyField != value)
             {
                 this.CyField = value;
                 this.RaisePropertyChanged("Cy");
             }
          }
      }
      
      [DataMemberAttribute()]
      public DateTime UpdateDate
      {
          get
          {
              return this.UpdateDateField;
          }
          set
          {
             if(this.UpdateDateField != value)
             {
                 this.UpdateDateField = value;
                 this.RaisePropertyChanged("UpdateDate");
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
      public string InstalDate
      {
          get
          {
              return this.InstalDateField;
          }
          set
          {
             if(this.InstalDateField != value)
             {
                 this.InstalDateField = value;
                 this.RaisePropertyChanged("InstalDate");
             }
          }
      }
      
   }
   
   /// <summary>
   /// OilHistoryDataObjectList
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [CollectionDataContractAttribute(Name = "OilHistoryDataObjectList", ItemName = "OilHistoryDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public class OilHistoryDataObjectList : BaseDataObjectList<OilHistoryDataObject>
   {
   }
   
   /// <summary>
   /// OilHistoryResultData
   /// </summary>
   [DataContractAttribute(Name = "OilHistoryResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(OilHistoryResultData))]
   public class OilHistoryResultData : ResultData<OilHistoryDataObject>
   {
   }
   
   /// <summary>
   /// OilHistoryWithPagination
   /// </summary>
   [DataContractAttribute(Name = "OilHistoryWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(OilHistoryWithPagination))]
   public class OilHistoryWithPagination : BaseDataObjectListWithPagination<OilHistoryDataObject>
   {
   }
}
