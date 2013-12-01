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

namespace BaseCodeTools.AutoGenerate.ClassCode
{
    interface IClassCode
    {
        /// <summary>
        /// 添加类代码 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="sb"></param>
        void AddClassCodePart(Type m, StringBuilder sb);

        /// <summary>
        /// 获取类名
        /// </summary>
        /// <param name="modelName">模块名称</param>
        /// <returns></returns>
        string GetClassName(string modelName);
    }

}
