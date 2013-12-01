#region Version Info

/* ========================================================================
// 版权所有 (C) 2013 UniCloud 
//【本类功能概述】
// 
// 作者：chency 时间：2013/8/9 11:24:26
// 文件名：SortByExtension
// 版本：V1.0.0
//
// 修改者： 时间： 
// 修改说明：
// ========================================================================*/

#endregion

using System;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using UniCloud.Domain;

namespace UniCloud.Query
{
	public static class SortByExtension
	{
		#region Internal Methods

		internal static IOrderedQueryable<TEntity> SortBy<TEntity>(this IQueryable<TEntity> query,
		                                                           Expression<Func<TEntity, dynamic>> sortPredicate)
			where TEntity : class, IEntity
		{
			return InvokeSortBy(query, sortPredicate, SortOrder.Ascending);
		}

		internal static IOrderedQueryable<TEntity> SortByDescending<TEntity>(this IQueryable<TEntity> query,
		                                                                     Expression<Func<TEntity, dynamic>> sortPredicate)
			where TEntity : class, IEntity
		{
			return InvokeSortBy(query, sortPredicate, SortOrder.Descending);
		}

		#endregion

		#region Private Methods

		private static IOrderedQueryable<TEntity> InvokeSortBy<TEntity>(IQueryable<TEntity> query,
		                                                                Expression<Func<TEntity, dynamic>> sortPredicate,
		                                                                SortOrder sortOrder)
			where TEntity : class, IEntity
		{
			ParameterExpression param = sortPredicate.Parameters[0];
			string propertyName = null;
			Type propertyType = null;
			Expression bodyExpression = null;
			if (sortPredicate.Body is UnaryExpression)
			{
				var unaryExpression = sortPredicate.Body as UnaryExpression;
				bodyExpression = unaryExpression.Operand;
			}
			else if (sortPredicate.Body is MemberExpression)
			{
				bodyExpression = sortPredicate.Body;
			}
			else
				throw new ArgumentException(@"The body of the sort predicate expression should be 
                either UnaryExpression or MemberExpression.", "sortPredicate");
			var memberExpression = (MemberExpression) bodyExpression;
			propertyName = memberExpression.Member.Name;
			if (memberExpression.Member.MemberType == MemberTypes.Property)
			{
				var propertyInfo = memberExpression.Member as PropertyInfo;
				propertyType = propertyInfo.PropertyType;
			}
			else
				throw new InvalidOperationException(@"Cannot evaluate the type of property since the member expression 
                represented by the sort predicate expression does not contain a PropertyInfo object.");

			Type funcType = typeof (Func<,>).MakeGenericType(typeof (TEntity), propertyType);
			LambdaExpression convertedExpression = Expression.Lambda(funcType,
			                                                         Expression.Convert(
				                                                         Expression.Property(param, propertyName), propertyType),
			                                                         param);

			MethodInfo[] sortingMethods = typeof (Queryable).GetMethods(BindingFlags.Public | BindingFlags.Static);
			string sortingMethodName = GetSortingMethodName(sortOrder);
			MethodInfo sortingMethod = sortingMethods.Where(sm => sm.Name == sortingMethodName &&
			                                                      sm.GetParameters() != null &&
			                                                      sm.GetParameters().Length == 2).First();
			return (IOrderedQueryable<TEntity>) sortingMethod
				                                    .MakeGenericMethod(typeof (TEntity), propertyType)
				                                    .Invoke(null, new object[] {query, convertedExpression});
		}

		private static string GetSortingMethodName(SortOrder sortOrder)
		{
			switch (sortOrder)
			{
				case SortOrder.Ascending:
					return "OrderBy";
				case SortOrder.Descending:
					return "OrderByDescending";
				default:
					throw new ArgumentException("Sort Order must be specified as either Ascending or Descending.",
					                            "sortOrder");
			}
		}

		#endregion
	}
}