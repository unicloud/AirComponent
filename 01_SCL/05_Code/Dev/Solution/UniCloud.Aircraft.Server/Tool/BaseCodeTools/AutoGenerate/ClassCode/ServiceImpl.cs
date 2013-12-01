#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：zhangnx 时间：2013/8/9 15:34:40
// 文件名：ServiceImpl
// 版本：V1.0.0
//
// 修改者： 时间： 
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;
using BaseCodeTools.AutoGenerate.PropertyCode;

namespace BaseCodeTools.AutoGenerate.ClassCode
{
    public class ServiceImpl : BaseClassCode
    {
        public override string GetClassName(string modelName)
        {
            return "" + modelName + "ServiceImpl";
        }

        protected override void AddClassHeader(Type m, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// 表示与" + m.Name + "相关的应用层服务的一种实现。");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"public class " + GetClassName(m.Name) +
                          " : ApplicationService, I" + m.Name + "Service, I" + m.Name + "Query");
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"{");
        }

        protected override void AddClassContent(Type m, StringBuilder sb)
        {
            //Private declare
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"#region Private Fields");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"private readonly I" + m.Name + "Repository _" +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Repository;");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"private readonly I" + m.Name + "Query _" +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Query;");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"private readonly IDomainService _domainService;");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"#endregion");
            // ctor
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"#region Ctor");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 初始化一个<c>" + m.Name + "ServiceImpl</c>类型的实例。");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"context\">用来初始化<c>" + m.Name +
                          "ServiceImpl</c>类型的仓储上下文实例。</param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"" +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Repository\">“" + m.Name + "”仓储实例。</param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"" +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Query\">“" +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Query”查询实例。</param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"domainService\">“领域服务”实例。</param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"public " + m.Name +
                          "ServiceImpl(IRepositoryContext context,");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"I" + m.Name + "Repository " +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Repository,");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"I" + m.Name + "Query " +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Query,");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"IDomainService domainService)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @": base(context)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"this._" +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Repository = " +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Repository;");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"this._" +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Query = " +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Query;");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"this._domainService = domainService;");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"#endregion");

            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"#region I" + m.Name + "Service");
            //create
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 创建" + m.Name + "。");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" +
                          "\"" + GeneratorHelper.LowercaseFirst(m.Name) + "s\">需要创建的" + m.Name + "。</param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns>创建的" + m.Name + "。</returns>");

            sb.AppendLine(GeneratorHelper.GetTabString(2) +
                          @"public " + m.Name + "DataObjectList Create" + m.Name + "s(" + m.Name + "DataObjectList " +
                          GeneratorHelper.LowercaseFirst(m.Name) + "s)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @" return PerformCreateObjects<" + m.Name +
                          "DataObjectList, " + m.Name + "DataObject, " + m.Name + ">(" +
                          GeneratorHelper.LowercaseFirst(m.Name) + "s, _" +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Repository);");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");
            //delete
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 删除" + m.Name + "信息。");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" +
                          "\"" + GeneratorHelper.LowercaseFirst(m.Name) + "IDs\">需要更新的" + m.Name + "信息的ID值。</param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"public IDList Delete" + m.Name + "s(IDList " +
                          GeneratorHelper.LowercaseFirst(m.Name) + "IDs)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @" PerformDeleteObjects(" +
                          GeneratorHelper.LowercaseFirst(m.Name) + "IDs, _" + GeneratorHelper.LowercaseFirst(m.Name) +
                          "Repository);");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @" return " +
                          GeneratorHelper.LowercaseFirst(m.Name)+"IDs;");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");
            //update
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 更新" + m.Name + "信息。");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" +
                          "\"" + GeneratorHelper.LowercaseFirst(m.Name) + "s\">需要更新的" + m.Name + "信息。</param>");

            sb.AppendLine(GeneratorHelper.GetTabString(2) +
                          @"public " + m.Name + "DataObjectList Update" + m.Name + "s(" + m.Name + "DataObjectList " +
                          GeneratorHelper.LowercaseFirst(m.Name) + "s)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"return PerformUpdateObjects<" + m.Name +
                          "DataObjectList, " + m.Name + "DataObject, " + m.Name + ">(" +
                          GeneratorHelper.LowercaseFirst(m.Name) + "s,");
            sb.AppendLine(GeneratorHelper.GetTabString(4) + @"_" + GeneratorHelper.LowercaseFirst(m.Name) +
                          "Repository,");
            sb.AppendLine(GeneratorHelper.GetTabString(4) + @"pdo => pdo.ID,");
            sb.AppendLine(GeneratorHelper.GetTabString(4) + @"(p, pdo) =>");
            sb.AppendLine(GeneratorHelper.GetTabString(4) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(4) + @"});");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");
            //commit
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 提交" + m.Name + "的增删改数据");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"" +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Data\"></param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns>提交成功的数据</returns>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) +
                          @"public " + m.Name + "ResultData Commit" + m.Name + "s(" + m.Name + "ResultData " +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Data)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
            // commit method
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"var resultData = new " + m.Name + "ResultData");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(4) + @"AddedCollection =");
            sb.AppendLine(GeneratorHelper.GetTabString(5) + @"new " + m.Name + "DataObjectList(),");
            sb.AppendLine(GeneratorHelper.GetTabString(4) + @"DeletedCollection = new List<string>(),");
            sb.AppendLine(GeneratorHelper.GetTabString(4) + @"ModefiedCollection =");
            sb.AppendLine(GeneratorHelper.GetTabString(5) + @"new " + m.Name + "DataObjectList()");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"};");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"var addList = new List<" + m.Name + ">();");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"IEnumerable<string> deleteList = new List<string>();");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"var updateList = new List<" + m.Name + ">();");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"#region Input");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(3) +
                          @"if (" +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Data.AddedCollection != null && " +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Data.AddedCollection.Any())");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(4) + @"" +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Data.AddedCollection.ForEach(");
            sb.AppendLine(GeneratorHelper.GetTabString(4) + @"p =>");
            sb.AppendLine(GeneratorHelper.GetTabString(5) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(6) +
                          @"addList.Add(Mapper.Map<" + m.Name + "DataObject, " + m.Name + ">(p));");
            sb.AppendLine(GeneratorHelper.GetTabString(5) + @"});");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"}");
            sb.AppendLine(GeneratorHelper.GetTabString(3) +
                          @"if (" +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Data.DeletedCollection != null && " +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Data.DeletedCollection.Any())");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(4) + @"deleteList = " +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Data.DeletedCollection;");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"}");
            sb.AppendLine(GeneratorHelper.GetTabString(3) +
                          @"if (" +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Data.ModefiedCollection != null && " +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Data.ModefiedCollection.Any())");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(4) + @"" +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Data.ModefiedCollection.ForEach(");
            sb.AppendLine(GeneratorHelper.GetTabString(5) +
                          @"p => updateList.Add(Mapper.Map<" + m.Name + "DataObject, " + m.Name + ">(p)));");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"}");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"#endregion");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(3) +
                          @"_" + GeneratorHelper.LowercaseFirst(m.Name) + "Repository.Commit" + m.Name + "(addList, deleteList, updateList);");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"#region Output");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(3) +
                          @"var addResults = new ObservableCollection<" + m.Name + "DataObject>();");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"if (addList.Any())");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(4) + @"addList.ForEach(");
            sb.AppendLine(GeneratorHelper.GetTabString(5) +
                          @"p => addResults.Add(Mapper.Map<" + m.Name + ", " + m.Name + "DataObject>(p)));");
            sb.AppendLine(GeneratorHelper.GetTabString(4) + @"resultData.AddedCollection = addResults;");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @" }");
            sb.AppendLine(GeneratorHelper.GetTabString(3) +
                          @"var updateResults = new ObservableCollection<" + m.Name + "DataObject>();");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"if (updateList.Any())");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(4) + @"updateList.ForEach(");
            sb.AppendLine(GeneratorHelper.GetTabString(5) +
                          @"p => updateResults.Add(Mapper.Map<" + m.Name + ", " + m.Name + "DataObject>(p)));");
            sb.AppendLine(GeneratorHelper.GetTabString(4) + @"resultData.ModefiedCollection = updateResults;");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @" }");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"if (deleteList != null && deleteList.Any())");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(4) + @"resultData.DeletedCollection = deleteList;");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"}");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"#endregion");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"return resultData;");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"#endregion");
            //Query
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"#region I" + m.Name + "Query");
            //get all
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 获取所有的" + m.Name + "信息。");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns>所有的" + m.Name + "信息。</returns>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"public " + m.Name + "DataObjectList Get" + m.Name
                + "s(ColumnFilterDescriptorCollection colFilter,ColumnSortDescriptorCollection sortFilter)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"return _" +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Query.Get" + m.Name
                          + "s(colFilter,sortFilter);");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");

            //get page
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 获取所有的" + m.Name + "分页信息。");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns>所有的" + m.Name + "分页信息。</returns>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"public " + m.Name + "WithPagination Get" + m.Name + "WithPagination(Pagination pagination)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"return _" +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Query.Get" + m.Name + "WithPagination(pagination);");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");

            // getbyid
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 通过" + m.Name + "Id获取相应的" + m.Name + "DataObject");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"id\"></param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns></returns>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"public " + m.Name + "DataObject Get" + m.Name +
                          "ByID(int id)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"return _" +
                          GeneratorHelper.LowercaseFirst(m.Name) + "Query.Get" + m.Name + "ByID(id);");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");


            //GetByID Method Add By Gyoung
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 通过" + m.Name + "Id获取相应的" + m.Name + "DataObject 有导航属性");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"id\"></param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns></returns>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"public " + m.Name + "DataObject GetFull" + m.Name +
                          "ByID(int id)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");

            sb.AppendLine(GeneratorHelper.GetTabString(3) + @" var result = _" + GeneratorHelper.LowercaseFirst(m.Name) +
                          "Repository.GetByKey(id);");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"return result!=null?Mapper.Map<" +
                          m.Name + "," + m.Name + "DataObject>(result) : null;");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");


            // GetAll Method Add By gyoung
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"///  获取所有的" + m.Name + "信息 有导航属性");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"id\"></param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns></returns>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"public " + m.Name + "DataObjectList GetFull" + m.Name +
                          "s()");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");

            sb.AppendLine(GeneratorHelper.GetTabString(3) + @" var results = _" + GeneratorHelper.LowercaseFirst(m.Name) +
                          "Repository.GetAll();");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"return results!=null?Mapper.Map<IEnumerable<" +
                          m.Name + ">," + m.Name + "DataObjectList>(results) : null;");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");

            // DropDownSource集合 Add By gyoung
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 获取" + m.Name + "下拉数据集合");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"colFilter\"></param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"sortFilter\"></param>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns></returns>");
            sb.AppendLine(GeneratorHelper.GetTabString(2) +
                       @"public KeyValueDataObjectList Get" + m.Name + "Col(ColumnFilterDescriptorCollection colFilter, ColumnSortDescriptorCollection sortFilter)");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
            sb.AppendLine(GeneratorHelper.GetTabString(3) + @"return _" +
                            GeneratorHelper.LowercaseFirst(m.Name) + "Query.Get" + m.Name + "Col(colFilter,sortFilter);");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");
            
            ////GetByNo
            //if (HasNoField(m))
            //{
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 通过" + m.Name + "No获取相应的" + m.Name + "");
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"no\"></param>");
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns></returns>");
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) +
            //                  @"public " + m.Name + "DataObject Get" + m.Name + "ByNo(string no)");
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
            //    sb.AppendLine(GeneratorHelper.GetTabString(3) + @"return _" +
            //                  GeneratorHelper.LowercaseFirst(m.Name) + "Query.Get" + m.Name + "ByNo(no);");
            //    sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");
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
                sb.AppendLine(GeneratorHelper.GetTabString(2) +
                              @"public " + m.Name + "ItemDataObjectList Get" + m.Name + "ItemsByID(string id)");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
                sb.AppendLine(GeneratorHelper.GetTabString(3) + @"return _" +
                              GeneratorHelper.LowercaseFirst(m.Name) + "Query.Get" + m.Name + "ItemsByID(id);");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");
                //GetItemByItemID
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <summary>");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// 通过" + m.Name + "Id和" + m.Name + "ItemId获取相应的" +
                              m.Name +
                              "Item");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// </summary>");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <param name=" + "\"id\"></param>");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"/// <returns></returns>");
                sb.AppendLine(GeneratorHelper.GetTabString(2) +
                              @"public " + m.Name + "ItemDataObject Get" + m.Name + "ItemByID(string id, string itemId)");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"{");
                sb.AppendLine(GeneratorHelper.GetTabString(3) + @"return _" +
                              GeneratorHelper.LowercaseFirst(m.Name) + "Query.Get" + m.Name + "ItemByID(id, itemId);");
                sb.AppendLine(GeneratorHelper.GetTabString(2) + @"}");
            }
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"");
            sb.AppendLine(GeneratorHelper.GetTabString(2) + @"#endregion");
        }

        protected override void AddClassFooter(Type m, StringBuilder sb)
        {
            sb.AppendLine(GeneratorHelper.GetTabString(1) + @"}");
        }
    }
}
