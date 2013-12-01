#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency 时间：2013/8/21 17:00:48
// 文件名：PartialClass
// 版本：V1.0.0
//
// 修改者： 时间： 
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BaseCodeTools.AutoGenerate.PropertyCode;

namespace BaseCodeTools.AutoGenerate.ClassCode {
	public class PartialClass : BaseClassCode
	{
		public override string GetClassName(string modelName) {
			return modelName + "DataObject.Partial";
		}


		/// <summary>
		/// 判断是否为属性
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		protected override bool IsValidProperty(PropertyInfo p) {
			return p.Name != "UncommittedEvents";
		}

		/// <summary>
		/// 反射，获取属性
		/// </summary>
		/// <param name="m"></param>
		/// <returns></returns>
		public override PropertyInfo[] GetProperties(Type m)
		{

			var dataAssembly = GeneratorHelper.GetDataObjectAssembly();
			var dataName = "UniCloud.DataObjects." + m.Name + "DataObject";
			if (dataAssembly.GetType(dataName) == null) return null;
			var dataType = dataAssembly.GetType(dataName);
			var modelProperties = m.GetProperties(BindingFlags.GetProperty | BindingFlags.Instance |
			                                      BindingFlags.Public);
			 return (dataType.GetProperties(BindingFlags.GetProperty | BindingFlags.Instance |
			                       BindingFlags.Public).Where(p=>modelProperties.All(t => t.Name != p.Name)&&p.Name!="Id")).ToArray();

		}


		protected override void AddClassHeader(Type m, StringBuilder sb) {
			sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// <summary>");
			sb.AppendLine(GeneratorHelper.GetTabString(1) + @"///" + m.Name + "DataObject");
			sb.AppendLine(GeneratorHelper.GetTabString(1) + @"/// </summary>");
			sb.AppendLine(GeneratorHelper.GetTabString(1) + @"public partial class " + m.Name + "DataObject");
			sb.AppendLine(GeneratorHelper.GetTabString(1) + @"{");
		}

		protected override void AddClassContent(Type m, StringBuilder sb) {
			var propertyInfos = GetProperties(m);
			if (propertyInfos == null) return;
			
			//Private declare
			foreach (var p in propertyInfos) {
				if (IsValidProperty(p)) {
					var ipc = PropertyCodeContainer.GetInstance().GetProertyCode(GetPropertyTypeName(p));
					if (ipc == null) continue;
					if (!IsID(p)) {
						ipc.DataObjectPrivateDeclare(p, sb);
					}
					else {
						ipc.DataObjectPrivateDeclare(p, sb);
					}
				}
			}
			sb.AppendLine(GeneratorHelper.GetTabString(1) + @"");
			//Property
			foreach (var p in propertyInfos) {
				if (IsValidProperty(p)) {
					var ipc = PropertyCodeContainer.GetInstance().GetProertyCode(GetPropertyTypeName(p));
					if (ipc == null) continue;
					if (!IsID(p)) {
						ipc.DataObjectPropertyServer(p, sb);
					}
					else {
						ipc.DataObjectPropertyServer(p, sb);
					}
				}
			}
		}
		protected override void AddClassFooter(Type m, StringBuilder sb) {
			sb.AppendLine(GeneratorHelper.GetTabString(1) + @"}");

		}

		
	}
}
