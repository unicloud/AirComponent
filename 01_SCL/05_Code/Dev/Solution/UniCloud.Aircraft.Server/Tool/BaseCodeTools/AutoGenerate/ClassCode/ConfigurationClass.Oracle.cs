#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：zhangnx 时间：2013/8/9 15:34:40
// 文件名：ConfigurationClassOracle
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
    public class ConfigurationClassOracle : BaseClassCode
    {
        public override string GetClassName(string modelName)
        {
            return modelName + "Configuration";
        }

        protected override void AddClassHeader(Type m, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"public class " + GetClassName(m.Name) + ": EntityTypeConfiguration<" + m.Name + ">");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"{");
        }

        /// <summary>
        /// 反射，获取属性
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public override PropertyInfo[] GetProperties(Type m)
        {
            return m.GetProperties(BindingFlags.GetProperty | BindingFlags.Instance |
                                                   BindingFlags.Public | BindingFlags.DeclaredOnly);
        }

        protected override void AddClassContent(Type m, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"public " + GetClassName(m.Name) + "()");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"HasKey(k => k.ID);");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + "Property(p => p.ID).HasColumnName(\"" + m.Name + "ID\").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);");

            var propertyInfos = GetProperties(m);
            foreach (var p in propertyInfos)
            {
                if (IsValidProperty(p) )
                {
                    if (IsValidProperty(p) && !IsID(p))
                    {
                        var ipc = PropertyCodeContainer.GetInstance().GetProertyCode(p.PropertyType.Name);
                        if (ipc == null) continue;
                        ipc.ConfigurationPropertyOracle(p, sb);
                    }
                }
            }
            sb.AppendLine(GeneratorHelper.GetTabString(3) + "ToTable(\"" + m.Name + "\", DefineTableSchema.Schema );");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + "}");
        }

        protected override void AddClassFooter(Type m, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"}");
        }
    }
}