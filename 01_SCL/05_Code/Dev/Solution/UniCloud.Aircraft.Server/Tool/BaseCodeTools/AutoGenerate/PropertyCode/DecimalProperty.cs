#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：zhangnx 时间：2013/8/14 15:54:03
// 文件名：DecimalProperty
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
   public class DecimalProperty:  BaseProperty
    {
       public DecimalProperty(string typeName)
           : base(typeName)
        {
            
        }
       /// <summary>
       //// 生成Configuration属性(SqlServer)  
       /// </summary>
       /// <param name="p"></param>
       /// <param name="sb"></param>
       public override void ConfigurationPropertySqlServer(PropertyInfo p, StringBuilder sb)
       {
           if (p.Name.Equals("CurrencyRate"))
           {
               sb.AppendLine(GeneratorHelper.GetTabString(3) + "Property(p => p." + p.Name +
                             ").HasColumnType(\"decimal\").HasPrecision(12, 6);");
           }

           else
           {
               sb.AppendLine(GeneratorHelper.GetTabString(3) + "Property(p => p." + p.Name +
                             ").HasColumnType(\"decimal\").HasPrecision(16, 4);");
           }
       }

       /// <summary>
       //// 生成Configuration属性(Oracle) 
       /// </summary>
       /// <param name="p"></param>
       /// <param name="sb"></param>
       public override void ConfigurationPropertyOracle(PropertyInfo p, StringBuilder sb)
       {
           sb.AppendLine(GeneratorHelper.GetTabString(3) + "Property(p => p." + p.Name + ").HasColumnName(\"" + GetOracleColumnName(p.Name) + "\").HasColumnType(\"decimal\").HasPrecision(16, 4);");
       }
    }
}
