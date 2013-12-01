#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：zhangnx 时间：2013/8/9 15:34:40
// 文件名：QueryInterface
// 版本：V1.0.0
//
// 修改者： 时间： 
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Reflection;
using System.Text;
using BaseCodeTools.AutoGenerate.PropertyCode;

namespace BaseCodeTools.AutoGenerate.ClassCode
{
    public class ServiceContractInterface : BaseClassCode
    {
        public override string GetClassName(string modelName)
        {
            return "I" +　modelName + "Service";
        }

        protected override void AddClassHeader(Type m, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// 表示与" + m.Name + "相关的应用层服务契约。");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"[ServiceContract(Namespace =" + "\"http://www.UniCloud.com\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"public interface " + GetClassName(m.Name));
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"{");
        }

        protected override void AddClassContent(Type m, StringBuilder sb)
        {
            //create
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 创建" + m.Name + "。");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" +
                          "\"" + GeneratorHelper.LowercaseFirst(m.Name) + "s\">需要创建的" + m.Name + "。</param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns>创建的" + m.Name + "。</returns>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[OperationContract(Action =" + "\"http://www.UniCloud.com/I"
                                                 + GeneratorHelper.GetServiceName("Project") + "Service/Create" + m.Name + "s\", ReplyAction =" + "\"http://www.UniCloud.com/I" + GeneratorHelper.GetServiceName("Project") + "Service/Create" + m.Name + "sResponse\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[FaultContract(typeof(FaultData),Name =" + "\"FaultData\", Action=" + "\"http://www.UniCloud.com/I" + GeneratorHelper.GetServiceName("Project") + "Service/Create" + m.Name + "sDataFault\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[Caching(CachingMethod.Remove, " + "\"Get" + m.Name +
                          "s\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) +
                          @"" + m.Name + "DataObjectList Create" + m.Name + "s(" + m.Name + "DataObjectList " +
                          GeneratorHelper.LowercaseFirst(m.Name) + "s);");
            //delete
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 删除" + m.Name + "信息。");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" +
                          "\"" + GeneratorHelper.LowercaseFirst(m.Name) + "IDs\">需要更新的" + m.Name + "信息的ID值。</param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[OperationContract(Action =" + "\"http://www.UniCloud.com/I"
                                                            + GeneratorHelper.GetServiceName("Project") + "Service/Delete" + m.Name + "s\", ReplyAction =" + "\"http://www.UniCloud.com/I" + GeneratorHelper.GetServiceName("Project") + "Service/Delete" + m.Name + "sResponse\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[FaultContract(typeof(FaultData),Name =" + "\"FaultData\", Action=" + "\"http://www.UniCloud.com/I" + GeneratorHelper.GetServiceName("Project") + "Service/Delete" + m.Name + "sDataFault\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[Caching(CachingMethod.Remove, " +
                          "\"Get" + m.Name + "s\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"IDList Delete" + m.Name + "s(IDList " +
                          GeneratorHelper.LowercaseFirst(m.Name) + "IDs);");
            //update
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 更新" + m.Name + "信息。");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" +
                          "\"" + GeneratorHelper.LowercaseFirst(m.Name) + "s\">需要更新的" + m.Name + "信息。</param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[OperationContract(Action =" + "\"http://www.UniCloud.com/I"
                                                            + GeneratorHelper.GetServiceName("Project") + "Service/Update" + m.Name + "s\", ReplyAction =" + "\"http://www.UniCloud.com/I" + GeneratorHelper.GetServiceName("Project") + "Service/Update" + m.Name + "sResponse\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[FaultContract(typeof(FaultData),Name =" + "\"FaultData\", Action=" + "\"http://www.UniCloud.com/I" + GeneratorHelper.GetServiceName("Project") + "Service/Update" + m.Name + "sDataFault\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[Caching(CachingMethod.Remove, " +
                          "\"Get" + m.Name + "s\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) +
                          @"" + m.Name + "DataObjectList Update" + m.Name + "s(" + m.Name + "DataObjectList " +
                          GeneratorHelper.LowercaseFirst(m.Name) + "s);");
            //commit
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 提交" + m.Name + "的增删改数据");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"" +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Data\"></param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns>提交成功的数据</returns>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[OperationContract(Action =" + "\"http://www.UniCloud.com/I"
                                                            + GeneratorHelper.GetServiceName("Project") + "Service/Commit" + m.Name + "s\", ReplyAction =" + "\"http://www.UniCloud.com/I" + GeneratorHelper.GetServiceName("Project") + "Service/Commit" + m.Name + "sResponse\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[FaultContract(typeof(FaultData),Name =" + "\"FaultData\", Action=" + "\"http://www.UniCloud.com/I" + GeneratorHelper.GetServiceName("Project") + "Service/Commit" + m.Name + "sDataFault\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[Caching(CachingMethod.Remove, " +
                          "\"Get" + m.Name + "s\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) +
                          @"" + m.Name + "ResultData Commit" + m.Name + "s(" + m.Name + "ResultData " +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Data);");

            //GetByID Add By gyoung
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 通过" + m.Name + "Id获取相应的" + m.Name + " 带导航属性");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"id\"></param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns></returns>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[OperationContract(Action =" + "\"http://www.UniCloud.com/I"
                                                            + GeneratorHelper.GetServiceName("Project") + "Service/GetFull" + m.Name + "ByID\", ReplyAction =" + "\"http://www.UniCloud.com/I" + GeneratorHelper.GetServiceName("Project") + "Service/GetFull" + m.Name + "ByIDResponse\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[FaultContract(typeof(FaultData),Name =" + "\"FaultData\",Namespace=" + "\"http://schemas.datacontract.org/2004/07/UniCloud.DataObjects\" ,Action=" + "\"http://www.UniCloud.com/I" + GeneratorHelper.GetServiceName("Project") + "Service/GetFull" + m.Name + "ByIDDataFault\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) +
                          @"" + m.Name + "DataObject GetFull" + m.Name + "ByID(int id);");

            //GetAll Add by gyoung
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 获取所有" + m.Name + " 带导航属性");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns>所有的" + m.Name + "。</returns>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[OperationContract(Action =" + "\"http://www.UniCloud.com/I"
                                                            + GeneratorHelper.GetServiceName("Project") + "Service/GetFull" + m.Name + "s\", ReplyAction =" + "\"http://www.UniCloud.com/I" + GeneratorHelper.GetServiceName("Project") + "Service/GetFull" + m.Name + "sResponse\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[FaultContract(typeof(FaultData),Name =" + "\"FaultData\", Action=" + "\"http://www.UniCloud.com/I" + GeneratorHelper.GetServiceName("Project") + "Service/GetFull" + m.Name + "sDataFault\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"" + m.Name + "DataObjectList GetFull" + m.Name + "s();");

        }

        protected override void AddClassFooter(Type m, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"}");
        }
    }
}