#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：zhangnx 时间：2013/8/14 15:54:03
// 文件名：GuidClassProperty
// 版本：V1.0.0
//
// 修改者： 时间： 
// 修改说明：
// ========================================================================*/
#endregion

using System.Reflection;
using System.Text;

namespace BaseCodeTools.AutoGenerate.PropertyCode
{
   public class GuidClassProperty: BaseProperty
    {
       public GuidClassProperty(string typeName)
           : base(typeName)
        {
            
        }
        /// <summary>
        ///生成DataObject定义部分  
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sb"></param>
       public override void DataObjectPrivateDeclare(PropertyInfo p, StringBuilder sb)
       {
           sb.AppendLine(GeneratorHelper.GetTabString(2) + "private " + p.Name.Substring(0, p.Name.Length - 2) +
                         "DataObject " + p.Name.Substring(0, p.Name.Length - 2) +
                         "Field;");
       }

       /// <summary>
       /// 生成DataObject属性（服务端）  
       /// </summary>
       /// <param name="p"></param>
       /// <param name="sb"></param>
       public override void DataObjectPropertyServer(PropertyInfo p, StringBuilder sb)
       {
           sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[DataMemberAttribute()]");
           sb.AppendLine(GeneratorHelper.GetTabString(2) + @"public " + p.Name.Substring(0, p.Name.Length - 2) + "DataObject " + p.Name.Substring(0, p.Name.Length - 2));
           sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
           sb.AppendLine(GeneratorHelper.GetTabString(2) + @"    get");
           sb.AppendLine(GeneratorHelper.GetTabString(2) + @"    {");
           sb.AppendLine(GeneratorHelper.GetTabString(2) + @"        return this." + p.Name.Substring(0, p.Name.Length - 2) + "Field;");
           sb.AppendLine(GeneratorHelper.GetTabString(2) + @"    }");
           sb.AppendLine(GeneratorHelper.GetTabString(2) + @"    set");
           sb.AppendLine(GeneratorHelper.GetTabString(2) + @"    {");
           sb.AppendLine(GeneratorHelper.GetTabString(3) + @"        if(this." + p.Name + "Field != value)");
           sb.AppendLine(GeneratorHelper.GetTabString(3) + @"    {");
           sb.AppendLine(GeneratorHelper.GetTabString(4) + @"        this." + p.Name + "Field = value;");
           sb.AppendLine(GeneratorHelper.GetTabString(4) + @"        this.RaisePropertyChanged(""" + p.Name + "\"");
           sb.AppendLine(GeneratorHelper.GetTabString(3) + @"    }");
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
           sb.AppendLine(GeneratorHelper.GetTabString(2) + @"public Guid " + p.Name);
           sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
           sb.AppendLine(GeneratorHelper.GetTabString(2) + @"    get");
           sb.AppendLine(GeneratorHelper.GetTabString(2) + @"    {");
           sb.AppendLine(GeneratorHelper.GetTabString(2) + @"        return this." + p.Name + "Field;");
           sb.AppendLine(GeneratorHelper.GetTabString(2) + @"    }");
           sb.AppendLine(GeneratorHelper.GetTabString(2) + @"    set");
           sb.AppendLine(GeneratorHelper.GetTabString(2) + @"    {");
           sb.AppendLine(GeneratorHelper.GetTabString(2) + @"        this." + p.Name + "Field = value;");
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
