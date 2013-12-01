#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：zhangnx 时间：2013/8/9 15:34:40
// 文件名：QueryFile
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
    public class QueryFile : BaseFileCode
    {

        protected override string GetFilePath()
        {
            return "E:\\AutoGenerate\\Querys\\";
        }

        protected override string GetFileName(string modelName)
        {
            return ClassCode.GetClassName(modelName);
         }

        protected override BaseClassCode CreateBaseClassCode()
        {
            return new QueryClass();
        }

        /// <summary>
        /// 添加文件引用单元
        /// </summary>
        /// <param name="m"></param>
        /// <param name="sb"></param>
        protected override void AddHeaderUsing(Type m, StringBuilder sb)
        {
            sb.AppendLine(@"using System;");
            sb.AppendLine(@"using System.Linq;");
            sb.AppendLine(@"using System.Linq.Expressions;");
            sb.AppendLine(@"using UniCloud.DataObjects;");
            sb.AppendLine(@"using UniCloud.Domain.Model;");
            sb.AppendLine(@"using UniCloud.Domain.Repositories.EntityFramework;");
            sb.AppendLine(@"");
        }

        /// <summary>
        /// 添加类命名空间
        /// </summary>
        /// <param name="m"></param>
        /// <param name="sb"></param>
        protected override void AddHeaderNameSpace(Type m, StringBuilder sb)
        {
            sb.AppendLine(@"namespace UniCloud.Query.FRP");
            sb.AppendLine(@"{");
        }

        /// <summary>
        /// 判断是否为模型文件
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public override bool IsNeedModelFile(Type m)
        {
            if (m.BaseType == null)
            {
                return false;
            }
            else
            {
                var parentType = m.BaseType;
                while (parentType.BaseType != null &&
                       !parentType.BaseType.Name.Equals("object", StringComparison.CurrentCultureIgnoreCase))
                    parentType = parentType.BaseType;
                return parentType.Name.IndexOf("AggregateRoot", 0, StringComparison.InvariantCultureIgnoreCase)>=0;
            }
        }
    }
}