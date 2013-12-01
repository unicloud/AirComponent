#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/21 9:41:58

// 文件名：AttactDocumentDataObject
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
    ///AttactDocumentDataObject
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "AttactDocumentDataObject", IsReference = false, Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public partial class AttactDocumentDataObject : BaseDataObject
    {
        private int BusinessIDField;
        private string BusinessField;
        private Guid DocumentIDField;
        private string FileNameField;
        private DateTime? UploadTimeField;
        private string ExtendTypeField;
        private string UploaderField;
        private string DocumentTypeField;
        private int IDField;
        private DocumentDataObject DocumentField;
        private bool CanAddField;
        private bool CanCheckField;

        /// <summary>
        /// 控制按钮是否可以查看
        /// </summary>
        [DataMemberAttribute()]
        public bool CanCheck
        {
            get
            {
                return !string.IsNullOrWhiteSpace(FileName);
            }
            set
            {
                if (this.CanCheckField != value)
                {
                    this.CanCheckField = value;
                    this.RaisePropertyChanged("CanCheck");
                }
            }
        }

        /// <summary>
        /// 控制按钮是否可以新增
        /// </summary>
        [DataMemberAttribute()]
        public bool CanAdd
        {
            get
            {
                return string.IsNullOrWhiteSpace(FileName);
            }
            set
            {
                if (this.CanAddField != value)
                {
                    this.CanAddField = value;
                    this.RaisePropertyChanged("CanAdd");
                }
            }
        }

        [DataMemberAttribute()]
        public DocumentDataObject Document
        {
            get
            {
                return this.DocumentField;
            }
            set
            {
                if (this.DocumentField != value)
                {
                    this.DocumentField = value;
                    this.RaisePropertyChanged("Document");
                }
            }
        }

        [DataMemberAttribute()]
        public int BusinessID
        {
            get
            {
                return this.BusinessIDField;
            }
            set
            {
                if (this.BusinessIDField != value)
                {
                    this.BusinessIDField = value;
                    this.RaisePropertyChanged("BusinessID");
                }
            }
        }

        [DataMemberAttribute()]
        public string Business
        {
            get
            {
                return this.BusinessField;
            }
            set
            {
                if (this.BusinessField != value)
                {
                    this.BusinessField = value;
                    this.RaisePropertyChanged("Business");
                }
            }
        }

        [DataMemberAttribute()]
        public Guid DocumentID
        {
            get
            {
                return this.DocumentIDField;
            }
            set
            {
                if (this.DocumentIDField != value)
                {
                    this.DocumentIDField = value;
                    this.RaisePropertyChanged("DocumentID");
                }
            }
        }

        [DataMemberAttribute()]
        public string FileName
        {
            get
            {
                return this.FileNameField;
            }
            set
            {
                if (this.FileNameField != value)
                {
                    this.FileNameField = value;
                    this.RaisePropertyChanged("FileName");
                }
            }
        }

        [DataMemberAttribute()]
        public DateTime? UploadTime
        {
            get
            {
                return this.UploadTimeField;
            }
            set
            {
                if (this.UploadTimeField != value)
                {
                    this.UploadTimeField = value;
                    this.RaisePropertyChanged("UploadTime");
                }
            }
        }

        [DataMemberAttribute()]
        public string ExtendType
        {
            get
            {
                return this.ExtendTypeField;
            }
            set
            {
                if (this.ExtendTypeField != value)
                {
                    this.ExtendTypeField = value;
                    this.RaisePropertyChanged("ExtendType");
                }
            }
        }

        [DataMemberAttribute()]
        public string Uploader
        {
            get
            {
                return this.UploaderField;
            }
            set
            {
                if (this.UploaderField != value)
                {
                    this.UploaderField = value;
                    this.RaisePropertyChanged("Uploader");
                }
            }
        }

        [DataMemberAttribute()]
        public string DocumentType
        {
            get
            {
                return this.DocumentTypeField;
            }
            set
            {
                if (this.DocumentTypeField != value)
                {
                    this.DocumentTypeField = value;
                    this.RaisePropertyChanged("DocumentType");
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

    }

    /// <summary>
    /// AttactDocumentDataObjectList
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [CollectionDataContractAttribute(Name = "AttactDocumentDataObjectList", ItemName = "AttactDocumentDataObject", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    public class AttactDocumentDataObjectList : BaseDataObjectList<AttactDocumentDataObject>
    {
    }

    /// <summary>
    /// AttactDocumentResultData
    /// </summary>
    [DataContractAttribute(Name = "AttactDocumentResultData", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(AttactDocumentResultData))]
    public class AttactDocumentResultData : ResultData<AttactDocumentDataObject>
    {
    }

    /// <summary>
    /// AttactDocumentWithPagination
    /// </summary>
    [DataContractAttribute(Name = "AttactDocumentWithPagination", Namespace = "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects")]
    [KnownType(typeof(AttactDocumentWithPagination))]
    public class AttactDocumentWithPagination : BaseDataObjectListWithPagination<AttactDocumentDataObject>
    {
    }
}
