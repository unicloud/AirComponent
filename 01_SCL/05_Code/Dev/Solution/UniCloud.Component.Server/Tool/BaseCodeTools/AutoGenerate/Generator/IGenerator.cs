#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：zhangnx 时间：2013/8/9 15:36:18
// 文件名：IGenerator
// 版本：V1.0.0
//
// 修改者： 时间： 
// 修改说明：
// ========================================================================*/
#endregion

namespace BaseCodeTools.AutoGenerate.Generator
{
  public interface IGenerator
    {
        /// <summary>
        /// 生成代码文件
        /// </summary>
        void GenerateCodeFile();
    }

}
