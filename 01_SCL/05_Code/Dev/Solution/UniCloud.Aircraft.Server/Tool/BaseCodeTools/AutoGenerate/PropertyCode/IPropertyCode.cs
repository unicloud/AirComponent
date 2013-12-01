#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：zhangnx 时间：2013/8/9 15:36:18
// 文件名：IPropertyCode
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
    public interface IPropertyCode
    {
        /// <summary>
        ///生成DataObject定义部分  
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sb"></param>
        void DataObjectPrivateDeclare(PropertyInfo p, StringBuilder sb);

        /// <summary>
        /// 生成DataObject属性（服务端）  
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sb"></param>
        void DataObjectPropertyServer(PropertyInfo p, StringBuilder sb);

        /// <summary>
        //// 生成DataObject属性（Silverlight客户端）  
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sb"></param>
        void DataObjectPropertySilverlight(PropertyInfo p, StringBuilder sb);

        /// <summary>
        /// 生成Configuration属性(SqlServer)  
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sb"></param>
        void ConfigurationPropertySqlServer(PropertyInfo p, StringBuilder sb);

        /// <summary>
        /// 生成Configuration属性(Oracle) 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sb"></param>
        void ConfigurationPropertyOracle(PropertyInfo p, StringBuilder sb);

        /// <summary>
        /// 查询属性赋值 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="sb"></param>
        void QueryPropertyAssign(PropertyInfo p, StringBuilder sb, ref bool blNeedComma);

    }

}
