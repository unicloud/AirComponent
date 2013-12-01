using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using UniCloud.DataObjects;
using UniCloud.Domain;
using UniCloud.Infrastructure;

namespace UniCloud.Query
{
    public static class QueryExtension
    {
        private static Expression<Func<TEntity, dynamic>> GetSortExpression<TEntity>(string sortPredicate)
            where TEntity : class
        {
            if (string.IsNullOrEmpty(sortPredicate)) return null;
            Type type = typeof(TEntity);
            ParameterExpression param = Expression.Parameter(type, "t");

            PropertyInfo property = type.GetProperty(sortPredicate);
            var sortExpression =
                Expression.Lambda<Func<TEntity, dynamic>>(
                    Expression.Convert(Expression.Property(param, property), typeof(object)),
                    new ParameterExpression[1]
                        {
                            param
                        });
            return sortExpression;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="TEntity">实体</typeparam>
        /// <typeparam name="TObject">DTO对象</typeparam>
        /// <param name="context">查询域上下文</param>
        /// <param name="wherelambda">查询表达式</param>
        /// <param name="sortPredicate">排序字段</param>
        /// <param name="pagination">分页信息</param>
        /// <param name="entityToObject"></param>
        /// <returns>分页查询结果</returns>
        public static PagedResult<TObject> LoadPageDataObjects<TEntity, TObject>(this DbContext context,
                    Expression<Func<TEntity, bool>> wherelambda,
                    Expression<Func<TEntity, dynamic>> sortPredicate,
                    Pagination pagination,
                    Expression<Func<TEntity, TObject>> entityToObject)
            where TEntity : class, IEntity
            where TObject : class
        {
            return LoadObjects(context, entityToObject, wherelambda, sortPredicate, SortOrder.Ascending, pagination);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="sortPredicate"></param>
        /// <param name="sortOrder"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        private static IQueryable<TEntity> SortQuery<TEntity, TObject>(IQueryable<TEntity> query,
                Expression<Func<TEntity, dynamic>> sortPredicate,
                SortOrder sortOrder)
            where TEntity : class, IEntity
            where TObject : class
        {
            if (sortPredicate != null)
            {
                switch (sortOrder)
                {
                    case SortOrder.Unspecified:
                        break;
                    case SortOrder.Ascending:
                        query = query.SortBy(sortPredicate);
                        break;
                    case SortOrder.Descending:
                        query = query.SortByDescending(sortPredicate);
                        break;
                }
            }

            return query;
        }

        /// <summary>
        ///     获取DTO对象
        /// </summary>
        /// <typeparam name="TEntity">实体</typeparam>
        /// <typeparam name="TObject">DTO对象</typeparam>
        /// <param name="context"></param>
        /// <param name="entityToObject">实体转化DTO</param>
        /// <param name="wherelambda">查询表达式</param>
        /// <param name="sortPredicate">排序表达式</param>
        /// <param name="sortOrder">排序的字段</param>
        /// <param name="pagination">分页信息</param>
        /// <returns>返回DTO对象</returns>
        public static PagedResult<TObject> LoadObjects<TEntity, TObject>(this DbContext context,
            Expression<Func<TEntity, TObject>> entityToObject,
            Expression<Func<TEntity, bool>> wherelambda,
            Expression<Func<TEntity, dynamic>> sortPredicate,
            SortOrder sortOrder,
            Pagination pagination)
            where TEntity : class, IEntity
            where TObject : class
        {
            if (pagination == null)
                throw new ArgumentNullException("pagination", "分页信息不能为空。");
            if (pagination.PageNumber <= 0)
                throw new ArgumentNullException("pagination", "页码必须大于或等于1。");
            if (pagination.PageSize <= 0)
                throw new ArgumentNullException("pagination", "每页大小必须大于或等于1。");
            if (sortPredicate == null)
                throw new InvalidOperationException("基于分页功能的查询必须指定排序字段和排序顺序。");
            //Where部分条件
            var query = context.Set<TEntity>().Where(wherelambda);
            //应用过滤
            var filter = pagination.FilterDescriptors.GetLambdaExpression<TEntity>();
            if (filter != null)
                query = query.Where(filter);
            //应用排序
            query = pagination.SortDescriptors.Count != 0
                        ? pagination.SortDescriptors.Aggregate(query,
                                                               (current, sortDescriptor) =>
                                                               SortQuery<TEntity, TObject>(current,
                                                                                           GetSortExpression<TEntity>
                                                                                               (sortDescriptor.
                                                                                                    SortPredicate),
                                                                                           sortDescriptor.SortOrder))
                        : SortQuery<TEntity, TObject>(query, sortPredicate, sortOrder);
            //分页取数
            var skip = (pagination.PageNumber - 1) * pagination.PageSize;
            var take = pagination.PageSize;
            var pagedGroup = query.Skip(skip)
                .Take(take)
                .Select(entityToObject)
                .GroupBy(p => new { Total = query.Count() }).FirstOrDefault();
            if (pagedGroup == null) return null;
            pagination.TotalItemCounts = pagedGroup.Key.Total;
            pagination.TotalPages = (pagedGroup.Key.Total + pagination.PageSize - 1) / pagination.PageSize;
            return new PagedResult<TObject>(pagination.TotalItemCounts,
                                            pagination.TotalPages,
                                            pagination.PageSize, pagination.PageNumber,
                                            pagedGroup.Select(p => p).ToList());
        }

        /// <summary>
        ///     获取DTO对象
        /// </summary>
        /// <typeparam name="TEntity">实体</typeparam>
        /// <typeparam name="TObject">DTO对象</typeparam>
        /// <param name="context"></param>
        /// <param name="entityToObject">实体转化DTO</param>
        /// <param name="wherelambda">查询表达式</param>
        /// <param name="sortPredicate">排序表达式</param>
        /// <param name="sortOrder">排序的字段</param>
        /// <returns>返回DTO对象</returns>
        public static List<TObject> LoadObjects<TEntity, TObject>(this DbContext context,
                                                                  Expression<Func<TEntity, TObject>> entityToObject,
                                                                  Expression<Func<TEntity, bool>> wherelambda,
                                                                  Expression<Func<TEntity, dynamic>> sortPredicate,
                                                                  SortOrder sortOrder)
            where TEntity : class, IEntity
            where TObject : class
        {
            if (wherelambda == null)
            {
                wherelambda = p => true;
            }
            if (entityToObject == null)
            {
                throw new ArgumentNullException("entityToObject", "entityToObject 不能为空。");
            }
            var query = context.Set<TEntity>().Where(wherelambda);
            query = SortQuery<TEntity, TObject>(query, sortPredicate, sortOrder);
            return query.Select(entityToObject).ToList();
        }


        /// <summary>
        ///     获取DTO对象
        /// </summary>
        /// <typeparam name="TEntity">实体</typeparam>
        /// <typeparam name="TObject">DTO对象</typeparam>
        /// <param name="context"></param>
        /// <param name="entityToObject">实体转化DTO</param>
        /// <param name="wherelambda">查询表达式</param>
        /// <param name="sortPredicate">排序表达式</param>
        /// <param name="sortOrder">排序的字段</param>
        /// <param name="action">action的操作</param>
        /// <returns>返回DTO对象</returns>
        public static List<TObject> LoadObjects<TEntity, TObject>(this DbContext context,
                                                         Expression<Func<TEntity, TObject>> entityToObject,
                                                         Expression<Func<TEntity, bool>> wherelambda,
                                                         Expression<Func<TEntity, dynamic>> sortPredicate,
                                                         SortOrder sortOrder,
                                                         Action<List<TObject>> action)
            where TEntity : class, IEntity
            where TObject : class
        {
            var result = LoadObjects(context, entityToObject, wherelambda, sortPredicate, sortOrder);
            if (action != null)
            {
                action(result);
            }
            return result;
        }

        /// <summary>
        ///     获取当个DTO对象
        /// </summary>
        /// <typeparam name="TEntity">实体</typeparam>
        /// <typeparam name="TObject">DTO</typeparam>
        /// <returns>返回单个DTO对象</returns>
        public static TObject LoadObject<TEntity, TObject>(this DbContext context,
                                                           Expression<Func<TEntity, TObject>> entityToObject,
                                                           Expression<Func<TEntity, bool>> wherelambda)
            where TEntity : class, IEntity
            where TObject : class
        {
            if (wherelambda == null)
            {
                wherelambda = p => true;
            }
            if (entityToObject == null)
            {
                throw new ArgumentNullException("entityToObject", "entityToObject 不能为空。");
            }
            var result = context.Set<TEntity>().Where(wherelambda).Select(entityToObject).FirstOrDefault();

            return result;

        }

        /// <summary>
        ///     获取当个DTO对象
        /// </summary>
        /// <typeparam name="TEntity">实体</typeparam>
        /// <typeparam name="TObject">DTO</typeparam>
        /// <returns>返回单个DTO对象</returns>
        public static TObject LoadObject<TEntity, TObject>(this DbContext context,
                                                           Expression<Func<TEntity, TObject>> entityToObject,
                                                           Expression<Func<TEntity, bool>> wherelambda,
                                                           Action<TObject> action)
            where TEntity : class, IEntity
            where TObject : class
        {
            var result = LoadObject(context, entityToObject, wherelambda);

            if (action != null)
            {
                action(result);
            }

            return result;
        }
    }
}
