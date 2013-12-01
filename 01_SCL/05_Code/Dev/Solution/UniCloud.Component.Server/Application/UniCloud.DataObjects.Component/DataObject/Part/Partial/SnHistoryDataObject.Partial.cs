#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/21 9:41:58

// 文件名：SnHistoryDataObject.Partial
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
   ///SnHistoryDataObject
   /// </summary>
   public partial class SnHistoryDataObject
   {
      private SnHistoryUnitDataObject SnHistoryFhField;
      private SnHistoryUnitDataObject SnHistoryCyField;
      private string SnField;
      private string PnField;
      private string NhSnField;
      private string NhPnField;
   
      [DataMemberAttribute()]
      public SnHistoryUnitDataObject SnHistoryFh
      {
          get
          {
              return this.SnHistoryFhField;
          }
          set
          {
             if(this.SnHistoryFhField != value)
             {
                 this.SnHistoryFhField = value;
             }
          }
      }
      
      [DataMemberAttribute()]
      public SnHistoryUnitDataObject SnHistoryCy
      {
          get
          {
              return this.SnHistoryCyField;
          }
          set
          {
             if(this.SnHistoryCyField != value)
             {
                 this.SnHistoryCyField = value;
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
             }
          }
      }
      
      [DataMemberAttribute()]
      public string NhSn
      {
          get
          {
              return this.NhSnField;
          }
          set
          {
             if(this.NhSnField != value)
             {
                 this.NhSnField = value;
             }
          }
      }
      
      [DataMemberAttribute()]
      public string NhPn
      {
          get
          {
              return this.NhPnField;
          }
          set
          {
             if(this.NhPnField != value)
             {
                 this.NhPnField = value;
             }
          }
      }
      
   }
}
