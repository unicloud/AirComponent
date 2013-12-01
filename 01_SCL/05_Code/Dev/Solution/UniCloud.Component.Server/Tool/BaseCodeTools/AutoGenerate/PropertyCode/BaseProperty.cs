#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：zhangnx 时间：2013/8/14 15:54:03
// 文件名：BooleanProperty
// 版本：V1.0.0
//
// 修改者： 时间： 
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Reflection;
using System.Text;

namespace BaseCodeTools.AutoGenerate.PropertyCode
{
    public class BaseProperty : IPropertyCode
    {

        protected string TypeName;

        protected BaseProperty(string typeName)
        {
            TypeName = typeName;
        }

        /// <summary>
        /// Is Nullable Property
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        protected static bool IsNullableProperty(PropertyInfo p)
        {
            return p.PropertyType.Name.Equals("Nullable`1", StringComparison.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Get Property Type Name
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string GetPropertyTypeName(PropertyInfo p)
        {
            if (!IsNullableProperty(p))
            {
                if (IsDataObjectProperty(p))
                {
                    return "DataObject";
                    
                }
                else if (IsCollectionProperty(p))
                {
                    return "Collection";
                }
                else
                {
                    return p.PropertyType.Name;
                }
            }
            else
            {
                return p.PropertyType.GenericTypeArguments[0].Name;
            }
        }

        /// <summary>
        /// Is DataObject Property
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        protected static bool IsDataObjectProperty(PropertyInfo p)
        {
            return p.PropertyType.Name.IndexOf("DataObject", StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        /// <summary>
        /// Is Collection Property
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        protected static bool IsCollectionProperty(PropertyInfo p)
        {
            return p.PropertyType.Name.IndexOf("ICollection", StringComparison.CurrentCultureIgnoreCase) >= 0;
        }

        /// <summary>
        /// Is Nullable Property
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        protected string GetTypeNamePostfix(PropertyInfo p)
        {
            return IsNullableProperty(p) ? "?" : "";
        }

        /// <summary>
        ///生成DataObject定义部分  
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sb"></param>
        public virtual void DataObjectPrivateDeclare(PropertyInfo p, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(2) + "private " + GetTypeName(p) + " " + p.Name + "Field;");
        }

        /// <summary>
        ///获取类型名称
        /// </summary>
        /// <param name="p"></param>
        public virtual string GetTypeName(PropertyInfo p)
        {
            return TypeName + GetTypeNamePostfix(p);
        }

        /// <summary>
        /// 获取Oracle字段名,字母全大写， 原有字母大写的从中间分割开
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public virtual string GetOracleColumnName(string name)
        {
            var result = "";
            var temp = name.Replace("ID", "Id");
            for (var i = 0; i < temp.Length; i++) //字符c遍历数组中的所有字符; 
            {
                var c = temp[i];

                if ( i!=0 && char.IsUpper(c)) //是否为大写 如大写计数器加1; 
                {
                    result += '_' + Convert.ToString(c);
                }
                else
                {
                    result += Convert.ToString(c);
                }
            }
            return result.ToUpper();
        }

        /// <summary>
        /// 生成DataObject属性（服务端）  
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sb"></param>
        public virtual void DataObjectPropertyServer(PropertyInfo p, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[DataMemberAttribute()]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"public " + GetTypeName(p) + " " + p.Name);
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"    get");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"    {");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"        return this." + p.Name + "Field;");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"    }");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"    set");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"    {");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"       if(this." + p.Name + "Field != value)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"       {");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"           this." + p.Name + "Field = value;");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"       }");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"    }");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
        }

        /// <summary>
        //// 生成DataObject属性（客户端）  
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sb"></param>
        public virtual void DataObjectPropertySilverlight(PropertyInfo p, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[DataMemberAttribute()]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"public " + GetTypeName(p) + " " + p.Name);
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"    get");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"    {");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"        return this." + p.Name + "Field;");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"    }");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"    set");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"    {");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"       if(this." + p.Name + "Field != value)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"       {");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"           this." + p.Name + "Field = value;");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"           this.RaisePropertyChanged(""" + p.Name + "\");");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"       }");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"    }");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
        }

        /// <summary>
        //// 生成Configuration属性(SqlServer)  
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sb"></param>
        public virtual void ConfigurationPropertySqlServer(PropertyInfo p, StringBuilder sb)
        {
        }

        /// <summary>
        //// 生成Configuration属性(Oracle) 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sb"></param>
        public virtual void ConfigurationPropertyOracle(PropertyInfo p, StringBuilder sb)
        {

        }

        /// <summary>
        /// 查询属性赋值 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sb"></param>
        public void QueryPropertyAssign(PropertyInfo p, StringBuilder sb, ref bool blNeedComma)
        {
            if (blNeedComma)
            {
                sb.AppendLine(GeneratorHelper.GetTabString(5)  + @"" + p.Name + " = t." +
                              p.Name+",");
            }
            else
            {
                sb.AppendLine(GeneratorHelper.GetTabString(5) + @"" + p.Name + " = t." +
                              p.Name + ",");
                blNeedComma = true;
            }
        }

    }
}
