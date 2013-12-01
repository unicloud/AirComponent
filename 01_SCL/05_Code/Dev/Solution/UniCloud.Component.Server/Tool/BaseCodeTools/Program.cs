using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BaseCodeTools.AutoGenerate.Generator;


namespace BaseCodeTools
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var generators = new GeneratorContainer();
			
			generators.GeneratorAllFile();
        }


        //生成模型到数据库的映射文件(configuration文件)
        private static void GenerateConfigureFile()
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

                    sb.AppendLine(@"// 文件名：" + m.Name + "Configuration");
                    sb.AppendLine(@"// 版本：V1.0.0
//
// 修改者： 时间： 
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Model;
");
                    sb.AppendLine(
                        @"namespace UniCloud.Domain.Repositories.EntityFramework.ModelConfigurations.SqlServer
{");
                    sb.AppendLine(@"public class " + m.Name + "Configuration :EntityTypeConfiguration<" + m.Name +
                                  ">{");
                    sb.AppendLine(@"public " + m.Name + "Configuration(){");
                    sb.AppendLine(@"HasKey(k => k.ID);");
                    sb.AppendLine("Property(p => p.ID).HasColumnName(\"" + m.Name +
                                  "ID\").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);");
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
                                            sb.AppendLine("Property(p => p." + p.Name +
                                                          ").HasColumnType(\"datetime2\");");
                                        else if (p.PropertyType.Name == "String")
                                            sb.AppendLine("Property(p => p." + p.Name + ").HasMaxLength(100);");
                                        else if (p.PropertyType.Name == "xml")
                                            sb.AppendLine("Property(p => p." + p.Name + ").HasColumnType(\"xml\");");
                                        //else
                                        //    sb.AppendLine("Property(p => p." + p.Name + ");");
                                    }
                                }
                            });
                    }
                    sb.AppendLine("ToTable(\"" + m.Name + "\", DefineTableSchema.Schema );");
                    sb.AppendLine("}");
                    sb.AppendLine("}");
                    sb.AppendLine("}");
                    File.WriteAllText("E:\\Configurations\\" + m.Name + "Configuration.cs", sb.ToString(),
                                      UTF8Encoding.UTF8);
                }
                );
        }



        //生成AFRP到UniCloud.FRP数据迁移脚本
        private static void GenerateDataMigrationFile()
        {
            //根据本地具体的UniCloud.Domain.dll所在路径设置
            Assembly ase =
                Assembly.LoadFrom(
                    @"..\..\Domain\UniCloud.Domain\bin\Debug\UniCloud.Domain.FRP.dll");

            Type[] types = ase.GetTypes();
            //获取模块数目，遍历各个类，去生成对应的数据库迁移脚本，各个脚本都还需要进行校验
            types.Where(t => !t.Name.StartsWith("I")).ToList().ForEach(
                m =>
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(@"use master");
                    PropertyInfo[] propertyInfos = m.GetProperties();
                    List<string> propertyNames = new List<string>();

                    #region declareParts

                    if (propertyInfos.Any())
                    {
                        propertyInfos.ToList().ForEach(p =>
                            {
                                if (!p.PropertyType.Name.StartsWith("ICollection") && p.Name != "UncommittedEvents")
                                {
                                    if (p.Name == "ID")
                                    {
                                        sb.AppendLine("declare @" + m.Name + "ID uniqueidentifier;");
                                        propertyNames.Add(m.Name + "ID");
                                    }
                                    else
                                    {
                                        if (p.PropertyType.Name == "Guid")
                                        {
                                            sb.AppendLine("declare @" + p.Name + " uniqueidentifier;");
                                        }
                                        else if (p.PropertyType.Name == "DateTime")
                                        {
                                            sb.AppendLine("declare @" + p.Name + " datetime2;");
                                        }
                                        else if (p.PropertyType.Name == "String")
                                        {
                                            sb.AppendLine("declare @" + p.Name + " nvarchar(255);");
                                        }
                                        else if (p.PropertyType.Name == "Integer")
                                        {
                                            sb.AppendLine("declare @" + p.Name + " int;");
                                        }
                                        else if (p.PropertyType.Name == "Boolean")
                                        {
                                            sb.AppendLine("declare @" + p.Name + " bit;");
                                        }
                                        else if (p.PropertyType.Name == "Decimal")
                                        {
                                            sb.AppendLine("declare @" + p.Name + " decimal;");
                                        }
                                        else
                                        {
                                            sb.AppendLine("declare @" + p.Name + " ;");
                                        }
                                        propertyNames.Add(p.Name);
                                    }
                                }
                            });
                    }

                    #endregion

                    sb.AppendLine("--遍历AFRP中的" + m.Name + "表格" + System.Environment.NewLine +
                                  "declare Current" + m.Name + " CURSOR FOR" + System.Environment.NewLine +
                                  "Select " + m.Name + "ID from AFRP.Fleet." + m.Name + System.Environment.NewLine +
                                  "open Current" + m.Name + System.Environment.NewLine +
                                  "fetch next from Current" + m.Name + " into @" + m.Name + "ID" +
                                  System.Environment.NewLine +
                                  "while @@FETCH_STATUS=0 " + System.Environment.NewLine +
                                  " Begin" + System.Environment.NewLine);

                    string slectSentence = null;
                    string insertSentence1 = null;
                    string insertSentence2 = null;
                    foreach (string a in propertyNames)
                    {
                        string b = "@" + a + "=" + a + ",";
                        slectSentence += b;
                        insertSentence1 += a + ",";
                        insertSentence2 += "@" + a + ",";
                    }
                    sb.AppendLine("select " + slectSentence + System.Environment.NewLine +
                                  "from AFRP.Fleet." + m.Name + " where " + m.Name + "ID=@" + m.Name + "ID");
                    sb.AppendLine("if(not exists (Select " + m.Name + "ID from [UniCloud.FRP].FRP." + m.Name +
                                  " where " + m.Name + "ID=@" + m.Name + "ID))" + System.Environment.NewLine +
                                  "begin" + System.Environment.NewLine +
                                  "insert [UniCloud.FRP].FRP." + m.Name + " (" + insertSentence1 + ")" +
                                  System.Environment.NewLine +
                                  " values (" + insertSentence2 + ")" + System.Environment.NewLine +
                                  "end" + System.Environment.NewLine
                        );
                    sb.AppendLine("fetch next from Current" + m.Name + " into @" + m.Name + "ID" +
                                  System.Environment.NewLine +
                                  "End" + System.Environment.NewLine +
                                  "close Current" + m.Name + System.Environment.NewLine +
                                  "deallocate Current" + m.Name + System.Environment.NewLine
                        );
                    File.WriteAllText("E:\\MigrationsSQL\\" + m.Name + "迁移.sql", sb.ToString());
                }
                );
        }

        //从模型生成DTO文件
        private static void CreatDataObjectFiles()
        {
            Assembly ase =
                Assembly.LoadFrom(
                    @"D:\ProgramCODE\FOCCollection\FRP\SiChuanAir\01_SCL\05_Code\Dev\Solution\UniCloud.FRP.Server\Domain\UniCloud.Domain\bin\Debug\UniCloud.Domain.FRP.dll");

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


        //从Unicloud.FRP.Models.dll生成相应的仓储实现文件RepositoryAndIRepository
        private static void CreatRepositoryFiels()
        {
            Assembly ase =
                Assembly.LoadFrom(
                    @"D..\..\Domain\UniCloud.Domain\bin\Debug\UniCloud.Domain.FRP.dll");

            Type[] types = ase.GetTypes();
            //获取模块数目
            types.Where(p => p.BaseType != null && p.BaseType.Name != "GuidEntity").ToList().ForEach(
                m =>
                {
                    StringBuilder repositoryf = new StringBuilder();
                    StringBuilder irepositoryf = new StringBuilder();
                    DateTime dateTime = new DateTime();
                    dateTime = DateTime.Now;
                    repositoryf.AppendLine(@"#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：huangqb 时间：" + dateTime);

                    repositoryf.AppendLine(@"// 文件名：" + m.Name + "Repository");
                    repositoryf.AppendLine(@"// 版本：V1.0.0
//
// 修改者： 时间： 
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UniCloud.Domain.Model;
using UniCloud.Domain.Repositories.EntityFramework;

namespace UniCloud.Domain.Repositories.Plan
{
	/// <summary>
	///     
	/// </summary>
	public class " + m.Name + "Repository : EntityFrameworkGuidRepository<" + m.Name + ">, I" + m.Name + "Repository");
                    repositoryf.AppendLine(@"{
		private readonly UniCloudDbContextFRP _efContext;

		public " + m.Name + "Repository(IRepositoryContext context) : base(context)");

                    repositoryf.AppendLine(@"{
			_efContext = EFContext.Context as UniCloudDbContextFRP;
		}
}
}");

                    irepositoryf.AppendLine(@"#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：huangqb 时间：" + dateTime);

                    irepositoryf.AppendLine(@"// 文件名：I" + m.Name + "Repository");
                    irepositoryf.AppendLine(@"// 版本：V1.0.0
//
// 修改者： 时间： 
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Collections.Generic;
using UniCloud.Domain.Model;

namespace UniCloud.Domain.Repositories.Plan
{
    /// <summary>
    /// 
    /// </summary>
    public interface I" + m.Name + "Repository : IRepository<" + m.Name + ">");
                    irepositoryf.AppendLine(@"{
}
}");
                    File.WriteAllText("E:\\RepositoryFiles\\" + m.Name + "Repository.cs", repositoryf.ToString(),
                                      UTF8Encoding.UTF8);
                    File.WriteAllText("E:\\IRepositoryFiles\\I" + m.Name + "Repository.cs", irepositoryf.ToString(),
                                      UTF8Encoding.UTF8);
                }
                );
        }

    }
}