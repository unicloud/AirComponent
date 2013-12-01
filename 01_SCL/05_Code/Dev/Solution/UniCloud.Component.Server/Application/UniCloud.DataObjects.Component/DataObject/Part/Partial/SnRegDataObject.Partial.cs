#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/21 9:41:58

// 文件名：SnRegDataObject.Partial
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
   ///SnRegDataObject
   /// </summary>
   public partial class SnRegDataObject
   {
      private SnHistoryDataObject snHistoryField;
      private SnHistoryUnitDataObject SnTsnField;
      private SnHistoryUnitDataObject SnCsnField;
      private SnRegDataObject NhSnRegField;
      private SnRegDataObject RootSnRegField;
      private AttactDocumentDataObjectList AttactDocumentsField;
      private string ItemNoField;
      private string PnSnField;
   
      [DataMemberAttribute()]
      public SnHistoryDataObject snHistory
      {
          get
          {
              return this.snHistoryField;
          }
          set
          {
             if(this.snHistoryField != value)
             {
                 this.snHistoryField = value;
             }
          }
      }
      
      [DataMemberAttribute()]
      public SnHistoryUnitDataObject SnTsn
      {
          get
          {
              return this.SnTsnField;
          }
          set
          {
             if(this.SnTsnField != value)
             {
                 this.SnTsnField = value;
             }
          }
      }
      
      [DataMemberAttribute()]
      public SnHistoryUnitDataObject SnCsn
      {
          get
          {
              return this.SnCsnField;
          }
          set
          {
             if(this.SnCsnField != value)
             {
                 this.SnCsnField = value;
             }
          }
      }
      
      [DataMemberAttribute()]
      public SnRegDataObject NhSnReg
      {
          get
          {
              return this.NhSnRegField;
          }
          set
          {
             if(this.NhSnRegField != value)
             {
                 this.NhSnRegField = value;
             }
          }
      }
      
      [DataMemberAttribute()]
      public SnRegDataObject RootSnReg
      {
          get
          {
              return this.RootSnRegField;
          }
          set
          {
             if(this.RootSnRegField != value)
             {
                 this.RootSnRegField = value;
             }
          }
      }
      
      [DataMemberAttribute()]
      public AttactDocumentDataObjectList AttactDocuments
      {
          get
          {
              return this.AttactDocumentsField;
          }
          set
          {
             if(this.AttactDocumentsField != value)
             {
                 this.AttactDocumentsField = value;
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
             }
          }
      }
      
      [DataMemberAttribute()]
      public string PnSn
      {
          get
          {
              return this.PnSnField;
          }
          set
          {
             if(this.PnSnField != value)
             {
                 this.PnSnField = value;
             }
          }
      }
      
   }
}
