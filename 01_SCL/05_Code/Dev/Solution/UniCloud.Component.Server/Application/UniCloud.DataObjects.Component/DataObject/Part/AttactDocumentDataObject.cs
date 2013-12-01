#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：gyoung 时间：2013/10/21 9:40:27

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

namespace UniCloud.DataObjects
{
    /// <summary>
    ///AttactDocumentDataObject
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [DataContractAttribute(Name = "AttactDocumentDataObject", IsReference = false)]
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

        [DataMemberAttribute]
        public DocumentDataObject Document { get; set; }

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
    /// AttactDocumentDataObjectList
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [CollectionDataContractAttribute(Name = "AttactDocumentDataObjectList", ItemName = "AttactDocumentDataObject")]
    public class AttactDocumentDataObjectList : BaseDataObjectList<AttactDocumentDataObject>
    {
    }

    /// <summary>
    /// AttactDocumentResultData
    /// </summary>
    [KnownType(typeof(AttactDocumentResultData))]
    public class AttactDocumentResultData : ResultData<AttactDocumentDataObject>
    {
    }

    /// <summary>
    /// AttactDocumentWithPagination
    /// </summary>
    [KnownType(typeof(AttactDocumentWithPagination))]
    public class AttactDocumentWithPagination : BaseDataObjectListWithPagination<AttactDocumentDataObject>
    {
    }
}
