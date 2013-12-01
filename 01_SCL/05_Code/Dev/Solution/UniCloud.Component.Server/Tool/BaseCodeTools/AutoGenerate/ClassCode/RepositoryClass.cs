#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：zhangnx 时间：2013/8/9 15:34:40
// 文件名：RepositoryClass
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
    public class RepositoryClass : BaseClassCode
    {
        public override string GetClassName(string modelName)
        {
            return modelName + "Repository";
        }

        protected override void AddClassHeader(Type m, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"public class " + GetClassName(m.Name) + ": EntityFrameworkGuidRepository<" + m.Name + ">, I" + GetClassName(m.Name));
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"{");
        }

        protected override void AddClassContent(Type m, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"private readonly UniCloudDbContextFRP _efContext;");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + "public " + GetClassName(m.Name) +
                          "(IRepositoryContext context) : base(context)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"_efContext = EFContext.Context as UniCloudDbContextFRP;");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");

            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 实现对" + m.Name + "的增删改。");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 需要添加的" + m.Name + "对象集合");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 需要删除的" + m.Name + "的ID集合");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 需要更新的" + m.Name + "对象集合");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns>执行后的更改结果</returns>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"public void Commit" + m.Name + "(List<" + m.Name +
                          "> add" +
                          m.Name + "s,  IEnumerable<string> deleteIds,  List<" + m.Name + "> update" + m.Name +
                          "s)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"Add" + m.Name + "s(add" + m.Name + "s);");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"Delete" + m.Name + "s(deleteIds);");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"Update" + m.Name + "s(update" + m.Name + "s);");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"_efContext.SaveChanges();");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");
            //Add method
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 增加" + m.Name + "");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" +"\"add" + m.Name + "s\">" + m.Name + "</param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"private void Add" + m.Name + "s(List<" + m.Name + "> add" +
                          m.Name + "s)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"  if (add" + m.Name + "s != null && add" + m.Name + "s.Any())");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"  {");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"      add" + m.Name + "s.ForEach(p =>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"      {");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"          p.ID = Guid.NewGuid();");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"          p.CreateDate = DateTime.Now;");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"          _efContext.Entry(p).State = EntityState.Added;");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"      });");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"  }");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");
            //delete method
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 删除" + m.Name + "");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" +"\"deleteIds\">删除" + m.Name + "</param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) +
                          @"private void Delete" + m.Name + "s(IEnumerable<string> deleteIds)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(2) +
                          @"  if (deleteIds != null)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"  {");
            sb.AppendLine(GeneratorHelper.GetTabString(2) +
                          @"      foreach (var id in deleteIds)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"      {");
            sb.AppendLine(GeneratorHelper.GetTabString(2) +
                          @"          var result = Get" + m.Name + "ById(id.ToString());");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"          if (result != null)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"          {");
            sb.AppendLine(GeneratorHelper.GetTabString(3) +
                          @"          _efContext.Entry(result).State = EntityState.Deleted;");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"          }");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"      }");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"  }");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");
            //update method
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"///     更新" + m.Name + "");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"update" + m.Name + "s\">更新的" + m.Name + "</param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) +
                          @"private void Update" + m.Name + "s(List<" + m.Name + "> update" + m.Name + "s)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"  if (update" + m.Name + "s != null && update" + m.Name + "s.Any())");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"  {");
            sb.AppendLine(GeneratorHelper.GetTabString(2) +
                          @"      foreach (var updateObj in update" + m.Name + "s)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"      {");
            sb.AppendLine(GeneratorHelper.GetTabString(2) +
                          @"          var obj = Get" + m.Name + "ById(updateObj.ID.ToString());");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"          if (obj != null)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"          {");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"              _efContext." + m.Name + "s.Attach(obj);");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"          }");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"      }");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"  }");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");
            //get method
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"///     根据" + m.Name + "ID获取" + m.Name + "");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name="+"\"id\">" + m.Name + "主键</param>")
            ;
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns>" + m.Name + "</returns>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) +
                          @"private " + m.Name + " Get" + m.Name + "ById(string id)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"  Guid key = Guid.Parse(id);");
            sb.AppendLine(GeneratorHelper.GetTabString(2) +
                          @"    return _efContext == null ? null : _efContext." + m.Name + "s.FirstOrDefault(p => p.ID == key);");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");

        }

        protected override void AddClassFooter(Type m, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"}");
        }
    }
}
