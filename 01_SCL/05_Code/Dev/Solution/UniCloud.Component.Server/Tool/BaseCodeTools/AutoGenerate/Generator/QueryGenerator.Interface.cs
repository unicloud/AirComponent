#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：zhangnx 时间：2013/8/9 17:04:00
// 文件名：QueryGeneratorInterface
// 版本：V1.0.0
//
// 修改者： 时间： 
// 修改说明：
// ========================================================================*/
#endregion

using BaseCodeTools.AutoGenerate.FileCode;

namespace BaseCodeTools.AutoGenerate.Generator
{
    public class QueryGeneratorInterface : BaseGenerator
    {
        protected override BaseFileCode CreateFileCode()
        {
            return new QueryInterfaceFile();
        }
    }
}
