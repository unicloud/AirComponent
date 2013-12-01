#region Version Info
/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：zhangnx 时间：2013/8/27 17:25:31
// 文件名：RePositoriesHelper
// 版本：V1.0.0
//
// 修改者： 时间： 
// 修改说明：
// ========================================================================*/
#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UniCloud.Domain.Model;
using UniCloud.Domain.Repositories.EntityFramework;

namespace UniCloud.Domain.Repositories
{
    public class RepositoriesHelper
    {


        /// <summary>
        ///  update Items dst by src 
        /// </summary>
        /// <param name="srcItems"></param>
        /// <param name="dstItems"></param>
        /// <param name="items"></param>
        /// <param name="efContext"></param>
        /// <param name="addItem"></param> 

        public static void UpdateItems<TItem>(ICollection<TItem> srcItems, ICollection<TItem> dstItems, 
            DbSet<TItem> items, DbContext efContext,
            Action<TItem> addItem = null,Expression<Func<TItem,bool>> express=null)
            where TItem: class, IEntity

        {
            //if (srcItems == null || dstItems == null) return;
            ////数据库中没有，直接新增
            //if (!dstItems.Any())
            //{
            //    foreach (var srcItem in srcItems)
            //    {
            //        if (addItem != null)
            //        {
            //            addItem(srcItem);
            //        }
            //        efContext.Entry(srcItem).State = EntityState.Added;
            //    }
            //    return;
            //}
            ////传进来的是空集合，则删除数据库中集合
            //if (!srcItems.Any())
            //{
            //    foreach (var dstItem in dstItems)
            //    {
            //        efContext.Entry(dstItem).State = EntityState.Deleted;
            //    }
            //    return;
            //}
            ////遍历数据库中集合，与传入集合对比
            //foreach (var dstItem in dstItems)
            //{
            //    TItem srcItem;
            //    //传入集合中没有数据库现在ID，则认为是新增，如果有，则是修改
            //    if (express != null)
            //    {
            //        srcItem = srcItems.FirstOrDefault(express.Compile());
            //    }
            //    {
            //        srcItem = srcItems.FirstOrDefault(p => p.GetEntityID().Equals(dstItem.GetEntityID()));
            //    }
            //    if (srcItem == null)
            //    {
            //        efContext.Entry(dstItem).State = EntityState.Deleted;
            //    }
            //    else
            //    {
            //        items.Attach(dstItem);
            //        UpdateProperty(srcItem, dstItem);
            //    }
            //}
            ////遍历传入集合，与数据库集合对比
            //foreach (var srcItem in srcItems)
            //{
            //    TItem dstItem;
            //    if (express != null)
            //    {
            //        dstItem = dstItems.FirstOrDefault(express.Compile());
            //    }
            //    {
            //        dstItem = dstItems.FirstOrDefault(p => p.GetEntityID().Equals(srcItem.GetEntityID()));
            //    }
               
            //    if (dstItem != null) continue;
            //    if (addItem != null)
            //    {
            //        addItem(srcItem);
            //    }
            //    efContext.Entry(srcItem).State = EntityState.Added;
            //}
        }

        /// <summary>
        /// update dst by src 
        /// </summary>
        /// <param name="src"></param>
        /// <param name="dst"></param>
        public static void UpdateProperty(object src, object dst)
        {
            if (src == null || dst == null)
                throw new ArgumentNullException("src");


            PropertyInfo[] srcProperties = src.GetType()
                                    .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);

            PropertyInfo[] dstProperties = src.GetType()
                                    .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);

            foreach (var dstP in dstProperties)
            {
                if (dstP.PropertyType.Attributes.ToString().Contains("ClassSemanticsMask")) continue;
                var srcP = srcProperties.FirstOrDefault(p => p.Name.Equals(dstP.Name));
                if (srcP == null) continue;
                dstP.SetValue(dst, srcP.GetValue(src));
            }
        }

    }
}
