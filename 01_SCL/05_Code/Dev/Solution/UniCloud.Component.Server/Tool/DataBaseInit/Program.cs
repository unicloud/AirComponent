using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataBaseInit
{
    static class Program
    {
        private static readonly string AssemblyPath =
            @"F:\work\Configuration\01_SCL\05_Code\Dev\Solution\UniCloud.Component.Server\Domain\UniCloud.Domain.Component\bin\Debug\UniCloud.Domain.Component.dll";
        static void Main(string[] args)
        {
            GenerateMap();
        }

        #region 生成Oracle SQL
        /// <summary>
        /// 生成SQL的方法
        /// </summary>
        static void GenerateOracleSql()
        {
            string schemal = "UC_AMD";
            Assembly ase = Assembly.LoadFrom(AssemblyPath);
            Type[] types = ase.GetTypes();

            //创建表
            StringBuilder tableBuilder = new StringBuilder();
            tableBuilder.AppendLine("-- --------------------------------------------------");
            tableBuilder.AppendLine("--Creating all tables");
            tableBuilder.AppendLine("-- --------------------------------------------------");
            tableBuilder.AppendLine();

            //创建主键
            StringBuilder pkBuilder = new StringBuilder();
            pkBuilder.AppendLine("-- --------------------------------------------------");
            pkBuilder.AppendLine("-- Creating all PRIMARY KEY constraints");
            pkBuilder.AppendLine("-- --------------------------------------------------");
            pkBuilder.AppendLine();

            //创建外键
            StringBuilder fkbuilder = new StringBuilder();
            fkbuilder.AppendLine("-- --------------------------------------------------");
            fkbuilder.AppendLine("-- Creating all FOREIGN KEY constraints");
            fkbuilder.AppendLine("-- --------------------------------------------------");
            fkbuilder.AppendLine();

            //创建Sequence
            StringBuilder seqBuilder = new StringBuilder();
            seqBuilder.AppendLine("-- --------------------------------------------------");
            seqBuilder.AppendLine("-- Creating all Sequence");
            seqBuilder.AppendLine("-- --------------------------------------------------");
            seqBuilder.AppendLine();

            //创建trigger
            StringBuilder triggerBuilder = new StringBuilder();
            triggerBuilder.AppendLine("-- --------------------------------------------------");
            triggerBuilder.AppendLine("-- Creating all Trigger");
            triggerBuilder.AppendLine("-- --------------------------------------------------");
            triggerBuilder.AppendLine();

            if (types.Count() > 0)
            {
                foreach (var tp in types)
                {
                    if (tp.Name == "DerivedParameter")
                    {
                    }

                    if ((tp.Name.StartsWith("I") && tp.BaseType == null) || tp.Name == "Entity")
                        continue;
                    if (tp.BaseType.Name.ToLower() != "intaggregateroot" && tp.BaseType.Name.ToLower() != "intentity")
                    {
                        continue;
                    }
                    //创建表
                    tableBuilder.AppendLine("-- Creating table '" + tp.Name.SplitWord() + "'");
                    tableBuilder.AppendLine("CREATE TABLE \"" + schemal + "\".\"" + tp.Name.SplitWord().ToUpper() + "\" (");

                    //创建sequence
                    seqBuilder.AppendLine("-- Creating sequence  '" + tp.Name.SplitWord() + "'");
                    seqBuilder.AppendLine("CREATE sequence \"" + schemal + "\".\"SEQ_" + tp.Name.SplitWord().ToUpper() + "\" ");
                    seqBuilder.AppendLine("minvalue 1");
                    seqBuilder.AppendLine("maxvalue 9999999999");
                    seqBuilder.AppendLine("start with 1");
                    seqBuilder.AppendLine("increment by 1;");
                    seqBuilder.AppendLine();

                    //创建trigger
                    triggerBuilder.AppendLine("-- Creating trigger  for  '" + tp.Name.SplitWord() + "'");
                    triggerBuilder.AppendLine("CREATE Trigger \"" + schemal + "\".\"TRG_" + tp.Name.SplitWord().ToUpper() + "\" ");
                    triggerBuilder.AppendLine("before insert on \"" + schemal + "\".\"" + tp.Name.SplitWord().ToUpper() + "\"");
                    triggerBuilder.AppendLine("for each row");
                    triggerBuilder.AppendLine("begin");
                    triggerBuilder.AppendLine("select \"" + schemal + "\".\"SEQ_" + tp.Name.SplitWord().ToUpper() + "\".nextval into:new.id from dual;");
                    triggerBuilder.AppendLine("end;");
                    triggerBuilder.AppendLine();


                    PropertyInfo[] propertyInfos = tp.GetProperties();
                    foreach (var p in propertyInfos)
                    {
                        if (p.PropertyType.Name.StartsWith("ICollection") || p.Name == "UncommittedEvents")
                            continue;
                        //外键关联，如果不是系统类型，则认为是有一个导航属性
                        if (!p.PropertyType.FullName.StartsWith("System"))
                        {
                            if (p.PropertyType.Name.ToUpper() == "INTUNIT")
                            {
                            }
                            fkbuilder.AppendLine();
                            fkbuilder.AppendLine("--Create Foreign Key on table " + tp.Name.SplitWord());
                            fkbuilder.AppendLine("ALTER TABLE \"" + schemal + "\".\"" + tp.Name.SplitWord().ToUpper() + "\"");
                            //因为oracle名字不能超过30个字符，所以如果大于30则截断
                            string constraintName = tp.Name.ToUpper() + "_" + p.PropertyType.Name.ToUpper();
                            if (constraintName.Length > 24)
                            {
                                constraintName = constraintName.Substring(0, 24);
                            }
                            fkbuilder.AppendLine("ADD CONSTRAINT FK_" + constraintName);
                            fkbuilder.AppendLine("FOREIGN KEY (\"" + p.PropertyType.Name.SplitWord().ToUpper() + "ID\") ");
                            fkbuilder.AppendLine("REFERENCES \"" + schemal + "\".\"" + p.PropertyType.Name.SplitWord().ToUpper() + "\"");
                            fkbuilder.AppendLine("(\"ID\")");
                            fkbuilder.AppendLine("ENABLE");
                            fkbuilder.AppendLine("VALIDATE;");
                            fkbuilder.AppendLine();
                            fkbuilder.AppendLine("-- Creating index for FOREIGN KEY ");

                            fkbuilder.AppendLine("CREATE INDEX \"IX_FK_" + constraintName + "\"");
                            fkbuilder.AppendLine("ON  \"" + schemal + "\".\"" + tp.Name.SplitWord().ToUpper() + "\"");
                            //("AcTypeID");
                            fkbuilder.AppendLine("(\"" + p.PropertyType.Name.SplitWord().ToUpper() + "ID\");");
                            fkbuilder.AppendLine();
                            continue;
                        }
                        if (p.Name.ToLower().EndsWith("id"))
                        {
                            if (p.PropertyType.Name.StartsWith("Nullable"))
                            {
                                var bp = p.PropertyType.GenericTypeArguments[0].Name;
                                tableBuilder.AppendLine("\"" + p.Name.SplitWord().ToUpper() + "\" " + GetSqlType(bp) + " NULL,");
                            }
                            else
                            {
                                tableBuilder.AppendLine("\"" + p.Name.SplitWord().ToUpper() + "\" " + GetSqlType(p.PropertyType.Name) + " NOT NULL,");
                            }
                        }
                        else
                        {
                            //处理可空类型
                            if (p.PropertyType.Name.StartsWith("Nullable"))
                            {
                                var bp = p.PropertyType.GenericTypeArguments[0].Name;
                                tableBuilder.AppendLine("\"" + p.Name.SplitWord().ToUpper() + "\" " + GetSqlType(bp) + " NULL,");
                            }
                            else
                            {
                                tableBuilder.AppendLine("\"" + p.Name.SplitWord().ToUpper() + "\" " + GetSqlType(p.PropertyType.Name) + " NULL,");
                            }
                        }

                    }
                    tableBuilder = tableBuilder.Remove(tableBuilder.Length - 3, 1);
                    tableBuilder.AppendLine(");");
                    tableBuilder.AppendLine();

                    //创建主键
                    pkBuilder.AppendLine("-- Creating primary key on \"ID\"in table '" + tp.Name + "'");
                    pkBuilder.AppendLine("ALTER TABLE \"" + schemal + "\".\"" + tp.Name.SplitWord().ToUpper() + "\"");
                    pkBuilder.AppendLine("ADD CONSTRAINT \"PK_" + tp.Name.ToUpper() + "\"");
                    pkBuilder.AppendLine(" PRIMARY KEY (\"ID\" )");
                    pkBuilder.AppendLine("ENABLE");
                    pkBuilder.AppendLine("VALIDATE;");
                    pkBuilder.AppendLine();
                }

            }
            using (StreamWriter sw = new StreamWriter("Table.txt", true))
            {
                sw.Write(tableBuilder.ToString());
            }
            using (StreamWriter sw = new StreamWriter("PK.txt", true))
            {
                sw.Write(pkBuilder.ToString());
            }
            using (StreamWriter sw = new StreamWriter("FK.txt", true))
            {
                sw.Write(fkbuilder.ToString());
            }
            using (StreamWriter sw = new StreamWriter("Sequence.txt", true))
            {
                sw.Write(seqBuilder.ToString());
            }
            using (StreamWriter sw = new StreamWriter("Trigger.txt", true))
            {
                sw.Write(triggerBuilder.ToString());
            }
        
        }

        /// <summary>
        /// 返回.NET类型对应的Oralce类型
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        static string GetSqlType(string typeName)
        {
            string tp = string.Empty;
            switch (typeName)
            {
                case "Int32": tp = "NUMBER(9,0)"; break;
                case "String": tp = "NVARCHAR2(100)"; break;
                case "Decimal": tp = "NUMBER(38,4)"; break;
                case "Double": tp = "NUMBER(38,4)"; break;
                case "Float": tp = "NUMBER(38,4)"; break;
                case "DateTime": tp = "DATE"; break;
                case "Boolean": tp = "NUMBER(1,0)"; break;
                case "Char": tp = "NVARCHAR2(10)"; break;
                case "Guid": tp = "RAW(16)"; break;
                default: tp = "NVARCHAR2(100)"; break;
            }
            return tp;
        }

        /// <summary>
        /// 分割复合类型的英文名，如OrderDetail
        /// 分割成Order_Detail
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        static string SplitWord(this string word)
        {
            string fw = string.Empty;
            char[] cs = word.ToCharArray();
            Regex r2 = new Regex("[A-Z]");
            List<int> indexs = new List<int>();
            for (int i = 1; i < cs.Length; i++)
            {
                bool f = r2.IsMatch(cs[i].ToString());
                if (f)
                {
                    //最后有大于两个字母在分词
                    if (cs.Length - i > 2)
                    {
                        indexs.Add(i);
                    }
                }
            }

            int start = 0;
            for (int i = 0; i < indexs.Count; i++)
            {
                int length = indexs[i] - start;
                fw += word.Substring(start, length) + "_";
                start = indexs[i];
            }

            fw += word.Substring(start, word.Length - start);
            return fw;
        }
        #endregion

        static void GenerateInterface()
        {
            Assembly ase = Assembly.LoadFrom(AssemblyPath);
            Type[] types = ase.GetTypes();
            StringBuilder interfaceBuilder = new StringBuilder();
            StringBuilder implementationBuilder=new StringBuilder();
            foreach (var tp in types)
            {
                if ((tp.Name.StartsWith("I") && tp.BaseType == null) || tp.Name == "Entity")
                    continue;
                if (tp.BaseType != null && tp.BaseType.Name.ToLower() != "intaggregateroot" &&
                    tp.BaseType.Name.ToLower() != "intentity")
                    continue;
                string name = tp.Name.ToLower().Substring(0, 1) + tp.Name.Substring(1, tp.Name.Length - 1);
                interfaceBuilder.AppendLine("#region " + tp.Name);
                interfaceBuilder.AppendLine("/// <summary>");
                interfaceBuilder.AppendLine("/// 添加" + tp.Name);
                interfaceBuilder.AppendLine("/// </summary>");
                interfaceBuilder.AppendLine("/// <param name=\"" + name + "s\"></param>");
                interfaceBuilder.AppendLine("/// <returns></returns>");
                interfaceBuilder.AppendLine("[OperationContract]");
                interfaceBuilder.AppendLine("[FaultContract(typeof (FaultData))]");
                interfaceBuilder.AppendLine(tp.Name + "DataObjectList Add" + tp.Name + "(" + tp.Name + "DataObjectList " +
                                            name + "s);");
                interfaceBuilder.AppendLine();


                interfaceBuilder.AppendLine("/// <summary>");
                interfaceBuilder.AppendLine("/// 删除" + tp.Name);
                interfaceBuilder.AppendLine("/// </summary>");
                interfaceBuilder.AppendLine("/// <param name=\"" + name + "Ids\"></param>");
                interfaceBuilder.AppendLine("[OperationContract]");
                interfaceBuilder.AppendLine("[FaultContract(typeof (FaultData))]");
                interfaceBuilder.AppendLine("void Delete" + tp.Name + "(IDList " +
                                            name + "Ids);");
                interfaceBuilder.AppendLine();

                interfaceBuilder.AppendLine("/// <summary>");
                interfaceBuilder.AppendLine("/// 更新" + tp.Name);
                interfaceBuilder.AppendLine("/// </summary>");
                interfaceBuilder.AppendLine("/// <param name=\"" + name + "s\"></param>");
                interfaceBuilder.AppendLine("/// <returns></returns>");
                interfaceBuilder.AppendLine("[OperationContract]");
                interfaceBuilder.AppendLine("[FaultContract(typeof (FaultData))]");
                interfaceBuilder.AppendLine(tp.Name + "DataObjectList Update" + tp.Name + "(" + tp.Name + "DataObjectList " +
                                            name + "s);");
                interfaceBuilder.AppendLine();

                interfaceBuilder.AppendLine("/// <summary>");
                interfaceBuilder.AppendLine("/// 获取所有" + tp.Name);
                interfaceBuilder.AppendLine("/// </summary>");
                interfaceBuilder.AppendLine("/// <returns></returns>");
                interfaceBuilder.AppendLine("[OperationContract]");
                interfaceBuilder.AppendLine("[FaultContract(typeof (FaultData))]");
                interfaceBuilder.AppendLine(tp.Name + "DataObjectList GetAll" + tp.Name + "s();");
                interfaceBuilder.AppendLine();

                interfaceBuilder.AppendLine("/// <summary>");
                interfaceBuilder.AppendLine("/// 通过ID获取" + tp.Name);
                interfaceBuilder.AppendLine("/// </summary>");
                interfaceBuilder.AppendLine("/// <param name=\"" + name + "Id\"></param>");
                interfaceBuilder.AppendLine("/// <returns></returns>");
                interfaceBuilder.AppendLine("[OperationContract]");
                interfaceBuilder.AppendLine("[FaultContract(typeof (FaultData))]");
                interfaceBuilder.AppendLine(tp.Name + "DataObject Get" + tp.Name + "(int " + name + "Id);");
                interfaceBuilder.AppendLine();
                interfaceBuilder.AppendLine("#endregion");
                interfaceBuilder.AppendLine();

                implementationBuilder.AppendLine("#region " + tp.Name);
                implementationBuilder.AppendLine("/// <summary>");
                implementationBuilder.AppendLine("/// 添加" + tp.Name);
                implementationBuilder.AppendLine("/// </summary>");
                implementationBuilder.AppendLine("/// <param name=\"" + name + "s\"></param>");
                implementationBuilder.AppendLine("/// <returns></returns>");
                implementationBuilder.AppendLine("public " + tp.Name + "DataObjectList Add" + tp.Name + "(" + tp.Name + "DataObjectList " +
                                            name + "s)");
                implementationBuilder.AppendLine("{");
                implementationBuilder.AppendLine("throw new NotImplementedException();");
                implementationBuilder.AppendLine("}");
                implementationBuilder.AppendLine();

                implementationBuilder.AppendLine("/// <summary>");
                implementationBuilder.AppendLine("/// 删除" + tp.Name);
                implementationBuilder.AppendLine("/// </summary>");
                implementationBuilder.AppendLine("/// <param name=\"" + name + "Ids\"></param>");
                implementationBuilder.AppendLine("public void Delete" + tp.Name + "(IDList " +
                                            name + "Ids)");
                implementationBuilder.AppendLine("{");
                implementationBuilder.AppendLine("throw new NotImplementedException();");
                implementationBuilder.AppendLine("}");
                implementationBuilder.AppendLine();

                implementationBuilder.AppendLine("/// <summary>");
                implementationBuilder.AppendLine("/// 更新" + tp.Name);
                implementationBuilder.AppendLine("/// </summary>");
                implementationBuilder.AppendLine("/// <param name=\"" + name + "s\"></param>");
                implementationBuilder.AppendLine("/// <returns></returns>");
                implementationBuilder.AppendLine("public "+tp.Name + "DataObjectList Update" + tp.Name + "(" + tp.Name + "DataObjectList " +
                                            name + "s)");
                implementationBuilder.AppendLine("{");
                implementationBuilder.AppendLine("throw new NotImplementedException();");
                implementationBuilder.AppendLine("}");
                implementationBuilder.AppendLine();

                implementationBuilder.AppendLine("/// <summary>");
                implementationBuilder.AppendLine("/// 获取所有" + tp.Name);
                implementationBuilder.AppendLine("/// </summary>");
                implementationBuilder.AppendLine("/// <returns></returns>");
                implementationBuilder.AppendLine("public " + tp.Name + "DataObjectList GetAll" + tp.Name + "s()");
                implementationBuilder.AppendLine("{");
                implementationBuilder.AppendLine("throw new NotImplementedException();");
                implementationBuilder.AppendLine("}");
                implementationBuilder.AppendLine();

                implementationBuilder.AppendLine("/// <summary>");
                implementationBuilder.AppendLine("/// 通过ID获取" + tp.Name);
                implementationBuilder.AppendLine("/// </summary>");
                implementationBuilder.AppendLine("/// <param name=\"" + name + "Id\"></param>");
                implementationBuilder.AppendLine("/// <returns></returns>");
                implementationBuilder.AppendLine("public " + tp.Name + "DataObject Get" + tp.Name + "(int " + name + "Id)");
                implementationBuilder.AppendLine("{");
                implementationBuilder.AppendLine("throw new NotImplementedException();");
                implementationBuilder.AppendLine("}");
                implementationBuilder.AppendLine("#endregion");
                implementationBuilder.AppendLine();
            }

            using (StreamWriter sw = new StreamWriter("Interface.txt", false))
            {
                sw.Write(interfaceBuilder.ToString());
            }

            using (var sw = new StreamWriter("Implementation.txt", false))
            {
                sw.Write(implementationBuilder.ToString());
            }
        }

        static void GenerateMap()
        {
            Assembly ase = Assembly.LoadFrom(AssemblyPath);
            Type[] types = ase.GetTypes();
            StringBuilder mapStringBuilder=new StringBuilder();
            foreach (var type in types)
            {
                if ((type.Name.StartsWith("I") && type.BaseType == null) || type.Name == "Entity")
                    continue;
                if (type.BaseType != null && type.BaseType.Name.ToLower() != "intaggregateroot" &&
                    type.BaseType.Name.ToLower() != "intentity")
                    continue;
                mapStringBuilder.AppendLine("Mapper.CreateMap<" + type.Name + "," + type.Name + "DataObject>();");
                mapStringBuilder.AppendLine("Mapper.CreateMap<" + type.Name + "DataObject," + type.Name + ">();");
            }
            using (var sw = new StreamWriter("map.txt", false))
            {
                sw.Write(mapStringBuilder.ToString());
            }
        }
    }
}
