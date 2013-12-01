#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency 时间：2013/8/21 16:30:01
// 文件名：IDocumentService
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
using UniCloud.DataObjects;

namespace UniCloud.Service.Refernce {
	/// <summary>
	/// 表示文档服务接口
	/// </summary>
	public interface IDocumentService
	{
		/// <summary>
		/// 添加文档
		/// </summary>
		/// <param name="doc">文档</param>
		/// <returns>文档主键</returns>
	    Guid? AddDocument(DocumentDataObject doc);

		/// <summary>
		/// 根据文档主键获取文档
		/// </summary>
		/// <param name="docID">文档主键</param>
		/// <returns>文档</returns>
		DocumentDataObject GetDocumentDataObjectByDocID(Guid docID);

	}
}
