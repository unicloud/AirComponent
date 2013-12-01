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
    ///ScnItemDto
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "ScnItemDto", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public partial class ScnItemDto : BaseDataObject
    {
        private int IDField;
        private string ScnNoField;
        private int ItemNoField;
        private string PnClassField;
        private string AtaField;
        private string PnField;
        private string DescriptionField;
        private string VendorField;
        private string NotesField;
        private int QtyField;
        private string CurrencyField;

        [DataMemberAttribute()]
        public int ID
        {
            get
            {
                return this.IDField;
            }
            set
            {
                if (this.IDField != value)
                {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }

        [DataMemberAttribute()]
        public string ScnNo
        {
            get
            {
                return this.ScnNoField;
            }
            set
            {
                if (this.ScnNoField != value)
                {
                    this.ScnNoField = value;
                    this.RaisePropertyChanged("ScnNo");
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
                if (this.ItemNoField != value)
                {
                    this.ItemNoField = value;
                    this.RaisePropertyChanged("ItemNo");
                }
            }
        }

        [DataMemberAttribute()]
        public string PnClass
        {
            get
            {
                return this.PnClassField;
            }
            set
            {
                if (this.PnClassField != value)
                {
                    this.PnClassField = value;
                    this.RaisePropertyChanged("PnClass");
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
        public string Pn
        {
            get
            {
                return this.PnField;
            }
            set
            {
                if (this.PnField != value)
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
                if (this.DescriptionField != value)
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
                if (this.VendorField != value)
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
                if (this.NotesField != value)
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
                if (this.QtyField != value)
                {
                    this.QtyField = value;
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
                if (this.CurrencyField != value)
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
    /// ScnItemDtoList
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [CollectionDataContractAttribute(Name = "ScnItemDtoList", ItemName = "ScnItemDto", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class ScnItemDtoList : BaseDataObjectList<ScnItemDto>
    {
    }

    /// <summary>
    /// ScnItemDtoResultData
    /// </summary>
    [DataContractAttribute(Name = "ScnItemDtoResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(ScnItemDtoResultData))]
    public class ScnItemDtoResultData : ResultData<ScnItemDto>
    {
    }
}
