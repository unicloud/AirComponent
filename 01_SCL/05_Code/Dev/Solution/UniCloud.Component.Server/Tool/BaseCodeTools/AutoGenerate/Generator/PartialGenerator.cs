#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency 时间：2013/8/21 17:16:50
// 文件名：PartialGenerator
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
using BaseCodeTools.AutoGenerate.FileCode;

namespace BaseCodeTools.AutoGenerate.Generator {


	public class PartialGenerator : BaseGenerator {
		protected override BaseFileCode CreateFileCode() {
			return new PartialFile();
		}

	}
}
