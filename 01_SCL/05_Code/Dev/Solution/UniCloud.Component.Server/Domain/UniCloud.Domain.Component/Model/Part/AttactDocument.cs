#region Version Info
/* ========================================================================
* 版权所有 (C) 2013 UniCloud 
*【本类功能概述】
* 
* 作者：Gyoung 时间：2013/10/16 14:32:53
* 文件名：AttactDocument
* 版本：V1.0.0
*
* 修改者： 时间： 
* 修改说明：
* ========================================================================
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniCloud.Domain.Model
{
    public class AttactDocument : IntAggregateRoot
    {
        /// <summary>
        /// 业务主键
        /// </summary>
        public virtual int BusinessID
        {
            get;
            set;
        }

        /// <summary>
        /// 业务代码
        /// </summary>
        public virtual string Business
        {
            get;
            set;
        }

        /// <summary>
        /// 文档ID
        /// </summary>
        public virtual Guid DocumentID { get; set; }

        /// <summary>
        /// 文档名称
        /// </summary>
        public virtual string FileName { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        public virtual DateTime UploadTime { get; set; }

        /// <summary>
        ///扩展名
        /// </summary>
        public virtual string ExtendType { get; set; }

        /// <summary>
        /// 上传者  
        /// </summary>
        public virtual string Uploader { get; set; }

        /// <summary>
        /// 文档类型
        /// </summary>
        public virtual string DocumentType { get; set; }
    }
}
