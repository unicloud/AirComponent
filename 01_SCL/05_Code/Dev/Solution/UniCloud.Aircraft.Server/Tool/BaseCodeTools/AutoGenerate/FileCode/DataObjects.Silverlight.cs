#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：zhangnx 时间：2013/8/9 16:51:56
// 文件名：Class1
// 版本：V1.0.0
//
// 修改者： 时间： 
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BaseCodeTools.AutoGenerate.FileCode
{
    public class DataObjects_Silverlight : BaseAutoGenerate
    {
        //从模型生成DTO文件
        public string GenerateCode()
        {
            Assembly ase =
                Assembly.LoadFrom(
                    @"..\..\Domain\UniCloud.Domain\bin\Debug\UniCloud.Domain.FRP.dll");

            Type[] types = ase.GetTypes();
            //获取模块数目
            types.Where(t => !t.Name.StartsWith("I")).ToList().ForEach(
                m =>
                {
                    DateTime dateTime = new DateTime();
                    dateTime = DateTime.Now;
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(@"#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：huangqb 时间：" + dateTime);

                    sb.AppendLine(@"// 文件名：" + m.Name + "DataObject");
                    sb.AppendLine(@"// 版本：V1.0.0
//
// 修改者： 时间： 
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace UniCloud.DataObjects
{
    /// <summary>
    /// 
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute(" + "\"System.Runtime.Serialization\", \"4.0.0.0\")]");
                    sb.AppendLine(" [DataContractAttribute(Name = \"" + m.Name +
                                  "DataObject\", IsReference = false)]");
                    sb.AppendLine(@"public partial class " + m.Name + "DataObject : BaseDataObject");
                    sb.AppendLine(@"{
                                       private Guid IDField;");
                    PropertyInfo[] propertyInfos = m.GetProperties();
                    if (propertyInfos.Any())
                    {
                        propertyInfos.ToList().ForEach(p =>
                        {
                            if (!p.PropertyType.Name.StartsWith("ICollection") && p.Name != "UncommittedEvents")
                            {
                                if (p.Name == "ID")
                                {

                                }
                                else
                                {
                                    if (p.PropertyType.Name == "DateTime")
                                        sb.AppendLine("private DateTime " + p.Name + "Field;");
                                    else if (p.PropertyType.Name == "String")
                                        sb.AppendLine("private string " + p.Name + "Field;");
                                    else if (p.PropertyType.Name == "Boolean")
                                        sb.AppendLine("private bool " + p.Name + "Field;");
                                    else if (p.PropertyType.Name == "Int32")
                                        sb.AppendLine("private int " + p.Name + "Field;");
                                    else if (p.PropertyType.Name == "Decimal")
                                        sb.AppendLine("private decimal " + p.Name + "Field;");
                                    else if (p.PropertyType.Name == "Byte[]")
                                        sb.AppendLine("private Byte[] " + p.Name + "Field;");
                                    else if (p.PropertyType.Name == "Guid")
                                        sb.AppendLine("private " + p.Name.Substring(0, p.Name.Length - 2) +
                                                      "DataObject " + p.Name.Substring(0, p.Name.Length - 2) +
                                                      "Field;");
                                    else
                                        sb.AppendLine("private DataObjectList " + p.Name + "Field;");
                                }
                            }
                        });

                        sb.AppendLine(@"
[DataMemberAttribute()]
        public Guid ID
        {
            get
            {
                return this.IDField;
            }
            set
            {
                this.IDField = value;
            }
        }
");

                        propertyInfos.ToList().ForEach(p =>
                        {
                            if (!p.PropertyType.Name.StartsWith("ICollection") && p.Name != "UncommittedEvents")
                            {
                                if (p.Name == "ID")
                                {

                                }
                                else
                                {
                                    if (p.PropertyType.Name == "DateTime")
                                    {
                                        sb.AppendLine(@"[DataMemberAttribute()]
        public DateTime " + p.Name);

                                        sb.AppendLine(@"{
            get
            {
                return this." + p.Name + "Field;");
                                        sb.AppendLine(@"}
            set
            {
                this." + p.Name + "Field = value;");
                                        sb.AppendLine(@" }
        }
");
                                    }
                                    else if (p.PropertyType.Name == "String")
                                    {
                                        sb.AppendLine(@"[DataMemberAttribute()]
        public string " + p.Name);

                                        sb.AppendLine(@"{
            get
            {
                return this." + p.Name + "Field;");
                                        sb.AppendLine(@"}
            set
            {
                this." + p.Name + "Field = value;");
                                        sb.AppendLine(@" }
        }
");
                                    }
                                    else if (p.PropertyType.Name == "Boolean")
                                    {
                                        sb.AppendLine(@"[DataMemberAttribute()]
        public bool " + p.Name);

                                        sb.AppendLine(@"{
            get
            {
                return this." + p.Name + "Field;");
                                        sb.AppendLine(@"}
            set
            {
                this." + p.Name + "Field = value;");
                                        sb.AppendLine(@" }
        }
");
                                    }
                                    else if (p.PropertyType.Name == "Int32")
                                    {
                                        sb.AppendLine(@"[DataMemberAttribute()]
        public int " + p.Name);

                                        sb.AppendLine(@"{
            get
            {
                return this." + p.Name + "Field;");
                                        sb.AppendLine(@"}
            set
            {
                this." + p.Name + "Field = value;");
                                        sb.AppendLine(@" }
        }
");
                                    }
                                    else if (p.PropertyType.Name == "Decimal")
                                    {
                                        sb.AppendLine(@"[DataMemberAttribute()]
        public decimal " + p.Name);

                                        sb.AppendLine(@"{
            get
            {
                return this." + p.Name + "Field;");
                                        sb.AppendLine(@"}
            set
            {
                this." + p.Name + "Field = value;");
                                        sb.AppendLine(@" }
        }
");
                                    }
                                    else if (p.PropertyType.Name == "Byte[]")
                                    {
                                        sb.AppendLine(@"[DataMemberAttribute()]
        public Byte[] " + p.Name);

                                        sb.AppendLine(@"{
            get
            {
                return this." + p.Name + "Field;");
                                        sb.AppendLine(@"}
            set
            {
                this." + p.Name + "Field = value;");
                                        sb.AppendLine(@" }
        }
");
                                    }
                                    else if (p.PropertyType.Name == "Guid")
                                    {
                                        sb.AppendLine(@"[DataMemberAttribute()]
        public " + p.Name.Substring(0, p.Name.Length - 2) + "DataObject " + p.Name.Substring(0, p.Name.Length - 2));

                                        sb.AppendLine(@"{
            get
            {
                return this." + p.Name.Substring(0, p.Name.Length - 2) + "Field;");
                                        sb.AppendLine(@"}
            set
            {
                this." + p.Name.Substring(0, p.Name.Length - 2) + "Field = value;");
                                        sb.AppendLine(@" }
        }
");
                                    }
                                    //else
                                    //    sb.AppendLine("private DataObjectList " + p.Name + "Field;");
                                }
                            }
                        });
                    }
                    sb.AppendLine("}");

                    sb.AppendLine(@"
    /// <summary>
    /// 
    /// </summary>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute(" + "\"System.Runtime.Serialization\", \"4.0.0.0\")]");
                    sb.AppendLine("[CollectionDataContractAttribute(Name = \"" + m.Name +
                                  "DataObjectList\", ItemName = \"" + m.Name + "DataObject\")]");
                    sb.AppendLine(@"public class " + m.Name + "DataObjectList : BaseDataObjectList<" + m.Name + "DataObject>");
                    sb.AppendLine(@"{
 }

    [KnownType(typeof(ResultData" + m.Name + "DataObject))]");
                    sb.AppendLine(@"public class ResultData" + m.Name + "DataObject : ResultData<" + m.Name +
                                  "DataObject>");
                    sb.AppendLine(@"{
 }");

                    sb.AppendLine("}");
                    File.WriteAllText("E:\\DataObjects\\" + m.Name + "DataObject.cs", sb.ToString(),
                                      UTF8Encoding.UTF8);
                }
                );
        }

        public override void AutoGenerateCode()
        {
            throw new NotImplementedException();
        }

        protected override string GetFileName(string modelName)
        {
            throw new NotImplementedException();
        }

        protected override string GetFilePath()
        {
            throw new NotImplementedException();
        }
    }
}