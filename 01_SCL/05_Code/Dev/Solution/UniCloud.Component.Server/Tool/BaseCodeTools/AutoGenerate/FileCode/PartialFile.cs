#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency 时间：2013/8/21 17:15:19
// 文件名：PartialFile
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
using BaseCodeTools.AutoGenerate.ClassCode;

namespace BaseCodeTools.AutoGenerate.FileCode {

	public class PartialFile : BaseFileCode {

		protected override string GetFilePath() {
			return "E:\\AutoGenerate\\DataObjects\\Partial\\";
		}

		protected override string GetFileName(string modelName) {
			return ClassCode.GetClassName(modelName);
			//return modelName + "DataObject";
		}

		protected override BaseClassCode CreateBaseClassCode() {
			return new PartialClass();
		}

		/// <summary>
		/// 添加文件引用单元
		/// </summary>
		/// <param name="m"></param>
		/// <param name="sb"></param>
		protected override void AddHeaderUsing(Type m, StringBuilder sb) {

			sb.AppendLine(@"using System;");
			sb.AppendLine(@"using System.Collections.Generic;");
			sb.AppendLine(@"using System.Linq;");
			sb.AppendLine(@"using System.Text;");
			sb.AppendLine(@"using System.Threading.Tasks;");
			sb.AppendLine(@"using System.Runtime.Serialization;");
			sb.AppendLine(@"");
		}

		/// <summary>
		/// 添加类命名空间
		/// </summary>
		/// <param name="m"></param>
		/// <param name="sb"></param>
		protected override void AddHeaderNameSpace(Type m, StringBuilder sb) {
			sb.AppendLine(@"namespace UniCloud.DataObjects");
			sb.AppendLine(@"{");
		}
	}

}
