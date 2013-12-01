#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：zhangnx 时间：2013/8/9 15:34:40
// 文件名：ConfigurationFileSqlServer
// 版本：V1.0.0
//
// 修改者： 时间： 
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Text;
using BaseCodeTools.AutoGenerate.ClassCode;

namespace BaseCodeTools.AutoGenerate.FileCode
{
    public class ConfigurationFileSqlServer : BaseFileCode
    {

        protected override string GetFilePath()
        {
            return "E:\\AutoGenerate\\Configurations\\SqlServer\\";
        }

        protected override string GetFileName(string modelName)
        {
            return ClassCode.GetClassName(modelName);
           // return  modeName + "Configuration";
        }

        protected override BaseClassCode CreateBaseClassCode()
        {
            return new ConfigurationClassSqlServer();
        }

        /// <summary>
        /// 添加文件引用单元
        /// </summary>
        /// <param name="m"></param>
        /// <param name="sb"></param>
        protected override void AddHeaderUsing(Type m, StringBuilder sb)
        {
            sb.AppendLine(@"using System;");
            sb.AppendLine(@"using System.Collections.Generic;");
            sb.AppendLine(@"using System.ComponentModel.DataAnnotations.Schema;");
            sb.AppendLine(@"using System.Data.Entity.ModelConfiguration;");
            sb.AppendLine(@"using System.Linq;");
            sb.AppendLine(@"using System.Text;");
            sb.AppendLine(@"using System.Threading.Tasks;");
            sb.AppendLine(@"using UniCloud.Domain.Model;");
            sb.AppendLine(@"");
        }

        /// <summary>
        /// 添加类命名空间
        /// </summary>
        /// <param name="m"></param>
        /// <param name="sb"></param>
        protected override void AddHeaderNameSpace(Type m, StringBuilder sb)
        {
            sb.AppendLine(@"namespace UniCloud.Domain.Repositories.EntityFramework.ModelConfigurations.SqlServer");
            sb.AppendLine(@"{");
        }

    }
}