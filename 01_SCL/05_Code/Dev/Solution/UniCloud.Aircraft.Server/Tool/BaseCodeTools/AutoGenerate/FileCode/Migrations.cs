#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：zhangnx 时间：2013/8/9 16:35:13
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
    public class Migrations : BaseGenerateCode
    {

        //生成AFRP到UniCloud.FRP数据迁移脚本
        public string GenerateCode()
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
