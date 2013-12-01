#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：zhangnx 时间：2013/8/9 15:36:18
// 文件名：IAutoGenerateCode
// 版本：V1.0.0
//
// 修改者： 时间： 
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Text;

namespace BaseCodeTools.AutoGenerate.FileCode
{
   public interface IFileCode
    {
        /// <summary>
        ///生成一个文件  
        /// </summary>
        /// <param name="m"></param>
        void GenerateOneCodeFile(Type m);
    }

}
