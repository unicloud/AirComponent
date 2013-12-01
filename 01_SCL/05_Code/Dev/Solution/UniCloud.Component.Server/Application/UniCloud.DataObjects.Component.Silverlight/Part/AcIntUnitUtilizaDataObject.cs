#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/6 11:27:30

// 文件名：AcIntUnitUtilizaDataObject
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
   ///AcIntUnitUtilizaDataObject
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [DataContractAttribute(Name = "AcIntUnitUtilizaDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public partial class AcIntUnitUtilizaDataObject : BaseDataObject
   {
      private string AcRegField;
      private string MsnField;
      private string UnitField;
      private decimal UtilizaField;
      private decimal UtilizaRateField;
      private int IDField;
   
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
      public decimal Utiliza
      {
          get
          {
              return this.UtilizaField;
          }
          set
          {
             if(this.UtilizaField != value)
             {
                 this.UtilizaField = value;
                 this.RaisePropertyChanged("Utiliza");
             }
          }
      }
      
      [DataMemberAttribute()]
      public decimal UtilizaRate
      {
          get
          {
              return this.UtilizaRateField;
          }
          set
          {
             if(this.UtilizaRateField != value)
             {
                 this.UtilizaRateField = value;
                 this.RaisePropertyChanged("UtilizaRate");
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
   /// AcIntUnitUtilizaDataObjectList
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [CollectionDataContractAttribute(Name = "AcIntUnitUtilizaDataObjectList", ItemName = "AcIntUnitUtilizaDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public class AcIntUnitUtilizaDataObjectList : BaseDataObjectList<AcIntUnitUtilizaDataObject>
   {
   }
   
   /// <summary>
   /// AcIntUnitUtilizaResultData
   /// </summary>
   [DataContractAttribute(Name = "AcIntUnitUtilizaResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(AcIntUnitUtilizaResultData))]
   public class AcIntUnitUtilizaResultData : ResultData<AcIntUnitUtilizaDataObject>
   {
   }
   
   /// <summary>
   /// AcIntUnitUtilizaWithPagination
   /// </summary>
   [DataContractAttribute(Name = "AcIntUnitUtilizaWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(AcIntUnitUtilizaWithPagination))]
   public class AcIntUnitUtilizaWithPagination : BaseDataObjectListWithPagination<AcIntUnitUtilizaDataObject>
   {
   }
}
