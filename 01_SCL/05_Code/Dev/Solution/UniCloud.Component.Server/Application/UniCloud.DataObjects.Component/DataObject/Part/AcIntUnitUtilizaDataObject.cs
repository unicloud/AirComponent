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

namespace UniCloud.DataObjects
{
   /// <summary>
   ///AcIntUnitUtilizaDataObject
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [DataContractAttribute(Name = "AcIntUnitUtilizaDataObject", IsReference = false)]
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
   /// AcIntUnitUtilizaDataObjectList
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [CollectionDataContractAttribute(Name = "AcIntUnitUtilizaDataObjectList", ItemName = "AcIntUnitUtilizaDataObject")]
   public class AcIntUnitUtilizaDataObjectList : BaseDataObjectList<AcIntUnitUtilizaDataObject>
   {
   }
   
   /// <summary>
   /// AcIntUnitUtilizaResultData
   /// </summary>
   [KnownType(typeof(AcIntUnitUtilizaResultData))]
   public class AcIntUnitUtilizaResultData : ResultData<AcIntUnitUtilizaDataObject>
   {
   }
   
   /// <summary>
   /// AcIntUnitUtilizaWithPagination
   /// </summary>
   [KnownType(typeof(AcIntUnitUtilizaWithPagination))]
   public class AcIntUnitUtilizaWithPagination : BaseDataObjectListWithPagination<AcIntUnitUtilizaDataObject>
   {
   }
}
