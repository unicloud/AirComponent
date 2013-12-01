#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：zhangnx 时间：2013/8/9 15:34:40
// 文件名：RepositoryInterfaceClass
// 版本：V1.0.0
//
// 修改者： 时间： 
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Reflection;
using System.Text;
using BaseCodeTools.AutoGenerate.PropertyCode;

namespace BaseCodeTools.AutoGenerate.ClassCode
{
    public class RepositoryInterface : BaseClassCode
    {
        public override string GetClassName(string modelName)
        {
            return "I" +　modelName + "Repository";
        }

        protected override void AddClassHeader(Type m, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// 表示用于" + m.Name + "聚合根的仓储接口。");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"public interface " + GetClassName(m.Name) +
                          ": IRepository<" + m.Name + ">");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"{");
        }

        protected override void AddClassContent(Type m, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 实现对" + m.Name + "的增删改。");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 需要添加的" + m.Name + "对象集合");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 需要删除的" + m.Name + "的ID集合");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 需要更新的" + m.Name + "对象集合");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns>执行后的更改结果</returns>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"void Commit" + m.Name + "(List<" + m.Name + "> add" +
                          m.Name + "s, IEnumerable<string> deleteIds, List<" + m.Name + "> update" + m.Name +
                          "s);");
        }

        protected override void AddClassFooter(Type m, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"}");
        }
    }
}
