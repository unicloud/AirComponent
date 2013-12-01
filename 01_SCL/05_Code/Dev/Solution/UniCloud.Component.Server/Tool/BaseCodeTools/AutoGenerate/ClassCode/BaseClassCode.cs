#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：zhangnx 时间：2013/8/9 17:04:00
// 文件名：BaseClassCode
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
using BaseCodeTools.AutoGenerate.PropertyCode;

namespace BaseCodeTools.AutoGenerate.ClassCode
{
    public  abstract class BaseClassCode : IClassCode
    {

        /// <summary>
        /// 获取类名
        /// </summary>
        /// <param name="modelName">模块名称</param>
        /// <returns></returns>
        public abstract string GetClassName(string modelName);

        /// <summary>
        /// 判断是否为属性
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        protected virtual bool IsValidProperty(PropertyInfo p)
        {
            return !p.PropertyType.Name.StartsWith("ICollection") && p.Name != "UncommittedEvents";
        }

        /// <summary>
        /// 反射，获取属性
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public virtual PropertyInfo[] GetProperties(Type m)
        {
            return m.GetProperties(BindingFlags.GetProperty | BindingFlags.Instance |
                                                   BindingFlags.Public);
        }

        /// <summary>
        /// 反射，获取属性
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public virtual PropertyInfo[] GetItemProperties(Type m)
        {
            Assembly asm = GeneratorHelper.GetModelAssembly();
            Type[] types = asm.GetTypes();
            return (from type in types
                    where type.Name.Equals(m.Name + "Item", StringComparison.InvariantCultureIgnoreCase)
                    select type.GetProperties(BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public)).FirstOrDefault();
        }

        protected bool HasNoField(Type m)
        {
            return !m.Name.Equals("InvoiceType", StringComparison.CurrentCultureIgnoreCase)
                   && !m.Name.Equals("InvoiceBatch", StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// 判断是否为ID属性
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        protected virtual bool IsID(PropertyInfo p)
        {
            return p.Name.Equals("ID", StringComparison.InvariantCultureIgnoreCase);
        }

        protected virtual string GetPropertyTypeName(PropertyInfo p)
        {
           return BaseProperty.GetPropertyTypeName(p);
        }
        /// <summary>
        /// 添加类头部
        /// </summary>
        /// <param name="m"></param>
        /// <param name="sb"></param>
        protected abstract void AddClassHeader(Type m, StringBuilder sb);

        /// <summary>
        /// 添加类内容 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="sb"></param>
        protected abstract void AddClassContent(Type m, StringBuilder sb);

        /// <summary>
        /// 添加类结束
        /// </summary>
        /// <param name="m"></param>
        /// <param name="sb"></param>
        protected abstract void AddClassFooter(Type m, StringBuilder sb);

        /// <summary>
        /// 添加类代码 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="sb"></param>
        public virtual void AddClassCodePart(Type m, StringBuilder sb)
        {
            AddClassHeader(m, sb);
            AddClassContent(m, sb);
            AddClassFooter(m, sb);
        }
  
    }
}
