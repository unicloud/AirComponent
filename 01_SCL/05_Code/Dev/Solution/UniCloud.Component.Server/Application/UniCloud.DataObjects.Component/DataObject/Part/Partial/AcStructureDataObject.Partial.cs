#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/11/20 10:07:15
* 文件名：AcStructureDataObject
* 版本：V1.0.0
*
* 修改者： 时间： 
* 修改说明：
* ========================================================================
*/
#endregion
using System.Runtime.Serialization;

namespace UniCloud.DataObjects
{
    public partial class AcStructureDataObject
    {
        private AttactDocumentDataObjectList AttactDocumentsField;

        [DataMemberAttribute()]
        public AttactDocumentDataObjectList AttactDocuments
        {
            get
            {
                return this.AttactDocumentsField;
            }
            set
            {
                if (this.AttactDocumentsField != value)
                {
                    this.AttactDocumentsField = value;
                }
            }
        }
    }
}
