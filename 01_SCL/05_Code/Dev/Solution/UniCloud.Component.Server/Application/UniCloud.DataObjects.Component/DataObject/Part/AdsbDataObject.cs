#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/11/18 10:33:25

// 文件名：AdsbDataObject
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
    ///AdsbDataObject
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "AdsbDataObject", IsReference = false)]
    public partial class AdsbDataObject : BaseDataObject
    {
        private string ActypeField;
        private string FileTypeField;
        private string FileNoField;
        private string FileVersionField;
        private string FileTitleField;
        private string FromFileField;
        private string ContentField;
        private DateTime? ReceiveDateField;
        private AdsbComplyDataObjectList AdsbComplysField;
        private int IDField;


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
        public string FileTitle
        {
            get
            {
                return this.FileTitleField;
            }
            set
            {
                if (this.FileTitleField != value)
                {
                    this.FileTitleField = value;
                }
            }
        }

        [DataMemberAttribute()]
        public string FromFile
        {
            get
            {
                return this.FromFileField;
            }
            set
            {
                if (this.FromFileField != value)
                {
                    this.FromFileField = value;
                }
            }
        }

        [DataMemberAttribute()]
        public string Content
        {
            get
            {
                return this.ContentField;
            }
            set
            {
                if (this.ContentField != value)
                {
                    this.ContentField = value;
                }
            }
        }

        [DataMemberAttribute()]
        public DateTime? ReceiveDate
        {
            get
            {
                return this.ReceiveDateField;
            }
            set
            {
                if (this.ReceiveDateField != value)
                {
                    this.ReceiveDateField = value;
                }
            }
        }

        [DataMemberAttribute()]
        public AdsbComplyDataObjectList AdsbComplys
        {
            get
            {
                return this.AdsbComplysField;
            }
            set
            {
                if (this.AdsbComplysField != value)
                {
                    this.AdsbComplysField = value;
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

    }

    /// <summary>
    /// AdsbDataObjectList
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [CollectionDataContractAttribute(Name = "AdsbDataObjectList", ItemName = "AdsbDataObject")]
    public class AdsbDataObjectList : BaseDataObjectList<AdsbDataObject>
    {
    }

    /// <summary>
    /// AdsbResultData
    /// </summary>
    [KnownType(typeof(AdsbResultData))]
    public class AdsbResultData : ResultData<AdsbDataObject>
    {
    }

    /// <summary>
    /// AdsbWithPagination
    /// </summary>
    [KnownType(typeof(AdsbWithPagination))]
    public class AdsbWithPagination : BaseDataObjectListWithPagination<AdsbDataObject>
    {
    }
}
