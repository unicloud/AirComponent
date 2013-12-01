#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency时间：2013/8/27 15:14:30

// 文件名：ScnAcorderDataObject
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
    ///ScnAcorderDataObject
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "ScnAcorderDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public partial class ScnAcorderDataObject : BaseDataObject
    {
        private int IDField;
        private string AcOrderField;
        private string AcOrderItemField;
        private string NotesField;
        private string AcregField;
        private int ScnMainIDField;
        private bool IsCheckField;
        private string AcModelField;
        private string MSNField;
        private decimal? PriceField;
        private string CSCNumberField;
        //private ScnMainDataObject ScnMainField;

        [DataMemberAttribute()]
        public string CSCNumber
        {
            get
            {
                return this.CSCNumberField;
            }
            set
            {
                if (this.CSCNumberField != value)
                {
                    this.CSCNumberField = value;
                    this.RaisePropertyChanged("CSCNumber");
                }
            }
        }

        [DataMemberAttribute()]
        public decimal? Price
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
                    this.RaisePropertyChanged("Price");
                }
            }
        }

        [DataMemberAttribute()]
        public string MSN
        {
            get
            {
                return this.MSNField;
            }
            set
            {
                if (this.MSNField != value)
                {
                    this.MSNField = value;
                    this.RaisePropertyChanged("MSN");
                }
            }
        }

        [DataMemberAttribute()]
        public string AcModel
        {
            get
            {
                return this.AcModelField;
            }
            set
            {
                if (this.AcModelField != value)
                {
                    this.AcModelField = value;
                    this.RaisePropertyChanged("AcModel");
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
                if (this.IDField != value)
                {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }

        [DataMemberAttribute()]
        public string Acreg
        {
            get
            {
                return this.AcregField;
            }
            set
            {
                if (this.AcregField != value)
                {
                    this.AcregField = value;
                    this.RaisePropertyChanged("Acreg");
                }
            }
        }

        [DataMemberAttribute()]
        public string AcOrder
        {
            get
            {
                return this.AcOrderField;
            }
            set
            {
                if (this.AcOrderField != value)
                {
                    this.AcOrderField = value;
                    this.RaisePropertyChanged("AcOrder");
                }
            }
        }

        [DataMemberAttribute()]
        public string AcOrderItem
        {
            get
            {
                return this.AcOrderItemField;
            }
            set
            {
                if (this.AcOrderItemField != value)
                {
                    this.AcOrderItemField = value;
                    this.RaisePropertyChanged("AcOrderItem");
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
        public int ScnMainID
        {
            get
            {
                return this.ScnMainIDField;
            }
            set
            {
                if (this.ScnMainIDField != value)
                {
                    this.ScnMainIDField = value;
                    this.RaisePropertyChanged("ScnMainID");
                }
            }
        }

        [DataMemberAttribute()]
        public bool IsCheck
        {
            get
            {
                return this.IsCheckField;
            }
            set
            {
                if (this.IsCheckField != value)
                {
                    this.IsCheckField = value;
                    this.RaisePropertyChanged("IsCheck");
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
    /// ScnAcorderDataObjectList
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [CollectionDataContractAttribute(Name = "ScnAcorderDataObjectList", ItemName = "ScnAcorderDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class ScnAcorderDataObjectList : BaseDataObjectList<ScnAcorderDataObject>
    {
    }

    /// <summary>
    /// ScnAcorderResultData
    /// </summary>
    [DataContractAttribute(Name = "ScnAcorderResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(ScnAcorderResultData))]
    public class ScnAcorderResultData : ResultData<ScnAcorderDataObject>
    {
    }

    /// <summary>
    /// ScnAcorderWithPagination
    /// </summary>
    [DataContractAttribute(Name = "ScnAcorderWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(ScnAcorderWithPagination))]
    public class ScnAcorderWithPagination : BaseDataObjectListWithPagination<ScnAcorderDataObject>
    {
    }
}
