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

using System.Reflection;
using System.Text;

namespace BaseCodeTools.AutoGenerate.PropertyCode
{
   public class DataObjectProperty:  BaseProperty
    {
       public DataObjectProperty(string typeName)
           : base(typeName)
        {
            
        }

       /// <summary>
       ///获取类型名称
       /// </summary>
       /// <param name="p"></param>
       public override string GetTypeName(PropertyInfo p)
       {
           return p.PropertyType.Name;
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
