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
using System.Reflection;
using System.Text;
using BaseCodeTools.AutoGenerate.PropertyCode;

namespace BaseCodeTools.AutoGenerate.ClassCode
{
    public class QueryClass : BaseClassCode
    {
        public override string GetClassName(string modelName)
        {
            return modelName + "Query";
        }

        protected override void AddClassHeader(Type m, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// 表示用于" + m.Name + "的查询接口。");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"public class " + GetClassName(m.Name) +
                          ": I" + GetClassName(m.Name));
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"{");
        }

        private string GetMasterId(Type m)
        {
            if (m.Name.IndexOf("Invoice", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                return "InvoiceID";
            }
            else if (m.Name.Equals("PaymentPlan", StringComparison.InvariantCultureIgnoreCase))
            {
                return "PlanID";
            }
            else if (m.Name.Equals("PayNotification", StringComparison.InvariantCultureIgnoreCase))
            {
                return "NotificationID";
            }

            else if (m.Name.Equals("PrepayWriteOff", StringComparison.InvariantCultureIgnoreCase))
            {
                return "WriteOffID";
               
            }
            return m.Name +"ID";
        }

        private string GetMasterNo(Type m)
        {

            if (m.Name.Equals("PaymentPlan", StringComparison.InvariantCultureIgnoreCase))
            {
                return "PlanNo";
            }
            else if (m.Name.Equals("PayNotification", StringComparison.InvariantCultureIgnoreCase))
            {
                return "NotifyNo";
            }
            else if (m.Name.Equals("PrepayWriteOff", StringComparison.InvariantCultureIgnoreCase))
            {
                return "WriteOffNo";
            }
            else if (m.Name.Equals("CreditMemo", StringComparison.InvariantCultureIgnoreCase))
            {
                return "CreditMemoNo";
            }
            else if (m.Name.Equals("HRepairLG", StringComparison.InvariantCultureIgnoreCase))
            {
                return "LGNo";
            }
            else if (m.Name.Equals("LendLG", StringComparison.InvariantCultureIgnoreCase))
            {
                return "LGNo";
            }
            else if (m.Name.Equals("InvoiceBatch", StringComparison.InvariantCultureIgnoreCase))
            {
                return "";
            }
            else if (m.Name.Equals("InvoiceType", StringComparison.InvariantCultureIgnoreCase))
            {
                return "";
            }
            else if (m.Name.IndexOf("Invoice", StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                return "InvoiceNo";
            }
            return m.Name + "No";
        }

        protected override void AddClassContent(Type m, StringBuilder sb)
        {
            var itemPropertyInfos = GetItemProperties(m);

            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"private readonly UniCloudDbContextFRP _context;");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"public " + m.Name + "Query(IUniCloudDbContext context)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"_context = context as UniCloudDbContextFRP;");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"#region Query " + m.Name + "");
            //GetAll
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 获取所有" + m.Name + "");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns>所有的" + m.Name + "。</returns>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"public " + m.Name + "DataObjectList Get" + m.Name + "s(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"Expression<Func<" + m.Name +
                          ", bool>> source = p => true;");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"return Get" + m.Name + "List(source);");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");


            //GetPagination
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 获取所有" + m.Name + "分页信息");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"pagination\"></param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns>所有的" + m.Name + "分页信息。</returns>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"public " + m.Name + "WithPagination Get" + m.Name + "WithPagination(Pagination pagination)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"Expression<Func<" + m.Name +
                                   ", bool>> wherePredicate = p => true;");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"Expression<Func<" + m.Name +
                                  ", dynamic>> sortPredicate = t =>t.ID;");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"return Get" + m.Name + "Page(wherePredicate,sortPredicate,pagination);"); 
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");


            //GetByID
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 通过" + m.Name + "Id获取相应的" + m.Name + "");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"id\"></param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns></returns>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) +
                          @" public " + m.Name + "DataObject Get" + m.Name + "ByID(int id)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"Expression<Func<" + m.Name +
                          ", bool>> source = p => p.ID == id;");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"var result = Get" + m.Name + "List(source);");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"return result == null ? null : result.FirstOrDefault();");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            ////GetByNo
            //if (GetMasterNo(m) != "")
            //{
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 通过" + m.Name + "No获取相应的" + m.Name + "");
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"no\"></param>");
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns></returns>");
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) +
            //                  @" public " + m.Name + "DataObject Get" + m.Name + "ByNo(string no)");
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
            //    sb.AppendLine(GeneratorHelper.GetTabString(3) + @"Expression<Func<" + m.Name +
            //                  ", bool>> source = p => p." + GetMasterNo(m) + " == no;");
            //    sb.AppendLine(GeneratorHelper.GetTabString(3) + @"var result = Get" + m.Name + "List(source);");
            //    sb.AppendLine(GeneratorHelper.GetTabString(3) +
            //                  @"return result == null ? null : result.FirstOrDefault();");
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            //}
            if (itemPropertyInfos != null)
            {
                //GetItemsById
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 通过" + m.Name + "Id获取相应的" + m.Name + "Items");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"id\"></param>");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns></returns>");
                sb.AppendLine(GeneratorHelper.GetTabString(2) +
                              @" public " + m.Name + "ItemDataObjectList Get" + m.Name + "ItemsByID(int id)");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
                sb.AppendLine(GeneratorHelper.GetTabString(3) + @"Expression<Func<" + m.Name +
                              "Item, bool>> source = p => p." + GetMasterId(m) + " == id;");
                sb.AppendLine(GeneratorHelper.GetTabString(3) + @"return Get" + m.Name + "ItemList(source);");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
                //GetItemByItemId
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 通过" + m.Name + "ItemId获取相应的" + m.Name + "Item");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"id\"></param>");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"itemId\"></param>");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns></returns>");
                sb.AppendLine(GeneratorHelper.GetTabString(2) +
                              @" public " + m.Name + "ItemDataObject Get" + m.Name + "ItemByID(int id, int itemId)");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
                sb.AppendLine(GeneratorHelper.GetTabString(3) + @"Expression<Func<" + m.Name +
                              "Item, bool>> source = p => p." + GetMasterId(m) + " == id && p.ID == itemId;");
                sb.AppendLine(GeneratorHelper.GetTabString(3) + @"var result = Get" + m.Name + "ItemList(source);");
                sb.AppendLine(GeneratorHelper.GetTabString(3) +
                              @"return result == null ? null : result.FirstOrDefault();");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            }
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"#endregion");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            //private method
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"#region Common Query");

            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) +
                          @" private " + m.Name + "DataObjectList Get" + m.Name + "List(Expression<Func<" + m.Name +
                          ", bool>> source)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(3) +
                          @"var queryResult = (_context." + m.Name + "s.Where(source).Select(t => new " + m.Name +
                          "DataObject()");
            sb.AppendLine(GeneratorHelper.GetTabString(4) +
                          @"{");
            var propertyInfos = GetProperties(m);
            //Private declare
            var blNeedComma = false;
            foreach (PropertyInfo p in propertyInfos)
            {
                if (IsValidProperty(p))
                {
                    var ipc = PropertyCodeContainer.GetInstance().GetProertyCode(GetPropertyTypeName(p));
                    if (ipc == null)
                        continue;
                    ipc.QueryPropertyAssign(p, sb, ref blNeedComma);
                }
            }
            sb.AppendLine(GeneratorHelper.GetTabString(4) + @"})).ToList();");
            sb.AppendLine(GeneratorHelper.GetTabString(3) +
                          @"if (!queryResult.Any()) return new " + m.Name + "DataObjectList();");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"var transferResult = new " + m.Name +
                          "DataObjectList();");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"queryResult.ForEach(transferResult.Add);");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"return transferResult;");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");

            //GetPage
            sb.AppendLine(GeneratorHelper.GetTabString(2) +
                       @" private " + m.Name + "WithPagination Get" + m.Name + "Page(Expression<Func<" + m.Name +
                       ", bool>> wherePredicate,");
            sb.AppendLine(GeneratorHelper.GetTabString(6) +
                               @"Expression<Func<" + m.Name +
                       ", dynamic>> sortPredicate,");
            sb.AppendLine(GeneratorHelper.GetTabString(6) +
                   @"Pagination pagination)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) +@"{");

            sb.AppendLine(GeneratorHelper.GetTabString(3) +
                                        @"Expression<Func<" + m.Name +
                                "," + m.Name + "DataObject>> mapper=t=> new " + m.Name + "DataObject");
            sb.AppendLine(GeneratorHelper.GetTabString(4) +@"{");

            foreach (PropertyInfo p in propertyInfos)
            {
                if (IsValidProperty(p))
                {
                    var ipc = PropertyCodeContainer.GetInstance().GetProertyCode(GetPropertyTypeName(p));
                    if (ipc == null)
                        continue;
                    ipc.QueryPropertyAssign(p, sb, ref blNeedComma);
                }
            }
            sb.AppendLine(GeneratorHelper.GetTabString(4) +@"};");
            sb.AppendLine(GeneratorHelper.GetTabString(3) +
                          @"var "+m.Name+"Result = _context.LoadPageDataObjects<" + m.Name + "," + m.Name +
                          "DataObject>(wherePredicate, sortPredicate, pagination, mapper);");
            sb.AppendLine(GeneratorHelper.GetTabString(3) +
                          @"if(" + m.Name + "Result==null) return null;");
            sb.AppendLine(GeneratorHelper.GetTabString(3) +
                          @"pagination.TotalPages=" + m.Name + "Result.TotalPages;");
            sb.AppendLine(GeneratorHelper.GetTabString(3) +
                          @"var " + m.Name + "WithPagination= new " + m.Name + "WithPagination");
            sb.AppendLine(GeneratorHelper.GetTabString(4) +
                          @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(5) +
                          @"Pagination=pagination,");
            sb.AppendLine(GeneratorHelper.GetTabString(5) +
                          @"BaseDataObjectList = new BaseDataObjectList<"+m.Name+"DataObject>()");
            sb.AppendLine(GeneratorHelper.GetTabString(4) +
                          @"};");
            sb.AppendLine(GeneratorHelper.GetTabString(3) +
                          @"foreach (var value in "+ m.Name+"Result.Data)");
            sb.AppendLine(GeneratorHelper.GetTabString(4) +
                          @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(5) +
                          @""+m.Name+"WithPagination.BaseDataObjectList.Add(value);");
            sb.AppendLine(GeneratorHelper.GetTabString(4) +
                          @"}");
            sb.AppendLine(GeneratorHelper.GetTabString(4) +
                      @"return " + m.Name + "WithPagination;");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");

            //GetItemsById
            if (itemPropertyInfos != null)
            {
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
                sb.AppendLine(GeneratorHelper.GetTabString(2) +
                              @" private " + m.Name + "ItemDataObjectList Get" + m.Name + "ItemList(Expression<Func<" +
                              m.Name +
                              "Item, bool>> source)");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
                sb.AppendLine(GeneratorHelper.GetTabString(3) +
                              @"var queryResult = (_context." + m.Name + "Items.Where(source).Select(t => new " + m.Name +
                              "ItemDataObject()");
                sb.AppendLine(GeneratorHelper.GetTabString(4) +
                              @"{");
                //Private declare
                var blNeedCommaItem = false;
                foreach (PropertyInfo p in itemPropertyInfos)
                {
                    if (IsValidProperty(p))
                    {
                        var ipc = PropertyCodeContainer.GetInstance().GetProertyCode(GetPropertyTypeName(p));
                        if (ipc == null)
                            continue;
                        ipc.QueryPropertyAssign(p, sb, ref blNeedCommaItem);
                    }
                }
                sb.AppendLine(GeneratorHelper.GetTabString(4) + @"})).ToList();");
                sb.AppendLine(GeneratorHelper.GetTabString(3) +
                              @"if (!queryResult.Any()) return new " + m.Name + "ItemDataObjectList();");
                sb.AppendLine(GeneratorHelper.GetTabString(3) + @"var transferResult = new " + m.Name +
                              "ItemDataObjectList();");
                sb.AppendLine(GeneratorHelper.GetTabString(3) + @"queryResult.ForEach(transferResult.Add);");
                sb.AppendLine(GeneratorHelper.GetTabString(3) + @"return transferResult;");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");

            }
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"#endregion");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
        }

        protected override void AddClassFooter(Type m, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"}");
        }
    }
}
