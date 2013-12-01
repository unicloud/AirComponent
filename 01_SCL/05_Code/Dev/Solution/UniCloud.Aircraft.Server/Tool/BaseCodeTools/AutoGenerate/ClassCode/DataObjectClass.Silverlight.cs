#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：zhangnx 时间：2013/8/9 15:34:40
// 文件名：DataObjectClassSilverlight
// 版本：V1.0.0
//
// 修改者： 时间： 
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Linq;
using System.Reflection;
using System.Text;
using BaseCodeTools;
using BaseCodeTools.AutoGenerate.PropertyCode;

namespace BaseCodeTools.AutoGenerate.ClassCode
{
    public class DataObjectClassSilverlight : BaseClassCode
    {
        public override string GetClassName(string modelName)
        {
            return modelName + "DataObject";
        }

        protected override void AddClassHeader(Type m, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"///"+ m.Name + "DataObject");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"[System.Diagnostics.DebuggerStepThroughAttribute()]");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"[System.CodeDom.Compiler.GeneratedCodeAttribute(" + "\"System.Runtime.Serialization\", \"4.0.0.0\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + "[DataContractAttribute(Name = \"" + m.Name + "DataObject\", IsReference = false, Namespace = \""+"http://schemas.datacontract.org/2004/07/UniCloud.DataObjects"+"\""+")]");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"public partial class " + m.Name + "DataObject : " + GetBaseTypeName(m));
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"{");
        }

        private string GetBaseTypeName(Type m)
        {
            var baseType = m.BaseType;
            if (baseType != null)
            {
                if (!(baseType.Name.IndexOf("AggregateRoot", StringComparison.CurrentCultureIgnoreCase) > 0 ||
                    baseType.Name.IndexOf("Entity", StringComparison.CurrentCultureIgnoreCase) > 0))
                {
                    return baseType.Name + "DataObject";
                }
            }
            return "BaseDataObject";
        }

        /// <summary>
        /// 判断是否为属性
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        protected override bool IsValidProperty(PropertyInfo p)
        {
            return p.Name != "UncommittedEvents";
        }

        /// <summary>
        /// 反射，获取属性
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public override PropertyInfo[] GetProperties(Type m)
        {
            if (this.GetBaseTypeName(m).Equals("BaseDataObject", StringComparison.InvariantCultureIgnoreCase))
            {
                return m.GetProperties(BindingFlags.GetProperty | BindingFlags.Instance |
                                       BindingFlags.Public);
            }
            else
            {
                return m.GetProperties(BindingFlags.GetProperty | BindingFlags.Instance |
                                       BindingFlags.Public | BindingFlags.DeclaredOnly);
            }
        }

        private  Type GetDataObjectsType(Type m)
        {
            var ase = GeneratorHelper.GetDataObjectAssembly();
            var types = ase.GetTypes();
            return types.FirstOrDefault(type => type.Name.Equals(m.Name + "DataObject"));
        }

        protected override void AddClassContent(Type m, StringBuilder sb)
        {
            var type = GetDataObjectsType(m);
            PropertyInfo[] propertyInfos;
            if (type != null)
            {
                propertyInfos = GetProperties(type);
            }
            else
            {
                propertyInfos = GetProperties(m); 
            }

            //Private declare
            foreach (var p in propertyInfos)
            {
                if (IsValidProperty(p))
                {
                    var ipc = PropertyCodeContainer.GetInstance().GetProertyCode(GetPropertyTypeName(p));
                    if (ipc == null) 
                        continue;
                    if (!IsID(p))
                    {
                        ipc.DataObjectPrivateDeclare(p, sb);
                    }
                    else
                    {
                        ipc.DataObjectPrivateDeclare(p, sb);
                    }
                }
            }
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"");
            //Property
            foreach (var p in propertyInfos)
            {
                if (IsValidProperty(p))
                {
                    var ipc = PropertyCodeContainer.GetInstance().GetProertyCode(GetPropertyTypeName(p));
                    if (ipc == null) continue;
                    if (!IsID(p))
                    {
                        ipc.DataObjectPropertySilverlight(p, sb);
                    }
                    else
                    {
                        ipc.DataObjectPropertySilverlight(p, sb);
                    }
                }
            }
        }

        protected void AddDataObjectListClass(Type m, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// " + m.Name + "DataObjectList");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"[System.Diagnostics.DebuggerStepThroughAttribute()]");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"[System.CodeDom.Compiler.GeneratedCodeAttribute(" + "\"System.Runtime.Serialization\", \"4.0.0.0\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + "[CollectionDataContractAttribute(Name = \"" + m.Name + "DataObjectList\", ItemName = \"" + m.Name + "DataObject\", Namespace = \""+"http://schemas.datacontract.org/2004/07/UniCloud.DataObjects"+"\""+")]");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"public class " + m.Name + "DataObjectList : BaseDataObjectList<" + m.Name + "DataObject>");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"}");
        }

        protected void AddResultDataClass(Type m, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// " + m.Name + "ResultData");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// </summary>");
			sb.AppendLine(GeneratorHelper.GetTabString(1) + "[DataContractAttribute(Name = \"" + m.Name + "ResultData\", Namespace = \"" + "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" + "\"" + ")]");
			sb.AppendLine(GeneratorHelper.GetTabString(1) + @"[KnownType(typeof(" + m.Name + "ResultData))]");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"public class " + m.Name + "ResultData : ResultData<" + m.Name + "DataObject>");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"}");
        }

        protected void AddPaginationDataClass(Type m, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// " + m.Name + "WithPagination");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + "[DataContractAttribute(Name = \"" + m.Name + "WithPagination\", Namespace = \"" + "http://schemas.datacontract.org/2004/07/UniCloud.DataObjects" + "\"" + ")]");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"[KnownType(typeof(" + m.Name + "WithPagination))]");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"public class " + m.Name + "WithPagination : BaseDataObjectListWithPagination<" + m.Name + "DataObject>");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"}");
        }

        protected override void AddClassFooter(Type m, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"}");
            AddDataObjectListClass(m, sb);
            AddResultDataClass(m, sb);
            AddPaginationDataClass(m, sb);
        }
    }
}
