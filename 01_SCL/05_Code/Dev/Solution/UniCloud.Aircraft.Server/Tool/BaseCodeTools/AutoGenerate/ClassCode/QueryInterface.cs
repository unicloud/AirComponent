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
    public class QueryInterface : BaseClassCode
    {
        public override string GetClassName(string modelName)
        {
            return "I" + modelName + "Query";
        }

        protected override void AddClassHeader(Type m, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// 表示用于" + m.Name + "的查询接口。");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"[ServiceContract(Namespace ="+"\"http://www.UniCloud.com\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"public interface " + GetClassName(m.Name) +
                          "");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"{");
        }

        protected override void AddClassContent(Type m, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"#region Get " + m.Name + "");
            //QueryAll
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 获取所有" + m.Name + "");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns>所有的" + m.Name + "。</returns>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[OperationContract(Action ="+"\"http://www.UniCloud.com/I"
                                                            + GeneratorHelper.GetServiceName("Project") + "Service/Get" + m.Name + "s\", ReplyAction =" + "\"http://www.UniCloud.com/I" + GeneratorHelper.GetServiceName("Project") + "Service/Get" + m.Name + "sResponse\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[FaultContract(typeof(FaultData),Name =" + "\"FaultData\", Action=" + "\"http://www.UniCloud.com/I" + GeneratorHelper.GetServiceName("Project") + "Service/Get" + m.Name + "sDataFault\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"" + m.Name + "DataObjectList Get" + m.Name + "s(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter);");


           
            //GetPagination
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 获取所有" + m.Name + "分页信息");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"pagination\"></param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns>所有的" + m.Name + "分页信息。</returns>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[OperationContract(Action =" + "\"http://www.UniCloud.com/I"
                                                            + GeneratorHelper.GetServiceName("Project") + "Service/Get" + m.Name + "WithPagination\", ReplyAction =" + "\"http://www.UniCloud.com/I" + GeneratorHelper.GetServiceName("Project") + "Service/Get" + m.Name + "WithPaginationResponse\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[FaultContract(typeof(FaultData), Name =" + "\"FaultData\", Namespace=" + "\"http://schemas.datacontract.org/2004/07/UniCloud.DataObjects\", Action=" + "\"http://www.UniCloud.com/I" + GeneratorHelper.GetServiceName("Project") + "Service/Get" + m.Name + "WithPaginationDataFault\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"" + m.Name + "WithPagination Get" + m.Name + "WithPagination(Pagination pagination);");

            //QueryByID
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 通过" + m.Name + "Id获取相应的" + m.Name + "");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"id\"></param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns></returns>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[OperationContract(Action =" + "\"http://www.UniCloud.com/I"
                                                            + GeneratorHelper.GetServiceName("Project") + "Service/Get" + m.Name + "ByID\", ReplyAction =" + "\"http://www.UniCloud.com/I" + GeneratorHelper.GetServiceName("Project") + "Service/Get" + m.Name + "ByIDResponse\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[FaultContract(typeof(FaultData),Name =" + "\"FaultData\",Namespace=" + "\"http://schemas.datacontract.org/2004/07/UniCloud.DataObjects\" ,Action=" + "\"http://www.UniCloud.com/I" + GeneratorHelper.GetServiceName("Project") + "Service/Get" + m.Name + "ByIDDataFault\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) +
                          @"" + m.Name + "DataObject Get" + m.Name + "ByID(int id);");
         
            ////GetByNo
            //if (HasNoField(m))
            //{
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 通过" + m.Name + "No获取相应的" + m.Name + "");
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"no\"></param>");
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns></returns>");
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[OperationContract(Action =" + "\"http://www.UniCloud.com/I"
            //                                                    + m.Name + "Service/Get" + m.Name + "ByNo\", ReplyAction =" + "\"http://www.UniCloud.com/I" + m.Name + "Service/Get" + m.Name + "ByNoResponse\")]");
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[FaultContract(typeof(FaultData),Name =" + "\"FaultData\",Namespace=" + "\"http://schemas.datacontract.org/2004/07/UniCloud.DataObjects\", Action=" + "\"http://www.UniCloud.com/I" + m.Name + "Service/Get" + m.Name + "ByNoDataFault\")]");
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) +
            //                  @"" + m.Name + "DataObject Get" + m.Name + "ByNo(string no);");
            //}
            if (GetItemProperties(m) != null)
            {
                //GetItemsById
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 通过" + m.Name + "Id获取相应的" + m.Name + "Items");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"id\"></param>");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns></returns>");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[OperationContract(Action =" + "\"http://www.UniCloud.com/I"
                                                                + GeneratorHelper.GetServiceName("Project") + "Service/Get" + m.Name + "ItemsByID\", ReplyAction =" + "\"http://www.UniCloud.com/I" + GeneratorHelper.GetServiceName("Project") + "Service/Get" + m.Name + "ItemsByIDResponse\")]");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[FaultContract(typeof(FaultData),Name =" + "\"FaultData\",Namespace=" + "\"http://schemas.datacontract.org/2004/07/UniCloud.DataObjects\", Action=" + "\"http://www.UniCloud.com/I" + GeneratorHelper.GetServiceName("Project") + "Service/Get" + m.Name + "ItemsByIDDataFault\")]");
                sb.AppendLine(GeneratorHelper.GetTabString(2) +
                              @"" + m.Name + "ItemDataObjectList Get" + m.Name + "ItemsByID(int id);");
                //GetItemByItemID
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 通过" + m.Name + "Id和" + m.Name + "ItemId获取相应的" +
                              m.Name +
                              "Item");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"id\"></param>");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns></returns>");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[OperationContract(Action =" + "\"http://www.UniCloud.com/I"
                                                                + GeneratorHelper.GetServiceName("Project") + "Service/Get" + m.Name + "ItemByID\", ReplyAction =" + "\"http://www.UniCloud.com/I" + GeneratorHelper.GetServiceName("Project") + "Service/Get" + m.Name + "ItemByIDResponse\")]");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[FaultContract(typeof(FaultData),Name =" + "\"FaultData\",Namespace=" + "\"http://schemas.datacontract.org/2004/07/UniCloud.DataObjects\", Action=" + "\"http://www.UniCloud.com/I" + GeneratorHelper.GetServiceName("Project") + "Service/Get" + m.Name + "ItemByIDDataFault\")]");
                sb.AppendLine(GeneratorHelper.GetTabString(2) +
                              @"" + m.Name + "ItemDataObject Get" + m.Name + "ItemByID(int id, int itemId);");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            }

            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"#endregion");


            //DorpDownSource Collection By gyoung
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"#region " + m.Name + "DorpDownSource");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 获取" + m.Name + "下拉数据集合");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"colFilter\"></param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"sortFilter\"></param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns></returns>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[OperationContract(Action =" + "\"http://www.UniCloud.com/I"
                                                            + GeneratorHelper.GetServiceName("Project") + "Service/Get" + m.Name + "Col\", ReplyAction =" + "\"http://www.UniCloud.com/I" + GeneratorHelper.GetServiceName("Project") + "Service/Get" + m.Name + "ColResponse\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"[FaultContract(typeof(FaultData),Name =" + "\"FaultData\",Namespace=" + "\"http://schemas.datacontract.org/2004/07/UniCloud.DataObjects\" ,Action=" + "\"http://www.UniCloud.com/I" + GeneratorHelper.GetServiceName("Project") + "Service/Get" + m.Name + "ColDataFault\")]");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + 
                          @"KeyValueDataObjectList Get" + m.Name + "Col(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter);");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"#endregion");
            sb.AppendLine();

        }

        protected override void AddClassFooter(Type m, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"}");
        }

      
    }
}
