#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/18 10:33:25

// 文件名：AdsbComplyDataObject
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
    ///AdsbComplyDataObject
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "AdsbComplyDataObject", IsReference = false)]
    public partial class AdsbComplyDataObject : BaseDataObject
    {
        private string ActypeField;
        private string FileTypeField;
        private string FileNoField;
        private string FileVersionField;
        private string ComplyAcField;
        private string ComplyStatusField;
        private DateTime? ComplyDateField;
        private string ComplyNotesField;
        private string ComplyCloseField;
        private decimal? ComFeeField;
        private string ComFeeNotesField;
        private string ComFeeCurrencyField;
        private int IDField;
        private AdsbDataObject AdsbField;
        private int AdsbIDField;

        [DataMemberAttribute()]
        public int AdsbID
        {
            get
            {
                return this.AdsbIDField;
            }
            set
            {
                if (this.AdsbIDField != value)
                {
                    this.AdsbIDField = value;
                }
            }
        }

        [DataMemberAttribute()]
        public string Actype
        {
            get
            {
                return this.ActypeField;
            }
            set
            {
                if (this.ActypeField != value)
                {
                    this.ActypeField = value;
                }
            }
        }

        [DataMemberAttribute()]
        public string FileType
        {
            get
            {
                return this.FileTypeField;
            }
            set
            {
                if (this.FileTypeField != value)
                {
                    this.FileTypeField = value;
                }
            }
        }

        [DataMemberAttribute()]
        public string FileNo
        {
            get
            {
                return this.FileNoField;
            }
            set
            {
                if (this.FileNoField != value)
                {
                    this.FileNoField = value;
                }
            }
        }

        [DataMemberAttribute()]
        public string FileVersion
        {
            get
            {
                return this.FileVersionField;
            }
            set
            {
                if (this.FileVersionField != value)
                {
                    this.FileVersionField = value;
                }
            }
        }

        [DataMemberAttribute()]
        public string ComplyAc
        {
            get
            {
                return this.ComplyAcField;
            }
            set
            {
                if (this.ComplyAcField != value)
                {
                    this.ComplyAcField = value;
                }
            }
        }

        [DataMemberAttribute()]
        public string ComplyStatus
        {
            get
            {
                return this.ComplyStatusField;
            }
            set
            {
                if (this.ComplyStatusField != value)
                {
                    this.ComplyStatusField = value;
                }
            }
        }

        [DataMemberAttribute()]
        public DateTime? ComplyDate
        {
            get
            {
                return this.ComplyDateField;
            }
            set
            {
                if (this.ComplyDateField != value)
                {
                    this.ComplyDateField = value;
                }
            }
        }

        [DataMemberAttribute()]
        public string ComplyNotes
        {
            get
            {
                return this.ComplyNotesField;
            }
            set
            {
                if (this.ComplyNotesField != value)
                {
                    this.ComplyNotesField = value;
                }
            }
        }

        [DataMemberAttribute()]
        public string ComplyClose
        {
            get
            {
                return this.ComplyCloseField;
            }
            set
            {
                if (this.ComplyCloseField != value)
                {
                    this.ComplyCloseField = value;
                }
            }
        }

        [DataMemberAttribute()]
        public decimal? ComFee
        {
            get
            {
                return this.ComFeeField;
            }
            set
            {
                if (this.ComFeeField != value)
                {
                    this.ComFeeField = value;
                }
            }
        }

        [DataMemberAttribute()]
        public string ComFeeNotes
        {
            get
            {
                return this.ComFeeNotesField;
            }
            set
            {
                if (this.ComFeeNotesField != value)
                {
                    this.ComFeeNotesField = value;
                }
            }
        }

        [DataMemberAttribute()]
        public string ComFeeCurrency
        {
            get
            {
                return this.ComFeeCurrencyField;
            }
            set
            {
                if (this.ComFeeCurrencyField != value)
                {
                    this.ComFeeCurrencyField = value;
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
                }
            }
        }

        [DataMemberAttribute()]
        public AdsbDataObject Adsb
        {
            get
            {
                return this.AdsbField;
            }
            set
            {
                if (this.AdsbField != value)
                {
                    this.AdsbField = value;
                }
            }
        }

    }

    /// <summary>
    /// AdsbComplyDataObjectList
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [CollectionDataContractAttribute(Name = "AdsbComplyDataObjectList", ItemName = "AdsbComplyDataObject")]
    public class AdsbComplyDataObjectList : BaseDataObjectList<AdsbComplyDataObject>
    {
    }

    /// <summary>
    /// AdsbComplyResultData
    /// </summary>
    [KnownType(typeof(AdsbComplyResultData))]
    public class AdsbComplyResultData : ResultData<AdsbComplyDataObject>
    {
    }

    /// <summary>
    /// AdsbComplyWithPagination
    /// </summary>
    [KnownType(typeof(AdsbComplyWithPagination))]
    public class AdsbComplyWithPagination : BaseDataObjectListWithPagination<AdsbComplyDataObject>
    {
    }
}
