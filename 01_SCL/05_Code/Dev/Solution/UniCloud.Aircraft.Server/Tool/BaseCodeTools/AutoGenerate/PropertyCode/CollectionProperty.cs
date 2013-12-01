#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：zhangnx 时间：2013/8/14 15:54:03
// 文件名：StringProperty
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
   public class CollectionProperty:  BaseProperty
    {
       public CollectionProperty(string typeName)
           : base(typeName)
        {
            
        }

       /// <summary>
       ///获取类型名称
       /// </summary>
       /// <param name="p"></param>
       public override string GetTypeName(PropertyInfo p)
       {
           if (p.PropertyType.GenericTypeArguments.Length > 0)
           {
               return p.PropertyType.GenericTypeArguments[0].Name + "DataObjectList";
           }
           else
           {
               var subName = p.Name.Substring(p.Name.Length - 1);
               if (subName.Equals("s", StringComparison.InvariantCultureIgnoreCase))
               {
                   return subName + "DataObjectList";
               }
               subName = p.Name.Substring(p.Name.Length - 3);
               if (subName.Equals("ses", StringComparison.InvariantCultureIgnoreCase))
               {
                   return subName + "s" + "DataObjectList";
               }
               else if (subName.Equals("ies", StringComparison.InvariantCultureIgnoreCase))
               {
                   return subName + "y" + "DataObjectList";
               }
               return p.Name + "DataObjectList";
           }

       }

       /// <summary>
       /// 生成DataObject属性（服务端）  
       /// </summary>
       /// <param name="p"></param>
       /// <param name="sb"></param>
       public override void DataObjectPropertyServer(PropertyInfo p, StringBuilder sb)
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
       public override void DataObjectPropertySilverlight(PropertyInfo p, StringBuilder sb)
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
       public override void ConfigurationPropertySqlServer(PropertyInfo p, StringBuilder sb)
       {
       }

       /// <summary>
       //// 生成Configuration属性(Oracle) 
       /// </summary>
       /// <param name="p"></param>
       /// <param name="sb"></param>
       public override void ConfigurationPropertyOracle(PropertyInfo p, StringBuilder sb)
       {

       }
    }
}
