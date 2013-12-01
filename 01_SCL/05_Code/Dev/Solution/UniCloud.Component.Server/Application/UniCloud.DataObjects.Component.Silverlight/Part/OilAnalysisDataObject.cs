#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/6 10:51:21

// 文件名：OilAnalysisDataObject
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
   ///OilAnalysisDataObject
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [DataContractAttribute(Name = "OilAnalysisDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public partial class OilAnalysisDataObject : BaseDataObject
   {
      private DateTime FlightDateField;
      private string PnField;
      private string SnField;
      private string AcRegField;
      private string MsnField;
      private string AtaField;
      private string ZoneField;
      private string PositionField;
      private decimal TqsrField;
      private decimal TsrField;
      private string NotesField;
      private decimal? TocField;
      private decimal? TocnField;
      private decimal? IocField;
      private decimal? IocaField;
      private decimal? IocnField;
      private decimal? Aoc3Field;
      private decimal? Aoc7Field;
      private decimal? AocnField;
      private string WarnTagField;
      private int IDField;


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
      public decimal Tqsr
      {
          get
          {
              return this.TqsrField;
          }
          set
          {
             if(this.TqsrField != value)
             {
                 this.TqsrField = value;
                 this.RaisePropertyChanged("Tqsr");
             }
          }
      }
      
      [DataMemberAttribute()]
      public decimal Tsr
      {
          get
          {
              return this.TsrField;
          }
          set
          {
             if(this.TsrField != value)
             {
                 this.TsrField = value;
                 this.RaisePropertyChanged("Tsr");
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
      public decimal? Toc
      {
          get
          {
              return this.TocField;
          }
          set
          {
             if(this.TocField != value)
             {
                 this.TocField = value;
                 this.RaisePropertyChanged("Toc");
             }
          }
      }
      
      [DataMemberAttribute()]
      public decimal? Tocn
      {
          get
          {
              return this.TocnField;
          }
          set
          {
             if(this.TocnField != value)
             {
                 this.TocnField = value;
                 this.RaisePropertyChanged("Tocn");
             }
          }
      }
      
      [DataMemberAttribute()]
      public decimal? Ioc
      {
          get
          {
              return this.IocField;
          }
          set
          {
             if(this.IocField != value)
             {
                 this.IocField = value;
                 this.RaisePropertyChanged("Ioc");
             }
          }
      }
      
      [DataMemberAttribute()]
      public decimal? Ioca
      {
          get
          {
              return this.IocaField;
          }
          set
          {
             if(this.IocaField != value)
             {
                 this.IocaField = value;
                 this.RaisePropertyChanged("Ioca");
             }
          }
      }
      
      [DataMemberAttribute()]
      public decimal? Iocn
      {
          get
          {
              return this.IocnField;
          }
          set
          {
              if (this.IocnField != value)
             {
                 this.IocnField = value;
                 this.RaisePropertyChanged("Iocn");
             }
          }
      }
      
      [DataMemberAttribute()]
      public decimal? Aoc3
      {
          get
          {
              return this.Aoc3Field;
          }
          set
          {
             if(this.Aoc3Field != value)
             {
                 this.Aoc3Field = value;
                 this.RaisePropertyChanged("Aoc3");
             }
          }
      }
      
      [DataMemberAttribute()]
      public decimal? Aoc7
      {
          get
          {
              return this.Aoc7Field;
          }
          set
          {
             if(this.Aoc7Field != value)
             {
                 this.Aoc7Field = value;
                 this.RaisePropertyChanged("Aoc7");
             }
          }
      }
      
      [DataMemberAttribute()]
      public decimal? Aocn
      {
          get
          {
              return this.AocnField;
          }
          set
          {
             if(this.AocnField != value)
             {
                 this.AocnField = value;
                 this.RaisePropertyChanged("Aocn");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string WarnTag
      {
          get
          {
              return this.WarnTagField;
          }
          set
          {
             if(this.WarnTagField != value)
             {
                 this.WarnTagField = value;
                 this.RaisePropertyChanged("WarnTag");
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
   /// OilAnalysisDataObjectList
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [CollectionDataContractAttribute(Name = "OilAnalysisDataObjectList", ItemName = "OilAnalysisDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public class OilAnalysisDataObjectList : BaseDataObjectList<OilAnalysisDataObject>
   {
   }
   
   /// <summary>
   /// OilAnalysisResultData
   /// </summary>
   [DataContractAttribute(Name = "OilAnalysisResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(OilAnalysisResultData))]
   public class OilAnalysisResultData : ResultData<OilAnalysisDataObject>
   {
   }
   
   /// <summary>
   /// OilAnalysisWithPagination
   /// </summary>
   [DataContractAttribute(Name = "OilAnalysisWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(OilAnalysisWithPagination))]
   public class OilAnalysisWithPagination : BaseDataObjectListWithPagination<OilAnalysisDataObject>
   {
   }
}
