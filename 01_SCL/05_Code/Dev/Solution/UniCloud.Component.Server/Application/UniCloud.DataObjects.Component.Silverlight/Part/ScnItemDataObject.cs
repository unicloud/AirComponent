#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/27 15:14:30

// 文件名：ScnItemDataObject
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
   ///ScnItemDataObject
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [DataContractAttribute(Name = "ScnItemDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public partial class ScnItemDataObject : BaseDataObject
   {
      private int IDField;
      private int ScnMainIDField;
      private int ItemNoField;
      private int? PnRegIDField;
      private int AtaIDField;
      private Guid AtaGuidField;
      private string PnField;
      private string DescriptionField;
      private string VendorField;
      private string NotesField;
      private int QtyField;
      private string CurrencyField;
      private decimal PriceField;
      private decimal TotalPriceField;
      //private ScnMainDataObject ScnMainField;

      /// <summary>
      ///总价
      /// </summary>
      [DataMemberAttribute()]
      public decimal TotalPrice
      {
          get
          {
              return this.TotalPriceField;
          }
          set
          {
              if (this.TotalPriceField != value)
              {
                  this.TotalPriceField = value;
                  this.RaisePropertyChanged("TotalPrice");
              }
          }
      }

      /// <summary>
      /// 单价
      /// </summary>
      [DataMemberAttribute()]
      public decimal Price
      {
          get
          {
              return this.PriceField;
          }
          set
          {
              if (this.PriceField != value)
              {
                  this.PriceField = value;
                  this.TotalPrice = this.QtyField * this.PriceField;
                  this.RaisePropertyChanged("Price");
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
      
      [DataMemberAttribute()]
      public int ScnMainID
      {
          get
          {
              return this.ScnMainIDField;
          }
          set
          {
             if(this.ScnMainIDField != value)
             {
                 this.ScnMainIDField = value;
                 this.RaisePropertyChanged("ScnMainID");
             }
          }
      }
      
      [DataMemberAttribute()]
      public int ItemNo
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
      public int AtaID
      {
          get
          {
              return this.AtaIDField;
          }
          set
          {
             if(this.AtaIDField != value)
             {
                 this.AtaIDField = value;
                 this.RaisePropertyChanged("AtaID");
             }
          }
      }
      
      [DataMemberAttribute()]
      public Guid AtaGuid
      {
          get
          {
              return this.AtaGuidField;
          }
          set
          {
             if(this.AtaGuidField != value)
             {
                 this.AtaGuidField = value;
                 this.RaisePropertyChanged("AtaGuid");
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
      public string Vendor
      {
          get
          {
              return this.VendorField;
          }
          set
          {
             if(this.VendorField != value)
             {
                 this.VendorField = value;
                 this.RaisePropertyChanged("Vendor");
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
      public int Qty
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
                 this.TotalPrice = this.QtyField*this.PriceField;
                 this.RaisePropertyChanged("Qty");
             }
          }
      }
      
      [DataMemberAttribute()]
      public string Currency
      {
          get
          {
              return this.CurrencyField;
          }
          set
          {
             if(this.CurrencyField != value)
             {
                 this.CurrencyField = value;
                 this.RaisePropertyChanged("Currency");
             }
          }
      }
      
      //[DataMemberAttribute()]
      //public ScnMainDataObject ScnMain
      //{
      //    get
      //    {
      //        return this.ScnMainField;
      //    }
      //    set
      //    {
      //       if(this.ScnMainField != value)
      //       {
      //           this.ScnMainField = value;
      //           this.RaisePropertyChanged("ScnMain");
      //       }
      //    }
      //}
      
   }
   
   /// <summary>
   /// ScnItemDataObjectList
   /// </summary>
   [System.Diagnostics.DebuggerStepThroughAttribute()]
   [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
   [CollectionDataContractAttribute(Name = "ScnItemDataObjectList", ItemName = "ScnItemDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   public class ScnItemDataObjectList : BaseDataObjectList<ScnItemDataObject>
   {
   }
   
   /// <summary>
   /// ScnItemResultData
   /// </summary>
   [DataContractAttribute(Name = "ScnItemResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(ScnItemResultData))]
   public class ScnItemResultData : ResultData<ScnItemDataObject>
   {
   }
   
   /// <summary>
   /// ScnItemWithPagination
   /// </summary>
   [DataContractAttribute(Name = "ScnItemWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
   [KnownType(typeof(ScnItemWithPagination))]
   public class ScnItemWithPagination : BaseDataObjectListWithPagination<ScnItemDataObject>
   {
   }
}
