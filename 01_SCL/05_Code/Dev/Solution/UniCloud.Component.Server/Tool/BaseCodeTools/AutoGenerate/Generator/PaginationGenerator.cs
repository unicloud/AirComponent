using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BaseCodeTools.AutoGenerate.FileCode;
using BaseCodeTools.AutoGenerate.PropertyCode;

namespace BaseCodeTools.AutoGenerate.Generator
{
    public class PaginationGenerator : IGenerator
   {
       private string _nameSpace = "UniCloud.Domain.Model.";
        protected string GetFilePath()
        {
            return "E:\\AutoGenerate\\Others\\";
        }

        private string GetFileName()
        {
            return "Pagination.cs";
        }

        /// <summary>
        /// 获取文件全路径
        /// </summary>
        /// <returns></returns>
        protected string GetFullFileName()
        {
            return GetFilePath() + GetFileName();
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="content"></param>
        /// <param name="fileName"></param>
        protected void SaveFile(string content, string fileName)
        {
            File.WriteAllText(fileName, content);
        }

        /// <summary>
        /// 生成代码文件
        /// </summary>
        public void GenerateCodeFile()
        {
            var sb = new StringBuilder();
            var modelTypes = GeneratorHelper.GetModelAssembly();
            var modelType= modelTypes.GetType();
            CreatePaginationBuilder(sb, modelType);

            GeneratorHelper.ForceDirectory(GetFilePath());
            SaveFile(sb.ToString(), GetFullFileName());
        }
        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="typeName">类型名称</param>
        /// <returns></returns>
        private string GetTypeName(string typeName)
       {
           return _nameSpace + typeName;
       }

        private StringBuilder CreatePaginationBuilder(StringBuilder sb, Type m)
        {
            //GetPage
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 获取" + m.Name + "分页信息。");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"wherePredicate\">查询表达式。</param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"sortPredicate\">排序表达式。</param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"pagination\">分页信息。</param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns>"+m.Name +"分页信息。</returns>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) +
                       @" public " + m.Name + "WithPagination Get" + m.Name + "Page(Expression<Func<" + m.Name +
                       ", bool>> wherePredicate,");
            sb.AppendLine(GeneratorHelper.GetTabString(6) +
                               @"Expression<Func<" + m.Name +
                       ", dynamic>> sortPredicate,");
            sb.AppendLine(GeneratorHelper.GetTabString(6) +
                   @"Pagination pagination)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");

            sb.AppendLine(GeneratorHelper.GetTabString(3) +
                                        @"Expression<Func<" + m.Name +
                                "," + m.Name + "DataObject>> mapper=t=> new " + m.Name + "DataObject");
            sb.AppendLine(GeneratorHelper.GetTabString(4) + @"{");
            var propertyInfos = GetProperties(m);
            var blNeedComma = false;
            foreach (PropertyInfo p in propertyInfos)
            {
                if (IsValidProperty(p))
                {
                    var ipc = PropertyCodeContainer.GetInstance().GetProertyCode(GetPropertyTypeName(p));
                    if (ipc == null)
                        continue;
                    ipc.QueryPropertyAssign(p, sb, ref blNeedComma);
                }
            }
            sb.AppendLine(GeneratorHelper.GetTabString(4) + @"};");
            sb.AppendLine(GeneratorHelper.GetTabString(3) +
                          @"var " + GeneratorHelper.LowercaseFirst(m.Name) + "Result = _context.LoadPageDataObjects<" + m.Name + "," + m.Name +
                          "DataObject>(wherePredicate, sortPredicate, pagination, mapper);");
            sb.AppendLine(GeneratorHelper.GetTabString(3) +
                          @"if(" + GeneratorHelper.LowercaseFirst(m.Name) + "Result==null) return null;");
            sb.AppendLine(GeneratorHelper.GetTabString(3) +
                          @"pagination.TotalPages=" + GeneratorHelper.LowercaseFirst(m.Name) + "Result.TotalPages;");
            sb.AppendLine(GeneratorHelper.GetTabString(3) +
                          @"var " + GeneratorHelper.LowercaseFirst(m.Name) + "WithPagination= new " + m.Name + "WithPagination");
            sb.AppendLine(GeneratorHelper.GetTabString(4) +
                          @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(5) +
                          @"Pagination=pagination,");
            sb.AppendLine(GeneratorHelper.GetTabString(5) +
                          @"BaseDataObjectList = new BaseDataObjectList<" + m.Name + "DataObject>()");
            sb.AppendLine(GeneratorHelper.GetTabString(4) +
                          @"};");
            sb.AppendLine(GeneratorHelper.GetTabString(3) +
                          @"foreach (var value in " + GeneratorHelper.LowercaseFirst(m.Name) + "Result.Data)");
            sb.AppendLine(GeneratorHelper.GetTabString(4) +
                          @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(5) +
                          @"" + GeneratorHelper.LowercaseFirst(m.Name) + "WithPagination.BaseDataObjectList.Add(value);");
            sb.AppendLine(GeneratorHelper.GetTabString(4) +
                          @"}");
            sb.AppendLine(GeneratorHelper.GetTabString(4) +
                      @"return " + GeneratorHelper.LowercaseFirst(m.Name) + "WithPagination;");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            return sb;

        }

        /// <summary>
        /// 反射，获取属性
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public virtual PropertyInfo[] GetProperties(Type m)
        {
            return m.GetProperties(BindingFlags.GetProperty | BindingFlags.Instance |
                                                   BindingFlags.Public);
        }

        /// <summary>
        /// 判断是否为属性
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        protected virtual bool IsValidProperty(PropertyInfo p)
        {
            return !p.PropertyType.Name.StartsWith("ICollection") && p.Name != "UncommittedEvents";
        }

        /// <summary>
        /// Get Property Type Name
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string GetPropertyTypeName(PropertyInfo p)
        {
            return BaseProperty.GetPropertyTypeName(p);
        }
   }
}
