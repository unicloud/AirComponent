#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency 时间：2013/8/21 16:33:24
// 文件名：DocumentService
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
	/// 实现文档接口实例
	/// </summary>
	public class DocumentService:IDocumentService {

		private readonly DocumentServiceClient _service=new DocumentServiceClient();
		private static  readonly  DocumentService _instance=new DocumentService();

		public static DocumentService Instance
		{
			get { return _instance; }
		}

		/// <summary>
		/// 添加文档
		/// </summary>
		/// <param name="doc">文档</param>
		/// <returns>文档主键</returns>
		public Guid? AddDocuemnt(DocumentDataObject doc)
		{
			return _service.AddContractDTO(doc);
		}

		/// <summary>
		/// 根据文档主键获取文档
		/// </summary>
		/// <param name="docID">文档主键</param>
		/// <returns>文档</returns>
		public DocumentDataObject GetDocumentDataObjectByDocID(Guid docID)
		{
			return _service.GetDocumentDataObjectByDocID(docID);
		}
	}
}
